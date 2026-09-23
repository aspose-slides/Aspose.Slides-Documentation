---
title: จัดการคอมเมนต์งานนำเสนอใน Python
linktitle: คอมเมนต์งานนำเสนอ
type: docs
weight: 100
url: /th/python-net/presentation-comments/
keywords:
- คอมเมนต์
- คอมเมนต์สมัยใหม่
- คอมเมนต์ PowerPoint
- คอมเมนต์งานนำเสนอ
- คอมเมนต์สไลด์
- เพิ่มคอมเมนต์
- เข้าถึงคอมเมนต์
- แก้ไขคอมเมนต์
- ตอบคอมเมนต์
- ลบคอมเมนต์
- ลบคอมเมนต์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการคอมเมนต์งานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบคอมเมนต์ในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการคอมเมนต์งานนำเสนอด้วย Aspose.Slides for Python via .NET แนะนำประเภทหลักที่เกี่ยวกับคอมเมนต์และแสดงวิธีเพิ่มคอมเมนต์ในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับและคอมเมนต์สมัยใหม่, และลบคอมเมนต์ออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดคอมเมนต์ให้กับผู้เขียน, การอ่านข้อความคอมเมนต์และเมตาดาต้า, การสร้างสายตอบกลับ, และการลบคอมเมนต์ที่เลือกหรือคอมเมนต์ทั้งหมด

ใน PowerPoint คอมเมนต์ปรากฏเป็นคำอธิบายบนสไลด์ การเลือกคอมเมนต์จะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการให้คอมเมนต์แสดงหรือซ่อนเมื่อเปิดงานนำเสนอโดยไม่ทำการเปลี่ยนแปลงคอมเมนต์เอง, ดู [แสดงหรือซ่อนคอมเมนต์เมื่อเปิดงานนำเสนอ](/slides/th/python-net/presentation-view-properties/)

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณสามารถใช้คอมเมนต์เพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อรีวิวงานนำเสนอ

Aspose.Slides for Python via .NET ให้ API ต่อไปนี้สำหรับการทำงานกับคอมเมนต์:

* คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่ให้การเข้าถึงผู้เขียนคอมเมนต์ของงานนำเสนอ
* คลาส [CommentCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/) ที่แสดงคอมเมนต์ที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) ที่ให้ข้อมูลเกี่ยวกับคอมเมนต์ รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentauthor/) ที่ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, ตัวย่อ, และคอมเมนต์ที่เชื่อมโยง

## **เพิ่มคอมเมนต์ในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มคอมเมนต์ในสไลด์ของงานนำเสนอ PowerPoint:

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

## **เข้าถึงคอมเมนต์ในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงคอมเมนต์ที่มีอยู่ในงานนำเสนอ PowerPoint:

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

## **ตอบกลับคอมเมนต์**

คอมเมนต์พาเรนต์คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของโครงสร้างการตอบกลับ คุณสมบัติ [parent_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) ของคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) ช่วยให้คุณรับหรือกำหนดคอมเมนต์พาเรนต์ได้

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างคอมเมนต์ที่ได้:

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
* เมื่อใช้เมธอด [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/remove/) ของคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) เพื่อลบคอมเมนต์, การตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย
* หากคุณสมบัติ [parent_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) สร้างการอ้างอิงวนลูป, จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

คอมเมนต์สมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/add_modern_comment/) ยอมรับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) นอกเหนือจากสไลด์และพิกัดเครื่องหมายคอมเมนต์

เมื่อส่งค่า `None` ให้กับอาร์กิวเมนต์รูปร่าง, คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์ เครื่องหมายจะถูกกำหนดตำแหน่งตามพิกัดที่ให้มา แต่จะไม่เชื่อมกับรูปร่างใด, ดังนั้น [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/) จะคืนค่า `None` เมื่อมีการระบุ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) คอมเมนต์จะถูกยึดกับรูปร่างนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์, ในขณะที่การเชื่อมกับรูปร่างสามารถดึงข้อมูลผ่าน [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/) ได้

### **เชื่อมคอมเมนต์สมัยใหม่กับรูปร่าง**

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ระดับสไลด์และคอมเมนต์สมัยใหม่ที่ยึดกับ AutoShape เฉพาะ แล้วอ่านรูปร่างที่เชื่อมโยงจากแต่ละคอมเมนต์

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

### **เชื่อมคอมเมนต์กับประเภทรูปร่างต่าง ๆ**

อ็อบเจกต์สไลด์ใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) สามารถใช้เป็นตัวยึดรูปร่างได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/python-net/aspose.slides/connector/), และอินสแตนซ์ [GraphicalObject](https://reference.aspose.com/slides/th/python-net/aspose.slides/graphicalobject/) เช่น แผนภูมิ

ตัวอย่างต่อไปนี้สร้างหลายประเภทรูปร่างทั่วไปและเชื่อมคอมเมนต์สมัยใหม่กับแต่ละประเภท

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

### **เชื่อมคอมเมนต์กับข้อความและตั้งค่าสถานะ**

สำหรับคอมเมนต์สมัยใหม่ที่เชื่อมกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/), คุณสมบัติ [ModernComment.text_selection_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_start/) ระบุตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปร่าง, ขณะที่ [ModernComment.text_selection_length](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_length/) ระบุความยาวของการเลือก ทั้งสองคุณสมบัตินี้ทำให้คอมเมนต์เชื่อมกับช่วงข้อความเฉพาะภายใน AutoShape

คุณสมบัติ [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/) สามารถอ่านหรืออัปเดตด้วยค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncommentstatus/) ดังนี้

- `NOT_DEFINED` — ไม่ได้กำหนดสถานะคอมเมนต์สมัยใหม่เฉพาะ
- `ACTIVE` — คอมเมนต์อยู่ในสถานะทำงาน
- `RESOLVED` — คอมเมนต์ได้รับการแก้ไขแล้ว
- `CLOSED` — คอมเมนต์ถูกปิด

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ที่ยึดกับรูปร่าง, เชื่อมกับการเลือกข้อความ, ตั้งค่าสถานะเป็น `RESOLVED`, บันทึกงานนำเสนอ, และตรวจสอบค่าเมื่อเปิดไฟล์อีกครั้ง

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

### **ตรวจสอบคอมเมนต์สมัยใหม่ที่มีอยู่**

เพื่อทำการตรวจสอบงานนำเสนอที่มีอยู่, ตรวจสอบว่าคอมเมนต์ใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/) แล้วตรวจสอบ [ModernComment.shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/text_selection_length/), และ [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/). รูปร่างที่เป็น `None` หมายถึงคอมเมนต์ระดับสไลด์ สำหรับการยึดกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) คุณสมบัติการเลือกข้อความจะระบุช่วงที่เชื่อมกับเฟรมข้อความของรูปร่าง

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

## **ลบคอมเมนต์**

### **ลบคอมเมนต์ทั้งหมดและผู้เขียนคอมเมนต์**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์ทั้งหมดและผู้เขียนคอมเมนต์จากงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบคอมเมนต์เฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์เฉพาะจากสไลด์:

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

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับคอมเมนต์สมัยใหม่หรือไม่?**

ใช่. [ModernComment.status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/) สามารถอ่านและตั้งค่าได้ด้วยค่าใน enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncommentstatus/) รวมถึง `RESOLVED`. สถานะจะถูกบันทึกในงานนำเสนอและสามารถอ่านใหม่ได้หลังจากเปิดไฟล์อีกครั้ง

**สนับสนุนการสนทนาเชิงเธรด (สายตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละคอมเมนต์สามารถอ้างอิง [parent comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/parent_comment/) ของมันเอง ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันโดยเฉพาะ

**ตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์กำหนดด้วยระบบพิกัดอะไร?**

ตำแหน่งของเครื่องหมายถูกกำหนดด้วยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์