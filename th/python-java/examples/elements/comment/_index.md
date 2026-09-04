---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/python-java/examples/elements/comment/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- ลบความคิดเห็น
- ตอบกลับความคิดเห็น
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นสไลด์สมัยใหม่ใน Aspose.Slides สำหรับ Python via Java: เพิ่ม, อ่าน, ลบ และตอบกลับความคิดเห็นในงานนำเสนอ PowerPoint และ OpenDocument."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนที่จะเริ่ม JVM จากนั้นจึงนำเข้า API และประเภท Java ที่จำเป็นหลังจาก JVM ทำงานแล้ว ตัวอย่างการเข้าถึงและการลบจะใช้ไฟล์ `modern_comment.pptx` ซึ่งสร้างโดยตัวอย่างแรก.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นที่เขียนโดยผู้ใช้และบันทึกงานนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    position = Point2D.Float(100, 100)
    author.getComments().addModernComment("This is a modern comment", slide, None, position, Date())

    presentation.save("modern_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่แรกจากงานนำเสนอที่มีอยู่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            print("Author:", author.getName())
            print("Comment:", comment.getText())
            print("Position:", comment.getPosition())
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")
finally:
    presentation.dispose()
```

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นแรกและบันทึกงานนำเสนอที่อัปเดต.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            comment.remove()
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")

    presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตอบกลับความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นหลัก, เพิ่มการตอบกลับสองรายการ, และบันทึกงานนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    created_time = Date()

    parent_position = Point2D.Float(100, 100)
    parent_comment = author.getComments().addModernComment("Parent comment", slide, None, parent_position, created_time)

    reply1_position = Point2D.Float(110, 100)
    reply1 = author.getComments().addModernComment("Reply 1", slide, None, reply1_position, created_time)

    reply2_position = Point2D.Float(120, 100)
    reply2 = author.getComments().addModernComment("Reply 2", slide, None, reply2_position, created_time)

    reply1.setParentComment(parent_comment)
    reply2.setParentComment(parent_comment)

    presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```