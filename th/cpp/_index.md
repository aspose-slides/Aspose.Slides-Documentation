---
title: Aspose.Slides สำหรับ C++
second_title: Aspose.Slides สำหรับ C++
type: docs
weight: 30
url: /th/cpp/
keywords:
- เอกสาร
- การประมวลผลงานนำเสนอ
- การแปลงงานนำเสนอ
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for C++ สร้างงานนำเสนอแรก และค้นหาคู่มือสำหรับงานทั่วไป อ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ เป็นไลบรารี C++ เนทีฟสำหรับสร้าง อ่าน แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument โดยไม่ต้องใช้ Microsoft PowerPoint หรือ Office Automation.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีแมโครและเทมเพลตต่าง ๆ และสามารถส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพได้.

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
<li><a href="/slides/th/cpp/convert-slide/">เรนเดอร์สไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/cpp/manage-text/">แก้ไขข้อความและรูปทรง</a></li>
</ul>
<p>เวิร์กโฟลว์ของ Slides</p>
<ul>
<li><a href="/slides/th/cpp/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/cpp/powerpoint-animation/">การเคลื่อนไหว</a></li>
<li><a href="/slides/th/cpp/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/cpp/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/cpp/merge-presentation/">ผสานงานนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/cpp/examples/">ตัวอย่างตามส่วนประกอบของสไลด์</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">ตัวอย่างบน GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/th/cpp/">เอกสารอ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/th/cpp/release-notes/">บันทึกการอัปเดต</a></li>
<li><a href="/slides/th/cpp/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/th/cpp/">ดาวน์โหลด</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/th/11">ฟอรัมสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **งานนำเสนอแรกของคุณ**

บน Windows ให้สร้างโครงการ **Console App** C++ ใน Visual Studio และติดตั้งแพ็กเกจ NuGet ผ่าน Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

บน Linux ให้ดาวน์โหลดแพ็กเกจ ZIP สำหรับ Linux และตั้งค่าโปรเจกต์ CMake ตามที่อธิบายในหน้า [Installation](/slides/th/cpp/installation/#linux).

จากนั้นใช้โค้ดนี้เป็นไฟล์ซอร์สหลักของโปรแกรม มันจะสร้างงานนำเสนอที่มีกล่องข้อความหนึ่งกล่องและบันทึกไฟล์:

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

เพื่อเรียกใช้บน Windows ให้เลือกแพลตฟอร์ม **x64** ในแถบเครื่องมือและกด **Ctrl+F5**. บน Linux ให้บันทึกเป็น *main.cpp* ในโฟลเดอร์โปรเจกต์ จากนั้นคอมไพล์และรันที่นั่น:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

โปรแกรมบันทึกไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งสไลด์ซึ่งมีกล่องข้อความ หากไม่มีลิขสิทธิ์ ไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [Licensing](/slides/th/cpp/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมเนื้อหาในงานนำเสนอ โปรดดูที่ [Create Presentations](/slides/th/cpp/create-presentation/).