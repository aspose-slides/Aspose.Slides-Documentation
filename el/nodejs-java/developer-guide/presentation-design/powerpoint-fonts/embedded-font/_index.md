---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις με JavaScript
linktitle: Ενσωμάτωση Γραμματοσειράς
type: docs
weight: 40
url: /el/nodejs-java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- κατάργηση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ενσωμάτωση γραμματοσειρών TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java, εξασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

Οι **ενσωματωμένες γραμματοσειρές σε PowerPoint** είναι χρήσιμες όταν θέλετε η παρουσίασή σας να εμφανίζεται σωστά όταν ανοίγεται σε οποιοδήποτε σύστημα ή συσκευή. Εάν χρησιμοποιήσατε μια γραμματοσειρά τρίτου‑μέρους ή μη‑τυπική επειδή ήσασταν δημιουργικοί στη δουλειά σας, τότε έχετε ακόμη περισσότερους λόγους να ενσωματώσετε τη γραμματοσειρά σας. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), τα κείμενα ή οι αριθμοί στις διαφάνειές σας, η διάταξη, η μορφοποίηση κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγκεχυμένα πλαίσια. 

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager), η κλάση [FontData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontdata/) και η κλάση [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) περιέχουν τις περισσότερες ιδιότητες και μεθόδους που χρειάζεστε για εργασία με ενσωματωμένες γραμματοσειρές σε παρουσιάσεις PowerPoint.

## **Ανάκτηση ή κατάργηση ενσωματωμένων γραμματοσειρών από την παρουσίαση**

Η Aspose.Slides παρέχει τη μέθοδο [getEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (εκτεθειμένη από την κλάση [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager)) ώστε να μπορείτε να ανακτήσετε (ή να μάθετε) τις γραμματοσειρές που είναι ενσωματωμένες σε μια παρουσίαση. Για να αφαιρέσετε γραμματοσειρές, χρησιμοποιείται η μέθοδος [removeEmbeddedFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (εκτεθειμένη από την ίδια κλάση).

```javascript
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Αποδίδει μια διαφάνεια που περιέχει ένα πλαίσιο κειμένου που χρησιμοποιεί ενσωματωμένη "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Αποκτά όλες τις ενσωματωμένες γραμματοσειρές
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Εντοπίζει τη γραμματοσειρά "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Καταργεί τη γραμματοσειρά "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Αποδίδει την παρουσίαση· η γραμματοσειρά "Calibri" αντικαθίσταται με μια υπάρχουσα
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Αποθηκεύει την παρουσίαση χωρίς την ενσωματωμένη γραμματοσειρά "Calibri" στο δίσκο
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσθεση ενσωματωμένων γραμματοσειρών στην παρουσίαση**

Χρησιμοποιώντας το enum [EmbedFontCharacters](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/embedfontcharacters/) και τις δύο υπερφορτώσεις της μεθόδου [addEmbeddedFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), μπορείτε να επιλέξετε τον προτιμώμενο κανόνα (ενσωμάτωσης) για να ενσωματώσετε τις γραμματοσειρές σε μια παρουσίαση. Αυτός ο κώδικας JavaScript δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

```javascript
// Φορτώνει την παρουσίαση
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συμπίεση ενσωματωμένων γραμματοσειρών**

Για να σας επιτρέψει να συμπιέσετε τις γραμματοσειρές που είναι ενσωματωμένες σε μια παρουσίαση και να μειώσετε το μέγεθός της, η Aspose.Slides παρέχει τη μέθοδο [compressEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (εκτεθειμένη από την κλάση [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/)).

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να βεβαιώσω ότι μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά την απόδοση παρά την ενσωμάτωση;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/nodejs-java/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες εφεδρείας/αντικατάστασης](/slides/el/nodejs-java/fallback-font/): εάν η γραμματοσειρά είναι μη διαθέσιμη ή περιορισμένη, θα χρησιμοποιηθεί εφεδρική.

**Αξίζει να ενσωματώσω «σύστημα» γραμματοσειρές όπως Arial/Calibri;**

Συνήθως όχι—είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεπτά» περιβάλλοντα (Docker, διακομιστή Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση γραμματοσειρών συστήματος μπορεί να εξαλείψει τον κίνδυνο απρόσμενων αντικαταστάσεων.