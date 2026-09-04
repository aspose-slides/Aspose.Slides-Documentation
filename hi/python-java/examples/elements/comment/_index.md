---
title: टिप्पणी
type: docs
weight: 230
url: /hi/python-java/examples/elements/comment/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी हटाएँ
- टिप्पणी का उत्तर दें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में आधुनिक स्लाइड टिप्पणियों का प्रबंधन: PowerPoint और OpenDocument प्रस्तुतियों में टिप्पणियों को जोड़ें, पढ़ें, हटाएँ, और उत्तर दें।"
---
यह लेख **Aspose.Slides for Python via Java** का उपयोग करके आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उनका उत्तर देने का प्रदर्शन करता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को आयात करता है, फिर JVM चलने के बाद API और आवश्यक Java प्रकारों को आयात करता है। एक्सेस और हटाने के उदाहरण `modern_comment.pptx` का उपयोग करते हैं, जिसे पहले उदाहरण द्वारा बनाया गया था।

## **आधुनिक टिप्पणी जोड़ें**

उपयोगकर्ता द्वारा लिखी गई एक टिप्पणी बनाएँ और प्रस्तुति सहेजें।

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

## **आधुनिक टिप्पणी तक पहुँचें**

मौजूदा प्रस्तुति से पहली आधुनिक टिप्पणी पढ़ें।

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

## **आधुनिक टिप्पणी हटाएँ**

पहली टिप्पणी हटाएँ और अद्यतन प्रस्तुति सहेजें।

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

## **आधुनिक टिप्पणी का उत्तर दें**

एक मूल टिप्पणी बनाएँ, दो उत्तर जोड़ें, और प्रस्तुति सहेजें।

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