---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน Python ผ่าน Java
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/python-java/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF ไปยังการนำเสนอ
- PDF ไปยัง PPT
- PDF ไปยัง PPTX
- PDF ไปยัง ODP
- HTML ไปยังการนำเสนอ
- HTML ไปยัง PPT
- HTML ไปยัง PPTX
- HTML ไปถึง ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีนำเข้าข้อมูล PDF และ HTML ไปยังการนำเสนอ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides และบันทึกผลลัพธ์เป็นไฟล์ PPTX"
---
## **บทนำ**

Aspose.Slides for Python via Java สามารถแปลงหน้า PDF หรือเนื้อหา HTML ให้เป็นสไลด์ PowerPoint ได้โดยไม่ต้องใช้ Microsoft PowerPoint. คลาส [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) มีเมธอด [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) และ [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) เพื่อเพิ่มเนื้อหาที่นำเข้าไปยังงานนำเสนอ

หากต้องการควบคุมการวางตำแหน่ง HTML มากขึ้น, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) สามารถแทรกสไลด์ที่สร้างขึ้นตามตำแหน่งในคอลเลกชันหรือเริ่มเติมพื้นที่ว่างบนสไลด์ที่มีอยู่ได้. HTML ยาวจะถูกแบ่งหน้าเป็นสไลด์เพิ่มเติมโดยอัตโนมัติ, แหล่งข้อมูลสามารถส่งเป็นสตริงหรือสตรีมได้, และแอสเซ็ตภายนอกสามารถโหลดผ่าน [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) โดยกำหนด base URI. อาร์เรย์ [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) ที่คืนค่าจะบ่งบอกสไลด์ที่ได้รับผลกระทบและสไลด์ใหม่ที่สร้างขึ้น

## **การนำเข้าจาก PDF**

เพื่อแปลงเอกสาร PDF ให้เป็นงานนำเสนอ PowerPoint, ให้นำเข้เนื้อหาเข้าไปในคอลเลกชันสไลด์และบันทึกผลลัพธ์เป็นไฟล์ PPTX

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ใหม่
2. เรียกเมธอด [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) พร้อมเส้นทางไฟล์ PDF
3. เรียกเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) เพื่อบันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่าง Python ด้านล่างนำเข้าเอกสาร PDF และบันทึกสไลด์ที่สร้างเป็นงานนำเสนอ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สไลด์เปล่ามาตรฐานยังคงอยู่ในงานนำเสนอเนื่องจากการนำเข้าเพิ่มสไลด์ต่อท้าย. หากต้องการให้มีเพียงหน้าที่นำเข้าเท่านั้น, ให้ล้างคอลเลกชันสไลด์ด้วย [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) ก่อนทำการนำเข้า

เมธอด [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) จะคืนค่าสไลด์ที่เพิ่มเข้ามา ซึ่งมีประโยชน์เมื่อคุณต้องการประมวลผลเฉพาะสไลด์ที่นำเข้า

{{% alert title="Tip" color="success" %}}
ลองใช้แอปเว็บฟรี [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) เพื่อดูขั้นตอนการแปลงนี้ทำงานอย่างไร
{{% /alert %}}

## **การนำเข้าจาก HTML**

Aspose.Slides ยังสามารถสร้างสไลด์จากเอกสาร HTML ได้. แหล่งข้อมูลสามารถส่งเป็นข้อความ HTML หรือสตรีม. ตัวอย่างต่อไปนี้ใช้ไฟล์สตรีม:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ใหม่
2. เปิดไฟล์ HTML เพื่ออ่านและส่งสตรีมไปยังเมธอด [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml)
3. เรียกเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) เพื่อบันทึกผลลัพธ์เป็นไฟล์ PPTX

ตัวอย่าง Python ด้านล่างนำเข้าเอกสาร HTML และบันทึกสไลด์ที่สร้างเป็นงานนำเสนอ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แทรกเนื้อหา HTML**

ใช้ [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) เมื่อสไลด์ที่สร้างจาก HTML ต้องวางในตำแหน่งเฉพาะแทนการเพิ่มต่อท้าย. ดัชนีเริ่มจากศูนย์และระบุตำแหน่งที่การนำเข้าจะเริ่มต้น

พารามิเตอร์ `useSlideWithIndexAsStart` ควบคุมวิธีที่ตัวนำเข้าใช้ตำแหน่งนั้น:

- หากเป็น `False` ตัวนำเข้าจะสร้างสไลด์ใหม่ที่ตำแหน่งที่ระบุและเลื่อนสไลด์ที่ตามมาท้าย
- หากเป็น `True` ตัวนำเข้าจะเริ่มวางเนื้อหาในพื้นที่ว่างของสไลด์ที่มีอยู่ที่ตำแหน่งนั้น. หาก HTML ไม่พอดี, Aspose.Slides จะแบ่งหน้าอัตโนมัติและแทรกสไลด์เพิ่มทันทีหลังสไลด์เริ่มต้น

เมธอด [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) จะคืนอาร์เรย์ของอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) เมื่อการแทรกเริ่มที่สไลด์ใหม่, รายการที่คืนค่าทั้งหมดจะเป็นสไลด์ที่สร้างใหม่. หากใช้สไลด์ที่มีอยู่เป็นจุดเริ่มต้น, อาร์เรย์จะรวมสไลด์ที่ได้รับผลกระทบและสไลด์ที่เพิ่มจากการล้น. คุณสามารถตรวจสอบอาร์เรย์นี้แทนการคำนวณช่วงที่ได้รับผลกระทบจากจำนวนสไลด์ของงานนำเสนอ

### **แทรก HTML เป็นสไลด์ใหม่**

ตัวอย่างต่อไปนี้ส่ง HTML เป็นสตริงและแทรกสไลด์ที่สร้างที่ดัชนีคอลเลกชัน `1`. การส่งค่า `False` จะทำให้สไลด์ที่มีอยู่คงเดิมเพียงแค่เลื่อนตำแหน่งเพื่อให้มีที่ว่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เริ่มที่สไลด์ที่มีอยู่**

ตัวอย่างต่อไปนี้ส่ง HTML ผ่านสตรีม. มันรักษา Shape ส่วนหัวบนสไลด์เทมเพลตที่มีอยู่, เริ่มนำเข้าตำแหน่งด้านล่างพื้นที่ที่ถูกใช้, และให้เนื้อหายาวต่อเนื่องไปยังสไลด์ใหม่

HTML ยังมี URL ของรูปภาพแบบ relative. [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) จะดึงแหล่งข้อมูล, ในขณะที่ base URI จะบอกตัวนำเข้าให้แก้ไข `images/logo.png`. ในตัวอย่างนี้ไฟล์ดังกล่าวคาดว่าจะอยู่ที่ `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
ตัวแก้ไขแหล่งข้อมูลภายนอกที่ไม่มีข้อจำกัดสามารถอ่านแหล่งข้อมูลแบบโลคัลหรือเครือข่ายที่อ้างอิงจาก HTML ได้. สำหรับอินพุตที่ไม่เชื่อถือ, ควรตรวจสอบและทำความสะอาด URL ของแหล่งข้อมูลโดยอ้างอิงจากรายการอนุญาตของสคีม, ไดเรกทอรีและโฮสต์ที่อนุญาตก่อนทำการนำเข้า HTML
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถตรวจจับตารางเมื่อทำการนำเข้าจาก PDF ได้หรือไม่?**

ได้. สร้างอ็อบเจ็กต์ [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/), เรียกเมธอด [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) ด้วยค่า `True`, แล้วส่งตัวเลือกไปยังเมธอด [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf). คุณภาพของการจดจำตารางขึ้นอยู่กับโครงสร้างและความซับซ้อนของ PDF ต้นฉบับ

{{% alert title="Note" color="info" %}}
หลังจากนำเข้า HTML แล้ว คุณยังสามารถส่งออกสไลด์เป็น [images](/slides/th/python-java/convert-powerpoint-to-png/), [TIFF](/slides/th/python-java/convert-powerpoint-to-tiff/), หรือ [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/) ได้เช่นกัน
{{% /alert %}}