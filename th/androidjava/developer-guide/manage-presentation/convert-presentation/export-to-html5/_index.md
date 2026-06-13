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
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และความโต้ตอบ."
---
## **Overview**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides. ครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ บทความนี้ยังแสดงกระบวนการส่งออก PowerPoint เป็น HTML มาตรฐาน อธิบายวิธีสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีรวมความคิดเห็นในเอกสารที่ส่งออกโดยกำหนดค่าเลย์เอาต์ของพวกมัน.

## **Export PowerPoint to HTML5**

โค้ด Java นี้แสดงวิธีการส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
ในกรณีนี้ คุณจะได้ HTML ที่สะอาด 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ด้วยวิธีนี้:

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

## **Export PowerPoint to HTML**

โค้ด Java นี้แสดงกระบวนการมาตรฐานของการแปลง PowerPoint เป็น HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

ในกรณีนี้ เนื้อหาของงานนำเสนอถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังต่อไปนี้:

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
เมื่อคุณใช้วิธีนี้เพื่อส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำการเคลื่อนไหวบางองค์ประกอบได้. 
{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์จะแสดงในโหมดมุมมองสไลด์ ในกรณีนี้ เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ.

โค้ด Java นี้แสดงกระบวนการส่งออก PowerPoint ไปยังมุมมองสไลด์ HTML5:

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

## **Convert a Presentation to an HTML5 Document with Comments**

ความคิดเห็นใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถทิ้งบันทึกหรือข้อเสนอแนะบนสไลด์ของงานนำเสนอได้ เหมาะอย่างยิ่งสำหรับโครงการร่วมมือ ที่หลายคนสามารถเพิ่มข้อเสนอแนะหรือหมายเหตุในองค์ประกอบของสไลด์โดยไม่เปลี่ยนแปลงเนื้อหาหลัก แต่ละความคิดเห็นจะแสดงชื่อผู้เขียน ทำให้ง่ายต่อการติดตามว่าใครเป็นผู้ทิ้งหมายเหตุ

สมมติว่าเรามีงานนำเสนอ PowerPoint ต่อไปนี้ที่บันทึกในไฟล์ "sample.pptx".

![ความคิดเห็นสองข้อบนสไลด์งานนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้อย่างง่ายดายว่าจะรวมความคิดเห็นจากงานนำเสนอในเอกสารผลลัพธ์หรือไม่ เพื่อทำเช่นนี้ คุณต้องระบุพารามิเตอร์การแสดงผลสำหรับความคิดเห็นในเมธอด `getNotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 โดยแสดงความคิดเห็นทางด้านขวาของสไลด์.

```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

เอกสาร "output.html" แสดงในรูปภาพด้านล่าง.

![ความคิดเห็นในเอกสาร HTML5 ผลลัพธ์](two_comments_html5.png)

## **FAQ**

**Can I control whether object animations and slide transitions will play in HTML5?**

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [slide transitions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Is the output of comments supported, and where can they be placed relative to the slide?**

ใช่, ความคิดเห็นสามารถเพิ่มใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับโน้ตและความคิดเห็น.

**Can I skip links that invoke JavaScript for security or CSP reasons?**

ใช่, มี [setting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ที่ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียกใช้ JavaScript ระหว่างการบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด.