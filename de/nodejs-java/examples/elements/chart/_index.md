---
title: Diagramm
type: docs
weight: 60
url: /de/nodejs-java/examples/elements/chart/
keywords:
- Codebeispiel
- Diagramm
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Meistern Sie Diagramme mit Aspose.Slides für Node.js via Java: Erstellen, formatieren, Daten binden und Diagramme in PPT, PPTX und ODP exportieren mit JavaScript-Beispielen."
---
Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for Node.js via Java**. Die nachstehenden Snippets demonstrieren grundlegende Diagramm‑Operationen.

## **Diagramm hinzufügen**

Diese Methode fügt dem ersten Folie ein einfaches Flächendiagramm hinzu.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Füge ein einfaches Flächendiagramm zur ersten Folie hinzu.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Auf ein Diagramm zugreifen**

Nach dem Erstellen eines Diagramms können Sie es über die Shape Collection abrufen.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Greife auf das erste Diagramm auf der Folie zu.
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

## **Diagramm entfernen**

Der folgende Code entfernt das Diagramm von der Folie.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Entferne das Diagramm.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Ändere den Diagrammtitel.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```