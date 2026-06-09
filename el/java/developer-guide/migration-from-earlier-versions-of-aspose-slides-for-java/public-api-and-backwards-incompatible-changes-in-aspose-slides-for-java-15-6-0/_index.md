---
title: Δημόσιο API και Αντίστροφες Ασύμβατες Αλλαγές στο Aspose.Slides για Java 15.6.0
linktitle: Aspose.Slides για Java 15.6.0
type: docs
weight: 140
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [changes](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) που εισήχθησαν με το Aspose.Slides for Java 15.6.0 API.

{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
Η υπογραφή του κατασκευαστή έχει αλλάξει από DataLabel(com.aspose.slides.IChartSeries) σε DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Οι μέθοδοι IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) έχουν χαρακτηριστεί ως παρωχημένες. Έχουν εισαχθεί οι μέθοδοι IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ως εναλλακτικές.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Η μέθοδος com.aspose.slides.INotesSlideManager.RemoveNotesSlide() έχει προστεθεί για την αφαίρεση της σημειωτικής διαφάνειας κάποιας διαφάνειας.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Οι μέθοδοι ISSlide.getNotesSlide() και ISlide.addNotesSlide() έχουν χαρακτηριστεί ως παρωχημένες. Χρησιμοποιήστε τη νέα μέθοδο ISlide.getNotesSlideManager() αντί αυτού.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - παρωχημένο

// notes = slide.getNotesSlide(); - παρωχημένο

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Η μέθοδος com.aspose.slides.IDocumentProperties.getAppVersion() έχει προστεθεί ώστε να λαμβάνει ενσωματωμένη ιδιότητα εγγράφου, η οποία αντιπροσωπεύει τους εσωτερικούς αριθμούς έκδοσης που χρησιμοποιεί το Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
Η μέθοδος com.aspose.slides.IComment.remove() έχει προστεθεί για την αφαίρεση σχολίου από τη συλλογή.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Η μέθοδος ICommentAuthor.Remove έχει προστεθεί για την αφαίρεση του δημιουργού των σχολίων από τη συλλογή.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Η μέθοδος com.aspose.slides.IDocumentProperties.clearCustomProperties() έχει προστεθεί για την αφαίρεση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου.
Η μέθοδος com.aspose.slides.IDocumentProperties.clearBuiltInProperties() έχει προστεθεί για την αφαίρεση και ορισμό προεπιλεγμένων τιμών για όλες τις ενσωματωμένες ιδιότητες εγγράφου (Company, Subject, Author κ.λπ.).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Οι μέθοδοι getBlackWhiteMode(), setBlackWhiteMode(byte) έχουν προστεθεί στην com.aspose.slides.IShape.
Οι μέθοδοι καθορίζουν πώς θα αποτυπώνεται ένα σχήμα σε λειτουργία ασπρόμαυρου προβολής. Οι δυνατές τιμές καθορίζονται στην κλάση com.aspose.slides.BlackWhiteMode.

|**Τιμή**|**Σημασία**|
| :- | :- |
|Χρώμα|Επιστρέφει με κανονικό χρώμα|
|Αυτόματο|Επιστρέφει με αυτόματο χρώμα|
|Γκρίζο|Επιστρέφει με γκρίζο χρώμα|
|Ανοιχτό Γκρίο|Επιστρέφει με ανοιχτό γκρίζο χρώμα|
|Αντίστροφο Γκρίο|Επιστρέφει με αντίστροφο γκρίζο χρώμα|
|Γκρίο‑Λευκό|Επιστρέφει με γκρίζο και λευκό χρώμα|
|Μαύρο‑Γκρίο|Επιστρέφει με μαύρο και γκρίζο χρώμα|
|Μαύρο‑Λευκό|Επιστρέφει με μαύρο και λευκό χρώμα|
|Μαύρο|Επιστρέφει μόνο με μαύρο χρώμα|
|Λευκό|Επιστρέφει με λευκό χρώμα|
|Κρυφό|Το αντικείμενο δεν αποτυπώνεται|
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Η μέθοδος ICommentAuthorCollection.removeAt(int) προστέθηκε για την αφαίρεση δημιουργού με συγκεκριμένο δείκτη. Η μέθοδος ICommentAuthorCollection.remove(ICommentAuthor) προστέθηκε για την αφαίρεση συγκεκριμένου δημιουργού από τη συλλογή. Η μέθοδος ICommentAuthorCollection.clear() έχει προστεθεί για την αφαίρεση όλων των στοιχείων από τη συλλογή.