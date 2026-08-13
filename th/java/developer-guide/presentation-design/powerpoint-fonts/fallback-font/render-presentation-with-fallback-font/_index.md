---
title: เรนเดอร์งานนำเสนอด้วยแบบอักษรสำรองใน Java
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/java/render-presentation-with-fallback-font/
keywords:
- แบบอักษรสำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยแบบอักษรสำรองใน Aspose.Slides สำหรับ Java – รักษาข้อความให้สอดคล้องกันใน PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด Java ทีละขั้นตอน."
---
## **Overview**

Aspose.Slides ช่วยให้คุณสามารถเรนเดอร์งานนำเสนอโดยใช้กฎแบบอักษรสำรอง. บทความนี้จะแสดงวิธีสร้างคอลเลกชันกฎแบบอักษรสำรอง, แก้ไขกฎโดยการลบหรือเพิ่มแบบอักษรสำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager.setFontFallBackRulesCollection`.

เมื่อคอลเลกชันกฎแบบอักษรสำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ, กฎเหล่านี้จะถูกนำไปใช้ในกระบวนการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นรูป JPEG.

## **Render a Slide Using Fallback Font Rules**

เรนเดอร์สไลด์โดยใช้กฎแบบอักษรสำรอง

The following example includes these steps:

1. เรา[สร้างคอลเลกชันกฎแบบอักษรสำรอง](/slides/th/java/create-fallback-fonts-collection/).
1. [ลบ](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎแบบอักษรสำรองและ [addFallBackFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ให้กับกฎอื่น.
1. ตั้งค่าคอลเลกชันกฎโดยใช้ [getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) เมธอด.
1. ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันกฎแบบอักษรสำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) กฎเหล่านี้จะถูกนำไปใช้ในการดำเนินการใด ๆ บนงานนำเสนอ เช่น บันทึก, เรนเดอร์, แปลง เป็นต้น.

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// สร้างกฎหลายรายการ
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // พยายามลบแบบอักษรสำรอง "Tahoma" จากกฎที่โหลด
    fallBackRule.remove("Tahoma");

    // และอัปเดตกฎสำหรับช่วงที่ระบุ
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// เรายังสามารถลบกฎที่มีอยู่จากรายการได้ โดยคงไว้อย่างน้อยหนึ่งกฎสำหรับการเรนเดอร์
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // กำหนดรายการกฎที่เตรียมไว้เพื่อใช้
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าแล้วและบันทึกเป็น JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [Convert PPT and PPTX to JPG in Java](/slides/th/java/convert-powerpoint-to-jpg/).
{{% /alert %}}