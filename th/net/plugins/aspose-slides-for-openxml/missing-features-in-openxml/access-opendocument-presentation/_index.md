---
title: เข้าถึงการนำเสนอ OpenDocument
type: docs
weight: 10
url: /th/net/access-opendocument-presentation/
---
Aspose.Slides for .NET มีคลาส **Presentation** ที่ใช้แทนไฟล์งานนำเสนอ. คลาส **Presentation** ตอนนี้สามารถเข้าถึง **ODP** ผ่านคอนสตรัคเตอร์ **Presentation** เมื่อวัตถุถูกสร้างขึ้น.
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

using (Presentation pres = new Presentation(srcFileName))

{

    //บันทึกงานนำเสนอ PPTX เป็นรูปแบบ PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างการทำงาน**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)