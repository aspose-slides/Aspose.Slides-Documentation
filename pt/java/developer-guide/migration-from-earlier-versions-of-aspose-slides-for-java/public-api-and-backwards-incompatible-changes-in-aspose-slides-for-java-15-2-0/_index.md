---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.2.0
linktitle: Aspose.Slides para Java 15.2.0
type: docs
weight: 110
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Revise as atualizações da API pública e as alterações incompatíveis retroativas no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Esta página lista todas as classes, métodos, propriedades adicionados e assim por diante, quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introduzidas com a API Aspose.Slides for Java 15.2.0.
{{% /alert %}} {{% alert color="primary" %}} 
Existem problemas conhecidos com alguns marcadores de imagem e objetos WordArt que serão corrigidos no Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Alterações da API Pública**
### **Métodos addDataPointForDoughnutSeries foram adicionados**
As duas sobrecargas do método IChartDataPointCollection.addDataPointForDoughnutSeries() foram adicionadas para inserir pontos de dados em séries do tipo Rosca.
### **A classe com.aspose.slides.SmartArtShape foi herdada da classe com.aspose.slides.GeometryShape**
A classe com.aspose.slides.SmartArtShape foi herdada da classe com.aspose.slides.GeometryShape. Essa mudança melhora o modelo de objetos do Aspose.Slides e adiciona novos recursos à classe SmartArtShape.
### **Métodos IGradientStopCollection.add(...) e IGradientStopCollection.insert(...) foram alterados**
A assinatura IGradientStop add(float position, int presetColor) foi substituída pela assinatura IGradientStop addPresetColor(float position, int presetColor).

A assinatura do método IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) foi substituída pela assinatura IGradientStop addSchemeColor(float position, int schemeColor).

A assinatura do método IGradientStopCollection void insert(int index, float position, int presetColor) foi substituída pela assinatura void insertPresetColor(int index, float position, int presetColor).

A assinatura do método IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) foi substituída pela assinatura void insertSchemeColor(int index, float position, int schemeColor).
### **O método java.awt.Color getAutomaticSeriesColor() foi adicionado ao com.aspose.slides.IChartSeries**
O método getAutomaticSeriesColor() retorna uma cor automática da série baseada no índice da série e no estilo do gráfico. Essa cor é usada por padrão se FillType for igual a NotDefined.
 
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Método para remover ponto de dados do gráfico e categoria do gráfico pelo seu índice foi adicionado**
O método IChartDataPointCollection.removeAt(int index) foi adicionado para remover um ponto de dados do gráfico pelo seu índice.
O método IChartCategoryCollection.removeAt(int index) foi adicionado para remover uma categoria do gráfico pelo seu índice.
### **O valor PptXPptY foi adicionado à enumeração com.aspose.slides.PropertyType**
O valor PptXPptY foi adicionado à enumeração com.aspose.slides.PropertyType no contexto de correção de um problema de serialização.