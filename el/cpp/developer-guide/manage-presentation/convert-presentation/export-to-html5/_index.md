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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμόσιμο HTML5 με το Aspose.Slides για C++. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή σε HTML5 χωρίς επεκτάσεις ιστού ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής από PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαχθέν έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας C++ δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
Σε αυτήν την περίπτωση, λαμβάνετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να θέσετε ρυθμίσεις για τις κινήσεις σχήματος και τις μεταβάσεις διαφάνειας με αυτόν τον τρόπο:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτός ο κώδικας C++ παρουσιάζει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```cpp
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

{{% alert title="Note" color="warning" %}} 
Όταν χρησιμοποιήσετε αυτήν τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να κινηθείτε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε Προβολή Διαφάνειας HTML5**

**Aspose.Slides** σας επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το προκύπτον αρχείο HTML5 σε ένα πρόγραμμα περιήγησης, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα. 

Αυτός ο κώδικας C++ δείχνει τη διαδικασία εξαγωγής PowerPoint σε Προβολή Διαφάνειας HTML5:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανταπόκριση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να τροποποιήσουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, διευκολύνοντας την παρακολούθηση του ποιος άφησε την παρατήρηση.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε αν θα συμπεριλάβετε τα σχόλια από την παρουσίαση στο τελικό έγγραφο. Για να το κάνετε αυτό, πρέπει να ορίσετε τις παραμέτρους εμφάνισης των σχολίων στη μέθοδο `get_NotesCommentsLayouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/) .

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια εμφανιζόμενα στα δεξιά των διαφανειών.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Το έγγραφο "output.html" εμφανίζεται στην εικόνα παρακάτω.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα αναπαράγονται σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [κινήσεων σχήματος](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animateshapes/) και των [μεταβάσεων διαφάνειας](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animatetransitions/) .

**Υποστηρίζεται η εξαγωγή σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (π.χ. στα δεξιά της διαφάνειας) μέσω ρυθμίσεων διάταξης για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει μια [ρύθμιση](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) που επιτρέπει την παράλειψη των υπερσυνδέσμων με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στη συμμόρφωση με αυστηρές πολιτικές ασφαλείας.