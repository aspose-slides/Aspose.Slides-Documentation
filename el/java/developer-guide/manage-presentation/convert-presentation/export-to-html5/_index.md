---
title: Μετατροπή Παρουσιάσεων σε HTML5 με Java
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
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμόσιμο HTML5 με το Aspose.Slides για Java. Διατήρηση μορφοποίησης, κινούμενων γραφικών και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή HTML5 χωρίς επεκτάσεις ιστού ή πρόσθετες εξαρτήσεις, καθώς και επιλογές για έλεγχο των κινούμενων σχημάτων και των μεταβάσεων διαφάνειας. Το άρθρο δείχνει επίσης τη τυπική διαδικασία εξαγωγής PowerPoint σε HTML, επεξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και δείχνει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5 χωρίς επεκτάσεις ιστού και εξαρτήσεις:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Σε αυτή την περίπτωση, λαμβάνετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να καθορίσετε ρυθμίσεις για τις κινούμενες εικόνες και τις μεταβάσεις διαφάνειας με αυτόν τον τρόπο:

```java
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

Αυτός ο κώδικας Java δείχνει τη τυπική διαδικασία εξαγωγής PowerPoint σε HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Σε αυτή την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με τη μορφή όπως φαίνεται παρακάτω:

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
Όταν χρησιμοποιείτε αυτή τη μέθοδο για εξαγωγή PowerPoint σε HTML, λόγω της απόδοσης SVG, δεν θα μπορείτε να εφαρμόσετε στυλ ή να κουνήσετε συγκεκριμένα στοιχεία. 
{{% /alert %}}

## **Εξαγωγή PowerPoint σε προβολή διαφάνειας HTML5**

**Aspose.Slides** σάς επιτρέπει να μετατρέψετε μια παρουσίαση PowerPoint σε έγγραφο HTML5 στο οποίο οι διαφάνειες παρουσιάζονται σε λειτουργία προβολής διαφάνειας. Σε αυτή την περίπτωση, όταν ανοίγετε το προκύπτον αρχείο HTML5 σε έναν φυλλομετρητή, βλέπετε την παρουσίαση σε λειτουργία προβολής διαφάνειας σε μια ιστοσελίδα. 

Αυτός ο κώδικας Java δείχνει τη διαδικασία εξαγωγής PowerPoint σε προβολή διαφάνειας HTML5:

```java
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

## **Μετατροπή παρουσιάσεων σε έγγραφα HTML5 με σχόλια**

Τα σχόλια στο PowerPoint είναι ένα εργαλείο που επιτρέπει στους χρήστες να αφήνουν σημειώσεις ή σχόλια στις διαφάνειες της παρουσίασης. Είναι ιδιαίτερα χρήσιμα σε συνεργατικά έργα, όπου πολλοί μπορούν να προσθέσουν προτάσεις ή παρατηρήσεις σε συγκεκριμένα στοιχεία της διαφάνειας χωρίς να τροποποιήσουν το κύριο περιεχόμενο. Κάθε σχόλιο εμφανίζει το όνομα του συγγραφέα, καθιστώντας εύκολο τον εντοπισμό του ατόμου που το άφησε.

Ας υποθέσουμε ότι έχουμε την ακόλουθη παρουσίαση PowerPoint αποθηκευμένη στο αρχείο "sample.pptx".

![Δύο σχόλια στη διαφάνεια της παρουσίασης](two_comments_pptx.png)

Όταν μετατρέπετε μια παρουσίαση PowerPoint σε έγγραφο HTML5, μπορείτε εύκολα να καθορίσετε εάν θα συμπεριληφθούν τα σχόλια της παρουσίασης στο τελικό έγγραφο. Για να το κάνετε αυτό, πρέπει να ορίσετε τις παραμέτρους εμφάνισης των σχολίων στη μέθοδο `getNotesCommentsLayouting` της κλάσης [Html5Options](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/) .

Το παρακάτω παράδειγμα κώδικα μετατρέπει μια παρουσίαση σε έγγραφο HTML5 με τα σχόλια να εμφανίζονται στα δεξιά των διαφανειών.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Το έγγραφο "output.html" εμφανίζεται στην παρακάτω εικόνα.

![Τα σχόλια στο παραγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω εάν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφάνειας θα εκτελεστούν σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή την απενεργοποίηση των [shape animations](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και των [slide transitions](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Υπάρχει υποστήριξη για την έξοδο των σχολίων, και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, τα σχόλια μπορούν να προστεθούν σε HTML5 και να τοποθετηθούν (για παράδειγμα, στα δεξιά της διαφάνειας) μέσω των [layout settings](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει ένα [setting](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) που σας επιτρέπει να παραλείψετε υπερσυνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στην τήρηση αυστηρών πολιτικών ασφαλείας.