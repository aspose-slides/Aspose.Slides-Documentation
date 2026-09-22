---
title: Python'da Sunumları Kaydet
linktitle: Sunumu Kaydet
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
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Python'da Aspose.Slides ile dosyalara veya akışlara kaydedin ve PPTX çıktı seçeneklerini yapılandırın."
---
## **Genel Bakış**

Bir sunum oluşturduktan veya [var olan bir sunumu açtıktan](/slides/tr/python-net/open-presentation/), sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) yöntemini kullanın. Aspose.Slides for Python via .NET, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosya ya da akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) yöntemine iletin. Format değeri, Aspose.Slides'ın oluşturduğu dosyanın türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve onu PPTX dosyası olarak kaydeder:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Sunum içeriğini buraya ekleyin veya değiştirin.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumları Orijinal Formatlarında Kaydet**

Dosya ve akış algılama örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için, [Orijinal Sunum Formatını Belirleme](/slides/tr/python-net/detect-presentation-source-format/) bölümüne bakın.

Toplu işleme uygulamasında, giriş formatı önceden bilinemeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [Presentation.source_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/source_format/) özelliğinden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sourceformat/) değerini [SlideUtil.to_save_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/to_save_format/) ile ilgili [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) değerine dönüştürün ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) yöntemini kullanarak değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, bir giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta bir çıktı dizinine kaydeder:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/to_save_format/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i ilgili sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF veya görüntüler gibi dışa aktarım formatlarını seçmek için tasarlanmamıştır. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sourceformat/) değeri geçirilirse bir istisna fırlatılır.

Eski PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt türleri korumanız gerekiyorsa, orijinal dosya adını veya format meta verisini ayrı olarak tutun ve çıktı dosya adı ve formatı seçerken kullanın.

## **Sunumları Akışa Kaydet**

Bir sunumu nihai bir dosya yoluna bağlı olmadan yazmak için, yazılabilir bir [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) akışı ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) yöntemine iletin. Bu yaklaşım, çıktının bir web hizmetinden döndürülmesi, bir veritabanına depolanması veya bellek içinde işlenmesi gerektiğinde kullanışlıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Önceden Tanımlı Görünüm Türü ile Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığında kullanılacak görünümü belirtebilirsiniz. Kaydetmeden önce [ViewProperties.last_view](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewproperties/last_view/) özelliğine bir [ViewType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/viewtype/) değeri atayın.

Aşağıdaki örnek Slayt Ana Sayfası görünümünü başlangıç görünümü olarak yapılandırır:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumları Katı Office Open XML Formatında Kaydet**

Katı Office Open XML profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/) örneği oluşturun ve bunun [conformance](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/conformance/) özelliğini `Conformance.ISO_29500_2008_STRICT` olarak ayarlayın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) yöntemine iletin.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Office Open XML Formatında Zip64 Modunda Sunumları Kaydet**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları, ilgili boyut ve giriş sayısı sınırlamalarını artırır.

[**PptxOptions.zip_64_mode**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) özelliğini kullanarak Aspose.Slides'ın ZIP64 uzantılarını yazıp yazmayacağını kontrol edebilirsiniz:

- `IF_NECESSARY` yalnızca sunum standart ZIP sınırlarını aştığında ZIP64 kullanır. Bu varsayılan moddur.
- `NEVER` ZIP64 uzantılarını devre dışı bırakır.
- `ALWAYS` her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için ZIP64 uzantılarını her zaman etkinleştirir:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode.NEVER` kullanılırsa ve sunum standart ZIP sınırları içinde yer alamazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Office Open XML Formatında Sıkıştırma Seviyeleri ile Sunumları Kaydet**

PPTX çıktısı için, [PptxOptions.compression_level](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/compression_level/) özelliğini ayarlayarak kaydetme hızını dosya boyutuyla dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/compressionlevel/) enum'ı şu değerleri sunar:

- `NONE` veriyi sıkıştırma olmadan depolar.
- `LEVEL1` en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- `LEVEL2`‑`LEVEL5` sıkıştırma seviyesini artırarak daha küçük çıktı üretir, ancak kaydetme hızı azalır.
- `LEVEL6` kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan seviyedir.
- `LEVEL7` ve `LEVEL8` daha çok küçük çıktıyı tercih eder.
- `LEVEL9` en güçlü sıkıştırmayı sağlar ancak en fazla işlem süresi gerektirir.

Aşağıdaki örnek sıkıştırma olmadan bir sunumu kaydeder:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Aşağıdaki örnek en yüksek sıkıştırma seviyesini kullanır:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) özelliği belge küçük resmini denetler:

- `True` kaydetme sırasında küçük resmi yeniden üretir. Bu varsayılan değerdir.
- `False` mevcut küçük resmi korur. Sunumda küçük resim yoksa Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek küçük resmi yenilemeden bir sunumu kaydeder:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemesini devre dışı bırakmak, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API'si ile oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Seçilen slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme”yi destekliyor mu?**

Hayır. Her kaydetme işlemi, yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği **istek başına güvenli değildir**. Her bir örneğe aynı anda yalnızca bir iş parçacığından erişip kaydedin.

**Bir sunumu kaydettiğimde köprüler ve harici bağlanan dosyalar ne olur?**

[Hyperlinks](/slides/tr/python-net/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlanan dosyaları kopyalamaz; bu nedenle kaydedilen sunum hâlâ bu dosyaların konumlarına erişebilmelidir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [belge özelliklerini](/slides/tr/python-net/presentation-properties/) ayarlayın; Aspose.Slides bunları çıktı dosyasına yazar.