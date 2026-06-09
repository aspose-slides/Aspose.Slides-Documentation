---
title: API Pública e Alterações Incompatíveis com Versões Anteriores em Aspose.Slides para .NET 14.3.0
linktitle: Aspose.Slides para .NET 14.3.0
type: docs
weight: 50
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis em Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
## **API Pública e Alterações Incompatíveis com Versões Anteriores**
### **Enumeração Aspose.Slides.ShapeThumbnailBounds e Métodos Aspose.Slides.IShape.GetThumbnail() Adicionados**
Os métodos GetThumbnail() e GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) são usados para criar uma miniatura de forma separada. A enumeração ShapeThumbnailBounds define os possíveis tipos de limites de miniatura de forma.
### **Propriedade UniqueId Foi Adicionada ao Aspose.Slides.IShape**
A propriedade Aspose.Slides.IShape.UniqueId obtém um identificador de forma exclusivo no escopo de uma apresentação. Esses identificadores exclusivos são armazenados nas tags personalizadas da forma.
### **Assinatura do Método SetGroupingItem Alterada em IChartCategoryLevelsManager**
A assinatura do método IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

está obsoleta agora e foi substituída pela assinatura

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Agora chamadas como

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

devem ser alteradas para chamadas como

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Passe um valor como "Group 1" para SetGroupingItem, mas não um valor do tipo IChartDataCell. Construir IChartDataCell com uma planilha, linha e coluna definidas para níveis de categoria deve atender a alguns requisitos e foi encapsulado no método SetGroupingItem(int, object).
### **Propriedade SlideId Adicionada à Interface Aspose.Slides.IBaseSlide**
A propriedade SlideId obtém um identificador de slide exclusivo.
### **Propriedade SoundName Adicionada ao ISlideShowTransition**
String de leitura e escrita. Especifica um nome legível para o som da transição. A propriedade Sound deve ser atribuída para obter ou definir o nome do som. Esse nome aparece na interface do usuário do PowerPoint ao configurar manualmente o som da transição. Pode lançar PptxException quando a propriedade Sound não está atribuída.
### **Tipo da Propriedade ChartSeriesGroup.Type Alterado**
A propriedade ChartSeriesGroup.Type foi alterada da enumeração ChartType para a nova enumeração CombinableSeriesTypesGroup. A enumeração CombinableSeriesTypesGroup representa os grupos de tipos de séries combináveis.
### **Suporte para Geração de Miniaturas de Formas Individuais Adicionado**
Aspose.Slides.ShapeThumbnailBounds

Novos membros em Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)