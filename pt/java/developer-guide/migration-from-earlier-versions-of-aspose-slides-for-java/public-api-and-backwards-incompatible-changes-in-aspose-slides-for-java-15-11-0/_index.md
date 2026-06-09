---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.11.0
linktitle: Aspose.Slides para Java 15.11.0
type: docs
weight: 190
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
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
description: "Revisar atualizações da API pública e alterações que quebram a compatibilidade no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e similares [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) ou [removidos](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/), e outras alterações introduzidas com a API Aspose.Slides for Java 15.11.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Métodos obsoletos na classe com.aspose.slides.DataLabelCollection foram removidos**
Métodos obsoletos na classe com.aspose.slides.DataLabelCollection foram removidos:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Novos métodos getFirstSlideNumber() e setFirstSlideNumber() foram adicionados à classe Presentation**
Novos métodos getFirstSlideNumber() e setFirstSlideNumber() permitem obter ou definir o número do primeiro slide em uma apresentação.
Quando um novo valor para o número do primeiro slide é especificado, todos os números dos slides são recalculados.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```