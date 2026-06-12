---
title: Hypertextový odkaz
type: docs
weight: 130
url: /cs/python-net/examples/elements/hyperlink/
keywords:
- hypertextový odkaz
- přidat hypertextový odkaz
- přístup k hypertextovému odkazu
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přidávejte, upravujte a odstraňujte hypertextové odkazy v Pythonu s Aspose.Slides: text odkazů, tvary, snímky, URL adresy a e-mail; nastavujte cíle a akce pro PPT, PPTX a ODP."
---
Ukazuje, jak přidávat, přistupovat, odstraňovat a aktualizovat hypertextové odkazy na tvarech pomocí **Aspose.Slides for Python via .NET**.

## **Přidat hypertextový odkaz**

Vytvořte obdélníkový tvar s hypertextovým odkazem směřujícím na externí webovou stránku.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání hypertextového odkazu**

Přečtěte informace o hypertextovém odkazu z textové části tvaru.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Odstranit hypertextový odkaz**

Odstraňte hypertextový odkaz z textu tvaru.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizovat hypertextový odkaz**

Změňte cíl existujícího hypertextového odkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hypertextový odkaz, což napodobuje bezpečný způsob aktualizace odkazů v PowerPointu.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Změna hypertextového odkazu v existujícím textu by měla být provedena pomocí
        # HyperlinkManager místo přímého nastavení vlastnosti.
        # Tím se napodobuje, jak PowerPoint bezpečně aktualizuje hypertextové odkazy.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```