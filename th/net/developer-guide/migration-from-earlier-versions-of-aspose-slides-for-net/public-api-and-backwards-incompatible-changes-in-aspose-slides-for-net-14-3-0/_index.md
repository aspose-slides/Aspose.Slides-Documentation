---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.3.0
linktitle: Aspose.Slides สำหรับ .NET 14.3.0
type: docs
weight: 50
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- การย้ายข้อมูล
- โค้ดแบบดั้งเดิม
- โค้ดสมัยใหม่
- วิธีการแบบดั้งเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides สำหรับ .NET เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
## **API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลัง**
### **เพิ่มการอธิบายค่า Enumeration Aspose.Slides.ShapeThumbnailBounds และเมธอด Aspose.Slides.IShape.GetThumbnail()**
เมธอด GetThumbnail() และ GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) ใช้เพื่อสร้างภาพย่อของรูปร่างแยกต่างหาก. Enumeration ShapeThumbnailBounds กำหนดประเภทขอบเขตของภาพย่อรูปร่างที่เป็นไปได้.
### **เพิ่มคุณสมบัติ UniqueId ให้กับ Aspose.Slides.IShape**
คุณสมบัติ Aspose.Slides.IShape.UniqueId จะคืนค่าตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับการนำเสนอ. ตัวระบุเอกลักษณ์เหล่านี้จะถูกจัดเก็บในแท็กที่กำหนดเองของรูปร่าง.
### **ลายเซ็นของเมธอด SetGroupingItem ถูกเปลี่ยนแปลงใน IChartCategoryLevelsManager**
ลายเซ็นของเมธอด IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

```

ตอนนี้ล้าสมัยและถูกแทนที่ด้วยลายเซ็น

``` csharp

 void SetGroupingItem(int level, object value);

```

การเรียกใช้งานเช่น

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

```

ต้องเปลี่ยนเป็นการเรียกแบบ

``` csharp

 .SetGroupingItem(1, "Group 1");

```

ส่งค่าเช่น "Group 1" ไปยัง SetGroupingItem แต่ไม่ใช่ค่าชนิด IChartDataCell. การสร้าง IChartDataCell ด้วย worksheet แถวและคอลัมน์ที่กำหนดสำหรับระดับประเภทต้องตอบสนองความต้องการบางประการและได้ถูกบรรจุในเมธอด SetGroupingItem(int, object).
### **เพิ่มคุณสมบัติ SlideId ให้กับอินเทอร์เฟซ Aspose.Slides.IBaseSlide**
คุณสมบัติ SlideId จะคืนค่าตัวระบุสไลด์ที่เป็นเอกลักษณ์.
### **เพิ่มคุณสมบัติ SoundName ให้กับ ISlideShowTransition**
เป็นสตริงที่อ่านและเขียนได้. ระบุชื่อที่มนุษย์อ่านได้สำหรับเสียงของการเปลี่ยนสไลด์. ต้องกำหนดค่าให้กับคุณสมบัติ Sound เพื่อรับหรือกำหนดชื่อเสียง. ชื่อนี้จะแสดงในส่วนติดต่อผู้ใช้ของ PowerPoint เมื่อกำหนดค่าเสียงการเปลี่ยนสไลด์ด้วยตนเอง. อาจจะทำให้เกิด PptxException หากไม่ได้กำหนดคุณสมบัติ Sound.
### **ประเภทของคุณสมบัติ ChartSeriesGroup.Type ได้รับการเปลี่ยนแปลง**
คุณสมบัติ ChartSeriesGroup.Type ได้ถูกเปลี่ยนจาก enumeration ChartType ไปเป็น enumeration ใหม่ CombinableSeriesTypesGroup. enum CombinableSeriesTypesGroup แสดงกลุ่มของประเภทซีรีส์ที่สามารถรวมกันได้.
### **เพิ่มการสนับสนุนการสร้างภาพย่อของรูปร่างแต่ละอัน**
Aspose.Slides.ShapeThumbnailBounds

สมาชิกใหม่ใน Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)