---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/nodejs-java/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε, μορφοποιήστε, ενημερώστε και αφαιρέστε υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java, χρησιμοποιώντας παραδείγματα JavaScript."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με έναν ιστότοπο ή μια τοποθεσία εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστότοπου από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα από έναν πίνακα περιεχομένων.

Aspose.Slides for Node.js via Java επιτρέπει την προσθήκη αυτών των συνδέσμων, τον έλεγχο της εμφάνισης και του ήχου τους, την ενημέρωση των ιδιοτήτων τους και την αφαίρεσή τους. Τα παρακάτω παραδείγματα δείχνουν πώς να δουλέψετε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Σημείωση" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις χρησιμοποιώντας το [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να εκχωρήσετε ένα URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο εκχωρείτε τον υπερσύνδεσμο καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε [Διαχείριση της Βάσης Υπερσυνδέσμων](/slides/el/nodejs-java/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, τροποποίηση ή εκκαθάριση της βάσης σε επίπεδο εγγράφου.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-δυνατό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ-δυνατό, καλέστε τη μέθοδό του [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick). Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνας, ήχου και βίντεο: εκχωρήστε τον υπερσύνδεσμο στο πλαίσιο και καλέστε το [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) εάν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-δυνατό:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να περάσουν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί το [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) για να συνδέσει το κείμενο “Σελίδα 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Color**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) του [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) καθορίζει εάν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) και ορίστε το χρώμα γεμάσης του τμήματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο χρώμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sound**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη αναπαράγεται. Χρησιμοποιήστε τις ακόλουθες μεθόδους για να διαμορφώσετε αυτές τις συμπεριφορές:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) καθορίζει το ήχο που σχετίζεται με τον υπερσύνδεσμο.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) ελέγχει εάν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Add a Hyperlink Sound**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί αναπαράγεται ο ήχος και γίνεται πλοήγηση στη επόμενη διαφάνεια. Ένα δεύτερο σχήμα στην ίδια διαφάνεια σταματά τον προηγούμενο ήχο όταν κάνετε κλικ, χωρίς να εκτελεί ενέργεια πλοήγησης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extract a Hyperlink Sound**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) και [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip and Interaction Settings**

Μπορείτε να καλέσετε τις ακόλουθες μεθόδους του [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) μετά την εκχώρηση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) ορίζει το κείμενο που μπορεί να εμφανίσει ένας θεατής ως υπόδειξη για τον σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) καθορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό HTML frameset, όταν είναι εφαρμοστέο.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) ελέγχει εάν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβληθέντων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) ελέγχει εάν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) για να συλλέξετε δοχεία υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα τροποποιήσετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Για αμετάκλητη αφαίρεση, το [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) αφαιρεί και τους δύο τύπους ενεργοποίησης στην επιλεγμένη εμβέλεια με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν τη διανομή μιας παρουσίασης, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς της συνδέσμους. Το [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) επιστρέφει δοχεία υπερσυνδέσμων, όχι μια επίπεδη λίστα από συμβολοσειρές URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) σε κάθε δοχείο. Είναι ανεξάρτητα: το ίδιο δοχείο μπορεί να εκθέτει και τις δύο ενέργειες, ώστε μια πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά δοχείο.

Η σάρωση μόνο των υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραβλέψει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Αντ' αυτού, ερωτήστε την κατάλληλη εμβέλεια και διατηρήστε τα επιστρεφόμενα δοχεία ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Query Presentation, Slide, and Text-Frame Scopes**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) είναι διαθέσιμη μέσω των [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) και [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Κάθε εμβέλεια υποστηρίζει τις ίδιες ερωτήσεις:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) επιστρέφει δοχεία με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) επιστρέφει δοχεία με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) επιστρέφει δοχεία με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ίδιες ερωτήσεις λειτουργούν σε κάθε εμβέλεια· οι μετρήσεις περιγράφουν δοχεία, όχι συνολικές ενέργειες. Η εμβέλεια πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία δοχεία κλικ, δύο δοχεία mouse‑over και τρία δοχεία με μία ή και τις δύο ενέργειες. Η ερώτηση πλαισίου κειμένου αναφέρει ένα δοχείο σε κάθε κατηγορία.

### **Classify Actions and Destinations**

Χρησιμοποιήστε το [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) καλύπτουν περισσότερα από την περιήγηση στον ιστό:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση της παρουσίασης, επιλύεται στο πλαίσιο της παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός της τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε χωριστά από τα URL του ιστού. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Χωρίς ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί έλεγχο. |

Αναγνώστε εξωτερικούς προορισμούς μέσω του [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) και συγκεκριμένους εσωτερικούς προορισμούς μέσω του [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές ενδέχεται να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το δοχείο δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει το [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε τη συμβουλή εργαλείου που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) όταν είναι διαθέσιμη.

### **Report, Sanitize, and Verify Hyperlinks**

Το παρακάτω παράδειγμα JavaScript διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει και τις δύο τύποι ενεργοποίησης. Συλλέγει τα δοχεία πριν τα τροποποιήσει και χρησιμοποιεί ισότητα αναφοράς για να αποτρέψει την επεξεργασία του ίδιου δοχείου δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις συνηθισμένες διαφάνειες· για έναν συνολικό κατάλογο πακέτου, ερωτά ρητά και τα master, τα layout, τις σημειώσεις και τα master σημειώσεων και φυλλαδίων όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας αρχής από το 1 και το [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) όπου είναι διαθέσιμο. Το [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) παρέχει τη διαφάνεια‑κάτοχο για τα υποστηριζόμενα δοχεία. Τα master, τα layout και οι σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και ταυτοποιούνται με την εμβέλειά τους. Τα δοχεία σχήματος και τα δοχεία μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι δοχείων διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε δοχείο λαμβάνει ένα αναφορικό ID ώστε οι δύο ενέργειές του να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενεργειών ως ακέραιες σταθερές που ορίζει η αρίθμηση HyperlinkActionType.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URL και έγκυρους εσωτερικούς στόχους διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι δικαστική απόφαση για την ασφάλεια του Aspose.Slides. Το HTTPS από μόνο του δεν εγγυάται την εμπιστοσύνη: προσθέστε λίστες επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URL. Το παράδειγμα ελέγχει τα μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) του δοχείου υποστηρίζει τα [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλοι απαγορευμένοι κλικ και απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν από την υλοποίηση.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: σημαδεύει ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι υπόδειξη ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι οι μη σημαδεμένες συνδέσεις θα παραμείνουν μετά την εξαγωγή. Τα υποστηριζόμενα εξαγόμενα σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προορισμό. Τα raster [images](/slides/el/nodejs-java/convert-powerpoint-to-png/) και [video](/slides/el/nodejs-java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδέψτε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και ο κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Ένα εισαγόμενο αρχείο που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλαδί αντικατάστασης. Ένα δοχείο με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλη την επιλεγμένη εμβέλεια ανεξαρτήτως πολιτικής. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες των υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα έργα VBA, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο και δεν επικυρώνει ένα εξαγόμενο αρχείο PDF ή HTML.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να δημιουργήσω σύνδεσμο σε ενότητα ή στην πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε μια ενότητα, συνδέστε την πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω έναν υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master slide και των layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι εξαγωγές PDF και HTML ενδέχεται να διατηρήσουν τους υπερσυνδέσμους· οι raster εικόνες και το βίντεο δεν μπορούν. Δείτε τις επι considerations εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).