---
title: เพิ่มรูปภาพในเซลล์ของตาราง
type: docs
weight: 10
url: /th/net/add-image-in-table-cell/
---
## **VSTO**
ด้านล่างเป็นโค้ดสำหรับการเพิ่มรูปภาพในเซลล์ของตาราง:

``` csharp

    //เปิดคลาส Presentation ที่มีตารางอยู่
   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //รับสไลด์แรก
   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides for .NET ได้ให้ API ที่ง่ายที่สุดในการสร้างตารางอย่างง่ายดาย เพื่อเพิ่มรูปภาพในเซลล์ของตารางขณะสร้างตารางใหม่ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง
- กำหนดอาเรย์ของแถวพร้อมความสูง
- เพิ่ม Table ไปยังสไลด์โดยใช้เมธอด AddTable ที่เปิดให้ใช้โดยอ็อบเจกต์ IShapes
- สร้างอ็อบเจกต์ Bitmap เพื่อเก็บไฟล์รูปภาพ
- เพิ่มรูปภาพ Bitmap ไปยังอ็อบเจกต์ IPPImage
- ตั้งค่า Fill Format ของเซลล์ตารางเป็น Picture
- เพิ่มรูปภาพไปยังเซลล์แรกของตาราง
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //รับสไลด์แรก

  ISlide sld = MyPresentation.Slides[0];

  //สร้างอ็อบเจกต์ Bitmap Image เพื่อเก็บไฟล์รูปภาพ

  using IImage image = Images.FromFile(ImageFile);

  //สร้างอ็อบเจกต์ IPPImage ด้วยอ็อบเจกต์ bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //เพิ่มรูปภาพไปยังเซลล์แรกของตาราง

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //บันทึก PPTX ไปยังดิสก์

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **ดาวน์โหลดโค้ดที่ทำงานอยู่**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)