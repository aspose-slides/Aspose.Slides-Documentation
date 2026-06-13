---
title: PHP में प्रस्तुतियों में वाटरमार्क जोड़ें
linktitle: वाटरमार्क
type: docs
weight: 40
url: /hi/php-java/watermark/
keywords:
- वाटरमार्क
- टेक्स्ट वाटरमार्क
- इमेज वाटरमार्क
- वाटरमार्क जोड़ें
- वाटरमार्क बदलें
- वाटरमार्क हटाएँ
- वाटरमार्क हटाएँ
- PPT में वाटरमार्क जोड़ें
- PPTX में वाटरमार्क जोड़ें
- ODP में वाटरमार्क जोड़ें
- PPT से वाटरमार्क हटाएँ
- PPTX से वाटरमार्क हटाएँ
- ODP से वाटरमार्क हटाएँ
- PPT से वाटरमार्क हटाएँ
- PPTX से वाटरमार्क हटाएँ
- ODP से वाटरमार्क हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट और इमेज वाटरमार्क को प्रबंधित करें ताकि ड्राफ्ट, गोपनीय जानकारी, कॉपीराइट आदि दर्शाए जा सकें।"
---
## **परिचय**

**एक वाटरमार्क** प्रस्तुति में टेक्स्ट या इमेज स्टैम्प है जो स्लाइड पर या सभी स्लाइड्स पर प्रयोग किया जाता है। आम तौर पर, वाटरमार्क यह दर्शाने के लिए उपयोग किया जाता है कि प्रस्तुति ड्राफ्ट है (उदाहरण के लिये, "Draft" वाटरमार्क), इसमें गोपनीय जानकारी है (उदाहरण के लिये, "Confidential" वाटरमार्क), यह किस कंपनी से संबंधित है (उदाहरण के लिये, "Company Name" वाटरमार्क), प्रस्तुति लेखक की पहचान करने आदि। वाटरमार्क कॉपीराइट उल्लंघन को रोकने में मदद करता है यह दर्शाकर कि प्रस्तुति को कॉपी नहीं किया जाना चाहिए। वाटरमार्क PowerPoint और OpenOffice दोनों प्रस्तुति फ़ॉर्मेट में उपयोग होते हैं। Aspose.Slides में, आप PowerPoint PPT, PPTX और OpenOffice ODP फ़ाइल फ़ॉर्मेट में वाटरमार्क जोड़ सकते हैं।

[**Aspose.Slides**](https://products.aspose.com/slides/hi/php-java/) में, PowerPoint या OpenOffice दस्तावेज़ों में वाटरमार्क बनाने और उनके डिज़ाइन व व्यवहार को बदलने के विभिन्न तरीके हैं। सामान्य बात यह है कि टेक्स्ट वाटरमार्क जोड़ने के लिए आपको [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) क्लास का उपयोग करना चाहिए, और इमेज वाटरमार्क जोड़ने के लिए [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) क्लास या वाटरमार्क आकार को इमेज से भरना चाहिए। `PictureFrame` [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास को लागू करता है, जिससे आप शेप ऑब्जेक्ट की सभी लचीली सेटिंग्स का उपयोग कर सकते हैं। चूँकि `ITextFrame` एक शेप नहीं है और इसकी सेटिंग्स सीमित हैं, इसे एक [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट में रैप किया जाता है।

वाटरमार्क लगाने के दो तरीके हैं: एकल स्लाइड पर या सभी प्रस्तुति स्लाइड्स पर। सभी स्लाइड्स पर वाटरमार्क लागू करने के लिए Slide Master का उपयोग किया जाता है — वाटरमार्क को Slide Master में जोड़ा जाता है, वहाँ पूरी तरह डिज़ाइन किया जाता है, और सभी स्लाइड्स पर लागू किया जाता है बिना व्यक्तिगत स्लाइड्स में वाटरमार्क को संशोधित करने की अनुमति को प्रभावित किए।

आमतौर पर वाटरमार्क को अन्य उपयोगकर्ताओं द्वारा संपादन योग्य नहीं माना जाता। वाटरमार्क (या अधिक सटीक रूप से वाटरमार्क के पैरेंट शेप) को संपादन से रोकने के लिए, Aspose.Slides शेप लॉक करने की सुविधा प्रदान करता है। एक विशिष्ट शेप को सामान्य स्लाइड या Slide Master पर लॉक किया जा सकता है। जब वाटरमार्क शेप Slide Master पर लॉक किया जाता है, तो वह सभी प्रस्तुति स्लाइड्स पर लॉक हो जाता है।

आप वाटरमार्क को एक नाम दे सकते हैं ताकि भविष्य में इसे हटाना चाहें तो स्लाइड की शेप्स में नाम द्वारा इसे खोज सकें।

आप वाटरमार्क को किसी भी तरीके से डिज़ाइन कर सकते हैं; फिर भी आमतौर पर वाटरमार्क में कुछ सामान्य विशेषताएँ होती हैं, जैसे मध्य संरेखण, घुमाव, अग्रभूमि स्थिति आदि। हम नीचे दिए गए उदाहरणों में इनका उपयोग कैसे किया जाए, देखेंगे।

## **टेक्स्ट वाटरमार्क**

### **स्लाइड में टेक्स्ट वाटरमार्क जोड़ें**

PPT, PPTX या ODP में टेक्स्ट वाटरमार्क जोड़ने के लिए, आप पहले स्लाइड में एक शेप जोड़ सकते हैं, फिर उस शेप में एक टेक्स्ट फ्रेम जोड़ें। टेक्स्ट फ्रेम [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) क्लास द्वारा दर्शाया जाता है। यह प्रकार [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) से विरासत में नहीं मिला है, जिसमें वाटरमार्क को लचीले तरीके से स्थिति देने के लिए व्यापक प्रॉपर्टीज़ होते हैं। इसलिए, [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) ऑब्जेक्ट को एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) ऑब्जेक्ट में रैप किया जाता है। वाटरमार्क टेक्स्ट शेप में जोड़ने के लिए, नीचे दिखाए अनुसार [addTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/#addTextFrame) मेथड का उपयोग करें।

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="और देखें" %}} 
- [TextFrame क्लास का उपयोग कैसे करें](/slides/hi/php-java/text-formatting/)
{{% /alert %}}

### **पूरी प्रस्तुति में टेक्स्ट वाटरमार्क जोड़ें**

यदि आप पूरी प्रस्तुति (अर्थात् सभी स्लाइड्स एक साथ) में टेक्स्ट वाटरमार्क जोड़ना चाहते हैं, तो इसे [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) में जोड़ें। बाकी लॉजिक वही है जैसा कि एकल स्लाइड में वाटरमार्क जोड़ते समय होता है — एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) ऑब्जेक्ट बनाएं और फिर [addTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/#addTextFrame) मेथड से उसमें वाटरमार्क जोड़ें।

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="और देखें" %}} 
- [Slide Master का उपयोग कैसे करें](/slides/hi/php-java/slide-master/)
{{% /alert %}}

### **वाटरमार्क शेप की पारदर्शिता सेट करें**

डिफ़ॉल्ट रूप से, आयताकार शेप में भराव और लाइन रंग होते हैं। नीचे दिया गया कोड शेप को पारदर्शी बनाता है।

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **टेक्स्ट वाटरमार्क के लिए फ़ॉन्ट सेट करें**

नीचे दिखाए अनुसार आप टेक्स्ट वाटरमार्क का फ़ॉन्ट बदल सकते हैं।

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **वाटरमार्क टेक्स्ट का रंग सेट करें**

वाटरमार्क टेक्स्ट का रंग सेट करने के लिए, इस कोड का उपयोग करें:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **टेक्स्ट वाटरमार्क को केंद्रित करें**

स्लाइड पर वाटरमार्क को केंद्रित करना संभव है, इसके लिए आप निम्न कर सकते हैं:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

नीचे की छवि अंतिम परिणाम दिखाती है।

![टेक्स्ट वाटरमार्क](text_watermark.png)

## **इमेज वाटरमार्क**

### **प्रस्तुति में इमेज वाटरमार्क जोड़ें**

प्रस्तुति स्लाइड में इमेज वाटरमार्क जोड़ने के लिए, आप निम्न कर सकते हैं:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **वाटरमार्क को संपादन से लॉक करें**

यदि वाटरमार्क को संपादित होने से रोकना आवश्यक है, तो शेप पर [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/#getAutoShapeLock) मेथड का उपयोग करें। इस प्रॉपर्टी से आप शेप को चयन, आकार बदलने, पुनः स्थिति निर्धारण, अन्य तत्वों के साथ समूह बनाने, उसके टेक्स्ट को संपादित होने से लॉक करने और बहुत कुछ से सुरक्षित रख सकते हैं:

```php
// वाटरमार्क आकार को संशोधन से लॉक करें
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **वाटरमार्क को आगे लाएँ**

Aspose.Slides में शेप्स का Z-ऑर्डर [ShapeCollection.reorder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#reorder) मेथड से सेट किया जा सकता है। ऐसा करने के लिए, आपको प्रस्तुति स्लाइड्स सूची से इस मेथड को कॉल करना होगा और शेप रेफ़रेंस तथा उसका क्रमांक पास करना होगा। इस तरह आप शेप को आगे (फ़्रंट) ला सकते हैं या स्लाइड के बैक में भेज सकते हैं। यह फीचर विशेष रूप से उपयोगी है जब आपको प्रस्तुति में वाटरमार्क को आगे रखना हो:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **वाटरमार्क का घुमाव सेट करें**

यहां एक कोड उदाहरण है जो दिखाता है कि वाटरमार्क का घुमाव कैसे सेट करें ताकि वह स्लाइड में तिरछा स्थित हो:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **वाटरमार्क का नाम सेट करें**

Aspose.Slides आपको शेप का नाम सेट करने की अनुमति देता है। शेप नाम का उपयोग करके आप भविष्य में उसे संशोधित या हटाने के लिए एक्सेस कर सकते हैं। वाटरमार्क शेप का नाम सेट करने के लिए, इसे [AutoShape.setName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setName) मेथड को असाइन करें:

```php
$watermarkShape->setName("watermark");
```

### **वाटरमार्क हटाएँ**

वाटरमार्क शेप को हटाने के लिए, स्लाइड शेप्स में इसे खोजने हेतु [AutoShape.getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getName) मेथड का उपयोग करें। फिर, वाटरमार्क शेप को [ShapeCollection.remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#remove) मेथड में पास करें:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वाटरमार्क क्या है और मुझे इसे क्यों उपयोग करना चाहिए?**

वाटरमार्क टेक्स्ट या इमेज ओवरले है जो स्लाइड्स पर लागू किया जाता है और जो बौद्धिक संपदा की सुरक्षा, ब्रांड पहचान को बढ़ाने या अनधिकृत उपयोग को रोकने में मदद करता है।

**क्या मैं एक प्रस्तुति में सभी स्लाइड्स पर वाटरमार्क जोड़ सकता हूँ?**

हाँ, Aspose.Slides आपको प्रोग्रामेटिकली हर स्लाइड में वाटरमार्क जोड़ने देता है। आप सभी स्लाइड्स पर इटरिट करके व्यक्तिगत रूप से वाटरमार्क सेटिंग्स लागू कर सकते हैं।

**मैं वाटरमार्क की पारदर्शिता कैसे समायोजित कर सकता हूँ?**

आप शेप के फ़िल फ़ॉर्मेट ([getFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getfillformat/)) को बदलकर वाटरमार्क की पारदर्शिता समायोजित कर सकते हैं। इससे वाटरमार्क हल्का रहेगा और स्लाइड सामग्री में बाधा नहीं बनेगा।

**वाटरमार्क के लिए कौन से इमेज फ़ॉर्मेट सपोर्टेड हैं?**

Aspose.Slides विभिन्न इमेज फ़ॉर्मेट जैसे PNG, JPEG, GIF, BMP, SVG आदि को सपोर्ट करता है।

**क्या मैं टेक्स्ट वाटरमार्क का फ़ॉन्ट और शैली कस्टमाइज़ कर सकता हूँ?**

हाँ, आप अपनी प्रस्तुति की डिज़ाइन और ब्रांड संगतता के अनुसार कोई भी फ़ॉन्ट, साइज और शैली चुन सकते हैं।

**मैं वाटरमार्क की स्थिति या अभिविन्यास कैसे बदल सकता हूँ?**

आप शेप के कॉर्डिनेट्स, आकार और घुमाव प्रॉपर्टीज़ को बदलकर प्रोग्रामेटिकली वाटरमार्क की स्थिति और अभिविन्यास समायोजित कर सकते हैं।