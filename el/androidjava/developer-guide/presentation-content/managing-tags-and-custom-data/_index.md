---
title: "Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις στο Android"
linktitle: "Ετικέτες και Προσαρμοσμένα Δεδομένα"
type: docs
weight: 300
url: /el/androidjava/managing-tags-and-custom-data
keywords:
- "ιδιότητες εγγράφου"
- "ετικέτα"
- "προσαρμοσμένα δεδομένα"
- "προσθήκη ετικέτας"
- "ζεύγη τιμών"
- "PowerPoint"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Προσθήκη, ανάγνωση, ενημέρωση και αφαίρεση ετικετών & προσαρμοσμένων δεδομένων στο Aspose.Slides για Android, με παραδείγματα Java για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Συνοψίζει εν συντομία πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, σημειώνει ότι τα δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρχουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδιού‑τιμής σε μορφή συμβολοσειράς.

Δείχνει επίσης πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, σε μια μεμονωμένη διαφάνεια ή σε ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως ο καθαρισμός όλων των ετικετών, η αφαίρεση ετικέτας με όνομα και η ανάκτηση της λίστας των ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσιάσεων**

Τα αρχεία PPTX—αντικείμενα με την επέκταση .pptx—αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Η μορφή Office Open XML ορίζει τη δομή των δεδομένων που περιέχονται σε παρουσιάσεις.

Με μια *διαφάνεια* να είναι ένα από τα στοιχεία στις παρουσιάσεις, ένα *τμήμα διαφάνειας* περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας. Ένα τμήμα διαφάνειας επιτρέπεται να έχει ρητές σχέσεις με πολλά τμήματα—όπως τις Προσαρμοσμένες Ετικέτες—που ορίζονται από το ISO/IEC 29500.

Προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή ο χρήστης μπορούν να εμφανιστούν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITagCollection)) και CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Οι ετικέτες είναι ουσιαστικά ζεύγη κλειδιού‑συμβολοσειράς. 
{{% /alert %}} 

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στις μεθόδους [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) και [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Αυτό το παράδειγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides for Android μέσω Java για το [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας - `MyTag` 
- η τιμή της προσαρμοσμένης ιδιότητας - `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις με βάση έναν συγκεκριμένο κανόνα ή ιδιότητα, τότε μπορείτε να επωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, αν θέλετε να ομαδοποιήσετε όλες τις παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και στη συνέχεια να ορίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό και Καναδά) ως τιμές.

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) χρησιμοποιώντας το Aspose.Slides for Android μέσω Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για το [Slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape):

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

Οι ετικέτες που προστίθενται μέσω της συλλογής ετικετών προσαρμοσμένων δεδομένων με τη χρήση `getCustomData().getTags()` αποθηκεύονται μόνο μέσα στο αρχείο PowerPoint. Δεν μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος ταυτοποιητής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Workaround**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο ταυτοποιητή στο **Alt Text** του αντικειμένου (π.χ., `shape.setAlternativeText("MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/#clear--) που διαγράφει όλα τα ζεύγη κλειδί‑τιμής ταυτόχρονα.

**Πώς μπορώ να διαγράψω μια μόνο ετικέτα κατά όνομά της χωρίς να περάσω όλη τη συλλογή;**

Χρησιμοποιήστε τη λειτουργία [remove(name)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε το [getNamesOfTags](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) στη [συλλογή ετικετών](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.