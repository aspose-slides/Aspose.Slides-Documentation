---
title: "Python'da PPT & PPTX'i PDF'ye Dönüştür | Gelişmiş Seçenekler"
linktitle: "PowerPoint'ten PDF'ye"
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint dönüştür"
- "sunum"
- "PowerPoint'ten PDF'ye"
- "PPT'den PDF'ye"
- "PPTX'ten PDF'ye"
- "PowerPoint'i PDF olarak kaydet"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Aspose.Slides for Python"
description: "Python'da Aspose.Slides ile PPT, PPTX ve ODP'yi yüksek kalite, WCAG uyumlu PDF'lere dönüştürmek için adım adım rehber—şifre koruması, slayt seçimi ve görüntü kalitesi kontrolü içerir."
showReadingTime: true
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP) Python'da PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluğu sağlamak ve sunumunuzun yerleşimini ve biçimlendirmesini korumak gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları eklemeyi, PDF belgelerini şifre korumalı yapmayı, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak bu formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python'da bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir argümanı olarak vermeniz ve ardından sunumu bir PDF olarak [Save](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/#methods) yöntemiyle kaydetmeniz yeterlidir. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [Save](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/#methods) yöntemini sunar.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Python, çıktı belgelerine API bilgisi ve Versiyon Numarasını doğrudan yazar. Örneğin, bir sunumu PDF'ye dönüştürdüğünde, Aspose.Slides for Python Application alanını '*Aspose.Slides*' değeriyle ve PDF Producer alanını '*Aspose.Slides v XX.XX*' biçiminde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides, aşağıdaki dönüşümleri yapmanıza olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdaki belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktararak, ortaya çıkan PDF'lerin içeriğinin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, bunlar şunları içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint PDF dönüştürme işlemi varsayılan seçenekler kullanılarak yürütülür. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır. Bu Python kodu, bir PowerPoint'i PDF'ye nasıl dönüştüreceğinizi gösterir:

_Adımlar: Python'da PowerPoint'ten PDF'ye Dönüştürmeler_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Adımlar: Python üzerinden .NET kullanarak PowerPoint'i PDF'ye Dönüştür</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Adımlar: Python üzerinden .NET kullanarak PPT'yi PDF'ye Dönüştür</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Adımlar: Python üzerinden .NET kullanarak PPTX'i PDF'ye Dönüştür</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: Python üzerinden .NET kullanarak ODP'yi PDF'ye Dönüştür</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: Python üzerinden .NET kullanarak PPS'yi PDF'ye Dönüştür</a></strong>

**Kod Adımları:**

- PowerPoint dosyasını sağlayarak [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
  * ._ppt_ uzantısı, _Presentation_ sınıfı içinde **PPT** dosyasını yüklemek için.
  * ._pptx_ uzantısı, _Presentation_ sınıfı içinde **PPTX** dosyasını yüklemek için.
  * ._odp_ uzantısı, _Presentation_ sınıfı içinde **ODP** dosyasını yüklemek için.
  * ._pps_ uzantısı, _Presentation_ sınıfı içinde **PPS** dosyasını yüklemek için.
- _Presentation_ nesnesini **PDF** formatında kaydetmek için **Save** metodunu çağırın ve **SaveFormat.PDF** enum değerini kullanın.
  

```python
import aspose.slides as slides

# Bir PowerPoint dosyasını temsil eden Presentation sınıfını örnekler
presentation = slides.Presentation("PowerPoint.ppt")

# Sunumu PDF olarak kaydeder
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 
Aspose, sunumu PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi **PowerPoint to PDF dönüştürücü** sağlar. Burada açıklanan prosedürün canlı bir uygulaması için dönüştürücü ile bir test yapabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, PDF'yi (dönüştürme sürecinden elde edilen) özelleştirmenizi, PDF'yi bir şifreyle kilitlemenizi veya dönüşüm sürecinin nasıl gerçekleşeceğini belirlemenizi sağlayan, [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sağlar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için istediğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini tanımlayabilir, metinler için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI belirleyebilir vb.

Aşağıdaki kod örneği, bir PowerPoint sunumunun çeşitli özel seçeneklerle PDF'ye dönüştürüldüğü bir işlemi gösterir:

```python
import aspose.slides as slides

# PdfOptions sınıfını örnekler
pdf_options = slides.export.PdfOptions()

# JPG görüntülerin kalitesini ayarlar
pdf_options.jpeg_quality = 90

# Görüntüler için DPI ayarlar
pdf_options.sufficient_resolution = 300

# Metafile'ların davranışını ayarlar
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

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfındaki `show_hidden_slides` özelliğini kullanarak Aspose.Slides'a gizli slaytları sonuç PDF'de sayfa olarak eklemesini söyleyebilirsiniz.

Bu Python kodu, gizli slaytların dahil edildiği bir PowerPoint sunumunun PDF'ye nasıl dönüştürüleceğini gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfını örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# Gizli slaytları ekler
pdfOptions.show_hidden_slides = True

# Sunumu PDF olarak kaydeder
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint'i Şifre Korumalı PDF'ye Dönüştür**

Bu Python kodu, bir PowerPoint'i şifre korumalı PDF'ye (koruma parametrelerini [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfından kullanarak) nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesini örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# PDF şifresini ve erişim izinlerini ayarlar
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Sunumu PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint'te Seçili Slaytları PDF'ye Dönüştür**

Bu Python kodu, bir PowerPoint sunumundaki belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesini örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# Slayt konumlarının bir dizisini ayarlar
slides_array = [ 1, 3 ]

# Sunumu PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

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

        # Orijinal sunumdan ilk slaytı klonlar.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Yeniden boyutlandırılmış sunumu notlarla bir PDF olarak kaydeder.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Bu Python kodu, bir PowerPoint'i PDF notlarına nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfını örnekler
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sunumu PDF notları olarak kaydeder
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye dışa aktarırken bu uyumluluk standartlarından herhangi birini kullanabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu Python kodu, farklı uyumluluk standartlarına göre birden fazla PDF elde edilen bir PowerPoint'ten PDF'ye dönüşüm işlemini gösterir:

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
Aspose.Slides, PDF dönüşüm işlemleri desteğini en popüler dosya formatlarına PDF dönüştürme olanağına da genişletir. [PDF to HTML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-png/) dönüşümlerini yapabilirsiniz. Ayrıca, özel formatlara PDF dönüşüm işlemleri—[PDF to SVG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Aspose.Slides for Python PDF'den uygulama bilgisini kaldırabilir mi?**  
Hayır, Aspose.Slides for Python çıktı PDF'ye otomatik olarak API bilgisi ve sürüm numarasını ekler. Bu bilgi değiştirilemez veya kaldırılamaz.

**PDF dönüşümünde sadece belirli slaytları nasıl dahil edebilirim?**  
`save` metoduna slayt konumlarını içeren bir dizi geçirerek dönüştürmek istediğiniz slayt indekslerini belirtebilirsiniz.

**Dönüşüm sırasında PDF'yi şifre korumalı yapmak mümkün mü?**  
Evet, sunumu PDF olarak kaydetmeden önce `PdfOptions` sınıfını kullanarak bir şifre belirleyebilir ve erişim izinlerini tanımlayabilirsiniz.

**Aspose.Slides PDF'yi diğer formatlara dönüştürmeyi destekliyor mu?**  
Evet, Aspose.Slides PDF'leri HTML, görsel formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürmeyi destekler.

**PDF'imin erişilebilirlik standartlarına uygun olduğundan nasıl emin olabilirim?**  
Erişilebilirlik yönergelerine uyumu sağlamak için `PdfOptions` içindeki `compliance` özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayın.

**PDF çıktısına gizli slaytları ekleyebilir miyim?**  
Evet, `PdfOptions` içinde `show_hidden_slides` özelliğini `True` olarak ayarladığınızda gizli slaytlar PDF'ye dahil edilir.

**Dönüşüm sırasında görüntü kalitesi ve çözünürlüğü nasıl ayarlarım?**  
Sonuç PDF'deki görüntü kalitesi ve çözünürlüğü kontrol etmek için `PdfOptions` içindeki `jpeg_quality` ve `sufficient_resolution` özelliklerini kullanın.

**Aspose.Slides yazı tipi ikamelerini otomatik olarak yönetiyor mu?**  
Aspose.Slides dönüşüm sırasında yazı tipi ikamelerini algılar ve bunları `SaveOptions` içindeki `warning_callback` özelliğiyle (şu anda sınırlı) ele alabilirsiniz.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Belgelendirmesi](https://docs.aspose.com/slides/tr/python-net/)
- [Aspose.Slides API Referansı](https://reference.aspose.com/slides/tr/python-net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/tr/conversion)