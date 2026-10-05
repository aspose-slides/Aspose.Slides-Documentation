---
title: Python'da PPT & PPTX'yi PDF'ye Dönüştür | Gelişmiş Seçenekler
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint'u Dönüştür
- sunum
- PowerPoint'ten PDF'ye
- PPT'den PDF'ye
- PPTX'den PDF'ye
- PowerPoint'u PDF olarak kaydet
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Aspose.Slides ile Python'da PPT, PPTX ve ODP'yi yüksek kalite, WCAG uyumlu PDF'lere dönüştürmek için adım adım kılavuz—şifre koruması, slayt seçimi ve görüntü kalitesi kontrolünü içerir."
showReadingTime: true
---
## **Genel Bakış**

Python’da PowerPoint sunumlarını (PPT, PPTX, ODP) PDF formatına dönüştürmek, farklı cihazlarda uyumluluğu sağlamak ve sunumunuzun düzenini ve biçimlendirmesini korumak gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF belgelerini şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıkış belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak bu formatlardaki sunumları PDF’ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python’da bir sunumu PDF’ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfına bir argüman olarak geçirmeniz ve ardından sunumu bir [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydetmeniz yeterlidir. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF’ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python, çıktıya API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF’ye dönüştürdüğünde, Aspose.Slides for Python Application alanını '*Aspose.Slides*' değeriyle ve PDF Producer alanını '*Aspose.Slides v XX.XX*' biçiminde doldurur. **Note** bu bilgiyi çıktılardan değiştiremez veya kaldıramazsınız.
{{% /alert %}}

Aspose.Slides şunları dönüştürmenize izin verir:

* Tüm sunumları PDF’ye
* Sunumdaki belirli slaytları PDF’ye

Aspose.Slides, PDF’ye dışa aktarırken, sonuç PDF’lerin içeriğinin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşümde aşağıdaki öğeler ve öznitelikler doğru bir şekilde işlenir:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Hipermetin bağlantıları
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF’ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve tüm görünen slaytları varsayılan dışa aktarma ayarlarıyla PDF’ye kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose, sunumu PDF’ye dönüştürme sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için dönüştürücüyi kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfı altında yer alan özel seçenekler—özellikler—sağlayarak PDF’yi (dönüşüm sürecinin sonucunu) özelleştirmenize, PDF’yi bir şifreyle kilitlemenize veya dönüşüm sürecinin nasıl işleyeceğini belirlemenize olanak tanır.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile’ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI değeri vb. ayarlayabilirsiniz.

Aşağıdaki örnek bir sunumu PDF 1.5 formatına, JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile’lar PNG olarak kaydedilmiş ve Flate metin sıkıştırması uygulanmış şekilde dışa aktarır.

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

Sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem çalışma kitabının verilerine erişmesini hem de slaytları görüntülemesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF’de ek olarak tutmak için [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) özelliğini `True` olarak ayarlayın.

Varsayılan değer `False`’tur: OLE nesnesinin ön izleme görüntüsü veya simgesi PDF sayfasında gösterilir, ancak gömülü dosya ek olarak eklenmez. Özelliği `True` yaparsanız dosya verisi de eklenir. Ön izleme görsel bir temsil olmaya devam eder; ek, alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfası haline gelmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabını ekli olarak PDF’ye dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Sonucu kontrol etmek için:

1. PDF’i ekleri destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader, açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel’de açarak verilerini inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler konusunda kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 diğer dosya türlerini, Excel çalışma kitapları dahil, izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides’e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Sunumda gizli slaytlar varsa, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfındaki [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini kullanarak Aspose.Slides’ın gizli slaytları sonuç PDF’de sayfa olarak dahil etmesini sağlayabilirsiniz.

Aşağıdaki örnek gizli slaytları da içerecek şekilde bir sunumu PDF’ye dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint'i Şifre Korunmalı PDF'ye Dönüştür**

Aşağıdaki örnek, açmak için `password` şifresi gerektiren ve yüksek kaliteli baskı dahil olmak üzere yazdırma izinleri tanımlı bir PDF’ye sunumu dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PowerPoint'te Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan slayt 1 ve 3’ü PDF’ye dışa aktarır. Bu dizi içinde slayt numaraları bir‑bazlıdır ve giriş sunumu en az üç slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Özel Slayt Boyutuyla PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 point (8,5 × 11 inç) boyutunda yeni bir sunuma kopyalar, slayt içeriğini sığdırmak için ölçeklendirir ve tek slaytı PDF’ye dışa aktarır.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Yeni sunumun oluşturulduğu boş slaytı kaldır.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Aşağıdaki örnek, her slaytın konuşmacı notlarını slaytın altında yer alacak şekilde bir sunumu PDF’ye dışa aktarır. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web İçerik Erişilebilirlik Yönergeleri (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. PowerPoint belgenizi aşağıdaki uyumluluk standartlarından herhangi biriyle PDF’ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu Python kodu, farklı uyumluluk standartlarına göre birden çok PDF elde eden bir PowerPoint‑PDF dönüşüm işlemini gösterir:

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
Aspose.Slides, PDF dönüşüm işlemlerini en popüler dosya formatlarına dönüştürmenizi sağlar. [PDF'den HTML'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) ve [PDF'den PNG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Özel formatlara yönelik diğer PDF dönüşüm işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)]—da desteklenir.
{{% /alert %}}

> **Note:** PDF/UA’ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekle uygulanır.

## **SSS**

**Aspose.Slides for Python PDF’den uygulama bilgilerini kaldırabilir mi?**

Hayır, Aspose.Slides for Python çıkış PDF’sine API bilgisi ve sürüm numarasını otomatik olarak ekler. Bu bilgi değiştirilemez veya kaldırılamaz.

**PDF dönüşümünde yalnızca belirli slaytları nasıl ekleyebilirim?**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemine bir slayt konumu dizisi geçirerek dönüştürmek istediğiniz slayt indekslerini belirtebilirsiniz.

**Dönüşüm sırasında PDF’yi şifreyle korumak mümkün mü?**

Evet, PDF’yi kaydetmeden önce [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfını kullanarak bir şifre ve erişim izinleri ayarlayabilirsiniz.

**Aspose.Slides PDF’yi diğer formatlara dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides PDF’yi HTML, görüntü formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürmeyi destekler.

**PDF’min erişilebilirlik standartlarına uygun olduğunu nasıl garanti ederim?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içindeki [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayarak erişilebilirlik yönergelerine uygunluğunu sağlayabilirsiniz.

**Gizli slaytları PDF çıktısına dahil edebilir miyim?**

Evet, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içinde [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini `True` olarak ayarladığınızda gizli slaytlar PDF’ye dahil edilir.

**Dönüşüm sırasında görüntü kalitesi ve çözünürlüğünü nasıl ayarlarım?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içindeki [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) ve [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) özelliklerini kullanarak sonuç PDF’de görüntü kalitesi ve çözünürlüğünü kontrol edebilirsiniz.

**Aspose.Slides yazı tipi ikamelerini otomatik olarak yönetiyor mu?**

Aspose.Slides dönüşüm sırasında yazı tipi ikamelerini algılar ve bunları `warning_callback` özelliğiyle (şu anda sınırlı) ele alabilirsiniz.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via .NET Documentation](/slides/tr/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)