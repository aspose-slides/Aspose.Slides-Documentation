---
title: จัดการส่วนสไลด์ในงานนำเสนอโดยใช้ Java
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำให้ส่วนสไลด์ใน PowerPoint และ OpenDocument มีประสิทธิภาพด้วย Aspose.Slides for Java — แบ่ง, เปลี่ยนชื่อ, และจัดลำดับใหม่เพื่อเพิ่มประสิทธิภาพกระบวนการทำงานของ PPTX และ ODP."
---
## **บทนำ**

ด้วย Aspose.Slides for Java คุณสามารถจัดระเบียบ PowerPoint Presentation เป็นส่วนต่าง ๆ ได้ คุณสามารถสร้างส่วนที่มีสไลด์เฉพาะได้

คุณอาจต้องการสร้างส่วนและใช้เพื่อจัดระเบียบหรือแบ่งสไลด์ในงานนำเสนอออกเป็นส่วนที่มีตรรกะในสถานการณ์ต่อไปนี้:

- เมื่อคุณกำลังทำงานบนงานนำเสนอขนาดใหญ่กับคนอื่นหรือทีม — และคุณต้องมอบสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกในทีม
- เมื่อคุณกำลังจัดการกับงานนำเสนอที่มีสไลด์จำนวนมาก — และคุณประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาทั้งหมดพร้อมกัน

โดยทั่วไปคุณควรสร้างส่วนที่เก็บสไลด์ที่คล้ายคลึงกัน — สไลด์เหล่านั้นมีสิ่งที่เหมือนกันหรือสามารถอยู่ในกลุ่มตามกฎต่าง ๆ — และตั้งชื่อส่วนที่บรรยายสไลด์ภายใน

## **สร้างส่วนในงานนำเสนอ**

เพื่อเพิ่มส่วนที่เก็บสไลด์ในงานนำเสนอ Aspose.Slides for Java มีเมธอด [addSection()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) ที่ให้คุณระบุชื่อของส่วนที่ต้องการสร้างและสไลด์ที่ส่วนนั้นเริ่มต้น

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
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 จะจบที่ newSlide2 และหลังจากนั้น section2 จะเริ่มต้น   

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

## **เปลี่ยนชื่อของส่วน**

หลังจากที่คุณสร้างส่วนใน PowerPoint presentation แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน

โค้ดตัวอย่างนี้แสดงวิธีเปลี่ยนชื่อของส่วนในงานนำเสนอด้วย Java โดยใช้ Aspose.Slides:

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

**ส่วนยังคงอยู่เมื่อตัวบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003)?**

ไม่. รูปแบบ PPT ไม่รองรับข้อมูลเมทาดาทาของส่วน ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt.

**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

ไม่. สามารถซ่อนได้เฉพาะสไลด์แต่ละอันเท่านั้น ส่วนในฐานะเอนทิตี้ไม่มีสถานะ "hidden".

**ฉันสามารถค้นหาส่วนโดยอิงจากสไลด์ได้อย่างรวดเร็ว หรือในทางกลับกันสไลด์แรกของส่วนได้หรือไม่?**

ใช่. ส่วนจะถูกกำหนดอย่างเฉพาะโดยสไลด์เริ่มต้น; เมื่อให้สไลด์หนึ่ง คุณสามารถระบุได้ว่ามันอยู่ในส่วนใด และสำหรับส่วนหนึ่งคุณสามารถเข้าถึงสไลด์แรกของมันได้.