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
- نسخة يدوية
- ملاحظات
- باوربوينت
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "استخدم Aspose.Slides لبايثون عبر .NET لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument لمظهر احترافي."
---

## **نظرة عامة**

تمكنك Aspose.Slides لبايثون من التحكم في عناصر النائب الخاصة بالرأس والتذييل عبر العرض التقديمي بنطاق دقيق. يتم إدارة نص التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح من مستوى الرئيس ويمكن تطبيقها عالميًا أو تعديلها لكل شريحة. يدعم الرؤوس على الملاحظات والنسخ اليدوية، حيث يمكنك تبديل الظهور وتعيين نص للرأس، التذييل، التاريخ/الوقت، وأرقام الصفحات من خلال مدير الرأس والتذييل المخصص على شريحة الملاحظات الرئيسة أو شرائح الملاحظات الفردية. يوضح هذا المقال الأنماط الأساسية لتحديث هذه العناصر النائبة ونشر التغييرات بشكل متسق عبر مجموعة الشرائح الخاصة بك.

## **إدارة نص الرأس والتذييل**

في هذا القسم، ستتعلم كيفية إدارة محتوى الرأس والتذييل في عرض تقديمي — تمكين أو تعديل التذييل، التاريخ والوقت، وأرقام الشرائح. سنستعرض بإيجاز النطاقات لتطبيق هذه الإعدادات (العرض التقديمي بالكامل، الشرائح الفردية، وعرض الملاحظات/النسخة اليدوية) وسنوضح كيفية استخدام Aspose.Slides API لتحديثها بسرعة وبشكل متسق.

المثال البرمجي أدناه يفتح عرضًا تقديميًا، يفعّل ويضبط نص التذييل، يحدّث نص الرأس على شريحة الملاحظات الرئيسة، ويحفظ الملف.

```py
import aspose.slides as slides

# دالة لتعيين نص الرأس.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# تحميل العرض التقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تعيين التذييل.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # الوصول إلى الرأس وتحديثه.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة الرأس والتذييل على شرائح الملاحظات**

في هذا القسم، ستتعلم كيفية إدارة الرؤوس والتذييلات خصيصًا لشرائح الملاحظات في Aspose.Slides. سنغطي تمكين العناصر النائبة ذات الصلة، ضبط النص للتذييلات، التاريخ/الوقت، وأرقام الصفحات، وتطبيق هذه التغييرات بشكل متسق عبر الرئيس الرئيسي للملاحظات والصفحات الفردية للملاحظات.

اتبع الخطوات أدناه:

1. تحميل ملف العرض التقديمي.
2. الحصول على شريحة الملاحظات الرئيسة و[مدير الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. على شريحة الملاحظات الرئيسة، تمكين ظهور الرأس، التذييل، رقم الشريحة، والوقت/التاريخ للرئيس وجميع شرائح الملاحظات الفرعية.
4. على شريحة الملاحظات الرئيسة، ضبط النص للرأس، التذييل، والوقت/التاريخ للرئيس وجميع شرائح الملاحظات الفرعية.
5. الحصول على شريحة الملاحظات للشرحة الأولى في العرض و[مدير الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
6. بالنسبة لهذه الشريحة الملاحظة الأولى فقط، تأكد من ظهور الرأس، التذييل، رقم الشريحة، والوقت/التاريخ (فعّل أي منها معطل).
7. بالنسبة لهذه الشريحة الملاحظة الأولى فقط، اضبط النص للرأس، التذييل، والوقت/التاريخ.
8. حفظ العرض التقديمي بصيغة PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # جعل شريحة الملاحظات الرئيسية وجميع عناصر الرأس، التذييل، رقم الشريحة، وتاريخ/وقت الأطفال مرئية.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # تعيين النص على شريحة الملاحظات الرئيسية وجميع عناصر الرأس، التذييل، وتاريخ/وقت الأطفال.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # تغيير إعدادات الرأس، التذييل، رقم الشريحة، وتاريخ/وقت لشرائح الملاحظات الأولى فقط.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # التأكد من أن عناصر الرأس، التذييل، رقم الشريحة، وتاريخ/وقت مرئية.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # تعيين النص على عناصر الرأس، التذييل، وتاريخ/وقت في شريحة الملاحظات.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني إضافة «رأس» إلى الشرائح العادية؟**

في PowerPoint، يوجد «رأس» فقط للملاحظات والنسخ اليدوية؛ على الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: رأس للملاحظات/النسخة اليدوية فقط، وعلى الشرائح — تذييل/تاريخ/وقت/رقم شريحة.

**ماذا لو لم تحتوي التخطيط على منطقة تذييل — هل يمكنني «تفعيل» رؤيته؟**

نعم. تحقق من الظهور عبر مدير الرأس/التذييل وفعّله إذا لزم الأمر. تم تصميم مؤشرات وطرق API هذه للتعامل مع الحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

اضبط [رقم الشريحة الأول](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض التقديمي؛ بعد ذلك، يُعاد حساب جميع الترقيمات. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم رسمها كعناصر نصية عادية في العرض التقديمي. أي أن العناصر المرئية على الشرائح/صفحات الملاحظات ستظهر أيضًا في تنسيق الإخراج إلى جانب باقي المحتوى.