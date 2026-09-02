---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε .NET
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/net/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχημάτων
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχήματος από διαφάνειες PowerPoint με Aspose.Slides για .NET – δημιουργήστε εύκολα και εξάγετε μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Aspose.Slides for .NET χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης όπου κάθε σελίδα είναι μια διαφάνεια. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, μερικές φορές οι προγραμματιστές μπορεί να χρειαστούν να δουν τις εικόνες των σχημάτων χωριστά σε προβολέα εικόνας. Σε τέτοιες περιπτώσεις, το Aspose.Slides for .NET σας βοηθά να δημιουργήσετε μικρογραφίες των σχημάτων της διαφάνειας. Πώς να χρησιμοποιήσετε αυτή τη δυνατότητα περιγράφεται σε αυτό το άρθρο.

Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε μικρογραφίες διαφανειών με διαφορετικούς τρόπους:

- Δημιουργία μικρογραφίας σχήματος μέσα σε μία διαφάνεια.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη.
- Δημιουργία μικρογραφίας σχήματος στα όρια της εμφάνισης του σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for .NET:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας του σχήματος της αναφερόμενης διαφάνειας σε προεπιλεγμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το ακόλουθο παράδειγμα δημιουργεί μικρογραφία σχήματος.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Δημιουργία μικρογραφίας με παράγοντα κλιμάκωσης που ορίζεται από το χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος οποιουδήποτε σχήματος διαφάνειας χρησιμοποιώντας το Aspose.Slides for .NET:

1. Δημιουργήστε μια εμφάνιση της κλάσης `Presentation`.
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τα όρια του σχήματος.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με παράγοντα κλιμάκωσης που ορίζεται από το χρήστη.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Κλιμάκωση στους άξονες X και Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Δημιουργία μικρογραφίας εμφάνισης σχήματος βάσει ορίων**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία εντός των ορίων της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία οποιουδήποτε σχήματος διαφάνειας εντός των ορίων της εμφάνισης του, χρησιμοποιήστε τον παρακάτω κώδικα:

1. Δημιουργήστε μια εμφάνιση της κλάσης `Presentation`.
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τα όρια του σχήματος ως εμφάνιση.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με παράγοντα κλιμάκωσης που ορίζεται από το χρήστη.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Κλιμάκωση στους άξονες X και Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Λήψη των πραγματικών ορατών ορίων ενός σχήματος**

Οι ιδιότητες πλαισίου του [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) — οι ιδιότητες `X`, `Y`, `Width` και `Height` — περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που πραγματικά αποδίδεται μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο προσανατολισμένο στον άξονα. Περιστροφή, περιγράμματα, κεφαλές βελών, διάταξη και υπερχείλιση κειμένου, η παραγόμενη γεωμετρία SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την περιοχή που καταλαμβάνει.

Χρησιμοποιήστε το [GetVisualBounds](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getvisualbounds/) για να υπολογίσετε αυτήν την κατοικημένη περιοχή χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν κόβεται στο μέγεθος της διαφάνειας, επομένως οι συντεταγμένες του μπορεί να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από την αρχή της διαφάνειας.

Το [GetVisualBounds](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getvisualbounds/) δεν είναι επί του παρόντος δηλωμένο από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/). Επομένως, διατηρήστε το σχήμα που λαμβάνετε από τη συλλογή σχημάτων της διαφάνειας ως τιμή διεπαφής και κάντε cast μόνο όταν καλείτε τη μέθοδο.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει το πλαίσιο και τα οπτικά όρια:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Το ίδιο [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) μπορεί να χρησιμοποιηθεί για την ευθυγράμμιση κοντινών σχημάτων προς την άκρη `Left`, `Right`, `Top` ή `Bottom`· για την κράτηση αρκετού χώρου σε μια παραγόμενη διάταξη· ή για την ανίχνευση περιεχομένου εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσιο κειμένου, βέλη, εικόνες, περιστρεφόμενα σχήματα και ομάδες σχημάτων, όπου το αποθηκευμένο πλαίσιο μπορεί να μην αντιπροσωπεύει το πλήρες αποτέλεσμα της απόδοσης.

Χρησιμοποιήστε το [GetVisualBounds](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getvisualbounds/) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε το [IShape.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getimage/) όταν χρειάζεστε την απόδοση του σχήματος. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/net/aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds.Shape` καθορίζει το μέγεθος της εικόνας από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds.Appearance` καθορίζει το μέγεθος από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το [GetVisualBounds](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getvisualbounds/) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το κόβει στην διαφάνεια.

## **FAQ**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/net/aspose.slides/shape/writeassvg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη [τα οπτικά εφέ](/slides/el/net/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι επισημασμένο ως κρυφό; Θα αποδοθεί ακόμα ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής εμφάνισης επηρεάζει την προβολή της παρουσίασης αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα γραφήματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Όποιοδήποτε αντικείμενο που αναπαρίσταται ως [Shape](https://reference.aspose.com/slides/el/net/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/), και [SmartArt](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι γραμματοσειρές που είναι εγκατεστημένες στο σύστημα την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/net/custom-font/) (ή να [ρυθμίσετε τις υποκαταστάσεις γραμματοσειρών](/slides/el/net/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλακτικές και αναδιάταξη κειμένου.