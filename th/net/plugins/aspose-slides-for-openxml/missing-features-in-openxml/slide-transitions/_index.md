---
title: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/net/slide-transitions/
---
เพื่อให้ง่ายต่อการเข้าใจ เราได้สาธิตการใช้ Aspose.Slides for .NET เพื่อจัดการการเปลี่ยนสไลด์อย่างง่าย ผู้พัฒนาสามารถไม่เพียงแค่ใช้เอฟเฟกต์การเปลี่ยนสไลด์ที่ต่างกันบนสไลด์เท่านั้น แต่ยังสามารถกำหนดพฤติกรรมของเอฟเฟกต์การเปลี่ยนเหล่านี้ได้ เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์อย่างง่าย ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for .NET เสนอผ่าน enum **TransitionType**
- บันทึกไฟล์การนำเสนอที่แก้ไขแล้ว
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
using (Presentation pres = new Presentation(FileName))
{
    //ใช้การเปลี่ยนสไลด์แบบวงกลมบนสไลด์ที่ 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    //ใช้การเปลี่ยนสไลด์แบบคอมบบนสไลด์ที่ 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;
    //ใช้การเปลี่ยนสไลด์แบบซูมบนสไลด์ที่ 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
    //บันทึกการนำเสนอลงดิสก์
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างที่ทำงานได้**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
สำหรับรายละเอียดเพิ่มเติม โปรดเยี่ยมชม [การจัดการการเปลี่ยนสไลด์](/slides/th/net/slide-transition/).
{{% /alert %}}