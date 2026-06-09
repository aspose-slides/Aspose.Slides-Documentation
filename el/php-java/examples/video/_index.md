---
title: Βίντεο
type: docs
weight: 80
url: /el/php-java/examples/elements/video/
keywords:
- βίντεο
- καρέ βίντεο
- προσθήκη βίντεο
- πρόσβαση βίντεο
- αφαίρεση βίντεο
- αναπαραγωγή βίντεο
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργασία με βίντεο σε PHP χρησιμοποιώντας Aspose.Slides: εισαγωγή, αντικατάσταση, περικοπή, ορισμός πλαισίων αφίσας και επιλογών αναπαραγωγής, καθώς και εξαγωγή παρουσιάσεων για PPT, PPTX και ODP."
---
Δείχνει πώς να ενσωματώσετε καρέ βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη καρέ βίντεο**

Εισάγετε ένα καρέ βίντεο σε μια διαφάνεια.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθήκη καρέ βίντεο.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε καρέ βίντεο**

Ανακτήστε το πρώτο καρέ βίντεο που προστέθηκε σε μια διαφάνεια.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο καρέ βίντεο στη διαφάνεια.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση καρέ βίντεο**

Διαγράψτε ένα καρέ βίντεο από τη διαφάνεια.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το καρέ βίντεο.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Αφαίρεση του καρέ βίντεο.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ορισμός αναπαραγωγής βίντεο**

Ρυθμίστε το βίντεο ώστε να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το καρέ βίντεο.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Ρυθμίστε το βίντεο ώστε να αναπαράγεται αυτόματα.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```