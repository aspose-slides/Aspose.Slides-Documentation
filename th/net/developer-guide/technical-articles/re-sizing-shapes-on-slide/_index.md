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
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET—ทำให้การปรับแต่งเค้าโครงสไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for .NET คือวิธีการปรับขนาดรูปร่างให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลจะไม่ถูกตัดออก บทความเทคนิคสั้นนี้จะแสดงวิธีทำเช่นนั้น

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเบี่ยงเบนเมื่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและขนาดของแต่ละรูปร่างให้สอดคล้องกับเค้าโครงสไลด์ใหม่

```c#
// โหลดไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // รับขนาดสไลด์เดิม.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // รับขนาดสไลด์ใหม่.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // ปรับขนาดและตำแหน่งรูปร่างบนสไลด์ทุกหน้า.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // สเกลขนาดของรูปร่าง.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // สเกลตำแหน่งของรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
หากสไลด์มีตาราง โค้ดด้านบนจะทำงานไม่ถูกต้อง ในกรณีนั้นต้องปรับขนาดแต่ละเซลล์ในตาราง
{{% /alert %}}

ใช้โค้ดต่อไปนี้เพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตาราง การกำหนดความกว้างหรือความสูงเป็นกรณีพิเศษ: คุณต้องปรับความสูงของแถวและความกว้างของคอลัมน์แต่ละอันเพื่อเปลี่ยนขนาดโดยรวมของตาราง

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // รับขนาดสไลด์เดิม.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // รับขนาดสไลด์ใหม่.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // สเกลขนาดของรูปร่าง.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // สเกลตำแหน่งของรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // สเกลขนาดของรูปร่าง.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // สเกลตำแหน่งของรูปร่าง.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // สเกลขนาดของรูปร่าง.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // สเกลตำแหน่งของรูปร่าง.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ทำไโมชั่นรูปร่างบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมไว้ หากไม่เปลี่ยนสเกลโดยเจตนา สิ่งนี้อาจทำให้เนื้อหาถูกตัดหรือรูปร่างเบี่ยงเบน

**โค้ดที่ให้มาทำงานกับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างพื้นฐานทำงานกับรูปร่างส่วนใหญ่ (ข้อความ, รูปภาพ, แผนภูมิ ฯลฯ) อย่างไรก็ตามสำหรับตารางคุณต้องจัดการแถวและคอลัมน์แยกกัน เนื่องจากความสูงและความกว้างของตารางกำหนดโดยขนาดของเซลล์แต่ละอัน

**จะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

คุณต้องวนลูปผ่านทุกแถวและคอลัมน์ของตารางและปรับความสูงและความกว้างของพวกมันโดยสัดส่วน ตามที่แสดงในตัวอย่างโค้ดที่สอง

**การปรับขนาดนี้ทำงานกับสไลด์แม่แบบและสไลด์เค้าโครงหรือไม่?**

ใช่ แต่คุณควรวนลูปผ่าน[แม่แบบ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/)และ[สไลด์เค้าโครง](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/layoutslides/)และใช้ตรรกะสเกลเดียวกันกับรูปร่างของพวกมันเพื่อให้การนำเสนอทั้งหมดสอดคล้องกัน

**ฉันสามารถเปลี่ยนการวางแนวของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ทำได้ คุณสามารถตั้งค่า[presentation.SlideSize.Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/orientation/)เพื่อเปลี่ยนการวางแนว ตรวจสอบให้แน่ใจว่าตั้งตรรกะสเกลให้สอดคล้องเพื่อรักษาเค้าโครง

**มีขีดจำกัดขนาดสไลด์ที่ฉันตั้งค่าได้หรือไม่?**

Aspose.Slides รองรับขนาดที่กำหนดเอง แต่ขนาดที่ใหญ่เกินไปอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

**ฉันจะป้องกันไม่ให้รูปร่างที่ล็อกอัตราส่วนถูกบิดเบี้ยวได้อย่างไร?**

คุณสามารถตรวจสอบคุณสมบัติ`AspectRatioLocked`ของรูปร่างก่อนทำการสเกล หากถูกล็อก ให้ปรับความกว้างหรือความสูงโดยสัดส่วนแทนการสเกลแยกกัน