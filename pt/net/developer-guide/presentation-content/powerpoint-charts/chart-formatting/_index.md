---
title: "Formatar Gráficos de Apresentação em .NET"
linktitle: "Formatação de Gráficos"
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
description: "Aprenda a formatar gráficos no Aspose.Slides para .NET e eleve sua apresentação PowerPoint com eixos personalizados, fontes, formatos numéricos e bordas arredondadas nos gráficos."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar elementos‑chave do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

Para preenchimentos e contornos separados em intervalos de alta e baixa, consulte o [exemplo de gráfico de ações](/slides/pt/net/create-chart/#create-stock-charts).

## **Formatar Entidades de Gráfico**

Use [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) para formatar títulos de gráfico, eixos, linhas de grade, legendas e a área de plotagem. Este exemplo cria um gráfico de linhas com marcadores e dados padrão, então aplica estilos de texto e linha separados aos seus eixos de valores e de categorias. Tamanhos de fonte e larguras de linha são especificados em pontos; os rótulos de categoria são girados em 45 graus.

O eixo de valores usa [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) independentemente das células de origem. Sua escala varia de -2 a 15, com intervalos principais de 2 e intervalos secundários de 0,5. O exemplo também combina formatação percentual com [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) definido para milhares, portanto ajuste essas configurações ao significado e magnitude dos seus dados. A legenda permanece fora da área de plotagem porque [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) está desativado. Os preenchimentos de parede traseira e piso são configurados através de [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) e [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), mas essas superfícies são visíveis apenas em gráficos 3D.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Definir propriedades de fonte para um gráfico**

Defina o tamanho de fonte padrão para o texto do gráfico através de [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). O exemplo cria um gráfico de colunas agrupadas com fonte de 20 pontos e habilita rótulos de valor para a primeira série através de [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Elementos de texto com suas próprias configurações explícitas de fonte podem sobrescrever o padrão do gráfico.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Reutilizar formatação de quadro de texto para a legenda do gráfico**

Para combinar uma legenda com o título de um slide, defina a fonte no [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) do primeiro parágrafo. Chame [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) no [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) da legenda. Ele lê as configurações do quadro de texto, a formatação do primeiro parágrafo e as propriedades de fonte padrão desse parágrafo. A formatação aplicada diretamente a porções individuais ou a parágrafos posteriores permanece local à fonte.

O exemplo usa um título em Calibri negrito de 26 pontos em azul marinho como modelo. Após estilizar a legenda, ele usa [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) para aplicar a mesma formatação a uma legenda separada.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

Na apresentação salva, a legenda e a legenda (caption) correspondem ao título em tamanho, peso e cor. A legenda ainda exibe os nomes das séries, e a legenda (caption) mantém seu próprio texto. Se uma porção na legenda já tiver um tamanho de fonte explícito, esse tamanho tem precedência sobre o padrão do parágrafo copiado.

| Antes de copiar | Depois de copiar |
| --- | --- |
| ![Gráfico de vendas trimestrais com rótulos de legenda pretos regulares e uma legenda preta](legend-formatting-before.png) | ![O mesmo gráfico com rótulos de legenda maiores, em negrito e azul marinho, e uma legenda correspondente](legend-formatting.png) |

## **Definir o formato numérico**

Use [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) para aplicar um formato numérico embutido às células da planilha do gráfico. Este exemplo cria um gráfico de colunas agrupadas com dados padrão baseados em células e aplica o índice de formato 10 (`0.00%`) a cada célula de valor da série. Isso altera a forma como os valores são exibidos na planilha sem mudar os números subjacentes; por exemplo, 0,25 é exibido como 25,00%. Os formatos de eixo e de rótulo de dados podem ser configurados separadamente.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

A tabela a seguir lista os índices de formatos numéricos incorporados com formatos representativos do Excel para o locale Inglês (Estados Unidos). As strings de formato exatas e sua exibição podem variar por aplicativo e locale, particularmente para moeda e datas. Alguns formatos do Excel também diferem dos padrões no padrão OOXML, conforme descrito nas [observações de implementação de formato numérico da Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Índice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Definir bordas arredondadas da área do gráfico**

Habilite [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) para arredondar os cantos da área do gráfico. O exemplo cria um gráfico de colunas agrupadas e usa [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para dar ao seu contorno uma cor cinza sólida e um estilo de linha única antes de salvar a apresentação.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Editar Anotações de Gráfico Existentes**

Um gráfico pode conter formas personalizadas, como uma anotação de texto explicando o status de um relatório. Acesse essas formas através de [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), também listadas em [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) na referência da API de Gráficos. Sua coleção [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) contém as formas pertencentes ao gráfico.

Uma caixa de texto comum posicionada sobre um gráfico pertence ao slide, mesmo que pareça parte do gráfico. Iterar através de [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) encontra o gráfico e as formas comuns do slide, mas não enumera as formas individuais dentro do gráfico. Títulos de gráfico e rótulos de dados são elementos de gráfico separados, não anotações personalizadas nesta coleção.

Faça o download de [chart-annotations.pptx](chart-annotations.pptx) e coloque‑o no diretório de trabalho do aplicativo. Seu primeiro slide contém um gráfico com uma anotação desagrupada exibindo "Resultados preliminares", uma linha pertencente ao gráfico e uma caixa de texto comum do slide exibindo "Sobreposição de slide". O exemplo encontra o primeiro gráfico nesse slide e altera a anotação para "Resultados finais" quando o relatório estiver pronto para publicação. Ele verifica se a coleção está vazia e edita apenas um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) com um [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) não nulo e o texto esperado.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

A linha e a caixa de texto do slide permanecem inalteradas. As imagens a seguir mostram a entrada e o resultado salvo e reaberto:

| Antes de editar | Depois de editar |
| --- | --- |
| ![Anotação do gráfico exibindo Resultados preliminares](chart-annotations-before.png) | ![Anotação do gráfico exibindo Resultados finais](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
O exemplo inspeciona apenas as formas de nível superior pertencentes ao gráfico. Se uma anotação estiver dentro de um [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), inspecione também a coleção [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) desse grupo. Repita isso recursivamente para grupos aninhados, aplicando as mesmas verificações de texto às suas formas filhas. Um grupo em si é um contêiner; não o trate como uma caixa de texto.
{{% /alert %}}

## **Perguntas frequentes**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como posso lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste a posição do rótulo, exiba rótulos apenas para pontos selecionados, se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos de gradiente ou padrão às séries?**

Sim. As séries suportam preenchimentos sólidos, gradientes e padrões. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.