---
title: Graf
type: docs
weight: 60
url: /cs/java/examples/elements/chart/
keywords:
- ukázka kódu
- graf
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládejte grafy pomocí Aspose.Slides pro Java: vytvářejte, formátujte, svazujte data a exportujte grafy do PPT, PPTX a ODP s ukázkami v jazyce Java."
---
Příklady pro přidávání, přístup, odstraňování a aktualizaci různých typů grafů pomocí **Aspose.Slides for Java**. Následující úryvky demonstrují základní operace s grafy.

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

## **Přístup ke grafu**

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

        // Odeberte graf.
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