---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอบน Android
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/androidjava/managing-tags-and-custom-data
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าแบบคู่
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม, อ่าน, ปรับปรุง, และลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ Android, พร้อมตัวอย่าง Java สำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร และระบุว่าข้อมูลเฉพาะของงานนำเสนอสามารถอยู่ในรูปแบบแท็กและส่วน Custom XML และอธิบายว่าแท็กเป็นคู่ค่าแบบคีย์‑ค่าในรูปแบบสตริง

บทความนี้ยังแสดงวิธีอ่านค่าของแท็กและวิธีการเพิ่มแท็กให้กับงานนำเสนอ สไลด์เดี่ยว หรือรูปทรงต่าง ๆ นอกจากนี้ยังครอบคลุมภารกิจทั่วไปในการจัดการแท็ก เช่น การลบแท็กทั้งหมด การลบแท็กตามชื่อ และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX—ไฟล์ที่มีส่วนขยาย .pptx—จะถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML รูปแบบ Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ

เมื่อ *slide* เป็นหนึ่งในองค์ประกอบของงานนำเสนอ *slide part* จะบรรจุเนื้อหาของสไลด์เดียว *slide part* สามารถมีความสัมพันธ์แบบชัดเจนกับหลายส่วน—เช่น User Defined Tags—ที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเอง (เฉพาะงานนำเสนอ) หรือข้อมูลของผู้ใช้สามารถอยู่ในรูปแบบแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITagCollection)) และ CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection))

{{% alert color="primary" %}} 
แท็กโดยพื้นฐานคือค่าคู่คีย์แบบสตริง 
{{% /alert %}} 

## **ดึงค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) และ [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Android ผ่าน Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มแท็กให้กับงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กให้กับงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอบางอย่างตามกฎหรือคุณสมบัติเฉพาะ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กให้กับงานนำเสนนั้น ตัวอย่างเช่น หากต้องการจัดกลุ่มหรือรวบรวมงานนำเสนอจากประเทศในอเมริกาเหนือทั้งหมด คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา เม็กซิโก และแคนาดา) เป็นค่า

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กให้กับ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ด้วย Aspose.Slides for Android ผ่าน Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

แท็กยังสามารถกำหนดให้กับ [Slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) ได้เช่นกัน:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

หรือกับ [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ใด ๆ:

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

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชันแท็กข้อมูลกำหนดเองโดยใช้ `getCustomData().getTags()` จะถูกจัดเก็บเฉพาะภายในไฟล์ PowerPoint เท่านั้น โดย **ไม่** ถูกถ่ายโอนไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่บันทึกเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถจัดเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ สไลด์ หรือรูปทรงในการทำงานหนึ่งครั้งได้หรือไม่?**

ได้. [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#clear--) ซึ่งลบคู่คีย์‑ค่าทั้งหมดในครั้งเดียว

**ฉันจะลบแท็กเดี่ยวโดยระบุชื่อโดยไม่ต้องวนรอบคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้การทำงาน [remove(name)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) บน [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [getNamesOfTags](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) บน [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) จะได้รับอาเรย์ของชื่อแท็กทั้งหมด