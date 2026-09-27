---
title: Aspose.Slides สำหรับ Node.js ผ่าน Java
second_title: Aspose.Slides สำหรับ Node.js
type: docs
weight: 47
url: /th/nodejs-java/
keywords:
- เอกสาร
- การประมวลผลงานนำเสนอ
- การแปลงงานนำเสนอ
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "เริ่มที่นี่: ติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน Java, สร้างงานนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java เป็นไลบรารีสำหรับสร้าง อ่าน แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Node.js โดยไม่ต้องใช้ Microsoft PowerPoint.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมโครและเทมเพลตได้ และสามารถส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/nodejs-java/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/nodejs-java/create-presentation/">สร้างงานนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/nodejs-java/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/nodejs-java/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/nodejs-java/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/nodejs-java/licensing/">การให้สิทธิ์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/nodejs-java/open-presentation/">เปิดงานนำเสนอ</a></li>
<li><a href="/slides/th/nodejs-java/save-presentation/">บันทึกงานนำเสนอ</a></li>
<li><a href="/slides/th/nodejs-java/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/nodejs-java/convert-slide/">เรนเดอร์สไลด์เป็นรูปภาพ</a></li>
<li><a href="/slides/th/nodejs-java/manage-text/">แก้ไขข้อความและรูปทรง</a></li>
</ul>
<p>เวิร์กโฟลว์ Slides</p>
<ul>
<li><a href="/slides/th/nodejs-java/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/nodejs-java/powerpoint-animation/">ภาพเคลื่อนไหว</a></li>
<li><a href="/slides/th/nodejs-java/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/nodejs-java/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/nodejs-java/merge-presentation/">รวมงานนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/nodejs-java/examples/">ตัวอย่างตามส่วนประกอบสไลด์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/th/nodejs-java/">เอกสารอ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/th/nodejs-java/release-notes/">บันทึกการปล่อยเวอร์ชัน</a></li>
<li><a href="/slides/th/nodejs-java/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/th/nodejs-java/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/th/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

นอกเหนือจาก Node.js 20 หรือเวอร์ชันใหม่กว่า แพ็กเกจนี้ต้องการ Java Development Kit (JDK) Python และชุดเครื่องมือสร้าง C++ เนื่องจาก npm จะคอมไพล์บริดจ์ `java` ระหว่างการติดตั้ง ดูที่ [การติดตั้ง](/slides/th/nodejs-java/installation/) สำหรับขั้นตอนในแต่ละระบบปฏิบัติการ จากนั้นสร้างโปรเจกต์และติดตั้งแพ็กเกจจาก npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

บันทึกโค้ดนี้เป็น *hello.js* ในโฟลเดอร์โปรเจกต์:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides ทำงานในเครื่องเสมือน Java ที่ทำให้ Node.js ทำงานต่อเนื่อง ดังนั้นต้องสิ้นสุดกระบวนการอย่างชัดเจน.
process.exit(0);
```

รันด้วยคำสั่ง `node hello.js`. สคริปต์จะบันทึกไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งที่มีกล่องข้อความ หากไม่มีลิขสิทธิ์ ไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [การให้สิทธิ์](/slides/th/nodejs-java/licensing/). สำหรับวิธีการสร้างและเติมข้อมูลในงานนำเสนอเพิ่มเติม ดูที่ [สร้างงานนำเสนอ](/slides/th/nodejs-java/create-presentation/).