---
title: ดึงข้อมูลและอัปเดตข้อมูลการนำเสนอใน .NET
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/net/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติของเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย .NET เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม อ่านคุณสมบัติของเอกสาร และอัปเดตคุณสมบัตินั้นเมื่อจำเป็น

ตัวอย่างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/) เพื่อสาธิตการดำเนินการทั่วไปในการทำงานกับเมตาดาต้าการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP หรือรูปแบบอื่น) ขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดการนำเสนอได้ ดูโค้ด C# นี้:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด C# นี้แสดงวิธีการรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

คุณอาจต้องการดู [คุณสมบัติต่างๆ ภายใต้ DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/#properties) ของคลาส

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) ที่ให้คุณเปลี่ยนแปลงคุณสมบัติการนำเสนอ

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนคุณสมบัติเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและแอตทริบิวต์ความปลอดภัย คุณอาจพบลิงก์ต่อไปนี้เป็นประโยชน์:

- [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/)
- [การป้องกันการเขียนของการนำเสนอ](/slides/th/net/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรฝังอยู่หรือไม่และเป็นแบบอักษรใด?**

ค้นหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) ระดับการนำเสนอ จากนั้นเปรียบเทียบรายการเหล่านั้นกับชุด [fonts actually used across content](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getfonts/) เพื่อระบุว่าแบบอักษรใดสำคัญต่อการเรนเดอร์

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

วนซ้ำผ่าน [slide collection](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่าขนาดและแนวตั้งของสไลด์ที่กำหนดเองถูกใช้และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้. เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/) และการวางแนวกับค่าเริ่มต้นมาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีเร็วๆ ที่จะตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. เดินทางผ่าน [charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) ของแต่ละกราฟ และบันทึกรูปแบบข้อมูลว่าเป็นข้อมูลภายในหรือแบบลิงก์ รวมถึงลิงก์ที่เสียหาย

**ฉันจะประเมินสไลด์ที่ 'หนัก' ซึ่งอาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงอย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนอ็อบเจกต์และมองหาภาพขนาดใหญ่, ความโปร่งแสง, เงา, แอนิเมชัน, และสื่อมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจทำให้ประสิทธิภาพต่ำ