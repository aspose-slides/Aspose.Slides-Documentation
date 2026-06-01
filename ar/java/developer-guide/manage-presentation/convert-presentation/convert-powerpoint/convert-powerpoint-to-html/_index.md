---
title: تحويل عروض PowerPoint إلى HTML باستخدام Java
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML باستخدام Java. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي يتم بتحميل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) واحدة ثم استدعاء `save` مع [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، مخرجات SVG، أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير العرض بالكامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط، مستجيب، أو مبني على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقتصّة.
- تضمين الخطوط أو حفظ ملفات الخطوف بشكل منفصل.
- اختيار طريقة كتابة الموارد الخارجية وملفات الوسائط والإشارة إليها.

افتراضيًا، ينتج تصدير HTML مستندًا HTML موحدًا حيث تُدمج معظم الموارد. هذا ملائم لمشاركة ملف واحد، لكنه قد يزيد حجم الإخراج. للنشر على الويب، فكر في الموارد الخارجية، خفض DPI للصور، وتضمين الخطوط فقط إذا لم تتوفر بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض إلى HTML**

لتصدير عرض إلى HTML، حمّله باستخدام [Presentation](https://reference.aspos

e.com/slides/ar/java/com.aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض في كتلة `finally`، مما يحرّر مقابض الملفات وموارد العرض بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/) هي الفئة الأساسية لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف ملاحظات، تعليقات، أوراق توزيع، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يسلّم التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الإخراج.
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصورة المقتصّة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدّر يتكيف مع الحاوية الخاصة به.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

تُظهر الأقسام التالية أكثر الخيارات شيوعًا بصورة منفصلة حتى يمكنك دمج ما تحتاجه فقط لسيناريو عملك.

## **تحويل شرائح مختارة إلى HTML**

تُستخدم overload `Presentation.save` التي تقبل أرقام الشرائح بمواقع شرائح تبدأ من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة لها نفس التخطيط، أنشئ مثيلًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/) ومرره لكل استدعاء `save`.

## **إنشاء HTML مستجيب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/responsivehtmlcontroller/) يوفر مخرجات HTML مستجيبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmlformatter/). استخدمه عندما ينبغي للصفحة المصدّر أن تتكيف بشكل أفضل مع عرض المتصفح.

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

للتخطيط المستجيب المبني على SVG، اضبط `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/). هذا مفيد عندما يُصدَّر محتوى الشريحة كعلامة SVG قابلة للتوسيع.

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

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) عبر `HtmlOptions.setSlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواقعها.

لنفترض أن العرض الأصلي يحتوي على ملاحظات المتحدث:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

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

يشمل HTML المصدّر منطقة الملاحظات:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج كلاً من الملاحظات والتعليقات، اضبط كلا الخاصيتين.

## **التحكم في جودة الصورة والمساحات المقتصّة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الإخراج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

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

افتراضيًا، قد تُزال المناطق المقتصّة من الصور في الإخراج المصدّر. احتفظ بالبيانات المقتصّة فقط عندما يكون من الضروري أن يتمكن المستخدمون من استعادة أو فحص تلك الأجزاء المخفية من الصورة. الحفاظ عليها قد يزيد من حجم HTML.

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

للتنسيق البسيط، مرّر سلسلة CSS إلى `HtmlFormatter.createDocumentFormatter`. يغيّر هذا المستند HTML المحيط بينما يواصل Aspose.Slides عرض محتوى الشريحة.

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

لرأس مستند مخصص، ملف CSS مرتبط، أو تعليمات خاصة حول الشرائح والأشكال، نفّذ [IHtmlFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihtmlformattingcontroller/) ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmlformatter/) باستخدام `createCustomFormatter`.

## **تضمين الخطوط**

إذا كان من المحتمل ألا تكون خطوط العرض مثبتة في البيئة المستهدفة، ضمّن الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embedallfontshtmlcontroller/). يُحسّن التضمين من الدقة البصرية لكنه يزيد من حجم الإخراج.

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

استبعد الخطوط فقط عندما تكون واثقًا من أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامة التجارية أو الخطوط النادرة، يكون التضمين عادةً أكثر أمانًا.

## **ربط ملفات الخطوط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. المساعد أدناه يمد [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embedallfontshtmlcontroller/) ويتجاوز `writeFont`.

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

في هذا المثال، تُحفظ ملفات الخط في `html-output/fonts`، ويُشير HTML إليها باستخدام عناوين URL مثل `fonts/BrandFont-normal-400.woff`. إذا تم نشر ملف HTML والخطوط في موقع آخر، اختر `fontUrlPrefix` بحيث يتطابق مع مسار URL المنشور.

## **حفظ الموارد خارجيًا**

HTML المدمج سهل النقل، لكن الموارد المشفَّرة بـ Base64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صور خارجية، نفّذ [ILinkEmbedController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/).

عند استخراج الموارد إلى خارج، اختر مسارين بوعي:

- مسار نظام الملفات حيث يكتب تطبيقك الصور، الخطوط، الصوت، أو الفيديو المُولَّد.
- مسار URL وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكنه تشغيلها في المتصفح. يتضمن مُنشئه ما يلي:

- `path`: الدليل الذي تُكتب فيه ملفات الوسائط المُولَّدة.
- `fileName`: اسم ملف HTML الجاري إنشاؤه.
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML إلى ملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وملفات الوسائط تُحفظ في `html-output/media`, يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `baseUri` إلى نفس الدليل من منظور المتصفح. للمعاينة المحلية، يمكنك بناء URI من نوع `file:///` من دليل الوسائط. لتطبيق منشور، استخدم URL المطلق لدليل الوسائط المنشور.

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
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

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

استخدم أدلة إخراج تكون فريدة لكل مهمة تصدير، خصوصًا في تطبيقات الخادم. يمكن أن تتسبب مسارات الإخراج المشتركة في استبدال ملفات من تحويلات مختلفة ببعضها.

## **الأداء وإدارة الموارد**

تحويل HTML عملية عرض، لذا يعتمد زمن المعالجة واستخدام الذاكرة على عدد الشرائح، دقة الصورة، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. القيم الأعلى لـ `PicturesCompression` DPI، الخطوط المضمنة، مخرجات SVG، وتحتفظ بمناطق الصورة المقتصّة قد تحسّن الدقة لكن عادةً ما تزيد من حجم الإخراج.

للتحويل على دفعات:

- تخلص من كل مثيل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) بسرعة.
- استخدم أدلة إخراج منفصلة للوظائف المختلفة.
- تجنّب تضمين الخطوط الشائعة إلا إذا استدعت الدقة ذلك.
- خفّض DPI الصورة عندما يكون HTML مخصصًا للمعاينة أو المصغرات.
- احتفظ بالعرض الأصلي، HTML المولَّد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الروابط التشعبية في مخرجات HTML؟**

نعم. تُصَدَّر روابط العرض إلى HTML وتبقى قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض إلى HTML بصورة متوازية؟**

نعم، لكن لا تشارك مثيل واحد من [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) عبر الخيوط. عالج ملفات مختلفة بمثيلات عرض منفصلة، تدفقات منفصلة، وأدلة إخراج منفصلة. راجع دليل [multithreading guidance](/slides/ar/java/multithreading/) للحصول على التفاصيل.

**هل كائن Presentation آمن للخلط بين الخيوط؟**

لا. يجب تحميل، تعديل، حفظ، وتحرير مثيل واحد من [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) على خيط واحد فقط. للعمل المتوازي، أنشئ مثيلًا مستقلاً لكل خيط أو عملية.

**لماذا يكون ملف HTML المولَّد كبيرًا؟**

الإعداد الافتراضي قد يضمّن الموارد مباشرة داخل HTML. الخطوط المضمَّنة، الصور عالية DPI، الوسائط، محتوى SVG، والاحتفاظ بمناطق الصورة المقتصّة كلها تزيد من الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من التضمين، وخفّض `PicturesCompression` عندما يكون حجم أصغر أكثر أهمية من أقصى درجة من الدقة.

**كيف أختار baseUri لتصدير الوسائط؟**

اختر `baseUri` من منظور المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك اشتقاقه من دليل الإخراج باستخدام `mediaDirectory.toUri().toString()`. للنشر، استخدم URL مطلق لدليل الوسائط المنشور. لا يلزم أن تكون سلسلة نظام الملفات `path` و `baseUri` متطابقة، لكن يجب أن تصف نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. اضبط `ShowHiddenSlides` إلى `true` على [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/) عندما يجب تصدير الشرائح المخفية.