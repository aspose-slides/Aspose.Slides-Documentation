---
title: Formatar Gráficos de Apresentação em Java
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/java/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades de gráfico
- configurações de gráfico
- opções de gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para Java e eleve sua apresentação PowerPoint com um estilo profissional e atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar os principais elementos dos gráficos, como eixos, linhas de grade, títulos, legendas, a área de trama e preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar Entidades de Gráfico**
Aspose.Slides for Java permite que os desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Este artigo explica como formatar diferentes entidades de gráfico, incluindo o eixo de categoria e o eixo de valores.

Aspose.Slides for Java fornece uma API simples para gerenciar diferentes entidades de gráfico e formatá‑las usando valores personalizados:

1. Crie uma instância da classe [**Presentation**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão e escolha o tipo desejado (neste exemplo usaremos ChartType.LineWithMarkers).
4. Acesse o eixo de Valor do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de Valor
   2. Definir **Line format** para linhas de grade secundárias do eixo de Valor
   3. Definir **Number Format** para o eixo de Valor
   4. Definir **Min, Max, Major and Minor units** para o eixo de Valor
   5. Definir **Text Properties** para os dados do eixo de Valor
   6. Definir **Title** para o eixo de Valor
   7. Definir **Line Format** para o eixo de Valor
5. Acesse o eixo de Categoria do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de Categoria
   2. Definir **Line format** para linhas de grade secundárias do eixo de Categoria
   3. Definir **Text Properties** para os dados do eixo de Categoria
   4. Definir **Title** para o eixo de Categoria
   5. Definir **Label Positioning** para o eixo de Categoria
   6. Definir **Rotation Angle** para os rótulos do eixo de Categoria
6. Acesse a legenda do gráfico e defina as **Text Properties** para ela
7. Configure a exibição das legendas do gráfico sem sobrepor o gráfico
8. Acesse o **Secondary Value Axis** do gráfico e defina as seguintes propriedades:
   1. Habilite o **Value Axis** secundário
   2. Definir **Line Format** para o **Secondary Value Axis**
   3. Definir **Number Format** para o **Secondary Value Axis**
   4. Definir **Min, Max, Major and Minor units** para o **Secondary Value Axis**
9. Agora trace a primeira série do gráfico no **Secondary Value Axis**
10. Defina a cor de preenchimento da parede traseira do gráfico
11. Defina a cor de preenchimento da área de trama do gráfico
12. Grave a apresentação modificada em um arquivo PPTX

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Acessando o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionando o gráfico de exemplo
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Definindo o Título do Gráfico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Definindo o formato das linhas de grade principais para o eixo de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Definindo o formato das linhas de grade secundárias para o eixo de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Definindo o formato numérico do eixo de valores
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Definindo valores máximo e mínimo do gráfico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Definindo Propriedades de Texto do Eixo de Valores
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Definindo o título do eixo de valores
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Definindo o formato das linhas de grade principais para o eixo de Categoria
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Definindo o formato das linhas de grade secundárias para o eixo de Categoria
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Definindo Propriedades de Texto do Eixo de Categoria
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Definindo o Título da Categoria
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Definindo a posição do rótulo do eixo de categoria
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Definindo o ângulo de rotação do rótulo do eixo de categoria
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Definindo Propriedades de Texto das Legendas
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Definir exibição das legendas do gráfico sem sobrepor o gráfico

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Definindo eixo de valor secundário
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Definindo o formato numérico do eixo de valor secundário
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Definindo valores máximo e mínimo do gráfico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Definindo a cor da parede traseira do gráfico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Definindo a cor da área de trama
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Salvar Apresentação
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Propriedades de Fonte para um Gráfico**
Aspose.Slides for Java fornece suporte para definir as propriedades relacionadas à fonte para o gráfico. Siga os passos abaixo para definir as propriedades de fonte para o gráfico.

- Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) .
- Adicione um gráfico ao slide.
- Defina a altura da fonte.
- Salve a apresentação modificada.

A seguir, um exemplo de amostra.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir o Formato Numérico**
Aspose.Slides for Java fornece uma API simples para gerenciar o formato de dados do gráfico:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) .
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão e escolha o tipo desejado (este exemplo usa **ChartType.ClusteredColumn**).
4. Defina o formato numérico predefinido a partir dos valores predefinidos possíveis.
5. Percorra cada célula de dados do gráfico em todas as séries e defina o formato numérico dos dados do gráfico.
6. Salve a apresentação.
7. Defina o formato numérico personalizado.
8. Percorra as células de dados do gráfico dentro de cada série e defina um formato numérico de dados diferente.
9. Salve a apresentação.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Acesse o primeiro slide da apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionando um gráfico de colunas agrupadas padrão
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Acessando a coleção de séries do gráfico
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Percorrendo cada série do gráfico
    for (IChartSeries ser : series) 
    {
        // Percorrendo cada célula de dados na série
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Definindo o formato numérico
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Salvando a apresentação
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Os possíveis valores de formato numérico predefinidos, juntamente com seus índices predefinidos, que podem ser usados, são apresentados abaixo:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Definir Bordas Arredondadas da Área do Gráfico**
Aspose.Slides for Java oferece suporte para definir a área do gráfico. Os métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChart#hasRoundedCorners--) e [**setRoundedCorners**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) foram adicionados à interface [IChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChart) e à classe [Chart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Chart) .

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) .
2. Adicione um gráfico ao slide.
3. Defina o tipo de preenchimento e a cor de preenchimento do gráfico
4. Defina a propriedade de canto arredondado como True.
5. Salve a apresentação modificada.

A seguir, um exemplo de amostra.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, exiba rótulos apenas para pontos selecionados, se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos de gradiente ou padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto de gradiente/padrão estão normalmente disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.