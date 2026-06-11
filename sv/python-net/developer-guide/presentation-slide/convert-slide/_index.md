---
title: Konvertera PowerPoint-bildspel till bilder i Python
linktitle: Bildspel till bild
type: docs
weight: 41
url: /sv/python-net/convert-slide/
keywords:
- konvertera bildspel
- konvertera bildspel till bild
- exportera bildspel som bild
- spara bildspel som bild
- bildspel till bild
- bildspel till PNG
- bildspel till JPEG
- bildspel till bitmap
- Python
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint- och OpenDocument-bildspel till olika format med Aspose.Slides för Python via .NET. Exportera enkelt PPTX- och ODP-bildspel till BMP, PNG, JPEG, TIFF och fler med högkvalitativa resultat."
---
## **Introduktion**

Aspose.Slides för Python via .NET gör det enkelt att konvertera PowerPoint- och OpenDocument-presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bild till en bild, följ dessa steg:

1. Definiera de önskade konverteringsinställningarna och välj de bildspel du vill exportera genom att använda:
    - Klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) eller
    - Klassen [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/).
2. Generera bildspelets bild genom att anropa `get_image`-metoden från klassen [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/).

I Aspose.Slides för Python via .NET är [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) en klass som låter dig arbeta med bilder definierade av pixeldata. Du kan använda en instans av denna klass för att spara bilder i ett brett sortiment av format (BMP, JPG, PNG, etc.).

## **Konvertera bildspel till bitmap och spara bilderna i PNG**

Du kan konvertera ett bildspel till ett bitmap-objekt och använda det direkt i din applikation. Alternativt kan du konvertera ett bildspel till en bitmap och sedan spara bilden i JPEG eller något annat föredraget format.

Den här Python-koden demonstrerar hur du konverterar den första bilden i en presentation till ett bitmap-objekt och sedan sparar bilden i PNG-format:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Konvertera den första bilden i presentationen till en bitmap.
    with presentation.slides[0].get_image() as image:
        # Spara bilden i PNG-formatet.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Konvertera bildspel till bilder med anpassade storlekar**

Du kan behöva få en bild i en viss storlek. Genom att använda en överlagring från [get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) kan du konvertera ett bildspel till en bild med specifika dimensioner (bredd och höjd).

Den här exempelkoden visar hur du gör detta:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Konvertera den första bilden i presentationen till en bitmap med den angivna storleken.
    with presentation.slides[0].get_image(image_size) as image:
        # Spara bilden i JPEG-formatet.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Konvertera bildspel med anteckningar och kommentarer till bilder**

Vissa bildspel kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två klasser—[TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) och [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/)—som låter dig kontrollera rendering av presentationsbilder till bilder. Båda klasserna innehåller egenskapen `slides_layout_options`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bild när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Den här Python-koden demonstrerar hur du konverterar ett bildspel med anteckningar och kommentarer:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Ange positionen för anteckningarna.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Ange positionen för kommentarerna.
    notes_comments_options.comments_area_width = 500                                       # Ange bredden på kommentarsområdet.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Ange färgen för kommentarsområdet.

    # Skapa renderingsalternativen.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Konvertera den första bilden i presentationen till en bild.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Spara bilden i GIF-formatet.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

I alla bild‑till‑bildkonverteringsprocesser kan inte egenskapen [notes_position](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) sättas till `BOTTOM_FULL` (för att ange positionen för anteckningar) eftersom en antecknings text kan vara för stor, vilket gör att den inte får plats inom den angivna bildstorleken.

{{% /alert %}} 

## **Konvertera bildspel till bilder med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/) ger större kontroll över den resulterande TIFF‑bilden genom att låta dig specificera parametrar som storlek, upplösning, färgpalett och mer.

Den här Python-koden demonstrerar en konverteringsprocess där TIFF‑alternativ används för att skapa en svart‑vit bild med 300 DPI‑upplösning och en storlek på 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Läs in en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Hämta den första bilden från presentationen.
    slide = presentation.slides[0]

    # Konfigurera inställningarna för den utgående TIFF-bilden.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Ange bildstorleken.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Ange pixelformatet (svartvitt).
    options.dpi_x = 300                                                        # Ange horisontell upplösning.
    options.dpi_y = 300                                                        # Ange vertikal upplösning.

    # Konvertera bilden till en bild med angivna alternativ.
    with slide.get_image(options) as image:
        # Spara bilden i TIFF-format.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Konvertera alla bildspel till bilder**

Aspose.Slides låter dig konvertera alla bildspel i en presentation till bilder, vilket effektivt omvandlar hela presentationen till en serie bilder.

Den här exempelkoden visar hur du konverterar alla bildspel i en presentation till bilder i Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Rendera presentationen till bilder, bild för bild.
    for i, slide in enumerate(presentation.slides):
        # Kontrollera dolda bilder (rendera inte dolda bilder).
        if slide.hidden:
            continue

        # Konvertera bilden till en bild.
        with slide.get_image(scale_x, scale_y) as image:
            # Spara bilden i JPEG-formatet.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **FAQ**

**Stöder Aspose.Slides rendering av bildspel med animationer?**

Nej, `get_image`‑metoden sparar endast en statisk bild av bildspelet, utan animationer.

**Kan dolda bildspel exporteras som bilder?**

Ja, dolda bildspel kan behandlas på samma sätt som vanliga. Se bara till att de inkluderas i behandlingsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder rendering av skuggor, transparens och andra grafiska effekter när bildspel sparas som bilder.