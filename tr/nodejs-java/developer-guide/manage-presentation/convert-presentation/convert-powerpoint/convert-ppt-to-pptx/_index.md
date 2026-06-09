---
title: "JavaScript'te PPT'yi PPTX'e Dönüştür"
linktitle: "PPT'den PPTX'e"
type: docs
weight: 20
url: /tr/nodejs-java/convert-ppt-to-pptx/
keywords:
- "PowerPoint'ı dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT'yi dönüştür"
- "PPT'den PPTX'e"
- "PPT'yi PPTX olarak kaydet"
- "PPT'yi PPTX'e aktar"
- "PowerPoint"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js ile eski PPT sunumlarını modern PPTX'e hızlıca dönüştürün — net öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, PowerPoint Sunumunu PPT formatından PPTX formatına JavaScript kullanarak ve çevrimiçi PPT‑den PPTX‑e dönüştürme uygulamasıyla nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır.

- JavaScript'te PPT'den PPTX'e Dönüştürme

## **Java PPT'yi PPTX'e Dönüştürme**

PPT'yi PPTX'e dönüştüren JavaScript örnek kodu için lütfen aşağıdaki bölüme bakın; ör. [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu sadece PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek PPT dosyasını PDF, XPS, ODP, HTML gibi birçok başka formata da kaydedebilirsiniz; bu makalelerde tartışıldığı gibi.

- [JavaScript'te PPT'yi PDF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript'te PPT'yi XPS'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript'te PPT'yi HTML'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript'te PPT'yi ODP'e Dönüştür](/slides/tr/nodejs-java/save-presentation/)
- [JavaScript'te PPT'yi PNG'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüştürme Hakkında**

Eski PPT formatını Aspose.Slides API ile PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API sayesinde sadece birkaç satır kodla bunu gerçekleştirebilirsiniz. API, PPT sunumlarını PPTX'e tam uyumlulukla dönüştürmeyi destekler ve aşağıdakileri yapmanıza olanak tanır:

- Karmaşık ana şablon, düzen ve slayt yapıları dönüştürün.
- Grafik içeren sunumları dönüştürün.
- Grup şekilleri, otomatik şekiller (örneğin dikdörtgen ve elips), özel geometrili şekiller içeren sunumları dönüştürün.
- Otomatik şekiller için doku ve resim dolgu stillerine sahip sunumları dönüştürün.
- Yer tutucular, metin çerçeveleri ve metin tutucular içeren sunumları dönüştürün.

{{% alert color="primary" %}} 

Şuna bir göz atın [**Aspose.Slides PPT'den PPTX'e Dönüştürme**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulamasına:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama, [**Aspose.Slides API**](https://products.aspose.com/slides/tr/nodejs-java/) temel alınarak oluşturulmuştur; böylece temel PPT'den PPTX'e dönüştürme yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Dönüştürme, PPT formatındaki sunum dosyasını bırakmanıza ve PPTX'e dönüştürülmüş olarak indirmenize olanak tanıyan bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Dönüştürme**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}} 

## **PPT'yi PPTX'e Dönüştürme**
Aspose.Slides for Node.js via Java artık geliştiricilerin PPT'yi [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı örneğiyle erişmesine ve bunu ilgili [PPTX](https://docs.fileformat.com/presentation/pptx/) formatına dönüştürmesine olanak tanır. Şu anda, [PPT ](https://docs.fileformat.com/presentation/ppt/)den PPTX'e kısmi dönüşüm desteklenmektedir.

Aspose.Slides for Node.js via Java, **PPTX** sunum dosyasını temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı sunar. Presentation sınıfı, nesne örneklenirken artık **PPT**'ye de erişebilir. Aşağıdaki örnek, bir PPT sunumunu PPTX sunumuna nasıl dönüştüreceğinizi gösterir.

```javascript
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturun
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // PPTX sunumunu PPTX formatında kaydediyor
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Şekil : Kaynak PPT Sunumu**|

Yukarıdaki kod parçacığı dönüştürmeden sonra aşağıdaki PPTX sunumunu oluşturdı

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Şekil: Dönüştürme Sonrası Oluşturulan PPTX Sunumu**|

## **FAQ**

**PPT ve PPTX formatları arasındaki fark nedir?**

PPT, Microsoft PowerPoint tarafından kullanılan daha eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan daha yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha küçük dosya boyutu ve geliştirilmiş veri kurtarma sağlar.

**Aspose.Slides birden fazla PPT dosyasını PPTX'e toplu dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides'i bir döngü içinde kullanarak birden fazla PPT dosyasını programlı olarak PPTX'e dönüştürebilirsiniz; bu, toplu dönüşüm senaryoları için uygundur.

**Dönüştürmeden sonra içerik ve biçimlendirme korunacak mı?**

Aspose.Slides, sunumları yüksek doğrulukla dönüştürür. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

**PPT dosyalarından PDF veya HTML gibi başka formatlara dönüştürebilir miyim?**

Evet, Aspose.Slides, PPT dosyalarını PDF, XPS, HTML, ODP ve PNG ile JPEG gibi görüntü formatları dahil olmak üzere çeşitli formatlara dönüştürmeyi destekler.

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?**

Evet, Aspose.Slides bağımsız bir API'dir ve dönüşüm gerçekleştirmek için Microsoft PowerPoint veya herhangi bir üçüncü taraf yazılımına ihtiyaç duymaz.

**PPT'den PPTX'e dönüşüm için çevrimiçi bir araç var mı?**

Evet, ücretsiz [Aspose.Slides PPT'den PPTX'e Dönüştürücü](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanarak kod yazmadan tarayıcınızda doğrudan dönüşümü yapabilirsiniz.