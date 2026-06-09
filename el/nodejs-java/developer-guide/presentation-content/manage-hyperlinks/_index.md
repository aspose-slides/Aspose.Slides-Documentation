---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Υπερσύνδεσμου
type: docs
weight: 20
url: /el/nodejs-java/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσύνδεσμου
- δημιουργία υπερσύνδεσμου
- μορφοποίηση υπερσύνδεσμου
- αφαίρεση υπερσύνδεσμου
- ενημέρωση υπερσύνδεσμου
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
description: "Διαχειριστείτε άψογα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε ένα αντικείμενο ή δεδομένα ή σε μια τοποθεσία σε κάτι. Αυτοί είναι συνηθισμένοι υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Σύνδεσμοι προς ιστοσελίδες μέσα σε κείμενα, σχήματα ή πολυμέσα
* Σύνδεσμοι προς διαφάνειες

Το Aspose.Slides για Node.js μέσω Java σάς επιτρέπει να εκτελείτε πολλές εργασίες που αφορούν υπερσυνδέσμους σε παρουσιάσεις.

{{% alert color="primary" %}} 
Μπορείτε να θέλετε να δείτε το απλό Aspose, [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας PowerPoint.](https://products.aspose.app/slides/el/editor)
{{% /alert %}} 

## **Προσθήκη υπερσυνδέσμων URL**

### **Προσθήκη υπερσυνδέσμων URL σε κείμενα**

Αυτό το κώδικα JavaScript σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε ένα κείμενο:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Προσθήκη υπερσυνδέσμων URL σε σχήματα ή πλαίσια**

Αυτό το παράδειγμα κώδικα σε JavaScript σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε ένα σχήμα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Προσθήκη υπερσυνδέσμων URL σε πολυμέσα**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε υπερσυνδέσμους σε εικόνες, ήχο και βίντεο.

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει εικόνα στην παρουσίαση
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 με βάση την προηγουμένως προστιθέμενη εικόνα
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Μπορείτε να θέλετε να δείτε *[Διαχείριση OLE](/slides/el/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Χρήση υπερσυνδέσμων για δημιουργία πίνακα περιεχομένων**

Δεδομένου ότι οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή τοποθεσίες, μπορείτε να τους χρησιμοποιήσετε για να δημιουργήσετε έναν πίνακα περιεχομένων.

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μορφοποίηση υπερσυνδέσμων**

### **Χρώμα**

Με τη μέθοδο [setColorSource](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) στην κλάση [Hyperlink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink), μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε τις πληροφορίες χρώματος από αυτούς. Η δυνατότητα εισήχθη για πρώτη φορά στο PowerPoint 2019, οπότε οι αλλαγές που αφορούν αυτήν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτό το παράδειγμα κώδικα δείχνει μια λειτουργία όπου υπερσύνδεσμοι με διαφορετικά χρώματα προστέθηκαν στην ίδια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση υπερσυνδέσμων σε παρουσιάσεις**

### **Αφαίρεση υπερσυνδέσμων από κείμενα**

Αυτό το κώδικα JavaScript σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα κείμενο σε μια διαφάνεια παρουσίασης:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Ελέγχει εάν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Διατρέχει τις παραγράφους στο πλαίσιο κειμένου
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Διατρέχει κάθε τμήμα στην παράγραφο
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Αλλάζει το κείμενο
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Αλλάζει τη μορφοποίηση
                    }
                }
            }
        }
    }
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Αφαίρεση υπερσυνδέσμων από σχήματα ή πλαίσια**

Αυτό το κώδικα JavaScript σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε μια διαφάνεια παρουσίασης:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μεταβλητός υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink) είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για τις ακόλουθες ιδιότητες:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Το απόσπασμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και να επεξεργαστείτε το tooltip του αργότερα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Υποστηριζόμενες ιδιότητες στο IHyperlinkQueries**

Μπορείτε να έχετε πρόσβαση στο [HyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries) από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries) υποστηρίζει αυτές τις μεθόδους και ιδιότητες:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;**

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση τεχνικά στοχεύει σε μια συγκεκριμένη διαφάνεια. Για να «πλοηγήσετε σε μια ενότητα», συνήθως συνδέεστε με την πρώτη της διαφάνεια.

**Μπορώ να προσθέσω έναν υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και της διάταξης υποστηρίζουν υπερσυνδέσμους. Τέτοιοι σύνδεσμοι εμφανίζονται στις θυγατρικές διαφάνειες και είναι κλικ‑δυνατά κατά την προβολή.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Στα [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), ναι — οι σύνδεσμοι συνήθως διατηρούνται. Κατά την εξαγωγή σε [images](/slides/el/nodejs-java/convert-powerpoint-to-png/) και [video](/slides/el/nodejs-java/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν θα μεταφερθεί λόγω της φύσης αυτών των μορφών (πλαίσιο/βίντεο raster δεν υποστηρίζουν υπερσυνδέσμους).