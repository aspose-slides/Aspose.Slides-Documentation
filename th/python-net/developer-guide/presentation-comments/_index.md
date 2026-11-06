---
title: จัดการคอมเมนต์การนำเสนอใน Python
linktitle: คอมเมนต์การนำเสนอ
type: docs
weight: 100
url: /th/python-net/presentation-comments/
keywords:
- คอมเมนต์
- คอมเมนต์สมัยใหม่
- คอมเมนต์ PowerPoint
- คอมเมนต์การนำเสนอ
- คอมเมนต์สไลด์
- เพิ่มคอมเมนต์
- เข้าถึงคอมเมนต์
- แก้ไขคอมเมนต์
- ตอบกลับคอมเมนต์
- ลบคอมเมนต์
- ลบคอมเมนต์
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการคอมเมนต์การนำเสนอด้วย Aspose.Slides for Python via .NET: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบคอมเมนต์ในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการคอมเมนต์ในงานนำเสนอด้วย Aspose.Slides for Python via .NET โดยแนะนำประเภทที่เกี่ยวข้องกับคอมเมนต์หลักและสาธิตวิธีการเพิ่มคอมเมนต์ในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับและคอมเมนต์สมัยใหม่, และลบคอมเมนต์ออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดคอมเมนต์ให้กับผู้เขียน, การอ่านข้อความและข้อมูลเมตาของคอมเมนต์, การสร้างสายตอบกลับ, และการลบคอมเมนต์ที่เลือกหรือคอมเมนต์ทั้งหมด

ใน PowerPoint คอมเมนต์จะแสดงเป็นคำอธิบายบนสไลด์ การเลือกคอมเมนต์จะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการร้องขอให้คอมเมนต์แสดงหรือซ่อนเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแปลงคอมเมนต์เอง ดูที่[Show or Hide Comments When Opening a Presentation](/slides/th/python-net/presentation-view-properties/)

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณสามารถใช้คอมเมนต์เพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อรีวิวงานนำเสนอ

Aspose.Slides for Python via .NET มี API ดังต่อไปนี้สำหรับทำงานกับคอมเมนต์:

* คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ซึ่งให้เข้าถึงผู้เขียนคอมเมนต์ของงานนำเสนอ
* คลาส [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) ซึ่งเป็นตัวแทนของคอมเมนต์ที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) ซึ่งให้ข้อมูลเกี่ยวกับคอมเมนต์ รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) ซึ่งให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, ชื่อย่อ, และคอมเมนต์ที่เชื่อมโยง

## **เพิ่มคอมเมนต์ในสไลด์**

ตัวอย่างนี้สร้างสไลด์สองสไลด์และลงทะเบียนผู้เขียนคอมเมนต์ด้วย [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) จากนั้นใช้ [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) เพื่อวางคอมเมนต์หนึ่งรายการบนแต่ละสไลด์ แล้วดึงคอมเมนต์ของสไลด์แรกสำหรับผู้เขียนคนนั้นด้วย [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) คอนโซลจะแสดงข้อความของคอมเมนต์แรกสองครั้งเพื่อสาธิตการเข้าถึงผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกจะมีคอมเมนต์ทั้งสองรายการ

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **ค้นหา หรือสร้างผู้เขียนคอมเมนต์**

เมื่อกระบวนการตรวจสอบอัตโนมัติเสียบบงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหาในคอลเลคชัน [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) ก่อนเพิ่มผู้เขียน [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) จะตรงกับทั้งชื่อและชื่อย่อและคืนค่าอาร์เรย์ของผู้เขียนที่ตรงกัน, หรืออาร์เรย์ว่างหากไม่มีผลลัพธ์ ในทางกลับกัน [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) ค้นหาโดยใช้ชื่ออย่างเดียวโดยไม่สนใจชื่อย่อ การเรียก [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) ด้วยชื่อและชื่อย่อที่มีอยู่แล้วในคอลเลคชันจะทำให้เกิดข้อยกเว้น

ตัวอย่างนี้ต้องการไฟล์งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ ในแต่ละรอบสองรอบ จะใช้ผู้เขียนที่ตรงกันครั้งแรก, หรือสร้างใหม่เมื่อตัวผลลัพธ์ว่าง หากมีหลายผลลัพธ์ จะเลือกอีลเมนต์แรกของอาร์เรย์โดยไม่ผสานหรือลบผู้เขียนคนอื่น จากนั้นเรียก [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์ของรอบแรกและทำซ้ำขั้นตอนเดิม

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

รอบที่สองเพิ่มคอมเมนต์อีกรายการโดยไม่เพิ่มผู้เขียนใหม่หรือ حذفคอมเมนต์ที่มีอยู่ไฟล์สุดท้าย `review_pass_2.pptx` จะมีคอมเมนต์ใหม่สองรายการพร้อมกับคอมเมนต์เดิม การใช้ผู้เขียนซ้ำไม่ได้ทำให้คอมเมนต์ซ้ำหายไป: เพื่อหลีกเลี่ยงการเพิ่มคอมเมนต์เดียวกันซ้ำ ๆ ควรตรวจจับคอมเมนต์ซ้ำก่อนทำการเพิ่ม

## **เข้าถึงคอมเมนต์ในสไลด์**

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และอ่านคอลเลคชัน [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) สำหรับแต่ละผู้เขียน จะวนลูปผ่าน [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) และพิมพ์หมายเลขสไลด์, ข้อความคอมเมนต์, ชื่อผู้เขียน, และเวลาสร้าง งานนำเข้าต้องมีคอมเมนต์เพื่อให้คอนโซลแสดงผล

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

คอมเมนต์แม่คือคอมเมนต์ต้นฉบับที่อยู่ด้านบนของลำดับชั้นการตอบกลับ คุณสมบัติ [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) ของคลาส [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) ให้คุณรับหรือกำหนดพาเรนต์ของคอมเมนต์ได้

ตัวอย่างนี้สร้างคอมเมนต์จากผู้เขียนสองคนและใช้ [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) เพื่อสร้างการตอบกลับ รวมถึงการตอบกลับต่อการตอบกลับอื่น ๆ การส่ง `None` ไปยัง [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) จะดึงคอมเมนต์จากผู้เขียนทั้งหมด; คอนโซลจะเยื้องแต่ละรายการตามระดับความลึกในลำดับชั้นการตอบกลับ ตัวอย่างบันทึกการสนทนาครบถ้วน, เรียก [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) กับคอมเมนต์รากแรก, และบันทึกงานนำเสนอที่สองโดยคอมเมนต์และการตอบกลับของมันถูกลบออก

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) ของคลาส [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) เพื่อลบคอมเมนต์ คำตอบทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วยเช่นกัน
* หากคุณสมบัติ [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) สร้างการอ้างอิงเป็นวงกลม จะทำให้เกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

คอมเมนต์สมัยใหม่สามารถเชื่อมโยงกับสไลด์โดยตรง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape วิธี [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) นอกเหนือจากสไลด์และพิกัดของตัวบ่งชี้คอมเมนต์

เมื่อส่ง `None` ให้กับอาร์กิวเมนต์ shape คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์ ตัวบ่งชี้จะถูกวางตำแหน่งตามพิกัดที่ระบุ, แต่จะไม่เชื่อมโยงกับรูปทรงใดโดยเฉพาะ ดังนั้น [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) จะคืนค่า `None` หากส่ง [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) มา คอมเมนต์จะถูกยึดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของตัวบ่งชี้บนสไลด์ ส่วนการเชื่อมโยงกับรูปทรงสามารถดึงผ่าน [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) ได้

### **ยึดคอมเมนต์สมัยใหม่กับรูปทรง**

ตัวอย่างนี้เรียก [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) สองครั้ง: ครั้งแรกใช้ shape เป็น `None` สำหรับคอมเมนต์ระดับสไลด์, ครั้งที่สองใช้สี่เหลี่ยมเป็นจุดยึด การอ่าน [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) จะพิมพ์ `True` สำหรับการตรวจสอบคอมเมนต์ระดับสไลด์ที่เป็น null และพิมพ์ `Revenue title` สำหรับคอมเมนต์ที่ยึดกับรูปทรง ทั้งสองคอมเมนต์จะถูกบันทึกพร้อมงานนำเสนอ

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **ยึดคอมเมนต์กับประเภทรูปทรงต่าง ๆ**

รูปทรงใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปทรงได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), และ [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) เช่น แผนภูมิ

ตัวอย่างนี้ใช้ [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) เพื่อเชื่อมคอมเมนต์กับรูปทรงแต่ละประเภทจำนวนห้าแบบ: AutoShape, picture frame, group, connector, และ chart ภาพใช้ข้อมูลภาพฝังในตัว, ไม่ต้องการไฟล์ภาพภายนอก แต่ละคอมเมนต์มีตำแหน่งตัวบ่งชี้ของตนเอง และงานนำเสนอที่บันทึกจะรักษาการเชื่อมโยงกับรูปทรงทั้งห้าไว้

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **ยึดคอมเมนต์กับข้อความและกำหนดสถานะ**

สำหรับคอมเมนต์สมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), คุณสมบัติ [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) ระบุตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรง, ส่วน [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) ระบุความยาวของการเลือก ทั้งสองคุณสมบัติจับคอมเมนต์กับช่วงข้อความเฉพาะใน AutoShape

คุณสมบัติ [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) สามารถอ่านหรืออัปเดตด้วยค่าจาก enum [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) ดังนี้

- `NOT_DEFINED` — ไม่ได้กำหนดสถานะคอมเมนต์สมัยใหม่เฉพาะใด
- `ACTIVE` — คอมเมนต์อยู่ในสถานะใช้งาน
- `RESOLVED` — คอมเมนต์ได้รับการแก้ไขแล้ว
- `CLOSED` — คอมเมนต์ถูกปิด

ตัวอย่างนี้ยึดคอมเมนต์สมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม มันคำนวณ [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) เริ่มจากศูนย์จากข้อความและตั้งค่า [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) เป็นจำนวนอักขระที่เลือก หลังจากตั้งค่า [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) เป็น `RESOLVED` จะบันทึกและเปิดงานนำเสนอใหม่ การตรวจสอบสี่ครั้งในคอนโซลควรพิมพ์ `True` ทุกครั้งเพื่อยืนยันว่าการยึดรูปทรง, ช่วงข้อความ, และสถานะถูกเก็บรักษาไว้

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

ตัวอย่างนี้ต้องการงานนำเสนอที่มีคอมเมนต์สมัยใหม่และพิมพ์ข้อความ, สถานะ, และรายละเอียดการยึดรูปทรง ตรวจสอบโดยดูคอมเมนต์ที่เป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), จากนั้นตรวจสอบ [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/), และ [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) `None` shape บ่งบอกว่าคอมเมนต์ระดับสไลด์ สำหรับการยึดกับ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) คุณสมบัติการเลือกข้อความจะแสดงช่วงที่เชื่อมโยงกับกรอบข้อความของรูปทรง

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

Aspose.Slides for Python via .NET สามารถลบคอมเมนต์ทั้งหมดและผู้เขียนจากงานนำเสนอ หรือจะลบคอมเมนต์ที่เลือกไว้โดยคงส่วนที่เหลือไว้ ตัวอย่างต่อไปนี้สาธิตทั้งสองวิธีและบันทึกงานนำเสนอที่อัปเดตแล้ว

### **ลบคอมเมนต์และผู้เขียนคอมเมนต์ทั้งหมด**

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) สำหรับแต่ละผู้เขียน, จากนั้นเรียก [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) เพื่อลบผู้เขียนด้วย งานนำเสนอที่บันทึกจะไม่มีคอมเมนต์หรือผู้เขียนคอมเมนต์ ใช้งานนำเสนอที่มีคอมเมนต์เพื่อสังเกตการลบ

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบคอมเมนต์เฉพาะ**

ตัวอย่างนี้สร้างคอมเมนต์สองรายการบนสไลด์เดียวและใช้ [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) เพื่อค้นหาคอมเมนต์ของแต่ละผู้เขียน มันเก็บคอมเมนต์ที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเลคชันขณะเลือก งานนำเสนอที่บันทึกจะเหลือเพียง "comment 2" เท่านั้น

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

**Aspose.Slides รองรับสถานะ resolved สำหรับคอมเมนต์สมัยใหม่หรือไม่?**

ใช่. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) สามารถอ่านและตั้งค่าได้ด้วยค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) รวมถึง `RESOLVED` สถานะจะถูกเก็บไว้ในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**รองรับการสนทนาที่เป็นเธรด (สายตอบกลับ) หรือไม่? มีขีดจำกัดการซ้อนชั้นหรือไม่?**

ใช่. คอมเมนต์แต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) ของมันได้ ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนชั้นโดยเฉพาะ

**ตำแหน่งของตัวบ่งชี้คอมเมนต์บนสไลด์กำหนดในระบบพิกัดอะไร?**

ตำแหน่งตัวบ่งชี้กำหนดโดยค่าพิกัดแบบ floating‑point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์