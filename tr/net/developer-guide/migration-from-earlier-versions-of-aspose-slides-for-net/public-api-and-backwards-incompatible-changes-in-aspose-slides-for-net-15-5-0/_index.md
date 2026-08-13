---
title: Aspose.Slides for .NET 15.5.0'da Genel API ve Geriye Uyumlu Olmayan Değişiklikler
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for .NET 15.5.0 API'sı ile tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **CommonSlideViewProperties Sınıfı ve ICommonSlideViewProperties Arayüzü Eklendi**
Aspose.Slides.CommonSlideViewProperties sınıfı ve Aspose.Slides.ICommonSlideViewProperties arayüzü ortak slayt görünüm özelliklerini temsil eder (şu anda görünüm ölçekleme seçenekleri).
#### **IAxis.LabelOffset Özelliği Eklendi**
IAxis.LabelOffset özelliği etiketlerin eksenden olan mesafesini belirtir. Kategori veya tarih eksenine uygulanır.
#### **IChartTextBlockFormat.AutofitType Özelliği Eklendi**
Bu özelliğin değiştirilmesi sadece şu grafik bölümleri için belirli bir etki oluşturabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de renderleme için etkisi yok).
#### **IChartTextBlockFormat.WrapText Özelliği Eklendi**
Bu özelliğin değiştirilmesi sadece şu grafik bölümleri için belirli bir etki oluşturabilir: DataLabel ve DataLabelFormat (PowerPoint 2007/2013'te tam destek).
#### **Margin Özellikleri IChartTextBlockFormat'a Eklendi**
Bu özelliklerin değiştirilmesi sadece şu grafik bölümleri için belirli bir etki oluşturabilir: DataLabel ve DataLabelFormat (PowerPoint 2013'te tam destek; PowerPoint 2007'de renderleme için etkisi yok).
#### **ViewProperties.NotesViewProperties Özelliği Eklendi**
Aspose.Slides.ViewProperties.NotesViewProperties özelliği eklendi. Notlar görünüm moduyla ilişkili ortak görünüm özelliklerini belirtir.
#### **ViewProperties.SlideViewProperties Özelliği Eklendi**
Aspose.Slides.ViewProperties.SlideViewProperties özelliği eklendi. Slayt görünüm modu ile ilişkili ortak görünüm özelliklerini belirtir.