---
title: Βίντεο
type: docs
weight: 80
url: /el/androidjava/examples/elements/video/
keywords:
- παράδειγμα κώδικα
- βίντεο
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθέστε και ελέγξτε βίντεο με το Aspose.Slides for Android: εισαγάγετε, αναπαράγετε, περικόψτε, ορίστε πλαίσια αφίσας και εξάγετε με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Το παρόν άρθρο δείχνει πώς να ενσωματώσετε καρέ βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη καρέ βίντεο**

Εισάγετε ένα κενό καρέ βίντεο σε μια διαφάνεια.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθήκη βίντεο.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε καρέ βίντεο**

Ανακτήστε το πρώτο καρέ βίντεο που προστέθηκε σε μια διαφάνεια.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Πρόσβαση στο πρώτο καρέ βίντεο στη διαφάνεια.
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

## **Αφαίρεση καρέ βίντεο**

Διαγράψτε ένα καρέ βίντεο από τη διαφάνεια.

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

        // Διαμόρφωση του βίντεο ώστε να αναπαράγεται αυτόματα.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```