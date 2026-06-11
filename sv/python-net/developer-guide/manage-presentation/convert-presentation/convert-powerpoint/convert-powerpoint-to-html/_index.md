---
title: Konvertera PowerPoint-presentationer till HTML i Python
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/python-net/convert-powerpoint-to-html/
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
- Python
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML i Python. Använd Aspose.Slides för att exportera PPT- och PPTX-filer, valda bilder, anteckningar, teckensnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides for Python via .NET kan spara PowerPoint‑presentationer som HTML utan Microsoft PowerPoint. Den grundläggande konverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑laddning och ett `save`‑anrop med [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/) när du behöver styra den exporterade layouten, teckensnitt, bilder, anteckningar, kommentarer, SVG‑utmatning eller länkade resurser.

Den här guiden fokuserar på praktiska scenarier för HTML‑export:

- Exportera en hel presentation eller utvalda bilder.
- Generera fast layout, responsiv eller SVG‑baserad HTML.
- Inkludera talarnoteringar och kommentarer.
- Styr bildkvalitet och beskurna bilddata.
- Bädda in teckensnitt eller spara teckensnitts­filer separat.
- Välj hur externa resurser och media‑filer skrivs och refereras.

Som standard producerar HTML‑export ett självständigt HTML‑dokument där de flesta resurser är inbäddade. Det är bekvämt för delning av en enda fil, men kan öka utdata­storleken. För webbpublicering bör du överväga externa resurser, lägre bild‑DPI och enbart bädda in teckensnitt som inte är pålitligt tillgängliga i målmiljön.

## **Konvertera en presentation till HTML**

För att exportera en presentation till HTML, läs in den med [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och spara den med [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Detta exempel skriver en HTML‑fil. `with`‑satsen avyttrar presentations‑objektet och frigör filhandtag samt renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/) är huvudklassen för konfiguration av HTML‑export. Vanliga inställningar inkluderar:

- `slides_layout_options`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `html_formatter`: ändrar HTML‑dokumentets struktur eller delegerar formatering till en kontroller.
- `slide_image_format`: ändrar hur bilder representeras, till exempel som SVG.
- `pictures_compression`: styr bild‑DPI och utdata­storlek.
- `delete_pictures_cropped_areas`: behåller eller tar bort beskurna bilddata.
- `svg_responsive_layout`: får exporterad SVG‑content att anpassa sig till sin behållare.
- `show_hidden_slides`: inkluderar dolda bilder när så krävs.

Följande avsnitt visar de vanligaste alternativen var för sig så att du kan kombinera endast de du behöver i ditt arbetsflöde.

## **Konvertera valda bilder till HTML**

Den `save`‑överladdning som accepterar bildnummer använder 1‑baserade positionsnummer. Loopen nedan sparar varje bild till en separat HTML‑fil.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Använd detta mönster när en webbplats eller applikation kräver en HTML‑sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/)‑instans och skicka den till varje `save`‑anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/responsivehtmlcontroller/) ger responsiv HTML‑utmatning via [HtmlFormatter](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmlformatter/). Använd den när den exporterade sidan ska anpassa sig bättre till webbläsarens bredd.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

För SVG‑baserad responsiv layout, sätt `svg_responsive_layout` på [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/). Detta är användbart när bildinnehållet exporteras som skalbar SVG‑markup.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Inkludera talarnoteringar och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/) via `html_options.slides_layout_options` för att inkludera talarnoteringar eller kommentarer. Noteringar och kommentarer är dolda som standard om du inte anger deras positioner.

Anta att källpresentationen innehåller talarnoteringar:

![Bild med talarnoteringar i PowerPoint](slide_with_notes.png)

Följande kod exporterar bildens innehåll med talarnoteringar under bilden.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Den exporterade HTML‑filen innehåller noteringsområdet:

![HTML‑utdata med bilden och talarnoteringar](HTML_with_notes.png)

För att exportera kommentarer, sätt `comments_position`, till exempel till `CommentsPositions.RIGHT` eller `CommentsPositions.BOTTOM`. Om du bara behöver kommentarer, utelämna `notes_position`. Om du behöver både noteringar och kommentarer, sätt båda egenskaperna.

## **Styr bildkvalitet och beskurna områden**

HTML‑export kan komprimera bildbilder för att minska utdata­storleken. Sätt `pictures_compression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/picturescompression/) när du behöver högre bildkvalitet.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Som standard kan beskurna områden av bilder tas bort från den exporterade utdata. Behåll beskurna data endast när användare måste kunna återställa eller inspektera de dolda bilddelarna. Att behålla dem kan öka HTML‑storleken.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Lägg till CSS**

För enkel styling, skicka en CSS‑sträng till [HtmlFormatter](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmlformatter/). Detta ändrar det omgivande HTML‑dokumentet medan Aspose.Slides fortsätter rendera bildinnehållet.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

För ett anpassat dokumenthuvud, en länkad CSS‑fil eller anpassad markup runt bilder och former, använd en egen formateringskontroller och skicka den till [HtmlFormatter](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmlformatter/) med `create_custom_formatter`.

## **Bädda in teckensnitt**

Om målmiljön kanske inte har presentationens teckensnitt installerade, bädda in teckensnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Inbäddning förbättrar visuell trohet men ökar utdata­storleken.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Utelämna ett teckensnitt endast när du är säker på att målwebbläsarna eller systemen redan tillhandahåller det. För varumärkesteckensnitt eller mindre vanliga teckensnitt är inbäddning vanligtvis säkrare.

## **Länka teckensnittsfiler istället för att bädda in dem**

För att minska HTML‑filens storlek kan du skriva teckensnittsdata till separata WOFF‑filer och lägga till `@font-face`‑regler i HTML. Detta kräver en kontroller som anpassar hur teckensnittsdata skrivs under export. I Python via .NET implementerar du den kontrollen i ett litet .NET‑hjälpassembly, läser in den i Python och skickar hjälpar‑objektet till [HtmlFormatter](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmlformatter/) med `create_custom_formatter`.

När du externaliserar teckensnitt, välj två sökvägar med avsikt:

- Filsystemets utdatamapp där genererade WOFF‑filer skrivs.
- URL‑sökvägen som kommer att visas i HTML‑dokumentet och som webbläsaren använder för att ladda dessa teckensnittsfiler.

Behåll HTML‑filen och de genererade teckensnittsfilerna tillsammans tills distributionssökvägarna är definitiva. Om filerna distribueras till en annan plats, låt URL‑prefixet matcha den distribuerade URL‑sökvägen.

## **Spara resurser externt**

Självständigt HTML är lätt att flytta, men inbäddade Base64‑resurser kan göra filen stor. Om din applikation behöver externa bild‑, teckensnitt‑, ljud‑ eller videofiler, använd en egen länk‑/inbäddningskontroller och skicka den till [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/)-konstruktorn.

När du externaliserar resurser, välj två sökvägar med avsikt:

- Filsystems‑utdata‑sökväg där din applikation skriver genererade bilder, teckensnitt, ljud eller video.
- URL‑sökväg, vilket är vad webbläsaren använder från HTML‑dokumentet för att ladda dessa filer.

För en fullständig diskussion om bildlänkning, se [Export Presentations to HTML with Externally Linked Images](/slides/sv/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportera mediafiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exporterar video‑ och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: katalogen där genererade mediefiler skrivs.
- `file_name`: HTML‑filnamnet som genereras.
- `base_uri`: det absoluta URI‑prefixet som används i HTML‑länkarna till mediefiler.

Om HTML‑filen är `html-output/presentation.html` och mediefiler sparas i `html-output/media`, bör `path` peka på mediakatalogen på disken, medan `base_uri` ska peka på samma katalog ur webbläsarens perspektiv. För lokal förhandsvisning kan du bygga ett `file:///`‑URI från mediakatalogen. För en distribuerad applikation, använd den absoluta URL‑en till den publicerade mediakatalogen.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Använd utdatakataloger som är unika per exportjobb, särskilt i serverapplikationer. Delade utdatakataloger kan leda till att filer från olika konverteringar skrivs över varandra.

## **Prestanda och resurshantering**

HTML‑konvertering är en renderingsoperation, så behandlingstid och minnesbruk beror på antal bilder, bildupplösning, teckensnitt, effekter, diagram och inbäddad media. Högre `pictures_compression`‑DPI‑värden, inbäddade teckensnitt, SVG‑utmatning och behållna beskurna bildområden kan förbättra trohet men ökar vanligtvis filstorleken.

För batch‑konvertering:

- Avyttra varje [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans omedelbart.
- Använd separata utdatakataloger för separata jobb.
- Undvik att bädda in vanliga teckensnitt om inte trohet kräver det.
- Sänk bild‑DPI när HTML‑filen bara ska användas för förhandsvisning eller miniatyrer.
- Behåll källpresentationen, den genererade HTML‑filen och externa resurser tillsammans tills distributionssökvägarna är definitiva.

## **FAQ**

**Behåller hyperlänkar sina funktioner i HTML‑utdata?**

Ja. Hyperlänkar i presentationen exporteras till HTML och förblir klickbara när mål‑URL:en är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans mellan trådar. Bearbeta olika filer med separata presentations‑instanser, separata strömmar och separata utdatakataloger. Se [multithreading guidance](/slides/sv/python-net/multithreading/) för detaljer.

**Är en Presentation‑objekt trådsäker?**

Nej. En enskild [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans bör laddas, modifieras, sparas och avyttras på en enda tråd. För parallellt arbete, skapa en oberoende instans per tråd eller process.

**Varför är den genererade HTML‑filen stor?**

Standard‑exporten kan bädda in resurser direkt i HTML. Inbäddade teckensnitt, hög‑DPI‑bilder, media, SVG‑innehåll och behållna beskurna bildområden ökar också storleken. Använd externa resurser, uteslut vanliga teckensnitt från inbäddning och sänk `pictures_compression` när mindre filstorlek är viktigare än maximal trohet.

**Varför visas en PowerPoint‑teckenstorlek som 24 pt som 17.999819 pt i HTML?**

Detta kan ske eftersom PowerPoint och HTML använder olika DPI‑modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserade på 72 DPI, medan HTML‑layout baseras på CSS‑pixlar i en 96 DPI‑modell. När Aspose.Slides exporterar en presentation till HTML översätts teckenstorleken mellan dessa system, och konverteringen kan introducera små avrundningsskillnader.

Dessa värden indikerar inte en verklig visuell förändring av teckenstorleken. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur bör jag välja base_uri för media‑export?**

Välj `base_uri` ur webbläsarens perspektiv och skicka den som ett absolut URI. För lokal förhandsvisning kan du härleda den från utdatakatalogen med `Path(media_directory).as_uri() + "/"`. För distribution, använd den absoluta URL‑en till den publicerade mediakatalogen. Filsystems‑`path` och webbläsar‑`base_uri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `show_hidden_slides = True` på [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/) när dolda bilder måste exporteras.