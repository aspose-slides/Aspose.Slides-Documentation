---
title: Python üzerinden Java ile PPT ve PPTX'i PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Python üzerinden Java ile PowerPoint PPT/PPTX'i yüksek kalitede, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüştürme seçenekleri ile."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Python aracılığıyla Java üzerinden PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ve biçimlendirmesini koruma gibi birçok avantaj sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, font ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'tan PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfına bir argüman olarak geçirin ve ardından sunumu [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemiyle PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini sunar.

{{% alert color="info" title="Not" %}}
Aspose.Slides for Python via Java, API bilgi ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application (Uygulama) alanını "*Aspose.Slides*" ve PDF Producer (PDF Üreticisi) alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** Aspose.Slides'ın bu bilgiyi çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF olarak dışa aktarır ve oluşan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart dönüşüm, varsayılan PDF dışa aktarma ayarlarını kullanır. Görüntü kalitesi, sayfa içeriği veya PDF uyumluluğunu kontrol etmeniz gerektiğinde özelleştirilmiş seçenekler kullanın.

Örnekleri çalıştırmadan önce [Aspose.Slides for Python via Java](/slides/tr/python-java/installation/) ve uyumlu bir Java çalışma zamanı kurun. Her örnek, geçerli çalışma dizinindeki `presentation.pptx` dosyasını okur; bunu kendi PPT, PPTX veya ODP dosyanızla değiştirin. JVM'yi Python süreci başına bir kez başlatın.

Bu kod bir sunumu PDF'ye dönüştürür:

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

{{% alert color="info" title="Not" %}}
Aspose, sunumdan PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint PDF Dönüştürücüsü**(https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Buradaki prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, oluşan PDF'yi özelleştirmenizi, PDF'yi bir şifreyle kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenizi sağlayan özel seçenekler—[PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfının özellikleri—sunar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini tanımlayabilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI'yi yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunu birkaç özel seçenekle PDF'ye nasıl dönüştüreceğinizi gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini kullanarak gizli slaytları oluşan PDF'de sayfa olarak dahil edebilirsiniz.

Bu kod, gizli slaytlar dahil edilerek bir PowerPoint sunumunun PDF'ye nasıl dönüştürüleceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint'i Şifre Koruması ile PDF'ye Dönüştür**

Bu kod, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Font İkamelerini Tespit Et**

Aspose.Slides, sunumdan PDF'ye dönüşüm sırasında font ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini sunar.

Java API'den uyarı geri aramalarını almak için bir JPype vekilini kullanın. Önekini kontrol etmeden önce Java açıklama dizesini bir Python dizesine dönüştürün:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Renderleme işlemi sırasında font ikameleri için geri arama alımı hakkında daha fazla bilgi için [Getting Warning Callbacks for Fonts Substitution](/slides/tr/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) sayfasına bakın.

Font ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/python-java/font-substitution/) makalesine bakın.
{{% /alert %}}

## **PowerPoint'te Seçilen Slaytları PDF'ye Dönüştür**

[Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine geçirilen slayt numaraları 1 tabanlıdır. Bu örnek, hem mevcut olduğunda 1 ve 3 numaralı slaytları dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **PowerPoint'i Özel Slayt Boyutuyla PDF'ye Dönüştür**

Bu örnek, ilk slaytı 612x792 puan (US Letter) ölçüsünde bir sayfaya dışa aktarır. Slaytı belirtilen boyutta yeni bir sunuma klonlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Bu kod, notları içeren bir PDF'ye PowerPoint sunumunun nasıl dönüştürüleceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Erişilebilir PDF'ler hazırlanırken, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) rehberine bakın. Çıktı standardını seçmek için [PdfOptions.setCompliance](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setCompliance) yöntemini kullanın: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden çok PDF üreten bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides karmaşık grafikleri (SmartArt, grafikler ve formüller gibi) tek bir figür olarak ele alır. Bireysel yol elementleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınız içinde döngü oluşturup dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Evet. Dönüşüm sırasında şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl dahil ederim?**

Gizli slaytları sonuç PDF'ye dahil etmek için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemleri kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi [çeşitli standartlar](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfcompliance/) uygun PDF'ler dışa aktarmanıza olanak tanır; erişilebilirlik veya arşivleme için uygun standartı seçin ve çıktıyı gereksinimlerinize göre inceleyin.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via Java Documentation](/slides/tr/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/tr/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)