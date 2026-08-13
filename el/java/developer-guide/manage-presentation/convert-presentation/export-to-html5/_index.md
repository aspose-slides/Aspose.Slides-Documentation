---
title: Μετατροπή Παρουσιάσεων σε HTML5 σε Java
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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή HTML5 χωρίς επεκτάσεις ιστού ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των κινήσεων σχήματος και των μεταβάσεων διαφανειών. Το άρθρο επίσης δείχνει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και επιδεικνύει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο διαμορφώνοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας Java δείχνει πώς να εξαγάγετε μια παρουσίαση σε HTML5 χωρίς επεκτάσεις ιστού και εξαρτήσεις:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Σε αυτήν την περίπτωση, θα λάβετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να καθορίσετε ρυθμίσεις για κινήσεις σχήματος και μεταβάσεις διαφανειών με τον ακόλουθο τρόπο:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτός ο κώδικας Java επιδεικνύει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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
Όταν χρησιμοποιείτε αυτήν τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να κινήσετε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε Προβολή Διαφανειών HTML5**

**Aspose.Slides** σας επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε έγγραφο HTML5 στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτήν την περίπτωση, όταν ανοίγετε το παραγόμενο αρχείο HTML5 σε ένα πρόγραμμα περιήγησης, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα. 

Αυτός ο κώδικας Java επιδεικνύει τη διαδικασία εξαγωγής PowerPoint σε Προβολή Διαφανειών HTML5:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή Παρουσιάσεων σε Έγγραφα HTML5 με Σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή ανατροφοδότηση στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί άνθρωποι μπορούν να προσθέσουν τις προτάσεις ή παρατηρήσεις τους σε συγκεκριμένα στοιχεία διαφάνειας χωρίς να αλλάξουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, διευκολύνοντας την παρακολούθηση του ποιος έκανε την παρατήρηση.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο «sample.pptx».

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να ορίσετε αν θα συμπεριληφθούν τα σχόλια της παρουσίασης στο παραγόμενο έγγραφο. Για να το κάνετε αυτό, περάστε τις παραμέτρους εμφάνισης σχολίων στη μέθοδο `setSlidesLayoutOptions` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/).

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με σχόλια που εμφανίζονται δεξιά από τις διαφάνειες.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Το έγγραφο «output.html» εμφανίζεται στην παρακάτω εικόνα.

![Τα σχόλια στο εξαγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές Ερωτήσεις**

### Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα εκτελεστούν σε HTML5;

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για ενεργοποίηση ή απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και των [slide transitions](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Υποστηρίζεται η εξαγωγή σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (για παράδειγμα, δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για σημειώσεις και σχόλια.

### Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;

Ναι, υπάρχει μια [setting](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) που επιτρέπει την παράλειψη υπερσυνδέσμων με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στη συμμόρφωση με αυστηρές πολιτικές ασφαλείας.