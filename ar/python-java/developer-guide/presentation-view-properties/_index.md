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
- تثبيت القسام العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للغة Python عبر Java لتخصيص شرائح PPT و PPTX و ODP — عدّل التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. تصف خصائص العرض العادي تموضع هذه المناطق. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض في نفس الحالة عند فتحه مرة أخرى كما كان عند آخر حفظ للعرض التقديمي.

تم إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/) و[NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/) والتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/).

## **حول NormalViewProperties**

تمثل خصائص العرض العادي.

الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) تحدد ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) تحدد ما إذا كان يجب أن يلتقط القاسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الطرق [getPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و[setPreferSingleView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) تحدد ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الطرق [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) تحدد الحالة التي يجب عرض شريط القاسم الأفقي أو العمودي فيها. شريط القاسم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة؛ شريط القاسم العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored).

الطرق [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و[getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop) تحدد حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما تُطبق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/python-java/aspose.slides/splitterbarstatetype/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) على التوالي.

## **حول استعادة NormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغراً ولا مكبراً).

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredTop)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) تحدد ما إذا كان يجب أن يعوّض حجم منطقة المحتوى الجانبية الحجم الجديد عند تعديل حجم النافذة التي تحتوي العرض داخل التطبيق.

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

{{% alert color="info" title="ملاحظة" %}}
يدعم Aspose.Slides for Python via Java تعديل قيمة التكبير الافتراضية بحيث تُطبق تلقائياً عند فتح العرض التقديمي. يمكن ذلك عبر ضبط [ViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للعرض التقديمي. يمكن تكوين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNotesViewProperties) برمجياً. في هذا الموضوع، سنستعرض مثالاً يوضح كيفية ضبط [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في [Aspose.Slides](/slides/ar/).
{{% /alert %}}

لتعيين خصائص العرض، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. اضبط [View Properties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. احفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

في المثال أدناه، نضبط قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ضبط خصائص العرض للعرض التقديمي.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # نسبة التكبير لعرض الشريحة.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # نسبة التكبير لعرض الملاحظات.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[عرض الشريحة](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#getSlideViewProperties))، وليس لكل قسم، لذا يطبق مجموعة واحدة من المعلمات على المستند بالكامل عند فتحه.

**هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة لتفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [خصائص العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getViewProperties) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.