---
title: "تصدير إلى HTML5"
type: docs
weight: 40
url: /ar/net/export-to-html5/
keywords:
  - "PowerPoint إلى HTML"
  - "شرائح إلى HTML"
  - "HTML5"
  - "تصدير HTML"
  - "تصدير العرض التقديمي"
  - "تحويل العرض التقديمي"
  - "تحويل الشرائح"
  - "C#"
  - "Csharp"
  - "Aspose.Slides for .NET"
description: "تصدير PowerPoint إلى HTML5 باستخدام C# أو .NET"
---

{{% alert title="Info" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/net/aspose-slides-for-net-21-9-release-notes/) تم تنفيذ دعم لتصدير HTML5. ومع ذلك، إذا كنت تفضّل تصدير PowerPoint إلى HTML باستخدام WebExtensions، راجع [هذه المقالة](/slides/ar/net/web-extensions/) بدلاً من ذلك. 

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML دون الحاجة إلى ملحقات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة تُحدد عملية التصدير والـ HTML وCSS وJavaScript وسمات الرسوم المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود C# كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب أو تبعيات:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

في هذه الحالة ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لتحريك الأشكال وانتقالات الشرائح بهذه الطريقة:
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

يعرض هذا الكود C# العملية القياسية لتحويل PowerPoint إلى HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


في هذه الحالة يتم عرض محتوى العرض التقديمي عبر SVG بالشكل التالي:
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

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر محددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى وضع عرض الشرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

يعرض هذا الكود C# عملية تصدير PowerPoint إلى عرض الشرائح HTML5:
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

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تغيير المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في خاصية `NotesCommentsLayouting` من فصل [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) . 

الكود التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
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


يظهر مستند "output.html" في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت تحريكات الكائنات وانتقالات الشرائح ستُشغل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [تحريكات الأشكال](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشارحة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) يسمح بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد ذلك في الالتزام بسياسات الأمان الصارمة.