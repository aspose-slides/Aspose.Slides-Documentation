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
- การทำงานอัตโนมัติของ Office
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และสร้างงานนำเสนอ PowerPoint (PPT, PPTX) ใหม่ใน C# ด้วยโค้ดที่สะอาดและเชื่อถือได้."
---
{{% alert color="info" %}} 

VSTO ถูกพัฒนาเพื่อให้ผู้พัฒนาสร้างแอปพลิเคชันที่สามารถทำงานภายใน Microsoft Office ได้ VSTO มีพื้นฐานเป็น COM แต่ถูกห่อหุ้มภายในวัตถุ .NET เพื่อให้สามารถใช้ในแอปพลิเคชัน .NET ได้ VSTO ต้องการการสนับสนุนจาก .NET framework รวมถึงรันไทม์ Microsoft Office ที่ใช้ CLR แม้ว่าจะสามารถใช้สร้าง Microsoft Office add‑ins ได้ แต่การใช้เป็นส่วนประกอบฝั่งเซิร์ฟเวอร์เป็นเรื่องแทบทำไม่ได้เช่นกัน อีกทั้งยังมีปัญหาเรื่องการปรับใช้ที่รุนแรง

Aspose.Slides for .NET เป็นคอมโปเนนท์ที่สามารถใช้จัดการงานนำเสนอ Microsoft PowerPoint ได้เช่นเดียวกับ VSTO แต่มีข้อได้เปรียบหลายประการ:

- Aspose.Slides มีโค้ดที่จัดการได้เท่านั้นและไม่จำเป็นต้องติดตั้งรันไทม์ Microsoft Office
- สามารถใช้เป็นคอมโปเนนท์ฝั่งไคลเอนต์หรือฝั่งเซิร์ฟเวอร์ได้
- การปรับใช้ทำได้ง่ายเนื่องจาก Aspose.Slides อยู่ใน DLL ไฟล์เดียว

{{% /alert %}} 
## **การสร้างงานนำเสนอ**
ด้านล่างเป็นตัวอย่างโค้ดสองตัวอย่างที่แสดงให้เห็นว่า VSTO และ Aspose.Slides for .NET สามารถใช้เพื่อบรรลุเป้าหมายเดียวกันได้ ตัวอย่างแรกคือ [VSTO](/slides/th/net/create-a-new-presentation/); [ตัวอย่างที่สอง](/slides/th/net/create-a-new-presentation/) ใช้ Aspose.Slides.
### **ตัวอย่าง VSTO**
**ผลลัพธ์จาก VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//หมายเหตุ: PowerPoint เป็นเนมสเปซที่ได้กำหนดไว้ข้างบนเช่นนี้
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
//สร้างงานนำเสนอ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **ตัวอย่าง Aspose.Slides for .NET**
**ผลลัพธ์จาก Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//สร้างงานนำเสนอ
Presentation pres = new Presentation();

//เพิ่มสไลด์หัวเรื่อง
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//ตั้งค่าข้อความหัวเรื่อง
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//ตั้งค่าข้อความหัวเรื่องย่อย
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//เขียนผลลัพธ์ไปยังดิสก์
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```