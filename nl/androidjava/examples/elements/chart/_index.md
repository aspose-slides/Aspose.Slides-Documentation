---
title: Grafiek
type: docs
weight: 60
url: /nl/androidjava/examples/elements/chart/
keywords:
- codevoorbeeld
- grafiek
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer grafieken met Aspose.Slides voor Android: maak, formateer, koppel gegevens en exporteer grafieken in PPT, PPTX en ODP met Java-voorbeelden."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektype met **Aspose.Slides for Android via Java**. De fragmenten hieronder demonstreren basisbewerkingen op grafieken.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige gebiedsgrafiek toe aan de eerste dia.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een eenvoudige gebiedsgrafiek toe aan de eerste dia.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiek benaderen**

Na het maken van een grafiek kun je deze ophalen via de vormverzameling.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Toegang tot de eerste grafiek op de dia.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiek verwijderen**

De onderstaande code verwijdert een grafiek van een dia.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Verwijder de grafiek.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Gegevens van een grafiek bijwerken**

Je kunt grafiekeigenschappen wijzigen, zoals de titel.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Wijzig de grafiektitel.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```