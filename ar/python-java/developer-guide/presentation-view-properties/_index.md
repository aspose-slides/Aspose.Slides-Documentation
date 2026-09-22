---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في Python عبر Java
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/python-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- إغلاق القاسم العمودي
- عرض مفرد
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
description: "اكتشف خصائص العرض في Aspose.Slides for Python عبر Java لتخصيص شرائح PPT، PPTX، وODP — ضبط التخطيطات، مستويات التكبير، وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. تصف خصائص العرض العادي موضع هذه المناطق. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة هي نفسها كما كانت عند حفظ العرض التقديمي آخر مرة.

تمت إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تمت إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/) و[NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/) والتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/).

## **حول NormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ما إذا كان ينبغي للتطبيق إظهار الرموز عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ما إذا كان يجب أن ينقلب القاسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الطريقتان [getPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و[setPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يتضمن ثلاث مناطق محتوى. إذا تم تمكين ذلك، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) الحالة التي يجب أن يُعرض فيها شريط القاسم الأفقي أو العمودي. يفصل شريط القاسم الأفقي بين الشريحة ومنطقة المحتوى أسفل الشريحة؛ يفصل شريط القاسم العمودي بين الشريحة ومنطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored).

تحدد الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و[getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop) حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي، عندما تُطبق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState)، على التوالي.

## **حول استعادة NormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغراً ولا مكبراً).

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) ما إذا كان حجم منطقة المحتوى الجانبية يجب أن يعوض الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties) لعرض تقديمي.

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

    # استعادة خصائص عرض العرض التقديمي.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين قيمة التكبير الافتراضية**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java يدعم تعيين قيمة التكبير الافتراضية بحيث تُطبّق فعلياً عند فتح العرض التقديمي. يمكن القيام بذلك بتعيين [ViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للعرض التقديمي. يمكن تكوين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNotesViewProperties) برمجياً. في هذا الموضوع، سنرى مثالاً يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) لـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في Aspose.Slides.
{{% /alert %}}

لتعيين خصائص العرض، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. تعيين [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
3. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

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

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ وتغيّر الطريقتان [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getGridSpacing) و[ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setGridSpacing) الفاصل الزمني للشبكة التحريرية الأساسية. يُطبّق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة واحدة. يُحدّد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة وفقاً لتوثيق API.

يفتح المثال التالي ملف `demo.pptx` الموجود مسبقاً، يطبع تباعد الشبكة الحالي، يضبط فاصل ربع بوصة، ويحفظ النتيجة.

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

الشبكة تختلف عن [drawing guides](/slides/ar/python-java/drawing-guides/). تتحكم شبكة التباعد في فاصل منتظم، بينما تكون الأدلة الرسومية خطوط توجيه أفقية أو رأسية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كلٌ من الشبكة والأدلة الرسومية هما أدوات تحرير. لا يتم تصويرهما كجزء من محتوى الشريحة في ملفات PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة؛ فالرؤية تعتمد أيضاً على تفضيلات المشاهد أو المحرر.

## **الأسئلة الشائعة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر يتحكم في ما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسومية إلى تغيير تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

إعدادات العرض تُحدد على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties))، ولا تُحدد لكل قسم، لذا تُطبّق مجموعة واحدة من المعلمات على المستند بأكمله عند الفتح.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين مسبقاً؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مُعَرَّفة مسبقاً بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [view properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الابتدائي.