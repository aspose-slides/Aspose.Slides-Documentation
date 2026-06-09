---
title: Ήχος
type: docs
weight: 70
url: /el/java/examples/elements/audio/
keywords:
- παράδειγμα κώδικα
- ήχος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε παραδείγματα ήχου Aspose.Slides for Java: εισαγωγή, αναπαραγωγή, περικοπή και εξαγωγή ήχου σε παρουσιάσεις PPT, PPTX και ODP με σαφή κώδικα Java."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε καρέ ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for Java**. Τα παρακάτω παραδείγματα παρουσιάζουν βασικές λειτουργίες ήχου.

## **Προσθήκη καρέ ήχου**

Εισάγετε ένα κενό καρέ ήχου που μπορεί αργότερα να περιέχει ενσωματωμένα δεδομένα ήχου.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Δημιουργήστε ένα κενό καρέ ήχου (ο ήχος θα ενσωματωθεί αργότερα).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε καρέ ήχου**

Αυτός ο κώδικας ανακτά το πρώτο καρέ ήχου σε μια διαφάνεια.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Πρόσβαση στο πρώτο καρέ ήχου της διαφάνειας.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση καρέ ήχου**

Διαγράψτε ένα προηγουμένως προστιθέμενο καρέ ήχου.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Αφαιρέστε το καρέ ήχου.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός αναπαραγωγής ήχου**

Ρυθμίστε το καρέ ήχου ώστε να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```