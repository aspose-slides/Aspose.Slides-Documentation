---
title: تحويل العروض التقديمية إلى HTML5 في .NET
linktitle: عرض تقديمي إلى HTML5
type: docs
weight: 40
url: /ar/net/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- عرض تقديمي إلى HTML5
- شريحة إلى HTML5
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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 مستجيب باستخدام Aspose.Slides لـ .NET. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة طريقة تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides. تغطي التصدير الأساسي إلى HTML5، بالإضافة إلى الخيارات للتحكم في رسوم حركة الأشكال وانتقالات الشرائح. كما تُظهر العملية القياسية لتصدير PowerPoint إلى HTML، وتوضح كيفية توليد مخرجات HTML5 في وضع عرض الشرائح، وتُظهر كيفية تضمين التعليقات في المستند المُصدَّر عن طريق ضبط تخطيطها.

## **تصدير PowerPoint إلى HTML5**

هذا الكود بلغة C# يوضح كيفية تصدير عرض تقديمي إلى HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
بالإضافة إلى مستند HTML، يكتب التصدير الملفات الداعمة التي يشير إليها: `pres.css`، `master.css`، `animation.js`، `effects.js`، و`navigation.js`. كما تقوم الصفحة المُولَّدة بتحميل jQuery وAnime.js من CDNs عامة؛ بدونهما لا تعمل تنقلات الشرائح ورسوم الحركة. 
{{% /alert %}}

قد ترغب في تحديد إعدادات رسوم حركة الأشكال وانتقالات الشرائح بهذه الطريقة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **تصدير PowerPoint إلى HTML**

هذا المثال بلغة C# يُظهر العملية القياسية لتصدير PowerPoint إلى HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG بالشكل التالي:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر محددة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ستظهر العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

هذا الكود بلغة C# يوضح عملية تصدير PowerPoint إلى عرض شرائح HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. تُظهر كل تعليق اسم الكاتب، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظ في الملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كان سيتم تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في الخاصية `NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/).

المثال التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

المستند "output.html" موضح في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

### هل يمكنني التحكم فيما إذا كانت رسوم الحركة للكيانات وانتقالات الشرائح ستعمل في HTML5؟

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animateshapes/) و[slide transitions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animatetransitions/).

### هل يتم دعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) من خلال [layout settings](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/notescommentslayouting/) للملاحظات والتعليقات.

### هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟

نعم، هناك [setting](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) يسمح لك بتخطي الروابط التي تستدعي JavaScript أثناء الحفظ. يساعد ذلك في الالتزام بسياسات الأمان الصارمة.