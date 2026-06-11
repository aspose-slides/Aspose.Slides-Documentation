---
title: Wykres
type: docs
weight: 60
url: /pl/androidjava/examples/elements/chart/
keywords:
- przykład kodu
- wykres
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Opanuj wykresy przy użyciu Aspose.Slides dla Androida: twórz, formatuj, powiązuj dane i eksportuj wykresy w formatach PPT, PPTX i ODP przy użyciu przykładów w Javie."
---
Przykłady dodawania, uzyskiwania dostępu, usuwania i aktualizacji różnych typów wykresów przy użyciu **Aspose.Slides for Android via Java**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**

Ta metoda dodaje prosty wykres obszarowy do pierwszego slajdu.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dodaj prosty wykres obszarowy do pierwszego slajdu.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do wykresu**

Po utworzeniu wykresu możesz go pobrać za pośrednictwem kolekcji kształtów.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Uzyskaj dostęp do pierwszego wykresu na slajdzie.
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

## **Usuń wykres**

Poniższy kod usuwa wykres ze slajdu.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Usuń wykres.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Aktualizuj dane wykresu**

Możesz zmienić właściwości wykresu, takie jak tytuł.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Zmień tytuł wykresu.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```