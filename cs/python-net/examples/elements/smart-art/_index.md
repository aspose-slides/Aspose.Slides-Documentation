---
title: SmartArt
type: docs
weight: 140
url: /cs/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- přidat SmartArt
- přístup ke SmartArt
- odstranit SmartArt
- rozvržení SmartArt
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a upravujte SmartArt v Pythonu pomocí Aspose.Slides: přidávejte uzly, měňte rozvržení a styly, přesně převádějte na tvary a exportujte do formátů PPT, PPTX a ODP."
---
Ukazuje, jak přidávat grafiku SmartArt, přistupovat k ní, odstraňovat ji a měnit rozvržení pomocí **Aspose.Slides for Python via .NET**.

## **Přidat SmartArt**

Vložte grafiku SmartArt pomocí jednoho z vestavěných rozvržení.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup ke SmartArt**

Získejte první objekt SmartArt na snímku.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Přistupte k prvnímu tvaru SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Odstranit SmartArt**

Smažte tvar SmartArt ze snímku.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je objekt SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Změnit rozvržení SmartArt**

Aktualizujte typ rozvržení existující grafiky SmartArt.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je objekt SmartArt.
        smart_art = slide.shapes[0]

        # Změňte rozvržení SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```