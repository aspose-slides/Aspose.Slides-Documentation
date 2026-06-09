---
title: "Android'de PPTX'yi PPT'ye Dönüştür"
linktitle: "PPTX'ten PPT'ye"
type: docs
weight: 21
url: /tr/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides ile PPTX'i PPT'ye kolayca dönüştürün—PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzenini ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPTX formatından Java kullanarak PPT formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır.

- Java’da PPTX’yi PPT’ye Dönüştür

## **Android’de PPTX’yi PPT’ye Dönüştür**

PPTX'yi PPT'ye dönüştürmek için Java örnek kodu için lütfen aşağıdaki bölüme bakın, yani [Convert PPTX to PPT](#convert-pptx-to-ppt). Bu sadece PPTX dosyasını yükler ve PPT formatında kaydeder. Farklı kaydetme formatları belirterek, PPTX dosyasını PDF, XPS, ODP, HTML vb. gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde açıklandığı gibi.

- [Android’de PPTX'yi PDF'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-pdf/)
- [Android’de PPTX'yi XPS'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-xps/)
- [Android’de PPTX'yi HTML'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-html/)
- [Android’de PPTX'yi ODP'ye Dönüştür](/slides/tr/androidjava/save-presentation/)
- [Android’de PPTX'yi PNG'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-png/)

## **PPTX'yi PPT'ye Dönüştür**

Bir PPTX'yi PPT'ye dönüştürmek için dosya adını ve kaydetme formatını **Save** metoduna [**Presentation**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı üzerinden aktarın. Aşağıdaki Java kod örneği, bir Sunumu varsayılan seçeneklerle PPTX'den PPT'ye dönüştürür.

```java
// PPTX dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation presentation = new Presentation("template.pptx");

// Sunumu PPT olarak kaydet
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri, eski PPT (97–2003) formatına kaydedildiğinde korunur mu?**

Her zaman değildir. PPT formatı bazı yeni yeteneklerden yoksundur (ör. belirli efektler, nesneler ve davranışlar), bu nedenle özellikler dönüştürme sırasında basitleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine sadece seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için yalnızca o slaytları içeren yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt bazında dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Şifre korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve ayrıca kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandır](/slides/tr/androidjava/password-protected-presentation/) yapılandırabilirsiniz.