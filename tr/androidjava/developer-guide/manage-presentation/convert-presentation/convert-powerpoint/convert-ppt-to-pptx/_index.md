---
title: Android'de PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da eski PPT sunumlarını modern PPTX'e hızlıca dönüştürün — net öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPT formatından PPTX formatına Java kullanarak ve çevrimiçi PPT'den PPTX'e dönüşüm uygulamasıyla nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- Java'da PPT'yi PPTX'e Dönüştürün

## **Android'de PPT'yi PPTX'e Dönüştürün**

PPT'yi PPTX'e dönüştürmek için Java örnek kodu için lütfen aşağıdaki bölüme bakın, yani [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu sadece PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek PPT dosyasını PDF, XPS, ODP, HTML vb. gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi.

- [Android'de PPT'yi PDF'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-pdf/)
- [Android'de PPT'yi XPS'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-xps/)
- [Android'de PPT'yi HTML'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-html/)
- [Android'de PPT'yi ODP'ye Dönüştür](/slides/tr/androidjava/save-presentation/)
- [Android'de PPT'yi PNG'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüştürme Hakkında**
Eski PPT formatını Aspose.Slides API ile PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde bunu sadece birkaç satır kodla yapabilirsiniz. API, PPT sunumunu PPTX'e dönüştürmek için tam uyumluluk sağlar ve şunları yapmak mümkündür:

- Karmaşık ana slayt, yerleşim ve slayt yapılarının dönüştürülmesi.
- Grafikler içeren sunumların dönüştürülmesi.
- Grup şekilleri, otomatik şekilleri (ör. dikdörtgen ve elips), özel geometriye sahip şekilleri içeren sunumların dönüştürülmesi.
- Otomatik şekiller için doku ve resim doldurma stillerine sahip sunumların dönüştürülmesi.
- Yer tutucular, metin çerçeveleri ve metin taşıyıcıları içeren sunumların dönüştürülmesi.

{{% alert color="primary" %}} 

Şuradaki [**Aspose.Slides PPT'den PPTX'e Dönüştürme**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulamasına bir göz atın:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama, [**Aspose.Slides API**](https://products.aspose.com/slides/tr/androidjava/) temel alınarak oluşturulmuştur, böylece temel PPT'den PPTX'e dönüştürme yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Dönüştürme, PPT formatındaki sunum dosyasını bırakmanıza ve PPTX'e dönüştürülmüş olarak indirmenize olanak tanıyan bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Dönüştürme**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'e Dönüştürün**
Aspose.Slides for Android via Java, geliştiricilerin [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıf örneğiyle PPT'ye erişmesini ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesini sağlar. Şu anda, [PPT](https://docs.fileformat.com/presentation/ppt/)‘nin kısmi dönüşümünü PPTX'e desteklemektedir.

Aspose.Slides for Android via Java, **PPTX** sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfını sunar. Presentation sınıfı, nesne örneklenirken artık **PPT**'ye de erişebilir. Aşağıdaki örnek, bir PPT sunumunu PPTX sunumuna nasıl dönüştüreceğinizi gösterir.

```java
// PPTX dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPTX sunumunu PPTX formatında kaydediyor
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Şekil : Kaynak PPT Sunumu**|

Yukarıdaki kod parçacığı dönüşümden sonra aşağıdaki PPTX sunumunu oluşturur

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüştürmeden Sonra Oluşturulan PPTX Sunumu**|

## **SSS**

**PPT ve PPTX formatları arasındaki fark nedir?**

PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha düşük dosya boyutu ve geliştirilmiş veri kurtarma sunar.

**Aspose.Slides, birden çok PPT dosyasını PPTX'e toplu olarak dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides'i bir döngü içinde kullanarak birden çok PPT dosyasını programlı olarak PPTX'e dönüştürebilirsiniz, bu da toplu dönüşüm senaryoları için uygundur.

**Dönüştürme sonrası içerik ve biçimlendirme korunacak mı?**

Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt yerleşimleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

**PPT dosyalarından PDF veya HTML gibi diğer formatlara dönüştürebilir miyim?**

Evet, Aspose.Slides, PPT dosyalarını [multiple formats](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/), PDF, XPS, HTML, ODP ve PNG, JPEG gibi görüntü formatlarına dönüştürmeyi destekler.

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?**

Evet, Aspose.Slides bağımsız bir API'dir ve dönüşüm için Microsoft PowerPoint ya da üçüncü taraf bir yazılım gerektirmez.

**PPT'den PPTX'e dönüşüm için çevrimiçi bir araç mevcut mu?**

Evet, kod yazmadan doğrudan tarayıcınızda dönüşüm yapmanızı sağlayan ücretsiz [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanabilirsiniz.