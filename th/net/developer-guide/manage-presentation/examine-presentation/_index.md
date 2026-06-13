---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน .NET
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/net/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- ดึงคุณสมบัติ
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
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย .NET เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides. มันอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น.

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/) และแสดงการทำงานทั่วไปสำหรับการทำงานกับข้อมูลเมตาของการนำเสนอ.

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการค้นหารูปแบบ (PPT, PPTX, ODP และอื่น ๆ) ที่การนำเสนออยู่ในขณะนั้น.

คุณสามารถตรวจสอบรูปแบบของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอ ดูโค้ด C# นี้:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด C# นี้แสดงวิธีรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

คุณอาจต้องการดูคุณสมบัติภายใต้คลาส [คุณสมบัติภายใต้ DocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/documentproperties/#properties).

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) ที่ให้คุณเปลี่ยนแปลงคุณสมบัติของการนำเสนอ.

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติเอกสารแสดงด้านล่างนี้.

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเอกสารแสดงด้านล่าง.

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบว่าลิงก์เหล่านี้มีประโยชน์:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอได้รับการป้องกันการเขียน (อ่านอย่างเดียว)](https://docs.aspose.com/slides/th/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังและเป็นฟอนต์ใดบ้าง?**

ค้นหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) ในระดับการนำเสนอ จากนั้นเปรียบเทียบรายการนั้นกับชุดของ [fonts actually used across content](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getfonts/) เพื่อระบุฟอนต์ที่สำคัญต่อการแสดงผล.

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

วนรอบผ่าน [slide collection](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) ของแต่ละสไลด์.

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวทางสไลด์ที่กำหนดเอง และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้. เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/) และแนวทางปัจจุบันกับค่ามาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก.

**มีวิธีเร็ว ๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. ตรวจสอบทุก [charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) ของพวกมันและบันทึกว่าข้อมูลเป็นภายในหรือเป็นลิงก์ รวมถึงลิงก์ที่เสียหาย.

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและค้นหาภาพขนาดใหญ่, ความโปร่งใส, เงา, แอนิเมชัน, และสื่อมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจทำให้ประสิทธิภาพต่ำ.