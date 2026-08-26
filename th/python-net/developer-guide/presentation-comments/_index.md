---
title: จัดการความคิดเห็นงานนำเสนอใน Python
linktitle: ความคิดเห็นงานนำเสนอ
type: docs
weight: 100
url: /th/python-net/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นงานนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการความคิดเห็นงานนำเสนอด้วย Aspose.Slides for Python via .NET: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Python via .NET จะนำเสนอประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างเหล่านี้ครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างโซ่มาการตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทุกความคิดเห็น

ใน PowerPoint ความคิดเห็นจะแสดงเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อตรวจสอบงานนำเสนอได้

Aspose.Slides for Python via .NET มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:
* The [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) class, คลาสที่ให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* The [CommentCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/) class, คลาสที่แสดงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* The [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) class, คลาสที่ให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน เวลาการสร้าง ตำแหน่ง และข้อความ
* The [CommentAuthor](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentauthor/) class, คลาสที่ให้ข้อมูลเกี่ยวกับผู้เขียน ได้แก่ ชื่อ, อักษรย่อ, และความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นบนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:
```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงความคิดเห็นบนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **ตอบกลับความคิดเห็น**

ความคิดเห็นพาเรนต์คือความคิดเห็นต้นฉบับที่อยู่บนสุดของลำดับชั้นการตอบกลับ property [parent_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) ของคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) ให้คุณดึงหรือกำหนดความคิดเห็นพาเรนต์ของความคิดเห็น

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มการตอบกลับและตรวจสอบลำดับชั้นของความคิดเห็นที่ได้:
```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/remove/) ของคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบด้วย
* หาก property [parent_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/add_modern_comment/) รับอาร์กิวเมนต์ประเภท [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) นอกจากสไลด์และพิกัดของเครื่องหมายความคิดเห็น

เมื่อส่งค่า `None` ให้กับอาร์กิวเมนต์ shape ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ เครื่องหมายของมันจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้มา แต่ไม่ได้เชื่อมโยงกับรูปใดเป็นพิเศษ ดังนั้น [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/) จะคืนค่า `None` เมื่อใส่ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) มา ความคิดเห็นจะถูกยึดกับรูปนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ ส่วนการเชื่อมโยงรูปสามารถดึงได้ผ่าน [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/)

### **ยึดความคิดเห็นสมัยใหม่กับรูป**

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดกับ AutoShape เฉพาะ จากนั้นอ่านรูปที่เชื่อมโยงจากแต่ละความคิดเห็น
```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **ยึดความคิดเห็นกับประเภทรูปต่าง ๆ**

ออบเจ็กต์สไลด์ใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) สามารถใช้เป็นตัวยึดรูปได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/python-net/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/python-net/aspose.slides/graphicalobject/) เช่น แผนภูมิ

ตัวอย่างต่อไปนี้สร้างรูปหลายประเภทที่พบบ่อยและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละรูป
```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **ยึดความคิดเห็นกับข้อความและกำหนดสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_start/) ระบุตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปนั้น ส่วน [ModernComment.text_selection_length](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_length/) ระบุความยาวของการเลือก ทั้งสองคุณสมบัติร่วมกันทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

คุณสมบัติ [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/) สามารถอ่านหรืออัปเดตด้วยค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncommentstatus/) ได้ดังนี้:
- `NOT_DEFINED` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่เฉพาะ
- `ACTIVE` — ความคิดเห็นอยู่ในสถานะทำงาน
- `RESOLVED` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `CLOSED` — ความคิดเห็นถูกปิด

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดกับรูป, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่
```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

เพื่อทำการตรวจสอบงานนำเสนอที่มีอยู่ ให้ตรวจสอบว่าความคิดเห็นใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/) จากนั้นตรวจสอบ [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_length/), และ [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/). รูปแบบ `None` หมายถึงความคิดเห็นระดับสไลด์ สำหรับการยึดกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) คุณสมบัติการเลือกข้อความจะบ่งชี้ช่วงที่เชื่อมโยงในกรอบข้อความของรูป
```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีการลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากงานนำเสนอ:
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีการลบความคิดเห็นเฉพาะจากสไลด์:
```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะ resolved สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/) สามารถอ่านและตั้งค่าได้ด้วยค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncommentstatus/), รวมถึง `RESOLVED`. สถานะนี้จะถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**การสนทนาที่เป็นเธรด (โซ่ตอบกลับ) ได้รับการสนับสนุนหรือไม่, และมีขีดจำกัดของการซ้อนกันหรือไม่?**

ใช่. ความคิดเห็นแต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) ของมันได้, ทำให้สามารถสร้างโซ่ตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นพิเศษ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ถูกกำหนดในระบบพิกัดใด?**

ตำแหน่งของเครื่องหมายถูกกำหนดด้วยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ซึ่งทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์