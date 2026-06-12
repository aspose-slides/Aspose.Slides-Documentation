---
title: Graf
type: docs
weight: 60
url: /cs/androidjava/examples/elements/chart/
keywords:
- ukázka kódu
- graf
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Mistrovské ovládání grafů s Aspose.Slides for Android: vytvářejte, formátujte, propojujte data a exportujte grafy v PPT, PPTX a ODP pomocí Java příkladů."
---
Příklady přidávání, přístupu, odstraňování a aktualizace různých typů grafů pomocí **Aspose.Slides for Android via Java**. Níže uvedené ukázky demonstrují základní operace s grafy.

## **Přidat graf**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Přidejte jednoduchý plošný graf na první snímek.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k grafu**

Po vytvoření grafu jej můžete získat prostřednictvím kolekce tvarů.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Přístup k prvnímu grafu na snímku.
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

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Odstraňte graf.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```


## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například název.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Změňte název grafu.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```