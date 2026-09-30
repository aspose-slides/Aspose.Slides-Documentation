---
title: Personalizar legendas de gráficos em apresentações usando PHP
linktitle: Legenda do Gráfico
type: docs
url: /pt/php-java/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides for PHP via Java para otimizar apresentações PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides for PHP via Java oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para a legenda inteira, formatar uma entrada individual da legenda e ocultar ou restaurar entradas selecionadas.

A FAQ cobre comportamentos relacionados, incluindo reservar espaço para a legenda, exibir rótulos multilinha e herdar formatação do tema da apresentação.

## **Posicionamento da Legenda**

Use os métodos [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) e [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) da legenda para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividindo os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico converte‑os em valores relativos: a legenda é deslocada 50 pontos a partir do canto superior esquerdo do gráfico e dimensionada em 100 × 100 pontos. O exemplo usa **java_values** para converter as dimensões do gráfico retornadas pela PHP/Java Bridge em números PHP antes da divisão.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Expresse a posição e o tamanho da legenda em relação ao gráfico.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir o Tamanho da Fonte de uma Legenda**

Use o [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) da legenda para acessar sua formatação de texto e use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para definir o tamanho da fonte em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Ele também desabilita os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir o Tamanho da Fonte de uma Entrada Individual da Legenda**

Use a coleção retornada pelo método [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) da legenda para acessar a formatação de uma entrada específica. Os índices das entradas são baseados em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujos dados padrão incluem ao menos duas séries. Ele formata a segunda entrada da legenda com texto em negrito, itálico e azul de 20 pontos.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ocultar Entradas Individuais da Legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, chame [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) com `true` através de [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Isso oculta apenas a entrada de legenda selecionada; não remove a série nem seus pontos de dados. Chamar [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) com `false`, por contraste, oculta a legenda inteira.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada chamando [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) com `false` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Restaurar a mesma entrada sem mudar os dados do gráfico.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas visíveis e com a segunda entrada oculta. As colunas da segunda série permanecem inalteradas.

![Comparação de um gráfico com todas as entradas de legenda visíveis e com a Série 2 oculta da legenda; todas as colunas permanecem visíveis.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas da legenda identificam séries. Nos gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na fatia selecionada. A API documenta esse método de ponto de dados para os tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Não presuma que ele se aplique a gráficos de rosquinha, que não estão incluídos nessa lista.

## **FAQ**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô‑la?**

Sim. Chame [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) com `false` para reservar espaço para a legenda em vez de permitir que ela sobreponha a área do gráfico.

**Posso criar rótulos de legenda multilinha?**

Sim. Rótulos longos podem quebrar quando a largura disponível é insuficiente. Você também pode usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Deixe as cores, preenchimentos e fontes da legenda sem definição para que ela possa herdar a formatação do tema. Formatação explícita substitui as configurações correspondentes do tema.