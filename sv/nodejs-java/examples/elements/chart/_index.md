---
title: Diagram
type: docs
weight: 60
url: /sv/nodejs-java/examples/elements/chart/
keywords:
- kodexempel
- diagram
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska diagram med Aspose.Slides för Node.js via Java: skapa, formatera, binda data och exportera diagram i PPT, PPTX och ODP med JavaScript-exempel."
---
Exempel på att lägga till, komma åt, ta bort och uppdatera olika diagramtyper med **Aspose.Slides for Node.js via Java**. Nedanstående kodsnuttar demonstrerar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Denna metod lägger till ett enkelt område-diagram på den första bilden.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Lägg till ett enkelt område-diagram på den första bilden.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt ett diagram**

Efter att ha skapat ett diagram kan du hämta det via formsamlingen.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till det första diagrammet på bilden.
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

## **Ta bort ett diagram**

Följande kod tar bort diagrammet från bilden.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ta bort diagrammet.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uppdatera diagramdata**

Du kan ändra diagrammets egenskaper, till exempel titeln.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Ändra diagramtitel.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```