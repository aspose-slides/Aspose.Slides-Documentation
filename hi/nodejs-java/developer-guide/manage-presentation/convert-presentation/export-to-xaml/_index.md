---
title: JavaScript में XAML के लिए प्रस्तुतियों का निर्यात
linktitle: प्रस्तुति को XAML
type: docs
weight: 30
url: /hi/nodejs-java/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides का उपयोग करके JavaScript में PowerPoint और OpenDocument स्लाइड्स को XAML में बदलें—एक तेज़, Office‑मुक्त समाधान जो आपके लेआउट को बरकरार रखता है।
---
## **Overview**

यह लेख Aspose.Slides का प्रयोग करके PowerPoint प्रस्तुतीकरण को XAML में निर्यात करने का तरीका समझाता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुतीकरण को XAML में सहेजने का उदाहरण, और [XamlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन (छिपी हुई स्लाइड्स को निर्यात करना सहित) शामिल है। लेख फॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता, और छिपी हुई स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी देता है।

## **About XAML**

XAML एक XML‑आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ़्रेमवर्क में उपयोगकर्ता इंटरफ़ेस का वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ायनर में काम कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **Export Presentations to XAML With Default Options**

निम्नलिखित JavaScript उदाहरण डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुतीकरण को XAML में निर्यात करने को दर्शाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइड्स प्रक्रिया की वर्तमान कार्य निर्देशिका की `input` उप‑फ़ोल्डर में सहेजी जाती हैं। फ़ोल्डर स्वचालित रूप से बनाया जाता है, और आवश्यक छवि फ़ाइलें भी वहीं सहेजी जाती हैं।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल नाम से उसका एक्सटेंशन हटाकर लिया जाता है। Aspose.Slides for Node.js via Java 26.8 में `input.pptx` निर्यात करने पर `input/input/Slide_1.xaml` जैसा नेस्टेड पथ उत्पन्न होता है। आउटपुट को संभालते समय उत्पन्न पथों को पूर्ण रूप से संरक्षित रखें। डिफ़ॉल्ट आउटपुट वर्तमान कार्य निर्देशिका के सापेक्ष होता है, न कि अनिवार्य रूप से स्रोत फ़ाइल के समान स्तर पर।

## **Export Presentations to XAML With Custom Options**

[IXamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloptions/) इंटरफ़ेस का उपयोग करके आप Aspose.Slides द्वारा XAML निर्यात को नियंत्रित कर सकते हैं।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को लागू करें और इसकी इंस्टेंस को [XamlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/) के [setOutputSaver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) मेथड को पास करें।

XAML आउटपुट में छिपी हुई स्लाइड्स शामिल करने के लिए, नीचे दिए गए JavaScript उदाहरण की तरह `true` के साथ [setExportHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) को कॉल करें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capture All Generated XAML Artifacts**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़, साथ ही अलग‑अलग छवि और सहायक संसाधन बना सकता है। डिफ़ॉल्ट फ़ाइल‑सिस्टम सेव़र के बजाय इन कलाकृतियों को प्राप्त करने के लिए एक कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) में असाइन करें। XAML विकल्पों को स्वीकार करने वाले [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) ओवरलोड का उपयोग करके निर्यात प्रारंभ करें।

Node.js में, Aspose.Slides द्वारा उपयोग किए गए `java` पैकेज की `java.newProxy` फ़ंक्शन से Java इंटरफ़ेस को लागू करें। निर्यात समाप्त होने तक प्रॉक्सी को सुलभ रखें।

### **Understand the Callback Lifecycle**

निर्यातकर्ता प्रत्येक निर्मित कलाकृति के लिए अलग‑अलग [IXamlOutputSaver.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) को कॉल करता है:

- `path` कलाकृति की पहचान करता है और इसमें सापेक्ष डायरेक्टरी शामिल हो सकती हैं। इस जानकारी को रखें क्योंकि XAML सापेक्ष पथों के माध्यम से संसाधन संदर्भित कर सकता है।
- `data` में कलाकृति के बाइट्स होते हैं। छवियों और अन्य बाइनरी संसाधनों को टेक्स्ट के रूप में डिकोड न करें।
- सेव़र डेटा को स्थायी या अस्थायी रूप से रखने के बाद रिटर्न करना चाहिए। उदाहरण में प्रत्येक Java बाइट ऐरे को एप्लिकेशन‑स्वामित्व वाले Node.js बफ़र में कॉपी किया गया है।
- निर्यात को तभी सफल मानें जब प्रस्तुतीकरण सहेजने का ऑपरेशन रिटर्न हो और सभी कॉलबैक सफलतापूर्वक पूर्ण हो चुके हों। स्टोरेज त्रुटियों को दबाएँ नहीं या बैकग्राउंड राइट को अनदेखा न करें। यदि स्थायित्व बाद में होता है, तो कुल सफलता केवल उस चरण के सफल होने के बाद रिपोर्ट करें।

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) कस्टम सेव़र पर भी लागू होता है। डिफ़ॉल्ट मान `false` छिपी‑स्लाइड XAML दस्तावेज़ को बाहर रखता है। `true` पास करने पर वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन की संख्या प्रस्तुतीकरण पर निर्भर करती है; प्रत्येक स्लाइड के लिए एक कॉलबैक या स्थिर क्रम मानने से बचें।

### **Export to Memory and Inspect the Artifacts**

यह पूर्ण उदाहरण `input.pptx` को लोड करता है, प्रत्येक कलाकृति को नाम‑से‑बफ़र मैप में इकट्ठा करता है, और उसका नाम, प्रकार तथा बाइट काउंट प्रिंट करता है। यह प्रदान किए गए नामों को बिल्कुल वैसा ही रखता है। डुप्लिकेट नाम संग्रह को अमान्य दर्शाते हैं और चुपचाप कलाकृति को ओवरराइट नहीं करते। उदाहरण उपयोग से पहले इस सत्यापन को करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // केवल XAML को डिकोड करें, और केवल तभी जब पाठ्य निरीक्षण आवश्यक हो।
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

फ़ाइल एक्सटेंशन जाँच निरीक्षण के लिए उपयोगी है; सभी कलाकृतियों, सहित अपरिचित संसाधन प्रकार, को रखें। स्टोर या ट्रांसमिट करते समय बाइट्स को अपरिवर्तित रखें। केवल उन XAML के लिए UTF‑8 डिकोडिंग का उपयोग करें जिन्हें टेक्स्ट प्रोसेसिंग की आवश्यकता है।

### **Package Collected Artifacts in a ZIP Archive**

यह स्वतंत्र उदाहरण निर्यात को एकत्र करता है, नामों को सत्यापित करता है, और Java ब्रिज का उपयोग करके मूल बाइट्स को ZIP आर्काइव में लिखता है। ZIP मेमोरी में असेंबल होने के बाद डिस्क पर सहेजा जाता है। एक अनूठा आर्काइव नाम समानांतर निर्यात कार्यों को अलग करता है। ZIP प्रविष्टियों में फ़ॉरवर्ड स्लैश होते हैं और सापेक्ष डायरेक्टरी बनी रहती है। असुरक्षित नाम या सामान्यीकरण के बाद टकराव वाले नाम पूरे पैकेज को लिखने से पहले अस्वीकार कर देते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // बंद करना अभिलेख को सहेजने से पहले ZIP निर्देशिका को अंतिम रूप देता है।
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

उदाहरण में एकल स्थानीय आर्काइव लिखने के लिए [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) का उपयोग किया गया है; निर्यातकर्ता स्वयं ढीली XAML या छवि फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, आर्काइव‑लेखन चरण को संग्रहित बाइट ऐरे की अपलोड के साथ बदलें। निर्यात‑कार्य पहचानकर्ता प्लस पूर्ण सापेक्ष कलाकृति नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या कार्य पहचानकर्ता, सापेक्ष नाम, और बाइनरी डेटा को डेटाबेस पंक्ति में स्टोर करें। सभी अपलोड पूर्ण होने या डेटाबेस ट्रांज़ैक्शन कमिट होने के बाद ही कार्य प्रकाशित करें। यदि स्थायित्व विफल हो तो भागिक आउटपुट को साफ़ करें।

बड़े प्रस्तुतीकरणों के लिए, एक कस्टम सेव़र प्रत्येक कलाकृति को सीधे एप्लिकेशन स्टोरेज में स्थायी बना सकता है, जिससे पूरी निर्यात को मेमोरी में दोहराने की आवश्यकता नहीं रहती। निर्यातकर्ता के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: बाइट्स स्वीकार होने के बाद ही रिटर्न करें, और विफलताओं को कॉलर तक पहुँचने दें।

### **Preserve Resource Names and Verify References**

- यदि लक्ष्य ऐसा माँगता है तो पाथ सेपरेटर को सामान्यीकृत करें, लेकिन सापेक्ष डायरेक्टरी को बनाए रखें। केवल बेसनेम का उपयोग न करें जब तक कि सभी उत्पन्न नाम अनन्य हों और संसाधन संदर्भ वैध रहیں।
- लक्ष्य‑विशिष्ट नाम समानता लागू करें। ढीली फ़ाइलें लिखते समय रूटेड पाथ और ट्रैवर्सल सेगमेंट को अस्वीकार करें, लक्ष्य को पूर्ण पाथ में बदलें, और सुनिश्चित करें कि वह निर्यात डायरेक्टरी के भीतर ही रहता है (संक containment जाँच में डायरेक्टरी सेपरेटर शामिल हो)। प्रतीकात्मक लिंक न होने वाले, एप्लिकेशन‑नियंत्रित डायरेक्टरी का प्रयोग करें।
- प्रत्येक निर्यात कार्य के लिये अलग‑अलग सेव़र और स्टोरेज नेमस्पेस रखें। सेपरेटर सामान्यीकरण और लक्ष्य की केस‑संवेदनशीलता नियमों के अनुसार टकराव का पता लगाएँ।
- प्रकाशित करने से पहले, प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसकी फ़ाइल‑आधारित संसाधन संदर्भों (जैसे image `Source` या `ImageSource` एट्रिब्यूट) का निरीक्षण करें। प्रत्येक सापेक्ष URI को संबंधित XAML कलाकृति की डायरेक्टरी के विरुद्ध हल करें, परिणामी स्टोरेज नाम को सामान्यीकृत करें, और सुनिश्चित करें कि मैप कुंजी, ZIP प्रविष्टि, या संग्रहित ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के लिये, यदि `input/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `input/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखने से यह संबंध टूट जाएगा। ऑब्जेक्ट स्टोरेज के लिए, जॉब प्रीफ़िक्स के अंतर्गत समान लेआउट रखें और उन संसाधन URLs को XAML उपभोक्ता के लिये सुलभ बनाएं। पूर्ण ZIP को पुनः खोलकर प्रविष्टियों के नाम और संसाधन बाइट्स की जाँच करें, तथा लक्ष्य XAML पर्यावरण में प्रतिनिधि स्लाइड्स लोड करके पुष्टि करें कि छवियाँ सही ढंग से हल हो रही हैं।

## **FAQ**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वनिर्धारित फ़ॉन्ट कैसे सुनिश्चित करूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) को कॉल करें — निर्यात के समय मूल फ़ॉन्ट अनुपलब्ध होने पर इसे फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। यह सुनिश्चित नहीं करता कि उत्पन्न XAML फॉलबैक फ़ॉन्ट का संदर्भ देगा या लक्ष्य मशीन पर फ़ॉन्ट उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट्स उस वातावरण में उपलब्ध हों जहाँ वह प्रदर्शित किया जाएगा।

**क्या निर्यात किया गया XAML केवल WPF के लिये है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides अपनी सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP, Xamarin.Forms आदि जैसे अन्य XAML स्टैक्स के साथ संगतता गारंटीकृत नहीं है। उत्पन्न मार्कअप को अपने लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी हुई स्लाइड्स समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकें?**

डिफ़ॉल्ट रूप से छिपी स्लाइड्स शामिल नहीं होतीं। आप इसे [XamlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/) में [setExportHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) द्वारा नियंत्रित कर सकते हैं — यदि आपको उनका निर्यात नहीं चाहिए तो इसे निष्क्रिय रखें।