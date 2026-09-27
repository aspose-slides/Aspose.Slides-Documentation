---
title: Δημιουργία παρουσιάσεων σε PHP
linktitle: Δημιουργία παρουσίασης
type: docs
weight: 10
url: /el/php-java/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις με το Aspose.Slides για PHP μέσω Java — παράγετε αρχεία PPT, PPTX και ODP και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο. Επίσης δείχνει πώς να δημιουργήσετε και να αποθηκεύσετε μια κενή παρουσίαση, καθώς και πώς να ανοίξετε μια υπάρχουσα παρουσίαση σε υποστηριζόμενη μορφή και να την αποθηκεύσετε σε άλλη μορφή. Μια σύντομη ενότητα Συχνών Ερωτήσεων στο τέλος καλύπτει κοινές ερωτήσεις σχετικά με μορφές, πρότυπα, μέγεθος διαφάνειας, μονάδες, χρήση μνήμης, πολυνηματισμό, άδειες, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, εγκαταστήστε το Aspose.Slides για PHP μέσω Java με τον Composer και εκκινήστε το PHP/Java Bridge στον Apache Tomcat. Δείτε την [Εγκατάσταση](/slides/el/php-java/installation/) για τη πλήρη ρύθμιση. Τα παραδείγματα παρακάτω υποθέτουν ότι ο Tomcat εκτελείται στο `localhost:8080` και ότι ο φάκελος `vendor` του Composer βρίσκεται δίπλα στο script.

## **Δημιουργία παρουσίασης PowerPoint**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) . Μια νέα παρουσίαση περιέχει ήδη μία κενή διαφάνεια.
1. Αποκτήστε αυτή τη διαφάνεια από τη συλλογή που επιστρέφει το [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getslides/), με το δείκτη του, 0.
1. Προσθέστε ένα ορθογώνιο με τη μέθοδο [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addautoshape/) και ορίστε το κείμενό του με το [TextFrame::setText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/settext/).
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX με τη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/save/) .

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/el/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Οι δύο γραμμές `require_once` φορτώνουν τον πελάτη PHP/Java Bridge από τον Tomcat και τις κλάσεις Aspose.Slides από το πακέτο Composer. Η πάνω‑αριστερή γωνία του ορθογωνίου βρίσκεται 50 σημεία από την αριστερή άκρη και 50 σημεία από την πάνω άκρη της διαφάνειας, και το ορθογώνιο έχει πλάτος 400 σημείων και ύψος 100 σημείων. Το αποθηκευμένο αρχείο περιέχει μία διαφάνεια με αυτό το ορθογώνιο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε την [Άδεια](/slides/el/php-java/licensing/) .

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαβάζει και γράφει αρχεία μέσα στον Tomcat, όχι στη διαδικασία PHP σας, έτσι ένα σχετικό μονοπάτι όπως `"hello.pptx"` λύνεται σε σχέση με το φάκελο εργασίας του Tomcat. Τα παραδείγματα σε αυτή τη σελίδα δημιουργούν απόλυτες διαδρομές με `__DIR__`, ώστε τα αρχεία να διαβάζονται και να αποθηκεύονται δίπλα στο script.
{{% /alert %}}

## **Δημιουργία και αποθήκευση παρουσίασης**

Για να δημιουργήσετε μια κενή παρουσίαση και να την αποθηκεύσετε, δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και αποθηκεύστε την σε οποιαδήποτε μορφή της απαρίθμησης [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) . Το αποτέλεσμα είναι μια παρουσίαση με μία κενή διαφάνεια.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/el/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Άνοιγμα και αποθήκευση παρουσίασης**

Για να μετατρέψετε μια παρουσίαση από μορφή σε άλλη, ανοίξτε την περνώντας τη διαδρομή της στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) , στη συνέχεια αποθηκεύστε τη στη στοχευμένη μορφή. Το Aspose.Slides εντοπίζει τη μορφή εισόδου, όπως PPT, PPTX ή ODP, από το ίδιο το αρχείο.

Το παρακάτω παράδειγμα υποθέτει ότι υπάρχει μια παρουσίαση OpenDocument με όνομα *Sample.odp* δίπλα στο script και την αποθηκεύει ως PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/el/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές ερωτήσεις**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/php-java/save-presentation/) , και να εξάγετε σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) , [XPS](/slides/el/php-java/convert-powerpoint-to-xps/) , [HTML](/slides/el/php-java/convert-powerpoint-to-html/) , [SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/) , και [images](/slides/el/php-java/convert-powerpoint-to-png/) , μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε το στην επιθυμητή μορφή· τα POTX/POTM/PPTM και παρόμοιες μορφές [υποστηρίζονται](/slides/el/php-java/supported-file-formats/) .

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας όταν δημιουργώ μια παρουσίαση;

Ορίστε το [μέγεθος διαφάνειας](/slides/el/php-java/slide-size/) (συμπεριλαμβανομένων των προκαθορισμένων όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε σημεία: 1 ίντσα ισούται με 72 μονάδες.

### Πώς διαχειρίζομαι πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) για να μειώσω τη χρήση μνήμης;

Χρησιμοποιήστε τις [στρατηγικές διαχείρισης BLOB](/slides/el/php-java/manage-blob/) , περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρά ροές μνήμης.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε στο ίδιο αντικείμενο [Presentation]... από [πολλαπλά νήματα]... Εκτελέστε ξεχωριστές, απομονωμένες εμφανίσεις ανά νήμα ή διεργασία.

### Πώς αφαιρώ το υδατογράφημα δοκιμής και τους περιορισμούς;

[Εφαρμόστε άδεια](/slides/el/php-java/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμένει αμετάβλητο και η ρύθμιση της άδειας πρέπει να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [Ψηφιακές υπογραφές](/slides/el/php-java/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [δημιουργία/επεξεργασία έργων VBA](/slides/el/php-java/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένες μακροεντολές όπως PPTM/PPSM.