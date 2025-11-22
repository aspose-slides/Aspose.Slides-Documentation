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
- ضبط الرأس
- ضبط التذييل
- نشرة
- ملاحظات
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم Aspose.Slides for Python عبر .NET لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

## **نظرة عامة**

تسمح لك Aspose.Slides for Python بالتحكم في عناصر العنصر النائب للعنوان وتذييل الصفحات عبر العرض التقديمي بنطاق دقيق. يتم إدارة نص التذييل وتاريخ/وقت وعناوين الشرائح من المستوى الرئيسي ويمكن تطبيقه عالميًا أو تعديله لكل شريحة على حدة. يتم دعم العناوين في الملاحظات والنشرات، حيث يمكنك تبديل الظهور وتعيين النص للعنوان، التذييل، التاريخ/الوقت، وأرقام الصفحات من خلال مدير العنوان وتذييل الصفحات المخصص على شريحة الملاحظات الرئيسية أو شرائح الملاحظات الفردية. يوضح هذا المقال الأنماط الأساسية لتحديث هذه العناصر النائبة ونشر التغييرات بشكل متسق عبر مجموعة الشرائح الخاصة بك.

## **إدارة نص العنوان وتذييل الصفحات**

في هذا القسم، ستتعلم كيفية إدارة محتوى العنوان وتذييل الصفحات في عرض تقديمي—تمكين أو تعديل التذييل، التاريخ والوقت، وأرقام الشرائح. سنستعرض بإيجاز نطاقات تطبيق هذه الإعدادات (العرض التقديمي بالكامل، الشرائح الفردية، وعروض الملاحظات/النشرات) ونظهر كيفية استخدام Aspose.Slides API لتحديثها بسرعة وبشكل متسق.

المثال البرمجي أدناه يفتح عرضًا تقديميًا، يمكّن ويضبط نص التذييل، يحدّث نص العنوان على شريحة الملاحظات الرئيسية، ويحفظ الملف.
```py
import aspose.slides as slides

# دالة لتعيين نص العنوان.
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

    # الوصول إلى وتحديث العنوان.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # حفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة العنوان وتذييل الصفحات على شرائح الملاحظات**

في هذا القسم، ستتعلم كيفية إدارة العناوين وتذييلات الصفحات خصيصًا لشرائح الملاحظات في Aspose.Slides. سنغطي تمكين العناصر النائبة ذات الصلة، ضبط النص للتذييل، التاريخ/الوقت، وأرقام الصفحات، وتطبيق هذه التغييرات بشكل متسق عبر الملاحظات الرئيسية والصفحات الفردية.

اتبع الخطوات أدناه:

1. تحميل ملف عرض تقديمي.
1. الحصول على شريحة الملاحظات الرئيسية وإدارة [مدير العنوان وتذييل الصفحات](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. على شريحة الملاحظات الرئيسية، تمكين ظهور العنوان، التذييل، رقم الشريحة، وتاريخ/وقت للمستوى الرئيسي وجميع الشرائح الملاحظة الفرعية.
1. على شريحة الملاحظات الرئيسية، ضبط النص للعناوين، التذييل، وتاريخ/وقت للمستوى الرئيسي وجميع الشرائح الملاحظة الفرعية.
1. الحصول على شريحة الملاحظات للشرحة الأولى وعرض [مدير العنوان وتذييل الصفحات](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. لهذه الشريحة الملاحظة الأولى فقط، التأكد من ظهور العنوان، التذييل، رقم الشريحة، وتاريخ/وقت (تفعيل أي منها متوقف).
1. لهذه الشريحة الملاحظة الأولى فقط، ضبط النص للعناوين، التذييل، وتاريخ/وقت.
1. حفظ العرض التقديمي بصيغة PPTX.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # اجعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للعنوان، التذييل، رقم الشريحة، وتاريخ/وقت للأطفال مرئية.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # عيّن النص على شريحة الملاحظات الرئيسية وجميع العناصر النائبة للعنوان، التذييل، وتاريخ/وقت للأطفال.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # غيّر إعدادات العنوان، التذييل، رقم الشريحة، وتاريخ/وقت للشرحة الملاحظة الأولى فقط.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # تأكد من أن العناصر النائبة للعنوان، التذييل، رقم الشريحة، وتاريخ/وقت مرئية.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # عيّن النص على عناصر النشرة الملاحظة للعنوان، التذييل، وتاريخ/وقت.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # احفظ العرض التقديمي.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتداولة**

**هل يمكنني إضافة "عنوان" إلى الشرائح العادية؟**

في PowerPoint، وجود "العنوان" يقتصر على الملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: العنوان فقط للملاحظات/النشرات، وعلى الشرائح—التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التخطيط على مساحة للتذييل—هل يمكنني "تشغيل" ظهوره؟**

نعم. تحقق من الظهور عبر مدير العنوان/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم هذه المؤشرات والطرق في API لحالات عدم وجود العنصر النائب أو إخفائه.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

حدد [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض التقديمي؛ بعد ذلك، يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للعناوين/التذييلات عند تصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض التقديمي. أي إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضًا في صيغة الإخراج جنبًا إلى جنب مع باقي المحتوى.