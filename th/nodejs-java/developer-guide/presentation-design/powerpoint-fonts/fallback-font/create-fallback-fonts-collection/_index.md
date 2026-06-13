---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน JavaScript
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/nodejs-java/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎสำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อให้ข้อความคงที่และคมชัดในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับการนำเสนอแต่ละกฎสำรองจะถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection`。

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดค่าโดยใช้เมธอด `setFontFallBackRulesCollection` ของ `FontsManager` ของการนำเสนอ `FontsManager` ควบคุมฟอนต์ทั่วการนำเสนอและแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง。

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรองแล้ว ฟอนต์สำรองที่กำหนดจะถูกนำไปใช้ในระหว่างการเรนเดอร์การนำเสนอ。

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของคลาส[FontFallBackRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule)สามารถจัดระเบียบเป็น[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRulesCollection)ซึ่งเป็นคลาสที่ทำการใช้[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRulesCollection)ได้ สามารถเพิ่มหรือลบกฎจากคอลเลกชันได้。

จากนั้นคอลเลกชันนี้สามารถกำหนดให้กับเมธอด[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRulesCollection)ของคลาส[FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager)ได้ FontsManager ควบคุมฟอนต์ทั่วการนำเสนอ。

แต่ละ[Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)มีเมธอด[getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getFontsManager--)ที่ให้อินสแตนซ์ของคลาส[FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager)ของตนเอง。

ต่อไปนี้เป็นตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ[FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getFontsManager--)ของการนำเสนอบางประเภท：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

หลังจากที่ FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ในระหว่างการเรนเดอร์การนำเสนอ。

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [Render Presentation with Fallback Font](/slides/th/nodejs-java/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎสำรองของฉันจะถูกฝังลงในไฟล์ PPTX และมองเห็นใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่มี. กฎสำรองเป็นการตั้งค่าการเรนเดอร์ในเวลารันไทม์; พวกมันไม่ได้ถูกจัดเก็บลงในไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint.

**การสำรองใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**

ใช่. กลไกการแทนที่ glyph เดียวกันถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้.

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่มี. คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบเอง.

**การแทนที่/การเปลี่ยนฟอนต์ที่หายไปและการสำรองสำหรับ glyph ที่หายไปสามารถใช้ร่วมกันได้หรือไม่?**

ใช่. พวกมันเป็นขั้นตอนอิสระของท่อการแก้ไขฟอนต์เดียวกัน: ก่อนหน้าเอนจินจะตรวจสอบความพร้อมของฟอนต์([replacement](/slides/th/nodejs-java/font-replacement/)/[substitution](/slides/th/nodejs-java/font-substitution/)) แล้วการสำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในฟอนต์ที่มี.