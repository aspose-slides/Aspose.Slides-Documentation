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
description: "สำรวจสไลด์, โครงสร้างและเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น"
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม อ่านคุณสมบัติของเอกสาร และอัปเดตคุณสมบัตินั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/) ซึ่งสาธิตการทำงานทั่วไปกับ metadata ของการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนอนั้นอยู่ในรูปแบบใด (PPT, PPTX, ODP หรืออื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดไฟล์ได้ ดูตัวอย่างโค้ด Java นี้:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **รับคุณสมบัติของการนำเสนอ**

โค้ด Java นี้แสดงวิธีดึงคุณสมบัติของการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

คุณอาจต้องการดู [properties under the DocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) คลาส

## **อัปเดตคุณสมบัติของการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ที่ให้คุณทำการเปลี่ยนแปลงคุณสมบัติของการนำเสนอได้

สมมติว่าเรามีไฟล์ PowerPoint ที่มีคุณสมบัติเอกสารแสดงด้านล่าง

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

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

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเอกสารแสดงด้านล่าง

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณสมบัติด้านความปลอดภัย คุณอาจพบลิงก์เหล่านี้มีประโยชน์:

- [การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอ](/slides/th/androidjava/password-protected-presentation/)
- [การป้องกันการเขียนสำหรับงานนำเสนอ](/slides/th/androidjava/write-protected-presentation/)

## **FAQ**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังไว้และเป็นแบบใดบ้าง?**

ค้นหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ระดับการนำเสนอ แล้วเปรียบเทียบรายการนั้นกับชุด [fonts actually used across content](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getFonts--) เพื่อระบุว่าแบบอักษรใดสำคัญต่อการเรนเดอร์

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ซ่อนอยู่หรือไม่และมีจำนวนเท่าไร?**

วนลูปผ่าน [slide collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#getHidden--) ของแต่ละสไลด์

**ฉันจะตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวกำหนดสไลด์แบบกำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ครับ เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideSize--) ปัจจุบันและแนวกับค่าพรีเซ็ตมาตรฐาน ซึ่งช่วยคาดการณ์พฤติกรรมเมื่อต้องพิมพ์หรือส่งออก

**มีวิธีเร็ว ๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

มีครับ ให้เดินทางผ่าน [charts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/) ทั้งหมด ตรวจสอบ [data source](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ของแต่ละกราฟ แล้วบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยงจากภายนอก รวมถึงลิงก์ที่เสียหายด้วย

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนอ็อบเจกต์และมองหารูปภาพขนาดใหญ่ ความโปร่งแสง เงา แอนิเมชัน และสื่อมัลติมีเดีย แล้วกำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดที่อาจเป็นคอขวดด้านประสิทธิภาพ