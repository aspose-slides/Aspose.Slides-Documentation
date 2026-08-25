---
title: Aangepaste PowerPoint-lettertypen in C++
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
- lettertype‑map
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Pas lettertypen aan in PowerPoint‑dia's met Aspose.Slides voor C++ om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie leveren via document‑niveau font‑bronnen, of externe lettertypen rechtstreeks laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen nadat u met externe lettertypen heeft gewerkt.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de ingebouwde insluitingsfuncties.

Een presentatiethema kan verschillende lettertype‑families refereren voor individuele schriftsystemen. Deze koppelingen slaan alleen de lettertype‑namen op, maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑specifieke thema‑lettertypen](/slides/nl/cpp/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Opmerking" %}}

Aspose Slides stelt u in staat deze lettertypen te laden met [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen uit aangepaste directories.

1. Geef één of meer mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische methode [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) aan om lettertypen uit die mappen te laden.
3. Laad en render/​exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld laat het laadproces van lettertypen zien:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definieer de mappen die aangepaste lettertype‑bestanden bevatten.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/​exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wis de lettertype‑cache nadat het werk voltooid is.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de volgorde waarin lettertypen worden geïnitialiseerd.  
Lettertypen worden in de volgende volgorde geïnitialiseerd:

1. Het standaard‑pad van het besturingssysteem.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen opvragen**

Aspose.Slides biedt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) zodat u lettertype‑mappen kunt vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeembrede lettertype‑mappen.

Deze C++‑code laat zien hoe u de methode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) gebruikt:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Deze regel geeft de mappen weer die gecontroleerd worden op lettertype-bestanden.
// Dit zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeembrede lettertype-mappen.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specificeer aangepaste lettertypen die met een presentatie worden gebruikt**

Aspose.Slides biedt de eigenschap [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) zodat u externe lettertypen kunt opgeven die met de presentatie worden gebruikt.

Deze C++‑code laat zien hoe u de eigenschap [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) gebruikt:

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
    //CustomFont1, CustomFont2 evenals lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfont/) zodat u externe lettertypen in een byte‑array kunt laden.

Deze C++‑code demonstreert het laadproces van een byte‑array‑lettertype:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Het pad naar de documentmap
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

### Heeft het gebruik van aangepaste lettertypen invloed op de export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het insluiten ervan in een PPTX. Als u het lettertype in het presentatie‑bestand wilt opnemen, moet u de expliciete [insluitingsfuncties](/slides/nl/cpp/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [font‑substitutie](/slides/nl/cpp/font-substitution/), [vervangingsregels](/slides/nl/cpp/font-replacement/) en [fallback‑sets](/slides/nl/cpp/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Hierdoor is er geen afhankelijkheid meer van systeembrede lettertype‑mappen in de container‑image.

### Hoe zit het met licenties — mag ik elk aangepast lettertype insluiten zonder beperkingen?

U bent zelf verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de gegenereerde output distribueert.