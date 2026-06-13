---
title: จัดการตัวแสดงตำแหน่งในงานนำเสนอใน .NET
linktitle: จัดการตัวแสดงตำแหน่ง
type: docs
weight: 10
url: /th/net/manage-placeholder/
keywords:
- ตัวแสดงตำแหน่ง
- ตัวแสดงตำแหน่งข้อความ
- ตัวแสดงตำแหน่งรูปภาพ
- ตัวแสดงตำแหน่งแผนภูมิ
- ข้อความพร้อมใช้งาน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการตัวแสดงตำแหน่งใน Aspose.Slides สำหรับ .NET อย่างง่ายดาย: แทนที่ข้อความ ปรับแต่งข้อความพร้อมใช้งาน และตั้งค่าความโปร่งใสของรูปภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการกับตัวแสดงตำแหน่งในงานนำเสนอได้โดยใช้โปรแกรม บทความนี้อธิบายวิธีค้นหาตัวแสดงตำแหน่งบนสไลด์และเปลี่ยนข้อความของมัน ตั้งข้อความพร้อมใช้งานแบบกำหนดเองสำหรับเค้าโครงตัวแสดงตำแหน่ง และปรับความโปร่งใสของภาพที่ใช้เป็นพื้นหลังของตัวแสดงตำแหน่ง นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่างตัวแสดงตำแหน่งฐานและรูปร่างท้องถิ่น อธิบายวิธีการนำการเปลี่ยนแปลงของตัวแสดงตำแหน่งไปใช้ผ่านเค้าโครงหรือมาสเตอร์ และชี้ไปยังการจัดการตัวแสดงตำแหน่งส่วนหัวและส่วนท้าย

## **เปลี่ยนข้อความในตัวแสดงตำแหน่ง**

โดยใช้ [Aspose.Slides for .NET](/slides/th/net/), คุณสามารถค้นหาและแก้ไขตัวแสดงตำแหน่งบนสไลด์ในงานนำเสนอได้ Aspose.Slides ช่วยให้คุณสามารถทำการเปลี่ยนแปลงข้อความในตัวแสดงตำแหน่งได้

**ข้อกำหนดเบื้องต้น**: คุณต้องมีงานนำเสนอที่มีตัวแสดงตำแหน่งอยู่ คุณสามารถสร้างงานนำเสนอนั้นในแอปพลิเคชัน Microsoft PowerPoint มาตรฐาน

นี่คือวิธีการที่คุณใช้ Aspose.Slides เพื่อแทนที่ข้อความในตัวแสดงตำแหน่งในงานนำเสนอนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และส่งงานนำเสนอเป็นอาร์กิวเมนต์
2. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน
3. วนลูปผ่านรูปร่างเพื่อค้นหาตัวแสดงตำแหน่ง
4. ทำการแคสต์ประเภทของรูปร่างตัวแสดงตำแหน่งเป็น [`AutoShape`](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) และเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ที่เชื่อมโยงกับ [`AutoShape`](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C# นี้แสดงวิธีการเปลี่ยนข้อความในตัวแสดงตำแหน่ง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // วนลูปผ่านรูปร่างเพื่อค้นหาตัวแสดงตำแหน่ง
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // เปลี่ยนข้อความในแต่ละตัวแสดงตำแหน่ง
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // บันทึกงานนำเสนอลงดิสก์
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ตั้งข้อความพร้อมใช้งานในตัวแสดงตำแหน่ง**

เค้าโครงมาตรฐานและเค้าโครงที่สร้างไว้ล่วงหน้ามีข้อความพร้อมใช้งานของตัวแสดงตำแหน่งเช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** โดยใช้ Aspose.Slides คุณสามารถแทรกข้อความพร้อมใช้งานที่คุณต้องการลงในเค้าโครงของตัวแสดงตำแหน่งได้

โค้ด C# นี้แสดงวิธีการตั้งข้อความพร้อมใช้งานในตัวแสดงตำแหน่ง:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // วนลูปผ่านสไลด์
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint แสดง "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // เพิ่มคำบรรยาย
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าความโปร่งใสของภาพตัวแสดงตำแหน่ง**

Aspose.Slides ช่วยให้คุณตั้งค่าความโปร่งใสของภาพพื้นหลังในตัวแสดงตำแหน่งข้อความได้ โดยการปรับความโปร่งใสของภาพในกรอบดังกล่าว คุณสามารถทำให้ข้อความหรือภาพโดดเด่นขึ้น (ขึ้นอยู่กับสีของข้อความและภาพ)

โค้ด C# นี้แสดงวิธีการตั้งค่าความโปร่งใสสำหรับภาพพื้นหลัง (ภายในรูปร่าง):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **คำถามที่พบบ่อย**

**ตัวแสดงตำแหน่งฐานคืออะไร และแตกต่างจากรูปร่างท้องถิ่นบนสไลด์อย่างไร?**

ตัวแสดงตำแหน่งฐานคือรูปร่างดั้งเดิมบนเค้าโครงหรือมาสเตอร์ที่รูปร่างของสไลด์สืบทอดมาจาก—ประเภท, ตำแหน่ง, และการจัดรูปแบบบางส่วนมาจากมัน ส่วนรูปร่างท้องถิ่นเป็นอิสระ; หากไม่มีตัวแสดงตำแหน่งฐาน การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวข้อหรือคำอธิบายทั้งหมดในงานนำเสนอได้อย่างไรโดยไม่ต้องวนลูปทุกสไลด์?**

แก้ไขตัวแสดงตำแหน่งที่สอดคล้องบนเค้าโครงหรือมาสเตอร์ สไลด์ที่อิงตามเค้าโครง/มาสเตอร์เหล่านั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุมตัวแสดงตำแหน่งส่วนหัว/ส่วนท้ายมาตรฐาน—วันที่และเวลา, หมายเลขสไลด์, และข้อความส่วนท้ายอย่างไร?**

ใช้ตัวจัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ปกติ, เค้าโครง, มาสเตอร์, บันทึก/เอกสารแจก) เพื่อเปิดหรือปิดตัวแสดงตำแหน่งเหล่านั้นและตั้งค่าข้อความของพวกมัน