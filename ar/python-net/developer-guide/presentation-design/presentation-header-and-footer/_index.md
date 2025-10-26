---
title: إدارة رؤوس وتذييلات العرض باستخدام بايثون
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/python-net/developer-guide/presentation-design/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين رأس
- تعيين تذييل
- نشرة
- ملاحظات
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم Aspose.Slides لبايثون عبر .NET لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

## **نظرة عامة**

تتيح لك Aspose.Slides لبايثون التحكم في عناصر العنصر النائب للرأس والتذييل عبر العرض التقديمي بدقة نطاقية. يتم إدارة نص التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح من مستوى القالب الرئيسي ويمكن تطبيقها عالميًا أو تعديلها لكل شريحة. تُدعم الرؤوس في الملاحظات والنشرات، حيث يمكنك تبديل رؤيتها وتعيين نص للرأس، التذييل، التاريخ/الوقت، وأرقام الصفحات من خلال مدير الرأس والتذييل المخصص على شريحة ملاحظات القالب أو على شرائح الملاحظات الفردية. توضح هذه المقالة الأنماط الأساسية لتحديث هذه العناصر النائبة ونشر التغييرات بشكل ثابت عبر كامل العرض.

## **إدارة نص الرأس والتذييل**

في هذا القسم، ستتعلم كيفية إدارة محتوى الرأس والتذييل في عرض تقديمي—تمكين أو تعديل التذييل، التاريخ والوقت، وأرقام الشرائح. سنستعرض باختصار نطاقات تطبيق هذه الإعدادات (العرض الكامل، الشرائح الفردية، وعروض الملاحظات/النشرات) ونوضح كيفية استخدام واجهة Aspose.Slides API لتحديثها بسرعة وبشكل ثابت.

مثال الشيفرة أدناه يفتح عرضًا تقديميًا، يمكّن ويضبط نص التذييل، يحدّث نص الرأس على شريحة ملاحظات القالب، ويحفظ الملف.

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة الرأس والتذييل على شرائح الملاحظات**

في هذا القسم، ستتعلم كيفية إدارة الرؤوس والتذييلات بشكل خاص لشرائح الملاحظات في Aspose.Slides. سنغطي تمكين العناصر النائبة ذات الصلة، ضبط النص للتذييل، التاريخ/الوقت، وأرقام الصفحات، وتطبيق هذه التغييرات بشكل ثابت عبر قالب الملاحظات والصفحات الفردية للملاحظات.

اتبع الخطوات أدناه:

1. حمّل ملف عرض تقديمي.
1. احصل على شريحة ملاحظات القالب و[مدير الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. في شريحة ملاحظات القالب، مكّن رؤية الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت للقالب وجميع شرائح الملاحظات الفرعية.
1. في شريحة ملاحظات القالب، اضبط نص الرأس، التذييل، والتاريخ/الوقت للقالب وجميع شرائح الملاحظات الفرعية.
1. احصل على شريحة الملاحظات للشرائح الأولى في العرض و[مدير الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. لهذه الشريحة الملاحظة الأولى فقط، تأكد من أن الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت مرئيون (فعّل أي منها كان معطلاً).
1. لهذه الشريحة الملاحظة الأولى فقط، اضبط النص للرأس، التذييل، والتاريخ/الوقت.
1. احفظ العرض التقديمي بصيغة PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، "الرأس" موجود فقط للملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يطابق هذا القيود نفسها: رأس فقط للملاحظات/النشرة، وعلى الشرائح—تذييل/تاريخ-وقت/رقم شريحة.

**ماذا لو لم يحتوي التخطيط على منطقة تذييل—هل يمكنني "تشغيل" رؤيتها؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وفّعلها إذا لزم الأمر. تم تصميم مؤشرات وطرق API هذه لحالات غياب العنصر النائب أو كونه مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

حدد [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض؛ بعد ذلك، يُعاد حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض. أي أن العناصر المرئية على الشرائح/صفحات الملاحظات ستظهر أيضًا في التنسيق الناتج مع باقي المحتوى.