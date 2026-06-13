---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ .NET
linktitle: การทำงานหลายเธรด
type: docs
weight: 310
url: /th/net/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "การทำงานหลายเธรดใน Aspose.Slides สำหรับ .NET ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับกระบวนการทำงานการนำเสนอที่มีประสิทธิภาพ"
---
## **บทนำ**

แม้ว่าการทำงานแบบขนานกับการนำเสนอจะเป็นไปได้ (นอกเหนือจากการแยกวิเคราะห์/โหลด/สำเนา) และส่วนใหญ่จะทำงานได้อย่างราบรื่น (ส่วนใหญ่), ก็มีโอกาสเล็กน้อยที่คุณอาจได้รับผลลัพธ์ที่ไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรด  

เราขอแนะนำอย่างยิ่งว่า **ไม่** ควรใช้ตัวอย่าง [การนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพียงหนึ่งตัวในสภาพแวดล้อมที่ใช้หลายเธรด เพราะอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่ไม่สามารถคาดการณ์ได้และตรวจจับยาก  

ไม่ปลอดภัยที่จะโหลด, บันทึก, และ/หรือสำเนาตัวอย่างของคลาส [การนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ในหลายเธรด การดำเนินการดังกล่าว **ไม่** ได้รับการสนับสนุน หากคุณต้องการทำงานเหล่านี้ คุณต้องทำงานแบบขนานโดยใช้หลายกระบวนการแบบ single‑threaded และแต่ละกระบวนการควรใช้ตัวอย่างการนำเสนอของตนเอง  

## **แปลงสไลด์การนำเสนอเป็นภาพแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากการนำเสนอ PowerPoint เป็นภาพ PNG แบบขนาน เนื่องจากไม่ปลอดภัยที่จะใช้ `Presentation` ตัวเดียวในหลายเธรด เราจึงแบ่งสไลด์การนำเสนอออกเป็นการนำเสนอหลายตัวและแปลงสไลด์เป็นภาพแบบขนานโดยใช้การนำเสนอแต่ละตัวในเธรดแยกกัน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น  

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // แยกสไลด์ i ไปยังการนำเสนอแยกส่วน.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // แปลงสไลด์เป็นภาพในงานที่ดำเนินการแยกกัน.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **คำถามที่พบบ่อย**

**ฉันต้องเรียกการตั้งค่าลิขสิทธิ์ในทุกเธรดหรือไม่?**  

ไม่จำเป็น เพียงทำครั้งเดียวต่อกระบวนการ/โดเมนแอปก่อนที่เธรดจะเริ่มทำงาน หาก [การตั้งค่าลิขสิทธิ์](/slides/th/net/licensing/) อาจถูกเรียกพร้อมกัน (เช่น ระหว่างการเริ่มต้นแบบ lazy) ให้ทำการซิงโครไนซ์การเรียกนั้น เนื่องจากเมธอดการตั้งค่าลิขสิทธิ์เองไม่ปลอดภัยต่อเธรด  

**ฉันสามารถส่งผ่านวัตถุ `Presentation` หรือ `Slide` ระหว่างเธรดได้หรือไม่?**  

การส่งผ่านวัตถุการนำเสนอที่ยังใช้งานอยู่ระหว่างเธรดไม่แนะนำ: ให้ใช้ตัวอย่างอิสระต่อเธรดหรือสร้างการนำเสนอ/คอนเทนเนอร์สไลด์แยกล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปที่ไม่ควรแชร์ตัวอย่างการนำเสนอเดียวกันระหว่างเธรด  

**การทำส่งออกเป็นรูปแบบต่าง ๆ (PDF, HTML, ภาพ) แบบขนานปลอดภัยหรือไม่ หากแต่ละเธรดมี `Presentation` ของตนเอง?**  

ใช่ เมื่อใช้ตัวอย่างแยกกันและเส้นทางเอาต์พุตแยกกัน งานเหล่านี้มักทำงานแบบขนานได้อย่างถูกต้อง; ควรหลีกเลี่ยงการแชร์วัตถุกาานนำเสนอและสตรีม I/O ร่วม  

**ควรทำอย่างไรกับการตั้งค่าฟอนต์ระดับโลก (โฟลเดอร์, การทดแทน) ในการทำงานหลายเธรด?**  

ให้กำหนดค่าฟอนต์ระดับโลกทั้งหมดก่อนเริ่มเธรดและไม่เปลี่ยนแปลงระหว่างการทำงานขนาน วิธีนี้จะขจัดปัญหาการแข่งขันเมื่อเข้าถึงทรัพยากรฟอนต์ที่ใช้ร่วมกัน  