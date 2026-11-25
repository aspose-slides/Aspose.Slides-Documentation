---
title: Personalizar Gráficos 3D em Apresentações no .NET
linktitle: Gráfico 3D
type: docs
url: /pt/net/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie gráficos 3D em apresentações do PowerPoint com Aspose.Slides para .NET. Ajuste rotação, proporções de altura, profundidade do gráfico e espaçamento entre séries com exemplos em C#."
---
## **Visão geral**

Aspose.Slides for .NET permite que você personalize a visualização de um gráfico 3D através da propriedade [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Este artigo demonstra como ajustar rotação, proporções de altura, profundidade, eixos em ângulo reto e espaçamento entre séries, e então salvar a apresentação no formato PPTX.

## **Definir a rotação e a profundidade de um gráfico 3D**

O exemplo abaixo cria uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e usa [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) para adicionar um gráfico de colunas 3D empilhado ao seu primeiro slide. Ele substitui as séries e categorias padrão por duas séries contendo três valores cada. O índice da planilha `0` identifica a primeira planilha de dados do gráfico; a linha `0` contém os nomes das séries, e a coluna `0` contém os rótulos das categorias.

As propriedades [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) e [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) definem a rotação do gráfico para 40 e 270 graus, respectivamente. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) define sua profundidade para 150% da largura, enquanto [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) habilita eixos em ângulo reto em vez de perspectiva. A apresentação resultante contém o gráfico preenchido com essas configurações de visualização 3D.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Aplicar preenchimento de imagem a uma superfície de gráfico 3D**

Um gráfico 3D possui três superfícies que podem ser preenchidas independentemente: a [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), a [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/), e o [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Defina o [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) da superfície selecionada como `Picture` e atribua uma imagem. Defina tanto o [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) quanto o [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) da superfície como `Stretch` para ajustar uma cópia da imagem em toda a superfície.

Salve [arrow.png](arrow.png) no diretório de trabalho. O exemplo rotaciona o gráfico e eleva o valor máximo no eixo vertical para que o piso fique visível entre as colunas. Em seguida, clona o slide duas vezes antes de aplicar a seta a uma superfície diferente em cada slide. Todos os três gráficos mantêm os mesmos dados, ângulo de visualização e plano de fundo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

O Microsoft PowerPoint exibe os três slides da seguinte forma.

| Parede lateral | Parede traseira | Piso |
| --- | --- | --- |
| ![Seta apontando para dentro do gráfico ao longo da parede lateral](side-wall.png) | ![Seta apontando para a direita atravessando a parede traseira](back-wall.png) | ![Seta apontando para a direita atravessando o piso entre as colunas](floor.png) |

## **Ajustar as proporções de altura de um gráfico 3D**

Use [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) para definir a altura de um gráfico 3D como uma porcentagem de sua largura. Isso altera as proporções da cena 3D sem redimensionar o objeto do gráfico no slide.

O exemplo a seguir cria um gráfico [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) com os dados padrão: três séries e quatro categorias. Ele salva três apresentações com proporções de altura de 50%, 100% e 200%. A posição, largura e altura do gráfico permanecem fixas. Os dados, rotação, profundidade, espaçamento das séries e formatação são idênticos em todos os três arquivos; apenas a porcentagem de altura muda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

As imagens a seguir foram exportadas das apresentações geradas usando o Microsoft PowerPoint. Uma porcentagem menor produz uma cena mais plana, enquanto uma porcentagem maior produz uma cena mais alta dentro do mesmo objeto de gráfico. O PowerPoint também pode ajustar os intervalos de marcação dos eixos e a colocação dos rótulos para adaptar a cena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de colunas 3D com altura definida em 50% de sua largura](height_percent_50.png) | ![Gráfico de colunas 3D com altura definida em 100% de sua largura](height_percent_100.png) | ![Gráfico de colunas 3D com altura definida em 200% de sua largura](height_percent_200.png) |

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Altura da cena 3D como uma porcentagem de sua largura. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Altura do objeto de gráfico no slide, em pontos. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profundidade da cena 3D como uma porcentagem de sua largura. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |

A configuração de altura afeta gráficos de colunas e barras 3D, incluindo variantes de cilindro, cone e pirâmide, bem como gráficos de linha, área, pizza e superfície 3D. A comparação acima utiliza o tipo verificado `Column3D`. A configuração não altera a aparência de um gráfico 2D `ClusteredColumn` ou de um gráfico `BubbleWith3D`; esses nomes são membros da enumeração [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Para outras configurações de aparência de gráfico, consulte [Formatação de Gráficos](/slides/pt/net/chart-formatting/).

## **Ajustar o intervalo entre séries**

Use [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) para controlar a distância entre séries de dados ao longo do eixo de profundidade de um gráfico 3D, expressa como porcentagem da largura do marcador. Use valores de **0 a 500**, inclusive: `0` remove o intervalo, enquanto valores maiores aumentam o espaçamento. Com uma profundidade de gráfico fixa, aumentar o intervalo torna os marcadores mais finos ao longo do eixo de profundidade.

Acesse o grupo através de [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). A definição se aplica a todas as séries desse grupo, não apenas à série usada para acessá-lo. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) é somente leitura e reflete a configuração do grupo pai.

Esta configuração afeta gráficos de colunas e barras 3D, incluindo suas variantes de cilindro, cone e pirâmide, bem como gráficos de linha e área 3D. A aparência depende de como as séries estão organizadas em profundidade, em agrupamento ou empilhadas. Para uma comparação clara dos intervalos entre séries distintas, use `ChartType.Column3D` da enumeração [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Essas propriedades controlam diferentes aspectos do gráfico:

| Propriedade | Efeito |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espaçamento entre séries ao longo do eixo de profundidade, como porcentagem da largura do marcador. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Espaçamento entre clusters adjacentes de barras ou colunas, como porcentagem da largura da barra ou coluna. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profundidade geral do gráfico, como porcentagem da largura do gráfico. |

O exemplo autônomo a seguir usa os dados padrão do gráfico, que contêm três séries e quatro categorias. Ele salva duas apresentações com dados idênticos, rotação, largura de intervalo e profundidade do gráfico; apenas a profundidade do intervalo muda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

As imagens a seguir foram exportadas das apresentações geradas usando o Microsoft PowerPoint.

| Profundidade do intervalo: 0% | Profundidade do intervalo: 500% |
| --- | --- |
| ![Gráfico de colunas 3D sem intervalo entre séries ao longo do eixo de profundidade](gap_depth_0.png) | ![Gráfico de colunas 3D com intervalo de 500% entre séries ao longo do eixo de profundidade](gap_depth_500.png) |

## **Alterar o tipo de série 3D e a forma da barra**

Em um gráfico de cilindro agrupado, a primeira série começa com uma forma de barra cilíndrica. O exemplo lê [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) e [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) antes e depois de cada alteração.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Alteração na primeira série | Tipo | Bar3DShape |
| --- | --- | --- |
| Criar o gráfico | `ClusteredCylinder` | `Cylinder` |
| Definir `Type` como `ClusteredCone` | `ClusteredCone` | `Cone` |
| Definir `Bar3DShape` como `Box` | `ClusteredColumn3D` | `Box` |

Definir a forma como `Box` também altera o tipo de série para `ClusteredColumn3D`. Se o seu código ramifica com base no tipo de série, leia `series.Type` após mudar a forma. Um valor armazenado em cache antes da atribuição ainda selecionaria o ramo `ClusteredCone`.

![Comparação no PowerPoint mostrando a primeira série como cilindros, cones e colunas retangulares da esquerda para a direita](series-shapes.png)

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, junto com tipos 3D relacionados expostos através da enumeração [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) na referência de API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem com [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou [renderizar o slide inteiro](/slides/pt/net/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização raster ou deseja incorporar o gráfico em documentos, dashboards ou páginas da web sem exigir o PowerPoint.

**Qual é o desempenho ao construir e renderizar grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de trama, limite o número de pontos de dados por série quando possível e renderize para uma saída de tamanho adequado (resolução e dimensões) que corresponda à exibição ou necessidade de impressão alvo.