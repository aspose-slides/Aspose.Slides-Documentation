---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في بايثون عبر جافا
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/python-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- التقاط الفاصل العمودي
- عرض فردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للبايثون عبر جافا لتخصيص شرائح PPT و PPTX و ODP — تعديل التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **مقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. تصف خصائص العرض العادي موضع هذه المناطق. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض في نفس الحالة عند إعادة فتحه كما كان عندما تم حفظ العرض آخر مرة.

تم إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي لعرض تقديمي.

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/) و[NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/) والتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/).

## **حول NormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ما إذا كان يجب على التطبيق إظهار أيقونات عندما يتم عرض محتوى المخطط في أي من مناطق المحتوى وضع العرض العادي.

تحدد الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ما إذا كان يجب أن يلتقط الفاصل العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الطريقتان [getPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و[setPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدد الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو العمودي. الشريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة؛ والشريط الفاصل العمودي يفصل الشريحة عن المنطقة الجانبية. القيم المحتملة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored).

تحدد الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و[getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop) حجم المنطقة العلوية أو الجانبية من الشريحة في العرض العادي عندما تُطبق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) على التوالي.

## **حول استعادة NormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغراً ولا مكبرة).

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) ما إذا كان يجب على منطقة المحتوى الجانبية تعويض الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.

يعرض المثال أدناه كيفية الوصول إلى [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties) لعرض تقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # استعادة خصائص العرض للعرض التقديمي.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين قيمة التكبير الافتراضية**

{{% alert color="info" title="ملاحظة" %}}

يدعم Aspose.Slides for Python via Java تعيين قيمة التكبير الافتراضية بحيث تُطبق تلقائيًا عند فتح العرض التقديمي. يمكن تحقيق ذلك عبر تعيين [ViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للعرض التقديمي. يمكن تكوين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNotesViewProperties) برمجيًا. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) لـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في Aspose.Slides.

{{% /alert %}}

لتعيين خصائص العرض، اتبع الخطوات التالية:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. عيّن [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) لـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
3. احفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

في المثال أدناه، نعين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # تعيين خصائص العرض للعرض التقديمي.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # نسبة التكبير لعرض الشريحة.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # نسبة التكبير لعرض الملاحظات.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تتيح الطريقتان [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getGridSpacing) و[ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setGridSpacing) قراءة أو تغيير الفاصل الزمني لشبكة التحرير الأساسية. يُطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث تساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

المثال التالي يفتح ملف `demo.pptx` الموجود، يطبع تباعد الشبكة الحالي، يعيّن فاصل ربع بوصة، ثم يحفظ النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الشبكة تختلف عن [drawing guides](/slides/ar/python-java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسمية هي خطوط محاذاة أفقية أو عمودية موضوعة بشكل فردي. إضافة أو تحريك أو مسح الأدلة لا يغيّر تباعد الشبكة.

كلا من الشبكة والأدلة الرسمية هما أدوات مساعدة للتحرير. لا تُظهران كمحتوى شريحة في PDF أو الصور أو SVG أو عرض الشرائح. لا يضمن تخزين تباعد الشبكة أن يعرضه المحرر: تعتمد رؤيته أيضًا على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [ViewProperties.getShowComments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getShowComments) و[ViewProperties.setShowComments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setShowComments) لقراءة أو تغيير التفضيل المخزن بشأن ما إذا كان ينبغي إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

يتحكم هذا الإعداد فقط في التفضيل المخزن للعرض. لا يضيف أو يزيل أو يحرر أو يحل التعليقات. إخفاء التعليقات يحافظ على محتواها، ومؤلفيها، ومواقعها، وردودها، وحالاتها. راجع [Presentation Comments](/slides/ar/python-java/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود `comments.pptx` يحتوي على تعليقات. يطبع الإعداد الحالي لرؤية التعليقات، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يستخدم [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setLastView) مع [ViewType.SlideView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewtype/#SlideView) لتكوين عرض التحرير الأولي إلى جانب رؤية التعليقات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذا الإعداد لا يحدد ما إذا كانت التعليقات مدرجة في تصديرات PDF أو HTML أو الصور أو الملاحظات أو النشرات. قم بتكوين الخيارات الخاصة بكل صيغة تصدير بشكل منفصل.

## **الأسئلة المتكررة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

يخزن الملف تباعد الشبكة، لكن المحرر هو من يتحكم في ما إذا كانت الشبكة تظهر. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسمية إلى تغيير تباعد الشبكة؟**

لا. الأدلة الرسمية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties))، وليس لكل قسم، لذلك يُطبق مجموعة واحدة من المعلمات على المستند بأكمله عند فتحه.

**هل يمكنني تحديد حالات عرض مسبقة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك بين جميع المستخدمين. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة بحيث تُفتح العروض الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.