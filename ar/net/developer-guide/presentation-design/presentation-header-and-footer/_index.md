---
title: رأس وتذييل العرض التقديمي
type: docs
weight: 140
url: /ar/net/presentation-header-and-footer/
keywords: "رأس, تذييل, ضبط الرأس, ضبط التذييل, ضبط الرأس والتذييل, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "رأس وتذييل PowerPoint في C# أو .NET"
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ar/net/) توفر الدعم للعمل مع نص رؤوس وتذييلات الشرائح التي تُحافظ عليها فعليًا على مستوى ماستر الشريحة.
{{% /alert %}} 
[Aspose.Slides for .NET](/slides/ar/net/) توفر ميزة إدارة رؤوس وتذييلات الشرائح داخل العروض التقديمية. يتم إدارة هذه فعليًا على مستوى ماستر العرض.
## **إدارة نص الرأس والتذييل**
يمكن تحديث ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```c#
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");

// ضبط التذييل
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// الوصول وتحديث الرأس
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// حفظ العرض
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





## **إدارة الرأس والتذييل في شرائح المستندات الموزعة والملاحظات**
يدعم Aspose.Slides for .NET الرأس والتذييل في شرائح المستندات الموزعة والملاحظات. يرجى اتباع الخطوات التالية:

- تحميل [عرض تقديمي ](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات.
- ضبط شريحة الملاحظات الرئيسة وجعل جميع العناصر النائبة للتذييل الفرعية مرئية.
- ضبط شريحة الملاحظات الرئيسة وجعل جميع العناصر النائبة للتاريخ والوقت الفرعية مرئية.
- تغيير إعدادات الرأس والتذييل للشرائح الملاحظات الأولى فقط.
- ضبط عنصر نائب رأس شريحة الملاحظات مرئي.
- تعيين نص إلى عنصر نائب رأس شريحة الملاحظات.
- تعيين نص إلى عنصر نائب تاريخ-وقت شريحة الملاحظات.
- كتابة ملف العرض المعدل.

مقتطف الشفرة المقدم في المثال أدناه.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية مرئية
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية مرئية
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة لأرقام الشرائح الفرعية مرئية
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية مرئية

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية
	}

	// تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // جعل عنصر نائب الرأس لهذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // جعل عنصر نائب التذييل لهذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // جعل عنصر نائب رقم الشريحة لهذه شريحة الملاحظات مرئيًا

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // جعل عنصر نائب التاريخ والوقت لهذه شريحة الملاحظات مرئيًا

		headerFooterManager.SetHeaderText("New header text"); // تعيين النص إلى عنصر نائب الرأس لشريحة الملاحظات
		headerFooterManager.SetFooterText("New footer text"); // تعيين النص إلى عنصر نائب التذييل لشريحة الملاحظات
		headerFooterManager.SetDateTimeText("New date and time text"); // تعيين النص إلى عنصر نائب التاريخ والوقت لشريحة الملاحظات
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
        
 }
```


## **الأسئلة المتكررة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، "Header" موجود فقط للملاحظات والنسخ المطبوعة؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: الرأس متاح فقط للملاحظات/النسخة المطبوعة، وفي الشرائح—التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التصميم على منطقة تذييل—هل يمكنني "تشغيل" رؤيته؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم هذه المؤشرات والطرق في الـ API للحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

قم بتعيين [رقم الشريحة الأول](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) للعرض؛ بعد ذلك يتم إعادة حساب جميع الترميزات. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم في شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض. أي أنه إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، ستظهر أيضًا في تنسيق الإخراج مع بقية المحتوى.