---
title: PHP का उपयोग करके प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/php-java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **अवलोकन**

एक ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for PHP via Java के साथ, आप एक ऑडियो क्लिप को एम्बेड कर सकते हैं, उसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन संलग्न कर सकते हैं। आप स्लाइड ट्रांज़िशन को असाइन की गई ध्वनि भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

स्थानीय ऑडियो क्लिप को पहली स्लाइड पर एम्बेड करने के लिए [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) का उपयोग करें। पहले दो निर्देशांक फ्रेम को स्लाइड पर स्थित करता है, और अगले दो मान उसकी चौड़ाई और ऊँचाई को पॉइंट्स में निर्धारित करता है। यह उदाहरण क्लिप को स्वचालित रूप से शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) को कॉल करता है और तेज़ वॉल्यूम प्रीसेट चुनने के लिए [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) को कॉल करता है।

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ऑडियो फ्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप से, एक ऑडियो फ्रेम स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) से एक छवि जोड़ें और फ्रेम की तस्वीर पर इसे [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) से सेट करें। उदाहरण एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में JPEG का उपयोग करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint के **Audio Options** नियंत्रण निर्धारित करते हैं कि क्लिप कब शुरू होती है, उसकी आवाज़ कितनी तेज़ है, और स्लाइड शो के दौरान इसका व्यवहार कैसा होता है।

![ऑडियो फ्रेम के लिए PowerPoint ऑडियो विकल्प नियंत्रण](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for PHP via Java मेथड |
| --- | --- |
| शुरू | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| वॉल्यूम प्रीसेट | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| स्लाइडों के पार चलाएँ | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| रोकने तक लूप | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| प्रदर्शन के दौरान छिपाएँ | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| प्ले के बाद रीवाइंड | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| फ़ेड इन | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| फ़ेड आउट | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| ऑडियो प्रारंभ समय ट्रिम करें | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| ऑडियो अंत समय ट्रिम करें | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| वॉल्यूम स्लाइडर | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

यह उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम खोजता है, क्लिप को क्लिक पर चलाने के लिए [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) को कॉल करता है, और कम वॉल्यूम प्रीसेट चुनता है। क्लिप स्लाइडों के बीच जारी रहती है जबकि लूपिंग अक्षम है। आइकन शो के दौरान छिपा रहता है, और प्लेबैक के बाद क्लिप रीवाइंड होता है।

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

3.5 सेकंड से लंबी क्लिप के लिए, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) क्लिप के अंत से हटाए जाने वाले समय को लेता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए उस ऑफसेट को पूरी क्लिप अवधि से घटाएँ। ट्रिम की गई क्लिप 200 मिलीसेकंड में फ़ेड इन होती है और 500 मिलीसेकंड में फ़ेड आउट होती है। सभी चार विधियों के मान मिलीसेकंड में होते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

प्लेबैक वॉल्यूम को विशिष्ट प्रतिशत पर सेट करने के लिए, [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम को 85% पर सेट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ्रेम [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) के माध्यम से उसके कैप्शन ट्रैक्स तक पहुँच प्रदान करता है। आप इस संग्रह का उपयोग क्लिप से WebVTT कैप्शन संलग्न करने, मौजूदा ट्रैक्स निर्यात करने, या उन्हें हटाने के लिए कर सकते हैं।

### **ऑडियो कैप्शन जोड़ें**

यह उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक संलग्न करने के लिए [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) का उपयोग करता है। पहला आर्गुमेंट ट्रैक लेबल देता है, और दूसरा टाइम्ड कैप्शन वाली फ़ाइल को पहचानता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर ऑडियो फ्रेम से जुड़े प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) द्वारा लौटाए गए बाइट्स को WebVTT फ़ाइल में लिखता है और [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) द्वारा लौटाए गए पहचानकर्ता को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **ऑडियो कैप्शन हटाएँ**

एकल ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन को हटाने के लिए [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) का उपयोग करता है जबकि क्लिप संरक्षित रहती है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **ऑडियो कैप्शन में पंक्ति खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में एक पंक्ति खोजने के लिए, मेमोरी में [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) द्वारा लौटाए गए टेक्स्ट को खोजें। साधारण टेक्स्ट WebVTT क्यू में, टाइमिंग पंक्ति में `-->` होता है, उसके बाद कैप्शन पंक्तियाँ आती हैं, और एक खाली पंक्ति क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन पंक्ति को प्रिंट करता है जिसमें “café” शामिल है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ऑडियो निकालें**

स्लाइड ट्रांज़िशन का अपना ध्वनि हो सकता है। इसे प्राप्त करने के लिए स्लाइड ट्रांज़िशन पर [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) कॉल करें। यह उदाहरण [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) द्वारा लौटाए गए बाइट्स तक पहुँचता है और बाइट्स की संख्या प्रिंट करता है। यदि पहली स्लाइड में कोई ट्रांज़िशन साउंड नहीं है, तो यह एक संदेश प्रिंट करता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड्स में बिना डुप्लिकेट किए पुन: उपयोग कर सकता हूँ?**

हाँ। ऑडियो क्लिप को प्रस्तुति की [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) में एक बार जोड़ें और प्रत्येक स्लाइड के लिए वही ऑडियो ऑब्जेक्ट को [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) में पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि बदल सकता हूँ?**

हाँ। लिंक्ड ध्वनि के लिए, प्रतिस्थापन फ़ाइल की ओर इंगित करने के लिए [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) का उपयोग करें। एम्बेडेड ध्वनि के लिए, प्रस्तुति की ऑडियो कलेक्शन से किसी अन्य क्लिप को [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) के साथ चुनें। दोनों तरीकों से मौजूदा फ्रेम बरकरार रहता है।

**क्या ट्रिमिंग से प्रस्तुति में संधारित ऑडियो डेटा बदलता है?**

नहीं। [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) और [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) प्लेबैक सीमाएँ निर्धारित करते हैं। आप अभी भी [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) से पूरी क्लिप प्राप्त कर सकते हैं।