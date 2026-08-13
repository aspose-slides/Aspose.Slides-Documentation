---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides for Java 14.10.0
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações que quebram a compatibilidade no Aspose.Slides for Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as classes, métodos, propriedades e afins [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduzidas com a API Aspose.Slides for Java 14.10.0.
{{% /alert %}} 
## **Alterações da API Pública**
### **Método com.aspose.slides.FieldType.getFooter() foi adicionado**
O método getFooter() retorna o tipo de campo de rodapé. Foi adicionado para a implementação da possibilidade de criar campos desse tipo e para a serialização válida da apresentação.
### **Elemento com.aspose.slides.ShapeElementFillSource.Own foi removido**
O elemento ShapeElementFillSource.Own foi removido por duplicação. Use ShapeElementFillSource.Shape em vez de ShapeElementFillSource.Own.
### **Métodos para remoção de pontos de dados e categorias de gráfico foram adicionados**
**Os seguintes métodos, que permitem remover um ponto de dados de um gráfico de uma coleção de pontos de dados, foram adicionados:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**O seguinte método, que permite remover uma categoria de gráfico da coleção contendo, foi adicionado:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // remover com ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // remover com ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // remover com ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Métodos obsoletos de Aspose.Slides.ParagraphFormat foram removidos**
Os métodos getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() e os métodos set correspondentes foram removidos. Eles foram marcados como obsoletos há muito tempo.
### **Construtores inúteis e obsoletos foram removidos**
Os seguintes construtores foram removidos:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)