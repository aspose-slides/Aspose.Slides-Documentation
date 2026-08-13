---
title: "Aspose.Slides for .NET 14.2.0'de Genel API ve Geriye Uyumsuz Değişiklikler"
linktitle: "Aspose.Slides for .NET 14.2.0"
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
description: "Aspose.Slides for .NET'te genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
## **Genel API ve Geriye Uyumsuz Değişiklikler**
{{% alert color="info" %}} 

Aspose.Slides for .NET 14.2.0 API'sinde bazı değişiklikler yaptık. Bazı özellikler ve yöntemler kaldırıldı, bazıları ise başka bir ad alanına taşındı.

{{% /alert %}} 
### **Aspose.Slides.IPresentation.Write(…) Yöntemleri Kaldırıldı**
Bu yöntemler yalnızca Presentation nesnelerini PPTX format dosyasına yazıyordu. Yeni API'de Presentation sınıfı tüm biçimlerle çalışmak için tasarlanmıştır. Presentation.Save(…) yöntemlerini kullanarak Presentation nesnelerini desteklenen tüm biçimlere kaydetmek mümkündür.
### **Tema Stilleriyle İlgili Sınıflar Aspose.Slides.Theme Ad Alanına Taşındı**
Aşağıdaki sınıflar Aspose.Slides ad alanından Aspose.Slides.Theme ad alanına taşınmıştır.

- Types ColorScheme
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
### **Aspose.Slides for .NET 8.X.0'dan Değişiklikler**
Aspose.Slides for .NET 8.4 özellikleri Aspose.Slides for .NET 14.2.0'a eklenmiştir.