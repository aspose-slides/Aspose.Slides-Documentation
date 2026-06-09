---
title: Προηγμένη εξαγωγή κειμένου από παρουσιάσεις σε JavaScript
linktitle: Εξαγωγή κειμένου
type: docs
weight: 90
url: /el/nodejs-java/extract-text-from-presentation/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια συχνή αλλά κρίσιμη εργασία για τους προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε εργάζεστε με αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε με παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση των κειμενικών δεδομένων μπορεί να είναι καθοριστική για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή μεταφορά περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποδοτικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for Node.js via Java. Θα μάθετε πώς να διατρέχετε συστηματικά τα στοιχεία της παρουσίασης για να ανακτήσετε με ακρίβεια το κειμενικό περιεχόμενο που χρειάζεστε.

## **Εξαγωγή κειμένου από διαφάνεια**

Το Aspose.Slides for Node.js via Java παρέχει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/) . Αυτή η κλάση εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [getAllTextBoxes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Αυτή η μέθοδος δέχεται ένα αντικείμενο διαφάνειας ως παράμετρο. Όταν εκτελείται, η μέθοδος σαρώνει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) , διατηρώντας τυχόν μορφοποίηση κειμένου.

Το παρακάτω αποσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή κειμένου από παρουσίαση**

Για να σαρώσετε το κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [getAllTextFrames](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/) . Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερον, μια τιμή τύπου `boolean` που υποδεικνύει εάν οι κύριες διαφάνειες πρέπει να συμπεριληφθούν όταν γίνεται σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) , περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο κώδικας παρακάτω σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Κατηγοριοποιημένη και γρήγορη εξαγωγή κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Το enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textextractionarrangingmode/) ορίζει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις παρακάτω τιμές:
- `Unarranged` - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- `Arranged` - Το κείμενο είναι οργανωμένο στην ίδια σειρά όπως εμφανίζεται στη διαφάνεια.

Η κατάσταση Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από την κατάσταση Arranged.

`PresentationText` αντιπροσωπεύει το ακατέργαστο κείμενο που έχει εξαχθεί από την παρουσίαση. Η μέθοδος `getSlidesText` επιστρέφει έναν πίνακα αντικειμένων, καθένα από τα οποία αντιπροσωπεύει το κείμενο της αντίστοιχης διαφάνειας. Κάθε αντικείμενο κειμένου διαφάνειας διαθέτει τις ακόλουθες μεθόδους:

- Η μέθοδος `getText` επιστρέφει το κείμενο εντός των σχημάτων της διαφάνειας.
- Η μέθοδος `getMasterText` επιστρέφει το κείμενο εντός των σχημάτων της κύριας διαφάνειας που σχετίζονται με αυτή τη διαφάνεια.
- Η μέθοδος `getLayoutText` επιστρέφει το κείμενο εντός των σχημάτων της διαφάνειας διάταξης που σχετίζονται με αυτή τη διαφάνεια.
- Η μέθοδος `getNotesText` επιστρέφει το κείμενο εντός των σχημάτων της διαφάνειας σημειώσεων που σχετίζονται με αυτή τη διαφάνεια.
- Η μέθοδος `getCommentsText` επιστρέφει το κείμενο εντός των σχολίων που σχετίζονται με αυτή τη διαφάνεια.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Συχνές ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [large presentations](/slides/el/nodejs-java/open-presentation/), καθιστώντας το κατάλληλο για σε πραγματικό χρόνο ή μαζικές επεξεργασίες.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και διαγράμματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφανειών, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με διαγράμματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζεται ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν έκδοση δοκιμής του Aspose.Slides, αν και θα έχει [certain limitations](/slides/el/nodejs-java/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για τη διαχείριση μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.