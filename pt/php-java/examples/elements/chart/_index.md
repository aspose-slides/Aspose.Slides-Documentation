---
title: Gráfico
type: docs
weight: 60
url: /pt/php-java/examples/elements/chart/
keywords:
- gráfico
- adicionar gráfico
- acessar gráfico
- remover gráfico
- atualizar gráfico
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie e personalize gráficos em PHP com Aspose.Slides: adicione dados, formate séries, eixos e rótulos, altere tipos e exporte — funciona com PPT, PPTX e ODP."
---
Exemplos de adição, acesso, remoção e atualização de diferentes tipos de gráficos com **Aspose.Slides for PHP via Java**. Os trechos abaixo demonstram operações básicas de gráficos.

## **Adicionar um Gráfico**

Este método adiciona um gráfico de área simples ao primeiro slide.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adiciona um gráfico de coluna simples ao slide.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar um Gráfico**

Recupere o gráfico da coleção de formas.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessa o primeiro gráfico no slide.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Gráfico**

O código a seguir remove um gráfico de um slide.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é o gráfico.
        $chart = $slide->getShapes()->get_Item(0);

        // Remove o gráfico.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Atualizar Dados do Gráfico**

Você pode alterar propriedades do gráfico, como o título.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supondo que a primeira forma no slide é o gráfico.
        $chart = $slide->getShapes()->get_Item(0);

        // Alterar o título do gráfico.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```