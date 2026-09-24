---
title: Gerenciar Séries de Dados de Gráficos em Apresentações Usando JavaScript
linktitle: Séries de Dados
type: docs
url: /pt/nodejs-java/chart-series/
keywords:
- série de gráfico
- sobreposição de séries
- cor da série
- nome da série
- ponto de dados
- célula da planilha
- lacuna da série
- valor negativo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a gerenciar séries de gráficos, pontos de dados, células da planilha, formatação, sobreposição, largura de lacuna e valores negativos em apresentações com JavaScript."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma planilha de dados do gráfico. Um [ChartSeries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/) representa um conjunto de valores relacionados, e cada [ChartDataPoint](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/) na série refere-se a uma ou mais células da planilha. Objetos [ChartCategory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pela série. Portanto, o nome da série, as categorias e os valores dos pontos estão conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatacell/) , em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categorias típico, a planilha padrão usa a linha 0 para nomes das séries, a coluna 0 para nomes das categorias e as demais células para os valores das séries. Os índices de planilha, linha e coluna passados para [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdataworkbook/#getCell) são baseados em zero. Esse layout é útil ao criar um gráfico com dados padrão, mas não suponha que todo gráfico existente o utilize. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da planilha.

As configurações do gráfico têm três escopos diferentes:

- Configurações ao nível de série, como [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getFormat), fornecem a aparência padrão para todos os pontos de uma série.
- Configurações de ponto de dados, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getFormat), substituem a aparência da série para um ponto.
- Configurações de grupo se aplicam a séries compatíveis que pertencem ao mesmo [ChartSeriesGroup](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseriesgroup/). Acesse o grupo por meio de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) quando precisar definir opções como sobreposição ou largura de lacuna.

Quando nenhuma preenchimento explícito de ponto ou série está definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação tanto de série quanto de ponto, a formatação do ponto tem precedência para esse ponto.

![série de gráfico PowerPoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série do Gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getOverlap) informa quanta sobreposição há entre barras ou colunas em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente leitura da configuração no grupo de séries pai. Use [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) para atualizar todas as séries compatíveis nesse grupo. Essa opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

O exemplo a seguir define a sobreposição para o grupo que contém a primeira série:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // O novo gráfico contém séries de amostra, categorias e valores.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Sobreposição da série](series_overlap.png)

## **Alterar a Cor de Preenchimento da Série**

Use [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getFormat) para definir o preenchimento padrão para uma série inteira. Se um ponto já possui um preenchimento explícito, sua configuração [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getFormat) substitui o preenchimento da série para esse ponto.

O exemplo a seguir aplica um preenchimento sólido azul à primeira série:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Cor da série](series_color.png)

## **Alterar o Nome da Série**

Um nome de série é armazenado na planilha de dados do gráfico e normalmente é exibido na legenda. Na planilha padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As constantes nomeadas no exemplo a seguir tornam essa estrutura explícita:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode atualizar a célula já referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getName). Essa abordagem evita assumir uma linha e coluna específicas em um gráfico existente:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Nome da série](series_name.png)

## **Obter a Cor Automática de Preenchimento da Série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retorna a cor calculada a partir do índice da série e do estilo do gráfico. Esta é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; não atribui um novo preenchimento.

O exemplo a seguir imprime a cor automática de cada série padrão:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Exemplo de saída para o estilo padrão do gráfico:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir Cor de Preenchimento Invertido para uma Série de Gráfico**

Para séries de barras, colunas e bolhas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor de valor negativo por meio de [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Números negativos permanecem inalterados na planilha; apenas a cor de exibição muda.

O exemplo a seguir substitui os dados padrão do gráfico por uma série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes das categorias e a coluna 1 contém os valores:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Cor de preenchimento sólido invertido](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). No exemplo a seguir, a inversão está desativada para a série e habilitada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Limpar o Valor de um Ponto de Dados Específico**

Para deixar um ponto vazio sem remover os outros pontos, defina sua célula de suporte na planilha como `null`. Para um gráfico de colunas, o valor plotado está disponível por meio de [ChartDataPoint.getValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#getValue). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como em branco de acordo com as configurações de valores em branco do gráfico.

O exemplo a seguir limpa apenas o segundo ponto da primeira série:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gráficos de dispersão utilizam células X e Y separadas, e gráficos de bolhas também utilizam uma célula de tamanho. Limpe apenas a célula que representa o valor que você pretende remover. Não chame [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapointcollection/#clear) quando quiser manter os outros pontos, pois esse método remove todos os pontos de dados da coleção.

## **Controlar a Exibição de Células Vazias**

Uma célula vazia da planilha representa dados ausentes; uma célula contendo `0` representa um valor numérico conhecido. Chame [ChartDataCell.setValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatacell/#setValue) com `null` para tornar uma célula vazia. Um zero numérico permanece zero independentemente da configuração de célula vazia. Use [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) para escolher como o gráfico exibe células vazias. Essa configuração se aplica a todo o gráfico. Ela altera como os vazios são plotados, sem preencher a célula vazia da planilha com zero ou um valor interpolado.

O exemplo independente a seguir cria um gráfico de linhas com uma série, limpa o valor para o Dia 3 e salva o mesmo gráfico em cada modo. Nenhum arquivo de entrada é necessário. O [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdataworkbook/) usa a planilha 0, a coluna 0 para rótulos de categoria e a coluna 1 para valores; a linha 0 contém o nome da série. Os dados finais são `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Deixe o Dia 3 realmente vazio, mantendo sua categoria e ponto de dados.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Cada arquivo de saída armazena o modo atribuído antes de salvar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Para salvar apenas uma versão, atribua o modo desejado e salve a apresentação uma única vez em vez de iterar sobre os modos.

A comparação abaixo mostra os mesmos dados nos três arquivos. O Dia 3 está vazio na planilha em todos os casos:

![Gráficos de linha com dados idênticos: Gap interrompe a linha no Dia 3, Zero faz a linha cair a zero, e Span conecta o Dia 2 ao Dia 4.](display_blanks_as.png)

O efeito visível depende do tipo de gráfico. Um gráfico de linhas torna os três modos fáceis de comparar. Gráficos de barras e colunas não têm linha para conectar uma categoria ausente, portanto `Span` não pode produzir o segmento de conexão mostrado acima; uma coluna ausente e uma coluna de altura zero também podem parecer semelhantes. Da mesma forma, um gráfico de dispersão apenas com marcadores não possui linha de conexão. Não espere três resultados distintos para todos os tipos de gráfico; verifique a saída para o tipo que você usar.

## **Definir a Largura de Lacuna da Série**

A largura da lacuna é o espaço entre agrupamentos adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Assim como a sobreposição, ela pertence ao grupo de séries pai, e não a uma única série. Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) uma vez para o grupo. Um valor maior cria mais espaço entre os agrupamentos; um valor menor os torna mais densos.

O exemplo a seguir altera a largura da lacuna e salva apenas a apresentação final:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Largura da lacuna](gap_width.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/) utilizam dados de gráfico, mas suas séries não têm todas a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categoria utilizam categorias e valores, gráficos de dispersão utilizam valores X e Y, e gráficos de bolhas adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura de lacuna se aplicam apenas a grupos de barras ou colunas compatíveis.

**O que é um grupo de séries de gráfico?**

Um [ChartSeriesGroup](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem em nível de grupo. Um gráfico combinado pode conter mais de um grupo, portanto alterar o grupo acessado por meio de uma série não altera necessariamente todas as séries no gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [ShapeCollection.addChart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addChart) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar tanto as coleções de séries quanto de categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos de gráfico estão conectados às células da planilha?**

Nomes de séries, rótulos de categorias e valores de pontos de dados referenciam células em um [ChartDataWorkbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente do gráfico. Ao construir dados personalizados, mantenha as linhas de categorias e as linhas de valores das séries alinhadas para que cada ponto seja plotado na categoria pretendida.

**Como limpar um ponto em vez de toda a série?**

Defina a célula de valor relevante como `null` para manter a posição de categoria do ponto como um ponto vazio. Use [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapointcollection/#clear) apenas quando pretender remover todos os pontos dessa série. Se você também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e do valor configurado em [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Gráficos suportados podem exibir vazios como lacunas, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponde ao significado dos dados ausentes em sua apresentação. Veja [Control the Display of Empty Cells](#control-the-display-of-empty-cells) para um exemplo completo e comparação visual.

**Como valores negativos são formatados?**

Para séries de barras, colunas e bolhas suportadas, chame [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) e defina a cor retornada por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Você pode substituir o comportamento para um ponto individual com [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Esses métodos afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto uma série quanto um ponto são formatados?**

A formatação explícita de ponto de dados tem precedência para esse ponto. Outros pontos continuam a usar o formato explícito da série ou, quando o formato da série não está definido, o estilo e tema automáticos do gráfico. Configurações de grupo, como sobreposição e largura de lacuna, controlam o layout e não são substituições de formatação ao nível do ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado de quantidade de séries. Na prática, restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo alterar quando as colunas estão muito próximas ou muito distantes?**

Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre os agrupamentos, ou diminua‑o para aproximar os agrupamentos.