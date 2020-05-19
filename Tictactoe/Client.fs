namespace Tictactoe

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.UI.Html
open System.Collections.Generic


// TODO
// 
// Ha nem nyert, akkor az AI lép, és ismét megnézzük nyert-e, csak most az AI-ra. Ha az AI nyert, akkor szintén blockolunk minden további lépést
// Az AI lépést mondjuk megoldhatjuk úgy, hogy végig megy mindkét lépéstároló tömbbön egy ciklus, és ha bármelyikben van a pozíció érték, akkor számol +1-et. Ezután egy random generátorral
// generálunk egy számot 1-tõl az üres helyek számá-ig, majd újra végigmegyünk a tömbbön, és a randomadik helyre berakunk egy lépést. 
// Ez az AI ugye nem rendelkezik logikával, teljesen random módon mûködik
// 
// 
// Írjuk ki hogy ki nyert, vagy hogy döntetlen lett-e a játék
// 
// 
// 
// 
// 





[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>


    [<SPAEntryPoint>]

    let Main () =
        let mutable gameCell0 = Var.Create ""
        let mutable gameCell1 = Var.Create ""
        let mutable gameCell2 = Var.Create ""
        let mutable gameCell3 = Var.Create ""
        let mutable gameCell4 = Var.Create ""
        let mutable gameCell5 = Var.Create ""
        let mutable gameCell6 = Var.Create ""
        let mutable gameCell7 = Var.Create ""
        let mutable gameCell8 = Var.Create ""

        let mutable hardMode = Var.Create false

        let mutable gameIsOver = Var.Create false

        let mutable endresult = Var.Create ""

        let mutable aiplace = Var.Create 0
        // A két lista ami megjegyzi a játék állást
        // let mutable playerList = [false; false; false; false; false; false; false; false; false;]
        // let mutable AIList = [false; false; false; false; false; false; false; false; false;]
        
        let AIList = new List<bool>()
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)
        AIList.Add(false)


        let playerList = new List<bool>()
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)
        playerList.Add(false)

        // Lista ami a nyertes kombókat tartalmazza
        // let mutable winList = [[0; 1; 2]; [3; 4; 5]; [6; 7; 8]; [0; 4; 8]; [2; 4; 6]; [0; 3; 6]; [1; 4; 7]; [2; 5; 8]]


        // Függvény ami megnézi nyert-e valaki
        let CheckWin(plist: List<bool>) =
            if ( plist.[0] = true && plist.[1] = true && plist.[2] = true ) || ( plist.[3] = true && plist.[4] = true && plist.[5] = true ) || ( plist.[6] = true && plist.[7] = true && plist.[8] = true ) || ( plist.[0] = true && plist.[4] = true && plist.[8] = true ) || ( plist.[2] = true && plist.[4] = true && plist.[6] = true ) || ( plist.[0] = true && plist.[3] = true && plist.[6] = true ) || ( plist.[1] = true && plist.[4] = true && plist.[7] = true ) || ( plist.[2] = true && plist.[5] = true && plist.[8] = true ) then
                true
            else
                false
        
        // Megnézi döntetlen-e, ez ugye akkor van ha tele lett az összes mezõ, de senki nem nyert
        let checkDraw(plist: List<bool>, ailist: List<bool>) =
            if ( plist.[0] = true || ailist.[0] = true ) && ( plist.[1] = true || ailist.[1] = true ) && ( plist.[2] = true || ailist.[2] = true ) && ( plist.[3] = true || ailist.[3] = true ) && ( plist.[4] = true || ailist.[4] = true ) && ( plist.[5] = true || ailist.[5] = true ) && ( plist.[6] = true || ailist.[6] = true ) && ( plist.[7] = true || ailist.[7] = true ) && ( plist.[8] = true || ailist.[8] = true ) then
                true
            else
                false

        // Beveszi a 2 játék listánkat, és keres egy helyet ahova az AI rakhat
        let AIStep(plist: List<bool>, ailist: List<bool>) =
            let mutable counter = 0
            let mutable retval = 0
            
            // Ez a for megszámolja nekünk az üres helyek számát, ahova az AI tehet
            for i in 0 .. ((plist.Count)-1) do
                if plist.[i] = false && ailist.[i] = false then
                    counter <- counter + 1
                else
                    counter <- counter + 0
            // Rand init
            let rand = System.Random()
            // Generáljunk egy random számot 1 és counter + 1 között, ide fogjuk tenni az AI lépést
            let choice = rand.Next(1, counter+1)
            counter <- 0
            // Végigmegyünk még 1x a listán, és ahol a kapott randomunk egyezik a counterrel oda fogunk pakolni
            for i in 0 .. ((plist.Count)-1) do
                if plist.[i] = false && ailist.[i] = false then
                    counter <- counter + 1
                    // printfn "Choice: %d" choice      // debug
                    // printfn "counter: %d" counter    // debug
                    if choice = counter then
                        retval <- i
                    else
                        ()
                else
                    counter <- counter + 0
            // printfn "retval: %d" retval              // debug
            retval



        // Minimax algoritmus által vezérelt Tic-Tac-Toe AI
        //let hardAIStep ( = 
        //    let asd = 0
        //    asd



        IndexTemplate.Main()

            .endgamevar(
                endresult
            )

            .cell0var(
                gameCell0
            )      
            

            .cell1var(
                gameCell1
            )


            .cell2var(
                gameCell2
            )


            .cell3var(
                gameCell3
            )


            .cell4var(
                gameCell4
            )


            .cell5var(
                gameCell5
            )


            .cell6var(
                gameCell6
            )


            .cell7var(
                gameCell7
            )


            .cell8var(
                gameCell8
            )


            // Mindent alaphelyzetbe állít
            .startGameEasy(fun _ ->
                playerList.[0] <- false
                playerList.[1] <- false
                playerList.[2] <- false
                playerList.[3] <- false
                playerList.[4] <- false
                playerList.[5] <- false
                playerList.[6] <- false
                playerList.[7] <- false
                playerList.[8] <- false

                AIList.[0] <- false
                AIList.[1] <- false
                AIList.[2] <- false
                AIList.[3] <- false
                AIList.[4] <- false
                AIList.[5] <- false
                AIList.[6] <- false
                AIList.[7] <- false
                AIList.[8] <- false

                // Reset logikai változó, amiben a játék vége érték van
                gameIsOver.Value <- false

                // Reseteljük a játékcellákat
                gameCell0.Value <- ""
                gameCell1.Value <- ""
                gameCell2.Value <- ""
                gameCell3.Value <- ""
                gameCell4.Value <- ""
                gameCell5.Value <- ""
                gameCell6.Value <- ""
                gameCell7.Value <- ""
                gameCell8.Value <- ""

                // Reseteljük a nyertes szöveget
                endresult.Value <- ""

                // Állítsuk easyre az AI-t
                hardMode.Value <- false

            )

            .startGameHard(fun _ ->
                playerList.[0] <- false
                playerList.[1] <- false
                playerList.[2] <- false
                playerList.[3] <- false
                playerList.[4] <- false
                playerList.[5] <- false
                playerList.[6] <- false
                playerList.[7] <- false
                playerList.[8] <- false

                AIList.[0] <- false
                AIList.[1] <- false
                AIList.[2] <- false
                AIList.[3] <- false
                AIList.[4] <- false
                AIList.[5] <- false
                AIList.[6] <- false
                AIList.[7] <- false
                AIList.[8] <- false

                // Reset logikai változó, amiben a játék vége érték van
                gameIsOver.Value <- false

                // Reseteljük a játékcellákat
                gameCell0.Value <- ""
                gameCell1.Value <- ""
                gameCell2.Value <- ""
                gameCell3.Value <- ""
                gameCell4.Value <- ""
                gameCell5.Value <- ""
                gameCell6.Value <- ""
                gameCell7.Value <- ""
                gameCell8.Value <- ""

                // Reseteljük a nyertes szöveget
                endresult.Value <- ""

                // Állítsuk easyre az AI-t
                hardMode.Value <- true

            )

            .cell0(fun _ ->
            // Megnézzük elõször van-e benne player által rakott dolog, ha van akkor ugyanazt beletesszük még 1x mert az if és else ágaknak ugyanazzal kell visszatérni. Ha nincs, akkor vizsgáljuk,
            // hogy van-e benne AI által rakott cucc, ha van beletesszük ugyanazt, ha nincs akkor beleteszünk egy player lépést.
                if gameIsOver.Value = false then                        // Megnézzük vége-e a játéknak, ha igen, akkor nem reagálunk a kattintásra
                    if playerList.[0] = true then                       // Ha nincs vége, akkor megnézzük, van-e már a kattintott mezõben player karakter
                        gameCell0.Value <- "O"                          // Ha van akkor megint beletesszük ugyanazt, az ártani nem fog
                    else                                                // Ha nincs, akkor jöhet a vizsgálat hogy van-e benne AI karakter
                        if AIList.[0] = true then                       // Van-e benne AI karakter
                            gameCell0.Value <- "X"                      // Ha van, akkor beletesszük megint ugyanazt, az nem árt
                        else                                            // Ha nincs benne se player sem AI karakter
                            gameCell0.Value <- "O"                      // Tegyünk bele egy player karaktert
                            playerList.[0] <- true                      // állítsuk be, hogy van a mezõben karakter innentõl
                            if CheckWin playerList then                 // Nézzük meg nyert-e a player a legutóbbi lépésének hatására
                                gameIsOver.Value <- true                // Ha nyert, állítsuk be a vége a játéknak logikai kapcsolót igazra
                                endresult.Value <- "Player wins!"       // Írjuk ki a "Player wins!" szöveget
                            else                                        // Ha nem nyert a player
                                if checkDraw(playerList, AIList) = true then    // Nézzük meg döntetlen-e
                                    endresult.Value <- "It's a draw!"           // Ha döntetlen írjuk ki és állítsuk be a játék végét
                                    gameIsOver.Value <- true
                                else                                            // Ha nem döntetlen, akkor nyilván még nincs vége a játéknak
                                    gameIsOver.Value <- false                   // Ekkor kell az AI-nak lépni egyet

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       // Kell egy fv. ami visszaadja, hogy hányadik lista mezõbe tegyük bele az AI lépést
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    // printfn "%d" aiplace                     // debug
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false

                else                                                // Ide megyünk be, ha vége a játéknak
                    gameIsOver.Value <- true
            )


            .cell1(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[1] = true then
                        gameCell1.Value <- "O"
                    else
                        if AIList.[1] = true then
                            gameCell1.Value <- "X"
                        else
                            gameCell1.Value <- "O"
                            playerList.[1] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"     
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                    gameIsOver.Value <- true
            )


            .cell2(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[2] = true then
                        gameCell2.Value <- "O"
                    else
                        if AIList.[2] = true then
                            gameCell2.Value <- "X"
                        else
                            gameCell2.Value <- "O"
                            playerList.[2] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell3(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[3] = true then
                        gameCell3.Value <- "O"
                    else
                        if AIList.[3] = true then
                            gameCell3.Value <- "X"
                        else
                            gameCell3.Value <- "O"
                            playerList.[3] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                   //if hardMode.Value = true then
                                   //    aiplace.Value <- hardAIStep
                                   //    ()
                                   //else
                                   //    aiplace.Value <- AIStep(playerList, AIList)       
                                   //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell4(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[4] = true then
                        gameCell4.Value <- "O"
                    else
                        if AIList.[4] = true then
                            gameCell4.Value <- "X"
                        else
                            gameCell4.Value <- "O"
                            playerList.[4] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell5(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[5] = true then
                        gameCell5.Value <- "O"
                    else
                        if AIList.[5] = true then
                            gameCell5.Value <- "X"
                        else
                            gameCell5.Value <- "O"
                            playerList.[5] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell6(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[6] = true then
                        gameCell6.Value <- "O"
                    else
                        if AIList.[6] = true then
                            gameCell6.Value <- "X"
                        else
                            gameCell6.Value <- "O"
                            playerList.[6] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell7(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[7] = true then
                        gameCell7.Value <- "O"
                    else
                        if AIList.[7] = true then
                            gameCell7.Value <- "X"
                        else
                            gameCell7.Value <- "O"
                            playerList.[7] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .cell8(fun _ ->
                if gameIsOver.Value = false then
                    if playerList.[8] = true then
                        gameCell8.Value <- "O"
                    else
                        if AIList.[8] = true then
                            gameCell8.Value <- "X"
                        else
                            gameCell8.Value <- "O"
                            playerList.[8] <- true
                            if CheckWin playerList then
                                gameIsOver.Value <- true
                                endresult.Value <- "Player wins!"
                            else                                        
                                if checkDraw(playerList, AIList) = true then    
                                    endresult.Value <- "It's a draw!"           
                                    gameIsOver.Value <- true
                                else                                        
                                    gameIsOver.Value <- false                 

                                    //if hardMode.Value = true then
                                    //    aiplace.Value <- hardAIStep
                                    //    ()
                                    //else
                                    //    aiplace.Value <- AIStep(playerList, AIList)       
                                    //    ()
                                    aiplace.Value <- AIStep(playerList, AIList)
                                    if aiplace.Value = 0 then
                                        gameCell0.Value <- "X"
                                        AIList.[0] <- true
                                    elif aiplace.Value = 1 then
                                        gameCell1.Value <- "X"
                                        AIList.[1] <- true
                                    elif aiplace.Value = 2 then
                                        gameCell2.Value <- "X"
                                        AIList.[2] <- true
                                    elif aiplace.Value = 3 then
                                        gameCell3.Value <- "X"
                                        AIList.[3] <- true
                                    elif aiplace.Value = 4 then
                                        gameCell4.Value <- "X"
                                        AIList.[4] <- true
                                    elif aiplace.Value = 5 then
                                        gameCell5.Value <- "X"
                                        AIList.[5] <- true
                                    elif aiplace.Value = 6 then
                                        gameCell6.Value <- "X"
                                        AIList.[6] <- true
                                    elif aiplace.Value = 7 then
                                        gameCell7.Value <- "X"
                                        AIList.[7] <- true
                                    else
                                        gameCell8.Value <- "X"
                                        AIList.[8] <- true
                                    if CheckWin AIList then
                                        gameIsOver.Value <- true
                                        endresult.Value <- "AI wins!"
                                    else
                                        gameIsOver.Value <- false
                else
                     gameIsOver.Value <- true
            )


            .Doc()
        |> Doc.RunById "main"
