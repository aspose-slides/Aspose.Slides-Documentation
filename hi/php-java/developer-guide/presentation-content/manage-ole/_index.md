---
title: PHP का उपयोग करके प्रस्तुतियों में OLE का प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/php-java/manage-ole/
keywords:
- OLE ऑब्जेक्ट
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
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और एक्सपोर्ट करें।"
---
## **परिचय**

{{% alert color="primary" %}} 

OLE (ऑब्जेक्ट लिंकिंग और एम्बेडिंग) माइक्रोसॉफ़्ट तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के द्वारा दूसरे एप्लिकेशन में रखने की अनुमति देती है। 

{{% /alert %}} 

MS Excel में बनाई गई एक चार्ट को विचार करें। फिर वह चार्ट PowerPoint स्लाइड के भीतर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, आइकन पर डबल‑क्लिक करने से चार्ट अपने संबंधित एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने को कहा जाता है। 
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस मामले में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hi/php-java/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स को OLE ऑब्जेक्ट फ्रेम्स ([OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/)) के रूप में सम्मिलित करने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

मान लीजिए आपने Microsoft Excel में पहले ही एक चार्ट बना लिया है और इसे Aspose.Slides for PHP via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) जोड़ें जिसमें बाइट एरे और OLE ऑब्जेक्ट के बारे में अन्य जानकारी हो।  
5. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे के उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for PHP via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleembeddeddatainfo/) कन्स्ट्रक्टर दूसरे पैरामीटर के रूप में एक एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में मदद करता है।

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// OLE ऑब्जेक्ट फ्रेम को स्लाइड में जोड़ें।
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम्स जोड़ें**

Aspose.Slides for PHP via Java आपको डेटा एम्बेड किए बिना बल्कि केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देता है।

यह PHP कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) को स्लाइड में जोड़ें:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE ऑब्जेक्ट फ्रेम्स तक पहुँचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या पहुँच सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया है जिसमें पहली स्लाइड पर केवल एक शेप है।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँच लिया जाए, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।

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

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम की प्रॉपर्टीज़ तक पहुँचने की सुविधा देता है।

यह PHP कोड आपको दिखाता है कि कैसे यह जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त करें:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // लिंक्ड फ़ाइल का पूरा पाथ प्रिंट करें।
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

{{% alert color="primary" %}} 

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for PHP via Java](/cells/php-java/) का उपयोग करता है। 

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इस तरीके से उस ऑब्जेक्ट तक आसानी से पहुँच सकते हैं और उसके डेटा को संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) शेप तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक शेप है।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँच लिया जाए, आप उसपर कोई भी ऑपरेशन कर सकते हैं।  
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. वांछित `Worksheet` तक पहुँचें और डेटा को संशोधित करें।  
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँच प्राप्त की गई है, और उसके फ़ाइल डेटा को बदलकर चार्ट डेटा को अपडेट किया गया है।

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // वर्कबुक डेटा संशोधित करें।
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

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट्स के अलावा, Aspose.Slides for PHP via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के तौर पर, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उचित प्रोग्राम चुनने का संकेत दिया जाता है।

यह PHP कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

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

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित में बदलना पड़ सकता है। Aspose.Slides for PHP via Java आपको एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह PHP कोड आपको दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` पर सेट करें:

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

OLE ऑब्जेक्ट एम्बेड करने के बाद, एक आइकन इमेज से बनी प्रीव्यू स्वतः ही जोड़ दी जाती है। यह प्रीव्यू वह है जिसे उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for PHP via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह PHP कोड आपको दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट करें:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// प्रस्तुति संसाधनों में एक छवि जोड़ें।
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE ऑब्जेक्ट फ्रेम को रिसाइज़ और रीपोझिशन करने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने के लिए एक संदेश मिल सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थान बदल सकता है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट के डेटा को अपडेट करने के लिए प्रॉम्प्ट करने से रोकने हेतु, [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) क्लास की `setUpdateAutomatic` मेथड को `false` सेट करें:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for PHP via Java आपको स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में इस तरह निकालने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रेजेंटेशन में सभी शेप्स के माध्यम से लूप चलाएँ और [OLEObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) शेप्स तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और उसे डिस्क पर लिखें।  

यह PHP कोड आपको दिखाता है कि कैसे एक स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकालें:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/इमेजेज़ में एक्सपोर्ट करने पर OLE कंटेंट रेंडर किया जाएगा?**

स्लाइड पर जो दिखाई देता है, वह रेंडर किया जाता है—आइकन/विकल्पिक इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो निर्यात किए गए PDF में अपेक्षित रूप सुनिश्चित करने के लिए अपना प्रीव्यू इमेज सेट करें।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता PowerPoint में इसे स्थानांतरित/संपादित न कर सकें?**

शेप को लॉक करें: Aspose.Slides shape‑level लॉक प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह अनजाने में होने वाले संपादन और मूवमेंट को प्रभावी ढंग से रोकता है।

**क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ्स को PPTX फ़ॉर्मेट में संरक्षित रखा जाएगा?**

PPTX में, "relative path" जानकारी उपलब्ध नहीं होती—केवल पूर्ण पाथ होता है। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय एब्सोल्यूट पाथ्स/एक्सेसिबल URIs या एम्बेडिंग को प्राथमिकता दें।