---
title: C++ में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियां
type: docs
weight: 100
url: /hi/cpp/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियां
- प्रस्तुति टिप्पणियां
- स्लाइड टिप्पणियां
- टिप्पणी जोड़ें
- टिप्पणी पढ़ें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएं
- टिप्पणी मिटाएं
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियों को तेजी से और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides for C++ के साथ प्रस्तुति टिप्पणी प्रबंधन को समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियां जोड़ने, मौजूदा टिप्पणियों तक पहुंचने, उत्तरों और आधुनिक टिप्पणियों के साथ काम करने, तथा प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण सामान्य रिव्यू और सहयोग परिदृश्यों को कवर करते हैं जैसे कि टिप्पणी को लेखक से असाइन करना, टिप्पणी टेक्स्ट और मेटाडाटा पढ़ना, जवाब श्रृंखलाएं बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियां स्लाइड पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका टेक्स्ट और संबंधित चर्चा प्रदर्शित होती है।

## **प्रस्तुति में टिप्पणियां क्यों जोड़ें?**

आप प्रस्तुति की समीक्षा करते समय फ़ीडबैक देने और सहयोगियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for C++ टिप्पणी के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **स्लाइड टिप्पणियां जोड़ें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स में टिप्पणियां कैसे जोड़ी जाएँ:

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

## **स्लाइड टिप्पणियों तक पहुंचें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक कैसे पहुंचा जाए:

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

एक पैरेंट टिप्पणी उत्तर पदानुक्रम के शीर्ष पर मूल टिप्पणी होती है। [IComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/) इंटरफ़ेस की [get_ParentComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/get_parentcomment/) और [set_ParentComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/set_parentcomment/) मेथड आपको टिप्पणी का पैरेंट प्राप्त या सेट करने की अनुमति देती हैं।

निम्नलिखित उदाहरण दर्शाता है कि उत्तर कैसे जोड़े जाएँ और परिणामी टिप्पणी पदानुक्रम की जाँच कैसे की जाए:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
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

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* जब टिप्पणी को हटाने के लिए [IComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/) इंटरफ़ेस की [Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/remove/) मेथड का उपयोग किया जाता है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [set_ParentComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/set_parentcomment/) मेथड एक सर्कुलर रेफ़रेंस बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियां जोड़ें**

आधुनिक टिप्पणियां स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर टेक्स्ट रेंज से जुड़ी हो सकती हैं। [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icommentcollection/addmoderncomment/) मेथड स्लाइड और टिप्पणी‑मार्कर कोऑर्डिनेट्स के अतिरिक्त एक [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) आर्गुमेंट स्वीकार करती है।

जब `nullptr` आकार आर्गुमेंट के रूप में पास किया जाता है, तो टिप्पणी एक स्लाइड‑लेवल टिप्पणी होती है। उसका मार्कर प्रदान किए गए कोऑर्डिनेट्स द्वारा स्थित होता है, लेकिन यह किसी विशिष्ट आकार से जुड़ा नहीं होता, इसलिए [IModernComment::get_Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` लौटाता है। जब कोई [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) दिया जाता है, तो टिप्पणी उस आकार से एंकर हो जाती है। कोऑर्डिनेट्स फिर भी स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार संबंध को [IModernComment::get_Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_shape/) के माध्यम से पुनः प्राप्त किया जा सकता है।

### **एक आधुनिक टिप्पणी को आकार पर एंकर करें**

निम्नलिखित उदाहरण दोनों एक स्लाइड‑लेवल आधुनिक टिप्पणी और एक विशिष्ट AutoShape पर एंकर की गई आधुनिक टिप्पणी बनाता है। फिर यह प्रत्येक टिप्पणी से संबंधित आकार को पढ़ता है।

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

### **विभिन्न आकार प्रकारों पर टिप्पणियों को एंकर करें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) को लागू करता है, आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iconnector/), और [IGraphicalObject](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igraphicalobject/) जैसी वस्तुएँ शामिल हैं।

निम्नलिखित उदाहरण कई सामान्य आकार प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी जोड़ता है।

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

### **टिप्पणी को टेक्स्ट पर एंकर करें और उसकी स्थिति सेट करें**

एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_textselectionstart/) और [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/set_textselectionstart/) आकार के टेक्स्ट फ्रेम में चयनित टेक्स्ट की प्रारंभिक स्थिति को नियंत्रित करते हैं। इसी तरह, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_textselectionlength/) और [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/set_textselectionlength/) चयन की लंबाई को नियंत्रित करते हैं। साथ में, ये मेथड AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से टिप्पणी को जोड़ते हैं।

[IModernComment::get_Status](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_status/) और [IModernComment::set_Status](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/set_status/) मेथड [ModernCommentStatus](https://reference.aspose.com/slides/hi/cpp/aspose.slides/moderncommentstatus/) एन्ह्यूमरेशन के मान का उपयोग करते हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी का निराकरण किया गया है।
- `Closed` — टिप्पणी बंद है।

निम्नलिखित उदाहरण एक आकार‑एंकर वाली आधुनिक टिप्पणी बनाता है, उसे एक टेक्स्ट चयन से जोड़ता है, उसे निराकरण के रूप में चिह्नित करता है, प्रस्तुति को सहेजता है, और फ़ाइल को फिर से खोलने के बाद मानों की जाँच करता है।

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

### **मौजूदा आधुनिक टिप्पणियों की जाँच करें**

किसी मौजूदा प्रस्तुति की जाँच करने के लिए, देखें कि कौन सी टिप्पणियां [IModernComment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/) को लागू करती हैं, फिर [IModernComment::get_Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_textselectionlength/), और [IModernComment::get_Status](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_status/) की जाँच करें। `nullptr` आकार एक स्लाइड‑लेवल टिप्पणी दर्शाता है। एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) एंकर के लिए, टेक्स्ट‑सेलेक्शन मेथड आकार के टेक्स्ट फ्रेम में संबंधित रेंज को पहचानते हैं।

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

## **टिप्पणियां हटाएं**

### **सभी टिप्पणियां और टिप्पणी लेखकों को हटाएं**

निम्नलिखित उदाहरण दिखाता है कि प्रस्तुति से सभी टिप्पणियां और टिप्पणी लेखक कैसे हटाए जाएँ:

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

### **विशिष्ट टिप्पणियां हटाएं**

निम्नलिखित उदाहरण दिखाता है कि स्लाइड से विशिष्ट टिप्पणियां कैसे हटाई जाएँ:

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

## **FAQ**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए निराकरण स्थिति का समर्थन करता है?**

हाँ। [IModernComment::get_Status](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/get_status/) और [IModernComment::set_Status](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imoderncomment/set_status/) एक [ModernCommentStatus](https://reference.aspose.com/slides/hi/cpp/aspose.slides/moderncommentstatus/) मान का उपयोग करते हैं, जिसमें `Resolved` भी शामिल है। यह स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को फिर से खोलने के बाद पुनः पढ़ी जा सकती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएं) समर्थित हैं, और क्या किसी नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icomment/set_parentcomment/) को रेफ़र कर सकती है, जिससे उत्तर श्रृंखलाएं बनती हैं। API विशेष नेस्टिंग‑डैप्थ सीमा निर्धारित नहीं करती।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कोऑर्डिनेट सिस्टम में परिभाषित होती है?**

मार्कर स्थिति स्लाइड कोऑर्डिनेट सिस्टम में फ्लोटिंग‑पॉइंट कोऑर्डिनेट्स द्वारा परिभाषित की जाती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।