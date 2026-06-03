---
title: تحويل عروض PowerPoint إلى HTML على Android
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML على Android. استخدم Aspose.Slides for Android عبر Java لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمكنه حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي يتم عبر تحميل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحد واستدعاء `save` مع [SaveFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، مخرجات SVG، أو الموارد المرتبطة.

هذا الدليل يركز على سيناريوهات تصدير HTML العملية:

- تصدير عرض كامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط، مستجيب، أو مبني على SVG.
- تضمين ملاحظات المتحدث وتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.
- اختيار كيفية كتابة الإشارة إلى الموارد الخارجية وملفات الوسائط.

بشكل افتراضي، تصدير HTML ينتج مستند HTML مستقل حيث تُضمّن معظم الموارد. هذا مريح للمشاركة بملف واحد، لكنه قد يزيد حجم الناتج. للنشر على الويب، فكر في استخدام موارد خارجية، خفض DPI للصور، وتضمين الخطوط فقط عندما تكون غير متوفرة بموثوقية في البيئة المستهدفة.

## **تحويل عرض إلى HTML**

لتصدير عرض إلى HTML، حمّله باستخدام [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

هذا المثال يكتب ملف HTML واحد. يتم التخلص من كائن العرض في كتلة `finally`، مما يحرّر مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) هي فئة التكوين الرئيسية لتصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف ملاحظات، تعليقات، كتيبات، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصورة المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المُصدّر يتكيف مع حاويته.
- `ShowHiddenSlides`: يدرج الشرائح المخفية عند الحاجة.

الأقسام التالية تعرض الخيارات الأكثر شيوعًا بشكل منفصل حتى تتمكن من دمج ما يلزم فقط لسيناريو عملك.

## **تحويل شرائح مختارة إلى HTML**

تجاوز `Presentation.save` الذي يقبل أرقام الشرائح يستخدم مواضع الشرائح بنظام 1‑based. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج الموقع أو التطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة بنفس التخطيط، أنشئ كائن [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/) واحد ومرره إلى كل استدعاء `save`.

## **إنشاء HTML مستجيب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/responsivehtmlcontroller/) يوفر مخرجات HTML مستجيبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmlformatter/). استخدمه عندما يجب أن تتكيف الصفحة المصدّرة مع عرض المتصفح.

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

للتخطيط المستجيب المبني على SVG، اضبط `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/). هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامة SVG قابلة للتوسع.

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

افترض أن العرض الأصلي يحتوي على ملاحظات المتحدث:

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

HTML المصدّر يتضمن منطقة الملاحظات:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت تحتاج فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت تحتاج إلى كل من الملاحظات والتعليقات، اضبط الخصيتين معًا.

## **التحكم في جودة الصورة والمساحات المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

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

بشكل افتراضي، قد تُزيل المناطق المقصوصة من الصور في الناتج المصدّر. احتفظ بالبيانات المقصوصة فقط عندما يحتاج المستخدمون إلى استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

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

للتنسيق البسيط، مرّر سلسلة CSS إلى `HtmlFormatter.createDocumentFormatter`. هذا يغيّر مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

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

لرأس مستند مخصص، ملف CSS مرتبط، أو علامات مخصصة حول الشرائح والأشكال، نفّذ [IHtmlFormattingController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.sl