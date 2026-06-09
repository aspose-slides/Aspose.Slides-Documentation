---
title: Δημοσιο API και Αλλαγές που δεν είναι συμβατές με προηγούμενες εκδόσεις στο Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- μετάβαση
- κληρονομικού κώδικα
- σύγχρονο κώδικα
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σπαστικών αλλαγών στο Aspose.Slides for .NET για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
## **Δημόσιο API και Αλλαγές που δεν είναι συμβατές με προηγούμενες εκδόσεις**
{{% alert color="primary" %}} 
Έχουμε κάνει κάποιες αλλαγές στο Aspose.Slides for .NET 14.2.0 API. Ορισμένες ιδιότητες και μέθοδοι έχουν αφαιρεθεί και κάποιες έχουν μεταφερθεί σε άλλο namespace.
{{% /alert %}} 
### **Μέθοδοι Aspose.Slides.IPresentation.Write(…) Αφαιρέθηκαν**
Αυτές οι μέθοδοι έγραφαν αντικείμενα Presentation μόνο σε αρχείο μορφής PPTX. Στο νέο API, η κλάση Presentation προορίζεται για εργασία με όλες τις μορφές. Είναι δυνατόν να χρησιμοποιηθούν οι μέθοδοι Presentation.Save(…) για αποθήκευση των αντικειμένων Presentation σε όλες τις υποστηριζόμενες μορφές.
### **Κλάσεις σχετικές με Στυλ Θέματος Μεταφέρθηκαν στο Namespace Aspose.Slides.Theme**
Οι παρακάτω κλάσεις έχουν μετακινηθεί από το namespace Aspose.Slides στο namespace Aspose.Slides.Theme.

- Τύποι ColorScheme
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
### **Αλλαγές από Aspose.Slides for .NET 8.X.0**
Οι δυνατότητες Aspose.Slides for .NET 8.4 προστέθηκαν στο Aspose.Slides for .NET 14.2.0