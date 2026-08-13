---
title: Δημόσιο API και Αντισυμβατές Αλλαγές στο Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
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
description: "Ανασκοπήστε τις ενημερώσεις του δημόσιου API και τις ανατμητικές αλλαγές στο Aspose.Slides for Java για να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα καταγράφει όλα τα [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) ή [removed](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for Java 15.11.0.
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
Οι νέες μέθοδοι getFirstSlideNumber() και setFirstSlideNumber() επιτρέπουν την ανάκτηση ή τον ορισμό του αριθμού της πρώτης διαφάνειας σε μια παρουσίαση.
Όταν καθοριστεί μια νέα τιμή για τον αριθμό της πρώτης διαφάνειας, όλοι οι αριθμοί διαφανειών επαναϋπολογίζονται.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```