---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอใน .NET
type: docs
weight: 130
url: /th/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /th/net/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายด้วย Aspose.Slides สำหรับ .NET—อัตโนมัติการปรับแต่งเลย์เอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของการนำเสนอ คุณอาจต้องปรับขนาดและย้ายตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีการปรับขนาดรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลย์เอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม ใช้อัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของมัน

ตัวอย่างแรกโหลดการนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ตัวอย่างใช้ [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) กับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) เพื่อให้ลูปถัดไปควบคุมการปรับสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนแปลงมิติของรูปร่างจะไม่ปรับสเกลขนาดฟอนต์

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// คำนวณอัตราส่วนการสเกลแนวนอนและแนวตั้งแบบอิสระ.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```
{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงโดยรวมของตาราง ความสูงของแถวอาจใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่มากกว่า
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลย์เอาต์รวมถึงสไลด์แต่ละสไลด์ก่อนบันทึกการนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) โดยการปรับสเกล [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) และ [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) จากนั้นปรับสเกลตำแหน่งของตารางโดยไม่ปรับสเกลมิติรวมของตารางแยกต่างหาก

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// คำนวณอัตราส่วนการสเกลแนวนอนและแนวตั้งแบบอิสระ.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลย์เอาต์รวมถึงสไลด์แต่ละสไลด์.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```
## **คำถามที่พบบ่อย**

**ทำไมหรือรูปร่างจึงบิดเบี้ยวหรือถูกตัดหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่ปรับสเกลรูปร่าง พวกมันจะรักษาตำแหน่งและมิติเดิมและอาจเกินขอบสไลด์ การปรับสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้

**โค้ดที่ให้มาทำงานได้กับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลย์เอาต์ที่ได้โดยเฉพาะข้อความและตาราง เพราะตัวอย่างเหล่านี้ไม่ได้ปรับสเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

ปรับสเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงต่ำสุดของแถวด้วยอัตราส่วนความสูง จากนั้นปรับสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลย์เอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองเรียกวนผ่าน [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) และ [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) ของแต่ละมาสเตอร์ และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**ฉันสามารถเปลี่ยนแนวตั้ง/แนวนอนของสไลด์พร้อมกับการปรับขนาดได้หรือไม่?**

ได้ ใช้การตั้งค่า [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าสเกลสะท้อนถึงแนวสุดท้าย

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุมิติสไลด์แบบกำหนดเองได้ด้วย [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). มิติที่รองรับยังขึ้นอยู่กับรูปแบบการนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ค่าสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลย์เอาต์เดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่ารหว่างอัตราส่วนความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้รักษาสัดส่วนไว้แต่บางครั้งอาจเหลือพื้นที่ว่างที่ขอบหนึ่ง