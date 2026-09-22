---
title: Python'da Orijinal Sunum Formatını Belirleme
linktitle: Kaynak Format
type: docs
weight: 35
url: /tr/python-net/detect-presentation-source-format/
keywords:
- kaynak format
- sunum formatını algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile yüklü bir sunumun orijinal formatını okuyun, algılama API'lerini karşılaştırın ve dosyaları, akışları ve eski formatları yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal formatını belirlemek için yalnızca okunan [Presentation.source_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/source_format/) özelliğini okuyun. Gelecek işlem mevcut örneğin yüklendiği formata bağlı olduğunda bunu kullanın.

Kaynak format, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) formatından farklıdır. Başka bir formata kaydetmek, mevcut örneğin kaynak formatını değiştirmez.

## **Bir Dosyanın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adını kullanmak yerine [Presentation.source_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/source_format/) ile bir uygulama işleme politikasını seçer. Diğer formatları denemek için girdi yolunu değiştirin. Örnek seçilen politikayı yazdırır; mesajları uygulama mantığınızla değiştirin.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sourceformat/) sayımı aşağıdaki sunum formatlarını ayırır. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 sunumu |
| `PPTX` | `.pptx` | Office Open XML sunumu |
| `PPTM` | `.pptm` | Makro etkin Office Open XML sunumu |
| `PPS` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `PPSX` | `.ppsx` | Office Open XML slayt gösterisi |
| `PPSM` | `.ppsm` | Makro etkin Office Open XML slayt gösterisi |
| `POT` | `.pot` | PowerPoint 97–2003 şablonu |
| `POTX` | `.potx` | Office Open XML şablonu |
| `POTM` | `.potm` | Makro etkin Office Open XML şablonu |
| `ODP` | `.odp` | OpenDocument sunumu |
| `OTP` | `.otp` | OpenDocument sunum şablonu |
| `FODP` | `.fodp` | Düz XML ODF sunumu |
| `XML` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okuyarak, bir veritabanı değeri veya yüklenen bayt dizisi gibi dosya adı olmadan alınan girdi modellemesi yapılır. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yapıcı yalnızca akışı alır.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS ve POT aynı temel ikili formatı kullanır. Dosya yolu ile yüklenirken, uzantı slayt gösterisi veya şablon ayrımında yardımcı olabilir. Dosya adı olmadan, eski PPS ve POT içeriği `SourceFormat.PPT` olarak raporlanabilir; yukarıdaki PPS örneği `PPT` rapor eder.

Uygulamanız bu ayrımı korumalıysa, orijinal dosya adını veya alt tip meta verilerini ayrı olarak saklayın. Bir uzantı bu eski alt tipler için yararlı bir ipucu olsa da, rastgele sunum içeriğini tanımlamak için tek temel olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Tam sunum nesne modelini yüklemeden önce bir dosyayı incelemeniz gerektiğinde [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) ve [PresentationInfo.load_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/load_format/) kullanın. Örneklendirme zaten mevcut olduğunda [Presentation.source_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/source_format/) kullanın.

Bu örnek `sample.pptx` gerektirir ve her iki kontrol için de `PPTX` yazdırır. Üretim ortamında, işleme aşamanıza uygun API'yi seçin; zaten yüklü bir sunumun kaynak formatını elde etmek için ikinci bir denetim gerekmez.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Sonuçlar farklı sayım türlerine sahiptir: [LoadFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sourceformat/). Sayısal değerlerini dökerek karşılaştırmayın veya her formatın aynı algılama sonuçlarına sahip olduğunu varsaymayın. Aşağıda açıklanan kaydet-ve-yeniden-aç kontrolünde, PowerPoint XML yüklenmeden önce `LoadFormat.UNKNOWN`, yüklendikten sonra `SourceFormat.XML` olarak raporlanmıştır.

## **Kaynak ve Çıktı Formatlarını Ayrı Tutma**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Orijinal örneği kaydetmeden önce ve sonra `PPTX` yazdırır. Sadece ODP çıktısından yüklenen yeni örnek `ODP` rapor eder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

`slides.Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat.PPTX` rapor eder. Girdi dosyası yoktur: bu yeni oluşturulan bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Bu ayrım önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Formatını Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Girdi dosya adı ayrıştırılmadan, şu anda desteklenen her [SourceFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sourceformat/) değerini geleneksel bir uzantıya eşler. Geri dönüş, tanınmayan bir değere sessizce uzantı atamayı önler.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Bu eşleme bir dosyayı dönüştürmez veya akış yüklemesi sırasında kaybolan eski PPS/POT alt tipini geri getirmez. Gerçek kaydetme için, bir [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) açıkça seçin veya [Sunuları Orijinal Formatında Kaydetme](/slides/tr/python-net/save-presentation/#save-presentations-in-their-original-format) bölümünde gösterilen dönüşümü kullanın.

## **Kaydedip Yeniden Açarak Formatları Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde aynı adlara sahip dosyaları üzerine yazarak üç dosya yazar. Her çıktıyı hem dosya yolu hem de bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen formatı rapor eder. PPS için, dosya yolu ile yükleme `PPS` rapor ederken, aynı baytları dosya adı olmadan yükleme `PPT` rapor eder.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Yukarıda listelenen tüm formatlarla yapılan aynı kontrol, eşleşen uzantılara sahip oluşturulan sunumlar için şu sonuçları verdi:

| Kaydedilen format | Dosya yolundan SourceFormat | Adsız akıştan SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` sırasıyla | Dosya yoluyla aynı |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` sırasıyla | Dosya yoluyla aynı |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` sırasıyla | Dosya yoluyla aynı |
| ODP, OTP | `ODP`, `OTP` sırasıyla | Dosya yoluyla aynı |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Bu kontrollerde, adsız akışlar için tek kaynak-format normalleştirmesi PPS/POT'un `PPT` olarak raporlanmasıdır. Tablo format tanımlamasını açıklar, dönüşüm sırasında her sunum özelliğinin korunmasını değil.

## **SSS**

**PPTX'ten yüklü bir sunumu ODP olarak kaydetmek, kaynak formatını değiştirir mi?**

Hayır. Mevcut örnek hâlâ `PPTX` rapor eder. Kaydedilen ODP dosyasından yüklenen bir örnek `ODP` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT ikili formatı paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tip meta verilerini ayrı tutun.

**Sunum zaten yüklüyse hangi API'yi kullanmalıyım?**

[Presentation.source_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/source_format/) okuyun. Yüklemeden önce inceleme için [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanın.