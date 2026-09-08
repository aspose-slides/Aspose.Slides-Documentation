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
- HTML ไปยัง ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีนำเข้าเนื้อหา PDF และ HTML ไปยังการนำเสนอ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides และบันทึกผลลัพธ์เป็นไฟล์ PPTX."
---
## **บทนำ**

Aspose.Slides สำหรับ Python ผ่าน Java สามารถแปลงหน้าของ PDF หรือเนื้อหา HTML ให้เป็นสไลด์ PowerPoint โดยไม่ต้องใช้ Microsoft PowerPoint. คลาส [SlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) มีเมธอด [addFromPdf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromPdf) และ [addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromHtml) เพื่อเพิ่มเนื้อหาที่นำเข้าลงในงานนำเสนอ.

หากต้องการควบคุมตำแหน่งของ HTML มากขึ้น, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertFromHtml) สามารถแทรกสไลด์ที่สร้างขึ้นได้ที่ตำแหน่งดัชนีของคอลเลกชันหรือเริ่มเติมพื้นที่ที่มีอยู่บนสไลด์เดิม. HTML ที่ยาวจะถูกแบ่งหน้าเป็นสไลด์เพิ่มเติมโดยอัตโนมัติ, แหล่งข้อมูลสามารถส่งเป็นสตริงหรือสตรีม, และทรัพยากรภายนอกสามารถโหลดผ่าน [ExternalResourceResolver](https://reference.aspose.com/slides/th/python-java/aspose.slides/externalresourceresolver/) พร้อม Base URI. อาร์เรย์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ที่คืนค่าจะแสดงสไลด์ที่ได้รับผลกระทบและสไลด์ที่สร้างใหม่.

## **นำเข้าจาก PDF**

เพื่อแปลงเอกสาร PDF ให้เป็นงานนำเสนอ PowerPoint ให้ทำการนำเข้เนื้อหาไปยังคอลเลกชันสไลด์และบันทึกผลลัพธ์เป็นไฟล์ PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใหม่.
2. เรียกใช้ [addFromPdf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromPdf) พร้อมเส้นทางไปยังไฟล์ PDF.
3. เรียกใช้ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) เพื่อบันทึกงานนำเสนอเป็นไฟล์ PPTX.

ตัวอย่าง Python ด้านล่างแสดงการนำเข้าเอกสาร PDF และบันทึกสไลด์ที่สร้างเป็นงานนำเสนอ PowerPoint:

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

สไลด์เปล่าตั้งต้นจะยังคงอยู่ในงานนำเสนอเนื่องจากการนำเข้าเพิ่มสไลด์ต่อท้าย. หากต้องการเก็บเฉพาะหน้าที่นำเข้าให้ทำการล้างคอลเลกชันสไลด์ด้วย [SlideCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#clear) ก่อนการนำเข้า.

เมธอด [addFromPdf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromPdf) จะคืนค่าสไลด์ที่เพิ่มเข้ามา ซึ่งมีประโยชน์เมื่อคุณต้องการประมวลผลเฉพาะสไลด์ที่นำเข้า.

{{% alert title="Tip" color="success" %}}
ลองแอปเว็บฟรี [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เพื่อดูการทำงานของกระบวนการแปลงนี้.
{{% /alert %}}

## **นำเข้าจาก HTML**

Aspose.Slides ยังสามารถสร้างสไลด์จากเอกสาร HTML ได้. แหล่งข้อมูลสามารถให้เป็นข้อความ HTML หรือสตรีม. ขั้นตอนต่อไปนี้ใช้ไฟล์สตรีม:

1. สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใหม่.
2. เปิดไฟล์ HTML เพื่ออ่านและส่งสตรีมไปยัง [addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromHtml).
3. เรียกใช้ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) เพื่อบันทึกผลลัพธ์เป็นไฟล์ PPTX.

ตัวอย่าง Python ด้านล่างแสดงการนำเข้าเอกสาร HTML และบันทึกสไลด์ที่สร้างเป็นงานนำเสนอ PowerPoint:

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

ใช้ [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertFromHtml) เมื่อสไลด์ที่สร้างจาก HTML ต้องวางในตำแหน่งเฉพาะแทนการต่อท้าย. ดัชนีเป็นแบบศูนย์เริ่มต้นและระบุตำแหน่งที่การนำเข้าเริ่มต้น.

อาร์กิวเมนต์ `useSlideWithIndexAsStart` ควบคุมวิธีการใช้ตำแหน่งนั้น:

- เมื่อเป็น `False` ตัวนำเข้าจะสร้างสไลด์ใหม่ที่ดัชนีที่ระบุและเลื่อนสไลด์ที่ตามมาทั้งหมด.
- เมื่อเป็น `True` ตัวนำเข้าจะเริ่มวางเนื้อหาในพื้นที่ว่างที่มีบนสไลด์ที่มีอยู่ที่ดัชนีนั้น. หาก HTML ไม่พอ, Aspose.Slides จะทำการแบ่งหน้าโดยอัตโนมัติและแทรกสไลด์เพิ่มเติมทันทีหลังจากสไลด์เริ่มต้น.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertFromHtml) จะคืนค่าอาร์เรย์ของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/). หากการแทรกเริ่มบนสไลด์ใหม่แต่ละรายการที่คืนค่าจะเป็นสไลด์ที่สร้างใหม่. หากใช้สไลด์ที่มีอยู่เป็นจุดเริ่มต้น อาร์เรย์จะรวมสไลด์ที่ได้รับผลกระทบนั้นตามด้วยสไลด์ส่วนเกินใหม่ใดๆ. คุณสามารถตรวจสอบอาร์เรย์นี้แทนการคำนวณช่วงที่ได้รับผลกระทบจากจำนวนสไลด์ของงานนำเสนอ.

### **แทรก HTML เป็นสไลด์ใหม่**

ตัวอย่างต่อไปนี้ให้ HTML เป็นสตริงและแทรกสไลด์ที่สร้างที่ดัชนีของคอลเลกชัน `1`. การส่งค่า `False` จะทำให้สไลด์เดิมคงอยู่โดยไม่ได้เปลี่ยนแต่อยู่ในตำแหน่งที่ถูกเลื่อนเพื่อให้มีที่ว่าง.

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

### **เริ่มจากสไลด์ที่มีอยู่**

ตัวอย่างต่อไปนี้ให้ HTML ผ่านสตรีม. มันคงรูปหัวเรื่องบนสไลด์แม่แบบที่มีอยู่, เริ่มนำเข้าตำแหน่งด้านล่างพื้นที่ที่ถูกใช้แล้ว, และให้เนื้อหายาวต่อไปในสไลด์ใหม่.

HTML ยังมี URL ของรูปภาพแบบ relative. [ExternalResourceResolver](https://reference.aspose.com/slides/th/python-java/aspose.slides/externalresourceresolver/) จะดึงทรัพยากร, ส่วน Base URI จะบอกตัวนำเข้าให้แก้ไข `images/logo.png` อย่างไร. ในตัวอย่างนี้ไฟล์ดังกล่าวคาดว่าจะอยู่ที่ `html-assets/images/logo.png`.

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
ExternalResourceResolver ที่ไม่มีข้อจำกัดสามารถอ่านทรัพยากรภายในเครื่องหรือเครือข่ายที่อ้างอิงโดย HTML ได้. สำหรับข้อมูลที่ไม่เชื่อถือ, ควรตรวจสอบและทำความสะอาด URL ของทรัพยากรโดยอิงกับรายการอนุญาตของสเคม, ไดเรกทอรี, และโฮสต์ที่อนุญาตก่อนการนำเข้า HTML.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถตรวจจับตารางได้หรือไม่ขณะนำเข้า PDF?**

ได้. สร้างอ็อบเจกต์ [PdfImportOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfimportoptions/) แล้วเรียก [setDetectTables](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfimportoptions/#setDetectTables) ด้วยค่า `True`, จากนั้นส่งตัวเลือกนี้ไปยัง [addFromPdf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addFromPdf). คุณภาพของการจดจำตารางขึ้นอยู่กับโครงสร้างและความซับซ้อนของ PDF แหล่งที่มา.

{{% alert title="Note" color="info" %}}
หลังจากนำเข้า HTML แล้ว คุณยังสามารถส่งออกสไลด์เป็น [images](/slides/th/python-java/convert-powerpoint-to-png/), [TIFF](/slides/th/python-java/convert-powerpoint-to-tiff/), หรือ [SVG](/slides/th/python-java/render-slide-as-svg/) ได้.
{{% /alert %}}