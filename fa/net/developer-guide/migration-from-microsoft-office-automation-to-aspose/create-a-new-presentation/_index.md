---
title: ایجاد ارائه‌های جدید با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: ایجاد ارائه جدید
type: docs
weight: 10
url: /fa/net/create-a-new-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و ارائه‌های جدید PowerPoint (PPT، PPTX) را در C# با کدی تمیز و قابل اعتماد ایجاد نمایید."
---
{{% alert color="info" %}} 

VSTO برای این که توسعه‌دهندگان بتوانند برنامه‌هایی بسازند که در داخل Microsoft Office اجرا شوند، توسعه یافت. VSTO مبتنی بر COM است اما داخل یک شیء .NET بسته‌بندی شده تا در برنامه‌های .NET قابل استفاده باشد. VSTO به پشتیبانی .NET Framework و همچنین زمان اجرا پایه‌دار بر CLR برای Microsoft Office نیاز دارد. اگرچه می‌توان از آن برای ساخت افزونه‌های Microsoft Office استفاده کرد، استفاده از آن به‌عنوان یک مؤلفه سمت سرور تقریباً غیرممکن است و مشکلات جدی در استقرار دارد.

Aspose.Slides for .NET یک مؤلفه است که می‌تواند ارائه‌های Microsoft PowerPoint را همانند VSTO دستکاری کند، اما مزایای متعددی دارد:

- Aspose.Slides فقط شامل کد مدیریت‌شده است و نیازی به نصب زمان اجرا Microsoft Office ندارد.
- می‌تواند به‌عنوان یک مؤلفه سمت مشتری یا سمت سرور استفاده شود.
- استقرار آسان است زیرا Aspose.Slides در یک DLL واحد قرار دارد.

{{% /alert %}} 
## **ایجاد یک ارائه**
در زیر دو مثال کد موجود است که نشان می‌دهند چگونه می‌توان با VSTO و Aspose.Slides for .NET به هدف یکسان رسید. مثال اول [VSTO](/slides/fa/net/create-a-new-presentation/) است؛ مثال دوم [مثال دوم](/slides/fa/net/create-a-new-presentation/) از Aspose.Slides استفاده می‌کند.
### **مثال VSTO**
**خروجی VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//نکته: PowerPoint یک فضای نام است که در بالا به این شکل تعریف شده است
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
**خروجی Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//ایجاد یک ارائه
Presentation pres = new Presentation();

//اضافه کردن اسلاید عنوان
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//تنظیم متن عنوان
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//تنظیم متن زیرعنوان
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//نوشتن خروجی به دیسک
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```