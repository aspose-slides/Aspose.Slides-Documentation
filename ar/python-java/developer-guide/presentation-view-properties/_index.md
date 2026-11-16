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
- تقسيم عمودي قابل للانقضاط
- عرض مفرد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides ل Python عبر Java لتكوين تخطيط العرض العادي، وتكبير الشريحة والملاحظات، وتباعد الشبكة، ورؤية التعليقات في عروض PowerPoint التقديمية."
---
## **المقدمة**

في عرض العادي في PowerPoint، تظهر الشريحة بين لوحة جانبية للمصغرات أو المخطط ولوحة ملاحظات أسفلها. Aspose.Slides for Python عبر Java تكشف عن تفضيلات التحرير المحفوظة للعرض من خلال [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). تشمل هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، ورؤية التعليقات.

## **حول NormalViewProperties**

استخدم [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) للوصول إلى الفئة [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). يتحكم [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) فيما إذا كانت الأيقونات تظهر بجانب عناوين الشرائح في المخطط. يسمح [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) للوحة الجانبية بالانقضاط إلى حالتها المصغرة عندما يضيقها المستخدم. يشير [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.  
[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) يتحكم في الفاصل بين اللوحة الجانبية والشريحة. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) يتحكم في الفاصل فوق لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) وهي `Minimized`، `Maximized`، أو `Restored`.

## **حول استعادة NormalViewProperties**

عند استعادة الفاصل، يُقدِّم [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) الحجم المحفوظ للوحة الجانبية و [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) الحجم المحفوظ للمنطقة العليا من الشريحة. كلاهما يعيد مثيلاً من [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). طريقة [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) تقبل نسبة مئوية من 0 إلى 100، وتتحكم [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) فيما إذا كان المحرر يضبط الحجم عند تغيير حجم النافذة.  
هذا المثال يحدث عرضاً تقديمياً موجوداً. يستعيد الفاصل الأفقي، يضبط الحجم الذي تُرجعه [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) إلى 80٪ مع تمكين الضبط التلقائي، ويكبد الفاصل العمودي إلى الحالة القصوى. كما يستدعي [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) لعرض الأيقونات في عرض المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **تعيين قيمة التكبير الافتراضية**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) يخزنان إعدادات تكبير مستقلة للمحرر. لا تؤثر هذه الإعدادات على أبعاد الشرائح، تشغيل العرض الشرائحي، أو دقة تصدير الصور.  
يفتح هذا المثال عرضاً تقديمياً موجوداً ويستدعي [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) لتناسب الشريحة مع نافذة التحرير. بالنسبة لصفحة الملاحظات، يقوم بتعطيل التكبير التلقائي ويستدعي [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) لتعيين تكبير ثابت بنسبة 80٪.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **تعيين تباعد الشبكة**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) يحدد المسافة بين خطوط شبكة التحرير في جميع أنحاء العرض التقديمي. يأخذ قيمة موجبة بالنقاط، حيث يوجد 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة ربع بوصة بتعيين الفاصل إلى 18 نقطة.

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
تتكرر الشبكة على فاصل ثابت. [Drawing guides](/slides/ar/python-java/drawing-guides/) تميّز المواقع الأفقية أو العمودية الفردية. كلاهما أدوات تحرير وتظهر فقط في المحررات التي تعرضها. عروض الشرائح والتصدير إلى PDF أو صور أو SVG تتجاهلها.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) يخزن تفضيلاً يستخدمه المحررات المتوافقة عند فتح العرض التقديمي. بالنسبة لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) مع [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) لتفتح النسخة في عرض الشريحة.

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
إخفاء التعليقات يحافظ على نصها، مؤلفيها، مواقعها، ردودها، وحالاتها. لتغيير التعليقات نفسها، راجع [Presentation Comments](/slides/ar/python-java/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو نسخ مطبوعة.

## **الأسئلة الشائعة**

**لماذا تكون الشبكة مخفية عندما أعيد فتح العرض التقديمي؟**  
العرض التقديمي يخزن فاصل الشبكة. لرؤية الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسومية إلى تغيير تباعد الشبكة؟**  
لا. إضافة أو نقل أو مسح دليل لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تحتوي على إعدادات عرض مختلفة؟**  
لا. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) ينطبق على العرض التقديمي كاملًا.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**  
الملف يخزن مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات محلية للمستخدم.

**هل يمكنني حفظ إعدادات العرض في قالب؟**  
نعم. العروض التقديمية التي تُنشأ من القالب ترث إعدادات العرض المحفوظة.