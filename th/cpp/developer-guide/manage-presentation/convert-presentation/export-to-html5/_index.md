---
title: แปลงงานนำเสนอเป็น HTML5 ใน C++
linktitle: งานนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 แบบตอบสนองด้วย Aspose.Slides สำหรับ C++. รักษาการจัดรูปแบบ การเคลื่อนไหว และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides รวมถึงการส่งออก HTML5 ขั้นพื้นฐานโดยไม่ต้องใช้ส่วนขยายเว็บหรือพึ่งพาเพิ่มเติม พร้อมตัวเลือกสำหรับควบคุมการเคลื่อนที่ของรูปร่างและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออกมาตรฐานจาก PowerPoint ไปยัง HTML การสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และวิธีใส่คอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดการจัดวาง

## **ส่งออก PowerPoint ไปยัง HTML5**

โค้ด C++ นี้แสดงวิธีการส่งออกงานนำเสนอเป็น HTML5

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
ในกรณีนี้คุณจะได้ HTML ที่สะอาด
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนที่ของรูปร่างและการเปลี่ยนสไลด์โดยวิธีนี้:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **ส่งออก PowerPoint ไปยัง HTML**

โค้ด C++ นี้สาธิตกระบวนการมาตรฐานจาก PowerPoint ไปยัง HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

ในกรณีนี้เนื้อหาของงานนำเสนอจะถูกแสดงผลผ่าน SVG ในรูปแบบดังนี้:
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
เมื่อคุณใช้วิธีนี้ในการส่งออก PowerPoint ไปยัง HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถปรับสไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนไหวได้
{{% /alert %}}

## **ส่งออก PowerPoint ไปยัง HTML5 โหมดสไลด์**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 ที่สไลด์แสดงในโหมดมุมมองสไลด์ ในกรณีนี้เมื่อเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ

โค้ด C++ นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML5 โหมดสไลด์:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้เพิ่มบันทึกหรือข้อเสนอแนะบนสไลด์ของงานนำเสนอ โดยเฉพาะอย่างยิ่งในการทำงานร่วมกันหลายคนสามารถเพิ่มข้อเสนอหรือความคิดเห็นต่อส่วนประกอบของสไลด์โดยไม่แก้ไขเนื้อหาหลักได้แต่ละคอมเมนต์จะแสดงชื่อผู้เขียน ทำให้ง่ายต่อการติดตามว่าใครเป็นผู้ทิ้งข้อคิดเห็น

สมมติว่ามีงานนำเสนอ PowerPoint ดังต่อไปนี้ที่บันทึกไว้ในไฟล์ "sample.pptx" file.

![คอมเมนต์สองรายการบนสไลด์ของงานนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้ง่ายว่าต้องการรวมคอมเมนต์จากงานนำเสนอไว้ในเอกสารผลลัพธ์หรือไม่ เพื่อทำเช่นนี้คุณต้องกำหนดพารามิเตอร์การแสดงคอมเมนต์ในเมธอด `get_NotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/) 

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 โดยแสดงคอมเมนต์ทางด้านขวาของสไลด์
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

ไฟล์ "output.html" แสดงในภาพด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าการเคลื่อนที่ของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5?**

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [slide transitions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animatetransitions/)  

**การส่งออกคอมเมนต์สนับสนุนหรือไม่และสามารถวางตำแหน่งคอมเมนต์สัมพันธ์กับสไลด์ได้ที่ไหน?**

ใช่, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่านการตั้งค่าการจัดวางสำหรับโน้ตและคอมเมนต์  

**ฉันสามารถข้ามลิงก์ที่เรียก JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ใช่, มี [setting](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) ที่ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด  