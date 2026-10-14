---
title: Personalizar Gráficos de Pizza em Apresentações Usando PHP
linktitle: Gráfico de Pizza
type: docs
url: /pt/php-java/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plot
- cor da fatia
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e personalize gráficos de pizza em PHP com Aspose.Slides. Configure plots secundários, exiba rótulos de dados e aplique cores automáticas nas fatias no PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plot secundário para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos se concentram em tarefas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados, e salvar a apresentação atualizada.

## **Opções de Plot Secundário para Gráficos Pie of Pie e Bar of Pie**

O Aspose.Slides for PHP via Java oferece suporte a opções de plot secundário para gráficos Pie of Pie e Bar of Pie. Essas opções controlam o tamanho do plot secundário e como os pontos de dados são divididos entre os dois plots.

O exemplo a seguir cria um gráfico Pie of Pie em uma nova apresentação e exibe os valores dos pontos de dados como rótulos. O método [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) define o tamanho do plot secundário em 149% do plot principal. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) seleciona a divisão baseada em porcentagem, e [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) define o limite em 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Exibir valores e configurar o plot secundário.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Selecionar Categorias para o Plot Secundário**

Use a divisão personalizada quando quiser agrupar categorias específicas no plot secundário independentemente de seus valores percentuais. Por exemplo, um relatório de vendas pode mostrar Online e Events juntos para que os leitores comparem esses dois canais, mesmo que eles representem 35% e 10% das vendas totais.

Chame [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) com [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) e selecione os pontos através de [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). O método [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) da coleção aceita um índice baseado em zero na série; use [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) para adicionar um objeto de ponto de dados. Neste exemplo, o índice 1 seleciona Online, e o ponto no índice 3 seleciona Events. Partners também é adicionado temporariamente, e depois excluído usando [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Substitua os dados padrão por vendas por canal.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Selecione Online pelo seu índice baseado em zero e Events pelo seu objeto de ponto de dados.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Exclua Partners da seleção sem excluir seus dados de origem.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) e Events (10) aparecem como fatias separadas no plot secundário. No plot principal, eles são representados por uma única fatia combinada com valor 45, ao lado de Retail (40) e Partners (15). Remover Partners da seleção personalizada mantém‑lo no plot principal; não remove a categoria ou seu valor dos dados de origem do gráfico.

A imagem a seguir mostra a apresentação salva no PowerPoint:

![Gráfico Pie of Pie com Online e Events no plot secundário e seu valor combinado de 45 no plot principal](pie_of_pie_custom.png)

## **Definir Cores Automáticas para Fatias de Gráfico de Pizza**

O Aspose.Slides for PHP via Java pode atribuir cores diferentes automaticamente às fatias de um gráfico de pizza. O exemplo a seguir cria um gráfico de pizza com um título centralizado e substitui os dados padrão por três categorias trimestrais e seus valores. O método [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) exibe os valores 20, 50 e 30 como rótulos, enquanto [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) habilita uma cor distinta para cada fatia.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Adicionar um título de gráfico centralizado.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Substituir os dados padrão usando a primeira planilha.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Exibir valores e atribuir cores diferentes às fatias.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Perguntas Frequentes**

**As variações Pie of Pie e Bar of Pie são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) um plot secundário para gráficos de pizza, incluindo os tipos Pie of Pie e Bar of Pie.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (como PNG) sem exportar a apresentação inteira.