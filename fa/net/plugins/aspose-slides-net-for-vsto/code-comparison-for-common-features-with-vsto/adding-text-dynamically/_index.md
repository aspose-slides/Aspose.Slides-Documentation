---
title: افزودن متن به صورت پویا
type: docs
weight: 40
url: /fa/net/adding-text-dynamically/
---
هر دو روش مراحل زیر را دنبال می‌کنند:

- یک ارائه ایجاد کنید.
- یک اسلاید خالی اضافه کنید.
- یک جعبه متن اضافه کنید.
- متن موردنظر را تنظیم کنید.
- نوشتن ارائه.

## **VSTO**
``` csharp

 private void AddTextBox()

{

	//ایجاد یک ارائه
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//دریافت طرح اسلاید خالی
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//اضافه کردن اسلاید خالی
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//اضافه کردن متن
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//تنظیم متن
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//نوشتن خروجی به دیسک
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//ایجاد یک ارائه
	Presentation pres = new Presentation();

	//اسلاید خالی به صورت پیش‌فرض اضافه می‌شود، وقتی شما می‌سازید
	//ارائه از سازنده پیش‌فرض
	//بنابراین، نیازی به اضافه کردن اسلاید خالی نداریم
	Slide sld = pres.GetSlideByPosition(1);

	//دریافت شاخص قلم برای Arial
	//همیشه ۰ است اگر ارائه را از
	//سازنده پیش‌فرض
	int arialFontIndex = 0;

	//افزودن یک جعبه متن
	//برای افزودن آن، ابتدا یک مستطیل اضافه می‌کنیم
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//پنهان کردن خط آن
	shp.LineFormat.ShowLines = false;

	//سپس یک قاب متن داخل آن اضافه کنید
	TextFrame tf = shp.AddTextFrame("");

	//تنظیم متن
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//نوشتن خروجی به دیسک
	pres.Write("outAspose.ppt");

}

``` 
## **کد نمونه را دانلود کنید**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)