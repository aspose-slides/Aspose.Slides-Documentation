---
title: Graf
type: docs
weight: 60
url: /cs/python-net/examples/elements/chart/
keywords:
- graf
- přidat graf
- přístup k grafu
- odstranit graf
- aktualizovat graf
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v Pythonu pomocí Aspose.Slides: přidávejte data, formátujte řady, osy a popisky, měňte typy a exportujte - funguje s PPT, PPTX a ODP."
---
Příklady pro přidávání, přístup, odstraňování a aktualizaci různých typů grafů pomocí **Aspose.Slides for Python via .NET**. Níže uvedené úryvky demonstrují základní operace s grafy.

## **Přidat graf**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidá jednoduchý sloupcový graf na první snímek.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k grafu**

Následující kód načte graf ze sbírky tvarů.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Získá první graf na snímku.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je graf.
        chart = slide.shapes[0]

        # Odstraní graf.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například název.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je graf.
        chart = slide.shapes[0]

        # Změní název grafu.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```