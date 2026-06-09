---
title: Ομαδικά Σχήματα Παρουσίασης σε Java
linktitle: Ομάδα Σχημάτων
type: docs
weight: 40
url: /el/java/group/
keywords:
- ομαδικό σχήμα
- ομάδα σχημάτων
- προσθήκη ομάδας
- εναλλακτικό κείμενο
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ομαδοποιείτε και να αποομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java—γρήγορος, βήμα-βήμα οδηγός με δωρεάν κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με ομαδικά σχήματα στο Aspose.Slides. Δείχνει πώς να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα σε αυτό και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, παρουσιάζει πώς να αποκτήσετε πρόσβαση στα σχήματα που είναι αποθηκευμένα μέσα σε μια ομάδα και να διαβάσετε τις τιμές `AlternativeText` τους. Επιπλέον, το άρθρο καλύπτει εν συντομία τις σχετικές δυνατότητες των ομαδικών σχήματος όπως οι ένθετες ομάδες, η σειρά z και οι επιλογές κλειδώματος.

## **Προσθήκη Ομαδικού Σχήματος**
Το Aspose.Slides υποστηρίζει εργασία με ομαδικά σχήματα στις διαφάνειες. Αυτή η δυνατότητα βοηθά τους προγραμματιστές να δημιουργούν πιο πλούσιες παρουσιάσεις. Το Aspose.Slides for Java υποστηρίζει την προσθήκη ή την πρόσβαση σε ομαδικά σχήματα. Είναι δυνατόν να προσθέσετε σχήματα σε ένα προστιθέμενο ομαδικό σχήμα για να το γεμίσετε ή να έχετε πρόσβαση σε οποιαδήποτε ιδιότητα του ομαδικού σχήματος. Για να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
1. Προσθέστε ένα ομαδικό σχήμα στη διαφάνεια.
1. Προσθέστε τα σχήματα στο προστιθέμενο ομαδικό σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ομαδικό σχήμα σε μια διαφάνεια.

```java
// Δημιουργία αντικειμένου της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
    IShapeCollection slideShapes = sld.getShapes();

    // Προσθήκη ομαδικού σχήματος στη διαφάνεια
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Προσθήκη σχημάτων μέσα στο προστεθέν ομαδικό σχήμα
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Προσθήκη πλαισίου ομαδικού σχήματος
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση στην Ιδιότητα AltText**
Αυτό το θέμα παρουσιάζει απλά βήματα, πλήρη με παραδείγματα κώδικα, για την προσθήκη ενός ομαδικού σχήματος και την πρόσβαση στην ιδιότητα AltText των ομαδικών σχημάτων στις διαφάνειες. Για να αποκτήσετε πρόσβαση στο AltText ενός ομαδικού σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που αντιπροσωπεύει αρχείο PPTX.
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Πρόσβαση στη συλλογή σχημάτων των διαφανειών.
1. Πρόσβαση στο ομαδικό σχήμα.
1. Πρόσβαση στην ιδιότητα [AlternativeText](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape#getAlternativeText--).

Το παρακάτω παράδειγμα αποκτά πρόσβαση στο εναλλακτικό κείμενο του ομαδικού σχήματος.

```java
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Πρόσβαση στο ομαδικό σχήμα.
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

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε μια ομάδα);**

Ναι. Το [GroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/groupshape/) έχει τη μέθοδο [getParentGroup](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getParentGroup--) η οποία υποδεικνύει άμεσα την υποστήριξη ιεραρχίας (μια ομάδα μπορεί να είναι παιδί μιας άλλης ομάδας).

**Πώς να ελέγξω τη σειρά z της ομάδας σε σχέση με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε τη μέθοδο [getZOrderPosition](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getZOrderPosition--) του [GroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/groupshape/) για να ελέγξετε τη θέση του στην στοίβα εμφάνισης.

**Μπορώ να αποτρέψω τη μετακίνηση/επεξεργασία/αποομαδοποίηση;**

Ναι. Η ενότητα κλειδώματος της ομάδας εκτίθεται μέσω του [GroupShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/groupshape/#getGroupShapeLock--) που σας επιτρέπει να περιορίσετε τις ενέργειες στο αντικείμενο.