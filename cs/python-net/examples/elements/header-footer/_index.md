---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/python-net/examples/elements/header-footer/
keywords:
- záhlaví a zápatí
- přidat záhlaví a zápatí
- aktualizovat záhlaví a zápatí
- nastavit datum a čas
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Řízení záhlaví a zápatí v Pythonu s Aspose.Slides: přidání nebo úprava data/času, čísel snímků a textu zápatí, zobrazení nebo skrytí zástupných znaků v PPT, PPTX a ODP."
---
Ukazuje, jak přidat zápatí a aktualizovat zástupné znaky data a času pomocí **Aspose.Slides for Python via .NET**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zajistěte, aby byl viditelný.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizovat datum a čas**

Upravte zástupný znak data a času na snímku.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```