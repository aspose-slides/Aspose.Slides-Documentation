---
title: प्रेजेंटेशनों में PHP का उपयोग करके वीडियो फ्रेम प्रबंधित करें
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
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के लिए तेज़ गाइड सीखें।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को आकर्षित करने में मदद कर सकते हैं। Aspose.Slides for PHP via Java आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स को समायोजित करने, कैप्शन प्रबंधित करने, और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो के लिंक, जैसे YouTube वीडियो, को सपोर्ट करता है।

वीडियो डेटा और वीडियो फ्रेम को दर्शाने के लिए, Aspose.Slides [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) क्लास, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाना**

यदि आप अपनी स्लाइड में जोड़ने के लिए वीडियो फ़ाइल स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम को सहेजता है। फ्रेम के निर्देशांक और आकार पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं हो जाता, क्योंकि [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) प्रस्तुति के उपयोग के दौरान इसे लॉक रखता है।

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

आप स्थानीय वीडियो पथ को सीधे [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) में पास भी कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एम्बेड करता है। प्रस्तुति सहेजी जाने तक वीडियो सुलभ रहना चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ्रेम बनाना**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुतियों में ऑनलाइन वीडियो को सपोर्ट करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) मेथड स्वचालित प्लेबैक का अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **फ़ुल‑स्क्रीन मोड में वीडियो चलाएँ**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमोंस्ट्रेशन को फ़ुल‑स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) को `true` के साथ कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) खोजता है, और फ़ुल‑स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ्रेम होना चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

फ़ुल‑स्क्रीन प्लेबैक नियंत्रित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) यह निर्धारित करता है कि यह स्वचालित रूप से शुरू होता है या क्लिक पर, और [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) यह नियंत्रित करता है कि यह दोहराता है या नहीं। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग्स को बनाए रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमॉन्स्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना प्रस्तोता को फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिए [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) को `true` के साथ कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) खोजता है, और रीवाइंड सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू होने के लिए सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ्रेम होना चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

रीवाइंड करने से वीडियो उसकी शुरुआत में लौट आता है बिना फिर से शुरू किए। इसके विपरीत, [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) को `true` के साथ कॉल करने से प्लेबैक स्वचालित रूप से दोहराता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे तो लूपिंग को निष्क्रिय रखें। [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) स्वतंत्र रूप से स्वचालित या क्लिक पर स्टार्टअप को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तोता तय कर सके कि प्लेबैक कब शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) से स्वतंत्र रूप से काम करता है।

## **वीडियो फ्रेम को ट्रिम करें**

प्लेबैक के दौरान वीडियो की शुरुआत या अंत के भाग को छोड़ने के लिए आप [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) और [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) का उपयोग कर सकते हैं। दोनों मान मिलिसेकेंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स को बदलता है।

**ट्रिम सेटिंग्स निर्धारित करें**

यह उदाहरण स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है। एक प्ले करने योग्य भाग बचाने के लिए 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलिसेकेंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ भी प्रिंट नहीं होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण स्थानीय वीडियो एम्बेड करता है और English लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मिलना चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) क्लास भी एक ओवरलोड प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक नंबर आउटपुट फ़ाइलों को विशिष्ट रखते हैं। कंसोल निकाले गए ट्रैकों की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

प्रत्येक [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट को उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप पोजीशन पर वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और वह शेप एक वीडियो फ्रेम है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) के बजाय [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) मेथड का प्रयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग-अलग क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ा जाता है क्योंकि उनमें एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल गिनती प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता पर रिपोर्टेड मीडिया प्रकार से मेल खाने के लिए इसे बदलें।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (स्वचालित या क्लिक पर) और [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) ऑब्जेक्ट की मेथड्स के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो का लिंक जोड़ते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को वीडियो डेटा के बजाय संग्रहीत करती है, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को बिना उसकी स्थिति और आकार बदले बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) को बदल सकते हैं जबकि शेप की ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) का पता लगाया जा सकता है?**

हां। एक एम्बेडेड वीडियो में एक [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए इसे डिस्क पर सहेजते समय।