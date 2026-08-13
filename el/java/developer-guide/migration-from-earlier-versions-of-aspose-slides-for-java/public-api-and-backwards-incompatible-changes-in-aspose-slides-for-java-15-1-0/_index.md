---
title: Δημόσια API και Ασυμβατές Αλλαγές σε Aspose.Slides για Java 15.1.0
linktitle: Aspose.Slides για Java 15.1.0
type: docs
weight: 100
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διασπαστικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα παραθέτει όλες τις προστιθέμενες κλάσεις, μεθόδους, ιδιότητες κλπ, τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) που εισήχθησαν με το Aspose.Slides for Java 15.1.0 API.
{{% /alert %}} {{% alert color="info" %}} 
Υπάρχουν γνωστά προβλήματα με ορισμένα σημεία εικόνας και αντικείμενα WordArt που θα διορθωθούν στο Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Αλλαγές Δημόσιας API**
### **Η λειτουργικότητα αντικατάστασης γραμματοσειρών προστέθηκε**
Η δυνατότητα αντικατάστασης γραμματοσειρών παγκόσμια σε όλη την παρουσίαση και προσωρινά για την απόδοση έχει προστεθεί.

Νέα μέθοδος getFontsManager() της κλάσης Presentation παρουσιάστηκε. Η κλάση FontsManager έχει τα ακόλουθα μέλη:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Αυτή είναι η συλλογή των αντικειμένων IFontSubstRule που χρησιμοποιούνται για την αντικατάσταση γραμματοσειρών κατά την απόδοση. Το IFontSubstRule διαθέτει τις μεθόδους getSourceFont() και getDestFont() που υλοποιούν τη διεπαφή IFontData και τη μέθοδο getReplaceFontCondition() που επιτρέπει την επιλογή της συνθήκης αντικατάστασης ("WhenInaccessible" ή "Always").

**IFontData[] getFonts**() method μπορεί να χρησιμοποιηθεί για να ανακτήσει όλες τις γραμματοσειρές που χρησιμοποιούνται στην τρέχουσα παρουσίαση.

**replaceFont(...)** methods μπορούν να χρησιμοποιηθούν για να αντικαταστήσουν μόνιμα μια γραμματοσειρά σε μια παρουσίαση.

Το παρακάτω παράδειγμα δείχνει πώς να αντικαταστήσετε μια γραμματοσειρά σε μια παρουσίαση:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Ένα άλλο παράδειγμα δείχνει την αντικατάσταση γραμματοσειρών για απόδοση όταν η γραμματοσειρά είναι μη προσβάσιμη:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Η γραμματοσειρά Arial θα χρησιμοποιηθεί αντί της SomeRareFont όταν είναι μη προσβάσιμη.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```