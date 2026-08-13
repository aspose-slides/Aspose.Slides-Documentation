---
title: แปลงงานนำเสนอเป็น HTML5 บน Android
linktitle: งานนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML5 ที่เป็น responsive ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. รักษาการจัดรูปแบบ, การเคลื่อนที่, และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น HTML5 ด้วย Aspose.Slides รวมถึงการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาอื่น ๆ อีกทั้งยังมีตัวเลือกสำหรับควบคุมการเคลื่อนที่ของรูปทรงและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออกมาตรฐานจาก PowerPoint ไปเป็น HTML การสร้างผลลัพธ์ HTML5 ในโหมดดูสไลด์ และวิธีการใส่คอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดเลย์เอาต์

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด Java นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพาอื่นใด:

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
ในกรณีนี้คุณจะได้ HTML ที่สะอาดตา 
{{% /alert %}}

หากต้องการกำหนดค่าการเคลื่อนที่ของรูปทรงและการเปลี่ยนสไลด์ คุณสามารถทำได้ดังนี้:

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

โค้ด Java นี้สาธิตกระบวนการส่งออกแบบมาตรฐานจาก PowerPoint ไปเป็น HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

ในกรณีนี้เนื้อหาของงานนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังนี้:

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
เมื่อใช้วิธีนี้ส่งออก PowerPoint ไปเป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนที่ได้ 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 แบบมุมมองสไลด์**

**Aspose.Slides** อนุญาตให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 ที่แสดงสไลด์ในโหมดมุมมองสไลด์ ในกรณีนี้เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint ไปเป็น HTML5 แบบมุมมองสไลด์:

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

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถใส่บันทึกหรือข้อเสนอแนะบนสไลด์ของงานนำเสนอได้ มีประโยชน์อย่างยิ่งในโครงการทำงานร่วมกันที่หลายคนสามารถเพิ่มข้อเสนอแนะหรือความคิดเห็นต่อส่วนประกอบของสไลด์โดยไม่กระทบต่อเนื้อหาหลัก คอมเมนต์แต่ละรายการจะแสดงชื่อผู้เขียน ทำให้ติดตามได้ว่าใครเป็นผู้ทิ้งข้อความ

สมมติว่าเรามีงานนำเสนอ PowerPoint ที่บันทึกในไฟล์ “sample.pptx”

![Two comments on the presentation slide](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 คุณสามารถระบุได้ง่ายว่าต้องการใส่คอมเมนต์จากงานนำเสนอในเอกสารผลลัพธ์หรือไม่ โดยทำเช่นนั้นผ่านการส่งพารามิเตอร์การแสดงคอมเมนต์ไปยังเมธอด `setSlidesLayoutOptions` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 ที่แสดงคอมเมนต์ทางด้านขวาของสไลด์:
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

เอกสาร “output.html” แสดงในภาพด้านล่าง

![The comments in the output HTML5 document](two_comments_html5.png)

## **คำถามที่พบบ่อย**

### ฉันสามารถควบคุมการเล่นการเคลื่อนที่ของวัตถุและการเปลี่ยนสไลด์ใน HTML5 ได้หรือไม่?

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [slide transitions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)

### การสนับสนุนการแสดงคอมเมนต์มีหรือไม่ และสามารถวางตำแหน่งคอมเมนต์สัมพันธ์กับสไลด์อย่างไร?

ใช่, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับบันทึกและคอมเมนต์

### ฉันสามารถข้ามลิงก์ที่เรียก JavaScript เพื่อความปลอดภัยหรือเหตุผลด้าน CSP ได้หรือไม่?

ใช่, มี [setting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ที่อนุญาตให้ข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ขณะบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด