---
title: Aspose.Slides สำหรับ Node.js ผ่าน .NET
second_title: Aspose.Slides สำหรับ Node.js
type: docs
weight: 47
url: /th/nodejs-net/
keywords:
- เอกสาร
- การประมวลผลงานนำเสนอ
- การแปลงงานนำเสนอ
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน .NET, สร้างงานนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, การให้ใบอนุญาต, อ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET คือไลบรารีสำหรับสร้าง, อ่าน, แก้ไขและแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Node.js โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation. ไลบรารีทำงานโดยรัน Aspose.Slides for .NET ผ่านบริดจ์ edge‑js ทำให้ API ของ JavaScript สะท้อนกับ API ของ .NET ด้วยชื่อสมาชิกแบบ camelCase.

ไลบรารีรองรับการโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีมาโครและแบบเทมเพลต, และสามารถส่งออกเป็น PDF, XPS, HTML, TIFF, Markdown และภาพต่าง ๆ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้นใช้งาน</b></p>
<hr>
<p>เริ่มต้น</p>
<ul>
<li><a href="/slides/th/nodejs-net/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/nodejs-net/create-presentation/">สร้างงานนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/nodejs-net/developer-guide/">คู่มือสำหรับนักพัฒนา</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/nodejs-net/evaluate-aspose-slides/">ข้อจำกัดของการทดลองใช้ฟรี</a></li>
<li><a href="/slides/th/nodejs-net/licensing/">ใบอนุญาต</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/nodejs-net/open-presentation/">เปิดและบันทึกงานนำเสนอ</a></li>
<li><a href="/slides/th/nodejs-net/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/nodejs-net/convert-slide/">แสดงสไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/nodejs-net/manage-text/">แก้ไขข้อความ</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">อ้างอิง API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">บันทึกการออกเวอร์ชัน</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">หน้าผลิตภัณฑ์</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

คุณต้องการ Node.js 22 หรือ 24 และ .NET SDK 8 หรือใหม่กว่า; Linux ยังต้องการแพ็คเกจระบบบางอย่าง [การติดตั้ง](/slides/th/nodejs-net/installation/) รายการเหล่านั้นและแพลตฟอร์มที่ทดสอบแล้ว. สร้างโปรเจกต์, เพิ่มการตั้งค่าทดแทนที่บอก npm ว่าให้ติดตั้ง edge‑js รุ่นใด, แล้วติดตั้งแพคเกจ:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

ทำครั้งเดียวต่อเครื่อง, กู้คืนแพคเกจ .NET ที่ไลบรารีต้องการ. บันทึกไฟล์ `deps.csproj` จาก [กู้คืนการพึ่งพา .NET](/slides/th/nodejs-net/installation/#restore-the-net-dependencies) ลงในโฟลเดอร์ `deps` ภายในโฟลเดอร์โปรเจกต์, จากนั้นรัน:

```sh
dotnet restore deps/deps.csproj
```

บันทึกโค้ดนี้เป็น *hello.js* ในโฟลเดอร์โปรเจกต์:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// งานนำเสนอใหม่มีสไลด์เปล่า 1 สไลด์.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // ตำแหน่งและขนาดเป็นหน่วยพอยต์ (1/72 นิ้ว): x, y, ความกว้าง, ความสูง.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // ปล่อยอ็อบเจ็กต์ .NET ที่สนับสนุนงานนำเสนอ.
    presentation.dispose();
}
```

เรียกใช้จากโฟลเดอร์โปรเจกต์:

```sh
node hello.js
```

สคริปต์จะแสดงข้อความ `Saved hello.pptx` และบันทึก *hello.pptx* ที่มีสไลด์หนึ่งที่มีสี่เหลี่ยมผืนผ้าพร้อมข้อความ. หากไม่มีใบอนุญาต, ไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดู [ใบอนุญาต](/slides/th/nodejs-net/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมเนื้อหาในงานนำเสนอ, ดู [สร้างงานนำเสนอ](/slides/th/nodejs-net/create-presentation/).