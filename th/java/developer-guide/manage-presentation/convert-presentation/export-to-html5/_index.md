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
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ Java. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides ครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีเว็บเอ็กซ์เทนชันหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกในการควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออก PowerPoint เป็น HTML มาตรฐาน อธิบายวิธีสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีรวมคอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดการจัดวาง

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด Java นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีเว็บเอ็กซ์เทนชันและการพึ่งพา:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
ในกรณีนี้คุณจะได้ HTML ที่สะอาดและเรียบง่าย. 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์แบบนี้:

```java
import com.aspose.slides.*;

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

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint เป็น HTML มาตรฐาน:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

ในกรณีนี้ เนื้อหาของงานนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังนี้:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
เมื่อคุณใช้วิธีนี้เพื่อส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถกำหนดสไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนไหวได้. 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 Slide View**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่แสดงสไลด์ในโหมดมุมมองสไลด์ ในกรณีนี้เมื่อเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ.

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint เป็น HTML5 Slide View:

```java
import com.aspose.slides.*;

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

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถใส่โน้ตหรือข้อเสนอแนะบนสไลด์งานนำเสนอได้ เหมาะสำหรับโครงการทำงานร่วมกันที่หลายคนสามารถเพิ่มข้อเสนอแนะให้กับองค์ประกอบของสไลด์โดยไม่แก้ไขเนื้อหาหลัก คอมเมนต์แต่ละรายการจะแสดงชื่อผู้เขียน ทำให้ติดตามว่าใครเป็นผู้ทิ้งข้อคิดเห็นได้ง่าย

สมมติเรามีงานนำเสนอ PowerPoint ที่บันทึกในไฟล์ "sample.pptx".

![สองคอมเมนต์บนสไลด์งานนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้ง่ายว่าจะรวมคอมเมนต์จากงานนำเสนอในเอกสารผลลัพธ์หรือไม่ ทำได้โดยส่งพารามิเตอร์การแสดงคอมเมนต์ไปยังเมธอด `setSlidesLayoutOptions` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 ที่แสดงคอมเมนต์ทางขวาของสไลด์
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

เอกสาร "output.html" แสดงในภาพด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ผลลัพธ์](two_comments_html5.png)

## **FAQ**

### ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [slide transitions](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### การสนับสนุนการแสดงคอมเมนต์มีหรือไม่ และสามารถวางคอมเมนต์ได้ตำแหน่งใดสัมพันธ์กับสไลด์?

ใช่, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับโน้ตและคอมเมนต์.

### ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?

ใช่, มี [setting](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ที่อนุญาตให้ข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ซึ่งช่วยปฏิบัติตามนโยบายความปลอดภัยที่เคร่งครัด