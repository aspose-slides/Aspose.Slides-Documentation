---
title: Μετατροπή παρουσιάσεων σε HTML5 με JavaScript
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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για Node.js. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει τη βασική εξαγωγή σε HTML5 χωρίς επεκτάσεις web ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των κινήσεων σχημάτων και των μεταβάσεων διαφανειών. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφανειών και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαχθέν έγγραφο διαμορφώνοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας JavaScript δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5 χωρίς επεκτάσεις web και εξαρτήσεις:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Σε αυτήν την περίπτωση, λαμβάνετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να καθορίσετε ρυθμίσεις για τις κινήσεις σχημάτων και τις μεταβάσεις διαφανειών με τον εξής τρόπο:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτό το JavaScript επιδεικνύει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με τη μορφή:

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
Όταν χρησιμοποιείτε αυτή τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να κινήσετε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε HTML5 με Προβολή Διαφάνειας**

**Aspose.Slides** επιτρέπει τη μετατροπή μιας παρουσίασης PowerPoint σε έγγραφο HTML5 στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε έναν περιηγητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα.

Αυτός ο κώδικας JavaScript επιδεικνύει τη διαδικασία εξαγωγής PowerPoint σε HTML5 με προβολή διαφάνειας:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μετατροπή Παρουσίασης σε Έγγραφο HTML5 με Σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανατροφοδότηση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν τις προτάσεις ή τα σχόλιά τους σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να τροποποιήσουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, διευκολύνοντας την ανίχνευση του ποιος έκανε την παρατήρηση.

Ας υποθέσουμε ότι έχουμε την παρακάτω παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε αν θα συμπεριλάβετε τα σχόλια της παρουσίασης στο έγγραφο εξόδου. Για να το κάνετε αυτό, πρέπει να ορίσετε τις παραμέτρους εμφάνισης για τα σχόλια στην ιδιότητα `notes_comments_layouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/).

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται στα δεξιά των διαφανειών.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Το έγγραφο "output.html" εμφανίζεται στην εικόνα παρακάτω.

![The comments in the output HTML5 document](two_comments_html5.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαράγονται σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [κινήσεων σχημάτων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/setanimateshapes/) και των [μεταβάσεων διαφανειών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Υποστηρίζεται η έξοδος των σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (για παράδειγμα, στα δεξιά της διαφάνειας) μέσω των [ρυθμίσεων διάταξης](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει μια [ρύθμιση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) που επιτρέπει την παράλειψη των υπερσυνδέσμων με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στη συμμόρφωση με αυστηρές πολιτικές ασφαλείας.