---
title: ทำงานกับขนาดและเค้าโครงของงานนำเสนอ
type: docs
weight: 90
url: /th/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** และ **SlideSize.Size** เป็นคุณสมบัติของคลาส Presentation ที่สามารถตั้งค่าหรือดึงค่าได้ตามที่แสดงในตัวอย่างด้านล่าง
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ 
Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//ตั้งค่าขนาดสไลด์ของงานนำเสนอที่สร้างขึ้นให้เท่ากับของต้นฉบับ
auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//บันทึก Presentation ไปยังดิสก์
auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างที่ทำงานได้**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
สำหรับรายละเอียดเพิ่มเติม ดูที่ [เปลี่ยนขนาดสไลด์การนำเสนอใน .NET](/slides/th/net/slide-size/).
{{% /alert %}}