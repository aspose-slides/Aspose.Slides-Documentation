---
title: แปลงการนำเสนอเป็น HTML5 ด้วย C++
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ C++. รักษาฟอร์แมต การเคลื่อนไหว และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides โดยครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์อีกด้วย บทความนี้ยังแสดงกระบวนการส่งออก PowerPoint‑to‑HTML มาตรฐาน อธิบายวิธีสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีรวมคอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดค่าเลย์เอาต์ของคอมเมนต์

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด C++ นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
ในกรณีนี้คุณจะได้ HTML ที่สะอาดตา 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ดังนี้:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **ส่งออก PowerPoint เป็น HTML**

โค้ด C++ นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML มาตรฐาน:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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

{{% alert title="Note" color="warning" %}} 
เมื่อใช้วิธีนี้ส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนไหวได้ 
{{% /alert %}}

## **ส่งออก PowerPoint เป็นมุมมองสไลด์ HTML5**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์แสดงในโหมดมุมมองสไลด์ ในกรณีนี้เมื่อเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ

โค้ด C++ นี้สาธิตกระบวนการส่งออก PowerPoint ไปยังมุมมองสไลด์ HTML5:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมความคิดเห็น**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถทิ้งบันทึกหรือข้อเสนอแนะบนสไลด์ได้ โดยเฉพาะอย่างยิ่งในโครงการทำงานร่วมกันที่หลายคนสามารถเพิ่มข้อเสนอแนะหรือหมายเหตุต่อองค์ประกอบของสไลด์โดยไม่แก้ไขเนื้อหาหลัก คอมเมนต์แต่ละรายการแสดงชื่อผู้เขียน ทำให้ติดตามว่าใครเป็นผู้ทิ้งข้อคิดเห็นได้ง่าย

สมมติว่าเรามีงานนำเสนอ PowerPoint ดังต่อไปนี้ที่บันทึกในไฟล์ “sample.pptx”

![สองคอมเมนต์บนสไลด์การนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้อย่างง่ายดายว่าต้องรวมคอมเมนต์จากงานนำเสนอไว้ในเอกสารผลลัพธ์หรือไม่ เพื่อทำเช่นนี้คุณต้องกำหนดพารามิเตอร์การแสดงคอมเมนต์ในเมธอด `get_NotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/) 

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์ที่แสดงทางด้านขวาของสไลด์
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

เอกสาร “output.html” แสดงในรูปด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ผลลัพธ์](two_comments_html5.png)

## **คำถามที่พบบ่อย**

### ฉันสามารถควบคุมว่าจะให้การเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์ทำงานใน HTML5 หรือไม่?

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [การเคลื่อนไหวของรูปร่าง](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [การเปลี่ยนสไลด์](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animatetransitions/)

### การส่งออกคอมเมนต์ได้รับการสนับสนุนหรือไม่ และสามารถวางคอมเมนต์ตำแหน่งใดสัมพันธ์กับสไลด์ได้บ้าง?

ใช่, คอมเมนต์สามารถเพิ่มใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่านการตั้งค่าเลย์เอาต์สำหรับโน้ตและคอมเมนต์

### ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?

ใช่, มี [การตั้งค่า](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) ที่ช่วยให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียกใช้ JavaScript ระหว่างการบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด