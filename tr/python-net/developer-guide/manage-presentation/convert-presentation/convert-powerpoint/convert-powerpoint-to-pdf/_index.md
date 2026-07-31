---
title: PPT & PPTX'i Python'da PDF'ye Dönüştür | Gelişmiş Seçenekler
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint dönüştür
- sunum
- PowerPoint'ten PDF
- PPT'den PDF
- PPTX'den PDF
- PowerPoint'i PDF olarak kaydet
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Aspose.Slides ile Python'da PPT, PPTX ve ODP'yi yüksek kalite, WCAG uyumlu PDF'lere dönüştürmek için adım adım kılavuz—şifre koruması, slayt seçimi ve görüntü kalitesi kontrolü içerir."
showReadingTime: true
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP) Python’da PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluğu sağlamak ve sunumun düzeni ile biçimlendirmesini korumak gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelere dönüştürmeyi, görüntü kalitesini kontrol eden çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF belgelerini şifre korumalı hale getirmeyi, yazı tipi değişimlerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüştürmeler**

Aspose.Slides kullanarak aşağıdaki formatlardaki sunumları PDF’ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python’da bir sunumu PDF’ye dönüştürmek için yalnızca dosya adını `Presentation` sınıfına argüman olarak geçirmeniz ve ardından `Save` yöntemiyle sunumu PDF olarak kaydetmeniz yeterlidir. `Presentation` sınıfı, genellikle bir sunumu PDF’ye dönüştürmek için kullanılan `Save` yöntemini ortaya çıkarır.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python, çıktı belgelerine doğrudan API bilgisi ve Sürüm Numarasını yazar. Örneğin, bir sunumu PDF’ye dönüştürdüğünde, Aspose.Slides for Python `Application` alanını '*Aspose.Slides*' değeriyle, `PDF Producer` alanını ise '*Aspose.Slides v XX.XX*' biçiminde doldurur. **Not**: Aspose.Slides for Python ile bu bilgileri çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides aşağıdaki dönüşümleri yapmanıza olanak tanır:

* Tüm sunumları PDF’ye
* Sunum içindeki belirli slaytları PDF’ye

Aspose.Slides, sunumları PDF’ye dışa aktararak ortaya çıkan PDF’lerin içeriğinin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında aşağıdaki öğeler ve nitelikler doğru şekilde işlenir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üst bilgi ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştürme**

Standart PowerPoint PDF dönüşüm işlemi, varsayılan seçeneklerle yürütülür. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF’ye dönüştürmeye çalışır. Aşağıdaki Python kodu, PowerPoint’i PDF’ye nasıl dönüştüreceğinizi gösterir:

_Adımlar: Python’da PowerPoint'ten PDF'ye Dönüştürme_

Aşağıdaki örnek kod, .NET aracılığıyla Python kullanarak bu dönüşümleri açıklar
- <a name="python-net-powerpoint-to-pdf"><strong>Adımlar: .NET üzerinden Python kullanarak PowerPoint’i PDF’ye Dönüştür</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Adımlar: .NET üzerinden Python kullanarak PPT’yi PDF’ye Dönüştür</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Adımlar: .NET üzerinden Python kullanarak PPTX’i PDF’ye Dönüştür</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: .NET üzerinden Python kullanarak ODP’yi PDF’ye Dönüştür</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Adımlar: .NET üzerinden Python kullanarak PPS’yi PDF’ye Dönüştür</strong></a>

_Kod Adımları:_

- `Presentation` sınıfının bir örneğini oluşturun ve PowerPoint dosyasını ona sağlayın.
  * *.ppt* uzantısı **PPT** dosyasını `Presentation` sınıfına yüklemek için.
  * *.pptx* uzantısı **PPTX** dosyasını `Presentation` sınıfına yüklemek için.
  * *.odp* uzantısı **ODP** dosyasını `Presentation` sınıfına yüklemek için.
  * *.pps* uzantısı **PPS** dosyasını `Presentation` sınıfına yüklemek için.
- `Save` yöntemini çağırarak ve `SaveFormat.PDF` enum değerini kullanarak _Presentation_ʼı **PDF** formatında kaydedin.
  

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfı örnekler
presentation = slides.Presentation("PowerPoint.ppt")

# Sunumu PDF olarak kaydeder
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose, sunumu PDF’ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sağlar. Burada açıklanan prosedürün canlı bir uygulamasını görmek isterseniz, dönüştürücüyle bir test yapabilirsiniz.

{{% /alert %}}

## **PowerPoint'ten PDF'ye Seçeneklerle Dönüştürme**

Aspose.Slides, [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfı altında bulunan özelleştirilebilir seçenekler (özellikler) sayesinde PDF’yi (dönüştürme sürecinin sonucu) özelleştirmenize, PDF’yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl yürütüleceğini belirlemenize olanak tanır.

### **PowerPoint'ten PDF'ye Özelleştirilmiş Seçeneklerle Dönüştürme**

Özel dönüşüm seçenekleri kullanarak raster görseller için tercih ettiğiniz kalite ayarını belirleyebilir, metafile’ların nasıl işleneceğini seçebilir, metinler için sıkıştırma seviyesini ayarlayabilir, görseller için DPI belirleyebilirsiniz vb.

Aşağıdaki kod örneği, bir PowerPoint sunumunun çeşitli özel seçeneklerle PDF’ye dönüştürülmesini göstermektedir:

```python
import aspose.slides as slides

# PdfOptions sınıfını örnekler
pdf_options = slides.export.PdfOptions()

# JPG görüntülerinin kalitesini ayarlar
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
    # Sunumu PDF belgesi olarak kaydeder
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Gizli Slaytlarla PowerPoint'ten PDF'ye Dönüştürme**

Sunumda gizli slaytlar varsa, [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfındaki `show_hidden_slides` özelliğini kullanarak Aspose.Slides’ın gizli slaytları sonuç PDF’de sayfa olarak dahil etmesini sağlayabilirsiniz.

Bu Python kodu, gizli slaytların dahil edildiği bir PowerPoint sunumunun PDF’ye nasıl dönüştürüleceğini gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfı örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# Gizli slaytları ekler
pdfOptions.show_hidden_slides = True

# Sunumu PDF olarak kaydeder
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Şifre Koruması ile PowerPoint'ten PDF'ye Dönüştürme**

Bu Python kodu, bir PowerPoint’i şifre korumalı PDF’ye ( [PdfOptions](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides.export/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak) nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesi örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions sınıfını örnekler
pdfOptions = slides.export.PdfOptions()

# PDF şifresi ve erişim izinlerini ayarlar
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Sunumu PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint’te Seçilen Slaytları PDF’ye Dönüştürme**

Bu Python kodu, bir PowerPoint sunumundaki belirli slaytların PDF’ye nasıl dönüştürüleceğini gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation nesnesi örnekler
presentation = slides.Presentation("PowerPoint.pptx")

# Slayt konumlarının bir dizisini ayarlar
slides_array = [ 1, 3 ]

# Sunumu PDF olarak kaydeder
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Özel Slayt Boyutu ile PowerPoint'ten PDF'ye Dönüştürme**

Bu Python kodu, slayt boyutu belirtilmiş bir PowerPoint’in PDF’ye nasıl dönüştürüleceğini gösterir:

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

        # Yeniden boyutlandırılmış sunumu notlarla birlikte PDF olarak kaydeder.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Not Slayt Görünümünde PowerPoint'ten PDF'ye Dönüştürme**

Bu Python kodu, bir PowerPoint’in not slaytları ile PDF’ye nasıl dönüştürüleceğini gösterir:

```python
import aspose.slides as slides

# PowerPoint dosyasını temsil eden bir Presentation sınıfı örnekler
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sunumu PDF notları olarak kaydeder
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. Bir PowerPoint belgesini aşağıdaki uyumluluk standartlarından herhangi birini kullanarak PDF’ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu Python kodu, farklı uyumluluk standartlarına göre birden fazla PDF elde eden bir PowerPoint‑PDF dönüşüm işlemini gösterir:

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

Aspose.Slides, PDF dönüşüm işlemlerinin ötesinde PDF’yi en popüler dosya formatlarına dönüştürmenize de olanak tanır. Şu dönüşümleri yapabilirsiniz: [PDF to HTML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-png/). Ayrıca, [PDF to SVG](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/python-net/conversion/pdf-to-xml/) gibi özel formatlara dönüşüm de desteklenir.

{{% /alert %}}

> **Not:** PDF/UA’ya dışa aktarırken, Aspose.Slides, SmartArt, grafikler ve formüller gibi karmaşık görselleri tek bir şekil olarak işler. Bireysel yol elemanları ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Aspose.Slides for Python PDF’den uygulama bilgilerini kaldırabilir mi?**

Hayır, Aspose.Slides for Python çıktı PDF’sine otomatik olarak API bilgisi ve sürüm numarasını ekler. Bu bilgi değiştirilemez veya kaldırılamaz.

**PDF dönüşümünde yalnızca belirli slaytları nasıl dahil edebilirim?**

`save` yöntemine slayt konumlarını içeren bir dizi geçirerek dönüştürmek istediğiniz slayt indekslerini belirtebilirsiniz.

**Dönüşüm sırasında PDF’yi şifre korumalı hale getirmek mümkün mü?**

Evet, PDF’yi kaydetmeden önce `PdfOptions` sınıfı aracılığıyla bir şifre belirleyebilir ve erişim izinlerini tanımlayabilirsiniz.

**Aspose.Slides PDF’yi başka formatlara dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides, PDF’yi HTML, resim formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürmeyi destekler.

**PDF’imin erişilebilirlik standartlarına uygun olmasını nasıl sağlarım?**

`PdfOptions` içindeki `compliance` özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayarak uyumluluğu sağlayabilirsiniz.

**Gizli slaytları PDF çıktısına dahil edebilir miyim?**

Evet, `PdfOptions` içindeki `show_hidden_slides` özelliğini `True` olarak ayarladığınızda gizli slaytlar PDF’ye dahil edilir.

**Dönüşüm sırasında görüntü kalitesini ve çözünürlüğünü nasıl ayarlarım?**

`PdfOptions` içindeki `jpeg_quality` ve `sufficient_resolution` özelliklerini kullanarak ortaya çıkan PDF’deki görüntü kalitesini ve çözünürlüğünü kontrol edebilirsiniz.

**Aspose.Slides yazı tipi değişimlerini otomatik olarak yönetiyor mu?**

Aspose.Slides dönüşüm sırasında yazı tipi değişimlerini algılar ve (şu anda sınırlı olan) `SaveOptions` içindeki `warning_callback` özelliğiyle bunları yönetebilirsiniz.

## **Ek Kaynaklar**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/tr/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/tr/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)