---
title: رأس وتذييل العرض
type: docs
weight: 140
url: /python-net/presentation-header-and-footer/
keywords: "رأس, تذييل, تعيين رأس, تعيين تذييل, تعيين رأس وتذييل, عرض PowerPoint, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "رأس وتذييل PowerPoint في بايثون"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/python-net/) توفر الدعم للعمل مع نصوص رؤوس وتذايل الشرائح التي يتم الحفاظ عليها على مستوى الشريحة الرئيسية.

{{% /alert %}} 

[Aspose.Slides لـ بايثون عبر .NET](/slides/python-net/) توفر الميزة لإدارة الرؤوس والتذييلات داخل شرائح العرض. هذه في الواقع تُدار على مستوى الشريحة الرئيسية.
## **إدارة نص الرأس والتذييل**
يمكن تحديث ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# طريقة لتعيين نص الرأس/التذييل
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "مرحبًا هناك رأس جديد"

# تحميل العرض
with slides.Presentation("combined_with_master.pptx") as pres:
    # تعيين التذييل
    pres.header_footer_manager.set_all_footers_text("نص تذييلتي")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # الوصول إلى وتحديث الرأس
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # حفظ العرض
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **إدارة الرأس والتذييل في شرائح الكتيب والملاحظات**
Aspose.Slides لـ بايثون عبر .NET تدعم الرأس والتذييل في شرائح الكتيب والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [عرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل لمعلم الملاحظات وجميع شرائح الملاحظات.
- جعل شريحة ملاحظات الماستر وجميع عناصر التذييل الفرعية مرئية.
- جعل شريحة ملاحظات الماستر وجميع عناصر التاريخ والوقت الفرعية مرئية.
- تغيير إعدادات الرأس والتذييل لأول شريحة ملاحظات فقط.
- جعل عنصر تذييل شريحة الملاحظات مرئيًا.
- تعيين النص لعنصر تذييل شريحة الملاحظات.
- تعيين النص لعنصر التاريخ والوقت لشريحة الملاحظات.
- كتابة ملف العرض المعدل.

مقتطف الكود المقدم في المثال أدناه.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# جعل شريحة ملاحظات الماستر وجميع عناصر التذييل الفرعية مرئية
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# تعيين النص لشريحة ملاحظات الماستر وجميع عناصر الرأس الفرعية
		headerFooterManager.set_header_and_child_headers_text("نص الرأس") 
		headerFooterManager.set_footer_and_child_footers_text("نص التذييل") 
		headerFooterManager.set_date_time_and_child_date_times_text("نص التاريخ والوقت") 

	# تغيير إعدادات الرأس والتذييل لأول شريحة ملاحظات فقط
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# جعل عنصر الرأس لشريحة الملاحظات مرئيًا

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# تعيين النص لعنصر الرأس لشريحة الملاحظات
		headerFooterManager.set_header_text("نص رأس جديد") 
		headerFooterManager.set_footer_text("نص تذييل جديد") 
		headerFooterManager.set_date_time_text("نص تاريخ ووقت جديد") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```