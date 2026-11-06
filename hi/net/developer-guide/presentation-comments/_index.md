---
title: .NET में प्रेजेंटेशन टिप्पणियों का प्रबंधन
linktitle: प्रेजेंटेशन टिप्पणियां
type: docs
weight: 100
url: /hi/net/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियां
- प्रेजेंटेशन टिप्पणियां
- स्लाइड टिप्पणियां
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी उत्तर
- टिप्पणी हटाएँ
- टिप्पणी हटाएँ
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रेजेंटेशन टिप्पणियों को प्रबंधित करें: PowerPoint प्रेजेंटेशन में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **समीक्षा**

यह लेख Aspose.Slides for .NET के साथ प्रेजेंटेशन टिप्पणियों को प्रबंधित करने का तरीका समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय देता है और स्लाइड में टिप्पणियां जोड़ना, मौजूदा टिप्पणियों तक पहुंचना, उत्तरों और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रेजेंटेशन से टिप्पणियां हटाना दिखाता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे टिप्पणी लेखकों को सौंपना, टिप्पणी टेक्स्ट और मेटाडाटा पढ़ना, रिप्लाई चेन बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियां स्लाइड पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका टेक्स्ट और संबंधित चर्चा प्रदर्शित होती है।

जब आप चाहते हैं कि प्रेजेंटेशन खुलने पर टिप्पणियां दिखें या छिपें, बिना स्वयं टिप्पणियों को बदले, देखें [प्रेजेंटेशन खोलते समय टिप्पणियां दिखाने या छिपाने के लिए](/slides/hi/net/presentation-view-properties/)।

## **प्रेजेंटेशन में टिप्पणियां क्यों जोड़ें?**

आप प्रेजेंटेशन की समीक्षा करते समय प्रतिक्रिया देने और सहकर्मियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for .NET टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास, जो प्रेजेंटेशन के टिप्पणी लेखकों तक पहुंच प्रदान करती है।
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) इंटरफ़ेस, जो व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करता है।
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) इंटरफ़ेस, जो टिप्पणी के बारे में जानकारी देता है, जिसमें उसका लेखक, निर्माण समय, स्थिति और टेक्स्ट शामिल है।
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) क्लास, जो लेखक के बारे में जानकारी प्रदान करती है, जैसे उनका नाम, आद्याक्षर, और संबंधित टिप्पणियां।

## **स्लाइड टिप्पणियां जोड़ें**

उदाहरण दो स्लाइड बनाता है और [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) से एक टिप्पणी लेखक को पंजीकृत करता है। यह प्रत्येक स्लाइड पर एक टिप्पणी रखने के लिए [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) का उपयोग करता है, फिर उस लेखक के लिए पहले स्लाइड की टिप्पणियां [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) से प्राप्त करता है। कंसोल पहले टिप्पणी के टेक्स्ट को दो बार प्रदर्शित करता है, जिससे स्लाइड और लेखक दोनों के माध्यम से पहुंच दर्शाई जाती है, और सहेजा गया प्रेजेंटेशन दोनों टिप्पणियां रखता है।

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

## **टिप्पणी लेखक खोजें या बनाएं**

जब कोई स्वचालित समीक्षा समान प्रेजेंटेशन को बार‑बार प्रोसेस करती है, तो लेखक जोड़ने से पहले उसकी [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) संग्रह को खोजें। [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) नाम और आद्याक्षर दोनों से मेल खाता है और मिलते‑जुलते लेखकों की एक array लौटाता है, या यदि कोई मेल नहीं है तो खाली array। इसके विपरीत, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) केवल नाम से खोज करता है, चाहे आद्याक्षर हों या न हों। यदि आप वही नाम और आद्याक्षर वाली एक लेखक को फिर से जोड़ते हैं, तो [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) अपवाद फेंकेगा।

उदाहरण के लिए, कम से कम एक स्लाइड वाले प्रेजेंटेशन फ़ाइल की आवश्यकता होती है। दो पासों में, यह पहले मिले लेखक को पुन: उपयोग करता है, या परिणाम खाली होने पर नया बनाता है। यदि कई मिलते हैं, तो यह पहला array तत्व चुनता है, बिना अन्य लेखकों को मिलाए या हटाए। फिर वह चयनित लेखक के लिए [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) को कॉल करता है और प्रेजेंटेशन सहेजता है। दूसरा पास पहले पास के आउटपुट को खोलता है और वही प्रक्रिया दोहराता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

दूसरे पास में एक और टिप्पणी जोड़ी जाती है, लेकिन नया लेखक नहीं बनाया जाता और मौजूदा टिप्पणियों को नहीं हटाया जाता। अंतिम फ़ाइल `review_pass_2.pptx` दोनों नई टिप्पणियां साथ ही मूल टिप्पणियां रखती है। लेखक का पुन: उपयोग करने से टिप्पणियों का डुप्लिकेशन नहीं होता: समान टिप्पणी को बार‑बार जोड़ने से बचने के लिए जोड़ने से पहले अलग डुप्लीकेट जाँच लागू करें।

## **स्लाइड टिप्पणियों तक पहुंचें**

उदाहरण मौजूदा प्रेजेंटेशन को खोलता है और उसकी [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) संग्रह को पढ़ता है। प्रत्येक लेखक के लिए, यह [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) पर इटरेट करता है और स्लाइड नंबर, टिप्पणी टेक्स्ट, लेखक नाम, तथा निर्माण समय को प्रिंट करता है। इनपुट प्रेजेंटेशन में टिप्पणी होनी चाहिए ताकि कंसोल आउटपुट उत्पन्न हो।

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

एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदानुक्रम के शीर्ष पर स्थित होती है। [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) इंटरफ़ेस की [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) प्रॉपर्टी आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने देती है।

उदाहरण दो लेखकों से टिप्पणियां बनाता है और [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) का उपयोग करके उत्तर बनाता है, जिसमें एक उत्तर का उत्तर भी शामिल है। `null` को [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) में पास करने से सभी लेखकों की टिप्पणियां प्राप्त होती हैं; कंसोल प्रत्येक प्रविष्टि को उसकी गहराई के अनुसार इंडेंट करता है। उदाहरण पूरी चर्चा को सहेजता है, पहले रूट टिप्पणी पर [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) को कॉल करता है, और उस टिप्पणी और उसके उत्तरों को हटाकर दूसरा प्रेजेंटेशन बनाता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* जब [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) इंटरफ़ेस की [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) विधि से कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटा दिए जातें हैं।
* यदि [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) प्रॉपर्टी एक चक्रीय संदर्भ बनाती है, तो [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) फेंका जाएगा।
{{% /alert %}}

## **आधुनिक टिप्पणियां जोड़ें**

आधुनिक टिप्पणी को स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के टेक्स्ट रेंज के साथ जोड़ा जा सकता है। [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) विधि में स्लाइड और टिप्पणी‑मार्कर निर्देशांक के साथ एक अतिरिक्त [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) आर्ग्यूमेंट स्वीकार किया जाता है।

जब `null` को shape आर्ग्यूमेंट के रूप में पास किया जाता है, तो टिप्पणी स्लाइड‑स्तरीय टिप्पणी बन जाती है। उसका मार्कर प्रदान किए गए निर्देशांक द्वारा स्थित होता है, लेकिन यह किसी विशेष आकार से जुड़ा नहीं होता, इसलिए [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` लौटाता है। जब कोई [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) दिया जाता है, तो टिप्पणी उस आकार से एंकर होती है। निर्देशांक अभी भी स्लाइड पर मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार का संबंध [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार पर एंकर करें**

उदाहरण दो बार [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) को कॉल करता है: एक बार `null` आकार के साथ स्लाइड‑स्तरीय टिप्पणी के लिए और एक बार आयत को एंकर के रूप में। [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) पढ़ने से स्लाइड‑स्तरीय टिप्पणी के `null` जांच के लिए `True` और एंकर की गई टिप्पणी के लिए `Revenue title` प्रदर्शित होता है। दोनों टिप्पणियां प्रेजेंटेशन के साथ सहेजी गई हैं।

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

### **विभिन्न आकार प्रकारों पर टिप्पणियां एंकर करें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) को लागू करता है, उसे आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), और चार्ट जैसी [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) इंस्टैंस शामिल हैं।

उदाहरण [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) का उपयोग करके पाँच आकार प्रकारों—AutoShape, picture frame, group, connector, और chart—के साथ एक‑एक टिप्पणी जोड़ता है। चित्र में एम्बेडेड इमेज डेटा होता है, इसलिए कोई बाहरी इमेज आवश्यक नहीं है। प्रत्येक टिप्पणी का अपना मार्कर स्थिति होता है, और सहेजा गया प्रेजेंटेशन सभी पाँच आकार संबंधों को बरकरार रखता है।

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

### **टेक्स्ट पर टिप्पणी एंकर करें और उसकी स्थिति सेट करें**

[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) आकार के टेक्स्ट फ़्रेम में चयनित टेक्स्ट की शुरुआती स्थिति निर्धारित करता है, जबकि [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) चयन की लंबाई बताता है। ये दोनों प्रॉपर्टी टिप्पणी को AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से जोड़ती हैं।

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) प्रॉपर्टी को [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) एन्यूमरेशन के मानों से पढ़ा या अपडेट किया जा सकता है:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति निर्धारित नहीं।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी हल हो गई है।
- `Closed` — टिप्पणी बंद है।

उदाहरण एक आयत के टेक्स्ट में शब्द “quarterly revenue” पर आधुनिक टिप्पणी एंकर करता है। वह टेक्स्ट से शून्य‑आधारित [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) की गणना करता है और चयनित अक्षरों की संख्या के रूप में [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) सेट करता है। [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) को `Resolved` करने के बाद, वह प्रेजेंटेशन को सहेजता और पुनः खोलता है। चार कंसोल जाँच प्रत्येक `True` प्रिंट करनी चाहिए, जिससे पुष्टि हो कि आकार एंकर, टेक्स्ट रेंज, और स्थिति संरक्षित रह गई।

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

### **मौजूदा आधुनिक टिप्पणियों की जांच करें**

उदाहरण के लिए एक मौजूदा प्रेजेंटेशन की आवश्यकता है जिसमें आधुनिक टिप्पणियां हों, और वह उनके टेक्स्ट, स्थिति, और एंकर विवरण प्रिंट करता है। जांचने के लिए, देखें कि कौन सी टिप्पणियां [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) लागू करती हैं, फिर [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), और [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) का परीक्षण करें। `null` आकार का अर्थ है स्लाइड‑स्तरीय टिप्पणी। यदि [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) एंकर है, तो टेक्स्ट‑सेलेक्शन प्रॉपर्टी आकार के टेक्स्ट फ़्रेम में संबंधित रेंज को पहचानती है।

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

## **टिप्पणियां हटाएं**

Aspose.Slides for .NET आपको प्रेजेंटेशन से सभी टिप्पणियां और उनके लेखकों को हटाने या चयनित टिप्पणियों को हटाते हुए शेष को बरकरार रखने की अनुमति देता है। निम्न उदाहरण दोनों विधियों को दर्शाते हैं और अद्यतन प्रेजेंटेशन को सहेजते हैं।

### **सभी टिप्पणियां और टिप्पणी लेखकों को हटाएं**

उदाहरण मौजूदा प्रेजेंटेशन को खोलता है और प्रत्येक लेखक के लिए [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) को कॉल करता है, फिर [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) को कॉल करके स्वयं लेखकों को हटाता है। सहेजा गया प्रेजेंटेशन न तो टिप्पणियां न ही टिप्पणी लेखक रखता है। हटाने को देखना हो तो टिप्पणी वाली प्रेजेंटेशन का उपयोग करें।

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

### **विशिष्ट टिप्पणियां हटाएं**

उदाहरण एक स्लाइड पर दो टिप्पणी बनाता है और प्रत्येक लेखक की टिप्पणियों को खोजने के लिए [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) का उपयोग करता है। वह उन टिप्पणियों को इकट्ठा करता है जिनका टेक्स्ट “comment 1” के बराबर है, फिर [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) को कॉल करता है, जिससे चयन के दौरान संग्रह बदलने से बचा जा सके। सहेजा गया प्रेजेंटेशन केवल “comment 2” को रखता है।

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

## **FAQ**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल की गई स्थिति का समर्थन करता है?**

हाँ। [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) को [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) मान के साथ पढ़ा और सेट किया जा सकता है, जिसमें `Resolved` भी शामिल है। स्थिति प्रेजेंटेशन में संग्रहीत होती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड डिस्कशन (उत्तर चेन) समर्थित हैं, और क्या इनमें नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) को संदर्भित कर सकती है, जिससे उत्तर चेन बनती है। API कोई विशिष्ट नेस्टिंग‑गहराई सीमा निर्धारित नहीं करती।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में निर्धारित की जाती है?**

मार्कर की स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांकों द्वारा परिभाषित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।