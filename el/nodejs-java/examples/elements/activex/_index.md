---
title: ActiveX
type: docs
weight: 200
url: /el/nodejs-java/examples/elements/activex/
keywords:
- παράδειγμα κώδικα
- ActiveX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δείτε παραδείγματα ActiveX για Aspose.Slides for Node.js: εισαγωγή, διαμόρφωση και έλεγχο αντικειμένων ActiveX σε παρουσιάσεις PPT και PPTX με σαφή κώδικα JavaScript."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να προσπελάσετε, να αφαιρέσετε και να ρυθμίσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη ελέγχου ActiveX**

Προσθέστε έναν νέο έλεγχο ActiveX σε μια διαφάνεια.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Προσθήκη ενός νέου ελέγχου ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε έλεγχο ActiveX**

Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Πρόσβαση στον πρώτο έλεγχο ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση ελέγχου ActiveX**

Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Αφαίρεση του πρώτου ελέγχου ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ρύθμιση ιδιοτήτων ActiveX**

Ρυθμίστε πολλές ιδιότητες του ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```