---
title: PHP का उपयोग करके प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/php-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में वीडियो फ़्रेम को प्रोग्रामेटिकली जोड़ने और निकालने के बारे में सीखें। त्वरित कैसे‑करें गाइड।"
---
## **परिचय**

प्रस्तुति में सही ढंग से रखी गई वीडियो आपके संदेश को अधिक आकर्षक बना सकती है और दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकती है।

PowerPoint आपको प्रस्तुति में स्लाइड पर वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके कंप्यूटर पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube जैसी वेब स्रोत से)।

एक प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) क्लास और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाएँ**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं, स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड का संदर्भ उसके इंडेक्स से प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति के साथ एम्बेड करें।
1. वीडियो के लिए एक फ्रेम बनाने हेतु एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दर्शाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```php
  # Presentation क्लास का इंस्टेंस बनाता है
  $pres = new Presentation("pres.pptx");
  try {
    # वीडियो लोड करता है
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # पहली स्लाइड प्राप्त करता है और एक वीडियोफ़्रेम जोड़ता है
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

वैकल्पिक रूप से, आप वीडियो को सीधे उसके फ़ाइल पथ को [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addvideoframe/) मेथड में पास करके जोड़ सकते हैं:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **वेब स्रोतों से वीडियो के साथ वीडियो फ्रेम बनाएँ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुतियों में YouTube वीडियो को समर्थन देता है। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (उदाहरण के लिए, YouTube पर), तो आप उसे उसके वेब लिंक के माध्यम से अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड का संदर्भ उसके इंडेक्स से प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

यह PHP कोड दर्शाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT प्रारूप में संग्रहीत होते हैं और उन्हें [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से एक्सपोज़ किया जाता है।

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) द्वारा लौटाए गए [CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) संग्रह का उपयोग करके एक WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) संग्रह के माध्यम से इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // कैप्शन ट्रैक को एक WebVTT फ़ाइल में सहेजता है।
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) संग्रह से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // प्रकार: VideoFrame

    // वीडियो फ़्रेम से सभी कैप्शन हटाता है।
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#clear) के बजाय [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें।

## **स्लाइड्स से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेड किए गए वीडियो निकालने की सुविधा देता है।

1. वीडियो वाली प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. सभी [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) ऑब्जेक्ट्स के माध्यम से इटररेट करें।
1. सभी [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट्स के माध्यम से इटररेट करके एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) खोजें।
1. वीडियो को डिस्क पर सहेजें।

यह PHP कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```php
  # एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # फ़ाइल विस्तार प्राप्त करता है
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक VideoFrame के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/setplaymode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/setplayloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हाँ। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप एक ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसके स्थान और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/setembeddedvideo/) को बदल सकते हैं जबकि आकृति की ज्यामिति को बरकरार रख सकते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कॉन्टेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/getcontenttype/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, जैसे कि इसे डिस्क पर सहेजते समय।