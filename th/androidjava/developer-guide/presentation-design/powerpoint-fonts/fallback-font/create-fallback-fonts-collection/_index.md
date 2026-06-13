---
title: ตั้งค่าคอลเลกชันฟอนต์สำรองบน Android
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/androidjava/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้ข้อความคงที่และคมชัดในงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับงานนำเสนอ แต่ละกฎฟอนต์สำรองจะแสดงโดยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection` ซึ่งทำการ implement อินเทอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับคุณสมบัติ `FontFallBackRulesCollection` ของ `FontsManager` ของงานนำเสนอ `FontsManager` จะควบคุมฟอนต์ทั่วทั้งงานนำเสนอและแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรองแล้ว ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) สามารถจัดเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection) ซึ่งทำการ implement อินเทอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFontFallBackRulesCollection) ได้ สามารถเพิ่มหรือกำจัดกฎจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้สามารถกำหนดให้กับเมธอด [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) ได้ FontsManager จะควบคุมฟอนต์ทั่วทั้งงานนำเสนอ  

แต่ละ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) มีเมธอด [getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--) ที่มีอินสแตนซ์ของคลาส [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) ของตนเอง  

นี่คือตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--) ของงานนำเสนอบางรายการ:

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรองแล้ว ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

{{% alert color="primary" %}} 
อ่านรายละเอียดเพิ่มเติมเกี่ยวกับการ [เรนเดอร์งานนำเสนอด้วยฟอนต์สำรอง](/slides/th/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนต์สำรองของฉันจะถูกฝังเข้าไปในไฟล์ PPTX และมองเห็นใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกจัดเก็บเป็นส่วนหนึ่งของไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint  

**ฟอนต์สำรองจะใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ, และตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้  

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบต่อการใช้ฟอนต์นั้น  

**สามารถใช้การแทนที่/การสับเปลี่ยนสำหรับฟอนต์ที่หายไปและฟอนต์สำรองสำหรับ glyph ที่หายไปร่วมกันได้หรือไม่?**

ใช่ พวกมันเป็นขั้นตอนอิสระของ pipeline การแก้ไขฟอนต์เดียวกัน: ก่อนแรกเอนจินจะตรวจสอบการมีอยู่ของฟอนต์ ([replacement](/slides/th/androidjava/font-replacement/)/[substitution](/slides/th/androidjava/font-substitution/)) แล้วฟอนต์สำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในฟอนต์ที่มีอยู่