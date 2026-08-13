---
title: Android'de PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da eski PPT sunumlarını modern PPTX'e hızlıca dönüştürün — net öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPT formatından PPTX formatına Java kullanarak ve çevrimiçi PPT‑den PPTX dönüşüm uygulamasıyla nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- Java'da PPT'yi PPTX'e dönüştür

## **Android'de PPT'yi PPTX'e Dönüştür**

Java örnek kodu için PPT'yi PPTX'e dönüştürmek üzere aşağıdaki bölüme bakın: [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu sadece PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek PPT dosyasını PDF, XPS, ODP, HTML vb. gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde açıklandığı gibi.

- [Android'de PPT'yi PDF'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-pdf/)
- [Android'de PPT'yi XPS'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-xps/)
- [Android'de PPT'yi HTML'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-html/)
- [Android'de PPT'yi ODP'ye Dönüştür](/slides/tr/androidjava/save-presentation/)
- [Android'de PPT'yi PNG'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüştürme Hakkında**
Eski PPT formatını Aspose.Slides API ile PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde sadece birkaç satır kodla bu mümkündür. API, PPT sunumunu PPTX'e dönüştürmek için tam uyumluluk sağlar ve şunları yapabilir:

- Karmaşık ana şablon, düzen ve slayt yapılarını dönüştür.
- Grafikler içeren sunumları dönüştür.
- Grup şekilleri, otomatik şekilleri (ör. dikdörtgen ve elips), özel geometriye sahip şekiller içeren sunumları dönüştür.
- Otomatik şekiller için doku ve resim doldurma stillerine sahip sunumları dönüştür.
- Yer tutucular, metin çerçeveleri ve metin kutuları içeren sunumları dönüştür.

{{% alert color="info" %}} 

Şu uygulamaya bir göz atın: [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulaması:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama, [**Aspose.Slides API**](https://products.aspose.com/slides/tr/androidjava/) temelli olarak oluşturulmuştur, böylece temel PPT'den PPTX'e dönüştürme yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Conversion, PPT formatındaki sunum dosyasını sürükleyip bırakmanıza ve PPTX'e dönüştürülmüş hâlinde indirmenize olanak tanıyan bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'e Dönüştür**
Aspose.Slides for Android via Java, geliştiricilerin PPT'ye [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı örneğiyle erişmesini ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesini sağlar. Şu anda, [PPT](https://docs.fileformat.com/presentation/ppt/) formatının kısmi dönüşümünü PPTX'e desteklemektedir.

Aspose.Slides for Android via Java, **PPTX** sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfını sunar. Presentation sınıfı, nesne oluşturulduğunda **PPT**'ye de erişebilir. Aşağıdaki örnek, bir PPT sunumunu PPTX sunumuna nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

// PPT dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPT sunumunu PPTX formatına kaydediyor
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Şekil : Kaynak PPT Sunumu**|

Yukarıdaki kod parçacığı, dönüşümden sonra aşağıdaki PPTX sunumunu oluşturdu

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüşümden sonra Oluşturulan PPTX Sunumu**|

## **SSS**

### PPT ve PPTX formatları arasındaki fark nedir?
PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha küçük dosya boyutu ve geliştirilmiş veri kurtarma sağlar.

### Aspose.Slides birden çok PPT dosyasının toplu olarak PPTX'e dönüştürülmesini destekliyor mu?
Evet, Aspose.Slides'i bir döngü içinde kullanarak birden çok PPT dosyasını programlı olarak PPTX'e dönüştürebilir, bu da toplu dönüşüm senaryoları için uygundur.

### Dönüştürme sonrasında içerik ve biçimlendirme korunacak mı?
Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT‑den PPTX‑e dönüşüm sırasında korunur.

### PPT dosyalarından PDF veya HTML gibi diğer formatlara dönüştürebilir miyim?
Evet, Aspose.Slides, PPT dosyalarını [multiple formats](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) dahil PDF, XPS, HTML, ODP ve PNG, JPEG gibi resim formatlarına dönüştürmeyi destekler.

### Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?
Evet, Aspose.Slides bağımsız bir API'dir ve dönüşüm için Microsoft PowerPoint veya herhangi bir üçüncü taraf yazılımı gerektirmez.

### PPT'den PPTX'e dönüşüm için çevrimiçi bir araç var mı?
Evet, ücretsiz [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanarak kod yazmadan doğrudan tarayıcınızda dönüşüm yapabilirsiniz.