---
title: Μετατροπή Διαφανειών PowerPoint σε PNG σε JavaScript
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/nodejs-java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας σε JavaScript γρήγορα με το Aspose.Slides για Node.js, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα δείχνουν την απόδοση στην προεπιλεγμένη κλίμακα, την αύξηση της κλίμακας, τον καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και την επιλογή ενός τύπου απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειες της μέσω της συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Το παράδειγμα αποδίδει κάθε διαφάνεια με τη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους για να δημιουργήσει μια μικρογραφία. Στη συνέχεια καλεί τη μέθοδο [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) με το [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) για να αποθηκεύσει κάθε αποδιδόμενη διαφάνεια ως εικόνα PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους αποδίδει σε κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια μεγέθους 720 × 540 points παράγει μικρογραφία 144 × 108 εικονοστοιχεία. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα συγκεκριμένο μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Δώστε τους οριζόντιους και κατακόρυφους παράγοντες κλίμακας στη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) για να ελέγξετε τις αποδιδόμενες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια μεγέθους 720 × 540 points παράγει εικόνα 1440 × 1080 εικονοστοιχείων. Ίδιοι παράγοντες κλίμακας διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, δώστε ένα μέγεθος στη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια σε 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Επιλέξτε διαστάσεις που ταιριάζουν στην αναλογία διαστάσεων της διαφάνειας ώστε να αποφύγετε το τράνταγμα της εικόνας.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Επιλογή Τύπου Απόδοσης Διαβάθμισης**

Υποθέτουμε ότι μια διαφάνεια περιέχει διαβαθμίσεις γεμίσματος, αλλά οι μεταβάσεις στην εξαχθείσα PNG φαίνονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) που κληρονομείται από τη [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το αρχείο [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει δύο γραμμικές διαβαθμίσεις: από κυανό σε πορτοκαλί στο επάνω μέρος και από μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο σημεία, στο 0% και στο 100%.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με τη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις από κυανό σε πορτοκαλί και από μπλε σε κίτρινο αποδίδονται με Default](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδίδονται με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `Default` παράγει πιο ανοιχτά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τα σημεία της διαβάθμισης.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides ικανοποιεί τις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι η αντιστοιχία της εμφάνισης στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· κανένας τρόπος δεν είναι γενικά προτιμότερος.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή μια εικόνα, αντί της ολόκληρης διαφάνειας;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/nodejs-java/create-shape-thumbnails/), επιτρέποντάς σας να αποδείξετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε έναν διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντίτυπο παρουσίασης για κάθε νήμα ή διαδικασία· [μην μοιράζεστε ένα ενιαίο αντίτυπο μεταξύ νημάτων](/slides/el/nodejs-java/multithreading/).

**Ποιες είναι οι περιορισμοί της αξιολόγησης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις παραγόμενες εικόνες και εφαρμόζει [άλλους περιορισμούς](/slides/el/nodejs-java/licensing/) μέχρι να εφαρμοστεί άδεια.