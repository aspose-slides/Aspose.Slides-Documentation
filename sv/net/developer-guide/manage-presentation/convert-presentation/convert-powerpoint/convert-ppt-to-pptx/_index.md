---
title: Konvertera PPT till PPTX i .NET
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/net/convert-ppt-to-pptx/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- PPT till PPTX
- spara PPT som PPTX
- exportera PPT till PPTX
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i .NET med Aspose.Slides. Inkluderar C#-exempel för enstaka fil- och batchkonvertering, felhantering och noggrannhetsnoteringar."
---
## **Översikt**

PPT är det äldre binära PowerPoint-formatet, medan PPTX är det nyare Open XML-formatet. Aspose.Slides för .NET kan läsa in en PPT-fil och spara den som PPTX utan Microsoft PowerPoint. Den här artikeln visar hur man konverterar en fil eller en katalog med filer och förklarar vad man ska verifiera efter konverteringen.

## **Konvertera en PPT-fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och anropa sedan [IPresentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/). `using`-deklarationen frigör presentationen och släpper dess resurser när scopet avslutas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Läs in den äldre PPT-presentationen.
using var presentation = new Presentation("presentation.ppt");

// Spara presentationen i PPTX-format.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Filändelsen väljer inte utdataformatet av sig själv; argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) gör det. Håll in- och utdata-sökvägarna olika om du behöver behålla den ursprungliga PPT-filen.

## **Konvertera flera PPT-filer**

Följande exempel konverterar varje `.ppt`-fil i en katalog. Varje fil bearbetas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utfil får skrivas över, och skriv namn på misslyckade filer till en återförsök- eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och ej stödt innehåll kan alla orsaka att en konvertering misslyckas. Se [Password-Protected Presentations](/slides/sv/net/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar vanligtvis bilder, masterbilder, layouter, text, former, bilder, tabeller och diagram. Däremot representerar PPT och PPTX inte varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande i PPTX, eller som inte stöds av biblioteket, kan normaliseras, uteslutas eller visas annorlunda.

Kontrollera den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE-objekt, ActiveX-kontroller, inbäddade media, ovanliga teckensnitt eller VBA-makron. En vanlig PPTX-fil är inte ett makro-aktiverat format, så använd ett lämpligt makro-aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX-filen programatiskt igen och inspektera viktiga antal bilder och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Behandla inte ett lyckat anrop av [IPresentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/) som ett bevis på att varje äldre funktion har en exakt PPTX-representation.

## **När du ska använda PPTX**

Använd PPTX när presentationen ska redigeras i nuvarande versioner av PowerPoint, utbytas med system som arbetar med Open XML-paket, eller lagras i ett format som är enklare att undersöka och återställa än det äldre binära PPT-formatet. Behåll den ursprungliga PPT-filen som ett arkiv- eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller en annan utmatningstyp, använd den format-specifika vägledningen i [Convert Presentations to Multiple Formats](/slides/sv/net/convert-presentation/) snarare än att anta att alla mål bevarar redigerbara PowerPoint-funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT till PPTX konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch-bearbetning eller felhantering på applikationsnivå, använd .NET-API-et.

## **Relaterade artiklar**

- [PPT vs PPTX](/slides/sv/net/ppt-vs-pptx/)
- [Spara presentationer i .NET](/slides/sv/net/save-presentation/)
- [Stödda filformat](/slides/sv/net/supported-file-formats/)
- [Öppna presentationer i .NET](/slides/sv/net/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides för .NET läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet garanteras inte för varje äldre eller ej‑stött funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen läses in. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Bör jag radera PPT‑filen efter konvertering?**

Behåll originalen tills du har verifierat PPTX-filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.