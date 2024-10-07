---
title: إضافة نص ديناميكي
type: docs
weight: 40
url: /net/adding-text-dynamically/
---

تتبع كلا الطريقتين هذه الخطوات:

- إنشاء عرض تقديمي.
- إضافة شريحة فارغة.
- إضافة مربع نص.
- تعيين بعض النص.
- كتابة العرض التقديمي.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//إنشاء عرض تقديمي

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//الحصول على تخطيط الشريحة الفارغة

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//إضافة شريحة فارغة

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//إضافة نص

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//تعيين نص

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "تم إضافة النص ديناميكيًا";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//كتابة الناتج إلى القرص

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//إنشاء عرض تقديمي

	Presentation pres = new Presentation();

	//يتم إضافة شريحة فارغة افتراضيًا عند إنشاء

	//عرض تقديمي من الباني الافتراضي

	//لذا، لا نحتاج إلى إضافة أي شريحة فارغة

	Slide sld = pres.GetSlideByPosition(1);

	//الحصول على فهرس الخط لـ Arial

	//دائمًا يكون 0 إذا أنشأت عرضًا تقديميًا من

	//الباني الافتراضي

	int arialFontIndex = 0;

	//إضافة مربع نص

	//لإضافته، سنقوم أولاً بإضافة مستطيل

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//إخفاء حدوده

	shp.LineFormat.ShowLines = false;

	//ثم إضافة إطار نص داخله

	TextFrame tf = shp.AddTextFrame("");

	//تعيين نص

	tf.Text = "تم إضافة النص ديناميكيًا";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//كتابة الناتج إلى القرص

	pres.Write("outAspose.ppt");

}

``` 
## **تنزيل الكود التجريبي**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)