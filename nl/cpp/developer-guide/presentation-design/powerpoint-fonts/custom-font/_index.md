---
title: "Aanpassen van PowerPoint-lettertypen in C++"
linktitle: "Aangepast lettertype"
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
description: "Pas lettertypen aan in PowerPoint-dia's met Aspose.Slides voor C++ om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om aangepaste lettertypen in presentaties te gebruiken zonder ze te installeren op het besturingssysteem. Je kunt lettertypen laden vanuit aangepaste mappen, lettertypen aanbieden voor een specifieke presentatie via document‑level font‑sources, of externe lettertypen rechtstreeks vanuit binaire data laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden over verschillende omgevingen. Het artikel legt ook uit hoe je de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe je de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor rendering is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de functies voor het insluiten van lettertypen.

{{% alert color="primary" %}} 
Aspose Slides laat je deze lettertypen laden met [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides maakt het mogelijk om lettertypen die in een presentatie worden gebruikt te laden zonder ze te installeren op het systeem. Dit heeft invloed op de exportresultaten—zoals PDF, afbeeldingen en andere ondersteunde formaten—zodat de resulterende documenten er consistent uitzien over omgevingen heen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef een of meerdere mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) methode aan om de lettertypen uit die mappen te laden.
3. Laad en render/ exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

De volgende code‑voorbeeld laat het lettertype‑laadproces zien:

```cpp
// Definieer mappen die aangepaste lettertypebestanden bevatten.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/en exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wis de lettertype-cache nadat het werk voltooid is.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de volgorde waarin lettertypen worden geïnitialiseerd.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑lettertypepad van het besturingssysteem.
1. De paden die worden geladen via [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) zodat je lettertype‑mappen kunt vinden. Deze methode retourneert de mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en de systeem‑lettertype‑mappen.

Deze C++‑code toont hoe je de [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) methode gebruikt:

``` cpp
// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dat zijn mappen die via de LoadExternalFonts‑methode zijn toegevoegd en systeem‑lettertype‑mappen.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**
Aspose.Slides biedt de eigenschap [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) zodat je externe lettertypen kunt opgeven die met de presentatie worden gebruikt.

Deze C++‑code toont hoe je de [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) eigenschap gebruikt:

``` cpp
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
Aspose.Slides biedt de [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfont/) methode zodat je externe lettertypen kunt laden in een byte‑array.

Deze C++‑code demonstreert het laden van een lettertype‑byte‑array:

```cpp
// Het pad naar de map met documenten
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Verbonden lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?**

Nee. Een lettertype registreren voor rendering is niet hetzelfde als het insluiten in een PPTX. Als je wilt dat het lettertype in het presentatie‑bestand zelf zit, moet je de expliciete [insluit‑functies](/slides/nl/cpp/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font substitution](/slides/nl/cpp/font-substitution/), [replacement rules](/slides/nl/cpp/font-replacement/) en [fallback sets](/slides/nl/cpp/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?**

Ja. Verwijs naar je eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Daarmee verwijder je elke afhankelijkheid van systeem‑lettertype‑mappen in de container‑image.

**Wat betreft licenties—mag ik elk aangepast lettertype insluiten zonder restricties?**

Jij bent verantwoordelijk voor naleving van de lettertype‑licenties. De voorwaarden variëren; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat je output distribueert.