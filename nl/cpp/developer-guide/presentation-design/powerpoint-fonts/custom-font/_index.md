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
- lettertype map
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Pas lettertypen aan in PowerPoint-slides met Aspose.Slides voor C++ om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie leveren via document‑niveau lettertypebronnen, of externe lettertypen rechtstreeks vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt om de uitvoer van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor rendering is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruikt u de functionaliteit voor lettertype‑insluiting expliciet.

{{% alert color="primary" %}} 
Aspose Slides stelt u in staat om deze lettertypen te laden met behulp van [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf)‑ en TrueType‑collectie (.ttc)‑lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf)‑lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt u in staat om lettertypen die in een presentatie worden gebruikt, te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput – zoals PDF, afbeeldingen en andere ondersteunde formaten – zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste directories.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en render/​exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/clearcache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld laat het proces van het laden van lettertypen zien:

```cpp
// Definieer mappen die aangepaste lettertypebestanden bevatten.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laad aangepaste lettertypen uit de opgegeven mappen.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/​exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Wis de lettertypecache nadat het werk is voltooid.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert de initialisatievolgorde van lettertypen niet. Lettertypen worden in de volgende volgorde geïnitialiseerd:

1. Het standaard‑lettertypepad van het besturingssysteem.
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**

Aspose.Slides biedt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/) om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze C++‑code toont hoe u de [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/getfontfolders/)‑methode gebruikt:

``` cpp
// Deze regel geeft de mappen weer die worden gecontroleerd op lettertypebestanden.
// Dat zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeem-lettertype-mappen.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**

Aspose.Slides biedt de eigenschap [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) om u in staat te stellen externe lettertypen op te geven die met de presentatie worden gebruikt.

Deze C++‑code toont hoe u de [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)‑eigenschap gebruikt:

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

Aspose.Slides biedt de methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfont/) om u in staat te stellen externe lettertypen in een byte‑array te laden.

Deze C++‑code demonstreert het proces van het laden van een lettertype‑byte‑array:

```cpp
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

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Het registreren van een lettertype voor rendering is niet hetzelfde als het insluiten ervan in een PPTX. Als u wilt dat het lettertype in het presentatiebestand wordt meegenomen, moet u de expliciete [insluitingsfuncties](/slides/nl/cpp/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [lettertype‑substitutie](/slides/nl/cpp/font-substitution/), [vervangingsregels](/slides/nl/cpp/font-replacement/) en [fallback‑sets](/slides/nl/cpp/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyph ontbreekt.

**Kan ik lettertypen in Linux/Docker‑containers gebruiken zonder ze systeemwijd te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Hierdoor is er geen afhankelijkheid meer van systeem‑lettertype‑mappen in het container‑image.

**Wat betreft licenties—kan ik elk aangepast lettertype insluiten zonder beperkingen?**

U bent verantwoordelijk voor de naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de uitvoer verspreidt.