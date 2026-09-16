---
title: Διαχειριστείτε τους Υπερσυνδέσμους Παρουσίασης σε JavaScript
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

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με έναν ιστότοπο ή μια τοποθεσία μέσα στην παρουσίαση. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Ανοίξτε έναν ιστότοπο από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Μεταβείτε σε άλλη διαφάνεια, για παράδειγμα από έναν πίνακα περιεχομένων.

Aspose.Slides for Node.js via Java σάς επιτρέπει να προσθέτετε αυτούς τους συνδέσμους, να ελέγχετε την εμφάνιση και τον ήχο τους, να ενημερώνετε τις ιδιότητές τους και να τους αφαιρείτε. Τα παραδείγματα παρακάτω δείχνουν πώς να δουλέψετε με υπερσυνδέσμους σε επιμέρους στοιχεία και πώς να προσπελάσετε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε ένα URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίζετε τον υπερσύνδεσμο καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-αποδεκτό.

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

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ-αποδεκτό, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setHyperlinkClick) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε κάποιο τμήμα κειμένου μέσα σε αυτό.

Το ίδιο ισχύει για πλαίσια εικόνας, ήχου και βίντεο: αντιστοιχίστε τον υπερσύνδεσμο στο πλαίσιο και καλέστε [setTooltip](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setTooltip) εάν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-αποδεκτό:

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

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [setInternalHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

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

### **Χρώμα**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setColorSource) του [Hyperlink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσύνδεσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkColorSource) και ορίστε το χρώμα γέμισης του τμήματος. Η δυνατότητα αυτή εισήχθηκε στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

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
### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο κατά την ενεργοποίησή του ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink.setSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setSound) καθορίζει τον ήχο που συνδέεται με τον υπερσύνδεσμο.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συνδέει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί παίζει ο ήχος και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα στην ίδια διαφάνεια σταματά τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια μετάβασης.

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

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο του πρώτου σχήματος μέσω των μεθόδων [getSound](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getSound) και [getBinaryData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **Tooltip και Ρυθμίσεις Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [Hyperlink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink) μετά την εκχώρηση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setTooltip) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για το σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) προσδιορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό HTML frameset, όταν ισχύει.
- [setHistory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setHistory) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προσανατολισμένων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν κλικαριστεί.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) για να συλλέξετε τα κοντέινερ υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

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

Για απεριόριστη αφαίρεση, το [removeAllHyperlinks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο πεδίο με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των κυρίων, διατάξεων και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους συνδέσμους web. Το [getAnyHyperlinks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) επιστρέφει κοντέινερ υπερσυνδέσμων, όχι μια απλή λίστα URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getHyperlinkClick) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) σε κάθε κοντέινερ. Είναι ανεξάρτητα: το ίδιο κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφοράς χρειάζεται έως δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Κάντε ερώτημα στο κατάλληλο πεδίο αντί αυτού και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε να μπορείτε αργότερα να τα ενημερώσετε ή να αφαιρέσετε τις ενέργειες τους.

### **Ερώτημα Πεδίων Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries) είναι διαθέσιμη μέσω των μεθόδων [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) και [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Κάθε πεδίο υποστηρίζει τις ίδιες ερωτήσεις:

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) επιστρέφει κοντέινερ με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) επιστρέφει κοντέινερ με οποιαδήποτε από τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ερωτήσεις λειτουργούν σε κάθε πεδίο· οι μετρήσεις περιγράφουν κοντέινερ, όχι συνολικό αριθμό ενεργειών. Το πεδίο πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους σχήματος.

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

Σε αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας επιστρέφουν τρία κοντέινερ κλικ, δύο κοντέινερ mouse‑over και τρία κοντέινερ με οποιαδήποτε από τις δύο ενέργειες. Η ερώτηση πλαισίου κειμένου επιστρέφει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink.getActionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getActionType) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkActionType) καλύπτουν περισσότερα από την πλοήγηση ιστού:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· εξετάστε ξεχωριστά από τα URL ιστού. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμμία ενέργεια πλοήγησης ή μη αναγνωρίσιμη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [getExternalUrl](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) και συγκεκριμένους εσωτερικούς προορισμούς από το [getTargetSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το κοντέινερ δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφεται από το [getExternalUrlOriginal](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#getTooltip) εφόσον είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Έλεγχος Υπερσυνδέσμων**

Το παρακάτω παράδειγμα JavaScript διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει ξανά και τις δύο ενέργειες ενεργοποίησης. Συλλέγει τα κοντέινερ πριν τα αλλάξει και χρησιμοποιεί ισότητα αναφοράς για να αποφύγει την επεξεργασία του ίδιου κοντέινερ δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για πλήρη απογραφή σε όλο το πακέτο, ερωτούν επίσης ρητά τους κυρίους, τις διατάξεις, τις σημειώσεις και τους κύριους σημειώσεων/χαιρετισμού όταν υπάρχουν.

Η αναφορά καταγράφει τον δείκτη διαφάνειας με βάση το 1 και το [getSlideId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide#getSlideId) όπου είναι διαθέσιμο. Το [getSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getSlide) παρέχει τη διαφάνεια‑ιδιοκτήτη για τα υποστηριζόμενα κοντέινερ. Οι κύριοι, οι διατάξεις και οι σημειώσεις δεν έχουν συνηθισμένο δείκτη διαφάνειας και ταυτοποιούνται από το πεδίο τους. Τα κοντέινερ σχήματος και τα κοντέινερ μορφοποίησης τμημάτων κειμένου ετικετοποιούνται ξεχωριστά· άλλοι τύποι κοντέινερ διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε κοντέινερ λαμβάνει τοπικό ID αναφοράς ώστε οι δύο του ενέργειες να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενεργειών ως ακέραιους σταθερούς που ορίζονται από την απαρίθμηση HyperlinkActionType.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URL και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι μια τελική αξιολόγηση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη: προσθέστε λιστές επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URL. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, το [getHyperlinkManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getHyperlinkManager) του κοντέινερ υποστηρίζει τα [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· οι άλλοι απαγορευμένοι κλικ και οι απαγορευμένες ενέργειες mouse‑over αφαιρούνται αυτόνομα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή σας πριν την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί συντηρητική πολιτική ελέγχου PDF: σημαίνει ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από έναν εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι μια υπόδειξη ελέγχου, όχι ένα τεστ δυνατότητας ή εγγύηση ότι οι μη σημασμένες συνδέσεις θα διατηρηθούν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και το πρόγραμμα προβολής. Τα raster [images](/slides/el/nodejs-java/convert-powerpoint-to-png/) και [video](/slides/el/nodejs-java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαίνετε κάθε ενέργεια κατά τον έλεγχο για αυτές τις εξόδους.

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

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και το κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφανειών παραμένουν. Η επαλήθευση εκτυπώνει μηδενικές απαγορευμένες ενέργειες. Ένα εισαγόμενο αρχείο με απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί το κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), το οποίο αφαιρεί και τις δύο ενέργειες σε όλο το επιλεγμένο πεδίο ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, OLE objects ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει εξαγόμενο αρχείο PDF ή HTML.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε την πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία κύριου (master) διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του κύριου (master) διαφάνειας και των διατάξεων υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά το slideshow στις διαφάνειες που χρησιμοποιούν τον αντίστοιχο κύριο ή διάταξη.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορεί να διατηρήσουν τους υπερσυνδέσμους· οι raster εικόνες και το βίντεο δεν μπορούν. Δείτε τις παρατηρήσεις εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).