---
title: Aspose.Slides for .NET 14.2.0'de Genel API ve Geriye Yönelik Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde taşınmasını sağlayın."
---
## **Genel API ve Geriye Yönelik Uyumsuz Değişiklikler**
{{% alert color="primary" %}} 

Aspose.Slides for .NET 14.2.0 API'sinde bazı değişiklikler yaptık. Bazı özellikler ve yöntemler kaldırıldı ve bazıları başka bir ad alanına taşındı.

{{% /alert %}} 
### **Aspose.Slides.IPresentation.Write(…) Yöntemleri Kaldırıldı**
Bu yöntemler sadece Presentation nesnelerini PPTX format dosyasına yazıyordu. Yeni API'de Presentation sınıfı tüm formatlarla çalışmak için kullanılıyor. Presentation.Save(…) yöntemlerini kullanarak Presentation nesnelerini desteklenen tüm formatlarda kaydetmek mümkün.
### **Tema Stilleriyle İlgili Sınıflar Aspose.Slides.Theme Ad Alanına Taşındı**
Aşağıdaki sınıflar Aspose.Slides ad alanından Aspose.Slides.Theme ad alanına taşındı.

- Türler ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Aspose.Slides for .NET 8.X.0'dan Gelen Değişiklikler**
Aspose.Slides for .NET 8.4 özellikleri Aspose.Slides for .NET 14.2.0 sürümüne eklendi.