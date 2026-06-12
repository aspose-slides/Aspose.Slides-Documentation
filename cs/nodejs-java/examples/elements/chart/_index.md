---
title: Graf
type: docs
weight: 60
url: /cs/nodejs-java/examples/elements/chart/
keywords:
- ukázka kódu
- graf
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte grafy s Aspose.Slides pro Node.js přes Java: vytvářejte, formátujte, svazujte data a exportujte grafy ve formátech PPT, PPTX a ODP s příklady v JavaScriptu."
---
Příklady pro přidávání, přístup, odstraňování a aktualizaci různých typů grafů pomocí **Aspose.Slides for Node.js via Java**. Níže uvedené úryvky ukazují základní operace s grafy.

## **Přidat graf**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přidejte jednoduchý plošný graf na první snímek.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k grafu**

Po vytvoření grafu jej můžete získat prostřednictvím kolekce tvarů.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k prvnímu grafu na snímku.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Odstraňte graf.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například název.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Změňte název grafu.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```