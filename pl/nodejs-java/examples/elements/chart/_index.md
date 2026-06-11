---
title: Wykres
type: docs
weight: 60
url: /pl/nodejs-java/examples/elements/chart/
keywords:
- przykład kodu
- wykres
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Mistrzowskie wykresy z Aspose.Slides for Node.js via Java: twórz, formatuj, podłączaj dane i eksportuj wykresy w formatach PPT, PPTX i ODP z przykładami JavaScript."
---
Przykłady dodawania, uzyskiwania dostępu, usuwania i aktualizowania różnych typów wykresów przy użyciu **Aspose.Slides for Node.js via Java**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**

Ta metoda dodaje prosty wykres obszarowy do pierwszego slajdu.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Dodaj prosty wykres obszarowy do pierwszego slajdu.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do wykresu**

Po utworzeniu wykresu możesz go pobrać za pośrednictwem kolekcji kształtów.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do pierwszego wykresu na slajdzie.
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

## **Usuń wykres**

Poniższy kod usuwa wykres ze slajdu.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Usuń wykres.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aktualizuj dane wykresu**

Możesz zmienić właściwości wykresu, takie jak tytuł.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Zmień tytuł wykresu.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```