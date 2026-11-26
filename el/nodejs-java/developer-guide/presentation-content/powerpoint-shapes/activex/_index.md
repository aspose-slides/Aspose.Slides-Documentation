---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /el/nodejs-java/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- Διαχείριση ActiveX
- Προσθήκη ActiveX
- Τροποποίηση ActiveX
- Αναπαραγωγέας πολυμέσων
- PowerPoint
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Επεξεργαστείτε πλαίσια κειμένου και κουμπιά ActiveX, ενημερώστε τις προεπισκοπήσεις ελέγχων, και επαναχρησιμοποιήστε έναν έλεγχο Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js μέσω Java."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX δίνουν σε μια διαφάνεια PowerPoint διαδραστικά στοιχεία όπως πλαίσια κειμένου, κουμπιά εντολών και αναπαραγωγείς πολυμέσων. Το Aspose.Slides για Node.js μέσω Java εκθέτει τους ελέγχους μιας διαφάνειας μέσω του [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον αφαιρέσετε.

## **Λίστα ελέγχων ActiveX και των αποθηκευμένων ιδιοτήτων τους**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα αναφέρει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, το [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) και κάθε ζεύγος κλειδιού‑τιμής στο [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Διαβάζει την παρουσίαση χωρίς να ενεργοποιεί τους ελέγχους, να καλεί συμβάντα ή μακροεντολές, να αλλάζει τιμές ή να αποθηκεύει το αρχείο.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Το επιλεγμένο αποτέλεσμα από το `ActiveX.pptm` εμφανίζει ένα πλαίσιο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) μπορεί να επιστρέψει `null`, που εμφανίζεται ως `Properties unavailable`. Αν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) μετά τον έλεγχο για `null`. Η αναφορά καταγράφει τις ιδιότητες που είναι διαθέσιμες από την παρουσίαση. Ένας έλεγχος μπορεί να υποστηρίζει πρόσθετες ιδιότητες κατά το χρόνο εκτέλεσης.

## **Τροποποίηση ελέγχων ActiveX**

Το παράδειγμα υποθέτει μια παρουσίαση με δυνατότητα μακροεντολών που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [συλλογή ιδιοτήτων ελέγχου](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και την τιτλοποίηση του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που το PowerPoint μπορεί να εμφανίσει πριν την ενεργοποίηση. Παρέχετε ένα αρχείο PNG για κάθε έλεγχο που εμφανίζει το ενημερωμένο κείμενο και την εμφάνιση του. Το παράδειγμα εκχωρεί αυτές τις εικόνες μέσω του [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 σημεία ορίζοντας το πλαίσιο του με το [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM, μετά χρησιμοποιεί το [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ελέγχους ActiveX αφαιρεμένους από εκείνη τη διαφάνεια.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **Προσθήκη ελέγχου Media Player ActiveX**

Για να επαναχρησιμοποιήσετε έναν ρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο της οποίας η πρώτη διαφάνεια περιέχει έναν παίκτη με όνομα `WindowsMediaPlayer1`. Το [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του παίκτη στη [συλλογή ιδιοτήτων](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως την μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, οπότε επιλέξτε μια διαδρομή που ο παίκτης να μπορεί να προσπελάσει κατά την αναπαραγωγή.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τους ελέγχους ActiveX χωρίς να τους εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει τους ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE;**

Οι έλεγχοι ActiveX επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [OLE object](/slides/el/nodejs-java/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα εξακολουθούν τα γεγονότα ActiveX να ενεργοποιούν μακροεντολές VBA μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή με δυνατότητα μακροεντολών, όπως PPTM, για να διατηρήσετε το πρότζεκτ VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας επιτρέπουν τόσο τους ελέγχους ActiveX όσο και τις μακροεντολές.