---
title: Gerenciar séries de dados de gráficos em apresentações em Java
linktitle: Séries de Dados
type: docs
url: /pt/java/chart-series/
keywords:
- séries de gráfico
- sobreposição de série
- cor da série
- nome da série
- ponto de dados
- célula da pasta de trabalho
- intervalo da série
- valor negativo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como gerenciar séries de gráficos, pontos de dados, células da pasta de trabalho, formatação, sobreposição, largura do intervalo e valores negativos em apresentações com Java."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma pasta de trabalho de dados de gráfico. Um [IChartSeries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/) representa um conjunto de valores relacionados, e cada [IChartDataPoint](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/) na série refere‑se a uma ou mais células da pasta de trabalho. Objetos [IChartCategory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pelas séries. O nome da série, as categorias e os valores dos pontos estão, portanto, conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatacell/) em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categorias típico, a pasta de trabalho padrão usa a linha 0 para os nomes das séries, a coluna 0 para os nomes das categorias e as demais células para os valores das séries. Os índices de planilha, linha e coluna passados para [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) são baseados em zero. Esse layout é útil quando você cria um gráfico com dados padrão, mas não presuma que todo gráfico existente o utilize. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da pasta de trabalho.

As configurações do gráfico têm três escopos diferentes:

- Configurações de nível de série, como [IChartSeries.getFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getFormat--), fornecem a aparência padrão para todos os pontos em uma série.
- Configurações de ponto de dados, como [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getFormat--), substituem a aparência da série para um ponto.
- Configurações de grupo aplicam‑se a séries compatíveis que pertencem ao mesmo [IChartSeriesGroup](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseriesgroup/). Acesse o grupo através de [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) quando precisar definir opções como sobreposição ou largura do intervalo.

Quando nenhum preenchimento explícito de ponto ou série está definido, o estilo e o tema do gráfico determinam a aparência automática. Quando tanto a formatação da série quanto a do ponto estão presentes, a formatação do ponto tem precedência para esse ponto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a sobreposição das séries do gráfico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getOverlap--) informa quanto as barras ou colunas se sobrepõem em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente leitura da configuração no grupo de séries pai. Use [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) para atualizar todas as séries compatíveis nesse grupo. Essa opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

O exemplo a seguir define a sobreposição para o grupo que contém a primeira série:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // O novo gráfico contém séries, categorias e valores de exemplo.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The series overlap](series_overlap.png)

## **Alterar a cor de preenchimento da série**

Use [IChartSeries.getFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getFormat--) para definir o preenchimento padrão de uma série inteira. Se um ponto já possui um preenchimento explícito, sua configuração [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getFormat--) substitui o preenchimento da série para esse ponto.

O exemplo a seguir aplica um preenchimento sólido azul à primeira série:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The color of the series](series_color.png)

## **Alterar o nome da série**

Um nome de série é armazenado na pasta de trabalho de dados do gráfico e normalmente é exibido na legenda. Na pasta de trabalho padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As constantes nomeadas no exemplo a seguir tornam essa estrutura explícita:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode atualizar a célula já referenciada por [IChartSeries.getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getName--). Essa abordagem evita assumir uma linha e coluna específicas em um gráfico existente:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The series name](series_name.png)

## **Obter a cor automática de preenchimento da série**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Essa é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; ele não atribui um novo preenchimento.

O exemplo a seguir imprime a cor automática de cada série padrão:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Saída de exemplo para o estilo de gráfico padrão:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir preenchimento invertido para uma série do gráfico**

Para séries de barras, colunas e bolhas, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor de valor negativo por meio de [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Números negativos permanecem inalterados na pasta de trabalho; apenas sua cor de exibição muda.

O exemplo a seguir substitui os dados padrão do gráfico por uma série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes das categorias e a coluna 1 contém os valores:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). No exemplo a seguir, a inversão está desativada para a série e habilitada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Limpar o valor de um ponto de dados específico**

Para deixar um ponto vazio sem remover os demais, defina sua célula de apoio na pasta de trabalho como `null`. Para um gráfico de colunas, o valor plotado está disponível através de [IChartDataPoint.getValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#getValue--). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como em branco de acordo com as configurações de valores em branco do gráfico.

O exemplo a seguir limpa apenas o segundo ponto da primeira série:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolhas também usam uma célula de tamanho. Limpe apenas a célula que representa o valor que você pretende remover. Não chame [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapointcollection/#clear--) quando quiser manter os demais pontos, pois esse método remove todos os pontos de dados da coleção.

## **Controlar a exibição de células vazias**

Células ocultas que contêm valores são um caso diferente de células vazias. Para incluir ou excluir dados de linhas e colunas ocultas da planilha, veja [Include Data from Hidden Rows and Columns](/slides/pt/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Uma célula vazia na pasta de trabalho representa dados ausentes; uma célula contendo `0` representa um valor numérico conhecido. Chame [IChartDataCell.setValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) com `null` para tornar uma célula vazia. Um zero numérico permanece zero independentemente da configuração de célula em branco.

Use [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) para escolher como o gráfico exibe células vazias. Essa configuração se aplica ao gráfico inteiro. Ela altera a forma como os vazios são plotados, sem preencher a célula vazia da pasta de trabalho com zero ou um valor interpolado.

O exemplo autônomo a seguir cria um gráfico de linhas com uma série, limpa o valor do Dia 3 e salva o mesmo gráfico em cada modo. Nenhum arquivo de entrada é necessário. O [IChartDataWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdataworkbook/) usa a planilha 0, coluna 0 para rótulos de categoria e coluna 1 para valores; a linha 0 contém o nome da série. Os dados finais são `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Deixe o Dia 3 realmente vazio, enquanto mantém sua categoria e ponto de dados.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Cada arquivo de saída armazena o modo atribuído antes de salvar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Para salvar apenas uma versão, atribua o modo desejado e salve a apresentação uma única vez em vez de iterar sobre os modos.

A comparação abaixo mostra os mesmos dados nos três arquivos. O Dia 3 está vazio na pasta de trabalho em todos os casos:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

O efeito visível depende do tipo de gráfico. Um gráfico de linhas facilita a comparação dos três modos. Gráficos de barras e colunas não possuem linha para conectar categorias ausentes, portanto `Span` não pode produzir o segmento de conexão mostrado acima; uma coluna ausente e uma coluna de altura zero podem parecer iguais. Da mesma forma, um gráfico de dispersão apenas com marcadores não tem linha de conexão. Não espere três resultados distintos para todos os tipos de gráfico; verifique a saída para o tipo que você utiliza.

## **Definir a largura do intervalo da série**

A largura do intervalo é o espaço entre clusters adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Assim como a sobreposição, ela pertence ao grupo de séries pai, não a uma única série. Chame [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) uma vez para o grupo. Um valor maior cria mais espaço entre os clusters; um valor menor os deixa mais densos.

O exemplo a seguir altera a largura do intervalo e salva apenas a apresentação final:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The gap width](gap_width.png)

## **FAQ**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/) utilizam dados de gráfico, mas suas séries não têm todas a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categorias usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolhas adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura do intervalo aplicam‑se apenas a grupos compatíveis de barras ou colunas.

**O que é um grupo de séries de gráfico?**

Um [IChartSeriesGroup](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem em nível de grupo. Um gráfico combinado pode conter mais de um grupo, de modo que mudar o grupo acessado por uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [IShapeCollection.addChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar as coleções de séries e categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos do gráfico estão conectados às células da pasta de trabalho?**

Nomes de séries, rótulos de categorias e valores de pontos de dados referenciam células em um [IChartDataWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente do gráfico. Ao criar dados personalizados, mantenha as linhas de categorias e as linhas de valores das séries alinhadas para que cada ponto seja plotado na categoria pretendida.

**Como limpar um ponto sem remover toda a série?**

Defina a célula de valor pertinente como `null` para manter a posição de categoria do ponto como um ponto vazio. Use [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapointcollection/#clear--) somente quando desejar remover todos os pontos daquela série. Se também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e do valor configurado em [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Gráficos suportados podem exibir vazios como lacunas, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponda ao significado dos dados ausentes em sua apresentação. Consulte [Controlar a exibição de células vazias](#controlar-a-exibição-de-células-vazias) para um exemplo completo e comparação visual.

**Como os valores negativos são formatados?**

Para séries de barras, colunas e bolhas compatíveis, chame [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) e defina a cor retornada por [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Você pode sobrescrever o comportamento para um ponto individual com [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Esses métodos afetam apenas a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto o ponto são formatados?**

A formatação explícita do ponto de dados tem precedência para esse ponto. Os demais pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Configurações de grupo, como sobreposição e largura do intervalo, controlam o layout e não são sobrescritas pela formatação de ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado de séries. Na prática, as restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo alterar quando as colunas estão muito próximas ou muito afastadas?**

Chame [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre os clusters ou diminua‑o para aproximar os clusters.