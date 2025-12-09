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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ .NET. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

{{% alert title="Info" color="info" %}}
في [Aspose.Slides 21.9](/slides/ar/net/aspose-slides-for-net-21-9-release-notes/)، قمنا بتنفيذ دعم لتصدير HTML5. ومع ذلك، إذا كنت تفضل تصدير PowerPoint إلى HTML باستخدام WebExtensions، راجع [هذه المقالة](/slides/ar/net/web-extensions/) بدلاً من ذلك. 
{{% /alert %}} 
تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML دون امتدادات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير ونتيجة HTML وCSS وJavaScript وخصائص الرسوم المتحركة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود C# كيفية تصدير عرض تقديمي إلى HTML5 دون امتدادات ويب وتبعيات:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 
في هذه الحالة، ستحصل على HTML نظيف. 
{{% /alert %}}

قد ترغب في تحديد إعدادات رسوم المتحركات للأشكال وانتقالات الشرائح بهذه الطريقة:
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

يعرض هذا الكود C# عملية التصدير القياسية من PowerPoint إلى HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG بصيغة مثل التالي:
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
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر محددة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، سترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

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

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. هي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.  

لنفترض أن لدينا عرض تقديمي PowerPoint التالي محفوظ في الملف "sample.pptx".  

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت ترغب في تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في خاصية `NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).  

مثال الكود التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
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


يتم عرض مستند "output.html" في الصورة أدناه.  

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسوم المتحركات للأجسام وانتقالات الشرائح ستعمل في HTML5؟**  
نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوم المتحركات للأشكال](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).  

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**  
نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) للملاحظات والتعليقات.  

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**  
نعم، هناك [إعداد](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) يتيح لك تخطي الروابط التشعبية التي تحتوي على استدعاءات JavaScript أثناء الحفظ. هذا يساعد على الامتثال للسياسات الأمنية الصارمة.