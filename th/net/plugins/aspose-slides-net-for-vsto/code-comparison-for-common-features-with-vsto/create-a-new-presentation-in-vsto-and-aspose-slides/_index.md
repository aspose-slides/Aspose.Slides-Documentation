---
title: สร้างงานนำเสนอใหม่ใน VSTO และ Aspose.Slides
type: docs
weight: 80
url: /th/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
ด้านล่างเป็นตัวอย่างโค้ดสองตัวอย่างที่แสดงให้เห็นว่า VSTO และ Aspose.Slides สำหรับ .NET สามารถใช้เพื่อบรรลุเป้าหมายเดียวกันได้อย่างไร
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Set the title text

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()
{
	//สร้างงานนำเสนอ
	Presentation pres = new Presentation();
	//เพิ่มสไลด์หัวข้อ
	Slide slide = pres.AddTitleSlide();
	//ตั้งค่าข้อความหัวข้อ
	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";
	//ตั้งค่าข้อความหัวข้อย่อย
	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";
	//เขียนผลลัพธ์ไปยังดิสก์
	pres.Write("outAsposeSlides.ppt");
}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)