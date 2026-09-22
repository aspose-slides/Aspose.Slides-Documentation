---
title: Python ile Java üzerinden Sunumları Kaydet
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
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java kullanarak PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Sunum oluşturduktan veya [var olan bir sunumu açtıktan](/slides/tr/python-java/open-presentation/) sonra, sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini kullanın. Aspose.Slides for Python via Java, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosya ya da akış olarak kaydedebilir. Aşağıdaki bölümler, standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için, çıkış yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine geçirin. Format değeri, Aspose.Slides’in oluşturacağı dosya türünü belirler.

Aşağıdaki örnek, bir sunum oluşturur ve bunu PPTX dosyası olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Sunum içeriğini burada ekleyin veya değiştirin.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunumları Orijinal Formatlarında Kaydet**

Dosya ve akış algılama örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için [Determine the Original Presentation Format](/slides/tr/python-java/detect-presentation-source-format/) bölümüne bakın.

Yığın işleme uygulamasında giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSourceFormat) yönteminden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) değerini [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#toSaveFormat) yöntemine geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini alın ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemiyle değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta çıktı dizinine kaydeder:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i ilgili sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF veya görüntüler gibi dışa aktarma formatlarını seçmek amacıyla kullanılmaz. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sourceformat/) değeri geçirilmesi, bir [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) ile sonuçlanır.

Eski PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum, dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt tiplerin korunması gerekiyorsa, orijinal dosya adını veya format meta verilerini ayrı tutun ve çıktı dosya adı ve formatı seçilirken kullanın.

## **Sunumları Akışlara Kaydet**

Sunumu nihai bir dosya yoluna bağlı olmadan yazmak için, yazılabilir bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine geçirin. Bu yöntem, çıktının bir web hizmetinden döndürülmesi, bir veritabanında saklanması veya bellekte işlenmesi gerektiğinde faydalıdır.

Aşağıdaki örnek, yeni bir sunumu dosya akışına kaydeder:

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

## **Önceden Tanımlı Görünüm Türü ile Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığı görünümü belirleyebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewtype/) değeriyle birlikte [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/python-java/aspose.slides/viewproperties/#setLastView) yöntemini kullanın.

Aşağıdaki örnek, Slide Master görünümünü başlangıç görünümü olarak yapılandırır:

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

## **Sunumları Katı Office Open XML Formatında Kaydet**

Office Open XML'in Strict profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/) örneği oluşturun ve [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) ile birlikte [setConformance](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setConformance) yöntemini kullanın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine geçirin.

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

## **Sunumları Office Open XML Formatında Zip64 Modunda Kaydet**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu limitleri aşabilir. ZIP64 uzantıları, ilgili boyut ve giriş sayısı limitlerini artırır.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setZip64Mode) yöntemini kullanarak Aspose.Slides'in ZIP64 uzantılarını yazıp yazmayacağını kontrol edin:

- [IfNecessary](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#IfNecessary) sadece sunum standart ZIP limitlerini aştığında ZIP64 kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Always) ZIP64 uzantılarını her zaman yazar.

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
Eğer [Zip64Mode.Never](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zip64mode/#Never) kullanılır ve sunum standart ZIP limitlerine sığmazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Formatında Sıkıştırma Düzeyleriyle Kaydet**

PPTX çıktısı için, [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setCompressionLevel) yöntemini kullanarak kaydetme hızını dosya boyutuyla dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/) sınıfı şu değerleri sağlar:

- [None](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#None) verileri sıkıştırma olmadan depolar.
- [Level1](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- [Level2](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level2) üzerinden [Level5](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level5) daha küçük çıktıyı kaydetme hızına tercih eder.
- [Level6](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level6) kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan düzeydir.
- [Level7](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level8) daha küçük çıktıyı kaydetme hızına daha fazla tercih eder.
- [Level9](https://reference.aspose.com/slides/tr/python-java/aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en çok işlem süresi gerektirir.

Aşağıdaki örnek, bir sunumu sıkıştırma olmadan kaydeder:

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

Aşağıdaki örnek, maksimum sıkıştırma seviyesini kullanır:

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

## **Sunumları Küçük Resmi Yenilemeden Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) yöntemi belge küçük resmini kontrol eder:

- `True` kaydetme işlemi sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `False` mevcut küçük resmi korur. Sunumda küçük resim yoksa, Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek, bir sunumu küçük resmini yenilemeden kaydeder:

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
Küçük resmi yenilemeyi devre dışı bırakmak, PPTX dosyasının kaydedilmesi için gereken süreyi azaltabilir.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Raporla**

Bir kaydetme işlemini izlemek için, `jpype.JProxy` aracılığıyla bir Python ilerleme işleyicisi kaydedin ve bunu [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setProgressCallback) yöntemine geçirin. Aspose.Slides daha sonra dışa aktarma sırasında ilerleme değerleriyle işleyicinin `reporting` yöntemini çağırır.

Aşağıdaki örnek, PDF dışa aktarımının ilerlemesini konsola raporlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

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
Aspose, Aspose.Slides API ile oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Bu araç, bir sunumdan seçili slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme” destekliyor mu?**

Hayır. Her kaydetme işlemi, yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Aynı Presentation örneği birden fazla iş parçacığı tarafından kaydedilebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/python-java/multithreading/). Her örneğe aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Bir sunumu kaydettiğimde hiperlinkler ve dışa bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/python-java/manage-hyperlinks/) sunumda kalır. Aspose.Slides dışa bağlı dosyaları kopyalamaz, bu yüzden kaydedilen sunum hâlâ bu dosyaların konumlarına erişebilmelidir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [document properties](/slides/tr/python-java/presentation-properties/) ayarlayın ve Aspose.Slides bunları çıktı dosyasına yazar.