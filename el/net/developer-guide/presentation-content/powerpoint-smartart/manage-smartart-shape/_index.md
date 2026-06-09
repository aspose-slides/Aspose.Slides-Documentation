---
title: Διαχείριση γραφικών SmartArt σε παρουσιάσεις στο .NET
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/net/manage-smartart-shape/
keywords:
- SmartArt αντικείμενο
- SmartArt γραφικό
- SmartArt στυλ
- SmartArt χρώμα
- δημιουργία SmartArt
- προσθήκη SmartArt
- επεξεργασία SmartArt
- αλλαγή SmartArt
- πρόσβαση SmartArt
- τύπος διάταξης SmartArt
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, επεξεργασία και στυλιζάρισμα SmartArt στο PowerPoint σε .NET χρησιμοποιώντας το Aspose.Slides, με σύντομα παραδείγματα κώδικα και οδηγίες εστιασμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, να έχετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, να βρείτε SmartArt με συγκεκριμένο τύπο διάταξης και να ενημερώσετε την οπτική του εμφάνιση αλλάζοντας το στυλ SmartArt ή το χρωματικό στυλ.

Τα παραδείγματα δείχνουν πώς να εργαστείτε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας της παρουσίασης, να ελέγξετε εάν ένα σχήμα είναι SmartArt και στη συνέχεια να τροποποιήσετε ή να εξετάσετε τις ιδιότητές του.

## **Δημιουργία σχήματος SmartArt**
Το Aspose.Slides for .NET πλέον διευκολύνει την προσθήκη προσαρμοσμένων σχημάτων SmartArt στις διαφάνειές τους από το μηδέν. Το Aspose.Slides for .NET παρέχει το πιο απλό API για τη δημιουργία σχημάτων SmartArt με τον ευκολότερο τρόπο. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα σχήμα SmartArt ορίζοντας το LayoutType του.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
// Δημιουργία της παρουσίασης
using (Presentation pres = new Presentation())
{
    // Πρόσβαση στη διαφάνεια παρουσίασης
    ISlide slide = pres.Slides[0];

    // Προσθήκη σχήματος Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Αποθήκευση παρουσίασης
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Πρόσβαση σε σχήμα SmartArt σε διαφάνεια**
Ο παρακάτω κώδικας θα χρησιμοποιηθεί για την πρόσβαση στα σχήματα SmartArt που προστέθηκαν στην διαφάνεια της παρουσίασης. Στον δείγμα κώδικα θα διασχίσουμε κάθε σχήμα μέσα στη διαφάνεια και θα ελέγξουμε εάν πρόκειται για σχήμα SmartArt. Εάν το σχήμα είναι τύπου SmartArt, τότε θα το μετατρέψουμε σε αντικείμενο SmartArt.

```c#
// Φόρτωση της επιθυμητής παρουσίασης
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape is ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **Πρόσβαση σε σχήμα SmartArt με συγκεκριμένο τύπο διάταξης**
Ο παρακάτω δείγμα κώδικα θα βοηθήσει στην πρόσβαση στο σχήμα SmartArt με συγκεκριμένο LayoutType. Σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt, καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα SmartArt προστίθεται.

- Δημιουργήστε ένα αντίτυπο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.
- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
- Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
- Ελέγξτε εάν το σχήμα είναι τύπου SmartArt και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
- Ελέγξτε το σχήμα SmartArt με συγκεκριμένο LayoutType και εκτελέστε ό,τι απαιτείται μετά.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape is ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Έλεγχος διάταξης SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Αλλαγή στυλ σχήματος SmartArt**
Ο παρακάτω δείγμα κώδικα θα βοηθήσει στην πρόσβαση στο σχήμα SmartArt με συγκεκριμένο LayoutType.

- Δημιουργήστε ένα αντίτυπο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.
- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
- Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
- Ελέγξτε εάν το σχήμα είναι τύπου SmartArt και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
- Βρείτε το σχήμα SmartArt με συγκεκριμένο Style.
- Ορίστε το νέο Style για το σχήμα SmartArt.
- Αποθηκεύστε την παρουσίαση.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape is ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Έλεγχος στυλ SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Αλλαγή στυλ SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Αποθήκευση παρουσίασης
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Αλλαγή χρωματικού στυλ σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάζουμε το χρωματικό στυλ για οποιοδήποτε σχήμα SmartArt. Στον παρακάτω δείγμα κώδικα θα γίνει πρόσβαση στο σχήμα SmartArt με συγκεκριμένο χρωματικό στυλ και θα αλλάξει το στυλ του.

- Δημιουργήστε ένα αντίτυπο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.
- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
- Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
- Ελέγξτε εάν το σχήμα είναι τύπου SmartArt και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
- Βρείτε το σχήμα SmartArt με συγκεκριμένο Color Style.
- Ορίστε το νέο Color Style για το σχήμα SmartArt.
- Αποθηκεύστε την παρουσίαση.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape is ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Έλεγχος τύπου χρώματος SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Αλλαγή τύπου χρώματος SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Αποθήκευση παρουσίασης
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να κάνω animation το SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, επομένως μπορείτε να εφαρμόσετε [standard animations](/slides/el/net/powerpoint-animation/) μέσω του API animation (είσοδος, έξοδος, έμφαση, μονοπάτια κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και αναζητήστε το σχήμα με αυτήν την τιμή — αυτή είναι μια συνιστώμενη μέθοδος για τον εντοπισμό του στοχευμένου σχήματος.

**Μπορώ να ομαδοποιήσω το SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες κ.λπ.) και στη συνέχεια να [manipulate the group](/slides/el/net/group/).

**Πώς λαμβάνω μια εικόνα ενός συγκεκριμένου SmartArt (π.χ. για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [render individual shapes](/slides/el/net/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt όταν μετατρέπετε ολόκληρη την παρουσίαση σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για [PDF export](/slides/el/net/convert-powerpoint-to-pdf/), με μια σειρά επιλογών ποιότητας και συμβατότητας.