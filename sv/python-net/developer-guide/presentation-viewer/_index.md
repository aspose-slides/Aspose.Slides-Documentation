---
title: Skapa en presentationsvisare i Python
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/python-net/presentation-viewer/
keywords:
- visa presentation
- presentationsvisare
- skapa presentationsvisare
- visa PPT
- visa PPTX
- visa ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Lär dig hur du skapar en anpassad presentationsvisare i Python med Aspose.Slides. Visa enkelt PowerPoint‑filer (PPTX, PPT) och OpenDocument‑filer (ODP) utan Microsoft PowerPoint eller annan kontorsprogramvara."
---
## **Introduktion**

Aspose.Slides för Python används för att skapa presentationsfiler med bilder. Dessa bilder kan visas genom att öppna presentationerna i Microsoft PowerPoint, till exempel. Men utvecklare kan ibland behöva se bilder som bilder i deras föredragna bildvisare eller använda dem i en anpassad presentationsvisare. I sådana fall låter Aspose.Slides dig exportera enskilda bilder som bilder. Den här artikeln förklarar hur du gör det.

## **Generera en SVG-bild från en bild**

För att generera en SVG-bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Öppna en filström.
1. Spara bilden som en SVG-bild till filströmmen.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Skapa en miniatyrbild av en bild**

Aspose.Slides hjälper dig att skapa miniatyrbilder av bilder. För att generera en miniatyrbild av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Skapa en miniatyrbild av den refererade bilden i önskad skala.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Skapa en miniatyrbild med användardefinierade dimensioner**

För att skapa en miniatyrbild av en bild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Generera en miniatyrbild av den refererade bilden med de specificerade dimensionerna.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Skapa en miniatyrbild med talarnoter**

För att generera en miniatyrbild av en bild med talarnoter med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/).
1. Använd egenskapen `RenderingOptions.slides_layout_options` för att ange positionen för talarnoter.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Generera en miniatyrbild av den refererade bilden med hjälp av renderingsalternativen.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Liveexempel**

Prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/sv/viewer/)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en ASP.NET-webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bilder som [bilder](/slides/sv/python-net/convert-powerpoint-to-png/) eller [HTML](/slides/sv/python-net/convert-powerpoint-to-html/) och visa dem i webbläsaren. Navigations- och zoomfunktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bilder i en anpassad .NET-visare?**

Det rekommenderade tillvägagångssättet är att rendera varje bild som en [bild](/slides/sv/python-net/convert-powerpoint-to-png/) (t.ex. PNG eller SVG) eller konvertera den till [HTML](/slides/sv/python-net/convert-powerpoint-to-html/) med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller HTML‑behållare (för webb).

**Hur hanterar jag stora presentationer med många bilder?**

För stora bildspel, överväg lazy‑loading eller rendering på begäran av bilder. Detta innebär att generera en bilds innehåll endast när användaren navigerar till den, vilket minskar minnes- och laddningstid.