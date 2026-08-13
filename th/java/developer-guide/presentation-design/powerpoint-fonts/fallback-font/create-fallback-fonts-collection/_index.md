---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน Java
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/java/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ Java เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานพรีเซนเทชัน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดชุดกฎฟอนต์สำรองสำหรับงานพรีเซนเทชัน แต่ละกฎฟอนต์สำรองจะถูกแสดงโดยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection` ซึ่งทำหน้าที่เป็น `IFontFallBackRulesCollection` 

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับคุณสมบัติ `FontFallBackRulesCollection` ของ `FontsManager` ของพรีเซนเทชันได้ `FontsManager` จะควบคุมฟอนต์ทั้งหมดในพรีเซนเทชัน และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตัวเอง

เมื่อ `FontsManager` ถูกกำหนดค่าโดยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ในระหว่างการเรนเดอร์พรีเซนเทชัน

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของ[FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule)สามารถจัดกลุ่มเป็น[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection)ซึ่งทำหน้าที่เป็น[IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFontFallBackRulesCollection) สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้

จากนั้นคอลเลกชันนี้สามารถกำหนดให้กับเมธอด[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection)ของคลาส[FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) FontsManager ควบคุมฟอนต์ทั้งหมดในพรีเซนเทชัน

แต่ละ[Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)มีเมธอด[getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--)ซึ่งคืนค่าอินสแตนซ์ของคลาส[FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager)ของตนเอง

นี่คือตัวอย่างการสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ[FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--)ของพรีเซนเทชันบางรายการ:  

```java
import com.aspose.slides.*;

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

หลังจากที่ FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ในระหว่างการเรนเดอร์พรีเซนเทชัน

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับการ[Render Presentation with Fallback Font](/slides/th/java/render-presentation-with-fallback-font/) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

### กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และปรากฏใน PowerPoint หลังบันทึกหรือไม่?

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกซีเรียลไลซ์ลงในไฟล์ PPTX จึงไม่แสดงใน UI ของ PowerPoint

### การฟอนต์สำรองทำงานกับข้อความภายใน SmartArt, WordArt, แผนภูมิและตารางหรือไม่?

ใช่ กลไกการแทนที่ glyphเดียวกันจะถูกใช้กับข้อความทั้งหมดในวัตถุเหล่านี้

### Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตัวเองและรับผิดชอบต่อการใช้งานนั้นเอง

### สามารถใช้การแทนที่/การสับเปลี่ยนฟอนต์ที่หายไปร่วมกับฟอนต์สำรองสำหรับ glyph ที่หายไปได้หรือไม่?

ได้ ทั้งสองเป็นขั้นตอนที่แยกจากกันของกระบวนการแก้ไขฟอนต์: ก่อนอื่นเครื่องมือจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/java/font-replacement/)/[substitution](/slides/th/java/font-substitution/)) แล้วฟอนต์สำรองจะเติมเต็ม glyph ที่หายไปในฟอนต์ที่พร้อมใช้งาน.