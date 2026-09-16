---
title: Java में प्रस्तुतियों को XAML में निर्यात करें
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें - एक तेज़, Office-मुक्त समाधान जो आपके लेआउट को अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने की प्रक्रिया को समझाता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और निर्यात को [XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) के माध्यम से अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। लेख फ़ॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी देता है।

## **XAML के बारे में**

XAML एक XML‑आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ्रेमवर्क में उपयोगकर्ता इंटरफ़ेस वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में संपादित कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

निम्नलिखित Java उदाहरण डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में निर्यात करने को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइड्स को प्रक्रिया की वर्तमान कार्य निर्देशिका के एक `pres` उप‑फ़ोल्डर में सहेजा जाता है, जिसे खाली पथ से [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) द्वारा हल किया जाता है। फ़ोल्डर स्वचालित रूप से बनाया जाता है, और किसी भी आवश्यक छवि को भी वहीं सहेजा जाता है।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से बिना एक्सटेंशन के लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम की होंगी। भले ही आप इनपुट प्रस्तुति के लिए पूर्ण पथ प्रदान करें, आउटपुट फ़ोल्डर वर्तमान कार्य निर्देशिका के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

Aspose.Slides को प्रस्तुति को XAML में निर्यात करने के लिए नियंत्रित करने हेतु [IXamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloptions/) इंटरफ़ेस का उपयोग करें।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को लागू करें और इस कार्यान्वयन का एक उदाहरण [XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) की `setOutputSaver` विधि को पास करें।

XAML आउटपुट में छिपी स्लाइडें शामिल करने के लिए, नीचे दिखाए अनुसार `true` के साथ [setExportHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) को कॉल करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **सभी उत्पन्न XAML कला वस्तुओं को कैप्चर करें**

XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़ और अलग‑अलग छवियों एवं सहायक संसाधनों को उत्पन्न कर सकता है। इन वस्तुओं को प्राप्त करने के लिए डिफ़ॉल्ट फ़ाइल‑सिस्टम सहेजने के बजाय एक कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/) को [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) पर असाइन करें। XAML‑विशिष्ट [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ओवरलोड का उपयोग करके निर्यात शुरू करें जो XAML विकल्प स्वीकार करता है।

### **कॉलबैक जीवनचक्र को समझें**

निर्यातक प्रत्येक उत्पन्न कला वस्तु के लिए [IXamlOutputSaver.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) को अलग‑अलग कॉल करता है:

- `path` कला वस्तु को पहचानता है और इसमें सापेक्ष निर्देशिकाएँ शामिल हो सकती हैं। इस जानकारी को रखें क्योंकि XAML सापेक्ष पथों के माध्यम से संसाधनों को संदर्भित कर सकता है।
- `data` में कला वस्तु के बाइट्स होते हैं। छवियों एवं अन्य द्वि‑आधारी संसाधनों को टेक्स्ट के रूप में डिकोड नहीं किया जाना चाहिए।
- सहेजने वाले को डेटा को लौटाने से पहले बनाए रखना या स्थायित्व प्रदान करना आवश्यक है। उदाहरण प्रत्येक बाइट ऐरे को एप्लिकेशन‑स्वामित्व मेमोरी में कॉपी करते हैं।
- निर्यात को तभी सफल मानें जब प्रस्तुति सहेजने का ऑपरेशन लौटे और सभी कॉलबैक सफलतापूर्वक समाप्त हों। स्टोरेज त्रुटियों को चुपचाप न लें या अनदेखी पृष्ठभूमि लिखावट न शुरू करें। यदि स्थायित्व बाद में होता है, तो समग्र सफलता की रिपोर्ट केवल उसी चरण के सफल होने पर ही दें।

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) कस्टम सहेजने वाले पर भी लागू होता है। डिफ़ॉल्ट मान `false` छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर रखता है। `true` पास करने से उन्हें तथा उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गिनती प्रस्तुति पर निर्भर करती है; प्रति स्लाइड एक कॉलबैक या निश्चित क्रम मानने से बचें।

### **स्मृति में निर्यात करें और कला वस्तुओं का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` लोड करता है, सभी कला वस्तुओं को एक [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) में एकत्र करता है, और उनका नाम, प्रकार तथा बाइट गिनती प्रिंट करता है। यह प्रदान किए गए नामों को ठीक उसी रूप में संरक्षित रखता है। दोहराए गए नाम संग्रह को अमान्य चिन्हित करते हैं, न कि चुपचाप अधिलेखित करते हैं। उदाहरण परिणामों का उपयोग करने से पहले इस स्थिति की जाँच करता है।

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // केवल XAML को डिकोड करें, और केवल जब टेक्स्टुअल निरीक्षण की आवश्यकता हो।
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

विस्तार जाँच निरीक्षण के लिए उपयोगी है; सभी कला वस्तुओं को, अपरिचित संसाधन प्रकार सहित, रखें। बाइट्स को संग्रहीत या प्रसारित करते समय अपरिवर्तित रखें। XAML के लिए केवल टेक्स्ट प्रोसेसिंग की आवश्यकता होने पर UTF‑8 के साथ [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) का प्रयोग करें।

### **संकलित कला वस्तुओं को ZIP अभिलेख में पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को एकत्र करता है, नामों को मान्य करता है, और मूल बाइट्स को एक ZIP अभिलेख में लिखता है। एक अद्वितीय अभिलेख नाम समानांतर निर्यात कार्यों को अलग करता है। ZIP प्रविष्टियों में फॉरवर्ड स्लैश का प्रयोग होता है और सापेक्ष निर्देशिकाएँ बनी रहती हैं। असुरक्षित नाम या सामान्यीकरण के बाद टकराव वाले नाम संपूर्ण पैकेज को लिखे जाने से पहले ही अस्वीकार कर दिए जाते हैं।

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // सफलत‍ा की रिपोर्ट करने से पहले बंद करके ZIP निर्देशिका को अंतिम रूप दिया गया है।
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

उदाहरण एक [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) का उपयोग करके स्थानीय अभिलेख लिखता है; निर्यातकर्ता स्वयं ढीली XAML या छवि फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए अभिलेख‑लेखन चरण को संकलित बाइट ऐरे की अपलोड से बदलें। निर्यात‑कार्य पहचानकर्ता के साथ पूर्ण सापेक्ष कला वस्तु नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या कार्य‑पहचानों, सापेक्ष नाम और द्वि‑आधारी डेटा को डेटाबेस पंक्ति में संग्रहीत करें। सभी अपलोड पूर्ण होने या डेटाबेस लेन‑देन कमिट होने के बाद ही कार्य को प्रकाशित करें। स्थायित्व विफल होने पर आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, कस्टम सहेजने वाला प्रत्येक कला वस्तु को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है जिससे पूरी निर्यात की अतिरिक्त प्रति मेमोरी में रखनी न पड़े। निर्यातकर्ता के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: केवल तभी लौटें जब गंतव्य ने बाइट्स स्वीकार कर लिये हों, और विफलताओं को कॉलर तक पहुँचने दें।

### **संसाधन नामों को संरक्षित रखें और संदर्भ सत्यापित करें**

- जब गंतव्य को आवश्यकता हो तो पथ विभाजकों को सामान्यीकृत करें, पर सापेक्ष निर्देशिकाएँ बनाए रखें। केवल तब `Path.getFileName` का प्रयोग करें जब प्रत्येक उत्पन्न नाम की विशिष्टता सुनिश्चित हो और संसाधन संदर्भ वैध रहें।
- गंतव्य‑विशिष्ट नाम मान्यकरण लागू करें। ढीली फ़ाइलें लिखते समय मूल पथ और ट्रैवर्सल खंडों को अस्वीकार करें, गंतव्य को [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) से हल करें, और सुनिश्चित करें कि यह नियत निर्यात निर्देशिका के अंतर्गत ही रहे, जिसमें कंटेनमेंट जाँच में निर्देशिका विभाजक को शामिल करें। प्रतीकात्मक लिंक के बिना एप्लिकेशन‑नियंत्रित निर्देशिका का प्रयोग करें जो लिखने को पुनर्निर्देशित कर सकते हैं।
- प्रत्येक निर्यात कार्य के लिए अलग सहेजने वाला और स्टोरेज नामस्थान उपयोग करें। विभाजक सामान्यीकरण और गंतव्य की केस‑संवेदनशीलता नियमों के अनुसार टकरावों का पता लगाएँ।
- प्रकाशित करने से पहले प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसकी फ़ाइल‑आधारित संसाधन संदर्भों, जैसे `Source` या `ImageSource` गुणों, का निरीक्षण करें। प्रत्येक सापेक्ष URI को शामिल XAML कला वस्तु की निर्देशिका के सापेक्ष हल करें, परिणामस्वरूप स्टोरेज नाम को सामान्यीकृत करें, और पुष्टि करें कि संबंधित MAP कुंजी, ZIP प्रविष्टि या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग संभालें।

उदाहरण के लिए, यदि `pres/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना इस संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज के लिए कार्य‑उपसर्ग के अंतर्गत वही लेआउट संरक्षित रखें और उन संसाधन URLs को XAML उपभोक्ता के लिए उपलब्ध कराएँ। पूर्ण ZIP को पुनः खोलें और प्रविष्टि नाम तथा संसाधन बाइट्स की जाँच करें, तथा लक्ष्य XAML परिवेश में प्रतिनिधि स्लाइड्स को लोड करके यह सत्यापित करें कि छवियाँ सही ढंग से हल हो रही हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं कैसे सुनिश्चित करूँ कि फ़ॉन्ट पूर्वानुमानित रहें?**  
[XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) को कॉल करें — यह निर्यात के दौरान अभाव में फ़ॉन्ट को फ़ॉलबैक के रूप में उपयोग करता है। यह गारंटी नहीं देता कि निर्मित XAML फ़ॉलबैक फ़ॉन्ट को संदर्भित करेगा या फ़ॉन्ट लक्ष्य मशीन पर उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध हों।

**क्या निर्यातित XAML केवल WPF के लिए है या इसे अन्य XAML स्टैक में भी उपयोग किया जा सकता है?**  
Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसे अन्य XAML स्टैकों के साथ संगतता गारंटीकृत नहीं है। उत्पन्न मार्कअप को लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात से कैसे रोकूँ?**  
डिफ़ॉल्ट रूप से छिपी स्लाइडें शामिल नहीं होतीं। आप [XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) में [setExportHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) को निष्क्रिय रखकर इस व्यवहार को नियंत्रित कर सकते हैं।