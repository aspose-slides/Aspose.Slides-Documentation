---
title: ترويسة وتذييل العرض التقديمي
type: docs
weight: 140
url: /net/presentation-header-and-footer/
keywords: "ترويسة, تذييل, تعيين ترويسة, تعيين تذييل, تعيين ترويسة وتذييل, عرض بوربوينت, C#, Csharp, Aspose.Slides for .NET"
description: "ترويسة وتذييل عرض بوربوينت بلغة C# أو .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/net/) يوفر دعمًا للعمل مع نصوص ترويسة وتذييل الشرائح التي يتم الاحتفاظ بها فعليًا على مستوى شريحة الماستر.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/net/) يوفر ميزة إدارة ترويسات وتذييلات داخل شرائح العرض التقديمي. هذه تُدار في الواقع على مستوى ماستر العرض التقديمي.
## **إدارة نصوص الترويسة والتذييل**
يمكن تحديث ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

```c#
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");

// تعيين التذييل
pres.HeaderFooterManager.SetAllFootersText("نص التذييل الخاص بي");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// الوصول إلى تحديث الترويسة
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// حفظ العرض التقديمي
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// طريقة لتعيين نص الترويسة/التذييل
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "مرحبًا بك في الترويسة الجديدة";
            }
        }
    }
}
```




## **إدارة الترويسة والتذييل في شرائح الملاحظات والنسخ**
يدعم Aspose.Slides for .NET الترويسة والتذييل في شرائح النسخ والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation) الذي يحتوي على فيديو.
- تغيير إعدادات الترويسة والتذييل لماستر الملاحظات وجميع شرائح الملاحظات.
- جعل شريحة الملاحظات الرئيسية وجميع عناصر التذييل المرئية.
- جعل شريحة الملاحظات الرئيسية وجميع عناصر تاريخ ووقت المرئية.
- تغيير إعدادات الترويسة والتذييل لشريحة الملاحظات الأولى فقط.
- جعل عنصر ترويسة شريحة الملاحظات مرئيًا.
- تعيين نص لعنصر ترويسة شريحة الملاحظات.
- تعيين نص لعنصر تاريخ ووقت شريحة الملاحظات.
- كتابة ملف العرض التقديمي المعدل.

تم تقديم مقتطف الشيفرة في المثال أدناه.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// تغيير إعدادات الترويسة والتذييل لماستر الملاحظات وجميع شرائح الملاحظات
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر التذييل المرئية
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر الترويسة المرئية
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر رقم الشريحة المرئية
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر التاريخ والوقت المرئية

		headerFooterManager.SetHeaderAndChildHeadersText("نص الترويسة"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع عناصر الترويسة
		headerFooterManager.SetFooterAndChildFootersText("نص التذييل"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع عناصر التذييل
		headerFooterManager.SetDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع عناصر التاريخ والوقت
	}

	// تغيير إعدادات الترويسة والتذييل لشريحة الملاحظات الأولى فقط
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // جعل عنصر ترويسة شريحة هذه الملاحظات مرئيًا

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // جعل عنصر تذييل شريحة هذه الملاحظات مرئيًا

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // جعل عنصر رقم شريحة هذه الملاحظات مرئيًا

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // جعل عنصر تاريخ ووقت شريحة هذه الملاحظات مرئيًا

		headerFooterManager.SetHeaderText("نص الترويسة الجديدة"); // تعيين نص لعنصر ترويسة شريحة الملاحظات
		headerFooterManager.SetFooterText("نص التذييل الجديد"); // تعيين نص لعنصر تذييل شريحة الملاحظات
		headerFooterManager.SetDateTimeText("نص التاريخ والوقت الجديد"); // تعيين نص لعنصر تاريخ ووقت شريحة الملاحظات
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```