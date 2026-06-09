---
title: Aspose.Slides for Java 15.5.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini gözden geçirerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.5.0 API'sı ile tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) sınıfları, metodları, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **CommonSlideViewProperties sınıfı ve ICommonSlideViewProperties arabirimi eklendi**
com.aspose.slides.CommonSlideViewProperties sınıfı (ve arayüzü com.aspose.slides.ICommonSlideViewProperties) ortak slayt görünüm özelliklerini temsil eder (şu anda görünüm ölçek seçenekleri).
### **IAxis.getLabelOffset(), setLabelOffset(int) metodları eklendi**
IAxis.getLabelOffset(), setLabelOffset(int) metodları, etiketlerin eksenden olan mesafesini almayı ve belirlemeyi sağlar. Kategori ya da tarih eksenine uygulanır.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) metodları eklendi**
getAutofitType(), setAutofitType(/**TextAutofitType**/byte) metodları com.aspose.slides.IChartTextBlockFormat arabirimine eklendi. Bu değerin değiştirilmesi yalnızca şu grafik bölümlerinde belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de render etkisi yoktur).
### **IChartTextBlockFormat.getWrapText(), setWrapText(byte) metodları eklendi**
getWrapText(), setWrapText(/**NullableBool**/byte) metodları com.aspose.slides.IChartTextBlockFormat arabirimine eklendi. Bu değerin değiştirilmesi yalnızca şu grafik bölümlerinde belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2007/2013'te tam destek).
### **Marjinleri yönetmek için metodlar IChartTextBlockFormat'e eklendi**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() ve setMarginBottom(double) metodları com.aspose.slides.IChartTextBlockFormat arabirimine eklendi. Bu değerlerin değiştirilmesi yalnızca şu grafik bölümlerinde belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de render etkisi yoktur).
### **ViewProperties.getNotesViewProperties() metodu eklendi**
com.aspose.slides.ViewProperties.getNotesViewProperties() özelliği eklendi. Notlar görünüm moduyla ilişkili ortak görünüm özelliklerini alır.
### **ViewProperties.getSlideViewProperties() metodu eklendi**
com.aspose.slides.ViewProperties.getSlideViewProperties() metodu eklendi. Slayt görünüm moduyla ilişkili ortak görünüm özelliklerini alır.