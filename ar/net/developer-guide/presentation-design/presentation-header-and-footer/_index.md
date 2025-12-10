---
title: إدارة رؤوس وتذييلات العروض التقديمية في .NET
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "استخدم Aspose.Slides for .NET لإضافة وتخصيص رؤوس وتذييلات في عروض PowerPoint و OpenDocument للحصول على مظهر احترافي."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/net/) يوفر دعماً للعمل مع نص رؤوس وتذييلات الشرائح التي تُحافظ عليها فعليًا على مستوى ماستر الشريحة.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ar/net/) يوفر الميزة لإدارة رؤوس وتذييلات الشرائح داخل العروض التقديمية. يتم إدارة هذه فعليًا على مستوى ماستر العرض التقديمي.
## **إدارة نص الرأس والتذييل**
يمكن تحديث ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```c#
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");

// تعيين التذييل
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// الوصول وتحديث الرأس
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// حفظ العرض التقديمي
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// طريقة لتعيين نص الرأس/التذييل
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **إدارة رؤوس وتذييلات الشرائح المرفقة وملاحظات الشرائح**
يدعم Aspose.Slides for .NET الرؤوس والتذييلات في شرائح المرفقات والملاحظات. يرجى اتباع الخطوات أدناه:

- قم بتحميل [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation) المتضمن فيديو.
- غيّر إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات.
- اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب للتذييل الفرعية مرئية.
- اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب للتاريخ والوقت الفرعية مرئية.
- غيّر إعدادات الرأس والتذييل للشرائح الملاحظة الأولى فقط.
- اجعل عنصر النائب للرأس في شريحة الملاحظات مرئيًا.
- عيّن النص لعنصر النائب للرأس في شريحة الملاحظات.
- عيّن النص لعنصر النائب للتاريخ والوقت في شريحة الملاحظات.
- احفظ ملف العرض التقديمي المعدل.

الكود المضمن مقدم في المثال أدناه.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// تغيير إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر النائب للتذييل الفرعية مرئية
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر النائب للرأس الفرعية مرئية
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر النائب لأرقام الشرائح الفرعية مرئية
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر النائب للتاريخ والوقت الفرعية مرئية

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع عناصر النائب للرأس الفرعية
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع عناصر النائب للتذييل الفرعية
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع عناصر النائب للتاريخ والوقت الفرعية
	}

	// تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // جعل عنصر النائب للرأس في هذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // جعل عنصر النائب للتذييل في هذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // جعل عنصر النائب لأرقام الشريحة في هذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // جعل عنصر النائب للتاريخ والوقت في هذه شريحة الملاحظات مرئيًا

		headerFooterManager.SetHeaderText("New header text"); // تعيين النص إلى عنصر النائب للرأس في شريحة الملاحظات
		headerFooterManager.SetFooterText("New footer text"); // تعيين النص إلى عنصر النائب للتذييل في شريحة الملاحظات
		headerFooterManager.SetDateTimeText("New date and time text"); // تعيين النص إلى عنصر النائب للتاريخ والوقت في شريحة الملاحظات
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **الأسئلة المتكررة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، "الرأس" موجود فقط للملاحظات والمواد المطبوعة؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق هذا مع نفس القيود: الرأس فقط للملاحظات/الملف المرفق، وعلى الشرائح — التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التخطيط على منطقة تذييل—هل يمكنني "تشغيل" رؤيتها؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل ومكّنه إذا لزم الأمر. تم تصميم مؤشرات وطرق API هذه للحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

قم بتعيين [رقم الشريحة الأولى](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) للعرض التقديمي؛ بعد ذلك يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض التقديمي. أي إذا كانت العناصر مرئية على صفحات الشرائح/الملاحظات، فستظهر أيضًا في صيغة المخرجات جنبًا إلى جنب مع باقي المحتوى.