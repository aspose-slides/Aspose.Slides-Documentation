---
title: จัดการย่อหน้าข้อความ PowerPoint ใน .NET
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/net/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อย่อย
- การเยื้องย่อหน้า
- การเยื้องแบบ hanging
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัติของย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ .NET—ปรับปรุงการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX, และ ODP ด้วย C#."
---
## **บทนำ**

Aspose.Slides มีอินเทอร์เฟซและคลาสทั้งหมดที่คุณต้องการใช้ในการทำงานกับข้อความ PowerPoint, ย่อหน้า และส่วนใน C#.

* Aspose.Slides มีอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แทนย่อหน้าอ็อบเจ็กต์ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างผ่านการขึ้นบรรทัดใหม่)
* Aspose.Slides มีอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แทนส่วนอ็อบเจ็กต์ `IParagraph` สามารถมีหนึ่งหรือหลายส่วน (คอลเลกชันของอ็อบเจ็กต์ iPortions)
* Aspose.Slides มีอินเทอร์เฟซ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แทนข้อความและคุณสมบัติกำหนดรูปแบบของมัน

อ็อบเจ็กต์ `IParagraph` สามารถจัดการข้อความที่มีคุณสมบัติกำหนดรูปแบบต่าง ๆ ผ่านอ็อบเจ็กต์ `IPortion` ที่เป็นพื้นฐานของมัน

## **เพิ่มย่อหน้าหลายรายการที่มีหลายส่วน**

ขั้นตอนต่อไปนี้แสดงวิธีเพิ่มกรอบข้อความที่ประกอบด้วย 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เพิ่มสี่เหลี่ยม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงบนสไลด์
4. รับ ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
5. สร้างอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) จำนวนสองอ็อบเจ็กต์และเพิ่มลงในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
6. สร้างอ็อบเจ็กต์ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) จำนวนสามอ็อบเจ็กต์สำหรับแต่ละ `IParagraph` ใหม่ (สองอ็อบเจ็กต์ Portion สำหรับย่อหน้าเริ่มต้น) และเพิ่มแต่ละอ็อบเจ็กต์ `IPortion` ลงในคอลเลกชัน IPortion ของแต่ละ `IParagraph`
7. ตั้งข้อความสำหรับแต่ละส่วน
8. ใช้คุณลักษณะการกำหนดรูปแบบที่คุณต้องการกับแต่ละส่วนโดยใช้คุณสมบัติการกำหนดรูปแบบที่เปิดเผยจากอ็อบเจ็กต์ `IPortion`
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# ด้านล่างเป็นการดำเนินการตามขั้นตอนสำหรับการเพิ่มย่อหน้าที่มีส่วน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // เพิ่ม IAutoShape รูปสี่เหลี่ยม
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // เข้าถึง TextFrame ของ AutoShape
    ITextFrame tf = ashp.TextFrame;

    // สร้างย่อหน้าและส่วนด้วยรูปแบบข้อความต่าง ๆ
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **จัดการรูปแบบหัวข้อย่อยแบบ Bullets**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มี Bullets จะอ่านและเข้าใจได้ง่ายขึ้นเสมอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงบนสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/)
8. ตั้งค่า `Type` ของ bullet เป็น `Symbol` และกำหนดอักขระ bullet
9. ตั้งค่า `Text` ของย่อหน้า
10. ตั้งค่า `Indent` ของ bullet สำหรับย่อหน้านั้น
11. ตั้งค่าสีของ bullet
12. ตั้งค่าความสูงของ bullet
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าใน `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนที่ 7‑13
15. บันทึกงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีเพิ่ม bullet ให้กับย่อหน้า:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];


    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // ลบย่อหน้าเริ่มต้น
    txtFrm.Paragraphs.RemoveAt(0);

    // สร้างย่อหน้า
    Paragraph para = new Paragraph();

    // ตั้งค่ารูปแบบหัวข้อย่อยของย่อหน้าและสัญลักษณ์
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // ตั้งค่าข้อความย่อหน้า
    para.Text = "Welcome to Aspose.Slides";

    // ตั้งค่าการเยื้อนหัวข้อย่อย
    para.ParagraphFormat.Indent = 25;

    // ตั้งค่าสีหัวข้อย่อย
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งค่าความสูงของหัวข้อย่อย
    para.ParagraphFormat.Bullet.Height = 100;

    // เพิ่มย่อหน้าลงใน TextFrame
    txtFrm.Paragraphs.Add(para);

    // สร้างย่อหน้าที่สอง
    Paragraph para2 = new Paragraph();

    // ตั้งค่าชนิดและรูปแบบหัวข้อย่อยของย่อหน้า
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // เพิ่มข้อความย่อหน้า
    para2.Text = "This is numbered bullet";

    // ตั้งค่าการเยื้อนหัวข้อย่อย
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งค่าความสูงของหัวข้อย่อย
    para2.ParagraphFormat.Bullet.Height = 100;

    // เพิ่มย่อหน้าลงใน TextFrame
    txtFrm.Paragraphs.Add(para2);


    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **จัดการรูปแบบ Bullet แบบรูปภาพ**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีรูปภาพเป็น Bullet อ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/)
7. โหลดรูปภาพใน [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)
8. ตั้งค่า bullet type เป็น [Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) และกำหนดรูปภาพ
9. ตั้งค่า `Text` ของย่อหน้า
10. ตั้งค่า `Indent` ของ bullet สำหรับย่อหน้านั้น
11. ตั้งค่าสีของ bullet
12. ตั้งค่าความสูงของ bullet
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าใน `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามที่ได้อธิบายไว้ก่อนหน้า
15. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการ Bullet แบบรูปภาพ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation presentation = new Presentation();

// เข้าถึงสไลด์แรก
ISlide slide = presentation.Slides[0];

// สร้างอินสแตนซ์ของภาพสำหรับหัวข้อย่อย
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// เพิ่มและเข้าถึง Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// เข้าถึง TextFrame ของ autoshape
ITextFrame textFrame = autoShape.TextFrame;

// ลบย่อหน้าเริ่มต้น
textFrame.Paragraphs.RemoveAt(0);

// สร้างย่อหน้าใหม่
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// ตั้งค่ารูปแบบหัวข้อย่อยของย่อหน้าและภาพ
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// ตั้งค่าความสูงของหัวข้อย่อย
paragraph.ParagraphFormat.Bullet.Height = 100;

// เพิ่มย่อหน้าลงใน TextFrame
textFrame.Paragraphs.Add(paragraph);

// เขียนงานนำเสนอเป็นไฟล์ PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// เขียนงานนำเสนอเป็นไฟล์ PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **จัดการ Bullet แบบหลายระดับ**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Bullet แบบหลายระดับอ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 0
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 1
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 2
9. สร้างย่อหน้าที่สี่ผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 3
10. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าใน `TextFrame`
11. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการ Bullet แบบหลายระดับ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];
    
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    ITextFrame text = aShp.AddTextFrame("");
    
    // ลบย่อหน้าเริ่มต้น
    text.Paragraphs.Clear();

    // เพิ่มย่อหน้าแรก
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ตั้งค่าระดับหัวข้อย่อย
    para1.ParagraphFormat.Depth = 0;

    // เพิ่มย่อหน้าที่สอง
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ตั้งค่าระดับหัวข้อย่อย
    para2.ParagraphFormat.Depth = 1;

    // เพิ่มย่อหน้าที่สาม
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ตั้งค่าระดับหัวข้อย่อย
    para3.ParagraphFormat.Depth = 2;

    // เพิ่มย่อหน้าที่สี่
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // ตั้งค่าระดับหัวข้อย่อย
    para4.ParagraphFormat.Depth = 3;

    // เพิ่มย่อหน้าเข้าในคอลเลกชัน
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // เขียนงานนำเสนอเป็นไฟล์ PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **จัดการย่อหน้าด้วยรายการเลขกำกับแบบกำหนดเอง**

อินเทอร์เฟซ [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าด้วยการนับเลขหรือการกำหนดรูปแบบแบบกำหนดเอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class
2. เข้าถึงสไลด์ที่มีย่อหน้า
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith) เป็น 2
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าใน `TextFrame`
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการย่อหน้าด้วยการนับเลขหรือการกำหนดรูปแบบแบบกำหนดเอง:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
	ITextFrame textFrame = shape.TextFrame;

	// ลบย่อหน้าเริ่มต้นที่มีอยู่
	textFrame.Paragraphs.RemoveAt(0);

	// รายการแรก
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **กำหนด Indent บรรทัดแรกสำหรับย่อหน้า**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า ค่าที่เป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ที่ตำแหน่งเดิมของย่อหน้า

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและตั้งค่าค่า `Indent` ต่าง ๆ เพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงบนสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ที่ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่าค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Indent ของย่อหน้า:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The first-line indent of the paragraphs](first_line_indent.png)

## **กำหนด Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ตั้งค่า `Indent` เป็นค่าลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาของย่อหน้า

โดยปกติ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ MarginLeft การสร้าง Hanging Indent ให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ

รูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการศัพท์ และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ต่อเนื่องจัดชิดกับเนื้อหาย่อหน้าแทนบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงบนสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ที่ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) ที่เป็นค่าบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์ Hanging Indent
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Hanging Indent สำหรับย่อหน้า:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The hanging indent of the paragraphs](hanging_indent.png)

## **จัดการคุณสมบัติ End ของย่อหน้า**

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) class
1. รับอ้างอิงสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน
1. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) แบบสี่เหลี่ยมลงบนสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ที่มีสองย่อหน้าลงในสี่เหลี่ยม
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า
1. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า
1. เขียนไฟล์งานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด C# นี้แสดงวิธีตั้งค่าคุณสมบัติ End สำหรับย่อหน้าใน PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **นำเข้า HTML Text ไปยังย่อหน้า**

Aspose.Slides มีการสนับสนุนขั้นสูงสำหรับการนำเข้า HTML Text ไปยังย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ลงบนสไลด์
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)
5. ลบย่อหน้าเริ่มต้นใน `ITextFrame`
6. อ่านไฟล์ HTML ต้นฉบับโดยใช้ TextReader
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# นี้เป็นการดำเนินการตามขั้นตอนสำหรับการนำเข้า HTML Text ไปยังย่อหน้า:

```c#
// สร้างอินสแตนซ์การนำเสนอเปล่า
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรกที่เป็นค่าเริ่มต้นของการนำเสนอ
    ISlide slide = pres.Slides[0];

    // เพิ่ม AutoShape เพื่อบรรจุเนื้อหา HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // เพิ่ม TextFrame ให้กับรูปร่าง
    ashape.AddTextFrame("");

    // ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มเข้ามา
    ashape.TextFrame.Paragraphs.Clear();

    // โหลดไฟล์ HTML ด้วย StreamReader
    TextReader tr = new StreamReader("file.html");

    // เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // บันทึกการนำเสนอ
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนขั้นสูงสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปยัง HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์ที่ต้องการผ่านตำแหน่งดัชนีของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของรูปร่างนั้น
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่
6. ระบุดัชนีเริ่มต้นให้กับ StreamWriter และส่งออกย่อหน้าที่ต้องการ

โค้ด C# นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปยัง HTML:

```c#
// โหลดไฟล์การนำเสนอ
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    ISlide slide = pres.Slides[0];

    // เข้าถึงดัชนีที่ต้องการ
    int index = 0;

    // เข้าถึงรูปร่างที่เพิ่มเข้ามา
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกย่อข้อความที่แสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เป็นภาพ ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่มีย่อหน้าด้วยเมธอด `GetImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/), การคำนวณขอบเขตของย่อหน้าในรูปร่าง, และการส่งออกเป็นภาพบิตแมพ วิธีเหล่านี้ช่วยให้คุณดึงส่วนของข้อความจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์ในสถานการณ์ต่าง ๆ

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![The text box with three paragraphs](paragraph_to_image_input.png)

**ตัวอย่าง 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยการดึงภาพของรูปร่างจากสไลด์แรกของงานนำเสนอ แล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่าง ย่อหน้าจะถูกวาดใหม่บนบิตแมพภาพใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้มีประโยชน์เมื่อคุณต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยยังคงรักษาขนาดและการกำหนดรูปแบบของข้อความลต้น

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

ผลลัพธ์:

![The paragraph image](paragraph_to_image_output.png)

**ตัวอย่าง 2**

ในตัวอย่างนี้ เราขยายแนวทางเดิมโดยเพิ่มปัจจัยสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงจากงานนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ผลลัพธ์ความละเอียดสูงกว่าเมื่อส่งออกย่อหน้า จากนั้นคำนวณขอบเขตย่อหน้าโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เมื่อต้องการภาพที่ละเอียดมากขึ้น เช่น ใช้ในสื่อพิมพ์คุณภาพสูง

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติใน TextFrame ได้หรือไม่?**

ได้ ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/wraptext/)) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่แตกที่ขอบของกรอบ

**ฉันจะหาขอบเขตบนสไลด์ของย่อหน้าที่กำหนดได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือแม้แต่ของส่วนเดียว) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/กลาง/เต็ม) ควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/) ซึ่งจะใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการกำหนดรูปแบบของส่วนแต่ละส่วน

**ฉันสามารถตั้งค่าภาษาเช็คตัวสะกดสำหรับส่วนของย่อหน้าเดียว (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาได้รับการตั้งค่าที่ระดับส่วน ([PortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/)) ดังนั้นสามารถมีหลายภาษาภายในย่อหน้าหนึ่งได้