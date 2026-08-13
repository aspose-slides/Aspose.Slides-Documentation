---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอใน .NET
type: docs
weight: 130
url: /th/net/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides for .NET—อัตโนมัติการปรับเปลี่ยนเค้าโครงสไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

คำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for .NET คือวิธีการปรับขนาดรูปร่างเพื่อให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลไม่ถูกตัดออก บทความเชิงเทคนิคสั้นนี้แสดงวิธีทำ

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเบี่ยงเบนอเมื่อตัวขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและมิติของแต่ละรูปร่างให้สอดคล้องกับเค้าโครงสไลด์ใหม่

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// โหลดไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // ดึงขนาดสไลด์ต้นฉบับ.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // เปลี่ยนขนาดสไลด์โดยไม่ปรับสเกลรูปร่างที่มีอยู่.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // ดึงขนาดสไลด์ใหม่.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // ปรับขนาดและตำแหน่งของรูปร่างบนสไลด์ทุกสไลด์.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // ปรับสเกลขนาดรูปร่าง.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // ปรับสเกลตำแหน่งรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
หากสไลด์มีตาราง โค้ดข้างต้นจะทำงานไม่ถูกต้อง ในกรณีนั้นแต่ละเซลล์ในตารางจะต้องถูกปรับขนาด
{{% /alert %}}

ใช้โค้ดต่อไปนี้เพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตารางให้ปรับสเกลความสูงของแถวและความกว้างของคอลัมน์แต่ละอันแทนการปรับความกว้างและความสูงของรูปร่าง—การทำทั้งสองอย่างจะทำให้ตารางสเกลสองครั้งและทำให้เลื่อนออกจากสไลด์

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // ดึงขนาดสไลด์ดั้งเดิม.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // ดึงขนาดสไลด์ใหม่.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // ปรับสเกลขนาดรูปร่าง.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // ปรับสเกลตำแหน่งรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // ปรับสเกลขนาดรูปร่าง.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // ปรับสเกลตำแหน่งรูปร่าง.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // ปรับสเกลขนาดตารางผ่านแถวและคอลัมน์.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // ปรับสเกลขนาดรูปร่าง.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // ปรับสเกลตำแหน่งรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

### ทำไมหรือรูปร่างบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?
เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมเว้นแต่จะเปลี่ยนสเกลโดยเจตนา ซึ่งอาจทำให้เนื้อหาถูกตัดหรือรูปร่างบิดเบี้ยว

### โค้ดที่ให้มาทำงานได้กับรูปแบบรูปร่างทั้งหมดหรือไม่?
ตัวอย่างพื้นฐานทำงานได้กับรูปแบบรูปร่างส่วนใหญ่ (กล่องข้อความ, ภาพ, แผนภูมิ ฯลฯ) อย่างไรก็ตามสำหรับตารางคุณต้องจัดการแถวและคอลัมน์แยกกัน เนื่องจากความสูงและความกว้างของตารางกำหนดโดยมิติของเซลล์แต่ละเซลล์

### ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?
คุณต้องวนลูปผ่านแถวและคอลัมน์ทั้งหมดของตารางและปรับขนาดความสูงและความกว้างอย่างสัดส่วน ตามที่แสดงในตัวอย่างโค้ดที่สอง

### การปรับขนาดนี้ทำงานกับสไลด์แม่และสไลด์เค้าโครงได้หรือไม่?
ใช่ แต่คุณควรวนลูปผ่าน [Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) และ [LayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/layoutslides/) และใช้ตรรกะการปรับสเกลเดียวกันกับรูปร่างของพวกเขาเพื่อให้การนำเสนอสอดคล้องกันทั่วทั้งไฟล์

### ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?
ใช่ คุณสามารถตั้งค่า [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/orientation/) เพื่อเปลี่ยนทิศทาง อย่าลืมตั้งตรรกะการปรับสเกลให้สอดคล้องเพื่อคงเค้าโครง

### มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?
Aspose.Slides รองรับขนาดกำหนดเอง แต่ขนาดใหญ่มากอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

### ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?
คุณสามารถตรวจสอบคุณสมบัติ `AspectRatioLocked` ของรูปร่างก่อนทำการสเกล หากล็อคอยู่ ให้ปรับความกว้างหรือความสูงอย่างสัดส่วนแทนการสเกลแยกกัน