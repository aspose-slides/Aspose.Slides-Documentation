---
title: PHP में PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड्स का प्रबंधन
linktitle: टेक्स्ट फ़ील्ड्स
type: docs
weight: 52
url: /hi/php-java/text-fields/
keywords:
- टेक्स्ट फ़ील्ड
- स्वचालित टेक्स्ट
- स्लाइड नंबर
- तारीख और समय
- हेडर
- फ़ूटर
- टेक्स्ट भाग
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में टेक्स्ट फ़ील्ड्स बनाएं, जांचें, संशोधित करें और हटाएं। फ़ॉर्मेटिंग को संरक्षित रखें और सहेजे गए PPTX और PPT फ़ाइलों को सत्यापित करें।"
---
## **अवलोकन**

एक पाठ पैराग्राफ हिस्सों से बना होता है। एक सामान्य [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) में शाब्दिक पाठ होता है; एक फ़ील्ड हिस्सा में additionally एक [Field](https://reference.aspose.com/slides/hi/php-java/aspose.slides/field/) भी होता है जिसका प्रकार स्वतः अपडेट होने वाला मान पहचानता है, जैसे स्लाइड नंबर या तिथि। दो हिस्से समान अक्षर प्रदर्शित कर सकते हैं जबकि केवल एक में फ़ील्ड होता है।

उन्हें अलग करने के लिए [Portion::getField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getField) का उपयोग करें: सामान्य पाठ के लिए यह `null` है। [Portion::addField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#addField) मौजूदा हिस्से को फ़ील्ड में बदलता है। लेबल और उसके गतिशील मान को अलग-अलग हिस्सों में रखें ताकि मान को बदलने से लेबल भी बदल न जाए।

यह गाइड टेक्स्ट के भीतर फ़ील्ड, उनका फ़ॉर्मेटिंग, और PPTX तथा PPT में सहेजने को कवर करता है। टेक्स्ट फ्रेम और पैराग्राफ के लिए, देखें [Manage Text](/slides/hi/php-java/manage-text/)।

## **स्लाइड नंबर फ़ील्ड बनाना**

निम्नलिखित पूर्ण उदाहरण एक टेक्स्ट बॉक्स बनाता है जिसमें शाब्दिक `Slide ` लेबल और उसके बाद स्वतः अपडेट होने वाला नंबर होता है। यह फ़ील्ड जोड़ने से पहले नंबर का आकार, भार, और रंग सेट करता है, फिर सहेजे हुए प्रेजेंटेशन को फिर से खोलता है और फ़ील्ड प्रकार, टेक्स्ट, और फ़ॉर्मेटिंग की जाँच करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है।

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

नया प्रेजेंटेशन स्लाइड नंबर 1 से शुरू होता है, इसलिए टेक्स्ट `Slide 1` होता है, और दोनों जाँचें `true` प्रिंट करती हैं। पुनः खोलने के बाद भी नंबर फ़ील्ड बना रहता है; यह शाब्दिक `1` नहीं है। सत्यापन में उपयोग किए गए सूचकांक उस उदाहरण द्वारा निर्मित आकार और हिस्सों को दर्शाते हैं।

## **फ़ील्ड प्रकार चुनें**

[FieldType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/) पूर्वनिर्धारित मान प्राप्त करने के लिये निम्न विधियां प्रदान करता है। उपयुक्त मान को [addField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#addField) में पास करें।

| विधि | उद्देश्य |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getSlideNumber) | वर्तमान स्लाइड नंबर। |
| [getDateTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime) | रेंडरिंग एप्लिकेशन के डिफ़ॉल्ट फ़ॉर्मेट में तिथि/समय। |
| [getDateTime1](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime9) | पूर्वनिर्धारित तिथि या संयुक्त तिथि/समय फ़ॉर्मेट। |
| [getDateTime10](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime13) | पूर्वनिर्धारित समय फ़ॉर्मेट, सेकंड और 12‑घंटे वाले घड़ी के विकल्पों के साथ। |
| [getHeader](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getHeader) | हेडर फ़ील्ड; नीचे प्लेसहोल्डर और फ़ॉर्मेट सीमाओं को देखें। |
| [getFooter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getFooter) | फ़ूटर फ़ील्ड। |

उदाहरण के लिये, [getDateTime3](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getDateTime3) एक दिन, पूर्ण अंग्रेज़ी महीना नाम, और वर्ष को दर्शाता है। ये पूर्वनिर्धारित फ़ील्ड फ़ॉर्मेट हैं, 任意 PHP तिथि‑फ़ॉर्मेट स्ट्रिंग नहीं। [setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) द्वारा सेट की गई भाषा और प्रेजेंटेशन को प्रोसेस करने वाला एप्लिकेशन प्रदर्शित परिणाम को प्रभावित कर सकते हैं।

## **आंतरिक स्ट्रिंग से फ़ील्ड बनाना**

[addField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#addField) का स्ट्रिंग ओवरलोड एक आंतरिक फ़ील्ड पहचानकर्ता स्वीकार करता है। इसका उपयोग तब करें जब आप किसी अन्य एप्लिकेशन द्वारा प्रदान किए गए पहचानकर्ता को संरक्षित रखना चाहते हैं जिसके लिये कोई पूर्वनिर्धारित मान नहीं है। आप इस पहचानकर्ता से एक [FieldType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#FieldType) भी बना सकते हैं। [FieldType::getInternalString](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fieldtype/#getInternalString) उस पहचानकर्ता को निरीक्षण के लिये उजागर करता है।

यह उदाहरण एक एप्लिकेशन‑विशिष्ट `custom-report-id` फ़ील्ड को फॉलबैक टेक्स्ट `Report-042` के साथ संग्रहीत करता है। पहचानकर्ता कोई गणना नहीं रजिस्टर्ड करता: Aspose.Slides अज्ञात प्रकार के लिये रिपोर्ट आईडी उत्पन्न नहीं करता। वह एप्लिकेशन जो इस पहचानकर्ता को समझता है, उसे उसका अर्थ प्रदान करनا और मान को अपडेट करना होगा।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

राउंड‑ट्रिप के बाद प्रकार `custom-report-id` और टेक्स्ट `Report-042` रहता है। `Y-m-d` जैसी स्ट्रिंग पास करने पर एक फ़ील्ड प्रकार का नाम दिया जाता है; यह कस्टम तिथि फ़ॉर्मेट को कॉन्फ़िगर नहीं करता। 任意 फ़ॉर्मेट में स्थिर तिथि के लिये सामान्य पाठ का उपयोग करें।

## **तारीख/समय फ़ील्ड की जाँच, संशोधन, और हटाना**

मौजूदा फ़ील्ड को [Field::setType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/field/#setType) से बदलें। उसके प्रकार तक पहुँचने से पहले जांचें कि फ़ील्ड मौजूद है। स्वचालित अपडेट को रोकने के लिये [Portion::removeField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#removeField) को कॉल करें। यह फ़ील्ड संबंध को हटाते हुए भाग और उसका वर्तमान टेक्स्ट रखता है। यदि आपको विशिष्ट स्थिर मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

तारीख/समय फ़ील्ड प्रोसेसिंग से संबंधित API सेटिंग के लिये देखें [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#setCurrentDateTime)। नीचे दिया गया उदाहरण फ़ील्ड को सामान्य टेक्स्ट में बदलते समय स्पष्ट अनुमोदन तिथि का उपयोग करता है।

[sample.pptx](sample.pptx) को डाउनलोड करके उसे JavaBridge कार्य निर्देशिका में रखें, या प्रेजेंटेशन कंस्ट्रक्टर में उसका पूर्ण पथ पास करें। इसमें दो नामांकित टेक्स्ट शेप `UpdatedAt` और `ApprovedDate` हैं, प्रत्येक में एक तारीख/समय फ़ील्ड तथा सामान्य टेक्स्ट लेबल हैं। निम्न उदाहरण नियमित स्लाइड्स पर टॉप‑लेवल टेक्स्ट शेप्स को क्रमबद्ध करता है। यह तारीख/समय फ़ील्ड को लंबी‑तारीख फ़ॉर्मेट में बदलता है और इटैलिक बनाता है, जबकि अन्य फ़ॉर्मेटिंग को बनाए रखता है। केवल `ApprovedDate` में फ़ील्ड स्थिर टेक्स्ट बन जाता है।

नमूना अंतर्निहित पहचानकर्ता `datetime` और `datetime1` से `datetime13` तक पहचानता है। समूह, तालिकाएं, नोट्स, लेआउट और मास्टर को उनके अपने टेक्स्ट कंटेनर की यात्रा करनी पड़ती है और यह उदाहरण उनके दायरे में नहीं है।

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

पुनः खोलने के बाद `UpdatedAt` का प्रकार `datetime3` है और यह गतिशील बना रहता है। `ApprovedDate` का कोई फ़ील्ड नहीं है और इसमें `05 April 2030` मौजूद है। दोनों तारीख हिस्से इटैलिक हैं, और उनका मूल फ़ॉन्ट आकार, बोल्ड सेटिंग, तथा रंग अपरिवर्तित रहता है। सामान्य टेक्स्ट लेबल अपरिवर्तित हैं। सत्यापन प्रदान किए गए नमूने में दो ज्ञात शेप्स के पहले हिस्से को पढ़ता है।

## **पाठ फ़ॉर्मेटिंग को बनाए रखें**

फ़ील्ड जोड़ते, प्रकार बदलते, या हटाते समय मौजूदा हिस्से के साथ काम करें। ये क्रियाएँ उस हिस्से की फ़ॉर्मेटिंग को बरकरार रखती हैं। आवश्यक प्रॉपर्टीज़ को बदलने के लिये [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat) का उपयोग करें, जैसा कि उदाहरण रंग या इटैलिक के लिये करते हैं।

केवल एक फ़ील्ड को अपडेट करने के लिये पूरे टेक्स्ट फ्रेम को फिर से बनाने से बचें: इससे मूल हिस्से की सीमाएँ और उनका व्यक्तिगत फ़ॉर्मेटिंग खो सकता है। पैराग्राफ, लेआउट, या थीम से विरासत में मिलने वाले फ़ॉर्मेटिंग और स्पष्ट रूप से सेट किए गए फ़ॉर्मेटिंग में अंतर करें। विस्तृत फ़ॉर्मेटिंग विकल्पों के लिये देखें [Text Formatting](/slides/hi/php-java/text-formatting/)।

## **फ़ील्ड और हेडर/फ़ूटर प्लेसहोल्डर**

एक फ़ील्ड टेक्स्ट हिस्से का भाग है। एक प्लेसहोल्डर वह शेप है जिसका प्रेजेंटेशन में भूमिका होती है, जैसे फ़ूटर या स्लाइड नंबर। सामान्य टेक्स्ट बॉक्स में फ़ील्ड जोड़ने से वह शेप प्लेसहोल्डर नहीं बन जाता।

हेडर/फ़ूटर मैनेजर्स स्लाइड्स, लेआउट, और मास्टर्स पर प्लेसहोल्डर टेक्स्ट और दृश्यता को नियंत्रित करते हैं, जिसमें आश्रित स्लाइड्स में प्रसार शामिल है। कस्टम टेक्स्ट बॉक्स में नंबर फ़ील्ड तब भी उपयोगी हो सकता है जब आप स्लाइड‑नंबर प्लेसहोल्डर का उपयोग नहीं कर रहे हों। इसके विपरीत, प्लेसहोल्डर दृश्यता बदलने से किसी असंबंधित टेक्स्ट बॉक्स से फ़ील्ड नहीं हटता।

पूर्वनिर्धारित हेडर और फ़ूटर प्रकार संबंधित प्लेसहोल्डर नहीं बनाते और न ही उनका कंटेंट प्रदान करते हैं। विशेष रूप से, एक सामान्य PowerPoint स्लाइड में हेडर प्लेसहोल्डर नहीं होता; हेडर नोट पेज और हैंडआउट्स से संबंधित होते हैं। यह न मानें कि किसी भी शेप में हेडर या फ़ूटर फ़ील्ड स्वचालित रूप से प्लेसहोल्डर मैनेजर द्वारा कॉन्फ़िगर किया गया टेक्स्ट प्राप्त कर लेगा। उस वर्कफ़्लो के लिये देखें [Presentation Headers and Footers](/slides/hi/php-java/presentation-header-and-footer/)।

## **PPTX और PPT सीमाएँ**

सहेजने और पुनः खोलने के बाद फ़ील्ड प्रकार और उत्पन्न टेक्स्ट दोनों की जाँच करें। पहचानकर्ता को संरक्षित करने से यह सिद्ध नहीं होता कि एप्लिकेशन उसके मान की गणना या प्रदर्शित कर सकता है।

| फ़ॉर्मेट | फ़ील्ड व्यवहार और सीमाएँ |
|---|---|
| PPTX | आंतरिक फ़ील्ड पहचानकर्ताओं को फ़ील्ड टेक्स्ट के साथ संग्रहीत करता है। राउंड‑ट्रिप जाँच में, पूर्वनिर्धारित प्रकार और ऊपर उपयोग किया गया कस्टम पहचानकर्ता सहेजने और पुनः खोलने के बाद भी बना रहता है। अज्ञात कस्टम प्रकार अपना फॉलबैक टेक्स्ट रखता है; उसने स्वचालित गणना लॉजिक नहीं प्राप्त किया। कोई अन्य एप्लिकेशन असमर्थित पहचानकर्ताओं को अलग तरह से संभाल सकता है। |
| PPT | लेगेसी फ़ील्ड प्रतिनिधित्व का उपयोग करता है और अधिक सीमित संगतता रखता है। राउंड‑ट्रिप जाँच में, स्लाइड‑नंबर और पूर्वनिर्धारित तारीख/समय फ़ील्ड सहेजने और पुनः खोलने के बाद भी बना रहता है। सामान्य स्लाइड टेक्स्ट बॉक्स में एक कस्टम फ़ील्ड अपने पहचानकर्ता के साथ पुनः खोला जाता है लेकिन उसका टेक्स्ट `*` रहता है; उसी संदर्भ में एक हेडर फ़ील्ड भी `*` पैदा करता है। कस्टम फ़ील्ड या असमर्थित फ़ील्ड संदर्भों को उनके दृश्यमान टेक्स्ट को बनाए रखने पर भरोसा न करें। |

पोर्टेबल, स्थिर आउटपुट के लिये, असमर्थित फ़ील्ड को सामान्य टेक्स्ट में बदलें और सहेजने से पहले इच्छित मान स्पष्ट रूप से असाइन करें। यह चुने हुए टेक्स्ट को संरक्षित करता है लेकिन स्वचालित अपडेट को जानबूझकर रोकता है। यदि आपका वर्कफ़्लो लक्ष्य एप्लिकेशन के अपने फ़ील्ड पुनर्गणना पर निर्भर करता है, तो उसे भी परीक्षण करें।

## **FAQ**

**मैं कैसे पता करूँ कि प्रदर्शित संख्या या तिथि फ़ील्ड है या नहीं?**

[Portion::getField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getField) को देखें। गैर‑null मान फ़ील्ड की पहचान करता है; केवल प्रदर्शित टेक्स्ट यह नहीं बता सकता।

**क्या फ़ील्ड हटाने से उसका टेक्स्ट या फ़ॉर्मेटिंग हट जाता है?**

नहीं। [removeField](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#removeField) मौजूदा हिस्से को सामान्य टेक्स्ट में बदल देता है। यदि आपको कोई विशेष स्थिर तिथि या फॉलबैक मान चाहिए, तो फ़ील्ड हटाने के बाद वह टेक्स्ट असाइन करें।

**क्या एक आंतरिक स्ट्रिंग नई तिथि फ़ॉर्मेट या सूत्र निर्धारित कर सकती है?**

नहीं। वह फ़ील्ड प्रकार की पहचान करती है। अज्ञात पहचानकर्ता कोई मूल्यांकक या PHP तिथि‑फ़ॉर्मेट पैटर्न प्रदान नहीं करता। समर्थित पूर्वनिर्धारित प्रकार का उपयोग करें या मूल्य को स्वयं सामान्य टेक्स्ट के रूप में फ़ॉर्मेट करें।

**सहेजने के बाद प्रेजेंटेशन की फिर से जाँच क्यों करनी चाहिए?**

फ़ील्ड पहचानकर्ता, गणना किया गया टेक्स्ट, और फ़ॉर्मेटिंग अलग‑अलग चीज़ें हैं जिन्हें सत्यापित करना आवश्यक है। फ़ॉर्मेट परिवर्तन दृश्यमान परिणाम को बदल सकता है, भले ही फ़ील्ड पहचानकर्ता अभी भी मौजूद हो।