---
title: إدارة رؤوس وتذييلات العروض التقديمية باستخدام بايثون
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/python-net/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- مسودة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة أماكن الحامل للتذييل، التاريخ-الوقت، رقم الشريحة، والرأس في الشرائح، صفحات الملاحظات، والمسودات باستخدام Aspose.Slides لبايثون عبر .NET."
---
## **نظرة عامة**

يستخدم PowerPoint أماكن حامل مختلفة للرأس والتذييل حسب نوع الصفحة. يتيح Aspose.Slides for Python via .NET لك التحكم في النص ورؤية هذه الأماكن الحاملة من خلال فئات مدير الرأس/التذييل.

الأماكن الحاملة المتوفرة تعتمد على النطاق:

| النطاق | رأس الصفحة | تذييل الصفحة | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| ملاحظات رئيسية | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| مسودة رئيسية | نعم | نعم | نعم | نعم |

الشريحة العادية لا تحتوي على مكان حامل للرأس. تتوفر رؤوس الصفحات في صفحات الملاحظات والمسودات. بالنسبة للشرائح العادية، استخدم أماكن حامل التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

نطاق التغيير يعتمد على المدير الذي تستخدمه. تتحكم فئة [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slideheaderfootermanager/) في شريحة عادية واحدة. تتحكم فئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري الماستر والتخطيط أيضاً نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم فئة [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) في مسودة الماستر.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح في الشرائح العادية**

بالنسبة للشرائح العادية، سير العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، تعيين نص التذييل والتاريخ/الوقت، تمكين الأماكن الحاملة المطلوبة، ثم حفظ العرض التقديمي. يتم إنشاء أرقام الشرائح تلقائياً، لذا يكفي التحكم في رؤيتها فقط.

استخدم [`set_footer_text`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) و[`set_date_time_text`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) لتعيين النص، واستخدم [`set_footer_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/)، [`set_date_time_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/)، و[`set_slide_number_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) لإظهار الأماكن الحاملة المقابلة.

المثال التالي يغطي جميع الشرائح العادية لتطبيق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة لتحديث شريحة واحدة فقط، فاحصل على تلك الشريحة مباشرة عبر مجموعة [`slides`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) بدلاً من التنقل عبر المجموعة كلها.

## **تعيين الرؤوس والتذييلات في ملاحظات الماستر**

تحدد ملاحظات الماستر تنسيقاً مشتركاً وسلوك الأماكن الحاملة لصفحات الملاحظات. استخدم فئة [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/) عندما تريد تغيير الماستر نفسه فقط.

المثال التالي يضع رأس، تذييل، ونص تاريخ/وقت في ملاحظات الماستر ويجعل جميع الأماكن الحاملة المدعومة مرئية في ذلك الماستر:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

قد لا يحتوي العرض التقديمي على ملاحظات ماستر، لذا تحقق من القيمة المرجعة لتكون `None` قبل تعديلها.

## **تطبيق إعدادات ملاحظات الماستر على الشرائح الفرعية للملاحظات**

يمكن لملاحظات الماستر تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع الشرائح الفرعية للملاحظات التابعة. استخدم طرق النشر المخصصة على [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر التسلسل الهرمي للملاحظات.

على سبيل المثال، تقوم الدالتان [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) و[`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) بتحديث رأس ملاحظات الماستر وجميع رؤوس الشرائح الفرعية. تتوفر طرق مماثلة للتذييل، التاريخ/الوقت، وأرقام الشرائح.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

طرق النشر المستخدمة أعلاه هي [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/)، [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/)، [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/)، [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/)، و[`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **تعيين الرؤوس والتذييلات في شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم فئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`add_notes_slide`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslidemanager/add_notes_slide/) تُعيد شريحة الملاحظات للشريحة الحالية وتُنشئ واحدة إذا لم تكن موجودة. المثال التالي يضبط صفحة الملاحظات المرتبطة بأول شريحة في العرض:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

إذا قمت أولاً بنشر الإعدادات من ملاحظات الماستر ثم غيرت شريحة ملاحظات فردية، فإن الإعدادات الخاصة بالشريحة الأخيرة تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تعيين الرؤوس والتذييلات في مسودة الماستر**

تستخدم صفحات المسودة مسودة الماستر لأماكن حاملة الرأس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات المسودة عبر مسودة الماستر وليس عبر شرائح المسودة الفردية.

استخدم الخاصية [`master_handout_slide`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) للوصول إلى مسودة الماستر. إذا لم تكن موجودة، استدعِ [`set_default_master_handout_slide`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) لإنشاء مسودة المسودة الافتراضية.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslideheaderfootermanager/) يتحكم في ماستر شرائح عادي ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslideheaderfootermanager/) يتحكم في ملاحظات الماستر ويمكنه نشر الإعدادات إلى جميع الشرائح الفرعية للملاحظات.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم مكان حامل رأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) يغيّر مسودة الماستر ويدعم جميع أنواع الأماكن الحاملة الأربعة.

استخدم النشر من ماستر أو تخطيط عندما يجب تطبيق الإعداد نفسه على كامل التسلسل الهرمي. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتكررة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يحدد PowerPoint مكان حامل للرأس في الشرائح العادية. في الشرائح العادية استخدم أماكن حامل التذييل، التاريخ/الوقت، ورقم الشريحة. تتوفر أماكن حامل الرؤوس في صفحات الملاحظات والمسودات.

**ماذا إذا لم يكن مكان حامل التذييل أو التاريخ/الوقت أو رقم الشريحة مرئياً؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، تُظهر الدالة [`is_footer_visible`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) ما إذا كان مكان حامل التذييل موجوداً، وتُغيّر الدالة [`set_footer_visibility`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

عيّن الخاصية [`first_slide_number`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/first_slide_number/) للعرض التقديمي. بعد ذلك تستخدم أماكن حامل رقم الشريحة تسلسل ترقيم محدث.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

يتم تصيير عناصر الرأس والتذييل المرئية مع باقي محتوى العرض في تنسيق الإخراج. يعتمد مظهرها على نوع الصفحة التي يتم تصديرها وإعدادات رؤية الأماكن الحاملة المقابلة.