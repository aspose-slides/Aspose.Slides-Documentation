---
title: Aspose.Slides for Java 15.11.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.11.0 API'sı ile tanıtılan [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) veya [kaldırılan](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **com.aspose.slides.DataLabelCollection sınıfındaki kullanımdan kaldırılmış metodlar silindi**
com.aspose.slides.DataLabelCollection sınıfındaki kullanımdan kaldırılmış metodlar silindi:

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


#### **Presentation sınıfına getFirstSlideNumber() ve setFirstSlideNumber() metodları eklendi**
Yeni getFirstSlideNumber() ve setFirstSlideNumber() metodları, bir sunumdaki ilk slayt numarasını almayı veya ayarlamayı sağlar.  
Yeni bir ilk slayt numarası değeri belirtildiğinde tüm slayt numaraları yeniden hesaplanır.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```