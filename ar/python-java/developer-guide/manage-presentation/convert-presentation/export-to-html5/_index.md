---
title: تحويل العروض إلى HTML5 في Python عبر Java
linktitle: العرض إلى HTML5
type: docs
weight: 40
url: /ar/python-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض إلى HTML5
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
- بايثون
- جافا
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للغة Python عبر Java. الحفاظ على التنسيق، التحريكات، والتفاعل."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides. تغطي التصدير الأساسي إلى HTML5 دون امتدادات ويب إضافية، بالإضافة إلى خيارات التحكم في تحريك الأشكال وانتقالات الشرائح. كما تعرض العملية القياسية لتصدير PowerPoint إلى HTML، وتوضح كيفية توليد ناتج HTML5 في وضع عرض الشرائح، وتبين كيفية تضمين التعليقات في المستند المُصدَّر عن طريق ضبط تخطيطها.

تتطلب الأمثلة Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. ضع الملف `pres.pptx` (أو `sample.pptx` لمثال التعليقات) في دليل العمل الحالي. يبدأ كل مثال تشغيل JVM فقط إذا لم يكن قيد التشغيل مسبقاً.

## **تصدير PowerPoint إلى HTML5**

استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Html5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html5) لتصدير العرض دون امتدادات ويب إضافية:

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

{{% alert color="info" title="ملاحظة" %}} 
المصدِّر HTML5 ينشئ محتوى HTML للعرض في المتصفح. 
{{% /alert %}}

استخدم [Html5Options](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/) لتكوين التصدير. استدعِ [setAnimateShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions) مع `False` لتعطيل تحريك الأشكال وانتقالات الشرائح:

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

استخدم [SaveFormat.Html](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html) للتصدير القياسي إلى HTML. راجع [Convert PowerPoint to HTML](/slides/ar/python-java/convert-powerpoint-to-html/) للمزيد من الخيارات:

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

في هذه الحالة، يتم عرض محتوى العرض عبر SVG على النحو التالي:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="تحذير" color="warning" %}} 
التصدير القياسي إلى HTML يعرض محتوى الشرائح عبر SVG ولا يوفر خيارات تحريك الأشكال وانتقالات الشرائح في HTML5. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض في وضع عرض الشرائح على صفحة الويب.

يعرض هذا الكود Python عملية تصدير PowerPoint إلى عرض شرائح HTML5:

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

## **تحويل العروض إلى مستندات HTML5 مع التعليقات**

التعليقات في PowerPoint أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. تُفيد بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاته أو ملاحظاته إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint محفوظ في الملف “sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كان سيتم تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، مرّر معلمات عرض التعليقات إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) من فئة [Html5Options](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/).

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) و[setCommentsPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) مع [CommentsPositions.Right](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Right). المثال التالي يحوِّل العرض إلى مستند HTML5 تُعرض فيه التعليقات إلى يمين الشرائح.

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

المستند “output.html” موضح في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت تحركات الكائنات وانتقالات الشرائح ستُشغَّل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) و[slide transitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions).

**هل يمكن تصدير التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بـ CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يتيح لك تخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. هذا يزيل تلك الروابط؛ لكنه لا يضمن بحد ذاته توافق جميع سكريبتات HTML5 المولَّدة مع سياسة أمان المحتوى الخاصة بالموقع.