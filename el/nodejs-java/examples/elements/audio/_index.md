---
title: Ήχος
type: docs
weight: 70
url: /el/nodejs-java/examples/elements/audio/
keywords:
- παράδειγμα κώδικα
- ήχος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε παραδείγματα ήχου του Aspose.Slides for Node.js: εισαγωγή, αναπαραγωγή, περικοπή και εξαγωγή ήχου σε παρουσιάσεις PPT, PPTX και ODP με σαφή κώδικα JavaScript."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for Node.js via Java**. Τα παρακάτω παραδείγματα παρουσιάζουν βασικές λειτουργίες ήχου.

## **Προσθήκη πλαισίου ήχου**

Το παρακάτω παράδειγμα κώδικα προσθέτει ένα πλαίσιο ήχου σε μια διαφάνεια παρουσίασης.

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε πλαίσιο ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση πλαισίου ήχου**

Διαγραφή ενός προηγουμένως προστιθέμενου πλαισίου ήχου.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το πλαίσιο ήχου.
        let audioFrame = slide.getShapes().get_Item(0);

        // Αφαιρέστε το πλαίσιο ήχου.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ρύθμιση αναπαραγωγής ήχου**

Ρυθμίστε το πλαίσιο ήχου να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι ένα πλαίσιο ήχου.
        let audioFrame = slide.getShapes().get_Item(0);

        // Αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```