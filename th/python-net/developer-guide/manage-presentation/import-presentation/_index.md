---
title: นำเข้าการนำเสนอด้วย Python
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/python-net/import-presentation/
keywords:
- นำเข้า PowerPoint
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- PDF เป็นการนำเสนอ
- PDF เป็น PPT
- PDF เป็น PPTX
- PDF เป็น ODP
- HTML เป็นการนำเสนอ
- HTML เป็น PPT
- HTML เป็น PPTX
- HTML เป็น ODP
- Python
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายใน Python ด้วย Aspose.Slides เพื่อการประมวลผลสไลด์ที่ราบรื่นและประสิทธิภาพสูง."
---
## **บทนำ**

ด้วย [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/th/python-net/), คุณสามารถนำเข้าข้อมูลเข้าสู่การนำเสนอจากรูปแบบไฟล์อื่นได้. คลาส [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ให้เมธอดสำหรับนำเข้าสไลด์จาก PDF, HTML และแหล่งข้อมูลอื่นๆ.

## **แปลง PDF เป็นการนำเสนอ**

ส่วนนี้แสดงวิธีการแปลง PDF เป็นการนำเสนอด้วย Aspose.Slides โดยอธิบายขั้นตอนการนำเข้า PDF, แปลงหน้าของมันเป็นสไลด์, และบันทึกผลลัพธ์เป็นไฟล์ PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. เรียกเมธอด [add_from_pdf](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_from_pdf/) และส่งไฟล์ PDF ไป.
3. ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกการนำเสนอในรูปแบบ PowerPoint.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
คุณอาจต้องการลองแอปเว็บ **Aspose’s free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) — เป็นการดำเนินการจริงของกระบวนการที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง HTML เป็นการนำเสนอ**

ส่วนนี้แสดงวิธีการนำเข้าเนื้อหา HTML ไปยังการนำเสนอด้วย Aspose.Slides รวมถึงการโหลด HTML, แปลงเป็นสไลด์พร้อมรักษาข้อความ, รูปภาพและการจัดรูปแบบพื้นฐาน, และบันทึกผลลัพธ์เป็นไฟล์ PPTX.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. เรียกเมธอด [add_from_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_from_html/) และส่งไฟล์ HTML ไป.
3. ใช้เมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกการนำเสนอในรูปแบบ PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ตารางจะยังคงอยู่เมื่อนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?**

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.importing/pdfimportoptions/) มีพารามิเตอร์ [detect_tables](https://reference.aspose.com/slides/th/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) เพื่อเปิดใช้งานการจำลองตาราง. ประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF.

{{% alert title="Note" color="info" %}}
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML ไปยังรูปแบบไฟล์ยอดนิยมอื่นๆ:

* [HTML to image](https://products.aspose.com/slides/th/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/th/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/th/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/th/python-net/conversion/html-to-tiff/)

{{% /alert %}}