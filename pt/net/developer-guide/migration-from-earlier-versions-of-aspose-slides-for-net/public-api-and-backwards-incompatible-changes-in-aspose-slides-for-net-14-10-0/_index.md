---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 14.10.0
linktitle: Aspose.Slides para .NET 14.10.0
type: docs
weight: 120
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as classes, métodos, propriedades e etc. [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) e outras alterações introduzidas com a API Aspose.Slides for .NET 14.10.0.
{{% /alert %}} 
## **Alterações da API Pública**
#### **Tipo de Campo Footer Foi Adicionado**
O tipo de campo Footer foi adicionado para possibilitar a criação de campos desse tipo e para a serialização válida de apresentações.
#### **Elemento Enum ShapeElementFillSource.Own Foi Excluído**
O elemento enum ShapeElementFillSource.Own foi excluído por estar duplicado. Use ShapeElementFillSource.Shape em vez de ShapeElementFillSource.Own.
#### **Métodos para Remoção de Pontos de Dados e Categorias de Gráficos Foram Adicionados**
Os seguintes métodos, que permitem remover pontos de dados de um gráfico de uma coleção de pontos de dados, foram adicionados:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

O seguinte método, que permite remover uma categoria de gráfico da coleção que a contém, foi adicionado:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remover com ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remover com ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//remover com ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Propriedades Obsoletas de Aspose.Slides.ParagraphFormat Foram Removidas**
As propriedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith e NumberedBulletStyle foram removidas. Elas foram marcadas como obsoletas há muito tempo.
#### **Construtores Inúteis e Obsoletos Foram Removidos**
Os construtores a seguir foram removidos:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)