---
title: Gráfico
type: docs
weight: 60
url: /pt/nodejs-java/examples/elements/chart/
keywords:
- exemplo de código
- gráfico
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine gráficos com Aspose.Slides for Node.js via Java: crie, formate, vincule dados e exporte gráficos em PPT, PPTX e ODP com exemplos em JavaScript."
---
Exemplos de como adicionar, acessar, remover e atualizar diferentes tipos de gráfico com **Aspose.Slides for Node.js via Java**. Os trechos de código abaixo demonstram operações básicas de gráfico.

## **Adicionar um Gráfico**

Este método adiciona um gráfico de área simples ao primeiro slide.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Adicione um gráfico de área simples ao primeiro slide.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Gráfico**

Depois de criar um gráfico, você pode recuperá-lo através da coleção de formas.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acesse o primeiro gráfico no slide.
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

## **Remover um Gráfico**

O código a seguir remove o gráfico do slide.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Remova o gráfico.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar Dados do Gráfico**

Você pode alterar propriedades do gráfico, como o título.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Altere o título do gráfico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```