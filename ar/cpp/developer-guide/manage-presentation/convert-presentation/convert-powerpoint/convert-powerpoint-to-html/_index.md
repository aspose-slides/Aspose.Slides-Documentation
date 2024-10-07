---
title: تحويل PowerPoint إلى HTML باستخدام C++
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-html/
keywords: "C++ تحويل PowerPoint إلى HTML, تحويل عرض PowerPoint, PPTX, PPT, PPT إلى HTML, PPTX إلى HTML, PowerPoint إلى HTML, حفظ PowerPoint كـ HTML, حفظ PPT كـ HTML, حفظ PPTX كـ HTML, C++, CPP, Aspose.Slides, تصدير HTML"
description: "تحويل PowerPoint إلى HTML باستخدام C++. حفظ PPTX أو PPT كـ HTML في C++. حفظ الشرائح كـ HTML في C++"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام C++. تغطي المواضيع التالية.

- [تحويل PowerPoint إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل PPT إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل PPTX إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل ODP إلى HTML في C++](#convert-powerpoint-to-html)
- [تحويل شريحة PowerPoint إلى HTML في C++](#convert-slide-to-html)

## **C++ تحويل PowerPoint إلى HTML**

للحصول على كود مثال عن C++ لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من التنسيقات مثل PPT و PPTX و ODP في كائن العرض وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**

باستخدام [**Aspose.Slides لـ C++**](https://products.aspose.com/slides/cpp/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (صور، فيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث مضمنة أو غير مضمنة. 
* تحويل عرض PowerPoint إلى HTML مع التعليقات مضمنة أو غير مضمنة. 
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المضمنة. 
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام واجهتها البرمجية الخاصة، طورت Aspose محولات مجانية [للعرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على محولات أخرى [مجانية من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب عمليات التحويل الموصوفة هنا، يدعم Aspose.Slides أيضًا هذه العمليات التحويلية التي تتضمن تنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
   * تحميل **.ppt** في فئة _Presentation_ لتحويل **PPT إلى HTML في C++**
   * تحميل **.pptx** في فئة _Presentation_ لتحويل **PPTX إلى HTML في C++**
   * تحميل **.odp** في فئة _Presentation_ لتحويل **ODP إلى HTML في C++**
3. استخدم طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) لحفظ الكائن كملف HTML.

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML في C++:

```cpp
// قم بإنشاء كائن عرض يمثل ملف العرض
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// حفظ العرض كـ HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **تحويل PowerPoint إلى HTML متجاوب**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) التي تمكنك من إنشاء ملفات HTML متجاوبة. يظهر لك هذا الكود كيفية تحويل عرض PowerPoint إلى HTML متجاوب في C++:

```cpp
// قم بإنشاء كائن عرض يمثل ملف العرض
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// حفظ العرض كـ HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى HTML مع الملاحظات في C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// حفظ صفحات الملاحظات
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) التي تتيح لك تضمين جميع الخطوط في عرض تقديمي أثناء تحويل العرض إلى HTML.

لمنع تضمين بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ معتمد من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). لا تحتاج الخطوط الشائعة، مثل Calibri أو Arial، عند استخدامها في عرض تقديمي، إلى تضمينها، لأن معظم الأنظمة تحتوي بالفعل على هذه الخطوط. عندما يتم تضمين هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) التوريث وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77)، والتي من المقرر أن يتم تجاوزها.

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// استبعاد خطوط العرض الافتراضية
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عند تحويل PowerPoint إلى HTML، تقدم Aspose.Slides HTML صغيرًا مع صور بدقة 72 نقطة في البوصة ومناطق مقطوعة تم حذفها. للحصول على ملفات HTML بصور ذات جودة أعلى، يجب عليك تعيين خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression::Dpi96`) أو قيم أعلى [القيم](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

هذا الكود في C++ يوضح لك كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 نقطة في البوصة (أي `PicturesCompression::Dpi150`):

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

هذا الكود في C++ يوضح لك كيفية إخراج HTML مع صور بجودة كاملة:

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **تحويل شريحة إلى HTML**

لتحويل شريحة معينة في PowerPoint إلى HTML، عليك إنشاء مثيل من نفس فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدم طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) لتحديد خيارات تحويل إضافية:

هذا الكود في C++ يوضح لك كيفية تحويل شريحة في عرض PowerPoint إلى HTML:

```cpp
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

```cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>());
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

## **حفظ CSS والصور عند التصدير إلى HTML**

باستخدام ملفات الأنماط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML.

الكود في C++ في هذا المثال يوضح لك كيفية استخدام أساليب قابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```cpp
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

```cpp
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

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا تريد تضمين الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط عن طريق تنفيذ نسختك الخاصة من `LinkAllFontsHtmlController`.

هذا الكود في C++ يوضح لك كيفية تحويل PowerPoint إلى HTML أثناء ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (حيث أنها موجودة بالفعل في النظام): 

```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        : EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // قد تحتاج إلى بعض التنظيف في المسار
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

```cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // استبعاد خطوط العرض الافتراضية
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```

## **تحويل PowerPoint إلى HTML متجاوب**

هذا الكود في C++ يوضح لك كيفية تحويل عرض PowerPoint إلى HTML متجاوب:

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```

## **تصدير ملفات الوسائط إلى HTML**

باستخدام Aspose.Slides لـ C++، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

هذا الكود في C++ يوضح لك كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML: 

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

// تعيين خيارات HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// حفظ الملف
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```