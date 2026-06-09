---
title: Βελτιώστε τις Παρουσιάσεις σας με AutoFit στο Android
linktitle: Ρυθμίσεις Autofit
type: docs
weight: 30
url: /el/androidjava/manage-autofit-settings/
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
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ρυθμίσεις AutoFit στο Aspose.Slides για Android μέσω Java για να βελτιστοποιήσετε την προβολή κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να αυξήσετε την αναγνωστικότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο — προσαρμόζει αυτόματα το πλαίσιο ώστε το κείμενό του να ταιριάζει πάντα.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο κειμένου γίνεται μεγαλύτερο ή πιο εκτενές, το PowerPoint αυξάνει αυτόματα το πλαίσιο — αυξάνει το ύψος του — ώστε να χωράει περισσότερο κείμενο. 
* Όταν το κείμενο στο πλαίσιο κειμένου γίνεται πιο σύντομο ή μικρότερο, το PowerPoint μειώνει αυτόματα το πλαίσιο — μειώνει το ύψος του — για να αφαιρέσει το περιττό κενό. 

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρους ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Το Aspose.Slides for Android μέσω Java παρέχει παρόμοιες επιλογές — ορισμένες ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat) — που σας επιτρέπουν να ελέγχετε τη συμπεριφορά autofit για πλαίσια κειμένου σε παρουσιάσεις.

## **Αλλαγή μεγέθους σχήματος ώστε να ταιριάζει το κείμενο**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά τις αλλαγές στο κείμενο, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτήν τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) στην τιμή `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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

Αν το κείμενο γίνει μεγαλύτερο ή πιο εκτενές, το πλαίσιο κειμένου θα αλλάξει αυτόματα το μέγεθός του (αύξηση σε ύψος) ώστε να χωράει όλο το κείμενο. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο. 

## **Μη αυτόματη προσαρμογή**

Αν θέλετε ένα πλαίσιο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο που περιέχει, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) στην τιμή `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του, εκτρέπει έξω. 

## **Σμίκρυνση κειμένου κατά υπερχείλιση**

Αν ένα κείμενο γίνει πολύ μακρύ για το πλαίσιο του, μέσω της επιλογής **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και το διάστημα του κειμένου πρέπει να μειωθούν ώστε να χωράει στο πλαίσιο. Για να ορίσετε αυτήν τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) στην τιμή `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται εντός του σχήματος όταν το κείμενο υπερβεί το όριο του σχήματος (μόνο το πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτήν τη ρύθμιση, πρέπει να θέσετε την ιδιότητα [WrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) στην τιμή `true`.

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
Αν ορίσετε την ιδιότητα `WrapText` σε `False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει μεγαλύτερο από το πλάτος του σχήματος, το κείμενο θα εκτείνεται πέρα από τα όρια του σχήματος σε μια μόνο γραμμή. 
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ασχολούνται οι εσωτερικά περιθώρια του πλαισίου κειμένου με το AutoFit;**

Ναι. Η εσωτερική επένδυση (padding) μειώνει την διαθέσιμη περιοχή για το κείμενο, έτσι το AutoFit ενεργοποιείται νωρίτερα — μειώνοντας τη γραμματοσειρά ή αλλάζοντας το σχήμα νωρίτερα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και ήπιες αλλαγές γραμμής;**

Οι υποχρεωτικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος της γραμματοσειράς και το διάστημα γύρω τους. Η αφαίρεση περιττών αλλαγών συχνά μειώνει το πόσο εντατικά πρέπει να μειώσει το κείμενο το AutoFit.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η ενεργοποίηση αντικατάστασης γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η αντικατάσταση με μια γραμματοσειρά με διαφορετικά μετρικά γλύφων αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και την αναδίπλωση των γραμμών. Μετά από οποιαδήποτε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.