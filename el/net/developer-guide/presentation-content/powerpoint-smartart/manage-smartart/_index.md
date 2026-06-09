---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint στο .NET
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/net/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- τύπος διάταξης
- ιδιότητα κρυφής
- διάγραμμα οργάνωσης
- διάγραμμα οργάνωσης με εικόνα
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt του PowerPoint με το Aspose.Slides για .NET, χρησιμοποιώντας σαφή δείγματα κώδικα C# που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για .NET, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυφούς κόμβους, να διαμορφώσετε διατάξεις διαγράμματος οργάνωσης και να δημιουργήσετε διαγράμματα οργάνωσης με εικόνα.

## **Ανάκτηση Κειμένου από Αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το εμφανιζόμενο κείμενο, επαναλάβετε μέσω του [ISmartArt.AllNodes](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartart/allnodes/), στη συνέχεια διαβάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Αλλαγή Τύπου Διάταξης ενός Αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς οι κόμβοι τοποθετούνται και συνδέονται. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Έλεγχος Εάν Ένας Κόμβος SmartArt Είναι Κρυμμένος**

Το [ISmartArtNode.IsHidden](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartartnode/ishidden/) υποδεικνύει εάν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμα και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος. Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` και ελέγχει την κατάσταση κρυψιμου του κόμβου.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Ανάκτηση ή Ορισμός της Διάταξης Διαγράμματος Οργάνωσης**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη διαγράμματος οργάνωσης, το [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) ορίζει πώς οι υποκόμβοι τοποθετούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε οι υποκομμένοι κόμβοι να κρέμονται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/organizationchartlayouttype/). Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα οργάνωσης και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Δημιουργία Διαγράμματος Οργάνωσης με Εικόνα**

Ένα διάγραμμα οργάνωσης με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευτικά θέσεις εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` κατά την προσθήκη του αντικειμένου SmartArt σε μια διαφάνεια.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt καθρεπτισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η ιδιότητα [IsReversed](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartart/isreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει αντιστροφή.

**Πώς μπορώ να αντιγράψω SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/net/shape-manipulations/) με το [ShapeCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/net/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/net/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδει ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή [AlternativeText](https://reference.aspose.com/slides/el/net/aspose.slides/shape/alternativetext/) ή [Name](https://reference.aspose.com/slides/el/net/aspose.slides/shape/name/) στο σχήμα SmartArt, αναζητήστε αυτήν την τιμή στο [Slide.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide/shapes/), και μετά ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartart/).