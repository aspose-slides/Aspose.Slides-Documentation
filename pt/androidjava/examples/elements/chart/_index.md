---
title: Gráfico
type: docs
weight: 60
url: /pt/androidjava/examples/elements/chart/
keywords:
- exemplo de código
- gráfico
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Domine gráficos com Aspose.Slides para Android: crie, formate, vincule dados e exporte gráficos em PPT, PPTX e ODP com exemplos em Java."
---
Exemplos de adição, acesso, remoção e atualização de diferentes tipos de gráfico com **Aspose.Slides for Android via Java**. Os trechos abaixo demonstram operações básicas com gráficos.

## **Adicionar um Gráfico**

Este método adiciona um gráfico de área simples ao primeiro slide.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adiciona um gráfico de área simples ao primeiro slide.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Gráfico**

Depois de criar um gráfico, você pode recuperá-lo através da coleção de formas.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Acesse o primeiro gráfico no slide.
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

## **Remover um Gráfico**

O código a seguir remove um gráfico de um slide.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Remova o gráfico.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar Dados do Gráfico**

Você pode alterar propriedades do gráfico, como o título.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Altere o título do gráfico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```