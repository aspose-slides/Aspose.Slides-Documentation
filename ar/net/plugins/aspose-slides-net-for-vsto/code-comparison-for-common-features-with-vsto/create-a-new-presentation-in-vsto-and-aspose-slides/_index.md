---
title: إنشاء عرض تقديمي جديد في VSTO و Aspose.Slides
type: docs
weight: 80
url: /ar/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

تتضمن الأمثلة التالية كودين يوضحان كيف يمكن استخدام VSTO و Aspose.Slides لـ .NET لتحقيق نفس الهدف.
## **VSTO**
```csharp
 private void CreatePresentation()

{
PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//الحصول على تخطيط شريحة العنوان

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//إضافة شريحة عنوان.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//تعيين نص العنوان

slide.Shapes.Title.TextFrame.TextRange.Text = "عنوان الشريحة";

//تعيين نص العنوان الفرعي

slide.Shapes[2].TextFrame.TextRange.Text = "العنوان الفرعي للشريحة";

//كتابة الإخراج إلى القرص

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
```csharp
 private static void CreatePresentation()

{

	//إنشاء عرض تقديمي

	Presentation pres = new Presentation();

	//إضافة شريحة العنوان

	Slide slide = pres.AddTitleSlide();

	//تعيين نص العنوان

	((TextHolder)slide.Placeholders[0]).Text = "عنوان الشريحة";

	//تعيين نص العنوان الفرعي

	((TextHolder)slide.Placeholders[1]).Text = "العنوان الفرعي للشريحة";

	//كتابة الإخراج إلى القرص

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **تحميل رمز العينة**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)