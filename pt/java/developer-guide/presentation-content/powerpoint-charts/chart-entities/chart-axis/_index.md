---
title: Personalizar eixos de gráfico em apresentações usando Java
linktitle: Eixo de Gráfico
type: docs
url: /pt/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Descubra como usar o Aspose.Slides for Java para personalizar os eixos de gráfico em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides for Java. Ele abrange valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e de marcas de escala, categorias de data e formatação, rotação do título, posicionamento do eixo, unidades de exibição e escala logarítmica.

## **Obter os valores máximos no eixo vertical em gráficos**

Crie uma [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) antes de ler os valores de eixo calculados, para que o layout do gráfico esteja atualizado.

Leia [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) e [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) para os limites do eixo, e [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) e [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) para os intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) e [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) fornecem escalas de unidades de tempo, relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trocar os dados entre eixos**

Use [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) para trocar os papéis de séries e categorias nos dados do gráfico. Cada categoria anterior torna‑se uma série, e cada série anterior torna‑se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reverter a ordem de plotagem de um eixo**

Use [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) para reverter um eixo de categoria ou de valor. Por exemplo, um gráfico de barras horizontal pode mostrar as etapas do projeto de cima para baixo na mesma ordem da planilha: Planning, Development, Testing. Reverter um eixo altera a direção de plotagem; não ordena nem reorganiza os dados da planilha. Em comparação, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) troca os papéis de séries e categorias.

O exemplo a seguir cria um gráfico de barras horizontal com três etapas e uma série. Ele salva uma apresentação com três slides: ordem normal, categorias revertidas e valores revertidos. Cada cópia usa o mesmo conjunto de dados, e apenas um eixo é revertido em cada cópia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slide 2: exibir a primeira categoria no topo.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Manter o eixo de valores horizontal na parte inferior.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Slide 3: reverter apenas a escala numérica horizontal.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Reverter um eixo também pode mover o eixo perpendicular para o lado oposto do gráfico. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) controla onde o outro eixo cruza o eixo que está sendo configurado. No slide 2, chamá‑lo com `CrossesType.Maximum` no eixo de categoria revertido mantém o eixo de valor horizontal na parte inferior. Para um ponto de cruzamento específico, use [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Verifique as configurações de cruzamento ao mudar a direção, especialmente se o gráfico já possui um ponto de cruzamento personalizado. Chame `setPlotOrderReversed` com `false` para restaurar a direção de plotagem normal; as configurações de cruzamento são independentes.

| Ordem normal (slide 1) | Categorias revertidas (slide 2) | Valores revertidos (slide 3) |
| --- | --- | --- |
| ![Gráfico de barras horizontal com ordem normal de eixo de categoria e valor](axis-order-normal.png) | ![Gráfico de barras horizontal com categorias exibidas de cima para baixo](axis-order-categories-reversed.png) | ![Gráfico de barras horizontal com eixo de valor revertido e zero à direita](axis-order-values-reversed.png) |
| Categorias vão de baixo para cima; valores aumentam da esquerda para a direita. | Planning, Development e Testing vão de cima para baixo. Valores e ordem das linhas da planilha permanecem inalterados. | Categorias mantêm sua ordem normal; valores aumentam da direita para a esquerda. O eixo de categoria cruza em zero à direita. |

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desativar o eixo vertical para gráficos de linhas**

Chame [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) com `false` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linhas com dados padrão e o salva com o eixo vertical oculto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desativar o eixo horizontal para gráficos de linhas**

Chame [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) com `false` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linhas com dados padrão e o salva com o eixo horizontal oculto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alterar um eixo de categoria**

Use [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como a primeira forma no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Chamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) com `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) com `1` e [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) com `TimeUnitType.Months` coloca marcas principais em intervalos de um mês.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar intervalos de rótulos do eixo de categoria**

Quando um gráfico tem muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Chame [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) com `false`, então passe o intervalo de categoria desejado para [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe a cada terceiro rótulo, deixando dois rótulos ocultos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente todos os rótulos.

As marcas de escala têm controles separados. Chame [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) com `false` e use [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) para definir seu intervalo. Por exemplo, `1` mantém uma marca de escala em cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Use [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) com um estilo visível para que você possa ver o resultado. Chamar qualquer um dos definidores de espaçamento automático com `true` novamente permite que o gráfico escolha esse intervalo novamente.

O exemplo autocontido a seguir cria 24 categorias e uma série, então salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e espaçamento automático restaurado. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. Texto de rótulo horizontal facilita a visualização da diferença de densidade.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slide 2: exibir cada terceiro rótulo, mas manter uma marca de escala para cada categoria.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: deixar o gráfico escolher ambos os intervalos novamente.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espaçamento automático (slide 1):** Neste renderização, cada segundo rótulo de categoria é exibido e envolve em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e o renderizador.

![Espaçamento automático de rótulo de categoria com as 24 colunas visíveis](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de escala permanecem em cada intervalo de categoria. Todas as 24 colunas, incluindo as que não têm rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Intervalo manual de rótulo de categoria de três com as 24 colunas visíveis](category-axis-manual.png)

### **Escolher o eixo e intervalo corretos**

Use este intervalo de contagem de categoria para um eixo de categoria de texto, como o eixo de categoria de um gráfico de colunas, linhas, área ou barras. Em um gráfico de colunas, ele é o eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique essas configurações ao eixo retornado por [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). O espaçamento de marcas de escala também se aplica a um eixo de série em gráficos que possuem um.

Não use o espaçamento de rótulo de categoria para definir a escala numérica de um eixo de valor. Em um eixo de valor, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) especifica uma diferença em valores: por exemplo, uma unidade principal de `10` produz marcas em 0, 10, 20, etc., quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente de seus valores de dados. Gráficos de dispersão e bolha usam eixos de valor em vez de um eixo de categoria de texto. Para um eixo de data, use unidades e escalas principais baseadas em tempo como descrito em [Alterar um eixo de categoria](#change-a-category-axis).

## **Definir o formato de data para valores do eixo de categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números de série OLE Automation na primeira planilha (índice `0`), calculadas como o número de dias desde 30 de dezembro de 1899, para estas datas. Use [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) com `CategoryAxisType.Date`, chame [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) com `false` e passe `yyyy` para [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) para que os rótulos de categoria exibam anos de quatro dígitos independentemente da formatação da célula.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um ângulo de rotação para o título do eixo do gráfico**

Chame [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) com `true` no eixo vertical, forneça o texto do título e use [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de colunas com o título do eixo de valor girado em 90 graus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir a posição do eixo em um eixo de categoria ou de valor**

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) para controlar se o eixo de valor cruza o eixo de categoria entre as categorias ou nos marcadores de categoria. Essa configuração se aplica a eixos de categoria. O exemplo define como `true` no eixo de categoria horizontal de um gráfico de colunas e salva o resultado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir a unidade de exibição em um eixo de valor do gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) para escalar os rótulos em um eixo de valor sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) definido como `Millions`, um valor de 60.000.000 é exibido como 60. O exemplo cria um gráfico de colunas e aplica a unidade de exibição em milhões ao seu eixo vertical.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Manter o primeiro slide linear e alterar apenas a escala do eixo de valores da cópia.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurar um eixo de valor logarítmico**

Um eixo de valor logarítmico é útil quando valores positivos cobrem várias ordens de grandeza. Por exemplo, um serviço pode receber 10, 100, 1.000, 10.000 e 100.000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem próximos uns dos outros perto de zero. Uma escala logarítmica facilita a comparação de seu crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Chame [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) com `true` no eixo de valor e use [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) para escolher a base. Isso altera como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa um relacionamento ajustado nos dados e é um recurso separado.

### **Escolher o eixo de valor e a base**

Para um gráfico de linhas ou colunas, o eixo de valor é retornado por [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Para um gráfico de barras horizontal, ele é retornado por [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Gráficos de dispersão e bolha têm dois eixos de valor, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y, ou ambos. Não aplique escala logarítmica a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` a `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com base `10`, potências sucessivas como 10, 100, 1.000 e 10.000 são espaçadas igualmente.

### **Comparar escalonamento linear e logarítmico**

O exemplo autocontido a seguir cria um gráfico de linhas com as cinco contagens de solicitações no primeiro slide, então clona esse slide e habilita um eixo de valor logarítmico base 10 no segundo. Ambos os slides mantêm os mesmos dados.

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O valor maior domina o gráfico, dificultando a distinção dos valores menores.

![Gráfico de linhas no PowerPoint mostrando cinco contagens de solicitações em um eixo de valor linear](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala base 10. Os rótulos do eixo ainda mostram as contagens originais de solicitações.

![As mesmas cinco contagens de solicitações no PowerPoint em um eixo de valor logarítmico base 10](value-axis-logarithmic.png)

### **Tratar valores zero e negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem relevantes, mantenha uma escala linear ou mostre‑os separadamente. Se excluir esses valores for adequado para a análise, explique a omissão. Não substitua silenciosamente por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento do eixo)?**

Use [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, use [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Essas configurações permitem mover o cruzamento do eixo para um ponto de base adequado.

**Como posicionar os rótulos de marca de escala em relação ao eixo?**

Chame [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) usando [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de escala, use [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) ou [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); esses são independentes do posicionamento dos rótulos.