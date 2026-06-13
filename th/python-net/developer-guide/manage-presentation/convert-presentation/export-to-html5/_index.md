---
title: แปลงงานนำเสนอเป็น HTML5 ด้วย Python
linktitle: ส่งออกเป็น HTML5
type: docs
weight: 40
url: /th/python-net/export-to-html5/
keywords:
- PowerPoint เป็น HTML5
- OpenDocument เป็น HTML5
- งานนำเสนอเป็น HTML5
- สไลด์เป็น HTML5
- PPT เป็น HTML5
- PPTX เป็น HTML5
- ODP เป็น HTML5
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- การส่งออก HTML5
- ส่งออกงานนำเสนอ
- ส่งออกสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 ที่ตอบสนองด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น HTML5 ด้วย Aspose.Slides รวมถึงการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับควบคุมการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออกมาตรฐานจาก PowerPoint ไปยัง HTML อธิบายวิธีสร้างเอาต์พุต HTML5 ในโหมดการดูสไลด์ และสาธิตวิธีรวมคอมเมนต์ในเอกสารที่ส่งออกโดยกำหนดค่าเลย์เอาต์ของคอมเมนต์

## **ส่งออก PowerPoint เป็น HTML5**

โค้ด Python นี้แสดงวิธีส่งออกงานนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
ในกรณีนี้คุณจะได้ HTML ที่สะอาด 
{{% /alert %}}

คุณอาจต้องการกำหนดการตั้งค่าสำหรับการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ด้วยวิธีนี้:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **ส่งออก PowerPoint เป็น HTML**

โค้ด Python นี้สาธิตกระบวนการมาตรฐานจาก PowerPoint ไปยัง HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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
เมื่อคุณใช้วิธีนี้เพื่อส่งออก PowerPoint เป็น HTML เนื่องจากการเรนเดอร์ด้วย SVG คุณจะไม่สามารถใช้สไตล์หรือทำอนิเมชันให้กับองค์ประกอบเฉพาะได้ 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 Slide View**

**Aspose.Slides** ให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 ที่สไลด์จะแสดงในโหมดการดูสไลด์ ในกรณีนี้เมื่อคุณเปิดไฟล์ HTML5 ที่ได้ในเว็บเบราว์เซอร์ คุณจะเห็นงานนำเสนอในโหมดการดูสไลด์บนหน้าเว็บ

โค้ด Python นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML5 Slide View:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # ส่งออกงานนำเสนอที่มีการเปลี่ยนสไลด์, การเคลื่อนไหว, และการเคลื่อนไหวของรูปทรงเป็น HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # บันทึกงานนำเสนอ
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถทิ้งบันทึกหรือข้อคิดเห็นบนสไลด์งานนำเสนอได้ ซึ่งเป็นประโยชน์อย่างยิ่งในโครงการแบบร่วมมือ ที่หลายคนสามารถเพิ่มข้อเสนอหรือข้อสังเกตลงในองค์ประกอบสไลด์เฉพาะโดยไม่กระทบต่อเนื้อหาหลัก ทุกคอมเมนต์จะแสดงชื่อผู้เขียน ทำให้ติดตามว่าใครเป็นผู้ทิ้งข้อสังเกตได้ง่าย

สมมติว่าเรามีงานนำเสนอ PowerPoint ที่บันทึกในไฟล์ “sample.pptx”

![Two comments on the presentation slide](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint ไปเป็นเอกสาร HTML5 คุณสามารถระบุได้ว่าจะรวมคอมเมนต์จากงานนำเสนอในเอกสารผลลัพธ์หรือไม่ เพื่อทำเช่นนี้คุณต้องกำหนดพารามิเตอร์การแสดงผลของคอมเมนต์ในคุณสมบัติ `notes_comments_layouting` ของคลาส [Html5Options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/)

ตัวอย่างโค้ดต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์ที่แสดงทางด้านขวาของสไลด์
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

เอกสาร “output.html” แสดงในภาพด้านล่าง

![The comments in the output HTML5 document](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะทำงานใน HTML5 หรือไม่?**

ได้, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/animate_shapes/) และ [slide transitions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/animate_transitions/)

**การสนับสนุนการแสดงคอมเมนต์มีหรือไม่ และสามารถวางคอมเมนต์ relative to สไลด์ได้อย่างไร?**

ได้, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น อยู่ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/notes_comments_layouting/) สำหรับบันทึกและคอมเมนต์

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript ด้วยเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ได้, มี [setting](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/skip_java_script_links/) ที่ช่วยให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียกใช้ JavaScript ระหว่างการบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด