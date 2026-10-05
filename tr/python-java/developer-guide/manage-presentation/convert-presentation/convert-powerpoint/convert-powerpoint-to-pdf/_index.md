---
title: Python üzerinden Java ile PPT ve PPTX'i PDF'ye dönüştürün [Gelişmiş Özellikler Dahildir]
linktitle: PowerPoint'ten PDF
type: docs
weight: 40
url: /tr/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint PDF'ye
- sunumu PDF'ye
- PPT PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX PDF'ye
- PPTX'i PDF'ye dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye dışa aktar
- PPTX'i PDF'ye dışa aktar
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Python üzerinden Java ile PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Python üzerinden Java ile PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk, sunumunuzun düzen ve biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelere nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları eklemeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı göstermektedir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java, API bilgisi ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides, aşağıdakileri dönüştürmenize izin verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktararak elde edilen PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve özellikler doğru bir şekilde işlenir, örneğin:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştürme**

Standart dönüşüm, varsayılan PDF dışa aktarma ayarlarını kullanır. Görüntü kalitesi, sayfa içeriği veya PDF uyumluluğunu kontrol etmeniz gerektiğinde özel seçenekler kullanın.

[Aspose.Slides for Python via Java](/slides/tr/python-java/installation/) ve uyumlu bir Java çalışma zamanı kurarak örnekleri çalıştırın. Her örnek, geçerli çalışma dizinindeki `presentation.pptx` dosyasını okur; bunu kendi PPT, PPTX veya ODP dosyanızla değiştirin. JVM'yi Python işlemi başına bir kez başlatın.

Aşağıdaki örnek, bir sunumu yükler ve varsayılan dışa aktarma ayarlarıyla tüm görünür slaytları PDF olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Aspose, ücretsiz bir çevrimiçi [**PowerPoint'ten PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar; bu, burada açıklanan dönüşüm sürecinin canlı bir uygulamasını test etmenizi sağlar.

{{% /alert %}}

## **PowerPoint'ten PDF'ye Dönüştürme – Seçeneklerle**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfı altında bulunan özelleştirilebilir seçenekler—özellikler—sağlayarak oluşturulan PDF'yi özelleştirmenize, PDF'yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanır.

### **PowerPoint'ten PDF'ye Özelleştirilmiş Seçeneklerle Dönüştürme**

Özel dönüşüm seçenekleriyle raster görüntüler için tercih edilen kalite ayarını, metafile'ların nasıl işleneceğini, metin için sıkıştırma seviyesini, görüntüler için DPI ayarını ve daha fazlasını tanımlayabilirsiniz.

Aşağıdaki örnek, PDF 1.5 formatına JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması uygulanır şekilde bir sunumu dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Korumak**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının hem slaytları görüntüleyebilmesini hem de çalışma kitabının verilerine erişebilmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak tutmak için `[setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData)` yöntemini `True` olarak çağırın.

Varsayılan değer `False`'tur: OLE nesnesinin ön izleme görüntüsü veya simgesi PDF sayfasında render edilir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `True` olarak ayarlamak, dosya verilerini ayrıca ekler. Ön izleme görsel bir temsil olmaya devam eder; ek ise alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabını ek olarak tutarak PDF'ye dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Sonucu kontrol etmek için:

1. PDF'yi, ekleri destekleyen bir görüntüleyicide (ör. Adobe Acrobat Reader) açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Eki kaydedin ve verilerini incelemek için Excel'de açın veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme, ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}

PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 diğer dosya türlerine, Excel çalışma kitapları dahil, izin verir. Bu gereksinimler standartların kendisine aittir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.

{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'ten PDF'ye Dönüştürme**

Sunum gizli slaytlar içeriyorsa, [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfından çağırarak gizli slaytları sonuç PDF'de sayfa olarak ekleyebilirsiniz.

Aşağıdaki örnek, gizli slaytlar dahil olmak üzere bir sunumu PDF'ye dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Şifre Koruması Olan PDF'ye PowerPoint'ten Dönüştürme**

Aşağıdaki örnek, açmak için `password` şifresi gerekli olan bir PDF oluşturur. Erişim izinleri, yüksek kaliteli baskı dahil olmak üzere baskıya izin verir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Yazı Tipi İkamelerini Algılama**

Aspose.Slides, [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfı altında sağlayarak PDF dönüşümü sırasında oluşan yazı tipi ikamelerini algılamanızı sağlar.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve konsola yazı tipi ikamesi uyarılarını yazdırır. İkaz, dışa aktarma sırasında mevcut olmayan bir yazı tipi ikame edildiğinde yalnızca bir kez yazdırılır. Java API'sinden uyarı geri çağrıları almak için JPype proxy'si kullanın. Java açıklama dizesini Python dizesine dönüştürüp önekini kontrol edin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/python-java/font-substitution/) makalesine bakın.

{{% /alert %}}

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştürme**

[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yöntemine geçirilen slayt numaraları 1 tabanlıdır. Bu örnek, her iki slayt da mevcut olduğunda 1 ve 3 numaralı slaytları dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Özel Slayt Boyutuyla PowerPoint'ten PDF'ye Dönüştürme**

Bu örnek, 612 x 792 point (US Letter) ölçülerinde bir sayfada ilk slaytı dışa aktarır. Belirtilen boyutta yeni bir sunuma slaytı kopyalar ve slayt içeriğini sayfaya sığdırmak için ölçeklendirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Yeni oluşturulan sunumla birlikte gelen boş slaytı kaldır.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Not Slaytı Görünümünde PowerPoint'ten PDF'ye Dönüştürme**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Erişilebilir PDF'ler hazırlarken, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) yönergelerine bakın. Çıktı standardını seçmek için [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) yöntemini kullanın: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint‑PDF dönüşüm sürecini göstermektedir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızı döngüyle işleyerek dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle koruyabilir miyim?**

Evet. Dönüşüm sırasında şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfını kullanın.

**PDF'ye gizli slaytları nasıl ekleyebilirim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfında `[setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)` yöntemini `True` olarak çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemlerle [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfı içinde görüntü kalitesini yüksek tutabilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, [various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) arasında PDF/A1a, PDF/A1b ve PDF/UA gibi PDF/A uyumluluk standartlarına uygun PDF'ler dışa aktarmanıza olanak tanır. İhtiyacınıza uygun standardı seçin ve çıktıyı gereksinimlerinize göre gözden geçirin.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via Java Documentation](/slides/tr/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)