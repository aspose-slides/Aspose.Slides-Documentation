---
title: Personalizar eixos de gráficos em apresentações usando JavaScript
linktitle: Eixo de Gráfico
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
description: "Descubra como usar JavaScript com Aspose.Slides para Node.js via Java para personalizar eixos de gráficos em apresentações do PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides para Node.js via Java. Ele aborda valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e de marcas de graduação, categorias de data e formatação, rotação de título, posicionamento do eixo, unidades de exibição e dimensionamento logarítmico.

## **Obter os valores máximos no eixo vertical dos gráficos**

Crie uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) antes de ler os valores de eixo calculados para que o layout do gráfico esteja atualizado.

Leia [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) e [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) para os limites do eixo, e [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) e [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) para os intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) e [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) fornecem escalas de unidade de tempo, que são relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

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

## **Trocar os dados entre os eixos**

Use [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) para trocar os papéis de séries e categorias nos dados do gráfico. Cada categoria anterior torna-se uma série, e cada série anterior torna-se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

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

## **Desativar o eixo vertical para gráficos de linha**

Chame [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) com `false` no eixo vertical para ocultá-lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo vertical oculto.

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

## **Desativar o eixo horizontal para gráficos de linha**

Chame [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) com `false` no eixo horizontal para ocultá-lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo horizontal oculto.

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

Use [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como a primeira forma no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Chamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) com `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) com `1` e [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) com `TimeUnitType.Months` posiciona as marcas principais em intervalos de um mês.

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

## **Controlar intervalos de rótulos do eixo de categoria**

Quando um gráfico possui muitas categorias, diminua o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Chame [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) com `false`, então passe o intervalo de categoria desejado para [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe cada terceiro rótulo, deixando dois rótulos ocultos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não necessariamente exibe todos os rótulos.

As marcas de graduação têm controles separados. Chame [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) com `false` e use [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) para definir seu intervalo. Por exemplo, `1` mantém uma marca de graduação a cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) com um estilo visível para ver o resultado. Definir novamente o espaçamento automático com `true` permite que o gráfico escolha esse intervalo novamente.

O exemplo autônomo a seguir cria 24 categorias e uma série, salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de graduação independentes e restauração do espaçamento automático. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. O texto do rótulo horizontal facilita a visualização da densidade.

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

    // Slide 2: mostrar cada terceiro rótulo, mas manter uma marca de graduação para cada categoria.
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

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de graduação permanecem em cada intervalo de categoria. Todas as 24 colunas, inclusive as sem rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Escolher o eixo e intervalo corretos**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de colunas, linhas, áreas ou barras. Em um gráfico de colunas, ele é o eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique essas configurações ao eixo retornado por [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). O espaçamento de marcas de graduação também se aplica a um eixo de série em gráficos que o possuem.

Não use o espaçamento de rótulo de categoria para definir a escala numérica de um eixo de valores. Em um eixo de valores, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) especifica uma diferença em valores: por exemplo, uma unidade principal de `10` produz marcas em 0, 10, 20 etc., quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente dos valores de dados. Gráficos de dispersão e de bolhas usam eixos de valores em vez de um eixo de categoria de texto. Para um eixo de data, use unidades principais baseadas em tempo e escalas conforme descrito em [Alterar um eixo de categoria](#alterar-um-eixo-de-categoria).

## **Definir o formato de data para valores do eixo de categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números seriais OLE Automation na primeira planilha (índice `0`), calculados como o número de dias desde 30 de dezembro de 1899. O cálculo JavaScript usa timestamps UTC e divide a diferença por 86 400 000 milissegundos por dia. Use [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) com `CategoryAxisType.Date`, chame [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) com `false` e passe `yyyy` para [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) para que os rótulos de categoria exibam o ano com quatro dígitos independentemente da formatação da célula.

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

Chame [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) com `true` no eixo vertical, forneça o texto do título e use [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de colunas com o título do eixo de valores rotacionado em 90 graus.

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

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) para controlar se o eixo de valores cruza o eixo de categoria entre categorias ou em marcas de categoria. Essa configuração se aplica a eixos de categoria. O exemplo define isso como `true` no eixo de categoria horizontal de um gráfico de colunas e salva o resultado.

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

## **Definir a unidade de exibição em um eixo de valores do gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) para escalar os rótulos de um eixo de valores sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) definido como `Millions`, um valor de 60 000 000 é exibido como 60. O exemplo cria um gráfico de colunas e aplica a unidade de exibição em milhões ao eixo vertical.

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

## **Configurar um eixo de valores logarítmico**

Um eixo de valores logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1 000, 10 000 e 100 000 solicitações ao longo de cinco períodos. Em escala linear, os valores menores aparecem próximos uns dos outros perto de zero. Uma escala logarítmica facilita a comparação de seu crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Chame [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) com `true` no eixo de valores e use [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) para escolher a base. Isso altera a forma como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa um relacionamento ajustado nos dados e é um recurso separado.

### **Escolher o eixo de valores e a base**

Para um gráfico de linhas ou colunas, o eixo de valores é retornado por [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Para um gráfico de barras horizontal, ele é retornado por [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Gráficos de dispersão e de bolhas têm dois eixos de valores, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y ou ambos. Não aplique dimensionamento logarítmico a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` a `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com base `10`, potências sucessivas como 10, 100, 1 000 e 10 000 são espaçadas igualmente.

### **Comparar dimensionamento linear e logarítmico**

O exemplo autônomo a seguir cria um gráfico de linhas com as cinco contagens de solicitações no primeiro slide, então clona esse slide e habilita um eixo de valores logarítmico de base 10 no segundo. Ambos os slides mantêm os mesmos dados.

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

    // Manter o primeiro slide linear e mudar apenas a escala do eixo de valores da cópia.
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

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O valor mais alto domina o gráfico, dificultando a visualização dos valores menores.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala de base 10. Os rótulos do eixo ainda mostram as contagens originais de solicitações.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Tratar valores zero e negativos**

Uma escala logarítmica pode exibir somente valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem significativos, mantenha a escala linear ou mostre‑os separadamente. Se excluir esses valores for adequado à análise, explique a omissão. Não os substitua silenciosamente por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **Perguntas frequentes**

**Como definir o valor onde um eixo cruza o outro (cruzamento de eixos)?**

Use [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, use [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posicionar os rótulos de marca de graduação em relação ao eixo?**

Chame [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de graduação, use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); eles são independentes do posicionamento dos rótulos.