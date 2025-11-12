---
title: تحويل العروض التقديمية إلى HTML5 باستخدام بايثون
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
- تحويل العرض التقديمي
- تحويل الشريحة
- تصدير HTML5
- تصدير العرض التقديمي
- تصدير الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 مستجيب باستخدام Aspose.Slides للبايثون عبر .NET. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---

{{% alert title="معلومات" color="info" %}}

في **Aspose.Slides 21.9**، قمنا بتنفيذ دعم تصدير HTML5. ولكن إذا كنت تفضل تصدير PowerPoint إلى HTML باستخدام WebExtensions، راجع [هذه المقالة](/slides/ar/net/web-extensions/) بدلاً من ذلك. 

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML دون ملحقات ويب أو تبعيات. بهذه الطريقة، يمكنك باستخدام القوالب الخاصة بك تطبيق خيارات مرنة جدًا تُعرِّف عملية التصدير ونتائج HTML وCSS وJavaScript وخصائص الرسوم المتحركة. 

## **تصدير PowerPoint إلى HTML5**

يُظهر هذا الكود بايثون كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب أو تبعيات:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

في هذه الحالة ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات الرسوم المتحركة للأشكال وانتقالات الشرائح بهذه الطريقة:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **تصدير PowerPoint إلى HTML**

يُظهر هذا الكود بايثون عملية PowerPoint إلى HTML القياسية:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

في هذه الحالة يُعرض محتوى العرض التقديمي عبر SVG بصيغة كهذه:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> محتوى الشريحة يوضع هنا </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدامك لهذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك العناصر بشكل محدد. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شريحة HTML5**

يتيح **Aspose.Slides** لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض شريحة. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض شريحة على صفحة الويب. 

يوضح هذا الكود بايثون عملية تصدير PowerPoint إلى عرض شريحة HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # تصدير عرض تقديمي يحتوي على انتقالات الشرائح، الرسوم المتحركة، ورسوم تحريك الأشكال إلى HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # حفظ العرض التقديمي
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يعرض اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظ في الملف "sample.pptx".

![اثنان من التعليقات على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، يجب تحديد معلمات العرض للتعليقات في الخاصية `notes_comments_layouting` من فئة [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

المثال البرمجي التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

يُظهر المستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسومات الكائنات وانتقالات الشرائح ستُشغل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوم تحريك الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**هل تُدعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة للشفرة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) من خلال [إعدادات التخطيط](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، توجد [إعدادات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) تسمح بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد هذا على الالتزام بسياسات الأمن الصارمة.