---
title: สร้างเอฟเฟกต์ 3D ในงานนำเสนอโดยใช้ Python
linktitle: งานนำเสนอ 3D
type: docs
weight: 232
url: /th/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- งานนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดันออก 3D
- การไล่สี 3D
- ข้อความ 3D
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความของ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides. ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถสร้าง แก้ไข คงไว้และเรนเดอร์การจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน การดันออก (extrusion) การตัดมุม (bevels) การให้แสง วัสดุ การไล่สีหรือการเติมภาพ และข้อความ 3D

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

ติดตั้งแพ็กเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะ import `asposeslides` เริ่ม JVM หากจำเป็น แล้วจึง import API ตัวอย่างการเติมภาพต้องใช้ไฟล์ `image.jpg` ในไดเรกทอรีทำงาน

## **แนวคิดการจัดรูปแบบ 3D**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3D กับรูปทรง วัตถุรูปแบบที่ส่งกลับจะควบคุมฉาก 3D สำหรับรูปทรงนั้น

สำหรับข้อความ ใช้ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) สิ่งนี้จะใช้การจัดรูปแบบ 3D กับเฟรมข้อความแทนเนื้อหารูปทรง

สมาชิก API ที่สำคัญที่สุดมีดังนี้:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getCamera) | มุมมอง ประเภทกล้องตั้งต้น การหมุน เลนส์ซูม และมุมมองตาม perspektive | หมุนวัตถุในอวกาศ 3D หรือใช้ค่าการหมุน 3D ที่กำหนดไว้ใน PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getLightRig) | แสงตั้งต้น ทิศทาง และการหมุนแสง | ปรับวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3D |
| [getMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getMaterial) และ [setMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setMaterial) | วัสดุผิว เช่น แบน แมตต์ พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนนุ่ม แววสีหรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionHeight) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปทรงยื่นออกจากหน้าตัดด้านหน้า | แปลงรูปแบนให้กลายเป็นอ็อบเจ็กต์ 3D ที่มีความหนาเห็นได้ชัด |
| [getExtrusionColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ยื่นออก | ทำให้ความลึกมองเห็นได้หรือปรับสีด้านให้สอดคล้องกับสีเต็มของด้านหน้า |
| [getDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getDepth) และ [setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setDepth) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกสำหรับรูปทรงหรือข้อความ โดยเฉพาะเมื่อตั้งค่า bevel และ material ร่วมกัน |
| [getBevelTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelTop) และ [getBevelBottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelBottom) | ขอบยกหรือโค้งบนหน้าตัดหน้าและหลัง | เพิ่มขอบที่อ่อนหรือเป็นแม่พิมพ์แทนหน้าตัดแบนคม |
| [getContourColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourWidth) และ [setContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบอ็อบเจ็กต์ 3D | เน้นขอบอ็อบเจ็กต์ในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปทรง 3D**

รูปทรงมักต้องการการตั้งค่าสี่ประเภทก่อนจะแสดงเป็น 3D อย่างสมบูรณ์:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดันออก
- การตั้งค่าแสง เนื่องจากแสงทำให้ด้านและด้านข้างอ่านได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันออกหรือความลึก เนื่องจากรูปแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม เพิ่มข้อความบนหน้าตัดหน้า ใช้การจัดรูปแบบ 3D บันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

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

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3D หนา:

![รูปสี่เหลี่ยม 3D สีน้ำเงินที่เรนเดอร์แล้วพร้อมข้อความ 3D สีขาวบนหน้าด้านหน้า](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดจากแผง 3‑D Rotation ค่า X, Y และ Z เกี่ยวข้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง 3‑D Rotation ของ PowerPoint ที่ไฮไลต์ค่า X, Y และ Z](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าประเภทกล้องและการหมุนผ่าน 3D format ที่ได้จาก [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat):

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองอ็อบเจ็กต์ ไม่ได้เปลี่ยนรูปทรง 2D บนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปทรงดูหนาโดยขยายไปด้านหลังหน้าตัดหน้า ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่แมพไปยังคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ตั้งค่าความสูงการดันออกเพื่อกำหนดความหนาและสีการดันออกเพื่อกำหนดสีด้านข้าง:

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

ใช้การตั้งค่าความลึกเมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือผสานความลึกกับ bevel, material และเอฟเฟกต์ข้อความ ในหลายกรณีการตั้งค่าความสูงการดันออกชัดเจนกว่าเพราะบ่งบอกการดันออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D ไม่ผูกพันกับการเติมรูปทรง คุณสามารถกำหนดสีทึบ, การไล่สี, แบบลายหรือการเติมภาพบนหน้าตัดหน้าและยังใช้การตั้งค่ากล้อง, แสง, วัสดุและการดันออกเดียวกัน

ตัวอย่างนี้เติมการไล่สีให้รูปทรงและตั้งค่าสีการดันออกให้เข้มกว่า

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

ผลลัพธ์ที่เรนเดอร์ยังคงการไล่สีบนหน้าตัดหน้าและเรนเดอร์การดันออกแยกต่างหาก:

![รูปสี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการไล่สีจากน้ำเงินไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ ให้เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง:

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

ภาพจะถูกเรนเดอร์บนหน้าตัดหน้า ส่วนการดันออกจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3D:

![รูปสี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมภาพบนหน้าตัดหน้าและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปทรงมีผลต่อเนื้อหารูปทรง ส่วนการจัดรูปแบบ 3D ของข้อความมีผลต่อเฟรมข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการดันออก, วัสดุ, แสงและการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลาย pattern, ใช้การแปลง WordArt และตั้งค่า 3D บน [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/):

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

ข้อความจะถูกเรนเดอร์เป็นตัวอักษร 3D โค้ง, ดันออกและมีการเติมลายสีส้มและการดันออกสีเข้ม:

![ข้อความ 3D ที่เรนเดอร์ด้วยการแปลง WordArt โค้ง, การเติมลายสีส้มและการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3D ไว้เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกไปยังรูปแบบที่มีเลย์เอาต์คงที่ ฉาก 3D จะถูกแรสเตอร์ไทซ์หรือวาดลงในผลลัพธ์เป็น 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น PNG, ส่งออกเป็น PDF, HTML หรือสร้างเฟรมสำหรับการแปลงเป็นวิดีโอ

ควรจำไว้:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ ผู้ชมไม่สามารถหมุนอ็อบเจ็กต์หลังการส่งออกได้
- รูปลักษณ์สุดท้ายขึ้นกับการผสานของกล้อง, light rig, material, extrusion, fill และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้ใช้ API การจัดรูปแบบที่มีประสิทธิภาพ
- รูปแบบผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์จะถูกเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างงานนำเสนอ 3D แบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ทำให้ภาพที่ส่งออก, PDF หรือหน้า HTML เป็นฉาก 3D ที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คืออ็อบเจ็กต์ 3D แยกที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปทรงหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, bevel, แสงและวัสดุ บทความนี้อธิบายเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3D ปรากฏ?**

อย่างน้อยต้องตั้งการหมุนกล้องและตั้งค่าการดันออกหรือความลึก ในการปฏิบัติจริงควรตั้ง light rig และ material ด้วยเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**สามารถใช้เอฟเฟกต์ 3D กับรูปทรงและข้อความได้หรือไม่?**

ได้ ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) สำหรับเนื้อหารูปทรงและ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML และเฟรมที่ใช้สำหรับแปลงเป็นวิดีโอ ผลลัพธ์ที่ส่งออกจะมีรูปลักษณ์ที่เรนเดอร์แล้ว ไม่ใช่อ็อบเจ็กต์ 3D ที่แก้ไขได้

**สามารถอ่านค่าการจัดรูปแบบ 3D สุดท้ายหลังจากการสืบทอดและธีมถูกนำไปใช้ได้หรือไม่?**

ได้ ใช้ [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getEffective) เพื่ออ่านค่ากล้อง, light rig, bevel และค่าต่าง ๆ ของ 3D ที่ได้หลังจากการสืบทอดและธีมถูกนำไปใช้