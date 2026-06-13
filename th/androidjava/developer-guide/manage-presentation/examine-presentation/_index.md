---
title: ดึงและอัปเดตข้อมูลการนำเสนอบน Android
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/androidjava/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
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
- Android
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ความเข้าใจที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีการกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัตินั้นเมื่อจำเป็น

ตัวอย่างนี้อ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับการทำงานกับ metadata ของการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

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
// อื่นๆ 
```

คุณอาจต้องการดู [คุณสมบัติภายใต้คลาส DocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)

## **อัปเดตคุณสมบัติของการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่ให้คุณทำการเปลี่ยนแปลงคุณสมบัติของการนำเสนอ

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารแสดงด้านล่างนี้.

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติของเอกสารแสดงด้านล่างนี้.

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบว่าลิงก์ต่อไปนี้เป็นประโยชน์:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านอย่างเดียว) หรือไม่](https://docs.aspose.com/slides/th/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าตัวอักษรถูกฝังและมีตัวไหนบ้าง?**

ค้นหา [ข้อมูลตัวอักษรถูกฝัง](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ที่ระดับการนำเสนอ แล้วเปรียบเทียบรายการเหล่านั้นกับชุดของ [ตัวอักษรที่ใช้งานจริงในเนื้อหา](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getFonts--) เพื่อระบุว่าตัวอักษรใดเป็นสำคัญต่อการเรนเดอร์

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

วนรอบผ่าน [คอลเลคชันสไลด์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/) และตรวจสอบ [แฟล็กการมองเห็น](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#getHidden--) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่าใช้ขนาดและแนวทางสไลด์ที่กำหนดเองหรือไม่ และว่ามันต่างจากค่าเริ่มต้นหรือไม่?**

ได้. เปรียบเทียบ [ขนาดสไลด์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideSize--) และการวางแนวปัจจุบันกับค่าพรีเซ็ตมาตรฐาน เพื่อช่วยคาดการณ์พฤติกรรมในการพิมพ์และการส่งออก

**มีวิธีเร็ว ๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. ท่องทุก [กราฟ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/) ตรวจสอบ [แหล่งข้อมูล](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และบันทึกว่าข้อมูลเป็นภายในหรือแบบลิงก์ รวมถึงลิงก์ที่เสียหาย

**ฉันจะประเมินสไลด์ที่หนักซึ่งอาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและตรวจหาภาพขนาดใหญ่, ความโปร่งใส, เงา, แอนิเมชัน, และมัลติมีเดีย; แล้วกำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดบอดที่อาจส่งผลต่อประสิทธิภาพ