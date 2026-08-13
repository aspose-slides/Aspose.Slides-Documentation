---
title: Δημόσιο API και Μη Συμβατές Μεταβολές στην Aspose.Slides για .NET 15.1.0
linktitle: Aspose.Slides για .NET 15.1.0
type: docs
weight: 130
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- μετανάστευση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των μη συμβατών αλλαγών στην Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) κλάσεις, μεθόδους, ιδιότητες κ.ά., και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Δημόσιο API Αλλαγές**
#### **Η Λειτουργικότητα Υποκατάστασης Γραμματοσειρών Προστέθηκε**
Έχει προστεθεί η δυνατότητα αντικατάστασης γραμματοσειράς παγκοσμίως σε όλη την παρουσίαση και προσωρινά για απόδοση.

Εισήχθη νέα ιδιότητα "FontsManager" της κλάσης Presentation. Η κλάση FontsManager έχει τα ακόλουθα μέλη:

**IFontSubstRuleCollection FontSubstRuleList** Ιδιότητα

Αυτή η συλλογή των αντικειμένων IFontSubstRule χρησιμοποιείται για την υποκατάσταση γραμματοσειρών κατά την απόδοση. Το IFontSubstRule διαθέτει τις ιδιότητες SourceFont και DestFont που υλοποιούν τη διεπαφή IFontData και την ιδιότητα ReplaceFontCondition που επιτρέπει την επιλογή συνθήκης αντικατάστασης ("WhenInaccessible" ή "Always").

**IFontData[] GetFonts()** Μέθοδος

Χρησιμοποιείται για την ανάκτηση όλων των γραμματοσειρών που χρησιμοποιούνται στην τρέχουσα παρουσίαση.

**ReplaceFont** Μέθοδοι

Χρησιμοποιείται για τη μόνιμη αντικατάσταση γραμματοσειράς στην παρουσίαση.  

Το παρακάτω παράδειγμα δείχνει πώς να αντικαταστήσετε τη γραμματοσειρά στην παρουσίαση:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ένα άλλο παράδειγμα δείχνει την υποκατάσταση γραμματοσειρών για απόδοση όταν δεν είναι προσβάσιμη:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Η γραμματοσειρά Arial θα χρησιμοποιηθεί αντί για την SomeRareFont όταν δεν είναι προσβάσιμη

            pres.Slides[0].GetImage();

```