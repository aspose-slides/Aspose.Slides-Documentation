---
title: "Ήχος"
type: docs
weight: 70
url: /el/androidjava/examples/elements/audio/
keywords:
- "παράδειγμα κώδικα"
- "ήχος"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Ανακαλύψτε παραδείγματα ήχου του Aspose.Slides για Android: ενσωμάτωση, αναπαραγωγή, περικοπή και εξαγωγή ήχου σε παρουσιάσεις PPT, PPTX και ODP με καθαρό κώδικα Java."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for Android via Java**. Τα παρακάτω παραδείγματα παρουσιάζουν βασικές λειτουργίες ήχου.

## **Προσθήκη Πλαισίου Ήχου**

Εισάγετε ένα κενό πλαίσιο ήχου που μπορεί αργότερα να περιέχει ενσωματωμένα δεδομένα ήχου.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Δημιουργήστε ένα κενό πλαίσιο ήχου (ο ήχος θα ενσωματωθεί αργότερα).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Πλαίσιο Ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
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

## **Αφαίρεση Πλαισίου Ήχου**

Διαγράψτε ένα πλαίσιο ήχου που προστέθηκε προηγουμένως.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Αφαίρεση του πλαισίου ήχου.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός Αναπαραγωγής Ήχου**

Ρυθμίστε το πλαίσιο ήχου να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Αναπαραγωγή αυτόματα όταν εμφανιστεί η διαφάνεια.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```