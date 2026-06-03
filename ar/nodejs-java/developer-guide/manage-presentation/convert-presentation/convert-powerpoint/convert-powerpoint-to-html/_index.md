---
title: تحويل عروض PowerPoint إلى HTML في Node.js
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
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
description: "تحويل عروض PowerPoint إلى HTML في Node.js. استخدم Aspose.Slides لـ Node.js عبر Java لتصدير ملفات PPT و PPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمكنه حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) مرة واحدة واستدعاء `save` مع [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، إخراج SVG، أو الموارد المرتبطة.

هذا الدليل يركز على سيناريوهات تصدير HTML العملية:

- تصدير العرض كاملًا أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط، أو استجابة، أو قائم على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقتطعة.
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.
- اختيار كيفية كتابة الموارد والملفات الوسائطية الخارجية والإشارة إليها.

افتراضيًا، ينتج تصدير HTML مستند HTML موحد حيث يتم تضمين معظم الموارد. هذا مريح للمشاركة بملف واحد، لكنه قد يزيد من حجم المخرجات. للنشر على الويب، ضع في الاعتبار الموارد الخارجية، تقليل DPI للصورة، وتضمين الخطوط فقط عندما لا تكون متوفرة بصورة موثوقة في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، حمّله باستخدام [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض في كتلة `finally`، مما يحرّر مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) هي الفئة الرئيسية لضبط تصدير HTML. الإعدادات الشائعة تشمل:

- `SlidesLayoutOptions`: تضيف ملاحظات، تعليقات، كتيبات، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كملف SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم المخرجات.
- `DeletePicturesCroppedAreas`: يحافظ على بيانات الصور المقتطعة أو يزيلها.
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدّر يتكيّف مع الحاوية الخاصة به.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

تُظهر الأقسام التالية الخيارات الأكثر شيوعًا بشكل منفصل حتى تتمكن من دمج ما يلزم فقط لسير عملك.

## **تحويل شرائح مختارة إلى HTML**

التحميل الزائد `Presentation.save` الذي يقبل أرقام الشرائح يستخدم مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون جميع الشرائح ذات التخطيط نفسه، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/) ومرره إلى كل استدعاء `save`.

## **إنشاء HTML استجابة**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/responsivehtmlcontroller/) يوفر مخرجات HTML استجابة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmlformatter/). استخدمه عندما يجب أن تتكيّف الصفحة المصدّرة بشكل أفضل مع عرض المتصفح.

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

للتخطيط المستجيب القائم على SVG، عيّن `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/). هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامة SVG قابلة للتوسع.

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

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/) عبر `HtmlOptions.setSlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواضعها.

لنفترض أن العرض التقديمي الأصلي يحتوي على ملاحظات للمتحدث:

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

يتضمن HTML المصدّر منطقة الملاحظات:

![إخراج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، عيّن `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج إلى كل من الملاحظات والتعليقات، عيّن الخاصيتين معًا.

## **التحكم في جودة الصورة والمساحات المقتطعة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم المخرجات. عيّن `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

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

افتراضيًا، قد تتم إزالة المناطق المقصوصة من الصور في المخرجات المصدّرة. احتفظ بالبيانات المقصوصة فقط عندما يجب على المستخدمين أن يكونوا قادرين على استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

{{9743b