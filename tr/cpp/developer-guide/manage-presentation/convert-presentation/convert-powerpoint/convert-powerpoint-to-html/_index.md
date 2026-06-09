---
title: "C++'ta PowerPoint Sunumlarını HTML'ye Dönüştürme"
linktitle: "PowerPoint'ten HTML'ye"
type: docs
weight: 30
url: /tr/cpp/convert-powerpoint-to-html/
keywords:
- "PowerPoint'i dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT'yi dönüştür"
- "PPTX'i dönüştür"
- "PowerPoint'ten HTML'ye"
- "sunumu HTML'ye"
- "slaytı HTML'ye"
- "PPT'yi HTML'ye"
- "PPTX'i HTML'ye"
- "PowerPoint'i HTML olarak kaydet"
- "sunumu HTML olarak kaydet"
- "slaytı HTML olarak kaydet"
- "PPT'yi HTML olarak kaydet"
- "PPTX'i HTML olarak kaydet"
- "PPT'yi HTML'ye aktar"
- "PPTX'i HTML'ye aktar"
- "C++"
- "Aspose.Slides"
description: "C++'ta PowerPoint sunumlarını HTML'ye dönüştürün. PPT ve PPTX dosyalarını, seçili slaytları, notları, yazı tiplerini, görüntüleri, SVG'yi ve medyayı dışa aktarmak için Aspose.Slides kullanın."
---
## **Genel Bakış**

Aspose.Slides for C++ Microsoft PowerPoint olmadan PowerPoint sunumlarını HTML olarak kaydedebilir. Temel dönüşüm, tek bir [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yüklemesi ve [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) ile bir `Save` çağrısıdır. Dışa aktarılmış düzeni, yazı tiplerini, resimleri, notları, yorumları, SVG çıktısını veya bağlanmış kaynakları kontrol etmeniz gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) kullanın.

Bu kılavuz, pratik HTML dışa aktarma senaryolarına odaklanır:

- Tüm bir sunumu veya seçili slaytları dışa aktar.
- Sabit düzen, duyarlı veya SVG tabanlı HTML oluştur.
- Konuşmacı notlarını ve yorumları dahil et.
- Görüntü kalitesini ve kırpılmış görüntü verilerini kontrol et.
- Yazı tiplerini göm veya yazı tipi dosyalarını ayrı olarak kaydet.
- Harici kaynakların ve medya dosyalarının nasıl yazılacağını ve başvurulacağını seç.

Varsayılan olarak, HTML dışa aktarımı, çoğu kaynağın gömülü olduğu bağımsız bir HTML belge üretir. Bu, tek bir dosyanın paylaşılması için uygundur, ancak çıktı boyutunu artırabilir. Web yayıncılığı için, harici kaynakları, daha düşük görüntü DPI'sını ve hedef ortamda güvenilir bir şekilde bulunmayan yazı tiplerini yalnızca gömmeyi düşünün.

## **Sunumu HTML'ye Dönüştürme**

Bir sunumu HTML'ye dışa aktarmak için, onu [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) ile yükleyin ve `SaveFormat::Html` ile kaydedin.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Bu örnek tek bir HTML dosyası yazar. `Dispose` çağrısı, dışa aktarmadan sonra dosya tanıtıcılarını ve render kaynaklarını serbest bırakır.

## **HtmlOptions Kullanımı**

[HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) HTML dışa aktarımı için ana yapılandırma sınıfıdır. Yaygın ayarlar şunları içerir:

- `SlidesLayoutOptions`: notlar, yorumlar, el ilanları veya diğer düzen bilgilerini ekler.
- `HtmlFormatter`: HTML belge yapısını değiştirir veya biçimlendirmeyi bir denetleyiciye devreder.
- `SlideImageFormat`: slaytların temsil biçimini değiştirir, örneğin SVG olarak.
- `PicturesCompression`: görüntünün DPI'sını ve çıktı boyutunu kontrol eder.
- `DeletePicturesCroppedAreas`: kırpılmış görüntü verilerini tutar veya kaldırır.
- `SvgResponsiveLayout`: dışa aktarılan SVG içeriğinin kapsayıcısına uyum sağlamasını sağlar.
- `ShowHiddenSlides`: gerektiğinde gizli slaytları dahil eder.

Takip eden bölümler en yaygın seçenekleri ayrı ayrı gösterir, böylece iş akışınız için gerekenleri yalnızca birleştirebilirsiniz.

## **Seçili Slaytları HTML'ye Dönüştürme**

`Presentation::Save` aşırı yüklemesi, slayt numaralarını kabul eder ve 1 tabanlı slayt konumları kullanır. Aşağıdaki döngü her slaytı ayrı bir HTML dosyasına kaydeder.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Bir web sitesi veya uygulamanın her slayt için bir HTML sayfasına ihtiyacı olduğunda bu modeli kullanın. Her slayt aynı düzene sahip olmalıysa, tek bir [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) örneği oluşturun ve her `Save` çağrısına geçirin.

## **Duyarlı HTML Oluşturma**

[ResponsiveHtmlController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmlformatter/) aracılığıyla duyarlı HTML çıktısı sağlar. Dışa aktarılan sayfanın tarayıcı genişliğine daha iyi uyum sağlaması gerektiğinde kullanın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

SVG tabanlı duyarlı düzen için, [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) üzerinde `SvgResponsiveLayout` ayarlayın. Slayt içeriği ölçeklenebilir SVG işaretlemesi olarak dışa aktarıldığında bu yararlıdır.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Konuşmacı Notları ve Yorumları Dahil Et**

Konuşmacı notlarını veya yorumları dahil etmek için `HtmlOptions.SlidesLayoutOptions` üzerinden [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) kullanın. Notlar ve yorumlar, konumlarını seçmediğiniz sürece varsayılan olarak gizlidir.

Kaynak sunumun konuşmacı notları içerdiğini varsayalım:

![PowerPoint'ta konuşmacı notalı slayt](slide_with_notes.png)

Aşağıdaki kod, slayt içeriğini slaytın altında konuşmacı notalarıyla dışa aktarır.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Dışa aktarılan HTML not alanını içerir:

![Slayt ve konuşmacı notalarıyla HTML çıktısı](HTML_with_notes.png)

Yorumları dışa aktarmak için `CommentsPosition` ayarlayın, örneğin `CommentsPositions::Right` veya `CommentsPositions::Bottom`. Yalnızca yorumlara ihtiyacınız varsa `NotesPosition` öğesini atlayın. Hem not hem de yorumlara ihtiyacınız varsa her iki özelliği de ayarlayın.

## **Görüntü Kalitesini ve Kırpılmış Alanları Kontrol Et**

HTML dışa aktarımı, çıktı boyutunu azaltmak için slayt görüntülerini sıkıştırabilir. Daha yüksek görüntü kalitesine ihtiyaç duyduğunuzda `PicturesCompression` değerini [PicturesCompression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/picturescompression/) içinden bir değere ayarlayın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Varsayılan olarak, görüntülerin kırpılmış alanları dışa aktarılan çıktından kaldırılabilir. Bu gizli görüntü parçalarını kullanıcıların kurtarması veya incelemesi gerektiğinde kırpılmış verileri tutun. Tutmak HTML boyutunu artırabilir.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS Ekle**

Basit stil için, bir CSS dizesini `HtmlFormatter::CreateDocumentFormatter` metoduna geçirin. Bu, Aspose.Slides slayt içeriğini render etmeye devam ederken çevredeki HTML belgeyi değiştirir.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Özel bir belge başlığı, bağlanmış bir CSS dosyası veya slaytlar ve şekiller etrafında özel işaretleme için, [IHtmlFormattingController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ihtmlformattingcontroller/) uygulayın ve bunu `CreateCustomFormatter` ile [HtmlFormatter](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmlformatter/) metoduna geçirin.

## **Yazı Tiplerini Göm**

Hedef ortamda sunum yazı tipleri yüklü olmayabilecekse, yazı tiplerini HTML'de [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedallfontshtmlcontroller/) ile gömün. Gömme görsel sadakati artırır ancak çıktı boyutunu artırır.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Yazı tiplerini yalnızca hedef tarayıcıların veya sistemlerin zaten sağladığından emin olduğunuzda hariç tutun. Marka yazı tipleri veya daha az yaygın yazı tipleri için gömme genellikle daha güvenlidir.

## **Yazı Tipi Dosyalarını Gömmek Yerine Bağlantı Ver**

HTML dosya boyutunu azaltmak için, yazı tipi verilerini ayrı WOFF dosyalarına yazabilir ve HTML'ye `@font-face` kuralları ekleyebilirsiniz. Aşağıdaki yardımcı, [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedallfontshtmlcontroller/) sınıfını genişletir ve `WriteFont` metodunu geçersiz kılar.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Bu örnekte, yazı tipi dosyaları `html-output/fonts` klasörüne kaydedilir ve HTML, `fonts/BrandFont-normal-400.woff` gibi URL'lerle onlara referans verir. HTML dosyası ve yazı tipleri başka bir konuma dağıtılıyorsa, dağıtılan URL yoluyla eşleşecek şekilde `fontUrlPrefix` seçin.

## **Kaynakları Harici Olarak Kaydet**

Bağımsız HTML taşınması kolaydır, ancak gömülü Base64 kaynakları dosyayı büyük yapabilir. Uygulamanız dış kaynaklı resim dosyalarına ihtiyaç duyuyorsa, [ILinkEmbedController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/) uygulayın ve bunu [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) yapıcısına geçirin.

Kaynakları harici hale getirdiğinizde iki yolu kasıtlı olarak seçin:

- Dosya sistemi çıktı yolu, uygulamanızın oluşturulan resimleri, yazı tiplerini, ses veya video dosyalarını yazdığı yerdir.
- URL yolu, tarayıcının HTML belgesinden bu dosyaları yüklemek için kullandığı yoldur.

## **Medya Dosyalarını Dışa Aktar**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/videoplayerhtmlcontroller/) video ve ses dosyalarını dışa aktarır ve bunları bir tarayıcıda oynatabilecek HTML yazar. Yapıcısı şunları alır:

- `path`: oluşturulan medya dosyalarının yazılacağı dizin.
- `fileName`: oluşturulan HTML dosyasının adı.
- `baseUri`: HTML bağlantılarında medya dosyalarına kullanılan mutlak URI ön eki.

Eğer HTML dosyası `html-output/presentation.html` ve medya dosyaları `html-output/media` içinde kaydedilmişse, `path` diskteki medya dizinine işaret ederken, `baseUri` tarayıcının bakış açısından aynı dizine işaret etmelidir. Yerel önizleme için medya dizininden bir `file:///` URI oluşturabilirsiniz. Dağıtılmış bir uygulama için yayınlanmış medya dizininin mutlak URL'sini kullanın.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Özellikle sunucu uygulamalarında, dışa aktarım işine özgü benzersiz çıktı dizinleri kullanın. Paylaşılan çıktı yolları, farklı dönüşümlerden gelen dosyaların birbirinin üzerine yazılmasına neden olabilir.

## **Performans ve Kaynak Yönetimi**

HTML dönüşümü bir render işlemi olduğundan, işleme süresi ve bellek kullanımı slayt sayısı, görüntü çözünürlüğü, yazı tipleri, efektler, grafikler ve gömülü medya gibi faktörlere bağlıdır. Daha yüksek `PicturesCompression` DPI değerleri, gömülü yazı tipleri, SVG çıktısı ve tutulan kırpılmış görüntü alanları sadakati artırabilir ancak genellikle çıktı boyutunu artırır.

Toplu dönüşüm için:

- `Presentation` örneklerini hemen `Dispose` edin.
- Ayrı işler için ayrı çıktı dizinleri kullanın.
- Sadakat gerektiği durumlar dışında yaygın yazı tiplerini gömmekten kaçının.
- HTML önizleme veya küçük resimler için görüntü DPI'sını düşürün.
- Dağıtım yolları kesinleşene kadar kaynak sunumu, oluşturulan HTML ve dış kaynakları bir arada tutun.

## **SSS**

**HTML çıktısında bağlantılar korunur mu?**

Evet. Sunum bağlantıları HTML'ye dışa aktarılır ve hedef URL geçerli olduğunda tıklanabilir olarak kalır.

**Sunumları paralel olarak HTML'ye dönüştürebilir miyim?**

Evet, ancak bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. Farklı dosyaları ayrı sunum örnekleri, ayrı akışlar ve ayrı çıktı dizinleri ile işleyin. Ayrıntılar için [çoklu iş parçacığı rehberi](/slides/tr/cpp/multithreading/) bakın.

**Bir Presentation nesnesi iş parçacığı güvenli midir?**

Hayır. Tek bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği aynı iş parçacığında yüklenmeli, değiştirilip, kaydedilmeli ve `Dispose` edilmelidir. Paralel çalışma için, her iş parçacığına veya sürece bağımsız bir örnek oluşturun.

**Oluşturulan HTML dosyası neden büyük?**

Varsayılan dışa aktarım kaynakları doğrudan HTML içinde gömebilir. Gömülü yazı tipleri, yüksek DPI'lı görüntüler, medya, SVG içeriği ve tutulan kırpılmış görüntü alanları da boyutu artırır. Daha küçük çıktı gerektiğinde dış kaynakları kullanın, yaygın yazı tiplerini gömmekten kaçının ve `PicturesCompression` değerini düşürün.

**PowerPoint'te 24 pt gibi bir yazı tipi boyutu HTML'de 17.999819 pt olarak neden görünür?**

Bu, PowerPoint ve HTML'in farklı DPI modelleri kullanmasından kaynaklanabilir. PowerPoint metin boyutlarını 72 DPI temelinde tipografik puan olarak depolar, HTML ise 96 DPI modelinde CSS pikseline dayanır. Aspose.Slides bir sunumu HTML'ye dışa aktarırken, yazı tipi boyutu bu sistemler arasında çevrilir ve dönüşüm küçük yuvarlama farkları yaratabilir. Bu değerler gerçek bir görsel yazı tipi boyutu değişikliğini göstermez. Sadece PowerPoint ve HTML arasında metriklerin dönüştürülmesinden kaynaklanan matematiksel bir yan etkidir.

**Medya dışa aktarma için baseUri nasıl seçilmeli?**

`baseUri`'yi tarayıcının bakış açısından seçin ve mutlak bir URI olarak geçirin. Yerel önizleme için, çıktı dizininden `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` ile türetebilirsiniz. Dağıtımda, yayınlanan medya dizininin mutlak URL'sini kullanın. Dosya sistemi `path` ve tarayıcı `baseUri` aynı dize olmak zorunda değildir, ancak aynı kaynak konumunu tanımlamalıdır.

**Gizli slaytları dahil edebilir miyim?**

Evet. Gizli slaytların dışa aktarılması gerektiğinde [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) üzerinde `ShowHiddenSlides` değerini `true` yapın.