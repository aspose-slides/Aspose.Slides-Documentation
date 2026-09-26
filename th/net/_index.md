---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /th/net/
keywords:
- เอกสาร
- การประมวลผลพรีเซนเทชัน
- การแปลงพรีเซนเทชัน
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for .NET, สร้างพรีเซนเทชันแรก, และค้นหาแนวทางสำหรับงานทั่วไป, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET เป็นไลบรารีคลาสสำหรับสร้าง, อ่าน, แก้ไขและแปลงพรีเซนเทชัน PowerPoint และ OpenDocument ในแอปพลิเคชัน .NET โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมโครและเทมเพลตได้ และสามารถส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้นใช้งาน</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/net/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/net/create-presentation/">สร้างพรีเซนเทชันแรกของคุณ</a></li>
<li><a href="/slides/th/net/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/net/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/net/evaluate-aspose-slides/">ข้อจำกัดของการทดลองใช้</a></li>
<li><a href="/slides/th/net/licensing/">การให้ใบอนุญาต</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/net/open-presentation/">เปิดพรีเซนเทชัน</a></li>
<li><a href="/slides/th/net/save-presentation/">บันทึกพรีเซนเทชัน</a></li>
<li><a href="/slides/th/net/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/net/convert-slide/">แปลงสไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/net/manage-text/">แก้ไขข้อความและรูปร่าง</a></li>
</ul>
<p>เวิร์กโฟลว์ Slides</p>
<ul>
<li><a href="/slides/th/net/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/net/powerpoint-animation/">การเคลื่อนไหว</a></li>
<li><a href="/slides/th/net/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/net/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/net/merge-presentation/">ผสานพรีเซนเทชัน</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/net/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">ตัวอย่างบน GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">เอกสาร API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">บันทึกการปล่อยเวอร์ชัน</a></li>
<li><a href="/slides/th/net/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/net/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือแบบชำระค่าบริการ</a></li>
</ul>
</div>
</div>

------

## **พรีเซนเทชันแรกของคุณ**

สร้างแอปพลิเคชันคอนโซลด้วย .NET SDK เวอร์ชัน 6 หรือใหม่กว่า:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

จากนั้นเพิ่มแพ็กเกจหนึ่งรายการสำหรับแพลตฟอร์มของคุณ:

- บน Windows: `dotnet add package Aspose.Slides.NET`
- บน Linux และ macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — ดู [Installation](/slides/th/net/installation/) สำหรับข้อกำหนดของ Linux และสำหรับระบบที่ต้องใช้ Aspose.Slides.NET แทน.

แทนที่เนื้อหาใน *Program.cs* ด้วยโค้ดนี้และรัน `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

โปรแกรมจะบันทึกไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งสไลด์พร้อมกล่องข้อความ. หากไม่มีใบอนุญาต ไฟล์ที่บันทึกจะมีลายน้ำการประเมินผล — ดู [Licensing](/slides/th/net/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมเนื้อหาในพรีเซนเทชัน ดูที่ [Create Presentations](/slides/th/net/create-presentation/).