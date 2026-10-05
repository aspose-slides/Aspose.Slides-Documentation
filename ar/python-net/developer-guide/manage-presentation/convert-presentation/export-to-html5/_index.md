---
title: "تحويل العروض التقديمية إلى HTML5 باستخدام بايثون"
linktitle: "العرض التقديمي إلى HTML5"
type: docs
weight: 40
url: /ar/python-net/export-to-html5/
keywords:
- "PowerPoint إلى HTML5"
- "OpenDocument إلى HTML5"
- "العرض التقديمي إلى HTML5"
- "شريحة إلى HTML5"
- "PPT إلى HTML5"
- "PPTX إلى HTML5"
- "ODP إلى HTML5"
- "حفظ PPT كـ HTML5"
- "حفظ PPTX كـ HTML5"
- "حفظ ODP كـ HTML5"
- "تصدير PPT إلى HTML5"
- "تصدير PPTX إلى HTML5"
- "تصدير ODP إلى HTML5"
- Python
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لبايثون عبر .NET. احفظ التنسيق والرسوم المتحركة والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint التقديمية إلى HTML5 باستخدام Aspose.Slides for Python عبر .NET. تغطي التصدير الأساسي، التحكم في رسوم تحريك الأشكال وانتقالات الشرائح، وتنسيق التعليقات. كما تقارن مخرجات HTML5 مع المخرجات المستندة إلى SVG للتصدير القياسي إلى HTML.

## **تصدير PowerPoint إلى HTML5**

المثال التالي يقوم بتحميل عرض تقديمي من دليل العمل ويحفظه بصيغة HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
إلى جانب مستند HTML، يقوم التصدير بإنشاء ملفات CSS و JavaScript الداعمة لتنسيق الشرائح، الرسوم المتحركة، التأثيرات، والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر المخرجات. تقوم الصفحة المولدة أيضًا بتحميل jQuery وAnime.js من شبكة CDN عامة؛ بدونهما لا يعمل تنقل الشرائح أو الرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل تحريك الأشكال أو انتقالات الشرائح، قم بضبط [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) إلى `False` في [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين واحدة وتعطيل الأخرى. المثال يقوم بتصدير العرض التقديمي مع تعطيل كلا نوعي الرسوم المتحركة في الصفحة المولدة.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهجًا مختلفًا في العرض: يتم تمثيل محتوى الشريحة بـ SVG داخل صفحة HTML. المثال التالي يقوم بتحويل عرض تقديمي إلى مستند HTML باستخدام هذا النهج في العرض.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

الترميز المبسط أدناه يوضح بنية الصفحة المولدة. يحتوي عنصر SVG على محتوى الشريحة المُعَرض؛ نص العنصر النائب يمثل ذلك المحتوى وليس مخرجات التصدير الفعلية.

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
التصدير المستند إلى SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات تحريك الأشكال وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يُنتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. المثال يفعّل كلٍ من [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) حتى يتمكن عرض الشرائح المُصدّر من تشغيل التأثيرات من العرض المصدر.

استخدم عرضًا تقديميًا يحتوي مسبقًا على تحريكات الأشكال وانتقالات الشرائح لتلاحظ تأثير هذه الإعدادات. تمكينها لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح المستند HTML5 المُولد في متصفح مع توفر ملفاته الداعمة.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين تعليقات الشرائح الحالية في مخرجات HTML5 حتى يتمكن القارئ من رؤية الملاحظات جنبًا إلى جنب مع محتوى الشريحة. المثال في هذا القسم يتوقع أن يحتوي العرض المصدر على تعليقات، كما هو موضح أدناه. يقوم بتصدير تلك التعليقات؛ ولا ينشئ تعليقات جديدة.

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

قم بتعيين كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) إلى خاصية [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) في [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). اضبط [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) إلى `RIGHT` من تعداد [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) لتضع التعليقات على يمين كل شريحة.

المثال التالي يصدر العرض التقديمي إلى HTML5 باستخدام تخطيط التعليقات هذا. العرض التقديمي بدون تعليقات لن يحتوي على نص تعليق للعرض.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

الصورة أدناه تُظهر مستند HTML5 المُصدّر مع عرض التعليقات بجانب الشريحة.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد روابط JavaScript أثناء التصدير**

افترض أن ملف `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد رابط JavaScript أثناء التصدير، اضبط [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) إلى `True`. الإعداد الافتراضي هو `False`، لذا لن يتم تصفية هذه الروابط ما لم تقم بتمكين الخيار.

المثال التالي يقوم بتحميل العرض التقديمي من دليل العمل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

الملف المُصدّر يحذف رابط JavaScript مع الحفاظ على نصه والرابط HTTPS العادي. العرض التقديمي المصدر يبقى دون تغيير.

هذا الخيار يصفي روابط JavaScript؛ لا يزيل جميع السكريبتات أو المحتوى النشط الآخر، ولا يضمن الالتزام بـ CSP. على سبيل المثال، لا يزال مخرجات HTML5 تتضمن سكريبتات من أجل تنقل الشرائح والرسوم المتحركة.

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت تحريكات الكائنات وانتقالات الشرائح ستُشغل في HTML5؟**

نعم، يوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن تضمين التعليقات الحالية في مخرجات HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) من خلال [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/).

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بـ CSP؟**

نعم، يتيح لك الإعداد [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) تخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. الإعداد الافتراضي هو `False`. راجع [استبعاد روابط JavaScript أثناء التصدير](/slides/ar/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق التصفية. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.