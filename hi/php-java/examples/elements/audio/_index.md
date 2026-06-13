---
title: "ऑडियो"
type: docs
weight: 70
url: /hi/php-java/examples/elements/audio/
keywords:
- "ऑडियो"
- "ऑडियो फ्रेम"
- "ऑडियो जोड़ें"
- "ऑडियो एक्सेस करें"
- "ऑडियो हटाएँ"
- "ऑडियो प्लेबैक"
- "कोड उदाहरण"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके PHP में ऑडियो के साथ काम करें: ध्वनियों को जोड़ें, बदलें, निकालें और ट्रिम करें, PowerPoint और OpenDocument में स्लाइड्स और शेप्स के लिए वॉल्यूम और प्लेबैक सेट करें।"
---
यह दर्शाता है कि **Aspose.Slides for PHP via Java** के साथ ऑडियो फ़्रेम को एम्बेड करना और प्लेबैक को नियंत्रित करना कैसे किया जाता है। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन को दिखाते हैं।

## **ऑडियो फ़्रेम जोड़ें**
एक ऑडियो फ़्रेम डालें।

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // एक ऑडियो फ्रेम बनाएं।
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ऑडियो फ़्रेम एक्सेस करें**
यह कोड स्लाइड पर पहला ऑडियो फ़्रेम प्राप्त करता है।

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड पर पहला ऑडियो फ्रेम एक्सेस करें।
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

## **ऑडियो फ़्रेम हटाएँ**
पहले जोड़े गए ऑडियो फ़्रेम को हटाएँ।

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लीजिए कि स्लाइड पर पहला आकार एक ऑडियो फ्रेम है।
        $audioFrame = $slide->getShapes()->get_Item(0);

        // ऑडियो फ्रेम हटाएँ।
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ऑडियो प्लेबैक सेट करें**
जब स्लाइड दिखाई देता है तो ऑडियो फ़्रेम को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // मान लीजिए कि स्लाइड पर पहला आकार एक ऑडियो फ्रेम है।
        $audioFrame = $slide->getShapes()->get_Item(0);

        // स्लाइड दिखाई देने पर स्वचालित रूप से चलाएँ।
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```