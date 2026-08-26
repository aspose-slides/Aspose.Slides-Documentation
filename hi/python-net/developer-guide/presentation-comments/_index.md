---
title: Python में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/python-net/presentation-comments/
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
- टिप्पणी हटाएँ
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियों को जोड़ना, पढ़ना, संपादित करना, उत्तर देना और हटाना।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via .NET के साथ प्रस्तुति टिप्पणियों के प्रबंधन का विवरण देता है। यह मुख्य टिप्पणी‑से‑संबंधित प्रकारों का परिचय कराता है और स्लाइड्स में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुँच, उत्तरों और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रस्तुति से टिप्पणियाँ हटाना दर्शाता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे कि लेखकों को टिप्पणियाँ नियोजित करना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर शृंखलाएँ बनाना, तथा चयनित या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइडों पर एनोटेशन के रूप में दिखती हैं। टिप्पणी का चयन करने से उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

## **प्रस्तुति में टिप्पणियाँ जोड़ने का कारण**

आप प्रस्तुति की समीक्षा के दौरान फीडबैक देने और सहयोगियों के साथ सहयोग करने के लिये टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for Python via .NET टिप्पणी के साथ काम करने के लिये निम्नलिखित API प्रदान करता है:

* वह [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास, जो प्रस्तुति के टिप्पणी लेखकों तक पहुँच प्रदान करती है।
* वह [CommentCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/) क्लास, जो व्यक्तिगत लेखक से संबंधित टिप्पणियों को दर्शाती है।
* वह [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) क्लास, जो टिप्पणी की जानकारी देती है, जिसमें लेखक, निर्माण समय, स्थिति और पाठ शामिल हैं।
* वह [CommentAuthor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentauthor/) क्लास, जो एक लेखक की जानकारी देती है, जिसमें उनका नाम, आरम्भ अक्षर और संबंधित टिप्पणियाँ शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

निम्न उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स पर टिप्पणियाँ कैसे जोड़ें:

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

## **स्लाइड टिप्पणियों तक पहुँचें**

निम्न उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक कैसे पहुँचें:

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

एक मूल टिप्पणी वह मूल टिप्पणी है जो उत्तर श्रेणी के शीर्ष पर होती है। [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) क्लास की [parent_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/) प्रॉपर्टी आपको टिप्पणी के मूल टिप्पणी को प्राप्त या सेट करने की अनुमति देती है।

निम्न उदाहरण दर्शाता है कि उत्तर कैसे जोड़ें और परिणामी टिप्पणी श्रेणी का निरीक्षण कैसे करें:

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

{{% alert color="warning" title="चेतावनी" %}}
* जब [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) क्लास की [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/remove/) विधि का उपयोग करके किसी टिप्पणी को हटाया जाता है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [parent_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/) प्रॉपर्टी एक चक्रीय संदर्भ बनाती है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न होती है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशेष आकार, या AutoShape के भीतर किसी पाठ श्रेणी से जोड़ा जा सकता है। [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/add_modern_comment/) विधि स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अलावा एक [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) तर्क को भी स्वीकार करती है।

जब `None` को आकार तर्क के लिए पास किया जाता है, तो टिप्पणी एक स्लाइड‑स्तरीय टिप्पणी होती है। इसका मार्कर प्रदान किए गए निर्देशांक द्वारा स्थित किया जाता है, लेकिन यह किसी विशिष्ट आकार से जुड़ा नहीं होता, इसलिए [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/) `None` लौटाता है। जब कोई [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) दिया जाता है, तो टिप्पणी उस आकार से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी‑मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार‑संबंध को [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/) के माध्यम से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार से जोड़ें**

निम्न उदाहरण एक स्लाइड‑स्तरीय आधुनिक टिप्पणी और एक विशिष्ट AutoShape से जुड़ी आधुनिक टिप्पणी बनाता है। फिर प्रत्येक टिप्पणी से संबंधित आकार को पढ़ता है।

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

### **विभिन्न आकार प्रकारों से टिप्पणियाँ जोड़ें**

[Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) से व्युत्पन्न कोई भी स्लाइड वस्तु आकार एंकर के रूप में उपयोग की जा सकती है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hi/python-net/aspose.slides/connector/), और चार्ट जैसे [GraphicalObject](https://reference.aspose.com/slides/hi/python-net/aspose.slides/graphicalobject/) के उदाहरण शामिल हैं।

निम्न उदाहरण कई सामान्य आकार प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी जोड़ता है।

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

### **टिप्पणी को पाठ से जोड़ें और उसकी स्थिति निर्धारित करें**

एक AutoShape से जुड़ी आधुनिक टिप्पणी के लिये, [ModernComment.text_selection_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_start/) आकार के पाठ फ़्रेम में चयनित पाठ की प्रारम्भिक स्थिति निर्दिष्ट करता है, जबकि [ModernComment.text_selection_length](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_length/) चयन की लंबाई निर्दिष्ट करता है। ये दोनों प्रॉपर्टी टिप्पणी को AutoShape के भीतर विशिष्ट पाठ श्रेणी से जोड़ती हैं।

[ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) प्रॉपर्टी को [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncommentstatus/) enumeration के मान से पढ़ा या अपडेट किया जा सकता है:

- `NOT_DEFINED` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति निर्धारित नहीं है।
- `ACTIVE` — टिप्पणी सक्रिय है।
- `RESOLVED` — टिप्पणी हल हो गई है।
- `CLOSED` — टिप्पणी बंद है।

निम्न उदाहरण एक आकार‑एंकर वाली आधुनिक टिप्पणी बनाता है, उसे पाठ चयन से जोड़ता है, उसे हल के रूप में चिह्नित करता है, प्रस्तुति को सहेजता है, और फ़ाइल को पुनः खोलने के बाद मानों की पुष्टि करता है।

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

### **मौजूदा आधुनिक टिप्पणियों का निरीक्षण करें**

किसी मौजूदा प्रस्तुति का निरीक्षण करने के लिये, देखें कि कौन सी टिप्पणियाँ [ModernComment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/) उदाहरण हैं, फिर [ModernComment.shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/text_selection_length/), और [ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) की जाँच करें। `None` आकार का अर्थ है स्लाइड‑स्तरीय टिप्पणी। किसी [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) एंकर के लिये, पाठ‑चयन प्रॉपर्टी आकार के पाठ फ़्रेम में सम्बंधित श्रेणी को पहचानती है।

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

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाएँ**

निम्न उदाहरण दर्शाता है कि प्रस्तुति से सभी टिप्पणियाँ और टिप्पणी लेखकों को कैसे हटाएँ:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **विशिष्ट टिप्पणियाँ हटाएँ**

निम्न उदाहरण दर्शाता है कि स्लाइड से विशिष्ट टिप्पणियाँ कैसे हटाएँ:

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

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिये हल की स्थिति का समर्थन करता है?**

हां। [ModernComment.status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) को [ModernCommentStatus](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncommentstatus/) मान, जिसमें `RESOLVED` भी शामिल है, से पढ़ा और सेट किया जा सकता है। स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को पुनः खोलने के बाद पुनः पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर शृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/parent_comment/) को संदर्भित कर सकती है, जिससे उत्तर शृंखलाएँ बनती हैं। API कोई विशिष्ट नेस्टिंग‑गहराई सीमा परिभाषित नहीं करता।

**किस निर्देशांक प्रणाली में स्लाइड पर टिप्पणी‑मार्कर की स्थिति निर्धारित की जाती है?**

मार्कर की स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांक द्वारा परिभाषित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से स्थित कर सकते हैं।