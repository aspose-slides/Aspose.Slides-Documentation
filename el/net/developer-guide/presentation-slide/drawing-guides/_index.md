---
title: Διαχείριση Γραμμών Οδηγών σε Παρουσιάσεις στο .NET
linktitle: Γραμμές Οδηγών
type: docs
weight: 85
url: /el/net/drawing-guides/
keywords:
- οδηγός σχεδίασης
- οριζόντια οδηγία
- κάθετη οδηγία
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- master διαφάνειας
- διαφάνεια διάταξης
- master σημειώσεων
- master φυλλαδίου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθέστε, αποκτήστε πρόσβαση και διαγράψτε οριζόντιες και κάθετες γραμμές οδηγών σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Οι γραμμές οδηγίες είναι ρυθμιζόμενες οριζόντιες και κάθετες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα σταθερά κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα χειροκίνητα: η εφαρμογή μπορεί να αποθηκεύσει τα ίδια βοηθήματα ευθυγράμμισης που πρέπει να ακολουθούν οι συγγραφείς κατά την προσθήκη ή τη μετακίνηση περιεχομένου.

Οι γραμμές οδηγίες είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή στην παραγόμενη έξοδο. Aspose.Slides for .NET τις εκθέτει μέσω της διεπαφής [IDrawingGuidesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguidescollection/). Μια οδηγία αντιπροσωπεύεται από το [IDrawingGuide](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguide/) και έχει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε points από την επάνω αριστερή γωνία της αντίστοιχης διαφάνειας ή του master. Μια κάθετη οδηγία χρησιμοποιεί οριζόντιο συντεταγμένο, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μια οριζόντια οδηγία χρησιμοποιεί κατακόρυφο συντεταγμένο, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Οδηγών στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/el/net/aspose.slides/icommonslideviewproperties/drawingguides/) για να διαχειριστείτε τις οδηγίες που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguidescollection/add/) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/orientation/) και μια θέση σε points.

Το παρακάτω παράδειγμα προσθέτει μια κάθετη οδηγία στα δεξιά του κέντρου της διαφάνειας και μια οριζόντια οδηγία κάτω από αυτήν:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση στις Γραφικές Οδηγίες**

Η ιδιότητα [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguidescollection/count/) και ο δείκτης παρέχουν πρόσβαση στις υπάρχουσες οδηγίες. Οι ιδιότητες [IDrawingGuide.Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguide/position/) και [IDrawingGuide.Color](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguide/color/) μπορούν να διαβαστούν ή να τροποποιηθούν.

Το παρακάτω παράδειγμα διαβάζει τις οδηγίες προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Προσθήκη Οδηγών σε Master και Διαφάνειες Διάταξης**

Ένας master διαφάνειας και κάθε μία από τις διαφάνειες διάταξής του μπορούν να έχουν τις δικές τους συλλογές γραμμών οδηγίας. Χρησιμοποιήστε το [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/drawingguides/) για έναν master διαφάνειας και το [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/drawingguides/) για μια διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μια κάθετη οδηγία στην πρώτη master διαφάνειας και μια οριζόντια οδηγία στην πρώτη διαφάνεια διάταξης:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Οδηγών σε Master Σημειώσεων και Χειροδειγμάτων**

Οι master σημειώσεων και οι master χειροδειγμάτων υποστηρίζουν επίσης γραμμές οδηγίας. Χρησιμοποιήστε τα [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslide/drawingguides/) και [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslide/drawingguides/) για να έχετε πρόσβαση στις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει έναν από αυτούς τους master, η μέθοδος [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ή η [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) δημιουργεί τον προεπιλεγμένο master και τον επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μια οριζόντια οδηγία σε έναν master σημειώσεων και μια κάθετη οδηγία σε έναν master χειροδειγμάτων:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Καθαρισμός Γραφικών Οδηγών**

Καλέστε το [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides/idrawingguidescollection/clear/) για να αφαιρέσετε κάθε οδηγία από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τις οδηγίες που αποθηκεύονται σε άλλο επίπεδο.

Το παρακάτω παράδειγμα καθαρίζει τις οδηγίες προβολής διαφάνειας και όλες τις οδηγίες στους master διαφανειών, τις διαφάνειες διάταξης, τον master σημειώσεων και τον master χειροδειγμάτων χωρίς να δημιουργήσει ελλιπείς master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Εμφανίζονται οι γραμμές οδηγίες σε παρουσίαση ή εξαγώμενες εικόνες;**

Όχι. Οι γραμμές οδηγίες είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί μια γραμμή οδηγία να προστεθεί άμεσα σε μια κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικών διαφανειών αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγών είναι διαθέσιμες για master διαφάνειες, διαφάνειες διάταξης, master σημειώσεων και master χειροδειγμάτων.

**Ποια μονάδα χρησιμοποιείται για τις θέσεις των οδηγών;**

Οι θέσεις καθορίζονται σε points, όπου 72 points ισοδυναμούν με ένα ίντσα. Οι κατακόρυφες θέσεις μετριούνται από την αριστερή άκρη, και οι οριζόντιες θέσεις μετριούνται από την επάνω άκρη.

**Ο καθαρισμός των γραμμών οδηγίας αφαιρεί σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος `Clear` αφαιρεί μόνο τις οδηγίες στη συγκεκριμένη συλλογή. Τα σχήματα και το υπόλοιπο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.