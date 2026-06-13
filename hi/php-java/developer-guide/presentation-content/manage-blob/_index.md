---
title: PHP में प्रस्तुति BLOBs को कुशल मेमोरी उपयोग के लिए प्रबंधित करें
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/php-java/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ी वस्तु
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी घटाएँ
- मेमोरी खपत
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के लिए PHP विया Java में BLOB डेटा को प्रबंधित करके PowerPoint और OpenDocument फ़ाइल संचालन को सुव्यवस्थित किया जाता है, जिससे प्रस्तुति हैंडलिंग कुशल बनती है।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में बड़े बाइनरी डेटा को संभालने के लिए BLOB‑आधारित हैंडलिंग प्रदान करता है, जिससे बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी खपत कम हो जाती है।

यह लेख दर्शाता है कि कैसे BLOB‑आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़े मीडिया को जोड़ा जाए, प्रस्तुति से बड़े मीडिया को निर्यात किया जाए, और बड़े प्रस्तुतियों को अधिक कुशलता से लोड किया जाए। यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें स्टोर करने वाले फ़ोल्डर को कैसे बदला जा सकता है।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी स्वरूप में सहेजा जाता है।

Aspose.Slides for PHP via Java आपको बड़े फ़ाइलों के साथ काम करते समय मेमोरी खपत को कम करने के लिए ऑब्जेक्ट्स के लिए BLOB का उपयोग करने की अनुमति देता है।

{{% alert title="Info" color="info" %}}

स्ट्रीम्स के साथ इंटरैक्ट करने पर कुछ सीमाओं को पार करने के लिए, Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम के माध्यम से एक बड़ी प्रस्तुति को लोड करने से प्रस्तुति की सामग्री की प्रतिलिपि बनती है और लोडिंग धीमी हो जाती है। इसलिए, जब आप बड़ी प्रस्तुति को लोड करने का इरादा रखते हैं, तो हम दृढ़ता से अनुशंसा करते हैं कि आप प्रस्तुति फ़ाइल पथ का उपयोग करें, न कि उसकी स्ट्रीम।

{{% /alert %}}

## **मेमोरी खपत को कम करने के लिए BLOB का उपयोग करें**

### **BLOB के माध्यम से प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/php-java/) for Java आपको BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस मामले में, एक बड़ी वीडियो फ़ाइल) जोड़ने की अनुमति देता है, जिससे मेमोरी खपत कम होती है।

यह Java कोड दर्शाता है कि कैसे BLOB प्रक्रिया के माध्यम से बड़ी वीडियो फ़ाइल को प्रस्तुति में जोड़ा जाए:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # एक नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # चलिए वीडियो को प्रस्तुति में जोड़ते हैं - हमने KeepLocked व्यवहार चुना क्योंकि हम
      # "veryLargeVideo.avi" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # प्रस्तुति सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी खपत
      # प्रेज़ ऑब्जेक्ट के लाइफ़साइकल के दौरान कम रहती है
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **BLOB के माध्यम से प्रस्तुति से बड़ी फ़ाइल निर्यात करें**
Aspose.Slides for PHP via Java आपको BLOB प्रक्रिया के माध्यम से प्रस्तुतियों से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको प्रस्तुति से एक बड़ी मीडिया फ़ाइल निकालनी पड़ सकती है, लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करने से मेमोरी खपत कम रहती है।

यह कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # स्रोत फ़ाइल को लॉक करता है और इसे मेमोरी में लोड नहीं करता
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Presentation का इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # चलिए प्रत्येक वीडियो को फ़ाइल में सहेजते हैं। उच्च मेमोरी उपयोग को रोकने के लिए हमें एक बफ़र चाहिए जो उपयोग किया जाएगा
    # प्रस्तुति के वीडियो स्ट्रीम से डेटा को नए बनाए गए वीडियो फ़ाइल के स्ट्रीम में ट्रांसफ़र करने के लिए।
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # वीडियोज़ पर इटररेट करता है
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # प्रस्तुति वीडियो स्ट्रीम खोलता है। कृपया ध्यान दें कि हमने जानबूझकर प्रॉपर्टीज़ तक पहुंच से बचा है
      # जैसे video.BinaryData - क्योंकि यह प्रॉपर्टी पूरे वीडियो को शामिल करने वाला बाइट एरे रिटर्न करती है, जो फिर
      # बाइट्स को मेमोरी में लोड करने का कारण बनता है। हम video.GetStream का उपयोग करते हैं, जो स्ट्रीम रिटर्न करेगा - और नहीं
      # आवश्यक बनाता है कि हम पूरे वीडियो को मेमोरी में लोड करें।
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # मेमोरी खपत वीडियो या प्रस्तुति के आकार की परवाह किए बिना कम रहेगी।
    }
    # यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी वही चरण लागू कर सकते हैं।
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **एक छवि को BLOB के रूप में प्रस्तुति में जोड़ें**
[ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) क्लास की विधियों का उपयोग करके आप बड़ी छवि को स्ट्रीम के रूप में जोड़ सकते हैं ताकि उसे BLOB के रूप में माना जाए।

यह PHP कोड दिखाता है कि कैसे BLOB प्रक्रिया के माध्यम से बड़ी छवि को जोड़ा जाए:

```php
  $pathToLargeImage = "large_image.jpg";
  # नई प्रस्तुति बनाता है जिसमें छवि जोड़ी जाएगी।
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # चलिए छवि को प्रस्तुति में जोड़ते हैं - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
      # "largeImage.png" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी खपत
      # प्रेज़ ऑब्जेक्ट के लाइफ़साइकल के दौरान कम रहती है
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, बड़ी प्रस्तुति को लोड करने के लिए कंप्यूटर को बहुत अधिक अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की सारी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) अब उपयोग नहीं की जाती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB का वीडियो फ़ाइल है। इस PHP कोड में प्रस्तुति लोड करने की मानक विधि दर्शाई गई है:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी consume करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB प्रक्रिया के माध्यम से आप बड़ी प्रस्तुति को कम मेमोरी का उपयोग करके लोड कर सकते हैं। यह PHP कोड दर्शाता है कि कैसे BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) को लोड किया जाए:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **अस्थायी फ़ाइलों के लिए फ़ोल्डर बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, तो आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइल फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अन्य फ़ोल्डर में रखी जाएँ, तो आप `setTempFilesRootPath` का उपयोग करके स्टोरेज सेटिंग्स बदल सकते हैं:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}

जब आप `setTempFilesRootPath` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को स्टोर करने के लिए फ़ोल्डर नहीं बनाता। आपको मैन्युअली फ़ोल्डर बनाना होगा।

{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट को डिस्पोज़ करें**

बड़े प्रस्तुतियों को प्रोसेस करते समय, सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को सही तरीके से डिस्पोज़ किया जाए ताकि वह उपयोग की गई मेमोरी रिलीज़ हो सके। प्रस्तुति का उपयोग समाप्त होने पर `dispose()` कॉल करें ताकि अनमैनेज्ड रिसोर्सेज़ मुक्त हो जाएँ।

```php
$presentation = new Presentation("large.pptx");

# ...प्रस्तुति को प्रोसेस करें...
$presentation->save("large.pdf", SaveFormat::Pdf);

# स्पष्ट रूप से संसाधनों को मुक्त करें।
$presentation->dispose();
```

## **FAQ**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB माना जाता है और BLOB विकल्पों द्वारा नियंत्रित किया जाता है?**

छवियों, ऑडियो और वीडियो जैसी बड़ी बाइनरी ऑब्जेक्ट्स को BLOB माना जाता है। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करने पर BLOB हैंडलिंग में शामिल होती है। इन ऑब्जेक्ट्स को BLOB नीतियों द्वारा नियंत्रित किया जाता है, जो आपको मेमोरी उपयोग प्रबंधित करने और आवश्यकता पड़ने पर अस्थायी फ़ाइलों में स्पिल करने की अनुमति देती हैं।

**प्रस्तुति लोडिंग के दौरान BLOB हैंडलिंग नियम कहाँ कॉन्फ़िगर करें?**

[LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहाँ आप BLOB के लिए इन‑मेमोरी सीमा, अस्थायी फ़ाइलों की अनुमति/अनुमति हटाना, अस्थायी फ़ाइलों की रूट पाथ और सोर्स लॉकिंग व्यवहार सेट करते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी का संतुलन कैसे करें?**

हां। BLOB को मेमोरी में रखने से गति अधिकतम होती है लेकिन RAM खपत बढ़ती है; मेमोरी सीमा कम करने से अधिक काम अस्थायी फ़ाइलों पर जाता है, जिससे RAM कम होती है लेकिन अतिरिक्त I/O लागत आती है। अपनी कार्यभार और वातावरण के अनुसार सही संतुलन पाने के लिए आप [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) मेथड का उपयोग करें।

**क्या अत्यधिक बड़े प्रस्तुतियों (जैसे गीगाबाइट्स) को खोलते समय BLOB विकल्प मदद करते हैं?**

हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/blobmanagementoptions/) ऐसे परिदृश्यों के लिए डिज़ाइन किए गए हैं: अस्थायी फ़ाइलों को सक्षम करना और सोर्स लॉकिंग का उपयोग करना शीर्ष RAM उपयोग को काफी कम कर सकता है और बहुत बड़ी डेक्स की प्रोसेसिंग को स्थिर कर सकता है।

**क्या मैं डिस्क फ़ाइलों के बजाय स्ट्रीम्स से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**

हां। वही नियम स्ट्रीम्स पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को स्वामित्व और लॉक कर सकता है (चुनी गई लॉकिंग मोड पर निर्भर), और जब अनुमति हो तो अस्थायी फ़ाइलें उपयोग की जाती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमेय रहता है।