---
title: PHP'de ODP'yi PPTX'e Dönüştür
linktitle: ODP'den PPTX'e
type: docs
weight: 10
url: /tr/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile ODP'yi PPTX'e dönüştürün. Temiz kod örnekleri, toplu ipuçları ve yüksek kalite sonuçlar—PowerPoint gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir ODP sunumunu PPTX formatına nasıl dönüştüreceğinizi açıklar.

## **ODP'yi PPTX/PPT Sunumuna Dönüştür**

Aspose.Slides for PHP via Java, bir sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfını sunar. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı, nesne oluşturulduğunda [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) yapıcısı aracılığıyla ODP'ye de erişebilir. Aşağıdaki örnek, bir ODP Sunumunu PPTX Sunumuna nasıl dönüştüreceğinizi gösterir.

```php
// ODP dosyasını aç
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # ODP sunumunu PPTX formatına kaydetme
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Canlı Örnek**

Aspose.Slides API ile oluşturulmuş [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) web uygulamasını ziyaret edebilirsiniz. Uygulama, ODP'den PPTX'e dönüşümünün Aspose.Slides API ile nasıl uygulanabileceğini gösterir.

## **SSS**

**ODP'yi PPTX'e dönüştürmek için Microsoft PowerPoint veya LibreOffice kurmam gerekiyor mu?**

Hayır. Aspose.Slides bağımsız çalışır ve ODP/PPTX dosyalarını okumak veya yazmak için üçüncü taraf uygulamalara ihtiyaç duymaz.

**Dönüştürme sırasında ana slaytlar, yerleşimler ve temalar korunuyor mu?**

Evet. Kütüphane tam bir sunum nesne modeli kullanır ve yapı, ana slaytlar ve yerleşimler dahil olmak üzere, korunur; böylece tasarım dönüşüm sonrası da doğru kalır.

**Şifre korumalı ODP dosyalarını dönüştürebilir miyim?**

Evet. Aspose.Slides, şifreyi sağladığınızda korumayı tespit etmeyi, [protected presentations](/slides/tr/php-java/password-protected-presentation/) (ODP dahil) açmayı ve üzerinde çalışmayı destekler; ayrıca şifreleme ve belge özelliklerine erişim yapılandırmayı da sağlar.

**Aspose.Slides bulut veya REST tabanlı dönüşüm hizmetleri için uygun mu?**

Evet. Yerel kütüphaneyi kendi arka ucunuzda veya [Aspose.Slides Cloud](https://products.aspose.cloud/slides/tr/family/) (REST API) kullanabilirsiniz; her iki seçenek de ODP → PPTX dönüşümünü destekler.