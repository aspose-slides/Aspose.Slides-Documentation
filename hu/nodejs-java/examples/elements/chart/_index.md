---
title: Diagram
type: docs
weight: 60
url: /hu/nodejs-java/examples/elements/chart/
keywords:
- kódpélda
- diagram
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Működjön a diagramokkal az Aspose.Slides for Node.js via Java segítségével: hozza létre, formázza, kössön adatot, és exportálja a diagramokat PPT, PPTX és ODP formátumokba JavaScript példákkal."
---
Példák különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére az **Aspose.Slides for Node.js via Java** használatával. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad az első diára.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Egyszerű területdiagram hozzáadása az első diára.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram elérése**

Diagram létrehozása után a shape gyűjteményen keresztül érhető vissza.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Az első diagram elérése a dián.
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

## **Diagram eltávolítása**

Az alábbi kód eltávolítja a diagramot a diáról.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Diagram eltávolítása.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagramadatok frissítése**

A diagram tulajdonságait, például a címet, meg lehet változtatni.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // A diagram címének módosítása.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```