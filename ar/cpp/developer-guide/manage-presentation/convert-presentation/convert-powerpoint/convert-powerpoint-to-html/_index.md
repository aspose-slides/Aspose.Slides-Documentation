---
title: تحويل عروض PowerPoint إلى HTML في C++
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/cpp/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML في C++. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) واحد واستدعاء `Save` مع [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، إخراج SVG، أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير عرض كامل أو شرائح محددة.  
- إنشاء HTML ثابت التخطيط، أو متجاوب، أو قائم على SVG.  
- إدراج ملاحظات المتحدث والتعليقات.  
- التحكم في جودة الصورة وبيانات المنطقة المقتصة.  
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.  
- اختيار طريقة كتابة الموارد الخارجية وملفات الوسائط والإشارة إليها.

بشكل افتراضي، ينتج تصدير HTML مستند HTML ذاتي‑الاحتواء حيث يتم تضمين معظم الموارد. هذا مريح للمشاركة كملف واحد، لكنه قد يزيد من حجم الناتج. للنشر على الويب، ضع في الاعتبار الموارد الخارجية، خفض DPI للصور، وتضمين الخطوط فقط عندما لا تكون متوفرة بثقة في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، قم بتحميله باستخدام [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) واحفظه باستخدام `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

تكتب هذه العينة ملف HTML واحد. يقوم الاستدعاء إلى `Dispose` بإصدار مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/) هي الفئة الأساسية لضبط تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف الملاحظات، التعليقات، الأوراق الموزعة، أو معلومات تخطيط أخرى.  
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى متحكم.  
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، مثلاً كـ SVG.  
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.  
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصورة المقتصة.  
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدّر يتكيف مع الحاوية الخاصة به.  
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

تظهر الأقسام التالية أكثر الخيارات شيوعًا بصورة منفصلة حتى تتمكن من دمج ما تحتاجه فقط في سير عملك.

## **تحويل شرائح مختارة إلى HTML**

تتحكم نسخة `Presentation::Save` التي تقبل أرقام الشرائح في مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة ذات تخطيط موحد، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/) ومرره إلى كل استدعاء `Save`.

## **إنشاء HTML متجاوب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/responsivehtmlcontroller/) يوفر إخراج HTML متجاوب عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmlformatter/). استخدمه عندما ينبغي للصفحة المصدَّرة أن تتكيف بشكل أفضل مع عرض المتصفح.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

للتخطيط المتجاوب القائم على SVG، اضبط `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/). هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامات SVG قابلة للتوسع.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **إدراج ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) عبر `HtmlOptions.SlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواضعها.

افترض أن العرض المصدر يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

يقوم الكود التالي بتصدير محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

يتضمن HTML المصدَّر منطقة الملاحظات:

![إخراج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، مثالًا إلى `CommentsPositions::Right` أو `CommentsPositions::Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج كلاً من الملاحظات والتعليقات، اضبط الخاصيتين معًا.

## **التحكم في جودة الصورة والمساحات المقتصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

افتراضيًا، قد تُزال المناطق المقتصة من الصور في الناتج المصدَّر. احتفظ بالبيانات المقتصة فقط عندما يجب على المستخدمين القدرة على استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **إضافة CSS**

للتصميم البسيط، مرّر سلسلة CSS إلى `HtmlFormatter::CreateDocumentFormatter`. هذا يغيّر مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

لإنشاء رأس مستند مخصص، أو ملف CSS مرتبط، أو علامات مخصصة حول الشرائح والأشكال، نفّذ [IHtmlFormattingController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ihtmlformattingcontroller/) ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmlformatter/) عبر `CreateCustomFormatter`.

## **تضمين الخطوط**

إذا كان من المحتمل ألا تكون خطوط العرض مثبتة في البيئة المستهدفة، قم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedallfontshtmlcontroller/). يؤدي التضمين إلى تحسين الدقة البصرية لكنه يزيد من حجم الناتج.

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

استثنِ الخطوط فقط عندما تكون واثقًا من أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامة التجارية أو الخطوط الأقل شيوعًا، يكون التضمين عادةً أكثر أمانًا.

## **ربط ملفات الخطوط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. يمدّد المساعد أدناه [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedallfontshtmlcontroller/) ويعيد تعريف `WriteFont`.

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

في هذا المثال، تُحفظ ملفات الخط في `html-output/fonts`، ويتولى HTML الإشارة إليها عبر عناوين URL مثل `fonts/BrandFont-normal-400.woff`. إذا تم نشر ملف HTML والخطوط في موقع آخر، اختر `fontUrlPrefix` بحيث يتطابق مع مسار URL المنشور.

## **حفظ الموارد خارجيًا**

HTML ذاتية‑الاحتواء سهل النقل، لكن الموارد المدمجة بترميز Base64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صور خارجية، نفّذ [ILinkEmbedController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/) ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/).

عند استخراج الموارد، اختر مسارين بدقة:

- مسار مخرجات نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت أو الفيديو المولَّدة.  
- مسار URL، وهو ما يستخدمه المتصفح من داخل مستند HTML لتحميل تلك الملفات.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكنه تشغيلها في المتصفح. يأخذ مُنشئه المعاملات التالية:

- `path`: الدليل الذي ستُكتب فيه ملفات الوسائط المولَّدة.  
- `fileName`: اسم ملف HTML الجاري إنشاؤه.  
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML لملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وملفات الوسائط تُحفظ في `html-output/media`، يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `baseUri` إلى نفس الدليل من وجهة نظر المتصفح. للمعاينة المحلية، يمكنك بناء URI من النوع `file:///` من دليل الوسائط. للتطبيق المنشور، استخدم URL المطلق لدليل الوسائط المنشور.

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

استخدم أدلة مخرجات فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. يمكن أن تتسبب المسارات المشتركة في استبدال ملفات التحويلات المختلفة بعضها ببعض.

## **الأداء وإدارة الموارد**

تحويل HTML هو عملية تصيير، لذا فإن زمن المعالجة واستهلاك الذاكرة يعتمد على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المدمجة. قيم DPI أعلى في `PicturesCompression`، الخطوط المضمَّنة، الإخراج بصيغة SVG، والاحتفاظ بمناطق الصور المقتصة يمكن أن تحسن الدقة لكن عادةً ما تزيد من حجم الناتج.

للتحويل على دفعات:

- حرّر كل كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) فورًا.  
- استخدم أدلة مخرجات منفصلة للوظائف المختلفة.  
- تجنّب تضمين الخطوط الشائعة إلا إذا كان الضرورة لضمان الدقة.  
- اخفض DPI للصور عندما يكون HTML مخصصًا للمعاينة أو المصغرات.  
- احتفظ بالعروض الأصلية، HTML المولَّد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتكررة**

**هل تُحافظ الروابط التشعبية في مخرجات HTML؟**  
نعم. تُصدَّر روابط العرض إلى HTML وتبقى قابلة للنقر عندما تكون URL الهدف صالحة.

**هل يمكنني تحويل العروض إلى HTML بشكل متوازي؟**  
نعم، لكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) واحد بين الخيوط. عالج ملفات مختلفة باستخدام كائنات عرض منفصلة، تدفقات منفصلة، وأدلة مخرجات منفصلة. راجع دليل [multithreading guidance](/slides/ar/cpp/multithreading/) لمزيد من التفاصيل.

**هل كائن Presentation آمن للمواضيع المتعددة؟**  
لا. يجب تحميل وتعديل وحفظ وتحرير كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) على خيط واحد فقط. للعمل المتوازي، أنشئ نسخة مستقلة لكل خيط أو عملية.

**لماذا يكون ملف HTML المولَّد كبيرًا؟**  
التصدير الافتراضي قد يضمّن الموارد مباشرة في HTML. الخطوط المضمَّنة، الصور ذات DPI عالي، الوسائط، محتوى SVG، والاحتفاظ بمناطق الصور المقتصة كلها تزيد من الحجم. استخدم موارد خارجية، استثنِ الخطوط الشائعة من التضمين، وقلل `PicturesCompression` عندما يكون حجم أصغر أهم من أعلى دقة.

**كيف أختار baseUri لتصدير الوسائط؟**  
اختر `baseUri` من وجهة نظر المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك توليده من دليل المخرجات باستخدام `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. للنشر، استخدم URL المطلق للدليل الإعلامي المنشور. لا يلزم أن يكون مسار نظام الملفات `path` والمسار في المتصفح `baseUri` نفس السلسلة، لكن يجب أن يشيرا إلى نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**  
نعم. اضبط `ShowHiddenSlides` إلى `true` على [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/) عندما يجب تصدير الشرائح المخفية.