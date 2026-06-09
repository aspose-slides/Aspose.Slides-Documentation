---
title: Κύρια διαφάνεια
type: docs
weight: 30
url: /el/java/examples/elements/master-slide/
keywords:
- παράδειγμα κώδικα
- κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα master slide του Aspose.Slides for Java: δημιουργία, επεξεργασία και στυλιζάρισμα master, placeholders και θεμάτων σε PPT, PPTX και ODP με σαφή κώδικα Java."
---
Οι κύριες διαφάνειες αποτελούν το υψηλότερο επίπεδο της ιεραρχίας κληρονομικότητας διαφανειών στο PowerPoint. Μια **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως τα φόντα, τα λογότυπα και τη μορφοποίηση κειμένου. Οι **layout slides** κληρονομούν από τις master slides, και οι **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, να τροποποιήσετε και να διαχειριστείτε τις κύριες διαφάνειες χρησιμοποιώντας το Aspose.Slides for Java.

## **Add a Master Slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα master slide κλωνοποιώντας την προεπιλεγμένη. Στη συνέχεια προσθέτει μια διαφήμιση με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω της κληρονομικότητας layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Κλωνοποιήστε τη προεπιλεγμένη κύρια διαφάνεια.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Προσθέστε μια επιγραφή με το όνομα της εταιρείας στην κορυφή της κύριας διαφάνειας.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Αναθέστε τη νέα κύρια διαφάνεια σε μια διαφάνεια διάταξης.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Αναθέστε τη διαφάνεια διάταξης στην πρώτη διαφάνεια της παρουσίασης.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Οι master slides παρέχουν έναν τρόπο εφαρμογής ομοιογενούς branding ή κοινού στοιχείου σχεδίασης σε όλες τις διαφάνειες. Οποιεσδήποτε αλλαγές γίνουν στη master θα αντικατοπτρίζονται αυτόματα στις εξαρτώμενες layout και normal slides.

> 💡 **Note 2:** Οποιαδήποτε σχήματα ή μορφοποίηση προστεθούν σε μια master slide κληρονομούνται από τις layout slides και, με τη σειρά τους, από όλες τις normal slides που χρησιμοποιούν αυτά τα layout.  
> Η εικόνα παρακάτω δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια master slide αποδίδεται αυτόματα στην τελική διαφάνεια.

![Παράδειγμα κληρονομικότητας master](master-slide-banner.png)

## **Access a Master Slide**

Μπορείτε να αποκτήσετε πρόσβαση στις master slides χρησιμοποιώντας τη συλλογή master του παρουσίασης. Δείτε πώς να τις ανακτήσετε και να εργαστείτε με αυτές:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Αλλάξτε τον τύπο του φόντου.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Master Slide**

Οι master slides μπορούν να αφαιρεθούν είτε με βάση τον δείκτη είτε με βάση την αναφορά.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Αφαιρέστε μια κύρια διαφάνεια με βάση το δείκτη.
        presentation.getMasters().removeAt(0);

        // Αφαιρέστε μια κύρια διαφάνεια με βάση την αναφορά.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Master Slides**

Ορισμένες παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Αφαιρέστε όλες τις αχρησιμοποίητες κύριες διαφάνειες (ακόμη και αυτές που σημειώνονται ως Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```