---
title: Δημιουργία παρουσιάσεων σε Node.js μέσω .NET
linktitle: Δημιουργία παρουσίασης
type: docs
weight: 10
url: /el/nodejs-net/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PowerPoint
- δημιουργία PPTX
- προσθήκη πλαισίου κειμένου
- προσθήκη διαφάνειας
- μέγεθος διαφάνειας
- ευρεία οθόνη
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις PowerPoint σε JavaScript με Aspose.Slides for Node.js μέσω .NET: προσθέστε ένα πλαίσιο κειμένου και διαφάνειες, ορίστε μέγεθος διαφάνειας 16:9 και αποθηκεύστε το αποτέλεσμα ως PPTX."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση με Aspose.Slides for Node.js μέσω .NET, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Επίσης δείχνει πώς να προσθέσετε περισσότερες διαφάνειες και πώς να αλλάξετε την παρουσίαση σε πλατιά (16:9) διαφάνειες.

Τα παραδείγματα απαιτούν ένα έργο ρυθμισμένο όπως περιγράφεται στην [Installation](/slides/el/nodejs-net/installation/). Αποθηκεύστε κάθε παράδειγμα ως αρχείο `.js` στον φάκελο του έργου και εκτελέστε το από αυτόν το φάκελο με `node`, για παράδειγμα `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Node.js μέσω .NET δεν διαθέτει δική του αναφορά API. Αντιγράφει το API του Aspose.Slides for .NET με ονόματα camelCase, έτσι οι σύνδεσμοι API σε αυτό το άρθρο οδηγούν στις αντίστοιχες κλάσεις και μέλη στην [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/el/net/).
{{% /alert %}}

## **Δημιουργία παρουσίασης με πλαίσιο κειμένου**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μια νέα παρουσίαση περιέχει ήδη μία κενή διαφάνεια.  
2. Αποκτήστε αυτή τη διαφάνεια από τη συλλογή [slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/). Οι συλλογές σε αυτό το πακέτο διαβάζονται με `get(index)`, και οι δείκτες αρχίζουν από 0.  
3. Προσθέστε ένα ορθογώνιο με τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/shapecollection/addautoshape/) και ορίστε το [text](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/text/) του [textFrame](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/textframe/).  
4. Αποθηκεύστε την παρουσίαση με τη μέθοδο [save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) και την τιμή `SaveFormat.Pptx`.  
5. Καλέστε τη `dispose` σε ένα μπλοκ `finally` για να απελευθερώσετε τους πόρους .NET που υποστηρίζουν την παρουσίαση.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Η θέση (x, y) και το μέγεθος (πλάτος, ύψος) είναι σε σημεία.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Το σενάριο γράφει το `new-presentation.pptx` στον φάκελο του έργου. Το αρχείο έχει μία διαφάνεια με ένα γεμάτο ορθογώνιο του οποίου η επάνω‑αριστερή γωνία βρίσκεται 50 points από τις αριστερές και πάνω άκρες της διαφάνειας. Το ορθογώνιο έχει πλάτος 400 points και ύψος 100 points, και το κείμενό του είναι κυκλισμένο στο κέντρο. Ένα point ισούται με 1/72 ίντσα. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογράφημα αξιολόγησης στη διαφάνεια· δείτε την [Licensing](/slides/el/nodejs-net/licensing/).

## **Προσθήκη διαφανειών**

Μια νέα παρουσίαση έχει μία διαφάνεια. Για να προσθέσετε περισσότερες, περάστε μια διαφάνεια διάταξης στη μέθοδο [addEmptySlide](https://reference.aspose.com/slides/el/net/aspose.slides/slidecollection/addemptyslide/) της συλλογής `slides`. Η μέθοδος [getByType](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslidecollection/getbytype/) της συλλογής [layoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/layoutslides/) επιστρέφει την πρώτη διάταξη ενός δεδομένου [SlideLayoutType](https://reference.aspose.com/slides/el/net/aspose.slides/slidelayouttype/).

Το παρακάτω παράδειγμα προσθέτει δύο διαφάνειες με τη διάταξη Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το σενάριο εκτυπώνει `Slide count: 3` και γράφει το `three-slides.pptx`. Οι νέες διαφάνειες προσαρτώνται μετά την πρώτη και δεν περιέχουν σχήματα. Μία νέα παρουσίαση έχει πάντα τη διάταξη Blank, αλλά μια παρουσίαση που ανοίγετε από αρχείο μπορεί να μην έχει διάταξη του ζητούμενου τύπου· σε αυτήν την περίπτωση η `getByType` επιστρέφει `null`, έτσι ελέγξτε το αποτέλεσμα πριν το χρησιμοποιήσετε.

## **Ορισμός μεγέθους διαφάνειας**

Μία νέα παρουσίαση χρησιμοποιεί διαφάνειες 4:3 με 720 × 540 points (10 × 7.5 ίντσες). Για να δημιουργήσετε πλατιές (widescreen) διαφάνειες, καλέστε τη μέθοδο [setSize](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/setsize/) της [slideSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slidesize/) της παρουσίασης με μια τιμή [SlideSizeType](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizetype/) και μια τιμή [SlideSizeScaleType](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizescaletype/). Ο τύπος κλίμακας λέει στο Aspose.Slides τι να κάνει με τα σχήματα που ήδη υπάρχουν στις διαφάνειες· `DoNotScale` τα αφήνει όπως είναι, κάτι που είναι η σωστή επιλογή για μια παρουσίαση που δεν έχει ακόμη περιεχόμενο.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το σενάριο εκτυπώνει `Slide size: 960 x 540 points`, που ισούται με 13.33 × 7.5 ίντσες, και γράφει το `widescreen.pptx`. Το `SlideSizeType.OnScreen16x9` έχει την ίδια αναλογία 16:9 αλλά είναι μικρότερο: 720 × 405 points.

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι θέσεις και τα μεγέθη;**

Σε points. Μία ίντσα είναι 72 points, έτσι η προεπιλεγμένη διαφάνεια 4:3 είναι 720 × 540 points, και μια πλατιά διαφάνεια 16:9 είναι 960 × 540 points.

**Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;**

Οποιαδήποτε τιμή της απαρίθμησης [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/), για παράδειγμα `SaveFormat.Ppt` για PowerPoint 97–2003, `SaveFormat.Odp` για OpenDocument ή `SaveFormat.Pdf`. Για έξοδο PDF, δείτε [Convert PowerPoint to PDF](/slides/el/nodejs-net/convert-powerpoint-to-pdf/).

**Γιατί η αποθηκευμένη παρουσίαση περιέχει το κείμενο "Evaluation only";**

Χωρίς άδεια, το Aspose.Slides προσθέτει υδατογράφημα αξιολόγησης στις διαφάνειες που αποθηκεύει. Εφαρμόστε άδεια όπως περιγράφεται στην [Licensing](/slides/el/nodejs-net/licensing/) για να το αφαιρέσετε.

**Γιατί πρέπει να καλέσω τη `dispose`;**

Ένα αντικείμενο `Presentation` υποστηρίζεται από ένα αντικείμενο .NET που κρατά μνήμη και άλλους πόρους. Η κλήση της `dispose` τα απελευθερώνει αμέσως μόλις δεν χρειάζεστε πια την παρουσίαση, και η κλήση της σε ένα μπλοκ `finally` τα απελευθερώνει ακόμα και όταν προκύψει σφάλμα.