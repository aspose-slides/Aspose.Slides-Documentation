---
title: แปลงการนำเสนอเป็น HTML5 ด้วย Python ผ่าน Java
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML5 ที่ตอบสนองต่ออุปกรณ์ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. รักษาการจัดรูปแบบ การเคลื่อนไหว และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงไฟล์งานนำเสนอ PowerPoint เป็น HTML5 ด้วย Aspose.Slides ครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บเพิ่มเติม พร้อมตัวเลือกสำหรับการควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออก PowerPoint ไปยัง HTML มาตรฐาน สาธิตการสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และอธิบายวิธีใส่คอมเมนต์ลงในเอกสารที่ส่งออกโดยกำหนดค่าเลเอาท์ของคอมเมนต์

ตัวอย่างต้องใช้ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ วางไฟล์ `pres.pptx` (หรือ `sample.pptx` สำหรับตัวอย่างคอมเมนต์) ไว้ในไดเรกทอรีทำงานปัจจุบัน แต่ละตัวอย่างจะเริ่ม JVM เฉพาะเมื่อยังไม่ได้รัน

## **ส่งออก PowerPoint เป็น HTML5**

ใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) กับ [SaveFormat.Html5](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Html5) เพื่อส่งออกงานนำเสนอโดยไม่มีส่วนขยายเว็บเพิ่มเติม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="หมายเหตุ" %}} 
โปรแกรมส่งออก HTML5 จะสร้างเนื้อหา HTML สำหรับการแสดงผลในเบราว์เซอร์ 
{{% /alert %}}

ใช้ [Html5Options](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/) เพื่อตั้งค่าการส่งออก เรียกใช้ [setAnimateShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateShapes) และ [setAnimateTransitions](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateTransitions) ด้วยค่า `False` เพื่อปิดการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **ส่งออก PowerPoint เป็น HTML**

ใช้ [SaveFormat.Html](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Html) สำหรับการส่งออก HTML มาตรฐาน ดูรายละเอียดเพิ่มเติมที่ [Convert PowerPoint to HTML](/slides/th/python-java/convert-powerpoint-to-html/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

ในกรณีนี้ เนื้อหาในงานนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังต่อไปนี้:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="คำเตือน" color="warning" %}} 
การส่งออก HTML มาตรฐานจะเรนเดอร์เนื้อหาสไลด์ผ่าน SVG และไม่ให้ตัวเลือกการเคลื่อนไหวของรูปร่างหรือการเปลี่ยนสไลด์ในรูปแบบ HTML5 
{{% /alert %}}

## **ส่งออก PowerPoint เป็น HTML5 แบบมุมมองสไลด์**

**Aspose.Slides** ทำให้คุณสามารถแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 ที่สไลด์จะถูกแสดงในโหมดมุมมองสไลด์ เมื่อเปิดไฟล์ HTML5 ที่ได้ในเบราว์เซอร์ คุณจะเห็นการนำเสนอในโหมดมุมมองสไลด์บนหน้าเว็บ

โค้ด Python ตัวอย่างนี้สาธิตกระบวนการส่งออก PowerPoint ไปเป็น HTML5 แบบมุมมองสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **แปลงการนำเสนอเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คอมเมนต์ใน PowerPoint เป็นเครื่องมือที่ช่วยให้ผู้ใช้สามารถทิ้งบันทึกหรือข้อเสนอแนะบนสไลด์ได้ โดยเฉพาะอย่างยิ่งในการทำงานร่วมกันหลายคนที่สามารถเพิ่มข้อเสนอหรือข้อคิดเห็นต่อองค์ประกอบของสไลด์โดยไม่ต้องแก้ไขเนื้อหาหลัก คอมเมนต์แต่ละรายการจะแสดงชื่อผู้เขียน ทำให้ติดตามได้ว่าใครเป็นผู้ทิ้งข้อคิดเห็น

ให้สมมติว่าเรามีไฟล์งานนำเสนอ PowerPoint ชื่อ “sample.pptx”

![สองคอมเมนต์บนสไลด์การนำเสนอ](two_comments_pptx.png)

เมื่อคุณแปลงงานนำเสนอ PowerPoint เป็นเอกสาร HTML5 สามารถระบุได้ว่าจะใส่คอมเมนต์จากงานนำเสนอลงในเอกสารผลลัพธ์หรือไม่ ทำได้โดยส่งพารามิเตอร์การแสดงผลของคอมเมนต์ไปยังเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) ของคลาส [Html5Options](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/)

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) และ [setCommentsPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) พร้อมกับ [CommentsPositions.Right](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentspositions/#Right) ตัวอย่างโค้ดต่อไปนี้จะแปลงงานนำเสนอเป็นเอกสาร HTML5 โดยแสดงคอมเมนต์ที่อยู่ด้านขวาของสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

เอกสาร “output.html” แสดงในภาพด้านล่าง

![คอมเมนต์ในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**  
ใช่, HTML5 มีตัวเลือกแยกต่างหากให้เปิดหรือปิด [shape animations](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateShapes) และ [slide transitions](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateTransitions)

**การสนับสนุนการแสดงคอมเมนต์เป็นอย่างไร และสามารถวางคอมเมนต์ได้ตำแหน่งใดบ้าง relative to สไลด์?**  
ใช่, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ด้านขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) สำหรับโน้ตและคอมเมนต์

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**  
ใช่, มี [setting](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ที่ช่วยให้ข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ในระหว่างการบันทึก ซึ่งจะลบไฮเปอร์ลิงก์เหล่านั้นออก แต่ไม่ได้รับประกันโดยตรงว่าสคริปต์ HTML5 ทั้งหมดที่สร้างขึ้นจะสอดคล้องกับ Content Security Policy ของเว็บไซต์.