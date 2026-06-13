---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงจากภายนอกใน Python
linktitle: ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงจากภายนอก
type: docs
weight: 100
url: /th/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint เป็น HTML
- OpenDocument เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- ODP เป็น HTML
- รูปภาพที่เชื่อมโยง
- รูปภาพที่เชื่อมโยงจากภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- Python
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML ใน Python ด้วย Aspose.Slides โดยบันทึกรูปภาพเป็นไฟล์ที่เชื่อมโยงจากภายนอก."
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกงานนำเสนอเป็นไฟล์ HTML ที่รวมทุกอย่างไว้ในไฟล์เดียว รูปภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงลงใน HTML มักในรูปแบบข้อมูล Base64 นี่เป็นวิธีที่สะดวกเมื่อคุณต้องการไฟล์พกพาเดียว แต่ไม่ใช่ว่าจะเป็นรูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS, หรือโซลูชันการแปลงฝั่งเซิร์ฟเวอร์

ใช้รูปภาพที่เชื่อมโยงจากภายนอกเมื่อคุณต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชรูปภาพแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด, หรือประมวลผลต่อรูปภาพที่สร้างหลังการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวังมากขึ้น

สำหรับกระบวนการแปลง HTML ทั่วไป ดูที่ [Convert PowerPoint Presentations to HTML](/slides/th/python-net/convert-powerpoint-to-html/). บทความนี้มุ่งเน้นที่ส่วนการเชื่อมโยงรูปภาพของการส่งออก

## **วิธีการส่งออกภาพที่เชื่อมโยง**

ใน .NET และ Java, [ILinkEmbedController](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/ilinkembedcontroller/) แสดงถึงอินเทอร์เฟซ callback ที่ใช้โดยโปรแกรมส่งออกเพื่อกำหนดว่าทรัพยากรควรฝังหรือเชื่อมโยง อย่างไรก็ตามใน Python ผ่าน .NET, คลาส Python ยังไม่สามารถนำเข้าอินเทอร์เฟซ callback ของ .NET นี้ได้โดยตรง ดังนั้นขั้นตอนที่ใช้จริงคือ:

1. ส่งออกงานนำเสนอเป็น HTML ด้วย [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/).
2. ใช้ [SlideImageFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/slideimageformat/) ร่วมกับ [SVGOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/) เพื่อให้สไลด์ถูกแสดงเป็น SVG ใน HTML.
3. ย้ายข้อมูลรูปภาพ Base64 จาก URL `data:` ของ HTML ไปยังไฟล์แยกต่างหาก.
4. แทนที่ URL `data:` ดั้งเดิมด้วยลิงก์แบบสัมพันธ์ เช่น `assets/resource-1.jpg`.

เส้นทางระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องแยกจากกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์รูปภาพไปที่ `html-output/assets` บนดิสก์ ขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.jpg`. เบราว์เซอร์จะทำการแก้ไข URL เหล่านี้สัมพันธ์กับไฟล์ HTML ที่มีลิงก์

## **ส่งออก HTML พร้อมรูปภาพที่เชื่อมโยง**

ตัวอย่าง Python ต่อไปนี้สร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ที่นั่น, เก็บรูปภาพที่ดึงออกในไดเรกทอรีย่อย `assets`, และเขียนทับ URL รูปภาพ Base64 ให้เป็นลิงก์แบบสัมพันธ์ ตัวอย่างจะดึงรูปแบบ Base64 ที่พบบ่อยเมื่อ Aspose.Slides ให้ส่วนขยายไฟล์ที่ปลอดภัย URL ของข้อมูลที่ไม่รู้จักจะยังคงฝังอยู่

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

หลังจากการส่งออก โฟลเดอร์ผลลัพธ์อาจมีโครงสร้างดังนี้:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

ไฟล์ที่แน่นอนจะขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น รูปภาพราสเตอร์มักจะส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือก codec รูปภาพที่ต่างจากที่ใช้ในงานนำเสนอต้นฉบับเมื่อทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า รูปภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/`. หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.jpg`

ใช้ชื่อไดเรกทอรี assets ที่แตกต่างหรือเขียนทับลิงก์ที่สร้างขึ้นเมื่อไฟล์ถูกปรับใช้ในที่อื่น:

- ใช้ `assets/` เมื่อไดเรกทอรี assets อยู่ใกล้ไฟล์ HTML.
- ใช้ `../assets/` เมื่อไดเรกทอรี assets อยู่ระดับหนึ่งเหนือไฟล์ HTML.
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สถิต

ในแอปพลิเคชันเซิร์ฟเวอร์ ให้ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าที่จัดเก็บใน object‑storage ที่ไม่ซ้ำกันสำหรับแต่ละงานแปลงเพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อควรฝังแทนที่เชื่อมโยง**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อต้องการผลลัพธ์เป็นไฟล์เดียว เช่น แนบอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่ต้องการย้ายโดยไม่มีโฟลเดอร์ assets รองรับ รูปภาพที่เชื่อมโยงจะเหมาะสมกว่าเมื่อ HTML จะให้บริการโดยเว็บแอปพลิเคชัน, เก็บใน CMS, ถูกปรับให้เหมาะสมโดย pipeline การสร้าง, หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **ถามบ่อย**

**ฉันสามารถทำให้รูปภาพเท่านั้นเป็นภายนอกและให้ทรัพยากรอื่น ๆ ยังคงฝังไว้ได้หรือไม่?**

ได้ ตัวอย่างจะดึงเฉพาะ URL ข้อมูล Base64 ที่เป็น `image/*` ซึ่งประเภทเนื้อหาอยู่ใน `EXTENSIONS_BY_CONTENT_TYPE` URL ข้อมูลอื่น ๆ จะยังคงฝังอยู่

**ทำไมนามสกุลไฟล์รูปภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอต้นฉบับ?**

Aspose.Slides อาจทำการเข้ารหัสใหม่ของรูปภาพราสเตอร์ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น รูปภาพจากไฟล์ต้นฉบับอาจถูกบันทึกเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่แสดง

**URL แบบสัมพันธ์ทำงานได้หรือไม่หลังจากที่ย้ายไฟล์ HTML?**

URL แบบสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์สัมพันธ์เดียวกันยังคงอยู่ หาก HTML อ้างอิง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างๆ ไฟล์ HTML เว้นแต่คุณจะสร้างคำนำหน้า URL ที่แตกต่าง

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าการจัดเก็บที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการชนของชื่อไฟล์และป้องกันไม่ให้การส่งออกหนึ่งเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น