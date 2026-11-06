---
title: Διαχείριση σχολίων παρουσίασης σε C++
linktitle: Σχόλια παρουσίασης
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
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε σχόλια παρουσίασης με το Aspose.Slides for C++: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης με το Aspose.Slides for C++. Παρουσιάζει τους κύριους τύπους σχετικού με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να προσπελάζετε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του κειμένου και των μεταδεδομένων του σχολίου, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις πάνω στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε η εμφάνιση ή η απόκρυψη των σχολίων κατά το άνοιγμα μιας παρουσίασης χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης](/slides/el/cpp/presentation-view-properties/).

## **Γιατί να Προσθέτετε Σχόλια στις Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Το Aspose.Slides for C++ παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) που παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η διεπαφή [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) που αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Η διεπαφή [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) που παρέχει πληροφορίες για ένα σχόλιο, όπως ο συγγραφέας, η ώρα δημιουργίας, η θέση και το κείμενο.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) που παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συν关联 σχόλια.

## **Προσθήκη Σχολίων Διάφανων**

Το παράδειγμα δημιουργεί δύο διαφάνειες και εγγράφει έναν συγγραφέα σχολίου με τη μέθοδο [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Χρησιμοποιεί το [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για εκείνο τον συγγραφέα με το [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δυο φορές, δείχνοντας την πρόσβαση μέσω της διαφάνειας και του συγγραφέα, ενώ η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

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

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη αξιολόγηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, αναζητήστε στη συλλογή που επιστρέφει η μέθοδος [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) πριν προσθέσετε έναν συγγραφέα. Η μέθοδος [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) ταιριάζει τόσο με το όνομα όσο και με τα αρχικά και επιστρέφει έναν πίνακα με τους αντιστοίχους συγγραφείς, ή έναν κενό πίνακα εάν δεν υπάρχουν αντιστοιχίες. Σε αντίθεση, η μέθοδος [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) αναζητά μόνο με βάση το όνομα, ανεξάρτητα από τα αρχικά. Καλώντας το [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) με όνομα και αρχικά που υπάρχουν ήδη στη συλλογή προκαλεί εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης τουλάχιστον με μία διαφάνεια. Σε κάθε μία από τις δύο διελεύσεις, επαναχρησιμοποιεί τον πρώτο ταιριαστό συγγραφέα ή δημιουργεί έναν νέο μόνο όταν το αποτέλεσμα είναι κενό. Εάν υπάρχουν πολλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς συγχώνευση ή αφαίρεση των άλλων συγγραφέων. Κατόπιν καλεί το [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη διελεύση ανοίγει το αποτέλεσμα της πρώτης διελεύσης και επαναλαμβάνει τη λειτουργία.

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

Η δεύτερη διελεύση προσθέτει ένα ακόμη σχόλιο χωρίς να προσθέτει νέο συγγραφέα ή να αφαιρεί υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα νέα σχόλια μαζί με τυχόν αρχικά σχόλια. Η επαναχρησιμοποίηση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επανειλημμένη προσθήκη του ίδιου σχολίου, υλοποιήστε ξεχωριστό μηχανισμό ανίχνευσης διπλότυπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφανών**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή που επιστρέφει η μέθοδος [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Για κάθε συγγραφέα, διασχίζει τη συλλογή που επιστρέφει η μέθοδος [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) και εκτυπώνει τον αριθμό διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η εισαγόμενη παρουσίαση πρέπει να περιέχει σχόλια ώστε να παραχθεί έξοδος στην κονσόλα.

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

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) και [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) της διεπαφής [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) σας επιτρέπουν να λάβετε ή να ορίσετε το γονικό ενός σχολίου.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί το [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Περάτοντας `nullptr` στη μέθοδο [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εντοπίζει κάθε στοιχείο ανάλογα με το βάθος του στην ιεραρχία απαντήσεων. Το παράδειγμα αποθηκεύει τη συνολική συζήτηση, καλεί το [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) στο πρώτο ριζικό σχόλιο, και αποθηκεύει μια δεύτερη παρουσίαση με το σχόλιο αυτό και τις απαντήσεις του αφαιρεμένα.

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
* Όταν η μέθοδος [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) της διεπαφής [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η μέθοδος [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) δημιουργήσει κυκλική αναφορά, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε AutoShape. Η μέθοδος [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) δέχεται ένα όρισμα τύπου [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) εκτός από τη διαφάνεια και τις συντεταγμένες του δείκτη σχολίου.

Όταν περνιέται `nullptr` για το όρισμα του σχήματος, το σχόλιο είναι ένα σχόλιο επιπέδου διαφάνειας. Ο δείκτης του τοποθετείται με τις παρεχόμενες συντεταγμένες, αλλά δεν συσχετίζεται με κάποιο συγκεκριμένο σχήμα, έτσι η μέθοδος [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) επιστρέφει `nullptr`. Όταν παρέχεται ένα [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να καθορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η συσχέτιση σχήματος μπορεί να ανακτηθεί μέσω του [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Αγκύρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί το [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) δύο φορές: μία με σχήμα `nullptr` για σχόλιο επιπέδου διαφάνειας και μία με ένα ορθογώνιο ως αγκίστρα. Καλώντας το [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) εκτυπώνει `True` για τον έλεγχο null του σχολίου επιπέδου διαφάνειας και `Revenue title` για το αγκιστρωμένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

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

### **Αγκύρωση Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που υλοποιεί το [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) μπορεί να χρησιμοποιηθεί ως αγκίστρωση σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), και περιπτώσεις του [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) όπως γραφήματα.

Το παράδειγμα χρησιμοποιεί το [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) για να συσχετίσει ένα σχόλιο με κάθε έναν από πέντε τύπους σχημάτων: AutoShape, πλαίσιο εικόνας, ομάδα, συνδέσμος και γράφημα. Η εικόνα ενσωματώνεται ως δεδομένα εικόνας, οπότε δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συνδέσεις σχήματος.

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

### **Αγκύρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο που συσχετίζεται με ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), οι μέθοδοι [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) και [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) ελέγχουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Ομοίως, οι μέθοδοι [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) και [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) ελέγχουν το μήκος της επιλογής. Μαζί, αυτές οι μέθοδοι συνδέουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Οι μέθοδοι [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) και [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) χρησιμοποιούν μια τιμή από την απαρίθμηση [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει καθοριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυροποιεί ένα σύγχρονο σχόλιο στις λέξεις «quarterly revenue» στο κείμενο ενός ορθογωνίου. Υπολογίζει τη θέση έναρξης (μηδενική βάση) από το κείμενο, τη περνά στη μέθοδο [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), και καλεί το [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) με τον αριθμό των επιλεγμένων χαρακτήρων. Μετά από κλήση του [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) με `Resolved`, αποθηκεύει και ξανανοιγο τη παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα πρέπει να εμφανίσουν `True`, επιβεβαιώνοντας ότι η αγκίστρωση σχήματος, το εύρος κειμένου και η κατάσταση διατηρήθηκαν.

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

### **Επιθεώρηση Υπάρχοντων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τις λεπτομέρειες αγκίστρωσης. Για να το επιθεωρήσετε, ελέγξτε ποια σχόλια υλοποιούν το [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), έπειτα εξετάστε τις μεθόδους [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/), και [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Ένα σχήμα `nullptr` υποδηλώνει σχόλιο επιπέδου διαφάνειας. Για αγκίστρωση σε [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), οι μέθοδοι επιλογής κειμένου προσδιορίζουν το αντίστοιχο εύρος στο πλαίσιο κειμένου του σχήματος.

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

## **Αφαίρεση Σχολίων**

Το Aspose.Slides for C++ σας επιτρέπει να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς τους από μια παρουσίαση ή να διαγράψετε επιλεγμένα σχόλια διατηρώντας τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί τη μέθοδο [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) για κάθε συγγραφέα, στη συνέχεια καλεί το [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) για να αφαιρέσει τους ίδιους τους συγγραφείς. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να δείτε την αφαίρεση.

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

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί το [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) για να βρει σχόλια ανά συγγραφέα. Συλλέγει τα σχόλια των οποίων το κείμενο ισούται με «comment 1» πριν καλέσει το [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

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

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένου σχολίου για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) και [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) χρησιμοποιούν μια τιμή από το [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να ανακτηθεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται συζητήσεις με αλυσίδες απαντήσεων και υπάρχει όριο βάθους;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους ιεραρχίας.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται με συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε τον δείκτη με ακρίβεια στην διαφάνεια.