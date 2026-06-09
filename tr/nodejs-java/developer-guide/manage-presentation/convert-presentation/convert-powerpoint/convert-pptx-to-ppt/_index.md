---
title: JavaScript'te PPTX'i PPT'ye Dönüştür
linktitle: PPTX'ten PPT'ye
type: docs
weight: 21
url: /tr/nodejs-java/convert-pptx-to-ppt/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPTX dönüştür
- PPTX'ten PPT'ye
- PPTX'i PPT olarak kaydet
- PPTX'i PPT'ye dışa aktar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile PPTX'i kolayca PPT'ye dönüştürün—PowerPoint formatlarıyla sorunsuz uyumluluğu sağlayın ve sunumunuzun düzeni ve kalitesini koruyun."
---
## **Genel Bakış**

Bu makale, PPTX biçimindeki PowerPoint Sunumunu JavaScript kullanarak PPT biçimine nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- JavaScript'te PPTX'i PPT'ye Dönüştür

## **JavaScript ile PPTX'i PPT'ye Dönüştür**

JavaScript örnek kodu için aşağıdaki bölüme bakınız, yani [PPTX'i PPT'ye Dönüştür](#convert-pptx-to-ppt). Bu sadece PPTX dosyasını yükler ve PPT biçiminde kaydeder. Farklı kaydetme biçimlerini belirterek, PPTX dosyasını PDF, XPS, ODP, HTML gibi diğer biçimlerde de kaydedebilirsiniz; bu, bu makalelerde tartışıldığı gibi.

- [JavaScript'te PPTX'i PDF'ye Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript'te PPTX'i XPS'ye Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript'te PPTX'i HTML'ye Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript'te PPTX'i ODP'ye Dönüştür](/slides/tr/nodejs-java/save-presentation/)
- [JavaScript'te PPTX'i PNG'ye Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-png/)

## **PPTX'i PPT'ye Dönüştür**

Bir PPTX'i PPT'ye dönüştürmek için **Presentation** sınıfının **Save** yöntemine dosya adını ve kaydetme biçimini geçirmeniz yeterlidir. Aşağıdaki JavaScript kod örneği, bir Sunumu PPTX'ten PPT'ye varsayılan seçeneklerle dönüştürür.

```javascript
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturun
var presentation = new aspose.slides.Presentation("template.pptx");
// sunumu PPT olarak kaydedin
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri, eski PPT (97–2003) biçimine kaydedildiğinde korunur mu?**

Her zaman olmaz. PPT biçimi bazı yeni yeteneklerden yoksundur (ör. belirli efektler, nesneler ve davranışlar), bu nedenle özellikler dönüştürme sırasında sadeleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine sadece seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için sadece o slaytları içeren yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt bazlı dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Şifre korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandırabilirsiniz](/slides/tr/nodejs-java/password-protected-presentation/).