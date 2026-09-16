---
title: PHP में प्रस्तुतियों को XAML में निर्यात करें
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/php-java/export-to-xaml/
keywords:
- PowerPoint निर्यात करें
- OpenDocument निर्यात करें
- प्रस्तुति निर्यात करें
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- PowerPoint को XAML में
- OpenDocument को XAML में
- प्रस्तुति को XAML में
- PPT को XAML में
- PPTX को XAML में
- ODP को XAML में
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स को XAML में बदलें — तेज़, Office‑मुक्त समाधान जो आपके लेआउट को बना रखता है।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने का तरीका बताता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का उदाहरण, और निर्यात को [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) के माध्यम से अनुकूलित करने का प्रदर्शन (जैसे छिपी स्लाइडों का निर्यात) शामिल है। लेख में फॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **XAML के बारे में**

XAML एक XML-आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ्रेमवर्क में उपयोगकर्ता इंटरफ़ेस वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को दृश्य डिज़ाइनर में काम कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

निम्नलिखित PHP उदाहरण दर्शाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए। इस लेख में उदाहरण चलाने से पहले PHP Java Bridge को प्रारंभ करें और `aspose.slides.php` लोड करें। `pres.pptx` को Java Bridge सर्वर की कार्य निर्देशिका में रखें, या उस सर्वर द्वारा पहुँचा जा सकने वाला पूर्ण पथ प्रदान करें।

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइडें Java Bridge सर्वर की वर्तमान कार्य निर्देशिका में `pres` उपफ़ोल्डर में सहेजी जाती हैं। फ़ोल्डर स्वचालित रूप से बनाया जाता है, और आवश्यक सभी छवियों को भी वहीं सहेजा जाता है।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से उसके एक्सटेंशन को हटाकर लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम की होंगी। यदि आप इनपुट प्रस्तुति के लिए पूर्ण पथ प्रदान करते हैं, तो भी आउटपुट फ़ोल्डर Java Bridge सर्वर की वर्तमान कार्य निर्देशिका के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

Aspose.Slides द्वारा प्रस्तुति को XAML में निर्यात करने के तरीके को नियंत्रित करने के लिए [IXamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloptions/) इंटरफ़ेस का उपयोग करें।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को लागू करने वाला एक Java प्रॉक्सी प्रदान करें और अपनी कार्यान्वयन का एक उदाहरण [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) के `setOutputSaver` मेथड में पास करें।

XAML आउटपुट में छिपी स्लाइडों को शामिल करने के लिए, नीचे दिए गए PHP उदाहरण की तरह `setExportHiddenSlides` को `true` के साथ कॉल करें:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **सभी उत्पन्न XAML कलाकृतियों को पकड़ें**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़ के साथ अलग-अलग छवियां और सहायक संसाधन उत्पन्न कर सकता है। डिफ़ॉल्ट फ़ाइल‑सिस्टम सेवेर की बजाय इन कलाकृतियों को प्राप्त करने के लिए एक कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/#setOutputSaver) पर असाइन करें। निर्यात को XAML‑विशिष्ट [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) ओवरलोड के माध्यम से शुरू करें जो XAML विकल्प लेता है।

PHP Java Bridge का `java_closure` फ़ंक्शन एक PHP ऑब्जेक्ट को Java इंटरफ़ेस के रूप में उजागर करता है। निर्यात समाप्त होने तक PHP सेवेर और उसके प्रॉक्सी दोनों को जीवित रखें। इंटरफ़ेस लिंक प्रॉक्सी द्वारा लागू Java API की ओर संकेत करते हैं।

### **कॉलबैक जीवनचक्र को समझें**

निर्यातकर्ता प्रत्येक उत्पन्न कलाकृति के लिए अलग‑अलग [IXamlOutputSaver::save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) को कॉल करता है:

- `path` कलाकृति की पहचान करता है और इसमें सापेक्ष डायरेक्ट्रीज़ शामिल हो सकती हैं। यह जानकारी रखें क्योंकि XAML सापेक्ष पथों का उपयोग करके संसाधनों को संदर्भित कर सकता है।
- `data` कलाकृति के बाइट्स को सम्मिलित करता है। छवियों और अन्य बाइनरी संसाधनों को टेक्स्ट के रूप में डिकोड नहीं किया जाना चाहिए।
- सेवेर को डेटा को बनाए रखना या स्थायी करना चाहिए और फिर लौटना चाहिए। उदाहरण प्रत्येक Java बाइट एरे को एक PHP बाइनरी स्ट्रिंग में बदलते हैं जो एप्लिकेशन के स्वामित्व में होती है।
- निर्यात को तभी सफल माना जाए जब प्रस्तुति सहेजने का ऑपरेशन लौटे और सभी कॉलबैक सफलतापूर्वक पूरा हो जाएँ। स्टोरेज त्रुटियों को अवरोधित न करें या अनदेखी बैकग्राउंड लिखाइयों को न शुरू करें। यदि स्थायित्व बाद में होता है, तो समग्र सफलता की रिपोर्ट केवल उस चरण के सफल होने के बाद ही करें।

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) कस्टम सेवेर पर भी लागू होता है। डिफ़ॉल्ट मान `false` छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर रखता है। `true` पास करने पर वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गणना प्रस्तुति पर निर्भर करती है; प्रत्येक स्लाइड के लिए एक कॉलबैक या निश्चित क्रम मानने से बचें।

### **मेमोरी में निर्यात करें और कलाकृतियों का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, प्रत्येक कलाकृति को PHP एसोसिएटिव एरे में बाइनरी स्ट्रिंग के रूप में संग्रहित करता है, और उसका नाम, प्रकार, तथा बाइट गिनती प्रिंट करता है। यह प्रदान किए गए नामों को ठीक वैसा ही रखता है। दोहराए गए नाम संग्रह को अमान्य चिन्हित करते हैं बजाय किसी कलाकृति को चुपचाप अधिलेखित करने के। उदाहरण इस जाँच को परिणाम उपयोग करने से पहले करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // केवल XAML को वैकल्पिक निरीक्षण के लिए UTF-8 टेक्स्ट माना जाता है।
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

फ़ाइल एक्सटेंशन जाँच निरीक्षण के लिए उपयोगी है; सभी कलाकृतियों को रखें, जिसमें अपरिचित संसाधन प्रकार भी शामिल हों। बाइट्स को संग्रहीत या प्रसारित करते समय उन्हें अपरिवर्तित रखें। PHP स्ट्रिंग बाइनरी डेटा, शून्य बाइट सहित, को धारण कर सकती है। XAML की जाँच करते समय स्ट्रिंग को केवल UTF‑8 टेक्स्ट मानें; छवि या संसाधन बाइट्स को ट्रांसकोड न करें।

### **कलाकृतियों को ZIP अभिलेख में पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को संग्रहित करता है, नामों की वैधता जाँचता है, और मूल बाइट्स को एक ZIP अभिलेख में लिखता है। एक विशेष रूप से बनाई गई जॉब डायरेक्ट्री समवर्ती निर्यात कार्यों को अलग करती है। इस उदाहरण में PHP Phar एक्सटेंशन के ZIP समर्थन की आवश्यकता है। ZIP प्रविष्टियों में आगे की स्लैश (`/`) उपयोग करें और सापेक्ष डायरेक्ट्री बनाए रखें। असुरक्षित नाम या सामान्यीकरण के बाद टकराव वाले नाम पूरे पैकेज को लिखने से पहले अस्वीकार कर देते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

उदाहरण [PharData](https://www.php.net/manual/en/class.phardata.php) का उपयोग करके PHP प्रक्रिया की कार्य निर्देशिका में एक स्थानीय ZIP अभिलेख लिखता है; निर्यातकर्ता स्वयं ढीली XAML या छवि फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, अभिलेख‑लेखन चरण को संग्रहीत बाइनरी स्ट्रिंग्स के अपलोड से प्रतिस्थापित करें। निर्यात‑जॉब पहचानकर्ता के साथ पूर्ण सापेक्ष कलाकृति नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या जॉब पहचानकर्ता, सापेक्ष नाम और बाइनरी डेटा को डेटाबेस पंक्ति में रखें। सभी अपलोड पूर्ण होने या डेटाबेस लेन‑देन कमिट होने के बाद ही जॉब प्रकाशित करें। स्थायित्व विफलता पर आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, एक कस्टम सेवेर प्रत्येक कलाकृति को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है ताकि पूरी निर्यात की अतिरिक्त प्रतिलिपि एप्लिकेशन मेमोरी में न रखनी पड़े। निर्यातकर्ता के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: बाइट्स को गंतव्य द्वारा स्वीकार करने के बाद ही लौटें, और विफलताओं को कॉलर तक पहुँचने दें।

### **संसाधन नामों को संरक्षित रखें और संदर्भों की जाँच करें**

- गंतव्य की आवश्यकता अनुसार पाथ विभाजकों को सामान्यीकृत करें, लेकिन सापेक्ष डायरेक्ट्रीज़ को बनाए रखें। केवल तब `basename` का प्रयोग करें जब सभी उत्पन्न नाम अद्वितीय हों और संसाधन संदर्भ वैध रहें।
- गंतव्य‑विशिष्ट नाम मान्यता लागू करें। ढीली फ़ाइलें लिखते समय, मूल पथ और ट्रैवर्सल सेगमेंट को अस्वीकार करें, गंतव्य को पूर्ण पथ में बदलें, और सुनिश्चित करें कि वह निर्यात डायरेक्ट्री के भीतर ही रहे, जिसमें containment जाँच में डायरेक्ट्री सेपरेटर शामिल हो। प्रतीकात्मक लिंक‑रहित, एप्लिकेशन‑नियंत्रित डायरेक्ट्री उपयोग करें।
- प्रत्येक निर्यात जॉब के लिए अलग सेवेर और स्टोरेज नेमस्पेस रखें। विभाजक सामान्यीकरण और गंतव्य की केस‑सेंसिटिविटी नियमों के अनुसार टकरावों का पता लगाएँ।
- प्रकाशित करने से पहले, प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसके फ़ाइल‑आधारित संसाधन संदर्भों (जैसे `Source` या `ImageSource` एट्रिब्यूट) की जाँच करें। प्रत्येक सापेक्ष URI को उस XAML कलाकृति की डायरेक्ट्री के सापेक्ष हल करें, resulting storage name को सामान्यीकृत करें, और पुष्टि करें कि संबंधित मानचित्र कुंजी, ZIP प्रविष्टि, या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को फ़ाइल‑नामों से अलग‑अलग संभालें।

उदाहरण के तौर पर, यदि `pres/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना इस संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज में, जॉब प्रीफ़िक्स के तहत वही लेआउट बनाए रखें और उन संसाधन URLs को XAML उपभोक्ता के लिए सुलभ बनाएँ। पूर्ण ZIP को फिर से खोलकर प्रविष्टि नामों और संसाधन बाइट्स की जाँच करें, और लक्ष्य XAML वातावरण में प्रतिनिधि स्लाइड्स लोड करके पुष्टि करें कि छवियां सही ढंग से हल होंगी।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो भविष्यवाणी योग्य फ़ॉन्ट कैसे सुनिश्चित करें?**

[XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) में `setDefaultRegularFont` को कॉल करें — निर्यात के दौरान मूल फ़ॉन्ट अनुपलब्ध होने पर यह फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। यह गारंटी नहीं देता कि उत्पन्न XAML फॉलबैक फ़ॉन्ट को संदर्भित करेगा या लक्ष्य मशीन पर फ़ॉन्ट उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध हों।

**क्या निर्यातित XAML केवल WPF के लिए ही लक्षित है, या इसे अन्य XAML स्टैक में भी उपयोग किया जा सकता है?**

Aspose.Slides अपना सार्वजनिक API द्वारा WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसे अन्य XAML स्टैक के साथ संगतता गारंटीकृत नहीं है। उत्पन्न मार्कअप को अपने लक्ष्य वातावरण में परीक्षण करें।

**क्या छिपी स्लाइडों का समर्थन है, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोका जा सकता है?**

डिफ़ॉल्ट रूप से छिपी स्लाइडें शामिल नहीं रहतीं। आप इस व्यवहार को [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) में `setExportHiddenSlides` के माध्यम से नियंत्रित कर सकते हैं — अगर आपको इन्हें निर्यात करने की आवश्यकता नहीं है तो इसे निष्क्रिय रखें।