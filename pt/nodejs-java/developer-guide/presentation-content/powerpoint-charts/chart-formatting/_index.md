---
title: Formatar Gráficos de Apresentação em JavaScript
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/nodejs-java/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades do gráfico
- configurações do gráfico
- opções de gráfico
- propriedades da fonte
- borda arredondada
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para Node.js em JavaScript e eleve sua apresentação PowerPoint com estilo profissional e atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando o Aspose.Slides. Ele mostra como personalizar elementos principais dos gráficos, como eixos, linhas de grade, títulos, legendas, a área de plotagem e preenchimentos de paredes, para melhorar a aparência e a legibilidade dos dados do gráfico.

Ele também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar Entidades do Gráfico**

Aspose.Slides for Node.js via Java permite que os desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Este artigo explica como formatar diferentes entidades de gráficos, incluindo o eixo de categoria e o eixo de valores.

Aspose.Slides for Node.js via Java fornece uma API simples para gerenciar diferentes entidades de gráficos e formatá‑las usando valores personalizados:

1. Crie uma instância da classe [**Presentation**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) .
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão junto ao tipo desejado (neste exemplo usaremos ChartType.LineWithMarkers).
1. Acesse o eixo de valores do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de valores
   1. Definir **Line format** para linhas de grade secundárias do eixo de valores
   1. Definir **Number Format** para o eixo de valores
   1. Definir **Min, Max, Major and Minor units** para o eixo de valores
   1. Definir **Text Properties** para os dados do eixo de valores
   1. Definir **Title** para o eixo de valores
   1. Definir **Line Format** para o eixo de valores
1. Acesse o eixo de categorias do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de categorias
   1. Definir **Line format** para linhas de grade secundárias do eixo de categorias
   1. Definir **Text Properties** para os dados do eixo de categorias
   1. Definir **Title** para o eixo de categorias
   1. Definir **Label Positioning** para o eixo de categorias
   1. Definir **Rotation Angle** para os rótulos do eixo de categorias
1. Acesse a legenda do gráfico e defina as **Text Properties** para ela
1. Defina a exibição das legendas do gráfico sem sobrepor o gráfico
1. Acesse o **Secondary Value Axis** do gráfico e defina as seguintes propriedades:
   1. Habilite o **Value Axis** secundário
   1. Definir **Line Format** para o **Secondary Value Axis**
   1. Definir **Number Format** para o **Secondary Value Axis**
   1. Definir **Min, Max, Major and Minor units** para o **Secondary Value Axis**
1. Agora plote a primeira série de gráfico no **Secondary Value Axis**
1. Defina a cor de preenchimento da parede traseira do gráfico
1. Defina a cor de preenchimento da área de plotagem do gráfico
1. Grave a apresentação modificada em um arquivo PPTX

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Acessando o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionando o gráfico de exemplo
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Definindo o Título do Gráfico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Definindo o formato das linhas de grade principais para o eixo de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Definindo o formato das linhas de grade secundárias para o eixo de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Definindo o formato numérico do eixo de valores
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Definindo os valores máximo e mínimo do gráfico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Definindo as Propriedades de Texto do Eixo de Valores
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Definindo o título do eixo de valores
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Definindo o formato das linhas de grade principais para o eixo de Categoria
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Definindo o formato das linhas de grade secundárias para o eixo de Categoria
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Definindo as Propriedades de Texto do Eixo de Categoria
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Definindo o Título da Categoria
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Definindo a posição do rótulo do eixo de categoria
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Definindo o ângulo de rotação do rótulo do eixo de categoria
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Definindo as Propriedades de Texto das Legendas
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Definir exibição das legendas do gráfico sem sobrepor o gráfico
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Definindo o eixo de valores secundário
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Definindo o formato numérico do eixo de valores secundário
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Definindo os valores máximo e mínimo do gráfico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Definindo a cor da parede traseira do gráfico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Definindo a cor da área de plotagem
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Salvar a Apresentação
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Propriedades de Fonte para o Gráfico**

Aspose.Slides for Node.js via Java fornece suporte para definir as propriedades relacionadas à fonte para o gráfico. Siga os passos abaixo para definir as propriedades de fonte para o gráfico.

- Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) .
- Adicione um gráfico ao slide.
- Defina a altura da fonte.
- Salve a apresentação modificada.

A seguir, um exemplo de amostra é apresentado.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Formato de Números**

Aspose.Slides for Node.js via Java fornece uma API simples para gerenciar o formato dos dados do gráfico:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) .
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão juntamente com o tipo desejado (este exemplo usa **ChartType.ClusteredColumn**).
4. Defina o formato numérico predefinido a partir dos valores predefinidos possíveis.
5. Percorra cada célula de dados do gráfico em todas as séries do gráfico e defina o formato numérico dos dados do gráfico.
6. Salve a apresentação.
7. Defina o formato numérico personalizado.
8. Percorra cada célula de dados do gráfico dentro de todas as séries do gráfico e defina um formato numérico diferente para os dados do gráfico.
9. Salve a apresentação.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Acessar o primeiro slide da apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adicionar um gráfico de coluna agrupada padrão
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Acessar a coleção de séries do gráfico
    var series = chart.getChartData().getSeries();
    // Percorrer todas as séries do gráfico
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Percorrer todas as células de dados na série
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Definir o formato numérico
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0,00%
        }
    }
    // Salvar a apresentação
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Os possíveis valores de formato numérico predefinidos, juntamente com seu índice predefinido, que podem ser usados, são apresentados abaixo:

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

Aspose.Slides for Node.js via Java fornece suporte para definir a área do gráfico. Os métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) e [**setRoundedCorners**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) foram adicionados à classe [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart).

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) .
2. Adicione um gráfico ao slide.
3. Defina o tipo de preenchimento e a cor de preenchimento do gráfico
4. Defina a propriedade round corner como True.
5. Salve a apresentação modificada.

A seguir, um exemplo de amostra é apresentado.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, exiba rótulos somente para pontos selecionados, se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos de gradiente ou padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto de gradiente/padrão geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.