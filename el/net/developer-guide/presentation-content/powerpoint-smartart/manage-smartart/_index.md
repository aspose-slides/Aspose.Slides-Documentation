---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint στο .NET
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/net/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργάνωσης
- Διάγραμμα οργάνωσης με εικόνα
- PowerPoint
- Παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για .NET, χρησιμοποιώντας σαφείς παραδείγματα κώδικα C# που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφάνειων."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides for .NET, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να εξετάσετε κρυφούς κόμβους, να ρυθμίσετε διατάξεις διαγράμματος οργάνωσης και να δημιουργήσετε διαγράμματα οργάνωσης με εικόνα.

## **Ανάκτηση κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), στη συνέχεια διαβάστε το [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) που επιστρέφεται από το [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως το πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Αλλαγή τύπου διάταξης ενός αντικειμένου SmartArt**

Η διάταξη του SmartArt ελέγχει πώς διευθετούνται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, την αλλάζει σε τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) μετρώνται σε σημεία. Ορίστε το [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) για να αλλάξετε τη διάταξη.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Έλεγχος εάν ένας κόμβος SmartArt είναι κρυφός**

Το [ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) υποδεικνύει εάν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` και ελέγχει την κρυφή κατάσταση του προστιθέμενου κόμβου. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυφός και αποθηκεύει το διάγραμμα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Ανάκτηση ή ορισμός της διάταξης διαγράμματος οργάνωσης**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη διαγράμματος οργάνωσης, το [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) ορίζει πώς οι θυγατρικοί κόμβοι διευθετούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τους θυγατρικούς κόμβους να κρέμονται από την αριστερή, τη δεξιά ή και τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα οργάνωσης και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Ο μηδενικός δείκτης `0` επιλέγει τον πρώτο κορυφαίο κόμβο· οι θυγατρικοί του κόμβοι χρησιμοποιούν την επιλεγμένη διευθέτηση. Η τροποποιημένη παρουσίαση αποθηκεύεται μετά.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Δημιουργία διαγράμματος οργάνωσης με εικόνα**

Ένα διάγραμμα οργάνωσης με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευτικά θέσης εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με δεσμευτικά θέσης εικόνας· δεν γεμίζει τα δεσμευτικά θέσης με εικόνες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τη μοντέρνα ενημέρωση μιας υπάρχουσας παρουσίασης, μπορεί να χρειαστεί να ενημερώσετε ένα διάγραμμα οργάνωσης που δημιουργήθηκε αρχικά στο PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλιά διαγράμματα ως αντικείμενα [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Χρησιμοποιήστε το [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων, ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρέσει το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό με το [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) για να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλιά διαγράμματα σε έναν πίνακα πριν τα μετατρέψετε, ώστε η προσθήκη και η αφαίρεση σχημάτων να μην διακοπεί η επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπέντων παλαιών διαγραμμάτων, χωρίς να παραμείνουν τα αρχικά διαγράμματα. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση τους.

## **FAQ**

**Υποστηρίζει το SmartArt αντικατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η ιδιότητα [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/net/shape-manipulations/) με το [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/net/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Απεικόνιση της διαφάνειας](/slides/el/net/convert-powerpoint-to-png/) ή ολόκληρης της παρουσίασης σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt στη διαφάνεια εάν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) ή [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) στο σχήμα SmartArt, αναζητήστε αυτήν την τιμή στο [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).