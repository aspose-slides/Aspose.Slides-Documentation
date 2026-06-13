---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/python-net/examples/elements/comment/
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
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการความคิดเห็นสไลด์ใน Python ด้วย Aspose.Slides: เพิ่ม, อ่าน, ตอบกลับ, แก้ไข, ลบ, และทำงานกับความคิดเห็นแบบเธรดสำหรับ PowerPoint และ OpenDocument."
---
สาธิตการเพิ่ม, การอ่าน, การลบ, และการตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นที่เขียนโดยผู้ใช้และบันทึกการนำเสนอ

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มผู้เขียนความคิดเห็น.
        author = presentation.comment_authors.add_author("User", "U1")

        # เพิ่มความคิดเห็นสมัยใหม่.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่จากการนำเสนอที่มีอยู่

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # เข้าถึงความคิดเห็นสมัยใหม่แรก.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นและบันทึกไฟล์ที่อัปเดต

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # ลบความคิดเห็น.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตอบกลับความคิดเห็นสมัยใหม่**

เพิ่มการตอบกลับให้กับความคิดเห็นสมัยใหม่ที่เป็นพาเรนท์

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # เพิ่มความคิดเห็นพาเรนท์.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # เพิ่มการตอบกลับแรก.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # เพิ่มการตอบกลับที่สอง.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```