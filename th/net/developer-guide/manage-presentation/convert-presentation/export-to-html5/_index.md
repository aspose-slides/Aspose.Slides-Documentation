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
description: "ส่งออกงานนำเสนอ PowerPoint & OpenDocument ไปเป็น HTML5 ที่ตอบสนองต่ออุปกรณ์ด้วย Aspose.Slides สำหรับ .NET. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น HTML5 โดยใช้ Aspose.Slides โดยครอบคลุมการส่งออก HTML5 เบื้องต้นโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ บทความยังแสดงขั้นตอนการส่งออกมาตรฐานจาก PowerPoint ไปเป็น HTML การอธิบายวิธีสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีใส่คอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดรูปแบบการแสดงผลของคอมเมนต์

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด C# นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
ในกรณีนี้ คุณจะได้ HTML ที่สะอาด
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ดังนี้:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **ส่งออก PowerPoint เป็น HTML**

โค้ด C# นี้แสดงกระบวนการส่งออกมาตรฐานจาก PowerPoint ไปเป็น HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

ในกรณีนี้ เนื้อหาของงานนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังนี้:

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
เมื่อคุณใช้วิธีนี้ในการส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำให้ชิ้นส่วนเฉพาะเคลื่อนไหวได้
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 โหมดมุมมองสไลด์**

**Aspose.Slides** ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่แสดงสไลด์ในโหมดมุมมองสไลด์ ในกรณีนี้ เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ

โค้ด C# นี้แสดงกระบวนการส่งออก PowerPoint ไปเป็น HTML5 โหมดมุมมองสไลด์:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถฝากบันทึกหรือข้อเสนอแนะลงบนสไลด์งานนำเสนอได้ มีประโยชน์โดยเฉพาะในโครงการที่ทำร่วมกันที่หลายคนสามารถเพิ่มข้อเสนอแนะหรือหมายเหตุในองค์ประกอบของสไลด์โดยไม่แก้ไขเนื้อหาหลัก แต่ละคอมเมนต์จะแสดงชื่อผู้เขียน ทำให้ง่ายต่อการติดตามว่าใครเป็นผู้ทิ้งข้อสังเกตนั้น

สมมติว่าเรามีงานนำเสนอ PowerPoint ต่อไปนี้ที่บันทึกไว้ในไฟล์ "sample.pptx"

![สองคอมเมนต์บนสไลด์งานนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 คุณสามารถระบุได้ว่าอยากรวมคอมเมนต์จากงานนำเสนอในเอกสารผลลัพธ์หรือไม่ เพื่อทำเช่นนี้คุณต้องระบุพารามิเตอร์การแสดงผลของคอมเมนต์ในคุณสมบัติ `NotesCommentsLayouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/) 

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์ที่แสดงทางด้านขวาของสไลด์

```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

เอกสาร "output.html" แสดงในภาพด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ที่ได้](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**

ใช่, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิดการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ [shape animations](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animateshapes/) และ [slide transitions](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animatetransitions/)

**การรองรับการแสดงคอมเมนต์เป็นอย่างไร และสามารถวางคอมเมนต์ไว้ตำแหน่งใดสัมพันธ์กับสไลด์ได้บ้าง?**

ใช่, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/notescommentslayouting/) สำหรับโน๊ตและคอมเมนต์

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ใช่, มี [setting](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ที่ช่วยให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียกใช้ JavaScript ระหว่างการบันทึก ซึ่งช่วยปฏิบัติตามนโยบายความปลอดภัยที่เข้มงวด