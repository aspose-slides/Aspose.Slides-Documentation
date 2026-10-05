---
title: Μετατροπή Παρουσιασών σε HTML5 σε Android
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με το Aspose.Slides για Android μέσω Java. Διατηρεί τη μορφοποίηση, τις κινήσεις και την διαδραστικότητα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφάνειας, καθώς και τη διάταξη σχολίων. Επίσης, συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα κατάλογο εργασίας και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε την αναπαραγωγή των κινήσεων ρητά. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή προς την παρουσίασή σας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Εκτός από το έγγραφο HTML, η εξαγωγή δημιουργεί υποστηρικτικά αρχεία CSS και JavaScript για το στυλ διαφάνειας, τις κινήσεις, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε το αποτέλεσμα. Η παραγόμενη σελίδα επίσης φορτώνει τα jQuery και Anime.js από δημόσια CDN· χωρίς αυτά, η πλοήγηση διαφάνειας και οι κινήσεις δεν λειτουργούν.
{{% /alert %}}

Για να εξάγετε χωρίς την αναπαραγωγή κινήσεων σχήματος ή μεταβάσεων διαφάνειας, περάστε `false` στο [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) στο [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, έτσι μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με τις δύο μορφές κινήσεων απενεργοποιημένες στη δημιουργούμενη σελίδα.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή PowerPoint σε HTML**

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο διαφάνειας αντιπροσωπεύεται από SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση απόδοσης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδομένο περιεχόμενο διαφάνειας· το κείμενο αντικατάστασης αντιπροσωπεύει εκείνο το περιεχόμενο και δεν είναι κυριολεκτικό αποτέλεσμα εξαγωγής.

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
Η εξαγωγή βασισμένη σε SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχήματος και μετάβασης διαφάνειας που δείχνονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφάνειας HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση στις διαφάνειες της παρουσίασης σε έναν φυλλομετρητή. Αυτό το παράδειγμα ενεργοποιεί τόσο το [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) όσο και το [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) ώστε η εξαγόμενη προβολή διαφάνειας να μπορεί να αναπαράγει τα εφέ από την πηγή της παρουσίασης.

Χρησιμοποιήστε μια παρουσίαση που περιέχει ήδη κινήσεις σχήματος και μεταβάσεις διαφάνειας για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν έχουν. Μετά την εξαγωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε έναν φυλλομετρητή με τα υποστηρικτικά αρχεία διαθέσιμα.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή παρουσίασης σε έγγραφο HTML5 με σχόλια**

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφάνειας στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν την ανατροφοδότηση δίπλα στο περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Περάστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) του [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Χρησιμοποιήστε το [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) για να επιλέξετε `Right` από την αρίθμηση [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) ώστε να τοποθετήσετε τα σχόλια δεξιά από κάθε διαφάνεια.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτήν τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίων για εμφάνιση.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Εξαίρεση συνδέσμων JavaScript κατά την εξαγωγή**

Ας υποθέσουμε ότι το `hyperlinks.pptx` περιέχει κείμενο με σύνδεσμο με στόχο `javascript:alert('Hello')` και έναν απλό σύνδεσμο `https://example.com/`. Για να εξαίρετε τον σύνδεσμο JavaScript κατά την εξαγωγή, περάστε `true` στο [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Η προεπιλογή είναι `false`, έτσι αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός εάν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα κατάλογο εργασίας και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Το εξαγόμενο αρχείο παραλείπει τον σύνδεσμο JavaScript ενώ διατηρεί το κείμενό του και τον απλό σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει τους συνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για πλοήγηση διαφάνειας και κινήσεις.

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα αναπαράγονται στο HTML5;**

Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Υποστηρίζονται τα σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (π.χ., δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, η ρύθμιση [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) σας επιτρέπει να παραλείψετε συνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα παράδειγμα εξαγωγής HTML5 και το πεδίο εφαρμογής του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιείται από τον προβολέα HTML5 για πλοήγηση και κινήσεις.