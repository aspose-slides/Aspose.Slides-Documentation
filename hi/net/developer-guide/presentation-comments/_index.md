---
title: ".NET में प्रस्तुति टिप्पणियों का प्रबंधन"
linktitle: "प्रस्तुति टिप्पणियाँ"
type: docs
weight: 100
url: /hi/net/presentation-comments/
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
- टिप्पणी निकालें
- टिप्पणी हटाएँ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET के साथ प्रस्तुति टिप्पणी प्रबंधन के बारे में समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुँचना, उत्तर और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रस्तुति से टिप्पणियों को हटाना दर्शाता है।

उदाहरण PowerPoint में सामान्य समीक्षात्मक और सहयोगी परिदृश्यों को कवर करता है, जैसे कि लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी पाठ और मेटाडाटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, तथा चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड्स पर एनोटेशन के रूप में दिखती हैं। कोई टिप्पणी चुनने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

जब आप प्रस्तुति खोलते समय टिप्पणियों को दिखाने या छिपाने का अनुरोध करना चाहते हैं, बिना स्वयं टिप्पणियों को बदले, तो देखें [Show or Hide Comments When Opening a Presentation](/slides/hi/net/presentation-view-properties/)।

## **प्रस्तुति में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुति की समीक्षा करते समय प्रतिक्रिया प्रदान करने और सहयोगियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for .NET टिप्पणी के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/hi/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments.

## **स्लाइड टिप्पणियाँ जोड़ें**
नीचे दिया गया उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स पर टिप्पणियाँ कैसे जोड़ें:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **स्लाइड टिप्पणियों तक पहुँचें**
नीचे दिया गया उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक कैसे पहुँचें:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **टिप्पणियों का उत्तर दें**
एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदानुक्रम के शीर्ष पर होती है। [ParentComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/properties/parentcomment) प्रॉपर्टी आपको टिप्पणी का पैरेंट प्राप्त करने या सेट करने की अनुमति देती है।

नीचे दिया गया उदाहरण दिखाता है कि उत्तर कैसे जोड़ें और परिणामी टिप्पणी पदानुक्रम की जांच कैसे करें:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* जब [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/methods/remove) मेथड का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उसकी सभी उत्तर भी हटाए जा जाते हैं।
* यदि [ParentComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/properties/parentcomment) प्रॉपर्टी एक चक्रीय संदर्भ बनाती है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर टेक्स्ट रेंज से जोड़ा जा सकता है। [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icommentcollection/addmoderncomment/) मेथड स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अतिरिक्त एक [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) аргумент स्वीकार करता है।

जब `null` को आकार аргумент के रूप में पास किया जाता है, तो टिप्पणी एक स्लाइड‑लेवल टिप्पणी होती है। उसका मार्कर प्रदान किए गए निर्देशांक द्वारा स्थित होता है, लेकिन वह किसी विशिष्ट आकार से जुड़ी नहीं होती, इसलिए [IModernComment.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/shape/) `null` लौटाता है। जब एक [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) दिया जाता है, तो टिप्पणी उस आकार से जुड़ी होती है। निर्देशांक फिर भी स्लाइड पर टिप्पणी‑मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार संबंध को [IModernComment.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/shape/) द्वारा प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार से जोड़ें**

नीचे दिया गया उदाहरण एक स्लाइड‑लेवल आधुनिक टिप्पणी और एक विशिष्ट AutoShape से जुड़ी आधुनिक टिप्पणी बनाता है। फिर प्रत्येक टिप्पणी से संबंधित आकार को पढ़ता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **विभिन्न आकार प्रकारों से टिप्पणियाँ जोड़ें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) को लागू करता है, आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hi/net/aspose.slides/iconnector/), और [IGraphicalObject](https://reference.aspose.com/slides/hi/net/aspose.slides/igraphicalobject/) जैसे चार्ट शामिल हैं।

नीचे दिया गया उदाहरण कई सामान्य आकार प्रकार बनाता है और प्रत्येक से एक आधुनिक टिप्पणी जोड़ता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **टेक्स्ट से टिप्पणी जोड़ें और उसकी स्थिति सेट करें**

एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/textselectionstart/) आकार के टेक्स्ट फ़्रेम में चयनित टेक्स्ट की प्रारम्भिक स्थिति दर्शाता है, जबकि [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/textselectionlength/) चयन की लंबाई बताता है। इन दोनों प्रॉपर्टी के साथ टिप्पणी को AutoShape के भीतर विशिष्ट टेक्स्ट रेंज से जोड़ा जाता है।

[IModernComment.Status](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/status/) प्रॉपर्टी को [ModernCommentStatus](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncommentstatus/) मान से पढ़ा या अद्यतन किया जा सकता है:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति निर्धारित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी हल हो गई है।
- `Closed` — टिप्पणी बंद है।

नीचे दिया गया उदाहरण एक आकार‑एंकर वाली आधुनिक टिप्पणी बनाता है, उसे टेक्स्ट चयन से जोड़ता है, इसे हल हुए के रूप में चिह्नित करता है, प्रस्तुति को सहेजता है, और फ़ाइल पुनः खोलने के बाद मूल्यों की जाँच करता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **मौजूदा आधुनिक टिप्पणियों की जाँच करें**

किसी मौजूदा प्रस्तुति की जाँच करने के लिए, देखें कि कौन‑से टिप्पणियाँ [IModernComment](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/) लागू करती हैं, फिर [IModernComment.Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/textselectionlength/), और [IModernComment.Status](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/status/) की जांच करें। `null` आकार एक स्लाइड‑लेवल टिप्पणी को दर्शाता है। जब [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) एंकर होता है, तो टेक्स्ट‑सेलेक्शन प्रॉपर्टी आकार के टेक्स्ट फ़्रेम में संबंधित रेंज को पहचानती है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणियों और टिप्पणी लेखकों को हटाएँ**

नीचे दिया गया उदाहरण दिखाता है कि प्रस्तुति से सभी टिप्पणियों और टिप्पणी लेखकों को कैसे हटाएँ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **विशिष्ट टिप्पणियों को हटाएँ**

नीचे दिया गया उदाहरण दिखाता है कि स्लाइड से विशिष्ट टिप्पणियों को कैसे हटाएँ:

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल‑होने की स्थिति समर्थन करता है?**

हाँ। [IModernComment.Status](https://reference.aspose.com/slides/hi/net/aspose.slides/imoderncomment/status/) को [ModernCommentStatus](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncommentstatus/) मान के साथ पढ़ा और सेट किया जा सकता है, जिसमें `Resolved` भी शामिल है। यह स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या nesting की कोई सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/net/aspose.slides/comment/parentcomment/) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएँ बनती हैं। API ने कोई विशेष nesting‑depth सीमा निर्धारित नहीं की है।

**स्लाइड पर टिप्पणी‑मार्कर की स्थिति कौन‑से निर्देशांक प्रणाली में निर्धारित की जाती है?**

मार्कर की स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांक द्वारा निर्धारित की जाती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।