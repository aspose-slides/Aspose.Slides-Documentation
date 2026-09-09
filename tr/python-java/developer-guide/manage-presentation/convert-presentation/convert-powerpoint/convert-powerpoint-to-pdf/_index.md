---
title: Python üzerinden Java ile PPT ve PPTX'i PDF'ye Dönüştürme [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- Sunumu dönüştür
- PowerPoint'ten PDF'ye
- Sunumu PDF'ye
- PPT'den PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'ten PDF'ye
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
description: "Aspose.Slides kullanarak Python üzerinden Java ile PowerPoint PPT/PPTX dosyalarını yüksek kalitede, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleri sunar."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Python üzerinden Java kullanarak PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uygunluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu PDF olarak [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı, bir sunumu PDF'ye dönüştürmek için genellikle kullanılan [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini sunar.

{{% alert color="info" title="Not" %}}
Aspose.Slides for Python via Java, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken Aspose.Slides, Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not**: Aspose.Slides'ın bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarırken, ortaya çıkan PDF'lerin orijinal sunumlara çok yakın olmasını sağlar. Dönüştürme sırasında aşağıdaki öğeler ve özellikler doğru şekilde işlenir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştürme**

Standart dönüşüm, varsayılan PDF dışa aktarma ayarlarını kullanır. Görüntü kalitesini, sayfa içeriğini veya PDF uyumluluğunu kontrol etmeniz gerektiğinde özel seçenekler kullanın.

Aşağıdaki örnekleri çalıştırmadan önce [Aspose.Slides for Python via Java](/slides/tr/python-java/installation/) ve uyumlu bir Java çalışma zamanı kurun. Her örnek, geçerli çalışma dizininden `presentation.pptx` dosyasını okur; bunu kendi PPT, PPTX veya ODP dosyanızla değiştirin. JVM'i Python süreci başına bir kez başlatın.

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
Aspose, sunum‑PDF dönüşüm sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint to PDF converter** (https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Buradaki prosedürü canlı olarak test edebilirsiniz.
{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştürme**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfı altında yer alan özel seçenekler sağlar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştürme**

Özel dönüşüm seçenekleriyle raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI değerini yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, birkaç özel seçenek kullanarak bir PowerPoint sunumunu PDF'ye dönüştürmeyi gösterir.

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

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştürme**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metodunu kullanabilirsiniz.

Bu kod, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'ye dönüştürmeyi gösterir:

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

### **Parola Korumalı PDF Oluşturma**

Aşağıdaki kod, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfının koruma parametrelerini kullanarak bir PowerPoint sunumunu parola korumalı PDF'ye dönüştürmeyi gösterir:

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

### **Yazı Tipi İkamelerini Algılama**

Aspose.Slides, sunum‑PDF dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [setWarningCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setWarningCallback) metodunu [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfı altında sunar.

Uyarı geri aramalarını Java API'den almak için bir JPype proxy'si kullanın. Java açıklama dizesini Python dizesine çevirerek önekini kontrol edin:

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
Oluşturma sırasında yazı tipi ikameleri için geri arama alımını daha ayrıntılı incelemek isterseniz, [Getting Warning Callbacks for Font Substitution](/slides/tr/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) bölümüne bakın.

Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/python-java/font-substitution/) makalesine göz atın.
{{% /alert %}}

## **Seçili Slaytları PowerPoint'ten PDF'ye Dönüştürme**

[Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine geçirilen slayt numaraları 1‑tabanlıdır. Aşağıdaki örnek, hem mevcut hem de mevcut olmayan durumlarda slayt 1 ve 3'ü dışa aktarır:

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

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştürme**

Bu örnek, 612 × 792 puan (US Letter) ölçülerinde bir sayfada ilk slaytı dışa aktarır. Belirtilen boyutta yeni bir sunuma slaytı klonlar:

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

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştürme**

Aşağıdaki kod, notları da içeren bir PDF oluşturmak için PowerPoint sunumunu nasıl dönüştüreceğinizi gösterir:

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

Erişilebilir PDF'ler hazırlarken, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) belgelerine bakın. Çıktı standardını seçmek için [PdfOptions.setCompliance](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setCompliance) yöntemini kullanın: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Aşağıdaki kod, farklı uyumluluk standartlarına göre birden çok PDF oluşturan bir PowerPoint‑PDF dönüşüm sürecini gösterir:

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

> **Not:** PDF/UA olarak dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık görselleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınız üzerinde döngü oluşturarak dönüşüm sürecini programmatically uygulayabilirsiniz.

**Dönüştürülen PDF'ye parola koruması ekleyebilir miyim?**

Evet. Dönüşüm sırasında bir parola ayarlamak ve erişim izinlerini belirlemek için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl dahil ederim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [setJpegQuality](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemlerle görüntü kalitesini kontrol ederek PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [various standards](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfcompliance/) ile uyumlu PDF'ler oluşturmanıza olanak tanır. İhtiyacınıza uygun standardı seçin ve çıktıyı gereksinimlerinize göre inceleyin.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via Java Documentation](/slides/tr/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/tr/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)