---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές Πίσω Συμβατότητας στο Aspose.Slides για .NET 15.5.0
linktitle: Aspose.Slides για .NET 15.5.0
type: docs
weight: 160
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιότερη προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των ασυμβίβαστων αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας σε PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλα τα [προστέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 15.5.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Η κλάση CommonSlideViewProperties και η διεπαφή ICommonSlideViewProperties προστέθηκαν**
Η κλάση Aspose.Slides.CommonSlideViewProperties και η διεπαφή Aspose.Slides.ICommonSlideViewProperties αντιπροσωπεύουν κοινές ιδιότητες προβολής διαφάνειας (προς το παρόν επιλογές κλιμάκωσης προβολής).

#### **Η ιδιότητα IAxis.LabelOffset προστέθηκε**
Η ιδιότητα IAxis.LabelOffset καθορίζει την απόσταση των ετικετών από τον άξονα. Εφαρμόζεται σε άξονα κατηγορίας ή ημερομηνίας.

#### **Η ιδιότητα IChartTextBlockFormat.AutofitType προστέθηκε**
Η αλλαγή αυτής της ιδιότητας μπορεί να έχει κάποια επίδραση μόνο για τα εξής μέρη του διαγράμματος: DataLabel και DataLabelFormat (πλήρη υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει επίδραση στην απόδοση).

#### **Η ιδιότητα IChartTextBlockFormat.WrapText προστέθηκε**
Η αλλαγή αυτής της ιδιότητας μπορεί να έχει κάποια επίδραση μόνο για τα εξής μέρη του διαγράμματος: DataLabel και DataLabelFormat (πλήρης υποστήριξη στο PowerPoint 2007/2013).

#### **Προστέθηκαν ιδιότητες περιθωρίου στο IChartTextBlockFormat**
Η αλλαγή αυτών των ιδιοτήτων μπορεί να έχει κάποια επ​επίδραση μόνο για τα εξής μέρη του διαγράμματος: DataLabel και DataLabelFormat (πλήρη υποστήριξη στο PowerPoint 2013· στο PowerPoint 2007 δεν υπάρχει επίδραση στην απόδοση).

#### **Η ιδιότητα ViewProperties.NotesViewProperties προστέθηκε**
Η ιδιότητα Aspose.Slides.ViewProperties.NotesViewProperties προστέθηκε. Καθορίζει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής σημειώσεων.

#### **Η ιδιότητα ViewProperties.SlideViewProperties προστέθηκε**
Η ιδιότητα Aspose.Slides.ViewProperties.SlideViewProperties προστέθηκε. Καθορίζει τις κοινές ιδιότητες προβολής που σχετίζονται με τη λειτουργία προβολής διαφάνειας.