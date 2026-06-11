---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/python-net/examples/elements/header-footer/
keywords:
- sidhuvud och sidfot
- lägga till sidhuvud och sidfot
- uppdatera sidhuvud och sidfot
- ange datum och tid
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Styr sidhuvuden och sidfötter i Python med Aspose.Slides: lägg till eller redigera datum/tid, bildnummer och sidfotstext, visa eller dölja platshållare i PPT, PPTX och ODP."
---
Visar hur man lägger till sidfot och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for Python via .NET**.

## **Lägg till en sidfot**

Lägg till text i sidfotens område på en bild och gör den synlig.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```