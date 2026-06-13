---
title: ایجاد یک ارائه جدید در VSTO و Aspose.Slides
type: docs
weight: 80
url: /fa/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
در ادامه دو مثال کد آورده شده است که نشان می‌دهد چگونه می‌توان از VSTO و Aspose.Slides برای .NET برای رسیدن به همان هدف استفاده کرد.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//دریافت طرح اسلاید عنوان

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//افزودن یک اسلاید عنوان.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//تنظیم متن عنوان

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//تنظیم متن زیرعنوان

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//نوشتن خروجی به دیسک

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()
{
	//ایجاد یک ارائه
	Presentation pres = new Presentation();
	//افزودن اسلاید عنوان
	Slide slide = pres.AddTitleSlide();
	//تنظیم متن عنوان
	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";
	//تنظیم متن زیرعنوان
	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";
	//نوشتن خروجی به دیسک
	pres.Write("outAsposeSlides.ppt");
}
``` 
## **دانلود کد نمونه**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)