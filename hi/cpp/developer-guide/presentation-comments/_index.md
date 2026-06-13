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
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति टिप्पणियों को मास्टर करें: PowerPoint फाइलों में टिप्पणियां जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुतिकरण टिप्पणियों को प्रबंधित करने के तरीके को समझाता है। यह मुख्य टिप्पणी-संबंधी प्रकारों को दिखाता है और स्लाइड्स में टिप्पणियां जोड़ना, मौजूदा टिप्पणियों तक पहुंचना, उत्तरों के साथ काम करना, आधुनिक टिप्पणियों का उपयोग करना, और प्रस्तुति से टिप्पणियों को हटाना प्रदर्शित करता है।

उदाहरण सामान्य समीक्षात्मक और सहयोगी परिदृश्यों पर केंद्रित हैं, जैसे कि PowerPoint में टिप्पणियों को लेखकों को असाइन करना, टिप्पणी की सामग्री और मेटाडाटा पढ़ना, उत्तर श्रंखलाएं बनाना, और सभी टिप्पणियों को साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, एक टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब किसी टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रदर्शित होते हैं।

## **प्रस्तुति में टिप्पणियां क्यों जोड़ें?**

जब आप प्रस्तुतियों की समीक्षा करते हैं, तो आप प्रतिक्रिया देने या अपने सहयोगियों के साथ संवाद करने के लिए टिप्पणियों का उपयोग करना चाह सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणियों का उपयोग करने के लिए, Aspose.Slides for C++ प्रदान करता है

* The [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास, जो लेखकों के संग्रह को रखती है ([get_CommentAuthors()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) मेथड से)। लेखक स्लाइड्स में टिप्पणियां जोड़ते हैं। 
* The [ICommentCollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_comment_collection) इंटरफ़ेस, जो व्यक्तिगत लेखकों के लिए टिप्पणियों का संग्रह रखता है। 
* The [IComment](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_comment) क्लास, जो लेखकों और उनकी टिप्पणियों की जानकारी रखती है: किसने टिप्पणी जोड़ी, टिप्पणी कब जोड़ी गई, टिप्पणी की स्थिति आदि। 
* The [CommentAuthor](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.comment_author) क्लास, जो व्यक्तिगत लेखकों की जानकारी रखती है: लेखक का नाम, उनके आद्याक्षर, लेखक नाम से जुड़ी टिप्पणियां आदि। 

## **स्लाइड टिप्पणी जोड़ें**
यह C++ कोड आपको बताता है कि PowerPoint प्रस्तुति में एक स्लाइड पर टिप्पणी कैसे जोड़ें:

```cpp
// Presentation क्लास का इंस्टेंस बनाएँ
auto presentation = System::MakeObject<Presentation>();
// एक खाली स्लाइड जोड़ता है
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// एक लेखक जोड़ता है
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// टिप्पणियों के लिए स्थिति सेट करता है
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// ISlide 1 तक पहुँचता है
auto slide1 = presentation->get_Slides()->idx_get(0);
// ISlide 2 तक पहुँचता है
auto slide2 = presentation->get_Slides()->idx_get(1);

// स्लाइड 1 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// स्लाइड 2 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// जब तर्क के रूप में null पास किया जाता है, सभी लेखकों की टिप्पणियां चयनित स्लाइड पर लाई जाती हैं
auto comments = slide1->GetSlideComments(author);

// स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुँचता है
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // इंडेक्स 0 पर लेखक की टिप्पणी संग्रह को चुनता है
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **स्लाइड टिप्पणियों तक पहुंचें**
यह C++ कोड आपको बताता है कि PowerPoint प्रस्तुति में एक स्लाइड पर मौजूदा टिप्पणी तक कैसे पहुंचें:

```cpp
// Presentation क्लास का इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **टिप्पणियों का उत्तर दें**
एक पैरेंट टिप्पणी वह शीर्ष या मूल टिप्पणी है जो टिप्पणी या उत्तरों की पदानुक्रम में होती है। [ParentComment] प्रॉपर्टी ([IComment] इंटरफ़ेस से) का उपयोग करके आप पैरेंट टिप्पणी सेट या प्राप्त कर सकते हैं।

यह C++ कोड आपको दिखाता है कि टिप्पणियां कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```cpp
auto pres = System::MakeObject<Presentation>();

// ISlide 1 तक पहुँचता है
auto slide1 = pres->get_Slides()->idx_get(0);

// एक टिप्पणी जोड़ता है
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// comment1 के लिए उत्तर जोड़ता है
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// comment1 के लिए एक और उत्तर जोड़ता है
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// मौजूदा उत्तर के लिए एक उत्तर जोड़ता है
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// कंसोल पर टिप्पणियों की पदानुक्रम दिखाता है
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// comment1 और उसके सभी उत्तरों को हटाता है
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="ध्यान दें" %}} 

* जब [Remove] मेथड ([IComment] इंटरफ़ेस से) का उपयोग करके टिप्पणी हटाई जाती है, तो टिप्पणी के उत्तर भी हटाए जाते हैं। 
* यदि [ParentComment] सेटिंग से सर्कुलर रेफ़रेंस बनता है, तो [PptxEditException] फेंका जाएगा।

{{% /alert %}}

## **आधुनिक टिप्पणी जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियां* पेश कीं। आधुनिक टिप्पणी सुविधा PowerPoint में सहयोग को काफी बेहतर बनाती है। आधुनिक टिप्पणियों के माध्यम से, PowerPoint उपयोगकर्ताओं को टिप्पणियों को हल करने, टिप्पणी को वस्तुओं और पाठों से जोड़ने, और पहले की तुलना में बहुत आसान इंटरैक्शन करने की सुविधा मिलती है। 

[Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/hi/cpp/aspose-slides-for-cpp-21-11-release-notes/) में, हमने [ModernComment] क्लास जोड़कर आधुनिक टिप्पणियों के समर्थन को लागू किया। [AddModernComment] और [InsertModernComment] मेथड्स को [CommentCollection] क्लास में जोड़ा गया।

यह C++ कोड आपको बताता है कि PowerPoint प्रस्तुति में एक स्लाइड पर आधुनिक टिप्पणी कैसे जोड़ें: 

```cpp
auto pres = System::MakeObject<Presentation>();
// ISlide 1 तक पहुँचता है
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **टिप्पणी हटाएँ**

### **सभी टिप्पणियां और लेखक हटाएँ**

यह C++ कोड आपको बताता है कि प्रस्तुति में सभी टिप्पणियां और लेखक कैसे हटाएँ:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// प्रस्तुति से सभी टिप्पणियां हटाता है
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// सभी लेखकों को हटाता है
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **विशिष्ट टिप्पणियां हटाएँ**

यह C++ कोड आपको बताता है कि स्लाइड पर विशिष्ट टिप्पणियां कैसे हटाएँ:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// टिप्पणियां जोड़ें...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// उन सभी टिप्पणियों को हटाएँ जो "comment 1" टेक्स्ट रखती हैं
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'सुलझा हुआ' जैसी स्थिति का समर्थन करता है?**

हाँ। [Modern comments] में एक [get_Status] और [set_Status] मेथड उपलब्ध है; आप टिप्पणी की स्थिति पढ़ सकते हैं और सेट कर सकते हैं (उदाहरण के लिए, इसे सुलझा हुआ चिह्नित करें), और यह स्थिति फाइल में सहेजी जाती है और PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएं) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment] को संदर्भित कर सकती है, जिससे मनमानी उत्तर श्रृंखलाएं बनती हैं। API में कोई विशेष नेस्टिंग गहराई सीमा घोषित नहीं की गई है।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कोऑर्डिनेट सिस्टम में परिभाषित होती है?**

स्थिति स्लाइड के कोऑर्डिनेट सिस्टम में एक फ्लोटिंग-पॉइंट पॉइंट के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को सटीक रूप से जहाँ चाहिए वहाँ रखने की अनुमति देता है।