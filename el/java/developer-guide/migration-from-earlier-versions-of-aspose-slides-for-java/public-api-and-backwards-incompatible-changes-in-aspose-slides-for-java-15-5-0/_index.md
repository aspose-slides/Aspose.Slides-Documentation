---
title: Δημόσιο API και Ασυμβατότητες Πίσω Συμβατότητας στο Aspose.Slides για Java 15.5.0
linktitle: Aspose.Slides για Java 15.5.0
type: docs
weight: 130
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- μετάβαση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των μη συμβατών αλλαγών στο Aspose.Slides για Java ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) που εισήχθηκαν με το Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Η κλάση CommonSlideViewProperties και η διεπαφή ICommonSlideViewProperties προστέθηκαν**
Η κλάση com.aspose.slides.CommonSlideViewProperties (και η διεπαφή της com.aspose.slides.ICommonSlideViewProperties) αντιπροσωπεύει τις κοινές ιδιότητες προβολής διαφάνειας (αυτή τη στιγμή επιλογές κλίμακας προβολής).
### **Οι μέθοδοι IAxis.getLabelOffset(), setLabelOffset(int) προστέθηκαν**
Οι μέθοδοι IAxis.getLabelOffset(), setLabelOffset(int) επιτρέπουν την ανάκτηση και τον καθορισμό της απόστασης των ετικετών από τον άξονα. Εφαρμόζονται σε άξονα κατηγορίας ή ημερομηνίας.
### **Οι μέθοδοι IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) προστέθηκαν**
Οι μέθοδοι getAutofitType(), setAutofitType(/**TextAutofitType**/byte) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτής της τιμής μπορεί να έχει συγκεκριμένη επίδραση μόνο σε αυτά τα τμήματα διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει αποτέλεσμα στην απόδοση).
### **Οι μέθοδοι IChartTextBlockFormat.getWrapText(), setWrapText(byte) προστέθηκαν**
Οι μέθοδοι getWrapText(), setWrapText(/**NullableBool**/byte) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτής της τιμής μπορεί να έχει συγκεκριμένη επίδραση μόνο σε αυτά τα τμήματα διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2007/2013).
### **Οι μέθοδοι για τη διαχείριση περιθωρίων προστέθηκαν στη IChartTextBlockFormat**
Οι μέθοδοι getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() και setMarginBottom(double) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτών των τιμών μπορεί να έχει συγκεκριμένη επίδραση μόνο σε αυτά τα τμήματα διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει αποτέλεσμα στην απόδοση).
### **Η μέθοδος ViewProperties.getNotesViewProperties() προστέθηκε**
Η ιδιότητα com.aspose.slides.ViewProperties.getNotesViewProperties() προστέθηκε. Λαμβάνει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής σημειώσεων.
### **Η μέθοδος ViewProperties.getSlideViewProperties() προστέθηκε**
Η μέθοδος com.aspose.slides.ViewProperties.getSlideViewProperties() προστέθηκε. Λαμβάνει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής διαφάνειας.