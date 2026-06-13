---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอโดยใช้ JavaScript
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/nodejs-java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- คู่ค่า
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, อ่าน, ปรับปรุง และลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร, ระบุว่าข้อมูลเฉพาะของงานนำเสนอสามารถอยู่ในรูปแบบของแท็กและส่วน XML กำหนดเอง, และอธิบายว่าแท็กเป็นคู่ค่ากุญแจ‑ค่าแบบสตริง

บทความนี้ยังแสดงวิธีการอ่านค่าของแท็กและวิธีการเพิ่มแท็กไปยังงานนำเสนอ, สไลด์เดี่ยว, หรือรูปทรง นอกจากนี้ยังครอบคลุมงานจัดการแท็กทั่วไป เช่น การลบแท็กทั้งหมด, การลบแท็กตามชื่อ, และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล .pptx — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML สเปค Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ

เมื่อ *สไลด์* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ, *ส่วนสไลด์* จะบรรจุเนื้อหาของสไลด์เดียว ส่วนสไลด์นี้สามารถมีความสัมพันธ์โดยตรงกับหลายส่วน — เช่น User Defined Tags — ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเอง (เฉพาะต่อหนึ่งงานนำเสนอ) หรือของผู้ใช้สามารถอยู่ในรูปแบบของแท็ก ([TagCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TagCollection)) และส่วน XML กำหนดเอง ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/CustomXmlPartCollection))

{{% alert color="primary" %}} 
แท็กโดยพื้นฐานคือค่าคู่คีย์‑สตริง 
{{% /alert %}} 

## **การรับค่าของแท็ก**

ใน slides, แท็กสอดคล้องกับเมธอด [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) และ [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) ตัวอย่างโค้ดนี้แสดงวิธีการดึงค่าของแท็กด้วย Aspose.Slides for Node.js via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเพิ่มแท็กในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กเข้าไปในงานนำเสนอ แท็กทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`  
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอบางส่วนตามกฎหรือคุณสมบัติเฉพาะ, คุณอาจได้รับประโยชน์จากการเพิ่มแท็กลงในงานนำเสนอเหล่านั้น ตัวอย่างเช่น หากต้องการจัดกลุ่มงานนำเสนอจากประเทศในทวีปอเมริกาเหนือ, คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา, เม็กซิโก, แคนาดา) เป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มแท็กไปยัง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ด้วย Aspose.Slides for Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

แท็กยังสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide) ได้เช่นกัน:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

หรือรูปทรงใด ๆ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชันแท็กข้อมูลกำหนดเองโดยใช้ `getCustomData().getTags()` จะถูกเก็บไว้เฉพาะภายในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกถ่ายโอนไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่ตั้งเป็นแท็กจะไม่สามารถดึงคืนได้จาก PDF ที่มีแท็ก

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของอ็อบเจกต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปทรงได้ในหนึ่งขั้นตอนหรือไม่?**

ได้. [tag collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/clear/) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวตามชื่อโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้การดำเนินการ [remove(name)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อวิเคราะห์หรือกรองได้อย่างไร?**

ใช้ [getNamesOfTags](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) บน [tag collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) จะคืนค่าอาร์เรย์ของชื่อแท็กทั้งหมด