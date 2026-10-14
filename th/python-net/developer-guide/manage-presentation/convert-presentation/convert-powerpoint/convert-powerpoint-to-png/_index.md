---
title: แปลงสไลด์ PowerPoint เป็น PNG ด้วย Python
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/python-net/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint เป็น PNG
- แปลงงานนำเสนอเป็น PNG
- แปลงสไลด์เป็น PNG
- แปลง PPT เป็น PNG
- แปลง PPTX เป็น PNG
- แปลง ODP เป็น PNG
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- ODP เป็น PNG
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์งานนำเสนอเป็นภาพ PNG โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET คุณสามารถโหลดงานนำเสนอในรูปแบบต่างๆ เช่น PPT, PPTX และ ODP, เรนเดอร์แต่ละสไลด์, และบันทึกเป็นภาพ PNG แยกกัน

ตัวอย่างด้านล่างแสดงการเรนเดอร์ด้วยสเกลเริ่มต้น, การเพิ่มสเกล, การระบุขนาดผลลัพธ์เป็นพิกเซล, และการเลือกสไตล์การเรนเดอร์แบบไล่สี

## **แปลง PowerPoint เป็น PNG**

โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านคอลเลกชัน [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) ตัวอย่างจะแนวรนเดอร์ทุกสไลด์ด้วย [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) โดยไม่มีพารามิเตอร์เพื่อสร้างภาพย่อ จากนั้นเรียก [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ด้วย [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) เพื่อบันทึกแต่ละสไลด์ที่เรนเดอร์เป็นภาพ PNG

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
โอเวอร์โหลด [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ที่ไม่มีพารามิเตอร์จะเรนเดอร์ด้วยสเกล 0.2 ตัวอย่างเช่น สไลด์ขนาด 720 × 540 พอยท์จะสร้างภาพย่อขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้โอเวอร์โหลดที่มีตัวคูณสเกลหรือขนาดภาพที่ระบุชัดเจนตามด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

ส่งตัวคูณสเกลแนวนอนและแนวตั้งไปยัง [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ทั้งสองค่ามีค่า 2 ดังนั้นสไลด์ขนาด 720 × 540 พอยท์จะผลิตภาพ 1440 × 1080 พิกเซล ตัวคูณสเกลเท่ากันจะรักษาอัตราส่วนของสไลด์ แต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) แทนการใช้ตัวคูณสเกล ตัวอย่างนี้เรนเดอร์ทุกสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) เลือกขนาดที่ตรงกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่าในสไลด์มีการเติมสีไล่สี แต่การเปลี่ยนแปลงในไฟล์ PNG ที่ส่งออกดูอ่อนแว่าหรือแตกต่างจากที่เห็นใน PowerPoint คุณสามารถใช้คุณสมบัติ [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) ของ [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่สี

ดาวน์โหลดไฟล์ [gradient-styles.pptx](gradient-styles.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์มีไล่สีเชิงเส้นสองแบบ: สีสีฟ้าครามไปสีส้มที่ด้านบนและสีน้ำเงินไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดด้วย [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

รูปภาพด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกันพร้อมไล่สีทั้งสองแบบในแต่ละภาพ:

| ค่าเริ่มต้น | PowerPointUI |
| --- | --- |
| ![ไล่สีสีฟ้า-ส้มและสีน้ำเงิน-เหลืองที่เรนเดอร์ด้วยค่าเริ่มต้น](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `DEFAULT` ทำให้สีกลางอ่อนกว่า ในขณะที่ `POWER_POINT_UI` ทำให้สีกลางเข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `DEFAULT` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides ตรงกับความต้องการของคุณ ลอง `POWER_POINT_UI` เมื่อความสำคัญของคุณคือการทำให้รูปแบบตรงกับ PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่ต้องการของคุณ; ไม่มีโหมดใดที่ดีกว่าในทุกกรณี

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปทรงเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ[สร้างภาพย่อสำหรับรูปทรงแต่ละรายการ](/slides/th/python-net/create-shape-thumbnails/), ซึ่งทำให้คุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG

**Is parallel conversion supported on a server?**

ใช่ ใช้อินสแตนซ์ของงานนำเสนอแยกสำหรับแต่ละเธรดหรือโพรเซส; [ห้ามแชร์อินสแตนซ์เดียวกันระหว่างเธรด](/slides/th/python-net/multithreading/).

**What are the evaluation limitations when exporting to PNG?**

โหมดประเมินผลจะเพิ่มลายน้ำในภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น ๆ](/slides/th/python-net/licensing/) จนกว่าจะมีการใช้ลิขสิทธิ์