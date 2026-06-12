---
title: Grafiek
type: docs
weight: 60
url: /nl/java/examples/elements/chart/
keywords:
- codevoorbeeld
- grafiek
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer grafieken met Aspose.Slides for Java: maak, formatteer, koppel gegevens en exporteer grafieken naar PPT, PPTX en ODP met Java-voorbeelden."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektypen met **Aspose.Slides for Java**. De onderstaande fragmenten demonstreren basisgrafiekbewerkingen.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige vlakgrafiek toe aan de eerste dia.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Voeg een eenvoudige vlakgrafiek toe aan de eerste dia.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Grafiek benaderen**

Na het aanmaken van een grafiek kun je deze ophalen via de vormverzameling.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Benader de eerste grafiek op de dia.
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

De volgende code verwijdert een grafiek van een dia.

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

## **Grafiekgegevens bijwerken**

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