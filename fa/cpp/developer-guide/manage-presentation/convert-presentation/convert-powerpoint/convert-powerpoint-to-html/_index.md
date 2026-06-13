---
title: تبدیل ارائه‌های PowerPoint به HTML با C++
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/cpp/convert-powerpoint-to-html/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ذخیره PowerPoint به عنوان HTML
- ذخیره ارائه به عنوان HTML
- ذخیره اسلاید به عنوان HTML
- ذخیره PPT به عنوان HTML
- ذخیره PPTX به عنوان HTML
- صادر کردن PPT به HTML
- صادر کردن PPTX به HTML
- C++
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML با C++. برای صادر کردن فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها از Aspose.Slides استفاده کنید."
---
## **مرور کلی**

Aspose.Slides برای C++ می‌تواند ارائه‌های PowerPoint را بدون Microsoft PowerPoint به HTML ذخیره کند. تبدیل پایه شامل یک بار بارگذاری [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) و یک فراخوانی `Save` با [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) است. هنگامی که نیاز به کنترل چیدمان صادر شده، قلم‌ها، تصاویر، نکات، نظرات، خروجی SVG یا منابع لینک شده دارید، از [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی صادرات HTML متمرکز است:

- صدور کل ارائه یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، واکنش‌گرا یا مبتنی بر SVG.
- گنجاندن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- قراردادن قلم‌ها یا ذخیره‌سازی فایل‌های قلم به صورت جداگانه.
- انتخاب نحوه نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌طور پیش‌فرض، صادرات HTML یک سند HTML خودکفا تولید می‌کند که اکثر منابع در آن قرار می‌گیرند. این برای به‌اشتراک‌گذاری یک فایل راحت است، اما می‌تواند حجم خروجی را افزایش دهد. برای انتشار در وب، منابع خارجی، DPI تصویر کمتر و قراردادن تنها قلم‌هایی که به‌صورت قابل اطمینان در محیط هدف موجود نیستند را در نظر بگیرید.

## **تبدیل یک ارائه به HTML**

برای صادر کردن یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگیری کنید و با `SaveFormat::Html` ذخیره کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

این مثال یک فایل HTML می‌نویسد. فراخوانی `Dispose` پس از صادرات دستگیره‌های فایل و منابع رندرینگ را آزاد می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) کلاس اصلی پیکربندی برای صادرات HTML است. تنظیمات رایج شامل:

- `SlidesLayoutOptions`: افزودن نکات، نظرات، برگه‌های توزیع یا سایر اطلاعات چیدمان.
- `HtmlFormatter`: ساختار سند HTML را تغییر می‌دهد یا قالب‌بندی را به یک کنترل‌کننده می‌سپارد.
- `SlideImageFormat`: نحوه نمایش اسلایدها را تغییر می‌دهد، برای مثال به عنوان SVG.
- `PicturesCompression`: DPI تصویر و اندازه خروجی را کنترل می‌کند.
- `DeletePicturesCroppedAreas`: داده‌های تصویر برش‌خورده را نگه می‌دارد یا حذف می‌کند.
- `SvgResponsiveLayout`: محتوای SVG صادر شده را طوری سازگار می‌کند که به ظرف خود سازگار شود.
- `ShowHiddenSlides`: در صورت نیاز اسلایدهای مخفی را شامل می‌شود.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نشان می‌دهند تا فقط گزینه‌های مورد نیاز جریان کاری خود را ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

بارگذاری بیشینه `Presentation::Save` که شماره اسلایدها را می‌پذیرد، موقعیت‌های اسلایدی ۱‑پایه استفاده می‌کند. حلقهٔ زیر هر اسلاید را در یک فایل HTML جداگانه ذخیره می‌کند.

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

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) ایجاد کنید و آن را به هر فراخوانی `Save` پاس بدهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmlformatter/) فراهم می‌کند. هنگامی که صفحه صادر شده باید بهتر به عرض مرورگر سازگار شود از آن استفاده کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

برای چیدمان واکنش‌گرا مبتنی بر SVG، `SvgResponsiveLayout` را بر روی [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) تنظیم کنید. این زمانی مفید است که محتوای اسلاید به صورت نشانه‌گذاری SVG مقیاس‌پذیر صادر شود.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **گنجاندن یادداشت‌های گوینده و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) از طریق `HtmlOptions.SlidesLayoutOptions` برای گنجاندن یادداشت‌های گوینده یا نظرات استفاده کنید. نکات و نظرات به‌طور پیش‌فرض مخفی هستند مگر آنکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائهٔ منبع شامل یادداشت‌های گوینده باشد:

![اسلاید با یادداشت‌های گوینده در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را همراه با یادداشت‌های گوینده در زیر اسلاید صادر می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

HTML صادر شده شامل ناحیهٔ یادداشت‌ها می‌شود:

![خروجی HTML با اسلاید و یادداشت‌های گوینده](HTML_with_notes.png)

برای صادر کردن نظرات، `CommentsPosition` را تنظیم کنید، برای مثال به `CommentsPositions::Right` یا `CommentsPositions::Bottom`. اگر فقط به نظرات نیاز دارید `NotesPosition` را حذف کنید. اگر به هر دو نیاز دارید، هر دو ویژگی را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

صادرات HTML می‌تواند تصاویر اسلاید را برای کاهش حجم خروجی فشرده کند. وقتی به کیفیت تصویر بالاتری نیاز دارید، `PicturesCompression` را به مقدار دلخواه از [PicturesCompression](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/picturescompression/) تنظیم کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

به‌طور پیش‌فرض، نواحی برش‌خوردهٔ تصاویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط زمانی نگه دارید که کاربران باید بتوانند آن بخش‌های مخفی تصویر را بازیابی یا بررسی کنند. نگه داشتن آن می‌تواند اندازهٔ HTML را افزایش دهد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **افزودن CSS**

برای استایل‌دهی ساده، یک رشتهٔ CSS را به `HtmlFormatter::CreateDocumentFormatter` پاس بدهید. این سند HTML پیرامونی را تغییر می‌دهد در حالی که Aspose.Slides به رندر محتوای اسلاید ادامه می‌دهد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

برای سربرگ سند سفارشی، فایل CSS لینک‌شده یا نشانه‌گذاری سفارشی دور اسلایدها و اشکال، [IHtmlFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ihtmlformattingcontroller/) را پیاده‌سازی کنید و آن را به [HtmlFormatter](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmlformatter/) با `CreateCustomFormatter` پاس دهید.

## **قراردادن قلم‌ها**

اگر محیط هدف ممکن است قلم‌های ارائه را نصب نکرده باشد، قلم‌ها را در HTML با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedallfontshtmlcontroller/) قرارداده کنید. قراردادن بهبود وفاداری بصری می‌دهد اما حجم خروجی را افزایش می‌دهد.

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

قلم‌ها را فقط زمانی حذف کنید که اطمینان دارید مرورگرها یا سیستم‌های هدف آنها را پیشاپیش فراهم می‌کنند. برای قلم‌های برند یا کم‌کاربرد، قراردادن معمولاً امن‌تر است.

## **اتصال فایل‌های قلم به‌جای قراردادن آن‌ها**

برای کاهش حجم فایل HTML، می‌توانید داده‌های قلم را در فایل‌های WOFF جداگانه بنویسید و قوانین `@font-face` را به HTML اضافه کنید. ابزار زیر [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedallfontshtmlcontroller/) را گسترش می‌دهد و `WriteFont` را بازنویسی می‌کند.

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

در این مثال، فایل‌های قلم در `html-output/fonts` ذخیره می‌شوند و HTML آنها را با URLهایی مانند `fonts/BrandFont-normal-400.woff` ارجاع می‌دهد. اگر فایل HTML و قلم‌ها در مسیر دیگری استقرار یابند، `fontUrlPrefix` را طوری انتخاب کنید که با مسیر URL استقرار مطابقت داشته باشد.

## **ذخیرهٔ منابع به‌صورت خارجی**

HTML خودکفا جابه‌جایی آسانی دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامهٔ شما به فایل‌های تصویری خارجی نیاز دارد، [ILinkEmbedController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/) را پیاده‌سازی کنید و آن را به سازندهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) پاس دهید.

هنگام خارجی‌سازی منابع، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی سیستم فایل، جایی که برنامه شما تصاویر، قلم‌ها، صدا یا ویدیوهای تولید شده را می‌نویسد.
- مسیر URL، مسیری که مرورگر از سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/videoplayerhtmlcontroller/) ویدیوها و فایل‌های صوتی را صادر می‌کند و HTMLی می‌نویسد که می‌تواند در مرورگر پخش شود. سازندهٔ آن شامل موارد زیر است:

- `path`: دایرکتوری که فایل‌های رسانه‌ای تولید شده در آن نوشته می‌شوند.
- `fileName`: نام فایل HTML که در حال تولید است.
- `baseUri`: پیشوند URI مطلق که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به دایرکتوری رسانه‌ای روی دیسک اشاره کند، در حالی که `baseUri` باید از دید مرورگر به همان دایرکتوری اشاره کند. برای پیش‌نمایش محلی می‌توانید یک URI `file:///` از دایرکتوری رسانه بسازید. برای برنامهٔ مستقر، URL مطلق دایرکتوری رسانهٔ منتشرشده را استفاده کنید.

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

از مسیرهای خروجی استفاده کنید که برای هر کار صادر کردن منحصر به‌فرد باشد، به‌ویژه در برنامه‌های سروری. مسیرهای خروجی مشترک می‌توانند باعث شوند فایل‌های تبدیل‌های مختلف یک‌دیگر را بازنویسی کنند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر DPI بالاتر `PicturesCompression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه داشتن نواحی برش‌خوردهٔ تصویر می‌تواند وفاداری را بهبود بخشد اما معمولاً حجم خروجی را افزایش می‌دهد.

برای تبدیل دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را به‌سرعت `Dispose` کنید.
- برای هر کار مسیرهای خروجی جداگانه استفاده کنید.
- از قراردادن قلم‌های عمومی خودداری کنید مگر اینکه وفاداری نیاز داشته باشد.
- DPI تصویر را هنگام استفاده برای پیش‌نمایش یا بندانگشتی‌ها کاهش دهید.
- تا زمان نهایی شدن مسیرهای استقرار، ارائهٔ منبع، HTML تولید شده و منابع خارجی را همراه نگه دارید.

## **سوالات متداول**

**آیا پیوندهای فرا hypertext در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ارائه به HTML صادر می‌شوند و وقتی URL هدف معتبر باشد قابل کلیک می‌مانند.

**آیا می‌توانم ارائه‌ها را به‌صورت هم‌زمان به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های جداگانهٔ ارائه، جریان‌های جداگانه و مسیرهای خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمایی چندرشته‌ای](/slides/fa/cpp/multithreading/) مراجعه کنید.

**آیا شیء Presentation ایمن برای استفاده در چند رشته است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) باید در یک رشته بارگذاری، تغییر، ذخیره و Dispose شود. برای کار موازی، یک نمونهٔ مستقل برای هر رشته یا فرآیند ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه داشتن نواحی برش‌خوردهٔ تصویر نیز حجم را افزایش می‌دهند. برای کاهش حجم، از منابع خارجی استفاده کنید، قلم‌های رایج را از جاسازی حذف کنید و `PicturesCompression` را وقتی اندازهٔ کوچک‌تر مهم‌تر از حداکثر وفاداری است، کاهش دهید.

**چرا اندازهٔ قلم PowerPoint مانند 24 pt در HTML به 17.999819 pt می‌رسد؟**

این به‌این دلیل است که PowerPoint و HTML مدل‌های DPI متفاوتی دارند. PowerPoint اندازهٔ متن را بر پایهٔ نقطهٔ تایپوگرافی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایهٔ پیکسل‌های CSS در مدل 96 DPI است. وقتی Aspose.Slides ارائه را به HTML صادر می‌کند، اندازهٔ قلم بین این سیستم‌ها تبدیل می‌شود و ممکن است اختلافات کوچک گرد شدن ایجاد شود.

این مقادیر نشان‌دهندهٔ تغییر واقعی در اندازهٔ دیداری قلم نیستند؛ فقط اثر جانبی ریاضیاتی تبدیل معیارهای متنی بین PowerPoint و HTML است.

**چگونه باید baseUri را برای خروجی رسانه انتخاب کنم؟**

baseUri را از دید مرورگر انتخاب کنید و به‌عنوان URI مطلق پاس بدهید. برای پیش‌نمایش محلی می‌توانید آن را از مسیر خروجی با `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` استخراج کنید. برای استقرار، URL مطلق دایرکتوری رسانهٔ منتشرشده را استفاده کنید. مسیر سیستم فایل `path` و `baseUri` مرورگر لازم نیست به‌صورت یک رشتهٔ یکسان باشند، اما باید همان مکان منبع را توصیف کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل شوم؟**

بله. وقتی اسلایدهای مخفی باید صادر شوند، `ShowHiddenSlides` را روی `true` در [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) تنظیم کنید.