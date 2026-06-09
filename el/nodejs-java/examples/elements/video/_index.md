---
title: Βίντεο
type: docs
weight: 80
url: /el/nodejs-java/examples/elements/video/
keywords:
- παράδειγμα κώδικα
- βίντεο
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε και ελέγξτε βίντεο με Aspose.Slides για Node.js: εισαγωγή, αναπαραγωγή, περικοπή, ορισμός πλαισίου αφίσας, και εξαγωγή με παραδείγματα για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη πλαισίου βίντεο**
Προσθέστε ένα πλαίσιο βίντεο σε μια διαφάνεια.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Προσθήκη βίντεο.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε πλαίσιο βίντεο**
Ανακτήστε το πρώτο πλαίσιο βίντεο που προστέθηκε σε μια διαφάνεια.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στο πρώτο πλαίσιο βίντεο της διαφάνειας.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση πλαισίου βίντεο**
Διαγράψτε ένα πλαίσιο βίντεο από τη διαφάνεια.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το πλαίσιο βίντεο.
        let videoFrame = slide.getShapes().get_Item(0);

        // Αφαίρεση του πλαισίου βίντεο.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός αναπαραγωγής βίντεο**
Ρυθμίστε το βίντεο να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το πλαίσιο βίντεο.
        let videoFrame = slide.getShapes().get_Item(0);

        // Ρυθμίστε το βίντεο να παίζει αυτόματα.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```