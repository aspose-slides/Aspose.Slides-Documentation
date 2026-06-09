---
title: PowerPoint Sunumlarını Node.js'te HTML'ye Dönüştürme
linktitle: PowerPoint'ten HTML
type: docs
weight: 30
url: /tr/nodejs-java/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten HTML
- sunumu HTML'ye
- slaytı HTML'ye
- PPT'den HTML'ye
- PPTX'den HTML'ye
- PowerPoint'i HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'ye dışa aktar
- PPTX'i HTML'ye dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarını Node.js'te HTML'ye dönüştürün. Aspose.Slides for Node.js via Java kullanarak PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG'yi ve medyayı dışa aktarın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) ile bir `save` çağrısıdır. Dışa aktarılan düzeni, yazı tiplerini, görüntüleri, notları, yorumları, SVG çıktısını veya bağlanan kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarma senaryalarına odaklanır:

- Tüm sunumu veya seçili slaytları dışa aktar.
- Sabit‑düzenli, duyarlı veya SVG‑tabanlı HTML üret.
- Sunum notlarını ve yorumları ekle.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Dış kaynakların ve medya dosyalarının nasıl yazılacağını ve başvurulacağını seç.

Varsayılan olarak, HTML dışa aktarma çoğu kaynağın gömülü olduğu kendi kendine yeten bir HTML belgesi üretir. Tek bir dosyayı paylaşmak için pratiktir, ancak çıktı boyutunu artırabilir. Web yayıncılığı için dış kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir olarak bulunmayan yazı tiplerini gömmeyi düşünün.

## **Sunumu HTML'ye Dönüştürme**

Bir sunumu HTML'ye dışa aktarmak için, onu [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) ile kaydedin.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Bu örnek tek bir HTML dosyası yazar. Sunum nesnesi `finally` bloğunda serbest bırakılır; bu, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakır.

## **HtmlOptions Kullanma**

[HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) HTML dışa aktarma için ana yapılandırma sınıfıdır. Yaygın ayarlar şunlardır:

- `SlidesLayoutOptions`: notlar, yorumlar, el kitapları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların temsil biçimini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verilerini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler en yaygın seçenekleri ayrı ayrı gösterir; böylece yalnızca iş akışınız için gerekli olanları birleştirebilirsiniz.

## **Seçili Slaytları HTML'ye Dönüştürme**

Slayt numaralarını kabul eden `Presentation.save` aşırı yüklemesi 1‑tabanlı slayt konumlarını kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Bir web sitesi veya uygulama her slayt için bir HTML sayfasına ihtiyaç duyduğunda bu deseni kullanın. Her slayt aynı düzene sahipse, tek bir [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) örneği oluşturup her `save` çağrısına iletebilirsiniz.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlamasını istediğinizde bunu kullanın.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG‑tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) üzerindeki `SvgResponsiveLayout` özelliğini ayarlayın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarılırken yararlıdır.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Sunum Notları ve Yorumları Dahil Etme**

Sunum notlarını veya yorumları dahil etmek için `HtmlOptions.setSlidesLayoutOptions` aracılığıyla [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) kullanın. Notlar ve yorumlar varsayılan olarak gizlidir; konumlarını seçmezseniz görünmezler.

Kaynak sunumda sunum notları olduğunu varsayalım:

![PowerPoint'te sunum notları içeren slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında not alanı ile dışa aktarır.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Dışa aktarılan HTML, not alanını içerir:

![Slayt ve sunum notları ile HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın; örneğin `CommentsPositions.Right` veya `CommentsPositions.Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` öğesini atlayın. Hem not hem de yorum istiyorsanız her iki özelliği de ayarlayın.

## **Görüntü Kalitesi ve Kırpılmış Alanları Kontrol Etme**

HTML dışa aktarma, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyaç duyduğunuzda, [PicturesCompression](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturescompression/) içindeki bir değere `PicturesCompression` atayın.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktıda kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde kırpılmış verileri tutun. Bu, HTML boyutunu artırabilir.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS Ekleme**

Basit stil vermek için bir CSS dizesini `HtmlFormatter.createDocumentFormatter` metoduna geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Özel bir belge başlığı, bağlantılı bir CSS dosyası veya slaytların ve şekillerin etrafında özel işaretleme için, bir biçimlendirme denetleyicisiyle birlikte [HtmlFormatter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmlformatter/) kullanın.

## **Yazı Tiplerini Gömme**

Hedef ortam sunum yazı tiplerini yüklü halde bulundurmayabilir; bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) ile HTML içinde yazı tiplerini gömün. Gömme görsel tutarlılığı artırır ancak çıktı boyutunu artırır.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sağladığından emin olduğunuzda dışarıda bırakın. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Gömme Yerine Bağlantı Verme**

HTML dosya boyutunu azaltmak için yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'e `@font-face` kuralları ekleyebilirsiniz. Node.js via Java'da bu senaryo genellikle [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) sınıfını genişleten küçük bir Java yardımcı sınıfı ile uygulanır; bu sınıf yazı tipi baytlarını bir çıktı dizinine yazar ve üretilecek HTML'e `@font-face` kurallarını enjekte eder. Bu yardımcıyı derleyin, Node.js modül sınıf yoluna ekleyin ve ardından JavaScript'ten `java.newInstanceSync` ile örnekleyin.

Böyle bir yardımcı oluştururken iki yolu kasıtlı olarak seçin:

- Üretilen yazı tipi dosyalarının yazılacağı dosya sistemi çıktı yolu.
- Tarayıcının HTML belgesinden bu yazı tipi dosyalarını yüklemek için kullandığı URL yolu.

## **Kaynakları Dışa Aktarma**

Kendi kendine yeten HTML hareketli ve kolay taşınabilir olsa da, gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanız dış resim, yazı tipi, ses veya video dosyalarına ihtiyaç duyuyorsa, kaynakları seçili bir dizine yazan ve tarayıcıda görülebilir URL'ler üreten bir dışa aktarma denetleyicisi kullanın. Dosya sistemi yolu ile URL yolunu dağıtım düzeninizle hizalı tutun.

## **Medya Dosyalarını Dışa Aktarma**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve bunların bir tarayıcıda oynatılabileceği HTML yazar. Yapıcı şu parametreleri alır:

- `path`: üretilen medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML'deki medya dosyalarına yönlendiren mutlak URI öneki.

HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydediliyorsa, `path` diskteki medya dizinine, `baseUri` ise tarayıcı bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için medya dizininden bir `file:///` URI oluşturabilirsiniz. Yayınlanmış bir uygulama için yayınlanan medya dizininin mutlak URL'sini kullanın.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları, farklı dönüşümlerden dosyaların üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemidir; bu nedenle işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medyaya bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları kaliteyi artırabilir ancak genellikle çıktı boyutunu büyütür.

Toplu dönüşüm için:

- Her [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini derhal serbest bırakın.
- Farklı işler için ayrı çıktı dizinleri kullanın.
- Yaygın yazı tiplerini, sadece kalite gerektirmiyorsa, gömmekten kaçının.
- HTML ön izleme veya ön izleme amaçlı ise görüntü DPI'sını düşürün.
- Kaynak sunum, üretilen HTML ve dış kaynakları, dağıtım yolları kesinleşene kadar bir arada tutun.

## **SSS**

**HTML çıktısında köprüler korunur mu?**

Evet. Sunum köprüleri HTML'ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, fakat bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini işçiler arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleri ile işleyin. Ayrıntılar için [çoklu iş parçacığı kılavuzu](/slides/tr/nodejs-java/multithreading/) bölümüne bakın.

**Presentation nesnesi iş parçacığı‑güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği bir işçi içinde yüklenmeli, değiştirilmeli, kaydedilmeli ve serbest bırakılmalıdır. Paralel çalışma için her işçi ya da süreç için bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarma, kaynakları doğrudan HTML içinde gömer. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Dış kaynakları kullanın, yaygın yazı tiplerinin gömülmesini dışarıda bırakın ve `PicturesCompression` değerini düşük tutun; daha küçük çıktı, maksimum kalite yerine öncelikli olduğunda bu ayarlar yardımcı olur.

**PowerPoint'te 24 pt olarak ayarlanan bir yazı tipi HTML'de 17.999819 pt olarak görülüyor, neden?**

Bu, PowerPoint ve HTML'nin farklı DPI modelleri kullanmasından kaynaklanır. PowerPoint, metin boyutlarını 72 DPI tabanlı tipografik puanlarla saklarken, HTML düzeni 96 DPI modelindeki CSS pikseline dayanır. Aspose.Slides bir sunumu HTML'ye dışa aktarırken, yazı tipi boyutu bu sistemler arasında çevrilir ve küçük yuvarlama farkları ortaya çıkabilir.

Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez; yalnızca PowerPoint ve HTML arasındaki metrik dönüşümünün matematiksel yan etkisidir.

**Medya dışa aktarma için baseUri nasıl seçilmeli?**

Tarayıcının bakış açısından bir `baseUri` seçin ve bunu mutlak bir URI olarak iletin. Yerel önizleme için çıktı dizininden bir `file:///` URI türetebilirsiniz. Dağıtımda ise yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde, [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) üzerinde `ShowHiddenSlides` değerini `true` olarak ayarlayın.