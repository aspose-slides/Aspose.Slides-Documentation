---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /python-net/export-to-html5/
keywords:
- PowerPoint إلى HTML
- الشرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- Java
- Aspose.Slides لـ Python عبر .NET
description: "تصدير PowerPoint إلى HTML5 في بايثون"
---

{{% alert title="معلومات" color="info" %}}

في **Aspose.Slides 21.9**، قمنا بتطبيق دعم لتصدير HTML5. ومع ذلك، إذا كنت تفضل تصدير PowerPoint الخاص بك إلى HTML باستخدام WebExtensions، يرجى الاطلاع على [هذه المقالة](/slides/net/web-extensions/) بدلاً من ذلك. 

{{% /alert %}} 

عملية التصدير إلى HTML5 هنا تسمح لك بتحويل PowerPoint إلى HTML بدون WebExtensions أو اعتمادات. بهذه الطريقة، باستخدام قوالبك الخاصة، يمكنك تطبيق خيارات مرنة جداً تحدد عملية التصدير و HTML و CSS و JavaScript وخصائص الرسوم المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود بلغة بايثون كيفية تصدير عرض تقديمي إلى HTML5 بدون WebExtensions وبدون اعتمادات:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم الشكل ورسوم الشرائح بهذه الطريقة:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **تصدير PowerPoint إلى HTML**

يعرض هذا الكود بلغة بايثون عملية تصدير PowerPoint إلى HTML القياسية:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG في شكل مثل هذا:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> محتوى الشريحة يأتي هنا </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر معينة. 

{{% /alert %}}

## **تصدير PowerPoint إلى HTML5 وضع الشريحة**

**Aspose.Slides** يسمح لك بتحويل عرض تقديمي PowerPoint إلى مستند HTML5 حيث يتم عرض الشرائح في وضع عرض الشريحة. في هذه الحالة، عند فتح الملف الناتج HTML5 في المتصفح، ترى العرض التقديمي في وضع عرض الشريحة على صفحة الويب. 

يعرض هذا الكود بلغة بايثون عملية تصدير PowerPoint إلى HTML5 وضع الشريحة:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # تصدير عرض تقديمي يحتوي على انتقالات الشرائح والرسوم المتحركة إلى HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # حفظ العرض التقديمي
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو تعليقات على شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر الشريحة المحددة دون تغيير المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفرض أنه لدينا عرض تقديمي PowerPoint محفوظ في ملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض التقديمي في الوثيقة الناتجة. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في خاصية `notes_comments_layouting` في [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) الفئة.

مثال الكود التالي يقوم بتحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات على يمين الشرائح.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

تم عرض وثيقة "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)