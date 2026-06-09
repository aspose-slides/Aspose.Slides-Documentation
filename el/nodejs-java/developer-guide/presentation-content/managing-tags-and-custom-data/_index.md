---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/nodejs-java/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- τιμές ζευγαριού
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέσετε, να διαβάσετε, να ενημερώσετε και να αφαιρέσετε ετικέτες & προσαρμοσμένα δεδομένα στο Aspose.Slides για Node.js, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει εν συντομία πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, επισημαίνει ότι τα δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρξουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδιού‑τιμής συμβολοσειράς.

Δείχνει επίσης πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, μια μεμονωμένη διαφάνεια ή ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως η εκκαθάριση όλων των ετικετών, η αφαίρεση ετικέτας με όνομα και η ανάκτηση της λίστας των ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX—αντικείμενα με την επέκταση .pptx—αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Η μορφή Office Open XML ορίζει τη δομή για τα δεδομένα που περιέχονται σε παρουσιάσεις. 

Με μια *διαφάνεια* να είναι ένα από τα στοιχεία στις παρουσιάσεις, ένα *τμήμα διαφάνειας* περιέχει το περιεχόμενο μιας μόνο διαφάνειας. Ένα τμήμα διαφάνειας μπορεί να έχει ρητές σχέσεις με πολλά τμήματα—όπως οι Προσδιορισμένες Ετικέτες Χρήστη—που ορίζονται από το ISO/IEC 29500. 

Προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή χρήστης μπορούν να υπάρξουν ως ετικέτες ([TagCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TagCollection)) και CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Οι ετικέτες είναι ουσιαστικά τιμές ζεύγους κλειδιού‑συμβολοσειράς. 
{{% /alert %}} 

## **Λήψη των Τιμών για τις Ετικέτες**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στις μεθόδους [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) και [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides για Node.js μέσω Java για [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχείο:

- το όνομα μιας προσαρμοσμένης ιδιότητας - `MyTag`
- την τιμή της προσαρμοσμένης ιδιότητας - `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις βάσει συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να επωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε ή να συγκεντρώσετε όλες τις παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και στη συνέχεια να ορίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό και Καναδά) ως τιμές.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής ετικετών προσαρμοσμένων δεδομένων με χρήση `getCustomData().getTags()` αποθηκεύονται μόνο μέσα στο αρχείο PowerPoint. **Δεν** μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος αναγνωριστικός κωδικός που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Αναμετάφραση**: Μπορείτε να αποθηκεύετε έναν προσαρμοσμένο αναγνωριστικό στον **Alt Text** του αντικειμένου (π.χ., `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text ενδέχεται να εμφανιστεί στη δομή ετικετών του PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/) υποστηρίζει ενέργεια [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτόχρονα.

**Πώς μπορώ να διαγράψω μία ετικέτα με το όνομά της χωρίς να επαναλαμβάνομαι σε όλη τη συλλογή;**

Χρησιμοποιήστε την ενέργεια [remove(name)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/remove/) στη [TagCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε τη μέθοδο [getNamesOfTags](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.