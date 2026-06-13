---
title: टिप्पणी
type: docs
weight: 230
url: /hi/python-net/examples/elements/comment/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- टिप्पणी जोड़ें
- टिप्पणी पहुँचें
- टिप्पणी हटाएँ
- टिप्पणी का उत्तर दें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेसेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में स्लाइड टिप्पणियों का प्रबंधन करें: जोड़ें, पढ़ें, उत्तर दें, संपादित करें, हटाएँ, और PowerPoint तथा OpenDocument के लिए थ्रेडेड टिप्पणियों के साथ काम करें।"
---
**Aspose.Slides for Python via .NET** का उपयोग करके आधुनिक टिप्पणी जोड़ने, पढ़ने, हटाने और उत्तर देने का प्रदर्शन करता है।

## **आधुनिक टिप्पणी जोड़ें**

उपयोगकर्ता द्वारा लिखी गई टिप्पणी बनाएं और प्रस्तुति को सहेजें।

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # टिप्पणी लेखक जोड़ें।
        author = presentation.comment_authors.add_author("User", "U1")

        # एक आधुनिक टिप्पणी जोड़ें।
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **आधुनिक टिप्पणी तक पहुँचें**

मौजूदा प्रस्तुति से एक आधुनिक टिप्पणी पढ़ें।

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # पहले आधुनिक टिप्पणी तक पहुँचें।
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **आधुनिक टिप्पणी हटाएं**

एक टिप्पणी हटाएं और अपडेटेड फ़ाइल को सहेजें।

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # टिप्पणी हटाएँ।
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **आधुनिक टिप्पणी का उत्तर दें**

पैरेंट आधुनिक टिप्पणी पर उत्तर जोड़ें।

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # मूल टिप्पणी जोड़ें।
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # पहली प्रतिक्रिया जोड़ें।
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # दूसरी प्रतिक्रिया जोड़ें।
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```