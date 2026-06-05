---
title: تحويل عروض PowerPoint إلى HTML في PHP
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML في PHP. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for PHP عبر Java حفظ عروض PowerPoint التقديمية كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation] واحد فقط واستدعاء `save` مع [SaveFormat]. استخدم [HtmlOptions] عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، مخرجات SVG، أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير العرض التقديمي الكامل أو الشرائح المحددة.
- إنشاء HTML ثابت التخطيط، أو متجاوب، أو قائم على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقتطعة.
- دمج الخطوط أو حفظ ملفات الخط بشكل منفصل.
- اختيار طريقة كتابة وإحالة الموارد الخارجية وملفات الوسائط.

كنتيجة افتراضية، ينتج عن تصدير HTML مستند HTML ذاتي الاحتواء حيث يتم تضمين معظم الموارد. هذا مريح لمشاركة ملف واحد، لكنه قد يزيد حجم الناتج. للنشر على الويب، ضع في اعتبارك الموارد الخارجية، خفض DPI للصور، وتضمين الخطوط فقط إذا لم تكن متوفرة بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، قم بتحميله باستخدام [Presentation] واحفظه باستخدام [SaveFormat.Html].

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض في كتلة `finally`، التي تقوم بتحرير مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions] هي الفئة الرئيسية لإعداد تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف الملاحظات، التعليقات، النشرات، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغير بنية مستند HTML أو يفوض التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصورة المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدر يتكيف مع حاويته.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

الأقسام التالية تعرض الخيارات الأكثر شيوعًا بشكل منفصل حتى تتمكن من دمج تلك التي يحتاجها سير العمل الخاص بك فقط.

## **تحويل الشرائح المحددة إلى HTML**

التجاوز `save` الذي ينقبل أرقام الشرائح يستخدم مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن يكون لكل شريحة نفس التخطيط، أنشئ مثيلًا واحدًا من [HtmlOptions] ومرره إلى كل استدعاء `save`.

## **إنشاء HTML متجاوب**

[ResponsiveHtmlController] يوفر مخرجات HTML متجاوبة عبر [HtmlFormatter]. استخدمه عندما يجب أن تتكيف الصفحة المصدرة بشكل أفضل مع عرض المتصفح.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

للتخطيط المتجاوب القائم على SVG، اضبط `SvgResponsiveLayout` في [HtmlOptions]. هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامات SVG قابلة للتوسيع.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions] عبر `HtmlOptions.SlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تقم باختيار مواضعها.

لنفترض أن العرض المصدر يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

يقوم الشيفرة التالية بتصدير محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

يتضمن HTML المصدر منطقة الملاحظات:

![ناتج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج إلى كل من الملاحظات والتعليقات، اضبط الخاصيتين معًا.

## **التحكم في جودة الصورة والمناطق المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression] عندما تحتاج إلى جودة صورة أعلى.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

كنتيجة افتراضية، قد يتم إزالة المناطق المقصوصة من الصور في الناتج المصدر. احفظ البيانات المقصوصة فقط عندما يحتاج المستخدمون إلى استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها يمكن أن يزيد حجم HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **إضافة CSS**

للتنسيق البسيط، مرر سلسلة CSS إلى [HtmlFormatter] عبر `createDocumentFormatter`. هذا يغيّر مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

لرأس مستند مخصص، أو ملف CSS مرتبط، أو علامات مخصصة حول الشرائح والأشكال، استخدم متحكم تنسيق مخصص ومرره إلى [HtmlFormatter] باستخدام `createCustomFormatter`.

## **دمج الخطوط**

إذا كان من الممكن أن البيئة المستهدفة لا تحتوي على خطوط العرض التقديمي مثبتة، قم بدمج الخطوط في HTML باستخدام [EmbedAllFontsHtmlController]. الدمج يحسن الدقة البصرية لكنه يزيد حجم الناتج.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

استبعد الخطوط فقط عندما تكون واثقًا أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط الخاصة بالعلامة التجارية أو الخطوط الأقل شيوعًا، يكون الدمج عادةً أكثر أمانًا.

## **ربط ملفات الخط بدلاً من دمجها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. في PHP عبر Java، يُنفذ هذا السيناريو عادةً بفئة مساعدة Java صغيرة تمتد من [EmbedAllFontsHtmlController]، تكتب بايتات الخط إلى دليل إخراج، وتدرج قواعد `@font-face` في HTML المُولَّد. قم بتجميع هذه المساعدة، أضفها إلى مسار صف Java Bridge، ثم أنشئ كائنًا منها في PHP باستخدام `new Java(...)`.

عند بناء مثل هذا المساعد، اختر مسارين عمدًا:
- مسار الإخراج في نظام الملفات، حيث تُكتب ملفات الخط المُولدة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل ملفات الخط تلك.

## **حفظ الموارد خارجياً**

HTML ذاتي الاحتواء سهل النقل، لكن الموارد المشفرة بـ Base64 يمكن أن تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صور خارجية، قدم متحكم ربط/دمج مخصص إلى مُنشئ [HtmlOptions].

عند إخراج الموارد إلى الخارج، اختر مسارين عمدًا:
- مسار الإخراج في نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت، أو الفيديو المُولدة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

حافظ على توافق هذه المسارات مع بنية النشر الخاصة بك حتى يتمكن HTML المُولَّد من تحميل موارده الخارجية بعد نقله إلى خادم ويب أو دليل آخر.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController] يصدر ملفات الفيديو والصوت ويكتب HTML يمكنه تشغيلها في المتصفح. مُنشئه يأخذ:
- `path`: دليل الإخراج المستخدم من قبل HTML والملفات الإعلامية المُولدة.
- `fileName`: اسم ملف HTML الجاري إنشاؤه.
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML إلى ملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html`, يجب أن يشير `path` إلى `html-output`، ويجب أن يشير `baseUri` إلى نفس الدليل من وجهة نظر المتصفح. للمعاينة المحلية، يمكنك بناء URI من نوع `file:///` من دليل الإخراج. للتطبيق المنشور، استخدم URL مطلق لدليل الإخراج المنشور.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

استخدم أدلة إخراج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. المسارات المشتركة قد تتسبب في كتابة ملفات تحويلات مختلفة فوق بعضها البعض.

## **الأداء وإدارة الموارد**

تحويل HTML هو عملية تصيير، لذا يعتمد وقت المعالجة واستهلاك الذاكرة على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المدمجة. قيم DPI أعلى في `PicturesCompression`، الخطوط المدمجة، مخرجات SVG، والاحتفاظ بالمناطق المقصوصة قد تحسن الدقة لكن عادةً ما تزيد حجم الناتج.

لتحويل دفعي:
- تخلص من كل مثيل [Presentation] على الفور.
- استخدام أدلة إخراج منفصلة للوظائف المختلفة.
- تجنب دمج الخطوط الشائعة ما لم تتطلب الدقة ذلك.
- خفض DPI الصورة عندما يكون HTML للمعاينة أو المصغرات.
- احتفظ بالعرض المصدر، HTML المُولد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتكررة**

**هل تم الحفاظ على الروابط التشعبية في ناتج HTML؟**

نعم. يتم تصدير روابط العرض التقديمي إلى HTML وتظل قابلة للنقر عندما يكون عنوان URL الهدف صحيحًا.

**هل يمكنني تحويل العروض إلى HTML بالتوازي؟**

نعم، لكن لا تشارك مثيل [Presentation] واحد عبر الخيوط. عالج ملفات مختلفة باستخدام مثيلات عرض منفصلة، تدفقات منفصلة، وأدلة إخراج منفصلة.

**هل كائن Presentation آمن للخطوط المتعددة؟**

لا. يجب تحميل وتعديل وحفظ وتخلص من مثيل واحد من [Presentation] على خيط واحد فقط. للعمل المتوازي، أنشئ مثيلًا مستقلاً لكل خيط أو عملية.

**لماذا يكون ملف HTML المُولد كبيرًا؟**

الإعداد الافتراضي قد يُضمّن الموارد مباشرة في HTML. دمج الخطوط، صور عالية DPI، ملفات وسائط، محتوى SVG، والاحتفاظ بالمناطق المقصوصة يزيد من الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من الدمج، وخفض `PicturesCompression` عندما يكون حجم أصغر أهم من أقصى دقة.

**كيف يجب أن أختار baseUri لتصدير الوسائط؟**

اختر `baseUri` من منظور المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك استنتاجه من دليل الإخراج باستخدام URI ملف Java. للنشر، استخدم URL مطلق لدليل الوسائط المنشور. لا يلزم أن يكون `path` في نظام الملفات هو نفس سلسلة `baseUri`، لكن يجب أن يصفا نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. اضبط `ShowHiddenSlides` إلى `true` على [HtmlOptions] عندما يجب تصدير الشرائح المخفية.