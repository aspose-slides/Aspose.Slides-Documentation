---
title: กำหนดค่าคอลเลกชันฟอนท์สำรองใน Java
linktitle: คอลเลกชันฟอนท์สำรอง
type: docs
weight: 20
url: /th/java/create-fallback-fonts-collection/
keywords:
- ฟอนท์สำรอง
- กฎฟอนท์สำรอง
- คอลเลกชันฟอนท์
- กำหนดค่าฟอนท์
- ตั้งค่าฟอนท์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนท์สำรองใน Aspose.Slides สำหรับ Java เพื่อให้ข้อความคงที่และคมชัดในการนำเสนอ PowerPoint และ OpenDocument."
---
## **Overview**

Aspose.Slides อนุญาตให้คุณกำหนดคอลเลกชันของกฎฟอนท์สำรองสำหรับการพรีเซนเทชัน แต่ละกฎสำรองจะถูกแสดงโดยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection` ซึ่งทำหน้าที่ตามอินเตอร์เฟซ `IFontFallBackRulesCollection`.

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับ property `FontFallBackRulesCollection` ของ `FontsManager` ของพรีเซนเทชัน `FontsManager` ควบคุมฟอนท์ทั่วทั้งพรีเซนเทชัน และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนท์สำรอง ฟอนท์สำรองที่ระบุจะถูกนำไปใช้ในระหว่างการเรนเดอร์พรีเซนเทชัน

## **Apply Fallback Rules**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection) ซึ่งทำตามอินเตอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFontFallBackRulesCollection) ได้ สามารถเพิ่มหรือลบกฎจากคอลเลกชันได้

จากนั้นคอลเลกชันนี้อาจถูกกำหนดให้กับเมธอด [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) FontsManager ควบคุมฟอนท์ทั่วทั้งพรีเซนเทชัน

แต่ละ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) มีเมธอด [getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--) ที่คืนค่าอินสแตนซ์ของคลาส [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) ของตนเอง

ต่อไปนี้คือตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนท์สำรองและกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--) ของพรีเซนเทชันหนึ่ง:

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

หลังจากที่ FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนท์สำรอง ฟอนท์สำรองจะถูกนำไปใช้ในระหว่างการเรนเดอร์พรีเซนเทชัน

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [เรนเดอร์พรีเซนเทชันด้วยฟอนท์สำรอง](/slides/th/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**กฎฟอนท์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และมองเห็นได้ใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่. กฎฟอนท์สำรองเป็นการตั้งค่าการเรนเดอร์แบบรันไทม์; ไม่ได้ถูกจัดเก็บเป็นส่วนหนึ่งของไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint

**ฟอนท์สำรองจะใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิและตารางหรือไม่?**

ใช่. กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใดๆ ในวัตถุเหล่านี้

**Aspose มีการแจกจ่ายฟอนท์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่. คุณต้องเพิ่มและใช้ฟอนท์ด้วยตนเอง และรับผิดชอบต่อการใช้ฟอนท์นั้น

**สามารถใช้การแทนที่/การเปลี่ยนฟอนท์ที่หายไปและการสำรองสำหรับ glyph ที่หายไปพร้อมกันได้หรือไม่?**

ใช่. ทั้งสองเป็นขั้นตอนอิสระของกระบวนการแก้ปัญหาฟอนท์เดียวกัน: ขั้นแรกเอ็นจินตรวจสอบความพร้อมของฟอนท์ ([replacement](/slides/th/java/font-replacement/)/[substitution](/slides/th/java/font-substitution/)) จากนั้นฟอนท์สำรองจะเติมช่องว่างของ glyph ที่หายไปในฟอนท์ที่มี