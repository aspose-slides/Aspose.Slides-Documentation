---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงภายนอก
type: docs
weight: 100
url: /th/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint ไปเป็น HTML
- OpenDocument ไปเป็น HTML
- งานนำเสนอไปเป็น HTML
- สไลด์ไปเป็น HTML
- PPT ไปเป็น HTML
- PPTX ไปเป็น HTML
- ODP ไปเป็น HTML
- รูปภาพที่เชื่อมโยง
- รูปภาพที่เชื่อมโยงภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- Python
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML ใน Python โดยใช้ Aspose.Slides พร้อมภาพและทรัพยากรอื่น ๆ ที่บันทึกเป็นไฟล์ที่เชื่อมโยงภายนอก"
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกงานนำเสนอเป็นไฟล์ HTML แบบอัตโนมัติทั้งหมด ภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงลงใน HTML ส่วนใหญ่ในรูปแบบข้อมูล Base64 ซึ่งสะดวกเมื่อต้องการไฟล์พกพาเดียว แต่ไม่จำเป็นต้องเป็นรูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS หรือสายงานการแปลงด้านเซิร์ฟเวอร์

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อคุณต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชภาพ, ฟอนต์, เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด หรือประมวลผลต่อเนื่องทรัพยากรที่สร้างขึ้นหลังการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวังมากขึ้น.

สำหรับกระบวนการแปลง HTML ทั่วไป ดูที่ [แปลงงานนำเสนอ PowerPoint เป็น HTML](/slides/th/python-java/convert-powerpoint-to-html/). บทความนี้มุ่งเน้นที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก.

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

`ILinkEmbedController` ให้แอปพลิเคชันของคุณตัดสินใจแบบทรัพยากรต่อทรัพยากรว่าจะให้ผู้ส่งออกฝังข้อมูลลงใน HTML หรือบันทึกเป็นไฟล์ภายนอกและเขียนลิงก์

อินเทอร์เฟซมีสามเมธ็อด:

- `ILinkEmbedController.getObjectStoringLocation` ตัดสินใจว่าจะลิงก์หรือฝังทรัพยากร;
- `ILinkEmbedController.getUrl` คืนค่า URL ที่จะเขียนลงใน HTML ที่สร้างหรือไปยังทรัพยากรที่เชื่อมโยงอื่น;
- `ILinkEmbedController.saveExternal` เขียนข้อมูลทรัพยากรที่เชื่อมโยงไปยังดิสก์หรือที่เก็บอื่น

เส้นทางไฟล์ระบบและ URL ของเบราว์เซอร์เป็นเรื่องแยกกัน ตัวอย่างเช่น ตัวอย่างด้านล่างจะเขียนไฟล์ทรัพยากรไปที่ `html-output/assets` บนดิสก์ ในขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.svg` เบราว์เซอร์จะตีความ URL เหล่านั้นสัมพันธ์กับไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ในขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`.

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง Python ต่อไปนี้สร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ไว้ที่นั่น, และเก็บทรัพยากรที่เชื่อมโยงในโฟลเดอร์ย่อย `assets` ตัวควบคุมจะลิงก์ภาพ, ฟอนต์, เสียง, วิดีโอ และทรัพยากร CSS ที่ Aspose.Slides จัดหาให้หรือสามารถสรุปส่วนต่อท้ายไฟล์ที่ปลอดภัยได้ ส่วนทรัพยากรที่ไม่รู้จักจะยังคงถูกฝังอยู่

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

หลังการส่งออก โฟลเดอร์ผลลัพธ์จะมีโครงสร้างดังนี้:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

ไฟล์ที่แน่นอนขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น รูปภาพเรสเตอร์มักจะถูกส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกโค้ดเคอดรูปภาพที่ต่างจากที่ใช้ในงานนำเสนอเดิมเมื่อทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า รูปภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG.

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/` หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงอีกทรัพยากรที่เชื่อมโยง ตัวอย่างจะใช้พารามิเตอร์ `referrer` ใน `ILinkEmbedController.getUrl` และคืนค่าเฉพาะชื่อไฟล์เท่านั้น ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ไฟล์ SVG ควรอ้างถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์จะปรับใช้ในที่อื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ข้างไฟล์ HTML;
- ใช้ `../assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ระดับหนึ่งเหนือไฟล์ HTML;
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์อัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สถิตย์

URL ที่ `ILinkEmbedController.getUrl` คืนค่าต้องตรงกับตำแหน่งที่ไฟล์ที่ `ILinkEmbedController.saveExternal` เขียนไว้ในขั้นตอนการปรับใช้ขั้นสุดท้าย ในแอปพลิเคชันเซิร์ฟเวอร์ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้า object-storage ที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อควรฝังแทน**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น แนบอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่จะย้ายโดยไม่มีโฟลเดอร์ทรัพยากรสนับสนุน ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะให้บริการโดยแอปพลิเคชันเว็บ, จัดเก็บใน CMS, ผ่านขั้นตอนการปรับแต่งใน pipeline, หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **FAQ**

**ฉันสามารถแยกภาพออกเป็นไฟล์ภายนอกและให้ทรัพยากรอื่นฝังอยู่ได้หรือไม่?**

ได้ ใน `ILinkEmbedController.getObjectStoringLocation` ให้คืนค่า [LinkEmbedDecision.Link](https://reference.aspose.com/slides/th/python-java/aspose.slides/linkembeddecision/#Link) เฉพาะสำหรับประเภทเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก และคืนค่า [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/th/python-java/aspose.slides/linkembeddecision/#Embed) สำหรับส่วนอื่นทั้งหมด

**ทำไมนามสกุลไฟล์รูปภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอต้นฉบับ?**

Aspose.Slides อาจทำการเข้ารหัสรูปภาพเรสเตอร์ใหม่ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น รูปภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นกับผลลัพธ์ที่เรนเดอร์

**URL แบบสัมพันธ์ยังทำงานได้หลังจากย้ายไฟล์ HTML หรือไม่?**

URL แบบสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์สัมพันธ์เดียวกันยังคงอยู่ หาก HTML อ้างอิง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างไฟล์ HTML นั้น เว้นแต่คุณจะสร้างคำนำหน้า URL ที่แตกต่าง

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าที่เก็บข้อมูลที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการชนของชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น.