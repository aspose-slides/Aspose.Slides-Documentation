---
title: Διαχείριση Σχολίων Παρουσίασης σε C++
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/cpp/presentation-comments/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- σχόλια PowerPoint
- σχόλια παρουσίασης
- σχόλια διαφάνειας
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- επεξεργασία σχολίου
- απάντηση σε σχόλιο
- αφαίρεση σχολίου
- διαγραφή σχολίου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για C++: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσίασης στο Aspose.Slides. Δείχνει τους κύριους τύπους που σχετίζονται με σχόλια και παρουσιάζει πώς να προσθέτετε σχόλια σε διαφάνειες, να αποκτάτε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις, να χρησιμοποιείτε σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα επικεντρώνονται σε κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του περιεχομένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων και η εκκαθάριση όλων των σχολίων ή η διαγραφή των επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωση ή επισημείωση σε μια διαφάνεια. Όταν κάνετε κλικ σε ένα σχόλιο, αποκαλύπτεται το περιεχόμενό του ή τα μηνύματά του.

### **Γιατί να προσθέσετε σχόλια σε παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να δώσετε ανατροφοδότηση ή να επικοινωνήσετε με τους συνεργάτες σας όταν ελέγχετε παρουσιάσεις.

Για να μπορείτε να χρησιμοποιήσετε σχόλια σε παρουσιάσεις PowerPoint, το Aspose.Slides for C++ παρέχει

* Την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) που περιλαμβάνει τις συλλογές συγγραφέων (από τη μέθοδο [get_CommentAuthors()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Οι συγγραφείς προσθέτουν σχόλια σε διαφάνειες. 
* Το interface [ICommentCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment_collection) που περιέχει τη συλλογή σχολίων για μεμονωμένους συγγραφείς. 
* Την κλάση [IComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment) που περιλαμβάνει πληροφορίες για τους συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα προσθήκης, η θέση του σχολίου κ.λπ. 
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.comment_author) που περιλαμβάνει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του συγγραφέα κ.λπ. 

## **Προσθήκη σχολίου σε διαφάνεια**
Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```cpp
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
auto presentation = System::MakeObject<Presentation>();
// Προσθέτει μια κενή διαφάνεια
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Προσθέτει έναν συγγραφέα
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Ορίζει τη θέση για τα σχόλια
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Πρόσβαση στην ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Πρόσβαση στην ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Όταν περνιέται null ως όρισμα, τα σχόλια από όλους τους συγγραφείς φέρνονται στη επιλεγμένη διαφάνεια
auto comments = slide1->GetSlideComments(author);

// Πρόσβαση στο σχόλιο με δείκτη 0 για τη διαφάνεια 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Επιλέγει τη συλλογή σχολίων του συγγραφέα στη θέση 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **Πρόσβαση σε σχόλια διαφάνειας**
Αυτός ο κώδικας C++ δείχνει πώς να αποκτήσετε πρόσβαση σε ένα υπάρχον σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```cpp
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
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

## **Απάντηση σε σχόλια**
Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας την ιδιότητα [ParentComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (από το interface [IComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment)), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο.

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε σχόλια και να λάβετε απαντήσεις σε αυτά:

```cpp
auto pres = System::MakeObject<Presentation>();

// Πρόσβαση στην ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Προσθέτει ένα σχόλιο
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Προσθέτει μια απάντηση στο comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Προσθέτει άλλη απάντηση στο comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Προσθέτει απάντηση σε υπάρχουσα απάντηση
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Εμφανίζει την ιεραρχία των σχολίων στην κονσόλα
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

// Αφαιρεί το comment1 και όλες τις απαντήσεις του
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* Όταν η μέθοδος [Remove](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (από το interface [IComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment)) χρησιμοποιείται για τη διαγραφή ενός σχολίου, διαγράφονται επίσης οι απαντήσεις στο σχόλιο. 
* Εάν η ρύθμιση [ParentComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) δημιουργεί κυκλική αναφορά, θα εξαχθεί η εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Προσθήκη σύγχρονου σχολίου**

Το 2021, η Microsoft εισήγαγε *σύγχρονα σχόλια* στο PowerPoint. Η λειτουργία σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω των σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να συνδέουν σχόλια σε αντικείμενα και κείμενα και να αλληλεπιδρούν πολύ πιο εύκολα από ό,τι πριν. 

Στο [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/el/cpp/aspose-slides-for-cpp-21-11-release-notes/), υλοποιήσαμε υποστήριξη για σύγχρονα σχόλια προσθέτοντας την κλάση [ModernComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.modern_comment). Οι μέθοδοι [AddModernComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) και [InsertModernComment](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) προστέθηκαν στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.comment_collection).

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Πρόσβαση στην ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Κατάργηση σχολίου**

### **Διαγραφή όλων των σχολίων και των συγγραφέων**

Αυτός ο κώδικας C++ δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Διαγράφει όλα τα σχόλια από την παρουσίαση
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Διαγράφει όλους τους συγγραφείς
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Διαγραφή συγκεκριμένων σχολίων**

Αυτός ο κώδικας C++ δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// προσθέτει σχόλια...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// αφαιρεί όλα τα σχόλια που περιέχουν το κείμενο "comment 1"
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

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides μια κατάσταση όπως 'επιλυμένο' για σύγχρονα σχόλια;**

Ναι. Τα [σύγχρονα σχόλια](https://reference.aspose.com/slides/el/cpp/aspose.slides/moderncomment/) εκθέτουν τις μεθόδους [get_Status](https://reference.aspose.com/slides/el/cpp/aspose.slides/moderncomment/get_status/) και [set_Status](https://reference.aspose.com/slides/el/cpp/aspose.slides/moderncomment/set_status/). Μπορείτε να διαβάσετε και να ορίσετε την κατάσταση ενός σχολίου (π.χ., να το σημειώσετε ως επιλυμένο)· αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υποστηρίζονται οι κεντρικές συζητήσεις (αλυσίδες απαντήσεων) και υπάρχει όριο εσωτερικοποίησης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/el/cpp/aspose.slides/comment/set_parentcomment/), επιτρέποντας αυθαίρετες αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εσωτερικοποίησης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο τύπου floating‑point στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε τον δείκτη σχολίου ακριβώς όπου χρειάζεται.