---
title: تحويل العروض التقديمية إلى HTML5 في Python عبر Java
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للغة Python عبر Java. الحفاظ على التنسيق والرسوم المتحمية والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides للغة Python عبر Java. تغطي التصدير الأساسي، والتحكم في رسوم المتحركات للأشكال والانتقالات بين الشرائح، وتنسيق التعليقات. كما تقارن مخرجات HTML5 بمخرجات SVG المستندة إلى التصدير القياسي إلى HTML.

الأمثلة تتطلب Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. ضع عروض الإدخال في دليل العمل الحالي. يبدأ كل مثال الـ JVM فقط إذا لم يكن قيد التشغيل بالفعل.

## **تصدير PowerPoint إلى HTML5**

المثال التالي يحمل عرضًا تقديميًا من دليل العمل ويحفظه بصيغة HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
إلى جانب مستند HTML، يكتب التصدير ملفات CSS وJavaScript المساندة لتنسيق الشرائح والرسوم المتحركة والتأثيرات والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر النتيجة. كما تقوم الصفحة المُنشأة بتحميل jQuery وAnime.js من شبكات CDN العامة؛ بدونهما لن يعمل التنقل بين الشرائح ولا تُشغل الرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل رسوم متحركة للأشكال أو انتقالات الشرائح، مرّر `False` إلى [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) في [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين أحدهما مع تعطيل الآخر. المثال يُصدّر العرض التقديمي مع تعطيل كلا نوعي الرسوم المتحركة في الصفحة المُنشأة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تصدير PowerPoint إلى HTML**

يستخدم التصدير القياسي إلى HTML نهج عرض مختلف: يتم تمثيل محتوى الشريحة عبر SVG داخل صفحة HTML. المثال التالي يحول عرضًا تقديميًا إلى مستند HTML باستخدام هذا النهج في العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

العلامة المبسطة أدناه توضح بنية الصفحة المُنشأة. يحتوي عنصر SVG على محتوى الشريحة المرسوم؛ النص النائب يمثل ذلك المحتوى وليس مخرجات التصدير الفعلية.

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
التصدير المستند إلى SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفردة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات رسوم المتحركات للأشكال والانتقالات بين الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يُنتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. يفعّل هذا المثال كلًا من [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) حتى يتمكن عرض الشرائح المُصدّر من تشغيل التأثيرات من العرض الأصلي.

استخدم عرضًا تقديميًا يحتوي مسبقًا على رسوم متحركة للأشكال وانتقالات بين الشرائح لرؤية تأثير هذه الإعدادات. تمكينهما لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المُنشأ في متصفح مع توفر ملفاته المساندة.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين تعليقات الشرائح الموجودة في ناتج HTML5 بحيث يتمكن القراء من رؤية الملاحظات بجانب محتوى الشريحة. المثال في هذا القسم يتوقع أن يحتوي العرض المصدر على تعليقات، كما هو موضح أدناه. يُصدّر تلك التعليقات؛ ولا ينشئ تعليقات جديدة.

![Two comments on the presentation slide](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) في [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). استخدم [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) لاختيار `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) لوضع التعليقات إلى يمين كل شريحة.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

المثال التالي يُصدّر العرض التقديمي إلى HTML5 مع تخطيط التعليقات هذا. العرض التقديمي بدون تعليقات لن يحتوي على نص تعليقات للعرض.

![The comments in the output HTML5 document](two_comments_html5.png)

## **استبعاد الروابط التشعبية JavaScript أثناء التصدير**

افترض أن ملف `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد الرابط التشعبي JavaScript أثناء التصدير، مرّر `True` إلى [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). القيمة الافتراضية هي `False`، لذا لن تُفلتر هذه الروابط إلا إذا فعلت الخيار.

المثال التالي يحمل العرض التقديمي من دليل العمل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

الملف المُصدّر يحذف الرابط التشعبي JavaScript مع الحفاظ على نصه والرابط HTTPS العادي. يبقى العرض المصدر دون تغيير.

هذا الخيار يفلتر روابط JavaScript؛ ولا يزيل جميع النصوص البرمجية أو المحتوى النشط الآخر، ولا يضمن توافقًا مع CSP. على سبيل المثال، لا يزال ناتج HTML5 يتضمن نصوصًا برمجية للتنقل بين الشرائح والرسوم المتحركة.

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسوم المتحركات للكائنات والانتقالات بين الشرائح ستُشغل في HTML5؟**

نعم، يُوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و[slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في ناتج HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو تتعلق بـ CSP؟**

نعم، يسمح لك الإعداد [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) بتخطي الروابط التشعبية التي تحتوي على استدعاءات JavaScript أثناء الحفظ. القيمة الافتراضية هي `False`. راجع [Exclude JavaScript Hyperlinks During Export](/slides/ar/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال تصدير HTML5 ونطاق الفلتر. لا يزيل هذا الإعداد JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.