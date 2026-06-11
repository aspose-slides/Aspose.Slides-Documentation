---
title: Konvertera PowerPoint-presentationer till HTML i C++
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/cpp/convert-powerpoint-to-html/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- spara PowerPoint som HTML
- spara presentation som HTML
- spara bild som HTML
- spara PPT som HTML
- spara PPTX som HTML
- exportera PPT till HTML
- exportera PPTX till HTML
- C++
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML i C++. Använd Aspose.Slides för att exportera PPT- och PPTX-filer, valda bilder, anteckningar, typsnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides för C++ kan spara PowerPoint-presentationer som HTML utan Microsoft PowerPoint. Den grundläggande konverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) laddning och ett anrop av `Save` med [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/) när du behöver kontrollera den exporterade layouten, typsnitt, bilder, anteckningar, kommentarer, SVG-utdata eller länkade resurser.

Den här guiden fokuserar på praktiska scenarier för HTML-export:

- Exportera en hel presentation eller utvalda bilder.
- Generera HTML med fast layout, responsiv eller baserad på SVG.
- Inkludera talaranteckningar och kommentarer.
- Kontrollera bildkvalitet och beskurna bilddata.
- Bädda in typsnitt eller spara typsnittsfiler separat.
- Välj hur externa resurser och mediafiler skrivs och refereras.

Som standard producerar HTML-export ett självständigt HTML-dokument där de flesta resurser är inbäddade. Detta är praktiskt för att dela en enda fil, men det kan öka filstorleken. För webbpublicering, överväg externa resurser, lägre bild-DPI och endast bädda in typsnitt som inte är pålitligt tillgängliga i målmiljön.

## **Konvertera en presentation till HTML**

För att exportera en presentation till HTML, läs in den med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och spara den med `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Detta exempel skriver en HTML-fil. Anropet till `Dispose` frigör filhandtag och renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/) är huvudkonfigurationsklassen för HTML-export. Vanliga inställningar inkluderar:

- `SlidesLayoutOptions`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `HtmlFormatter`: ändrar HTML-dokumentets struktur eller delegerar formatering till en kontroller.
- `SlideImageFormat`: ändrar hur bilder representeras, till exempel som SVG.
- `PicturesCompression`: kontrollerar bild-DPI och utdata storlek.
- `DeletePicturesCroppedAreas`: behåller eller tar bort beskurna bilddata.
- `SvgResponsiveLayout`: får exporterad SVG-innehåll att anpassa sig till sin behållare.
- `ShowHiddenSlides`: inkluderar dolda bilder när det krävs.

Följande sektioner visar de vanligaste alternativen separat så att du kan kombinera bara de du behöver i ditt arbetsflöde.

## **Konvertera valda bilder till HTML**

`Presentation::Save`-överladdningen som accepterar bildnummer använder 1-baserade bildpositioner. Loopen nedan sparar varje bild till en separat HTML-fil.

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

Använd detta mönster när en webbplats eller applikation behöver en HTML-sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/) instans och skicka den till varje `Save`-anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/responsivehtmlcontroller/) tillhandahåller responsiv HTML-utmatning via [HtmlFormatter](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmlformatter/). Använd den när den exporterade sidan bör anpassa sig bättre till webbläsarens bredd.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

För SVG-baserad responsiv layout, sätt `SvgResponsiveLayout` på [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/). Detta är användbart när bildinnehållet exporteras som skalbar SVG-markup.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Inkludera talaranteckningar och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` för att inkludera talaranteckningar eller kommentarer. Anteckningar och kommentarer är dolda som standard om du inte specificerar deras positioner.

Anta att källpresentationen innehåller talaranteckningar:

![Bild med talaranteckningar i PowerPoint](slide_with_notes.png)

Följande kod exporterar bildinnehållet med talaranteckningar under bilden.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Den exporterade HTML:n inkluderar anteckningsområdet:

![HTML-utdata med bilden och talaranteckningarna](HTML_with_notes.png)

För att exportera kommentarer, sätt `CommentsPosition`, exempelvis till `CommentsPositions::Right` eller `CommentsPositions::Bottom`. Om du bara behöver kommentarer, utelämna `NotesPosition`. Om du behöver både anteckningar och kommentarer, sätt båda egenskaperna.

## **Kontrollera bildkvalitet och beskurna områden**

HTML-export kan komprimera bildbilder för att minska utdata storlek. Sätt `PicturesCompression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/picturescompression/) när du behöver högre bildkvalitet.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Som standard kan beskurna områden av bilder tas bort från den exporterade utmatningen. Behåll beskurna data endast när användare måste kunna återhämta eller inspektera de dolda bilddelarna. Att behålla dem kan öka HTML-storleken.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Lägg till CSS**

För enkel styling, skicka en CSS-sträng till `HtmlFormatter::CreateDocumentFormatter`. Detta ändrar det omgivande HTML-dokumentet medan Aspose.Slides fortsätter rendera bildinnehållet.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

För ett anpassat dokumenthuvud, en länkad CSS-fil eller anpassad markup runt bilder och former, implementera [IHtmlFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ihtmlformattingcontroller/) och skicka den till [HtmlFormatter](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmlformatter/) med `CreateCustomFormatter`.

## **Bädda in typsnitt**

Om målmiljön kanske inte har presentationens typsnitt installerade, bädda in typsnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Inbäddning förbättrar visuell noggrannhet men ökar filstorleken.

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

Uteslut typsnitt endast när du är säker på att målwebbläsare eller system redan tillhandahåller dem. För varumärkestypsnitt eller mindre vanliga typsnitt är inbäddning vanligtvis säkrare.

## **Länka typsnitts-filer istället för att bädda in dem**

För att minska HTML-filens storlek kan du skriva typsnittsdata till separata WOFF-filer och lägga till `@font-face`-regler i HTML. Hjälpen nedan utökar [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedallfontshtmlcontroller/) och åsidosätter `WriteFont`.

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

I detta exempel sparas typsnitts-filerna till `html-output/fonts`, och HTML refererar dem med URL:er som `fonts/BrandFont-normal-400.woff`. Om HTML-filen och typsnitten distribueras till en annan plats, välj `fontUrlPrefix` så att den matchar den distribuerade URL-sökvägen.

## **Spara resurser externt**

Självständigt HTML är enkelt att flytta, men inbäddade Base64-resurser kan göra filen stor. Om din applikation behöver externa bildfiler, implementera [ILinkEmbedController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ilinkembedcontroller/) och skicka den till [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/) konstruktorn.

När du externlar resurser, välj två sökvägar med avsikt:

- Filssystemets utmatningssökväg, där din applikation skriver genererade bilder, typsnitt, ljud eller video.
- URL‑sökvägen, vilken webbläsaren använder från HTML-dokumentet för att ladda dessa filer.

## **Exportera mediafiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exporterar video- och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: katalogen där genererade mediafiler kommer att skrivas.
- `fileName`: det HTML-filnamn som genereras.
- `baseUri`: det absoluta URI‑prefixet som används i HTML-länkarna till mediafiler.

Om HTML-filen är `html-output/presentation.html` och mediafiler sparas i `html-output/media`, bör `path` peka på mediakatalogen på disk, medan `baseUri` bör peka på samma katalog ur webbläsarens perspektiv. För lokal förhandsgranskning kan du bygga en `file:///`‑URI från mediakatalogen. För en distribuerad applikation, använd den absoluta URL‑en för den publicerade mediakatalogen.

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

Använd utmatningskataloger som är unika per exportjobb, särskilt i serverapplikationer. Delade utmatningssökvägar kan orsaka att filer från olika konverteringar skriver över varandra.

## **Prestanda och resurs‑hantering**

HTML-konvertering är en renderingsoperation, så bearbetningstid och minnesanvändning beror på antal bilder, bildupplösning, typsnitt, effekter, diagram och inbäddade media. Högre `PicturesCompression`‑DPI‑värden, inbäddade typsnitt, SVG‑utdata och behållna beskurna bildområden kan förbättra troheten men ökar vanligtvis filstorleken.

För batch‑konvertering:

- Avsluta varje [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instans omedelbart.
- Använd separata utmatningskataloger för separata jobb.
- Undvik att bädda in vanliga typsnitt såvida inte trohet kräver det.
- Sänk bild‑DPI när HTML:n är för förhandsgranskning eller miniatyrer.
- Behåll källpresentationen, den genererade HTML:n och externa resurser tillsammans tills distributionssökvägarna är slutgiltiga.

## **FAQ**

**Behåller hyperlänkar HTML‑utdata?**

Ja. Presentationshyperlänkar exporteras till HTML och förblir klickbara när måladressen är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation]‑instans över trådar. Processa olika filer med separata presentations‑instanser, separata strömmar och separata utmatningskataloger. Se [multithreading‑guiden](/slides/sv/cpp/multithreading/) för detaljer.

**Är ett Presentation‑objekt trådsäkert?**

Nej. En enskild [Presentation]‑instans bör läsas, modifieras, sparas och avslutas på samma tråd. För parallellt arbete, skapa en oberoende instans per tråd eller process.

**Varför är den genererade HTML‑filen stor?**

Standardexporten kan bädda in resurser direkt i HTML. Inbäddade typsnitt, hög‑DPI‑bilder, media, SVG‑innehåll och behållna beskurna bildområden ökar också storleken. Använd externa resurser, uteslut vanliga typsnitt från inbäddning och sänk `PicturesCompression` när en mindre filstorlek är viktigare än maximal trohet.

**Varför visas en PowerPoint-typsnittsstorlek som 24 pt som 17.999819 pt i HTML?**

Detta kan ske eftersom PowerPoint och HTML använder olika DPI‑modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserade på 72 DPI, medan HTML‑layouten baseras på CSS‑pixlar i en 96 DPI‑modell. När Aspose.Slides exporterar en presentation till HTML översätts typsnittsstorleken mellan dessa system, och konverteringen kan introducera små avrundningsavvikelser.

Dessa värden indikerar inte en verklig visuell förändring av typsnittsstorleken. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur bör jag välja baseUri för mediaexport?**

Välj `baseUri` ur webbläsarens perspektiv och skicka den som en absolut URI. För lokal förhandsgranskning kan du härleda den från utmatningskatalogen med `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. För distribution, använd den absoluta URL:en för den publicerade mediakatalogen. Filsystemets `path` och webbläsarens `baseUri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `ShowHiddenSlides` till `true` på [HtmlOptions] när dolda bilder måste exporteras.