---
title: تحويل عروض PowerPoint إلى HTML على Android
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML على Android. استخدم Aspose.Slides for Android عبر Java لتصدير ملفات PPT و PPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمكنه حفظ عروض PowerPoint كـ HTML بدون Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحد واستدعاء `save` مع [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، مخرجة SVG، أو الموارد المرتبطة.

هذا الدليل يركز على سيناريوهات عملية لتصدير HTML:

- تصدير عرض تقديمي كامل أو شرائح محددة.
- إنشاء HTML بتصميم ثابت أو استجابة أو قائم على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.
- اختيار طريقة كتابة وإشارة الموارد الخارجية وملفات الوسائط.

بشكل افتراضي، ينتج تصدير HTML مستند HTML مستقل حيث يتم تضمين معظم الموارد. هذا ملائم لمشاركة ملف واحد، لكنه قد يزيد حجم الناتج. للنشر على الويب، ضع في الاعتبار الموارد الخارجية، تقليل DPI للصور، وتضمين الخطوط فقط إذا لم تتوفر بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، احمله باستخدام [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض التقديمي في كتلة `finally`، ما يحرّر مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) هو الفئة الرئيسية لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف الملاحظات، التعليقات، النشرات، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.
- `DeletePicturesCroppedAreas`: يحافظ أو يزيل بيانات الصورة المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدّر يتكيف مع الحاوية الخاصة به.
- `ShowHiddenSlides`: يضمّن الشرائح المخفية عند الحاجة.

الفقرات التالية تُظهر أكثر الخيارات شيوعًا بصورة منفصلة حتى تتمكن من دمج فقط ما يحتاجه سير عملك.

## **تحويل الشرائح المحددة إلى HTML**

تُستخدم نسخة `Presentation.save` التي تقبل أرقام الشرائح مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة ذات تخطيط متماثل، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) ومرره إلى كل استدعاء `save`.

## **إنشاء HTML مستجيب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/responsivehtmlcontroller/) يوفر مخرجات HTML مستجيبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmlformatter/). استخدمه عندما يجب أن يتكيف الصفحة المصدرة بشكل أفضل مع عرض المتصفح.

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

للتخطيط المستجيب القائم على SVG، اضبط `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/). هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامة SVG قابلة للتوسع.

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

## **تضمين ملاحظات المتحدث وتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) عبر `HtmlOptions.SlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواقعها.

افترض أن العرض التقديمي الأصلي يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

الكود التالي يصدر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

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

ناتج HTML يتضمن منطقة الملاحظات:

![ناتج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط التعليقات، احذف `NotesPosition`. إذا كنت تحتاج كلًا من الملاحظات والتعليقات، اضبط الخاصيتين معًا.

## **التحكم في جودة الصورة والمساحات المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturescompression/) عندما تحتاج جودة صورة أعلى.

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

بشكل افتراضي، قد تُزال المناطق المقصوصة من الصور في ناتج التصدير. احتفظ بالبيانات المقصوصة فقط عندما يجب أن يكون المستخدم قادرًا على استعادة أو فحص تلك الأجزاء المخفية من الصورة. الحفاظ عليها قد يزيد حجم HTML.

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

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى `HtmlFormatter.createDocumentFormatter`. هذا يغيّر مستند HTML المحيط بينما يستمر Aspose.Slides في تصيير محتوى الشريحة.

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

لإنشاء رأس مستند مخصص، ملف CSS مرتبط، أو علامة مخصصة حول الشرائح والأشكال، نفّذ [IHtmlFormattingController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihtmlformattingcontroller/) ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmlformatter/) باستخدام `createCustomFormatter`.

## **تضمين الخطوط**

إذا كان من الممكن أن البيئة المستهدفة لا تحتوي على خطوط العرض التقديمي مثبتة، قم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). التضمين يحسن الدقة البصرية لكنه يزيد حجم الناتج.

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

استبعد الخطوط فقط عندما تكون متأكدًا أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامية أو الخطوط الأقل شيوعًا، يكون التضمين عادةً أكثر أمانًا.

## **ربط ملفات الخطوط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. المساعد أدناه يمدّ [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) ويتجاوز `writeFont`.

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

في هذا المثال، تُحفظ ملفات الخط في `html-output/fonts`، ويشير HTML إليها عبر عناوين URL مثل `fonts/BrandFont-normal-400.woff`. إذا تم نشر ملف HTML والخطوط إلى موقع آخر، اختر `fontUrlPrefix` بحيث يتطابق مع مسار URL المنشور.

## **حفظ الموارد خارجيًا**

HTML المستقل سهل النقل، لكن الموارد المشفرة بـ Base64 يمكن أن تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صورة خارجية، نفّذ [ILinkEmbedController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/).

عند جعل الموارد خارجية، اختر طريقين بوعي:

- مسار إخراج نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت أو الفيديو المُنشأة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكنه تشغيلها في المتصفح. يأخذ المنشئ الخاص به:

- `path`: الدليل الذي سيتم كتابة ملفات الوسائط المُنشأة فيه.
- `fileName`: اسم ملف HTML الذي يتم إنشاؤه.
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML لملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وحُفظت ملفات الوسائط في `html-output/media`، يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `baseUri` إلى نفس الدليل من وجهة نظر المتصفح. للمعاينة المحلية، يمكنك بناء URI من نوع `file:///` من دليل الوسائط. لتطبيق منشور، استخدم URL المطلق لدليل الوسائط المنشور.

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

استخدم دلائل إخراج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخوادم. يمكن أن تتسبب مسارات الإخراج المشتركة في استبدال ملفات التحويلات المختلفة بعضها البعض.

## **الأداء وإدارة الموارد**

تحويل HTML هو عملية تصيير، لذا يعتمد وقت المعالجة واستخدام الذاكرة على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. قيم DPI أعلى في `PicturesCompression`، الخطوط المضمنة، مخرجات SVG، والحفاظ على مناطق الصورة المقصوصة يمكن أن يحسن الدقة لكن عادةً ما يزيد حجم الناتج.

للتحويل على دفعات:

- تخلص من كل مثال [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) على الفور.
- استخدم دلائل إخراج منفصلة للوظائف المختلفة.
- تجنب تضمين الخطوط الشائعة إلا إذا تطلبت الدقة ذلك.
- قلل DPI الصورة عندما يكون HTML للمعاينة أو الصور المصغرة.
- احتفظ بالعرض التقديمي الأصلي، HTML المُنشأ، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة الشائعة**

**هل يتم الحفاظ على الروابط الفائقة في ناتج HTML؟**

نعم. يتم تصدير روابط العرض التقديمي إلى HTML وتظل قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض التقديمية إلى HTML بشكل متوازي؟**

نعم، ولكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) الواحد عبر الخيوط. عالج ملفات مختلفة باستخدام أمثلة عرض تقديمي منفصلة، تدفقات منفصلة، ودلائل إخراج منفصلة. راجع [multithreading guidance](/slides/ar/androidjava/multithreading/) للحصول على التفاصيل.

**هل كائن Presentation آمن للاستخدام عبر الخيوط؟**

لا. يجب تحميل، تعديل، حفظ، والتخلص من مثال [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحد على خيط واحد. للعمل المتوازي، أنشئ مثالًا مستقلاً لكل خيط أو عملية.

**لماذا يكون ملف HTML الناتج كبيرًا؟**

التصدير الافتراضي يمكنه تضمين الموارد مباشرة في HTML. الخطوط المضمنة، الصور ذات DPI عالي، الوسائط، محتوى SVG، والحفاظ على مناطق الصورة المقصوصة تزيد جميعها الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من التضمين، وقلل `PicturesCompression` عندما يكون حجم أصغر أهم من أعلى دقة.

**كيف يجب أن أختار baseUri لتصدير الوسائط؟**

اختر `baseUri` من وجهة نظر المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك اشتقاقه من دليل الإخراج باستخدام `mediaDirectory.toUri().toString()`. للنشر، استخدم URL المطلق لدليل الوسائط المنشور. لا يلزم أن يكون ملف النظام `path` و`baseUri` نفس السلسلة، لكن يجب أن يصفا نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. اضبط `ShowHiddenSlides` إلى `true` على [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) عندما يجب تصدير الشرائح المخفية.