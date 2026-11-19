---
title: สร้างเอฟเฟ็กต์ 3 มิติในงานนำเสนอโดยใช้ Python
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/python-java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดันออก 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟ็กต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint ใน Python ผ่าน Java ด้วย Aspose.Slides กำหนดค่ากล้อง แสง วัสดุ การดันออก การเติม และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถสร้าง แก้ไข รักษาและเรนเดอร์รูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟ็กต์ 3 มิติ เช่น การหมุน การดันออก (extrusion) การเบเวล (bevels) การให้แสง (lighting) วัสดุ (material) การไล่สีหรือการเติมภาพ และข้อความ 3 มิติ

{{% alert color="info" title="Note" %}}
This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3 มิติให้กับรูปร่าง เมธอดนี้จะคืนค่า [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) วิธีนี้จะใช้การจัดรูปแบบ 3 มิติให้กับกรอบข้อความแทนส่วนเนื้อหารูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อใช้งาน |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | มุมมอง, ประเภทกล้องตั้งค่า, การหมุน, การซูม และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือจับคู่กับการตั้งค่าการหมุน 3 มิติของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | การตั้งค่าแสง, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, เงางาม หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปร่างยืดออกไปด้านหลังจากหน้าฝั่งหน้า | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3 มิติที่มีความหนาเห็นได้ชัด |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ดันออก | ทำให้ความลึกมองเห็นได้หรือปรับสีด้านให้สอดคล้องกับการเติมหน้าฝั่ง |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ | ปรับความลึกสำหรับรูปร่างหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่าเบเวลและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | ขอบยกขึ้นหรือโค้งบนหน้าฝั่งหน้าและหลัง | เพิ่มขอบที่นุ่มนวลหรือเป็นรูปแบบแทนที่ขอบแบนและคม |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตั้งต้นอาจซ่อนไปการดันออก
- การตั้งค่าแสง เนื่องจากแสงทำให้หน้าฝั่งและด้านอ่านได้ง่าย
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันออกหรือความลึก เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า เพิ่มข้อความลงบนหน้าฝั่งหน้า และใช้การจัดรูปแบบ 3 มิติ ค่าการหมุนของกล้องเป็นองศา และความสูงการดันออกเป็น 100 จุด ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ที่มีขนาดเป็นสองเท่าของขนาดเริ่มต้นและบันทึกการนำเสนอเป็น PPTX

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

![สี่เหลี่ยม 3 มิติสีน้ำเงินที่เรนเดอร์พร้อมข้อความ 3 มิติสีขาวบนหน้าฝั่งหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิตถูกกำหนดจากพาเนล 3-D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![พาเนล PowerPoint 3-D Rotation พร้อมค่าการหมุน X, Y, และ Z ที่เน้นให้เห็น](img_02_01.png)

ใน Aspose.Slides ให้เข้าถึงกล้องผ่าน [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) ตัวอย่างนี้สร้างสี่เหลี่ยม ผสานมุมมองหน้าแบบออร์โธกราฟิก และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองเห็นวัตถุ มันไม่เปลี่ยนรูปทรง 2 มิติของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

### **คัดลอกการกำหนดทิศทางกล้องจากรูปร่างต้นแบบ**

เพื่อให้ตรงกับการกำหนดทิศทางของรูปร่างต้นแบบ ให้อ่านการตั้งค่ากล้องจาก [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) และมุมการหมุนจาก [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) ตัวอย่างนี้เปิด `template.pptx` และคัดลอกการกำหนดทิศทางกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3 มิติแล้ว และรูปร่างที่สองไม่มีการหมุนกล้องอย่างชัดเจน

มุมเป็นองศา Index `0` คือ latitude, index `1` คือ longitude, และ index `2` คือ revolution ส่งค่าเหล่านี้ไปที่ [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) ตามลำดับ หากแหล่งคืนค่า `None` แสดงว่าไม่มีการหมุนชัดเจน ดังนั้นจึงเว้นมุมของรูปร่างที่สองไว้โดยไม่ได้กำหนด การหมุนอย่างชัดเจนของ `(0, 0, 0)` จะคืนค่าเป็นศูนย์สามค่าและควรคัดลอก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมื่อคุณเปิด `camera-copy.pptx` ใน PowerPoint อีกครั้ง ลูกศรด้านขวาจะมีการตั้งค่ากล้องและการหมุนเดียวกับสี่เหลี่ยมด้านซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดันออกเดียวกัน

![สี่เหลี่ยม 3 มิติสีน้ำเงินและลูกศรขวาที่มีการกำหนดทิศทางกล้องตรงกัน มองจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยการยืดส่วนหลังจากหน้าฝั่งหน้า ใน PowerPoint ควบคุมความลึกจะกำหนดความหนาที่มองเห็นได้และการควบคุมสีจะกำหนดสีของด้านที่ดันออก

![การควบคุมความลึกของ PowerPoint ที่แมพกับสีการดันออกและคุณสมบัติความสูงการดันออก](img_02_02.png)

ใช้ [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) เพื่อกำหนดความหนาและ [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมดันออก 100 จุดด้วยด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

เมธอด [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) ตั้งค่าความลึกของรูปร่าง 3 มิติ เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) ควบคุมความสูงของเอฟเฟ็กต์การดันออกตามที่แสดงในตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟ็กต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเป็นอิสระจากการเติมของรูปร่าง คุณสามารถใช้สีทึบ, การไล่สี, แพทเทิร์น หรือการเติมภาพบนหน้าฝั่งหน้าและยังคงใช้กล้อง, แสง, วัสดุ, และการตั้งค่าการดันออกเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีจากสีน้ำเงินเป็นสีส้มบนหน้าฝั่งหน้าและสีส้มเข้มบนการดันออก 150 จุด จุดหยุดไล่สีที่ 0 และ 100 เป็นจุดเริ่มและสิ้นสุดของการไล่สี การหมุนของกล้องเป็นองศา สไลด์ถูกเรนเดอร์เป็นภาพ PNG ที่มีขนาดเป็นสองเท่าของขนาดเริ่มต้น:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการไล่สีจากสีน้ำเงินเป็นสีส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพแทน ให้เพิ่มภาพลงในการนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องมีไฟล์ `image.jpg` อยู่ในไดเรกทอรีทำงาน มันขยายภาพเพื่อเติมสี่เหลี่ยม, ดันออก 150 จุด, แล้วตั้งการหมุนของกล้องเป็นองศา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมภาพบนหน้าฝั่งหน้าและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างมีผลต่อเนื้อหารูปร่าง การจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟ็กต์แบบ WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยลายกริดสีส้มและขาว, ใช้การโค้งขึ้น, และกำหนดค่าการตั้งค่า 3 มิติผ่าน [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) ความสูงการดันออกและความลึกเป็นจุด, การหมุนแสงเป็นองศา การเติมและเส้นขอบของรูปร่างถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างนี้เรนเดอร์ภาพ PNG ที่มีขนาดเป็นสองเท่าของสไลด์เริ่มต้นและบันทึกการนำเสนอเป็น PPTX:

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

![ข้อความ 3 มิติที่เรนเดอร์พร้อมการแปลง WordArt โค้ง, การเติมลายสีส้มและการดันออกสีเข้ม](img_02_05.png)

## **รักษาข้อความแบนบนรูปร่าง 3 มิติ**

เพื่อให้ข้อความอ่านง่ายขณะยังคงลักษณะ 3 มิติของรูปร่าง ให้เรียก [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) ผ่าน [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) เมื่อค่าเป็น `True` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อเป็น `False` ข้อความจะเข้าร่วมในฉากและตามการกำหนดทิศทาง 3 มิติ

การตั้งค่านี้ไม่ลบการจัดรูปแบบ 3 มิติของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงกำหนดผ่าน [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) นอกจากนี้ยังแตกต่างจากการหมุนทั่วไป [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) จะหมุนรูปร่างในระนาบสไลด์, ส่วน [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกรอบ การคงข้อความให้อยู่นอกฉาก 3 มิติไม่รีเซ็ตมุมใด ๆ

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาไว้ข้างๆ รูปร่างเดิม ทั้งสองรูปร่างมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงการตั้งค่าข้อความแตกต่างกัน: `False` ทางซ้ายและ `True` ทางขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 จุด ตัวอย่างบันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ที่มีขนาดเป็นสองเท่าของขนาดเริ่มต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

ทางซ้ายข้อความตามการกำหนดทิศทาง 3 มิติ ทางขวาข้อความแบนและอ่านง่ายขึ้น ทั้งสองสี่เหลี่ยมยังคงความหนาการดันออกและการกำหนดทิศทาง 3 มิติที่มองเห็นได้

![สี่เหลี่ยม 3 มิติข้างกัน: ข้อความตามการกำหนดทิศทาง 3 มิติทางซ้ายและแบนบนทางขวา](keep_text_flat.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ ฉาก 3 มิติจะถูกเรสเตอร์หรือวาดลงในผลลัพธ์เป็นภาพ 2 มิติ นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/python-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/python-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/python-java/convert-powerpoint-to-video/)

เก็บประเด็นต่อไปนี้ไว้ในใจ:

- ภาพและ PDF ที่ส่งออกไม่ใช่แบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการรวมกันของกล่อง, แสง, วัสดุ, การดันออก, การเติม, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [คุณสมบัติโครงสร้างรูปแบบที่มีผล](/slides/th/python-java/shape-effective-properties/)
- ฟอร์แมตผลลัพธ์บางชนิดไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในฟอร์แมตเหล่านั้น ผลลัพธ์ที่เห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟ็กต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพ, PDF หรือหน้า HTML เป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากฟอร์แมตสนับสนุน

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟ็กต์ 3 มิติคืออะไร?**

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟ็กต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, เบเวล, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟ็กต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3 มิตมองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดันออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่าแสงและวัสดุด้วยเพื่อให้หน้าฝั่งที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**สามารถใช้เอฟเฟ็กต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ทำได้ ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) สำหรับเนื้อหารูปร่างและ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) สำหรับข้อความ

**เอฟเฟ็กต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ปรากฏ Aspose.Slides เรนเดอร์เอฟเฟ็กต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**สามารถอ่านค่าการจัดรูปแบบ 3 มิติขั้นสุดท้ายหลังจากการสืบทอดและธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีผลอธิบายใน [คุณสมบัติโครงสร้างรูปแบบที่มีผล](/slides/th/python-java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, แสง, เบเวล, และค่าการจัดรูปแบบ 3 มิติที่เกี่ยวข้องอื่น ๆ.