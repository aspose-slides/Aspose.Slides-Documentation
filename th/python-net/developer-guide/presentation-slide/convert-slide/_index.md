---
title: แปลงสไลด์การนำเสนอเป็นภาพใน Python
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/python-net/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลงสไลด์จากงานนำเสนอรูปแบบ PPT, PPTX, และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน Python ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Python via .NET สามารถเรนเดอร์สไลด์แต่ละหน้าจากการนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. เลือกสไลด์ที่คุณต้องการเรนเดอร์
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) 
4. เรียกเมธอด [Slide.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/) ซึ่งจะคืนค่าเป็นอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) 
5. เรียกเมธอด [IImage.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/save/) และระบุรูปแบบเอาต์พุตโดยใช้ค่า [ImageFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/) 

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าเรนเดอร์เริ่มต้น อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกลงไฟล์ได้

ตัวอย่าง Python ด้านล่างจะเรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

ใช้ overload ของ [Slide.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) ที่รับค่า [Size](https://reference.aspose.com/slides/th/python-net/aspose.pydrawing/size/) เพื่อเรนเดอร์สไลด์ด้วยมิติพิกเซลที่แน่นอน

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040 พิกเซล:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **แปลงสไลด์ที่มีโน้ตและความคิดเห็นเป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมโน้ตหรือความคิดเห็น ให้กำหนดอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับคุณสมบัติ [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) เพื่อควบคุมตำแหน่งที่โน้ตและความคิดเห็นแสดง

ตัวอย่างต่อไปนี้วางโน้ตที่ถูกตัดสั้นไว้ด้านล่างสไลด์และความคิดเห็นทางด้านขวาของสไลด์:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าใช้คุณสมบัติ [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) เป็นค่า [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notespositions/) เนื่องจากโน้ตอาจมีข้อความมากกว่าขนาดภาพที่กำหนด ใช้ค่า [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) ช่วยให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติเพิ่มเติมของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 พิกเซลที่ 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนผ่านชุดสไลด์เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนอยู่จะรวมอยู่ด้วยเว้นแต่คุณจะข้ามอย่างเจาะจง

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG โดยมีปัจจัยสเกลแนวนอนและแนวตั้งเท่ากับ 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **สร้างเอาต์พุต Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafile ต่างจากภาพแบบพิกเซล EMF สามารถเก็บการวาดเวกเตอร์ที่ขยายได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้หลักสำหรับแอปที่สนับสนุน Windows metafile ไม่ได้เป็นรูปแบบแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อน เช่น ภาพบิตแมปและเอฟเฟกต์บางอย่าง อาจถูกเก็บเป็นองค์ประกอบ raster ภายในคอนเทนเนอร์เวกเตอร์เมตาฟไฟล์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [Slide.write_as_emf](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/write_as_emf/) จะเขียน [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ลงในสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เลือกสไลด์แรก และเขียนลงในสตรีมไฟล์ EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

ผู้เรียกต้องเป็นเจ้าของสตรีมที่ส่งให้กับ [Slide.write_as_emf](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/write_as_emf/) และต้องปิดสตรีมนั้น Aspose.Slides จะเขียนที่ตำแหน่งปัจจุบันของสตรีมและทิ้งสตรีมไว้เปิด

### **แปลงภาพ SVG เป็น EMF และเพิ่มลงในงานนำเสนอ**

ใช้ [SvgImage.write_as_emf](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/write_as_emf/) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในงานนำเสนอผ่าน [ImageCollection.add_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/add_image/) และวางบนสไลด์ด้วย [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/)

ตัวอย่างต่อไปนี้สร้าง [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) จาก markup SVG แปลงเป็น EMF ในหน่วยความจำ แทรกเมตาไฟล์บนสไลด์แรก และบันทึกงานนำเสนอ:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/write_as_emf/) ไม่เป็นเจ้าของสตรีมปลายทาง หลังการเขียนตำแหน่งสตรีมจะอยู่ที่ท้ายข้อมูลที่สร้างขึ้น เรียก `getvalue` เพื่อรับบัฟเฟอร์เต็มโดยไม่คำนึงถึงตำแหน่งสตรีมปัจจุบัน ตามที่แสดงด้านบน เก็บสตรีมเปิดอยู่จนกว่าจะอ่านข้อมูลเสร็จ แล้วปิดสตรีมหลังจากนั้น

การสร้าง EMF มีให้ใช้งานบนระบบปฏิบัติการที่รองรับโดย Aspose.Slides for Python via .NET อย่างไรก็ตามการเรนเดอร์อาจแตกต่างระหว่างแพลตฟอร์มเมื่อฟอนต์หรือไลบรารีกราฟิกพื้นฐานไม่พร้อมใช้งาน ให้ติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งหรือกำหนดการทดแทนที่เหมาะสม ปฏิบัติตาม [platform requirements](/slides/th/python-net/system-requirements/) ของ Aspose.Slides และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF เป้าหมาย แอปบน Linux และ macOS มักมีการสนับสนุนการแสดงและแก้ไข Windows metafile ที่จำกัดหรือไม่สอดคล้อง

## **การแสดงผล Emoji สี**

{{% alert title="Note" color="info" %}}
เพื่อให้การเรนเดอร์อีโมจีสีทำงานอย่างถูกต้องเมื่อแปลงสไลด์งานนำเสนอเป็นภาพ ฟอนต์อีโมจีที่ใช้ในงานนำเสนอต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำใช้ **Segoe UI Emoji** แต่ฟอนต์นี้หายไป อีโมจีอาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่มี เมธอด [Slide.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/) เรนเดอร์ภาพสถิตของสไลด์และไม่ส่งออกแอนิเมชัน

**สามารถส่งออกสไลด์ที่ซ่อนอยู่เป็นภาพได้หรือไม่?**

ได้ สไลด์ที่ซ่อนอยู่สามารถเรนเดอร์เช่นสไลด์ปกติ รวมไว้ในลูปการประมวลผลตามตัวอย่างด้านบน

**เงาและเอฟเฟกต์อื่น ๆ ถูกเก็บไว้ในภาพสไลด์หรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เงา ความโปร่งแสง และเอฟเฟกต์กราฟิกอื่น ๆ ที่สนับสนุนในภาพสไลด์