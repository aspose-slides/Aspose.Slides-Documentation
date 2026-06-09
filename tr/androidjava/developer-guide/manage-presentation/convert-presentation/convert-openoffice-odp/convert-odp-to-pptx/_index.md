---
title: Android'de ODP'yi PPTX'e Dönüştür
linktitle: ODP'den PPTX'e
type: docs
weight: 10
url: /tr/androidjava/convert-odp-to-pptx/
keywords:
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- ODP'yi dönüştür
- OpenDocument'tan PPTX'e
- ODP'den PPTX'e
- ODP'yi PPTX olarak kaydet
- ODP'yi PPTX'e dışa aktar
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile ODP'yi PPTX'e dönüştürün. Temiz Java kod örnekleri, toplu ipuçları ve yüksek kaliteli sonuçlar—PowerPoint gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir ODP sunumunu PPTX formatına nasıl dönüştüreceğinizi açıklar.

## **ODP'yi PPTX/PPT Sunumuna Dönüştür**
Aspose.Slides for Android via Java, bir sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfını sunar. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı artık nesne oluşturulduğunda [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) yapıcısı aracılığıyla ODP'ye de erişebilir. Aşağıdaki örnek, bir ODP Sunumunu PPTX Sunumuna nasıl dönüştüreceğinizi gösterir.

```java
// ODP dosyasını aç
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODP sunumunu PPTX formatına kaydet
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Canlı Örnek**
Aspose.Slides API ile inşa edilmiş [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) web uygulamasını ziyaret edebilirsiniz. Uygulama, ODP'den PPTX'e dönüşümünün Aspose.Slides API ile nasıl uygulanabileceğini gösterir.

## **SSS**

**ODP'yi PPTX'e dönüştürmek için Microsoft PowerPoint veya LibreOffice kurmam gerekir mi?**

Hayır. Aspose.Slides bağımsız çalışır ve ODP/PPTX dosyalarını okumak veya yazmak için üçüncü taraf uygulamalara ihtiyaç duymaz.

**Dönüştürme sırasında ana slaytlar, düzenler ve temalar korunuyor mu?**

Evet. Kütüphane, tam bir sunum nesne modeli kullanır ve ana slaytlar ve düzenler dahil yapıyı korur, böylece tasarım dönüştürme sonrasında da doğru kalır.

**Şifre korumalı ODP dosyalarını dönüştürebilir miyim?**

Evet. Aspose.Slides, şifre korumasını algılamayı, şifreyi sağladığınızda [korumalı sunumlar](/slides/tr/androidjava/password-protected-presentation/) (ODP dahil) açmayı ve bunlarla çalışmayı, ayrıca şifreleme ve belge özelliklerine erişimi yapılandırmayı destekler.

**Aspose.Slides bulut veya REST tabanlı dönüşüm hizmetleri için uygun mu?**

Evet. Yerel kütüphaneyi kendi arka uç sisteminizde veya [Aspose.Slides Cloud](https://products.aspose.cloud/slides/tr/family/) (REST API) içinde kullanabilirsiniz; her iki seçenek de ODP → PPTX dönüşümünü destekler.