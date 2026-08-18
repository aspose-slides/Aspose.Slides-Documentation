---
title: Κλωνοποίηση Διαφανειών Παρουσίασης σε .NET
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 40
url: /el/net/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε γρήγορα αντίγραφα διαφανειών PowerPoint με το Aspose.Slides για .NET. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλεισθεί η χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιτύπου κάτι. Το Aspose.Slides επίσης επιτρέπει την αντιγραφή (κλωνοποίηση) οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η κλωνοποίηση διαφάνειας δημιουργεί μια νέα διαφάνεια που οι προγραμματιστές μπορούν να τροποποιήσουν χωρίς να επηρεάσουν την αρχική διαφάνεια. Υπάρχουν πολλοί τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός μιας παρουσίασης.
- Κλωνοποίηση στο τέλος άλλης παρουσίασης.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση μαζί με τη μητρική διαφάνειά της σε άλλη παρουσίαση.

Στο Aspose.Slides για .NET, η συλλογή διαφανειών (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) ) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) παρέχει τις μεθόδους [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) και [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/insertclone/) για την εκτέλεση των παραπάνω λειτουργιών κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση Διαφάνειας στο Τέλος μιας Παρουσίασης**

Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε μέσα στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) αναφερόμενοι στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση Εντός μιας Παρουσίασης**

Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε μέσα στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Δημιουργήστε το αντικείμενο αναφερόμενοι στη συλλογή **Slides** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Καλέστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (που βρίσκεται στον δείκτη 1 – θέση 2 – της παρουσίασης) στο δείκτη 2 – θέση 3 – της παρουσίασης.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.Slides;

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στον καθορισμένο δείκτη στην ίδια παρουσίαση
    slds.InsertClone(2, pres.Slides[1]);

    // Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος Άλλης Παρουσίασης**

Εάν χρειάζεστε την κλωνοποίηση μιας διαφάνειας από μια παρουσίαση και τη χρήση της σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) αναφερόμενοι στη συλλογή **Slides** που εκτίθεται από το αντικείμενο Presentation της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index).
1. Γράψτε το τροποποιημένο αρχείο της προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από τον πρώτο δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για την προορισμένη PPTX (όπου η διαφάνεια θα κλωνοποιηθεί)
    using (Presentation destPres = new Presentation())
    {
        // Κλωνοποίηση της ζητούμενης διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση σε Άλλη Παρουσίαση**

Εάν χρειάζεστε την κλωνοποίηση μιας διαφάνειας από μια παρουσίαση και τη χρήση της σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) αναφερόμενοι στη συλλογή Slides της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με την επιθυμητή θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Γράψτε το τροποποιημένο αρχείο της προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από το μηδενικό δείκτη της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προορισμένης παρουσίασης.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για την προορισμένη PPTX (όπου η διαφάνεια θα κλωνοποιηθεί)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Κλωνοποίηση Διαφάνειας με τη Μητρική Διαφάνειά της σε Άλλη Παρουσίαση**

Εάν χρειάζεστε την κλωνοποίηση μιας διαφάνειας μαζί με μια μητρική διαφάνεια από μια παρουσίαση και τη χρήση τους σε άλλη παρουσίαση, πρώτα πρέπει να κλωνοποιήσετε τη ζητούμενη μητρική διαφάνεια από την πηγαία παρουσίαση στην προορισμένη παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτή τη μητρική διαφάνεια για την κλωνοποίηση της διαφάνειας με μητρική. Η μέθοδος **AddClone(ISlide, IMasterSlide)** αναμένει μια μητρική διαφάνεια από την προορισμένη παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με τη μητρική, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία του κλάσματος [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την προορισμένη παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Προσπελάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τη μητρική διαφάνεια.
1. Δημιουργήστε το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection) αναφερόμενοι στη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκτίθεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection) και περάστε τη μητρική διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index).
1. Δημιουργήστε το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) ορίζοντας την αναφορά στη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) της προορισμένης παρουσίασης.
1. Καλέστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκτίθεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και περάστε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί μαζί με τη μητρική διαφάνεια ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index).
1. Γράψτε το τροποποιημένο αρχείο της προορισμένης παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με μητρική (που βρίσκεται στο μηδενικό δείκτη της πηγαίας παρουσίασης) στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας μια μητρική από τη πηγαία διαφάνεια.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για την προορισμένη παρουσίαση (όπου η διαφάνεια θα κλωνοποιηθεί)
    using (Presentation destPres = new Presentation())
    {

        // Δημιουργία ISlide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        // Μητρική διαφάνεια
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Κλωνοποίηση της ζητούμενης μητρικής διαφάνειας από την πηγαία παρουσίαση στη συλλογή των μητρικών στην
        // Προορισμένη παρουσίαση
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Κλωνοποίηση της ζητούμενης μητρικής διαφάνειας από την πηγαία παρουσίαση στη συλλογή των μητρικών στην
        // Προορισμένη παρουσίαση
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Κλωνοποίηση της ζητούμενης διαφάνειας από την πηγαία παρουσίαση με τη ζητούμενη μητρική διαφάνεια στο τέλος της
        // Συλλογής διαφανειών στην προορισμένη παρουσίαση
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Κλωνοποίηση της ζητούμενης μητρικής διαφάνειας από την πηγαία παρουσίαση στη συλλογή των μητρικών στην // Προορισμένη παρουσίαση
        // Αποθήκευση της προορισμένης παρουσίασης στο δίσκο
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος Καθορισμένου Τμήματος**

Με το Aspose.Slides για .NET, μπορείτε να κλωνοποιήσετε μια διαφάνεια από ένα τμήμα μιας παρουσίασης και να την εισάγετε σε άλλο τμήμα στην ίδια παρουσίαση. Σε αυτήν την περίπτωση, πρέπει να χρησιμοποιήσετε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) από το Interface [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection).

Αυτός ο κώδικας C# σας δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε τη κλωνοποιημένη διαφάνεια σε καθορισμένο τμήμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // για κλωνοποίηση
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Διασφάλιση Συμφωνίας Μεγέθους Διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προορισμένη παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγή. Εάν τα μεγέθη διαφάνειας διαφέρουν, το Aspose.Slides δεν αλλάζει αυτόματα το μέγεθος των κλωνοποιημένων σχημάτων· οι αρχικές τους συντεταγμένες και διαστάσεις διατηρούνται, κάτι που μπορεί να προκαλέσει μη ευθυγράμμιση του περιεχομένου ή υπερέκταση εκτός των ορίων της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προορισμένης παρουσίασης ώστε να ταιριάζει με την πηγή πριν την κλωνοποίηση της μητρικής και της διαφάνειας:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Κάντε αυτό πριν την κλωνοποίηση της μητρικής και της διαφάνειας.

## **Συχνές Ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια αξιολογητών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια αξιολόγησης περιλαμβάνονται στην κλωνοποίηση. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/net/presentation-notes/) μετά την εισαγωγή.

**Πώς αντιμετωπίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο βιβλίο εργασίας OLE), η σύνδεση διατηρείται ως ένα [OLE object](/slides/el/net/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε την κλωνοποίηση σε συγκεκριμένο δείκτη διαφάνειας και να τη τοποθετήσετε σε μια επιλεγμένη [section](/slides/el/net/slide-section/). Εάν η ενότητα-στόχος δεν υπάρχει, δημιουργήστε την πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτήν.