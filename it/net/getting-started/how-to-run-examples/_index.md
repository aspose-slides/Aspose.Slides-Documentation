---
title: Come eseguire gli esempi
type: docs
weight: 130
url: /it/net/how-to-run-examples/
keywords:
- esempi
- requisiti software
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esegui rapidamente gli esempi di Aspose.Slides per .NET: clona il repository, ripristina i pacchetti, quindi compila e testa le funzionalità per PPT, PPTX e ODP."
---
## **Requisiti software**
Prima di scaricare ed eseguire gli esempi, verifica e conferma che la tua configurazione soddisfi questi requisiti: 

- Visual Studio 2010 o versioni successive.
- NuGet Package Manager installato in Visual Studio. Verifica che la versione più recente dell'API NuGet sia installata in Visual Studio. 

Per le istruzioni sull'installazione di NuGet package manager, visita questa pagina: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Vai su **Tools** > **Options** > **NuGet Package Manager**.

1. Espandi **NuGet Package Manager** (facendo doppio clic su di esso) e poi seleziona **Package Sources**. 

1. Verifica e conferma che il parametro nuget.org sia selezionato. 

   Il progetto di esempio utilizza la funzionalità NuGet Automatic Package Restore, quindi è necessario disporre di una connessione Internet attiva. 

   Se non hai una connessione Internet attiva sulla macchina su cui intendi eseguire gli esempi, controlla [Installation](https://docs.aspose.com/slides/it/net/installation/) e aggiungi (manualmente) un riferimento a Aspose.Slides.dll nel progetto di esempio.
## **Scarica Aspose.Slides da GitHub**
Tutti gli esempi di Aspose.Slides per .NET sono ospitati su [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Puoi clonare il repository utilizzando il tuo client GitHub preferito o scaricare il file ZIP [qui](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Se scarichi il file ZIP, devi estrarne il contenuto in una cartella sul tuo computer. 

Tutti gli esempi sono memorizzati nella cartella **Examples**.

È presente un file di soluzione Visual Studio C#. I progetti sono stati creati in Visual Studio 2013, ma i file di soluzione sono compatibili con Visual Studio 2010 SP1 e versioni successive.

2. Apri il file di soluzione in Visual Studio e costruisci il progetto.

   Al primo avvio, le dipendenze vengono scaricate automaticamente tramite NuGet.

La cartella **Data** nella directory principale di **Examples** contiene i file di input utilizzati negli esempi C#. Devi scaricare la cartella **Data** insieme al progetto degli esempi.

3. Apri il file RunExamples.cs. Tutti gli esempi vengono richiamati da qui.

4. Decommenta gli esempi che desideri eseguire all'interno del progetto.

Sentiti libero di contattarci tramite i nostri forum se hai problemi a configurare o eseguire gli esempi.
## **Contribuisci**
Puoi contribuire al progetto aggiungendo o migliorando un esempio. Tutti gli esempi e i progetti dimostrativi nel repository sono open-source, quindi tu (e altre persone) puoi usarli liberamente nelle applicazioni.

Per contribuire, puoi fare fork del repository, modificare il codice sorgente e creare una pull request. Revisioneremo le modifiche. Se le riterremo utili, le aggiungeremo al repository.