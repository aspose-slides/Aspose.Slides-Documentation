---
title: Python के माध्यम से Java में प्रस्तुति टिप्पणियों को प्रबंधित करें
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/python-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी को हटाएँ
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति टिप्पणियों का प्रबंधन करें: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करने के तरीके को समझाता है। यह मुख्य टिप्पणी‑संबंधी प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुँचना, उत्तरों और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रस्तुति से टिप्पणियों को हटाना दर्शाता है।

उदाहरण PowerPoint में सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी का टेक्स्ट और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, तथा चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड्स पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका टेक्स्ट और संबंधित चर्चा प्रदर्शित होती है।

## **प्रस्तुतियों में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुतियों की समीक्षा करते समय प्रतिक्रिया देने और सहयोगियों के साथ सहयोग करने के लिए टिप्पणी का उपयोग कर सकते हैं।

Aspose.Slides for Python via Java टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास, जो प्रस्तुति के टिप्पणी लेखकों तक पहुंच प्रदान करती है।
* The [CommentCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentcollection/) क्लास, जो व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करती है।
* The [Comment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/) क्लास, जो टिप्पणी के बारे में जानकारी प्रदान करती है, जिसमें लेखक, निर्माण समय, स्थिति और टेक्स्ट शामिल हैं।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentauthor/) क्लास, जो लेखक के बारे में जानकारी देती है, जिसमें उनका नाम, आद्याक्षर, और जुड़ी टिप्पणी शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स में टिप्पणियाँ कैसे जोड़ी जाती हैं:

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

## **स्लाइड टिप्पणियों तक पहुँचें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक कैसे पहुँचा जाता है:

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

## **टिप्पणियों का उत्तर दें**

एक पैरेंट टिप्पणी उत्तर पदानुक्रम के शीर्ष पर मौलिक टिप्पणी होती है। The [Comment.getParentComment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/#getParentComment) और The [Comment.setParentComment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/#setParentComment) मेथड आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने की अनुमति देते हैं।

निम्नलिखित उदाहरण दिखाता है कि उत्तर कैसे जोड़े जाएँ और परिणामस्वरूप टिप्पणी पदानुक्रम का निरीक्षण कैसे किया जाए:

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
* जब [Comment.remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/#remove) मेथड का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [Comment.setParentComment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/#setParentComment) एक चक्रीय संदर्भ बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट आकार, या किसी [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) के भीतर टेक्स्ट रेंज से संबंधित किया जा सकता है। The [CommentCollection.addModernComment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentcollection/#addModernComment) मेथड स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अतिरिक्त एक [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) आर्ग्यूमेंट स्वीकार करता है।

जब `None` को shape आर्ग्यूमेंट के रूप में पास किया जाता है, तो टिप्पणी एक स्लाइड‑स्तर टिप्पणी होती है। इसका मार्कर प्रदान किए गए निर्देशांकों द्वारा स्थित किया जाता है, लेकिन यह किसी विशेष shape से जुड़ी नहीं होती, इसलिए [ModernComment.getShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getShape) `None` लौटाता है। जब कोई [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) प्रदान किया जाता है, तो टिप्पणी उस shape से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी मार्कर की स्थिति को परिभाषित करते हैं, जबकि shape संबद्धता को [ModernComment.getShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getShape) के माध्यम से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को Shape से जोड़ना**

निम्नलिखित उदाहरण एक स्लाइड‑स्तर आधुनिक टिप्पणी और एक विशिष्ट [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) से जुड़ी आधुनिक टिप्पणी बनाता है। फिर यह प्रत्येक टिप्पणी से सम्बंधित shape को पढ़ता है।

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

### **टिप्पणियों को विभिन्न Shape प्रकारों से जोड़ना**

कोई भी स्लाइड ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) से विरासत में मिला है, उसे shape एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/), और [GraphicalObject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/graphicalobject/) उदाहरण जैसे चार्ट शामिल हैं।

निम्नलिखित उदाहरण कई सामान्य shape प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी को संबद्ध करता है।

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

### **टेक्स्ट से टिप्पणी जोड़ें और उसकी स्थिति सेट करें**

एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getTextSelectionStart) और [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#setTextSelectionStart) shape के टेक्स्ट फ्रेम में चयनित टेक्स्ट की प्रारम्भिक स्थिति तक पहुँचते हैं। [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getTextSelectionLength) और [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#setTextSelectionLength) चयन की लंबाई तक पहुँचते हैं। मिलकर, ये मान टिप्पणी को AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से जोड़ते हैं।

[ModernComment.getStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getStatus) और [ModernComment.setStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#setStatus) मेथड [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/) स्थिरांक से एक मान तक पहुँचते हैं:

- [NotDefined](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/#NotDefined) — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- [Active](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/#Active) — टिप्पणी सक्रिय है।
- [Resolved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/#Resolved) — टिप्पणी हल हो गई है।
- [Closed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/#Closed) — टिप्पणी बंद है।

निम्नलिखित उदाहरण एक shape‑एंकर वाली आधुनिक टिप्पणी बनाता है, उसे टेक्स्ट चयन से जोड़ता है, इसे हल‑की हुई के रूप में चिह्नित करता है, प्रस्तुति को सहेजता है, और फ़ाइल को पुनः खोलने के बाद मानों की जाँच करता है।

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

### **मौजूदा आधुनिक टिप्पणियों का निरीक्षण**

एक मौजूदा प्रस्तुति का निरीक्षण करने के लिए, देखें कि कौन‑सी टिप्पणियाँ [ModernComment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/) की इंस्टेंस हैं, फिर [ModernComment.getShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getTextSelectionLength) और [ModernComment.getStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getStatus) को देखें। `None` shape एक स्लाइड‑स्तर टिप्पणी को संकेत करता है। किसी [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) एंकर के लिए, टेक्स्ट‑सेलेक्शन मेथड्स shape के टेक्स्ट फ्रेम में संबंधित रेंज की पहचान करते हैं।

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

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाएँ**

निम्नलिखित उदाहरण दिखाता है कि प्रस्तुति से सभी टिप्पणियाँ और टिप्पणी लेखक कैसे हटाए जाएँ:

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

### **निर्दिष्ट टिप्पणियों को हटाएँ**

निम्नलिखित उदाहरण दिखाता है कि स्लाइड से विशिष्ट टिप्पणियों को कैसे हटाया जाए:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल‑की हुई स्थिति का समर्थन करता है?**

हां। [ModernComment.getStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#getStatus) और [ModernComment.setStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncomment/#setStatus) [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-java/aspose.slides/moderncommentstatus/) मान तक पहुँचते हैं, जिसमें `Resolved` शामिल है। यह स्थिति प्रस्तुति में संग्रहीत होती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/comment/#getParentComment) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएँ संभव होती हैं। API कोई विशिष्ट नेस्टिंग‑गहराई सीमा निर्धारित नहीं करती।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में परिभाषित होती है?**

मार्कर की स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांकों द्वारा परिभाषित होती है, जिससे आप इसे सटीक रूप से स्लाइड पर रख सकते हैं।