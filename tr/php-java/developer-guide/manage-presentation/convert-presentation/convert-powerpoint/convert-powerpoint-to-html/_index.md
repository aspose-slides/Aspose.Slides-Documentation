---
title: PowerPoint Sunumlarını PHP'de HTML'ye Dönüştür
linktitle: PowerPoint'ten HTML'ye
type: docs
weight: 30
url: /tr/php-java/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'ten HTML'ye
- PowerPoint'i HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'ye aktar
- PPTX'i HTML'ye aktar
- PHP
- Aspose.Slides
description: "PHP'de PowerPoint sunumlarını HTML'ye dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, resimleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) ile bir `save` çağrısıdır. Dışa aktarılan düzeni, yazı tiplerini, resimleri, notları, yorumları, SVG çıktısını veya bağlı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarım senaryolarına odaklanır:

- Tüm bir sunumu veya seçilmiş slaytları dışa aktar.
- Sabit düzenli, duyarlı veya SVG tabanlı HTML oluştur.
- Konuşmacı notlarını ve yorumları dahil et.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazılacağını ve başvurulacağını seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu bağımsız bir HTML belgesi üretir. Tek bir dosya paylaşmak için bu uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir şekilde bulunmayan yazı tiplerini yalnızca gömmeyi değerlendirin.

## **Bir Sunumu HTML'ye Dönüştürme**

Bir sunumu HTML'ye dışa aktarmak için, onu [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) ile kaydedin.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Bu örnek bir HTML dosyası yazar. Sunum nesnesi, dışa aktarmadan sonra dosya tutucuları ve render kaynaklarını serbest bırakan `finally` bloğunda yok edilir.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- `SlidesLayoutOptions`: notlar, yorumlar, el kitapçıkları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların nasıl temsil edileceğini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verilerini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler en yaygın seçenekleri ayrı ayrı gösterir, böylece iş akışınızın gerektirdiği yalnızca gerekli seçenekleri birleştirebilirsiniz.

## **Seçili Slaytları HTML'ye Dönüştürme**

Slayt numaralarını kabul eden `save` aşırı yüklemesi 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Bir web sitesi veya uygulamanın slayt başına bir HTML sayfasına ihtiyacı olduğunda bu deseni kullanın. Her slayt aynı düzene sahip olmalıysa bir [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) örneği oluşturun ve her `save` çağrısına geçirin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde bunu kullanın.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) üzerinde `SvgResponsiveLayout` ayarlayın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında faydalıdır.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Konuşmacı Notları ve Yorumları Dahil Etme**

Konuşmacı notlarını veya yorumları eklemek için `HtmlOptions.SlidesLayoutOptions` aracılığıyla [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) kullanın. Notlar ve yorumlar varsayılan olarak gizlidir; konumlarını seçmediğiniz sürece görünmez.

Kaynak sunumun konuşmacı notları içerdiğini varsayalım:

![PowerPoint'te konuşmacı notlarıyla slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında konuşmacı notlarıyla dışa aktarır.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

![Slayt ve konuşmacı notlarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın, örneğin `CommentsPositions.Right` veya `CommentsPositions.Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` özelliğini atlayın. Hem notları hem de yorumları istiyorsanız her iki özelliği de ayarlayın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Etme**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyacınız olduğunda `PicturesCompression` değerini [PicturesCompression](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturescompression/)‘den bir değerle ayarlayın.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktıda kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri getirebilmesi veya inceleyebilmesi gerektiğinde kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **CSS Ekleme**

Basit stillendirme için, `createDocumentFormatter` aracılığıyla bir CSS dizesini [HtmlFormatter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmlformatter/)’a geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevredeki HTML belgesini değiştirir.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Özel bir belge başlığı, bağlanmış bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için, özel bir biçimlendirme denetleyicisi kullanın ve bunu `createCustomFormatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmlformatter/)’a geçirin.

## **Yazı Tiplerini Gömme**

Hedef ortam sunum yazı tiplerini kurulu olmayabileceği durumlarda, [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/embedallfontshtmlcontroller/) ile yazı tiplerini HTML'ye gömün. Gömme görsel sadakati artırır ancak çıktı boyutunu büyütür.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sağladığından emin olduğunuzda dışarıda bırakın. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Gömmek Yerine Bağlantı Verme**

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'ye `@font-face` kuralları ekleyebilirsiniz. PHP via Java'da bu senaryo genellikle [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/embedallfontshtmlcontroller/)’ı genişleten küçük bir Java yardımcı sınıfı ile uygulanır; bu sınıf yazı tipi baytlarını bir çıktı dizinine yazar ve oluşturulan HTML'ye `@font-face` kurallarını ekler. Bu yardımcı sınıfı derleyin, PHP Java Bridge sınıf yoluna ekleyin ve ardından PHP'den `new Java(...)` ile örnekleyin.

Bu tür bir yardımcı oluştururken iki yolu bilinçli olarak seçin:

- Dosya sistemi çıktı yolu, oluşturulan yazı tipi dosyalarının yazıldığı yer.
- URL yolu, tarayıcının HTML belgesinden bu yazı tipi dosyalarını yüklemek için kullandığı yol.

## **Kaynakları Harici Olarak Kaydetme**

Bağımsız HTML taşımak kolaydır, ancak gömülü Base64 kaynaklar dosyayı büyük yapabilir. Uygulamanız harici resim dosyalarına ihtiyaç duyuyorsa, [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) yapıcıya özel bir bağlantı/gömme denetleyicisi sağlayın.

Kaynakları harici hale getirirken iki yolu bilinçli olarak seçin:

- Dosya sistemi çıktı yolu, uygulamanızın oluşturulan görüntü, yazı tipi, ses veya video dosyalarını yazdığı yer.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yol.

Bu yolları dağıtım yapınıza uygun tutun, böylece oluşturulan HTML bir web sunucusuna veya başka bir dizine taşındıktan sonra harici kaynaklarını yükleyebilir.

## **Medya Dosyalarını Dışa Aktarma**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve tarayıcıda oynatabilecek HTML yazar. Yapıcısı şunları alır:

- `path`: oluşturulan HTML ve medya dosyaları için kullanılan çıktı dizini.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: medya dosyalarına HTML bağlantılarında kullanılan mutlak URI öneki.

HTML dosyası `html-output/presentation.html` ise, `path` `html-output` dizinine işaret etmeli ve `baseUri` tarayıcının bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için, çıktı dizininden bir `file:///` URI'si oluşturabilirsiniz. Dağıtılmış bir uygulama için, yayınlanmış çıktı dizininin mutlak URL'sini kullanın.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

İhracat işi başına benzersiz çıktı dizinleri kullanın, özellikle sunucu uygulamalarında. Paylaşılan çıktı yolları farklı dönüşümlerin dosyalarının birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir renderleme işlemidir, bu nedenle işleme süresi ve bellek kullanımı slayt sayısına, görüntü çözünürlüğüne, yazı tiplerine, efektlere, grafiklere ve gömülü medyaya bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları sadakati artırabilir ancak genellikle çıktı boyutunu büyütür.

Toplu dönüşüm için:

- Her [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini hızlıca yok edin.
- Farklı işler için ayrı çıktı dizinleri kullanın.
- Sadakat gerektirmiyorsa yaygın yazı tiplerini gömmekten kaçının.
- HTML önizleme veya küçük resimler için görüntü DPI'sını düşürün.
- Kaynak sunumu, oluşturulan HTML ve harici kaynakları dağıtım yolları kesinleşene kadar bir arada tutun.

## **SSS**

**HTML çıktısında köprüler korunuyor mu?**

Evet. Sunum köprüleri HTML'ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini farklı iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin.

**Presentation nesnesi iş parçacığı güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği bir iş parçacığında yüklenmeli, değiştirilmeli, kaydedilmeli ve yok edilmelidir. Paralel çalışmalarda, iş parçacığı başına bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım kaynakları doğrudan HTML'ye gömebilir. Gömülü yazı tipleri, yüksek DPI'li görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı, en yüksek sadakatten daha önemliyse harici kaynaklar kullanın, yaygın yazı tiplerini gömmekten çıkarın ve `PicturesCompression` değerini düşürün.

**Neden PowerPoint'te 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak görülüyor?**

Bu, PowerPoint ve HTML'nin farklı DPI modelleri kullanmasından kaynaklanabilir. PowerPoint, metin boyutlarını 72 DPI'ye dayalı tipografik puanlarla saklarken, HTML yerleşimi 96 DPI modeline dayalı CSS piksellerine dayanır. Aspose.Slides bir sunumu HTML'ye dışa aktardığında, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farkları oluşturabilir.

Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Bunlar yalnızca PowerPoint ve HTML arasında metin ölçüleri dönüştürülürken ortaya çıkan matematiksel bir yan etkidir.

**Medya dışa aktarımı için baseUri nasıl seçilmeli?**

`baseUri`'yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak gönderin. Yerel önizleme için, çıktı dizininden bir Java dosya URI'si türetebilirsiniz. Dağıtım için yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) üzerinde `ShowHiddenSlides` değerini `true` olarak ayarlayın.