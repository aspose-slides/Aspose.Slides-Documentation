---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /th/cpp/
keywords:
- เอกสาร
- การประมวลผลการนำเสนอ
- การแปลงการนำเสนอ
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for C++, สร้างงานนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ เป็นไลบรารี C++ เนทีฟสำหรับการสร้าง, อ่าน, แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation.

มันสามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP, รวมถึงรูปแบบที่เปิดใช้งานมาโครและเทมเพลต, และส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/cpp/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/cpp/create-presentation/">สร้างงานนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/cpp/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/cpp/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/cpp/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/cpp/licensing/">การให้สิทธิ์ใช้งาน</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/cpp/open-presentation/">เปิดงานนำเสนอ</a></li>
<li><a href="/slides/th/cpp/save-presentation/">บันทึกงานนำเสนอ</a></li>
<li><a href="/slides/th/cpp/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/cpp/convert-slide/">แสดงสไลด์เป็นรูปภาพ</a></li>
<li><a href="/slides/th/cpp/manage-text/">แก้ไขข้อความและรูปทรง</a></li>
</ul>
<p>ขั้นตอนการทำงานของ Slides</p>
<ul>
<li><a href="/slides/th/cpp/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/cpp/powerpoint-animation/">การเคลื่อนไหว</a></li>
<li><a href="/slides/th/cpp/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/cpp/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/cpp/merge-presentation/">ผสานงานนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/cpp/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">ตัวอย่างบน GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิง &amp; สนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">เอกสารอ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">บันทึกการปล่อยเวอร์ชัน</a></li>
<li><a href="/slides/th/cpp/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">หน้าผลิตภัณฑ์</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">ดาวน์โหลด</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบเสียค่าใช้จ่าย</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

บน Windows, สร้างโปรเจกต์ C++ **Console App** ใน Visual Studio และติดตั้งแพคเกจ NuGet ผ่าน Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

บน Linux, ดาวน์โหลดแพคเกจ ZIP สำหรับ Linux และตั้งค่าโปรเจกต์ CMake ตามที่อธิบายใน [การติดตั้ง](/slides/th/cpp/installation/#linux).

จากนั้นใช้โค้ดนี้เป็นไฟล์ซอร์สหลักของโปรแกรม มันสร้างงานนำเสนอที่มีช่องข้อความหนึ่งและบันทึกไว้:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

ในการรันบน Windows, เลือกแพลตฟอร์ม **x64** ในแถบเครื่องมือและกด **Ctrl+F5**. บน Linux, บันทึกเป็น *main.cpp* ในโฟลเดอร์โปรเจกต์, แล้วทำการคอมไพล์และรันที่นั่น:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

โปรแกรมบันทึกไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งซึ่งมีช่องข้อความ หากไม่มีใบอนุญาตไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [การให้สิทธิ์ใช้งาน](/slides/th/cpp/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมข้อมูลในงานนำเสนอ, ดูที่ [สร้างงานนำเสนอ](/slides/th/cpp/create-presentation/).