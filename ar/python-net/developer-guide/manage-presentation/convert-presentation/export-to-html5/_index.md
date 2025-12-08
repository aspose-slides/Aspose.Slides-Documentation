---
title: تحويل العروض التقديمية إلى HTML5 في Python
linktitle: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/python-net/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- عرض تقديمي إلى HTML5
- شريحة إلى HTML5
- PPT إلى HTML5
- PPTX إلى HTML5
- ODP إلى HTML5
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تصدير HTML5
- تصدير عرض تقديمي
- تصدير شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للـ Python عبر .NET. الحفاظ على التنسيق، الرسوم المتحركة، والتفاعل."
---

{{% alert title="معلومات" color="info" %}}

في **Aspose.Slides 21.9**، قمنا بتنفيذ دعم لتصدير HTML5. ومع ذلك، إذا كنت تفضل تصيح PowerPoint إلى HTML باستخدام WebExtensions، راجع [هذا المقال](/slides/ar/net/web-extensions/) بدلاً من ذلك. 

{{% /alert %}} 

تسمح لك عملية تصدير HTML5 هنا بتحويل PowerPoint إلى HTML دون الحاجة إلى WebExtensions أو أي تبعيات. وبهذا الشكل، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تحدد عملية التصدير والنتيجة من HTML وCSS وJavaScript وخصائص الرسوم المتحركة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود بلغة Python كيفية تصدير عرض تقديمي إلى HTML5 دون WebExtensions أو تبعيات:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```


{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات تحركات الشكل وانتقالات الشرائح بهذه الطريقة:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```


## **تصدير PowerPoint إلى HTML**

يوضح هذا الكود بلغة Python عملية التحويل القياسية من PowerPoint إلى HTML:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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


{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر محددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

Aspose.Slides يسمح لك بتحويل عرض تقديمي من PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ستظهر العرض التقديمي في وضع عرض الشرائح على صفحة ويب. 

يوضح هذا الكود بلغة Python عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # تصدير عرض تقديمي يحتوي على انتقالات الشرائح، والرسوم المتحركة، وتحركات الأشكال إلى HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # حفظ العرض التقديمي
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. إنها مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأشخاص متعددين إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر معينة في الشريحة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint التالي محفوظ في ملف "sample.pptx".

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في الخاصية `notes_comments_layouting` من الفئة [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) .

الكود التالي يوضح تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```


مستند "output.html" يظهر في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

**هل يمكنني التحكم في ما إذا كانت تحركات العناصر وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [تحركات الشكل](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**هل يدعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) من خلال [إعدادات التخطيط](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) للملاحظات والتعليقات.

**هل يمكنني تجنب الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) يتيح لك تخطي الروابط التي تستدعي JavaScript أثناء الحفظ. يساعد ذلك في الامتثال لسياسات الأمان الصارمة.