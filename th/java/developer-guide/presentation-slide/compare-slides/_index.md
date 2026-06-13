---
title: การเปรียบเทียบสไลด์การนำเสนอใน Java
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/java/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เปรียบเทียบการนำเสนอ PowerPoint และ OpenDocument ด้วยโปรแกรมโดยใช้ Aspose.Slides สำหรับ Java ค้นหาความแตกต่างของสไลด์ในโค้ดได้อย่างรวดเร็ว."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเปรียบเทียบสไลด์, สไลด์เลย์เอาต์ และสไลด์มาสเตอร์โดยใช้เมธอด `equals` ที่มาจากอินเทอร์เฟซ `IBaseSlide` และคลาส `BaseSlide` เมธอดนี้จะคืนค่า `true` เมื่อสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาคงที่ตรงกัน

## **เปรียบเทียบสองสไลด์**
เมธอด Equals ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IBaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/IBaseSlide) และคลาส [BaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/BaseSlide) ซึ่งจะคืนค่า true สำหรับสไลด์/เลย์เอาต์และสไลด์มาสเตอร์ที่มีโครงสร้างและเนื้อคงที่ตรงกัน

สองสไลด์จะเท่ากันหากรูปทรง, สไตล์, ข้อความ, แอนิเมชันและการตั้งค่าอื่นๆ เป็นต้น มีค่าเท่ากัน การเปรียบเทียบไม่ได้คำนึงถึงค่าตัวระบุที่เป็นเอกลักษณ์ เช่น SlideId และเนื้อหาไดนามิก เช่น ค่าวันที่ปัจจุบันในตัวจองตำแหน่งวันที่

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **คำถามที่พบบ่อย**

**การที่สไลด์ถูกซ่อนมีผลต่อการเปรียบเทียบสไลด์หรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getHidden--) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น ไม่ใช่เนื้อหาภาพรวม ความเท่าเทียมของสองสไลด์ที่ระบุจะกำหนดโดยโครงสร้างและเนื้อหาคงที่; การที่สไลด์ถูกซ่อนเพียงอย่างเดียวไม่ได้ทำให้สไลด์แตกต่างกัน

**ลิงก์ไฮเปอร์และพารามิเตอร์ของมันจะถูกนำมาพิจารณาไหม?**

ใช่ ลิงก์เป็นส่วนหนึ่งของเนื้อหาคงที่ของสไลด์ หาก URL หรือการกระทำของลิงก์แตกต่างกัน จะถือว่าเป็นความแตกต่างในเนื้อหาคงที่

**หากแผนภูมิอ้างอิงไฟล์ Excel ภายนอก เนื้อหาของไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่ การเปรียบเทียบทำบนพื้นฐานของสไลด์เอง แหล่งข้อมูลภายนอกโดยทั่วไปจะไม่ได้ถูกอ่านในขณะเปรียบเทียบ; มีเพียงสิ่งที่อยู่ในโครงสร้างและสถานะคงที่ของสไลด์เท่านั้นที่ถูกนำมาพิจารณา