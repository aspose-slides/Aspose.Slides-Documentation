---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน Java
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น.

ตัวอย่างนี้อ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับทำงานกับเมทาดาต้าการนำเสนอ.

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดการนำเสนอได้ ดูตัวอย่างโค้ด Java นี้:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **รับคุณสมบัติของการนำเสนอ**

โค้ด Java นี้แสดงวิธีการรับคุณสมบัติของการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

คุณอาจต้องการดู [คุณสมบัติภายใต้ DocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#DocumentProperties--) class.

## **อัปเดตคุณสมบัติของการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่ให้คุณทำการเปลี่ยนแปลงคุณสมบัติของการนำเสนอได้

สมมติว่าเรามีการนำเสนอ PowerPoint โดยมีคุณสมบัติของเอกสารแสดงต่อไปนี้

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีการแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติของเอกสารแสดงต่อไปนี้

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบว่าลิงก์ต่อไปนี้เป็นประโยชน์:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านอย่างเดียว) หรือไม่](https://docs.aspose.com/slides/th/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **คำถามที่พบบ่อย**

**วิธีตรวจสอบว่าฟอนต์ถูกฝังหรือไม่และฟอนต์ใดบ้าง?**

ค้นหา [embedded-font information](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ในระดับการนำเสนอ จากนั้นเปรียบเทียบรายการนั้นกับชุดของ [fonts actually used across content](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getFonts--) เพื่อระบุฟอนต์ที่สำคัญต่อการเรนเดอร์

**วิธีตรวจสอบอย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าใด?**

วนผ่าน [slide collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) แล้วตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getHidden--) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์ที่กำหนดเองหรือไม่ และว่ามีความแตกต่างจากค่าเริ่มต้นหรือไม่?**

ใช่. เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideSize--) ปัจจุบันและการวางแนวกับชุดค่ามาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมในการพิมพ์และส่งออก

**มีวิธีรวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่. ตรวจสอบ [charts](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/) ทั้งหมด, ตรวจสอบ [data source](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) ของพวกมัน, และบันทึกว่าข้อมูลเป็นภายในหรือเป็นลิงก์, รวมถึงลิงก์ที่เสียหาย

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและมองหารูปภาพขนาดใหญ่, ความโปร่งใส, เงา, การเคลื่อนไหว, และสื่อมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจมีประสิทธิภาพต่ำ