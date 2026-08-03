---
title: PHP का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/php-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। त्वरित मार्गदर्शिका।"
---
## **परिचय**

एक सही जगह पर रखा गया वीडियो प्रस्तुति में आपका संदेश अधिक प्रभावी बना सकता है और आपके दर्शकों के साथ संपर्क स्तर को बढ़ा सकता है।  

PowerPoint आपको प्रस्तुति में स्लाइड पर वीडियो जोड़ने के दो तरीके देता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (जो आपके मशीन पर संग्रहीत है)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube जैसे वेब स्रोत से)।

प्रस्तुति में वीडियो (video objects) जोड़ने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो फ्रेम बना सकते हैं ताकि प्रस्तुति में वीडियो को एम्बेड किया जा सके।  

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. एक [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ को पास करके प्रस्तुति में वीडियो को एम्बेड करें।  
4. वीडियो के लिए फ्रेम बनाने हेतु एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।  
5. संशोधित प्रस्तुति को सहेजें।  

यह PHP कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

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

## **वेब स्रोतों से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint 2013 और बाद के संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुतियों में YouTube वीडियो को समर्थन देते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube पर), तो आप इसे अपने प्रस्तुति में उसके वेब लिंक के माध्यम से जोड़ सकते हैं।  

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. एक [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।  
4. वीडियो फ़्रेम के लिए थंबनेल सेट करें।  
5. प्रस्तुति को सहेजें।  

यह PHP कोड दिखाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```php
  # Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल को दर्शाता है
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

## **वीडियो फ्रेम को ट्रिम करें**

Aspose.Slides आपको वीडियो के किस भाग को चलाया जाए, इसे ट्रिम-फ्रॉम-स्टार्ट और ट्रिम-फ्रॉम-एंड मान सेट करके नियंत्रित करने देता है, जो [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#setTrimFromEnd) द्वारा किया जाता है। दोनों मान मिलीसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितना समय छोड़ा जाए, यह निर्धारित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; वे एम्बेडेड वीडियो बाइनरी डेटा को काटती या बदलती नहीं हैं।  

**ट्रिम सेटिंग्स सेट करें**

वीडियो फ्रेम बनाने और उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।  
2. प्रस्तुति में एक [Video](https://reference.aspose.com/slides/hi/php-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें।  
3. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।  
4. [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#setTrimFromEnd) के माध्यम से ट्रिम-फ्रॉम-स्टार्ट और ट्रिम-फ्रॉम-एंड मान सेट करें।  
5. संशोधित प्रस्तुति को सहेजें।  

निम्न कोड उदाहरण एम्बेडेड वीडियो के प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स को जांचने के लिए, प्रस्तुति लोड करें, पहले स्लाइड पर शेप्स में से [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें, और मानों को [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getTrimFromStart) और [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getTrimFromEnd) के माध्यम से पढ़ें।  

निम्न कोड उदाहरण पहला वीडियो फ्रेम प्रथम स्लाइड पर खोजता है और उसके ट्रिम सेटिंग्स को मिलीसेकंड में रिपोर्ट करता है:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से उपलब्ध होते हैं।  

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।  
2. प्रस्तुति में एक वीडियो जोड़ें।  
3. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।  
4. [CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) कलेक्शन का उपयोग करें, जो [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) द्वारा लौटाया जाता है, WebVTT कैप्शन ट्रैक जोड़ने के लिए।  
5. संशोधित प्रस्तुति को सहेजें।  

निम्न कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

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

[CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) क्लास एक ओवरलोड भी प्रदान करती है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।  

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो शामिल है।  
2. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।  
3. [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) कलेक्शन के माध्यम से इटररेट करें।  
4. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।  

निम्न कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

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
                // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रदान करता है।  

**वीडियो फ्रेम से कैप्शन हटाएं**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो शामिल है।  
2. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।  
3. [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/#getCaptionTracks) कलेक्शन से कैप्शन ट्रैक हटाएँ।  
4. संशोधित प्रस्तुति को सहेजें।  

निम्न कोड दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाए जाएँ:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // प्रकार: VideoFrame

    // वीडियो फ्रेम से सभी कैप्शन हटाता है।
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें, [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#clear) के बजाय।  

## **स्लाइड्स से वीडियो निकालें**

स्लाइड्स में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।  

1. वीडियो वाली प्रस्तुति को लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. सभी [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) ऑब्जेक्ट्स के माध्यम से इटररेट करें।  
3. सभी [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) मिल सके।  
4. वीडियो को डिस्क पर सहेजें।  

यह PHP कोड दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकाला जाए:

```php
  # प्रस्तुति फ़ाइल को दर्शाने वाला Presentation ऑब्जेक्ट बनाता है
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # फ़ाइल एक्सटेंशन प्राप्त करता है
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

## **FAQ**

### **कौन-से वीडियो प्लेबैक पैरामीटर को VideoFrame के लिए बदला जा सकता है?**

आप प्लेबैक मोड (ऑटो या क्लिक पर) और लूपिंग को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।  

### **क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ जाता है। जब आप एक ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड किए जाते हैं, इसलिए आकार वृद्धि कम होती है।  

### **क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर वीडियो कंटेंट को बदल सकते हैं जबकि शेप की ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।  

### **क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक कंटेंट टाइप होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के तौर पर जब इसे डिस्क पर सहेजते हैं।