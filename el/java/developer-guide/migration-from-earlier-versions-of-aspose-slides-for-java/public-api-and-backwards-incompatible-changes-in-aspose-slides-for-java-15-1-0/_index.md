---
title: Δημόσιο API και Μη Συμβατές Πίσω Αλλαγές στο Aspose.Slides για Java 15.1.0
linktitle: Aspose.Slides για Java 15.1.0
type: docs
weight: 100
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- μετανάστευση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των καταστροφικών αλλαγών στο Aspose.Slides for Java για την ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παρουσιάζει όλες τις [πρόσθετες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) που εισήχθησαν με το Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Υπάρχουν γνωστά προβλήματα με ορισμένες εικόνες-κουκκίδες και αντικείμενα WordArt που θα διορθωθούν στο Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Αλλαγές δημόσιου API**
### **Η λειτουργικότητα αντικατάστασης γραμματοσειρών προστέθηκε**
Η δυνατότητα αντικατάστασης γραμματοσειρών παγκοσμίως σε όλη την παρουσίαση και προσωρινά κατά τη δημιουργία προστέθηκε.

Εγινε γνωστή η νέα μέθοδος getFontsManager() της κλάσης Presentation. Η κλάση FontsManager έχει τα ακόλουθα μέλη:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Η συλλογή των στιγμιοτύπων IFontSubstRule που χρησιμοποιούνται για την αντικατάσταση γραμματοσειρών κατά τη δημιουργία. Η IFontSubstRule διαθέτει τις μεθόδους getSourceFont() και getDestFont() που υλοποιούν τη διεπαφή IFontData και τη μέθοδο getReplaceFontCondition() που επιτρέπει την επιλογή της προϋπόθεσης αντικατάστασης ("WhenInaccessible" ή "Always").

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.

Οι μέθοδοι **replaceFont(...)** μπορούν να χρησιμοποιηθούν για μόνιμη αντικατάσταση μιας γραμματοσειράς σε μια παρουσίαση. 

Το παρακάτω παράδειγμα δείχνει πώς να αντικαταστήσετε μια γραμματοσειρά σε μια παρουσίαση:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ένα άλλο παράδειγμα δείχνει την αντικατάσταση γραμματοσειρών για τη δημιουργία όταν αυτή δεν είναι προσβάσιμη:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Η γραμματοσειρά Arial θα χρησιμοποιηθεί αντί της SomeRareFont όταν είναι μη προσβάσιμη

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```