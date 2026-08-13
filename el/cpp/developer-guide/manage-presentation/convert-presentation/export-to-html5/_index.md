---
title: Μετατροπή Παρουσιάσεων σε HTML5 με C++
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/cpp/export-to-html5/
keywords:
- PowerPoint σε HTML5
- OpenDocument σε HTML5
- παρουσίαση σε HTML5
- διαφάνεια σε HTML5
- PPT σε HTML5
- PPTX σε HTML5
- ODP σε HTML5
- αποθήκευση PPT ως HTML5
- αποθήκευση PPTX ως HTML5
- αποθήκευση ODP ως HTML5
- εξαγωγή PPT σε HTML5
- εξαγωγή PPTX σε HTML5
- εξαγωγή ODP σε HTML5
- C++
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με το Aspose.Slides για C++. Διατήρηση μορφοποίησης, κινήσεων και αλληλεπιδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει την βασική εξαγωγή HTML5 χωρίς επεκτάσεις ιστού ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των κινήσεων σχημάτων και των μεταβάσεων διαφανειών. Το άρθρο δείχνει επίσης τη τυπική διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας C++ δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
Σε αυτήν την περίπτωση, λαμβάνετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να καθορίσετε ρυθμίσεις για τις κινήσεις σχημάτων και τις μεταβάσεις διαφανειών ως εξής:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτός ο κώδικας C++ δείχνει τη τυπική διαδικασία εξαγωγής PowerPoint σε HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG σε μορφή όπως αυτή:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Σημείωση" color="warning" %}} 
Όταν χρησιμοποιείτε αυτή τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να κάνετε animation σε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφάνειας HTML5**

**Aspose.Slides** επιτρέπει τη μετατροπή μιας παρουσίασης PowerPoint σε έγγραφο HTML5 όπου οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε έναν περιηγητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα.

Αυτός ο κώδικας C++ δείχνει τη διαδικασία εξαγωγής PowerPoint σε προβολή διαφάνειας HTML5:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανατροφοδότηση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία διαφάνειας χωρίς να τροποποιήσουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του δημιουργού, καθιστώντας εύκολο τον εντοπισμό του συγγραφέα.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε εάν θα συμπεριληφθούν τα σχόλια της παρουσίασης στο τελικό έγγραφο. Για να το κάνετε αυτό, πρέπει να ορίσετε τις παραμέτρους εμφάνισης για τα σχόλια στη μέθοδο `get_NotesCommentsLayouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/) .

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με σχόλια που εμφανίζονται δεξιά από τις διαφάνειες.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Το έγγραφο «output.html» εμφανίζεται στην παρακάτω εικόνα.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές ερωτήσεις**

### Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαραχθούν σε HTML5;

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animateshapes/) και των [slide transitions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Υποστηρίζεται η έξοδος των σχολίων, και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (π.χ. δεξιά της διαφάνειας) μέσω των ρυθμίσεων διάταξης για σημειώσεις και σχόλια.

### Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;

Ναι, υπάρχει μια [setting](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) που σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στην τήρηση αυστηρών πολιτικών ασφαλείας.