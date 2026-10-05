---
title: تحويل العروض التقديمية إلى HTML5 في .NET
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/net/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض التقديمي إلى HTML5
- الشريحة إلى HTML5
- PPT إلى HTML5
- PPTX إلى HTML5
- ODP إلى HTML5
- حفظ PPT كـ HTML5
- حفظ PPTX كـ HTML5
- حفظ ODP كـ HTML5
- تصدير PPT إلى HTML5
- تصدير PPTX إلى HTML5
- تصدير ODP إلى HTML5
- .NET
- C#
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ .NET. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---
## **نظرة عامة**

يشرح هذا المقال كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides for .NET. يغطي التصدير الأساسي، والتحكم في تحريك الأشكال وانتقالات الشرائح، وتنسيق التعليقات. كما يقارن ناتج HTML5 مع الناتج القائم على SVG لتصدير HTML القياسي.

## **تصدير PowerPoint إلى HTML5**

المثال التالي يقوم بتحميل عرض تقديمي من دليل العمل ويحفظه بتنسيق HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة صراحةً. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
إلى جانب مستند HTML، يكتب التصدير ملفات CSS وJavaScript الداعمة لتنسيق الشرائح، والرسوم المتحركة، والتأثيرات، والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر الناتج. يتم تحميل jQuery وAnime.js من CDNs عامة؛ بدونهما لا تعمل تنقلات الشرائح والرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل تحريك الأشكال أو انتقالات الشرائح، اضبط [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) إلى `false` في [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين أحدهما مع تعطيل الآخر. يصدّر المثال العرض مع تعطيل كلا النوعين من الرسوم المتحركة في الصفحة المولدة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهج عرض مختلف: يتم تمثيل محتوى الشريحة بواسطة SVG داخل صفحة HTML. المثال التالي يحول عرضًا تقديميًا إلى مستند HTML باستخدام هذا النهج.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

الترميز المبسط أدناه يوضح بنية الصفحة المولدة. يحتوي عنصر SVG على محتوى الشريحة المرسوم؛ النص النائب يمثل ذلك المحتوى وليس مخرجات تصدير حرفية.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
التصدير القائم على SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات تحريك الأشكال وانتقالات الشرائح الموضحة في هذا المقال.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

ينتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض في المتصفح. يتيح هذا المثال كلًا من [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) حتى يتمكن عرض الشرائح المصدر من تشغيل التأثيرات.

استخدم عرضًا تقديميًا يحتوي مسبقًا على تحريك الأشكال وانتقالات الشرائح لتلاحظ تأثير هذه الإعدادات. تمكينهما لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المُولد في متصفح مع توفر الملفات المساعدة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين تعليقات الشرائح الموجودة في ناتج HTML5 حتى يتمكن القراء من رؤية الملاحظات جنبًا إلى جنب مع محتوى الشريحة. المثال في هذا القسم يفترض أن العرض التقديمي المصدر يحتوي على تعليقات، كما هو موضح أدناه. يقوم بتصدير تلك التعليقات؛ ولا ينشئ تعليقات جديدة.

![Two comments on the presentation slide](two_comments_pptx.png)

عيّن كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) إلى خاصية [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) في [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). اضبط [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) إلى `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) لتضع التعليقات إلى يمين كل شريحة.

المثال التالي يصدر العرض التقديمي إلى HTML5 مع تخطيط التعليقات هذا. العرض التقديمي الذي لا يحتوي على تعليقات لن يظهر نصًا للتعليقات.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

الصورة أدناه تُظهر مستند HTML5 المُصدر مع عرض التعليقات بجانب الشريحة.

![The comments in the output HTML5 document](two_comments_html5.png)

## **استبعاد الروابط الفائقة JavaScript أثناء التصدير**

افترض أن `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد الرابط الفائق JavaScript أثناء التصدير، اضبط [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) إلى `true`. القيمة الافتراضية هي `false`، لذا لا يتم تصفية هذه الروابط إلا إذا فعلت الخيار.

المثال التالي يحمل العرض التقديمي من دليل العمل ويصدره باستخدام [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

الملف المُصدر يحذف الرابط الفائق JavaScript مع الاحتفاظ بنصه والرابط HTTPS العادي. لا يتغير العرض التقديمي المصدر.

هذا الخيار يفلتر روابط JavaScript؛ ولا يزيل جميع البرامج النصية أو المحتوى النشط الآخر، ولا يضمن الامتثال لـ CSP. على سبيل المثال، يظل ناتج HTML5 يتضمن برامج نصية لتنقل الشرائح والرسوم المتحركة.

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسومات الكائنات وانتقالات الشرائح ستُشغل في HTML5؟**

نعم، يوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة للشفرة؟**

نعم، يمكن تضمين التعليقات الموجودة في ناتج HTML5 وتحديد موقعها (على سبيل المثال إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمان أو CSP؟**

نعم، يسمح لك إعداد [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) بتخطي الروابط الفائقة التي تحتوي على استدعاءات JavaScript أثناء الحفظ. القيمة الافتراضية هي `false`. راجع [Exclude JavaScript Hyperlinks During Export](/slides/ar/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال بسيط لتصدير HTML، HTML5، وPDF ونطاق الفلتر. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.