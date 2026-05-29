---
title: تحويل عروض PowerPoint إلى HTML في Node.js
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML في Node.js. استخدم Aspose.Slides for Node.js عبر Java لتصدير ملفات PPT و PPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Node.js عبر Java حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) واحد وإجراء استدعاء `save` باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير أو الخطوط أو الصور أو الملاحظات أو التعليقات أو إخراج SVG أو الموارد المرتبطة.

يركّز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير عرض تقديمي كامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط أو مستجيب أو قائم على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.
- اختيار طريقة كتابة الموارد الخارجية وملفات الوسائط وإحالتها.

افتراضيًا، ينتج تصدير HTML مستند HTML مستقل حيث يتم تضمين معظم الموارد. هذا مريح لمشاركة ملف واحد، لكنه قد يزيد حجم الناتج. للنشر على الويب، ضع في الاعتبار الموارد الخارجية، خفض DPI للصور، وتضمين الخطوط فقط عندما لا تكون متوفرة بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، قم بتحميله باستخدام [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض التقديمي في كتلة `finally`، التي تُحرّر مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) هي فئة التكوين الأساسية لتصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف ملاحظات أو تعليقات أو نسخ مطبوعة أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصور المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المُصدّر يتكيّف مع الحاوية الخاصة به.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عندما يكون ذلك مطلوبًا.

تُظهر الأقسام التالية أكثر الخيارات شيوعًا بشكل منفصل حتى تتمكن من دمج فقط تلك التي تحتاجها سير عملك.

## **تحويل الشرائح المختارة إلى HTML**

الإصدار الزائد `Presentation.save` الذي يقبل أرقام الشرائح يستخدم مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة بنفس التخطيط، أنشئ نسخة واحدة من [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) ومرّرها إلى كل استدعاء `save`.

## **إنشاء HTML مستجيب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/responsivehtmlcontroller/) يوفّر مخرجات HTML مستجيبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmlformatter/). استخدمه عندما يجب أن تتكيف الصفحة المُصدّرة بشكل أفضل مع عرض المتصفح.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

للتخطيط المستجيب القائم على SVG، اضبط `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/). هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامات SVG قابلة للتوسيع.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/) عبر `HtmlOptions.setSlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تقم باختيار مواقعها.

افترض أن العرض التقديمي المصدر يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

الكود التالي يصدر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

يتضمن HTML المُصدّر منطقة الملاحظات:

![ناتج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج إلى كل من الملاحظات والتعليقات، اضبط كلا الخاصيتين.

## **التحكم في جودة الصورة والمساحات المقتطعة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

افتراضيًا، قد تُزال المناطق المقتطعة من الصور في الناتج المُصدّر. احتفظ ببيانات القص فقط عندما يجب على المستخدمين أن يكونوا قادرين على استعادة أو فحص تلك أجزاء الصورة المخفية. الحفاظ عليها يمكن أن يزيد حجم HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى `HtmlFormatter.createDocumentFormatter`. هذا يغيّر مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

لرأس مستند مخصص أو ملف CSS مرتبط أو علامة مخصصة حول الشرائح والأشكال، استخدم [HtmlFormatter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmlformatter/) مع متحكم تنسيق.

## **تضمين الخطوط**

إذا كان من الممكن أن البيئة المستهدفة لا تحتوي على خطوط العرض التقديمي مثبتة، فقم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). التضمين يحسن الدقة البصرية لكنه يزيد حجم الناتج.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

استبعد الخطوط فقط عندما تكون واثقًا من أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة لخطوط العلامة التجارية أو الخطوط الأقل شيوعًا، يكون التضمين عادةً أكثر أمانًا.

## **ربط ملفات الخطوط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. في Node.js عبر Java، يتم عادة تنفيذ هذا السيناريو باستخدام فئة مساعدة Java صغيرة تمتد من [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/embedallfontshtmlcontroller/)، وتكتب بايتات الخط إلى دليل إخراج، وتُدخل قواعد `@font-face` في HTML المُولد. قم بتجميع تلك المساعدة، وأضفها إلى مسار فئة وحدة Node.js، ثم أنشئ مثيلًا منها من JavaScript باستخدام `java.newInstanceSync`.

عند بناء مثل هذه المساعدة، اختر مسارين عن عمد:

- مسار الإخراج في نظام الملفات، حيث تُكتب ملفات الخطوط المُولدة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك ملفات الخطوط.

## **حفظ الموارد خارجياً**

HTML المستقل سهل النقل، لكن الموارد المضمنة بصيغة Base64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صورة أو خط أو صوت أو فيديو خارجية، استخدم متحكم تصدير يكتب الموارد إلى دليل مختار ويصدر عناوين URL مرئية للمتصفح. حافظ على توافق مسار نظام الملفات ومسار URL مع تخطيط النشر الخاص بك.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكن تشغيلها في المتصفح. يأخذ مُنشئه:

- `path`: الدليل الذي تُكتب فيه ملفات الوسائط المُولدة.
- `fileName`: اسم ملف HTML الجاري توليده.
- `baseUri`: بادئة URI المطلقة المستخدمة في الروابط داخل HTML إلى ملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وملفات الوسائط محفوظة في `html-output/media`, يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `baseUri` إلى نفس الدليل من وجهة نظر المتصفح. للمعاينة المحلية، يمكنك إنشاء URI من النوع `file:///` من دليل الوسائط. لتطبيق مُنَشَر، استخدم عنوان URL المطلق لدليل الوسائط المنشور.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

استخدم دلائل إخراج تكون فريدة لكل عملية تصدير، خاصة في تطبيقات الخادم. يمكن أن تتسبب مسارات الإخراج المشتركة في استبدال الملفات من عمليات تحويل مختلفة.

## **الأداء وإدارة الموارد**

تحويل HTML هو عملية تصيير، لذا يعتمد وقت المعالجة واستهلاك الذاكرة على عدد الشرائح، دقة الصورة، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. قيم DPI أعلى في `PicturesCompression`، الخطوط المضمنة، مخرجات SVG، والحفاظ على مناطق الصور المقصوطة يمكن أن يحسن الدقة لكن عادةً ما يزيد حجم الناتج.

لتحويل مجموعة:

- تخلص من كل نسخة من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) على الفور.
- استخدم دلائل إخراج منفصلة للوظائف المختلفة.
- تجنب تضمين الخطوط الشائعة ما لم تتطلب الدقة ذلك.
- قلل DPI الصور عندما يكون HTML للاستخدام كمعاينة أو مصغرات.
- احتفظ بالعرض التقديمي المصدر، HTML المُولد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **FAQ**

**هل يتم الحفاظ على الروابط التشعبية في ناتج HTML؟**

نعم. يتم تصدير روابط العرض التقديمي إلى HTML وتظل قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض التقديمية إلى HTML بصورة موازية؟**

نعم، لكن لا تشارك نسخة واحدة من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) عبر العاملين. عالج ملفات مختلفة باستخدام نسخ عرض تقديمي منفصلة، تدفقات منفصلة، ودلائل إخراج منفصلة. راجع [إرشادات تعدد الخيوط](/slides/ar/nodejs-java/multithreading/) للتفاصيل.

**هل كائن Presentation آمن للاستخدام في خيوط متعددة؟**

لا. يجب تحميل، تعديل، حفظ، والتخلص من نسخة واحدة من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) في عامل واحد. للعمل المتوازي، أنشئ نسخة مستقلة لكل عامل أو عملية.

**لماذا يكون ملف HTML الناتج كبيرًا؟**

يمكن للتصدير الافتراضي تضمين الموارد مباشرة في HTML. الخطوط المضمنة، الصور عالية DPI، الوسائط، محتوى SVG، والحفاظ على مناطق الصور المقصوطة تزيد أيضًا من الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من التضمين، وقلل `PicturesCompression` عندما يكون حجم الناتج الأصغر أكثر أهمية من أقصى دقة.

**كيف أختار baseUri لتصدير الوسائط؟**

اختر `baseUri` من وجهة نظر المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك استنتاجه من دليل الإخراج باستخدام URI من النوع `file:///`. للنشر، استخدم URL المطلق لدليل الوسائط المنشور. لا يلزم أن يكون `path` في نظام الملفات و`baseUri` في المتصفح نفس السلسلة، لكن يجب أن يصفا نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. اضبط `ShowHiddenSlides` على `true` في [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) عندما يجب تصدير الشرائح المخفية.