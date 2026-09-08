---
title: จัดการความคิดเห็นการนำเสนอใน Python ผ่าน Java
linktitle: ความคิดเห็นการนำเสนอ
type: docs
weight: 100
url: /th/python-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นการนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นการนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Python via Java แนะนำประเภทหลักที่เกี่ยวกับความคิดเห็นและแสดงวิธีการเพิ่มความคิดเห็นในสไลด์ เข้าถึงความคิดเห็นที่มีอยู่ ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่ และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน การอ่านข้อความและเมตาดาต้าของความคิดเห็น การสร้างห่วงโซ่การตอบกลับ และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint ความคิดเห็นจะแสดงเป็นคอมเมนต์บนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและร่วมทำงานกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ

Aspose.Slides for Python via Java มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:
* คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ให้เข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* คลาส [CommentCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentcollection/) แทนความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/) ให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน เวลาสร้าง ตำแหน่ง และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentauthor/) ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ ชื่อเต็มย่อ และความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มความคิดเห็นในสไลด์ของงานนำเสนอ PowerPoint:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **ตอบกลับความคิดเห็น**

คอมเมนต์แม่คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของลำดับการตอบกลับ เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#getParentComment) และ [Comment.setParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#setParentComment) ให้คุณดึงหรือกำหนดคอมเมนต์แม่ของคอมเมนต์ได้

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มการตอบกลับและตรวจสอบลำดับขั้นของคอมเมนต์ที่ได้:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [Comment.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#remove) เพื่อลบคอมเมนต์ การตอบกลับทั้งหมดของคอมเมนต์นั้นจะถูกลบด้วย
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#setParentComment) สร้างการอ้างอิงแบบวงกลม จะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/). เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentcollection/#addModernComment) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) นอกจากสไลด์และพิกัดของเครื่องหมายความคิดเห็น

เมื่อส่ง `None` เป็นอาร์กิวเมนต์ shape คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์ เครื่องหมายจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้มา แต่ไม่เชื่อมโยงกับรูปร่างใดโดยเฉพาะ ดังนั้น [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape) จะคืนค่า `None` เมื่อให้ค่า [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) คอมเมนต์จะถูกยึดกับรูปร่างนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์ ส่วนการเชื่อมโยงรูปร่างสามารถเรียกดูได้ผ่าน [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape)

### **แนบความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างต่อไปนี้สร้างทั้งความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดกับ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) เฉพาะ จากนั้นอ่านรูปร่างที่เชื่อมโยงจากแต่ละคอมเมนต์
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **แนบความคิดเห็นกับประเภทรูปร่างต่างๆ**

อ็อบเจ็กต์สไลด์ใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปร่างได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/python-java/aspose.slides/graphicalobject/) เช่นแผนภูมิ

ตัวอย่างต่อไปนี้สร้างประเภทรูปร่างที่พบบ่อยหลายประเภทและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละประเภท
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **แนบความคิดเห็นกับข้อความและกำหนดสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/), เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionStart) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setTextSelectionStart) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปร่าง เมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionLength) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setTextSelectionLength) เข้าถึงความยาวของการเลือก ค่าทั้งสองร่วมกันทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncommentstatus/) ดังนี้:
- [NotDefined] — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่โดยเฉพาะ.
- [Active] — ความคิดเห็นอยู่ในสถานะใช้งาน.
- [Resolved] — ความคิดเห็นได้รับการแก้ไขแล้ว.
- [Closed] — ความคิดเห็นถูกปิด.

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดกับรูปร่าง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

เพื่อตรวจสอบงานนำเสนอที่มีอยู่ ให้ตรวจสอบว่าคอมเมนต์ใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/) แล้วตรวจสอบ [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionLength), และ [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus). รูปร่างที่คืนค่า `None` หมายถึงคอมเมนต์ระดับสไลด์ สำหรับจุดยึดของ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) เมธอดการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในเฟรมข้อความของรูปร่าง
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีการลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากงานนำเสนอ:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีการลบความคิดเห็นเฉพาะจากสไลด์:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides รองรับสถานะ 'resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่า [ModernCommentStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะจะถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**การสนทนาแบบเธรด (ห่วงโซ่การตอบกลับ) รองรับหรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละคอมเมนต์สามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#getParentComment) ของมันได้ ทำให้สามารถสร้างห่วงโซ่การตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกัน

**ตำแหน่งเครื่องหมายคอมเมนต์บนสไลด์กำหนดโดยระบบพิกัดใด?**

ตำแหน่งเครื่องหมายถูกกำหนดโดยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ทำให้สามารถวางได้อย่างแม่นยำบนสไลด์