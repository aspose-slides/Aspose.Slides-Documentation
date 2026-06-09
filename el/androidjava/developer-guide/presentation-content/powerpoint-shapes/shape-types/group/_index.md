---
title: Σχήματα Ομάδας Παρουσίασης σε Android
linktitle: Ομάδα Σχημάτων
type: docs
weight: 40
url: /el/androidjava/group/
keywords:
- σχήμα ομάδας
- ομάδα σχημάτων
- προσθήκη ομάδας
- εναλλακτικό κείμενο
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ομαδοποιείτε και να αποομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Android—γρήγορος, βήμα-βήμα οδηγός με δωρεάν κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με ομάδες σχήματος στο Aspose.Slides. Δείχνει πώς να προσθέσετε ένα σχήμα ομάδας σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα σε αυτό και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, παρουσιάζει πώς να έχετε πρόσβαση στα σχήματα που βρίσκονται εντός μιας ομάδας και να διαβάσετε τις τιμές `AlternativeText` τους. Επιπλέον, το άρθρο καλύπτει εν συντομία σχετικές δυνατότητες ομάδων σχήματος όπως ένθετες ομάδες, σειρά z και επιλογές κλειδώματος.

## **Προσθήκη Σχήματος Ομάδας**
Aspose.Slides υποστηρίζει εργασία με ομάδες σχήματος σε διαφάνειες. Αυτή η δυνατότητα βοηθά τους προγραμματιστές να δημιουργούν πιο πλούσιες παρουσιάσεις. Το Aspose.Slides for Android μέσω Java υποστηρίζει την προσθήκη ή την πρόσβαση σε ομάδες σχήματος. Είναι δυνατόν να προσθέσετε σχήματα σε μια προστιθέμενη ομάδα σχήματος για να την γεμίσετε ή να έχετε πρόσβαση σε οποιαδήποτε ιδιότητα της ομάδας σχήματος. Για να προσθέσετε ένα σχήμα ομάδας σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Android μέσω Java:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.
1. Προσθέστε ένα σχήμα ομάδας στη διαφάνεια.
1. Προσθέστε τα σχήματα στην προστιθέμενη ομάδα σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα σχήμα ομάδας σε μια διαφάνεια.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Ανάκτηση της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
    IShapeCollection slideShapes = sld.getShapes();

    // Προσθήκη σχήματος ομάδας στη διαφάνεια
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Προσθήκη σχημάτων μέσα στο προστιθέμενο σχήμα ομάδας
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Προσθήκη πλαισίου σχήματος ομάδας
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση στην Ιδιοκτησία AltText**
Αυτό το θέμα παρουσιάζει απλά βήματα, με παραδείγματα κώδικα, για την προσθήκη ενός σχήματος ομάδας και την πρόσβαση στην ιδιότητα AltText των ομάδων σχήματος σε διαφάνειες. Για να αποκτήσετε πρόσβαση στο AltText ενός σχήματος ομάδας σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Android μέσω Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που αντιπροσωπεύει αρχείο PPTX.
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.
1. Πρόσβαση στη συλλογή σχήματος των διαφανειών.
1. Πρόσβαση στο σχήμα ομάδας.
1. Πρόσβαση στην ιδιότητα [AlternativeText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getAlternativeText--).

Το παρακάτω παράδειγμα αποκτά πρόσβαση στο εναλλακτικό κείμενο του σχήματος ομάδας.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Ανάκτηση της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Πρόσβαση στο σχήμα ομάδας.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Πρόσβαση στην ιδιότητα AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Ναι. Το [GroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/groupshape/) διαθέτει τη μέθοδο [getParentGroup](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getParentGroup--) η οποία υποδεικνύει άμεσα τη στήριξη ιεραρχίας (μια ομάδα μπορεί να είναι παιδί άλλης ομάδας).

**How do I control the group’s z-order relative to other objects on the slide?**

Χρησιμοποιήστε τη μέθοδο [getZOrderPosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getZOrderPosition--) του [GroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/groupshape/) για να ελέγξετε τη θέση του στην στοίβα εμφάνισης.

**Can I prevent moving/editing/ungrouping?**

Ναι. Η ενότητα κλειδώματος της ομάδας είναι προσβάσιμη μέσω της μεθόδου [getGroupShapeLock](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) η οποία επιτρέπει τον περιορισμό ενεργειών στο αντικείμενο.