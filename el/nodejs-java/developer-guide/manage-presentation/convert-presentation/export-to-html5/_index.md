---
title: Μετατροπή Παρουσιάσεων σε HTML5 με JavaScript
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για Node.js. Διατηρήστε τη μορφοποίηση, τις κινήσεις και τη διαδραστικότητα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινούμενων σχημάτων και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη των σχολίων. Επίσης συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε την αναπαραγωγή των κινήσεων ρητά. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Πέρα από το έγγραφο HTML, η εξαγωγή γράφει υποστηρικτικά αρχεία CSS και JavaScript για το στυλ των διαφανειών, τις κινήσεις, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα επίσης φορτώνει το jQuery και το Anime.js από δημόσια CDN· χωρίς αυτά, η πλοήγηση των διαφανειών και οι κινήσεις δεν λειτουργούν.
{{% /alert %}}

Για να εξάγετε χωρίς την αναπαραγωγή κινήσεων σχήματος ή μεταβάσεων διαφάνειας, περάστε `false` στο [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) και στο [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) του [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, ώστε να μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τις δύο μορφές κίνησης απενεργοποιημένες στη δημιουργημένη σελίδα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο της διαφάνειας αναπαρίσταται από SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτή την προσέγγιση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδομένο περιεχόμενο της διαφάνειας· το κείμενο κράτησης θέσης αντιπροσωπεύει αυτό το περιεχόμενο και δεν είναι κυριολεκτική έξοδος εξαγωγής.

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
Η εξαγωγή με βάση το SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχημάτων και μεταβάσεων διαφάνειας που παρουσιάζονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφανειών HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση στις διαφάνειες της παρουσίασης σε έναν περιηγητή. Αυτό το παράδειγμα ενεργοποιεί τόσο το [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) όσο και το [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) ώστε η εξαγόμενη προβολή διαφανειών να μπορεί να αναπαράγει εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινήσεις σχημάτων και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν έχουν κανένα. Μετά την εξαγωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε έναν περιηγητή με τα υποστηρικτικά αρχεία διαθέσιμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφανειών στο αποτέλεσμα HTML5 ώστε οι αναγνώστες να βλέπουν τα σχόλια παράλληλα με το περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτή την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Περνάτε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) του [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Χρησιμοποιήστε το [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) για να επιλέξετε `Right` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) ώστε να τοποθετήσετε τα σχόλια δεξιά από κάθε διαφάνεια.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτή τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίων προς εμφάνιση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Αποκλεισμός υπερσυνδέσμων JavaScript κατά την εξαγωγή**

Υποθέστε ότι το `hyperlinks.pptx` περιέχει κείμενο με σύνδεσμο `javascript:alert('Hello')` και έναν απλό σύνδεσμο `https://example.com/`. Για να εξαιρέσετε τον υπερσύνδεσμο JavaScript κατά την εξαγωγή, περάστε `true` στη μέθοδο [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Η προεπιλογή είναι `false`, οπότε αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός αν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Το εξαγόμενο αρχείο παραλείπει τον υπερσύνδεσμο JavaScript διατηρώντας το κείμενό του και τον απλό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει τους υπερσυνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για πλοήγηση και κινήσεις των διαφανειών.

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα αναπαράγονται σε HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) και των [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (για παράδειγμα, δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) για παράδειγμα εξαγωγής HTML5 και το πεδίο εφαρμογής του φίλτρου. Αυτή η ρύθμιση δεν καταργεί το JavaScript που χρησιμοποιείται από τον προβολέα HTML5 για πλοήγηση και κινήσεις.