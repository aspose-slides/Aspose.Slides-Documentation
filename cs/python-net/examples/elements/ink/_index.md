---
title: Inkoust
type: docs
weight: 180
url: /cs/python-net/examples/elements/ink/
keywords:
- inkoust
- přístup k inkoustu
- odstranění inkoustu
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zpracovávejte digitální inkoust na snímcích v Pythonu pomocí Aspose.Slides: přidejte tahy pera, upravujte cesty, nastavte barvu a šířku a exportujte výsledky pro PowerPoint a OpenDocument."
---
Poskytuje příklady přístupu k existujícím inkoustovým tvarům a jejich odebrání pomocí **Aspose.Slides for Python via .NET**.

> ❗ **Poznámka:** Inkoustové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové inkoustové tahy, ale můžete číst a upravovat existující inkoust.

## **Přístup k inkoustu**

Získejte první inkoustový tvar ze snímku.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Odebrání inkoustu**

Odstraňte inkoustový tvar ze snímku.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je objekt Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```