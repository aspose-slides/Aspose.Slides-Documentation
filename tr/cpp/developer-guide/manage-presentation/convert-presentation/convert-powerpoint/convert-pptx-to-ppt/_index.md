---
title: C++ ile PPTX'i PPT'ye Dönüştür
linktitle: PPTX'ten PPT'ye
type: docs
weight: 21
url: /tr/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPTX dönüştür
- PPTX'ten PPT'ye
- PPTX'i PPT olarak kaydet
- PPTX'i PPT'ye dışa aktar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PPTX'i PPT'ye kolayca dönüştürün—PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzeni ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPTX formatından C++ kullanarak PPT formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır.

- PPTX'i C++ ile PPT'ye dönüştürün

## **C++ ile PPTX'i PPT'ye Dönüştürme**

PPTX'i PPT'ye dönüştürmek için C++ örnek kodu görmek istiyorsanız, aşağıdaki bölüme, yani [Convert PPTX to PPT](#convert-pptx-to-ppt) bağlantısına bakın. Bu sadece PPTX dosyasını yükler ve PPT formatında kaydeder. Farklı kaydetme formatları belirterek, PPTX dosyasını PDF, XPS, ODP, HTML vb. gibi birçok diğer formata da kaydedebilirsiniz; bu makalelerde ele alınmıştır.

- [C++ ile PPTX'i PDF'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-pdf/)
- [C++ ile PPTX'i XPS'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-xps/)
- [C++ ile PPTX'i HTML'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-html/)
- [C++ ile PPTX'i ODP'ye Dönüştür](/slides/tr/cpp/save-presentation/)
- [C++ ile PPTX'i PNG'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-png/)

## **PPTX'i PPT'ye Dönüştür**

Bir PPTX'i PPT'ye dönüştürmek için dosya adını ve kaydetme formatını **Save** yöntemine [**Presentation**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının içinde iletmeniz yeterlidir. Aşağıdaki C++ kod örneği, bir Sunumu PPTX'den PPT'ye varsayılan seçeneklerle dönüştürür.

```cpp
// PPTX'i yükle.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT formatında kaydet.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri eski PPT (97–2003) formatına kaydedildiğinde korunur mu?**

Her zaman değil. PPT formatı bazı yeni yetenekleri (örneğin, belirli efektler, nesneler ve davranışlar) içermez, bu yüzden özellikler dönüşüm sırasında basitleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine yalnızca seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için, yalnızca o slaytlardan oluşan yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt bazında dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Parola korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve ayrıca kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandırabilirsiniz](/slides/tr/cpp/password-protected-presentation/).