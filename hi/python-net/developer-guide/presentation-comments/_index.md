---
title: "Python में प्रेज़ेंटेशन टिप्पणियों का प्रबंधन"
linktitle: "प्रेज़ेंटेशन टिप्पणियाँ"
type: docs
weight: 100
url: /hi/python-net/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रेज़ेंटेशन टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी हटाएँ
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रेज़ेंटेशन टिप्पणियों का प्रबंधन: PowerPoint प्रेज़ेंटेशन में टिप्पणियों को जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **सारांश**

This article explains how to manage presentation comments with Aspose.Slides for Python via .NET. It introduces the main comment-related types and demonstrates how to add comments to slides, access existing comments, work with replies and modern comments, and remove comments from a presentation.

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे कि लेखकों को टिप्पणी सौंपना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखला बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियां स्लाइडों पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

To request that comments be shown or hidden when a presentation opens without changing the comments themselves, see [प्रेज़ेंटेशन खोलते समय टिप्पणियां दिखाएँ या छिपाएँ](/slides/hi/python-net/presentation-view-properties/).

## **प्रेज़ेंटेशन में टिप्पणियों को क्यों जोड़ें?**

You can use comments to provide feedback and collaborate with colleagues when reviewing presentations.

Aspose.Slides for Python via .NET provides the following APIs for working with comments:

* The [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class, जो प्रेज़ेंटेशन के टिप्पणी लेखकों तक पहुंच प्रदान करता है।
* The [CommentCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/) class, जो व्यक्तिगत लेखक से संबंधित टिप्पणियों का प्रतिनिधित्व करता है।
* The [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class, जो एक टिप्पणी के बारे में जानकारी प्रदान करता है, जिसमें उसका लेखक, निर्माण समय, स्थिति और पाठ शामिल हैं।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentauthor/) class, जो एक लेखक के बारे में जानकारी देता है, जिसमें उनका नाम, शुरुआती अक्षर और संबंधित टिप्पणियां शामिल हैं।

## **स्लाइड टिप्पणियां जोड़ें**

The following example shows how to add comments to slides in a PowerPoint presentation:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **स्लाइड टिप्पणियों तक पहुंचें**

The following example shows how to access existing comments in a PowerPoint presentation:

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

## **टिप्पणियों का उत्तर दें**

A parent comment is the original comment at the top of a reply hierarchy. The [parent_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/) property of the [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class lets you get or set the parent of a comment.

The following example shows how to add replies and inspect the resulting comment hierarchy:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* When the [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/remove/) method of the [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class is used to delete a comment, all replies to that comment are also deleted.
* If the [parent_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/) property creates a circular reference, a [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) is thrown.
{{% /alert %}}

## **आधुनिक टिप्पणियां जोड़ें**

Modern comments can be associated with the slide itself, with a specific shape, or with a text range inside an AutoShape. The [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/add_modern_comment/) method accepts a [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) argument in addition to the slide and comment-marker coordinates.

When `None` is passed for the shape argument, the comment is a slide-level comment. Its marker is positioned by the supplied coordinates, but it is not associated with a particular shape, so [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/) returns `None`. When a [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) is supplied, the comment is anchored to that shape. The coordinates still define the position of the comment marker on the slide, while the shape association can be retrieved through [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/).

### **आधुनिक टिप्पणी को आकार पर एंकर करें**

The following example creates both a slide-level modern comment and a modern comment anchored to a specific AutoShape. It then reads the associated shape from each comment.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **विभिन्न आकार प्रकारों पर टिप्पणियों को एंकर करें**

Any slide object derived from [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) can be used as a shape anchor. Common examples include [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hi/python-net/aspose.slides/connector/), and [GraphicalObject](https://reference.aspose.com/slides/hi/python-net/aspose.slides/graphicalobject/) instances such as charts.

The following example creates several common shape types and associates a modern comment with each one.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **टेक्स्ट पर टिप्पणी को एंकर करें और उसकी स्थिति सेट करें**

For a modern comment associated with an [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_start/) specifies the starting position of the selected text in the shape's text frame, while [ModernComment.text_selection_length](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_length/) specifies the length of the selection. Together, these properties associate the comment with a specific text range inside the AutoShape.

The [ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) property can be read or updated with a value from the [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncommentstatus/) enumeration:

- `NOT_DEFINED` — कोई विशिष्ट आधुनिक-टिप्पणी स्थिति परिभाषित नहीं है।
- `ACTIVE` — टिप्पणी सक्रिय है।
- `RESOLVED` — टिप्पणी हल हो गई है।
- `CLOSED` — टिप्पणी बंद है।

The following example creates a shape-anchored modern comment, associates it with a text selection, marks it as resolved, saves the presentation, and verifies the values after reopening the file.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

### **मौजूदा आधुनिक टिप्पणियों की जांच करें**

To inspect an existing presentation, check which comments are [ModernComment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/) instances, then examine [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_length/), and [ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/). A `None` shape indicates a slide-level comment. For an [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) anchor, the text-selection properties identify the associated range in the shape's text frame.

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

## **टिप्पणियां हटाएँ**

### **सभी टिप्पणियां और टिप्पणी लेखकों को हटाएँ**

The following example shows how to remove all comments and comment authors from a presentation:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **विशिष्ट टिप्पणियां हटाएँ**

The following example shows how to remove specific comments from a slide:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल की गई स्थिति का समर्थन करता है?**

Yes. [ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) can be read and set with a [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncommentstatus/) value, including `RESOLVED`. The status is stored in the presentation and can be read again after the file is reopened.

**क्या थ्रेडेड चर्चा (उत्तर श्रृंखलाएं) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

Yes. Each comment can reference its [parent comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/), enabling reply chains. The API does not define a specific nesting-depth limit.

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कोऑर्डिनेट सिस्टम में परिभाषित होती है?**

The marker position is defined by floating-point coordinates in the slide coordinate system, allowing you to place it precisely on the slide.