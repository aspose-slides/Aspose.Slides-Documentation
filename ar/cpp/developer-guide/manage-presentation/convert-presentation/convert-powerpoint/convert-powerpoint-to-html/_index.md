---
title: تحويل عروض PowerPoint إلى HTML باستخدام C++
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/cpp/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML مستجيب باستخدام C++. الحفاظ على التخطيط والروابط والصور مع دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام C++. تغطي المواضيع التالية.

- [تحويل PowerPoint إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل PPT إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل PPTX إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل ODP إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل شريحة PowerPoint إلى HTML في C++](#convert-slide-to-html)

## **PowerPoint إلى HTML في C++**

للحصول على مثال كود C++ لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT وPPTX وODP في كائن Presentation وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**. 

**Aspose.Slides** توفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.  
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.  
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.  
* تحويل عرض PowerPoint إلى HTML مستجيب.  
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.  
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.  
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.  
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.  

{{% alert color="primary" %}} 

باستخدام واجهته البرمجية الخاصة، طوّر Aspose محولات مجانية [من عرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html) وغيرها. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب أيضًا في استكشاف [المحولات المجانية الأخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

إلى جانب عمليات التحويل الموصوفة هنا، يدعم Aspose.Slides أيضًا عمليات التحويل التالية المتعلقة بتنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/cpp/conversion/html-to-image/)  
* [HTML إلى JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)  
* [HTML إلى XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)  
* [HTML إلى TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)  

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
   * تحميل **.ppt** في فئة _Presentation_ لـ **تحويل PPT إلى HTML في C++**  
   * تحميل **.pptx** في فئة _Presentation_ لـ **تحويل PPTX إلى HTML في C++**  
   * تحميل **.odp** في فئة _Presentation_ لـ **تحويل ODP إلى HTML في C++**  
3. استخدم طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) لحفظ الكائن كملف HTML.

يعرض هذا الكود كيفية تحويل PowerPoint إلى HTML في C++:
```cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// حفظ العرض التقديمي إلى HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **تحويل PowerPoint إلى HTML مستجيب**
توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) التي تتيح لك إنشاء ملفات HTML مستجيبة. يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى HTML مستجيب في C++:
```cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// حفظ العرض التقديمي إلى HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **تحويل PowerPoint إلى HTML مع الملاحظات**
يعرض هذا الكود كيفية تحويل PowerPoint إلى HTML مع الملاحظات في C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**
توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) التي تتيح لك دمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ مُعامل من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). الخطوط الشائعة مثل Calibri أو Arial، عندما تُستخدم في عرض، لا تحتاج إلى دمجها لأن معظم الأنظمة تحتوي عليها مسبقًا. عندما تُدمج هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بلا داعٍ.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) الوراثة وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) التي يُقصد استبدالها.
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// استبعاد خطوط العرض التقديمي الافتراضية
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**
بشكل افتراضي، عندما تقوم بتحويل PowerPoint إلى HTML، ينتج Aspose.Slides ملفات HTML بصور بدقة 72 DPI ومناطق مقصوصة محذوفة. للحصول على ملفات HTML بصور ذات جودة أعلى، عليك ضبط خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression::Dpi96`) أو قيم أعلى [هنا](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

يعرض هذا الكود C++ كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور بجودة عالية بدقة 150 DPI (أي `PicturesCompression::Dpi150`):
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


يعرض هذا الكود في C++ كيفية إخراج HTML بصور ذات جودة كاملة:
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **تحويل شريحة إلى HTML**
لتحويل شريحة محددة في PowerPoint إلى HTML، يجب إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) لتحديد خيارات تحويل إضافية:

يعرض هذا الكود C++ كيفية تحويل شريحة في عرض PowerPoint إلى HTML:
``` cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // حفظ الملف              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```


## **حفظ CSS والصور عند تصدير إلى HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير مظهر ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML. 

يعرض الكود C++ في هذا المثال كيفية استخدام طرق قابلة للتهيئة لإنشاء مستند HTML مخصص يحتوي على رابط إلى ملف CSS:
``` cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Embedded fonts -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

``` cpp
void Run()
{
    // مسار دليل المستندات.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **ربط جميع الخطوط عند تحويل عرض إلى HTML**
إذا لم ترغب في دمج الخطوط (لتجنب زيادة حجم ملف HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة خاصة بك من `LinkAllFontsHtmlController`. 

يعرض هذا الكود C++ كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و"Arial" (لأنهما موجودان بالفعل في النظام):
```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // قد تحتاج إلى بعض تنقية المسار
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

``` cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // استبعاد خطوط العرض التقديمي الافتراضية
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **تحويل PowerPoint إلى HTML مستجيب**
يعرض هذا الكود C++ كيفية تحويل عرض PowerPoint إلى HTML مستجيب:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```



## **تصدير ملفات الوسائط إلى HTML**
باستخدام Aspose.Slides for C++، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
1. الحصول على مرجع إلى الشريحة.  
1. إضافة فيديو إلى الشريحة.  
1. كتابة العرض كملف HTML.

يعرض هذا الكود C++ كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:
```cpp
 // تحميل عرض تقديمي
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// ضبط خيارات HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// حفظ الملف
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **الأسئلة المتكررة**

**ما هو أداء Aspose.Slides عند تحويل عروض متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعال للغاية وقابل للتوسيع للعمليات الدُفعية. لتحقيق أفضل أداء عند تحويل العديد من العروض، يُنصح باستخدام التنفيذ المتعدد الخيوط أو المعالجة المتوازية كلما أمكن.

**هل يدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، يدعم Aspose.Slides تصدير الروابط التشعبية المدمجة إلى HTML بالكامل. عند تحويل العروض إلى تنسيق HTML، تُحافظ الروابط التشعبية تلقائيًا وتبقى قابلة للنقر.

**هل هناك حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة في الخادم أو النظام الخاص بك.