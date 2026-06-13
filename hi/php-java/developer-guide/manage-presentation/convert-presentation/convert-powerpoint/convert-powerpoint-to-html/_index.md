---
title: PHP में PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/php-java/convert-powerpoint-to-html/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से HTML
- प्रेजेंटेशन से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रेजेंटेशन को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- PHP
- Aspose.Slides
description: "PHP में PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें। PPT और PPTX फ़ाइलें, चयनित स्लाइड्स, नोट्स, फ़ॉन्ट्स, छवियाँ, SVG और मीडिया को निर्यात करने के लिए Aspose.Slides का उपयोग करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML में सहेज सकता है। बुनियादी रूपांतरण एकल [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) लोड और एक `save` कॉल है जिसमें [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) का उपयोग किया जाता है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियों, नोट्स, टिप्पणियों, SVG आउटपुट, या लिंक किए गए संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स को निर्यात करें।
- स्थिर लेआउट, प्रतिक्रियाशील, या SVG-आधारित HTML उत्पन्न करें।
- स्पीकर नोट्स और टिप्पणियां शामिल करें।
- छवि गुणवत्ता और क्रॉप्ड इमेज डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलों को अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को कैसे लिखा जाए और संदर्भित किया जाए, चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात एक स्वयं-समाविष्ट HTML दस्तावेज़ बनाता है जहाँ अधिकांश संसाधन एम्बेड होते हैं। यह एक फ़ाइल साझा करने के लिए सुविधाजनक है, लेकिन यह आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिए, बाहरी संसाधन, नीचे की DPI वाली छवियां, और केवल उन फ़ॉन्ट्स को एम्बेड करने पर विचार करें जो लक्ष्य वातावरण में विश्वसनीय रूप से उपलब्ध नहीं हैं।

## **प्रस्तुति को HTML में परिवर्तित करें**

परिचिति को HTML में निर्यात करने के लिए, इसे [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) से लोड करें और इसे [SaveFormat.Html](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) के साथ सहेजें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

यह उदाहरण एक HTML फ़ाइल लिखता है। प्रस्तुति ऑब्जेक्ट को `finally` ब्लॉक में नष्ट किया जाता है, जिससे निर्यात के बाद फ़ाइल हैंडल और रेंडरिंग संसाधन मुक्त हो जाते हैं।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) HTML निर्यात के लिए मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स शामिल हैं:

- `SlidesLayoutOptions`: नोट्स, टिप्पणियां, हैंडआउट या अन्य लेआउट जानकारी जोड़ता है।
- `HtmlFormatter`: HTML दस्तावेज़ संरचना बदलता है या फॉर्मेटिंग को कंट्रोलर को देता है।
- `SlideImageFormat`: स्लाइड्स के प्रतिनिधित्व को बदलता है, उदाहरण के लिए SVG के रूप में।
- `PicturesCompression`: छवि DPI और आउटपुट आकार नियंत्रित करता है।
- `DeletePicturesCroppedAreas`: क्रॉप्ड इमेज डेटा को रखता या हटाता है।
- `SvgResponsiveLayout`: निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- `ShowHiddenSlides`: आवश्यकता अनुसार छिपी स्लाइड्स को शामिल करता है।

निम्नलिखित अनुभाग सबसे आम विकल्पों को अलग‑अलग दिखाते हैं ताकि आप केवल उन विकल्पों को संयोजित कर सकें जो आपके कार्य प्रवाह की आवश्यकता है।

## **चयनित स्लाइड्स को HTML में परिवर्तित करें**

`save` ओवरलोड जो स्लाइड नंबर स्वीकार करता है, 1‑आधारित स्लाइड पोजीशन का उपयोग करता है। नीचे का लूप हर स्लाइड को एक अलग HTML फ़ाइल में सहेजता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

जब वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिए एक HTML पेज चाहिए तो इस पैटर्न का उपयोग करें। यदि प्रत्येक स्लाइड का लेआउट समान होना चाहिए, तो एक ही [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) इंस्टेंस बनाएं और उसे प्रत्येक `save` कॉल में पास करें।

## **प्रतिक्रियाशील HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmlformatter/) के माध्यम से प्रतिक्रियाशील HTML आउटपुट प्रदान करता है। जब निर्यातित पेज को ब्राउज़र चौड़ाई के अनुसार बेहतर अनुकूल होना चाहिए, तब इसका उपयोग करें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

SVG‑आधारित प्रतिक्रियाशील लेआउट के लिए, [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) पर `SvgResponsiveLayout` सेट करें। यह उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **स्पीकर नोट्स और टिप्पणियां शामिल करें**

स्पीकर नोट्स या टिप्पणी को शामिल करने के लिए `HtmlOptions.SlidesLayoutOptions` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) का उपयोग करें। नोट्स और टिप्पणियां डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थितियां निर्दिष्ट नहीं करते।

मान लेते हैं स्रोत प्रस्तुति में स्पीकर नोट्स हैं:

![PowerPoint में स्पीकर नोट्स के साथ स्लाइड](slide_with_notes.png)

निम्नलिखित कोड स्लाइड सामग्री को स्लाइड के नीचे स्पीकर नोट्स के साथ निर्यात करता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होता है:

![स्लाइड और स्पीकर नोट्स के साथ HTML आउटपुट](HTML_with_notes.png)

टिप्पणियों को निर्यात करने के लिए, `CommentsPosition` सेट करें, उदाहरण के लिए `CommentsPositions.Right` या `CommentsPositions.Bottom`। यदि आपको केवल टिप्पणियां चाहिए, तो `NotesPosition` को हटाएँ। यदि आपको दोनों चाहिए, तो दोनों प्रॉपर्टी सेट करें।

## **छवि गुणवत्ता और क्रॉप्ड एरिया को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संकुचित कर सकता है जिससे आउटपुट आकार घटे। जब आपको उच्च छवि गुणवत्ता चाहिए, तो [PicturesCompression](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturescompression/) से उपयुक्त मान सेट करें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, क्रॉप्ड क्षेत्रों को निर्यातित आउटपुट से हटाया जा सकता है। केवल तभी क्रॉप्ड डेटा रखें जब उपयोगकर्ताओं को उन छुपी हुई इमेज हिस्सों को पुनः प्राप्त या निरीक्षण करना आवश्यक हो। इसे रखने से HTML आकार बढ़ सकता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए, `createDocumentFormatter` के माध्यम से [HtmlFormatter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmlformatter/) में CSS स्ट्रिंग पास करें। यह स्लाइड सामग्री को रेंडर करते हुए आस-पास के HTML दस्तावेज़ को बदलता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड्स व शैप्स के आसपास कस्टम मार्कअप के लिए, कस्टम फॉर्मेटिंग कंट्रोलर बनाकर उसे `createCustomFormatter` के साथ [HtmlFormatter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmlformatter/) को पास करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य वातावरण में प्रस्तुति फ़ॉन्ट स्थापित नहीं हो सकते, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एम्बेड करें। एम्बेडिंग दृश्य सटीकता बढ़ाता है लेकिन आउटपुट आकार बढ़ाता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

केवल तभी फ़ॉन्ट्स को बाहर रखें जब आपको भरोसा हो कि लक्ष्य ब्राउज़र या सिस्टम में वे पहले से उपलब्ध हैं। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट्स के लिए एम्बेडिंग आमतौर पर सुरक्षित रहता है।

## **फ़ॉन्ट फ़ाइलों को एम्बेड करने के बजाय लिंक करें**

HTML फ़ाइल आकार घटाने के लिए, फ़ॉन्ट डेटा को अलग‑अलग WOFF फ़ाइलों में लिखें और HTML में `@font-face` नियम जोड़ें। PHP via Java में यह परिदृश्य आम तौर पर एक छोटे Java हेल्पर क्लास से लागू किया जाता है जो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedallfontshtmlcontroller/) को विस्तारित करता है, फ़ॉन्ट बाइट्स को आउटपुट डायरेक्टरी में लिखता है, और उत्पन्न HTML में `@font-face` नियम डालता है। इस हेल्पर को कंपाइल करें, PHP Java Bridge क्लासपाथ में जोड़ें, और फिर PHP से `new Java(...)` के साथ इंस्टैंसिएट करें।

हेल्पर बनाते समय दो पाथ जानबूझकर चुनें:

- फ़ाइल‑सिस्टम आउटपुट पाथ, जहाँ उत्पन्न फ़ॉन्ट फ़ाइलें लिखी जाती हैं।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ॉन्ट फ़ाइलों को लोड करने के लिए उपयोग करता है।

## **संसाधनों को बाहरी रूप में सहेजें**

स्वयं‑समाविष्ट HTML को स्थानांतरित करना आसान है, लेकिन एम्बेडेड Base64 संसाधन फ़ाइल आकार बढ़ा सकते हैं। यदि आपका एप्लिकेशन बाहरी इमेज फ़ाइलों की मांग करता है, तो [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) कन्स्ट्रक्टर में एक कस्टम लिंक/एम्बेड कंट्रोलर पास करें।

संसाधनों को बाहरी बनाने पर दो पाथ जानबूझकर चुनें:

- फ़ाइल‑सिस्टम आउटपुट पाथ, जहाँ आपका एप्लिकेशन उत्पन्न छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो लिखता है।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ाइलों को लोड करने के लिए उपयोग करता है।

इन पाथ को अपने डिप्लॉयमेंट लेआउट के साथ संगत रखें ताकि उत्पन्न HTML वेब सर्वर या किसी अन्य डायरेक्टरी पर ले जाने के बाद भी बाहरी संसाधन लोड कर सके।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलें निर्यात करता है और HTML लिखता है जो ब्राउज़र में उन्हें चलाने में सक्षम बनाता है। इसका कन्स्ट्रक्टर लेता है:

- `path`: उत्पन्न HTML और मीडिया फ़ाइलों द्वारा उपयोग किया गया आउटपुट डायरेक्टरी।
- `fileName`: उत्पन्न हो रहा HTML फ़ाइल नाम।
- `baseUri`: मीडिया फ़ाइलों के लिंक में उपयोग किया गया पूर्ण URI प्रीफ़िक्स।

यदि HTML फ़ाइल `html-output/presentation.html` है, तो `path` को `html-output` की ओर इशारा करना चाहिए, और `baseUri` को ब्राउज़र के दृष्टिकोण से उसी डायरेक्टरी की ओर इशारा करना चाहिए। स्थानीय प्रीव्यू के लिए आप आउटपुट डायरेक्टरी से `file:///` URI बना सकते हैं। डिप्लॉयड एप्लिकेशन के लिए प्रकाशित आउटपुट डायरेक्टरी का पूर्ण URL उपयोग करें।

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

ऐसे आउटपुट डायरेक्टरी का उपयोग करें जो प्रत्येक निर्यात कार्य के लिए अद्वितीय हो, विशेष रूप से सर्वर एप्लिकेशन में। साझा आउटपुट पाथ विभिन्न रूपांतरणों की फ़ाइलों को एक‑दूसरे के ऊपर लिख सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रोसेसिंग समय और मेमोरी उपयोग स्लाइड संख्या, इमेज रेज़ोल्यूशन, फ़ॉन्ट, इफेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। उच्च `PicturesCompression` DPI मान, एम्बेडेड फ़ॉन्ट, SVG आउटपुट, और रखे गए क्रॉप्ड इमेज एरिया फ़िडेलिटी बढ़ा सकते हैं लेकिन आमतौर पर आउटपुट आकार बढ़ाते हैं।

बैच रूपांतरण के लिए:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को तुरंत नष्ट करें।
- अलग-अलग कार्यों के लिए अलग आउटपुट डायरेक्टरी उपयोग करें।
- सामान्य फ़ॉन्ट को एम्बेड करने से बचें जब तक फ़िडेलिटी की आवश्यकता न हो।
- जब HTML प्रीव्यू या थंबनेल के लिए हो, तो इमेज DPI कम रखें।
- स्रोत प्रस्तुति, उत्पन्न HTML, और बाहरी संसाधनों को तब तक एक साथ रखें जब तक डिप्लॉयमेंट पाथ अंतिम न हो जाए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक HTML आउटपुट में बरकरार रहते हैं?**

हाँ। प्रस्तुति के हाइपरलिंक HTML में निर्यात होते हैं और लक्ष्य URL वैध होने पर क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुतियों को समानांतर में HTML में बदल सकता हूँ?**

हाँ, लेकिन एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स में साझा न करें। अलग फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग स्ट्रीम और अलग आउटपुट डायरेक्टरी के साथ प्रोसेस करें।

**क्या Presentation ऑब्जेक्ट थ्रेड‑सेफ़ है?**

नहीं। एकल [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को एक ही थ्रेड पर लोड, संशोधित, सहेज और नष्ट किया जाना चाहिए। समानांतर कार्य के लिए प्रत्येक थ्रेड या प्रोसेस के लिए स्वतंत्र इंस्टेंस बनाएं।

**जनित HTML फ़ाइल बड़ी क्यों होती है?**

डिफ़ॉल्ट निर्यात संसाधनों को सीधे HTML में एम्बेड करता है। एम्बेडेड फ़ॉन्ट, हाई‑DPI इमेज, मीडिया, SVG कंटेंट, और रखे गए क्रॉप्ड इमेज एरिया सभी आकार बढ़ाते हैं। बाहरी संसाधनों का उपयोग करें, सामान्य फ़ॉन्ट को एम्बेड न करें, और छोटे आउटपुट के लिए `PicturesCompression` को कम रखें।

**PowerPoint में 24 pt फ़ॉन्ट आकार HTML में 17.999819 pt क्यों दिखता है?**

यह इसलिए हो सकता है क्योंकि PowerPoint और HTML विभिन्न DPI मॉडल उपयोग करते हैं। PowerPoint 72 DPI पर टाइपोग्राफिक पॉइंट में टेक्स्ट आकार संग्रहीत करता है, जबकि HTML लेआउट CSS पिक्सेल के आधार पर 96 DPI मॉडल पर होता है। Aspose.Slides प्रस्तुति को HTML में निर्यात करते समय फ़ॉन्ट आकार को इन सिस्टमों के बीच अनुवादित करता है, और इस प्रक्रिया में छोटे राउंडिंग अंतर उत्पन्न हो सकते हैं।

इन मानों से वास्तविक दृश्य फ़ॉन्ट‑साइज़ परिवर्तन नहीं दर्शाता। यह केवल PowerPoint और HTML के बीच टेक्स्ट मीट्रिक्स के परिवर्तन का गणितीय साइड‑इफ़ेक्ट है।

**मीडिया निर्यात के लिए baseUri कैसे चुनें?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और उसे पूर्ण URI के रूप में पास करें। स्थानीय प्रीव्यू के लिए आप आउटपुट डायरेक्टरी से Java फ़ाइल URI बना सकते हैं। डिप्लॉयमेंट के लिए प्रकाशित मीडिया डायरेक्टरी का पूर्ण URL उपयोग करें। फ़ाइल‑सिस्टम `path` और ब्राउज़र `baseUri` समान स्ट्रिंग नहीं होना ज़रूरी है, पर दोनों को उसी संसाधन स्थान का वर्णन करना चाहिए।

**क्या मैं छिपी स्लाइड्स को शामिल कर सकता हूँ?**

हाँ। जब छिपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) पर `ShowHiddenSlides` को `true` सेट करें।