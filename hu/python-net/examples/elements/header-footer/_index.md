---
title: "Fejléc és lábléc"
type: docs
weight: 220
url: /hu/python-net/examples/elements/header-footer/
keywords:
- "fejléc lábléc"
- "fejléc és lábléc hozzáadása"
- "fejléc és lábléc frissítése"
- "dátum és idő beállítása"
- "kódpéldák"
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fejlécek és láblécek kezelése Pythonban az Aspose.Slides segítségével: dátum/óra, diák száma és láblécszöveg hozzáadása vagy szerkesztése, helyőrzők megjelenítése vagy elrejtése PPT, PPTX és ODP formátumokban."
---
Bemutatja, hogyan adhatók hozzá láblécek, és frissíthetők a dátum- és időhelyőrzők az **Aspose.Slides for Python via .NET** használatával.

## **Lábléc hozzáadása**

Adjon szöveget a diák lábléc területéhez, és tegye láthatóvá.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Dátum és idő frissítése**

Módosítsa a dián lévő dátum- és időhelyőrzőt.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```