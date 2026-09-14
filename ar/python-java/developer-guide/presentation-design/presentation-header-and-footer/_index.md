---
title: إدارة رؤوس وتذييلات العروض التقديمية في بايثون عبر جافا
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/python-java/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة عناصر النائب للتذييل، التاريخ/الوقت، رقم الشريحة، والرأس على الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides للبايثون عبر جافا."
---
## **نظرة عامة**

PowerPoint يستخدم عناصر نائبة مختلفة للرأس والتذييل بناءً على نوع الصفحة. يتيح Aspose.Slides for Python via Java التحكم في النص ورؤية هذه العناصر النائبة من خلال فئات مدير الرأس/التذييل.

العناصر النائبة المتوفرة تعتمد على النطاق:

| النطاق | رأس | تذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| القالب الرئيسي للملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| القالب الرئيسي للنشرات | نعم | نعم | نعم | نعم |

الشريحة العادية لا تحتوي على عنصر نائب للرأس. تتوفر رؤوس الصفحات في صفحات الملاحظات والنشرات. بالنسبة للشرائح العادية، استخدم عناصر النائب للتذييل، التاريخ/الوقت، ورقم الشريحة بدلًا من الرأس.

نطاق التغيير يعتمد على المدير الذي تستخدمه. فئة [SlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideheaderfootermanager/) تتحكم في شريحة عادية واحدة. فئة [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslideheaderfootermanager/) تتحكم في شريحة ملاحظات واحدة. يمكن لمديري القالب والتخطيط أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما فئة [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) تتحكم في القالب الرئيسي للنشرة.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح في الشرائح العادية**

بالنسبة للشرائح العادية، سير العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، تعيين نص التذييل والنص الزمني، تفعيل العناصر النائبة المطلوبة، ثم حفظ العرض. أرقام الشرائح تُولد تلقائيًا من قبل العرض، لذا تحتاج فقط للتحكم في رؤيتها.

استخدم [setFooterText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) و[setDateTimeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) لتعيين النص، واستخدم [setFooterVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)، [setDateTimeVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility)، و[setSlideNumberVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) لإظهار العناصر النائبة المقابلة.

المثال التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا كنت بحاجة لتحديث شريحة واحدة فقط، يمكنك الوصول إلى تلك الشريحة مباشرة عبر طريقة [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) بدلاً من الت iterating عبر المجموعة بأكملها.

## **تعيين الرؤوس والتذييلات في القالب الرئيسي للملاحظات**

القالب الرئيسي للملاحظات يحدد التنسيق المشترك وسلوك العناصر النائبة لصفحات الملاحظات. استخدم فئة [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/) عندما تريد تعديل القالب الرئيسي للملاحظات فقط.

المثال التالي يعين الرأس، التذييل، ونص التاريخ/الوقت في القالب الرئيسي للملاحظات ويجعل جميع العناصر النائبة المدعومة مرئية في ذلك القالب:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

طريقة `getMasterNotesSlide` تُرجع `None` عندما لا يحتوي العرض على قالب رئيسي للملاحظات.

## **تطبيق إعدادات القالب الرئيسي للملاحظات على شرائح الملاحظات التابعة**

يمكن للقالب الرئيسي للملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع شرائح الملاحظات التابعة. استخدم طرق النشر المخصصة على [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر تسلسل الملاحظات.

على سبيل المثال، تقوم [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) و[setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) بتحديث رأس القالب الرئيسي للملاحظات وجميع الرؤوس التابعة. توجد طرق مماثلة للتذييلات، التاريخ/الوقت، وأرقام الشرائح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

طرق النشر المستخدمة أعلاه هي [setFooterAndChildFootersText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)، [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)، [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)، [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility)، و[setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **تعيين الرؤوس والتذييلات في شريحة ملاحظات فردية**

شريحة الملاحظات تتبع شريحة عادية معينة. استخدم فئة [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة فقط.

طريقة [addNotesSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslidemanager/#addNotesSlide) تُرجع شريحة الملاحظات للشرحة الحالية وتُنشئ واحدة إذا لم تكن موجودة. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة في العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا قمت أولاً بنشر الإعدادات من القالب الرئيسي للملاحظات ثم غيرت شريحة ملاحظات فردية، فإن إعدادات كل شريحة تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تعيين الرؤوس والتذييلات في القالب الرئيسي للنشرات**

تستخدم صفحات النشرات القالب الرئيسي للنشرات لعناصر الرأس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات النشرات عبر القالب الرئيسي للنشرة بدلاً من الشرائح الفردية.

استخدم طريقة `getMasterHandoutSlide` للوصول إلى القالب الرئيسي للنشرة. إذا لم يكن موجودًا، استدعِ `setDefaultMasterHandoutSlide` لإنشاء القالب الرئيسي الافتراضي للنشرة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslideheaderfootermanager/) يتحكم في قالب شريحة عادية ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslideheaderfootermanager/) يتحكم في القالب الرئيسي للملاحظات ويمكنه نشر الإعدادات إلى جميع شرائح الملاحظات التابعة.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم عنصر رأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) يغيّر القالب الرئيسي للنشرة ويدعم جميع الأنواع الأربعة من العناصر النائبة.

استخدم النشر من قالب أو تخطيط عندما يجب تطبيق الإعداد نفسه عبر كل التسلسل الهرمي. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة الشائعة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. PowerPoint لا يعرف عنصر نائب للرأس في الشرائح العادية. في الشرائح العادية، استخدم عناصر التذييل، التاريخ/الوقت، ورقم الشريحة. عناصر الرأس متاحة في صفحات الملاحظات والنشرات.

**ماذا لو لم يكن عنصر التذييل أو التاريخ/الوقت أو رقم الشريحة مرئيًا؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، [isFooterVisible](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) يُظهر ما إذا كان عنصر التذييل موجودًا، و[setFooterVisibility](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) يغيّر رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استدعِ طريقة [setFirstSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#setFirstSlideNumber) على العرض. ثم تستخدم عناصر رقم الشريحة التسلسل المحدث.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

العناصر المرئية للرأس والتذييل تُرسم مع باقي محتوى العرض في صيغة الإخراج. مظهرها يعتمد على نوع الصفحة التي يتم تصديرها وإعدادات رؤية العناصر النائبة المقابلة.