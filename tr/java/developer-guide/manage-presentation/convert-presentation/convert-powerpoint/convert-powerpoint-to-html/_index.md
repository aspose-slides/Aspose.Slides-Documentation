---
title: Java'da PowerPoint Sunumlarını HTML'e Dönüştür
linktitle: PowerPoint'ten HTML'e
type: docs
weight: 30
url: /tr/java/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten HTML'e
- sunumdan HTML'e
- slayttan HTML'e
- PPT'den HTML'e
- PPTX'ten HTML'e
- PowerPoint'i HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'e aktar
- PPTX'i HTML'e aktar
- Java
- Aspose.Slides
description: "Java'da PowerPoint sunumlarını HTML'e dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile bir `save` çağrısıdır. Dışa aktarılan düzeni, yazı tiplerini, görüntüleri, notları, yorumları, SVG çıktısını veya bağlı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarım senaryolarına odaklanır:

- Tam bir sunumu veya seçili slaytları dışa aktar.
- Sabit düzenli, duyarlı veya SVG tabanlı HTML oluştur.
- Sunucu notlarını ve yorumları ekle.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı olarak kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazılacağını ve başvurulacağını seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu tek bir HTML belgesi üretir. Tek bir dosya paylaşmak için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir olarak bulunmayan yazı tiplerini yalnızca gömerek düşünün.

## **Bir Sunumu HTML'e Dönüştürme**

Bir sunumu HTML olarak dışa aktarmak için, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) ile kaydedin.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Bu örnek bir HTML dosyası yazar. Sunum nesnesi, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakan `finally` bloğunda yok edilir.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- `SlidesLayoutOptions`: notlar, yorumlar, el kitapları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların temsil şeklini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verilerini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin konteynerine uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler en yaygın seçenekleri ayrı ayrı gösterir, böylece iş akışınızın ihtiyaç duyduğu yalnızca gerekli seçenekleri birleştirebilirsiniz.

## **Seçili Slaytları HTML'e Dönüştürme**

`Presentation.save` aşırı yüklemesi, slayt numaralarını kabul eder ve 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Bir web sitesi veya uygulamanın slayt başına bir HTML sayfasına ihtiyacı olduğunda bu desenı kullanın. Her slayt aynı düzene sahip olmalıysa, bir [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) örneği oluşturun ve her `save` çağrısına geçirin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde kullanın.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) üzerinde `SvgResponsiveLayout` özelliğini ayarlayın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında faydalıdır.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Sunucu Notlarını ve Yorumları Dahil Etme**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) `HtmlOptions.setSlidesLayoutOptions` aracılığıyla kullanarak sunucu notlarını veya yorumları dahil edin. Notlar ve yorumlar varsayılan olarak gizlidir, konumlarını seçmediğiniz sürece.

PowerPoint'te sunucu notları olan slayt:

![PowerPoint'te sunucu notları olan slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında sunucu notlarıyla dışa aktarır.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Slayt ve sunucu notlarıyla HTML çıktısı:

![Slayt ve sunucu notlarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın, örneğin `CommentsPositions.Right` veya `CommentsPositions.Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` öğesini atlayın. Hem not hem de yorum gerekiyorsa her iki özelliği de ayarlayın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Etme**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyacınız olduğunda `PicturesCompression` özelliğini [PicturesCompression](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturescompression/) içindeki bir değere ayarlayın.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktıda kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS Ekleme**

Basit stil için, bir CSS dizesini `HtmlFormatter.createDocumentFormatter`'a aktarın. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Özel bir belge başlığı, bağlı bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için [IHtmlFormattingController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihtmlformattingcontroller/) uygulayın ve `createCustomFormatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmlformatter/)'a geçirin.

## **Yazı Tiplerini Gömme**

Hedef ortamda sunum yazı tipleri yüklü olmayabilir, bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embedallfontshtmlcontroller/) ile HTML içinde yazı tiplerini gömün. Gömme görsel doğruluğu artırır ancak çıktı boyutunu yükseltir.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sağladığından emin olduğunuzda hariç tutun. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Bağlantı Vermek Yerine Gömmek** 

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'ye `@font-face` kuralları ekleyebilirsiniz. Aşağıdaki yardımcı, [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/embedallfontshtmlcontroller/)'ı genişletir ve `writeFont` metodunu geçersiz kılar.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Bu örnekte, yazı tipi dosyaları `html-output/fonts` klasörüne kaydedilir ve HTML, `fonts/BrandFont-normal-400.woff` gibi URL'lerle onlara referans verir. HTML dosyası ve yazı tipleri başka bir konuma dağıtılırsa, dağıtılan URL yoluyla eşleşecek şekilde `fontUrlPrefix` seçin.

## **Kaynakları Dışarıda Kaydetme**

Kendinden oluşan HTML taşımak kolaydır, ancak gömülü Base64 kaynakları dosyayı büyütebilir. Uygulamanız dış resim dosyalarına ihtiyaç duyuyorsa, [ILinkEmbedController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) uygulayın ve [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) yapıcıya geçirin.

Kaynakları dışa aktardığınızda, iki yolu kasıtlı olarak seçin:

- Dosya sistemi çıktı yolu, uygulamanızın oluşturulan görüntüleri, yazı tiplerini, sesleri veya videoları yazdığı yer.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yoldur.

## **Medya Dosyalarını Dışa Aktarma**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve tarayıcıda oynatılabilecek HTML yazar. Yapıcısı şunları alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML içindeki medya dosyası bağlantılarında kullanılan mutlak URI ön eki.

Eğer HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydedildiyse, `path` diskteki medya dizinine işaret etmeli, `baseUri` ise tarayıcı bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için medya dizininden bir `file:///` URI oluşturabilirsiniz. Dağıtılmış bir uygulama için yayınlanan medya dizininin mutlak URL'sini kullanın.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları farklı dönüşümlerin dosyalarının birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemi olduğundan, işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medyaya bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve korunan kırpılmış görüntü alanları doğruluğu artırabilir ancak genellikle çıktı boyutunu yükseltir.

Toplu dönüşüm için:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini hemen yok edin.
- Ayrı işler için ayrı çıktı dizinleri kullanın.
- Doğruluk gerektirmiyorsa yaygın yazı tiplerini gömmekten kaçının.
- HTML önizleme veya küçük resimler için ise görüntü DPI'sını düşürün.
- Dağıtım yolları kesinleşene kadar kaynak sunumu, üretilen HTML ve harici kaynakları bir arada tutun.

## **SSS**

**HTML çıktısında hiperlinkler korunur mu?**

Evet. Sunum hiperlinkleri HTML'ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'e dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini farklı iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [çok iş parçacıklı rehber](/slides/tr/java/multithreading/) sayfasına bakın.

**Bir Presentation nesnesi iş parçacığı güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği bir iş parçacığında yüklenmeli, değiştirilip, kaydedilmeli ve yok edilmelidir. Paralel çalışma için, iş parçacığı başına bağımsız bir örnek oluşturun veya süreç başına.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım kaynakları doğrudan HTML'ye gömebilir. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve korunan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı maksimum doğruluktan daha önemliyse harici kaynaklar kullanın, yaygın yazı tiplerini gömmekten çıkarın ve `PicturesCompression` değerini düşürün.

**PowerPoint'te 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak neden görünüyor?**

Bu, PowerPoint ve HTML'nin farklı DPI modelleri kullanmasından kaynaklanabilir. PowerPoint, metin boyutlarını 72 DPI'ye dayalı tipografik puanlarda saklarken, HTML düzeni 96 DPI modelindeki CSS pikseline dayanır. Aspose.Slides bir sunumu HTML'e dışa aktardığında, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farkları oluşturabilir. Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Yalnızca PowerPoint ve HTML arasında metin ölçütlerinin dönüştürülmesinin matematiksel bir yan etkisidir.

**Medya dışa aktarma için baseUri nasıl seçilmeli?**

`baseUri`'yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak geçirin. Yerel önizleme için, `mediaDirectory.toUri().toString()` ile çıktı dizininden türetebilirsiniz. Dağıtım için, yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) üzerinde `ShowHiddenSlides` değerini `true` olarak ayarlayın.