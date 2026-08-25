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
description: "Konvertera äldre PPT-filer till PPTX i C++ med Aspose.Slides. Inkluderar C++-exempel för enkelfil- och batchkonvertering, felhantering och noteringar om trogenhet."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för C++ kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som bör verifieras efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/), anropa sedan [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/). Frigör presentationen när den inte längre behövs för att släppa dess resurser.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Läs in den äldre PPT-presentationen.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Spara presentationen i PPTX-format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Filändelsen bestämmer inte utmatningsformatet i sig; argumentet [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/) gör det. Håll in‑ och utdatavägarna olika om du måste behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

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

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan erforderligt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla leda till att en konvertering misslyckas. Se [Password-Protected Presentations](/slides/sv/cpp/password-protected-presentation/) för att läsa in krypterade filer.

## **Fidelity och äldre funktioner**

Konvertering bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. PPT och PPTX representerar dock inte varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande i PPTX, eller som inte stöds av biblioteket, kan normaliseras, uteslutas eller visas annorlunda.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade medier, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att erforderliga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programatiskt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Behandla inte ett lyckat anrop av [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) som ett bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När du bör använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina kontrolltest för trogenhet.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utdata‑typ, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/slides/sv/cpp/convert-presentation/) i stället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT to PPTX converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑bearbetning eller felhantering på applikationsnivå, använd C++‑API‑et.

## **Relaterade artiklar**

- [Spara presentationer i C++](/slides/sv/cpp/save-presentation/)
- [Filformat som stöds](/slides/sv/cpp/supported-file-formats/)
- [Öppna presentationer i C++](/slides/sv/cpp/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides för C++ läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt trogenhet garanteras inte för varje äldre eller ostrukturerad funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord vid inläsning av filen. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Bör jag ta bort PPT‑filen efter konvertering?**

Behåll originalet tills du har verifierat PPTX i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras på ett annat sätt.