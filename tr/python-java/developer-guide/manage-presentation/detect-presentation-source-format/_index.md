---
title: Python üzerinden Java ile Orijinal Sunum Biçimini Belirleme
linktitle: Kaynak Biçim
type: docs
weight: 35
url: /tr/python-java/detect-presentation-source-format/
keywords:
- kaynak biçim
- sunum biçimini tespit et
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile Python üzerinden Java kullanarak yüklenmiş bir sunumun orijinal biçimini okuyun, algılama API'lerini karşılaştırın ve dosyaları, akışları ve eski biçimleri yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, özgün biçimini belirlemek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) yöntemini çağırın. Mevcut örneğin yüklendiği biçime dayanarak sonraki işlem yapılacaksa bunu kullanın.

Kaynak biçim, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) biçiminden farklıdır. Başka bir biçime kaydetmek mevcut örneğin kaynak biçimini değiştirmez.

Örnekler, Java aracılığıyla Python için Aspose.Slides ve uyumlu bir Java çalışma zamanına ihtiyaç duyar. Her örnek, JVM zaten çalışmıyorsa başlatır.

## **Bir Dosyanın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pptx` dosyasına ihtiyaç duyar. Dosyayı yükler ve dosya adından ziyade [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) kullanarak bir uygulama işleme politikasını seçer. Başka biçimleri denemek için giriş yolunu değiştirin. Örnek seçilen politikayı yazdırır; mesajları uygulama mantığınızla değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) sınıfı, aşağıdaki sunum biçimlerini ayıran tamsayı sabitlerini tanımlar. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Biçim |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 sunumu |
| `Pptx` | `.pptx` | Office Open XML sunumu |
| `Pptm` | `.pptm` | Makro etkin Office Open XML sunumu |
| `Pps` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `Ppsx` | `.ppsx` | Office Open XML slayt gösterisi |
| `Ppsm` | `.ppsm` | Makro etkin Office Open XML slayt gösterisi |
| `Pot` | `.pot` | PowerPoint 97–2003 şablonu |
| `Potx` | `.potx` | Office Open XML şablonu |
| `Potm` | `.potm` | Makro etkin Office Open XML şablonu |
| `Odp` | `.odp` | OpenDocument sunumu |
| `Otp` | `.otp` | OpenDocument sunum şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pps` dosyasına ihtiyaç duyar. Baytlarını bir bellek akışına okumak, bir veritabanı değeri ya da yüklenen bayt dizisi gibi dosya adı olmadan alınan girdiyi modeller. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısı yalnızca akışı alır. Python dosya baytlarını okur ve JPype bunları Java bellek akışı için bir Java bayt dizisine dönüştürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS ve POT aynı temel ikili biçimi kullanır. Dosya yolu ile yüklenirken uzantı slayt gösterisini ya da şablonu ayırt etmeye yardımcı olabilir. Dosya adı olmadığında eski PPS ve POT içeriği `SourceFormat.Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `SourceFormat.Ppt` tamsayı değerini yazdırır.

Uygulamanız bu ayrımı korumak zorundaysa, özgün dosya adını ya da alt tür meta verisini ayrı tutun. Uzantı bu eski alt türler için yararlı bir ipucu olsa da, rastgele bir sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Tam sunum nesne modelini yüklemeden önce bir dosyayı incelemeniz gerektiğinde [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ve [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#getLoadFormat) kullanın. Örnek zaten mevcutsa [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) kullanın.

Bu örnek `sample.pptx` gerektirir ve sırasıyla `LoadFormat.Pptx` ve `SourceFormat.Pptx` tamsayı değerlerini yazdırır. Üretimde, işleme aşamanıza uygun API’yı seçin; zaten yüklenmiş bir sunumun kaynak biçimini elde etmek için ikinci bir inceleme gerekmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Sonuçlar farklı sınıflardan sabitler kullanır: [LoadFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/). Sayısal değerlerini karşılaştırmayın ve her biçimin aynı algılama sonuçlarına sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat.Unknown` ve yüklendikten sonra `SourceFormat.Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Biçimlerini Ayrı Tutun**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Orijinal örneği kaydetmeden önce ve sonra `SourceFormat.Pptx` tamsayı değerini yazdırır. Yalnızca ODP çıktısından yüklenen yeni örnek `Odp` raporlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

`Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat.Pptx` raporlar. Giriş dosyası yoktur: bu, yeni oluşturulmuş bir örnek için varsayılan değerdir, PPTX dosyasının yüklendiğine dair bir kanıt değildir. Bu ayrım önemliyse uygulamanızın örneği oluşturduğunu ya da yüklediğini ayrı olarak izleyin.

## **Bir Kaynak Biçimini Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Mevcut desteklenen her [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) değerini geleneksel bir uzantıya, giriş dosya adını ayrıştırmadan eşler. Yedekleme, tanınmayan bir değere sessizce bir uzantı atamaktan kaçınır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Bu eşleme bir dosyayı dönüştürmez ya da akış yüklemesi sırasında kaybolan eski bir PPS/POT alt türünü geri getirmez. Gerçek kaydetme için bir [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) seçin ya da [Orijinal Biçiminde Sunumları Kaydetme](/slides/tr/python-java/save-presentation/#save-presentations-in-their-original-format) bölümündeki dönüşümü kullanın.

## **Kaydetme ve Yeniden Açma ile Biçimleri Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar; aynı isimdeki dosyalar üzerine yazılır. Her çıktıyı hem yol ile hem de bellek akışı üzerinden yeniden açar. PPTX ve ODP için her iki yol da kaydedilen biçimi raporlar. PPS için yol ile yükleme `Pps` rapor ederken, aynı baytlar dosya adı olmadan yüklendiğinde `Ppt` rapor eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Aşağıdaki tablo, aynı uzantıya sahip sunumlar için kaynak‑biçim tanımlamasını özetler. İsimler sabitleri gösterir; Python örnekleri tamsayı değerlerini yazdırır:

| Kaydedilen biçim | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` sırasıyla | Dosya yoluyla aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` sırasıyla | Dosya yoluyla aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` sırasıyla | Dosya yoluyla aynı |
| ODP, OTP | `Odp`, `Otp` sırasıyla | Dosya yoluyla aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT içeriği, isimsiz akışlarda `Ppt` olarak tanımlanır. Tablo, format tanımlamasını açıklar; dönüşüm sırasında her sunum özelliğinin korunmasını garanti etmez.

## **SSS**

**PPTX'ten yüklü bir sunumu ODP olarak kaydetmek kaynak biçimini değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklü bir örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili biçimi paylaşır. Bu ayrım gerektiğinde dosya adını ya da alt tür meta verisini ayrı tutun.

**Sunum zaten yüklüyse hangi API'yi kullanmalıyım?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) metodunu okuyun. Yüklemeden önce inceleme için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın.