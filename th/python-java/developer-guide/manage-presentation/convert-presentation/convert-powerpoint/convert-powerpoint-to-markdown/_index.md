---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน Python ผ่าน Java
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/python-java/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกภาพใน Markdown
- ลิงก์ภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น Markdown ใน Python ผ่าน Java และควบคุมตำแหน่งที่บันทึกและอ้างอิงภาพ bitmap, metafile, และ SVG ที่ส่งออก"
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อการเขียนเอกสาร, เว็บไซต์แบบสถิต, การย้ายเนื้อหา, และกระบวนการควบคุมเวอร์ชันได้ คุณสามารถเลือกรูปแบบของ Markdown, ควบคุมการเรนเดอร์เนื้อหาสไลด์, และกำหนดว่าภาพที่ส่งออกจะถูกจัดเก็บที่ใดและ Markdown ที่สร้างขึ้นจะอ้างอิงถึงภาพอย่างไร

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้ผลลัพธ์แบบข้อความเท่านั้น หากต้องการส่งออกเนื้อหาภาพ ให้ตั้งค่าประเภทการส่งออกด้วยเมธอด [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setExportType) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownexporttype/) `Sequential` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ในขณะที่ `Visual` จะคงกลุ่มรายการไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรภาพ ดังนั้นคอลแบ็กการบันทึกภาพจะไม่ถูกเรียกในโหมดนั้น

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์แหล่งที่มาด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จากนั้นเรียกเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ด้วยค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

แต่ละตัวอย่างจะอ่านไฟล์ `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน ก่อนรันตัวอย่างให้ติดตั้ง Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ เริ่ม JVM ครั้งเดียวต่อกระบวนการ Python

## **เลือกรูปแบบ Markdown**

เมธอด [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setFlavor) ควบคุมสเปคของ Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/python-java/aspose.slides/flavor/) มี CommonMark, GitHub Flavored Markdown, และรูปแบบที่สนับสนุนอื่นๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **ส่งออกภาพโดยใช้พฤติกรรมการบันทึกในเครื่องโดยค่าเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/) มีเมธอดสองตัวสำหรับกำหนดการบันทึกรูปภาพในเครื่อง:

- [setBasePath](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setBasePath) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [setImagesSaveFolderName](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) ระบุไดเรกทอรีย่อยของภาพ ค่าเริ่มต้นคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ, เขียนภาพไปที่ `output/assets`, และสร้างลิงก์ภาพแบบ relative ในเอกสาร Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

พฤติกรรมนี้ยังทำหน้าที่เป็น fallback เมื่อตัวจัดการการบันทึกภาพแบบกำหนดเองคืนค่า `False`

## **ปรับแต่งการบันทึกภาพและลิงก์ Markdown**

ใช้เมธอด [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/) เพื่อลงทะเบียนคอลแบ็กสำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ส่งออกในขั้นตอน Markdown คอลแบ็ก `MarkdownImageSavingHandler` จะรับออบเจ็กต์ภาพ, ค่าของ [ImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/), และลิงก์ Markdown ที่สร้างขึ้นในพารามิเตอร์อาร์เรย์ `String[]` ขนาดหนึ่ง บันทึกหรืออัปโหลดภาพด้วยฟอร์แมตที่ให้มาแล้วแทนที่ `link[0]` ด้วยอ้างอิงที่ต้องปรากฏในผลลัพธ์ Markdown

ทรัพยากรที่ส่งออกเป็น SVG จะถูกจัดการแยกต่างหาก ลงทะเบียนคอลแบ็กด้วยเมธอด [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/) คอลแบ็ก `MarkdownSvgImageSavingHandler` จะรับออบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) และพารามิเตอร์อาร์เรย์ `String[] link` ขนาดหนึ่ง SVG ไม่มีอาร์กิวเมนต์ `ImageFormat`; ให้เขียนหรืออัปโหลดข้อมูล XML ของมันจากเมธอด [SvgImage.getSvgData](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/#getSvgData) ตามต้องการ ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มภาพ SVG ในงานนำเสนออาจถูกแปลงเป็น raster หรือรวมกับเนื้อหาอื่น; ทรัพยากรที่ไม่ใช่ SVG ที่ได้จะแพร่ผ่านไปยังคอลแบ็กการบันทึกภาพ ลงทะเบียนคอลแบ็กทั้งสองเมื่อต้องการประมวลผลทรัพยากรภาพที่ส่งออกทั้งหมดด้วยกระบวนการกำหนดเอง

ค่าที่คอลแบ็กคืนจะกำหนดว่าใครเป็นผู้ประมวลผลภาพ:

- คืนค่า `True` หลังจากคอลแบ็กบันทึก, อัปโหลด, แปลงรูป หรือประมวลผลภาพใด ๆ แล้วกำหนดค่าที่ถูกต้องให้กับ `link[0]` Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และไม่ทำการบันทึกในเครื่องตามค่าเริ่มต้น
- คืนค่า `False` เพื่อให้ Aspose.Slides บันทึกภาพในเครื่องและสร้างลิงก์ตามค่าที่ตั้งด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setBasePath) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName)

{{% alert color="danger" title="Important" %}}
ตัวจัดการที่คืนค่า `True` จะรับผิดชอบต่อภาพ หากคืนค่า `True` โดยไม่ได้กำหนดลิงก์ที่ถูกต้องและไม่ว่างเปล่า การส่งออกจะล้มเหลวด้วย `InvalidOperationException`
{{% /alert %}}

ใน Python ให้ลงทะเบียนคอลแบ็กเหล่านี้ด้วย `jpype.JProxy` โดยทำการนำเข้าตัวยืนยัน Java ผ่านเมธอด `invoke` อาร์กิวเมนต์ `link` เป็นอาร์เรย์ Java string ที่เปลี่ยนแปลงได้: แปลง `link[0]` เป็นสตริง Python ก่อนทำการประมวลผล แล้วกำหนด URL ที่แทนที่กลับไปยัง `link[0]`

### **บันทึกภาพไปยังไดเรกทอรีต้นทาง CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นทาง CDN ที่ถูกเมานท์หรือซิงโครไนซ์ ตัวจัดการแต่ละตัวจะดึงชื่อไฟล์ที่สร้างขึ้น, บันทึกภาพไปยังไดเรกทอรีที่กำหนดเองนั้น, และแทนที่ลิงก์ภาพในเครื่องที่สร้างขึ้นด้วย URL สาธารณะของ CDN ตัวอย่างไม่มีการอัปโหลดผ่านเครือข่าย: URL จะเป็นไปได้ก็ต่อเมื่อติดตั้งไดเรกทอรีเป็นต้นทาง CDN หรือไฟล์ถูกเผยแพร่ไปยัง CDN สำหรับการจัดเก็บแบบวัตถุ ให้แทนที่การเขียนไฟล์ระบบด้วยการอัปโหลดผ่าน SDK ของ storage และกำหนด `link[0]` หลังจากอัปโหลดสำเร็จ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

คอลแบ็ก bitmap ตั้งใจคืนค่า `False` สำหรับภาพที่มีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกภาพเหล่านั้นไปที่ `output/fallback-images` ตามพฤติกรรมค่าเริ่มต้น bitmap และ metafile ที่ใหญ่กว่า รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น ลิงก์ภาพภายในที่สร้างเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` ตัวจัดการจะใช้เส้นทางของระบบปฏิบัติการเท่านั้นเมื่อเขียนไฟล์; ลิงก์ที่เขียนใน Markdown จะใช้เครื่องหมายทับหน้า (`/`) และชื่อไฟล์ที่เข้ารหัสแบบ URL ปฏิบัติตามกฎเดียวกันเมื่อต้องสร้างลิงก์แบบ relative: ใช้ `/` ไม่ใช่ตัวคั่นไดเรกทอรีเฉพาะแพลตฟอร์ม

## **คำถามที่พบบ่อย**

**Can one handler process both raster images and SVG images?**  
**ตัวจัดการหนึ่งสามารถประมวลผลทั้งภาพเรสเตอร์และ SVG ได้หรือไม่?**  
No. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/) for bitmap and metafile resources and [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/) for SVG resources. The former provides an image object and an [ImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/) value; the latter provides an [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) object whose SVG data can be read with [SvgImage.getSvgData](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/#getSvgData). A source SVG that is rasterized during export is processed by the image‑saving callback instead.

**What happens when an image‑saving handler returns `False`?**  
**อะไรจะเกิดขึ้นเมื่อคอลแบ็กการบันทึกภาพคืนค่า `False`?**  
Aspose.Slides จะใช้พฤติกรรมการบันทึกในเครื่องตามค่าเริ่มต้น โดยตำแหน่งภาพและลิงก์ที่สร้างจะถูกควบคุมโดยค่าที่ตั้งด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setBasePath) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Can a handler provide a URL without saving the image locally?**  
**คอลแบ็กสามารถให้ URL ได้โดยไม่บันทึกภาพในเครื่องหรือไม่?**  
Yes. The handler may upload the image to object storage or pass it to another service, assign the resulting URL to `link[0]`, and return `True`. The handler must complete the processing itself; returning `True` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**  
**ทำไมการส่งออก Markdown จึงโยน `InvalidOperationException` จากคอลแบ็ก?**  
This occurs when the handler returns `True` but does not supply a valid, non‑empty link. Assign the relative path or external URL that should appear in Markdown before returning `True`.

**Which path separator should image links use?**  
**ลิงก์ภาพควรใช้ตัวคั่นเส้นทางแบบใด?**  
Use forward slashes (`/`) in Markdown links and URLs. Use `pathlib.Path` only for file‑system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**  
**ลิงก์ไฮเปอร์ลิงก์จะถูกรักษาไว้ในการส่งออกเป็น Markdown หรือไม่?**  
Yes. Text [hyperlinks](/slides/th/python-java/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/th/python-java/slide-transition/) and [animations](/slides/th/python-java/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**  
**สามารถแปลงงานนำเสนอเป็น Markdown แบบขนานได้หรือไม่?**  
You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/th/python-java/multithreading/) and use a separate instance for each file.