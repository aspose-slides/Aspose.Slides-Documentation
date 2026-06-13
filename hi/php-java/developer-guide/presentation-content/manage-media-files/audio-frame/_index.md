---
title: PHP का उपयोग करके प्रस्तुतियों में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/php-java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो प्रॉपर्टीज़
- ऑडियो विकल्प
- ऑडियो निकालें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP में ऑडियो फ्रेम बनाएं और नियंत्रित करें—एंबेड, ट्रिम, लूप और PPT, PPTX, तथा ODP प्रस्तुतियों में प्लेबैक कॉन्फ़िगर करने के कोड उदाहरण।"
---
## **परिचय**

यह लेख Aspose.Slides में ऑडियो फ्रेम के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में एंबेडेड ऑडियो कैसे जोड़ें, ऑडियो फ्रेम थंबनेल को अनुकूलित करें, वॉल्यूम, लूपिंग, छिपाने, ट्रिमिंग और फेड अवधि जैसे प्लेबैक विकल्पों को कॉन्फ़िगर करें, तथा स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को निकालें।

## **ऑडियो फ्रेम बनाएं**

Aspose.Slides for PHP via Java आपको स्लाइड में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड में ऑडियो फ्रेम के रूप में एंबेड की जाती हैं।

1. Presentation क्लास का एक उदाहरण बनाएँ।  
   `{{`**[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation)**`}}`
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में एंबेड करने के लिए ऑडियो फ़ाइल स्ट्रीम लोड करें।  
4. स्लाइड में एंबेडेड ऑडियो फ्रेम (जिसमें ऑडियो फ़ाइल है) जोड़ें।  
5. AudioFrame ऑब्जेक्ट द्वारा प्रदान किए गए **[PlayMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AudioPlayModePreset)** और `Volume` सेट करें।  
   `{{`**[AudioFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/)**`}}`
6. संशोधित प्रस्तुति सहेजें।

यह PHP कोड दिखाता है कि कैसे स्लाइड में एंबेडेड ऑडियो फ्रेम जोड़ें:

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
$pres = new Presentation();
try {
    # पहला स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # wav ध्वनि फ़ाइल को स्ट्रीम में लोड करता है
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # ऑडियो फ्रेम जोड़ता है
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # ऑडियो के प्ले मोड और वॉल्यूम सेट करता है
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint फ़ाइल को डिस्क पर लिखता है
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **ऑडियो फ्रेम थंबनेल बदलें**

जब आप प्रस्तुति में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक स्टैंडर्ड डिफ़ॉल्ट इमेज वाले फ्रेम के रूप में दिखता है (नीचे चित्र देखें)। आप ऑडियो फ्रेम की प्रीव्यू इमेज (अपनी पसंदीदा इमेज) सेट करके बदल सकते हैं।

यह PHP कोड दिखाता है कि कैसे ऑडियो फ्रेम का थंबनेल या प्रीव्यू इमेज बदला जाए:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# स्लाइड में निर्दिष्ट स्थिति और आकार के साथ एक ऑडियो फ्रेम जोड़ता है।
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# प्रस्तुति संसाधनों में एक छवि जोड़ता है।
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# ऑडियो फ्रेम के लिए छवि सेट करता है।
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# संशोधित प्रस्तुति को डिस्क पर सहेजता है।
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for PHP via Java आपको ऑडियो की प्लेबैक या प्रॉपर्टीज़ को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूपेड चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकन को छिपा भी सकते हैं।

PowerPoint में **Audio Options** पैन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/) प्रॉपर्टियों से मेल खाती हैं:

- **Start** ड्रॉप‑डाउन सूची [AudioFrame::setPlayMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setPlayMode) मेथड से मेल खाती है
- **Volume** [AudioFrame::setVolume](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setVolume) मेथड से मेल खाती है
- **Play Across Slides** [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) मेथड से मेल खाती है
- **Loop until Stopped** [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setPlayLoopMode) मेथड से मेल खाती है
- **Hide During Show** [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setHideAtShowing) मेथड से मेल खाती है
- **Rewind after Playing** [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setRewindAudio) मेथड से मेल खाती है

PowerPoint **Editing** विकल्प जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/) प्रॉपर्टियों से मेल खाते हैं:

- **Fade In** [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setFadeInDuration) मेथड से मेल खाता है
- **Fade Out** [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setFadeOutDuration) मेथड से मेल खाता है
- **Trim Audio Start Time** [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setTrimFromStart) मेथड से मेल खाता है
- **Trim Audio End Time** मान ऑडियो की कुल अवधि में से [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setTrimFromEnd) मेथड के मान को घटाकर प्राप्त होता है

PowerPoint **Volume controll** ऑडियो कंट्रोल पैनल पर [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#setVolumeValue) मेथड से मेल खाता है। यह आपको ऑडियो वॉल्यूम को प्रतिशत में बदलने की सुविधा देती है।

यहाँ बताया गया है कि आप Audio Play विकल्प कैसे बदल सकते हैं:

1. [Create](#create-audio-frame) या Audio Frame प्राप्त करें।  
2. उन Audio Frame प्रॉपर्टियों के नए मान सेट करें जिन्हें आप बदलना चाहते हैं।  
3. संशोधित PowerPoint फ़ाइल सहेजें।

यह PHP कोड दर्शाता है कि कैसे ऑडियो के विकल्पों को समायोजित किया जाता है:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # ऑडियोफ़्रेम शैप प्राप्त करता है
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # प्ले मोड को क्लिक पर चलाने के लिए सेट करता है
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # वॉल्यूम को लो सेट करता है
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # ऑडियो को सभी स्लाइड पर चलाने के लिए सेट करता है
    $audioFrame->setPlayAcrossSlides(true);
    # ऑडियो के लिए लूप को निष्क्रिय करता है
    $audioFrame->setPlayLoopMode(false);
    # स्लाइड शो के दौरान ऑडियोफ़्रेम को छिपाता है
    $audioFrame->setHideAtShowing(true);
    # प्ले होने के बाद ऑडियो को शुरुआत में रीवाइंड करता है
    $audioFrame->setRewindAudio(true);
    # PowerPoint फ़ाइल को डिस्क पर सहेजता है
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

यह PHP उदाहरण दिखाता है कि कैसे एंबेडेड ऑडियो वाला नया ऑडियो फ्रेम जोड़ा जाए, उसे ट्रिम किया जाए, और फेड अवधि सेट की जाए:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // ट्रिमिंग की प्रारंभिक ऑफ़सेट को 1.5 सेकंड पर सेट करता है
    $audioFrame->setTrimFromStart(1500);
    // ट्रिमिंग की समाप्ति ऑफ़सेट को 2 सेकंड पर सेट करता है
    $audioFrame->setTrimFromEnd(2000);

    // फेड-इन अवधि को 200 मिलीसेकंड पर सेट करता है
    $audioFrame->setFadeInDuration(200);
    // फेड-आउट अवधि को 500 मिलीसेकंड पर सेट करता है
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

निम्न कोड नमूना दिखाता है कि एंबेडेड ऑडियो वाले ऑडियो फ्रेम को प्राप्त करके उसकी वॉल्यूम को 85 % पर कैसे सेट किया जाए:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // एक ऑडियो फ़्रेम आकार प्राप्त करता है
    $audioFrame = $slide->getShapes()->get_Item(0);

    // ऑडियो वॉल्यूम को 85% पर सेट करता है
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको [getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#getCaptionTracks) मेथड के द्वारा ऑडियो फ्रेम में बंद कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक जोड़ सकते हैं, मौजूदा ट्रैक पर इटेरेट कर सकते हैं, और आवश्यकता पड़ने पर उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

[ getCaptionTracks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/#getCaptionTracks) मेथड का उपयोग करके एक या अधिक कैप्शन ट्रैक को ऑडियो फ्रेम से संलग्न करें। नीचे दिए गए उदाहरण में, एक ऑडियो फ़ाइल स्लाइड में जोड़ी गई है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया गया है।

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ्रेम से जुड़े कैप्शन ट्रैकों पर इटेरेट करके उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और एक अद्वितीय पहचानकर्ता एक्सपोज़ करता है, जिसे कैप्शन निर्यात करते समय उपयोग किया जा सकता है।

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // प्रत्येक कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**ऑडियो कैप्शन हटाएँ**

ऑडियो फ्रेम से कैप्शन हटाने के लिए [CaptionsCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/) द्वारा प्रदान किए गए मेथड, जैसे [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#remove), या [removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। नीचे दिया गया उदाहरण ऑडियो फ्रेम से सभी कैप्शन ट्रैक हटाता है।

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // प्रकार: AudioFrame

    // ऑडियो फ़्रेम से सभी कैप्शन ट्रैक हटाएँ।
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ऑडियो निकालें**

Aspose.Slides for PHP via Java आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए ध्वनि को निकालने की सुविधा देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग हुई ध्वनि को निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाकर वह प्रस्तुति लोड करें जिसमें ऑडियो मौजूद है।  
2. स्लाइड के इंडेक्स के माध्य म से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड के लिए [slideshow transitions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getSlideShowTransition) तक पहुँचें।  
4. ध्वनि को बाइट डेटा के रूप में निकालें।

यह कोड दिखाता है कि स्लाइड में उपयोग किए गए ऑडियो को कैसे निकाला जाए:

```php
# एक Presentation क्लास का उदाहरण बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# वांछित स्लाइड तक पहुँचता है
	$slide = $pres->getSlides()->get_Item(0);
	# स्लाइड के लिए स्लाइड शो ट्रांज़िशन इफ़ेक्ट प्राप्त करता है
	$transition = $slide->getSlideShowTransition();
	# ध्वनि को बाइट एरे में निकालता है
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को एक से अधिक स्लाइड में पुनः उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हां। प्रस्तुति के साझा [audio collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getaudios/) में ऑडियो को एक बार जोड़ें और अतिरिक्त ऑडियो फ्रेम बनाएं जो उस मौजूदा एसेट को रेफ़रेंस करें। इससे मीडिया डेटा की डुप्लिकेशन नहीं होगी और प्रस्तुति का आकार नियंत्रित रहेगा।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बदल सकते बिना शAPE को पुनः बनाये?**

हां। लिंक्ड ध्वनि के लिए, [link path](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/setlinkpathlong/) को नए फ़ाइल की ओर इंगित करने के लिए अपडेट करें। एंबेडेड ध्वनि के लिए, प्रस्तुति की [audio collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getaudios/) से किसी अन्य एंबेडेड ऑडियो ऑब्जेक्ट को बदलें। फ्रेम की फॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत मूल ऑडियो डेटा को बदलती है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहती हैं और एंबेडेड ऑडियो या प्रस्तुति की ऑडियो कलेक्शन के माध्यम से उपलब्ध रहती हैं।