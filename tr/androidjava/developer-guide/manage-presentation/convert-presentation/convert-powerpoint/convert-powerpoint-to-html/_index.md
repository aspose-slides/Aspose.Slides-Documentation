---
title: PowerPoint Sunumlarını Android'de HTML'ye Dönüştür
linktitle: PowerPoint'ten HTML'ye
type: docs
weight: 30
url: /tr/androidjava/convert-powerpoint-to-html/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten HTML'ye
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarını Android'de HTML'ye dönüştür. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides for Android via Java kullanın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) ile bir `save` çağrısıdır. Dışa aktarılan düzeni, yazı tiplerini, görüntüleri, notları, açıklamaları, SVG çıktısını veya bağlantılı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarma senaryolarına odaklanır:

- Tam bir sunumu ya da seçili slaytları dışa aktar.
- Sabit düzen, duyarlı veya SVG tabanlı HTML oluştur.
- Sunucu notlarını ve yorumları dahil et.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazıldığını ve referans verildiğini seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu tek bir HTML belgesi üretir. Tek bir dosyanın paylaşılması için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir şekilde bulunmayan yazı tiplerini gömmeyi düşünün.

## **Bir Sunumu HTML'ye Dönüştür**

Bir sunumu HTML olarak dışa aktarmak için, onu [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) ile kaydedin.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Bu örnek bir HTML dosyası yazar. Sunum nesnesi, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakan `finally` bloğunda iptal edilir.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- `SlidesLayoutOptions`: notlar, yorumlar, el ilanları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların temsil biçimini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verisini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin konteynerine uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları dahil eder.

Aşağıdaki bölümler, iş akışınızın ihtiyaç duyduğu seçenekleri yalnızca birleştirmeniz için en yaygın seçenekleri ayrı ayrı gösterir.

## **Seçili Slaytları HTML'ye Dönüştür**

`Presentation.save` aşırı yüklemesi, slayt numaralarını kabul eder ve 1 tabanlı slayt konumlarını kullanır. Aşağıdaki döngü, her slaytı ayrı bir HTML dosyasına kaydeder.

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

Bir web sitesi veya uygulama her slayt için bir HTML sayfasına ihtiyaç duyduğunda bu deseni kullanın. Eğer her slayt aynı düzeni taşımalıysa, bir [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) örneği oluşturun ve her `save` çağrısına geçirin.

## **Duyarlı HTML Oluştur**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde kullanın.

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

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) üzerine `SvgResponsiveLayout` ayarlayın. Bu, slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında yararlıdır.

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

## **Sunucu Notlarını ve Yorumları Dahil Et**

Sunucu notlarını veya yorumları dahil etmek için `HtmlOptions.SlidesLayoutOptions` üzerinden [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) kullanın. Notlar ve yorumlar varsayılan olarak gizlidir, konumlarını seçmezseniz.

Kaynak sunumun sunucu notları içerdiğini varsayalım:

![PowerPoint'te sunucu notlarıyla slayt](slide_with_notes.png)

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

![Slayt ve sunucu notlarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın, örneğin `CommentsPositions.Right` veya `CommentsPositions.Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` öğesini atlayın. Hem not hem de yorum ihtiyacınız varsa her iki özelliği de ayarlayın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Et**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyacınız olduğunda `PicturesCompression` değerini [PicturesCompression](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturescompression/) içindeki bir değere ayarlayın.

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

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarım çıktısından kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde kırpılmış veriyi saklayın. Saklamak HTML boyutunu artırabilir.

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

## **CSS Ekle**

Basit stil için bir CSS dizesini `HtmlFormatter.createDocumentFormatter`'a geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevredeki HTML belgesini değiştirir.

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

Özel bir belge başlığı, bağlı bir CSS dosyası veya slayt ve şekiller etrafında özel işaretleme için [IHtmlFormattingController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihtmlformattingcontroller/) uygulayın ve bunu `createCustomFormatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmlformatter/) 'a geçirin.

## **Yazı Tiplerini Göm**

Hedef ortamda sunum yazı tipleri yüklü olmayabilir; bu durumda [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) ile HTML içinde yazı tiplerini gömün. Gömme görsel sadakati artırır ancak çıktı boyutunu artırır.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sunduğundan emin olduğunuzda hariç tutun. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Bağlantı Ver**

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'ye `@font-face` kuralları ekleyebilirsiniz. Aşağıdaki yardımcı, [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 'ı genişletir ve `writeFont` yöntemini geçersiz kılar.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Bu örnekte, yazı tipi dosyaları `html-output/fonts` klasörüne kaydedilir ve HTML, `fonts/BrandFont-normal-400.woff` gibi URL'lerle onlara referans verir. HTML dosyası ve yazı tipleri başka bir konuma dağıtılıyorsa, dağıtılan URL yolu ile eşleşecek şekilde `fontUrlPrefix` seçin.

## **Kaynakları Harici Olarak Kaydet**

Tek başına HTML taşımak kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanızın harici görüntü dosyalarına ihtiyacı varsa, [ILinkEmbedController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) uygulayın ve bunu [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) yapıcıya geçirin.

Kaynakları harici hale getirirken iki yolu bilinçli olarak seçin:

- Dosya sistemi çıkış yolu, uygulamanızın oluşturulan görüntüleri, yazı tiplerini, sesleri veya videoları yazdığı yer.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yol.

## **Medya Dosyalarını Dışa Aktar**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve bir tarayıcıda oynatabilecek HTML yazar. Yapıcı şu parametreleri alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML bağlantılarında medya dosyalarına kullanılan mutlak URI öneki.

HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydedildiyse, `path` diskteki medya dizinine işaret etmeli, `baseUri` ise tarayıcının bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için medya dizininden bir `file:///` URI oluşturabilirsiniz. Dağıtılmış bir uygulama için yayınlanan medya dizininin mutlak URL'sini kullanın.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları, farklı dönüşümlerden gelen dosyaların birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemi olduğundan, işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medyaya bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları sadakati artırabilir ancak genellikle çıktı boyutunu artırır.

Toplu dönüştürme için:

- Her [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini hızlıca iptal edin.
- Ayrı işleri ayrı çıktı dizinleriyle yapın.
- Sadakat gerektirmedikçe yaygın yazı tiplerini gömmekten kaçının.
- HTML önizleme veya küçük resimler için görüntü DPI'sını düşürün.
- Kaynak sunumu, oluşturulan HTML ve harici kaynakları dağıtım yolları kesinleşene kadar birlikte tutun.

## **FAQ**

**HTML çıktısında hiperlinkler korunur mu?**

Evet. Sunum hiperlinkleri HTML'ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir olur.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [çoklu iş parçacığı rehberi](/slides/tr/androidjava/multithreading/) bölümüne bakın.

**Presentation nesnesi iş parçacığı güvenli mi?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği bir iş parçacığında yüklenmeli, değiştirilip, kaydedilmeli ve iptal edilmelidir. Paralel çalışma için, her iş parçacığı veya süreç için bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım, kaynakları doğrudan HTML'ye gömebilir. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı, en yüksek sadakatten daha önemli olduğunda harici kaynakları kullanın, yaygın yazı tiplerini gömmekten hariç tutun ve `PicturesCompression` değerini düşürün.

**Neden PowerPoint'te 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak görülüyor?**

Bu, PowerPoint ve HTML'nin farklı DPI modelleri kullanmasından kaynaklanabilir. PowerPoint, metin boyutlarını 72 DPI tabanlı tipografik puanlarda saklarken, HTML düzeni 96 DPI modelindeki CSS piksellerine dayanır. Aspose.Slides bir sunumu HTML'ye dışa aktarırken, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farklılıkları oluşturabilir. Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Yalnızca PowerPoint ve HTML arasında metin ölçütleri dönüştürülürken ortaya çıkan matematiksel bir yan etkidir.

**Medya dışa aktarımı için baseUri nasıl seçilmeli?**

`baseUri`'yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak geçirin. Yerel önizleme için, `mediaDirectory.toUri().toString()` ile çıktı dizininden türetebilirsiniz. Dağıtımda, yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) üzerinde `ShowHiddenSlides` özelliğini `true` olarak ayarlayın.