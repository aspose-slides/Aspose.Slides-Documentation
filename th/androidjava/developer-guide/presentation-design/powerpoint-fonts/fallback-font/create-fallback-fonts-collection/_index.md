---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองบน Android
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/androidjava/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎสำรองฟอนต์
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณกำหนดคอลเลกชันของกฎการใช้ฟอนต์สำรองสำหรับงานนำเสนอแต่ละงาน แต่ละกฎสำรองฟอนต์จะถูกแทนโดยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection` ซึ่งทำการใช้งานอินเทอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับคุณสมบัติ `FontFallBackRulesCollection` ของ `FontsManager` ของงานนำเสนอได้ `FontsManager` ควบคุมฟอนต์ทั่วทั้งงานนำเสนอ และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

## **ใช้กฎสำรองฟอนต์**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.  

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation.  

Each [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) class.  

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--) of a certain presentation:  

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

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.  

{{% alert color="info" %}} 
อ่านต่อเพื่อเรียนรู้วิธีการ [เรนเดอร์งานนำเสนอด้วยฟอนต์สำรอง](/slides/th/androidjava/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **คำถามที่พบบ่อย**

### กฎสำรองของฉันจะถูกฝังลงในไฟล์ PPTX และมองเห็นได้ใน PowerPoint หลังจากบันทึกหรือไม่?

ไม่. กฎสำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกจัดเก็บเป็นส่วนของ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint.  

### การสำรองฟอนต์จะใช้กับข้อความใน SmartArt, WordArt, แผนภูมิ, และตารางหรือไม่?

ใช่. กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความในวัตถุเหล่านี้ทั้งหมด.  

### Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?

ไม่. คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและเป็นความรับผิดชอบของคุณ.  

### สามารถใช้การแทนที่/การสับเปลี่ยนฟอนต์ที่หายไปและการสำรองฟอนต์สำหรับ glyph ที่หายไปพร้อมกันได้หรือไม่?

ใช่. ทั้งสองเป็นขั้นตอนอิสระของกระบวนการแก้ไขฟอนต์เดียวกัน: ก่อนอื่นเครื่องจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/androidjava/font-replacement/)/[substitution](/slides/th/androidjava/font-substitution/)) แล้วจึงใช้การสำรองฟอนต์เติมช่องว่างสำหรับ glyph ที่หายไปในฟอนต์ที่มีอยู่.