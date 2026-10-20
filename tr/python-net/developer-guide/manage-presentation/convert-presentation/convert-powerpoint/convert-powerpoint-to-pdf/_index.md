---
title: Python'da PPT & PPTX'yi PDF'ye Dönüştür | Gelişmiş Seçenekler
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint dönüştür
- sunum
- PowerPoint'ten PDF'ye
- PPT'den PDF'ye
- PPTX'ten PDF'ye
- PowerPoint'i PDF olarak kaydet
- ek
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Aspose.Slides ile Python'da PPT, PPTX ve ODP'yi yüksek kalite, WCAG uyumlu PDF'lere dönüştürmeye yönelik adım adım rehber—şifre koruması, slayt seçimi ve görüntü kalitesi kontrolünü içerir."
showReadingTime: true
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP) Python’da PDF formatına dönüştürmek, farklı cihazlarda uyumluluğu sağlamak ve sunumunuzun düzeni ile biçimlendirmesini korumak gibi birçok avantaj sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF belgelerini şifrelemeyi, yazı tipi değişimlerini algılamayı, belirli slaytları seçerek dönüştürmeyi ve çıktı belgelerine uyumluluk standartları uygulamayı göstermektedir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides ile bu formatlardaki sunumları PDF’ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Python’da bir sunumu PDF’ye dönüştürmek için dosya adını [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfına argüman olarak vermeniz ve ardından sunumu bir [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemiyle PDF olarak kaydetmeniz yeterlidir. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı, bir sunumu PDF’ye dönüştürmek için tipik olarak kullanılan [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python, API bilgisi ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF’ye dönüştürdüğünde Aspose.Slides for Python, Application alanını '*Aspose.Slides*' değeriyle ve PDF Producer alanını '*Aspose.Slides v XX.XX*' biçiminde doldurur. **Not**: Aspose.Slides for Python’un bu bilgiyi çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides şu dönüşümleri yapmanıza izin verir:

* Tüm sunumları PDF’ye
* Sunum içindeki belirli slaytları PDF’ye

Aspose.Slides, sunumları PDF’ye dışa aktarırken, ortaya çıkan PDF’lerin içeriğinin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında elemanlar ve öznitelikler doğru bir şekilde işlenir, örneğin:

* Görüntüler
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde imleri
* Tablolar

## **PowerPoint'i PDF'e Dönüştür**

Standart PowerPoint‑to‑PDF dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda Aspose.Slides, sağlanan sunumu en yüksek kalite düzeylerinde optimum ayarlarla PDF’ye dönüştürmeye çalışır.

Aşağıdaki örnek, bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarım ayarlarıyla PDF’ye kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose, sunduğu ücretsiz çevrimiçi [PowerPoint'ten PDF dönüştürücü](https://products.aspose.app/slides/conversion/ppt-to-pdf) ile sunum‑PDF dönüşüm sürecini gösterir. Burada anlatılan prosedürün canlı uygulamasını görmek için dönüştürücüde bir test yapabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'e Seçeneklerle Dönüştür**

Aspose.Slides, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfı altında bulunan özelleştirilebilir seçenekler‑özellikler sunar; bu sayede PDF’yi (dönüşüm sürecinin sonucunu) özelleştirebilir, PDF’yi şifreyle kilitleyebilir veya dönüşüm sürecinin nasıl ilerleyeceğini belirtebilirsiniz.

### **PowerPoint'i PDF'e Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile’ların nasıl ele alınacağını seçebilir, metin sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI belirleyebilirsiniz vb.

Aşağıdaki örnek, bir sunumu PDF 1.5 formatında, JPEG kalitesi 90, görüntü çözünürlüğü 300 DPI, metafile’lar PNG olarak kaydedilmiş ve Flate metin sıkıştırması uygulanmış şekilde dışa aktarır.

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

### **Görüntü Sıkıştırmasını Otomatik Olarak Seç**

Sunumda çok sayıda fotoğraf veya ekran görüntüsü olduğunda, dışa aktarılan PDF’nin boyutunu küçültmek, e‑posta ile gönderilmesini veya indirilmesini kolaylaştırır. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) özelliğini `True` yapın.

Aşağıdaki örnek mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve PDF belge olarak kaydeder. Diğer tüm PDF dışa aktarım ayarları varsayılan değerlerini korur.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Bu seçenek, her görüntü için bir sıkıştırma algoritması seçer. [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) değerini düşürmek JPEG görüntü kalitesini azaltırken, [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) değerini düşürmek görüntülerin daha düşük çözünürlüğe indirgenmesini sağlar; bu da ayrıntıyı azaltabilir. Otomatik sıkıştırma seçiminin etkinleştirilmesi, bu ayarları doğrudan düşürmez.

Görüntü sıkıştırma algoritmalarını seçmek ek işlem süresi ve bellek gerektirir. Boyut azalması, sunumdaki görüntülere ve dışa aktarım ayarlarına bağlıdır; her sunum için sabit bir azalma garantilenmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem slaytları hem de çalışma kitabının verilerini görmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF’de ek olarak saklamak için [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) özelliğini `True` yapın.

Varsayılan değer `False`’tur: OLE nesnesinin önizleme resmi veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak eklenmez. Özelliği `True` yaparsanız dosya verisi de eklenir. Önizleme görsel temsili olarak kalır; ek, alıcıların gömülü dosyayı ayrı olarak açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabını ekli olarak PDF’ye dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Sonucu kontrol etmek için:

1. PDF’yi ekleri destekleyen bir görüntüleyicide açın (ör. Adobe Acrobat Reader).
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel’de açarak verileri inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme, ekten ayrı bir unsur olarak kalır.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler konusunda kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir, PDF/A-3 ise Excel çalışma kitapları da dahil olmak üzere diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides’e özgü kısıtlamalar değildir. Bu örnek, varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarımını göstermez.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'e Dönüştür**

Sunumda gizli slaytlar varsa, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfındaki [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini kullanarak Aspose.Slides’ın gizli slaytları da sonuç PDF’de sayfa olarak eklemesini sağlayabilirsiniz.

Aşağıdaki örnek, gizli slaytları da içerecek şekilde bir sunumu PDF’e dışa aktarır.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint'i Şifre Korumalı PDF'e Dönüştür**

Aşağıdaki örnek, `password` şifresiyle açılması gereken bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kalite baskı dahil olmak üzere baskıya izin verir.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ayrı Bir Kalın Yazı Tipi Olmadan Yazı Tiplerini İşleme**

Bir sunum, kalın bir yazı tipine sahip olmayan bir fontta kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma ile kalın görünebilir; bu, normal glifleri yapay olarak kalınlaştırır. PDF’de metin çok ağır görünüyorsa veya istenilen görünümden farklıysa, [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) özelliğini `True` yapmayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında etkilenmiş metni bitmap olarak işler ve belirli fontlar için görünümünü iyileştirebilir. Varsayılan değeri `False`’tur.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı fontta, ancak ayrı bir kalın tipine sahip olmayan metni kalın biçimlendirmeye sahiptir. Aşağıdaki örnek sunumu yükler, desteklenmeyen yazı tipi stillerinin rasterleştirilmesini etkinleştirir ve PDF’ye dışa aktarır:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Aşağıdaki ön izlemeler, devre dışı ve etkin çıktıyı gösterir. Bu örnekte, kalın metin, seçenek devre dışı iken daha kalın çizgilere sahiptir. Seçenek etkinleştirildiğinde çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`False`, varsayılan) | Seçenek etkin (`True`) |
|---|---|
| ![Desteklenmeyen yazı tipi stili rasterleştirme devre dışı bırakılmış PDF](unsupported-bold-disabled.png) | ![Desteklenmeyen yazı tipi stili rasterleştirme etkin PDF](unsupported-bold-enabled.png) |

Bu örnekte, seçenek etkinleştirildiğinde yalnızca kalın metin bitmap’e dönüştürülür: OCR olmadan seçilemez, kopyalanamaz veya aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı bırakıldığında iki metin de metin olarak kalır.

Bu seçenek, fontun ayrı bir kalın tipine sahip olmadığı durumlarda kalın olarak biçimlendirilmiş metni rasterleştirir. [Font substitution](/slides/tr/python-net/font-substitution/) ise orijinal font bulunamadığında başka bir font seçer.

## **PowerPoint'te Seçili Slaytları PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF’e dışa aktarır. Bu dizi içindeki slayt numaraları 1‑tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Özel Slayt Boyutu ile PDF'e Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 point (8.5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar, slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF’e dışa aktarır.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Yeni sunum oluşturulurken eklenen boş slaytı kaldır.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'e Dönüştür**

Aşağıdaki örnek, her slaytın konuşmacı notlarını slaytın altında göstererek sunumu PDF’e dışa aktarır. Sonucu görmek için not içeren bir sunum kullanın.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Aşağıdaki uyumluluk standartlarından herhangi birini kullanarak bir PowerPoint belgesini PDF’ye dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu Python kodu, farklı uyumluluk standartlarına göre birden çok PDF elde eden bir PowerPoint‑to‑PDF dönüşüm operasyonunu gösterir:

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
Aspose.Slides, PDF dönüşüm işlemlerini en popüler dosya formatlarına çevirebilmenizi sağlar. [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) dönüşümleri desteklenir. Ayrıca, [PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) gibi uzman formatlara dönüşümler de mevcuttur.
{{% /alert %}}

> **Not:** PDF/UA’ya dışa aktarırken, Aspose.Slides karmaşık grafikleri (SmartArt, grafikler, formüller) tek bir şekil olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekle uygulanır.

## **SSS**

**Aspose.Slides for Python PDF’den uygulama bilgilerini kaldırabilir mi?**

Hayır, Aspose.Slides for Python çıktı PDF’sine API bilgisi ve sürüm numarasını otomatik olarak ekler. Bu bilgi değiştirilemez veya kaldırılamaz.

**PDF dönüşümünde yalnızca belirli slaytları nasıl dahil edebilirim?**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) yöntemine slayt konumlarını içeren bir dizi geçirerek dönüştürmek istediğiniz slayt indekslerini belirtebilirsiniz.

**Dönüşüm sırasında PDF’yi şifreyle korumak mümkün mü?**

Evet, PDF’yi kaydetmeden önce [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sınıfını kullanarak bir şifre belirleyebilir ve erişim izinlerini tanımlayabilirsiniz.

**Aspose.Slides PDF’yi diğer formatlara dönüştürmeyi destekliyor mu?**

Evet, Aspose.Slides PDF’leri HTML, görüntü formatları (JPG, PNG), SVG, TIFF ve XML gibi formatlara dönüştürebilir.

**PDF’imin erişilebilirlik standartlarına uygun olmasını nasıl sağlayabilirim?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içindeki [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) özelliğini `PDF_A1A`, `PDF_A1B` veya `PDF_UA` gibi standartlara ayarlayarak erişilebilirlik yönergelerine uyumu sağlayabilirsiniz.

**Gizli slaytları PDF çıktısına ekleyebilir miyim?**

Evet, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içinde [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) özelliğini `True` yaparsanız gizli slaytlar PDF’ye dahil edilir.

**Dönüşüm sırasında görüntü kalitesi ve çözünürlüğünü nasıl ayarlarım?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) içindeki [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) ve [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) özelliklerini kullanarak sonuç PDF’deki görüntü kalitesi ve çözünürlüğünü kontrol edebilirsiniz.

**Aspose.Slides yazı tipi değişimlerini otomatik olarak yönetiyor mu?**

Aspose.Slides dönüşüm sırasında yazı tipi değişimlerini algılar ve bunları `warning_callback` özelliğiyle (şu anda sınırlı) ele almanıza olanak tanır.

## **Ek Kaynaklar**

- [Aspose.Slides for Python via .NET Documentation](/slides/tr/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)