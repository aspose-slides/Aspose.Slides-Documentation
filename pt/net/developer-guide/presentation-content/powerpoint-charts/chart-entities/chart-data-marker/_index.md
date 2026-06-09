---
title: Gerenciar marcadores de dados de gráfico em apresentações no .NET
linktitle: Marcador de Dados
type: docs
url: /pt/net/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a personalizar marcadores de dados de gráficos no Aspose.Slides para .NET, aumentando o impacto das apresentações nos formatos PPT e PPTX com exemplos claros de código C#."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráfico no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimentos de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que formas padrão de marcador estão disponíveis através da enumeração `MarkerStyleType` e que a aparência do marcador é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir opções de marcador de gráfico**
Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de séries específicas. Para definir as opções de marcador de gráfico, siga os passos abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Criar o gráfico padrão.
- Definir a imagem.
- Obter a primeira série do gráfico.
- Adicionar novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

```c#
// Criar uma instância da classe Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Criando o gráfico padrão
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Obtendo o índice da planilha de dados padrão do gráfico
int defaultWorksheetIndex = 0;

// Obtendo a planilha de dados do gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Excluir a série de demonstração
chart.ChartData.Series.Clear();

// Adicionar nova série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Definir a imagem
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Definir a imagem
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Obter a primeira série do gráfico
IChartSeries series = chart.ChartData.Series[0];

// Adicionar novo ponto (1:3) lá.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Alterando o marcador da série do gráfico
series.Marker.Size = 15;

// Gravar a apresentação no disco
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quais formas de marcador estão disponíveis por padrão?**

Formas padrão estão disponíveis (círculo, quadrado, diamante, triângulo, etc.); a lista é definida pela enumeração [MarkerStyleType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/markerstyletype/). Se você precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [raster formats](/slides/pt/net/convert-powerpoint-to-png/) ou salvar [shapes as SVG](/slides/pt/net/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.