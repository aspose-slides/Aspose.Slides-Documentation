---
title: .NET'te PowerPoint Sunumlarını HTML'ye Dönüştür
linktitle: PowerPoint'ten HTML'ye
type: docs
weight: 30
url: /tr/net/convert-powerpoint-to-html/
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
- PPTX'den HTML'ye
- PowerPoint'i HTML olarak kaydet
- sunumu HTML olarak kaydet
- slaytı HTML olarak kaydet
- PPT'yi HTML olarak kaydet
- PPTX'i HTML olarak kaydet
- PPT'yi HTML'ye aktar
- PPTX'i HTML'ye aktar
- .NET
- C#
- Aspose.Slides
description: ".NET'te PowerPoint sunumlarını HTML'ye dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for .NET, Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yüklemesi ve [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) çağrısı ile [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) kullanılmasıdır. İhrac edilen düzeni, yazı tiplerini, görüntüleri, notları, yorumları, SVG çıktısını veya bağlı kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarma senaryolarına odaklanır:

- Tüm sunumu veya seçili slaytları dışa aktar.
- Sabit düzenli, duyarlı veya SVG tabanlı HTML oluştur.
- Konuşmacı notlarını ve yorumları dahil et.
- Görüntü kalitesini ve kırpılmış görüntü verisini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazıldığını ve referans alındığını seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu tek bir HTML belgesi üretir. Tek bir dosyayı paylaşmak için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için, harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir şekilde bulunmayan yazı tiplerini yalnızca gömerek düşünün.

## **Bir Sunumu HTML'ye Dönüştür**

Bir sunumu HTML olarak dışa aktarmak için, onu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) ile yükleyin ve [SaveFormat.Html](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) ile kaydedin.

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Bu örnek bir HTML dosyası yazar. Sunum nesnesi, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakan `using` bildirimiyle imha edilir.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunlardır:

- `SlidesLayoutOptions`: notlar, yorumlar, el ilanları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların temsil biçimini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntü DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verisini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları içerir.

Aşağıdaki bölümler en yaygın seçenekleri ayrı ayrı gösterir, böylece iş akışınızın ihtiyaç duyduğu seçenekleri yalnızca birleştirebilirsiniz.

## **Seçili Slaytları HTML'ye Dönüştür**

[Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) aşırı yüklemesi, slayt numaralarını kabul eder ve 1 tabanlı slayt konumları kullanır. Aşağıdaki döngü, her slaytı ayrı bir HTML dosyasına kaydeder.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Her slayt için bir HTML sayfasına ihtiyaç duyan bir web sitesi veya uygulama olduğunda bu deseni kullanın. Her slayt aynı düzene sahip olacaksa, bir [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) örneği oluşturun ve her `Save` çağrısına geçirin.

## **Duyarlı HTML Oluştur**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/responsivehtmlcontroller/) , [HtmlFormatter](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde kullanın.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) üzerinde `SvgResponsiveLayout` ayarını yapın. Slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında bu yararlıdır.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Konuşmacı Notlarını ve Yorumları Dahil Et**

Konuşmacı notlarını veya yorumları eklemek için `HtmlOptions.SlidesLayoutOptions` üzerinden [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) kullanın. Notlar ve yorumlar, konumlarını seçmezseniz varsayılan olarak gizlidir.

Kaynak sunumun konuşmacı notları içerdiğini varsayalım:

![PowerPoint'te konuşmacı notalı slayt](slide_with_notes.png)

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Aşağıdaki kod, slayt içeriğini slaydın altında konuşmacı notalarıyla dışa aktarır.

![Slayt ve konuşmacı notalarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın, örneğin `CommentsPositions.Right` veya `CommentsPositions.Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` değerini atlayın. Hem not hem de yorum gerekiyorsa her iki özelliği de ayarlayın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Et**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyaç duyduğunuzda `PicturesCompression` değerini [PicturesCompression](https://reference.aspose.com/slides/tr/net/aspose.slides.export/picturescompression/)’tan bir değere ayarlayın.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktıda kaldırılabilir. Kullanıcıların bu gizli görüntü parçalarını geri alabilmesi veya inceleyebilmesi gerektiğinde kırpılmış veriyi tutun. Tutmak HTML boyutunu artırabilir.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS Ekle**

Basit stil için, bir CSS dizesini [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmlformatter/createdocumentformatter/)’a geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevreleyen HTML belgesini değiştirir.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Özel bir belge başlığı, bağlanmış bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için, [IHtmlFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ihtmlformattingcontroller/)’ı uygulayın ve `CreateCustomFormatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmlformatter/)’a geçirin.

## **Yazı Tiplerini Göm**

Hedef ortamda sunumun yazı tipleri yüklü olmayabilir, bu yüzden yazı tiplerini HTML içinde [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedallfontshtmlcontroller/) ile gömün. Gömme görsel doğruluğu artırır ancak çıktı boyutunu büyütür.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sağladığından emin olduğunuzda hariç tutun. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarına Bağlantı Ver ve Gömme**

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'ye `@font-face` kuralları ekleyebilirsiniz. Aşağıdaki yardımcı, [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedallfontshtmlcontroller/)’ı genişletir ve `WriteFont` metodunu geçersiz kılar.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Bu örnekte, yazı tipi dosyaları `html-output/fonts` klasörüne kaydedilir ve HTML, `fonts/BrandFont-normal-400.woff` gibi URL'lerle onlara referans verir. HTML dosyası ve yazı tipleri başka bir yere dağıtılıyorsa, `fontUrlPrefix` değerini dağıtılan URL yoluna uygun şekilde seçin.

## **Kaynakları Harici Olarak Kaydet**

Tek dosya halinde HTML taşımak kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapar. Uygulamanız harici görüntü dosyalarına ihtiyaç duyuyorsa, [ILinkEmbedController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ilinkembedcontroller/)’ı uygulayın ve [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/htmloptions/) yapıcısına geçirin.

Kaynakları harici hale getirirken iki yolu bilinçli seçin:

- Dosya sistemi çıktı yolu, uygulamanızın oluşturulan görüntüleri, yazı tiplerini, ses veya video dosyalarını yazdığı yer.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yol.

Tam bir görüntü bağlantı uygulaması için, [Export Presentations to HTML with Externally Linked Images](/slides/tr/net/exporting-presentations-to-html-with-externally-linked-images/) sayfasına bakın.

## **Medya Dosyalarını Dışa Aktar**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve tarayıcıda oynatabilecek HTML yazar. Yapıcı şu parametreleri alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML'deki medya dosyası bağlantılarında kullanılan mutlak URI öneki.

HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydedilmişse, `path` diskteki medya dizinine işaret etmeli, `baseUri` ise tarayıcı bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için medya dizininden bir `file:///` URI oluşturabilirsiniz. Dağıtılan bir uygulama için, yayınlanan medya dizininin mutlak URL'sini kullanın.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Özellikle sunucu uygulamalarında, her dışa aktarma işi için benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları, farklı dönüşümlerin dosyalarının üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemi olduğundan, işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medya gibi faktörlere bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları doğruluğu artırabilir ancak genellikle çıktı boyutunu yükseltir.

Toplu dönüşüm için:

- Her [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini hızla imha edin.
- Ayrı işler için ayrı çıktı dizinleri kullanın.
- Doğruluk gerektirmedikçe yaygın yazı tiplerini gömmekten kaçının.
- HTML ön izleme veya küçük resimler için görüntü DPI'sını düşürün.
- Kaynak sunumu, oluşturulan HTML ve harici kaynakları dağıtım yolları kesinleşene kadar birlikte tutun.

## **SSS**

**HTML çıktısında hiperlinkler korunur mu?**

Evet. Sunumdaki hiperlinkler HTML'e dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir kalır.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini thread'ler arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleriyle işleyin. Ayrıntılar için [çoklu iş parçacığı rehberi](/slides/tr/net/multithreading/) sayfasına bakın.

**Presentation nesnesi thread‑safe midir?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği bir thread üzerinde yüklenmeli, değiştirilip, kaydedilmeli ve imha edilmelidir. Paralel çalışmalarda, her thread ya da süreç için bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım, kaynakları doğrudan HTML içinde gömebilir. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı en yüksek doğruluktan daha önemliyse harici kaynaklar kullanın, yaygın yazı tiplerini gömmekten hariç tutun ve `PicturesCompression` değerini düşürün.

**PowerPoint'te 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak neden görünür?**

Bu, PowerPoint ve HTML farklı DPI modelleri kullandıkları için olabilir. PowerPoint, metin boyutlarını 72 DPI tabanlı tipografik puanlarda saklarken, HTML düzeni 96 DPI modeline dayalı CSS pikselleri üzerine kuruludur. Aspose.Slides bir sunumu HTML'e dışa aktarırken, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farkları yaratabilir.

Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Sadece PowerPoint ile HTML arasındaki metin metrikleri dönüşümünün matematiksel bir yan etkisidir.

**Medya dışa aktarımı için baseUri nasıl seçilmeli?**

`baseUri` değerini tarayıcının bakış açısından seçin ve mutlak bir URI olarak geçirin. Yerel ön izleme için, `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` koduyla çıktı dizininden türetebilirsiniz. Dağıtımda, yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) üzerinde `ShowHiddenSlides = true` ayarlayın.