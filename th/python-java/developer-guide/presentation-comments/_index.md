---
title: การจัดการความคิดเห็นงานนำเสนอใน Python ผ่าน Java
linktitle: ความคิดเห็นงานนำเสนอ
type: docs
weight: 100
url: /th/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Python via Java โดยแนะนำประเภทหลักที่เกี่ยวข้องกับความคิดเห็นและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างโซ่มาตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint, ความคิดเห็นจะแสดงเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

เพื่อขอให้แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแปลงความคิดเห็นเอง ดูที่ [แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ](/slides/th/python-java/presentation-view-properties/).

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ

Aspose.Slides for Python via Java มี API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ให้เข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* คลาส [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) แสดงถึงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) ให้ข้อมูลเกี่ยวกับความคิดเห็นรวมถึงผู้เขียน, เวลาในการสร้าง, ตำแหน่ง, และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) ให้ข้อมูลเกี่ยวกับผู้เขียนรวมถึงชื่อ, อักษรย่อ, และความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างสร้างสไลด์สองแผ่นและลงทะเบียนผู้เขียนความคิดเห็นด้วย [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) ใช้ [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) เพื่อวางความคิดเห็นหนึ่งข้อความบนแต่ละสไลด์ จากนั้นดึงความคิดเห็นของสไลด์แรกสำหรับผู้เขียนนั้นด้วย [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง เพื่อแสดงการเข้าถึงทั้งผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกจะมีทั้งสองความคิดเห็น

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

## **ค้นหาหรือสร้างผู้เขียนความคิดเห็น**

เมื่อการตรวจทานอัตโนมัติประมวลผลงานนำเสนอเดียวกันหลายครั้ง ควรค้นหาในคอล렉ชันที่คืนค่าจาก [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) ก่อนที่จะเพิ่มผู้เขียน

เมธอด [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) จะจับคู่ทั้งชื่อและอักษรย่อและคืนค่าเป็นอาร์เรย์ของผู้เขียนที่ตรงกัน หรืออาร์เรย์ว่างหากไม่มีการแมตช์

ในทางตรงกันข้าม [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) ค้นหาโดยใช้ชื่อเพียงอย่างเดียว ไม่สนใจอักษรย่อ

การเรียก [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) ด้วยชื่อและอักษรย่อที่มีอยู่ในคอล렉ชันแล้วจะทำให้เกิดข้อยกเว้น

ตัวอย่างต้องการไฟล์งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ สำหรับแต่ละรอบสองรอบ จะใช้ผู้เขียนแรกที่ตรงกันซ้ำ หรือสร้างใหม่เมื่อผลลัพธ์ว่าง หากมีหลายผู้เขียนที่ตรงกัน จะเลือกอาร์เรย์ตัวแรกโดยไม่ผสานหรือลบผู้เขียนอื่น ๆ จากนั้นจะเรียก [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์จากรอบแรกและทำซ้ำการทำงาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

รอบที่สองจะเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนใหม่หรือ حذفความคิดเห็นที่มีอยู่ ไฟล์สุดท้าย `review_pass_2.pptx` มีทั้งความคิดเห็นใหม่สองรายการพร้อมกับความคิดเห็นเดิมทั้งหมด การใช้ผู้เขียนซ้ำไม่ได้ทำให้ความคิดเห็นซ้ำกันหายไป: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันหลายครั้ง ให้ดำเนินการตรวจจับซ้ำแยกต่างหากก่อนเพิ่ม

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และอ่านคอล렉ชันที่คืนค่าจาก [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) สำหรับผู้เขียนแต่ละคน จะวนลูปผ่านคอล렉ชันที่คืนค่าจาก [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) และแสดงหมายเลขสไลด์, ข้อความความคิดเห็น, ชื่อผู้เขียน, และเวลาที่สร้าง งานนำเข้าต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

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

ความคิดเห็นหลักคือความคิดเห็นต้นฉบับที่อยู่บนสุดของโครงสร้างการตอบกลับ เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) และ [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) ให้คุณดึงหรือกำหนดความคิดเห็นหลักได้

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้ [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) เพื่อสร้างการตอบกลับ รวมถึงการตอบกลับต่อการตอบกลับอีกหนึ่งขั้น การส่ง `None` ไปยัง [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะเยื้องแต่ละรายการตามความลึกในโครงสร้างการตอบกลับ ตัวอย่างบันทึกการสนทนาครบถ้วน, เรียก [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) เพื่อลบความคิดเห็นรากแรก, แล้วบันทึกงานนำเสนอที่สองที่มีความคิดเห็นและการตอบกลับนั้นถูกลบออก

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
* เมื่อเมธอด [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) ถูกใช้เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบเช่นกัน
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์โดยตรง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) รับอากิวเมนต์ [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) นอกจากนี้ยังต้องการพิกัดของสไลด์และตัวบ่งชี้ความคิดเห็น

เมื่อ `None` ถูกส่งเป็นอากิวเมนต์รูปทรง ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ ตัวบ่งชี้จะถูกวางตามพิกัดที่ให้ไว้ แต่จะไม่เชื่อมโยงกับรูปทรงใด ๆ ดังนั้น [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) จะคืนค่า `None` หากส่ง [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) มา ความคิดเห็นจะยึดติดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของตัวบ่งชี้บนสไลด์ ส่วนการเชื่อมโยงรูปทรงสามารถดึงกลับได้ด้วย [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)

### **ยึดความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างเรียก [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) สองครั้ง: ครั้งแรกกับรูปทรง `None` เพื่อสร้างความคิดเห็นระดับสไลด์ และครั้งที่สองกับสี่เหลี่ยมเป็นตัวยึด การอ่าน [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) จะแสดง `True` สำหรับการตรวจสอบ `None` ของความคิดเห็นระดับสไลด์และ `Revenue title` สำหรับความคิดเห็นที่ยึด รูปแบบทั้งสองจะถูกบันทึกพร้อมกับงานนำเสนอ

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

### **ยึดความคิดเห็นกับประเภทรูปร่างที่ต่างกัน**

รูปทรงใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), และ [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) เช่นแผนภูมิ

ตัวอย่างใช้ [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) เพื่อเชื่อมโยงความคิดเห็นกับรูปทรงห้าชนิด: AutoShape, picture frame, group, connector, และ chart ภาพใช้ข้อมูลภาพฝังไว้จึงไม่ต้องอ้างอิงไฟล์ภาพภายนอก แต่ละความคิดเห็นมีตำแหน่งตัวบ่งชี้ของตนเอง และงานนำเสนอที่บันทึกจะรักษาการเชื่อมโยงทั้งห้ารูปร่างไว้

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

### **ยึดความคิดเห็นกับข้อความและกำหนดสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปทรง เมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) เข้าถึงความยาวของการเลือก ค่าเหล่านี้รวมกันทำให้ความคิดเห็นเชื่อมกับช่วงข้อความเฉพาะใน AutoShape

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) ได้แก่

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — ไม่มีการกำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะ
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — ความคิดเห็นอยู่ในสภาพทำงาน
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — ความคิดเห็นได้รับการแก้ไขแล้ว
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — ความคิดเห็นถูกปิด

ตัวอย่างยึดความคิดเห็นสมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม คำนวนตำแหน่งเริ่มต้นศูนย์ฐานจากข้อความและส่งให้ [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) จากนั้นใช้ [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) ตั้งจำนวนอักขระที่เลือก หลังจากเรียก [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) ด้วย `Resolved` จะบันทึกและเปิดงานนำเสนอใหม่ การตรวจสอบคอนโซลสี่ครั้งควรพิมพ์ `True` แสดงว่าการยึดรูปทรง, ช่วงข้อความ, และสถานะได้รับการเก็บรักษา

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

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่อยู่แล้วและจะพิมพ์ข้อความ, สถานะ, และรายละเอียดการยึดรูปทรงของแต่ละความคิดเห็น เพื่อตรวจสอบ ให้ตรวจดูว่าใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) จากนั้นเรียก [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength), และ [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) `None` shape บ่งบอกว่าความคิดเห็นระดับสไลด์ สำหรับอินสแตนซ์ของ [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) การใช้เมธอดเลือกข้อความจะระบุช่วงที่เชื่อมกับข้อความในเฟรมของรูปทรง

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

Aspose.Slides for Python via Java ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนของมันจากงานนำเสนอ หรือสามารถลบความคิดเห็นที่เลือกได้โดยคงส่วนที่เหลือไว้ ตัวอย่างต่อไปนี้แสดงวิธีทั้งสองและบันทึกงานนำเสนอที่อัปเดต

### **ลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็น**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียก [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) สำหรับผู้เขียนแต่ละคน จากนั้นเรียก [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) เพื่อลบผู้เขียนเอง งานนำเสนอที่บันทึกจะแสดงว่าไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นใด ๆ ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์เดียวและใช้ [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) เพื่อค้นหาความคิดเห็นของแต่ละผู้เขียน จะเก็บความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอล렉ชันขณะเลือก งานนำเสนอที่บันทึกจะเหลือเพียง "comment 2"

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

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) และ [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) เข้าถึงค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) รวมถึง `Resolved` สถานะจะถูกเก็บไว้ในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**รองรับการสนทนาแบบเชือก (โซ่ตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนหรือไม่?**

ใช่. ความคิดเห็นแต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) ของมัน ทำให้สามารถสร้างโซ่ตอบกลับได้ API ไม่กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นพิเศษ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งของเครื่องหมายถูกกำหนดโดยพิกัดจุดลอยในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางได้อย่างแม่นยำบนสไลด์