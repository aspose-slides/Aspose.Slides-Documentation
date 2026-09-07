---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอด้วย Python
linktitle: พรีเซนเทชัน 3 มิติ
type: docs
weight: 232
url: /th/python-java/3d-presentation/
keywords:
- 3 มิติ PowerPoint
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การยืดออก 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปทรงและข้อความ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides. ตั้งค่ากล้อง, การจัดแสง, วัสดุ, การยืดออก, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถสร้าง แก้ไข รักษา และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน การยืดออก การขอบโค้ง การจัดแสง วัสดุ การไล่ระดับสีหรือการเติมภาพ และข้อความ 3 มิติ

{{% alert color="info" title="หมายเหตุ" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบแยกส่วน เมื่อคุณส่งออกสไลด์เป็นภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

ติดตั้งแพ็กเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/)。แต่ละตัวอย่างจะนำเข้า `asposeslides` เริ่ม JVM หากจำเป็น แล้วนำเข้า API ตัวอย่างการเติมภาพต้องใช้ไฟล์ `image.jpg` ในโฟลเดอร์ทำงาน

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) เพื่อทำการจัดรูปแบบ 3 มิติให้กับรูปทรง วัตถุที่ส่งกลับจะควบคุมฉาก 3 มิติของรูปทรงนั้น

สำหรับข้อความ ใช้ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) เพื่อจัดรูปแบบ 3 มิติให้กับเฟรมข้อความแทนส่วนเนื้อหาของรูปทรง

สมาชิก API ที่สำคัญที่สุดมีดังนี้

| สมาชิก API | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getCamera) | มุมมอง, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่ากล้องหมุนที่กำหนดไว้ใน PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getLightRig) | การตั้งค่าการส่องแสง, ทิศทาง, การหมุนแสง | ปรับวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getMaterial) และ [setMaterial](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setMaterial) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, มันวาวหรือเงาโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionHeight) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปทรงยืดออกจากหน้าหน้า | แปลงรูปทรงแบนให้เป็นวัตถุ 3 มิติที่มองเห็นความหนา |
| [getExtrusionColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ยืดออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าหน้า |
| [getDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getDepth) และ [setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setDepth) | ความลึกเพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ 3 มิติ | ปรับความลึกอย่างละเอียดสำหรับรูปทรงหรือข้อความ โดยเฉพาะร่วมกับการตั้งค่าขอบโค้งและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelTop) และ [getBevelBottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getBevelBottom) | ขอบที่ยกขึ้นหรือโค้งบนพื้นหน้าและพื้นหลัง | เพิ่มขอบโค้งหรือทำให้ขอบดูอ่อนนุ่มแทนที่หน้าที่แบนและคม |
| [getContourColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getContourWidth) และ [setContourWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปทรงมักต้องการการตั้งค่าสี่ประเภทก่อนจะดูเหมือน 3 มิติอย่างสมจริง

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าเริ่มต้นอาจทำให้การยืดออกไม่เห็นชัด
- การตั้งค่าแสง เนื่องจากแสงทำให้ด้านและข้างของรูปทรงอ่านได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการสะท้อนแสง
- การตั้งค่าการยืดออกหรือความลึก เนื่องจากรูปแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม เพิ่มข้อความบนหน้าหน้า ใช้การจัดรูปแบบ 3 มิติ บันทึกเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

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

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้าผลลัพธ์ที่แสดงข้อความ 3 มิติสีขาวบนพื้นหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติกำหนดจากแผง 3‑D Rotation ค่าการหมุน X, Y และ Z สอดคล้องกับการตั้งค่าที่ทำผ่าน API ของกล้อง

![แผงการหมุน 3 มิติของ PowerPoint แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลต์](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าประเภทกล้องและการหมุนผ่านรูปแบบ 3 D ที่ส่งกลับโดย [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat):

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนมุมมองที่ผู้ชมเห็นวัตถุ ไม่ได้เปลี่ยนรูปทรง 2 D บนสไลด์ แต่เปลี่ยนมุมมอง 3 D ที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการยืดออกและความลึก**

การยืดออกทำให้รูปทรงดูหนาด้วยการขยายไปด้านหลังของหน้าหน้า ใน PowerPoint ค่าความลึกกำหนดความหนาที่มองเห็นได้และค่าข้างสีกำหนดสีของด้านข้าง

![การตั้งค่าความลึกของ PowerPoint เชื่อมกับคุณสมบัติสีการยืดออกและความสูงการยืดออก](img_02_02.png)

ตั้งค่าความสูงการยืดออกสำหรับความหนาและสีการยืดออกสำหรับสีด้านข้าง:

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

ใช้การตั้งค่าความลึกเมื่อคุณต้องการทำงานกับค่าความลึกของ PowerPoint ตรง ๆ หรือรวมความลึกกับขอบโค้ง, วัสดุและเอฟเฟกต์ข้อความ ในหลายกรณีการตั้งค่าความสูงการยืดออกจะชัดเจนกว่าเพราะแสดงความยืดออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติทำงานแยกจากการเติมรูปทรง คุณสามารถใช้สีทึบ, การไล่สี, ลวดลาย หรือการเติมภาพบนหน้าหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุและการยืดออกเหมือนเดิม

ตัวอย่างนี้ใช้การไล่สีบนรูปทรงและสีการยืดออกที่เข้มขึ้นบนด้านข้าง:

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

ผลลัพธ์ที่เรนเดอร์ยังคงการไล่สีบนหน้าหน้าและแยกการเรนเดอร์การยืดออก:

![สี่เหลี่ยม 3 มิติที่แสดงผลด้วยการไล่สีจากฟ้าเป็นส้ม และการยืดออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ ให้เพิ่มรูปภาพลงในพรีเซนเทชันและกำหนดให้เป็นการเติมรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

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

รูปภาพจะถูกเรนเดอร์บนหน้าหน้า ส่วนการยืดออกจะถูกเรนเดอร์เป็นพื้นผิวด้านข้าง 3 D:

![สี่เหลี่ยม 3 มิติที่แสดงผลด้วยการเติมภาพบนพื้นหน้าและการยืดออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปทรงมีผลต่อส่วนเนื้อหาของรูปทรง ส่วนการจัดรูปแบบ 3 มิติของข้อความมีผลต่อเฟรมข้อความ ซึ่งเหมาะกับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการยืดออก, วัสดุ, การจัดแสงและการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความที่มีการเติมลวดลาย ใช้การแปลง WordArt แบบโค้ง และกำหนดค่าการจัดรูปแบบ 3 มิติบน [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/):

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

ข้อความถูกเรนเดอร์เป็นอักษร 3 มิติที่โค้ง, ยืดออก, มีการเติมลวดลายสีส้ม และการยืดออกสีเข้ม:

![ข้อความ 3 มิติที่เรนเดอร์ด้วยการแปลง WordArt แบบโค้ง, การเติมลวดลายสีส้ม, และการยืดออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบตายตัว ฉาก 3 มิติจะถูกแปลงเป็นภาพราสเตอร์หรือวาดลงในผลลัพธ์เป็น 2 D ทั้งนี้ใช้เมื่อเรนเดอร์สไลด์เป็น PNG, ส่งออกเป็น PDF, ส่งออกเป็น HTML หรือสร้างเฟรมสำหรับการแปลงวิดีโอ

ควรจำไว้ว่า:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นกับการรวมกันของกล้อง, ระบบแสง, วัสดุ, การยืดออก, การเติมและการปรับสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้ใช้ API การจัดรูปแบบที่มีผลจริง
- บางรูปแบบผลลัพธ์ไม่สามารถเก็บการจัดรูปแบบ 3 มิติที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ได้ทำให้ภาพที่ส่งออก, PDF หรือหน้า HTML เป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint ที่รองรับรูปแบบนั้น

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติคือวัตถุ 3 มิติแยกที่ถูกแทรกเข้าไปในพรีเซนเทชัน ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปทรงหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การยืดออก, ขอบโค้ง, การจัดแสงและวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3 มิติมองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและตั้งค่าการยืดออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่าระบบแสงและวัสดุเพื่อให้หน้าฝั่งมีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปทรงและข้อความได้หรือไม่?**

ได้ ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getThreeDFormat) สำหรับส่วนเนื้อหารูปร่าง และ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getThreeDFormat) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML และเฟรมที่ใช้สำหรับแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ไว้ ไม่ได้เป็นวัตถุ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติขั้นสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getEffective) เพื่ออ่านค่ากล้อง, ระบบแสง, ขอบโค้งและค่าที่เกี่ยวข้องกับ 3 มิติขั้นสุดท้าย