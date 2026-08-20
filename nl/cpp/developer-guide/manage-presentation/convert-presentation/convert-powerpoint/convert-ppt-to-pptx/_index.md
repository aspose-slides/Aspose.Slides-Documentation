---
title: PPT naar PPTX converteren in C++
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
description: "Converteer oude PPT-bestanden naar PPTX in C++ met Aspose.Slides. Bevat C++-voorbeelden voor enkele bestanden en batch-conversie, foutafhandeling en nauwkeurigheid-opmerkingen."
---
## **Overzicht**

PPT is het verouderde binaire PowerPoint-formaat, terwijl PPTX het nieuwere Open XML-formaat is. Aspose.Slides for C++ kan een PPT‑bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel laat zien hoe u één bestand of een map met bestanden kunt converteren en legt uit wat u na de conversie moet controleren.

## **Een PPT‑bestand naar PPTX converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse, roep vervolgens [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) aan met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/). Maak de presentatie vrij wanneer deze niet meer nodig is om de resources vrij te geven.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Laad de oude PPT-presentatie.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Sla de presentatie op in PPTX-formaat.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De bestandsextensie bepaalt niet automatisch het uitvoerformaat; het argument [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/) doet dat wel. Houd de invoer‑ en uitvoer‑paden verschillend als u het originele PPT‑bestand wilt behouden.

## **Meerdere PPT‑bestanden converteren**

Het volgende voorbeeld converteert elk `.ppt`‑bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat een mislukte conversie de rest van de batch niet stopt.

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

Voor productie‑workloads moet u de volledige exceptie loggen, bepalen of een bestaand uitvoerbestand mag worden overschreven, en misluke bestandsnamen naar een retry‑ of review‑queue schrijven. Beschadigde bestanden, met wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet‑ondersteunde inhoud kunnen allemaal een conversie laten mislukken. Zie [Password-Protected Presentations](/cpp/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy‑functies**

Conversie behoudt normaal gesproken dia’s, masters, lay‑outs, tekst, vormen, afbeeldingen, tabellen en grafieken. PPT en PPTX representeren echter niet elke functie op exact dezelfde manier. Een legacy‑functie waarvoor geen PPTX‑equivalent bestaat, of die niet door de bibliotheek wordt ondersteund, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingesloten of gekoppelde OLE‑objecten, ActiveX‑besturingselementen, ingesloten media, ongebruikelijke lettertypen of VBA‑macro’s bevat. Een standaard PPTX‑bestand is geen macro‑ondersteund formaat, dus gebruik een geschikte macro‑ondersteunde workflow wanneer VBA beschikbaar moet blijven. Controleer bovendien of vereiste lettertypen en externe bronnen aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten moet u de gegenereerde PPTX programmatisch opnieuw openen en de belangrijke dia‑aantallen en inhoud inspecteren, waarna u het uiterlijk en het diapresentatie‑gedrag in de beoogde viewer vergelijkt. Beschouw een succesvolle [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑aanroep niet als bewijs dat elke legacy‑functie een exacte PPTX‑representatie heeft.

## **Wanneer PPTX te gebruiken**

Gebruik PPTX wanneer de presentatie bewerkt zal worden in de huidige PowerPoint‑versies, wordt uitgewisseld met systemen die werken met Open‑XML‑pakketten, of wordt opgeslagen in een formaat dat gemakkelijker te inspecteren en te herstellen is dan het legacy‑binaire PPT. Bewaar het originele PPT als een archief‑ of rollback‑kopie totdat de geconverteerde presentatie uw nauwkeurigheidstests heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander uitvoertype nodig heeft, gebruik dan de format‑specifieke richtlijnen in [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) in plaats van aan te nemen dat alle doelformaten bewerkbare PowerPoint‑functies behouden.

## **Online‑converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op applicatieniveau gebruikt u de C++‑API.

## **Gerelateerde artikelen**

- [Presentaties opslaan in C++](/cpp/save-presentation/)
- [Ondersteunde bestandsformaten](/cpp/supported-file-formats/)
- [Presentaties openen in C++](/cpp/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for C++ laadt en slaat presentaties op zonder Microsoft PowerPoint te vereisen.

**Zal de PPT‑naar‑PPTX‑conversie alle inhoud exact behouden?**

Het behoudt de algemene presentatiedata, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy‑ of niet‑ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro’s, OLE‑ of ActiveX‑objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een met wachtwoord beveiligd PPT‑bestand converteren?**

Ja, als u het juiste wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat het laden mislukt.

**Moet ik het PPT‑bestand na de conversie verwijderen?**

Bewaar het origineel totdat u de PPTX in de viewers en workflows die voor u belangrijk zijn, hebt geverifieerd. Dit biedt een rollback‑kopie als een legacy‑functie anders wordt geconverteerd.