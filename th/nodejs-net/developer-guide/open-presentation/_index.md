---
title: เปิดพรีเซนเทชันใน Node.js ผ่าน .NET
linktitle: เปิดพรีเซนเทชัน
type: docs
weight: 20
url: /th/nodejs-net/open-presentation/
keywords:
- เปิดพรีเซนเทชัน
- เปิด PowerPoint
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดพรีเซนเทชัน
- พรีเซนเทชันจาก Buffer
- จำนวนสไลด์
- แปลงพรีเซนเทชัน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "เปิดไฟล์ PPTX, PPT, และ ODP ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน .NET: โหลดจากเส้นทางไฟล์หรือ Buffer, อ่านจำนวนสไลด์, และบันทึกเป็นรูปแบบอื่น."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Node.js ผ่าน .NET เปิดไฟล์พรีเซนเทชัน PowerPoint และ OpenDocument เช่นไฟล์ PPTX, PPT, และ ODP จากเส้นทางไฟล์หรือจาก `Buffer` ของ Node.js บทความนี้แสดงวิธีทั้งสอง อ่านจำนวนสไลด์ และบันทึกพรีเซนเทชันที่เปิดแล้วเป็นรูปแบบอื่น

ตัวอย่างเหล่านี้คาดว่ามีพรีเซนเทชันชื่อ `sample.pptx` อยู่ในโฟลเดอร์โปรเจคที่คุณตั้งค่าไว้ใน [Installation](/slides/th/nodejs-net/installation/). พรีเซนเทชัน PowerPoint ใดก็ได้ทำงานได้ บันทึกแต่ละตัวอย่างเป็นไฟล์ `.js` ในโฟลเดอร์โปรเจคและรันจากโฟลเดอร์นั้นด้วย `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js ผ่าน .NET ไม่มีเอกสารอ้างอิง API ของตนเอง มันสะท้อน API ของ Aspose.Slides for .NET ด้วยชื่อแบบ camelCase ดังนั้นลิงก์ API ในบทความนี้จะนำไปสู่คลาสและสมาชิกที่ตรงกันใน [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/).
{{% /alert %}}

## **เปิดพรีเซนเทชันจากไฟล์**

เพื่อเปิดพรีเซนเทชัน ให้ส่งเส้นทางของไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/presentation/). Aspose.Slides ตรวจจับรูปแบบจากเนื้อหาไฟล์แทนที่จะตรวจจากส่วนขยาย ดังนั้นโค้ดเดียวกันจึงเปิดไฟล์ PPTX, PPT, และ ODP ได้ เส้นทางสัมพันธ์จะถูกแก้ไขตามไดเรกทอรีทำงานปัจจุบัน ซึ่งคือโฟลเดอร์โปรเจคเมื่อคุณเรียกสคริปต์จากที่นั่น

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

สคริปต์จะพิมพ์จำนวนสไลด์ใน `sample.pptx` เช่น `Slide count: 9`. คุณสมบัติ `count` ของคอลเลกชัน [slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) รวมสไลด์ที่ซ่อนอยู่ด้วย เรียก `dispose` ในบล็อก `finally` ตามที่แสดง เพื่อให้ทรัพยากร .NET ที่อยู่เบื้องหลังพรีเซนเทชันถูกปล่อยแม้โค้ดของคุณจะล้มเหลว

## **เปิดพรีเซนเทชันจาก Buffer**

เมื่อพรีเซนเทชันมาจากฐานข้อมูล การอัปโหลด HTTP หรือแหล่งอื่นที่ให้ไบต์แทนเส้นทางไฟล์ ให้ส่ง `Buffer` ของ Node.js เป็นอาร์กิวเมนต์คอนสตรัคเตอร์ตัวที่สองและ `null` เป็นอาร์กิวเมนต์ตัวแรก ตัวอย่างต่อไปนี้อ่าน `sample.pptx` ลงในบัฟเฟอร์เพื่อทำหน้าที่เป็นแหล่งดังกล่าว:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

สคริปต์จะแสดงจำนวนสไลด์เดียวกับตัวอย่างก่อนหน้า อาร์กิวเมนต์ตัวที่สองต้องเป็น `Buffer`. สำหรับประเภทอื่นใด เช่น `Uint8Array` คอนสตรัคเตอร์จะไม่แจ้งข้อผิดพลาด; มันจะสร้างพรีเซนเทชันใหม่ที่มีสไลด์ว่างหนึ่งสไลด์แทน ให้แปลงประเภทไบนารีอื่นโดยใช้ `Buffer.from` ก่อน

## **บันทึกพรีเซนเทชันในรูปแบบอื่น**

เพื่อแปลงพรีเซนเทชันเป็นรูปแบบพรีเซนเทชันอื่น ให้เปิดมันและบันทึกด้วยค่า [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ที่ต่างกัน ตัวอย่างต่อไปนี้พิมพ์รูปแบบที่ Aspose.Slides ตรวจพบ ซึ่งเป็นค่าที่คุณสมบัติ [sourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sourceformat/) คืนค่า และบันทึกพรีเซนเทชันเป็นพรีเซนเทชัน OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

สคริปต์พิมพ์ `Source format: Pptx` และเขียนไฟล์ `sample.odp` ซึ่งมีสไลด์เดียวกัน `sourceFormat` คืนค่า `Ppt`, `Pptx` หรือ `Odp`. หากต้องการบันทึกเป็น PDF หรือเป็นภาพแทน ให้ดูที่ [Convert PowerPoint to PDF](/slides/th/nodejs-net/convert-powerpoint-to-pdf/) และ [Convert Slides to Images](/slides/th/nodejs-net/convert-slide/).

## **FAQ**

**ฉันจะเปิดพรีเซนเทชันที่มีการป้องกันด้วยรหัสผ่านได้อย่างไร?**

สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ตั้งค่าคุณสมบัติ [password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) ของมัน และส่งอ็อบเจ็กต์เป็นอาร์กิวเมนต์คอนสตรัคเตอร์ตัวที่สาม: `new Presentation("protected.pptx", null, loadOptions)`. หากไม่มีรหัสผ่านที่ถูกต้อง คอนสตรัคเตอร์จะโยนข้อผิดพลาด

**ทำไมคอนสตรัคเตอร์ถึงโยน `Error` ที่มีข้อความว่าง?**

เมื่อคอนสตรัคเตอร์ `Presentation` ล้มเหลวใน .NET เช่น เพราะไฟล์หาย ไม่ใช่พรีเซนเทชัน หรือต้องการรหัสผ่านที่ต่างกัน JavaScript จะได้รับ `Error` ที่มีข้อความว่าง ก่อนที่คุณจะเปิดไฟล์ ให้ตรวจสอบว่าไฟล์มีอยู่สัมพันธ์กับไดเรกทอรีทำงานหรือไม่ เช่นโดยใช้ `fs.existsSync`.

**ฉันสามารถเปิดรูปแบบใดได้บ้าง?**

รูปแบบพรีเซนเทชันของ PowerPoint และ OpenDocument รวมถึง PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP, และ FODP.