---
title: เรนเดอร์งานนำเสนอด้วยแบบอักษรสำรองบน Android
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/androidjava/render-presentation-with-fallback-font/
keywords:
- แบบอักษรสำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยแบบอักษรสำรองใน Aspose.Slides สำหรับ Android – ทำให้ข้อความคงที่ข้าม PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด Java ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเรนเดอร์งานนำเสนอโดยใช้กฎแบบอักษรสำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันของกฎแบบอักษรสำรอง, แก้ไขกฎโดยการลบหรือเพิ่มแบบอักษรสำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager.setFontFallBackRulesCollection`.

เมื่อคอลเลกชันของกฎแบบอักษรสำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ, กฎจะถูกนำไปใช้ระหว่างการทำงานต่าง ๆ เช่นการบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นภาพ PNG

## **เรนเดอร์สไลด์โดยใช้กฎแบบอักษรสำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนต่อไปนี้:

1. เรา [สร้างคอลเลกชันของกฎแบบอักษรสำรอง](/slides/th/androidjava/create-fallback-fonts-collection/).
2. [ลบ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎแบบอักษรสำรองและ [addFallBackFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ให้กับกฎอื่น.
3. กำหนดคอลเลกชันของกฎให้กับเมธอด [getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)
4. ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่นได้ หลังจากที่คอลเลกชันของกฎแบบอักษรสำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) กฎเหล่านี้จะถูกนำไปใช้ระหว่างการดำเนินการใด ๆ กับงานนำเสนอ เช่น บันทึก, เรนเดอร์, แปลง ฯลฯ.

```java
// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// สร้างกฎหลายรายการ
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //พยายามลบแบบอักษรสำรอง "Tahoma" จากกฎที่โหลด
    fallBackRule.remove("Tahoma");

    //และปรับปรุงกฎสำหรับช่วงที่ระบุ
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//เรายังสามารถลบกฎที่มีอยู่ใด ๆ จากรายการ
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //กำหนดรายการกฎที่เตรียมไว้สำหรับการใช้งาน
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่เริ่มต้นและบันทึกเป็น JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
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
อ่านเพิ่มเติมเกี่ยวกับ [แปลง PPT และ PPTX เป็น JPG บน Android](/slides/th/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}