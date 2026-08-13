---
title: Δημόσιο API και Ασυμβατότητες Πίσω Συμβατότητας στο Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κρίσιμων αλλαγών στο Aspose.Slides for Java για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα καταγράφει όλες τις [προστέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) κλάσεις, μεθόδους, ιδιότητες και άλλα, τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) που εισήχθησαν με το Aspose.Slides for Java 15.6.0 API.
{{% /alert %}} 
## **Αλλαγές δημόσιου API**
#### **Η υπογραφή του κατασκευαστή com.aspose.slides.DataLabel άλλαξε**
Η υπογραφή του κατασκευαστή έχει αλλάξει από DataLabel(com.aspose.slides.IChartSeries) σε DataLabel(com.aspose.slides.IChartDataPoint).
#### **Τα μέλη com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) σημειώθηκαν ως Deprecated· εισήχθησαν υποκατάστατα**
Οι μέθοδοι IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) σημειώθηκαν ως Deprecated. Έχουν εισαχθεί οι μέθοδοι IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ως υποκατάστατα.
#### **Η μέθοδος com.aspose.slides.INotesSlideManager.removeNotesSlide() προστέθηκε**
Η μέθοδος com.aspose.slides.INotesSlideManager.RemoveNotesSlide() προστέθηκε για την αφαίρεση της διαφάνειας σημειώσεων μιας διαφάνειας.
#### **Η μέθοδος com.aspose.slides.ISlide.getNotesSlideManager() προστέθηκε· Οι μέθοδοι ISlide.getNotesSlide() και ISlide.addNotesSlide() σημειώθηκαν ως Deprecated**
Οι μέθοδοι ISlide.getNotesSlide() και ISlide.addNotesSlide() σημειώθηκαν ως Deprecated. Χρησιμοποιήστε τη νέα μέθοδο ISlide.getNotesSlideManager() αντ’ αυτού.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - παρωχημένο

    // notes = slide.getNotesSlide(); - παρωχημένο

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Η μέθοδος getAppVersion() προστέθηκε στο com.aspose.slides.IDocumentProperties**
Η μέθοδος com.aspose.slides.IDocumentProperties.getAppVersion() προστέθηκε για την απόκτηση ενσωματωμένης ιδιότητας εγγράφου, η οποία αντιπροσωπεύει εσωτερικούς αριθμούς έκδοσης που χρησιμοποιεί το Microsoft PowerPoint.
#### **Η μέθοδος remove() προστέθηκε στο com.aspose.slides.IComment**
Η μέθοδος com.aspose.slides.IComment.remove() προστέθηκε για την αφαίρεση σχολίου από τη συλλογή.
#### **Η μέθοδος remove() προστέθηκε στο com.aspose.slides.ICommentAuthor**
Η μέθοδος ICommentAuthor.Remove προστέθηκε για την αφαίρεση του συγγραφέα σχολίων από τη συλλογή.
#### **Οι μέθοδοι clearCustomProperties() και clearBuiltInProperties() προστέθηκαν στο com.aspose.slides.IDocumentProperties**
Η μέθοδος com.aspose.slides.IDocumentProperties.clearCustomProperties() προστέθηκε για την αφαίρεση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου.
Η μέθοδος com.aspose.slides.IDocumentProperties.clearBuiltInProperties() προστέθηκε για την αφαίρεση και επαναφορά προεπιλεγμένων τιμών όλων των ενσωματωμένων ιδιοτήτων εγγράφου (Company, Subject, Author κ.λπ.).
#### **Οι μέθοδοι getBlackWhiteMode(), setBlackWhiteMode(byte) προστέθηκαν στο com.aspose.slides.IShape**
Οι μέθοδοι getBlackWhiteMode(), setBlackWhiteMode(byte) προστέθηκαν στο com.aspose.slides.IShape.
Οι μέθοδοι καθορίζουν πώς θα αποδίδεται ένα σχήμα σε λειτουργία ασπρόμαυρης εμφάνισης. Οι πιθανές τιμές καθορίζονται στην κλάση com.aspose.slides.BlackWhiteMode.

|**Τιμή**|**Νόημα**|
| :- | :- |
|Color|Επιστρέφει με κανονικό χρωματισμό|
|Automatic|Επιστρέφει με αυτόματο χρωματισμό|
|Gray|Επιστρέφει με γκρι χρωματισμό|
|LightGray|Επιστρέφει με ανοιχτό γκρι χρωματισμό|
|InverseGray|Επιστρέφει με αντίστροφο γκρι χρωματισμό|
|GrayWhite|Επιστρέφει με γκρι-λευκό χρωματισμό|
|BlackGray|Επιστρέφει με μαύρο-γκρι χρωματισμό|
|BlackWhite|Επιστρέφει με μαύρο-λευκό χρωματισμό|
|Black|Επιστρέφει μόνο με μαύρο χρωματισμό|
|White|Επιστρέφει με λευκό χρωματισμό|
|Hidden|Το αντικείμενο δεν αποδίδεται|

#### **Οι μέθοδοι removeAt(int), remove(ICommentAuthor) και clear() προστέθηκαν στο com.aspose.slides.ICommentAuthorCollection**
Η μέθοδος ICommentAuthorCollection.removeAt(int) προστέθηκε για την αφαίρεση συγγραφέα με συγκεκριμένο δείκτη. Η μέθοδος ICommentAuthorCollection.remove(ICommentAuthor) προστέθηκε για την αφαίρεση του συγκεκριμένου συγγραφέα από τη συλλογή. Η μέθοδος ICommentAuthorCollection.clear() προστέθηκε για την αφαίρεση όλων των αντικειμένων από τη συλλογή.