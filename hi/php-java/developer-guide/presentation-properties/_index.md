---
title: PHP में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/php-java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधन
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में प्रस्तुति गुणों को महारत से प्रबंधित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों गुण प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने के लिए [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) क्लास प्रदान करता है। इस क्लास का एक इंस्टेंस [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDocumentProperties) मेथड द्वारा लौटाया जाता है। निम्न उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सेव पर इन्हें पुनः लिखता है, इसलिए सहेजा गया प्रस्तुति हमेशा "Aspose.Slides for PHP via Java" और उस लाइब्रेरी का संस्करण दर्शाता है जिसने इसे बनाया था। `setNameOfApplication` को दिया गया कोई भी मान प्रस्तुति लिखते समय हटा दिया जाता है।
{{% /alert %}}

## **प्रेजेंटेशन गुण प्रबंधित करें**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण दस्तावेज़ (प्रस्तुति फ़ाइलों) के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुण हैं:

- सिस्टम परिभाषित (Built-in) गुण
- उपयोगकर्ता‑परिभाषित (Custom) गुण

**Built-in** गुण दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **Custom** गुण वे होते हैं जिन्हें उपयोगकर्ता द्वारा **नाम/मान** युग्म के रूप में परिभाषित किया जाता है, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for PHP via Java का उपयोग करके, डेवलपर बिल्ट‑इन गुणों और कस्टम गुणों दोनों के मानों तक पहुँच और उन्हें संशोधित कर सकते हैं।

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेन्यू आइटम को चुनना है, जैसा कि नीचे दिखाया गया है:

|**उन्नत गुण मेन्यू आइटम का चयन**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** मेन्यू आइटम चुनने के बाद, एक डायलॉग दिखाई देगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है, जैसा कि चित्र में दिखाया गया है:

|**गुण संवाद**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ऊपर के **गुण संवाद** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए उपयोग किया जाता है।

## **Aspose.Slides for PHP via Java का उपयोग करके दस्तावेज़ गुणों के साथ काम करना**

जैसा कि हमने पहले बताया, Aspose.Slides for PHP via Java दो प्रकार के दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom** गुण। इसलिए, डेवलपर Aspose.Slides for PHP via Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुँच सकते हैं। Aspose.Slides for PHP via Java एक क्लास **[DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties)** प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों का प्रतिनिधित्व करता है।

डेवलपर **[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation)** ऑब्जेक्ट द्वारा उजागर **DocumentProperties** प्रॉपर्टी का उपयोग करके प्रस्तुतियों के दस्तावेज़ गुणों तक नीचे वर्णित अनुसार पहुँच सकते हैं:

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड आमतौर पर प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब आप [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `false` पास करके प्रस्तुति को एन्क्रिप्ट करते हैं, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। तब एप्लिकेशन [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `true` पास करके ओपनिंग पासवर्ड नहीं देते हुए सार्वजनिक मेटाडाटा पढ़ सकता है।

`document‑properties‑only` विकल्प नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल होता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

नीचे दिया गया उदाहरण [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से लोडिंग मोड को सत्यापित करता है और फिर [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDocumentProperties) के द्वारा बिल्ट‑इन गुण पढ़ता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट्स अनुपलब्ध होते हैं। एप्लिकेशन को हमेशा [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) की जाँच करनी चाहिए इससे पहले कि वह ऐसी ऑपरेशन करे जिसके लिए पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडाटा में लेखक नाम, शीर्षक, विषय, कीवर्ड्स, कंपनी जानकारी, टिप्पणी और कस्टम मान शामिल हो सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना पहुँच की विशेष आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एन्क्रिप्टेड PPTX फ़ाइल के लिए, `document‑properties‑only` मोड में लोड किया गया प्रस्तुति मुख्यतः सार्वजनिक मेटाडाटा पढ़ने के लिए होता है। Aspose.Slides उस मेटाडाटा‑ओनली ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए अपडेट के लिए सही ओपनिंग पासवर्ड और पूर्ण लोड की आवश्यकता होती है।

नीचे दिया गया उदाहरण [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) के साथ प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके एन्क्रिप्शन बनाए रखा गया है या नहीं, सत्यापित करता है और पासवर्ड के बिना सार्वजनिक मेटाडाटा पुनः खोलकर नई मानों की पुष्टि करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

यदि किसी एप्लिकेशन को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने वाले रूप में मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँचें**

[DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा उजागर किए गए इन गुणों में शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**।

```php
  # प्रस्तुतिकरण को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट-इन गुण प्रदर्शित करें
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन गुणों को संशोधित करना उतना ही सरल है जितना कि उन्हें एक्सेस करना। आप बस किसी भी वांछित गुण को स्ट्रिंग मान असाइन कर सकते हैं और वह गुण संशोधित हो जाएगा। नीचे दिया गया उदाहरण दिखाता है कि हम Aspose.Slides for PHP via Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणों को कैसे संशोधित कर सकते हैं।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट-इन गुण निर्धारित करें
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # अपने प्रस्तुति को फ़ाइल में सहेजें
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह उदाहरण प्रस्तुति के बिल्ट‑इन गुणों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for PHP via Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी सुविधा देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम गुण कैसे सेट करें।

```php
  $pres = new Presentation();
  try {
    # दस्तावेज़ गुण प्राप्त कर रहे हैं
    $dProps = $pres->getDocumentProperties();
    # कस्टम गुण जोड़ रहे हैं
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # विशेष इंडेक्स पर प्रॉपर्टी नाम प्राप्त कर रहे हैं
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # चयनित गुण हटा रहे हैं
    $dProps->removeCustomProperty($getPropertyName);
    # प्रस्तुति सहेज रहे हैं
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**जोड़े गए कस्टम दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणों तक पहुँचें और संशोधित करें**

Aspose.Slides for PHP via Java डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुँच और उन्हें कैसे संशोधित कर सकते हैं।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़ी DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # कस्टम गुणों को एक्सेस करें और संशोधित करें
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # कस्टम गुणों के नाम और मान प्रदर्शित करें
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # कस्टम गुणों के मान संशोधित करें
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह उदाहरण [PPTX](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति के कस्टम गुणों को संशोधित करता है। नीचे के चित्रों में संशोधन से पहले और बाद के कस्टम गुण दिखाए गये हैं:

|**संशोधन से पहले कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुण**

{{% alert color="info" title="Note" %}}
नए मेथड्स **[readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)**, **[updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)** और **[writeBindedPresentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)** को **[PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo)** में जोड़ा गया है, तथा **[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#setLastSavedTime)** प्रॉपर्टी सेट्टर की लॉजिक बदली गई है।
{{% /alert %}}

दो नए मेथड्स **[readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)** और **[updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)** को **[PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo)** क्लास में जोड़ा गया है। ये मेथड्स दस्तावेज़ गुणों तक तेज़ पहुँच प्रदान करते हैं और पूरी प्रस्तुति लोड किए बिना गुणों को बदलने और अपडेट करने की अनुमति देते हैं।

सामान्य परिदृश्य: गुण लोड करें, कुछ मान बदलें और दस्तावेज़ को अपडेट करें, इसे आप नीचे दर्शाए अनुसार लागू कर सकते हैं:

```php
  # प्रस्तुति की जानकारी पढ़ें
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # वर्तमान गुण प्राप्त करें
  $props = $info->readDocumentProperties();
  # लेखक और शीर्षक फ़ील्ड के नए मान सेट करें
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # नई मानों के साथ प्रस्तुति को अपडेट करें
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

एक अन्य तरीका है कि किसी विशिष्ट प्रस्तुति के गुणों को टेम्प्लेट के रूप में उपयोग करके अन्य प्रस्तुतियों के गुण अपडेट किए जाएँ:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

नई टेम्प्लेट को शून्य से बनाकर कई प्रस्तुतियों को अपडेट किया जा सकता है:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides **LanguageId** प्रॉपर्टी (जो **PortionFormat** क्लास द्वारा उजागर है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह PHP कोड दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें: xxx Java PortionFormat क्लास में LanguageId क्यों नहीं है?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// प्रूफ़िंग भाषा का Id सेट करें

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह PHP कोड दिखाता है कि पूरी PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट करें:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # नई आयताकार आकृति को टेक्स्ट के साथ जोड़ता है
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # पहले भाग की भाषा जाँचता है
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लाइव उदाहरण**

ऑनलाइन ऐप **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** को आज़माएँ और Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ काम करना देखें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **FAQ**

**एक बिल्ट‑इन गुण को प्रस्तुति से कैसे हटाया जा सकता है?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उन्हें बदल सकते हैं या यदि विशेष गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। आप [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) का उपयोग करके फिर [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) को बुला सकते हैं, जिससे [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना संग्रहीत दस्तावेज़ मेटाडाटा पढ़ा जा सकता है। विस्तृत रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें **[Build a Lightweight Presentation Inventory](/slides/hi/php-java/examine-presentation/)**।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को बिना ओपनिंग पासवर्ड के पढ़ सकता हूँ?**

हाँ। दस्तावेज़‑गुण एन्क्रिप्शन को एन्क्रिप्ट करने से पहले अक्षम किया होना चाहिए, और प्रस्तुति को `document‑properties‑only` मोड में लोड किया जाना चाहिए।

**क्या मैं एन्क्रिप्टेड PPTX फ़ाइल को `document‑properties‑only` मोड में अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रखना आवश्यक है, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही ओपनिंग पासवर्ड के साथ पूरा प्रस्तुति लोड करना आवश्यक है।