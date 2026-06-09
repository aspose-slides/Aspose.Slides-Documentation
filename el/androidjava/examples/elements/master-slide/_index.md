---
title: Κύρια Διαφάνεια
type: docs
weight: 30
url: /el/androidjava/examples/elements/master-slide/
keywords:
- παράδειγμα κώδικα
- κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κύριων διαφανειών Aspose.Slides για Android: δημιουργία, επεξεργασία και στυλιζάρισμα κυρίων διαφανειών, σύμβολα κράτησης θέσης και θέματα σε PPT, PPTX, και ODP με σαφή κώδικα Java."
---
Οι κύριες διαφάνειες αποτελούν το υψηλότερο επίπεδο της ιεραρχίας κληρονομικότητας διαφάνειας στο PowerPoint. Μία **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως φόντα, λογότυπα και μορφοποίηση κειμένου. Οι **layout slides** κληρονομούν από τις master slides, και οι **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, τροποποιήσετε και διαχειριστείτε master slides χρησιμοποιώντας το Aspose.Slides for Android μέσω Java.

## **Προσθήκη Master Slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα master slide αντιγράφοντας τη προεπιλεγμένη. Στη συνέχεια προσθέτει μια μπάνερ με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω κληρονομικότητας layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Κλωνοποιήστε την προεπιλεγμένη κύρια διαφάνεια.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Προσθέστε μια λωρίδα με το όνομα της εταιρείας στην κορυφή της κύριας διαφάνειας.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Αναθέστε τη νέα κύρια διαφάνεια σε μια διαφάνεια διάταξης.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Αναθέστε τη διαφάνεια διάταξης στην πρώτη διαφάνεια στην παρουσίαση.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση 1:** Οι master slides παρέχουν τρόπο για την εφαρμογή συνεπούς επωνυμίας ή κοινών στοιχείων σχεδίασης σε όλες τις διαφάνειες. Οποιαδήποτε αλλαγή γίνει στη master θα αντικατοπτρίζεται αυτόματα στις εξαρτημένες layout και normal διαφάνειες.

> 💡 **Σημείωση 2:** Όλα τα σχήματα ή η μορφοποίηση που προστίθενται σε μια master slide κληρονομούνται από τις layout slides και, με τη σειρά τους, από όλες τις normal διαφάνειες που χρησιμοποιούν αυτές τις διαφάνειες.  
> Η παρακάτω εικόνα δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια master slide αποδίδεται αυτόματα στη τελική διαφάνεια.

![Παράδειγμα Κληρονομικότητας Master](master-slide-banner.png)

## **Πρόσβαση σε Master Slide**

Μπορείτε να έχετε πρόσβαση στις master slides χρησιμοποιώντας τη συλλογή master του παρουσίασης. Ακολουθεί πώς να τις ανακτήσετε και να δουλέψετε με αυτές:

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

## **Αφαίρεση Master Slide**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Αφαιρέστε μια κύρια διαφάνεια κατά δείκτη.
        presentation.getMasters().removeAt(0);

        // Αφαιρέστε μια κύρια διαφάνεια με αναφορά.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μη Χρησιμοποιημένων Master Slides**

Ορισμένες παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει να μειωθεί το μέγεθος του αρχείου.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Αφαιρέστε όλες τις μη χρησιμοποιημένες κύριες διαφάνειες (ακόμη και εκείνες που έχουν επισημανθεί ως Διατήρηση).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```