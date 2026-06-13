---
title: กำหนดสีพื้นหลังของสไลด์หลัก
type: docs
weight: 140
url: /th/net/setting-background-color-of-master-slide/
---
## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using (PresentationEx pres = new PresentationEx())
{
	//ตั้งค่าสีพื้นหลังของ Master ISlide เป็นสีเขียวป่า
	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;
	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;
	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;
	//บันทึกงานนำเสนอลงดิสก์
	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);
}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Setting%20Background%20color%20of%20Master%20Slide/)