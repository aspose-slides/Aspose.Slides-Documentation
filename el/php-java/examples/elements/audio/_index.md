---
title: Ήχος
type: docs
weight: 70
url: /el/php-java/examples/elements/audio/
keywords:
- ήχος
- πλαίσιο ήχου
- προσθέσε ήχο
- πρόσβαση ήχου
- αφαίρεση ήχου
- αναπαραγωγή ήχου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργαστείτε με ήχο σε PHP χρησιμοποιώντας το Aspose.Slides: προσθέστε, αντικαταστήστε, εξάγετε και περικόψτε ήχους, ορίστε την ένταση και την αναπαραγωγή για διαφάνειες και σχήματα σε PowerPoint και OpenDocument."
---
Δείχνει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for PHP via Java**. Τα παρακάτω παραδείγματα παρουσιάζουν βασικές λειτουργίες ήχου.

## **Προσθήκη Πλαισίου Ήχου**

Εισάγετε ένα πλαίσιο ήχου.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Δημιουργήστε ένα πλαίσιο ήχου.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε Πλαίσιο Ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση Πλαισίου Ήχου**

Διαγράψτε ένα πλαίσιο ήχου που προστέθηκε προηγουμένως.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι ένα πλαίσιο ήχου.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Αφαίρεση του πλαισίου ήχου.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ορισμός Αναπαραγωγής Ήχου**

Ρυθμίστε το πλαίσιο ήχου ώστε να παίζει αυτόματα όταν εμφανιστεί η διαφάνεια.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι ένα πλαίσιο ήχου.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Αναπαραγωγή αυτόματα όταν εμφανιστεί η διαφάνεια.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```