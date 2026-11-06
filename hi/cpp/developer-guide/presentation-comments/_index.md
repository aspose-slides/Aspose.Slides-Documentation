---
title: C++ में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/cpp/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें, और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for C++ के साथ प्रस्तुति टिप्पणियों को प्रबंधित करने के तरीके को समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय कराता है और स्लाइड में टिप्पणी जोड़ने, मौजूदा टिप्पणियों तक पहुंचने, उत्तरों और आधुनिक टिप्पणियों के साथ काम करने, तथा प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे कि टिप्पणियों को लेखकों को असाइन करना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, और चयनित टिप्पणियाँ या सभी टिप्पणियाँ हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा दिखाई देती है।

प्रस्तुति खोलते समय टिप्पणियों को दिखाने या छिपाने के लिए, बिना टिप्पणी को बदले, देखें **[प्रेजेंटेशन खोलते समय टिप्पणी दिखाएँ या छुपाएँ](/slides/hi/cpp/presentation-view-properties/)**।

## **प्रेजेंटेशन में टिप्पणियाँ क्यों जोड़ें?**

आप समीक्षण के दौरान प्रतिक्रिया देने और सहयोगियों के साथ मिलकर काम करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for C++ टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **स्लाइड टिप्पणी जोड़ें**

उदाहरण दो स्लाइड बनाता है और [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) के साथ एक टिप्पणी लेखक को पंजीकृत करता है। यह प्रत्येक स्लाइड पर एक टिप्पणी रखने के लिए [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) का उपयोग करता है, फिर उस लेखक के लिए पहली स्लाइड की टिप्पणियाँ [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) से प्राप्त करता है। कंसोल पहली टिप्पणी का पाठ दो बार प्रदर्शित करता है, जिससे स्लाइड और लेखक दोनों के माध्यम से पहुंच दिखती है, और सहेजे गए प्रेजेंटेशन में दोनों टिप्पणियाँ शामिल होती हैं।

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **टिप्पणी लेखक खोजें या बनाएं**

जब एक स्वचालित समीक्षा एक ही प्रेजेंटेशन को बार‑बार प्रोसेस करती है, तब लेखक जोड़ने से पहले [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) द्वारा लौटाए गए संग्रह को खोजें। [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) नाम और आद्याक्षर दोनों को मिलाता है और मिलते‑जुलते लेखकों का एक array लौटाता है, या कोई मिलान न मिलने पर खाली array। इसके विपरीत, [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) केवल नाम से खोजता है, चाहे आद्याक्षर हों या न हों। संग्रह में पहले से मौजूद नाम और आद्याक्षर के साथ [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) को कॉल करने से अपवाद उत्पन्न होता है।

उदाहरण को कम से कम एक स्लाइड वाली प्रेजेंटेशन फ़ाइल की आवश्यकता होती है। दो पासों में, यह पहले मिलते‑जुलते लेखक को पुनः उपयोग करता है, या परिणाम खाली होने पर नया बनाता है। यदि कई मिलान होते हैं, तो यह पहले array तत्व को चुनता है और अन्य लेखकों को नहीं मिलाता या हटाता। फिर चयनित लेखक के लिए [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) को कॉल करता है और प्रेजेंटेशन को सहेजता है। दूसरा पास पहले पास के आउटपुट को खोलता है और वही कार्य दोहराता है।

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

दूसरे पास में एक और टिप्पणी जोड़ी जाती है बिना अतिरिक्त लेखक बनाए या मौजूदा टिप्पणियाँ हटाए। अंतिम फ़ाइल, `review_pass_2.pptx`, दोनों नई टिप्पणियों को मूल टिप्पणियों के साथ रखती है। लेखक को पुनः उपयोग करने से टिप्पणियों की प्रतिलिपि नहीं हटती: समान टिप्पणी को बार‑बार जोड़ने से बचने के लिए, जोड़ने से पहले अलग से डुप्लिकेशन जाँच लागू करें।

## **स्लाइड टिप्पणियों तक पहुंचें**

उदाहरण मौजूदा प्रेजेंटेशन खोलता है और [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) द्वारा लौटाए गए संग्रह को पढ़ता है। प्रत्येक लेखक के लिये, वह [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) द्वारा लौटाए गए संग्रह पर इटरिट करता है और स्लाइड संख्या, टिप्पणी पाठ, लेखक नाम, तथा निर्माण समय प्रिंट करता है। इनपुट प्रेजेंटेशन में टिप्पणी होनी चाहिए ताकि कंसोल आउटपुट उत्पन्न हो।

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **टिप्पणियों का उत्तर दें**

एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदानुक्रम के शीर्ष पर होती है। [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) इंटरफ़ेस की [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) और [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) विधियाँ आपको टिप्पणी का पैरेंट प्राप्त या सेट करने देती हैं।

उदाहरण दो लेखकों से टिप्पणियाँ बनाता है और उत्तर बनाते समय [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) का उपयोग करता है, जिसमें किसी उत्तर का उत्तर भी शामिल है। `nullptr` को [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) में पास करने से सभी लेखकों की टिप्पणियाँ प्राप्त होती हैं; कंसोल प्रत्येक प्रविष्टि को उसकी गहराई के अनुसार इन्डेंट करता है। उदाहरण पूरी चर्चा को सहेजता है, पहले मूल टिप्पणी पर [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) को कॉल करता है, और उस टिप्पणी एवं उसके उत्तरों को हटाकर दूसरी प्रेजेंटेशन सहेजता है।

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* जब [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) इंटरफ़ेस की [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) विधि का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) विधि एक चक्रीय संदर्भ बनाती है, तो एक [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर किसी टेक्स्ट रेंज से जोड़ा जा सकता है। [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) विधि एक [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) तर्क को स्लाइड और टिप्पणी‑मार्कर निर्देशांक के साथ स्वीकार करती है।

जब `nullptr` को आकार तर्क के रूप में पास किया जाता है, तो टिप्पणी स्लाइड‑स्तरीय टिप्पणी बन जाती है। उसका मार्कर प्रदान किए गए निर्देशांक द्वारा निर्धारित होता है, लेकिन यह किसी विशिष्ट आकार से संबद्ध नहीं होता, इसलिए [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` लौटाता है। जब एक [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) प्रदान किया जाता है, तो टिप्पणी उस आकार से जुड़ जाती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी‑मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार संबद्धता को [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार से जोड़ें**

उदाहरण [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) को दो बार कॉल करता है: एक बार `nullptr` आकार के साथ स्लाइड‑स्तरीय टिप्पणी के लिये और एक बार आयताकार को एंकर के रूप में। [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) कॉल स्लाइड‑स्तरीय टिप्पणी के null जाँच के लिये `True` और एंकर किए गए टिप्पणी के लिये `Revenue title` प्रिंट करता है। दोनों टिप्पणी प्रेजेंटेशन के साथ सहेजी जाती हैं।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **विभिन्न आकार प्रकारों से टिप्पणियों को एंकर करें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) को लागू करता है, आकार एंकर के रूप में इस्तेमाल किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), और [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) जैसे चार्ट शामिल हैं।

उदाहरण [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) का उपयोग करके पाँच आकार प्रकारों — एक AutoShape, एक picture frame, एक group, एक connector, और एक chart — से प्रत्येक पर एक टिप्पणी जोड़ता है। चित्र में अंतर्निहित छवि डेटा होता है, इसलिए बाहरी छवि की आवश्यकता नहीं होती। प्रत्येक टिप्पणी का अपना मार्कर स्थान होता है, और सहेजे गए प्रेजेंटेशन में पाँचों आकार संबद्धताएँ संरक्षित रहती हैं।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **टेक्स्ट से टिप्पणी को एंकर करें और उसकी स्थिति सेट करें**

[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) से जुड़ी आधुनिक टिप्पणी के लिये, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) और [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) आकार के टेक्स्ट फ्रेम में चयनित टेक्स्ट की प्रारम्भिक स्थिति को नियंत्रित करते हैं। इसी प्रकार, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) और [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) चयन की लंबाई को नियंत्रित करते हैं। साथ में ये विधियाँ टिप्पणी को AutoShape के भीतर विशिष्ट टेक्स्ट रेंज से जोड़ती हैं।

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) और [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) विधियाँ [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) enumeration के मान को उपयोग करती हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति निर्धारित नहीं।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी हल हो गई है।
- `Closed` — टिप्पणी बंद है।

उदाहरण एक आयत के टेक्स्ट में शब्द “quarterly revenue” को चयनित करके एक आधुनिक टिप्पणी को एंकर करता है। यह चयन की शून्य‑आधारित प्रारम्भिक स्थिति को निकालता है, उसे [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) को देता है, और चयनित अक्षरों की संख्या को [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) को पास करता है। `Resolved` के साथ [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) को कॉल करने के बाद, यह प्रेजेंटेशन को सहेजता और पुनः खोलता है। चार कंसोल जाँच प्रत्येक `True` प्रिंट करनी चाहिए, जिससे आकार एंकर, टेक्स्ट रेंज, तथा स्थिति संरक्षित रहने की पुष्टि होती है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **मौजूदा आधुनिक टिप्पणियों का निरीक्षण करें**

उदाहरण को आधुनिक टिप्पणियों वाली मौजूदा प्रेजेंटेशन की आवश्यकता होती है और यह उनका पाठ, स्थिति, तथा एंकर विवरण प्रिंट करता है। निरीक्षण करने के लिये, देखें कि कौन‑सी टिप्पणियाँ [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) को लागू करती हैं, फिर [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/), तथा [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) को देखें। `nullptr` आकार का अर्थ स्लाइड‑स्तरीय टिप्पणी है। जब एंकर एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) होता है, तो टेक्स्ट‑सेलेक्शन विधियाँ आकार के टेक्स्ट फ्रेम में सम्बद्ध रेंज को पहचानती हैं।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **टिप्पणियाँ हटाएँ**

Aspose.Slides for C++ आपको सभी टिप्पणियों और उनके लेखकों को प्रेजेंटेशन से हटाने या चयनित टिप्पणियों को हटाते हुए बाकी को बरकरार रखने की सुविधा देती है। नीचे दिए गए उदाहरण दोनों विधियों को दर्शाते हैं और अद्यतन प्रेजेंटेशन को सहेजते हैं।

### **सभी टिप्पणियाँ और टिप्पणी लेखक हटाएँ**

उदाहरण मौजूदा प्रेजेंटेशन खोलता है और प्रत्येक लेखक के लिये [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) को कॉल करता है, फिर लेखकों को स्वयं हटाने के लिये [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) को कॉल करता है। सहेजा गया प्रेजेंटेशन न तो टिप्पणी रखता है न ही टिप्पणी लेखक। हटाने को देखने के लिये टिप्पणी‑युक्त प्रेजेंटेशन का उपयोग करें।

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **विशिष्ट टिप्पणियाँ हटाएँ**

उदाहरण एक स्लाइड पर दो टिप्पणियाँ बनाता है और प्रत्येक लेखक की टिप्पणी खोजने के लिये [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) का उपयोग करता है। यह उन टिप्पणियों को इकट्ठा करता है जिनका पाठ “comment 1” के बराबर होता है, फिर [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) को कॉल करता है, चयन के दौरान संग्रह में परिवर्तन से बचते हुए। सहेजा गया प्रेजेंटेशन केवल “comment 2” को रखता है।

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिये हल की गई (resolved) स्थिति समर्थन करता है?**

हाँ। [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) और [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) एक [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) मान का उपयोग करते हैं, जिसमें `Resolved` शामिल है। स्थिति प्रेजेंटेशन में संग्रहीत होती है और फ़ाइल को पुनः खोलने पर पुनः पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) का संदर्भ दे सकती है, जिससे उत्तर श्रृंखलाएँ बनती हैं। API द्वारा कोई विशिष्ट नेस्टिंग‑डिप्थ सीमा निर्धारित नहीं की गई है।

**स्लाइड पर टिप्पणी‑मार्कर की स्थिति किस निर्देशांक प्रणाली में परिभाषित होती है?**

मार्कर स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांकों द्वारा निर्धारित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।