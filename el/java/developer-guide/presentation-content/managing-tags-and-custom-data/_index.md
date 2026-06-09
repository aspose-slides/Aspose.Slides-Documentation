---
title: Διαχείριση ετικετών και προσαρμοσμένων δεδομένων σε παρουσιάσεις με Java
linktitle: Ετικέτες και προσαρμοσμένα δεδομένα
type: docs
weight: 300
url: /el/java/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- ζεύγη τιμών
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, διαβάζετε, ενημερώνετε και καταργείτε ετικέτες και προσαρμοσμένα δεδομένα στο Aspose.Slides για Java, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς η Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει εν συντομία πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, σημειώνει ότι τα δεδομένα που αφορούν συγκεκριμένη παρουσίαση μπορούν να υπάρχουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδί‑τιμή συμβολοσειρών.

Επίσης δείχνει πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, σε ένα μεμονωμένο σλάιδο ή σε ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως η εκκαθάριση όλων των ετικετών, η αφαίρεση μιας ετικέτας με το όνομά της και η λήψη της λίστας των ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX — στοιχεία με την επέκταση .pptx — αποθηκεύονται σε μορφή PresentationML, που αποτελεί μέρος της προδιαγραφή Office Open XML. Η μορφή Office Open XML ορίζει τη δομή για τα δεδομένα που περιέχονται σε παρουσιάσεις. 

Με ένα *slide* να αποτελεί ένα από τα στοιχεία στις παρουσιάσεις, ένα *slide part* περιέχει το περιεχόμενο ενός μόνο σλάιντ. Ένα slide part επιτρέπεται να έχει ρητές σχέσεις με πολλά μέρη — όπως οι User Defined Tags — όπως ορίζεται από ISO/IEC 29500. 

Προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή ο χρήστης μπορούν να υπάρξουν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITagCollection)) και CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 

Οι ετικέτες είναι ουσιαστικά τιμές ζεύγους κλειδί‑συμβολοσειρά. 

{{% /alert %}} 

## **Λήψη Τιμών των Ετικετών**

Στα slides, μια ετικέτα αντιστοιχεί στις μεθόδους [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDocumentProperties#getKeywords--) και [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Java για την [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας — `MyTag` 
- την τιμή της προσαρμοσμένης ιδιότητας — `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις βάσει συγκεκριμένου κανόνα ή ιδιότητας, τότε μπορείτε να ωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, εάν θέλετε να κατηγοριοποιήσετε ή να συγκεντρώσετε όλες τις παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και στη συνέχεια να αντιστοιχίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό και Καναδά) ως τιμές.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα στην [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) χρησιμοποιώντας το Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για το [Slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής ετικετών προσαρμοσμένων δεδομένων με χρήση `getCustomData().getTags()` αποθηκεύονται μόνο εντός του αρχείου PowerPoint. Δεν μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το ετικεταρισμένο PDF.

**Workaround**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ., `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, σλάιδο ή σχήμα με μία ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#clear--) που διαγράφει όλα τα ζεύγη κλειδί‑τιμή ταυτόχρονα.

**Πώς διαγράφω μια μεμονωμένη ετικέτα με το όνομά της χωρίς να διατρέξω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε τη λειτουργία [Remove(name)](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) στην [tag collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να λάβω τη πλήρη λίστα ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε το [getNamesOfTags](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/#getNamesOfTags--) στη [tag collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.