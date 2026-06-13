---
title: แปลงการนำเสนอเป็น HTML5 ด้วย JavaScript
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/nodejs-java/export-to-html5/
keywords:
- PowerPoint เป็น HTML5
- OpenDocument เป็น HTML5
- การนำเสนอเป็น HTML5
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint & OpenDocument ไปยัง HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ Node.js รักษาการจัดรูปแบบ, การเคลื่อนไหว และการโต้ตอบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงการนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides โดยครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมทั้งตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ นอกจากนี้บทความยังแสดงกระบวนการส่งออกมาตรฐานจาก PowerPoint ไปยัง HTML อธิบายวิธีสร้างผลลัพธ์ HTML5 ในโหมดดูสไลด์ และสาธิตวิธีรวมคอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดตำแหน่งของมัน

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด JavaScript นี้แสดงวิธีการส่งออกการนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
ในกรณีนี้ คุณจะได้ HTML ที่สะอาด 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ในวิธีนี้:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ส่งออก PowerPoint เป็น HTML**

โค้ด JavaScript นี้แสดงกระบวนการมาตรฐานจาก PowerPoint ไปยัง HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ในกรณีนี้ เนื้อหาการนำเสนอจะถูกแสดงผ่าน SVG ในรูปแบบดังต่อไปนี้:

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
เมื่อคุณใช้วิธีนี้ในการส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนไหวได้ 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 โหมดสไลด์**

**Aspose.Slides** ช่วยให้คุณแปลงการนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์จะแสดงในโหมดดูสไลด์ ในกรณีนี้ เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นการนำเสนอในโหมดดูสไลด์บนหน้าเว็บ

โค้ด JavaScript นี้แสดงกระบวนการส่งออก PowerPoint ไปยัง HTML5 โหมดดูสไลด์:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่อนุญาตให้ผู้ใช้ทิ้งบันทึกหรือข้อเสนอแนะบนสไลด์การนำเสนอ ซึ่งมีประโยชน์อย่างยิ่งในโครงการร่วมมือที่หลายคนสามารถเพิ่มข้อเสนอหรือความคิดเห็นต่อองค์ประกอบของสไลด์โดยไม่เปลี่ยนแปลงเนื้อหาหลัก คอมเมนต์แต่ละรายการจะแสดงชื่อผู้เขียน ทำให้ง่ายต่อการติดตามว่าใครเป็นผู้ทิ้งข้อคิดเห็นนั้น

สมมติว่าเรามีการนำเสนอ PowerPoint ที่บันทึกไว้ในไฟล์ “sample.pptx”

![สองคอมเมนต์บนสไลด์การนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงการนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้อย่างง่ายดายว่าต้องการรวมคอมเมนต์จากการนำเสนอในเอกสารผลลัพธ์หรือไม่ โดยต้องกำหนดพารามิเตอร์การแสดงคอมเมนต์ในคุณสมบัติ `notes_comments_layouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์ที่แสดงทางด้านขวาของสไลด์
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

เอกสาร “output.html” แสดงในภาพด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะทำงานใน HTML5 หรือไม่?**

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิดการ [shape animations](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/setanimateshapes/) และ [slide transitions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**การส่งออกคอมเมนต์รองรับหรือไม่, และสามารถวางคอมเมนต์สัมพันธ์กับสไลด์ได้ที่ไหน?**

ใช่, คอมเมนต์สามารถเพิ่มใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) สำหรับบันทึกและคอมเมนต์.

**ฉันสามารถข้ามลิงก์ที่เรียก JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ใช่, มี [setting](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ที่อนุญาตให้ข้ามไฮเพอร์ลิงก์ที่มีการเรียก JavaScript ขณะบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด.