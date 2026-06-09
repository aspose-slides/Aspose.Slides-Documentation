---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides para .NET 14.10.0
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
description: "Revise as atualizações da API pública e mudanças disruptivas no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}

Esta página lista todos os [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) classes, métodos, propriedades e assim por diante, e outras alterações introduzidas com a API do Aspose.Slides for .NET 14.10.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Aspose.Slides.FieldType.Footer Field Type foi adicionado**
O tipo de campo Footer foi adicionado para possibilitar a criação de campos desse tipo e para a serialização válida de apresentações.
#### **Enum Element ShapeElementFillSource.Own foi excluído**
O elemento de enumeração ShapeElementFillSource.Own foi excluído por ser duplicado. Use ShapeElementFillSource.Shape em vez de ShapeElementFillSource.Own.
#### **Métodos para remoção de pontos de dados e categorias de gráficos foram adicionados**
Os seguintes métodos, que permitem remover um ponto de dados de gráfico de uma coleção de pontos de dados, foram adicionados:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

O seguinte método, que permite remover uma categoria de gráfico da coleção que a contém, foi adicionado:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //remova com ChartCategory.Remove()
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remova com ChartCategoryCollection.Remove()
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//remova com ChartDataPoint.Remove()
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Propriedades obsoletas Aspose.Slides.ParagraphFormat foram removidas**
As propriedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith e NumberedBulletStyle foram removidas. Elas foram marcadas como obsoletas há muito tempo.
#### **Construtores inúteis e obsoletos foram removidos**
Os seguintes construtores foram removidos:

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