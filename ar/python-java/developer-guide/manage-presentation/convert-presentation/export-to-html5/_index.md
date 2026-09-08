---
title: تحويل العروض التقديمية إلى HTML5 باستخدام بايثون عبر جافا
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/python-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض التقديمي إلى HTML5
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
- بايثون
- جافا
- Aspose.Slides
description: "صدّر عروض PowerPoint وOpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للغة بايثون عبر جافا. احرص على الحفاظ على التنسيق والرسوم المتحركة والتفاعل."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides. تغطي تصدير HTML5 الأساسي دون امتدادات ويب إضافية، بالإضافة إلى خيارات التحكم في رسوم المتحركات للأشكال وانتقالات الشرائح. كما تُظهر المقالة عملية التصدير القياسية من PowerPoint إلى HTML، وتشرح كيفية إنشاء مخرجات HTML5 في وضع عرض الشرائح، وتُظهر كيفية تضمين التعليقات في المستند المصدَّر من خلال تكوين تخطيطها.

تتطلب الأمثلة Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. ضع ملف `pres.pptx` (أو `sample.pptx` لمثال التعليقات) في دليل العمل الحالي. يبدأ كل مثال تشغيل الـ JVM فقط إذا لم يكن قيد التشغيل بالفعل.

## **تصدير PowerPoint إلى HTML5**

استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Html5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html5) لتصدير عرض تقديمي دون امتدادات ويب إضافية:

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

The HTML5 exporter creates HTML content for viewing in a browser. 

{{% /alert %}}

استخدم [Html5Options](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/) لتكوين التصدير. استدعِ [setAnimateShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions) مع القيمة `False` لتعطيل رسوم المتحركات للأشكال وانتقالات الشرائح:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تصدير PowerPoint إلى HTML**

استخدم [SaveFormat.Html](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html) لتصدير HTML القياسي. راجع [Convert PowerPoint to HTML](/slides/ar/python-java/convert-powerpoint-to-html/) للمزيد من الخيارات:

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

في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG في شكل مشابه لهذا:

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

Standard HTML export renders slide content through SVG and does not provide the HTML5 shape-animation and slide-transition options. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب.

يوضح هذا الكود بلغة Python عملية تصدير PowerPoint إلى عرض شرائح HTML5:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تحويل العروض التقديمية إلى مستندات HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تغيير المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظ في الملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، مرّر معلمات عرض التعليقات إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) في فئة [Html5Options](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/) .

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) و[setCommentsPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) مع [CommentsPositions.Right](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Right). المثال التالي من الشيفرة يحول عرضًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

المستند "output.html" موضوح في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسوم المتحركات للكائنات وانتقالات الشرائح ستُشغَّل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) و[slide transitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions).

**هل يتم دعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو بسبب سياسات CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يتيح لك تخطي الروابط التشعبية التي تستدعي JavaScript أثناء الحفظ. يزيل هذا الروابط؛ لكنه لا يضمن بحد ذاته أن جميع سكريبتات HTML5 المُولدة تتوافق مع سياسة أمان المحتوى للموقع.