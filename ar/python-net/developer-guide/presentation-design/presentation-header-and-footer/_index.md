---
title: إدارة رؤوس وتذييلات العروض التقديمية باستخدام Python
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/python-net/presentation-header-and-footer/
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
description: "استخدم Aspose.Slides لـ Python عبر .NET لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

## **نظرة عامة**

يتيح لك Aspose.Slides لـ Python التحكم في العناصر النائبة للرأس والتذييل عبر العرض التقديمي بنطاق دقيق. يتم إدارة نص التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح من مستوى القالب الرئيسي ويمكن تطبيقه عالميًا أو تعديله لكل شريحة على حدة. يتم دعم الرؤوس في الملاحظات والنشرات، حيث يمكنك تبديل الرؤية وتعيين نص للرأس، التذييل، التاريخ/الوقت، وأرقام الصفحات من خلال مدير الرأس والتذييل المخصص على شريحة ملاحظات القالب الرئيسي أو على شرائح الملاحظات الفردية. يوضح هذا المقال الأنماط الأساسية لتحديث هذه العناصر النائبة ونشر التغييرات بشكل متسق عبر مجموعة الشرائح الخاصة بك.

## **إدارة نص الرأس والتذييل**

في هذا القسم، ستتعلم كيف تدير محتوى الرأس والتذييل في عرض تقديمي—تمكين أو تعديل التذييل، التاريخ والوقت، وأرقام الشرائح. سنستعرض باختصار نطاقات تطبيق هذه الإعدادات (العرض كاملًا، الشرائح الفردية، وعروض الملاحظات/النشرات) ونظهر كيفية استخدام واجهة برمجة تطبيقات Aspose.Slides لتحديثها بسرعة وبشكل متسق.

يعرض المثال البرمجي أدناه كيفية فتح عرض تقديمي، تمكين وتعيين نص التذييل، تحديث نص الرأس على شريحة ملاحظات القالب الرئيسي، ثم حفظ الملف.

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

## **إدارة الرأس والتذييل في شرائح الملاحظات**

في هذا القسم، ستتعلم كيف تدير الرؤوس والتذييلات خصيصًا لشرائح الملاحظات في Aspose.Slides. سنغطي تمكين العناصر النائبة ذات الصلة، تعيين نص للتذييلات، التاريخ/الوقت، وأرقام الصفحات، وتطبيق هذه التغييرات بشكل متسق عبر القالب الرئيسي للملاحظات والصفحات الفردية للملاحظات.

اتبع الخطوات أدناه:

1. حمّل ملف عرض تقديمي.  
1. احصل على شريحة ملاحظات القالب الرئيسي ومدير [الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
1. في شريحة ملاحظات القالب الرئيسي، فعّل رؤية الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت للقالب الرئيسي وجميع شرائح الملاحظات الفرعية.  
1. في شريحة ملاحظات القالب الرئيسي، عيّن نصًا للرأس، التذييل، والتاريخ/الوقت للقالب الرئيسي وجميع شرائح الملاحظات الفرعية.  
1. احصل على شريحة الملاحظات للشرحة الأولى في العرض ومدير [الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
1. لهذه الشريحة الملاحظة الأولى فقط، تأكّد من أن الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت مرئية (فعّل أي منها غير مفعلة).  
1. لهذه الشريحة الملاحظة الأولى فقط، عيّن النص للرأس، التذييل، والتاريخ/الوقت.  
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

في PowerPoint، وجود "الرأس" يقتصر فقط على الملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق هذا مع نفس القيود: رأس فقط للملاحظات/النشرات، وعلى الشرائح—تذييل/تاريخ-وقت/رقم شريحة.

**ماذا إذا لم يحتوي التخطيط على منطقة تذييل—هل يمكنني "تفعيل" رؤيتها؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. صُممت مؤشرات وطرق API هذه للتعامل مع الحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

عيّن [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض؛ بعد ذلك، يُعاد حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، ويمكنك إخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

تُرسم كعناصر نصية عادية في العرض. أي أن العناصر التي تكون مرئية على الشرائح/صفحات الملاحظات ستظهر أيضًا في صيغة الإخراج إلى جانب بقية المحتوى.