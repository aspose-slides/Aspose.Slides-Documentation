---
title: แปลงการนำเสนอเป็น HTML5 ใน .NET
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint & OpenDocument เป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ .NET. คงรูปแบบ, การเคลื่อนไหว, และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงการนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides ครอบคลุมการส่งออก HTML5 เบื้องต้น รวมถึงตัวเลือกสำหรับการควบคุมการเคลื่อนที่ของรูปทรงและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออก PowerPoint ไปเป็น HTML มาตรฐาน อธิบายวิธีการสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีการรวมความคิดเห็นในเอกสารที่ส่งออกโดยการกำหนดการจัดวาง

## **ส่งออก PowerPoint ไปเป็น HTML5**

This C# code shows how to export a presentation to HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

นอกเหนือจากเอกสาร HTML การส่งออกยังเขียนไฟล์สนับสนุนที่อ้างอิงไว้: `pres.css`, `master.css`, `animation.js`, `effects.js`, และ `navigation.js` หน้าเว็บที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และการเคลื่อนที่จะไม่ทำงาน 

{{% /alert %}}

คุณอาจต้องการระบุตั้งค่าเพื่อควบคุมการเคลื่อนที่ของรูปทรงและการเปลี่ยนสไลด์ตามนี้:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **ส่งออก PowerPoint ไปเป็น HTML**

This C# demonstrates the standard PowerPoint to HTML process:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

ในกรณีนี้ เนื้อหาการนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังนี้:

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

เมื่อคุณใช้วิธีนี้ในการส่งออก PowerPoint ไปเป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ส่วนประกอบเฉพาะเคลื่อนที่ได้ 

{{% /alert %}}

## **ส่งออก PowerPoint ไปเป็น HTML5 แบบมุมมองสไลด์**

**Aspose.Slides** อนุญาตให้คุณแปลงการนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์แสดงในโหมดมุมมองสไลด์ ในกรณีนี้ เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นการนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ 

This C# code demonstrates the PowerPoint to HTML5 Slide View export process:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมความคิดเห็น**

ความคิดเห็นใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถทิ้งบันทึกหรือข้อเสนอแนะบนสไลด์การนำเสนอได้ มีประโยชน์อย่างยิ่งในโครงการที่ทำงานร่วมกัน ซึ่งหลายคนสามารถเพิ่มคำแนะนำหรือข้อสังเกตลงในองค์ประกอบของสไลด์โดยไม่ต้องแก้ไขเนื้อหาหลัก ความคิดเห็นแต่ละรายการจะแสดงชื่อผู้เขียน ทำให้ติดตามว่าใครเป็นผู้ทิ้งข้อสังเกตได้ง่าย

สมมติว่าเรามีการนำเสนอ PowerPoint ที่บันทึกไว้ในไฟล์ **"sample.pptx"**.

![สองความคิดเห็นบนสไลด์การนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงการนำเสนอ PowerPoint เป็นเอกสาร HTML5 คุณสามารถระบุได้ว่าอยากรวมความคิดเห็นจากการนำเสนอไว้ในเอกสารผลลัพธ์หรือไม่ การทำเช่นนี้ต้องกำหนดพารามิเตอร์การแสดงผลสำหรับความคิดเห็นในคุณสมบัติ `NotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมแสดงความคิดเห็นที่ด้านขวามือของสไลด์
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

เอกสาร "output.html" ปรากฏในรูปด้านล่าง

![ความคิดเห็นในเอกสาร HTML5 ผลลัพธ์](two_comments_html5.png)

## **FAQ**

### ฉันสามารถควบคุมได้หรือไม่ว่าการเคลื่อนที่ของวัตถุและการเปลี่ยนสไลด์จะทำงานใน HTML5 หรือไม่?

ใช่ สามารถใช้ตัวเลือกแยกกันเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animateshapes/) และ [slide transitions](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animatetransitions/) ใน HTML5 ได้

### การสนับสนุนการแสดงผลความคิดเห็นมีหรือไม่ และสามารถวางตำแหน่งสัมพันธ์กับสไลด์ได้อย่างไร?

ใช่ ความคิดเห็นสามารถเพิ่มใน HTML5 และกำหนดตำแหน่ง (เช่น ด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/notescommentslayouting/) สำหรับบันทึกและความคิดเห็น

### ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?

ใช่ มี [setting](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ที่ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ซึ่งช่วยให้ปฏิบัติตามนโยบายความปลอดภัยที่เข้มงวดได้.