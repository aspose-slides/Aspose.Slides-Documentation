---
title: เปรียบเทียบสไลด์การนำเสนอบน Android
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/androidjava/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เปรียบเทียบงานนำเสนอ PowerPoint และ OpenDocument อย่างโปรแกรมด้วย Aspose.Slides สำหรับ Android. ระบุความแตกต่างของสไลด์ในโค้ด Java อย่างรวดเร็ว."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเปรียบเทียบสไลด์, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์ โดยใช้เมธอด `equals` ที่จัดเตรียมโดยอินเทอร์เฟซ `IBaseSlide` และคลาส `BaseSlide` เมธอดนี้จะคืนค่า `true` เมื่อสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาคงที่ตรงกันอย่างสมบูรณ์

## **เปรียบเทียบสองสไลด์**
เมธอด Equals ได้ถูกเพิ่มไปยังอินเทอร์เฟซ [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBaseSlide) และคลาส [BaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/BaseSlide) เมธอดนี้คืนค่า true สำหรับสไลด์/เลย์เอาต์และสไลด์มาสเตอร์ที่มีโครงสร้างและเนื้อหาคงที่ตรงกัน  

สองสไลด์ถือว่าเท่ากันถ้ารูปทรง, สไตล์, ข้อความ, แอนิเมชัน และการตั้งค่าอื่น ๆ เป็นต้น ทั้งหมดมีค่าเท่ากัน การเปรียบเทียบไม่พิจารณาค่าตัวระบุที่เป็นเอกลักษณ์ เช่น SlideId หรือเนื้อหาแบบไดนามิก เช่น ค่าที่เป็นวันที่ปัจจุบันใน Date Placeholder

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

**การที่สไลด์ถูกซ่อนทำให้การเปรียบเทียบสไลด์เองได้รับผลกระทบหรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#getHidden--) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น ไม่ใช่เนื้อหาภาพรวม ความเท่าเทียมของสองสไลด์เฉพาะจะถูกกำหนดโดยโครงสร้างและเนื้อหาคงที่; การที่สไลด์หนึ่งถูกซ่อนโดยตรงไม่ได้ทำให้สไลด์แตกต่างกัน

**ไฮเปอร์ลิงก์และพารามิเตอร์ของมันถูกนำมาพิจารณาหรือไม่?**

ใช่. ลิงก์เป็นส่วนหนึ่งของเนื้อหาคงที่ของสไลด์ หาก URL หรือการกระทำของไฮเปอร์ลิงก์แตกต่างกัน จะถือว่าเป็นความแตกต่างในเนื้อหาคงที่

**หากแผนภูมิอ้างอิงไฟล์ Excel ภายนอก เนื้อหาของไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่. การเปรียบเทียบทำโดยอิงจากสไลด์เอง แหล่งข้อมูลภายนอกโดยทั่วไปจะไม่ถูกอ่านในขณะเปรียบเทียบ; มีเพียงสิ่งที่อยู่ในโครงสร้างและสถานะคงที่ของสไลด์เท่านั้นที่ถูกพิจารณา