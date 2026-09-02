---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน Java
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาทาในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วขึ้นและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการตรวจสอบข้อมูลเมตาดาทาของงานนำเสนอใน Aspose.Slides อธิบายวิธีการกำหนดรูปแบบปัจจุบันของงานนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/) โดยแสดงการทำงานทั่วไปสำหรับการจัดการเมตาดาทาของงานนำเสนอ

## **ตรวจสอบรูปแบบของงานนำเสนอ**

ก่อนทำงานกับงานนำเสนอ คุณอาจต้องการทราบว่ารูปแบบ (PPT, PPTX, ODP หรืออื่น ๆ) ของงานนำเสนอในขณะนี้คืออะไร

คุณสามารถตรวจสอบรูปแบบของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอ ดูตัวอย่างโค้ด Java นี้:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **ดึงคุณสมบัติงานนำเสนอ**

โค้ด Java นี้แสดงวิธีการดึงคุณสมบัติงานนำเสนอ (ข้อมูลเกี่ยวกับงานนำเสนอ):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

คุณอาจต้องการดู [properties ภายใต้คลาส DocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/documentproperties/#DocumentProperties--) 

## **อัปเดตคุณสมบัติงานนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่อนุญาตให้คุณเปลี่ยนแปลงคุณสมบัติงานนำเสนอ

สมมติว่าเรามีงานนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารดังแสดงด้านล่าง

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีการแก้ไขคุณสมบัติงานนำเสนอบางส่วน:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติของเอกสารถูกแสดงด้านล่าง

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับงานนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบลิงก์เหล่านี้เป็นประโยชน์

- [Password-Protect Presentations](/slides/th/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/th/java/write-protected-presentation/)

## **FAQ**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังไว้หรือไม่และเป็นแบบใด?**

มองหา [ข้อมูลแบบอักษรที่ฝังไว้](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ระดับงานนำเสนอ แล้วเปรียบเทียบรายการเหล่านั้นกับชุดของ [แบบอักษรที่ใช้จริงในเนื้อหา](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getFonts--) เพื่อระบุว่าแบบอักษรใดสำคัญต่อการเรนเดอร์

**ฉันจะตรวจสอบอย่างรวดเร็วได้หรือไม่ว่าไฟล์มีสไลด์ที่ซ่อนอยู่และจำนวนเท่าไร?**

วนลูปผ่าน [slide collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getHidden--) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวการจัดวางสไลด์แบบกำหนดเองและแตกต่างจากค่าปริยายหรือไม่?**

ได้ การเปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideSize--) ปัจจุบันและแนวการจัดวางกับค่ามาตรฐานช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีที่เร็วในการดูว่ากราฟอ้างอิงข้อมูลจากแหล่งภายนอกหรือไม่?**

มี ให้ท่องทั้งหมด [charts](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) ของแต่ละกราฟ แล้วบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยงจากภายนอก รวมถึงลิงก์ที่เสียหาย

**ฉันจะประเมินสไลด์ที่ 'หนัก' ซึ่งอาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ นับจำนวนวัตถุและมองหาภาพขนาดใหญ่, ความโปร่งใส, เงา, 애니เมชันและมัลติมีเดีย; ให้คะแนนความซับซ้อนโดยคร่าว ๆ เพื่อระบุจุดบอดที่อาจส่งผลต่อประสิทธิภาพ