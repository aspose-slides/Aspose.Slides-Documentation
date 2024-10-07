---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /net/export-to-html5/
keywords:
- PowerPoint إلى HTML
- شرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "تصدير PowerPoint إلى HTML5 في C# أو .NET"
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/net/aspose-slides-for-net-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5. ومع ذلك، إذا كنت تفضل تصدير PowerPoint إلى HTML باستخدام WebExtensions، انظر [هذه المقالة](/slides/net/web-extensions/) بدلاً من ذلك.

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML دون استخدام إضافات الويب أو التبعية. بهذه الطريقة، باستخدام قوالبك الخاصة، يمكنك تطبيق خيارات مرنة جداً تحدد عملية التصدير وHTML وCSS وJavaScript وخصائص الرسوم المتحركة الناتجة.

## **تصدير PowerPoint إلى HTML5**

يوضح هذا الكود C# كيفية تصدير عرض تقديمي إلى HTML5 دون استخدام إضافات الويب والتبعية:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

في هذه الحالة، تحصل على HTML نظيف.

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم الشكل و انتقالات الشرائح بهذه الطريقة:

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

#### **تصدير PowerPoint إلى HTML**

يوضح هذا الكود C# عملية تصدير PowerPoint القياسية إلى HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG في شكل يشبه هذا:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> محتوى الشريحة هنا </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق أنماط أو تحريك عناصر معينة.

{{% /alert %}}

## **تصدير PowerPoint إلى HTML5 وضع العرض الشرائح**

**Aspose.Slides** تتيح لك تحويل عرض PowerPoint إلى وثيقة HTML5 يتم عرض الشرائح فيها في وضع عرض الشريحة. في هذه الحالة، عندما تفتح ملف HTML5 الناتج في متصفح، ترى العرض التقديمي في وضع عرض الشريحة على صفحة الويب.

يوضح هذا الكود C# عملية تصدير PowerPoint إلى HTML5 وضع العرض الشرائح:

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

## تحويل عرض تقديمي إلى وثيقة HTML5 مع التعليقات

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو تعليقات على شرائح العرض. إنها مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر الشرائح المحددة دون تغيير المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من غادر الملاحظة.

لنقل إن لدينا العرض التقديمي PowerPoint التالي محفوظًا في ملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى وثيقة HTML5، يمكنك بسهولة تحديد ما إذا كنت ترغب في تضمين التعليقات من العرض التقديمي في وثيقة الإخراج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في خاصية `NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

يوضح مثال الكود التالي كيفية تحويل عرض تقديمي إلى وثيقة HTML5 مع عرض التعليقات إلى يمين الشرائح.
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

تم عرض وثيقة "output.html" في الصورة أدناه.

![التعليقات في وثيقة HTML5 الناتجة](two_comments_html5.png)