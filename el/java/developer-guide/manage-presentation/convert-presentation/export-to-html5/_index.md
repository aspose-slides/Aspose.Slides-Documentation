---
title: Μετατροπή παρουσιάσεων σε HTML5 σε Java
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμόσιμο HTML5 με Aspose.Slides για Java. Διατήρηση μορφοποίησης, κινούμενων εικόνων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides for Java. Καλύπτει τη βασική εξαγωγή, τον έλεγχο των κινούμενων σχημάτων και των μεταβάσεων διαφανειών, καθώς και τη διάταξη σχολίων. Επιπλέον, συγκρίνει την έξοδο HTML5 με την έξοδο βασισμένη σε SVG της τυπικής εξαγωγής HTML.

## **Εξαγωγή PowerPoint σε HTML5**

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση από τον τρέχοντα φάκελο και την αποθηκεύει σε μορφή HTML5. Χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής· το επόμενο παράδειγμα δείχνει πώς να ελέγξετε ρητά την αναπαραγωγή των κινούμενων σχεδίων. Αντικαταστήστε τη διαδρομή εισόδου με τη διαδρομή της παρουσίασής σας.

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
Εκτός από το έγγραφο HTML, η εξαγωγή δημιουργεί υποστηρικτικά αρχεία CSS και JavaScript για το στυλ των διαφανειών, τις κινούμενες εικόνες, τα εφέ και την πλοήγηση. Διατηρήστε αυτά τα αρχεία μαζί με το έγγραφο HTML όταν μετακινείτε ή δημοσιεύετε την έξοδο. Η παραγόμενη σελίδα φορτώνει επίσης jQuery και Anime.js από δημόσια CDN· χωρίς αυτά, η πλοήγηση και οι κινούμενες εικόνες των διαφανών δεν λειτουργούν.
{{% /alert %}}

Για εξαγωγή χωρίς την αναπαραγωγή κινούμενων σχημάτων ή μεταβάσεων διαφανειών, περάστε `false` στην [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και την [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) στο [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Αυτές οι ρυθμίσεις είναι ανεξάρτητες, οπότε μπορείτε να ενεργοποιήσετε τη μία ενώ απενεργοποιείτε την άλλη. Το παράδειγμα εξάγει την παρουσίαση με και τις δύο μορφές κινούμενων εικόνων απενεργοποιημένες στην παραγόμενη σελίδα.

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

Η τυπική εξαγωγή HTML χρησιμοποιεί διαφορετική προσέγγιση απόδοσης: το περιεχόμενο των διαφανειών αναπαρίσταται με SVG μέσα σε μια σελίδα HTML. Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση σε έγγραφο HTML χρησιμοποιώντας αυτήν την προσέγγιση απόδοσης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Η απλοποιημένη σήμανση παρακάτω απεικονίζει τη δομή της παραγόμενης σελίδας. Το στοιχείο SVG περιέχει το αποδομένο περιεχόμενο της διαφάνειας· το κείμενο κράτησης θέσης αντιπροσωπεύει αυτό το περιεχόμενο και δεν αποτελεί κυριολεξία εξαγόμενο αποτέλεσμα.

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
Η εξαγωγή με βάση το SVG δεν εκθέτει τα σχήματα PowerPoint ως ξεχωριστά στοιχεία HTML. Χρησιμοποιήστε την εξαγωγή HTML5 όταν χρειάζεστε τις επιλογές κίνησης σχημάτων και μεταβάσεων διαφανειών που παρουσιάζονται σε αυτό το άρθρο.
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφανειών HTML5**

Η εξαγωγή HTML5 δημιουργεί μια σελίδα για προβολή και πλοήγηση των διαφανειών της παρουσίασης σε πρόγραμμα περιήγησης. Αυτό το παράδειγμα ενεργοποιεί τόσο την [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) όσο και την [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) ώστε η εξαγόμενη προβολή διαφανειών να μπορεί να αναπαράγει τα εφέ από την πηγαία παρουσίαση.

Χρησιμοποιήστε μια παρουσίαση που ήδη περιέχει κινούμενα σχήματα και μεταβάσεις διαφανειών για να δείτε το αποτέλεσμα αυτών των ρυθμίσεων. Η ενεργοποίησή τους δεν προσθέτει νέα εφέ σε διαφάνειες που δεν τα έχουν. Μετά την εξαγωγή, ανοίξτε το παραγόμενο έγγραφο HTML5 σε πρόγραμμα περιήγησης με τα υποστηρικτικά αρχεία διαθέσιμα.

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

Μπορείτε να συμπεριλάβετε υπάρχοντα σχόλια διαφανειών στην έξοδο HTML5 ώστε οι αναγνώστες να βλέπουν τα σχόλια παράλληλα με το περιεχόμενο της διαφάνειας. Το παράδειγμα σε αυτήν την ενότητα υποθέτει ότι η πηγαία παρουσίαση περιέχει σχόλια, όπως φαίνεται παρακάτω. Εξάγει αυτά τα σχόλια· δεν δημιουργεί νέα.

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Περιμένετε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) στο μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) της [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Χρησιμοποιήστε το [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) για να επιλέξετε `Right` από την απαρίθμηση [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) ώστε να τοποθετήσετε τα σχόλια δεξιά της κάθε διαφάνειας.

Το παρακάτω παράδειγμα εξάγει την παρουσίαση σε HTML5 με αυτή τη διάταξη σχολίων. Μια παρουσίαση χωρίς σχόλια δεν θα έχει κείμενο σχολίου προς εμφάνιση.

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

Η εικόνα παρακάτω δείχνει το εξαγόμενο έγγραφο HTML5 με τα σχόλια εμφανιζόμενα δίπλα στη διαφάνεια.

![Τα σχόλια στο εξαγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Εξαίρεση υπερσυνδέσμων JavaScript κατά την εξαγωγή**

Υποθέστε ότι το `hyperlinks.pptx` περιέχει κείμενο με συνδεμένο `javascript:alert('Hello')` προορισμό και έναν συνηθισμένο σύνδεσμο `https://example.com/`. Για να εξαιρέσετε τον υπερσύνδεσμο JavaScript κατά την εξαγωγή, περάστε `true` στην [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Η προεπιλογή είναι `false`, οπότε αυτοί οι σύνδεσμοι δεν φιλτράρονται εκτός εάν ενεργοποιήσετε την επιλογή.

Το παρακάτω παράδειγμα φορτώνει την παρουσίαση από τον τρέχοντα φάκελο και την εξάγει χρησιμοποιώντας το [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

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

Το εξαγόμενο αρχείο παραλείπει τον υπερσύνδεσμο JavaScript διατηρώντας το κείμενό του και τον συνηθισμένο σύνδεσμο HTTPS. Η πηγαία παρουσίαση παραμένει αμετάβλητη.

Αυτή η επιλογή φιλτράρει τους υπερσυνδέσμους JavaScript· δεν αφαιρεί όλα τα σενάρια ή άλλο ενεργό περιεχόμενο, ούτε εγγυάται τη συμμόρφωση με CSP. Για παράδειγμα, η έξοδος HTML5 εξακολουθεί να περιλαμβάνει σενάρια για την πλοήγηση και τις κινούμενες εικόνες των διαφανών.

## **ΣΥΧΝΆ ΡΩΤΗΜΑΤΑ**

**Μπορώ να ελέγξω εάν οι κινούμενες εικόνες αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαράγονται σε HTML5;**  
Ναι, η εξαγωγή HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και των [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Υπάρχουν στήριξη για σχόλια και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**  
Ναι, τα υπάρχοντα σχόλια μπορούν να συμπεριληφθούν στην έξοδο HTML5 και να τοποθετηθούν (π.χ. δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που εκτελούν JavaScript για λόγους ασφαλείας ή CSP;**  
Ναι, η ρύθμιση [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) σας επιτρέπει να παραλείψετε τους υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Η προεπιλογή είναι `false`. Δείτε το [Exclude JavaScript Hyperlinks During Export](/slides/el/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) για ένα παράδειγμα εξαγωγής HTML5 και το πεδίο εφαρμογής του φίλτρου. Αυτή η ρύθμιση δεν αφαιρεί το JavaScript που χρησιμοποιείται από τον προβολέα HTML5 για πλοήγηση και κινούμενες εικόνες.