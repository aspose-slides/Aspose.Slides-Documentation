---
title: رأس وتذييل العرض
type: docs
weight: 140
url: /ar/cpp/presentation-header-and-footer/
keywords: "رأس وتذييل في PowerPoint"
description: "رأس وتذييل في PowerPoint باستخدام Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/cpp/) توفر دعمًا للعمل مع نصوص رؤوس وتذييلات الشرائح التي يتم الحفاظ عليها على مستوى الشريحة الرئيسية.

{{% /alert %}} 

[Aspose.Slides for C++](/slides/ar/cpp/) يوفر ميزة إدارة الرؤوس والتذييلات داخل شرائح العرض. وهذه تُدار فعليًا على مستوى عرض المحاضرات.
## **إدارة نص الرأس والتذييل**
يمكن تحديث ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

``` cpp
// دالة لتعيين نص الرأس/التذييل
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"مرحبا، هذا رأس جديد");
            }
        }
    }
}
```

``` cpp
// تحميل العرض
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// إعداد التذييل
pres->get_HeaderFooterManager()->SetAllFootersText(u"نص التذييل الخاص بي");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// الوصول إلى وتحديث الرأس
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// حفظ العرض
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **إدارة الرأس والتذييل في الشرائح المخصصة والملاحظات**
Aspose.Slides for C++ تدعم الرأس والتذييل في الشرائح المخصصة والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [عرض ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل للعرض الرئيسي وجميع الشرائح الملاحظات.
- تعيين شريحة ملاحظات رئيسية وجميع أماكن تذييل الأطفال لرؤية.
- تعيين شريحة ملاحظات رئيسية وجميع أماكن التاريخ والوقت لرؤية.
- تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط.
- جعل مكان رأس شريحة الملاحظات مرئيًا.
- تعيين نص لمكان رأس شريحة الملاحظات.
- تعيين نص لمكان التاريخ والوقت لشريحة الملاحظات.
- كتابة ملف العرض المعدل.

رؤية مقتطف الشيفرة المقدمة في المثال أدناه.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// تغيير إعدادات الرأس والتذييل للعرض الرئيسي وجميع الشرائح الملاحظات
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// جعل شريحة الملاحظات الرئيسية وجميع أماكن تذييل الأطفال مرئية
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع أماكن الرأس مرئية
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع أماكن رقم الشريحة مرئية
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// جعل شريحة الملاحظات الرئيسية وجميع أماكن التاريخ والوقت مرئية
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن الرأس
	headerFooterManager->SetHeaderAndChildHeadersText(u"نص الرأس");
	// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن التذييل
	headerFooterManager->SetFooterAndChildFootersText(u"نص التذييل");
	// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن التاريخ والوقت
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"نص التاريخ والوقت");
}

// تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// جعل مكان رأس هذه الشريحة مرئيًا
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// جعل مكان تذييل هذه الشريحة مرئيًا
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// جعل مكان رقم الشريحة لهذه الشريحة مرئيًا
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// جعل مكان التاريخ والوقت لهذه الشريحة مرئيًا
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// تعيين نص لمكان رأس شريحة الملاحظات
	headerFooterManager->SetHeaderText(u"نص الرأس الجديد");
	// تعيين نص لمكان تذييل شريحة الملاحظات
	headerFooterManager->SetFooterText(u"نص التذييل الجديد");
	// تعيين نص لمكان التاريخ والوقت لشريحة الملاحظات
	headerFooterManager->SetDateTimeText(u"نص التاريخ والوقت الجديد");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```