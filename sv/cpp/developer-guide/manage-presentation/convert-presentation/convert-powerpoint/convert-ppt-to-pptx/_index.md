---
title: Konvertera PPT till PPTX i C++
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/cpp/convert-ppt-to-pptx/
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
- C++
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i C++ med Aspose.Slides. Inkluderar C++-exempel för enkel-fil- och batch-konvertering, felhantering och noteringar om noggrannhet."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för C++ kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som bör kontrolleras efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och anropa sedan [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/). Frigör presentationen när den inte längre behövs för att släppa dess resurser.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Filändelsen väljer inte utdataformatet i sig; argumentet [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/) gör det. Håll indata‑ och utdata‑sökvägarna olika om du måste behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av satsen.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

För produktionsmiljöer, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsöknings‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och ej stödt innehåll kan alla leda till att konverteringen misslyckas. Se [Password-Protected Presentations](/cpp/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konvertering bevarar normalt bilder, master‑bilder, layout, text, former, bilder, tabeller och diagram. PPT och PPTX representerar dock inte varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande i PPTX, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas annorlunda.

Kontrollera den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade media, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makronligt format, så använd ett lämpligt makro‑stött arbetsflöde när VBA måste vara tillgängligt. Verifiera även att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programatiskt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop till [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När man ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella versioner av PowerPoint, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller en annan utmatningstyp, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) i stället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Onlinekonverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT to PPTX converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑bearbetning eller felhantering på applikationsnivå, använd C++‑API:t.

## **Relaterade artiklar**

- [Spara presentationer i C++](/cpp/save-presentation/)
- [Stödda filformat](/cpp/supported-file-formats/)
- [Öppna presentationer i C++](/cpp/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan Microsoft PowerPoint installerat?**

Ja. Aspose.Slides för C++ läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanlig presentationsinnehåll, men exakt trohet garanteras inte för varje äldre eller ej stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord vid inläsning av filen. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag radera PPT‑filen efter konvertering?**

Behåll originalfilen tills du har verifierat PPTX‑filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia ifall en äldre funktion konverteras annorlunda.