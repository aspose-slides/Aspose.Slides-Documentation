---
title: PHP में प्रस्तुति गुणधर्म प्रबंधित करें
linktitle: प्रस्तुति गुणधर्म
type: docs
weight: 70
url: /hi/php-java/presentation-properties/
keywords:
- PowerPoint गुणधर्म
- प्रेजेंटेशन गुणधर्म
- दस्तावेज़ गुणधर्म
- बिल्ट‑इन गुणधर्म
- कस्टम गुणधर्म
- उन्नत गुणधर्म
- गुणधर्म प्रबंधित करें
- गुणधर्म संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में प्रस्तुति गुणधर्मों को पूरी तरह नियंत्रित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणधर्मों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणधर्मों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुतिकरण दस्तावेज़ गुणधर्मों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास का एक उदाहरण [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDocumentProperties) मेथड द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणधर्मों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="primary" %}} 
कृपया ध्यान दें कि **Application** और **Producer** फ़ील्ड संशोधित नहीं किए जा सकते हैं, क्योंकि ये फ़ील्ड हमेशा "Aspose Ltd." और "Aspose.Slides for PHP via Java x.x.x" प्रदर्शित करेंगे।
{{% /alert %}} 

## **प्रेजेंटेशन गुणधर्म प्रबंधन**

Microsoft PowerPoint कुछ गुणधर्मों को प्रस्तुतिकरण फ़ाइलों में जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुणधर्म उपयोगी जानकारी को दस्तावेज़ (प्रेजेंटेशन फ़ाइल) के साथ संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुणधर्म निम्नलिखित हैं:

- सिस्टम परिभाषित (Built-in) गुणधर्म
- उपयोगकर्ता-परिभाषित (Custom) गुणधर्म

**Built-in** गुणधर्म दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ सांख्यिकी आदि। **Custom** गुणधर्म वे होते हैं जिन्हें उपयोगकर्ता **नाम/मान** जोड़े के रूप में परिभाषित करते हैं, जहाँ दोनों नाम और मान उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for PHP via Java का उपयोग करके डेवलपर्स बिल्ट‑इन और कस्टम दोनों गुणधर्मों के मानों तक पहुंच और संशोधन कर सकते हैं।

## **PowerPoint में दस्तावेज़ गुणधर्म**

Microsoft PowerPoint 2007 प्रस्तुतिकरण फ़ाइलों के दस्तावेज़ गुणधर्मों का प्रबंधन करने की अनुमति देता है। आपको बस Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेन्यू आइटम चुनना है जैसा कि नीचे दिखाया गया है:

|**उन्नत गुणधर्म मेन्यू आइटम चुनना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** मेन्यू आइटम चुनने के बाद एक संवाद बॉक्स प्रकट होता है जिससे आप PowerPoint फ़ाइल के दस्तावेज़ गुणधर्मों को नीचे दिखाए अनुसार प्रबंधित कर सकते हैं:

|**गुणधर्म संवाद**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

उपरोक्त **गुणधर्म संवाद** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणधर्मों को प्रबंधित करने के लिए उपयोग किया जाता है।

Aspose.Slides for PHP via Java का उपयोग करके दस्तावेज़ गुणधर्मों के साथ काम करना

जैसा कि हमने पहले बताया था, Aspose.Slides for PHP via Java दो प्रकार के दस्तावेज़ गुणधर्मों का समर्थन करता है, जो **Built-in** और **Custom** गुणधर्म हैं। इसलिए, डेवलपर्स Aspose.Slides for PHP via Java API के उपयोग से दोनों प्रकार के गुणधर्मों तक पहुंच सकते हैं। Aspose.Slides for PHP via Java एक क्लास [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties) प्रदान करता है जो **Presentation.DocumentProperties** गुणधर्म के माध्यम से प्रस्तुतिकरण फ़ाइल से जुड़े दस्तावेज़ गुणधर्मों को दर्शाता है।

डेवलपर्स नीचे वर्णित अनुसार प्रस्तुति फ़ाइलों के दस्तावेज़ गुणधर्मों तक पहुँचने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर **DocumentProperties** गुणधर्म का उपयोग कर सकते हैं:

## **Built-in गुणधर्म तक पहुंच**

इन गुणधर्मों को [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा उजागर किया गया है और इनमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (सृजन तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject** और **Title**.

```php
  # प्रस्तुति को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट‑इन गुणधर्म दिखाएँ
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

## **Built-in गुणधर्म संशोधित करना**

प्रेजेंटेशन फ़ाइलों के बिल्ट‑इन गुणधर्मों को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस किसी भी इच्छित गुणधर्म को एक स्ट्रिंग मान असाइन कर सकते हैं और वह गुणधर्म मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे Aspose.Slides for PHP via Java का उपयोग करके प्रेजेंटेशन फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणधर्मों को संशोधित किया जा सकता है।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट‑इन गुणधर्म सेट करें
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # अपनी प्रस्तुति को फ़ाइल में सहेजें
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यह उदाहरण प्रेजेंटेशन के बिल्ट‑इन गुणधर्मों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ गुणधर्म**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुणधर्म जोड़ना**

Aspose.Slides for PHP via Java डेवलपर्स को प्रस्तुतिकरण दस्तावेज़ गुणधर्मों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रेजेंटेशन के लिए कस्टम गुणधर्म कैसे सेट किए जाएँ।

```php
  $pres = new Presentation();
  try {
    # दस्तावेज़ गुणधर्म प्राप्त करना
    $dProps = $pres->getDocumentProperties();
    # कस्टम गुणधर्म जोड़ना
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # विशिष्ट अनुक्रमांक पर गुणधर्म का नाम प्राप्त करना
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # चयनित गुणधर्म हटाना
    $dProps->removeCustomProperty($getPropertyName);
    # प्रेजेंटेशन सहेजना
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**जोड़े गये कस्टम दस्तावेज़ गुणधर्म**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणधर्मों तक पहुंच और संशोधन**

Aspose.Slides for PHP via Java डेवलपर्स को कस्टम गुणधर्मों के मानों तक पहुंचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रेजेंटेशन के सभी कस्टम गुणधर्मों तक कैसे पहुंच और संशोधन कर सकते हैं।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़े DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # कस्टम गुणधर्मों तक पहुंचें और संशोधित करें
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # कस्टम गुणधर्मों के नाम और मान प्रदर्शित करें
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # कस्टम गुणधर्मों के मान संशोधित करें
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

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/)प्रेजेंटेशन के कस्टम गुणधर्मों को संशोधित करता है। नीचे के चित्र संशोधन से पहले और बाद की कस्टम गुणधर्मों को दिखाते हैं:

|**संशोधन से पहले कस्टम गुणधर्म**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुणधर्म**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुणधर्म**

{{% alert color="primary" %}} 
नए मेथड [readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) और [writeBindedPresentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) को [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo) में जोड़ा गया है, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#setLastSavedTime) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।
{{% /alert %}} 

दो नए मेथड [readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) और [updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) को [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo) क्लास में जोड़ा गया है। ये मेथड जल्दी से दस्तावेज़ गुणधर्मों तक पहुंच प्रदान करते हैं और पूरी प्रेजेंटेशन लोड किए बिना गुणधर्मों को बदलने व अपडेट करने की सुविधा देते हैं।

सामान्य परिदृश्य में गुणधर्म लोड करना, कुछ मान बदलना और दस्तावेज़ को अपडेट करना निम्नलिखित तरीके से लागू किया जा सकता है:

```php
  # प्रस्तुति की जानकारी पढ़ें
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # वर्तमान गुणधर्म प्राप्त करें
  $props = $info->readDocumentProperties();
  # Author और Title फ़ील्ड के नए मान सेट करें
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # प्रस्तुति को नए मानों के साथ अपडेट करें
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

एक अन्य तरीका है कि किसी विशिष्ट प्रेजेंटेशन के गुणधर्मों को टेम्प्लेट के रूप में उपयोग कर अन्य प्रेजेंटेशनों के गुणधर्म अपडेट किए जाएँ:

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

शुरुआत से एक नया टेम्प्लेट बनाया जा सकता है और फिर कई प्रेजेंटेशनों को अपडेट करने के लिए उपयोग किया जा सकता है:

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

## **प्रूफ़िंग भाषा सेट करना**

Aspose.Slides LanguageId प्रॉपर्टी (जो PortionFormat क्लास द्वारा उजागर है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह PHP कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट करें: xxx Java PortionFormat क्लास में LanguageId क्यों अनुपलब्ध है?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// प्रूफ़िंग भाषा की Id सेट करें

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **डिफ़ॉल्ट भाषा सेट करना**

यह PHP कोड दिखाता है कि पूरी PowerPoint प्रेजेंटेशन के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # टेक्स्ट के साथ नया आयताकार आकार जोड़ता है
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # पहले हिस्से की भाषा जाँचता है
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लाइव उदाहरण**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप को आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणधर्मों के साथ काम करना देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रेजेंटेशन से बिल्ट‑इन प्रॉपर्टी को कैसे हटा सकता हूँ?**

बिल्ट‑इन प्रॉपर्टी प्रेजेंटेशन का अभिन्न हिस्सा है और इसे पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उसकी मूल्य बदल सकते हैं या यदि विशेष प्रॉपर्टी अनुमति देती है तो उसे खाली सेट कर सकते हैं।

**यदि मैं एक मौजूदा कस्टम प्रॉपर्टी जोड़ूँ तो क्या होगा?**

यदि आप एक कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले प्रॉपर्टी को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी का मान अपडेट कर देता है।

**क्या मैं पूरी प्रेजेंटेशन लोड किए बिना प्रेजेंटेशन गुणधर्मों तक पहुंच सकता हूँ?**

हाँ, आप [PresentationFactory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) क्लास की `getPresentationInfo` मेथड का उपयोग करके प्रेजेंटेशन को पूरी तरह लोड किए बिना गुणधर्मों तक पहुंच सकते हैं। उसके बाद, आप [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) क्लास की `readDocumentProperties` मेथड का उपयोग करके गुणधर्मों को कुशलतापूर्वक पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन सुधरता है।