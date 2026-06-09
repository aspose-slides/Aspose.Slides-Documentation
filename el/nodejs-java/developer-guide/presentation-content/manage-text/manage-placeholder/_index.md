---
title: Διαχείριση Δεσμευτικών Σημείων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Δεσμευτικών Σημείων
type: docs
weight: 10
url: /el/nodejs-java/manage-placeholder/
keywords:
- δεσμευτικό σημείο
- δεσμευτικό σημείο κειμένου
- δεσμευτικό σημείο εικόνας
- δεσμευτικό σημείο διαγράμματος
- κείμενο προτροπής
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε άψογα τα δεσμευτικά σημεία στο Aspose.Slides για Node.js μέσω Java: αντικαταστήστε κείμενο, προσαρμόστε προτροπές & ορίστε τη διαφάνεια της εικόνας σε PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σάς δίνει τη δυνατότητα να διαχειρίζεστε τα δεσμευτικά σημεία παρουσιάσεων προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να βρείτε δεσμευτικά σημεία στις διαφάνειες και να αλλάξετε το κείμενό τους, να ορίσετε προσαρμοσμένο κείμενο προτροπής για τις διατάξεις δεσμευτικών σημείων, και να ρυθμίσετε τη διαφάνεια μιας εικόνας που χρησιμοποιείται ως φόντο δεσμευτικού σημείου. Περιλαμβάνει επίσης μια σύντομη FAQ που διευκρινίζει τη διαφορά μεταξύ βασικών δεσμευτικών σημείων και τοπικών σχημάτων, εξηγεί πώς οι αλλαγές στα δεσμευτικά σημεία μπορούν να εφαρμοστούν μέσω διατάξεων ή μητρών, και αναφέρεται στη διαχείριση των δεσμευτικών σημείων κεφαλίδας και υποσέλιδου.

## **Αλλαγή κειμένου σε δεσμευτικό σημείο**

Χρησιμοποιώντας το [Aspose.Slides for Node.js via Java](/slides/el/nodejs-java/), μπορείτε να βρείτε και να τροποποιήσετε δεσμευτικά σημεία στις διαφάνειες των παρουσιάσεων. Το Aspose.Slides σάς επιτρέπει να κάνετε αλλαγές στο κείμενο ενός δεσμευτικού σημείου.

**Προαπαιτούμενο**: Χρειάζεστε μια παρουσίαση που περιέχει ένα δεσμευτικό σημείο. Μπορείτε να δημιουργήσετε τέτοια παρουσίαση στην τυπική εφαρμογή Microsoft PowerPoint.

Έτσι χρησιμοποιείτε το Aspose.Slides για να αντικαταστήσετε το κείμενο στο δεσμευτικό σημείο σε αυτή την παρουσίαση:

1. Δημιουργήστε μια παρουσία του [`Presentation`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) κλάσης και περάστε την παρουσία ως όρισμα.
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Επανάληψη μέσω των σχημάτων για να βρείτε το δεσμευτικό σημείο.
4. Κάντε μετατροπή τύπου του σχήματος δεσμευτικού σημείου σε [`AutoShape`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) και αλλάξτε το κείμενο χρησιμοποιώντας το [`TextFrame`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame) που είναι συσχετισμένο με το [`AutoShape`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape).
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε το κείμενο σε ένα δεσμευτικό σημείο:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Προσπελαύνει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Διασχίζει τα σχήματα για να βρει το δεσμευτικό σημείο
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Αλλάζει το κείμενο σε κάθε δεσμευτικό σημείο
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός κειμένου προτροπής σε δεσμευτικό σημείο**

Οι τυπικές και προκατασκευασμένες διατάξεις περιέχουν κείμενα προτροπής δεσμευτικού σημείου όπως ***Click to add a title*** ή ***Click to add a subtitle***. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να εισάγετε τα προτιμώμενα κείμενα προτροπής σας στις διατάξεις δεσμευτικών σημείων.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ορίσετε το κείμενο προτροπής σε ένα δεσμευτικό σημείο:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Διασχίζει τη διαφάνεια
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // Το PowerPoint εμφανίζει "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Προσθέτει υπότιτλο
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός διαφάνειας εικόνας δεσμευτικού σημείου**

Το Aspose.Slides σάς επιτρέπει να ορίσετε τη διαφάνεια της εικόνας φόντου σε ένα δεσμευτικό σημείο κειμένου. Ρυθμίζοντας τη διαφάνεια της εικόνας σε ένα τέτοιο πλαίσιο, μπορείτε να κάνετε το κείμενο ή την εικόνα να ξεχωρίζει (ανάλογα με τα χρώματα του κειμένου και της εικόνας).

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ορίσετε τη διαφάνεια για ένα φόντο εικόνας (μέσα σε σχήμα):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Τι είναι ένα βασικό δεσμευτικό σημείο και πώς διαφέρει από ένα τοπικό σχήμα σε μια διαφάνεια;**

Ένα βασικό δεσμευτικό σημείο είναι το αρχικό σχήμα σε μια διάταξη ή μητρική παρουσίαση από το οποίο κληρονομεί το σχήμα της διαφάνειας—ο τύπος, η θέση και ορισμένη μορφοποίηση προέρχονται από αυτό. Ένα τοπικό σχήμα είναι ανεξάρτητο· εάν δεν υπάρχει βασικό δεσμευτικό σημείο, η κληρονομικότητα δεν ισχύει.

**Πώς μπορώ να ενημερώσω όλους τους τίτλους ή τις λεζάντες σε όλη την παρουσίαση χωρίς να επαναλαμβάνω σε κάθε διαφάνεια;**

Επεξεργαστείτε το αντίστοιχο δεσμευτικό σημείο στην διάταξη ή στον κύριο (master). Οι διαφάνειες που βασίζονται σε αυτές τις διατάξεις/στον κύριο θα κληρονομήσουν αυτόματα την αλλαγή.

**Πώς ελέγχω τα τυπικά δεσμευτικά σημεία κεφαλίδας/υποσέλιδου—ημερομηνία & ώρα, αριθμός διαφάνειας και κείμενο υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές HeaderFooter στο κατάλληλο επίπεδο (κανονικές διαφάνειες, διατάξεις, master, σημειώσεις/χάρτες) για να ενεργοποιήσετε ή απενεργοποιήσετε αυτά τα δεσμευτικά σημεία και να ορίσετε το περιεχόμενό τους.