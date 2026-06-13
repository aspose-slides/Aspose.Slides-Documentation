---
title: वीडियो
type: docs
weight: 80
url: /hi/php-java/examples/elements/video/
keywords:
- वीडियो
- वीडियो फ़्रेम
- वीडियो जोड़ें
- वीडियो तक पहुँचें
- वीडियो हटाएँ
- वीडियो प्लेबैक
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides का उपयोग करके वीडियो के साथ काम करें: सम्मिलित करें, बदलें, ट्रिम करें, पोस्टर फ्रेम और प्लेबैक विकल्प सेट करें, और PPT, PPTX और ODP के लिए प्रस्तुतियों को निर्यात करें।"
---
किस प्रकार वीडियो फ्रेम एम्बेड करें और प्लेबैक विकल्प सेट करें, **Aspose.Slides for PHP via Java** का उपयोग करके दिखाता है।

## **वीडियो फ़्रेम जोड़ें**

स्लाइड में एक वीडियो फ़्रेम डालें।

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // एक वीडियो फ्रेम जोड़ें।
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **वीडियो फ़्रेम तक पहुंचें**

स्लाइड में जोड़ा गया पहला वीडियो फ़्रेम प्राप्त करें।

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला वीडियो फ्रेम एक्सेस करें।
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

## **वीडियो फ़्रेम हटाएँ**

स्लाइड से एक वीडियो फ़्रेम हटाएँ।

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लें कि स्लाइड पर पहला आकार वीडियो फ्रेम है।
        $videoFrame = $slide->getShapes()->get_Item(0);

        // वीडियो फ्रेम को हटाएँ।
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **वीडियो प्लेबैक सेट करें**

जब स्लाइड प्रदर्शित हो तो वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लें कि स्लाइड पर पहला आकार वीडियो फ्रेम है।
        $videoFrame = $slide->getShapes()->get_Item(0);

        // वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```