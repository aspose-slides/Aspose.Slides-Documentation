---
title: "วิธีสกัดข้อความจากไฟล์ PPT, PPTX, และ ODP ด้วย Open XML SDK ใน .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /th/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- แพลตฟอร์มคลาวด์
- การบูรณาการคลาวด์
- Open XML SDK
- การสกัดข้อความ PPTX
- การประมวลผลสไลด์ .NET
- การสกัดข้อความงานนำเสนอ
- สไลด์มาสเตอร์
- บันทึกผู้พูด
- การสกัดข้อความจากสไลด์
- C#
description: "เรียนรู้วิธีสกัดข้อความจากไฟล์ PPT, PPTX และ ODP ใน .NET ด้วย Open XML SDK โดยใช้การเข้าถึงแบบ XML, เคล็ดลับด้านประสิทธิภาพ, และวิธีแก้ปัญหาการแปลงสำหรับแอปคลาวด์."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการสกัดข้อความจากไฟล์งานนำเสนอโดยใช้ Open XML SDK บน .NET มุ่งเน้นที่การเข้าถึง XML โดยตรงสำหรับไฟล์ PPTX ซึ่งข้อความสามารถดึงจากองค์ประกอบสไลด์ที่มีโครงสร้างได้โดยไม่ต้องเรนเดอร์สไลด์หรือใช้ Microsoft PowerPoint บทความยังอธิบายประโยชน์ด้านประสิทธิภาพเช่นการประมวลผลที่เร็วขึ้นและการใช้หน่วยความจำน้อยลง  

สำหรับไฟล์ PPT และ ODP บทความอธิบายว่าข้อความไม่สามารถสกัดออกได้โดยตรงด้วย Open XML SDK แทนที่นั้น รูปแบบเหล่านี้จำเป็นต้องแปลงเป็น PPTX ก่อน แล้วจึงสกัดข้อความจากไฟล์ที่ได้  

## **Open XML SDK**

**Open XML SDK** ให้วิธีการที่มีโครงสร้างสูงและมีประสิทธิภาพในการสกัดข้อความจากไฟล์งานนำเสนอ—โดยเฉพาะ **PPTX** ที่สอดคล้องกับมาตรฐาน Open XML การให้การเข้าถึง XML พื้นฐานโดยตรงทำให้ SDK นี้สามารถจัดการเนื้อหาสไลด์ได้เร็วและยืดหยุ่นมากขึ้นเมื่อเทียบกับวิธีการแบบดั้งเดิม  

## **การเข้าถึง XML โดยตรง**

- **วิเคราะห์ข้อความโดยตรง**: Open XML SDK ช่วยให้คุณสกัดข้อความจากส่วน XML โดยไม่ต้องเรนเดอร์สไลด์  
- **องค์ประกอบที่มีโครงสร้าง**: เนื่องจากข้อความถูกเก็บในแท็ก XML ที่กำหนดอย่างชัดเจน ทำให้การดึงและประมวลผลง่ายขึ้น  

### **ตัวอย่าง: การสกัดข้อความโดยตรงจากเนื้อหา XML ของสไลด์**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **ข้อได้เปรียบด้านประสิทธิภาพ**

- **การสกัดที่เร็วขึ้น**: ข้ามขั้นตอนการเปิด PowerPoint หรือ API ระดับสูงอื่น ๆ  
- **การใช้หน่วยความจำน้อยลง**: เข้าถึงส่วน XML ที่เกี่ยวข้องเท่านั้น ลดการใช้ทรัพยากร  
- **ไม่ต้องใช้ Microsoft PowerPoint**: ปล่อยคุณจากความต้องการติดตั้งเพิ่มเติม  

### **ตัวอย่าง: การสกัดข้อความอย่างมีประสิทธิภาพโดยไม่ต้องโหลดงานนำเสนอทั้งหมด**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **การระบุองค์ประกอบข้อความ**

### **รายละเอียดของการสกัดข้อความจากงานนำเสนอ**

เมื่อสกัดข้อความจากงานนำเสนอ ให้พิจารณาปัจจัยต่อไปนี้:

- **ข้อความอาจอยู่ในส่วนต่าง ๆ**: สไลด์ทั่วไป, สไลด์มาสเตอร์, เลเอาต์, หรือบันทึกผู้พูด  
- **ตัวแสดงตำแหน่งเริ่มต้น**: สไลด์มาสเตอร์และเลเอาต์อาจมีตัวแสดงตำแหน่ง (เช่น “Click to edit Master title style”) ที่ไม่ได้เป็นเนื้อหาจริงของงานนำเสนอ  
- **การกรองข้อความว่างหรือซ่อน**: บางองค์ประกอบอาจว่างเปล่าหรือไม่ได้ตั้งใจให้แสดง  

### **แท็กที่บรรจุข้อความ**

ในไฟล์ **PPTX** ข้อความมักถูกเก็บใน:

- `<a:t>` องค์ประกอบภายใน `<a:p>` (ย่อหน้า)  
- `<a:r>` องค์ประกอบ (ส่วนของข้อความภายในย่อหน้า)  

### **ตัวอย่าง: การสกัดองค์ประกอบข้อความทั้งหมดจากสไลด์**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP และ PPT**

### **ความไม่สามารถสกัดข้อความโดยตรง**

- ไม่เหมือน **PPTX**، **PPT** (รูปแบบไบนารี) และ **ODP** (OpenDocument Presentation) **ไม่ได้รับการสนับสนุน** โดย Open XML SDK  
- **PPT** เก็บเนื้อหาในรูปแบบไบนารีที่ปิด ทำให้การสกัดข้อความซับซ้อน  
- **ODP** พึ่งพา **OpenDocument XML** ซึ่งมีโครงสร้างที่แตกต่างจาก PPTX  

### **วิธีแก้: การแปลงเป็น PPTX**

เพื่อสกัดข้อความจาก **PPT** หรือ **ODP** วิธีที่แนะนำคือ:

1. **แปลง PPT → PPTX** ด้วย PowerPoint หรือเครื่องมือของบุคคลที่สาม  
2. **แปลง ODP → PPTX** ผ่าน LibreOffice หรือ PowerPoint  
3. **สกัดข้อความ** จาก PPTX ใหม่โดยใช้ Open XML SDK  

### **ตัวอย่าง: การแปลง ODP ไปเป็น PPTX ผ่านบรรทัดคำสั่ง LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **แพลตฟอร์มและเฟรมเวิร์กที่รองรับ**

- **Windows**: .NET Framework 4.6.1 ขึ้นไป, .NET Core 2.1+, .NET 5/6/7.  
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.  
- **สภาพแวดล้อมคลาวด์**: Microsoft Azure Functions, AWS Lambda (.NET Core), คอนเทนเนอร์ Docker  
- **ความเข้ากันได้กับแอปพลิเคชัน Office**: ไม่ต้องติดตั้ง Microsoft Office  
- **ภาษาการเขียนโปรแกรมที่รองรับ**: Open XML SDK สามารถใช้กับ **C#**, **VB.NET**, **F#** และภาษาอื่นที่สนับสนุนโดย .NET  

## **สรุป**

การใช้ **Open XML SDK** สำหรับ **การสกัดข้อความจาก PPTX** ให้ประสิทธิภาพและความชัดเจน ในขณะที่ **PPT และ ODP** ต้องผ่านขั้นตอนการแปลงเริ่มต้นเพื่อการประมวลผลที่ราบรื่น การนำวิธีนี้ไปใช้รับประกัน **ประสิทธิภาพสูง**, **ความยืดหยุ่น**, และ **ความเข้ากันได้กว้างขวาง** กับแอปพลิเคชัน .NET สมัยใหม่