---
title: إدارة رؤوس وتذييلات العروض التقديمية في .NET
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/net/presentation-header-and-footer/
keywords:
- الرأس
- نص الرأس
- التذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- النشرة
- الملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدم Aspose.Slides for .NET لإضافة وتخصيص رؤوس وتذييلات في عروض PowerPoint و OpenDocument لتقديم مظهر احترافي."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/net/) يوفر دعمًا للعمل مع نصوص رؤوس وتذييلات الشرائح التي تُحافظ عليها فعليًا على مستوى ماستر الشريحة.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ar/net/) يقدم ميزة إدارة الرؤوس والتذييلات داخل شرائح العروض التقديمية. وهذه تُدار في الواقع على مستوى ماستر العرض.

## **إدارة نص العنوان والتذييل**
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





## **إدارة العنوان والتذييل في شرائح النشرات والملاحظات**
Aspose.Slides for .NET يدعم العنوان والتذييل في شرائح النشرات والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [العرض التقديمي ](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على فيديو.
- تغيير إعدادات العنوان والتذييل لبرسيم الملاحظات وجميع شرائح الملاحظات.
- ضبط ظهور عنصر نائب التذييل للشرائح الرئيسية للملاحظات وجميع الشرائح الفرعية.
- ضبط ظهور عنصر نائب التاريخ والوقت للشرائح الرئيسية للملاحظات وجميع الشرائح الفرعية.
- تغيير إعدادات العنوان والتذييل للشرائح الملاحظة الأولى فقط.
- جعل عنصر نائب العنوان للشرائح الملاحظة مرئياً.
- تعيين النص لعنصر نائب العنوان في شريحة الملاحظات.
- تعيين النص لعنصر نائب التاريخ والوقت في شريحة الملاحظات.
- حفظ ملف العرض التقديمي المعدل.

مقتطف الكود المقدم في المثال أدناه.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للتذييل مرئية
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للرأس مرئية
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي لرقم الشريحة مرئية
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // اجعل شريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للتاريخ والوقت مرئية

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // ضبط النص لشريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للرأس
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // ضبط النص لشريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للتذييل
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // ضبط النص لشريحة الملاحظات الرئيسية وجميع عناصر النائب الفرعي للتاريخ والوقت
	}

	// تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // اجعل عنصر النائب للرأس في شريحة الملاحظات هذه مرئيًا

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // اجعل عنصر النائب للتذييل في شريحة الملاحظات هذه مرئيًا

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // اجعل عنصر النائب لرقم الشريحة في شريحة الملاحظات هذه مرئيًا

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // اجعل عنصر النائب للتاريخ والوقت في شريحة الملاحظات هذه مرئيًا

		headerFooterManager.SetHeaderText("New header text"); // ضبط النص لعنصر النائب للرأس في شريحة الملاحظات
		headerFooterManager.SetFooterText("New footer text"); // ضبط النص لعنصر النائب للتذييل في شريحة الملاحظات
		headerFooterManager.SetDateTimeText("New date and time text"); // ضبط النص لعنصر النائب للتاريخ والوقت في شريحة الملاحظات
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **الأسئلة المتكررة**

**هل يمكنني إضافة "عنوان" إلى الشرائح العادية؟**

في PowerPoint، يوجد "العنوان" فقط للملاحظات والنشرات؛ على الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides تتطابق هذه القيود: العنوان فقط للملاحظات/النشرات، وعلى الشرائح—التذييل/DateTime/SlideNumber.

**ماذا لو لم يحتوي التخطيط على منطقة تذييل—هل يمكنني "تشغيل" ظهورها؟**

نعم. تحقق من الظهور عبر مدير العنوان/التذييل وفعلها إذا لزم الأمر. تم تصميم مؤشرات الـ API وهذه الطرق للحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

قم بتعيين [رقم الشريحة الأول] لمجلد العرض التقديمي (https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/); بعد ذلك، يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للعناوين/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض التقديمي. بمعنى أنه إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضًا في صيغة الإخراج جنبًا إلى جنب مع باقي المحتوى.