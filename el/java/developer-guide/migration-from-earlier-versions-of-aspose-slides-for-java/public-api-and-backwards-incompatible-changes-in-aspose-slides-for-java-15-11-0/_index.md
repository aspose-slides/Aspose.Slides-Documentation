---
title: Δημόσιο API και Αντίστροφες Μη Συμβατές Αλλαγές στο Aspose.Slides για Java 15.11.0
linktitle: Aspose.Slides για Java 15.11.0
type: docs
weight: 190
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση ενημερώσεων του δημόσιου API και ανατρεπτικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταναστεύσετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα λίστα όλα τα προστεμένα ή αφαιρεμένα κλασά, μεθόδους, ιδιότητες κλπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 15.11.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Οι παρωχημένες μέθοδοι στην κλάση com.aspose.slides.DataLabelCollection έχουν διαγραφεί**
Οι παρωχημένες μέθοδοι στην κλάση com.aspose.slides.DataLabelCollection έχουν διαγραφεί:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Οι νέες μέθοδοι getFirstSlideNumber() και setFirstSlideNumber() προστέθηκαν στην κλάση Presentation**
Οι νέες μέθοδοι getFirstSlideNumber() και setFirstSlideNumber() επιτρέπουν την λήψη ή τον ορισμό του αριθμού της πρώτης διαφάνειας σε μια παρουσίαση.
Όταν οριστεί μια νέα τιμή για τον αριθμό της πρώτης διαφάνειας, όλοι οι αριθμοί των διαφανειών επαναυπολογίζονται.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```