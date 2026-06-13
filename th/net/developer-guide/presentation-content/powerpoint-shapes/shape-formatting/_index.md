---
title: การจัดรูปแบบรูปทรง PowerPoint ใน .NET
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/net/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมแบบไล่สี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- การหมุนรูปทรง
- เอฟเฟกต์บีเวิล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ด้วย C# และ Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำพร้อมการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบของพวกมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมภายในของรูปทรง

![การจัดรูปแบบรูปร่าง PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET มีอินเทอร์เฟซและพรอพเพอร์ตี้ที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกันที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปทรงได้ ขั้นตอนต่อไปนี้สรุปขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/net/aspose.slides/linestyle/) ของรูปทรง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/net/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` รูปร่างสี่เหลี่ยม:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรกมา.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยม.
    shape.FillFormat.FillType = FillType.NoFill;

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในการนำเสนอ](formatted-lines.png)

## **จัดรูปแบบการเชื่อมต่อ**

มีตัวเลือกประเภทการเชื่อมต่อสามแบบดังนี้:

* โค้ง
* มิตเตอร์
* แบเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมสองเส้นด้วยมุม (เช่นที่มุมของรูปทรง) จะใช้การตั้งค่า **โค้ง** อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **มิตเตอร์**

![รูปแบบการเชื่อมต่อในการนำเสนอ](join-style-powerpoint.png)

โค้ด C# ต่อไปนี้แสดงวิธีที่สามสี่เหลี่ยม (ตามที่แสดงในภาพด้านบน) ถูกสร้างโดยใช้การตั้งค่าชนิดการเชื่อม **มิตเตอร์**, **แบเวล**, และ **โค้ง**:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape สามรูปประเภท Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละสี่เหลี่ยม.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // ตั้งค่าความหนาของเส้น.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // เพิ่มข้อความในแต่ละสี่เหลี่ยม.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **เติมแบบไล่สี**

ใน PowerPoint, การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณใช้การผสมสีอย่างต่อเนื่องกับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่าที่สีหนึ่งค่อยๆ จางหายไปสู่สีอีกสีหนึ่ง

ต่อไปนี้เป็นวิธีการเติมแบบไล่สีให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `Add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/net/aspose.slides/igradientformat/)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ประเภท Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับวงรี.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ตั้งค่าทิศทางของไล่สี.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // เพิ่มจุดหยุดไล่สีสองจุด.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปวงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

## **การเติมลวดลาย**

ใน PowerPoint, การเติมลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, ลายเส้น, ลายเส้นขวาง, หรือเช็คบอร์ด—กับรูปทรง คุณสามารถเลือกสีที่กำหนดเองสำหรับพื้นหน้าและพื้นหลังของลวดลาย

Aspose.Slides ให้รูปแบบลวดลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปทรงเพื่อเพิ่มความสวยงามของงานนำเสนอของคุณ แม้หลังจากเลือกลวดลายที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ

ต่อไปนี้เป็นวิธีการเติมลวดลายให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/backcolor/) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/forecolor/) ของลวดลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // ตั้งค่ารูปแบบลวดลาย.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลวดลาย.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลวดลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint, การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพเข้าไปในรูปทรง—โดยทำให้รูปภาพเป็นพื้นหลังของรูปทรง

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่ต้องการอื่น)
1. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) จากภาพที่คุณต้องการใช้
1. กำหนดภาพนี้ให้กับคุณสมบัติ `Picture.Image` ของ `PictureFillFormat` ของรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" พร้อมรูปภาพต่อไปนี้:

![รูป lotus](lotus.png)

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // โหลดรูปภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // ตั้งรูปภาพ.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปทรงที่เติมรูปภาพ](picture-fill.png)

### **เติมรูปแบบกระเบื้องเป็นพื้นผิว**

หากต้องการตั้งค่าภาพแบบกระเบื้องเป็นพื้นผิวและปรับพฤติกรรมการกระเบื้อง คุณสามารถใช้คุณสมบัติดังต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/)：

- [PictureFillMode](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/picturefillmode/)：กำหนดโหมดการเติมรูปภาพ — `Tile` หรือ `Stretch`
- [TileAlignment](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilealignment/)：ระบุตำแหน่งการจัดเรียงของกระเบื้องภายในรูปทรง
- [TileFlip](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileflip/)：ควบคุมการพลิกกระเบื้องในแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [TileOffsetX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsetx/)：กำหนดระยะห่างแนวนอนของกระเบื้อง (เป็นจุด) จากจุดเริ่มต้นของรูปทรง
- [TileOffsetY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsety/)：กำหนดระยะห่างแนวตั้งของกระเบื้อง (เป็นจุด) จากจุดเริ่มต้นของรูปทรง
- [TileScaleX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescalex/)：กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [TileScaleY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescaley/)：กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.Slides[0];

    // เพิ่ม AutoShape สี่เหลี่ยม.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // โหลดรูปภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // กำหนดรูปภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // ตั้งค่าโหมดการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![ตัวเลือกกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint, การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปทรงด้วยสีเดียวที่สม่ำเสมอ โดยไม่มีการไล่สี, พื้นผิว, หรือ ลวดลาย

เพื่อเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่ต้องการให้กับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
 using (Presentation presentation = new Presentation())
 {
     // ดึงสไลด์แรก.
     ISlide slide = presentation.Slides[0];

     // เพิ่ม AutoShape ประเภท Rectangle.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // ตั้งค่าชนิดการเติมเป็น Solid.
     shape.FillFormat.FillType = FillType.Solid;

     // ตั้งค่าสีเติม.
     shape.FillFormat.SolidFillColor.Color = Color.Yellow;

     // บันทึกไฟล์ PPTX ไปยังดิสก์.
     presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
 }
```

ผลลัพธ์:

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งแสง**

ใน PowerPoint, เมื่อคุณใช้การเติมสีทึบ, ไล่สี, รูปภาพ, หรือพื้นผิวกับรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งแสงเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งใสสูงทำให้รูปทรงดูใสขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งแสงโดยการปรับค่าอัลฟ่าในสีที่ใช้สำหรับการเติม อย่างนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color.FromArgb(alpha, baseColor)` เพื่อกำหนดสีที่มีความโปร่งแสง (ค่า `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

```c#
const int alpha = 128;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape สี่เหลี่ยมทึบ.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่ม AutoShape สี่เหลี่ยมโปร่งใสเหนือรูปทรงทึบ.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปทรงที่โปร่งแสง](shape-transparency.png)

## **การหมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามแนวตั้งหรือดีไซน์ที่ต้องการ

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่าคุณสมบัติ `Rotation` ของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงตามมุม 5 องศา.
    shape.Rotation = 5;

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวิล 3D**

Aspose.Slides ให้คุณเพิ่มเอฟเฟกต์บีเวิล 3D ให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวิล 3D ให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่าบีเวิล
1. บันทึกการนำเสนอ

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปทรงลงในสไลด์.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวิล 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

Aspose.Slides ให้คุณเพิ่มเอฟเฟกต์การหมุน 3D ให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3D กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [CameraType](https://reference.aspose.com/slides/th/net/aspose.slides/icamera/cameratype/) และ [LightType](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrig/lighttype/) ของรูปทรงเพื่อกำหนดการหมุน 3D
1. บันทึกการนำเสนอ

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C# ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/) ให้เป็นค่าตั้งต้น:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder บน layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**รูปแบบของรูปทรงส่งผลต่อขนาดไฟล์ของการนำเสนอสุดท้ายหรือไม่?**

เพียงเล็กน้อย เท่านั้น ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์, และไล่สีจะถูกจัดเก็บเป็นเมตาดาต้าและแทบไม่เพิ่มขนาดไฟล์

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีรูปแบบเดียวกันเพื่อจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปทรงเหล่านั้นอย่างมีตรรกะ ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้งานในงานนำเสนออื่นได้หรือไม่?**

ได้. สามารถเก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อสร้างการนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ที่ต้องการ, แล้วนำไปใช้ใหม่ตามต้องการ.