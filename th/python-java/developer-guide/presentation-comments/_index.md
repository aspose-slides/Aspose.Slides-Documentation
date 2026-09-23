---
title: จัดการคอมเมนต์การนำเสนอใน Python ผ่าน Java
linktitle: คอมเมนต์การนำเสนอ
type: docs
weight: 100
url: /th/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "จัดการคอมเมนต์การนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบคอมเมนต์ในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการคอมเมนต์ในการนำเสนอด้วย Aspose.Slides for Python via Java. มันแนะนำประเภทที่เกี่ยวข้องกับคอมเมนต์หลักและสาธิตวิธีการเพิ่มคอมเมนต์ลงในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับและคอมเมนต์สมัยใหม่, และลบคอมเมนต์ออกจากการนำเสนอ.

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันที่พบบ่อยใน PowerPoint เช่น การกำหนดคอมเมนต์ให้กับผู้เขียน, อ่านข้อความคอมเมนต์และเมตาดาต้า, สร้างสายการตอบกลับ, และลบคอมเมนต์ที่เลือกหรือคอมเมนต์ทั้งหมด.

ใน PowerPoint, คอมเมนต์จะแสดงเป็นคำอธิบายบนสไลด์ การเลือกคอมเมนต์จะแสดงข้อความและการสนทนาที่เกี่ยวข้อง.

หากต้องการให้คอมเมนต์แสดงหรือซ่อนเมื่อเปิดการนำเสนอโดยไม่เปลี่ยนแปลงคอมเมนต์เอง, ดูที่ [แสดงหรือซ่อนคอมเมนต์เมื่อเปิดการนำเสนอ](/slides/th/python-java/presentation-view-properties/).

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณสามารถใช้คอมเมนต์เพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ.

Aspose.Slides for Python via Java มี API ต่อไปนี้สำหรับทำงานกับคอมเมนต์:

* The [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) คลาส, ซึ่งให้การเข้าถึงผู้เขียนคอมเมนต์ของการนำเสนอ.
* The [CommentCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentcollection/) คลาส, ซึ่งเป็นตัวแทนของคอมเมนต์ที่เชื่อมโยงกับผู้เขียนแต่ละคน.
* The [Comment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/) คลาส, ซึ่งให้ข้อมูลเกี่ยวกับคอมเมนต์ รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ.
* The [CommentAuthor](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentauthor/) คลาส, ซึ่งให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, ตัวอักษรย่อ, และคอมเมนต์ที่เชื่อมโยง.

## **เพิ่มคอมเมนต์สไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มคอมเมนต์ลงในสไลด์ใน PowerPoint presentation:

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

## **เข้าถึงคอมเมนต์สไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงคอมเมนต์ที่มีอยู่ใน PowerPoint presentation:

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

## **ตอบกลับคอมเมนต์**

คอมเมนต์พาเรนท์คือคอมเมนต์ดั้งเดิมที่อยู่ด้านบนของลำดับการตอบกลับ. เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#getParentComment) และ [Comment.setParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#setParentComment) ให้คุณดึงหรือกำหนดพาเรนท์ของคอมเมนต์.

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มการตอบกลับและตรวจสอบลำดับคอมเมนต์ที่ได้:

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
* เมื่อใช้เมธอด [Comment.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#remove) เพื่อลบคอมเมนต์, การตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย.
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#setParentComment) สร้างการอ้างอิงแบบวงกลม, จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

คอมเมนต์สมัยใหม่สามารถผูกกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/). เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentcollection/#addModernComment) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) เพิ่มเติมนอกเหนือจากสไลด์และพิกัดเครื่องหมายคอมเมนต์.

เมื่อ `None` ถูกส่งเป็นอาร์กิวเมนต์ shape, คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์. เครื่องหมายของมันจะถูกวางตามพิกัดที่ระบุ, แต่ไม่ผูกกับรูปทรงใด, ดังนั้น [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape) จะคืนค่า `None`. เมื่อส่ง [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) มา, คอมเมนต์จะยึดติดกับรูปทรงนั้น. พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์, ส่วนการเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape).

### **ยึดคอมเมนต์สมัยใหม่ต่อรูปทรง**

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ระดับสไลด์และคอมเมนต์สมัยใหม่ที่ยึดกับ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) เฉพาะ. จากนั้นอ่านรูปทรงที่เชื่อมโยงจากแต่ละคอมเมนต์.

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

### **ยึดคอมเมนต์ต่อประเภทรูปทรงต่าง ๆ**

ออบเจ็กต์สไลด์ใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปทรงได้. ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/python-java/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/python-java/aspose.slides/graphicalobject/) เช่น แผนภูมิ.

ตัวอย่างต่อไปนี้สร้างรูปทรงทั่วไปหลายประเภทและเชื่อมต่อคอมเมนต์สมัยใหม่กับแต่ละรูป.

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

### **ยึดคอมเมนต์ต่อข้อความและตั้งค่าสถานะ**

สำหรับคอมเมนต์สมัยใหม่ที่ผูกกับ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/), เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionStart) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setTextSelectionStart) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรง. เมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionLength) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setTextSelectionLength) เข้าถึงความยาวของการเลือก. ค่าทั้งสองนี้ทำให้คอมเมนต์เชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape.

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined] — ไม่ได้กำหนดสถานะคอมเมนต์สมัยใหม่ใด ๆ.
- [Active] — คอมเมนต์อยู่ในสถานะใช้งาน.
- [Resolved] — คอมเมนต์ได้รับการแก้ไขแล้ว.
- [Closed] — คอมเมนต์ถูกปิด.

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ที่ยึดกับรูปทรง, ผูกกับช่วงข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกการนำเสนอ, และตรวจสอบค่าหลังเปิดไฟล์ใหม่.

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

### **ตรวจสอบคอมเมนต์สมัยใหม่ที่มีอยู่**

เพื่อทำการตรวจสอบการนำเสนอที่มีอยู่, ตรวจสอบว่าคอมเมนต์ใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/), แล้วตรวจสอบ [ModernComment.getShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getTextSelectionLength), และ [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus). รูปทรง `None` แสดงว่าคอมเมนต์เป็นระดับสไลด์. สำหรับจุดยึดของ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/), เมธอดเลือกข้อความจะบ่งชี้ช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรง.

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

## **ลบคอมเมนต์**

### **ลบคอมเมนต์ทั้งหมดและผู้เขียนคอมเมนต์**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์ทั้งหมดและผู้เขียนคอมเมนต์ออกจากการนำเสนอ:

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

### **ลบคอมเมนต์เฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์เฉพาะจากสไลด์:

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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะ ‘Resolved’ สำหรับคอมเมนต์สมัยใหม่หรือไม่?**

ใช่. [ModernComment.getStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/th/python-java/aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะถูกจัดเก็บในการนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่.

**การสนทนาหลายระดับ (สายตอบกลับ) รองรับหรือไม่, มีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละคอมเมนต์สามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/python-java/aspose.slides/comment/#getParentComment) ของตนเอง, ทำให้สามารถสร้างสายตอบกลับได้. API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันโดยเฉพาะ.

**ตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งของเครื่องหมายถูกกำหนดโดยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์, ช่วยให้คุณวางตำแหน่งได้อย่างแม่นยำบนสไลด์.