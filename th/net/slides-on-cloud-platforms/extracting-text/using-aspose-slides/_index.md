---
title: "วิธีดึงข้อความจาก PPT, PPTX, และ ODP ด้วย Aspose.Slides"
linktitle: สไลด์
type: docs
weight: 30
url: /th/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- แพลตฟอร์มคลาวด์
- การบูรณาการคลาวด์
- การดึงข้อความ
- ดึงข้อความ
- PPT
- PPTX
- ODP
- ไฟล์งานนำเสนอ
- ข้ามแพลตฟอร์ม
- อิสระจาก Office
- โน้ตและคอมเมนต์
- การทำดัชนีในองค์กร
- การเพิ่มคุณค่าข้อมูล
- .NET
- Aspose.Slides
description: "ดึงข้อความจากงานนำเสนอบนแพลตฟอร์มคลาวด์ยอดนิยมโดยใช้ Aspose.Slides API เพื่ออัตโนมัติการค้นหา การวิเคราะห์ และการส่งออกสำหรับ PPT, PPTX และ ODP."
---
## **บทนำ**

Aspose.Slides มี **API ที่ทรงพลังและระดับสูง** สำหรับการดึงข้อความจากไฟล์งานนำเสนอ รวมถึง **PPT, PPTX, และ ODP**. แตกต่างจาก Open XML SDK—ซึ่งรองรับเฉพาะ PPTX เท่านั้นและต้องการการแยกวิเคราะห์ XML ที่ซับซ้อน—Aspose.Slides ทำให้การดึงข้อความง่ายขึ้น ทำให้คุณสามารถมุ่งเน้นการรวมเนื้อหาที่ดึงออกมเข้าสู่กระบวนการทำงานของคุณได้.

## **การดึงข้อความอย่างรวดเร็วด้วย PresentationFactory.Instance.GetPresentationText**

เพื่อดึงข้อความจากงานนำเสนอ, **Aspose.Slides API** มีเมธอดแบบสแตติก `PresentationFactory.Instance.GetPresentationText`. เมธอดนี้มี overload หลายรูปแบบสำหรับทำงานกับไฟล์งานนำเสนอหรือสตรีมข้อมูล, สามารถดึงข้อความจาก **สไลด์, มาสเตอร์สไลด์, เลย์เอาต์, โน้ต, และคอมเมนต์**. ข้อความที่ดึงออกมาสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ `IPresentationText`.

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **โหมดการทำงานของ GetPresentationText**

เมธอด `GetPresentationText` ใน `PresentationFactory` ให้คุณปรับแต่งการดึงข้อความโดยใช้พารามิเตอร์ `TextExtractionArrangingMode` ซึ่งควบคุมวิธีการจัดเรียงข้อความในผลลัพธ์.

### **โหมดที่มีให้เลือก**

- **TextExtractionArrangingMode.Unarranged** – ดึงข้อความในรูปแบบอิสระโดยไม่คำนึงถึงโครงร่างสไลด์เดิม  
- **TextExtractionArrangingMode.Arranged** – รักษาลำดับของข้อความตามที่วางไว้บนแต่ละสไลด์  

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **ข้อได้เปรียบหลักของเมธอด PresentationFactory**

- **ไม่จำเป็นต้องโหลดงานนำเสนอทั้งหมด**: ลดการใช้หน่วยความจำและเพิ่มความเร็วในการประมวลผล  
- **ปรับให้เหมาะกับไฟล์ขนาดใหญ่**: จัดการกับงานนำเสนอขนาดใหญ่ได้อย่างมีประสิทธิภาพและดึงข้อความได้อย่างรวดเร็ว  
- **ดึงโน้ตและคอมเมนต์**: รวมถึงคำอธิบายของผู้ใช้เพื่อความครอบคลุมของเนื้อหา  
- **เหมาะสำหรับการทำดัชนีและการวิเคราะห์เนื้อหา**: เหมาะกับระบบองค์กรที่ต้องการการประมวลผลอัตโนมัติและการเพิ่มคุณค่าข้อมูล  
- **อิสระจาก Office**: ทำงานได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint, ให้เป็นโซลูชันที่ทำงานอิสระจริง ๆ  
- **รองรับหลายรูปแบบ**: ทำงานได้อย่างราบรื่นกับ **PPT, PPTX, และ ODP**.  
- **API ที่ยืดหยุ่นและทรงพลัง**: มีเมธอดหลากหลายสำหรับการดึงข้อความเชิงโครงสร้าง  
- **ครอบคลุมสไลด์ทั้งหมด**: ดึงข้อความจาก **เลย์เอาต์, มาสเตอร์สไลด์, สไลด์ทั่วไป, พื้นหลัง, โน้ตผู้พูด, และคอมเมนต์**.  
- **รองรับหลายแพลตฟอร์ม**: ทำงานบน **Windows, Linux, macOS** และในสภาพแวดล้อมคลาวด์  
- **ประสิทธิภาพสูงและปรับขยายได้**: เหมาะสำหรับ **แอปพลิเคชัน SaaS** และการปรับใช้ระดับองค์กรขนาดใหญ่  

## **ระบบปฏิบัติการที่รองรับ**

Aspose.Slides ทำงานบนระบบปฏิบัติการหลากหลาย:

- **Windows** (เช่น Windows 7, 8, 10, 11, และรุ่น Server)  
- **Linux** (หลายดิสโตริบิวชัน รวมถึง Ubuntu, Debian, Fedora, CentOS, ฯลฯ)  
- **macOS** (รวมถึงเวอร์ชันล่าสุดเช่น 10.15 Catalina และต่อไป)  

## **ภาษาโปรแกรมที่รองรับ**

Aspose.Slides ผสานงานกับหลายแพลตฟอร์มและภาษาต่าง ๆ:

- **C#** – รองรับเป็นหลักผ่าน Aspose.Slides for .NET.  
- **Java** – มี API ฟีเจอร์ครบถ้วนผ่าน Aspose.Slides for Java.  
- **C++** – ใช้ Aspose.Slides สำหรับแอปพลิเคชัน C++ ที่ต้องการประสิทธิภาพสูง.  
- **Python ผ่าน .NET** – นำฟังก์ชันของ Aspose.Slides มาใช้โดยผ่านความเข้ากันได้ของ .NET.  
- **ภาษาอื่นที่เข้ากันได้กับ .NET** – ใช้ไลบรารีในสภาพแวดล้อมใด ๆ ที่ .NET รองรับ.  

## **สรุป**

Aspose.Slides มอบ **การดึงข้อความอย่างครอบคลุม** สำหรับงานนำเสนอ PowerPoint และ OpenDocument, รองรับ **รูปแบบไฟล์ที่หลากหลาย, การจัดโครงสร้างข้อความที่เป็นมิตร, และการนำไปใช้ที่ง่าย** เมื่อเทียบกับ Open XML SDK. ตั้งแต่ **สไลด์และโน้ตจนถึงเนื้อหาเทมเพลต**, **Aspose.Slides** เป็นโซลูชันที่มีประสิทธิภาพสูงและฟีเจอร์ครบถ้วนสำหรับการดึงและจัดการข้อความในงานนำเสนอ.