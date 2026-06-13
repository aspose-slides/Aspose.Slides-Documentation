---
title: การลบแถวหรือคอลัมน์ในตารางด้วย VSTO และ Aspose.Slides
type: docs
weight: 130
url: /th/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
ต่อไปนี้เป็นโค้ดสำหรับการลบแถวหรือคอลัมน์จากตารางโดยใช้ VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //รับสไลด์แรก

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides สำหรับ .NET ได้ให้ API ที่ง่ายที่สุดในการสร้างตารางอย่างง่ายดาย เพื่อสร้างตารางในสไลด์และทำการดำเนินการพื้นฐานบางอย่างบนตาราง โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง
- กำหนดอาเรย์ของแถวพร้อมความสูง
- เพิ่มตารางลงในสไลด์โดยใช้เมธอด AddTable ที่เปิดให้ใช้จากอ็อบเจ็กต์ IShapes
- ลบแถวของตาราง
- ลบคอลัมน์ของตาราง
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //รับสไลด์แรก

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)