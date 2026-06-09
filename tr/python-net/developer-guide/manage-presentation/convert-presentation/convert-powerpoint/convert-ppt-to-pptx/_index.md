---
title: Python’da PPT'yi PPTX'e Dönüştürme
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/python-net/convert-ppt-to-pptx/
keywords:
- PPT'yi dönüştür
- PPT'den PPTX'e
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da eski PPT sunumlarını hızlı bir şekilde modern PPTX’e dönüştürün — net bir öğretici, ücretsiz kod örnekleri, Microsoft Office bağımlılığı yok."
---
## **Genel Bakış**

Bu makale, bir PowerPoint sunumunu PPT formatından Python kullanarak ve çevrimiçi bir PPT'den PPTX'e dönüştürme uygulaması ile PPTX formatına nasıl dönüştüreceğinizi açıklar. Aşağıdaki konu ele alınmaktadır:

- Python'da PPT'yi PPTX'e Dönüştür

## **Python ile PPT'yi PPTX'e Dönüştürme**

Python'da PPT'yi PPTX'e dönüştürmek için örnek kod aşağıdaki bölüme bakın, yani [Convert PPT to PPTX](#convert-ppt-to-pptx). Bu, PPT dosyasını yükler ve PPTX formatında kaydeder. Farklı kaydetme formatları belirterek PPT dosyasını PDF, XPS, ODP, HTML gibi birçok başka formata da kaydedebilirsiniz; ilgili makaleler:

- [Convert PPT to PDF in Python](/slides/tr/python-net/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in Python](/slides/tr/python-net/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in Python](/slides/tr/python-net/convert-powerpoint-to-html/)
- [Convert PPT to ODP in Python](/slides/tr/python-net/save-presentation/)
- [Convert PPT to PNG in Python](/slides/tr/python-net/convert-powerpoint-to-png/)

## **PPT'den PPTX'e Dönüştürme Hakkında**
Aspose.Slides API ile eski PPT formatını PPTX'e dönüştürün. Binlerce PPT sunumunu PPTX formatına dönüştürmeniz gerekiyorsa, en iyi çözüm bunu programlı olarak yapmaktır. Aspose.Slides API ile bunu sadece birkaç satır kodla gerçekleştirebilirsiniz. API, PPT sunumunu PPTX'e dönüştürmek için tam uyumluluk sağlar ve şu işlemler mümkündür:

- Master'lar, düzenler ve slaytların karmaşık yapılarını dönüştürün.
- Grafik içeren bir sunumu dönüştürün.
- Grup şekilleri, otomatik şekiller (örneğin dikdörtgen ve elipsler) ve özel geometriye sahip şekiller içeren bir sunumu dönüştürün.
- Otomatik şekiller için doku ve resim doldurma stillerine sahip bir sunumu dönüştürün.
- Yer tutucular, metin çerçeveleri ve metin tutucuları içeren bir sunumu dönüştürün.

{{% alert color="primary" %}}

Şu [**Aspose.Slides PPT'den PPTX'e Dönüştürme**](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) uygulamasına bir göz atın:

[](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx)

Bu uygulama **Aspose.Slides API** temelli olarak oluşturulmuştur, bu yüzden temel PPT'den PPTX'e dönüştürme yeteneklerinin canlı bir örneğini görebilirsiniz. Aspose.Slides Conversion, PPT formatında bir sunum dosyasını bırakıp PPTX'e dönüştürülmüş olarak indirmenizi sağlayan bir web uygulamasıdır.

Diğer canlı [**Aspose.Slides Dönüştürme**](https://products.aspose.app/slides/tr/conversion/) örneklerini bulun.
{{% /alert %}}

## **PPT'yi PPTX'e Dönüştürme**
PPT'yi PPTX'e dönüştürmek için, dosya adını ve kaydetme formatını [**Save**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) metoduna, [**Presentation**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının üzerinden geçirmeniz yeterlidir. Aşağıdaki Python kod örneği, varsayılan seçenekleri kullanarak bir sunumu PPT'den PPTX'e dönüştürür.

```python
import aspose.slides as slides

# Bir PPT dosyasını temsil eden Presentation nesnesini örnekleyin
pres = slides.Presentation("PPTtoPPTX.ppt")

# Sunumu PPTX formatında kaydedin
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[**PPT ve PPTX**](/slides/tr/python-net/ppt-vs-pptx/) sunum formatları ve [**Aspose.Slides'in PPT'den PPTX'e dönüşümünü nasıl desteklediği**](/slides/tr/python-net/convert-ppt-to-pptx/) hakkında daha fazla bilgi edinin.

## **SSS**

**PPT ve PPTX formatları arasındaki fark nedir?**

PPT, Microsoft PowerPoint tarafından kullanılan eski ikili dosya formatıdır, PPTX ise Microsoft Office 2007 ile tanıtılan yeni XML tabanlı formattır. PPTX dosyaları daha iyi performans, daha düşük dosya boyutu ve geliştirilmiş veri kurtarma sağlar.

**Python ile PPT'yi PPTX'e dönüştürebilir miyim?**

Evet, Aspose.Slides for Python via .NET kütüphanesini kullanarak bir PPT dosyasını kolayca yükleyebilir ve sadece birkaç satır kodla PPTX formatında kaydedebilirsiniz.

**Aspose.Slides birden fazla PPT dosyasının toplu olarak PPTX'e dönüştürülmesini destekliyor mu?**

Evet, Aspose.Slides'i bir döngü içinde kullanarak birden fazla PPT dosyasını programlı olarak PPTX'e dönüştürebilir ve toplu dönüşüm senaryoları için uygun hale getirebilirsiniz.

**Dönüştürme sonrasında içerik ve biçimlendirme korunur mu?**

Aspose.Slides, sunumları dönüştürürken yüksek doğruluk sağlar. Slayt düzenleri, animasyonlar, şekiller, grafikler ve diğer tasarım öğeleri PPT'den PPTX'e dönüşüm sırasında korunur.

**PPT dosyalarından PDF veya HTML gibi diğer formatlara dönüştürebilir miyim?**

Evet, Aspose.Slides, PPT dosyalarını PDF, XPS, HTML, ODP ve PNG, JPEG gibi görüntü formatları dahil olmak üzere birden çok formata dönüştürmeyi destekler.

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürmek mümkün mü?**

Evet, Aspose.Slides for Python via .NET bağımsız bir API'dir ve dönüşümü gerçekleştirmek için Microsoft PowerPoint ya da herhangi bir üçüncü taraf yazılımına ihtiyaç duymaz.

**PPT'den PPTX'e dönüşüm için çevrimiçi bir araç var mı?**

Evet, ücretsiz [Aspose.Slides PPT'den PPTX'e Dönüştürücü](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) web uygulamasını kullanarak kod yazmadan tarayıcınızda doğrudan dönüşüm yapabilirsiniz.