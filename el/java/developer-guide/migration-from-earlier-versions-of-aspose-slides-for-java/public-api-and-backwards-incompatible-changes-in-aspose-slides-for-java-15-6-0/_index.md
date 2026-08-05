---
title: Δημόσιο API και Ασυμβατότητες Πίσω σε Aspose.Slides για Java 15.6.0
linktitle: Aspose.Slides για Java 15.6.0
type: docs
weight: 140
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-για-java-15-6-0-σημειώσεις-κυκλοφορίας/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των καταστροφικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) κλάσεις, μεθόδους, ιδιότητες κ.ο.κ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) που εισήχθησαν με το Aspose.Slides for Java 15.6.0 API.

{{% /alert %}} 
## **Αλλαγές δημόσιου API**
#### **Η υπογραφή του κατασκευαστή com.aspose.slides.DataLabel έχει αλλάξει**
#### **Τα μέλη com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) έχουν χαρακτηριστεί ως Καταργημένα· έχουν εισαχθεί εναλλακτικές**
#### **Η μέθοδος com.aspose.slides.INotesSlideManager.removeNotesSlide() έχει προστεθεί**
#### **Η μέθοδος com.aspose.slides.ISlide.getNotesSlideManager() έχει προστεθεί. Οι μέθοδοι ISlide.getNotesSlide() και ISlide.addNotesSlide() έχουν χαρακτηριστεί ως Καταργημένες**
``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - καταργημένο

// notes = slide.getNotesSlide(); - καταργημένο

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Η μέθοδος getAppVersion() έχει προστεθεί στο com.aspose.slides.IDocumentProperties**
#### **Η μέθοδος remove() έχει προστεθεί στο com.aspose.slides.IComment**
#### **Η μέθοδος ICommentAuthor.Remove έχει προστεθεί για την αφαίρεση του συγγραφέα σχολίων από τη συλλογή**
#### **Οι μέθοδοι clearCustomProperties() και clearBuiltInProperties() έχουν προστεθεί στο com.aspose.slides.IDocumentProperties**
#### **Οι μέθοδοι getBlackWhiteMode(), setBlackWhiteMode(byte) έχουν προστεθεί στο com.aspose.slides.IShape**
Οι μέθοδοι καθορίζουν πώς θα αποτυπώνονται τα σχήματα σε λειτουργία ασπρόμαυρης προβολής. Οι δυνατές τιμές ορίζονται στην κλάση com.aspose.slides.BlackWhiteMode.

|**Τιμή** |**Σημασία** |
| :- | :- |
|Color |Επιστρέφει με κανονικό χρώμα |
|Automatic |Επιστρέφει με αυτόματο χρώμα |
|Gray |Επιστρέφει με γκριχρώμα |
|LightGray |Επιστρέφει με ανοιχτό γκριχρώμα |
|InverseGray |Επιστρέφει με αντίστροφο γκριχρώμα |
|GrayWhite |Επιστρέφει με γκρι και λευκό χρώμα |
|BlackGray |Επιστρέφει με μαύρο και γκρι χρώμα |
|BlackWhite |Επιστρέφει με μαύρο και λευκό χρώμα |
|Black |Επιστρέφει μόνο με μαύρο χρώμα |
|White |Επιστρέφει με λευκό χρώμα |
|Hidden |Το αντικείμενο δεν αποτυπώνεται |
#### **Οι μέθοδοι removeAt(int), remove(ICommentAuthor) και clear() έχουν προστεθεί στο com.aspose.slides.ICommentAuthorCollection**
Η μέθοδος ICommentAuthorCollection.removeAt(int) προστέθηκε για την αφαίρεση συγγραφέα με το συγκεκριμένο δείκτη. Η μέθοδος ICommentAuthorCollection.remove(ICommentAuthor) προστέθηκε για την αφαίρεση του συγκεκριμένου συγγραφέα από τη συλλογή. Η μέθοδος ICommentAuthorCollection.clear() προστέθηκε για την αφαίρεση όλων των στοιχείων από τη συλλογή.