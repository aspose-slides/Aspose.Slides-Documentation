---
title: PHP में प्रस्तुति स्लाइड्स क्लोन करें
linktitle: स्लाइड क्लोन करें
type: docs
weight: 35
url: /hi/php-java/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के साथ PowerPoint स्लाइड्स को जल्दी से डुप्लिकेट करें। सेकंडों में PPT निर्माण को स्वचालित करने और मैन्युअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों का अनुसरण करें।"
---
## **परिचय**

क्लोनिंग किसी वस्तु की सटीक प्रति या प्रतिरूप बनाने की प्रक्रिया है। Aspose.Slides for PHP via Java यह भी संभव बनाता है कि किसी भी स्लाइड की प्रतिलिपि या क्लोन बनाया जाए और फिर उस क्लोन किए गए स्लाइड को वर्तमान या किसी अन्य खुले हुए प्रस्तुति में सम्मिलित किया जाए। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रस्तुति के भीतर अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थिति में क्लोन करें।
- दूसरी प्रस्तुति में अंत में क्लोन करें।
- दूसरी प्रस्तुति में किसी अन्य स्थिति में क्लोन करें।
- दूसरी प्रस्तुति में किसी विशिष्ट स्थिति में क्लोन करें।

Aspose.Slides for PHP via Java में, (एक संग्रह जिसमें [स्लाइड](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Slide) वस्तुएँ होती हैं) जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वस्तु द्वारा उजागर किया गया है, [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) और [insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#insertClone) मेथड्स प्रदान करता है जिससे उपरोक्त प्रकार के स्लाइड क्लोनिंग को किया जा सकता है।

## **प्रेजेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड का उपयोग करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
2. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वस्तु द्वारा उजागर स्लाइड संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट प्राप्त करें।
3. [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट द्वारा उपलब्ध [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को पैरामीटर के रूप में पास करें।
4. परिवर्तित प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्थिति (शून्य इंडेक्स) में स्थित स्लाइड को प्रस्तुति के अंत में क्लोन किया है।

```php
  # प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंटिएट करें
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # उसी प्रेज़ेंटेशन में स्लाइड्स के संग्रह के अंत में वांछित स्लाइड को क्लोन करें
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # परिवर्तित प्रेज़ेंटेशन को डिस्क पर लिखें
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **प्रेजेंटेशन के भीतर किसी अन्य स्थिति में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रस्तुति फ़ाइल में लेकिन अलग स्थिति में उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#insertClone) मेथड का उपयोग करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
2. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वस्तु द्वारा उजागर [**Slides**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection) ऑब्जेक्ट प्राप्त करें।
3. [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट द्वारा उपलब्ध [insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#insertClone) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड के साथ नए स्थान के इंडेक्स को पैरामीटर के रूप में पास करें।
4. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के शून्य इंडेक्स (स्थिति 1) में स्थित स्लाइड को इंडेक्स 1 – स्थिति 2 – में क्लोन किया है।

```php
  # प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इनस्टैंटिएट करें
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # एक ही प्रेज़ेंटेशन में स्लाइड्स के संग्रह के अंत में वांछित स्लाइड को क्लोन करें
    $slds = $pres->getSlides();
    # एक ही प्रेज़ेंटेशन में निर्दिष्ट इंडेक्स पर वांछित स्लाइड को क्लोन करें
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # परिवर्तित प्रेज़ेंटेशन को डिस्क पर लिखें
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **दूसरी प्रस्तुति के अंत में स्लाइड क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके उसे दूसरी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना है:

1. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें वह प्रस्तुति है जिससे स्लाइड को क्लोन किया जाएगा।
2. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें लक्ष्य प्रस्तुति है जिसमें स्लाइड जोड़ी जाएगी।
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर [**Slides**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection) ऑब्जेक्ट प्राप्त करें।
4. [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट द्वारा उपलब्ध [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को पैरामीटर के रूप में पास करें।
5. परिवर्तित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है।

```php
  # स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास को इनस्टैंटिएट करें
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # लक्ष्य PPTX (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इनस्टैंटिएट करें
    $destPres = new Presentation();
    try {
      # स्रोत प्रस्तुति से वांछित स्लाइड को लक्ष्य प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # लक्ष्य प्रस्तुति को डिस्क पर लिखें
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **दूसरी प्रस्तुति में किसी अन्य स्थिति में स्लाइड क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके उसे दूसरी प्रस्तुति फ़ाइल में किसी विशिष्ट स्थिति में उपयोग करना है:

1. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें स्रोत प्रस्तुति है जिससे स्लाइड को क्लोन किया जाएगा।
2. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें लक्ष्य प्रस्तुति है जिसमें स्लाइड जोड़ी जाएगी।
3. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) क्लास प्राप्त करें।
4. [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट द्वारा उपलब्ध [insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#insertClone) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड के साथ इच्छित स्थिति को पैरामीटर के रूप में पास करें।
5. परिवर्तित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स से स्लाइड को लक्ष्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) में क्लोन किया है।

```php
  # स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास को इनस्टैंटिएट करें
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # लक्ष्य PPTX (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इनस्टैंटिएट करें
    $destPres = new Presentation();
    try {
      # स्रोत प्रस्तुति से वांछित स्लाइड को लक्ष्य प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # लक्ष्य प्रस्तुति को डिस्क पर लिखें
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **दूसरी प्रस्तुति में विशिष्ट स्थान पर स्लाइड क्लोन करें**
यदि आपको एक प्रस्तुति से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके उसे दूसरी प्रस्तुति में उपयोग करना है, तो पहले स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति में क्लोन करना होगा। फिर उस मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन किया जाता है। [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) मेथड लक्ष्य प्रस्तुति के मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत प्रस्तुति के। स्लाइड को मास्टर के साथ क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें स्रोत प्रस्तुति है जिससे स्लाइड को क्लोन किया जाएगा।
2. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें लक्ष्य प्रस्तुति है जिसमें स्लाइड को क्लोन किया जाएगा।
3. क्लोन की जाने वाली स्लाइड को उसके मास्टर स्लाइड के साथ एक्सेस करें।
4. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर Masters संग्रह को संदर्भित करके [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterSlideCollection) क्लास का इंस्टेंस बनाएँ।
5. [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MasterSlideCollection) ऑब्जेक्ट द्वारा उपलब्ध [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड को कॉल करें और स्रोत PPTX से क्लोन किए जाने वाले मास्टर को पैरामीटर के रूप में पास करें।
6. लक्ष्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा उजागर Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) क्लास को इंस्टेंस करें।
7. [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSlides) ऑब्जेक्ट द्वारा उपलब्ध [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड को कॉल करें और स्रोत प्रस्तुति से क्लोन की जाने वाली स्लाइड और मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
8. परिवर्तित लक्ष्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स में स्थित मास्टर के साथ स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है।

```php
  # स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास को इनस्टैंटिएट करें
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # लक्ष्य प्रस्तुति (जहाँ स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इनस्टैंटिएट करें
    $destPres = new Presentation();
    try {
      # स्रोत प्रस्तुति में स्लाइड्स के संग्रह से ISlide को इनस्टैंटिएट करें साथ में
      # मास्टर स्लाइड
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में क्लोन करें
      # लक्ष्य प्रस्तुति
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में क्लोन करें
      # लक्ष्य प्रस्तुति
      $iSlide = $masters->addClone($SourceMaster);
      # स्रोत प्रस्तुति से वांछित मास्टर के साथ वांछित स्लाइड को अंत में क्लोन करें
      # लक्ष्य प्रस्तुति में स्लाइड्स के संग्रह में
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # लक्ष्य प्रस्तुति को डिस्क पर सहेजें
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **निर्दिष्ट अनुभाग के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रस्तुति फ़ाइल में लेकिन किसी अन्य अनुभाग में उपयोग करना चाहते हैं, तो [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection/#addClone) मेथड का उपयोग करें जो [SlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideCollection) क्लास द्वारा प्रदान किया गया है। Aspose.Slides for PHP via Java यह संभव बनाता है कि पहली अनुभाग से स्लाइड को क्लोन करके उसी प्रस्तुति के दूसरे अनुभाग में सम्मिलित किया जाए।

निम्न कोड स्निपेट दिखाता है कि कैसे स्लाइड को क्लोन करके निर्दिष्ट अनुभाग में सम्मिलित किया जाए।

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # लक्ष्य प्रस्तुति को डिस्क पर सहेजें
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **स्लाइड आकार की समानता सुनिश्चित करें**
जब स्लाइड को किसी अन्य प्रस्तुति में क्लोन किया जाता है, तो सुनिश्चित करें कि लक्ष्य प्रस्तुति का स्लाइड आकार स्रोत के समान हो। यदि आकार अलग होते हैं, तो Aspose.Slides क्लोन किए गए आकारों को स्वचालित रूप से री‑स्केल नहीं करता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री गलत संरेखित या स्लाइड की सीमाओं से बाहर जा सकती है।

आप क्लोन करने से पहले स्रोत के साथ मिलाने के लिए लक्ष्य प्रस्तुति का स्लाइड आकार इस प्रकार सेट कर सकते हैं:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

क्लोन करने और स्लाइड तथा मास्टर को क्लोन करने से पहले यह करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और समीक्षक टिप्पणियां क्लोन की जाती हैं?**

हाँ। नोट्स पेज और समीक्षा टिप्पणियां क्लोन में शामिल होते हैं। यदि आप उन्हें नहीं चाहते, तो सम्मिलन के बाद उन्हें [हटाएँ](/slides/hi/php-java/presentation-notes/)।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी किया जाता है। यदि चार्ट बाहरी स्रोत (जैसे OLE‑एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE object](/slides/hi/php-java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन के सम्मिलन स्थान और अनुभागों को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [section](/slides/hi/php-java/slide-section/) में रख सकते हैं। यदि लक्ष्य अनुभाग मौजूद नहीं है, तो पहले उसे बनाएँ और फिर स्लाइड को उसमें ले जाएँ।