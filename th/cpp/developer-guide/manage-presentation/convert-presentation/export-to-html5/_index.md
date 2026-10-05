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
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 แบบตอบสนองด้วย Aspose.Slides สำหรับ C++. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงงานนำเสนอ PowerPoint เป็น HTML5 โดยใช้ Aspose.Slides for C++ ครอบคลุมการส่งออกพื้นฐาน การควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ รวมถึงการจัดวางคอมเมนต์ นอกจากนี้ยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์แบบ SVG ของการส่งออก HTML ปกติ

## **ส่งออก PowerPoint เป็น HTML5**

ตัวอย่างต่อไปนี้จะโหลดงานนำเสนอจากไดเรกทอรีการทำงานและบันทึกเป็นรูปแบบ HTML5 โดยใช้การตั้งค่าการส่งออกเริ่มต้น; ตัวอย่างต่อไปจะอธิบายวิธีควบคุมการเล่นอนิเมชันอย่างชัดเจน แทนที่เส้นทางไฟล์อินพุตด้วยเส้นทางไปยังงานนำเสนอของคุณ

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
นอกเหนือจากเอกสาร HTML แล้ว การส่งออกยังเขียนไฟล์ CSS และ JavaScript ที่สนับสนุนสำหรับการจัดรูปแบบสไลด์, การเคลื่อนไหว, เอฟเฟกต์และการนำทาง เก็บไฟล์เหล่านี้ไว้กับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเว็บที่สร้างยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และการเคลื่อนไหวยังไม่ทำงาน
{{% /alert %}}

หากต้องการส่งออกโดยไม่เล่นการเคลื่อนไหวของรูปร่างหรือการเปลี่ยนสไลด์ ให้ส่งค่า `false` ไปยัง [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) ใน [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) การตั้งค่าเหล่านี้เป็นอิสระกัน ดังนั้นคุณสามารถเปิดใช้งานหนึ่งส่วนในขณะที่ปิดอีกส่วนได้ ตัวอย่างนี้จะส่งออกงานนำเสนอโดยปิดการเคลื่อนไหวทั้งสองประเภทในหน้าเว็บที่สร้างขึ้น

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **ส่งออก PowerPoint เป็น HTML**

การส่งออก HTML ปกติใช้แนวทางการแสดงผลที่ต่างกัน: เนื้อหาสไลด์จะแสดงเป็น SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้จะแปลงงานนำเสนอเป็นเอกสาร HTML โดยใช้แนวทางการแสดงผลนี้

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

มาร์กอัปที่เรียบง่ายด้านล่างแสดงโครงสร้างของหน้าที่สร้างขึ้น ส่วนองค์ประกอบ SVG จะบรรจุเนื้อหาสไลด์ที่เรนเดอร์; ข้อความตัวอย่างจะแทนเนื้อหานั้นและไม่ใช่ผลลัพธ์การส่งออกจริง

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
การส่งออกแบบใช้ SVG จะไม่เปิดเผยรูปร่างของ PowerPoint เป็นองค์ประกอบ HTML แยกต่างหาก ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ตามที่แสดงในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint ไปยังมุมมองสไลด์ HTML5**

การส่งออก HTML5 จะสร้างหน้าเว็บสำหรับดูและนำทางสไลด์การนำเสนอในเบราว์เซอร์ ตัวอย่างนี้ส่งค่า `true` ไปยัง [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟกต์จากงานนำแหล่งต้นฉบับได้

ใช้งานนำเสนอที่มีการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานไม่ได้เพิ่มเอฟเฟกต์ใหม่ให้กับสไลด์ที่ไม่มีเอฟเฟกต์ หลังจากส่งออก ให้เปิดเอกสาร HTML5 ที่สร้างขึ้นในเบราว์เซอร์พร้อมไฟล์สนับสนุนที่พร้อมใช้งาน

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คุณสามารถรวมคอมเมนต์ของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะพร้อมกับเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดว่างานนำแหล่งต้นจะมีคอมเมนต์ตามที่แสดงด้านล่าง ซึ่งจะทำการส่งออกคอมเมนต์เหล่านั้นโดยไม่สร้างคอมเมนต์ใหม่

![คอมเมนต์สองรายการบนสไลด์งานนำเสนอ](two_comments_pptx.png)

ส่งอ็อบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) ไปยังเมธอด์ [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) ของ [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) จากนั้นเรียก [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) ด้วยค่า `CommentsPositions::Right` จาก enumeration [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) เพื่อวางคอมเมนต์ทางด้านขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้จะส่งออกงานนำเสนอเป็น HTML5 พร้อมเค้าโครงคอมเมนต์นี้ งานนำเสนอที่ไม่มีคอมเมนต์จะไม่มีข้อความคอมเมนต์ให้แสดง

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

ภาพด้านล่างแสดงเอกสาร HTML5 ที่ส่งออกพร้อมคอมเมนต์ที่แสดงอยู่ข้างสไลด์

![คอมเมนต์ในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ละเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก**

สมมุติว่า `hyperlinks.pptx` มีข้อความเชื่อมโยงที่มีเป้าหมาย `javascript:alert('Hello')` และลิงก์ธรรมดา `https://example.com/` หากต้องการละเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก ให้เรียก [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) ด้วยค่า `true` ค่าเริ่มต้นคือ `false` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองเว้นแต่คุณเปิดใช้ตัวเลือกนี้

ตัวอย่างต่อไปนี้จะโหลดงานนำเสนอจากไดเรกทอรีการทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

ไฟล์ที่ส่งออกจะละเว้นไฮเปอร์ลิงก์ JavaScript แต่ยังคงรักษาข้อความและลิงก์ HTTPS ธรรมดาไว้ งานนำแหล่งต้นจะไม่ถูกเปลี่ยนแปลง

ตัวเลือกนี้กรองไฮเปอร์ลิงก์ JavaScript; ไม่ได้ลบสคริปต์ทั้งหมดหรือเนื้อหาที่ทำงานอื่นๆ และไม่ได้รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังมีสคริปต์สำหรับการนำทางสไลด์และการเคลื่อนไหว

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าอนิเมชันของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**  
ใช่, การส่งออก HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)

**คอมเมนต์ได้รับการสนับสนุนหรือไม่, และสามารถวางตำแหน่งใดสัมพันธ์กับสไลด์?**  
ใช่, คอมเมนต์ที่มีอยู่สามารถรวมในผลลัพธ์ HTML5 และวางตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) สำหรับโน้ตและคอมเมนต์

**ฉันสามารถละเว้นลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**  
ใช่, เมธอด [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) ช่วยให้คุณละเว้นไฮเปอร์ลิงก์ที่มีการเรียกใช้ JavaScript ขณะบันทึก ค่าเริ่มต้นคือ `false` ดู [Exclude JavaScript Hyperlinks During Export](/slides/th/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) เพื่อดูตัวอย่างการส่งออก HTML5 และขอบเขตของฟิลเตอร์ ตัวเลือกนี้ไม่ได้ลบ JavaScript ที่ใช้โดยตัวดู HTML5 สำหรับการนำทางและการเคลื่อนไหว