---
title: Python üzerinden Java ile Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/python-java/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunum kaydet
- slayt kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Sıkı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java kullanarak PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Bir sunum oluşturduktan veya [varolan bir sunumu aç](/slides/tr/python-java/open-presentation/) sonra, sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu kullanın. Aspose.Slides for Python via Java, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosya ya da akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna geçirin. Format değeri, Aspose.Slides'ın oluşturduğu dosya türünü belirler.

İşte bir sunum oluşturup PPTX dosyası olarak kaydeden örnek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Sunum içeriğini buraya ekleyin veya değiştirin.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunumları Orijinal Biçimlerinde Kaydet**

Bir toplu işleme uygulamasında giriş biçimi önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal biçimini [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) metodundan okuyun. Ortaya çıkan [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) değerini [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#toSaveFormat) metoduna geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini alın ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu kullanarak değiştirilmiş sunumu yazın.

Şu tam örnek, giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği biçimde çıktı dizinine kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i karşılık gelen sunum kaydetme biçimlerine eşler. Bu metod yalnızca sunum kaynak biçimlerini eşler; PDF, HTML, TIFF veya görüntüler gibi dışa aktarım biçimlerini seçmek için tasarlanmamıştır. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) değeri geçirilmesi bir [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) sonucunu verir.

Legacy PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt tipleri korumanız gerekiyorsa, orijinal dosya adını veya biçim meta verisini ayrı olarak tutun ve çıktı dosya adı ve biçimini seçerken kullanın.

## **Sunumları Akışa Kaydet**

Bir sunumu nihai dosya yoluna bağlı olmadan yazmak için, yazılabilir bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna geçirin. Bu yaklaşım, çıktının bir web hizmetinden döndürülmesi, veritabanında saklanması veya bellekte işlenmesi gerektiğinde kullanışlıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

Kaydedilen bir sunumun PowerPoint tarafından ilk açıldığında kullanılacak görünümünü belirtebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewtype/) değeriyle [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setLastView) metodunu kullanın.

Aşağıdaki örnek Slide Master görünümünü başlangıç görünümü olarak ayarlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunumları Sıkı Office Open XML Biçiminde Kaydet**

Office Open XML'in Strict profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/) örneği oluşturun ve onun [setConformance](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setConformance) metodunu [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) ile kullanın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna iletin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Standart ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlı tutar. PPTX bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları uygulanabilir boyut ve giriş sayısı limitlerini yükseltir.

[**setZip64Mode**](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setZip64Mode) metodunu kullanarak Aspose.Slides'ın ZIP64 uzantılarını yazıp yazmayacağını kontrol edebilirsiniz:

- [IfNecessary](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#IfNecessary) yalnızca sunum standart ZIP sınırlamalarını aşarsa ZIP64 kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için ZIP64 uzantılarını her zaman etkinleştirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Never) kullanılırsa ve sunum standart ZIP sınırlamalarına sığamazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxexception/) hatası fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Seviyeleriyle Kaydet**

PPTX çıktısı için, [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setCompressionLevel) metodunu kullanarak kaydetme hızını dosya boyutuna göre dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/) sınıfı şu değerleri sağlar:

- [None](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#None) sıkıştırma olmadan veri depolar.
- [Level1](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- [Level2](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level2) ile [Level5](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level5) giderek daha küçük çıktıyı, kaydetme hızından feragat eder.
- [Level6](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level6) kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan seviyedir.
- [Level7](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level8) daha küçük çıktıyı, kaydetme hızından daha çok tercih eder.
- [Level9](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en çok işlem süresi gerektirir.

Aşağıdaki örnek sıkıştırma olmadan bir sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Aşağıdaki örnek maksimum sıkıştırma seviyesini kullanır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

PPTX çıktısı kaydedildiğinde, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metodu belge küçük resmini kontrol eder:

- `True` kaydetme sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `False` mevcut küçük resmi korur. Sunumda küçük resim yoksa Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek küçük resmi yenilemeden bir sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemesinin devre dışı bırakılması, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Güncelle**

Kaydetme işlemini izlemek için `jpype.JProxy` aracılığıyla bir Python ilerleme işleyicisi kaydedin ve bunu [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setProgressCallback) metoduna iletin. Aspose.Slides, dışa aktarma sırasında ilerleme değerleriyle işleyicinin `reporting` metodunu çağırır.

Aşağıdaki örnek PDF dışa aktarmasının ilerlemesini konsola raporlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API'siyle oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Bu araç, bir sunumdan seçili slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme”yi destekliyor mu?**  
Hayır. Her kaydetme işlemi, yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı Presentation örneğini kaydedebilir mi?**  
Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/python-java/multithreading/). Her örneğe yalnızca bir iş parçacığından erişin ve kaydedin.

**Sunumu kaydettiğimde bağlantılar ve harici bağlanan dosyalar ne olur?**  
[Hyperlinks](/slides/tr/python-java/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlanan dosyaları kopyalamaz, bu yüzden kaydedilen sunum hâlâ bu konumlara erişebilmelidir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge meta verilerini kaydedebilir miyim?**  
Evet. Uygun [document properties](/slides/tr/python-java/presentation-properties/) ayarlayın ve Aspose.Slides bunları çıktı dosyasına yazar.