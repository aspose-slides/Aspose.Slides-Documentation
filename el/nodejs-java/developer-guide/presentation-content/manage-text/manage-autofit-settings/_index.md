---
title: "Βελτιώστε τις Παρουσιάσεις σας με AutoFit σε JavaScript"
linktitle: "Ρυθμίσεις Autofit"
type: docs
weight: 30
url: /el/nodejs-java/manage-autofit-settings/
keywords:
- "πλαίσιο κειμένου"
- "autofit"
- "μη αυτόματη προσαρμογή"
- "προσαρμογή κειμένου"
- "σμίκρυνση κειμένου"
- "αναδίπλωση κειμένου"
- "αλλαγή μεγέθους σχήματος"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Διαχειριστείτε τις ρυθμίσεις AutoFit στο Aspose.Slides για Node.js ώστε να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο—αυτόματα αλλάζει το μέγεθος του πλαισίου ώστε το κείμενο του να χωρά πάντα. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο γίνεται μεγαλύτερο ή πιο εκτενές, το PowerPoint αυτόματα αυξάνει το ύψος του πλαισίου—αυξάνει το ύψος—για να χωρέσει περισσότερα κείμενα. 
* Όταν το κείμενο στο πλαίσιο γίνεται μικρότερο ή πιο σύντομο, το PowerPoint αυτόματα μειώνει το ύψος του πλαισίου—μειώνει το ύψος—ώστε να εξαλειφθεί η περιττή κενή περιοχή. 

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρους ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Το Aspose.Slides for Node.js via Java παρέχει παρόμοιες επιλογές—μερικές ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) που σας επιτρέπουν να ελέγξετε τη συμπεριφορά autofit για τα πλαίσια κειμένου στις παρουσιάσεις.

## **Resize Shape to Fit Text**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτή τη ρύθμιση, καλέστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) με τιμή `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε ότι ένα κείμενο πρέπει πάντα να χωράει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αν το κείμενο γίνει μακρύτερο ή μεγαλύτερο, το πλαίσιο κειμένου θα αυξηθεί αυτόματα (αύξηση σε ύψος) ώστε όλο το κείμενο να χωράει. Αν το κείμενο γίνει μικρότερο, συμβαίνει το αντίστροφο. 

## **Do Not Autofit**

Αν θέλετε ένα πλαίσιο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο που περιέχει, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, καλέστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) με τιμή `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε ότι ένα πλαίσιο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Όταν το κείμενο γίνει πολύ μεγάλο για το πλαίσιό του, θα ξεχειλίσει. 

## **Shrink Text on Overflow**

Αν ένα κείμενο γίνει πολύ μεγάλο για το πλαίσιό του, με την επιλογή **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και το διάστημα του κειμένου πρέπει να μειωθούν ώστε να χωράει στο πλαίσιό του. Για να ορίσετε αυτή τη ρύθμιση, καλέστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) με τιμή `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε ότι ένα κείμενο πρέπει να μειωθεί όταν ξεπερνά το πλαίσιό του σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}

Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνει πολύ μεγάλο για το πλαίσιό του. 

{{% /alert %}}

## **Wrap Text**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται εντός του σχήματος όταν υπερβαίνει το όριο του (μόνο πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτή τη ρύθμιση, πρέπει να καλέσετε τη μέθοδο [setWrapText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrameFormat) με τιμή `true`.

Αυτός ο κώδικας JavaScript δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Αν καλέσετε τη μέθοδο `setWrapText` με τιμή `False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει μακρύτερο από το πλάτος του σχήματος, το κείμενο θα εκτείνεται πέρα από τα όρια του σχήματος σε μία μόνο γραμμή. 

{{% /alert %}}

## **FAQ**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Η εσωτερική επένδυση (padding) μειώνει την διαθέσιμη περιοχή για κείμενο, έτσι το AutoFit ενεργοποιείται νωρίτερα—σμικρύνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος νωρίτερα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και μαλακές αλλαγές γραμμής;**

Οι υποχρεωτικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος της γραμματοσειράς και το διάστημα γύρω από αυτές. Η αφαίρεση περιττών αλλαγών γραμμής συχνά μειώνει το πόσο έντονα χρειάζεται το AutoFit να σμικρύνει το κείμενο.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η υποκατάσταση γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η υποκατάσταση με γραμματοσειρά που έχει διαφορετικά μετρικά γλύφων αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και την αναδίπλωση των γραμμών. Μετά από κάθε αλλαγή ή υποκατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.