---
title: تحويل عروض PowerPoint التقديمية إلى HTML في .NET
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint التقديمية إلى HTML في .NET. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET حفظ العروض التقديمية من PowerPoint كملف HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي يتم بتحميل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحد واستدعاء [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) مع [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير أو الخطوط أو الصور أو الملاحظات أو التعليقات أو إخراج SVG أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير العرض الكامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط أو مستجيب أو مستند إلى SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوف بشكل منفصل.
- اختيار طريقة كتابة الموارد المتصلة وملفات الوسائط والإشارة إليها.

بشكل افتراضي، ينتج تصدير HTML مستند HTML متكامل يحتوي على معظم الموارد المضمنة. هذا مناسب للمشاركة بملف واحد، لكنه قد يزيد من حجم الناتج. للنشر على الويب، فكر في استخدام موارد خارجية وخفض DPI للصور وتضمين الخطوط فقط عندما لا تكون متوفرة بشكل موثوق في بيئة الهدف.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، حمّله باستخدام [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

تكتب هذه العينة ملف HTML واحد. يتم إتلاف كائن العرض التقديمي عبر بيان `using`، والذي يحرّر مؤشرات الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) هي الفئة الرئيسية لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف الملاحظات أو التعليقات أو النشرات أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يوجّه التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، مثلاً كملف SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الناتج.
- `DeletePicturesCroppedAreas`: يحتفظ أو يزيل بيانات الصورة المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المصدّر يتكيف مع الحاوية.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

تُظهر الأقسام التالية أكثر الخيارات شيوعًا بشكل منفصل حتى تتمكن من دمج ما تحتاجه فقط في سير عملك.

## **تحويل شرائح مختارة إلى HTML**

يتقبل التحميل الزائد لـ [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) أرقام الشرائح باستخدام مواضع 1‑based. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

استخدم هذا النمط عندما تحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل الشريحة ذات تخطيط موحد، أنشئ كائن [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) واحدًا ومرره إلى كل استدعاء `Save`.

## **إنشاء HTML مستجيب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/responsivehtmlcontroller/) يوفر إخراج HTML مستجيب عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmlformatter/). استخدمه عندما يجب أن يتكيف الصفح المصدّر مع عرض المتصفح بشكل أفضل.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

للتخطيط المستجيب القائم على SVG، عيّن `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/). وهذا مفيد عندما يُصدّر محتوى الشريحة كعلامات SVG قابلة للتوسيع.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) عبر `HtmlOptions.SlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواضعها.

افترض أن العرض التقديمي الأصلي يحتوي على ملاحظات متحدث:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

الكود التالي يصدر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

يتضمن HTML المصدّر منطقة الملاحظات:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

لتصدير التعليقات، عيّن `CommentsPosition`، مثلاً إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا كنت بحاجة فقط إلى التعليقات، احذف `NotesPosition`. إذا كنت بحاجة إلى الملاحظات والتعليقات معًا، عيّن الخاصيتين.

## **التحكم في جودة الصورة والمساحات المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. عيّن `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/net/aspose.slides.export/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

افتراضيًا، قد تُزال المناطق المقصوصة من الصور في الناتج المصدّر. احتفظ بالبيانات المقصوصة فقط عندما يحتاج المستخدمون إلى استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmlformatter/createdocumentformatter/). يغيّر هذا المستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشرائح.

