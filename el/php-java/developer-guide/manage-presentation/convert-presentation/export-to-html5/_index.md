---
title: Μετατροπή Παρουσιών σε HTML5 με PHP
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/php-java/export-to-html5/
keywords:
- PowerPoint σε HTML5
- OpenDocument σε HTML5
- παρουσίαση σε HTML5
- διαφάνεια σε HTML5
- PPT σε HTML5
- PPTX σε HTML5
- ODP σε HTML5
- Αποθήκευση PPT ως HTML5
- Αποθήκευση PPTX ως HTML5
- Αποθήκευση ODP ως HTML5
- Εξαγωγή PPT σε HTML5
- Εξαγωγή PPTX σε HTML5
- Εξαγωγή ODP σε HTML5
- PHP
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για PHP μέσω Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη σχολίων. Επίσης συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε ρητά την αναπαραγωγή των κινήσεων. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Εκτός από το έγγραφο HTML, η εξαγωγή γράφει βοηθητικά αρχεία CSS και JavaScript για το στυλ των διαφανειών, τις κινήσεις, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η δημιουργημένη σελίδα φορτώνει επίσης jQuery και Anime.js από δημόσια CDNs· χωρίς αυτά, η πλοήγηση και οι κινήσεις δεν λειτουργούν.
{{% /alert %}}

Για να εξάγετε χωρίς την εκτέλεση κινήσεων σχήματος ή μεταβάσεων διαφάνειας, περάστε `false` στο [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) και στο [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) στο [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, έτσι μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τους δύο τύπους κίνησης απενεργοποιημένους στη δημιουργημένη σελίδα.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοση : το περιεχόμενο της διαφάνειας αντιπροσωπεύεται από SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση απόδοσης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Η απλουστευμένη σημασιολογία παρακάτω απεικονίζει τη δομή της δημιουργημένης σελίδας. Το στοιχείο SVG περιέχει το αποδιδόμενο περιεχόμενο της διαφάνειας· το κείμενο κράτησης θέσης αντιπροσωπεύει αυτό το περιεχόμενο και δεν είναι κυριολεκτική έξοδος εξαγωγής.

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

## **Εξαγωγή PowerPoint σε Προβολή Διαφάνειας HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση των διαφανειών της παρουσίασης σε πρόγραμμα περιήγησης. Το παράδειγμα ενεργοποιεί και τα [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) και [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) ώστε η εξαγόμενη προβολή διαφάνειας να μπορεί να παίζει εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχήματος και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν τα έχουν. Μετά την εξαγωγή, ανοίξτε το δημιουργημένο έγγραφο HTML5 σε πρόγραμμα περιήγησης με τα υποστηρικτικά αρχεία διαθέσιμα.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Μπορείτε να συμπεριλάβετε τα υπάρχοντα σχόλια διαφανειών στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν ανατροφοδότηση δίπλα στο περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια παρουσίασης](two_comments_pptx.png)

Περάστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) του [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Χρησιμοποιήστε το [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) για να επιλέξετε `Right` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) ώστε να τοποθετήσετε τα σχόλια στα δεξιά κάθε διαφάνειας.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτή τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίου προς εμφάνιση.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Η εικόνα παρακάτω δείχνει το εξαγόμενο έγγραφο HTML5 με τα σχόλια εμφανισμένα δίπλα στη διαφάνεια.

![Τα σχόλια στο εξαγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Εξαίρεση Συνδέσμων JavaScript Κατά την Εξαγωγή**

Έστω ότι το `hyperlinks.pptx` περιέχει κειμενικό σύνδεσμο με προορισμό `javascript:alert('Hello')` και έναν κοινό σύνδεσμο `https://example.com/`. Για να εξαίρετε τον σύνδεσμο JavaScript κατά την εξαγωγή, περάστε `true` στο [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Η προεπιλογή είναι `false`, επομένως αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός αν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Το εξαγόμενο αρχείο παραλείπει τον σύνδεσμο JavaScript ενώ διατηρεί το κείμενό του και τον κοινό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει συνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για την πλοήγηση και τις κινήσεις των διαφανειών.

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα εκτελούνται σε HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) και των [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (π.χ., στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) σάς επιτρέπει να παραλείψετε συνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα παράδειγμα εξαγωγής HTML5 και την εμβέλεια του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιείται από το πρόγραμμα προβολής HTML5 για πλοήγηση και κινήσεις.