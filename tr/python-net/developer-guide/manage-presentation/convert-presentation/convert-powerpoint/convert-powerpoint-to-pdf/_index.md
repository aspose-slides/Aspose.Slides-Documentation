---
title: Python'da PPT & PPTX'yi PDF'ye Dönüştür | Gelişmiş Seçenekler
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint'i dönüştür
- sunum
- PowerPoint'ten PDF'ye
- PPT'den PDF'ye
- PPTX'den PDF'ye
- PowerPoint'i PDF olarak kaydet
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Aspose.Slides kullanarak Python'da PPT, PPTX ve ODP dosyalarını yüksek kaliteli, WCAG uyumlu PDF'lere dönüştürmek için adım adım rehber—parola koruması, slayt seçimi ve görüntü kalitesi kontrolü içerir."
showReadingTime: true
---
## **Genel Bakış**

Python'da PowerPoint sunumlarını (PPT, PPTX, ODP) PDF formatına dönüştürmek, farklı cihazlarda uyumluluğu sağlamak ve sunumun düzenini ve biçimlendirmesini korumak gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF belgelerini parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak, bu formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python'da bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfına argüman olarak geçirmeniz ve ardından sunumu [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydetmeniz yeterlidir. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürdüğünde, Aspose.Slides for Python Application alanını '*Aspose.Slides*' değeriyle ve PDF Producer alanını '*Aspose.Slides v XX.XX*' biçiminde bir değerle doldurur. **Not** Aspose.Slides for Python'a bu bilgileri çıktı belgelerinden değiştirmesini veya kaldırmasını söyleyemezsiniz.
{{% /alert %}}

Aspose.Slides, şunları dönüştürmenizi sağlar:

* Tüm sunumları PDF'ye
* Bir sunumdaki belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktararak oluşan PDF'lerin içeriğinin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru şekilde işlenir, bunlar şunları içerir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Başlıklar ve altbilgiler
* Madde imleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarıyla tüm görünen slaytları PDF olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose, sunumu PDF'ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF'ye dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sağlar. Burada açıklanan işlemin canlı bir uygulaması için dönüştürücü ile bir test yapabilirsiniz.
{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sunar; bu seçenekler PDF'yi (dönüşüm sürecinden elde edilen), şifre ile kilitlemenizi veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenizi sağlar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için bir sıkıştırma seviyesi ayarlayabilir, görüntüler için DPI belirleyebilir vb.

Aşağıdaki örnek bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması kullanılır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve slaytları görmesini isteyebilirsiniz. Gömülü OLE dosyalarını çıkan PDF'de ek olarak korumak için [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) özelliğini `True` olarak ayarlayın.

Varsayılan değer `False`'tır: OLE nesnesinin ön izleme görüntüsü veya simgesi PDF sayfasında render edilir, ancak gömülü dosya ek olarak dahil edilmez. Bu seçeneği `True` olarak ayarlamak dosya verilerini ek olarak da içerir. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, önceden gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Sonucu kontrol etmek için:

1. PDF'yi, Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide açın.
2. Görüntüleyicinin **Attachments** (Ekler) panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve içindeki verileri incelemek için Excel'de açın; ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ek'ten ayrıdadır.

{{% alert color="info" title="Note" %}}
PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereksinimleridir, Aspose.Slides'e özgü kısıtlama değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmayı göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfından [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini kullanarak Aspose.Slides'e gizli slaytları çıkan PDF'de sayfa olarak eklemesini söyleyebilirsiniz.

Aşağıdaki örnek, gizli slaytları da içerecek şekilde bir sunumu PDF'ye dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint'i Parola Koruması Olan PDF'ye Dönüştür**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren bir PDF'ye bir sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil baskıya izin verir.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ayrı Bir Kalın Yazı Tipi Olmayan Fontları İşleyin**

Bir sunum, fontun ayrı bir kalın yazı tipi olmamasına rağmen metne kalın biçimlendirme uygulayabilir. Metin, yapay kalınlaştırma (synthetic bolding) ile kalın görünebilir; bu yöntem normal glifleri yapay olarak kalınlaştırır. Metin PDF'de çok ağır görünürse veya istenen görünüme uymuyorsa, [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) özelliğini `True` olarak ayarlamayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında etkilenen metni bitmap olarak render eder ve belirli fontlar için görünümünü iyileştirebilir. Varsayılan değeri `False`'tur.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı fontta kalın biçimlendirme uygulanmış (ayrı bir kalın yazı tipi yok) metin. Aşağıdaki örnek sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Aşağıdaki ön izlemeler, seçenek devre dışı bırakılmış ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışı bırakıldığında kalın metnin çizgileri daha kalındır. Seçenek etkinleştirildiğinde çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`False`, varsayılan) | Seçenek etkin (`True`) |
|---|---|
| ![Desteklenmeyen yazı tipi stili rasterleştirme devre dışı bırakılmış PDF](unsupported-bold-disabled.png) | ![Desteklenmeyen yazı tipi stili rasterleştirme etkin PDF](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 zumda daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı bırakıldığında, her iki dize de metin olarak kalır.

Bu seçenek, fontun ayrı bir kalın yazı tipi olmadığında kalın biçimlendirilmiş metni rasterleştirir. [Yazı tipi ikamesi](/slides/tr/python-net/font-substitution/) ise orijinal mevcut olmadığında başka bir font seçer.

## **PowerPoint'te Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları birden başlar ve giriş sunumu en az üç slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan ilk slaytı 612 × 792 nokta (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Yeni oluşturulan sunumda bulunan boş slaytı kaldır.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumu PDF'ye dışa aktarır; her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Bu Python kodu, farklı uyumluluk standartlarına dayalı birden fazla PDF elde edilen bir PowerPoint'ten PDF'ye dönüşüm operasyonunu gösterir:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides'in PDF dönüşüm işlemleri desteği, PDF'yi en popüler dosya formatlarına dönüştürmenizi sağlar. [PDF'den HTML'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) ve [PDF'den PNG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) dönüşümleri yapabilirsiniz. Özelleştirilmiş formatlara PDF dönüşüm işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF'den TIFF'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Note:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **FAQ**

**Aspose.Slides for Python PDF'den uygulama bilgisini kaldırabilir mi?**

Hayır, Aspose.Slides for Python çıktı PDF'sine API bilgisi ve sürüm numarasını otomatik olarak ekler. Bu bilgi değiştirilemez veya kaldırılmaz.

**PDF dönüşümünde sadece belirli slaytları nasıl dahil ederim?**

Dönüştürmek istediğiniz slayt indekslerini, [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemine bir slayt konumları dizisi geçirerek belirtebilirsiniz.

**Dönüşüm sırasında PDF'i parola ile korumak mümkün mü?**

Evet, sunumu PDF olarak kaydetmeden önce [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfını kullanarak bir parola belirleyebilir ve erişim izinlerini tanımlayabilirsiniz.

**Aspose.Slides PDF'yi başka formatlara dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides PDF'leri HTML, görüntü formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürmeyi destekler.

**PDF'imin erişilebilirlik standartlarına uymasını nasıl sağlarım?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içinde [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayarak PDF'nin erişilebilirlik yönergelerine uyumlu olmasını sağlayabilirsiniz.

**PDF çıktısına gizli slaytları dahil edebilir miyim?**

Evet, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içinde [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini `True` olarak ayarlayarak gizli slaytlar PDF'ye dahil edilir.

**Dönüşüm sırasında görüntü kalitesini ve çözünürlüğünü nasıl ayarlarım?**

Çıkan PDF'de görüntü kalitesi ve çözünürlüğü kontrol etmek için [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içinde [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) ve [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) özelliklerini kullanın.

**Aspose.Slides yazı tipi ikamelerini otomatik olarak yönetiyor mu?**

Aspose.Slides dönüşüm sırasında yazı tipi ikamelerini tespit eder ve bunları `SaveOptions` içindeki `warning_callback` özelliğiyle (şu anda sınırlı) yönetebilirsiniz.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via .NET Documentation](/slides/tr/python-net/)
- [Aspose.Slides API Referansı](https://reference.aspose.com/slides/python-net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)