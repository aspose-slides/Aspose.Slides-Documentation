---
title: إدارة رؤوس وتذييلات العروض التقديمية في C++
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/cpp/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين رأس
- تعيين تذييل
- نسخة مطبوعة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخدم Aspose.Slides لـ C++ لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ar/cpp/) يوفر الدعم للعمل مع نص رؤوس وتذييلات الشرائح التي يتم صيانتها فعلياً على مستوى ماستر الشريحة.
{{% /alert %}} 

[Aspose.Slides for C++](/slides/ar/cpp/) يوفر ميزة إدارة رؤوس وتذييلات داخل شرائح العرض. يتم إدارة هذه فعلياً على مستوى ماستر العرض.
## **إدارة نص رأس وتذييل الشريحة**
يمكن تحديث ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
``` cpp
// وظيفة لتعيين نص الرأس/التذييل
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// تحميل العرض التقديمي
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// تعيين التذييل
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// الوصول إلى الرأس وتحديثه
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// حفظ العرض التقديمي
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```


## **إدارة رؤوس وتذييلات الشرائح المطبوعات والملاحظات**
يدعم Aspose.Slides for C++ رؤوس وتذييلات في الشرائح المطبوعات والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات.
- تعيين ظهور العناصر النائبة للتذييل في شريحة الملاحظات الرئيسية وجميع العناصر النائبة التابعة.
- تعيين ظهور العناصر النائبة للتاريخ والوقت في شريحة الملاحظات الرئيسية وجميع العناصر النائبة التابعة.
- تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط.
- تعيين ظهور العنصر النائب للرأس في شريحة الملاحظات.
- تعيين النص للعنصر النائب للرأس في شريحة الملاحظات.
- تعيين النص للعنصر النابع للتاريخ والوقت في شريحة الملاحظات.
- كتابة ملف العرض المعدل.

يتم توفير مقتطف الشفرة في المثال أدناه.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية مرئية
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية مرئية
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة لأرقام الشرائح الفرعية مرئية
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية مرئية
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// تعيين النص لشريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// تعيين النص لشريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// تعيين النص لشريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// جعل عنصر نائب الرأس في هذه الشريحة مرئياً
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// جعل عنصر نائب التذييل في هذه الشريحة مرئياً
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// جعل عنصر نائب رقم الشريحة في هذه الشريحة مرئياً
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// جعل عنصر نائب التاريخ‑الوقت في هذه الشريحة مرئياً
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// تعيين النص لعنصر نائب الرأس في شريحة الملاحظات
	headerFooterManager->SetHeaderText(u"New header text");
	// تعيين النص لعنصر نائب التذييل في شريحة الملاحظات
	headerFooterManager->SetFooterText(u"New footer text");
	// تعيين النص لعنصر نائب التاريخ‑الوقت في شريحة الملاحظات
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، يُوجد "الرأس" فقط للملاحظات والنسخ المطبوعة؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: الرأس فقط للملاحظات/النسخ المطبوعة، وعلى الشرائح—التذييل/التاريخ‑الوقت/رقم الشريحة.

**ماذا لو كان التخطيط لا يحتوي على منطقة تذييل—هل يمكنني "تشغيل" ظهورها؟**

نعم. تحقق من الظهور عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم مؤشرات هذه API وطرقها لحالات عدم وجود العنصر النائب أو إخفائه.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

قم بتعيين [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) للعرض؛ بعد ذلك يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم تصويرها كعناصر نصية عادية في العرض. أي إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضاً في صيغة الإخراج مع باقي المحتوى.