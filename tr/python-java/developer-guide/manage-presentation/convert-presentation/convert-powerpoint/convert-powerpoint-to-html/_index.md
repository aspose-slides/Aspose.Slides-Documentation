---
title: PowerPoint Sunumlarını Python üzerinden Java ile HTML’e Dönüştürün
linktitle: PowerPoint'tan HTML’e
type: docs
weight: 30
url: /tr/python-java/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan HTML’e
- sunumu HTML’e
- slaytı HTML’e
- PPT'den HTML’e
- PPTX'den HTML’e
- PowerPoint'ı HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'e dışa aktar
- PPTX'i HTML'e dışa aktar
- Python
- Java
- Aspose.Slides
description: "PowerPoint sunumlarını Python üzerinden Java ile HTML'e dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüştürme, tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yüklemesi ve [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısı ile [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) kullanılmasıdır. Dışa aktarılan düzeni, yazı tiplerini, görüntüleri, notları, yorumları, SVG çıktısını veya bağlantılı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarma senaryolarına odaklanır:

- Tam bir sunumu veya seçili slaytları dışa aktar.
- Sabit düzenli, duyarlı veya SVG tabanlı HTML oluştur.
- Konuşmacı notlarını ve yorumları ekle.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazıldığını ve referans verildiğini seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu tek bir HTML belgesi üretir. Bu, tek bir dosyayı paylaşmak için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir bir şekilde bulunmayan yazı tiplerini yalnızca gömerek dikkate alın.

## **Sunumu HTML'e Dönüştür**

Bir sunumu HTML olarak dışa aktarmak için, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Html) ile kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Her örnek, `presentation.pptx` dosyasını geçerli çalışma dizininden yükler. Çalıştırmadan önce Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanı kurun. JVM, Python süreci başına bir kez başlatılır.

Bu örnek tek bir HTML dosyası yazar. Sunum nesnesi, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakan `finally` bloğunda yok edilir.

## **HTML Dışa Aktarmayı Yapılandırma**

[HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): notlar, yorumlar, el kitapları veya diğer düzen bilgilerini ekler.
- [setHtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- [setSlideImageFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlideImageFormat): slaytların nasıl temsil edildiğini değiştirir, örneğin SVG olarak.
- [setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression): görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): kırpılmış görüntü verilerini tutar veya kaldırır.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): dışa aktarılan SVG içeriğinin konteynerine uyum sağlamasını sağlar.
- [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler, iş akışınızın ihtiyaç duyduğu seçenekleri yalnızca birleştirmenize olanak tanıyacak şekilde en yaygın seçenekleri ayrı ayrı gösterir.

## **Seçili Slaytları HTML'e Dönüştür**

[Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) slayt numaralarını kabul eden aşırı yükleme, 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Her slayt için bir HTML sayfasına ihtiyaç duyulan bir web sitesi ya da uygulama olduğunda bu modeli kullanın. Her slayt aynı düzeni paylaşmalıysa, bir [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) örneği oluşturun ve bunu her [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısına iletin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde bunu kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

SVG tabanlı duyarlı düzen için, `[HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)` metodunu `True` ile çağırın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Konuşmacı Notlarını ve Yorumları Dahil Et**

Konuşmacı notlarını veya yorumları dahil etmek için, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) aracılığıyla [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) kullanın. Notlar ve yorumlar, konumları seçilmediği sürece varsayılan olarak gizlidir.

Kaynak sunumun konuşmacı notları içerdiğini varsayalım:

![PowerPoint'te konuşmacı notlarıyla slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında konuşmacı notlarıyla dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

![Slayt ve konuşmacı notlarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için, [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) metodunu, örneğin [CommentsPositions.Right](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentspositions/#Right) veya [CommentsPositions.Bottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentspositions/#Bottom) ile çağırın. Yalnızca yorumlara ihtiyacınız varsa, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodunu atlayın. Hem not hem de yorum gerekiyorsa, her iki yöntemi de çağırın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Et**

HTML dışa aktarımı, slayt görüntülerini sıkıştırarak çıktı boyutunu azaltabilir. Daha yüksek görüntü kalitesine ihtiyaç duyduğunuzda, [PicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturescompression/) üzerinden bir değer sağlayarak [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) metoduna geçirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Varsayılan olarak, görüntülerin kırpılmış bölgeleri dışa aktarılan sonuçtan kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri getirebilmesi veya inceleyebilmesi gerektiğinde kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS Ekle**

Basit stil için, bir CSS dizesini [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) metoduna iletin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Özel bir belge başlığı, bağlantılı bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için, JPype arayüz vekili üzerinden özelleştirilmiş bir biçimlendirme denetleyicisi kullanın ve bunu [HtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/) ile birlikte [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/#createCustomFormatter) metoduna iletin.

## **Yazı Tiplerini Göm**

Hedef ortamda sunumun yazı tipleri yüklü olmayabilir; bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embedallfontshtmlcontroller/) ile HTML içinde yazı tiplerini gömün. Gömme, görsel doğruluğu artırır ancak çıktı boyutunu yükseltir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten bu tipleri sağladığından emin olduğunuzda dışarıda bırakın. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Kaynakları Dışarıda Kaydet**

Kapsamlı HTML taşınması kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanız harici görüntü dosyalarına ihtiyaç duyuyorsa, JPype arayüz vekili üzerinden bir kaynak bağlama denetleyicisi uygulayın ve bunu [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) yapıcısına iletin.

Kaynakları dışa aktardığınızda, iki yolu bilinçli seçin:

- Uygulamanızın oluşturulan görüntü, yazı tipi, ses veya video dosyalarını yazdığı dosya sistemi çıktı yolu.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yoldur.

## **Medya Dosyalarını Dışa Aktar**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve bunları bir tarayıcıda oynatabilen HTML yazar. Yapıcısı şunları alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML içinde medya dosyalarına bağlantı için kullanılan mutlak URI öneki.

Aşağıdaki örnek, `presentation.pptx` içinde zaten gömülü medyayı dışa aktarır. Oluşturulan HTML, medya dosyalarına yalnızca dosya adıyla, HTML belgesine göreceli olarak referans verir; bu yüzden `path` HTML dosyasını da alan dizin olmalıdır. `baseUri` mutlak bir URI olmalıdır: yerel ön izleme için çıktı dizininden bir `file:///` URI oluşturun; dağıtılmış bir uygulama için yayınlanan dizinin mutlak URL'sini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

İhracat işi başına benzersiz çıktı dizinleri kullanın, özellikle sunucu uygulamalarında. Paylaşılan çıktı yolları, farklı dönüşümlerin dosyalarının birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemdir; bu nedenle işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medyaya bağlıdır. [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) üzerinden geçirilen yüksek görüntü DPI değerleri, gömülü yazı tipleri, SVG çıkışı ve tutulan kırpılmış görüntü alanları doğruluğu artırabilir ancak genellikle çıktı boyutunu yükseltir.

Toplu dönüştürme için:

- Her [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini mümkün olan en kısa sürede dispose edin.
- Farklı işler için ayrı çıktı dizinleri kullanın.
- Görünüm doğruluğu gerektirmedikçe ortak yazı tiplerini gömmekten kaçının.
- HTML önizleme ya da küçük resimler için görüntü DPI'sını düşürün.
- Dağıtım yolları kesinleşene kadar kaynak sunumu, oluşturulan HTML ve harici kaynakları birlikte tutun.

## **SSS**

**HTML çıktısında bağlantılar korunur mu?**

Evet. Sunum bağlantıları HTML'e dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'e dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [çok iş parçacıklı kullanım rehberi](/slides/tr/python-java/multithreading/) sayfasına bakın.

**Sunum nesnesi çoklu iş parçacığı için güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği aynı iş parçacığında yüklenmeli, değiştirilip, kaydedilip ve dispose edilmelidir. Paralel çalışmada, her iş parçacığı veya süreç için bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarma, kaynakları doğrudan HTML içinde gömebilir. Gömülü yazı tipleri, yüksek DPI görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı daha önemli olduğunda harici kaynakları kullanın, ortak yazı tiplerini gömmekten vazgeçin ve daha düşük bir DPI değeri geçmek için [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) metodunu kullanın.

**HTML'deki font-size değerleri PowerPoint değerlerinden neden farklı olabilir?**

Dışa aktarılan sayfa SVG koordinat sistemleri ve ölçek dönüşümleri kullanabilir. Yalnızca ham bir CSS veya SVG font-size değeri nihai görüntülenen boyutu açıklamaz. İstenen yakınlaştırma seviyesinde render edilen slaytı karşılaştırın ve metin farklı görünüyorsa yazı tipi kullanılabilirliğini kontrol edin.

**Medya dışa aktarımı için baseUri nasıl seçilmeli?**

`baseUri`yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak iletin. Yerel ön izleme için `output_directory.as_uri() + "/"` ifadesiyle türetebilirsiniz. Dağıtımda, yayınlanan dizinin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değil, ancak aynı konumu tanımlamalı ve bu konum, oluşturulan HTML dosyasının bulunduğu dizin olmalıdır; çünkü medya bağlantıları ona göre göreceli olarak yazılır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) metodunu `True` ile çağırın.