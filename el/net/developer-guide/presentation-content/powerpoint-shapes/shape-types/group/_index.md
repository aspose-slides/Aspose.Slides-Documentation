---
title: "Ομαδική Παρουσίαση Σχημάτων σε .NET"
linktitle: "Ομάδα Σχημάτων"
type: docs
weight: 40
url: /el/net/group/
keywords:
  - "ομαδικό σχήμα"
  - "ομάδα σχημάτων"
  - "προσθήκη ομάδας"
  - "εναλλακτικό κείμενο"
  - "PowerPoint"
  - "παρουσίαση"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Μάθετε πώς να ομαδοποιείτε και να αποομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET—γρήγορος, βήμα προς βήμα οδηγός με δωρεάν κώδικα C#."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με ομαδικά σχήματα στο Aspose.Slides. Δείχνει πώς να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα σε αυτό και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, δείχνει πώς να αποκτήσετε πρόσβαση στα σχήματα που βρίσκονται μέσα σε μια ομάδα και να διαβάσετε τις τιμές `AlternativeText` τους. Επιπλέον, το άρθρο καλύπτει εν συντομία σχετικές δυνατότητες ομαδικών σχημάτων όπως ένθετες ομάδες, z-order και επιλογές κλειδώματος.

## **Προσθήκη Ομαδικού Σχήματος**
Το Aspose.Slides υποστηρίζει την εργασία με ομαδικά σχήματα σε διαφάνειες. Αυτή η δυνατότητα βοηθά τους προγραμματιστές να δημιουργούν πιο πλούσιες παρουσιάσεις. Το Aspose.Slides for .NET υποστηρίζει την προσθήκη ή την πρόσβαση σε ομαδικά σχήματα. Είναι δυνατόν να προσθέσετε σχήματα σε ένα ήδη προστιθέμενο ομαδικό σχήμα για να το γεμίσετε ή να αποκτήσετε πρόσβαση σε οποιαδήποτε ιδιότητα του ομαδικού σχήματος. Για να προσθέσετε ένα ομαδικό σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for .NET:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε ένα ομαδικό σχήμα στη διαφάνεια.
1. Προσθέστε τα σχήματα στο προστιθέμενο ομαδικό σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ομαδικό σχήμα σε μια διαφάνεια.

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation 
using (Presentation pres = new Presentation())
{
    // Απόκτηση της πρώτης διαφάνειας 
    ISlide sld = pres.Slides[0];

    // Πρόσβαση στη συλλογή σχημάτων των διαφανειών 
    IShapeCollection slideShapes = sld.Shapes;

    // Προσθήκη ομαδικού σχήματος στη διαφάνεια 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Προσθήκη σχημάτων μέσα στο προστιθέμενο ομαδικό σχήμα 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Προσθήκη πλαισίου ομαδικού σχήματος 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Αποθήκευση του αρχείου PPTX στο δίσκο 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **Πρόσβαση στην Ιδιότητα AltText**
Αυτό το θέμα παρουσιάζει απλά βήματα, συμπληρωμένα με παραδείγματα κώδικα, για την προσθήκη ενός ομαδικού σχήματος και την πρόσβαση στην ιδιότητα AltText των ομαδικών σχημάτων σε διαφάνειες. Για να αποκτήσετε πρόσβαση στο AltText ενός ομαδικού σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for .NET:

1. Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` που αντιπροσωπεύει ένα αρχείο PPTX.
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Πρόσβαση στη συλλογή σχημάτων των διαφανειών.
1. Πρόσβαση στο ομαδικό σχήμα.
1. Πρόσβαση στην ιδιότητα AltText.

Το παρακάτω παράδειγμα αποκτά πρόσβαση στο εναλλακτικό κείμενο του ομαδικού σχήματος.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation("AltText.pptx");

// Απόκτηση της πρώτης διαφάνειας
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Πρόσβαση στο ομαδικό σχήμα.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Πρόσβαση στην ιδιότητα AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε άλλη ομάδα);**

Ναι. Το [GroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/groupshape/) διαθέτει ιδιότητα [ParentGroup](https://reference.aspose.com/slides/el/net/aspose.slides/shape/parentgroup/), η οποία δείχνει άμεσα την υποστήριξη της ιεραρχίας (μια ομάδα μπορεί να είναι παιδί άλλης ομάδας).

**Πώς ελέγχω το z-order της ομάδας σε σχέση με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε την ιδιότητα [ZOrderPosition](https://reference.aspose.com/slides/el/net/aspose.slides/shape/zorderposition/) του [GroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/groupshape/) για να ελέγξετε τη θέση του στο σωρό εμφάνισης.

**Μπορώ να εμποδίσω τη μετακίνηση/επεξεργασία/αποομάδωση;**

Ναι. Η ενότητα κλειδώματος της ομάδας εκτίθεται μέσω του [GroupShapeLock](https://reference.aspose.com/slides/el/net/aspose.slides/groupshape/groupshapelock/), που σας επιτρέπει να περιορίσετε λειτουργίες στο αντικείμενο.