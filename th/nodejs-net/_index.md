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
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for Node.js via .NET, สร้างงานนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, การให้สิทธิ์ใช้งาน, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides สำหรับ Node.js ผ่าน .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET เป็นไลบรารีสำหรับสร้าง อ่าน แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Node.js โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation มันทำงานโดยใช้ Aspose.Slides for .NET ผ่าน bridge edge-js ทำให้ API ของ JavaScript สะท้อน API ของ .NET ด้วยชื่อสมาชิกแบบ camelCase

ไลบรารีสามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมโครและแม่แบบต่างๆ และสามารถส่งออกเป็น PDF, XPS, HTML, TIFF, Markdown และภาพ

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/nodejs-net/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/nodejs-net/create-presentation/">สร้างงานนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/nodejs-net/developer-guide/">คู่มือผู้พัฒนา</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/nodejs-net/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/nodejs-net/licensing/">การให้สิทธิ์ใช้งาน</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/nodejs-net/open-presentation/">เปิดและบันทึกงานนำเสนอ</a></li>
<li><a href="/slides/th/nodejs-net/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/nodejs-net/convert-slide/">เรนเดอร์สไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/nodejs-net/manage-text/">แก้ไขข้อความ</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">เอกสารอ้างอิง API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">บันทึกการเผยแพร่</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

คุณต้องการ Node.js 22 หรือ 24 และ .NET SDK 8 หรือใหม่กว่า; Linux ยังต้องการแพ็คเกจระบบบางตัว [Installation](/slides/th/nodejs-net/installation/) ระบุรายการและแพลตฟอร์มที่ทดสอบแล้ว สร้างโปรเจกต์ เพิ่มการกำหนดทับที่บอก npm ว่าเวอร์ชัน edge-js ใดที่จะติดตั้ง และติดตั้งแพคเกจ:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

ทำการกู้คืนแพ็กเกจ .NET ที่ไลบรารีต้องพึ่งพาเพียงครั้งเดียวต่อเครื่อง บันทึกไฟล์ `deps.csproj` จาก [Restore the .NET Dependencies](/slides/th/nodejs-net/installation/#restore-the-net-dependencies) ลงในโฟลเดอร์ `deps` ภายในโฟลเดอร์โปรเจกต์ แล้วเรียกใช้:

```sh
dotnet restore deps/deps.csproj
```

บันทึกโค้ดนี้เป็น *hello.js* ในโฟลเดอร์โปรเจกต์:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// การนำเสนอใหม่ประกอบด้วยสไลด์ว่างหนึ่งสไลด์.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // ตำแหน่งและขนาดหน่วยเป็นพอยต์ (1/72 นิ้ว): x, y, ความกว้าง, ความสูง.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // ปลดปล่อยอ็อบเจกต์ .NET ที่เป็นฐานของการนำเสนอ.
    presentation.dispose();
}
```

เรียกใช้จากโฟลเดอร์โปรเจกต์:

```sh
node hello.js
```

สคริปต์จะพิมพ์ข้อความ `Saved hello.pptx` และบันทึกไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งหน้าซึ่งมีสี่เหลี่ยมผืกที่มีข้อความ หากไม่มีใบอนุญาตไฟล์ที่บันทึกจะมีเครื่องหมายลายน้ำการประเมิน — ดูที่ [Licensing](/slides/th/nodejs-net/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมข้อมูลงานนำเสนอ ดูที่ [Create a Presentation](/slides/th/nodejs-net/create-presentation/).