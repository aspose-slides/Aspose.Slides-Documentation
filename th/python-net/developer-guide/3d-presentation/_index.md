---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนองานด้วย Python
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดัน 3D
- ไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ประยุกต์ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปทรงและข้อความของ PowerPoint ด้วย Python และ Aspose.Slides. กำหนดค่ากล้อง, แสงสว่าง, วัสดุ, การดันสู่ภาคลึก, การเติมสี, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถสร้าง, แก้ไข, รักษา และเรนเดอร์การจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน, การดันสู่ภาคลึก, การทำ bevel, แสงสว่าง, วัสดุ, การเติมสีไล่สีหรือภาพ, และข้อความ 3D.

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นรูปภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นเข้าไปในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้คุณสมบัติ [Shape.three_d_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/three_d_format/) เพื่อทำการจัดรูปแบบ 3D ให้กับรูปร่าง คุณสมบัตินี้เปิดเผย [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/), ซึ่งควบคุมฉาก 3D สำหรับรูปร่างนั้น

สำหรับข้อความ, ใช้คุณสมบัติ [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/three_d_format/) การทำเช่นนี้จะจัดรูปแบบ 3D ให้กับกรอบข้อความแทนส่วนของรูปร่าง

คุณสมบัติที่สำคัญที่สุดคือ:

| คุณสมบัติ | สิ่งที่ควบคุม | เมื่อใดที่ใช้ |
|---|---|---|
| [camera](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/camera/) | มุมมอง, ประเภทกล้องที่กำหนดไว้ล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงมิติ | หมุนวัตถุในพื้นที่ 3D หรือจับคู่กับการตั้งค่าการหมุน 3D ของ PowerPoint ที่กำหนดไว้ล่วงหน้า |
| [light_rig](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/light_rig/) | การตั้งค่าแสงล่วงหน้า, ทิศทาง, และการหมุนของแสง | เปลี่ยนลักษณะของไฮไลท์และเงาบนพื้นผิว 3D |
| [material](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/material/) | วัสดุพื้นผิว เช่น แบน, แมท, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, เงางาม, หรือเป็นโลหะ |
| [extrusion_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/extrusion_height/) | ระยะที่รูปร่างยืดออกไปด้านหลังจากหน้า | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3D ที่มีความหนาชัดเจน |
| [extrusion_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/extrusion_color/) | สีของด้านที่ดันออก | ทำให้ความลึกเห็นได้หรือประสานสีด้านกับการเติมหน้าตรง |
| [depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/depth/) | ความลึก 3D เพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3D ของ PowerPoint | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ, โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่า bevel และ material |
| [bevel_top](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/bevel_bottom/) | ขอบที่ยกขึ้นหรือโค้งมนบนหน้าและด้านหลัง | เพิ่มขอบที่นุ่มหรือหล่อแทนหน้าที่แบนและคม |
| [contour_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/contour_width/) | เส้นรอบนอกของวัตถุ 3D | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3D**

โดยทั่วไปรูปร่างต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูเหมือน 3D อย่างเชื่อมั่น:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดันสู่ภาคลึก
- การตั้งค่าแสง, เนื่องจากแสงทำให้ด้านและขอบสามารถมองเห็นได้
- การตั้งค่าเนื้อวัสดุ, เนื่องจากพื้นผิวมีผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันสู่ภาคลึกหรือความลึก, เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า, เพิ่มข้อความไปยังหน้า, ใส่การจัดรูปแบบ 3D, บันทึกการนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมผืนผ้าเป็นบล็อก 3D ที่หนา:

![สี่เหลี่ยม 3D สีน้ำเงินที่เรนเดอร์พร้อมข้อความ 3D สีขาวบนหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ตั้งค่าจากแผง 3-D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง.

![แผง 3-D Rotation ของ PowerPoint พร้อมค่าการหมุน X, Y, และ Z ถูกไฮไลท์](img_02_01.png)

ใน Aspose.Slides, ตั้งค่าชนิดกล้องและการหมุนผ่าน [ThreeDFormat.camera](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองเห็นวัตถุ ไม่ได้เปลี่ยนรูปทรง 2D ของรูปร่างบนสไลด์ แต่จะเปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อทำการเรนเดอร์.

## **เพิ่มการดันสู่ภาคลึกและความลึก**

การดันสู่ภาคลึกทำให้รูปร่างดูหนาโดยขยายไปด้านหลังของหน้า ใน PowerPoint ควบคุมความลึกจะตั้งความหนาที่มองเห็นได้และควบคุมสีจะตั้งสีของด้านข้าง.

![การควบคุมความลึกของ PowerPoint ที่แมพกับคุณสมบัติ extrusion color และ extrusion height](img_02_02.png)

ตั้งค่า [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/extrusion_height/) เพื่อกำหนดความหนาและ [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/extrusion_color/) เพื่อกำหนดสีของด้านข้าง:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

ใช้ [ThreeDFormat.depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/depth/) เมื่อคุณต้องการทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายสถานการณ์ของรูปร่าง, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/extrusion_height/) เป็นการตั้งค่าที่ชัดเจนกว่าเพราะมันแสดงการดันสู่ภาคลึกที่มองเห็นได้โดยตรง.

## **ใช้การเติมไล่สีหรือรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D แยกจากการเติมสีของรูปร่าง คุณสามารถใช้สีทึบ, ไล่สี, ลวดลาย หรือการเติมรูปภาพบนหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันสู่ภาคลึกเดียวกัน

ตัวอย่างนี้ใช้การเติมไล่สีให้กับรูปร่างและสี extrusion ที่มืดกว่าบนด้านข้าง:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

ผลลัพธ์ที่เรนเดอร์จะคงไล่สีบนหน้าและเรนเดอร์การดันสู่ภาคลึกแยกกัน:

![สี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมไล่สีจากน้ำเงินไปส้มและ extrusion สีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปร่าง:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

รูปภาพจะถูกเรนเดอร์บนหน้า ในขณะที่ extrusion จะถูกเรนเดอร์เป็นพื้นผิวด้าน 3D:

![สี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมรูปภาพบนหน้าและ extrusion สีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อส่วนของรูปร่าง ส่วนของการจัดรูปแบบ 3D ของข้อความส่งผลต่อกรอบข้อความ สิ่งนี้เป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดันสู่ภาคลึก, วัสดุ, แสงสว่าง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลวดลาย, ใช้การแปลง WordArt, และกำหนดค่าการตั้งค่า 3D บน [TextFrameFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/):

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

ข้อความจะถูกเรนเดอร์เป็นตัวอักษร 3D โค้งและดันสู่ภาคลึก:

![ข้อความ 3D ที่เรนเดอร์ด้วยการแปลง WordArt โค้ง, การเติมลวดลายสีส้ม, และ extrusion สีเข้ม](img_02_05.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides จะคงการจัดรูปแบบ 3D ไว้เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อทำการเรนเดอร์หรือส่งออกเป็นรูปแบบ Layout คงที่, ฉาก 3D จะถูกแปลงเป็นราสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/python-net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/python-net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/python-net/convert-powerpoint-to-video/).

จดจำประเด็นต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่ใช่แบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออกได้.
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, light rig, material, extrusion, การเติมสี, และการปรับขนาดสไลด์.
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม, อ่าน [คุณสมบัติรูปร่างที่มีผล](/slides/th/python-net/shape-effective-properties/).
- รูปแบบผลลัพธ์บางอย่างไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้.

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D แบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ แต่ไม่ได้ทำให้ภาพที่ส่งออก, PDF, หรือหน้า HTML เป็นฉาก 3D แบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงเป็นแบบแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่ถูกแทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความของ PowerPoint ปกติ เช่น การหมุน, การดันสู่ภาคลึก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**การตั้งค่าใดบ้างที่จำเป็นสำหรับรูปร่าง 3D ที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดันสู่ภาคลึกหรือความลึก ในการปฏิบัติ ควรตั้งค่า light rig และ material ด้วยเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [Shape.three_d_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/three_d_format/) สำหรับส่วนของรูปร่างและ [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/three_d_format/) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นรูปภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D เมื่อผลิตภาพสไลด์, PDF, HTML และเฟรมที่ใช้ในการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะการเรนเดอร์ ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าขั้นสุดท้ายของ 3D หลังจากการสืบทอดและการตั้งค่าธีมถูกนำไปใช้ได้หรือไม่?**

ใช่ ใช้ API การจัดรูปแบบที่มีผลที่อธิบายไว้ใน [คุณสมบัติรูปร่างที่มีผล](/slides/th/python-net/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, bevel, และค่าที่เกี่ยวข้องของ 3D ที่สุดท้าย.