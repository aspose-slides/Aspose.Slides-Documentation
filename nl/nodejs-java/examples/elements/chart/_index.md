---
title: Grafiek
type: docs
weight: 60
url: /nl/nodejs-java/examples/elements/chart/
keywords:
- codevoorbeeld
- grafiek
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer grafieken met Aspose.Slides voor Node.js via Java: maak, formatteer, koppel gegevens en exporteer grafieken in PPT, PPTX en ODP met JavaScript-voorbeelden."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektypen met **Aspose.Slides for Node.js via Java**. De onderstaande fragmenten tonen basisbewerkingen met grafieken.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige gebiedsgrafiek toe aan de eerste dia.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Voeg een eenvoudige gebiedsgrafiek toe aan de eerste dia.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiek benaderen**

Nadat een grafiek is aangemaakt, kun je deze ophalen via de vormcollectie.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Benader de eerste grafiek op de dia.
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

## **Grafiek verwijderen**

De volgende code verwijdert de grafiek van de dia.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Verwijder de grafiek.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiekdata bijwerken**

Je kunt grafiekeigenschappen aanpassen, zoals de titel.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Wijzig de grafiektitel.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```