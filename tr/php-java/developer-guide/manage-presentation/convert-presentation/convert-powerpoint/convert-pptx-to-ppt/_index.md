---
title: PHP'de PPTX'yi PPT'ye Dönüştür
linktitle: PPTX'den PPT'ye
type: docs
weight: 21
url: /tr/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPTX'i dönüştür
- PPTX'den PPT'ye
- PPTX'i PPT olarak kaydet
- PPTX'i PPT'ye aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PPTX'i kolayca PPT'ye dönüştürün — PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzeni ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunusunu PPTX biçiminden PHP kullanarak PPT biçimine nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- PPTX'yi PPT'ye Dönüştür

## **PHP'de PPTX'yi PPT'ye Dönüştür**

PPTX'yi PPT'ye dönüştürmek için Java örnek kodu görmek istiyorsanız, aşağıdaki bölüme bakın: [Convert PPTX to PPT](#convert-pptx-to-ppt). Bu sadece PPTX dosyasını yükler ve PPT biçiminde kaydeder. Farklı kaydetme biçimlerini belirterek, PPTX dosyasını PDF, XPS, ODP, HTML vb. gibi birçok başka biçimde de kaydedebilirsiniz; bu makalelerde ele alınmıştır. 

- [PHP'de PPTX'yi PDF'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/)
- [PHP'de PPTX'yi XPS'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-xps/)
- [PHP'de PPTX'yi HTML'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-html/)
- [PHP'de PPTX'yi ODP'ye Dönüştür](/slides/tr/php-java/save-presentation/)
- [PHP'de PPTX'yi PNG'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-png/)

## **PPTX'yi PPT'ye Dönüştür**
PPTX'yi PPT'ye dönüştürmek için dosya adını ve kaydetme biçimini **Presentation** sınıfının **Save** yöntemine geçirmeniz yeterlidir. Aşağıdaki PHP kod örneği, varsayılan seçenekleri kullanarak bir sunumu PPTX'ten PPT'ye dönüştürür.

```php
  # bir PPTX dosyasını temsil eden Presentation nesnesi oluştur
  $presentation = new Presentation("template.pptx");
  # sunumu PPT olarak kaydet
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri, eski PPT (97–2003) biçimine kaydedildiğinde korunur mu?**

Her zaman değil. PPT biçimi, bazı yeni yeteneklere (örneğin belirli efektler, nesneler ve davranışlar) sahip değildir, bu yüzden özellikler dönüşüm sırasında sadeleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine yalnızca seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için, sadece o slaytları içeren yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt bazında dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Parola korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandırabilirsiniz](/slides/tr/php-java/password-protected-presentation/).