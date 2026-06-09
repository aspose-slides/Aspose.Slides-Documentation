---
title: PHP'de PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile eski PPT sunumlarını modern PPTX'e hızlı bir şekilde dönüştürün — net öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumunu PPT formatından PHP kullanarak ve çevrimiçi PPT'den PPTX dönüşüm uygulamasıyla PPTX formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır.

- PPT'yi PPTX'e Dönüştür

## **PHP'de PPT'yi PPTX'e Dönüştür**

PPT'yi PPTX'e dönüştürmek için Java örnek kodu görmek isterseniz, aşağıdaki bölüme bakın: [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu sadece PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek, PPT dosyasını PDF, XPS, ODP, HTML gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi.

- [PPT'yi PDF'e PHP ile Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/)
- [PPT'yi XPS'e PHP ile Dönüştür](/slides/tr/php-java/convert-powerpoint-to-xps/)
- [PPT'yi HTML'e PHP ile Dönüştür](/slides/tr/php-java/convert-powerpoint-to-html/)
- [PPT'yi ODP'ye PHP ile Dönüştür](/slides/tr/php-java/save-presentation/)
- [PPT'yi PNG'ye PHP ile Dönüştür](/slides/tr/php-java/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüşüm Hakkında**

Eski PPT formatını Aspose.Slides API ile PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde bunu sadece birkaç satır kodla yapabilirsiniz. API, PPT sunumunu PPTX'e dönüştürmek için tam uyumluluk sağlar ve şu işlemler mümkün:

- Master, düzen ve slaytların karmaşık yapısını dönüştürün.
- Grafik içeren sunumu dönüştürün.
- Grup şekilleri, otomatik şekiller (örneğin dikdörtgen ve elips), özel geometriye sahip şekiller içeren sunumu dönüştürün.
- Otomatik şekiller için doku ve resim dolgu stillerine sahip sunumu dönüştürün.
- Yer tutucular, metin çerçeveleri ve metin tutucular içeren sunumu dönüştürün.

{{% alert color="primary" %}} 

Şu uygulamaya bir göz atın [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama [**Aspose.Slides API**](https://products.aspose.com/slides/tr/php-java/) temelli olarak oluşturulmuştur, böylece temel PPT'den PPTX'e dönüşüm yeteneklerinin canlı örneğini görebilirsiniz. Aspose.Slides Conversion, PPT formatında sunum dosyasını sürükleyip bırakmanıza ve PPTX'e dönüştürülmüş olarak indirmenize izin veren bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'e Dönüştür**

Aspose.Slides for PHP via Java artık geliştiricilerin [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıf örneğiyle PPT'ye erişmesini ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesini kolaylaştırıyor. Şu anda, [PPT](https://docs.fileformat.com/presentation/ppt/) den PPTX'e kısmi dönüşümü desteklemektedir. PPT'den PPTX'e dönüşümde hangi özelliklerin desteklendiği ve desteklenmediği hakkında daha fazla bilgi için lütfen bu belgeye [link](/slides/tr/php-java/ppt-to-pptx-conversion/) gidin.

Aspose.Slides for PHP via Java, **PPTX** sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfını sunar. Presentation sınıfı artık nesne örneklenirken **PPT**'ye de erişebilir. Aşağıdaki örnek bir PPT sunumunu PPTX sunumuna nasıl dönüştüreceğinizi gösterir.

```php
  # PPTX dosyasını temsil eden bir Presentation nesnesi oluştur
  $pres = new Presentation("Aspose.ppt");
  try {
    # PPTX sunumunu PPTX formatına kaydet
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Şekil : Kaynak PPT Sunumu**|

Yukarıdaki kod örneği dönüşümden sonra aşağıdaki PPTX sunumunu oluşturdu

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüştürmeden Sonra Oluşturulan PPTX Sunumu**|

## **SSS**

**PPT ve PPTX formatları arasındaki fark nedir?**

PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha küçük dosya boyutu ve gelişmiş veri kurtarma sağlar.

**Aspose.Slides birden fazla PPT dosyasının toplu olarak PPTX'e dönüştürülmesini destekliyor mu?**

Evet, Aspose.Slides'ı bir döngü içinde kullanarak birden fazla PPT dosyasını programlı olarak PPTX'e dönüştürebilir ve bu sayede toplu dönüşüm senaryolarına uygun hale getirebilirsiniz.

**Dönüştürmeden sonra içerik ve biçimlendirme korunacak mı?**

Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

**PPT dosyalarından PDF veya HTML gibi diğer formatları dönüştürebilir miyim?**

Evet, Aspose.Slides PPT dosyalarını [çoklu formatlara](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) dönüştürmeyi destekler; bunlar arasında PDF, XPS, HTML, ODP ve PNG ile JPEG gibi görüntü formatları bulunur.

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?**

Evet, Aspose.Slides bağımsız bir API'dir ve dönüşüm gerçekleştirmek için Microsoft PowerPoint veya herhangi bir üçüncü taraf yazılımına ihtiyaç duymaz.

**PPT'den PPTX'e dönüşüm için çevrimiçi bir araç mevcut mu?**

Evet, ücretsiz [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanarak herhangi bir kod yazmadan doğrudan tarayıcınızda dönüşümü gerçekleştirebilirsiniz.