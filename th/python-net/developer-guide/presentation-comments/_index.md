---
title: จัดการความคิดเห็นในงานนำเสนอด้วย Python
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
description: "ควบคุมความคิดเห็นงานนำเสนอด้วย Aspose.Slides for Python via .NET: เพิ่ม อ่าน แก้ไข และลบความคิดเห็นในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides โดยแสดงประเภทหลักที่เกี่ยวกับความคิดเห็นและสาธิตวิธีเพิ่มความคิดเห็นลงในสไลด์ การเข้าถึงความคิดเห็นที่มีอยู่ การทำงานกับการตอบกลับ การใช้ความคิดเห็นสมัยใหม่ และการลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างมุ่งเน้นไปที่สถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน การอ่านเนื้อหาและเมตาดาต้าของความคิดเห็น การสร้างสายการตอบกลับ และการลบความคิดเห็นทั้งหมดหรือการลบความคิดเห็นที่เลือก

ใน PowerPoint ความคิดเห็นจะแสดงเป็นบันทึกหรือคำอธิบายบนสไลด์ เมื่อคลิกที่ความคิดเห็น จะเปิดเผยเนื้อหาหรือข้อความของมัน

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อคุณตรวจสอบงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint ได้ Aspose.Slides for Python via .NET มีให้

* คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ซึ่งมีคอลเลกชันของผู้เขียน (จากคุณสมบัติ [CommentAuthorCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentauthorcollection/)) ผู้เขียนจะเพิ่มความคิดเห็นลงในสไลด์
* คลาส [CommentCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/) ซึ่งมีคอลเลกชันของความคิดเห็นสำหรับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/) ซึ่งมีข้อมูลเกี่ยวกับผู้เขียนและความคิดเห็นของพวกเขา: ผู้ที่เพิ่มความคิดเห็น, เวลาเพิ่มความคิดเห็น, ตำแหน่งของความคิดเห็น ฯลฯ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentauthor/) ซึ่งมีข้อมูลของผู้เขียนแต่ละคน: ชื่อผู้เขียน, ตัวย่อของเขา, ความคิดเห็นที่เชื่อมโยงกับชื่อผู้เขียน ฯลฯ

## **เพิ่มความคิดเห็นในสไลด์**
โค้ด Python นี้แสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์ในงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    # เพิ่มสไลด์เปล่า
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # เพิ่มผู้เขียน
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # ตั้งค่าตำแหน่งสำหรับความคิดเห็น
    point = draw.PointF(0.2, 0.2)

    # เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # เข้าถึง ISlide 1
    slide = presentation.slides[0]

    # เมื่อส่งค่า null เป็นอาร์กิวเมนต์ ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกนำไปสไลด์ที่เลือก
    comments = slide.get_slide_comments(author)

    # เข้าถึงความคิดเห็นที่ตำแหน่งดัชนี 0 สำหรับสไลด์ 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ตำแหน่งดัชนี 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **เข้าถึงความคิดเห็นในสไลด์**
โค้ด Python นี้แสดงวิธีการเข้าถึงความคิดเห็นที่มีอยู่บนสไลด์ในงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **ตอบกลับความคิดเห็น**
ความคิดเห็นหลักคือความคิดเห็นบนสุดหรือความคิดเห็นต้นฉบับในโครงสร้างลำดับชั้นของความคิดเห็นหรือการตอบกลับ โดยใช้คุณสมบัติ `parent_comment` (จากคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/)) คุณสามารถตั้งหรือรับความคิดเห็นหลักได้

โค้ด Python นี้แสดงวิธีการเพิ่มความคิดเห็นและรับการตอบกลับต่อความคิดเห็นเหล่านั้น:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # เพิ่มความคิดเห็น
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # เพิ่มการตอบกลับให้กับ comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # เพิ่มการตอบกลับอีกอันให้กับ comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # แสดงลำดับความสำคัญของความคิดเห็นบนคอนโซล
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # ลบ comment1 และการตอบกลับทั้งหมดของมัน
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
* เมื่อใช้เมธอด `remove` (จากคลาส [Comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/comment/)) เพื่อลบความคิดเห็น การตอบกลับต่อความคิดเห็นนั้นก็จะถูกลบด้วย
* หากการตั้งค่า `parent_comment` ทำให้เกิดการอ้างอิงแบบวงกลม `PptxEditException` จะถูกโยนออก
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021 Microsoft ได้นำเสนอ *ความคิดเห็นสมัยใหม่* ใน PowerPoint ฟีเจอร์ความคิดเห็นสมัยใหม่ช่วยปรับปรุงการทำงานร่วมกันใน PowerPoint อย่างมาก ผ่านความคิดเห็นสมัยใหม่ ผู้ใช้ PowerPoint สามารถแก้ไขสถานะความคิดเห็น, ลากความคิดเห็นไปยังวัตถุและข้อความ, และมีปฏิสัมพันธ์ได้ง่ายขึ้นอย่างมาก

เราได้เพิ่มการสนับสนุนความคิดเห็นสมัยใหม่โดยเพิ่มคลาส [ModernComment](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/) เมธอด `add_modern_comment` และ `insert_modern_comment` ถูกเพิ่มเข้าไปในคลาส [CommentCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/commentcollection/)

โค้ด Python นี้แสดงวิธีการเพิ่มความคิดเห็นสมัยใหม่ลงในสไลด์ในงานนำเสนอ PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

โค้ด Python นี้แสดงวิธีการลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
    for author in presentation.comment_authors:
        author.comments.clear()

    # ลบผู้เขียนทั้งหมด
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบความคิดเห็นที่ระบุ**

โค้ด Python นี้แสดงวิธีการลบความคิดเห็นที่ระบุในสไลด์:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # เพิ่มความคิดเห็น...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น 'resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/) เปิดเผยคุณสมบัติ [status](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/status/) ; คุณสามารถอ่านและตั้งค่าสถานะของ [comment’s state](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncommentstatus/) (เช่น ทำเครื่องหมายว่า resolved) และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาที่เป็นเธรด (สายการตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนลำดับหรือไม่?**

ใช่. ความคิดเห็นแต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/python-net/aspose.slides/moderncomment/parent_comment/) ของมัน ทำให้สามารถสร้างสายการตอบกลับได้อย่างอิสระ API ไม่ได้ระบุขีดจำกัดความลึกของการซ้อนกัน

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งจะถูกเก็บเป็นจุดจำนวนทศนิยมในระบบพิกัดของสไลด์ ซึ่งทำให้คุณสามารถวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตามที่ต้องการ