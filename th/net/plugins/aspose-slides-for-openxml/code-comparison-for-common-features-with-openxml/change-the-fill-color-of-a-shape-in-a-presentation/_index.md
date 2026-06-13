---
title: เปลี่ยนสีเติมของรูปร่างในงานนำเสนอ
type: docs
weight: 40
url: /th/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **การนำเสนอ OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// เปลี่ยนสีเติมของรูปร่าง.

// ไฟล์ทดสอบต้องมีรูปร่างที่เติมสีเป็นรูปร่างแรกบนสไลด์แรก.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // ดึงค่า Relationship ID ของสไลด์แรก.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // ดึงส่วนของสไลด์จาก Relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // ดึง Shape tree ที่ประกอบด้วยรูปร่างที่จะเปลี่ยน.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // ดึงรูปร่างแรกใน Shape tree.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // ดึงสไตล์ของรูปร่าง.

                ShapeStyle style = shape.ShapeStyle;

                // ดึง Fill reference.

                Drawing.FillReference fillRef = style.FillReference;

                // ตั้งค่าสีเติมเป็น SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // บันทึกสไลด์ที่แก้ไขแล้ว.

                slide.Slide.Save();

            }

        }

    }

}
```
## **Aspose.Slides**
เราต้องทำตามขั้นตอนต่อไปนี้เพื่อเติมสีให้รูปร่างในงานนำเสนอ:

- สร้างอินสแตนซ์ของคลาส Presentation.
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม IShape ลงในสไลด์.
- ตั้งค่า Fill Type ของ Shape เป็น Solid.
- ตั้งค่าสีของ Shape.
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//สร้างอินสแตนซ์ของคลาส PrseetationEx ที่แสดงถึงไฟล์ PPTX

using (Presentation pres = new Presentation())

{

    //ดึงสไลด์แรก

    ISlide sld = pres.Slides[0];

    //เพิ่ม AutoShape แบบสี่เหลี่ยม

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //ตั้งค่าแบบเติมเป็น Solid

    shp.FillFormat.FillType = FillType.Solid;

    //ตั้งค่าสีของสี่เหลี่ยม

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //เขียนไฟล์ PPTX ไปยังดิสก์

    pres.Save(FileName, SaveFormat.Pptx);

}

```
## **ดาวน์โหลดตัวอย่างโค้ดที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **ตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)