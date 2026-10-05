---
title: PHP का उपयोग करके प्रस्तुतियों में OLE प्रबंधित करें
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/php-java/manage-ole/
keywords:
- OLE object
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (ऑब्जेक्ट लिंकिंग & एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक एप्लीकेशन में निर्मित डेटा और ऑब्जेक्ट को दूसरे एप्लीकेशन में लिंकिंग या एम्बेडिंग के माध्यम से रखने की अनुमति देती है।

{{% /alert %}} 

MS Excel में बनाया गया एक चार्ट विचार करें। यह चार्ट फिर PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है।

- एक OLE ऑब्जेक्ट एक आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन को दो बार क्लिक करते हैं, तो चार्ट अपने संबद्ध एप्लीकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट को खोलने या संपादित करने के लिए एप्लीकेशन चुनने का विकल्प दिया जाता है।
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) आपको OLE ऑब्जेक्ट्स को स्लाइड में OLE ऑब्जेक्ट फ्रेम्स ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)) के रूप में डालने की अनुमति देता है।

## **स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लेते हैं कि आपने Microsoft Excel में एक चार्ट बना लिया है और Aspose.Slides for PHP via Java का उपयोग करके इसे एक OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड के इंडेक्स के माध्यम से उसकी संदर्भ प्राप्त करें।
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।
4. बाइट एरे और OLE ऑब्जेक्ट की अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) को जोड़ें।
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for PHP via Java का उपयोग करके एक OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) कन्स्ट्रकटर्स एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन को दूसरे पैरामीटर के रूप में लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लीकेशन चुनने में सक्षम बनाता है।

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for PHP via Java आपको डेटा एम्बेड किए बिना बल्कि केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देता है।

यह PHP कोड दिखाता है कि लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) स्लाइड में कैसे जोड़ें:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुंचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या पहुंच सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाकर लोड करें।
2. स्लाइड का संदर्भ उसके इंडेक्स का उपयोग करके प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shape तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक shape है।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंच जाने पर, आप इस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड एक Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुंचा गया है।

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम गुणों तक पहुंचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुंचने की अनुमति देता है।

यह PHP कोड दिखाता है कि कैसे जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त करें:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन में रिलेटिव पाथ हो सकता है।
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/) का उपयोग करता है।

{{% /alert %}}

यदि OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस ऑब्जेक्ट तक पहुंच कर उसके डेटा को इस तरह संशोधित कर सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाकर लोड करें।
2. स्लाइड के इंडेक्स के माध्यम से उसकी संदर्भ प्राप्त करें। 
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shape तक पहुंचें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक shape है।
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुंच जाने पर, आप इस पर कोई भी ऑपरेशन कर सकते हैं।
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुंचें।
6. इच्छित `Worksheet` तक पहुंचें और डेटा में संशोधन करें।
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।
8. स्ट्रिम से OLE ऑब्जेक्ट डेटा बदलें।

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड एक Excel चार्ट ऑब्जेक्ट) तक पहुंचा गया है, और उसकी फ़ाइल डेटा को चार्ट डेटा अपडेट करने के लिये संशोधित किया गया है।

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Workbook डेटा को संशोधित करें।
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **स्लाइड में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट्स के अलावा, Aspose.Slides for PHP via Java आपको स्लाइड में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलें ऑब्जेक्ट के रूप में डाल सकते हैं। जब उपयोगकर्ता डालित ऑब्जेक्ट को डबल-क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने का संकेत दिया जाता है।

यह PHP कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for PHP via Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसका एक्सटेंशन अपडेट कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे एक एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` पर सेट करें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// फ़ाइल प्रकार को ZIP में बदलें।
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जिसमें आइकन इमेज होती है, स्वचालित रूप से जोड़ी जाती है। यह प्रीव्यू उपयोगकर्ताओं को OLE ऑब्जेक्ट तक पहुंचने या खोलने से पहले दिखाई देता है। यदि आप प्रीव्यू में एक विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for PHP via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह PHP कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट करें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// प्रेजेंटेशन संसाधनों में एक छवि जोड़ें।
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनः स्थित करने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रेरित होने से रोकने के लिए, [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) मेथड को [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) क्लास के साथ `false` के साथ कॉल करें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for PHP via Java आपको स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलों को इस तरह निकालने की अनुमति देता है:

1. उस [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।
2. प्रेजेंटेशन में सभी shapes पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shapes तक पहुंचें।
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों के डेटा तक पहुंचें और उसे डिस्क पर लिखें।

यह PHP कोड दिखाता है कि कैसे एक स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकालें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**क्या स्लाइड को PDF/छवियों में एक्सपोर्ट करने पर OLE कंटेंट रेंडर होगा?**

स्लाइड पर दिखने वाला ही रेंडर किया जाता है—आइकन/विकल्प छवि (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो अपने स्वयं के प्रीव्यू इमेज को सेट करें ताकि एक्सपोर्ट किए गए PDF में अपेक्षित दिखावट सुनिश्चित हो सके।  

PDF एटैचमेंट के रूप में एम्बेडेड फ़ाइल को भी संरक्षित करने के लिए, [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) को `true` के साथ कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। उदाहरण और एटैचमेंट की जाँच के निर्देशों के लिए, देखें [PDF एटैचमेंट के रूप में एम्बेडेड OLE फ़ाइलों को संरक्षित करें](/slides/hi/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं कैसे OLE ऑब्जेक्ट को स्लाइड पर लॉक कर सकता हूँ ताकि उपयोगकर्ता इसे PowerPoint में नहीं ले जा सकें/एडिट न कर सकें?**

शेप को लॉक करें: Aspose.Slides शेप-लेवल लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और आंदोलन से प्रभावी रूप से रोकता है।

**क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ PPTX फॉर्मेट में संरक्षित रहेंगे?**

PPTX में, "रिलेटिव पाथ" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ होता है। रिलेटिव पाथ पुराने PPT फॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय पूर्ण पाथ/एक्सेसिबल URIs या एम्बेडिंग को प्राथमिकता दें।