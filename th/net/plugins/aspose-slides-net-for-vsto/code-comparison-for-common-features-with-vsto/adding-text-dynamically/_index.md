---
title: การเพิ่มข้อความแบบไดนามิก
type: docs
weight: 40
url: /th/net/adding-text-dynamically/
---
ทั้งสองวิธีทำตามขั้นตอนต่อไปนี้:

- สร้างงานนำเสนอ.
- เพิ่มสไลด์เปล่า.
- เพิ่มกล่องข้อความ.
- ตั้งค่าข้อความบางส่วน.
- เขียนงานนำเสนอ.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//สร้างงานนำเสนอ
	PowerPoint.Presentation pres = Globals.ThisAddIn.Application
		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
	//รับรูปแบบสไลด์เปล่า
	PowerPoint.CustomLayout layout = pres.SlideMaster.
		CustomLayouts[7];
	//เพิ่มสไลด์เปล่า
	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);
	//เพิ่มข้อความ
	PowerPoint.Shape shp =sld.Shapes.AddTextbox
	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);
	//ตั้งค่าข้อความ
	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
	txtRange.Text = "Text added dynamically";
	txtRange.Font.Name = "Arial";
	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
	txtRange.Font.Size = 32;
	//เขียนผลลัพธ์ไปยังดิสก์
	pres.SaveAs("outVSTOAddingText.ppt",
		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
		Microsoft.Office.Core.MsoTriState.msoFalse);
}
```
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//สร้างงานนำเสนอ
	Presentation pres = new Presentation();

	//สไลด์เปล่าจะถูกเพิ่มโดยค่าเริ่มต้นเมื่อคุณสร้าง
	//งานนำเสนอจากคอนสตรัคเตอร์เริ่มต้น
	//ดังนั้น เราไม่จำเป็นต้องเพิ่มสไลด์เปล่าใดๆ
	Slide sld = pres.GetSlideByPosition(1);

	//รับดัชนีฟอนต์สำหรับ Arial
	//มันจะเป็น 0 เสมอหากคุณสร้างงานนำเสนอจาก
	//คอนสตรัคเตอร์เริ่มต้น
	int arialFontIndex = 0;

	//เพิ่มกล่องข้อความ
	//เพื่อติดตั้งมัน เราจะเพิ่มสี่เหลี่ยมก่อน
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//ซ่อนเส้นของมัน
	shp.LineFormat.ShowLines = false;

	//จากนั้นเพิ่ม TextFrame ภายใน
	TextFrame tf = shp.AddTextFrame("");

	//ตั้งค่าข้อความ
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//เขียนผลลัพธ์ไปยังดิสก์
	pres.Write("outAspose.ppt");

}
```
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)