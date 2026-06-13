---
title: PowerPoint प्रस्तुतियों को PHP में Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से MD
- प्रस्तुति से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रस्तुति को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- PowerPoint
- प्रस्तुति
- Markdown
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint स्लाइड्स — PPT, PPTX — को स्वच्छ Markdown में बदलें, दस्तावेज़ीकरण स्वचालित करें और फ़ॉर्मेटिंग बनाए रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में बदलने की सुविधा देता है, जो दस्तावेज़ीकरण वर्कफ़्लो, स्थिर साइट जनरेशन, सामग्री माइग्रेशन, और संस्करण‑नियंत्रित टेक्स्ट प्रकाशन के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों से सीधे MD फ़ाइलों में निर्यात का समर्थन करता है और स्लाइड सामग्री को उत्पन्न Markdown दस्तावेज़ में कैसे दर्शाया जाए, इसे नियंत्रित करने के लिए अतिरिक्त विकल्प प्रदान करता है।

आप प्रस्तुतियों को सादे Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसी कई Markdown शैलियों में से चुन सकते हैं, और निर्यात के दौरान चित्रों को कैसे संभालना है, इसे कॉन्फ़िगर कर सकते हैं। दृश्य सामग्री वाली प्रस्तुतियों के लिए, Aspose.Slides आपको छवियों को एक अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका संदर्भ देने की सुविधा भी देता है।

{{% alert color="warning" %}}
PowerPoint‑to‑Markdown निर्यात डिफ़ॉल्ट रूप से **चित्रों के बिना** होता है। यदि आप छवियों वाले PowerPoint दस्तावेज़ को निर्यात करना चाहते हैं, तो आपको `ExportType = MarkdownExportType::Visual` सेट करना होगा और `BasePath` निर्दिष्ट करना होगा, जहाँ Markdown दस्तावेज़ में संदर्भित छवियों को सहेजा जाएगा।
{{% /alert %}}

## **प्रस्तुति को Markdown में बदलें**

यह अनुभाग बताता है कि Aspose.Slides PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, ODP) को स्वच्छ Markdown में कैसे बदलता है, मूल स्लाइड क्रम, टेक्स्ट, और मुख्य फ़ॉर्मेटिंग को अपरिवर्तित रखता है ताकि आप सामग्री को दस्तावेज़ीकरण या संस्करण‑नियंत्रित वर्कफ़्लो में अतिरिक्त मैन्युअल प्रयास के बिना पुन: उपयोग कर सकें।

1. प्रस्तुति का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
2. [save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड का उपयोग करके इसे Markdown फ़ाइल के रूप में निर्यात करें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **प्रस्तुति को Markdown शैली में बदलें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को बुनियादी सिंटैक्स के साथ Markdown में, साथ ही CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab, और सत्रह अन्य Markdown शैलियों में बदलने की अनुमति देता है।

निम्नलिखित PHP कोड दर्शाता है कि PowerPoint प्रस्तुति को CommonMark में कैसे बदलें:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

23 समर्थित Markdown शैलियों को [Flavor enumeration](https://reference.aspose.com/slides/hi/php-java/aspose.slides/flavor/) में सूचीबद्ध किया गया है।

## **छवियों वाली प्रस्तुति को Markdown में बदलें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) वर्ग उन गुणों और एनेमरेशनों को उजागर करता है जो आपको उत्पन्न Markdown फ़ाइल को कॉन्फ़िगर करने की अनुमति देते हैं। उदाहरण के लिए, [MarkdownExportType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownexporttype/) एनेमरेशन निर्दिष्ट करता है कि छवियों को कैसे संभाला जाए: `Sequential`, `TextOnly`, या `Visual`।

{{% alert color="warning" %}}
डिफ़ॉल्ट रूप से, PowerPoint‑to‑Markdown निर्यात **छवियों को शामिल नहीं करता**। छवियों को एम्बेड करने के लिए, `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` कॉल करें और `BasePath` सेट करें जो निर्दिष्ट करता है कि Markdown फ़ाइल में संदर्भित छवियों को कहाँ सहेजा जाएगा।
{{% /alert %}}

### **छवियों को क्रमिक रूप से बदलें**

यदि आप चाहते हैं कि उत्पन्न Markdown में छवियां व्यक्तिगत रूप से, एक के बाद एक दिखें, तो आपको `Sequential` विकल्प चुनना होगा। निम्नलिखित PHP कोड दर्शाता है कि छवियों वाली प्रस्तुति को Markdown में कैसे बदलें:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **छवियों को विज़ुअली बदलें**

यदि आप चाहते हैं कि उत्पन्न Markdown में छवियां साथ में दिखें, तो आपको `Visual` विकल्प चुनना होगा। इस मामले में, छवियां एप्लिकेशन की वर्तमान डायरेक्टरी में सहेजी जाती हैं (और उनके लिए Markdown दस्तावेज़ में एक रिलेटिव पथ उत्पन्न होता है), या आप अपनी पसंदीदा डायरेक्टरी और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

निम्नलिखित PHP कोड इस कार्य को दर्शाता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक निर्यात के बाद Markdown में बने रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/php-java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/php-java/slide-transition/) और [animations](/slides/hi/php-java/powerpoint-animation/) को नहीं बदला जाता।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूं?**

आप फ़ाइलों के बीच समानांतर कर सकते हैं, लेकिन थ्रेड्स में एक ही [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को [don’t share](/slides/hi/php-java/multithreading/) नहीं करना चाहिए। प्रत्येक फ़ाइल के लिए अलग-अलग इंस्टेंस/प्रोसेस का उपयोग करें ताकि प्रतिस्पर्धा से बचा जा सके।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और पथ रिलेटिव हैं?**

[Images](/slides/hi/php-java/image/) एक समर्पित फ़ोल्डर में निर्यात की जाती हैं, और Markdown फ़ाइल उन्हें डिफ़ॉल्ट रूप से रिलेटिव पथों से संदर्भित करती है। आप बेस आउटपुट पाथ और एसेट फ़ोल्डर नाम को कॉन्फ़िगर कर सकते हैं ताकि एक पूर्वानुमेय रिपॉजिटरी संरचना बनी रहे।