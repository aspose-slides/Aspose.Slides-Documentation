---
title: टिप्पणी
type: docs
weight: 230
url: /hi/cpp/examples/elements/comment/
keywords:
- कोड उदाहरण
- टिप्पणी
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड टिप्पणियों के साथ काम करें: जोड़ें, उत्तर दें, संपादित करें, हल करें, और PPT, PPTX और ODP प्रस्तुतियों में टिप्पणियों को C++ कोड उदाहरणों के साथ निर्यात करें।"
---
यह लेख आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उत्तर देने को **Aspose.Slides for C++** का उपयोग करके प्रदर्शित करता है।

## **आधुनिक टिप्पणी जोड़ें**

उपयोगकर्ता द्वारा लिखी गई एक टिप्पणी बनाएं और प्रस्तुति को सहेजें।

```cpp
static void AddModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    author->get_Comments()->AddModernComment(
        u"This is a modern comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    presentation->Save(u"modern_comment.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **आधुनिक टिप्पणी तक पहुँचें**

एक मौजूदा प्रस्तुति से आधुनिक टिप्पणी पढ़ें।

```cpp
static void AccessModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");

    auto author = presentation->get_CommentAuthor(0);
    auto comment = ExplicitCast<SharedPtr<IModernComment>>(author->get_Comment(0));

    Console::WriteLine(u"Author: {0}, Comment: {1}, Position: {2}",
        author->get_Name(), comment->get_Text(), comment->get_Position());

    presentation->Dispose();
}
```

## **आधुनिक टिप्पणी हटाएँ**

टिप्पणी हटाएँ और अपडेटेड फ़ाइल को सहेजें।

```cpp
static void RemoveModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");
    auto author = presentation->get_CommentAuthor(0);

    auto comment = author->get_Comment(0);
    comment->Remove();

    presentation->Save(u"modern_comment_removed.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **आधुनिक टिप्पणी का उत्तर दें**

पैरेंट आधुनिक टिप्पणी पर उत्तर जोड़ें।

```cpp
static void ReplyToModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    auto parentComment = author->get_Comments()->AddModernComment(
        u"Parent comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    auto reply1 = author->get_Comments()->AddModernComment(
        u"Reply 1", slide, nullptr, PointF(110, 100), DateTime::get_Now());

    auto reply2 = author->get_Comments()->AddModernComment(
        u"Reply 2", slide, nullptr, PointF(120, 100), DateTime::get_Now());

    reply1->set_ParentComment(parentComment);
    reply2->set_ParentComment(parentComment);

    presentation->Save(u"modern_comment_replies.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```