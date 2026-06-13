---
title: แปลงงานนำเสนอเป็น HTML5 ด้วย Java
linktitle: งานนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/java/export-to-html5/
keywords:
- PowerPoint เป็น HTML5
- OpenDocument เป็น HTML5
- งานนำเสนอเป็น HTML5
- สไลด์เป็น HTML5
- PPT เป็น HTML5
- PPTX เป็น HTML5
- ODP เป็น HTML5
- บันทึก PPT เป็น HTML5
- บันทึก PPTX เป็น HTML5
- บันทึก ODP เป็น HTML5
- ส่งออก PPT เป็น HTML5
- ส่งออก PPTX เป็น HTML5
- ส่งออก ODP เป็น HTML5
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 ตอบสนองด้วย Aspose.Slides สำหรับ Java. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides ครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออก PowerPoint ไปยัง HTML มาตรฐาน วิธีการสร้างผลลัพธ์ HTML5 ในโหมดดูสไลด์ และการแสดงคอมเมนต์ในเอกสารที่ส่งออกโดยการกำหนดค่าเค้าโครงการแสดง

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด Java นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
ในกรณีนี้ คุณจะได้รับ HTML ที่สะอาด 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ดังนี้:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ส่งออก PowerPoint เป็น HTML**

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML มาตรฐาน:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

ในกรณีนี้ เนื้อหาของงานนำเสนอจะถูกแสดงผ่าน SVG ในรูปแบบดังต่อไปนี้:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="หมายเหตุ" color="warning" %}} 
เมื่อคุณใช้วิธีนี้ส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนไหวได้ 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 โหมดดูสไลด์**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์จะแสดงในโหมดดูสไลด์ ในกรณีนี้ เมื่อเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดดูสไลด์บนหน้าเว็บ

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML5 โหมดดูสไลด์:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้ฝากโน้ตหรือข้อเสนอแนะในสไลด์ของงานนำเสนอ มีประโยชน์โดยเฉพาะในโครงการร่วมทำงานที่หลายคนสามารถเพิ่มข้อเสนอหรือความเห็นต่อองค์ประกอบของสไลด์โดยไม่ต้องเปลี่ยนแปลงเนื้อหาหลัก คอมเมนต์แต่ละรายการแสดงชื่อผู้เขียน ทำให้ติดตามได้ว่าใครเป็นผู้ทิ้งข้อคิดเห็น

สมมติว่าเรามีงานนำเสนอ PowerPoint ที่บันทึกไว้ในไฟล์ “sample.pptx”

![Two comments on the presentation slide](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้ง่ายว่าต้องการใส่คอมเมนต์จากงานนำเสนอไว้ในเอกสารผลลัพธ์หรือไม่ โดยทำการกำหนดพารามิเตอร์การแสดงคอมเมนต์ในเมธอด `getNotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/) 

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์ที่แสดงทางด้านขวามือของสไลด์
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

เอกสาร “output.html” แสดงในรูปด้านล่าง

![The comments in the output HTML5 document](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าอนิเมชั่นของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5?**

ได้, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [slide transitions](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)

**การสนับสนุนการส่งออกคอมเมนต์เป็นอย่างไร และสามารถวางคอมเมนต์ relative กับสไลด์ได้ที่ไหน?**

ได้, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับบันทึกและคอมเมนต์

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ได้, มี [setting](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ที่ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด