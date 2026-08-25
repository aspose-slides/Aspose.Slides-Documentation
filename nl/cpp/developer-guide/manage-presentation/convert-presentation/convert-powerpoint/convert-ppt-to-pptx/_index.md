---
title: Converteer PPT naar PPTX in C++
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPT naar PPTX
- PPT opslaan als PPTX
- PPT exporteren naar PPTX
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Converteer legacy PPT-bestanden naar PPTX in C++ met Aspose.Slides. Inclusief C++-voorbeelden voor enkelvoudige en batchconversie, foutafhandeling en nauwkeurigheidsopmerkingen."
---
## **Overzicht**

PPT is het oudere binaire PowerPoint-formaat, terwijl PPTX het nieuwere Open XML-formaat is. Aspose.Slides for C++ kan een PPT-bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel toont hoe één bestand of een map met bestanden te converteren en legt uit wat er na de conversie gecontroleerd moet worden.

## **Converteer een PPT-bestand naar PPTX**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-klasse, roep vervolgens [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) aan met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/). Maak de presentatie vrij wanneer deze niet meer nodig is om de bronnen vrij te geven.

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

De bestands-extensie bepaalt niet automatisch het uitvoerformaat; het argument [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/) doet dat. Houd de invoer- en uitvoer-paden verschillend als u het originele PPT-bestand wilt behouden.

## **Converteer meerdere PPT-bestanden**

Het volgende voorbeeld converteert elk `.ppt`-bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat één mislukte conversie de rest van de batch niet stopt.

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

Voor productie-workloads logt u de volledige uitzondering, bepaalt u of een bestaand uitvoerbestand mag worden overschreven, en schrijft u de namen van mislukte bestanden naar een retry- of review-wachtrij. Beschadigde bestanden, wachtwoordbeveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet-ondersteunde inhoud kunnen allemaal een conversie laten mislukken. Zie [Password-Protected Presentations](/slides/nl/cpp/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy-functies**

Conversie behoudt normaal gezien dia's, masters, indelingen, tekst, vormen, afbeeldingen, tabellen en grafieken. Echter, PPT en PPTX vertegenwoordigen niet elke functie op precies dezelfde manier. Een legacy-functie zonder PPTX-equivalent, of die niet door de bibliotheek wordt ondersteund, kan worden genormaliseerd, weggelaten of anders weergegeven.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingebedde of gekoppelde OLE-objecten, ActiveX-besturingen, ingebedde media, ongebruikelijke lettertypen of VBA-macro's bevat. Een gewoon PPTX-bestand is geen macro-ondersteund formaat, dus gebruik een geschikt macro-ondersteund werkproces wanneer VBA beschikbaar moet blijven. Verifieer bovendien dat vereiste lettertypen en externe bronnen aanwezig zijn in de omgeving waar de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten opent u het gegenereerde PPTX programmatically opnieuw en controleert u het aantal dia's en de inhoud, waarna u het uiterlijk en het diavoorstellingsgedrag in de beoogde viewer vergelijkt. Beschouw een succesvolle aanroep van [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) niet als bewijs dat elke legacy-functie een exacte PPTX-representatie heeft.

## **Wanneer PPTX gebruiken**

Gebruik PPTX wanneer de presentatie wordt bewerkt in huidige PowerPoint-versies, wordt uitgewisseld met systemen die met Open XML-pakketten werken, of wordt opgeslagen in een formaat dat gemakkelijker te inspecteren en te herstellen is dan het legacy-binaire PPT. Bewaar het oorspronkelijke PPT als een archief- of rollback-kopie totdat de geconverteerde presentatie uw nauwkeurigheidstests heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander output-type nodig heeft, gebruik dan de formaat-specifieke richtlijnen in [Convert Presentations to Multiple Formats](/slides/nl/cpp/convert-presentation/) in plaats van aan te nemen dat alle doelformaten bewerkbare PowerPoint-functies behouden.

## **Online-converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op toepassingsniveau gebruikt u de C++-API.

## **Gerelateerde artikelen**

- [Presentaties opslaan in C++](/slides/nl/cpp/save-presentation/)
- [Ondersteunde bestandsformaten](/slides/nl/cpp/supported-file-formats/)
- [Presentaties openen in C++](/slides/nl/cpp/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for C++ laadt en slaat presentatiebestanden op zonder dat Microsoft PowerPoint vereist is.

**Zal de PPT-naar-PPTX-conversie alle inhoud exact behouden?**

Het behoudt de algemene presentatiewijzigingen, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy- of niet-ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro's, OLE- of ActiveX-objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een wachtwoord-beveiligd PPT-bestand converteren?**

Ja, mits u het juiste wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat het laadproces mislukt.

**Moet ik het PPT-bestand na de conversie verwijderen?**

Bewaar het origineel totdat u het PPTX hebt gecontroleerd in de viewers en werkstromen die voor u belangrijk zijn. Dit biedt een rollback-kopie als een legacy-functie anders wordt geconverteerd.