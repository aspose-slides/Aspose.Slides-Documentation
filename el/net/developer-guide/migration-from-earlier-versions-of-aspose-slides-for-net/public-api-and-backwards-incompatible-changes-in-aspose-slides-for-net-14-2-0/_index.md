---
title: Δημόσιο API και Αλλαγές Μη Συμβατότητας Πίσω στο Aspose.Slides για .NET 14.2.0
linktitle: Aspose.Slides για .NET 14.2.0
type: docs
weight: 40
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- μετάβαση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
## **Δημόσιο API και Αλλαγές Μη Συμβατότητας Πίσω**
{{% alert color="info" %}} 

Κάναμε κάποιες αλλαγές στο API του Aspose.Slides για .NET 14.2.0. Ορισμένες ιδιότητες και μέθοδοι έχουν αφαιρεθεί και άλλες έχουν μεταφερθεί σε άλλο namespace.

{{% /alert %}} 
### **Μέθοδοι Aspose.Slides.IPresentation.Write(…) Αφαιρέθηκαν**
Αυτές οι μέθοδοι έγραφαν αντικείμενα Presentation μόνο σε αρχείο μορφής PPTX. Στο νέο API, η κλάση Presentation χρησιμοποιείται για εργασία με όλες τις μορφές. Είναι δυνατόν να χρησιμοποιηθεί η μέθοδος Presentation.Save(…) για να αποθηκευτούν τα αντικείμενα Presentation σε όλες τις υποστηριζόμενες μορφές.
### **Κλάσεις Σχετικές με Τα Στυλ Θέματος Μεταφέρθηκαν στο Namespace Aspose.Slides.Theme**
Οι παρακάτω κλάσεις έχουν μεταφερθεί από το namespace Aspose.Slides στο namespace Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Αλλαγές από το Aspose.Slides για .NET 8.X.0**
Τα χαρακτηριστικά του Aspose.Slides για .NET 8.4 προστέθηκαν στο Aspose.Slides για .NET 14.2.0