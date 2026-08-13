---
title: Java'da PPT'yi PPTX'ye Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da eski PPT sunumlarını modern PPTX'e hızlıca dönüştürün — açık öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumu'nu PPT formatından Java kullanarak ve çevrimiçi PPT'den PPTX'ye dönüştürme uygulamasıyla PPTX formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmıştır.

- Java'da PPT'yi PPTX'ye Dönüştür

## **Java'da PPT'yi PPTX'ye Dönüştür**

Java örnek kodu için lütfen aşağıdaki bölüme bakın, yani [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu yalnızca PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek PPT dosyasını PDF, XPS, ODP, HTML gibi birçok başka formatta da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi.

- [Java'da PPT'yi PDF'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-pdf/)
- [Java'da PPT'yi XPS'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-xps/)
- [Java'da PPT'yi HTML'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-html/)
- [Java'da PPT'yi ODP'ye Dönüştür](/slides/tr/java/save-presentation/)
- [Java'da PPT'yi PNG'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-png/)

## **PPT'den PPTX'ye Dönüştürme Hakkında**
Eski PPT formatını Aspose.Slides API ile PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde sadece birkaç satır kodla bunu yapabilirsiniz. API, PPT sunumunu PPTX'e tam uyumlu şekilde dönüştürmeyi destekler ve aşağıdakileri yapmanıza olanak tanır:

- Master, layout ve slaytların karmaşık yapısını dönüştürme.
- Grafik içeren sunumları dönüştürme.
- Grup şekilleri, otomatik şekiller (dikdörtgen ve elips gibi), özel geometriye sahip şekilleri dönüştürme.
- Otomatik şekiller için doku ve resim dolgu stillerine sahip sunumları dönüştürme.
- Yer tutucular, metin çerçeveleri ve metin tutucular içeren sunumları dönüştürme.

{{% alert color="info" %}} 

Şuraya bir göz atın [**Aspose.Slides PPT'den PPTX'ye Dönüştürme**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulamasına:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama, [**Aspose.Slides API**](https://products.aspose.com/slides/tr/java/) temelli olarak oluşturulmuştur; bu sayede temel PPT'den PPTX'ye dönüşüm yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Conversion, PPT formatındaki sunum dosyasını sürükleyip bırakmanıza ve PPTX olarak indirmenize izin veren bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Conversion**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'ye Dönüştür**
Aspose.Slides for Java artık geliştiricilerin PPT'yi [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfı örneğiyle erişmesine ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesine olanak tanır. Şu anda, [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX kısmı dönüşümünü desteklemektedir. PPT'den PPTX'e dönüşümde hangi özelliklerin desteklendiği ve desteklenmediği hakkında daha fazla bilgi için lütfen bu [belge](/slides/tr/java/ppt-to-pptx-conversion/) sayfasına bakın.

Aspose.Slides for Java, **PPTX** sunum dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfını sunar. Presentation sınıfı, nesne oluşturulduğunda **PPT**'ye de erişebilir. Aşağıdaki örnek, bir PPT sunumunu PPTX Presentation'a nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

// Bir PPT dosyasını temsil eden Presentation nesnesini oluşturun
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPT sunumunu PPTX formatında kaydediyor
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Şekil : Kaynak PPT Sunumu**|

Yukarıdaki kod parçacığı dönüştürmeden sonra aşağıdaki PPTX sunumunu üretir

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüştürme Sonrası Oluşturulan PPTX Sunumu**|

## **SSS**

### PPT ve PPTX formatları arasındaki fark nedir?

PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha küçük dosya boyutu ve geliştirilmiş veri kurtarma sağlar.

### Aspose.Slides, birden çok PPT dosyasını PPTX'e toplu dönüştürmeyi destekliyor mu?

Evet, Aspose.Slides'ı bir döngü içinde kullanarak birden çok PPT dosyasını programlı bir şekilde PPTX'e dönüştürebilir, bu da toplu dönüşüm senaryoları için uygundur.

### Dönüştürme sonrasında içerik ve biçimlendirme korunur mu?

Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

### PPT dosyalarından PDF veya HTML gibi diğer formatlara dönüştürme yapabilir miyim?

Evet, Aspose.Slides, PDF, XPS, HTML, ODP ve PNG, JPEG gibi görüntü formatları dahil olmak üzere [çoklu formatlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/)a PPT dosyalarını dönüştürmeyi destekler.

### Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?

Evet, Aspose.Slides bağımsız bir API'dir ve dönüşüm işlemi için Microsoft PowerPoint veya üçüncü taraf bir yazılım gerektirmez.

### PPT'den PPTX'e dönüşüm için çevrimiçi bir araç var mı?

Evet, kod yazmadan doğrudan tarayıcınızda dönüşüm yapmanızı sağlayan ücretsiz [Aspose.Slides PPT'den PPTX'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanabilirsiniz.