---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές στο Aspose.Slides για .NET 15.1.0
linktitle: Aspose.Slides για .NET 15.1.0
type: docs
weight: 130
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- μετάβαση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κρίσιμων αλλαγών στο Aspose.Slides για .NET, ώστε να μεταβιβάσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλα τα [προστιθέμενα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) ή [απομακρυσμένα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 15.1.0.

{{% /alert %}} 
## **Δημόσιο API Αλλαγές**
#### **Προστέθηκε η λειτουργικότητα αντικατάστασης γραμματοσειρών**
Προστέθηκε η δυνατότητα αντικατάστασης γραμματοσειράς παγκοσμίως σε όλη την παρουσίαση και προσωρινά για την απόδοση.

Νέα ιδιότητα "FontsManager" της κλάσης Presentation εισήχθη. Η κλάση FontsManager περιλαμβάνει τα ακόλουθα μέλη:

**IFontSubstRuleCollection FontSubstRuleList** Ιδιότητα

Αυτή η συλλογή από αντικείμενα IFontSubstRule χρησιμοποιείται για την αντικατάσταση γραμματοσειρών κατά την απόδοση. Το IFontSubstRule διαθέτει τις ιδιότητες SourceFont και DestFont που υλοποιούν τη διεπαφή IFontData και την ιδιότητα ReplaceFontCondition που επιτρέπει την επιλογή της συνθήκης αντικατάστασης ("WhenInaccessible" ή "Always").

**IFontData[] GetFonts()** Μέθοδος

Χρησιμοποιείται για την ανάκτηση όλων των γραμματοσειρών που χρησιμοποιούνται στην τρέχουσα παρουσίαση.

**ReplaceFont** Μέθοδοι

Χρησιμοποιείται για τη μόνιμη αντικατάσταση μιας γραμματοσειράς στην παρουσίαση.  

Το παρακάτω παράδειγμα δείχνει πώς να αντικαταστήσετε γραμματοσειρά στην παρουσίαση:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ένα άλλο παράδειγμα δείχνει την αντικατάσταση γραμματοσειράς για απόδοση όταν δεν είναι προσπελάσιμο:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Η γραμματοσειρά Arial θα χρησιμοποιηθεί αντί της SomeRareFont όταν δεν είναι προσπελάσιμη

            pres.Slides[0].GetThumbnail();

```