---
title: Python'da PowerPoint Sunumlarını HTML'ye Dönüştürme
linktitle: PowerPoint'ten HTML'ye
type: docs
weight: 30
url: /tr/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten HTML'ye
- sunumu HTML'ye
- slaytı HTML'ye
- PPT'yi HTML'ye
- PPTX'i HTML'ye
- PowerPoint'i HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'ye dışa aktar
- PPTX'i HTML'ye dışa aktar
- Python
- Aspose.Slides
description: "Python'da PowerPoint sunumlarını HTML'ye dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görselleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) ile bir `save` çağrısıdır. Dışa aktarılan düzeni, yazı tiplerini, resimleri, notları, yorumları, SVG çıktısını veya bağlı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarım senaryolarına odaklanır:

- Tam bir sunumu veya seçili slaytları dışa aktar.
- Sabit düzenli, duyarlı veya SVG tabanlı HTML oluştur.
- Sunucu notlarını ve yorumları ekle.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazılacağını ve başvurulacağını seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu tek bir HTML belgesi üretir. Tek bir dosyayı paylaşmak için uygundur, ancak çıkış boyutunu artırabilir. Web yayıncılığı için, harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir şekilde bulunmayan yazı tiplerini sadece gömmeyi düşünün.

## **Bir Sunumu HTML'ye Dönüştürme**

Bir sunumu HTML olarak dışa aktarmak için, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) ile yükleyin ve [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) ile kaydedin.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Bu örnek bir HTML dosyası yazar. `with` ifadesi, sunum nesnesini temizler ve dışa aktarımdan sonra dosya tutucularını ve işleme kaynaklarını serbest bırakır.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) , HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- `slides_layout_options`: notlar, yorumlar, el ilanları veya diğer düzen bilgilerini ekler.
- `html_formatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `slide_image_format`: slaytların temsili şeklini değiştirir, örneğin SVG olarak.
- `pictures_compression`: görüntü DPI'sını ve çıkış boyutunu kontrol eder.
- `delete_pictures_cropped_areas`: kırpılmış görüntü verilerini tutar veya kaldırır.
- `svg_responsive_layout`: dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- `show_hidden_slides`: gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler, en yaygın seçenekleri ayrı ayrı gösterir, böylece iş akışınızın ihtiyaç duyduğu seçenekleri yalnızca birleştirebilirsiniz.

## **Seçili Slaytları HTML'ye Dönüştürme**

`save` aşırı yüklemesi, slayt numaralarını kabul eder ve 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Bir web sitesi veya uygulamanın her slayt için bir HTML sayfasına ihtiyacı olduğunda bu deseni kullanın. Eğer her slayt aynı düzeni paylaşacaksa, bir [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) örneği oluşturun ve her `save` çağrısına geçirin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/responsivehtmlcontroller/) , [HtmlFormatter](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde bunu kullanın.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) üzerinde `svg_responsive_layout` ayarlayın. Slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında bu kullanışlıdır.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Sunucu Notları ve Yorumları Dahil Etme**

`html_options.slides_layout_options` aracılığıyla [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) kullanarak sunucu notlarını veya yorumları dahil edin. Notlar ve yorumlar varsayılan olarak gizlidir, konumlarını seçmedikçe.

Kaynak sunumun sunucu notları içerdiğini varsayalım:

![PowerPoint'te sunucu notları içeren slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında sunucu notlarıyla dışa aktarır.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Dışa aktarılan HTML, not alanını içerir:

![Slayt ve sunucu notlarıyla HTML çıktısı](HTML_with_notes.png)

HTML dışa aktarımı, daha yüksek görüntü kalitesi gerektiğinde [PicturesCompression](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/picturescompression/) içinden bir değere `pictures_compression` ayarlayın.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktıda kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSS Ekleme**

Basit stil vermek için bir CSS dizesini [HtmlFormatter](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmlformatter/)’a aktarın. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Özel bir belge başlığı, bağlı bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için, özel bir biçimlendirme denetleyicisi kullanın ve bunu `create_custom_formatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmlformatter/)’a geçirin.

## **Yazı Tiplerini Gömme**

Hedef ortam sunum yazı tiplerini kurulu olmayabilir, bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/embedallfontshtmlcontroller/) ile HTML içinde yazı tiplerini gömün. Gömme, görsel doğruluğu artırır ancak çıkış boyutunu yükseltir.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Sadece hedef tarayıcıların veya sistemlerin yazı tipini zaten sağladığından emin olduğunuzda bir yazı tipini dışarıda bırakın. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Gömme Yerine Bağlantı Verme**

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML’ye `@font-face` kuralları ekleyebilirsiniz. Bu, dışa aktarım sırasında yazı tipi verilerinin nasıl yazıldığını özelleştiren bir denetleyici gerektirir. Python via .NET’te, bu denetleyiciyi küçük bir .NET yardımcı derlemesinde uygulayın, Python’da yükleyin ve yardımcı nesneyi `create_custom_formatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmlformatter/)’a geçirin.

Yazı tiplerini dışa aktardığınızda, iki yolu bilinçli olarak seçin:

- Oluşturulan WOFF dosyalarının yazılacağı dosya sistemi çıktı dizini.
- HTML belgesinde görünecek ve tarayıcının bu yazı tipi dosyalarını yüklemek için kullanacağı URL yolu.

HTML dosyasını ve oluşturulan yazı tipi dosyalarını dağıtım yolları kesinleşene kadar birlikte tutun. Dosyalar başka bir konuma dağıtılırsa, URL ön ekinin dağıtılan URL yolu ile eşleşmesini sağlayın.

## **Kaynakları Dışarıda Kaydetme**

Tek başına HTML taşınması kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanız harici görüntü, yazı tipi, ses veya video dosyalarına ihtiyaç duyuyorsa, özel bir bağlantı/ekleme denetleyicisi kullanın ve bunu [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) yapıcısına geçirin.

Kaynakları dışa aktarırken iki yolu bilinçli olarak seçin:

- Uygulamanızın oluşturulan görüntüleri, yazı tiplerini, sesleri veya videoları yazdığı dosya sistemi çıktı yolu.
- HTML belgesinden tarayıcının bu dosyaları yüklemek için kullandığı URL yolu.

Tam bir görüntü bağlama tartışması için, [Export Presentations to HTML with Externally Linked Images](/slides/tr/python-net/exporting-presentations-to-html-with-externally-linked-images/) bölümüne bakın.

## **Medya Dosyalarını Dışa Aktarma**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/videoplayerhtmlcontroller/) , video ve ses dosyalarını dışa aktarır ve bir tarayıcıda oynatabilecek HTML yazar. Yapıcı şu parametreleri alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `file_name`: oluşturulan HTML dosyasının adı.
- `base_uri`: medya dosyalarına HTML bağlantılarında kullanılan mutlak URI ön eki.

HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydedildiyse, `path` diskteki medya dizinine işaret etmelidir, `base_uri` ise tarayıcının bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için, medya dizininden bir `file:///` URI oluşturabilirsiniz. Dağıtılan bir uygulama için, yayınlanan medya dizininin mutlak URL'sini kullanın.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları, farklı dönüşümlerden gelen dosyaların birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir renderleme işlemidir, bu yüzden işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medyaya bağlıdır. Daha yüksek `pictures_compression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları doğruluğu artırabilir ancak genellikle çıkış boyutunu artırır.

Toplu dönüştürme için:

- Her [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini hızlıca Dispose edin.
- Farklı işler için ayrı çıktı dizinleri kullanın.
- Doğruluk gerektirmedikçe ortak yazı tiplerini gömmekten kaçının.
- HTML önizleme veya küçük resimler için olduğunda görüntü DPI'sını düşürün.
- Kaynak sunumu, oluşturulan HTML ve harici kaynakları dağıtım yolları kesinleşene kadar birlikte tutun.

## **SSS**

**HTML çıktısında köprüler korunuyor mu?**

Evet. Sunum köprüleri HTML'e dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [multithreading guidance](/slides/tr/python-net/multithreading/) bölümüne bakın.

**Presentation nesnesi çok iş parçacıklı kullanım için güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği bir iş parçacığı üzerinde yüklenmeli, değiştirilip, kaydedilmeli ve dispose edilmelidir. Paralel çalışma için, iş parçacığı başına bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım, kaynakları doğrudan HTML içinde gömebilir. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı, en yüksek doğruluktan daha önemli olduğunda harici kaynakları kullanın, ortak yazı tiplerini gömmekten çıkarın ve `pictures_compression` değerini düşürün.

**PowerPoint'teki 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak neden gözüküyor?**

Bu, PowerPoint ve HTML'in farklı DPI modelleri kullanmasından kaynaklanabilir. PowerPoint, metin boyutlarını 72 DPI temelli tipografik puanlarla saklarken, HTML düzeni 96 DPI modelinde CSS pikseline dayanır. Aspose.Slides bir sunumu HTML'ye dışa aktardığında, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farkları ortaya çıkarabilir.

Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Yalnızca PowerPoint ve HTML arasında metin ölçümlerinin dönüştürülmesinden kaynaklanan matematiksel bir yan etkidir.

**Medya dışa aktarımı için base_uri nasıl seçilmeli?**

`base_uri`yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak geçirin. Yerel önizleme için, çıktı dizininden `Path(media_directory).as_uri() + "/"` ile türetebilirsiniz. Dağıtım için, yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `base_uri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) üzerinde `show_hidden_slides = True` ayarlayın.