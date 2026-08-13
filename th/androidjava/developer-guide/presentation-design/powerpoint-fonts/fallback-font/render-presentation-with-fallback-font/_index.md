---
title: เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองบน Android
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/androidjava/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ Android – ทำให้ข้อความคงที่ในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด Java ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรอง บทความนี้จะแสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรอง ปรับเปลี่ยนกฎโดยการลบหรือเพิ่มฟอนต์สำรอง และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager.setFontFallBackRulesCollection`

เมื่อคอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านั้นจะถูกนำไปใช้ในขั้นตอนต่าง ๆ เช่น การบันทึก การเรนเดอร์ และการแปลงงานนำเสนอ ตัวอย่างแสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นไฟล์รูป JPEG

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนดังนี้:

1. เรา [สร้างคอลเลกชันกฎฟอนต์สำรอง](/slides/th/androidjava/create-fallback-fonts-collection/).
1. [ลบ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎฟอนต์สำรองและ [addFallBackFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ให้กับกฎอื่น
1. กำหนดคอลเลกชันกฎให้กับ [getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) เมธอด
1. ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) กฎเหล่านี้จะถูกนำไปใช้ในการปฏิบัติการใด ๆ บนงานนำเสนอ เช่น บันทึก เรนเดอร์ แปลง เป็นต้น

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // พยายามลบฟอนต์ FallBack "Tahoma" จากกฎที่โหลดไว้
    fallBackRule.remove("Tahoma");

    // และอัปเดตกฎสำหรับช่วงที่ระบุ
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// เรายังสามารถลบกฎที่มีอยู่ใด ๆ จากรายการได้ โดยคงไว้อย่างน้อยหนึ่งกฎสำหรับใช้ในการเรนเดอร์
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // กำหนดรายการกฎที่เตรียมไว้สำหรับใช้งาน
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าไว้และบันทึกเป็น JPEG
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

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับ [แปลง PPT และ PPTX เป็น JPG บน Android](/slides/th/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}