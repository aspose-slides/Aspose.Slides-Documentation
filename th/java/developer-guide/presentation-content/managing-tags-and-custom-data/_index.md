---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย Java
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, อ่าน, ปรับปรุง และลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ Java พร้อมตัวอย่างสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **Overview**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร, ระบุว่าข้อมูลที่เฉพาะเจาะจงต่อการนำเสนอสามารถมีอยู่ในรูปแบบแท็กและส่วน XML กำหนดเอง, และอธิบายว่าแท็กเป็นคู่ค่าแบบคีย์‑ค่าแบบสตริง  

บทความนี้ยังแสดงวิธีอ่านค่าของแท็กและวิธีเพิ่มแท็กลงในงานนำเสนอ, สไลด์เดี่ยว, หรือรูปทรง นอกจากนี้ยังครอบคลุมงานทั่วไปในการจัดการแท็ก เช่น การล้างแท็กทั้งหมด, การลบแท็กตามชื่อ, และการดึงรายการชื่อแท็ก  

## **Data Storage in Presentation Files**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล .pptx — ถูกเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML สเปค Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ  

ด้วย *สไลด์* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ, *ส่วนสไลด์* จะบรรจุเนื้อหาของสไลด์เดียว ส่วนสไลด์สามารถมีความสัมพันธ์แบบชัดเจนกับหลายส่วน — เช่น User Defined Tags — ตามที่ ISO/IEC 29500 กำหนด  

ข้อมูลกำหนดเอง (เฉพาะงานนำเสนอ) หรือข้อมูลของผู้ใช้สามารถอยู่ในรูปแบบแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITagCollection)) และ CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection))  

{{% alert color="primary" %}}  
แท็กโดยพื้นฐานแล้วเป็นค่าคู่คีย์‑สตริง  
{{% /alert %}}  

## **Get Values of Tags**

ใน Slides แท็กสอดคล้องกับเมธอด [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDocumentProperties#getKeywords--) และ [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Tags to Presentations**

Aspose.Slides ให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองส่วน  

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`  
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`  

หากจำเป็นต้องจัดประเภทงานนำเสนอบางชุดตามกฎหรือคุณสมบัติเฉพาะ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กลงในงานนำเสนนั้น ตัวอย่างเช่น หากต้องการจัดกลุ่มหรือรวมงานนำเสนอทั้งหมดจากประเทศในอเมริกาเหนือเข้าด้วยกัน คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าเป็นประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา, เม็กซิโก และแคนาดา)  

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ด้วย Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

แท็กยังสามารถกำหนดให้กับ [Slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) ได้เช่นกัน:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

หรือตัว [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) แยกเดี่ยวใด ๆ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Limitations**

แท็กที่เพิ่มผ่านคอลเลกชันแท็กข้อมูลกำหนดเองโดยใช้ `getCustomData().getTags()` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่ตั้งเป็นแท็กจะไม่สามารถดึงกลับมาจาก PDF ที่มีแท็กได้  

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของออบเจกต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF  

## **FAQ**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปทรงได้ในหนึ่งขั้นตอนหรือไม่?**  

ใช่ — [คอลเลกชันแท็ก](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#clear--) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน  

**ฉันจะลบแท็กเดี่ยวตามชื่อโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**  

ใช้การดำเนินการ [Remove(name)](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) บน [คอลเลกชันแท็ก](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์ของมัน  

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**  

ใช้ [getNamesOfTags](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#getNamesOfTags--) บน [คอลเลกชันแท็ก](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) — มันจะคืนค่าเป็นอาเรย์ของชื่อแท็กทั้งหมด