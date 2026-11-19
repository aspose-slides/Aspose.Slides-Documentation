---
title: สร้างเอฟเฟกต์ 3D ในงานนำเสนอโดยใช้ Python
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/python-net/3d-presentation/
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
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความของ PowerPoint ใน Python ด้วย Aspose.Slides. ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถสร้าง แก้ไข รักษา และแสดงผลการจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน การดันออก (extrusion) เบเวล การให้แสง วัสดุ การไล่สีหรือการเติมรูปภาพ และข้อความ 3D

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แบบแยกส่วน เมื่อคุณส่งออกสไลด์เป็นรูปภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้คุณสมบัติ [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) เพื่อใช้การจัดรูปแบบ 3D กับรูปร่าง คุณสมบัตินี้เปิดเผย [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) ซึ่งควบคุมฉาก 3D สำหรับรูปร่างนั้น

สำหรับข้อความ ใช้คุณสมบัติ [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) ซึ่งจะใช้การจัดรูปแบบ 3D กับกรอบข้อความแทนส่วนของรูปร่าง

คุณสมบัติที่สำคัญที่สุดคือ:

| คุณสมบัติ | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | มุมมอง, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และการมองเห็นแบบเพอร์สเปคทีฟ | หมุนวัตถุในพื้นที่ 3D หรือให้ตรงกับการตั้งค่าการหมุน 3D ของ PowerPoint |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | การตั้งค่าส่องแสง, ทิศทาง, และการหมุนของแสง | เปลี่ยนลักษณะไฮไลท์และเงาบนพื้นผิว 3D |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | วัสดุผิวหน้า เช่น แบน, แมต, พลาสติก หรือโลหะ | ทำให้เรขาคณิตเดียวกันดูแบนกว่า, นุ่มกว่า, มีความเงาหรือเป็นโลหะ |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | ระยะที่รูปร่างยืดออกไปด้านหลังจากหน้าหน้า | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3D ที่มีความหนาแน่นที่มองเห็นได้ |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | สีของด้านที่ดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับสีเติมหน้าหน้า |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ | ปรับแต่งความลึกสำหรับรูปร่างหรือข้อความ โดยเฉพาะร่วมกับการตั้งค่าเบเวลและวัสดุ |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | ขอบยกขึ้นหรือโค้งบนพื้นหน้าและหลัง | เพิ่มขอบที่นุ่มหรือเป็นรูปร่างแทนผิวแบนคม |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | เส้นขอบรอบวัตถุ 3D | ทำให้ขอบวัตถุมองเห็นชัดเจนในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3D**

รูปร่างมักต้องการการตั้งค่า 4 ประเภทก่อนที่จะแสดงเป็น 3D อย่างสมจริง:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดันออก
- การตั้งค่าแสง เนื่องจากแสงทำให้ด้านและข้างของรูปร่างมองเห็นได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันออกหรือความลึก เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม เพิ่มข้อความลงบนหน้าหน้า และใช้การจัดรูปแบบ 3D ค่าการหมุนของกล้องเป็นองศา และความสูงการดันออกเป็น 100 จุด ตัวอย่างเรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้นและบันทึกพรีเซนเทชันเป็น PPTX

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

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3D หนา

![สี่เหลี่ยม 3D สีฟ้าแสดงผลพร้อมข้อความ 3D สีขาวบนหน้าหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดจากแผง 3‑D Rotation ค่าการหมุน X, Y, และ Z ตรงกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผงการหมุน 3‑D ของ PowerPoint ที่แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลต์](img_02_01.png)

ใน Aspose.Slides เข้าถึงกล้องผ่าน [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) ตัวอย่างนี้สร้างสี่เหลี่ยม เลือกมุมมองหน้าความเป็นออร์โธกราฟิก และตั้งค่าการหมุน X, Y, Z เป็น 20°, 30°, 40° ตามลำดับ โดยกำหนดรูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมเห็นวัตถุ มันไม่เปลี่ยนรูปร่าง 2D บนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อต้องเรนเดอร์

### **คัดลอกการกำหนดทิศทางกล้องจากรูปร่างแม่แบบ**

เพื่อให้ตรงกับการกำหนดทิศทางของรูปร่างแม่แบบ ให้คัดลอกพรีเซ็ต [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) และอ่านการหมุนด้วย [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) ตัวอย่างเปิด `template.pptx` แล้วคัดลอกการกำหนดทิศทางของกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3D อยู่แล้วและรูปร่างที่สองไม่มีการกำหนดการหมุนของกล้องอย่างชัดเจน

ค่ามุมเป็นองศา ดัชนี `0`, `1`, `2` แทนละติจูด, ลองจิจูด, และการหมุนตามลำดับ ส่งค่าดังกล่าวให้กับ [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) ตามลำดับ หากแหล่งไม่มีการกำหนดการหมุน `get_rotation` จะคืนค่า `None` ดังนั้นให้ปล่อยมุมของปลายทางว่างไว้ หากแหล่งกำหนดมุมทั้งสามเป็นศูนย์ให้คัดลอกศูนย์เหล่านั้น

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

เมื่อคุณเปิด `camera-copy.pptx` ใน PowerPoint อีกทั้งสองรูปร่างจะมีพรีเซ็ตกล้องและการหมุนเดียวกัน ลูกศรทางขวาใช้การกำหนดทิศทางที่คัดลอกจากสี่เหลี่ยมทางซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดันออกเดียวกัน

![สี่เหลี่ยม 3D สีน้ำเงินและลูกศรขวาที่มีการกำหนดทิศทางกล้องตรงกัน, มองจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาด้วยการขยายไปด้านหลังจากหน้าหน้า ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่เชื่อมโยงกับคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ตั้งค่า [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) เพื่อกำหนดความหนาและ [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) เพื่อกำหนดสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมการดันออก 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา ตัวอย่างกำหนดรูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

คุณสมบัติ [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) ตั้งค่าความลึกของรูปร่าง 3D คุณสมบัติ [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) ควบคุมความสูงของเอฟเฟกต์การดันออกตามตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D เป็นอิสระจากการเติมของรูปร่าง คุณสามารถใช้สีทึบ, การไล่สี, พาเทิร์น หรือการเติมรูปภาพบนหน้าหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันออกเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีจากฟ้าไปส้มบนหน้าหน้าและสีส้มบนการดันออก 150 จุด จุดหยุดของการไล่สีที่ 0 และ 100 แสดงจุดเริ่มต้นและสิ้นสุดของการไล่สี ค่าการหมุนของกล้องเป็นองศา สไลด์เรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้น

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

ภาพที่เรนเดอร์รักษาการไล่สีบนหน้าหน้าและเรนเดอร์การดันออกแยกกัน

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการไล่สีจากสีฟ้าไปสีส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพ ให้เพิ่มรูปไปยังพรีเซนเทชันแล้วกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องมีไฟล์ `image.jpg` อยู่ในไดเรกทอรีทำงาน มันขยายรูปให้เต็มสี่เหลี่ยม ใช้การดันออก 150 จุดและตั้งค่าการหมุนของกล้องเป็นองศา ตัวอย่างกำหนดรูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

รูปภาพถูกเรนเดอร์บนหน้าหน้า ในขณะที่การดันออกแสดงเป็นพื้นผิวด้านข้าง 3D

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการเติมรูปภาพบนหน้าหน้าและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างมีผลต่อส่วนของรูปร่างเอง ส่วนการจัดรูปแบบ 3D ของข้อความมีผลต่อกรอบข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์คล้าย WordArt ที่อักขระต้องการการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยพาเทิร์นกริดสีส้ม‑ขาว ประยุกต์โค้งขึ้น และกำหนดค่าการจัดรูปแบบ 3D ผ่าน [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) ความสูงและความลึกของการดันออกเป็นจุด และการหมุนแสงเป็นองศา การเติมและขอบของรูปร่างถูกซ่อนไว้เพื่อให้เห็นข้อความเพียงอย่างเดียว ตัวอย่างเรนเดอร์ภาพ PNG ที่ขนาดสองเท่าของสไลด์เริ่มต้นและบันทึกพรีเซนเทชันเป็น PPTX

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

ข้อความที่เรนเดอร์เป็นตัวอักษร 3D โค้งพร้อมการดันออกสีเข้มและการเติมพาเทิร์นสีส้ม

![ข้อความ 3D ที่เรนเดอร์พร้อมการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **คงข้อความให้แบนบนรูปร่าง 3D**

เพื่อให้ข้อความอ่านง่ายขณะคงลักษณะ 3D ของรูปร่าง ตั้งค่า [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) ผ่าน [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) ค่า `True` ทำให้ข้อความอยู่นอกฉาก 3D ค่า `False` ทำให้ข้อความเข้าร่วมฉากและตามแนว 3D

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3D ของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงถูกกำหนดผ่าน [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) อีกทั้งยังแตกต่างจากการหมุนทั่วไป [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) หมุนรูปร่างในระนาบสไลด์ ส่วน [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกรอบ การเก็บข้อความให้อยู่นอกฉาก 3D จะไม่รีเซ็ตมุมใด ๆ เหล่านี้

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาข้าง ๆ ดั้งเดิม ทั้งสองรูปร่างมีการจัดรูปแบบ 3D เดียวกัน; เพียงการตั้งค่าข้อความที่ต่างกัน: `False` ทางซ้ายและ `True` ทางขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 จุด ตัวอย่างบันทึกพรีเซนเทชันเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของขนาดเริ่มต้น

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

ทางซ้ายข้อความตามแนว 3D ทางขวาข้อความอยู่แบนและอ่านง่ายขึ้น ทั้งสองสี่เหลี่ยมยังคงความลึกการดันออกและแนว 3D ที่มองเห็นได้เหมือนกัน

![สี่เหลี่ยม 3D ข้างกัน: keep_text_flat เป็น False ทางซ้ายและ True ทางขวา](keep_text_flat.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบคงที่ ฉาก 3D จะถูกแปลงเป็นภาพราสเตอร์หรือวาดลงในผลลัพธ์เป็น 2D ซึ่งเกิดขึ้นเมื่อตอนเรนเดอร์สไลด์เป็น [PNG](/slides/th/python-net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/python-net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/python-net/convert-powerpoint-to-video/)

จดจำประเด็นต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่เป็นเชิงโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ระบบแสง, วัสดุ, การดันออก, การเติม, และการปรับขนาดสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [คุณสมบัติรูปร่างที่ใช้ได้จริง](/slides/th/python-net/shape-effective-properties/)
- รูปแบบผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D เชิงโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพที่ส่งออก, PDF หรือหน้า HTML เป็นฉาก 3D เชิงโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงสามารถแก้ไขใน PowerPoint ได้หากรูปแบบสนับสนุน

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, เบเวล, แสง, และวัสดุ บทความนี้อธิบายเอฟเฟ็กต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3D ปรากฏชัด?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดันออกหรือความลึก ในทางปฏิบัติควรตั้งค่าระบบแสงและวัสดุเพื่อให้หน้าตัดมีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) สำหรับส่วนของรูปร่างและ [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะแสดงผลเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ เนื่องจาก Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D ลงในผลลัพธ์ที่ส่งออก ไม่ได้ส่งออกเป็นวัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าตัวเลข 3D สุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [คุณสมบัติรูปร่างที่ใช้ได้จริง](/slides/th/python-net/shape-effective-properties/) เพื่ออ่านกล้อง, ระบบแสง, เบเวล, และค่าที่เกี่ยวข้องกับ 3D สุดท้าย.