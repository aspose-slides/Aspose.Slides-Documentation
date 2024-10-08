---
title: تعيين لون الخلفية للشريحة الرئيسية
type: docs
weight: 140
url: /ar/net/setting-background-color-of-master-slide/
---

## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("تعيين لون الخلفية للشريحة الرئيسية.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //إنشاء كائن لفئة Presentation الذي يمثل ملف العرض التقديمي

using (PresentationEx pres = new PresentationEx())

{

	//تعيين لون الخلفية للشريحة الرئيسية ISlide إلى الأخضر الغابي

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//كتابة العرض التقديمي إلى القرص

	pres.Save("تعيين لون الخلفية للشريحة الرئيسية.pptx", SaveFormat.Pptx);

``` 
## **تحميل رمز العينة**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/787342)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Setting%20Background%20color%20of%20Master%20Slide%20\(Asose.Slides\).zip)