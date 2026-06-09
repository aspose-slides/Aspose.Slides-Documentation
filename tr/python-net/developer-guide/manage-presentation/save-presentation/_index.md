---
title: Python'da Sunumları Kaydet
linktitle: Sunumları Kaydet
type: docs
weight: 80
url: /tr/python-net/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- ön tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Open a Presentation in Python](/slides/tr/python-net/open-presentation/) sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıkladı. Bu makale, sunumların nasıl oluşturulup kaydedileceğini açıklar. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olsanız da, tamamladığınızda onu kaydetmek isteyeceksiniz. Aspose.Slides for Python ile bir **dosyaya** ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının `save` yöntemini çağırarak dosyaya kaydedin. Yönteme dosya adını ve kaydetme formatını geçin. Aşağıdaki örnek, Aspose.Slides for Python ile bir sunumu nasıl kaydedeceğinizi gösterir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    
    # Burada bazı işlemler yapın...

    # Sunumu bir dosyaya kaydedin.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumları Akışlara Kaydet**

Bir sunumu bir akışa kaydetmek için, çıktı akışını [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının `save` yöntemine aktarabilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturuyor, bir şekle metin ekliyoruz ve onu bir akışa kaydediyoruz.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Sunumu akışa kaydedin.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Ön Tanımlı Görünüm Türüyle Sunumları Kaydet**

Aspose.Slides for Python, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza olanak tanır. `last_view` özelliğini [ViewType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewtype/) sayımından bir değere ayarlayın.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenize izin verir. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/) sınıfını kullanın ve uyumluluk özelliğini ayarlayın. `Conformance.ISO_29500_2008_STRICT` ayarlarsanız, çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve onu Katı Office Open XML biçiminde kaydeder.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Presentation dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Bir Office Open XML dosyası, sıkıştırılmamış bir dosyanın 4 GB (2^32 bayt) limitini, sıkıştırılmış bir dosyanın boyutunu ve arşivin toplam boyutunu sınırlayan bir ZIP arşividir; ayrıca arşiv 65 535 (2^16‑1) dosyayla sınırlıdır. ZIP64 biçim uzantıları bu limitleri 2^64’e yükseltir.

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) özelliği, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu özellik aşağıdaki modları sunar:

- `IF_NECESSARY` yalnızca sunum yukarıdaki sınırlamaları aşarsa ZIP64 uzantılarını kullanır. Bu varsayılan moddur.
- `NEVER` ZIP64 uzantılarını asla kullanmaz.
- `ALWAYS` her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) özelliği, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `True` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `False` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiç biri oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanarak [ücretsiz PowerPoint Splitter uygulaması](https://products.aspose.app/slides/tr/splitter) geliştirdi. Uygulama, seçili slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) yalnızca değişikliklerin yazılması destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydet” desteklenmez.

**Aynı Presentation örneğini birden fazla thread'den kaydetmek thread‑safe midir?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/python-net/multithreading/); tek bir thread'den kaydedin.

**Kaydederken hiperlinkler ve harici bağlı dosyalar ne olur?**

[Hyperlinkler](/slides/tr/python-net/manage-hyperlinks/) korunur. Harici bağlı dosyalar (ör. göreceli yollarla videolar) otomatik olarak kopyalanmaz — referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp kaydedebilir miyim?**

Evet. Standart [document properties](/slides/tr/python-net/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.