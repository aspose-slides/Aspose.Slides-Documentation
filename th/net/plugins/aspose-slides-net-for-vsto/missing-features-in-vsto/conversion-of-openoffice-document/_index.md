---
title: การแปลงเอกสาร OpenOffice
type: docs
weight: 30
url: /th/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET มีคลาส **Presentation** ที่เป็นตัวแทนของไฟล์งานนำเสนอ. คลาส **Presentation** ตอนนี้ยังสามารถเข้าถึง **ODP** ผ่านตัวสร้าง Presentation เมื่อวัตถุถูกสร้างขึ้น

ด้านล่างเป็นตัวอย่างการแปลงจาก ODP เป็น PPT/PPTX.
## **ตัวอย่าง**
```

 //สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //บันทึกงานนำเสนอ PPTX ในรูปแบบ PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

ด้านล่างเป็นตัวอย่างการแปลงจาก PPT/PPTX เป็น ODP.
## **ตัวอย่าง**
``` 

 //สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //บันทึกงานนำเสนอ PPTX ในรูปแบบ PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}
``` 
## **ดาวน์โหลดตัวอย่างการทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **ดาวน์โหลดตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)