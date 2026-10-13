---
title: Personalizar eixos de gráficos em apresentações usando PHP
linktitle: Eixo de Gráfico
type: docs
url: /pt/php-java/chart-axis/
keywords:
- eixo do gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como usar Aspose.Slides para PHP via Java para personalizar eixos de gráficos em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar eixos de gráficos com Aspose.Slides para PHP via Java. Ele abrange valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e marcas de escala, categorias de data e formatação, rotação de título, posicionamento do eixo, unidades de exibição e escala logarítmica.

## **Obter os Valores Máximos no Eixo Vertical dos Gráficos**

Crie uma [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) antes de ler os valores de eixo calculados para que o layout do gráfico esteja atualizado.

Leia [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) e [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) para os limites do eixo, e [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) e [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) para os intervalos das marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) e [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) fornecem escalas de unidades de tempo, relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Trocar os Dados entre Eixos**

Use [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) para trocar os papéis de séries e categorias nos dados do gráfico. Cada categoria anterior torna‑se uma série, e cada série anterior torna‑se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Desabilitar o Eixo Vertical para Gráficos de Linha**

Chame [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) com `false` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo vertical oculto.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Desabilitar o Eixo Horizontal para Gráficos de Linha**

Chame [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) com `false` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo horizontal oculto.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alterar um Eixo de Categoria**

Use [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como o primeiro shape do primeiro slide e células de categoria contendo valores numéricos de data do Excel. Ele altera o eixo horizontal para um eixo de data. Chamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) com `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) com `1` e [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) com `TimeUnitType::Months` posiciona marcas principais em intervalos de um mês.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar Intervalos de Rótulos do Eixo de Categoria**

Quando um gráfico tem muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Chame [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) com `false`, então passe o intervalo de categoria desejado para [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe cada terceiro rótulo, ocultando dois rótulos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente todos os rótulos.

Marcas de escala têm controles separados. Chame [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) com `false` e use [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) para definir seu intervalo. Por exemplo, `1` mantém uma marca em cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Use [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) com um estilo visível para ver o resultado. Definir novamente qualquer um dos setters de espaçamento automático com `true` permite que o gráfico escolha aquele intervalo novamente.

O exemplo autônomo a seguir cria 24 categorias e uma série, então salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e restauração do espaçamento automático. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. O texto do rótulo horizontal facilita a visualização da densidade.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Slide 2: mostrar cada terceiro rótulo, mas manter uma marca de escala para cada categoria.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slide 3: deixar o gráfico escolher ambos os intervalos novamente.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Espaçamento automático (slide 1):** Nesta renderização, cada segundo rótulo de categoria é exibido e quebra em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e renderizador.

![Espaçamento automático de rótulo de categoria com todas as 24 colunas visíveis](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas permanecem em cada intervalo de categoria. Todas as 24 colunas, inclusive as sem rótulo, continuam visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Intervalo manual de rótulo de categoria de três com todas as 24 colunas visíveis](category-axis-manual.png)

### **Escolher o Eixo e Intervalo Correto**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de coluna, linha, área ou barra. Em um gráfico de coluna, ele é o eixo horizontal. Em um gráfico de barra horizontal, o eixo de categoria é vertical, portanto aplique essas configurações ao eixo retornado por [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). O espaçamento de marcas de escala também se aplica a um eixo de série em gráficos que o possuam.

Não use espaçamento de rótulos de categoria para definir a escala numérica de um eixo de valor. Em um eixo de valor, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) especifica uma diferença em valores: por exemplo, uma unidade principal de `10` produz marcas em 0, 10, 20 etc., quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente de seus valores de dados. Gráficos de dispersão e bolha usam eixos de valor em vez de um eixo de categoria de texto. Para um eixo de data, use unidades principais e escalas baseadas em tempo conforme descrito em [Alterar um Eixo de Categoria](#alterar-um-eixo-de-categoria).

## **Definir o Formato de Data para Valores do Eixo de Categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números seriais OLE Automation na primeira planilha (índice `0`), calculados como o número de dias desde 30 de dezembro de 1899, para essas datas. Use [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) com `CategoryAxisType::Date`, chame [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) com `false` e passe `yyyy` para [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) para que os rótulos de categoria exibam anos de quatro dígitos independentemente da formatação da célula.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir um Ângulo de Rotação para o Título do Eixo do Gráfico**

Chame [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) com `true` no eixo vertical, forneça o texto do título e use [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de coluna com o título do eixo de valores girado em 90 graus.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) para controlar se o eixo de valor cruza o eixo de categoria entre categorias ou nos marcadores de categoria. Essa configuração aplica‑se a eixos de categoria. O exemplo define `true` no eixo de categoria horizontal de um gráfico de coluna e salva o resultado.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir a Unidade de Exibição em um Eixo de Valor do Gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) para escalar os rótulos de um eixo de valor sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) definido como `Millions`, um valor de 60 000 000 é exibido como 60. O exemplo cria um gráfico de coluna e aplica a unidade de exibição de milhões ao seu eixo vertical.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Configurar um Eixo de Valor Logarítmico**

Um eixo de valor logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1 000, 10 000 e 100 000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem próximos uns dos outros perto de zero. Uma escala logarítmica facilita a comparação do crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Chame [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) com `true` no eixo de valor e use [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) para escolher a base. Isso altera a forma como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa um ajuste nos dados e é um recurso separado.

### **Escolher o Eixo de Valor e a Base**

Para um gráfico de linha ou coluna, o eixo de valor é retornado por [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Para um gráfico de barras horizontal, ele é retornado por [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Gráficos de dispersão e bolha têm dois eixos de valor, portanto escolha o eixo horizontal para valores X, o vertical para valores Y, ou ambos. Não aplique escala logarítmica a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base entre `2` e `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com base `10`, potências sucessivas como 10, 100, 1 000 e 10 000 ficam igualmente espaçadas.

### **Comparar Escala Linear e Logarítmica**

O exemplo autônomo a seguir cria um gráfico de linha com as cinco contagens de solicitações no primeiro slide, então clona esse slide e habilita um eixo de valor logarítmico base 10 no segundo. Ambos os slides mantêm os mesmos dados.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Manter o primeiro slide linear e mudar apenas a escala do eixo de valores da cópia.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Escala Linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O valor maior domina o gráfico, dificultando a distinção dos valores menores.

![Gráfico de linhas no PowerPoint mostrando cinco contagens de solicitações em um eixo de valor linear](value-axis-linear.png)

**Escala Logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala base 10. Os rótulos do eixo ainda mostram as contagens originais de solicitações.

![As mesmas cinco contagens de solicitações no PowerPoint em um eixo de valor logarítmico base 10](value-axis-logarithmic.png)

### **Lidar com Valores Zero e Negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem relevantes, mantenha uma escala linear ou mostre‑os separadamente. Se a exclusão desses valores for adequada à análise, explique a omissão. Não substitua silenciosamente esses valores por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento de eixos)?**

Use [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, use [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posicionar os rótulos de marcações em relação ao eixo?**

Chame [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de escala, use [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); esses controles são independentes do posicionamento dos rótulos.