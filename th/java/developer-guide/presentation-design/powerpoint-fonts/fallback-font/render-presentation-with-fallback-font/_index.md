---
title: เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน Java
linktitle: เรนเดอร์การนำเสนอ
type: docs
weight: 30
url: /th/java/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์การนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ Java – รักษาข้อความให้สอดคล้องกันระหว่าง PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด Java ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเรนเดอร์การนำเสนอโดยใช้กฎการสำรองแบบอักษร บทความนี้แสดงวิธีสร้างคอลเลคชันของกฎการสำรองแบบอักษร, แก้ไขกฎโดยการลบหรือเพิ่มแบบอักษรสำรอง, และกำหนดคอลเลคชันโดยใช้เมธอด `FontsManager.setFontFallBackRulesCollection`。

เมื่อคอลเลคชันกฎการสำรองแบบอักษรถูกกำหนดให้กับ `FontsManager` ของการนำเสนอ กฎเหล่านี้จะถูกนำไปใช้ในระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงการนำเสนอ ตัวอย่างแสดงวิธีใช้กฎที่กำหนดค่าไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นภาพ PNG

## **เรนเดอร์สไลด์โดยใช้กฎการสำรองแบบอักษร**

1. เราจะ[สร้างคอลเลคชันของกฎการสำรองแบบอักษร](/slides/th/java/create-fallback-fonts-collection/)。
2. [ลบ](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎการสำรองแบบอักษรและ[addFallBackFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ให้กับกฎอื่น。
3. ตั้งค่าคอลเลคชันของกฎโดยใช้เมธอด [getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)。
4. โดยใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกการนำเสนอในรูปแบบเดิม หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลคชันกฎการสำรองแบบอักษรถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการบนการนำเสนอ ได้แก่ การบันทึก, การเรนเดอร์, การแปลง, เป็นต้น。

```java
// สร้างอินสแตนซ์ใหม่ของคอลเลคชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// สร้างกฎหลายรายการ
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลดอยู่
    fallBackRule.remove("Tahoma");

    // และอัปเดตกฎสำหรับช่วงที่ระบุ
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// เรายังสามารถลบกฎที่มีอยู่แล้วจากรายการได้
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // กำหนดรายการกฎที่เตรียมไว้สำหรับใช้งาน
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // เรนเดอร์ภาพย่อโดยใช้คอลเลคชันกฎที่กำหนดค่าไว้และบันทึกเป็น JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [แปลง PPT และ PPTX เป็น JPG ใน Java](/slides/th/java/convert-powerpoint-to-jpg/)。
{{% /alert %}}