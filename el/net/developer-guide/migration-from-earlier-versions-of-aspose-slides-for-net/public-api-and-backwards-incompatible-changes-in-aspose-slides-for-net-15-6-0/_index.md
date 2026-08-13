---
title: Δημόσιο API και Αλλαγές που Δεν Συμβαδίζουν Πίσω στο Aspose.Slides για .NET 15.6.0
linktitle: Aspose.Slides για .NET 15.6.0
type: docs
weight: 170
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Επισκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακόπτουν τη συμβατότητα στο Aspose.Slides για .NET, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ή [αφαιρεμένες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Public API Changes**
#### **Η Υπογραφή Κατασκευής του DataLabel Έχει Αλλαγεί**
Η υπογραφή του κατασκευαστή DataLabel έχει αλλάξει:
παλιό: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
νέο: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Οι Μέθοδοι IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Έχουν Σημανθεί Ως Παρωχημένες και Έχουν Εισαχθεί Αντικαταστάτες.**
Η ιδιότητα IDocumentProperties.Count και οι μέθοδοι IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) έχουν σηματοδοτηθεί ως παρωχημένες. Η ιδιότητα IDocumentProperties.CountOfCustomProperties και οι μέθοδοι IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) προστέθηκαν αντίγ

#### **Η Μέθοδος INotesSlideManager.RemoveNotesSlide() Προστέθηκε**
Η μέθοδος INotesSlideManager.RemoveNotesSlide() προστέθηκε για την αφαίρεση της διαφάνειας σημειώσεων μιας διαφάνειας.
#### **Η Μέθοδος Remove Προστέθηκε στο IComment**
Η μέθοδος IComment.Remove προστέθηκε για την αφαίρεση σχολίου από τη συλλογή.
#### **Η Μέθοδος Remove Προστέθηκε στο ICommentAuthor**
Η μέθοδος ICommentAuthor.Remove προστέθηκε για την αφαίρεση του συγγραφέα σχολίων από τη συλλογή.
#### **Οι Μέθοδοι ClearCustomProperties και ClearBuiltInProperties Προστέθηκαν στο IDocumentProperties**
Η μέθοδος IDocumentProperties.ClearCustomProperties προστέθηκε για την αφαίρεση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου.
Η μέθοδος IDocumentProperties.ClearBuiltInProperties προστέθηκε για την αφαίρεση και επαναφορά των προεπιλεγμένων τιμών όλων των ενσωματωμένων ιδιοτήτων εγγράφου (Company, Subject, Author κ.λπ.).
#### **Οι Μέθοδοι RemoveAt, Remove και Clear Προστέθηκαν στο ICommentAuthorCollection**
Η μέθοδος ICommentAuthorCollection.RemoveAt προστέθηκε για την αφαίρεση συγγραφέα με συγκεκριμένο δείκτη.
Η μέθοδος ICommentAuthorCollection.Remove προστέθηκε για την αφαίρεση συγκεκριμένου συγγραφέα από τη συλλογή.
Η μέθοδος ICommentAuthorCollection.Clear προστέθηκε για την αφαίρεση όλων των στοιχείων από τη συλλογή.
#### **Η Ιδιότητα AppVersion Προστέθηκε στο IDocumentProperties**
Η ιδιότητα IDocumentProperties.AppVersion προστέθηκε για την ανάκτηση της ενσωματωμένης ιδιότητας εγγράφου που αντιπροσωπεύει εσωτερικούς αριθμούς έκδοσης που χρησιμοποιήθηκαν από τη Microsoft κατά την ανάπτυξη.
#### **Η Ιδιότητα BlackWhiteMode Προστέθηκε στο IShape και στο Shape**
Η ιδιότητα BlackWhiteMode προστέθηκε στο IShape και στο Shape.

Αυτή η ιδιότητα καθορίζει πώς θα αποδοθεί ένα σχήμα σε λειτουργία ασπρόμαυρης προβολής.

|**Τιμή** |**Σημασία** |
| :- | :- |
|Color |Απόδοση με φυσικά χρώματα |
|Automatic |Απόδοση με αυτόματη χρωματισμό |
|Gray |Απόδοση με γκρι χρώματα |
|LightGray |Απόδοση με ανοιχτό γκρι χρώματα |
|InverseGray |Απόδοση με αντίστροφο γκρι χρώματα |
|GrayWhite |Απόδοση με γκρι και λευκό χρώμα |
|BlackGray |Απόδοση με μαύρο και γκρι χρώματα |
|BlackWhite |Απόδοση με μαύρο και λευκό χρώματα |
|Black |Απόδοση μόνο με μαύρο χρώμα |
|White |Απόδοση με λευκό χρώμα |
|Hidden |Μη απόδοση |
|NotDefined|σημαίνει ότι η ιδιότητα δεν έχει οριστεί|
#### **Ιδιότητα ISlide.NotesSlideManager Προστέθηκε. Η Ιδιότητα ISlide.NotesSlide και η Μέθοδος ISlide.AddNotesSlide() Σημειώθηκαν Ως Παρωχημένες.**
Τα μέλη ISlide.NotesSlide και ISlide.AddNotesSlide() σημειώθηκαν ως παρωχημένα. Χρησιμοποιήστε τη νέα ιδιότητα ISlide.NotesSlideManager.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - παρωχημένο
    // notes = slide.NotesSlide; - παρωχημένο

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```