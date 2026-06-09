---
title: Δημόσιο API και Αλλαγές που Δεν Είναι Συμβατές προς τα Πίσω στο Aspose.Slides for .NET 15.6.0
linktitle: Aspose.Slides για .NET 15.6.0
type: docs
weight: 170
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- μετάβαση
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides for .NET για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) κλάσεις, μεθόδους, ιδιότητες κλπ, και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Η υπογραφή του κατασκευαστή DataLabel έχει αλλάξει**
Η υπογραφή του κατασκευαστή DataLabel έχει αλλάξει:
παλιά: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
τώρα: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Τα μέλη IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) έχουν χαρακτηριστεί ως παρωχημένα και έχουν εισαχθεί οι αντίστοιχες αντικαταστάσεις.**
Η ιδιότητα IDocumentProperties.Count και οι μέθοδοι IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) έχουν χαρακτηριστεί ως παρωχημένα. Η ιδιότητα IDocumentProperties.CountOfCustomProperties και οι μέθοδοι IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) έχουν προστεθεί αντί αυτού.
#### **Η μέθοδος INotesSlideManager.RemoveNotesSlide() προστέθηκε**
Η μέθοδος INotesSlideManager.RemoveNotesSlide() προστέθηκε για την αφαίρεση της διαφάνειας σημειώσεων κάποιας διαφάνειας.
#### **Η μέθοδος Remove προστέθηκε στο IComment**
Η μέθοδος IComment.Remove προστέθηκε για την αφαίρεση σχολίου από τη συλλογή.
#### **Η μέθοδος Remove προστέθηκε στο ICommentAuthor**
Η μέθοδος ICommentAuthor.Remove προστέθηκε για την αφαίρεση του δημιουργού σχολίων από τη συλλογή.
#### **Οι μέθοδοι ClearCustomProperties και ClearBuiltInProperties προστέθηκαν στο IDocumentProperties**
Η μέθοδος IDocumentProperties.ClearCustomProperties προστέθηκε για την αφαίρεση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου.
Η μέθοδος IDocumentProperties.ClearBuiltInProperties προστέθηκε για την αφαίρεση και ορισμό προεπιλεγμένων τιμών για όλες τις ενσωματωμένες ιδιότητες εγγράφου (Company, Subject, Author κλπ).
#### **Οι μέθοδοι RemoveAt, Remove και Clear προστέθηκαν στο ICommentAuthorCollection**
Η μέθοδος ICommentAuthorCollection.RemoveAt προστέθηκε για την αφαίρεση δημιουργού με συγκεκριμένο δείκτη.
Η μέθοδος ICommentAuthorCollection.Remove προστέθηκε για την αφαίρεση του συγκεκριμένου δημιουργού από τη συλλογή.
Η μέθοδος ICommentAuthorCollection.Clear προστέθηκε για την αφαίρεση όλων των στοιχείων από τη συλλογή.
#### **Η ιδιότητα AppVersion προστέθηκε στο IDocumentProperties**
Η ιδιότητα IDocumentProperties.AppVersion προστέθηκε για λήψη της ενσωματωμένης ιδιότητας εγγράφου που αντιπροσωπεύει εσωτερικούς αριθμούς έκδοσης που χρησιμοποιούνται από τη Microsoft κατά την ανάπτυξη.
#### **Η ιδιότητα BlackWhiteMode προστέθηκε στο IShape και στο Shape**
Η ιδιότητα BlackWhiteMode προστέθηκε στο IShape και στο Shape.

Αυτή η ιδιότητα καθορίζει πώς θα αποδίδεται ένα σχήμα σε λειτουργία ασπρόμαυρης προβολής.

|**Τιμή** |**Σημασία** |
| :- | :- |
|Color |Απόδοση με κανονικό χρώμα |
|Automatic |Απόδοση με αυτόματο χρώμα |
|Gray |Απόδοση με γκρι χρώμα |
|LightGray |Απόδοση με ανοιχτό γκρι χρώμα |
|InverseGray |Απόδοση με αντίστροφο γκρι χρώμα |
|GrayWhite |Απόδοση με γκρι και λευκό χρώμα |
|BlackGray |Απόδοση με μαύρο και γκρι χρώμα |
|BlackWhite |Απόδοση με μαύρο και λευκό χρώμα |
|Black |Απόδοση μόνο με μαύρο χρώμα |
|White |Απόδοση με λευκό χρώμα |
|Hidden |Μη απόδοση |
|NotDefined |Σημαίνει ότι η ιδιότητα δεν έχει οριστεί|
#### **Η ιδιότητα ISlide.NotesSlideManager προστέθηκε. Η ιδιότητα ISlide.NotesSlide και η μέθοδος ISlide.AddNotesSlide() χαρακτηρίστηκαν ως παρωχημένες.**
Τα μέλη ISlide.NotesSlide, ISlide.AddNotesSlide() χαρακτηρίστηκαν ως παρωχημένα. Χρησιμοποιήστε τη νέα ιδιότητα ISlide.NotesSlideManager αντί αυτού.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - παρωχημένο

// notes = slide.NotesSlide; - παρωχημένο

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```