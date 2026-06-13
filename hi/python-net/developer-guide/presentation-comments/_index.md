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
- टिप्पणी पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुति टिप्पणियों को सहजता से नियंत्रित करें: PowerPoint फ़ाइलों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति टिप्पणियों को प्रबंधित करने के तरीकों की व्याख्या करता है। यह मुख्य टिप्पणी‑से संबंधित प्रकारों को दिखाता है और स्लाइड्स में टिप्पणियाँ जोड़ने, मौजूदा टिप्पणियों तक पहुँचने, प्रतिक्रियाओं के साथ काम करने, आधुनिक टिप्पणियों का उपयोग करने, और प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे लेखकों को टिप्पणियाँ सौंपना, टिप्पणी सामग्री और मेटाडेटा पढ़ना, उत्तर शृंखलाएँ बनाना, तथा सभी टिप्पणियों को साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रदर्शित होते हैं।

## **प्रस्तुतियों में टिप्पणी क्यों जोड़ें?**

आप प्रस्तुति की समीक्षा करते समय अपने सहयोगियों को प्रतिक्रिया देने या संवाद करने के लिए टिप्पणियों का उपयोग करना चाह सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणी का उपयोग करने के लिए, Aspose.Slides for Python via .NET प्रदान करता है

* The [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class, जो लेखकों (from the [CommentAuthorCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentauthorcollection/) property) के संग्रह को शामिल करता है। लेखक स्लाइड्स पर टिप्पणी जोड़ते हैं। 
* The [CommentCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/) class, जो व्यक्तिगत लेखकों के लिए टिप्पणियों के संग्रह को शामिल करता है। 
* The [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class, जो लेखकों और उनकी टिप्पणियों की जानकारी रखता है: किसने टिप्पणी जोड़ी, टिप्पणी कब जोड़ी गई, टिप्पणी की स्थिति आदि। 
* The [CommentAuthor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentauthor/) class, जो व्यक्तिगत लेखकों की जानकारी रखता है: लेखक का नाम, उनके आरंभाक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ आदि। 

## **स्लाइड टिप्पणी जोड़ें**
यह Python कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड पर टिप्पणी कैसे जोड़ें:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation क्लास का एक उदाहरण बनाता है
with slides.Presentation() as presentation:
    # एक खाली स्लाइड जोड़ता है
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # एक लेखक जोड़ता है
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # टिप्पणियों के लिए स्थिति निर्धारित करता है
    point = draw.PointF(0.2, 0.2)

    # स्लाइड 1 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # स्लाइड 2 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1 तक पहुँच रहा है
    slide = presentation.slides[0]

    # जब null को तर्क के रूप में पास किया जाता है, तो सभी लेखकों की टिप्पणियाँ चयनित स्लाइड में लाई जाती हैं
    comments = slide.get_slide_comments(author)

    # स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुँचता है
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # इंडेक्स 0 पर लेखक की टिप्पणी संग्रह चुनता है
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **स्लाइड टिप्पणियों तक पहुँचें**
यह Python कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड पर मौजूदा टिप्पणी तक कैसे पहुँचें:

```python
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाता है
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **टिप्पणियों का उत्तर देना**
किसी टिप्पणी को पैरेंट टिप्पणी कहा जाता है जो टिप्पणी या उत्तर की पदानुक्रम में शीर्ष या मूल टिप्पणी होती है। आप `parent_comment` प्रॉपर्टी (from the [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class) का उपयोग करके पैरेंट टिप्पणी सेट या प्राप्त कर सकते हैं। 

यह Python कोड दिखाता है कि टिप्पणियाँ जोड़ें और उनके उत्तर प्राप्त करें:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # एक टिप्पणी जोड़ता है
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # comment1 के लिए एक उत्तर जोड़ता है
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # comment1 के लिए एक और उत्तर जोड़ता है
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # मौजूदा उत्तर के लिए एक उत्तर जोड़ता है
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # कंसोल पर टिप्पणी पदानुक्रम दिखाता है
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

    # comment1 और इसके सभी उत्तरों को हटाता है
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="ध्यान" %}} 

* जब `remove` मेथड (from the [Comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/comment/) class) का उपयोग करके टिप्पणी को हटाया जाता है, तो टिप्पणी के उत्तर भी हटा दिए जाते हैं। 
* यदि `parent_comment` सेटिंग के कारण एक चक्रीय संदर्भ बनता है, तो `PptxEditException` फेंका जाएगा।

{{% /alert %}}

## **आधुनिक टिप्पणी जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियों* का परिचय कराया। आधुनिक टिप्पणी सुविधा PowerPoint में सहयोग को काफी बेहतर बनाती है। आधुनिक टिप्पणियों के ज़रिए PowerPoint उपयोगकर्ता आसानी से टिप्पणियों को हल कर सकते हैं, टिप्पणियों को ऑब्जेक्ट और टेक्स्ट से जोड़ सकते हैं, और बातचीत को अधिक सहजता से कर सकते हैं। 

हमने आधुनिक टिप्पणियों के समर्थन को लागू करने के लिए [ModernComment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/) क्लास जोड़ा है। `add_modern_comment` और `insert_modern_comment` मेथड्स को [CommentCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/commentcollection/) क्लास में जोड़ा गया है। 

यह Python कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड पर आधुनिक टिप्पणी कैसे जोड़ें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **टिप्पणी हटाएँ**

### **सभी टिप्पणियों और लेखकों को हटाएँ**

यह Python कोड दिखाता है कि प्रस्तुति में सभी टिप्पणियों और लेखकों को कैसे हटाएँ:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # प्रस्तुति से सभी टिप्पणियों को हटाता है
    for author in presentation.comment_authors:
        author.comments.clear()

    # सभी लेखकों को हटाता है
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **विशिष्ट टिप्पणियों को हटाएँ**

यह Python कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाएँ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # टिप्पणियाँ जोड़ें...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # सभी टिप्पणियों को हटाएँ जिनमें "comment 1" पाठ हो
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'resolved' जैसी स्थिति को सपोर्ट करता है?**

हां। [Modern comments](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/) में एक [status](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/status/) प्रॉपर्टी उपलब्ध है; आप एक [comment’s state](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncommentstatus/) (उदाहरण के लिए, इसे resolved के रूप में चिह्नित) पढ़ और सेट कर सकते हैं, और यह स्थिति फ़ाइल में सहेजी जाती है तथा PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड चर्चा (उत्तर शृंखलाएँ) समर्थित हैं, और क्या इसमें नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/moderncomment/parent_comment/) को संदर्भित कर सकती है, जिससे 任意 उत्तर शृंखलाएँ संभव होती हैं। API कोई विशिष्ट नेस्टिंग गहराई सीमा निर्धारित नहीं करता।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में निर्धारित की गई है?**

स्थिति स्लाइड की निर्देशांक प्रणाली में एक फ्लोटिंग‑पॉइंट बिंदु के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को ठीक वहीँ रखने की सुविधा देता है जहाँ आपको आवश्यकता है।