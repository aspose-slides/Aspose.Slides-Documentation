---
title: Personalizar Eixos de Gráficos em Apresentações Usando Java
linktitle: Eixo do Gráfico
type: docs
url: /pt/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Descubra como usar Aspose.Slides for Java para personalizar eixos de gráficos em apresentações do PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides for Java. Ele cobre valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e marcas de escala, categorias de data e formatação, rotação do título, posicionamento do eixo, unidades de exibição e dimensionamento logarítmico.

## **Obter os valores máximos no eixo vertical dos gráficos**

Criar uma [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e adicionar um gráfico de área com dados padrão. Chamar [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) antes de ler os valores calculados do eixo para que o layout do gráfico esteja atualizado.

Leia [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) e [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) para os limites do eixo, e [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) e [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) para os intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) e [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) fornecem escalas de unidade de tempo, que são relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

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

## **Trocar os Dados entre Eixos**

Use [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) para trocar as funções de séries e categorias nos dados do gráfico. Cada categoria anterior torna‑se uma série e cada série anterior torna‑se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

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

## **Desativar o Eixo Vertical para Gráficos de Linha**

Chamar [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) com `false` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo vertical oculto.

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

## **Desativar o Eixo Horizontal para Gráficos de Linha**

Chamar [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) com `false` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo horizontal oculto.

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

## **Alterar um Eixo de Categoria**

Use [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como a primeira forma no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Chamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) com `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) com `1` e [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) com `TimeUnitType.Months` posiciona as marcas principais em intervalos de um mês.

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

## **Controlar Intervalos de Rótulos do Eixo de Categoria**

When um gráfico tem muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Chame [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) com `false`, então passe o intervalo de categoria desejado para [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe cada terceiro rótulo, deixando dois rótulos ocultos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente todos os rótulos.

As marcas de escala têm controles separados. Chame [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) com `false` e use [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) para definir seu intervalo. Por exemplo, `1` mantém uma marca de escala em cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Use [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) com um estilo visível para que você possa ver o resultado. Chamar qualquer um dos definidores de espaçamento automático com `true` novamente permite que o gráfico escolha esse intervalo novamente.

O exemplo autônomo a seguir cria 24 categorias e uma série, então salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e espaçamento automático restaurado. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. O texto do rótulo horizontal facilita a visualização da diferença de densidade.

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

**Espaçamento automático (slide 1):** Neste renderização, cada segundo rótulo de categoria é exibido e quebra em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e o renderizador.

![Espaçamento automático de rótulos de categoria com todas as 24 colunas visíveis](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de escala permanecem em cada intervalo de categoria. Todas as 24 colunas, inclusive as sem rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Intervalo manual de rótulo de categoria de três com todas as 24 colunas visíveis](category-axis-manual.png)

### **Escolher o Eixo e Intervalo Corretos**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de colunas, linhas, áreas ou barras. Em um gráfico de colunas, ele é o eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique estas configurações ao eixo retornado por [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). O espaçamento de marcas de escala também se aplica a um eixo de série em gráficos que possuem um.

Não use o espaçamento de rótulo de categoria para definir a escala numérica de um eixo de valores. Em um eixo de valores, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) especifica uma diferença em valores: por exemplo, um unidade maior de `10` produz marcas em 0, 10, 20 e assim por diante quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente de seus valores de dados. Gráficos de dispersão e bolha usam eixos de valores em vez de um eixo de categoria de texto. Para um eixo de data, use unidades maiores baseadas em tempo e escalas como descrito em [Change a Category Axis](#change-a-category-axis).

## **Definir o Formato de Data para Valores do Eixo de Categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números seriais OLE Automation na primeira planilha (índice `0`), calculados como o número de dias desde 30 de dezembro de 1899, para essas datas. Use [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) com `CategoryAxisType.Date`, chame [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) com `false` e passe `yyyy` para [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) para que os rótulos de categoria exibam anos de quatro dígitos independentemente da formatação da célula.

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

## **Definir um Ângulo de Rotação para o Título do Eixo do Gráfico**

Chame [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) com `true` no eixo vertical, forneça o texto do título e use [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de colunas com o título do eixo de valores girado em 90 graus.

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

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) para controlar se o eixo de valores cruza o eixo de categoria entre categorias ou nos marcadores de categoria. Esta configuração se aplica a eixos de categoria. O exemplo define como `true` no eixo de categoria horizontal de um gráfico de colunas e salva o resultado.

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

## **Definir a Unidade de Exibição em um Eixo de Valores do Gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) para escalar os rótulos em um eixo de valores sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) definido como `Millions`, um valor de 60.000.000 é exibido como 60. O exemplo cria um gráfico de colunas e aplica a unidade de exibição em milhões ao seu eixo vertical.

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

## **Configurar um Eixo de Valores Logarítmico**

Um eixo de valores logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1.000, 10.000 e 100.000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem próximos uns dos outros perto de zero. Uma escala logarítmica facilita a comparação de seu crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Chamar [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) com `true` no eixo de valores e usar [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) para escolher a base. Isso altera como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa uma relação ajustada nos dados e é um recurso separado.

### **Escolher o Eixo de Valores e a Base**

Para um gráfico de linha ou colunas, o eixo de valores é retornado por [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Para um gráfico de barras horizontal, ele é retornado por [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Gráficos de dispersão e bolha têm dois eixos de valores, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y, ou ambos. Não aplique dimensionamento logarítmico a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` até `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com a base `10`, potências sucessivas como 10, 100, 1.000 e 10.000 são igualmente espaçadas.

### **Comparar Dimensionamento Linear e Logarítmico**

O exemplo autônomo a seguir cria um gráfico de linha com as cinco contagens de solicitações no primeiro slide, então clona esse slide e habilita um eixo de valores logarítmico base‑10 no segundo. Ambos os slides mantêm os mesmos dados.

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

    // Manter o primeiro slide linear e mudar apenas a escala do eixo de valores da cópia.
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

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O maior valor domina o gráfico, dificultando a distinção dos valores menores.

![Gráfico de linhas no PowerPoint mostrando cinco contagens de solicitações em um eixo de valores linear](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, portanto os pontos formam uma linha reta ascendente na escala base‑10. Os rótulos do eixo ainda mostram as contagens originais de solicitações.

![As mesmas cinco contagens de solicitações no PowerPoint em um eixo de valores logarítmico base‑10](value-axis-logarithmic.png)

### **Tratar Valores Zero e Negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem significativos, mantenha uma escala linear ou mostre‑os separadamente. Se excluir esses valores for apropriado para a análise, explique a omissão. Não substitua silenciosamente por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definir o valor em que um eixo cruza o outro (cruzamento do eixo)?**

Use [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, use [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posicionar os rótulos das marcas em relação ao eixo?**

Chame [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) usando [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de escala, use [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) ou [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); elas são independentes do posicionamento dos rótulos.