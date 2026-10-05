---
title: Μετατροπή παρουσιάσεων σε HTML5 με C++
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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για C++. Διατήρηση μορφοποίησης, κινήσεων και αλληλεπιδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides for C++. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινούμενων σχεδίων και των μεταβάσεων διαφανειών, καθώς και τη διάταξη σχολίων. Επιπλέον συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε ρητά την αναπαραγωγή των κινούμενων αντικειμένων. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Πέρα από το έγγραφο HTML, η εξαγωγή γράφει υποστηρικτικά αρχεία CSS και JavaScript για στυλ διαφανειών, κινήσεις, εφέ και πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το αρχείο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα φορτώνει επίσης το jQuery και το Anime.js από δημόσια CDN· χωρίς αυτά, η πλοήγηση και οι κινήσεις των διαφανειών δεν λειτουργούν.

{{% /alert %}}

Για να εξάγετε χωρίς την αναπαραγωγή των κινήσεων σχημάτων ή των μεταβάσεων διαφανειών, περάστε `false` στο [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) και στο [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) στο [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, οπότε μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τους δύο τύπους κινήσεων απενεργοποιημένους στη δημιουργημένη σελίδα.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο της διαφάνειας αναπαρίσταται ως SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδομένο περιεχόμενο της διαφάνειας· το κείμενο κράτησης θέσης αντιπροσωπεύει αυτό το περιεχόμενο και δεν αποτελεί κυριολεκτικό αποτέλεσμα εξαγωγής.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}

Η εξαγωγή βασισμένη σε SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας που παρουσιάζονται σε αυτό το άρθρο.

{{% /alert %}}

## **Εξαγ ωγή PowerPoint σε προβολή διαφανειών HTML5**

Η εξαγ ωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση στις διαφάνειες της παρουσίασης σε πρόγραμμα περιήγησης. Το παράδειγμα περνά `true` τόσο στο [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) όσο και στο [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) ώστε η εξαγόμενη προβολή διαφάνειας να μπορεί να αναπαράγει τα εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχημάτων και μεταβάσεις διαφανειών για να δείτε την επίδραση αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν έχουν κανένα. Μετά την εξαγ ωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε πρόγραμμα περιήγησης με τα υποστηρικτικά αρχεία διαθέσιμα.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφάνειας στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν τα σχόλια παράλληλα με το περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια παρουσίασης](two_comments_pptx.png)

Προωθήστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) στη μέθοδο [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) του [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Καλέστε το [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) με `CommentsPositions::Right` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) για να τοποθετήσετε τα σχόλια δεξιά από κάθε διαφάνεια.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτήν τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κανένα κείμενο σχολίου προς εμφάνιση.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Αποκλεισμός υπερσυνδέσμων JavaScript κατά την εξαγωγή**

Υποθέστε ότι το `hyperlinks.pptx` περιέχει κείμενο με σύνδεσμο `javascript:alert('Hello')` και έναν κανονικό σύνδεσμο `https://example.com/`. Για να εξαιρέσετε τον υπερσύνδεσμο JavaScript κατά την εξαγ ωγή, καλέστε το [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) με `true`. Η προεπιλογή είναι `false`, οπότε αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός εάν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Το εξαγόμενο αρχείο παραλείπει τον υπερσύνδεσμο JavaScript ενώ διατηρεί το κείμενό του και τον κανονικό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει τους υπερσυνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για πλοήγηση διαφανειών και κινήσεις.

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαραχθούν στο HTML5;**

Ναι, η εξαγ ωγή HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) και των [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (για παράδειγμα, δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η μέθοδος [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) επιτρέπει την παράλειψη υπερσυνδέσμων με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) για παράδειγμα εξαγ ωγής HTML5 και το εύρος του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιεί ο προβολέας HTML5 για πλοήγηση και κινήσεις.