---
title: แปลงงานนำเสนอเป็น HTML5 ด้วย Python
linktitle: งานนำเสนอเป็น HTML5
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
- บันทึก PPT เป็น HTML5
- บันทึก PPTX เป็น HTML5
- บันทึก ODP เป็น HTML5
- ส่งออก PPT เป็น HTML5
- ส่งออก PPTX เป็น HTML5
- ส่งออก ODP เป็น HTML5
- Python
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. รักษาการจัดรูปแบบ, การเคลื่อนไหว และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น HTML5 โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET ครอบคลุมการส่งออกพื้นฐาน การควบคุมการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ รวมถึงการจัดวางความคิดเห็น นอกจากนี้ยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์รูปแบบ SVG ของการส่งออก HTML ปกติ

## **ส่งออก PowerPoint เป็น HTML5**

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและบันทึกเป็นรูปแบบ HTML5  
มันใช้การตั้งค่าการส่งออกเริ่มต้น; ตัวอย่างต่อไปจะแสดงวิธีควบคุมการเล่นอนิเมชันอย่างชัดเจน  
แทนที่เส้นทางอินพุตด้วยเส้นทางไปยังงานนำเสนอของคุณ

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
นอกจากเอกสาร HTML แล้ว การส่งออกยังเขียนไฟล์ CSS และ JavaScript รองรับสำหรับการจัดรูปแบบสไลด์, การเคลื่อนไหว, เอฟเฟกต์และการนำทาง เก็บไฟล์เหล่านี้ไว้กับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเว็บที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และการเคลื่อนไหวจะไม่ทำงาน
{{% /alert %}}

เพื่อส่งออกโดยไม่เล่นการเคลื่อนไหวของรูปทรงหรือการเปลี่ยนสไลด์ ให้ตั้งค่า [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) และ [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) เป็น `False` ใน [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) การตั้งค่าเหล่านี้เป็นอิสระต่อกัน ดังนั้นคุณสามารถเปิดใช้งานอันหนึ่งได้โดยปิดอีกอันหนึ่ง ตัวอย่างนี้ส่งออกงานนำเสนอพร้อมการเคลื่อนไหวทั้งสองประเภทถูกปิดในหน้าที่สร้างขึ้น

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **ส่งออก PowerPoint เป็น HTML**

การส่งออก HTML มาตรฐานใช้แนวทางการเรนเดอร์ที่ต่างออกไป: เนื้อหาสไลด์ถูกแทนด้วย SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML ด้วยแนวทางการเรนเดอร์นี้

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

การทำเครื่องหมายแบบง่ายด้านล่างแสดงโครงสร้างของหน้าที่สร้างขึ้น องค์ประกอบ SVG มีเนื้อหาของสไลด์ที่เรนเดอร์; ข้อความตัวอย่างเป็นเพียงการแทนที่และไม่ใช่ผลลัพธ์การส่งออกจริง

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
การส่งออกแบบใช้ SVG ไม่ได้เปิดเผยรูปร่าง PowerPoint เป็นองค์ประกอบ HTML แยกส่วน ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ที่แสดงในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint เป็นมุมมองสไลด์ HTML5**

การส่งออก HTML5 ผลิตหน้าที่ใช้ดูและนำทางสไลด์งานนำเสนอในเบราว์เซอร์ ตัวอย่างนี้เปิดใช้งานทั้ง [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) และ [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟกต์จากงานนำเสนอแหล่งต้นได้

ใช้งานนำเสนอที่มีการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานจะไม่เพิ่มเอฟเฟกต์ใหม่ให้สไลด์ที่ไม่มีเอฟเฟกต์ หลังการส่งออก ให้เปิดเอกสาร HTML5 ที่สร้างขึ้นในเบราว์เซอร์พร้อมไฟล์สนับสนุนที่พร้อมใช้งาน

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมความคิดเห็น**

คุณสามารถรวมความคิดเห็นของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะพร้อมกับเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดหวังว่างานนำแหล่งจะมีความคิดเห็นตามที่แสดงด้านล่าง การส่งออกจะนำความคิดเห็นเหล่านั้นออกมา; ไม่ได้สร้างความคิดเห็นใหม่

![สองความคิดเห็นบนสไลด์งานนำเสนอ](two_comments_pptx.png)

กำหนดอ็อบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับคุณสมบัติ [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) ของ [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) ตั้งค่า [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) เป็น `RIGHT` จากการนับ [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) เพื่อวางความคิดเห็นทางด้านขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น HTML5 พร้อมการจัดวางความคิดเห็นนี้ งานนำเสนอที่ไม่มีความคิดเห็นจะไม่มีข้อความความคิดเห็นให้แสดง

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![ความคิดเห็นในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก**

สมมติว่า `hyperlinks.pptx` มีข้อความลิงก์ที่เป้าหมายเป็น `javascript:alert('Hello')` และลิงก์ `https://example.com/` ปกติ เพื่อยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก ให้ตั้งค่า [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) เป็น `True` ค่าเริ่มต้นคือ `False` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองจนกว่าคุณจะเปิดใช้ตัวเลือกนี้

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

ไฟล์ที่ส่งออกจะละเว้นไฮเปอร์ลิงก์ JavaScript แต่ยังคงข้อความของมันและลิงก์ HTTPS ปกติ งานนำแหล่งไม่ได้ถูกเปลี่ยนแปลง

ตัวเลือกนี้กรองไฮเปอร์ลิงก์ JavaScript; มันไม่ลบสคริปต์ทั้งหมดหรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังรวมสคริปต์สำหรับการนำทางสไลด์และการเคลื่อนไหว

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**  
ใช่, การส่งออก HTML5 มีตัวเลือกแยกกันเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) และ [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)

**ความคิดเห็นรองรับหรือไม่ และสามารถวางตำแหน่งใดสัมพันธ์กับสไลด์?**  
ใช่, ความคิดเห็นที่มีอยู่สามารถรวมในผลลัพธ์ HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/)

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อความปลอดภัยหรือเหตุผลของ CSP ได้หรือไม่?**  
ใช่, การตั้งค่า [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) ช่วยให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ขณะบันทึก ค่าเริ่มต้นคือ `False` ดู [Exclude JavaScript Hyperlinks During Export](/slides/th/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) สำหรับตัวอย่างการส่งออก HTML5 และขอบเขตของฟิลเตอร์ ตัวเลือกนี้ไม่ลบ JavaScript ที่ใช้โดยตัวดู HTML5 สำหรับการนำทางและการเคลื่อนไหว