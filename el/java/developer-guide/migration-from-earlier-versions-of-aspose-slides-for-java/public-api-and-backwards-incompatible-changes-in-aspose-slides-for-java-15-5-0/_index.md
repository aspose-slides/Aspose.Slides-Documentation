---
title: Δημόσιο API και μη συμβατές αλλαγές στο Aspose.Slides για Java 15.5.0
linktitle: Aspose.Slides για Java 15.5.0
type: docs
weight: 130
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Επισκόπηση των ενημερώσεων του δημόσιου API και των breaking αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενα](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) που εισήχθησαν με το API του Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Η κλάση CommonSlideViewProperties και η διεπαφή ICommonSlideViewProperties προστέθηκαν**
Η κλάση com.aspose.slides.CommonSlideViewProperties (και η διεπαφή της com.aspose.slides.ICommonSlideViewProperties) αντιπροσωπεύει τις κοινές ιδιότητες προβολής διαφάνειας (προς το παρόν επιλογές κλίμακας προβολής).
### **Οι μέθοδοι IAxis.getLabelOffset(), setLabelOffset(int) προστέθηκαν**
Οι μέθοδοι IAxis.getLabelOffset(), setLabelOffset(int) επιτρέπουν την ανάκτηση και τον καθορισμό της απόστασης των ετικετών από τον άξονα. Εφαρμόζεται σε άξονα κατηγορίας ή ημερομηνίας.
### **Οι μέθοδοι IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) προστέθηκαν**
Οι μέθοδοι getAutofitType(), setAutofitType(/**TextAutofitType**/byte) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτής της τιμής μπορεί να έχει ορισμένη επίδραση μόνο σε αυτά τα τμήματα του διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει αποτέλεσμα στην απόδοση).
### **Οι μέθοδοι IChartTextBlockFormat.getWrapText(), setWrapText(byte) προστέθηκαν**
Οι μέθοδοι getWrapText(), setWrapText(/**NullableBool**/byte) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτής της τιμής μπορεί να έχει ορισμένη επίδραση μόνο σε αυτά τα τμήματα του διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2007/2013).
### **Οι μέθοδοι διαχείρισης περιθωρίων προστέθηκαν στη IChartTextBlockFormat**
Οι μέθοδοι getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() και setMarginBottom(double) προστέθηκαν στη διεπαφή com.aspose.slides.IChartTextBlockFormat. Η αλλαγή αυτών των τιμών μπορεί να έχει ορισμένη επίδραση μόνο σε αυτά τα τμήματα του διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει αποτέλεσμα στην απόδοση).
### **Η μέθοδος ViewProperties.getNotesViewProperties() προστέθηκε**
Η ιδιότητα com.aspose.slides.ViewProperties.getNotesViewProperties() προστέθηκε. Επιστρέφει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής σημειώσεων.
### **Η μέθοδος ViewProperties.getSlideViewProperties() προστέθηκε**
Η μέθοδος com.aspose.slides.ViewProperties.getSlideViewProperties() προστέθηκε. Επιστρέφει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής διαφάνειας.