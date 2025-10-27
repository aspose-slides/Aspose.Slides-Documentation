---
title: إدارة رؤوس وتذييلات العروض التقديمية باستخدام Python
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
- نسخة توزيع
- ملاحظات
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم Aspose.Slides لـ Python عبر .NET لإضافة وتخصيص رؤوس وتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

## **نظرة عامة**

Aspose.Slides لـ Python يتيح لك التحكم في عناصر النِسْقَة (placeholder) للراسية والتذييل عبر العرض التقديمي بالكامل بنطاق دقيق. يتم إدارة نص التذييل، التاريخ/الوقت، وأرقام الشرائح على مستوى الماستر ويمكن تطبيقها عالميًا أو تعديلها لكل شريحة. يتم دعم الرؤوس في الملاحظات والنسخ التوزيعية، حيث يمكنك تبديل الظهور وضبط النص للراسية، التذييل، التاريخ/الوقت، وأرقام الصفحات من خلال مدير الرأس والتذييل المخصص على شريحة الملاحظات الماستر أو على شرائح الملاحظات الفردية. يوضح هذا المقال الأنماط الأساسية لتحديث هذه العناصر والنشر المتسق للتغييرات في كامل العرض.

## **إدارة نص الرأس والتذييل**

في هذا القسم، ستتعلم كيفية إدارة محتوى الرأس والتذييل في عرض تقديمي—تمكين أو تعديل التذييل، التاريخ والوقت، وأرقام الشرائح. سنوضح بإيجاز النطاقات لتطبيق هذه الإعدادات (العرض كله، الشرائح الفردية، وعروض الملاحظات/النسخة التوزيعية) ونظهر كيفية استخدام Aspose.Slides API لتحديثها بسرعة وبشكل متسق.

مثال الشيفرة أدناه يفتح عرضًا تقديميًا، يمكّن ويضبط نص التذييل، يحدّث نص الرأس على شريحة الملاحظات الماستر، ثم يحفظ الملف.

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

في هذا القسم، ستتعلم كيفية إدارة الرؤوس والتذييلات خصيصًا لشرائح الملاحظات في Aspose.Slides. سنغطي تمكين العناصر النِسْقَة ذات الصلة، ضبط النص للتذييل، التاريخ/الوقت، وأرقام الصفحات، وتطبيق هذه التغييرات بشكل متسق عبر الماستر الملاحظات والصفحات الفردية للملاحظات.

اتبع الخطوات أدناه:

1. تحميل ملف عرض تقديمي.
1. الحصول على شريحة الملاحظات الماستر ومدير [الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. على شريحة الملاحظات الماستر، تمكين رؤية الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت للماستر وجميع شرائح الملاحظات الفرعية.
1. على شريحة الملاحظات الماستر، ضبط النص للرأس، التذييل، والتاريخ/الوقت للماستر وجميع شرائح الملاحظات الفرعية.
1. الحصول على شريحة الملاحظات للشرائح الأولى في العرض ومدير [الرأس والتذييل](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. لهذه الشريحة الملاحظات الأولى فقط، تأكد من أن الرأس، التذييل، رقم الشريحة، والتاريخ/الوقت مرئية (فعّل أي منها كان مطفأً).
1. لهذه الشريحة الملاحظات الأولى فقط، اضبط النص للرأس، التذييل، والتاريخ/الوقت.
1. حفظ العرض التقديمي بصيغة PPTX.

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

## **الأسئلة المتكررة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، "الرأس" موجود فقط للملاحظات والنسخ التوزيعية؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides هذا يطابق نفس القيود: الرأس للـ Notes/Handout فقط، وعلى الشرائح — التذييل/التاريخ‑الوقت/رقم الشريحة.

**ماذا لو لا يحتوي التصميم على منطقة تذييل—هل يمكنني "تشغيل" مرئيتها؟**

نعم. تحقق من المرئية عبر مدير الرأس/التذييل وقم بتمكينها إذا لزم الأمر. تم تصميم مؤشرات API وهذه الطرق للحالات التي يكون فيها العنصر النِسْقَة مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

اضبط [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض؛ بعد ذلك يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

تُعرض كعناصر نص عادية في العرض. أي أن العناصر المرئية على الشرائح/صفحات الملاحظات ستظهر أيضًا في صيغة الإخراج إلى جانب باقي المحتوى.