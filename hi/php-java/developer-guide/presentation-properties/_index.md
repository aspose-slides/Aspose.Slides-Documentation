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
- गुणों का प्रबंधन
- गुणों का संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादन
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सरल बनाएँ।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों गुण प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) वर्ग के माध्यम से। इस वर्ग का एक इंस्टेंस [Presentation::getDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getDocumentProperties) मेथड द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता है। Aspose.Slides प्रत्येक सहेजने पर उन्हें पुनः लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा "Aspose.Slides for PHP via Java" और उस पुस्तकालय के संस्करण को रिपोर्ट करती है जिसने इसे बनाया। `setNameOfApplication` को दिया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।
{{% /alert %}} 

## **प्रस्तुति गुणों का प्रबंधन**

Microsoft PowerPoint प्रस्तुतियों फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण दस्तावेज़ों (प्रेज़ेंटेशन फ़ाइलों) के साथ कुछ उपयोगी जानकारी संग्रहीत करने की अनुमति देते हैं। दस्तावेज़ गुणों के दो प्रकार हैं:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** गुण दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **Custom** गुण वे होते हैं, जिन्हें उपयोगकर्ता **Name/Value** जोड़ों के रूप में परिभाषित करते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा परिभाषित होते हैं। Aspose.Slides for PHP via Java का उपयोग करके, डेवलपर निर्मित (built-in) और कस्टम (custom) दोनों गुणों के मानों तक पहुंच और संशोधन कर सकते हैं।

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर Microsoft PowerPoint 2007 में **Prepare | Properties | Advanced Properties** मेनू आइटम पर जाना है जैसा कि नीचे दिखाया गया है:

|**उन्नत गुण मेनू आइटम चुनना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

जब आप **Advanced Properties** मेनू आइटम चुनते हैं, तो एक संवाद बॉक्स प्रदर्शित होता है जो आपको PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है, जैसा कि नीचे चित्र में दिखाया गया है:

|**गुण संवाद**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

उपर्युक्त **Properties Dialog** में, आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

Aspose.Slides for PHP via Java का उपयोग करके दस्तावेज़ गुणों के साथ काम करना

जैसा कि हमने पहले बताया था, Aspose.Slides for PHP via Java दो प्रकार के दस्तावेज़ गुणों का समर्थन करता है, अर्थात **Built-in** और **Custom** गुण। इसलिए, डेवलपर Aspose.Slides for PHP via Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुंच सकते हैं। Aspose.Slides for PHP via Java एक क्लास [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties) प्रदान करता है जो **Presentation.DocumentProperties** गुण के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों का प्रतिनिधित्व करता है।

डेवलपर **DocumentProperties** गुण को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा प्रदान किया गया, का उपयोग करके नीचे वर्णित अनुसार प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों तक पहुंच सकते हैं:

## **Built-in गुणों तक पहुँच**

इन गुणों को [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा उजागर किया गया है, जिसमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject** और **Title**.

```php
  # Presentation क्लास को instantiate करें जो प्रस्तुति का प्रतिनिधित्व करती है
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़ा IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट-इन गुणों को प्रदर्शित करें
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

## **निर्मित गुणों को संशोधित करें**

प्रस्तुति फ़ाइलों के निर्मित गुणों को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस किसी भी इच्छित गुण को एक स्ट्रिंग मान असाइन कर सकते हैं और वह गुण मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में, हमने दिखाया है कि हम Aspose.Slides for PHP via Java का उपयोग करके प्रस्तुति फ़ाइल के निर्मित दस्तावेज़ गुणों को कैसे संशोधित कर सकते हैं।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़ा IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # बिल्ट-इन गुण सेट करें
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

यह उदाहरण प्रस्तुति के निर्मित गुणों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद निर्मित दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for PHP via Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम गुण कैसे सेट किए जाएँ।

```php
  $pres = new Presentation();
  try {
    # दस्तावेज़ गुण प्राप्त करना
    $dProps = $pres->getDocumentProperties();
    # कस्टम गुण जोड़ना
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # किसी विशेष इंडेक्स पर गुण का नाम प्राप्त करना
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # चयनित गुण हटाना
    $dProps->removeCustomProperty($getPropertyName);
    # प्रस्तुति सहेजना
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**जोडे गये कस्टम दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणों तक पहुँच और संशोधन**

Aspose.Slides for PHP via Java डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुँच सकते हैं और उन्हें कैसे संशोधित कर सकते हैं।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation से जुड़ा DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    $dp = $pres->getDocumentProperties();
    # कस्टम गुणों तक पहुँचें और उन्हें संशोधित करें
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

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति के कस्टम गुणों को संशोधित करता है। निम्नलिखित चित्र प्रस्तुतियों के कस्टम गुणों को संशोधन से पहले और बाद में दिखाते हैं:

|**संशोधन से पहले कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुण**

{{% alert color="info" title="Note" %}}
नई विधियाँ [readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), और [writeBindedPresentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) को [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo) में जोड़ा गया है, और [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#setLastSavedTime) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।
{{% /alert %}} 

दो नई विधियाँ [readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) और [updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) को [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo) क्लास में जोड़ा गया है। वे दस्तावेज़ गुणों तक शीघ्र पहुँच प्रदान करती हैं और संपूर्ण प्रस्तुति लोड किए बिना गुणों को बदलने और अद्यतन करने की अनुमति देती हैं।

आम परिदृश्य जहाँ गुण लोड किए जाते हैं, कुछ मान बदले जाते हैं और दस्तावेज़ को अद्यतन किया जाता है, इसे निम्न प्रकार लागू किया जा सकता है:

```php
  # प्रस्तुति की जानकारी पढ़ें
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # मौजूदा गुण प्राप्त करें
  $props = $info->readDocumentProperties();
  # Author और Title फ़ील्ड के नए मान सेट करें
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # नई मानों के साथ प्रस्तुति को अपडेट करें
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

किसी विशेष प्रस्तुति के गुणों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में गुणों को अपडेट करने का एक और तरीका है:

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

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

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

Aspose.Slides LanguageId प्रॉपर्टी (जो PortionFormat क्लास द्वारा प्रदान की गई है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह PHP कोड दर्शाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें: xxx Java PortionFormat क्लास में LanguageId क्यों अनुपलब्ध है?

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

यह PHP कोड दर्शाता है कि पूरी PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट करें:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # एक नया आयताकार शेप टेक्स्ट के साथ जोड़ता है
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # पहले भाग की भाषा जांचता है
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **लाइव उदाहरण**

Aspose.Slides Metadata ऑनलाइन ऐप आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम करें, देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक Built-in गुण कैसे हटाऊँ?**

Built-in गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशेष गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप कोई ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले गुण को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट करता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हां। [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) का उपयोग करें और फिर [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) के साथ संग्रहित दस्तावेज़ मेटा डेटा को पढ़ें बिना [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाये। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट-विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/php-java/examine-presentation/)।