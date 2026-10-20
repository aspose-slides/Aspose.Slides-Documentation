---
title: Python üzerinden Java ile PPT ve PPTX'i PDF'ye dönüştürün [Gelişmiş Özellikler Dahildir]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- PPT'den PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'ten PDF'ye
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
description: "Aspose.Slides kullanarak Python üzerinden Java ile PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) Python üzerinden Java ile PDF formatına dönüştürmek, çeşitli avantajlar sunar; farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları eklemeyi, PDF dosalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides'ı kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfına bir argüman olarak geçirip, sonrasında sunumu [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yöntemi ile PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** Aspose.Slides'in bu bilgileri çıktı belgelerinden değiştirmenize veya kaldırmanıza izin vermediğini unutmayın.
{{% /alert %}}

Aspose.Slides size şunları dönüştürme imkanı verir:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlara yakın olmasını sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart dönüşüm,varsayılan PDF dışa aktarma ayarlarını kullanır. Görüntü kalitesini, sayfa içeriğini veya PDF uyumluluğunu kontrol etmeniz gerektiğinde özel seçenekler kullanın.

Aşağıdaki örnek, bir sunumu yükler ve tüm görünen slaytları varsayılan dışa aktarma ayarlarıyla PDF'ye kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan, [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI'yi yapılandırabilir ve daha fazlasını yapabilirsiniz.

İşte aşağıdaki örnek, bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması kullanılır.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpade.JByte(90))
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

### **Görüntü Sıkıştırmasını Otomatik Olarak Seç**

Bir sunumda birçok fotoğraf veya ekran görüntüsü bulunduğunda, dışa aktarılan PDF'nin boyutunu azaltmak e-posta göndermeyi veya indirmeyi kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) yöntemini `True` ile çağırın.

Aşağıdaki örnek, mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve bir PDF belgesi olarak kaydeder. Diğer tüm PDF dışa aktarma ayarları varsayılan değerlerini korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Bu seçenek her görüntü için bir sıkıştırma algoritması seçer. [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) yöntemine geçirilen değeri azaltmak JPEG görüntü kalitesini düşürür, [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) yöntemine geçirilen değeri azaltmak ise görüntülerin daha düşük çözünürlüğe düşürülmesini sağlar ve detay kaybına yol açabilir. Otomatik sıkıştırma seçimini etkinleştirmek, bu ayarların kendisini düşürmez.

Görüntü sıkıştırma algoritmalarını seçmek ek işlem süresi ve bellek gerektirir. Boyut azalması, sunumun görüntülerine ve dışa aktarma ayarlarına bağlıdır; her sunum için sabit bir azalma garantilenmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Biri gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve aynı zamanda slaytları görüntülemesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) yöntemini `True` ile çağırın.

Varsayılan değer `False`'tır: OLE nesnesinin ön izleme görüntüsü veya simgesi PDF sayfasına işlenir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `True` olarak ayarlamak, dosya verilerini ek olarak ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açmasına veya kaydetmesine olanak tanır. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, gömülü bir Excel çalışma kitabı zaten içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılan PDF'yi açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme, eklentiyle ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereksinimleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmayı göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfalar olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfından [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini kullanabilirsiniz.

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve gizli slaytları da içerir.

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

### **Şifre Korumalı PDF Olarak PowerPoint'i Dönüştür**

İşte aşağıdaki örnek, bir sunumu açmak için `password` şifresi gereken bir PDF'ye dışa aktarır. Erişim izinleri, yüksek kaliteli baskı da dahil olmak üzere yazdırmaya izin verir.

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

### **Yazı Tipi İkame Tespiti**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini sunar.

İşte aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır ve konsola yazı tipi ikame uyarılarını yazdırır. Uyarı yalnızca kullanılabilir olmayan bir yazı tipi dışa aktarma sırasında ikame edildiğinde yazdırılır. Java API'sinden uyarı geri aramalarını almak için bir JPype proxy'si kullanın. Başlığını kontrol etmeden önce Java açıklama dizesini Python dizesine dönüştürün:

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
Yazı tipi ikameleri hakkında daha fazla bilgi için, [Yazı Tipi İkamesi](/slides/tr/python-java/font-substitution/) makalesine bakın.
{{% /alert %}}

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşleme**

Bir sunum, yazı tipinin ayrı bir kalın tipine sahip olmaması durumunda da metne kalın biçimlendirme uygulayabilir. Metin, düzenli glifleri yapay olarak kalınlaştıran sentetik kalınlaştırma ile hâlâ kalın görünebilir. Bu metin PDF'de çok ağır göründüğünde veya istenen görünümden farklı olduğunda, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) yöntemini `True` ile çağırmayı deneyin. Bu seçenek, etkilenen metni PDF dışa aktarımı sırasında bir bitmap olarak işler ve belirli yazı tiplerinin görünümünü iyileştirebilir. Varsayılan değeri `False`'tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı yazı tipine uygulanan kalın biçimlendirmeye sahiptir ancak ayrı bir kalın tipine sahip değildir. Aşağıdaki örnek, sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

İşte aşağıdaki önizlemeler, devre dışı bırakılmış ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışı bırakıldığında kalın metnin çizgileri daha kalın olur. Seçenek etkinleştirildiğinde, çizgileri daha hafif olur; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`False`, varsayılan) | Seçenek etkin (`True`) |
|---|---|
| ![Desteklenmeyen font stili rasterleştirme devre dışı](unsupported-bold-disabled.png) | ![Desteklenmeyen font stili rasterleştirme etkin](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bir bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı bırakıldığında, her iki dize de metin olarak kalır.

Bu seçenek, yazı tipinin ayrı bir kalın tipine sahip olmadığı durumlarda kalın olarak biçimlendirilmiş metni rasterleştirir. [Yazı Tipi İkamesi](/slides/tr/python-java/font-substitution/) ise orijinal mevcut olmadığında başka bir yazı tipi seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metoduna iletilen slayt numaraları 1 tabanlıdır. Bu örnek, hem mevcut olduğunda 1 ve 3 numaralı slaytları dışa aktarır:

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

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştür**

Bu örnek, ilk slaytı 612x792 puan ölçüsünde (US Letter) bir sayfaya dışa aktarır. Slaytı belirtilen boyuta sahip yeni bir sunuma klonlar ve slayt içeriğini sığacak şekilde ölçeklendirir.

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

    # Yeni sunum oluşturulurken eklenen boş slaytı kaldır.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

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

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Yararlı PDF'ler hazırlarken, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) adresine bakın. Çıktı standardını seçmek için [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) yöntemini kullanın: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF üreten PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden fazla PPT veya PPTX dosyasını toplu olarak PDF'ye dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyebilir ve dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Evet. Dönüşüm sırasında bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

Sonuç PDF'ye gizli slaytları eklemek için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfında [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini `True` ile çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, erişilebilirlik veya arşivleme için PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) ile uyumlu PDF'ler dışa aktarmanıza olanak tanır. İhtiyacınıza uygun standardı seçin ve çıktıyı gereksinimlerinize göre gözden geçirin.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via Java Belgeleri](/slides/tr/python-java/)
- [Aspose.Slides for Python via Java API Referansı](https://reference.aspose.com/slides/python-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)