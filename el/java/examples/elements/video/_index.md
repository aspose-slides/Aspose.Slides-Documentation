---
title: Βίντεο
type: docs
weight: 80
url: /el/java/examples/elements/video/
keywords:
- παράδειγμα κώδικα
- βίντεο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Προσθέστε και ελέγξτε βίντεο με Aspose.Slides for Java: εισαγωγή, αναπαραγωγή, κοπή, ορισμός πλαισίων αφίσας και εξαγωγή με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη πλαισίου βίντεο**

Εισάγετε ένα κενό πλαίσιο βίντεο σε μια διαφάνεια.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθέστε ένα βίντεο.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε πλαίσιο βίντεο**

Ανακτήστε το πρώτο πλαίσιο βίντεο που έχει προστεθεί σε μια διαφάνεια.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Πρόσβαση στο πρώτο πλαίσιο βίντεο στη διαφάνεια.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
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

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Αφαίρεση του πλαισίου βίντεο.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός αναπαραγωγής βίντεο**

Ρυθμίστε το βίντεο να αναπαράγεται αυτόματα όταν η διαφάνεια εμφανίζεται.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Διαμορφώστε το βίντεο ώστε να αναπαράγεται αυτόματα.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```