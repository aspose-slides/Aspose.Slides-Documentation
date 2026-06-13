---
title: สร้างงานนำเสนอใหม่โดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: สร้างงานนำเสนอใหม่
type: docs
weight: 10
url: /th/net/create-a-new-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- การย้าย
- VSTO
- การทำอัตโนมัติของ Office
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และสร้างงานนำเสนอ PowerPoint (PPT, PPTX) ใหม่ใน C# ด้วยโค้ดที่สะอาดและเชื่อถือได้."
---
{{% alert color="primary" %}} 

VSTO ถูกพัฒนาขึ้นเพื่อให้ผู้พัฒนาสามารถสร้างแอปพลิเคชันที่ทำงานภายใน Microsoft Office VSTO เป็นแบบ COM แต่ถูกห่อหุ้มอยู่ในอ็อบเจ็กต์ .NET เพื่อให้สามารถใช้ในแอปพลิเคชัน .NET VSTO ต้องการการสนับสนุน .NET framework รวมถึง Microsoft Office runtime ที่ใช้ CLR แม้ว่าจะสามารถใช้สร้าง Microsoft Office add‑ins ได้ แต่ก็แทบจะเป็นไปไม่ได้ที่จะใช้เป็นคอมโพเนนต์ด้านเซิร์ฟเวอร์ นอกจากนี้ยังมีปัญหาการปรับใช้ที่สำคัญ

Aspose.Slides for .NET เป็นคอมโพเนนต์ที่สามารถใช้งานเพื่อจัดการไฟล์ Microsoft PowerPoint เช่นเดียวกับ VSTO แต่มีข้อได้เปรียตหลายประการ:

- Aspose.Slides มีเฉพาะโค้ดที่จัดการ (managed code) เท่านั้นและไม่ต้องการให้ติดตั้ง Microsoft Office runtime
- สามารถใช้เป็นคอมโพเนนต์ด้านไคลเอนต์หรือด้านเซิร์ฟเวอร์ได้
- การปรับใช้ทำได้ง่ายเนื่องจาก Aspose.Slides อยู่ในไฟล์ DLL เพียงไฟล์เดียว

{{% /alert %}} 
## **สร้างงานนำเสนอ**
ด้านล่างเป็นตัวอย่างโค้ดสองตัวอย่างที่แสดงให้เห็นว่า VSTO และ Aspose.Slides for .NET สามารถใช้เพื่อบรรลุเป้าหมายเดียวกันได้ ตัวอย่างแรกคือ[VSTO](/slides/th/net/create-a-new-presentation/); ตัวอย่างที่สอง[ตัวอย่างที่สอง](/slides/th/net/create-a-new-presentation/) ใช้ Aspose.Slides.
### **ตัวอย่าง VSTO**
**ผลลัพธ์ของ VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//หมายเหตุ: PowerPoint เป็นเนมสเปซซึ่งได้ถูกกำหนดข้างต้นดังนี้
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//สร้างงานนำเสนอ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//ดึงเลย์เอาต์สไลด์หัวเรื่อง
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//เพิ่มสไลด์หัวเรื่อง
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//ตั้งค่าข้อความหัวเรื่อง
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//ตั้งค่าข้อความหัวข้อย่อย
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//เขียนผลลัพธ์ไปยังดิสก์
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **ตัวอย่าง Aspose.Slides for .NET**
**ผลลัพธ์จาก Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//สร้างงานนำเสนอ
Presentation pres = new Presentation();

//เพิ่มสไลด์หัวเรื่อง
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//ตั้งค่าข้อความหัวเรื่อง
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//ตั้งค่าขข้อความหัวข้อย่อย
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//เขียนผลลัพธ์ไปยังดิสก์
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```