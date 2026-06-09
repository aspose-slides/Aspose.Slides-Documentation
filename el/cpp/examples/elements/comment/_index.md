---
title: Σχόλιο
type: docs
weight: 230
url: /el/cpp/examples/elements/comment/
keywords:
- παράδειγμα κώδικα
- σχόλιο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δουλέψτε με τα σχόλια διαφάνειας στο Aspose.Slides for C++: προσθέστε, απαντήστε, επεξεργαστείτε, επιλύστε και εξαγάγετε σχόλια σε παρουσιάσεις PPT, PPTX και ODP με παραδείγματα κώδικα C++."
---
Αυτό το άρθρο δείχνει πώς να προσθέτετε, να διαβάζετε, να αφαιρείτε και να απαντάτε σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη Σύγχρονου Σχολίου**

Δημιουργήστε ένα σχόλιο που έχει συνταχθεί από χρήστη και αποθηκεύστε την παρουσίαση.

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

## **Πρόσβαση σε Σύγχρονο Σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από υπάρχουσα παρουσίαση.

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

## **Κατάργηση Σύγχρονου Σχολίου**

Καταργήστε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

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

## **Απάντηση σε Σύγχρονο Σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό σύγχρονο σχόλιο.

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