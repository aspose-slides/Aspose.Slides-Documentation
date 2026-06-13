---
title: เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน JavaScript
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/nodejs-java/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ Node.js – ทำให้ข้อความสอดคล้องกันในทุกไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด JavaScript ทีละขั้นตอน"
---
## **ภาพรวม**

Aspose.Slides ให้คุณเรนเดอร์งานนำเสนอโดยใช้กฎการใช้ฟอนท์สำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันของกฎฟอนท์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนท์สำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager.setFontFallBackRulesCollection`。

เมื่อคอลเลกชันกฎฟอนท์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านี้จะถูกนำไปใช้ในระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดค่าไว้เมื่อเรนเดอร์ภาพย่อยของสไลด์และบันทึกเป็นภาพ PNG。

## **เรนเดอร์สไลด์โดยใช้กฎฟอนท์สำรอง**

1. เรา [สร้างคอลเลกชันกฎฟอนท์สำรอง](/slides/th/nodejs-java/create-fallback-fonts-collection/)。
2. [Remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎฟอนท์สำรองและ [addFallBackFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ให้กับกฎอื่น。
3. กำหนดคอลเลกชันกฎให้กับ [getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) เมธอด。
4. ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกงานนำเสนอในรูปแบบเดิมหรือบันทึกเป็นรูปแบบอื่น หลังจากที่คอลเลกชันกฎฟอนท์สำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager) กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการกับงานนำเสนอ: บันทึก, เรนเดอร์, แปลง, เป็นต้น。

```javascript
// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// สร้างกฎหลายรายการ
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // พยายามลบฟอนต์ FallBack "Tahoma" จากกฎที่โหลด
    fallBackRule.remove("Tahoma");
    // และอัปเดตกฎสำหรับช่วงที่ระบุ
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// นอกจากนี้เราสามารถลบกฎใด ๆ ที่มีอยู่ในรายการได้
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // กำหนดรายการกฎที่เตรียมไว้สำหรับการใช้งาน
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // เรนเดอร์ภาพย่อยโดยใช้คอลเลกชันกฎที่กำหนดค่าแล้วและบันทึกเป็น JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีที่ [แปลง PPT และ PPTX เป็น JPG ใน JavaScript](/slides/th/nodejs-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}