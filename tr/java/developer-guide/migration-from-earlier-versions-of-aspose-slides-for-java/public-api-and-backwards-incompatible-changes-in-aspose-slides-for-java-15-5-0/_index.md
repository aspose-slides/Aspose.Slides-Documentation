---
title: Aspose.Slides for Java 15.5.0'da Kamu API'sı ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- geçiş
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki kamu API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for Java 15.5.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) sınıfları, metodları, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) listeler.
{{% /alert %}} 
## **Public API Değişiklikleri**
### **CommonSlideViewProperties sınıfı ve ICommonSlideViewProperties arayüzü eklendi**
com.aspose.slides.CommonSlideViewProperties sınıfı (ve onun arayüzü com.aspose.slides.ICommonSlideViewProperties), ortak slayt görünüm özelliklerini temsil eder (şu anda görünüm ölçek seçenekleri).
### **IAxis.getLabelOffset(), setLabelOffset(int) metodları eklendi**
IAxis.getLabelOffset(), setLabelOffset(int) metodları, etiketlerin eksenden olan mesafesini almayı ve belirtmeyi sağlar. Kategori veya tarih eksenine uygulanır.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) metodları eklendi**
getAutofitType(), setAutofitType(/**TextAutofitType**/byte) metodları com.aspose.slides.IChartTextBlockFormat arayüzüne eklenmiştir. Bu değerin değiştirilmesi yalnızca aşağıdaki grafik bölümleri için belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de renderleme için etkisi yoktur).
### **IChartTextBlockFormat.getWrapText(), setWrapText(byte) metodları eklendi**
getWrapText(), setWrapText(/**NullableBool**/byte) metodları com.aspose.slides.IChartTextBlockFormat arayüzüne eklenmiştir. Bu değerin değiştirilmesi yalnızca aşağıdaki grafik bölümleri için belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2007/2013'te tam destek).
### **IChartTextBlockFormat için kenar boşluklarını yönetme metodları eklendi**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() ve setMarginBottom(double) metodları com.aspose.slides.IChartTextBlockFormat arayüzüne eklenmiştir. Bu değerlerin değiştirilmesi yalnızca aşağıdaki grafik bölümleri için belirli bir etki yaratabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de renderleme için etkisi yoktur).
### **ViewProperties.getNotesViewProperties() metodu eklendi**
com.aspose.slides.ViewProperties.getNotesViewProperties() özelliği eklendi. Notlar görünüm moduyla ilişkili ortak görünüm özelliklerini alır.
### **ViewProperties.getSlideViewProperties() metodu eklendi**
com.aspose.slides.ViewProperties.getSlideViewProperties() metodu eklendi. Slayt görünüm modu ile ilişkili ortak görüş özelliklerini alır.