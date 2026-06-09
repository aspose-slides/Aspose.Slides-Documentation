---
title: Java’da PPTX’yi PPT’ye Dönüştür
linktitle: PPTX’den PPT’ye
type: docs
weight: 21
url: /tr/java/convert-pptx-to-ppt/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPTX dönüştür
- PPTX’den PPT’ye
- PPTX’yi PPT olarak kaydet
- PPTX’yi PPT’ye dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PPTX’yi PPT’ye kolayca dönüştür—PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzenini ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPTX formatından PPT formatına Java kullanarak nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- Java’da PPTX’yi PPT’ye Dönüştürme

## **Java’da PPTX’yi PPT’ye Dönüştürme**

Java örnek kodu için aşağıdaki bölüme bakın: [PPTX’yi PPT’ye Dönüştür](#convert-pptx-to-ppt). Bu, PPTX dosyasını yükler ve PPT formatında kaydeder. Farklı kayıt formatları belirterek PPTX dosyasını PDF, XPS, ODP, HTML gibi birçok başka formata da kaydedebilirsiniz; bu konular ilgili makalelerde ele alınmıştır.

- [PPTX’yi PDF’ye Java’da Dönüştür](/slides/tr/java/convert-powerpoint-to-pdf/)
- [PPTX’yi XPS’ye Java’da Dönüştür](/slides/tr/java/convert-powerpoint-to-xps/)
- [PPTX’yi HTML’ye Java’da Dönüştür](/slides/tr/java/convert-powerpoint-to-html/)
- [PPTX’yi ODP’ye Java’da Dönüştür](/slides/tr/java/save-presentation/)
- [PPTX’yi PNG’ye Java’da Dönüştür](/slides/tr/java/convert-powerpoint-to-png/)

## **PPTX’yi PPT’ye Dönüştür**
Bir PPTX dosyasını PPT’ye dönüştürmek için dosya adını ve kayıt formatını **Save** yöntemine [**Presentation**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfı üzerinden geçirmeniz yeterlidir. Aşağıdaki Java kod örneği, bir sunumu varsayılan seçeneklerle PPTX’ten PPT’ye dönüştürür.

```java
// bir PPTX dosyasını temsil eden Presentation nesnesi oluştur
Presentation presentation = new Presentation("template.pptx");

// sunumu PPT olarak kaydet
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri, eski PPT (97–2003) formatına kaydedildiğinde korunur mu?**

Her zaman korunmaz. PPT formatı bazı yeni yeteneklerden (ör. belirli efektler, nesneler ve davranışlar) yoksundur, bu nedenle dönüşüm sırasında özellikler sadeleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine yalnızca seçili slaytları PPT’ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için sadece o slaytları içeren yeni bir sunum oluşturup PPT olarak kaydedebilir veya slayt‑başına dönüşüm parametrelerini destekleyen bir servis/API kullanabilirsiniz.

**Şifre korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandırabilirsiniz](/slides/tr/java/password-protected-presentation/).