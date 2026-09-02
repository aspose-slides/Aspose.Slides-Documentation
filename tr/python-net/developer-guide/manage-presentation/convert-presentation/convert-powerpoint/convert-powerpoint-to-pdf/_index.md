---
title: "Python'da PPT ve PPTX'i PDF'ye Dönüştürme | Gelişmiş Seçenekler"
linktitle: "PowerPoint'ten PDF'ye"
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - "PowerPoint dönüştür"
  - sunum
  - "PowerPoint'ten PDF'ye"
  - "PPT'den PDF'ye"
  - "PPTX'ten PDF'ye"
  - "PowerPoint'i PDF olarak kaydet"
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - "Aspose.Slides for Python"
description: "Aspose.Slides ile Python'da PPT, PPTX ve ODP'yi yüksek kalite, WCAG uyumlu PDF'lere dönüştürme adım adım rehberi — şifre koruması, slayt seçimi ve görüntü kalitesi kontrolü içerir."
showReadingTime: true
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP) Python'da PDF formatına dönüştürmek, farklı cihazlarda uyumluluğu sağlamak ve sunumunuzun düzenini ve biçimlendirmesini korumak gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF belgelerini parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **Kurulum**

```bash
pip install aspose.slides
```

Paket, ihtiyaç duyduğu çalışma zamanını içerdiği için, dönüşümü gerçekleştiren makinede Microsoft PowerPoint'in yüklü olmasına gerek yoktur.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak bu formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python'da bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfına argüman olarak geçirmeniz ve ardından sunumu bir PDF olarak [Save](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/#methods) yöntemiyle kaydetmeniz yeterlidir. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/#methods) yöntemini sunar.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python, çıktıda doğrudan API bilgilerini ve Versiyon Numarasını yazar. Örneğin, bir sunumu PDF'ye dönüştürdüğünde, Aspose.Slides for Python Application alanını '*Aspose.Slides*' değeriyle ve PDF Producer alanını '*Aspose.Slides v XX.XX*' biçiminde bir değerle doldurur. **Not** bu bilgileri çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Sunumdaki belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin içeriğinin orijinal sunumlara mümkün olduğunca yakın olmasını sağlar. Dönüşümde öğeler ve nitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint PDF dönüşüm işlemi, varsayılan seçenekler kullanılarak yürütülür. Bu durumda, Aspose.Slides, sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır. Bu Python kodu, bir PowerPoint'i PDF'ye nasıl dönüştüreceğinizi gösterir:

_Adımlar: Python'da PowerPoint'ten PDF'ye Dönüşümler_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Adımlar: Python via .NET kullanarak PowerPoint'i PDF'ye Dönüştür</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Adımlar: Python via .NET kullanarak PPT'yi PDF'ye Dönüştür</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Adımlar: Python via .NET kullanarak PPTX'i PDF'ye Dönüştür</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: Python via .NET kullanarak ODP'yi PDF'ye Dönüştür</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: Python via .NET kullanarak PPS'yi PDF'ye Dönüştür</a></strong>

_Kod Adımları:_

- PowerPoint dosyasını sağlayarak [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
  * _.ppt_ uzantısı, _Presentation_ sınıfı içinde **PPT** dosyasını yüklemek için kullanılır.
  * _.pptx_ uzantısı, _Presentation_ sınıfı içinde **PPTX** dosyasını yüklemek için kullanılır.
  * _.odp_ uzantısı, _Presentation_ sınıfı içinde **ODP** dosyasını yüklemek için kullanılır.
  * _.pps_ uzantısı, _Presentation_ sınıfı içinde **PPS** dosyasını yüklemek için kullanılır.
- _Presentation_'ı **PDF** formatında kaydetmek için **Save** metodunu çağırın ve **SaveFormat.PDF** enum değerini kullanın.
  

```python
import aspose.slides as slides

# Bir PowerPoint dosyasını temsil eden Presentation sınıfını örnekler
presentation = slides.Presentation("PowerPoint.ppt")

# Sunumu PDF olarak kaydeder
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose, sunumu PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrim içi [**PowerPoint to PDF dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sağlar. Burada açıklanan prosedürün canlı bir uygulaması için dönüştürücü ile bir test yapabilirsiniz.

{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, PDF'yi (dönüşüm sürecinin sonucunu) özelleştirmenizi, PDF'yi bir parola ile kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenizi sağlayan özel seçenekler—[PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfının özellikleri—sunar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini tanımlayabilir, metinler için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI belirleyebilir vb. yapabilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunun çeşitli özel seçeneklerle PDF'ye dönüştürüldüğü bir işlemi gösterir:

```python
import aspose.slides as slides

# PdfOptions sınıfını örnekler
pdf_options = slides.export.PdfOptions()

# JPG görüntülerinin kalitesini ayarlar
pdf_options.jpeg_quality = 90

# Görüntüler için DPI ayarlar
pdf_options.sufficient_resolution = 300

# Metafile'lerin davranışını ayarlar
pdf_options.save_metafiles_as_png = True

# Metin içeriği için metin sıkıştırma seviyesini ayarlar
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF uyumluluk modunu tanımlar
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint belgesini temsil eden Presentation sınıfını örnekler
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Sunumu bir PDF belgesi olarak kaydeder
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfındaki `show_hidden_slides` özelliğini kullanarak Aspose.Slides'e gizli slaytları ortaya çıkan PDF'de sayfa olarak eklemesini söyleyebilirsiniz.

Bu Python kodu, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# Bir PowerPoint dosyasını temsil eden Presentation sınıfını örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# Gizli slaytları ekler
pdfOptions.show_hidden_slides = True

# Sunumu bir PDF olarak kaydeder
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Şifre Korumalıklı PDF'ye PowerPoint Dönüştür**

Bu Python kodu, bir PowerPoint'i [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak şifre korumalıklı bir PDF'ye nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesini örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# PDF şifresi ve erişim izinlerini ayarlar
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Sunumu bir PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint'te Seçili Slaytları PDF'ye Dönüştür**

Bu Python kodu, bir PowerPoint sunumundaki belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesini örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# Slayt konumlarını içeren bir dizi ayarlar
slides_array = [ 1, 3 ]

# Sunumu bir PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

Bu Python kodu, slayt boyutu belirtilmiş bir PowerPoint'in PDF'ye nasıl dönüştürüleceğini gösterir:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekler.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Ayarlanmış slayt boyutuyla yeni bir sunum oluşturur.
    with slides.Presentation() as resized_presentation:

        # Özel slayt boyutunu ayarlar.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Orijinal sunumdan ilk slaytı klonlar ve varsayılan boş slaytı kaldırır.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Yeniden boyutlandırılmış sunumu PDF olarak kaydeder.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Bu Python kodu, bir PowerPoint'i PDF notlarına nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfını örnekler
presentation = slides.Presentation("NotesFile.pptx")

# Not düzeniyle PDF seçeneklerini yapılandırır
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sunumu notlarla bir PDF olarak kaydeder
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi bu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Python kodu, farklı uyumluluk standartlarına göre birden çok PDF elde edilen bir PowerPoint'ten PDF'ye dönüşüm işlemini gösterir:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dönüşüm işlemleri desteğini, PDF'yi en popüler dosya formatlarına dönüştürmenize izin verecek şekilde genişletir. [PDF to HTML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-png/) dönüşümlerini yapabilirsiniz. Ayrıca, özel formatlara—[PDF to SVG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-xml/)—PDF dönüştürme işlemleri de desteklenir.

{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides karmaşık grafikleri (SmartArt, grafikler ve formüller gibi) tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **FAQ**

### Aspose.Slides for Python PDF'den uygulama bilgilerini kaldırabilir mi?

Hayır, Aspose.Slides for Python, çıktıda otomatik olarak API bilgilerini ve sürüm numarasını içerir. Bu bilgiler değiştirilemez veya kaldırılamaz.

### PDF dönüşümünde yalnızca belirli slaytları nasıl dahil ederim?

İstediğiniz slayt indekslerini `save` metoduna bir slayt konumları dizisi geçirerek belirtebilirsiniz.

### Dönüşüm sırasında PDF'yi şifreyle korumak mümkün mü?

Evet, sunumu PDF olarak kaydetmeden önce `PdfOptions` sınıfını kullanarak bir şifre belirleyebilir ve erişim izinlerini tanımlayabilirsiniz.

### Aspose.Slides PDF'yi diğer formatlara dönüştürmeyi destekliyor mu?

Evet, Aspose.Slides, PDF'leri HTML, görüntü formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürmeyi destekler.

### PDF'min erişilebilirlik standartlarına uygunluğunu nasıl sağlayabilirim?

Erişilebilirlik yönergelerine uygunluğu sağlamak için `PdfOptions` içinde `compliance` özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayın.

### PDF çıktısına gizli slaytları dahil edebilir miyim?

Evet, `PdfOptions` içinde `show_hidden_slides` özelliğini `True` olarak ayarlayarak gizli slaytlar PDF'ye dahil edilir.

### Dönüşüm sırasında görüntü kalitesini ve çözünürlüğünü nasıl ayarlarım?

Sonuç PDF'de görüntü kalitesini ve çözünürlüğünü kontrol etmek için `PdfOptions` içinde `jpeg_quality` ve `sufficient_resolution` özelliklerini kullanın.

### Aspose.Slides yazı tipi ikamelerini otomatik olarak yönetiyor mu?

Aspose.Slides, dönüşüm sırasında yazı tipi ikamelerini algılar ve bunları `SaveOptions` içindeki `warning_callback` özelliği ile (şu anda sınırlı olarak) yönetebilirsiniz.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Dökümantasyonu](https://docs.aspose.com/slides/tr/python-net/)
- [Aspose.Slides API Referansı](https://reference.aspose.com/slides/tr/python-net/)
- [Aspose Ücretsiz Çevrim İçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)