---
title: Hur du kör exempel
type: docs
weight: 130
url: /sv/net/how-to-run-examples/
keywords:
- exempel
- programvarukrav
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kör Aspose.Slides för .NET-exempel snabbt: klona repot, återställ paket, bygg sedan och testa funktioner för PPT, PPTX och ODP."
---
## **Programvarukrav**
Innan du laddar ner och kör exemplen, kontrollera och bekräfta att din miljö uppfyller dessa krav: 

- Visual Studio 2010 eller högre.
- NuGet Package Manager installerad i Visual Studio. Verifiera att den senaste NuGet API‑versionen är installerad i Visual Studio. 

För instruktioner om hur du installerar NuGet Package Manager, gå till den här sidan: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Gå till **Tools** > **Options** > **NuGet Package Manager**.
1. Expandera **NuGet Package Manager** (genom att dubbelklicka på den) och välj sedan **Package Sources**. 
1. Kontrollera och bekräfta att parametern nuget.org är markerad. 

   Exempelprojektet använder funktionen NuGet Automatic Package Restore, så du behöver ha en aktiv internetanslutning. 

   Om du inte har en aktiv internetanslutning på maskinen där du avser att köra exemplen, kontrollera [Installation](https://docs.aspose.com/slides/sv/net/installation/) och (manuellt) lägg till en referens till Aspose.Slides.dll i exempelprojektet.
## **Ladda ner Aspose.Slides från GitHub**
Alla Aspose.Slides för .NET‑exempel finns på [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Du kan antingen klona repot med din föredragna GitHub‑klient eller ladda ner ZIP‑filen [här](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Om du laddar ner ZIP‑filen måste du packa upp dess innehåll till en mapp på din dator. 

Alla exempel lagras i mappen **Examples**.

Det finns en C#‑Visual‑Studio‑lösningsfil. Projekten skapades i Visual Studio 2013, men lösningsfilerna är kompatibla med Visual Studio 2010 SP1 och senare.

2. Öppna lösningsfilen i Visual Studio och bygg projektet.

   Vid första körningen hämtas beroenden automatiskt via NuGet.

Mappen **Data** i rotmappen för **Examples** innehåller indatafiler som används i C#‑exemplen. Du måste ladda ner mappen **Data** tillsammans med exempelprojektet.

3. Öppna filen RunExamples.cs. Alla exempel anropas härifrån.

4. Avkommentera de exempel du vill köra i projektet.

Tveka inte att kontakta oss via våra forum om du har problem med att konfigurera eller köra exemplen.
## **Bidra**
Du kan bidra till projektet genom att lägga till eller förbättra ett exempel. Alla exempel och showcase‑projekt i repot är öppen källkod, så du (och andra) kan använda dem fritt i applikationer.

För att bidra kan du fork:a repot, redigera källkoden och skapa en pull‑request. Vi kommer att granska ändringarna. Om vi finner dem användbara lägger vi till dem i repot.