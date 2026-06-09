---
title: Βελτιώστε τις παρουσιάσεις σας με AutoFit σε Java
linktitle: Ρυθμίσεις Autofit
type: docs
weight: 30
url: /el/java/manage-autofit-settings/
keywords:
- πλαίσιο κειμένου
- αυτόματη προσαρμογή
- μη αυτόματη προσαρμογή
- προσαρμογή κειμένου
- σμίκρυνση κειμένου
- αναδίπλωση κειμένου
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις ρυθμίσεις AutoFit στο Aspose.Slides για Java ώστε να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την ευαναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πεδίο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πεδίο κειμένου—αυτόματα αλλάζει το μέγεθος του πεδίου κειμένου ώστε το κείμενό του να χωράει πάντοτε. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πεδίο κειμένου γίνει πιο μακρύ ή μεγαλύτερο, το PowerPoint αυτόματα μεγενθύνει το πεδίο κειμένου—αυξάνει το ύψος του—για να χωρέσει περισσότερο κείμενο. 
* Όταν το κείμενο στο πεδίο κειμένου γίνει πιο σύντομο ή μικρότερο, το PowerPoint αυτόματα μειώνει το πεδίο κειμένου—μειώνει το ύψος του—για να αφαιρέσει περιττό χώρο. 

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρους ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πεδίο κειμένου: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Το Aspose.Slides for Java παρέχει παρόμοιες επιλογές—ορισμένες ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)—που σας επιτρέπουν να ελέγχετε τη συμπεριφορά autofit για πεδία κειμένου σε παρουσιάσεις. 

## **Αλλαγή μεγέθους σχήματος ώστε να ταιριάζει το κείμενο**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές στο κείμενο, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)) σε `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ότι ένα κείμενο πρέπει πάντα να ταιριάζει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αν το κείμενο γίνει πιο μακρύ ή μεγαλύτερο, το πεδίο κειμένου θα αλλάξει αυτόματα το μέγεθός του (αύξηση του ύψους) ώστε να χωράει όλο το κείμενο. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο. 

## **Μην εφαρμόζετε αυτόματη προσαρμογή**

Αν θέλετε ένα πεδίο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο που περιέχει, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)) σε `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ότι ένα πεδίο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του, υλοξυδεί (υπέρχει). 

## **Σμίκρυνση κειμένου κατά την υπερχείλιση**

Αν ένα κείμενο γίνει πολύ μακρύ για το πλαίσιό του, μέσω της επιλογής **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και το διάστιχο του κειμένου πρέπει να μειωθούν ώστε να χωράει στο πλαίσιο. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)) σε `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε ότι ένα κείμενο πρέπει να σμικρύνει κατά την υπερχείλιση σε μια παρουσίαση PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του.
{{% /alert %}}

## **Αναδίπλωση κειμένου**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται μέσα σε αυτό όταν το κείμενο ξεπεράσει το όριο του σχήματος (μόνο το πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτή τη ρύθμιση, πρέπει να θέσετε την ιδιότητα [WrapText](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat#getWrapText--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/TextFrameFormat)) σε `true`. 

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Αν θέσετε την ιδιότητα `WrapText` σε `False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει πιο μακρύ από το πλάτος του σχήματος, το κείμενο εκτείνεται πέρα από τα όρια του σχήματος σε μία μόνο γραμμή. 
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Τα εσωτερικά περιθώρια (padding) μειώνουν την διαθέσιμη περιοχή για κείμενο, έτσι το AutoFit ενεργοποιείται νωρίτερα—σμικρύνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος νωρίτερα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με τα χειροκίνητα και “soft” διαλείμματα γραμμής;**

Τα υποχρεωτικά διαλείμματα παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και το διάστιχο γύρω τους. Η αφαίρεση περιττών διαλειμμάτων συχνά μειώνει το πόσο έντονα χρειάζεται να σμικρύνει το AutoFit το κείμενο.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η ενεργοποίηση αντικατάστασης γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η αντικατάσταση με μια γραμματοσειρά που έχει διαφορετικές μετρικές glyph αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και την αναδίπλωση γραμμών. Μετά από κάθε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.