---
title: เปรียบเทียบสไลด์การนำเสนอใน JavaScript
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/nodejs-java/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เปรียบเทียบการนำเสนอ PowerPoint และ OpenDocument ด้วยโปรแกรมเมติกโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java. ระบุความแตกต่างของสไลด์ในโค้ดอย่างรวดเร็ว."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเปรียบเทียบสไลด์, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์โดยใช้เมธอด `equals` ที่มาจากคลาส `BaseSlide`. เมธอดนี้จะคืนค่า `true` เมื่อตัวสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาคงที่ที่เหมือนกัน.

## **เปรียบเทียบสองสไลด์**

เมธอด Equals ได้ถูกเพิ่มลงในคลาส [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide) และคลาส [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide) มันคืนค่า true สำหรับสไลด์/เลย์เอาต์และสไลด์/มาสเตอร์ที่มีโครงสร้างและเนื้อหาคงที่เหมือนกัน.

สองสไลด์จะถือว่าเท่ากันหากรูปทรง, สไตล์, ข้อความ, การเคลื่อนไหว และการตั้งค่าอื่น ๆ เป็นต้น มีค่าเท่ากัน. การเปรียบเทียบไม่พิจารณาค่าตัวระบุที่เป็นเอกลักษณ์ เช่น SlideId และเนื้อหาแบบไดนามิก เช่น ค่าข้อมูลวันที่ปัจจุบันในตัวจัดเก็บวันที่.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**การที่สไลด์ถูกซ่อนมีผลต่อการเปรียบเทียบสไลด์เองหรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/gethidden/) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น, ไม่ใช่เนื้อหาที่มองเห็นได้. ความเท่ากันของสองสไลด์ที่ระบุจะกำหนดโดยโครงสร้างและเนื้อหาคงที่; การที่สไลด์ถูกซ่อนอย่างเดียวไม่ทำให้สไลด์แตกต่างกัน.

**ลิงก์และพารามิเตอร์ของมันจะถูกนำมาพิจารณาหรือไม่?**

ใช่. ลิงก์เป็นส่วนหนึ่งของเนื้อหาคงที่ของสไลด์. หาก URL หรือการกระทำของลิงก์แตกต่างกัน, มักจะถือว่าเป็นความแตกต่างของเนื้อหาคงที่.

**หากแผนภูมิอ้างอิงไฟล์ Excel ภายนอก, เนื้อหาของไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่. การเปรียบเทียบทำบนพื้นฐานของสไลด์เอง. แหล่งข้อมูลภายนอกโดยทั่วไปจะไม่ถูกอ่านในขณะเปรียบเทียบ; มีเพียงสิ่งที่ปรากฏในโครงสร้างและสถานะคงที่ของสไลด์เท่านั้นที่ถูกพิจารณา.