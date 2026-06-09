---
title: ODP'yi JavaScript'te PPTX'e Dönüştür
linktitle: ODP'den PPTX'e
type: docs
weight: 10
url: /tr/nodejs-java/convert-odp-to-pptx/
keywords:
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- ODP'yi dönüştür
- OpenDocument'ten PPTX'e
- ODP'den PPTX'e
- ODP'yi PPTX olarak kaydet
- ODP'yi PPTX'e dışa aktar
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "ODP'yi PPTX'e, Aspose.Slides for Node.js ile dönüştürün. Temiz JavaScript kod örnekleri, toplu ipuçları ve yüksek kaliteli sonuçlar—PowerPoint gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir ODP sunumunu PPTX formatına nasıl dönüştüreceğinizi açıklar.

## **ODP'yi PPTX/PPT Sunumuna Dönüştür**
Aspose.Slides for Node.js via Java, bir sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfını sunar. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı, nesne oluşturulduğunda [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) yapıcı aracılığıyla ODP'ye de erişebilir. Aşağıdaki örnek, bir ODP Sunumunu PPTX Sunumuna nasıl dönüştüreceğinizi gösterir.

```javascript
// ODP dosyasını aç
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// ODP sunumunu PPTX formatına kaydet
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Canlı Örnek**
[**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) web uygulamasını ziyaret edebilirsiniz; bu uygulama **Aspose.Slides API** ile oluşturulmuştur. Uygulama, ODP'den PPTX'e dönüştürmenin Aspose.Slides API ile nasıl uygulanabileceğini gösterir.

## **SSS**

**ODP'yi PPTX'e dönüştürmek için Microsoft PowerPoint veya LibreOffice kurmam gerekiyor mu?**

Hayır. Aspose.Slides bağımsız çalışır ve ODP/PPTX dosyalarını okumak veya yazmak için üçüncü‑taraf uygulamalara ihtiyaç duymaz.

**Dönüştürme sırasında ana slaytlar, düzenler ve temalar korunuyor mu?**

Evet. Kütüphane tam bir sunum nesne modeli kullanır ve yapı, ana slaytlar ve düzenler dahil olmak üzere korunur; böylece tasarım dönüştürmeden sonra doğru kalır.

**Şifre korumalı ODP dosyalarını dönüştürebilir miyim?**

Evet. Aspose.Slides, korumayı algılamayı, şifreyi sağladığınızda [protected presentations](/slides/tr/nodejs-java/password-protected-presentation/) (ODP dahil) açmayı ve çalışmayı, ayrıca şifreleme ve belge özelliklerine erişimi yapılandırmayı destekler.

**Aspose.Slides bulut veya REST tabanlı dönüştürme hizmetleri için uygun mu?**

Evet. Yerel kütüphaneyi kendi arka uç sisteminizde veya [Aspose.Slides Cloud](https://products.aspose.cloud/slides/tr/family/) (REST API) kullanabilirsiniz; her iki seçenek de ODP → PPTX dönüşümünü destekler.