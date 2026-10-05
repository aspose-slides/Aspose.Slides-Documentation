---
title: แปลงงานนำเสนอเป็น HTML5 ใน .NET
linktitle: งานนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 ที่ตอบสนองพร้อม Aspose.Slides สำหรับ .NET. รักษาการจัดรูปแบบ, แอนิเมชันและการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides สำหรับ .NET ซึ่งครอบคลุมการส่งออกพื้นฐาน การควบคุมแอนิเมชันของรูปทรงและการเปลี่ยนสไลด์ รวมถึงรูปแบบการแสดงความคิดเห็น นอกจากนี้ยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์แบบ SVG ของการส่งออก HTML มาตรฐาน

## **ส่งออก PowerPoint เป็น HTML5**

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและบันทึกเป็นรูปแบบ HTML5 โดยใช้การตั้งค่าส่งออกค่าเริ่มต้น ตัวอย่างต่อมาจะแสดงวิธีควบคุมการเล่นแอนิเมชันอย่างชัดเจน ให้แทนที่เส้นทางอินพุตด้วยเส้นทางไปยังงานนำเสนอของคุณ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
นอกจากเอกสาร HTML แล้ว การส่งออกจะเขียนไฟล์ CSS และ JavaScript ที่สนับสนุนสำหรับการจัดรูปแบบสไลด์, แอนิเมชัน, เอฟเฟกต์และการนำทาง ให้เก็บไฟล์เหล่านี้ไว้พร้อมกับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเว็บที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และแอนิเมชันจะไม่ทำงาน
{{% /alert %}}

หากต้องการส่งออกโดยไม่เล่นแอนิเมชันของรูปทรงหรือการเปลี่ยนสไลด์ ให้ตั้งค่า [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) และ [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) เป็น `false` ใน [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). การตั้งค่าเหล่านี้เป็นอิสระกัน ดังนั้นคุณสามารถเปิดใช้งานหนึ่งขณะที่ปิดการใช้งานอีกอันได้ ตัวอย่างนี้ส่งออกงานนำเสนอโดยปิดการใช้งานแอนิเมชันทั้งสองประเภทในหน้าที่สร้างขึ้น

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **ส่งออก PowerPoint เป็น HTML**

การส่งออก HTML มาตรฐานใช้วิธีการเรนเดอร์ที่แตกต่าง: เนื้อหาสไลด์จะถูกแทนด้วย SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้จะแปลงงานนำเสนอเป็นเอกสาร HTML โดยใช้วิธีการเรนเดอร์นี้

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

มาร์กอัปที่ง่ายขึ้นด้านล่างแสดงโครงสร้างของหน้าที่สร้างขึ้น ส่วนประกอบ SVG จะบรรจุเนื้อหาสไลด์ที่เรนเดอร์; ข้อความตัวอย่างแทนเนื้อหานั้นและไม่ได้เป็นผลลัพธ์การส่งออกจริง

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
การส่งออกแบบใช้ SVG ไม่ได้เปิดเผยรูปร่างของ PowerPoint เป็นองค์ประกอบ HTML แยกแต่ละอัน ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกแอนิเมชันของรูปร่างและการเปลี่ยนสไลด์ที่แสดงในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint เป็นมุมมองสไลด์ HTML5**

การส่งออก HTML5 สร้างหน้าที่ใช้ดูและนำทางสไลด์ของงานนำเสนอในเว็บเบราว์เซอร์ ตัวอย่างนี้เปิดใช้งานทั้ง [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) และ [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟกต์จากงานนำแหล่งต้นแบบได้
ใช้งานนำเสนอที่มีแอนิเมชันของรูปทรงและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานไม่ได้เพิ่มเอฟเฟกต์ใหม่ให้สไลด์ที่ไม่มี หลังจากส่งออกให้เปิดเอกสาร HTML5 ที่สร้างในเว็บเบราว์เซอร์พร้อมไฟล์สนับสนุน

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมความคิดเห็น**

คุณสามารถรวมความคิดเห็นของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะควบคู่กับเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดว่างานนำแหล่งต้นแบบมีความคิดเห็นตามที่แสดงด้านล่าง ซึ่งจะส่งออกความคิดเห็นเหล่านั้น; ไม่ได้สร้างความคิดเห็นใหม่

![สองความคิดเห็นบนสไลด์งานนำเสนอ](two_comments_pptx.png)

กำหนดวัตถุ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับคุณสมบัติ [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) ของ [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). ตั้งค่า [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) เป็น `Right` จากการนับจำนวน [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) เพื่อวางความคิดเห็นทางด้านขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น HTML5 พร้อมรูปแบบความคิดเห็นนี้ งานนำเสนอที่ไม่มีความคิดเห็นจะไม่มีข้อความความคิดเห็นให้แสดง

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

ภาพด้านล่างแสดงเอกสาร HTML5 ที่ส่งออกพร้อมความคิดเห็นที่แสดงอยู่ข้างสไลด์

![ความคิดเห็นในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก**

สมมติว่า `hyperlinks.pptx` มีข้อความที่เชื่อมโยงกับเป้าหมาย `javascript:alert('Hello')` และลิงก์ธรรมดา `https://example.com/`. เพื่อลบไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก ให้ตั้งค่า [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) เป็น `true`. ค่าเริ่มต้นคือ `false` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองจนกว่าคุณจะเปิดใช้งานตัวเลือกนี้

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

ไฟล์ที่ส่งออกจะละเว้นไฮเปอร์ลิงก์ JavaScript แต่ยังคงข้อความของมันและลิงก์ HTTPS ธรรมดไว้ งานนำแหล่งต้นแบบไม่เปลี่ยนแปลง

ตัวเลือกนี้กรองไฮเปอร์ลิงก์ JavaScript; ไม่ได้ลบสคริปต์ทั้งหมดหรือเนื้อหาแอคทีฟอื่น ๆ และไม่รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังคงมีสคริปต์สำหรับการนำทางสไลด์และแอนิเมชัน

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าแอนิเมชันของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5?**  
ได้, การส่งออก HTML5 มีตัวเลือกแยกกันเพื่อเปิดหรือปิด [แอนิเมชันรูปทรง](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) และ [การเปลี่ยนสไลด์](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**ความคิดเห็นได้รับการสนับสนุนหรือไม่, และสามารถวางตำแหน่งอย่างไรเมื่อเทียบกับสไลด์?**  
ใช่, ความคิดเห็นที่มีอยู่สามารถรวมในผลลัพธ์ HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [การตั้งค่าเลย์เอาต์](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) สำหรับโน้ตและความคิดเห็น.

**ฉันสามารถละเว้นลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**  
ได้, การตั้งค่า [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ทำให้คุณสามารถละเว้นไฮเปอร์ลิงก์ที่เรียก JavaScript ระหว่างการบันทึก ค่าเริ่มต้นคือ `false`. ดู [การยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก](/slides/th/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) สำหรับตัวอย่างการส่งออก HTML, HTML5, และ PDF อย่างง่ายและขอบเขตของการกรอง ตัวเลือกนี้ไม่ลบ JavaScript ที่ผู้ชม HTML5 ใช้สำหรับการนำทางและแอนิเมชัน.