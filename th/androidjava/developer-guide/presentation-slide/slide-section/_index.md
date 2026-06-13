---
title: จัดการส่วนสไลด์ในการนำเสนอบน Android
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/androidjava/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำให้การจัดการส่วนสไลด์ใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java—แยก, เปลี่ยนชื่อ, และจัดลำดับใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของ PPTX และ ODP"
---
## **บทนำ**

ด้วย Aspose.Slides for Android ผ่าน Java คุณสามารถจัดระเบียบการนำเสนอ PowerPoint เป็นส่วนต่าง ๆ ได้ คุณสามารถสร้างส่วนที่มีสไลด์เฉพาะได้

คุณอาจต้องการสร้างส่วนและใช้มันเพื่อจัดระเบียบหรือแบ่งสไลด์ในงานนำเสนอเป็นส่วนที่มีความหมายในสถานการณ์ต่อไปนี้:

- เมื่อคุณกำลังทำงานกับการนำเสนอขนาดใหญ่ร่วมกับคนอื่นหรือทีม — และคุณต้องการมอบหมายสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกทีมบางคน  
- เมื่อคุณกำลังจัดการการนำเสนอที่มีสไลด์จำนวนมาก — และคุณกำลังประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาเหล่านั้นพร้อมกัน  

โดยอุดมคติ คุณควรสร้างส่วนที่เก็บสไลด์ที่คล้ายคลึงกัน — สไลด์เหล่านั้นมีความสัมพันธ์หรือสามารถจัดเป็นกลุ่มตามกฎเกณฑ์ — และตั้งชื่อส่วนให้สื่อความหมายของสไลด์ภายในนั้น  

## **สร้างส่วนในงานนำเสนอ**

เพื่อเพิ่มส่วนที่เก็บสไลด์ในงานนำเสนอ Aspose.Slides for Android ผ่าน Java มีเมธอด [addSection()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) ที่ให้คุณระบุชื่อของส่วนที่ต้องการสร้างและสไลด์ที่ส่วนนั้นเริ่มต้นจาก

โค้ดตัวอย่างนี้แสดงวิธีสร้างส่วนในงานนำเสนอด้วย Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 จะสิ้นสุดที่ newSlide2 และหลังจากนั้น section2 จะเริ่มต้น   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนชื่อส่วน**

หลังจากที่คุณสร้างส่วนในงานนำเสนอ PowerPoint แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน  

โค้ดตัวอย่างนี้แสดงวิธีเปลี่ยนชื่อส่วนในงานนำเสนอด้วย Java โดยใช้ Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ส่วนจะถูกเก็บไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่ ตัวฟอร์แมต PPT ไม่รองรับเมตาดาต้าของส่วน ดังนั้นการจัดกลุ่มส่วนจะสูญหายเมื่อบันทึกเป็น .ppt  

**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

ไม่ สามารถซ่อนได้เฉพาะสไลด์เดี่ยวเท่านั้น ส่วนในฐานะเอนทิตีไม่มีสถานะ “ซ่อน”  

**ฉันสามารถค้นหาส่วนโดยอิงจากสไลด์ได้อย่างรวดเร็วหรือไม่ และในทางกลับกันหาสไลด์แรกของส่วนได้หรือไม่?**

ใช่ ส่วนจะถูกกำหนดโดยสไลด์เริ่มต้นอย่างชัดเจน; หากทราบสไลด์หนึ่ง คุณสามารถบ่งบอกว่ามันอยู่ในส่วนใด และสำหรับส่วนหนึ่งคุณสามารถเข้าถึงสไลด์แรกของส่วนนั้นได้.