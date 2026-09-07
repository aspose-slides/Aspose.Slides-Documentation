---
title: PowerPoint Sunumlarını Python ile Java üzerinden HTML'ye Dönüştürme
linktitle: PowerPoint'ten HTML'ye
type: docs
weight: 30
url: /tr/python-java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint sunumlarını HTML'ye dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, resimleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yüklemesi ve bir [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısı ile [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) kullanımıdır. Dışa aktarım düzeni, yazı tipleri, resimler, notlar, yorumlar, SVG çıktısı veya bağlı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarım senaryolarına odaklanır:

- Tüm sunumu veya seçili slaytları dışa aktar.
- Sabit‑dizilim, duyarlı veya SVG‑tabanlı HTML oluştur.
- Sunum notları ve yorumları dahil et.
- Resim kalitesini ve kırpılmış resim verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Dış kaynakların ve medya dosyalarının nasıl yazılıp referans verileceğini seç.

Varsayılan olarak, HTML dışa aktarımı çoğu kaynağın gömülü olduğu, tek bir HTML belgesi üretir. Bu, tek bir dosyayı paylaşmak için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için dış kaynakları, daha düşük resim DPI değerlerini ve hedef ortamda güvenilir olarak bulunmayan yazı tiplerini yalnızca gömmeyi değerlendir.

## **Bir Sunumu HTML’ye Dönüştürme**

Bir sunumu HTML’ye dışa aktarmak için, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Html) ile kaydedin.

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

Her örnek, geçerli çalışma dizinindeki `presentation.pptx` dosyasını yükler. Çalıştırmadan önce Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanı kurun. JVM, Python süreci başına bir kez başlatılır.

Bu örnek tek bir HTML dosyası yazar. Sunum nesnesi `finally` bloğunda serbest bırakılır; bu, dışa aktarımdan sonra dosya tutamaçlarını ve render kaynaklarını serbest bırakır.

## **HTML Dışa Aktarımını Yapılandırma**

[HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunlardır:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): notlar, yorumlar, el ilanları veya diğer düzen bilgilerini ekler.
- [setHtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- [setSlideImageFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlideImageFormat): slaytların temsil biçimini değiştirir, örneğin SVG olarak.
- [setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression): resim DPI ve çıktı boyutunu kontrol eder.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): kırpılmış resim verilerini tutar veya kaldırır.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- [setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler en yaygın seçenekleri ayrı ayrı gösterir; böylece iş akışınız için gerekenleri birleştirebilirsiniz.

## **Seçili Slaytları HTML’ye Dönüştürme**

Slayt numaralarını kabul eden [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) aşırı yüklemesi 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü, her slaytı ayrı bir HTML dosyasına kaydeder.

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

Bir web sitesi veya uygulama her slayt için bir HTML sayfasına ihtiyaç duyduğunda bu modeli kullanın. Her slayt aynı düzeni kullanacaksa, tek bir [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) örneği oluşturun ve bunu her [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısına geçirin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfa tarayıcı genişliğine daha iyi uyum sağlamalıysa bunu kullanın.

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

SVG tabanlı duyarlı düzen için, `True` ile [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) çağırın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında faydalıdır.

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

## **Sunum Notları ve Yorumları Dahil Etme**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) aracılığıyla [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) kullanarak sunum notlarını veya yorumları dahil edin. Notlar ve yorumlar varsayılan olarak gizlidir; konumlarını seçmediğiniz sürece görünmezler.

Kaynak sunumda sunum notları olduğunu varsayalım:

![Notlu slayt PowerPoint’te](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında notlarla dışa aktarır.

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

Dışa aktarılan HTML, not bölgesini içerir:

![HTML çıktısı, slayt ve notlarla](HTML_with_notes.png)

Yorumları dışa aktarmak için, örneğin [CommentsPositions.Right](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentspositions/#Right) veya [CommentsPositions.Bottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentspositions/#Bottom) ile [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) çağırın. Yalnızca yorumlara ihtiyacınız varsa, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodunu atlayın. Hem not hem de yorum istiyorsanız, her iki yöntemi de çağırın.

## **Resim Kalitesini ve Kırpılmış Alanları Kontrol Etme**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt resimlerini sıkıştırabilir. Daha yüksek resim kalitesi gerektiğinde, [PicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturescompression/) üzerinden bir değerle [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) geçirin.

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

Varsayılan olarak, dışa aktarılan çıktıda resimlerin kırpılmış alanları kaldırılabilir. Kullanıcıların bu gizli resim parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde yalnızca kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

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

## **CSS Ekleme**

Basit stil uygulaması için, [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) metoduna bir CSS dizesi geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

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

Özel bir belge başlığı, bağlı bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme eklemek istiyorsanız, bir JPype arabirim vekili aracılığıyla özel bir formatlama denetleyicisi oluşturun ve bunu [HtmlFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/) ile [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmlformatter/#createCustomFormatter) ile geçirin.

## **Yazı Tiplerini Gömme**

Hedef ortamda sunum yazı tipleri kurulu olmayabilir; bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/embedallfontshtmlcontroller/) ile yazı tiplerini HTML’ye gömün. Gömme görsel tutarlılığı artırır ancak çıktı boyutunu büyütür.

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

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten bunları sağladığından emin olduğunuzda dışarıda bırakın. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Kaynakları Dışa Kaydetme**

Kendi içinde bütünleşik HTML taşınması kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanız dış resim dosyalarına ihtiyaç duyuyorsa, bir JPype arabirim vekili aracılığıyla bir kaynak‑bağlantı denetleyicisi uygulayın ve bunu [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) yapıcı aracılığıyla geçirin.

Kaynakları dışa aktarırken iki yolu kasıtlı olarak seçin:

- Dosya sistemi çıktı yolu: uygulamanızın oluşturulan resimleri, yazı tiplerini, ses ve video dosyalarını yazdığı yer.
- URL yolu: tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yol.

## **Medya Dosyalarını Dışa Aktarma**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve bunların tarayıcıda oynatılabileceği HTML yazar. Yapıcı şu parametreleri alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: medya dosyalarına HTML bağlantılarında kullanılacak mutlak URI öneki.

Aşağıdaki örnek, `presentation.pptx` içinde zaten gömülü medyayı dışa aktarır. Oluşturulan HTML, medya dosyalarına yalnızca dosya adıyla, HTML belgesine göre göreli olarak referans verir; bu nedenle `path` aynı zamanda HTML dosyasının da yazıldığı dizin olmalıdır. `baseUri` mutlak bir URI olmalıdır: yerel ön izleme için çıktı dizininden bir `file:///` URI oluşturun; dağıtılmış bir uygulama için yayınlanan dizinin mutlak URL’sini kullanın.

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

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Ortak çıktı yolları, farklı dönüşümlerin dosyalarını birbirinin üzerine yazabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemidir; işleme süresi ve bellek kullanımı slayt sayısına, resim çözünürlüğüne, yazı tiplerine, efektlere, grafiklere ve gömülü medyaya bağlıdır. Daha yüksek DPI değerleriyle [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) kullanmak, gömülü yazı tipleri, SVG çıktısı ve korunmuş kırpılmış resim alanları sadakati artırabilir ancak genellikle çıktı boyutunu büyütür.

Toplu dönüşüm için:

- Her [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini hızlıca serbest bırakın.
- Farklı işler için ayrı çıktı dizinleri kullanın.
- Sadakat gerektirmediği sürece ortak yazı tiplerini gömmekten kaçının.
- HTML ön izleme veya küçük resimler için resim DPI değerini düşürün.
- Dağıtım yolları kesinleşene kadar kaynak sunumu, oluşturulan HTML ve dış kaynakları birlikte tutun.

## **SSS**

**HTML çıktısında köprüler korunuyor mu?**

Evet. Sunum köprüleri HTML’ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML’ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [çoklu iş parçacığı kılavuzuna](/slides/tr/python-java/multithreading/) bakın.

**Sunum nesnesi iş parçacığı güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği bir iş parçacığında yüklenmeli, değiştirilmeli, kaydedilmeli ve serbest bırakılmalıdır. Paralel çalışma için iş parçacığı başına bağımsız bir örnek oluşturun veya ayrı bir süreç kullanın.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım, kaynakları doğrudan HTML içinde gömer. Gömülü yazı tipleri, yüksek DPI’lı resimler, medya, SVG içeriği ve korunmuş kırpılmış resim alanları da boyutu artırır. Daha küçük çıktı gerekiyorsa dış kaynakları kullanın, ortak yazı tiplerini dışarıda bırakın ve [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setPicturesCompression) ile daha düşük DPI değeri geçirin.

**HTML’deki font-size değerleri PowerPoint değerlerinden neden farklı?**

Dışa aktarılan sayfa, SVG koordinat sistemleri ve ölçekleme dönüşümleri kullanabilir. Tek bir CSS veya SVG font-size değeri, nihai görüntülenen boyutu tam olarak tanımlamaz. Slaytı istenen yakınlaştırma seviyesinde karşılaştırın ve metin farklı görünüyorsa yazı tipi bulunabilirliğini kontrol edin.

**Medya dışa aktarımı için baseUri nasıl seçilmeli?**

Tarayıcının bakış açısından `baseUri` seçin ve mutlak bir URI olarak geçirin. Yerel ön izleme için, çıktı dizininden `output_directory.as_uri() + "/"` gibi bir değer türetebilirsiniz. Dağıtımda, yayınlanan dizinin mutlak URL’sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı konumu tanımlamalıdır; bu konum, medya bağlantılarının göreli olarak yazıldığı HTML dosyasının bulunduğu dizin olmalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) metodunu `True` ile çağırın.