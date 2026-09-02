---
title: Konvertera presentationsbilder till bilder i Python
linktitle: Bild till bild
type: docs
weight: 41
url: /sv/python-net/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i Python med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides for Python via .NET kan rendera enskilda bilder från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till ett bildformat, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) .
4. Anropa metoden [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) . Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑objekt.
5. Anropa metoden [IImage.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/save/) och specificera utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/)‑värde.

## **Konvertera en bild till en PNG‑bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑objektet kan behandlas i minnet eller sparas till en fil.

Följande Python‑exempel renderar den första bilden och sparar den som en PNG‑bild:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Konvertera bilder till bildformat med anpassade storlekar**

Använd överlagringen av [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) som accepterar ett [Size](https://reference.aspose.com/slides/sv/python-net/aspose.pydrawing/size/)‑värde för att rendera en bild med exakt pixeldimensioner.

Följande exempel skapar en 1820 × 1040 JPEG‑bild:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Konvertera bilder med anteckningar och kommentarer till bildformat**

Som standard innehåller inte bildfiler anteckningar eller kommentarer. Tilldela ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till egenskapen [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
För konvertering från bild till bildformat ska du inte sätta egenskapen [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) till [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notespositions/). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd istället [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notespositions/) .
{{% /alert %}}

## **Konvertera bilder till bildformat med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) låter dig kontrollera storlek, upplösning och andra egenskaper för den renderade TIFF‑bilden.

Följande exempel renderar den första bilden som en 2160 × 2880 TIFF‑bild med 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Konvertera alla bilder till bildformat**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bilder. Dolda bilder inkluderas om du inte uttryckligen hoppar över dem.

Följande exempel renderar varje bild som en JPEG‑bild med horisontella och vertikala skalningsfaktorer på 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Skapa Enhanced Metafile‑utdata**

Enhanced Metafile (EMF) är användbart när vektorbaserad grafik måste utbytas med Microsoft Office eller andra Windows‑applikationer som stöder Windows‑metafiler. Till skillnad från en pixelbaserad bild kan en EMF bevara vektorritningsoperationer som skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för applikationer med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom rasterbilder och vissa effekter, lagras som rasteriserade element i vektormetafilbehållaren.

### **Exportera en bild till EMF**

Metoden [Slide.write_as_emf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/write_as_emf/) skriver en [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/) till ett mål‑ström i EMF‑format. Följande exempel laddar en presentation, väljer den första bilden och skriver den till ett EMF‑filström:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Anroparen äger strömmen som skickas till [Slide.write_as_emf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/write_as_emf/) och måste stänga den. Aspose.Slides skriver på strömmens aktuella position och lämnar strömmen öppen.

### **Konvertera en SVG‑bild till EMF och lägg till den i en presentation**

Använd [SvgImage.write_as_emf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/write_as_emf/) för att konvertera SVG‑innehåll till EMF. De resulterande bytes kan läggas till i presentationen via [ImageCollection.add_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/add_image/) och placeras på en bild med [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/) .

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) från SVG‑markup, konverterar den till en EMF i minnet, infogar metafilen på den första bilden och sparar presentationen:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/write_as_emf/) tar inte ägandeskap av destinationsströmmen. Efter skrivning är strömmens position i slutet av den genererade datan. Anropa `getvalue` för att erhålla hela bufferten oavsett aktuell strömposition, som visas ovan. Håll strömmen öppen tills data har lästs och stäng den därefter.

EMF‑generering är tillgänglig på de operativsystem som stöds av Aspose.Slides för Python via .NET, men rendering kan skilja sig mellan plattformar när teckensnitt eller inbyggda grafikberoenden saknas. Installera de teckensnitt som används av källinnehållet eller konfigurera lämpliga ersättningar, följ [platform requirements](/slides/sv/python-net/system-requirements/) för Aspose.Slides och verifiera resultatet i den EMF‑konsumerande applikationen. Linux‑ och macOS‑applikationer har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Färgrik Emoji‑rendering**

{{% alert title="Obs" color="info" %}}
För att rendera färgade emojis korrekt vid konvertering av presentationsbilder till bildformat måste emoji‑teckensnitten som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emojis visas i monokrom i utskriftsbilderna.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) renderar en statisk bild av bilden och exporterar inte animationer.

**Kan dolda bilder exporteras som bildformat?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som visas i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfiler?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödda grafiska effekter i bildfiler.