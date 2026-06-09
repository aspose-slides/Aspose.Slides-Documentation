---
title: PPTX'i .NET'te PPT'ye Dönüştür
linktitle: PPTX'ten PPT'ye
type: docs
weight: 21
url: /tr/net/convert-pptx-to-ppt/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPTX dönüştür
- PPTX'ten PPT'ye
- PPTX'i PPT olarak kaydet
- PPTX'i PPT'ye aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPTX'i PPT'ye kolayca dönüştürün—PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzenini ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPTX formatından C# kullanarak PPT formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- C#'ta PPTX'i PPT'ye Dönüştür

## **.NET'te PPTX'i PPT'ye Dönüştür**

C# örnek kodu için lütfen aşağıdaki bölüme bakın, yani [Convert PPTX to PPT](#convert-pptx-to-ppt). Bu sadece PPTX dosyasını yükler ve PPT formatında kaydeder. Farklı kaydetme formatları belirterek, PPTX dosyasını PDF, XPS, ODP, HTML vb. gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi. 

- [Convert PPTX to PDF in .NET](/slides/tr/net/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in .NET](/slides/tr/net/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in .NET](/slides/tr/net/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in .NET](/slides/tr/net/save-presentation/)
- [Convert PPTX to PNG in .NET](/slides/tr/net/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
Bir PPTX'i PPT'ye dönüştürmek için dosya adını ve kaydetme formatını [**Save**](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metoduna [**Presentation**](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı üzerinden iletmeniz yeterlidir. Aşağıdaki C# kod örneği, varsayılan seçeneklerle bir Sunumu PPTX'ten PPT'ye dönüştürür.

```c#
// Bir PPTX dosyasını temsil eden Presentation nesnesi oluşturun
Presentation pres = new Presentation("presentation.pptx");

// PPTX sunumunu PPT formatına kaydediyor
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri, eski PPT (97–2003) formatına kaydedildiğinde korunur mu?**

Her zaman değildir. PPT formatı bazı yeni yeteneklerden yoksundur (ör. belirli efektler, nesneler ve davranışlar), bu nedenle özellikler dönüşüm sırasında sadeleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine yalnızca seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için, sadece bu slaytlardan oluşan yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt bazında dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Şifre korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve kaydedilen PPT için ayrıca [configure protection/encryption settings](/slides/tr/net/password-protected-presentation/) yapılandırabilirsiniz.