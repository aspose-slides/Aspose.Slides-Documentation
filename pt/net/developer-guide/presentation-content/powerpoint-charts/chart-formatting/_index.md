---
title: "Formatar Gráficos de Apresentação em .NET"
linktitle: "Formatação de Gráfico"
type: docs
weight: 60
url: /pt/net/chart-formatting/
keywords:
- "formatar gráfico"
- "formatação de gráfico"
- "entidade de gráfico"
- "propriedades do gráfico"
- "configurações do gráfico"
- "opções de gráfico"
- "propriedades de fonte"
- "borda arredondada"
- "PowerPoint"
- "apresentação"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aprenda a formatar gráficos no Aspose.Slides para .NET e eleve sua apresentação PowerPoint com um estilo profissional e atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar elementos chave do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e os preenchimentos de parede, a fim de melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar Entidades de Gráfico**
Aspose.Slides for .NET permite que os desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Este artigo explica como formatar diferentes entidades de gráfico, incluindo o eixo de categoria e o eixo de valor.

Aspose.Slides for .NET fornece uma API simples para gerenciar diferentes entidades de gráfico e formatá‑las usando valores personalizados:

1. Crie uma instância da classe **Presentation**.
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (neste exemplo usaremos ChartType.LineWithMarkers).
1. Acesse o eixo de Valor do gráfico e defina as seguintes propriedades:
   1. Definindo **Line format** para linhas de grade principais do eixo de Valor
   1. Definindo **Line format** para linhas de grade secundárias do eixo de Valor
   1. Definindo **Number Format** para o eixo de Valor
   1. Definindo **Min, Max, Major and Minor units** para o eixo de Valor
   1. Definindo **Text Properties** para os dados do eixo de Valor
   1. Definindo **Title** para o eixo de Valor
   1. Definindo **Line Format** para o eixo de Valor
1. Acesse o eixo de Categoria do gráfico e defina as seguintes propriedades:
   1. Definindo **Line format** para linhas de grade principais do eixo de Categoria
   1. Definindo **Line format** para linhas de grade secundárias do eixo de Categoria
   1. Definindo **Text Properties** para os dados do eixo de Categoria
   1. Definindo **Title** para o eixo de Categoria
   1. Definindo **Label Positioning** para o eixo de Categoria
   1. Definindo **Rotation Angle** para os rótulos do eixo de Categoria
1. Acesse a Legenda do gráfico e defina as **Text Properties** para ela
1. Defina a exibição das legendas do gráfico sem sobrepor o gráfico
1. Acesse o **Secondary Value Axis** do gráfico e defina as seguintes propriedades:
   1. Habilite o **Value Axis** secundário
   1. Definindo **Line Format** para o eixo de Valor secundário
   1. Definindo **Number Format** para o eixo de Valor secundário
   1. Definindo **Min, Max, Major and Minor units** para o eixo de Valor secundário
1. Agora plote a primeira série do gráfico no eixo de Valor secundário
1. Defina a cor de preenchimento da parede traseira do gráfico
1. Defina a cor de preenchimento da área de plotagem do gráfico
1. Grave a apresentação modificada em um arquivo PPTX

```c#
// Instanciando apresentação// Instanciando apresentação
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the sample chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Value Axis line format : Now Obselete
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Definir Propriedades de Fonte para um Gráfico**
Aspose.Slides for .NET fornece suporte para definir as propriedades relacionadas à fonte do gráfico. Siga os passos abaixo para definir as propriedades de fonte do gráfico.

- Instancie o objeto da classe Presentation.
- Adicione um gráfico no slide.
- Defina a altura da fonte.
- Salve a apresentação modificada.

A seguir, um exemplo de amostra é apresentado.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Definir o Formato Numérico**
Aspose.Slides for .NET fornece uma API simples para gerenciar o formato dos dados do gráfico:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (este exemplo usa **ChartType.ClusteredColumn**).
1. Defina o formato numérico predefinido a partir dos valores predefinidos possíveis.
1. Percorra cada célula de dados do gráfico em todas as séries do gráfico e defina o formato numérico dos dados do gráfico.
1. Salve a apresentação.
1. Defina o formato numérico personalizado.
1. Percorra cada célula de dados do gráfico dentro de todas as séries e defina um formato numérico diferente para os dados do gráfico.
1. Salve a apresentação.

```c#
// Instanciar a apresentação// Instanciar a apresentação
Presentation pres = new Presentation();

// Acessar o primeiro slide da apresentação
ISlide slide = pres.Slides[0];

// Adicionando um gráfico de colunas agrupadas padrão
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Acessando a coleção de séries do gráfico
IChartSeriesCollection series = chart.ChartData.Series;

// Definindo o formato numérico predefinido
// Percorrendo todas as séries do gráfico
foreach (ChartSeries ser in series)
{
    // Percorrendo cada célula de dados na série
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Definindo o formato numérico
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Salvando a apresentação
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Os valores de formato numérico predefinidos possíveis, juntamente com seus índices, que podem ser usados, são apresentados abaixo:

|**0**|Geral|
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
Aspose.Slides for .NET fornece suporte para definir a área do gráfico. As propriedades **IChart.HasRoundedCorners** e **Chart.HasRoundedCorners** foram adicionadas ao Aspose.Slides.

1. Instancie o objeto da classe `Presentation`.
1. Adicione um gráfico no slide.
1. Defina o tipo de preenchimento e a cor de preenchimento do gráfico
1. Defina a propriedade de canto arredondado como True.
1. Salve a apresentação modificada.

A seguir, um exemplo de amostra é apresentado. 

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como posso lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, exiba rótulos apenas para pontos selecionados, se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos gradientes ou de padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto gradientes/padrões geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.