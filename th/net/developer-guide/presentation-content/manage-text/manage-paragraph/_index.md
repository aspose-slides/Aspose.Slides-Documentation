---
title: จัดการย่อหน้าข้อความ PowerPoint ใน .NET
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อย่อย
- การเยื้องย่อหน้า
- การเยื้องห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการแบบหัวข้อย่อย
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ .NET—ปรับการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย C#."
---
## **บทนำ**

Aspose.Slides ให้ทุกอินเทอร์เฟซและคลาสที่คุณต้องการเพื่อทำงานกับข้อความ, ย่อหน้า, และส่วนต่าง ๆ ของ PowerPoint ใน C#.

* Aspose.Slides มีอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนย่อหน้าได้ อ็อบเจกต์ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าจะสร้างโดยการขึ้นบรรทัดใหม่).
* Aspose.Slides มีอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนส่วนต่าง ๆ ได้ อ็อบเจกต์ `IParagraph` สามารถมีหนึ่งหรือหลายส่วน (ชุดของอ็อบเจกต์ iPortions).
* Aspose.Slides มีอินเทอร์เฟซ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนข้อความและคุณสมบัติการฟอร์แมตของข้อความได้. 

อ็อบเจกต์ `IParagraph` สามารถจัดการข้อความที่มีคุณสมบัติการฟอร์แมตต่าง ๆ ผ่านอ็อบเจกต์ `IPortion` ที่อยู่ภายใต้มัน.

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนต่อไปนี้จะแสดงวิธีเพิ่ม Text Frame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เพิ่ม Rectangle [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์.
4. เรียก ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/).
5. สร้างอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) สองอ็อบเจกต์และเพิ่มเข้าไปในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/).
6. สร้างอ็อบเจกต์ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) สามอ็อบเจกต์สำหรับแต่ละ `IParagraph` ใหม่ (สอง Portion สำหรับ Paragraph เริ่มต้น) และเพิ่มแต่ละอ็อบเจกต์ `IPortion` ไปยังคอลเลกชัน IPortion ของแต่ละ `IParagraph`.
7. กำหนดข้อความให้กับแต่ละ Portion.
8. ใช้คุณสมบัติการฟอร์แมตที่ต้องการกับแต่ละ Portion ผ่านคุณสมบัติของอ็อบเจกต์ `IPortion`.
9. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

โค้ด C# ด้านล่างเป็นการดำเนินตามขั้นตอนการเพิ่มย่อหน้าที่มีส่วน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // เพิ่ม IAutoShape รูปสี่เหลี่ยม
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // เข้าถึง TextFrame ของ AutoShape
    ITextFrame tf = ashp.TextFrame;

    // สร้างย่อหน้าและส่วนต่าง ๆ ด้วยรูปแบบข้อความที่แตกต่างกัน
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
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **จัดการ Bullet ของย่อหน้า**
รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบมี Bullet จะอ่านและเข้าใจได้ง่ายกว่าเสมอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ใส่สไลด์ที่เลือก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ autoshape. 
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอ็อบเจกต์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/).
8. ตั้งค่า `Type` ของ bullet เป็น `Symbol` และกำหนดอักขระของ bullet.
9. ตั้งค่า `Text` ของย่อหน้า.
10. ตั้งค่า `Indent` ของ bullet สำหรับย่อหน้านั้น.
11. กำหนดสีให้กับ bullet.
12. กำหนดความสูงของ bullet.
13. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`.
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนจาก 7 ถึง 13.
15. บันทึกพรีเซนเทชัน.

โค้ด C# ด้านล่างแสดงวิธีเพิ่ม Bullet ให้ย่อหน้า:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];


    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง Text Frame ของ autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // ลบย่อหน้าเริ่มต้น
    txtFrm.Paragraphs.RemoveAt(0);

    // สร้างย่อหน้า
    Paragraph para = new Paragraph();

    // ตั้งค่ารูปแบบหัวข้อย่อยของย่อหน้าและสัญลักษณ์
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // ตั้งค่าข้อความของย่อหน้า
    para.Text = "Welcome to Aspose.Slides";

    // ตั้งค่าการเยื้องหัวข้อย่อย
    para.ParagraphFormat.Indent = 25;

    // ตั้งค่าสีหัวข้อย่อย
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งค่าความสูงของหัวข้อย่อย
    para.ParagraphFormat.Bullet.Height = 100;

    // เพิ่มย่อหน้าไปยัง Text Frame
    txtFrm.Paragraphs.Add(para);

    // สร้างย่อหน้าที่สอง
    Paragraph para2 = new Paragraph();

    // ตั้งค่าชนิดและรูปแบบหัวข้อย่อยของย่อหน้า
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // เพิ่มข้อความย่อหน้า
    para2.Text = "This is numbered bullet";

    // ตั้งค่าการเยื้องหัวข้อย่อย
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งค่าความสูงของหัวข้อย่อย
    para2.ParagraphFormat.Bullet.Height = 100;

    // เพิ่มย่อหน้าไปยัง Text Frame
    txtFrm.Paragraphs.Add(para2);


    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **จัดการ Bullet แบบรูปภาพ**
รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบรูปภาพอ่านและเข้าใจได้ง่าย.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ใส่สไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอ็อบเจกต์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/).
7. โหลดรูปภาพใน [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).
8. ตั้งค่า bullet type เป็น [Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) และกำหนดรูปภาพ.
9. ตั้งค่า `Text` ของ Paragraph.
10. ตั้งค่า `Indent` ของ bullet สำหรับย่อหน้านั้น.
11. กำหนดสีให้กับ bullet.
12. กำหนดความสูงของ bullet.
13. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`.
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามที่กล่าวมาข้างต้น.
15. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการ Bullet แบบรูปภาพ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
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

// เพิ่มย่อหน้าไปยัง Text Frame
textFrame.Paragraphs.Add(paragraph);

// บันทึกพรีเซนเทชันเป็นไฟล์ PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// บันทึกพรีเซนเทชันเป็นไฟล์ PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **จัดการ Bullet แบบหลายระดับ**
รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Bullet แบบหลายระดับอ่านและเข้าใจได้ง่าย.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class.
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ใส่สไลด์ใหม่.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) และกำหนดระดับเป็น 0.
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` และกำหนดระดับเป็น 1.
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` และกำหนดระดับเป็น 2.
9. สร้างย่อหน้าที่สี่ผ่านคลาส `Paragraph` และกำหนดระดับเป็น 3.
10. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`.
11. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการ Bullet แบบหลายระดับ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];
    
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง Text Frame ของ Autoshape ที่สร้าง
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

    // เพิ่มย่อหน้าไปยังคอลเลกชัน
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **จัดการย่อหน้าที่มีรายการลำดับเลขกำหนดเอง**
อินเทอร์เฟซ [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith) และอื่น ๆ ที่ให้คุณจัดการย่อหน้าที่มีการตั้งค่าตัวเลขหรือการฟอร์แมตแบบกำหนดเอง.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class.
2. เข้าถึงสไลด์ที่มีย่อหน้าอยู่.
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ใส่สไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ autoshape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith) เป็น 2.
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3.
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7.
9. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`.
10. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

โค้ด C# ด้านล่างแสดงวิธีเพิ่มและจัดการย่อหน้าที่มีการกำหนดลำดับเลขแบบกำหนดเอง:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// เข้าถึง Text Frame ของ Autoshape ที่สร้าง
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

## **ตั้งค่า Indent แถวแรกของย่อหน้า**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงตำแหน่งเดิม.

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น.

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและกำหนดค่า `Indent` ที่แตกต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) .
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าใส่สไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ว่างเปล่าในรูปทรงและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและกำหนดค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ที่แตกต่างกันสำหรับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าเหล่านั้นเข้าไปใน Text Frame.
7. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

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

## **ตั้งค่า Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้โดยใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/). ตั้งค่า `Indent` เป็นค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า.

โดยปกติ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า ส่วน [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งบรรทัดแรกเทียบกับ MarginLeft. เพื่อสร้าง Hanging Indent ให้ตั้งค่า MarginLeft เป็นบวกและ Indent เป็นลบ.

การฟอร์แมตนี้เหมาะสำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดต่อเนื่องจัดแนวอยู่ใต้เนื้อหาย่อหน้า ไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) .
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าใส่สไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ว่างเปล่าในรูปทรงและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและกำหนดค่า [MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เป็นบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เป็นลบเพื่อสร้างเอฟเฟกต์ Hanging Indent.
7. เพิ่มย่อหน้าเหล่านั้นเข้าไปใน Text Frame.
8. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

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

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) class.
2. รับอ้างอิงสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน.
3. เพิ่มรูปสี่เหลี่ยม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ที่มีสองย่อหน้าใน Rectangle.
5. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า.
6. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า.
7. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX.

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


## **นำเข้า HTML Text เข้าไปในย่อหน้า**
Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ใส่สไลด์.
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/).
5. ลบย่อหน้าเริ่มต้นใน `ITextFrame`.
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader.
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/).
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader เข้าไปใน [ParagraphCollection](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/) ของ TextFrame.
9. บันทึกพรีเซนเทชันที่ปรับปรุงแล้ว.

โค้ด C# นี้เป็นการดำเนินตามขั้นตอนการนำเข้า HTML Text ในย่อหน้า:

```c#
// สร้างอินสแตนซ์ Presentation ว่าง
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรกของพรีเซนเทชันโดยค่าเริ่มต้น
    ISlide slide = pres.Slides[0];

    // เพิ่ม AutoShape เพื่อบรรจุเนื้อหา HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // เพิ่ม Text Frame ให้กับรูปทรง
    ashape.AddTextFrame("");

    // ลบย่อหน้าทั้งหมดใน Text Frame ที่เพิ่ม
    ashape.TextFrame.Paragraphs.Clear();

    // โหลดไฟล์ HTML ด้วย StreamReader
    TextReader tr = new StreamReader("file.html");

    // เพิ่มข้อความจาก StreamReader ของ HTML เข้าสู่ Text Frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // บันทึกพรีเซนเทชัน
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **ส่งออกข้อความย่อหน้าเป็น HTML**
Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดพรีเซนเทชันที่ต้องการ.
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของสไลด์นั้น.
3. เข้าถึงรูปทรงที่มีข้อความที่จะส่งออกเป็น HTML.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของรูปทรงนั้น.
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่.
6. ระบุดัชนีเริ่มต้นให้กับ StreamWriter และส่งออกย่อหน้าที่ต้องการ.

โค้ด C# นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปเป็น HTML:

```c#
// โหลดไฟล์พรีเซนเทชัน
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // เข้าถึงสไลด์แรกของพรีเซนเทชันโดยค่าเริ่มต้น
    ISlide slide = pres.Slides[0];

    // เข้าถึงดัชนีที่ต้องการ
    int index = 0;

    // เข้าถึงรูปทรงที่เพิ่มไว้
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจตัวอย่างสองกรณีที่แสดงวิธีบันทึกย่อความข้อความที่แสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เป็นภาพ ตัวอย่างทั้งสองใช้เมธอด `GetImage` ของอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) เพื่อดึงภาพของรูปทรงที่มีย่อหน้า, คำนวณขอบเขตของย่อหน้าในรูปทรง, และส่งออกเป็นไฟล์ bitmap วิธีเหล่านี้ทำให้คุณสามารถแยกส่วนข้อความจากพรีเซนเทชัน PowerPoint แล้วบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์ในสถานการณ์ต่าง ๆ

สมมติว่าเรามีพรีเซนเทชันไฟล์ชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า.

![The text box with three paragraphs](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยทำการดึงภาพของรูปทรงจากสไลด์แรกของพรีเซนเทชัน แล้วคำนวณขอบเขตของย่อหน้าที่สองใน Text Frame ของรูปทรง ย่อหน้าจะถูกวาดใหม่บน bitmap ใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้เหมาะเมื่อต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงมิตและฟอร์แมตเดิมของข้อความไว้.

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

**ตัวอย่างที่ 2**

ในตัวอย่างนี้ เราเพิ่มปัจจัยสเกลให้กับภาพย่อหน้า รูปทรงจะถูกดึงจากพรีเซนเทชันและบันทึกเป็นภาพด้วยสเกล `2` ทำให้ได้ภาพความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าจะถูกคำนวณโดยคำนึงถึงสเกล การสเกลมีประโยชน์เมื่อต้องการภาพรายละเอียดมาก เช่น ในวัสดุพิมพ์คุณภาพสูง.

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

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน Text Frame ได้หรือไม่?**

ได้. ใช้การตั้งค่า WrapText ของ Text Frame ([WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/wraptext/)) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่ตัดที่ขอบของ Frame.

**ฉันจะได้ขอบเขตบนสไลด์ของย่อหน้าที่ต้องการอย่างแม่นยำได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยม Bounding Rectangle ของย่อหน้า (หรือแม้แต่ของ Portion เดียว) เพื่อทราบตำแหน่งและขนาดที่แน่นอนบนสไลด์.

**การตั้งค่าการจัดแนวของย่อหน้า (ซ้าย/ขวา/ศูนย์/จัดเต็ม) อยู่ที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าที่ระดับ Paragraph ใน [ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/) ซึ่งจะนำไปใช้กับทั้งย่อหน้าโดยไม่คำนึงถึงการฟอร์แมตของ Portion แยกแต่ละส่วน.

**ฉันสามารถกำหนดภาษาตรวจสอบคำสำหรับส่วนของย่อหน้าเดียว (เช่น คำเดียว) ได้หรือไม่?**

ได้. ภาษาเป็นการตั้งค่าที่ระดับ Portion ([PortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/)) ดังนั้นย่อหน้าหนึ่งจึงสามารถมีหลายภาษาได้พร้อมกัน.