---
title: เพิ่มลายน้ำในงานพรีเซ็นเทชันด้วย Python
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/python-net/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- เปลี่ยนลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำใน PPT
- เพิ่มลายน้ำใน PPTX
- เพิ่มลายน้ำใน ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการลายน้ำข้อความและลายน้ำรูปภาพในงานพรีเซ็นเทชัน PowerPoint และ OpenDocument ด้วย Python เพื่อแสดงสถานะฉบับร่าง ข้อมูลลับ ลิขสิทธิ์ และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานพรีเซ็นเทชันคือสติ๊กเกอร์เป็นข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทุกสไลด์ของงานพรีเซ็นเทชัน โดยทั่วไปลายน้ำจะใช้เพื่อบ่งชี้ว่าผลงานเป็นฉบับร่าง (เช่นลายน้ำ “Draft”) ว่าประกอบด้วยข้อมูลลับ (เช่นลายน้ำ “Confidential”) เพื่อระบุว่าผลงานเป็นของบริษัทใด (เช่นลายน้ำ “Company Name”) เพื่อระบุตัวผู้สร้างงานพรีเซ็นเทชัน ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบอกว่าผลงานไม่ควรถูกคัดลอก ลายน้ำใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำลงในไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/python-net/), มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับเปลี่ยนการออกแบบและพฤติกรรมของมัน ส่วนร่วมคือเมื่อต้องการเพิ่มลายน้ำข้อความ คุณควรใช้คลาส [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) และเมื่อต้องการเพิ่มลายน้ำภาพ ให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปร่างลายน้ำ `PictureFrame` implements the [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) class, allowing you to use all the flexible settings of the shape object. Since `TextFrame` is not a shape and its settings are limited, it is wrapped into an [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) object.

มีสองวิธีในการใช้ลายน้ำ: บนสไลด์เดียวหรือบนสไลด์ทั้งหมดของงานพรีเซ็นเทชัน Slide Master ถูกใช้เพื่อใส่ลายน้ำบนสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มลงใน Slide Master ออกแบบเต็มที่ที่นั่นและนำไปใช้กับสไลด์ทุกอันโดยไม่กระทบต่อการแก้ไขลายน้ำบนสไลด์แต่ละอัน

ลายน้ำโดยทั่วไปถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง รูปร่างใดรูปร่างหนึ่งสามารถล็อกได้บนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมดของงานพรีเซ็นเทชัน

คุณสามารถตั้งชื่อให้กับลายน้ำเพื่อให้ในอนาคตหากต้องการลบ สามารถค้นหารูปร่างของมันในสไลด์โดยใช้ชื่อได้

คุณสามารถออกแบบลายน้ำได้ตามต้องการ อย่างไรก็ตามลายน้ำมักมีลักษณะร่วมกัน เช่น การจัดกึ่งกลาง การหมุน การวางอยู่ด้านหน้า เป็นต้น เราจะพิจารณาวิธีใช้สิ่งเหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์ก่อน แล้วเพิ่มเฟรมข้อความลงในรูปร่างนั้น เฟรมข้อความถูกแทนด้วยคลาส [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ประเภทนี้ไม่ได้สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ซึ่งมีคุณสมบัติหลายอย่างสำหรับตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นวัตถุ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) จะถูกห่อหุ้มในวัตถุ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [add_text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/add_text_frame/#str) ตามตัวอย่างด้านล่าง

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/th/python-net/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานพรีเซ็นเทชัน**

หากต้องการเพิ่มลายน้ำข้อความลงในงานพรีเซ็นเทชันทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/). ส่วนของตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำลงในสไลด์เดียว — สร้างวัตถุ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แล้วเพิ่มลายน้ำลงโดยใช้เมธอด [add_text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/add_text_frame/#str)

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/th/python-net/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะใช้สีเติมและสีเส้น บรรทัดโค้ดต่อไปทำให้รูปร่างโปร่งใส

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **ตั้งค่าฟอนต์สำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนฟอนต์ของลายน้ำข้อความได้ตามตัวอย่างด้านล่าง

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดนี้

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **จัดกลางลายน้ำข้อความ**

สามารถจัดลายน้ำให้อยู่กึ่งกลางสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

รูปด้านล่างแสดงผลลัพธ์สุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพลงในงานพรีเซ็นเทชัน**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานพรีเซ็นเทชัน คุณสามารถทำตามขั้นตอนต่อไปนี้

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้คุณสมบัติ [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/auto_shape_lock/) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันการเลือก, การปรับขนาด, การย้ายตำแหน่ง, การจัดกลุ่มกับองค์ประกอบอื่น, การล็อกข้อความจากการแก้ไขและอื่น ๆ อีกหลายอย่าง

```py
# ล็อกรูปร่างลายน้ำไม่ให้แก้ไข
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **นำลายน้ำไปไว้ด้านหน้าสไลด์**

ใน Aspose.Slides สามารถกำหนดลำดับ Z‑order ของรูปร่างได้ผ่านเมธอด [ShapeCollection.reorder](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) วิธีนี้ต้องเรียกเมธอดจากรายการสไลด์ของงานพรีเซ็นเทชันและส่งอ้างอิงรูปร่างพร้อมหมายเลขลำดับเข้ามา ซึ่งทำให้สามารถนำรูปร่างไปไว้ด้านหน้า หรือส่งไปยังด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์อย่างยิ่งเมื่อคุณต้องการวางลายน้ำไว้ด้านหน้าของงานพรีเซ็นเทชัน

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **ตั้งค่าการหมุนของลายน้ำ**

ต่อไปเป็นตัวอย่างโค้ดที่ปรับการหมุนของลายน้ำให้วางแนวเฉียงข้ามสไลด์

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **ตั้งชื่อลายน้ำ**

Aspose.Slides ให้คุณตั้งชื่อให้กับรูปร่างได้ โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงเพื่อแก้ไขหรือทำการลบในภายหลัง เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้กำหนดค่าให้กับคุณสมบัติ [AutoShape.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/name/)

```py
watermark_shape.name = "watermark"
```

## **ลบลายน้ำ**

เพื่อเอารูปร่างลายน้ำออก ให้ใช้เมธอด [AutoShape.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/name/) ค้นหามันในรูปร่างของสไลด์ จากนั้นส่งรูปร่างลายน้ำเข้าเมธอด [ShapeCollection.remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/remove/#ishape)

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **ตัวอย่างสด**

คุณอาจต้องการลองใช้ **Aspose.Slides ฟรี** [เพิ่มลายน้ำ](https://products.aspose.app/slides/th/watermark) และ [ลบลายน้ำ](https://products.aspose.app/slides/th/watermark/remove-watermark) ออนไลน์

![เครื่องมือออนไลน์สำหรับเพิ่มและลบลายน้ำ](online_tools.png)

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมจึงควรใช้?**

ลายน้ำคือการซ้อนข้อความหรือรูปภาพบนสไลด์เพื่อช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการรับรู้แบรนด์ หรือป้องกันการใช้ผลงานโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับสไลด์ทั้งหมดในงานพรีเซ็นเทชันได้ไหม?**

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ของงานพรีเซ็นเทชัน คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและกำหนดลายน้ำให้แต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าการเติม ([FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/)) ของรูปร่าง เพื่อให้ลายน้ำดูอ่อนโยนและไม่รบกวนเนื้อหาสไลด์

**รูปแบบภาพใดบ้างที่รองรับสำหรับลายน้ำ?**

Aspose.Slides รองรับรูปแบบภาพหลายประเภทเช่น PNG, JPEG, GIF, BMP, SVG เป็นต้น

**ฉันสามารถปรับแต่งฟอนต์และสไตล์ของลายน้ำข้อความได้ไหม?**

ได้, คุณสามารถเลือกฟอนต์, ขนาดและสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบของงานพรีเซ็นเทชันและคงเอกลักษณ์ของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำได้อย่างไร?**

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำได้โดยแก้ไขพิกัด, ขนาดและคุณสมบัติการหมุนของ [รูปร่าง](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) 