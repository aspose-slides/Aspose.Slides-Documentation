---
title: Aanpassen van PowerPoint-lettertypen in C++
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/cpp/custom-font/
keywords:
- lettertype
- aangepast lettertype
- extern lettertype
- lettertype laden
- lettertypen beheren
- lettertype map
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: Pas lettertypen aan in PowerPoint-dia's met Aspose.Slides voor C++ om uw presentaties scherp en consistent te houden op elk apparaat.
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden uit aangepaste mappen, lettertypen leveren voor een specifieke presentatie via document‑niveau lettertype‑bronnen, of externe lettertypen direct uit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de insluit‑functionaliteit.

{{% alert color="info" %}} 

Aspose Slides stelt u in staat deze lettertypen te laden met behulp van [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze te installeren op het systeem. Dit beïnvloedt de exportoutput—zoals PDF, afbeeldingen en andere ondersteunde formaten—zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef één of meerdere mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) methode aan om lettertypen uit die mappen te laden.
3. Laad en render/ exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definieer de mappen die aangepaste lettertypebestanden bevatten.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderen/exporteren van de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wis de lettertype-cache nadat het werk voltooid is.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde waarin lettertypen worden geïnitialiseerd.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑lettertypepad van het besturingssysteem.
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) om u lettertype‑mappen te laten vinden. Deze methode retourneert de mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeem‑lettertype‑mappen.

Deze C++‑code laat zien hoe u de [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) methode gebruikt:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dat zijn mappen die via de LoadExternalFonts‑methode zijn toegevoegd en systeem‑lettertype‑mappen.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**
Aspose.Slides biedt de eigenschap [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) zodat u externe lettertypen kunt opgeven die met de presentatie moeten worden gebruikt.

Deze C++‑code laat zien hoe u de [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) eigenschap gebruikt:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //werk met de presentatie
    //CustomFont1, CustomFont2 evenals lettertypen uit de folders assets\fonts & global\fonts en hun subfolders zijn beschikbaar voor de presentatie
}
```

## **Lettertypen extern beheren**
Aspose.Slides biedt de [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfont/) methode zodat u externe lettertypen kunt laden in een byte‑array.

Deze C++‑code demonstreert het proces van het laden van een byte‑array met een lettertype:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Het pad naar de documentenmap
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Veelgestelde vragen**

### Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Verbonden lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluit‑functionaliteit](/slides/nl/cpp/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [lettertype‑substitutie](/slides/nl/cpp/font-substitution/), [vervangingsregels](/slides/nl/cpp/font-replacement/) en [fallback‑sets](/slides/nl/cpp/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑directories in de container‑image.

### Hoe zit het met licenties—kan ik elk aangepast lettertype zonder beperkingen insluiten?

U bent verantwoordelijk voor de naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de uitvoer distribueert.