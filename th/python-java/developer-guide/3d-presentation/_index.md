---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอโดยใช้ Python
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดันออก 3D
- การไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปทรงและข้อความ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Python ผ่าน Java สามารถสร้าง, แก้ไข, รักษา, และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดันออก, การทำขอบแบบเบเวล, การกำหนดแสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3 มิติ

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบแยกส่วน เมื่อคุณส่งออกสไลด์เป็นรูปภาพ, PDF, หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

ติดตั้งแพคเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). แต่ละตัวอย่างจะนำเข้า `asposeslides`, เริ่ม JVM หากจำเป็น, และจากนั้นนำเข้า API. ตัวอย่างการเติมรูปภาพต้องใช้ไฟล์ `image.jpg` ในไดเรกทอรีทำงาน

## **แนวคิดการจัดรูปแบบ 3D**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3D กับรูปทรง วัตถุ format ที่ส่งกลับจะควบคุมฉาก 3D สำหรับรูปทรงนั้น

สำหรับข้อความ, ใช้ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3D กับกรอบข้อความแทนเนื้อหารูปทรง

API ที่สำคัญที่สุดมีดังนี้

| API member | ควบคุมอะไร | เมื่อใดควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getCamera) | จุดมอง, ประเภทกล้องที่กำหนดล่วงหน้า, การหมุน, การซูม, และการมองในมุมมอง | หมุนวัตถุในอวกาศ 3D หรือจับคู่กับการตั้งค่าการหมุน 3D ของ PowerPoint ที่กำหนดล่วงหน้า |
| [getLightRig](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getLightRig) | แสงที่กำหนดล่วงหน้า, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีที่เงาและไฮไลต์ปรากฏบนพื้นผิว 3D |
| [getMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setMaterial) | วัสดุพื้นผิว เช่น แบน, ทำมัด, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนยิ่งขึ้น, นุ่มขึ้น, มันวาว, หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปทรงขยายย้อนกลับจากหน้าตรงของมัน | เปลี่ยนรูปทรงแบนให้กลายเป็นวัตถุ 3D หน้าที่มองเห็นได้ |
| [getExtrusionColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าตรง |
| [getDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setDepth) | ความลึก 3D เพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3D ของ PowerPoint | ปรับความลึกให้ละเอียดสำหรับรูปทรงหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่าเบิลและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelBottom) | ขอบที่ยกขึ้นหรือโค้งมนบนหน้าและหลังของรูปทรง | เพิ่มขอบที่นุ่มหรือหล่อขึ้นแทนหน้าตรงแหลมคม |
| [getContourColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบวัตถุ 3D | เน้นขอบวัตถุในผลลัพธ์การเรนเดอร์ |

## **สร้างรูปทรง 3D**

รูปทรงโดยทั่วไปต้องการการตั้งค่าสี่ประเภทก่อนจะแสดงเป็น 3 มิติอย่างสมจริง:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าตรงเริ่มต้นอาจทำให้การดันออกมองไม่เห็น
- การตั้งค่าแสง, เนื่องจากแสงทำให้ด้านและข้างสามารถมองเห็นได้
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวส่งผลต่อการแสดงแสง
- การตั้งค่าการดันออกหรือความลึก, เนื่องจากรูปทรงแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เติมข้อความลงบนหน้าตรง, ใช้การจัดรูปแบบ 3D, บันทึกงานนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3D หนา:

![สี่เหลี่ยม 3D สีฟ้าถูกเรนเดอร์พร้อมข้อความ 3D สีขาวบนหน้าตรง](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint การหมุน 3D กำหนดจากแผง 3‑D Rotation ค่าการหมุน X, Y, และ Z สอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผงการหมุน 3-D ของ PowerPoint ที่แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides, ตั้งค่าชนิดกล้องและการหมุนผ่านรูปแบบ 3D ที่ส่งคืนโดย [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองเห็นวัตถุ ซึ่งไม่ได้เปลี่ยนรูปทรง 2D บนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปทรงดูหนาด้วยการขยายไปด้านหลังหน้าตรง ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่เชื่อมกับสีการดันออกและคุณสมบัติความสูงการดันออก](img_02_02.png)

ตั้งค่าความสูงการดันออกสำหรับความหนาและสีการดันออกสำหรับสีด้านข้าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

ใช้การตั้งค่าความลึกเมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับเบิล, วัสดุ, และเอฟเฟกต์ข้อความ ในหลายกรณีของรูปทรง ความสูงการดันออกเป็นการตั้งค่าที่ชัดเจนกว่าเพราะแสดงการดันออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D แยกจากการเติมรูปทรง คุณสามารถใช้สีทึบ, การไล่สี, ลาย, หรือการเติมรูปภาพบนหน้าตรงและยังคงใช้กล้อง, แสง, วัสดุ, และการตั้งค่าการดันออกเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีเติมรูปทรงและสีการดันออกที่มืดกว่าไปด้านข้าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

ผลลัพธ์ที่เรนเดอร์จะคงการไล่สีบนหน้าตรงและเรนเดอร์การดันออกแยกต่างหาก:

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการไล่สีจากน้ำเงินไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, เพิ่มรูปไปยังงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

รูปภาพจะถูกเรนเดอร์บนหน้าตรง, ในขณะที่การดันออกจะถูกเรนเดอร์เป็นพื้นผิวด้าน 3D:

![สี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมรูปภาพบนหน้าตรงและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปทรงส่งผลต่อเนื้อหารูปทรง ส่วนการจัดรูปแบบ 3D ของข้อความส่งผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลาย, ใช้การแปลง WordArt, และกำหนดค่าการตั้งค่า 3D บน [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ข้อความจะถูกเรนเดอร์เป็นตัวอักษร 3D โค้ง, ดันออก, มีการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม:

![ข้อความ 3D ที่เรนเดอร์เป็นลักษณะโค้ง, ดันออก, มีการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบที่มีการจัดวางตายตัว ฉาก 3D จะถูกแปลงเป็นภาพราสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น PNG, ส่งออกเป็น PDF, ส่งออกเป็น HTML, หรือสร้างเฟรมสำหรับการแปลงวิดีโอ

จำไว้ว่าเป็นข้อสำคัญต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่เป็นเชิงโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังจากการส่งออก
- ลักษณะที่ปรากฏสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ระบบไฟ, วัสดุ, การดันออก, การเติม, และการปรับขนาดสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม, ให้ใช้ API การจัดรูปแบบที่มีประสิทธิภาพ
- รูปแบบการส่งออกบางประเภทไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ภาพจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D เชิงโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปทรงและข้อความ แต่ไม่ได้ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3D เชิงโต้ตอบที่ผู้ชมสามารถหมุนได้ ในไฟล์ PPTX การจัดรูปแบบ 3D ยังคงสามารถแก้ไขได้ใน PowerPoint หากรูปแบบรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่แทรกเข้าสู่การนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปทรงหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การดันออก, เบเวล, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3D มองเห็นได้?**

อย่างน้อยต้องตั้งการหมุนของกล้องและตั้งค่าการดันออกหรือความลึก ในทางปฏิบัติควรตั้งระบบไฟและวัสดุเพื่อให้หน้าตัดที่เรนเดอร์มีไฮไลต์และเงาที่ชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปทรงและข้อความได้หรือไม่?**

ได้ ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) สำหรับเนื้อหารูปทรงและ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML, หรือเฟรมวิดีโอหรือไม่?**

ปรากฏ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าตัวสุดท้ายของ 3D หลังจากที่มีการสืบทอดและตั้งค่าธีมหรือไม่?**

ได้ ใช้ [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getEffective) เพื่ออ่านค่ากล้อง, ระบบไฟ, เบิล, และค่า 3D ที่เกี่ยวข้องที่ได้จากการสืบทอดและธีม