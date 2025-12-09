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

{{% alert title="Info" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/net/aspose-slides-for-net-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5. ومع ذلك، إذا كنت تفضل تصدير PowerPoint إلى HTML باستخدام WebExtensions، راجع [هذا المقال](/slides/ar/net/web-extensions/) بدلاً من ذلك. 

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML دون استخدام امتدادات الويب أو الاعتماديات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تحدد عملية التصدير والـ HTML وCSS وJavaScript وخصائص الرسوم المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود C# كيفية تصدير عرض تقديمي إلى HTML5 دون امتدادات ويب أو اعتماديات:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لتحريكات الأشكال وانتقالات الشرائح بهذه الطريقة:
```c#
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

يظهر هذا الكود C# العملية القياسية لتصدير PowerPoint إلى HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG بصيغة مثل هذه:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 

عند استخدامك هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر محددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يسمح لك بتحويل عرض تقديمي PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة ويب. 

يعرض هذا الكود C# عملية تصدير PowerPoint إلى وضع عرض شرائح HTML5:
```c#
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

التعليقات في PowerPoint هي أداة تمكن المستخدمين من ترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التشاركية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة محددة دون تعديل المحتوى الرئيسي. كل تعليق يعرض اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظًا في الملف "sample.pptx".

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في الخاصية `NotesCommentsLayouting` من الفئة [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

يقوم المثال البرمجي التالي بتحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


يتم عرض المستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت تحريكات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [تحريكات الأشكال](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**هل يدعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) يتيح لك تخطي الروابط التي تستدعي JavaScript أثناء الحفظ. هذا يساعد على الامتثال لسياسات الأمان الصارمة.