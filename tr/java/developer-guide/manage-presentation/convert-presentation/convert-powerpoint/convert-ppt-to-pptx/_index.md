---
title: Java’da PPT’yi PPTX’e Dönüştürme
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java’da eski PPT sunumlarını modern PPTX’e hızlıca dönüştürün — net öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPT formatından Java kullanarak ve çevrimiçi PPT'den PPTX'ye dönüşüm uygulaması ile PPTX formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır.

- Java ile PPT'yi PPTX'e dönüştürme

## **Java ile PPT'yi PPTX'e Dönüştürme**

Java için PPT'yi PPTX'e dönüştürmek üzere örnek kodu görmek istiyorsanız, aşağıdaki bölüme bakabilirsiniz: [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu sadece PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek, PPT dosyasını PDF, XPS, ODP, HTML gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi.

- [Java'da PPT'yi PDF'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-pdf/)
- [Java'da PPT'yi XPS'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-xps/)
- [Java'da PPT'yi HTML'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-html/)
- [Java'da PPT'yi ODP'ye Dönüştür](/slides/tr/java/save-presentation/)
- [Java'da PPT'yi PNG'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüşüm Hakkında**
Aspose.Slides API ile eski PPT formatını PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde sadece birkaç satır kodla bunu gerçekleştirebilirsiniz. API, PPT sunumlarını PPTX'e tam uyumlulukla dönüştürmeyi destekler ve aşağıdakileri yapmanıza olanak tanır:

- Karmaşık ana şablon, düzen ve slayt yapılarını dönüştürme.
- Grafik içeren sunumları dönüştürme.
- Grup şekilleri, otomatik şekiller (örneğin dikdörtgen ve elips), özel geometriye sahip şekiller içeren sunumları dönüştürme.
- Otomatik şekiller için doku ve resim doldurma stillerine sahip sunumları dönüştürme.
- Yer tutucular, metin çerçeveleri ve metin tutucuları içeren sunumları dönüştürme.

{{% alert color="primary" %}} 
Şuraya bir göz atın [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulamasına:
[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama, [**Aspose.Slides API**](https://products.aspose.com/slides/tr/java/) üzerine inşa edilmiştir, bu sayede temel PPT'den PPTX'e dönüşüm yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Conversion, PPT formatında sunum dosyasını sürükleyip bırakmanıza ve PPTX'e dönüştürülmüş olarak indirmenize olanak tanıyan bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'e Dönüştürme**
Aspose.Slides for Java artık geliştiricilerin [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıf örneğini kullanarak PPT'ye erişmesini ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesini sağlar. Şu anda, [PPT](https://docs.fileformat.com/presentation/ppt/) den PPTX'e kısmi dönüşümü desteklemektedir. PPT'den PPTX'e dönüşümde hangi özelliklerin desteklendiği ve desteklenmediği hakkında daha fazla bilgi için lütfen bu belgeler [link](/slides/tr/java/ppt-to-pptx-conversion/) sayfasına bakın.

Aspose.Slides for Java, **PPTX** sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfını sunar. Presentation sınıfı artık nesne oluşturulduğunda **PPT**'ye de erişebilir. Aşağıdaki örnek, bir PPT sunumunu PPTX Presentation'a nasıl dönüştüreceğinizi gösterir.

```java
// Bir PPTX dosyasını temsil eden Presentation nesnesi örnekleyin
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

Yukarıdaki kod parçacığı dönüşüm sonrası aşağıdaki PPTX sunumunu oluşturmuştur

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüşüm Sonrası Oluşturulan PPTX Sunumu**|

## **FAQ**

**PPT ve PPTX formatları arasındaki fark nedir?**

PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha küçük dosya boyutu ve geliştirilmiş veri kurtarma sağlar.

**Aspose.Slides birden çok PPT dosyasının toplu olarak PPTX'e dönüştürülmesini destekliyor mu?**

Evet, Aspose.Slides'ı bir döngü içinde kullanarak birden çok PPT dosyasını programlı olarak PPTX'e dönüştürebilirsiniz; bu, toplu dönüşüm senaryoları için uygundur.

**Dönüşüm sonrası içerik ve biçimlendirme korunur mu?**

Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

**PPT dosyalarından PDF veya HTML gibi diğer formatlara dönüştürebilir miyim?**

Evet, Aspose.Slides, PPT dosyalarını [birçok formata](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) dönüştürmeyi destekler; bunlar arasında PDF, XPS, HTML, ODP ve PNG, JPEG gibi görüntü formatları da vardır.

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?**

Evet, Aspose.Slides bağımsız bir API'dir ve dönüşümü gerçekleştirmek için Microsoft PowerPoint veya herhangi bir üçüncü taraf yazılımına ihtiyaç duymaz.

**PPT'den PPTX'e dönüşüm için çevrimiçi bir araç var mı?**

Evet, ücretsiz [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanarak dönüşümü doğrudan tarayıcınızda, herhangi bir kod yazmadan gerçekleştirebilirsiniz.