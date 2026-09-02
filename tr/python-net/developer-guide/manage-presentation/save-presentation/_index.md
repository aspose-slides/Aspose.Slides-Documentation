---
title: Python'da Sunumları Kaydetme
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
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm tipi
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da sunumları nasıl kaydedeceğinizi keşfedin—PowerPoint veya OpenDocument olarak dışa aktarırken düzenleri, yazı tiplerini ve efektleri koruyun."
---
## **Genel Bakış**

[Python'da Bir Sunumu Aç](/slides/tr/python-net/open-presentation/) kısmı, bir sunumu açmak için **Presentation**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklamaktadır. Bu makale, sunumların nasıl oluşturulacağını ve kaydedileceğini anlatır. **Presentation** sınıfı, bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde kaydetmek isteyeceksiniz. Aspose.Slides for Python ile bir **dosya**ya ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydetme**

Bir sunumu, **Presentation**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının `save` metodunu çağırarak dosyaya kaydedin. Metoda dosya adı ve kaydetme formatını iletin. Aşağıdaki örnek, Aspose.Slides for Python ile bir sunumun nasıl kaydedileceğini gösterir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    
    # Burada bazı işlemler yap...

    # Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumları Akışlara Kaydetme**

`save` metoduna bir çıktı akışı geçirerek bir sunumu akışa kaydedebilirsiniz. Bir sunum, birçok akış tipine yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup onu bir dosya akışına kaydediyoruz.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Sunumu akışa kaydet.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Önceden Tanımlı Görünüm Tipiyle Sunumları Kaydetme**

Aspose.Slides for Python, oluşturulan sunum açıldığında PowerPoint’in kullandığı ilk görünümü **ViewProperties**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. `last_view` özelliğini **ViewType**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewtype/) sayılımından bir değerle ayarlayın.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Katı Office Open XML Biçiminde Sunumları Kaydetme**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken **PptxOptions**(https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/) sınıfını kullanın ve `conformance` özelliğini ayarlayın. `Conformance.ISO_29500_2008_STRICT` ayarlanırsa çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve onu Katı Office Open XML biçiminde kaydeder.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # Sunumu Katı Office Open XML biçiminde kaydet.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ZIP64 Modunda Office Open XML Biçiminde Sunumları Kaydetme**

Office Open XML dosyası, sıkıştırılmamış dosya boyutu, sıkıştırılmış dosya boyutu ve arşiv toplam boyutu için 4 GB (2^32 bayt) ve 65 535 (2^16‑1) dosya sınırları getiren bir ZIP arşividir. ZIP64 biçim uzantıları bu sınırları 2^64’e çıkarır.

**PptxOptions.zip_64_mode**(https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) özelliği, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarını ne zaman kullanacağınıza karar verir.

Bu özellik aşağıdaki modları sunar:

- `IF_NECESSARY` sunum yukarıdaki sınırlamaları aşıyorsa ZIP64 uzantılarını kullanır. Varsayılan moddur.
- `NEVER` ZIP64 uzantılarını asla kullanmaz.
- `ALWAYS` her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER` ile kaydederseniz, sunum ZIP32 biçiminde kaydedilemezse bir **PptxException**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Sıkıştırma Seviyeleriyle Office Open XML Biçiminde Sunumları Kaydetme**

Büyük sunumlarla çalışırken dosya boyutu ve işlem süresi dengesini ayarlamak için sıkıştırma seviyesini değiştirebilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işlem ya da daha küçük dosya tercih edebilirsiniz.

Aspose.Slides, Office Open XML biçiminde kaydederken kullanılacak sıkıştırma seviyesini belirtmenizi sağlayan **PptxOptions.compression_level**(https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/compression_level/) özelliğini sunar.

Mevcut sıkıştırma seviyeleri:

- [**NONE**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): Sıkıştırma uygulanmaz. Dosyalar olduğu gibi depolanır.
- [**LEVEL1**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): En düşük sıkıştırma oranı ile en hızlı sıkıştırma.
- [**LEVEL2**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL1**’e göre biraz daha iyi sıkıştırma oranı, hâlâ hızlı.
- [**LEVEL3**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL2**’ye göre daha iyi sıkıştırma, işlem süresinde orta derecede etki.
- [**LEVEL4**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL3**’ten daha iyi sıkıştırma.
- [**LEVEL5**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL4**’e ek işlem süresi karşılığında geliştirilmiş sıkıştırma.
- [**LEVEL6**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): İşlem hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. *Varsayılan sıkıştırma seviyesidir*.
- [**LEVEL7**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL6**’dan daha iyi sıkıştırma, ancak daha yavaş işlem.
- [**LEVEL8**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): **LEVEL7**’den daha iyi sıkıştırma.
- [**LEVEL9**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/): Maksimum sıkıştırma. En uzun işlem süresi karşılığında en küçük dosya boyutunu üretir.

Aşağıdaki örnek, bir sunumu *sıkıştırma olmadan* PPTX dosyası olarak kaydetmeyi gösterir:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Bu örnek ise bir sunumu *maksimum sıkıştırma* ile PPTX dosyası olarak kaydetmeyi gösterir:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Küçük Resmi Yenilemeden Sunumları Kaydetme**

**PptxOptions.refresh_thumbnail**(https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) özelliği, PPTX olarak kaydederken küçük resim oluşturulmasını denetler:

- `True` ise kaydetme sırasında küçük resim yenilenir. Varsayılan davranıştır.
- `False` ise mevcut küçük resim korunur. Sunumda küçük resim yoksa hiç oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilenmeden PPTX olarak kaydeder.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose, kendi API’si kullanılarak geliştirilmiş bir [ücretsiz PowerPoint Bölücü uygulaması](https://products.aspose.app/slides/tr/splitter) sunmaktadır. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydetme” (artımlı kaydetme) sadece değişiklikler yazılacak şekilde destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden çok iş parçacığından kaydetmek güvenli mi?**

Hayır. **Presentation**(https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/python-net/multithreading/); tek bir iş parçacığından kaydedilmelidir.

**Kaydederken köprüler ve harici bağlı dosyalar ne olur?**

[Hyperlinkler](/slides/tr/python-net/manage-hyperlinks/) korunur. Harici bağlı dosyalar (ör. göreceli yollarla eklenmiş videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/python-net/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.