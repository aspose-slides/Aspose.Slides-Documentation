---
title: Κλωνοποίηση διαφανειών παρουσίασης σε .NET
linktitle: Κλωνοποίηση διαφανειών
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
description: "Δημιουργήστε γρήγορα αντίγραφα των διαφανειών PowerPoint με το Aspose.Slides για .NET. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιτύπου κάτι. Το Aspose.Slides επίσης επιτρέπει την κλωνοποίηση οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η κλωνοποίηση διαφάνειας δημιουργεί μια νέα διαφάνεια που οι προγραμματιστές μπορούν να τροποποιήσουν χωρίς να επηρεάσουν την αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι για την κλωνοποίηση μιας διαφάνειας:

- Κλωνοποίηση στο τέλος μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση εντός μιας παρουσίασης.
- Κλωνοποίηση στο τέλος μιας άλλης παρουσίασης.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for .NET, η συλλογή διαφανειών (μια συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) ) που εκδίδεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) παρέχει τις μεθόδους [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) και [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/insertclone/) για την εκτέλεση των παραπάνω λειτουργιών κλωνοποίησης διαφάνειας.

## **Κλωνοποίηση διαφάνειας στο τέλος μιας παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) με αναφορά στη συλλογή Slides που εκδίδεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
1. Καλείτε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκδίδεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και μεταβιβάζετε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση εντός μιας παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και στη συνέχεια να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
1. Δημιουργήστε μια παρουσία της κλάσης αναφέροντας τη συλλογή **Slides** που εκδίδεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
1. Καλείτε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) που εκδίδεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και μεταβιβάζετε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το ευρετήριο για τη νέα θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στην θέση μηδέν – θέση 1 – της παρουσίασης) στο ευρετήριο 1 – θέση 2 – της παρουσίασης.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    ISlideCollection slds = pres.Slides;

    // Κλωνοποιήστε τη ζητούμενη διαφάνεια στο συγκεκριμένο ευρετήριο στην ίδια παρουσίαση
    slds.InsertClone(2, pres.Slides[1]);

    // Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Κλωνοποίηση διαφάνειας στο τέλος μιας άλλης παρουσίασης**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να την χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) με αναφορά στη συλλογή **Slides** που εκδίδεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλείτε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκδίδεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και μεταβιβάζετε τη διαφάνεια από την πηγή ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (από το πρώτο ευρετήριο της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```c#
 // Δημιουργία αντικειμένου Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    using (Presentation destPres = new Presentation())
    {
        // Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Κλωνοποίηση διαφάνειας σε άλλη θέση σε άλλη παρουσίαση**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να την χρησιμοποιήσετε σε άλλη παρουσίαση, σε διαφορετική θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) με αναφορά στη συλλογή Slides που εκδίδεται από το αντικείμενο Presentation της προοριστικής παρουσίασης.
1. Καλείτε τη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) που εκδίδεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και μεταβιβάζετε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [InsertClone](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια (στη θέση μηδέν της πηγαίας παρουσίασης) στο ευρετήριο 1 (θέση 2) της προοριστικής παρουσίασης.

```c#
// Δημιουργία αντικειμένου Presentation για τη φόρτωση του πηγαίου αρχείου παρουσίασης
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Αποθηκεύστε την προοριστική παρουσίαση στο δίσκο
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Κλωνοποίηση διαφάνειας σε συγκεκριμένη θέση σε άλλη παρουσίαση**

Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια με κύρια διαφάνεια (master slide) από μία παρουσίαση και να την χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε τη ζητούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Στη συνέχεια, πρέπει να χρησιμοποιήσετε αυτήν τη κύρια διαφάνεια για την κλωνοποίηση της διαφάνειας με κύρια διαφάνεια. Η **AddClone(ISlide, IMasterSlide)** αναμένει μια κύρια διαφάνεια από την προοριστική παρουσίαση αντί για την πηγαία παρουσίαση. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την πηγαία παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει την προοριστική παρουσίαση στην οποία θα κλωνοποιηθεί η διαφάνεια.
1. Προσπελάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με τη κύρια διαφάνεια.
1. Δημιουργήστε μια παρουσία της κλάσης [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection) με αναφορά στη συλλογή Masters που εκδίδεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) της προοριστικής παρουσίασης.
1. Καλείτε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκδίδεται από το αντικείμενο [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection) και μεταβιβάζετε τη κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Δημιουργήστε μια παρουσία της κλάσης [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) θέτοντας την αναφορά στη συλλογή Slides που εκδίδεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) της προοριστικής παρουσίασης.
1. Καλείτε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) που εκδίδεται από το αντικείμενο [ISlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection) και μεταβιβάζετε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί και τη κύρια διαφάνεια ως παράμετρο στη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Γράψτε το τροποποιημένο αρχείο προοριστικής παρουσίασης.

Στο παρακάτω παράδειγμα, κλωνοποιήσαμε μια διαφάνεια με κύρια (στη θέση μηδέν της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας μια κύρια από τη διαφάνεια πηγής.

```c#
// Δημιουργία αντικειμένου Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Δημιουργία αντικειμένου Presentation για την προοριστική παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    using (Presentation destPres = new Presentation())
    {

        // Δημιουργία ISlide από τη συλλογή διαφανειών της πηγαίας παρουσίασης μαζί με
        // Κύρια διαφάνεια
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στο
        // Προοριστική παρουσίαση
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στο
        // Προοριστική παρουσίαση
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος του
        // Συλλογής διαφανειών στην προοριστική παρουσίαση
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κύριων διαφανειών στην // Προοριστική παρουσίαση
        // Αποθήκευση της προοριστικής παρουσίασης στο δίσκο
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Κλωνοποίηση διαφάνειας στο τέλος ενός συγκεκριμένου τμήματος**

Με το Aspose.Slides for .NET, μπορείτε να κλωνοποιήσετε μια διαφάνεια από ένα τμήμα μιας παρουσίασης και να την εισάγετε σε άλλο τμήμα στην ίδια παρουσίαση. Σε αυτή την περίπτωση, πρέπει να χρησιμοποιήσετε τη μέθοδο [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/methods/addclone/index) από το Interface [ISlideCollection].

Αυτός ο κώδικας C# δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε τη κλωνοποιημένη διαφάνεια σε ένα καθορισμένο τμήμα:

```c#
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

## **FAQ**

**Τα σημειώματα ομιλητή και τα σχόλια αξιολογητών κλωνοποιούνται;**

Ναι. Η σελίδα σημειώματος και τα σχόλια αξιολόγησης περιλαμβάνονται στην κλωνοποίηση. Αν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/net/presentation-notes/) μετά την εισαγωγή.

**Πώς διαχειρίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο βιβλίο εργασίας OLE), αυτή η σύνδεση διατηρείται ως [OLE object](/slides/el/net/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, επαληθεύστε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ενημέρωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε την κλωνοποιημένη διαφάνεια σε συγκεκριμένο ευρετήριο διαφάνειας και να τη βάλετε σε επιλεγμένο [section](/slides/el/net/slide-section/). Αν το τμήμα-στόχος δεν υπάρχει, δημιουργήστε το πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια μέσα σε αυτό.