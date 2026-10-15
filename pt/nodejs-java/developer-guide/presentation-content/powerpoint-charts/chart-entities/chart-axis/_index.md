---
title: Personalizar eixos de gráficos em apresentações usando JavaScript
linktitle: Eixo do Gráfico
type: docs
url: /pt/nodejs-java/chart-axis/
keywords:
- eixo de gráfico
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como usar JavaScript com Aspose.Slides para Node.js via Java para personalizar eixos de gráficos em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides para Node.js via Java. Ele aborda valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e marcas de escala, categorias de data e formatação, rotação do título, posicionamento do eixo, unidades de exibição e escala logarítmica.

## **Obter os valores máximos no eixo vertical em gráficos**

Crie uma [Apresentação](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) antes de ler os valores de eixo calculados para que o layout do gráfico esteja atualizado.

Leia [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) e [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) para os limites do eixo, e [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) e [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) para os intervalos das marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) e [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) fornecem escalas de unidades de tempo, que são relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trocar os dados entre eixos**

Use [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) para trocar os papéis de séries e categorias nos dados do gráfico. Cada categoria anterior torna‑se uma série, e cada série anterior torna‑se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) para associar os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Inverter a ordem de plotagem de um eixo**

Use [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) para inverter um eixo de categoria ou de valor. Por exemplo, um gráfico de barras horizontal pode mostrar as fases do projeto de cima para baixo na mesma ordem da planilha: Planejamento, Desenvolvimento, Teste. Inverter um eixo altera a direção de plotagem; não ordena nem reorganiza os dados da planilha. Em comparação, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) troca os papéis de séries e categorias.

O exemplo a seguir cria um gráfico de barras horizontal com três fases e uma série. Ele salva uma apresentação com três slides: ordem normal, categorias invertidas e valores invertidos. Cada cópia usa o mesmo conjunto de dados, e apenas um eixo é invertido em cada cópia.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slide 2: exibir a primeira categoria no topo.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Manter o eixo de valor horizontal na parte inferior.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Slide 3: inverter apenas a escala numérica horizontal.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Inverter um eixo também pode mover o eixo perpendicular para o lado oposto da plotagem. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) controla onde o outro eixo cruza o eixo sendo configurado. No slide 2, chamando‑o com `aspose.slides.CrossesType.Maximum` no eixo de categoria invertido mantém o eixo de valor horizontal na parte inferior. Para um ponto de cruzamento específico, use [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Verifique as configurações de cruzamento ao mudar a direção, especialmente se o gráfico já possui um ponto de cruzamento personalizado. Chame `setPlotOrderReversed` com `false` para restaurar a direção normal de plotagem; as configurações de cruzamento são separadas.

| Ordem normal (slide 1) | Categorias invertidas (slide 2) | Valores invertidos (slide 3) |
| --- | --- | --- |
| ![Gráfico de barras horizontal com ordem normal de eixo de categoria e valor](axis-order-normal.png) | ![Gráfico de barras horizontal com categorias exibidas de cima para baixo](axis-order-categories-reversed.png) | ![Gráfico de barras horizontal com eixo de valor invertido e zero à direita](axis-order-values-reversed.png) |
| As categorias vão de baixo para cima; os valores aumentam da esquerda para a direita. | Planejamento, Desenvolvimento e Teste vão de cima para baixo. Os valores e a ordem das linhas da planilha permanecem inalterados. | As categorias mantêm sua ordem normal; os valores aumentam da direita para a esquerda. O eixo de categoria cruza em zero à direita. |

## **Desativar o eixo vertical em gráficos de linhas**

Chame [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) com `false` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linhas com dados padrão e o salva com o eixo vertical oculto.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desativar o eixo horizontal em gráficos de linhas**

Chame [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) com `false` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linhas com dados padrão e o salva com o eixo horizontal oculto.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alterar um eixo de categoria**

Use [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) para escolher um eixo de categoria de data ou de texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como o primeiro objeto no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Chamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) com `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) com `1` e [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) com `TimeUnitType.Months` posiciona as marcas maiores em intervalos de um mês.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar intervalos de rótulo do eixo de categoria**

Quando um gráfico possui muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Chame [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) com `false`, então passe o intervalo de categoria desejado para [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe cada terceiro rótulo, deixando dois rótulos ocultos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente todos os rótulos.

As marcas de escala têm controles separados. Chame [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) com `false` e use [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) para definir seu intervalo. Por exemplo, `1` mantém uma marca de escala a cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) com um estilo visível para que você veja o resultado. Chamar qualquer definidor de espaçamento automático com `true` novamente permite que o gráfico escolha aquele intervalo novamente.

O exemplo autônomo a seguir cria 24 categorias e uma série, então salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e restauração do espaçamento automático. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. O texto horizontal dos rótulos facilita a visualização da densidade.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: mostrar cada terceiro rótulo, mas manter uma marca de escala para cada categoria.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: deixar o gráfico escolher ambos os intervalos novamente.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espaçamento automático (slide 1):** Nesta renderização, cada segundo rótulo de categoria é exibido e quebra em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e renderizador.

![Espaçamento automático de rótulo de categoria com todas as 24 colunas visíveis](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de escala permanecem a cada intervalo de categoria. Todas as 24 colunas, inclusive as que não têm rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Intervalo de rótulo de categoria manual de três com todas as 24 colunas visíveis](category-axis-manual.png)

### **Escolher o eixo e intervalo corretos**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de colunas, linhas, áreas ou barras. Em um gráfico de colunas, ele corresponde ao eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique essas configurações ao eixo retornado por [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). O espaçamento de marcas de escala também se aplica a um eixo de série em gráficos que o possuam.

Não use o espaçamento de rótulo de categoria para definir a escala numérica de um eixo de valor. Em um eixo de valor, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) especifica uma diferença em valores: por exemplo, uma unidade principal de `10` produz marcas em 0, 10, 20 etc. quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente de seus valores de dados. Gráficos de dispersão e bolha usam eixos de valor em vez de um eixo de categoria de texto. Para um eixo de data, use unidades principais e escalas baseadas em tempo conforme descrito em [Alterar um eixo de categoria](#alterar-um-eixo-de-categoria).

## **Definir o formato de data para valores do eixo de categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números seriais OLE Automation na primeira planilha (índice `0`), calculados como o número de dias desde 30 de dezembro de 1899. O cálculo JavaScript usa timestamps UTC e divide a diferença por 86 400 000 milissegundos por dia. Use [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) com `CategoryAxisType.Date`, chame [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) com `false` e passe `yyyy` para [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) para que os rótulos de categoria exibam anos com quatro dígitos independentemente da formatação da célula.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um ângulo de rotação para o título do eixo do gráfico**

Chame [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) com `true` no eixo vertical, forneça o texto do título e use [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de colunas com o título do eixo de valor girado em 90 graus.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir a posição do eixo em um eixo de categoria ou de valor**

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) para controlar se o eixo de valor cruza o eixo de categoria entre categorias ou nos marcadores de categoria. Essa configuração se aplica a eixos de categoria. O exemplo define isso como `true` no eixo de categoria horizontal de um gráfico de colunas e salva o resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir a unidade de exibição em um eixo de valor do gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) para escalar os rótulos em um eixo de valor sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) definido como `Millions`, um valor de 60 000 000 é exibido como 60. O exemplo cria um gráfico de colunas e aplica a unidade de exibição em milhões ao seu eixo vertical.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurar um eixo de valor logarítmico**

Um eixo de valor logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1 000, 10 000 e 100 000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem muito próximos entre si perto de zero. Uma escala logarítmica facilita a comparação do crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Chame [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) com `true` no eixo de valor e use [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) para escolher a base. Isso altera a forma como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa uma relação ajustada nos dados e é um recurso separado.

### **Escolher o eixo de valor e a base**

Para um gráfico de linhas ou colunas, o eixo de valor é retornado por [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Para um gráfico de barras horizontal, ele é retornado por [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Gráficos de dispersão e bolha possuem dois eixos de valor, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y, ou ambos. Não aplique escala logarítmica a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` a `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com base `10`, potências sucessivas como 10, 100, 1 000 e 10 000 são igualmente espaçadas.

### **Comparar escala linear e logarítmica**

O exemplo autônomo a seguir cria um gráfico de linhas com as cinco contagens de solicitações no primeiro slide, então clona esse slide e habilita um eixo de valor logarítmico de base 10 no segundo. Ambos os slides mantêm os mesmos dados.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Manter o primeiro slide linear e mudar apenas a escala do eixo de valor da cópia.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O valor maior domina o gráfico, dificultando a distinção dos valores menores.

![Gráfico de linhas no PowerPoint mostrando cinco contagens de solicitações em um eixo de valor linear](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala de base 10. Os rótulos do eixo ainda mostram as contagens originais.

![As mesmas cinco contagens de solicitações no PowerPoint em um eixo de valor logarítmico de base 10](value-axis-logarithmic.png)

### **Tratar valores zero e negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de ativá‑la. Se zero ou valores negativos forem significativos, mantenha uma escala linear ou mostre‑os separadamente. Se excluir esses valores for adequado à análise, explique a omissão. Não substitua silenciosamente por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento de eixo)?**

Use [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, use [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posicionar os rótulos das marcas em relação ao eixo?**

Chame [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de escala, use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); esses são independentes do posicionamento dos rótulos.