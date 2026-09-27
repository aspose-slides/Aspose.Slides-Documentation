---
title: Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες σε Node.js μέσω .NET
linktitle: Διαφάνεια σε Εικόνα
type: docs
weight: 40
url: /el/nodejs-net/convert-slide/
keywords:
- μετατροπή διαφάνειας
- διαφάνεια σε εικόνα
- διαφάνεια σε PNG
- αποθήκευση διαφάνειας ως εικόνα
- απόδοση διαφάνειας
- μικρογραφία διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Απόδοση διαφανειών από παρουσιάσεις PPTX, PPT και ODP ως εικόνες PNG σε JavaScript με Aspose.Slides για Node.js μέσω .NET, με συντελεστή κλίμακας ή σε ακριβές μέγεθος σε εικονοστοιχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Node.js μέσω .NET αποδίδει τις διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως εικόνες, για παράδειγμα για να εμφανίζει προεπισκοπήσεις διαφανειών σε μια ιστοσελίδα. Αυτό το άρθρο δείχνει δύο τρόπους επιλογής του μεγέθους της εικόνας: έναν συντελεστή κλίμακας σε σχέση με το μέγεθος της διαφάνειας και ένα ακριβές μέγεθος σε εικονοστοιχεία. Και τα δύο παραδείγματα αποθηκεύουν αρχεία PNG.

Τα παραδείγματα αναμένουν μια παρουσίαση με όνομα `sample.pptx` στο φάκελο του έργου που έχετε ρυθμίσει στην [Εγκατάσταση](/slides/el/nodejs-net/installation/). Οποιαδήποτε παρουσίαση PowerPoint είναι αποδεκτή. Αποθηκεύστε κάθε παράδειγμα ως αρχείο `.js` στο φάκελο του έργου και εκτελέστε το από αυτόν το φάκελο με `node`.

{{% alert color="info" title="Σημείωση" %}}
Το Aspose.Slides for Node.js μέσω .NET δεν διαθέτει δική του τεκμηρίωση API. Αντιγράφει το API του Aspose.Slides for .NET με ονόματα camelCase, έτσι οι σύνδεσμοι API σε αυτό το άρθρο οδηγούν στις αντίστοιχες κλάσεις και μέλη στην [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/el/net/).
{{% /alert %}}

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Ανοίξτε την παρουσίαση με τον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/presentation/).
1. Πάρτε μια διαφάνεια από τη συλλογή [slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) με `get(index)`. Οι δείκτες αρχίζουν από 0.
1. Αποδώστε τη διαφάνεια με `getImageWithScale` ή `getImageWithImageSize`. Στην τεκμηρίωση .NET API, και οι δύο είναι υπερφορτώσεις του [Slide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage/). Επιστρέφουν ένα αντικείμενο εικόνας που αντιστοιχεί στο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/).
1. Αποθηκεύστε την εικόνα με τη μέθοδο [save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/) και μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/), και κατόπιν καλέστε τη μέθοδο `dispose`.

## **Μετατροπή ΌΛΩΝ ΤΩΝ ΔΙΑΦΑΝΕΙΩΝ σε Εικόνα PNG**

`getImageWithScale` δέχεται έναν οριζόντιο και έναν κάθετο συντελεστή κλίμακας. Σε κλίμακα 1, ένα σημείο της διαφάνειας γίνεται ένα εικονοστοιχείο της εικόνας. Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια με κλίμακα 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Μια κλίμακα 1 αποδίδει ένα εικονοστοιχείο ανά σημείο· 2 διπλασιάζει το πλάτος και το ύψος.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Το script δημιουργεί ένα αρχείο ανά διαφάνεια, `slide_1.png`, `slide_2.png`, κ.λπ., αριθμημένα από το 1. Για μια παρουσίαση 16:9 με διαφάνειες των 960 × 540 σημείων, κάθε εικόνα είναι 1920 × 1080 εικονοστοιχεία. Οι κρυμμένες διαφάνειες αποδίδονται επίσης· για να τις παραλείψετε, ελέγξτε την ιδιότητα [hidden](https://reference.aspose.com/slides/el/net/aspose.slides/slide/hidden/) της διαφάνειας. Κάθε εικόνα απελευθερώνεται στο δικό της μπλοκ `finally`, το οποίο την απελευθερώνει πριν αποδοθεί η επόμενη διαφάνεια. Χωρίς άδεια, οι εικόνες εμφανίζουν επίσης υδατογράφημα αξιολόγησης· δείτε την [Αδειοδότηση](/slides/el/nodejs-net/licensing/).

## **Μετατροπή Μιας Διαφάνειας σε Εικόνα Δοσμένου Μεγέθους**

`getImageWithImageSize` δέχεται ένα αντικείμενο με `width` και `height` σε εικονοστοιχεία. Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια με πλάτος 1280 εικονοστοιχεία και υπολογίζει το ύψος από το μέγεθος της διαφάνειας, ώστε η εικόνα να διατηρεί την αναλογία διαστάσεων της διαφάνειας:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Η ιδιότητα [slideSize.size](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/size/) επιστρέφει το πλάτος και το ύψος της διαφάνειας σε σημεία. Για μια παρουσίαση 16:9, το script εκτυπώνει `Saved a 1280 x 720 image` και γράφει `slide_1_1280px.png`; για μια παρουσίαση 4:3, η εικόνα είναι 1280 × 960 εικονοστοιχεία.

## **Συχνές Ερωτήσεις**

**Γιατί η εικόνα από το `getImage` χωρίς επιχειρήματα είναι τόσο μικρή;**

Χωρίς επιχειρήματα, το `getImage` αποδίδει τη διαφάνεια στο 20 % του μεγέθους της σε σημεία, έτσι μια διαφάνεια 960 × 540 σημείων γίνεται εικόνα 192 × 108 εικονοστοιχείων. Χρησιμοποιήστε το `getImageWithScale` ή το `getImageWithImageSize` για να επιλέξετε το μέγεθος.

**Πώς αποθηκεύω JPEG ή άλλες μορφές εικόνας;**

Περάστε μια άλλη τιμή `ImageFormat` στη μέθοδο `save` της εικόνας, για παράδειγμα `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Η μορφή προέρχεται από την τιμή `ImageFormat`, όχι από την επέκταση του αρχείου, έτσι διατηρήστε τις δύο σταθερές.

**Γιατί το κείμενο στις εικόνες φαίνεται διαφορετικό σε Linux;**

Το Aspose.Slides μπορεί να χρησιμοποιήσει μόνο τις γραμματοσειρές που είναι εγκατεστημένες στο μηχάνημα που αποδίδει τις διαφάνειες. Όταν μια παρουσίαση χρησιμοποιεί μια γραμματοσειρά που λείπει, όπως η Calibri σε έναν τυπικό διακομιστή Linux, το Aspose.Slides χρησιμοποιεί μια εγκατεστημένη γραμματοσειρά στη θέση της, κάτι που μπορεί να αλλάξει την εμφάνιση του κειμένου και τις θέσεις διακοπής γραμμών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας ώστε να λαμβάνετε τις ίδιες εικόνες όπως στα Windows.

**Γιατί το `getThumbnailWithImageSize` αποτυγχάνει με TypeError;**

Το README του πακέτου χρησιμοποιεί το `getThumbnailWithImageSize`, αλλά το πακέτο δεν διαθέτει μεθόδους `getThumbnail`. Χρησιμοποιήστε το `getImageWithImageSize` αντί αυτού· λαμβάνει το ίδιο όρισμα `{ width, height }`.