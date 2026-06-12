---
title: PowerPoint-presentaties omzetten naar HTML in C++
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/cpp/convert-powerpoint-to-html/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- PowerPoint opslaan als HTML
- presentatie opslaan als HTML
- dia opslaan als HTML
- PPT opslaan als HTML
- PPTX opslaan als HTML
- PPT exporteren naar HTML
- PPTX exporteren naar HTML
- C++
- Aspose.Slides
description: "Converteer PowerPoint-presentaties naar HTML in C++. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides voor C++ kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basale conversie bestaat uit een enkele [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑lading en een `Save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) wanneer je de geëxporteerde lay‑out, lettertypen, afbeeldingen, aantekeningen, opmerkingen, SVG‑uitvoer of gekoppelde bronnen moet beheersen.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Een volledige presentatie of geselecteerde dia’s exporteren.
- Vaste lay‑out, responsieve of SVG‑gebaseerde HTML genereren.
- Sprekersnotities en opmerkingen opnemen.
- Beeldkwaliteit en bijgesneden afbeeldingsdata beheren.
- Lettertypen insluiten of lettertypebestanden apart opslaan.
- Bepalen hoe externe bronnen en mediabestanden worden geschreven en gerefereerd.

Standaard produceert HTML‑export een zelf‑containend HTML‑document waarbij de meeste bronnen zijn ingesloten. Dit is handig voor het delen van één bestand, maar kan de bestandsgrootte verhogen. Voor publicatie op het web kun je overwegen externe bronnen te gebruiken, de DPI van afbeeldingen te verlagen en alleen lettertypen in te sluiten die niet betrouwbaar beschikbaar zijn in de doelomgeving.

## **Een presentatie converteren naar HTML**

Om een presentatie naar HTML te exporteren, laad je deze met [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en sla je hem op met `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Dit voorbeeld schrijft één HTML‑bestand. De oproep naar `Dispose` vrijgeeft bestandshandvattingen en renderingsbronnen na de export.

## **HtmlOptions gebruiken**

[HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelvoorkomende instellingen omvatten:

- `SlidesLayoutOptions`: voegt aantekeningen, opmerkingen, hand-outs of andere lay‑out‑informatie toe.
- `HtmlFormatter`: verandert de structuur van het HTML‑document of delegeert formattering naar een controller.
- `SlideImageFormat`: verandert hoe dia’s worden weergegeven, bijvoorbeeld als SVG.
- `PicturesCompression`: beheert de DPI van afbeeldingen en de outputgrootte.
- `DeletePicturesCroppedAreas`: behoudt of verwijdert bijgesneden afbeeldingsdata.
- `SvgResponsiveLayout`: laat geëxporteerde SVG‑content zich aanpassen aan de container.
- `ShowHiddenSlides`: neemt verborgen dia’s op wanneer dat nodig is.

De volgende secties tonen de meest voorkomende opties afzonderlijk zodat je alleen die kunt combineren die jouw workflow vereist.

## **Geselecteerde dia's naar HTML converteren**

De `Presentation::Save`‑overload die dia‑nummers accepteert, gebruikt 1‑gebaseerde posities. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/)‑instantie aan en geef die door aan elke `Save`‑aanroep.

## **Responsieve HTML maken**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/responsivehtmlcontroller/) biedt responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmlformatter/). Gebruik deze wanneer de geëxporteerde pagina zich beter moet aanpassen aan de breedte van de browser.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Voor SVG‑gebaseerde responsieve lay‑out, stel `SvgResponsiveLayout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/). Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Sprekersnotities en opmerkingen opnemen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` om sprekersnotities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij je hun posities kiest.

Stel dat de bronpresentatie sprekersnotities bevat:

![Dia met sprekersnotities in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met sprekersnotities onder de dia.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

De geëxporteerde HTML bevat het notitiegebied:

![HTML‑output met de dia en sprekersnotities](HTML_with_notes.png)

Om opmerkingen te exporteren, stel `CommentsPosition` in, bijvoorbeeld op `CommentsPositions::Right` of `CommentsPositions::Bottom`. Als je alleen opmerkingen nodig hebt, laat `NotesPosition` weg. Als je zowel notities als opmerkingen wilt, stel beide eigenschappen in.

## **Beheer beeldkwaliteit en bijgesneden gebieden**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `PicturesCompression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/picturescompression/) wanneer je een hogere beeldkwaliteit nodig hebt.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Standaard kunnen bijgesneden delen van afbeeldingen worden verwijderd uit de geëxporteerde output. Behoud bijgesneden data alleen wanneer gebruikers die verborgen afbeeldingsdelen moeten kunnen herstellen of inspecteren. Het behouden ervan kan de HTML‑grootte verhogen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS toevoegen**

Voor eenvoudige styling kun je een CSS‑string doorgeven aan `HtmlFormatter::CreateDocumentFormatter`. Dit verandert het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Voor een aangepaste document‑header, een gekoppeld CSS‑bestand of aangepaste markup rondom dia’s en vormen, implementeer [IHtmlFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ihtmlformattingcontroller/) en geef die door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmlformatter/) met `CreateCustomFormatter`.

## **Lettertypen insluiten**

Als de doelomgeving de presentatielettertypen mogelijk niet geïnstalleerd heeft, sluit dan lettertypen in de HTML in met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar verhoogt de bestandsgrootte.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Sluit lettertypen alleen uit wanneer je er zeker van bent dat de doel‑browsers of -systemen ze al leveren. Voor merkletttypen of minder gangbare lettertypen is insluiten meestal veiliger.

## **Lettertypebestanden linken i.p.v. insluiten**

Om de HTML‑bestandsgrootte te verkleinen, kun je lettertype‑data naar aparte WOFF‑bestanden schrijven en `@font-face`‑regels aan de HTML toevoegen. De helper hieronder breidt [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedallfontshtmlcontroller/) uit en overschrijft `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

In dit voorbeeld worden lettertypebestanden opgeslagen in `html-output/fonts`, en de HTML verwijst ernaar met URL’s zoals `fonts/BrandFont-normal-400.woff`. Als het HTML‑bestand en de lettertypen naar een andere locatie worden uitgerold, kies dan `fontUrlPrefix` zodat deze overeenkomt met het uitgerolde URL‑pad.

## **Bronnen extern opslaan**

Zelf‑containende HTML is makkelijk verplaatsbaar, maar ingesloten Base64‑bronnen kunnen het bestand groot maken. Als jouw applicatie externe afbeeldingsbestanden nodig heeft, implementeer dan [ILinkEmbedController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ilinkembedcontroller/) en geef die door aan de constructor van [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/).

Wanneer je bronnen externaliseert, kies je twee paden bewust:

- Het bestandsysteem‑outputpad, waar je applicatie gegenereerde afbeeldingen, lettertypen, audio‑ of videobestanden schrijft.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

## **Media‑bestanden exporteren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor neemt:

- `path`: de map waarin gegenereerde mediabestanden worden geschreven.
- `fileName`: de te genereren HTML‑bestandsnaam.
- `baseUri`: het absolute URI‑voorvoegsel dat in de HTML‑links naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is en mediabestanden worden opgeslagen in `html-output/media`, moet `path` verwijzen naar de mediamap op schijf, terwijl `baseUri` moet verwijzen naar dezelfde map vanuit het perspectief van de browser. Voor lokale preview kun je een `file:///`‑URI bouwen vanuit de mediamap. Voor een uitgerolde applicatie gebruik je de absolute URL van de gepubliceerde mediamap.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Gebruik outputmappen die uniek zijn per exporttaak, vooral in server‑applicaties. Gedeelde outputpaden kunnen zorgen dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resource‑beheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugengebruik hangen af van het aantal dia’s, de resolutie van afbeeldingen, lettertypen, effecten, diagrammen en ingesloten media. Hogere `PicturesCompression`‑DPI‑waarden, ingesloten lettertypen, SVG‑output en behouden bijgesneden afbeeldingsgebieden kunnen de getrouwheid verbeteren maar verhogen doorgaans de outputgrootte.

Voor batch‑conversie:

- Dispose iedere [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie direct na gebruik.
- Gebruik aparte outputmappen voor verschillende taken.
- Vermijd het insluiten van algemene lettertypen tenzij getrouwheid dit vereist.
- Verlaag de DPI van afbeeldingen wanneer de HTML alleen voor preview of miniatuurweergaven dient.
- Houd de bronpresentatie, de gegenereerde HTML en externe bronnen samen tot de uiteindelijke implementatie‑paden definitief zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar zolang de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie over threads. Verwerk verschillende bestanden met aparte presentatie‑instanties, aparte streams en aparte outputmappen. Zie de [multithreading guidance](/slides/nl/cpp/multithreading/) voor details.

**Is een Presentation‑object thread‑safe?**

Nee. Een enkel [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑object moet geladen, aangepast, opgeslagen en disposed worden op één thread. Voor parallel werk maak je per thread een onafhankelijke instantie.

**Waarom is het gegenereerde HTML‑bestand zo groot?**

De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypen, afbeeldingen met hoge DPI, media, SVG‑content en behouden bijgesneden afbeelding‑gebieden verhogen de grootte. Gebruik externe bronnen, sluit algemene lettertypen uit en verlaag `PicturesCompression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom verschijnt een PowerPoint‑lettergrootte van 24 pt als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekstgroottes op in typografische punten op basis van 72 DPI, terwijl HTML‑lay‑out gebaseerd is op CSS‑pixels in een 96 DPI‑model. Wanneer Aspose.Slides een presentatie naar HTML exporteert, wordt de lettergrootte omgezet tussen deze systemen, en de conversie kan kleine afrondingsverschillen introduceren.

Deze waarden geven geen echte visuele verandering in lettergrootte weer; het is slechts een wiskundig neveneffect van het omrekenen van tekstmetriek tussen PowerPoint en HTML.

**Hoe moet ik baseUri kiezen voor mediabestanden‑export?**

Kies `baseUri` vanuit het perspectief van de browser en geef deze op als een absolute URI. Voor lokale preview kun je deze afleiden van de outputmap met `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Voor productie gebruik je de absolute URL van de gepubliceerde mediamap. Het bestandsysteem‑`path` en de browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar moeten dezelfde resource‑locatie beschrijven.

**Kan ik verborgen dia’s opnemen?**

Ja. Stel `ShowHiddenSlides` in op `true` op [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) wanneer verborgen dia’s geëxporteerd moeten worden.