---
title: Android पर प्रस्तुतियों को XAML में निर्यात करें
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/androidjava/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रेजेंटेशन निर्यात
- PowerPoint रूपांतरित करें
- OpenDocument रूपांतरित करें
- प्रेजेंटेशन रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रेजेंटेशन से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें—तेज़, ऑफिस-फ्री समाधान जो आपके लेआउट को अपरिवर्तित रखता है।"
---
## **Overview**

यह लेख बताता है कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों को XAML में कैसे निर्यात किया जाए। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स से प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। लेख में फ़ॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **About XAML**

XAML एक XML‑आधारित मार्कअप भाषा है जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) और Xamarin.Forms जैसे फ़्रेमवर्क में उपयोगकर्ता इंटरफ़ेस का वर्णन करती है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में उपयोग कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **Export Presentations to XAML With Default Options**

निम्न Java उदाहरण डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में निर्यात करने का तरीका दिखाता है:

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

डिफ़ॉल्ट रूप से निर्यातित स्लाइड्स प्रक्रिया की वर्तमान कार्यशील निर्देशिका के `pres` उपफ़ोल्डर में सहेजी जाती हैं। वह फ़ोल्डर स्वचालित रूप से बनाया जाता है, और आवश्यक छवियों को भी वहीं सहेजा जाता है।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से बिना एक्सटेंशन के लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम से बनती हैं। यदि आप इनपुट प्रस्तुति के लिए एक पूर्ण पथ पास करते हैं, तो भी आउटपुट फ़ोल्डर वर्तमान कार्यशील निर्देशिका के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

Android पर, ऐसी इनपुट फ़ाइल का उपयोग करें जो आपके ऐप के लिए सुलभ हो। वर्तमान कार्यशील निर्देशिका लिखने योग्य नहीं हो सकती; निर्यात को मेमोरी में रखने या ऐप स्टोरेज में लिखने के लिए एक कस्टम आउटपुट सेवर का उपयोग करें, जैसा कि नीचे दिखाया गया है। उत्पन्न WPF XAML एक संगत उपभोक्ता के लिए है और Android लेआउट रिसोर्स नहीं है।

## **Export Presentations to XAML With Custom Options**

Aspose.Slides को XAML में निर्यात नियंत्रित करने के लिए [IXamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ixamloptions/) इंटरफ़ेस का उपयोग करें।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ixamloutputsaver/) को लागू करें और अपने कार्यान्वयन का एक उदाहरण [XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) की [setOutputSaver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) मेथड में पास करें।

XAML आउटपुट में छिपी स्लाइडें शामिल करने के लिए, नीचे दिए गए Java उदाहरण की तरह `true` के साथ [setExportHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) कॉल करें:

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

## **Capture All Generated XAML Artifacts**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़ के साथ अलग‑अलग छवियों और सहायक संसाधनों को उत्पन्न कर सकता है। डिफ़ॉल्ट फ़ाइल‑सिस्टम सेवर के बजाय इन आर्टिफैक्ट्स को प्राप्त करने के लिए कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ixamloutputsaver/) को [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) में असाइन करें। XAML विकल्पों को स्वीकार करने वाले [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ओवरलोड का उपयोग करके निर्यात शुरू करें।

### **Understand the Callback Lifecycle**

निर्यातकर्ता प्रत्येक उत्पन्न आर्टिफैक्ट के लिए [IXamlOutputSaver.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) को अलग‑अलग कॉल करता है:

- `path` आर्टिफैक्ट को पहचानता है और इसमें सापेक्ष निर्देशिकाएँ हो सकती हैं। इस जानकारी को रखें क्योंकि XAML संसाधनों को सापेक्ष पथों से संदर्भित कर सकता है।
- `data` में आर्टिफैक्ट के बाइट्स होते हैं। छवियों और अन्य बाइनरी संसाधनों को टेक्स्ट के रूप में डिकोड नहीं करना चाहिए।
- सेवर को डेटा को बनाए रखना या स्थायी करना चाहिए और फिर रिटर्न करना चाहिए। उदाहरण प्रत्येक बाइट एरे को एप्लिकेशन‑स्वामित्व मेमोरी में कॉपी करते हैं।
- निर्यात को तभी सफल मानें जब प्रस्तुति सहेजने का ऑपरेशन रिटर्न हो और प्रत्येक कॉलबैक सफलतापूर्वक पूरा हो चुका हो। स्टोरेज त्रुटियों को दमन न करें या अनदेखे बैकग्राउंड राइट्स न शुरू करें। यदि स्थायित्व बाद में होता है, तो कुल सफलता की रिपोर्ट केवल उस चरण के सफल होने के बाद ही करें।

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) कस्टम सेवर पर भी लागू होता है। डिफ़ॉल्ट मान `false` छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर करता है। `true` पास करने से वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गणना प्रस्तुति पर निर्भर करती है; प्रत्येक स्लाइड के लिए एक कॉलबैक या स्थिर क्रम मानना न करें।

### **Export to Memory and Inspect the Artifacts**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, सभी आर्टिफैक्ट्स को एक [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) में एकत्र करता है और उनका नाम, प्रकार और बाइट गिनती प्रिंट करता है। यह प्रदान किए गए नामों को ठीक‑ठीक रखता है। डुप्लिकेट नाम संग्रह को अमान्य चिह्नित करते हैं, बजाय इसके कि किसी आर्टिफैक्ट को चुपचाप अधिलिखित किया जाए। उदाहरण परिणामों का उपयोग करने से पहले इस जांच को करता है।

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

    // केवल XAML डिकोड करें, और केवल तभी जब टेक्स्टुअल निरीक्षण आवश्यक हो।
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

विस्तार जाँच निरीक्षण के लिए उपयोगी है; सभी आर्टिफैक्ट्स, जिसमें अपरिचित संसाधन प्रकार भी शामिल हैं, को रखें। बाइट्स को संग्रहीत या प्रसारित करते समय अपरिवर्तित रखें। केवल XAML के लिए जो टेक्स्ट प्रोसेसिंग की आवश्यकता रखता है, UTF‑8 के साथ [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) का उपयोग करें।

### **Package Collected Artifacts in a ZIP Archive**

यह स्वतंत्र उदाहरण निर्यात को एकत्र करता है, नामों की वैधता जांचता है, और मूल बाइट्स को ZIP आर्काइव में लिखता है। `/path/to/app/files` को अपने Android कॉन्टेक्स्ट की [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) मेथड से प्राप्त पथ से बदलें। एक अद्वितीय आर्काइव नाम समानांतर निर्यात कार्यों को अलग रखता है। ZIP एंट्रीज़ आगे स्लैश (`/`) का उपयोग करती हैं और सापेक्ष निर्देशिकाओं को बनाए रखती हैं। सामान्यीकृत नामों के बाद टकराव या असुरक्षित नाम पूरे पैकेज को लिखे जाने से पहले ही अस्वीकार करते हैं।

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP निर्देशिका को बंद करके सुरक्षित कर दिया गया है, सफलता की रिपोर्ट करने से पहले।
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

उदाहरण [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) का उपयोग करके स्थानीय आर्काइव लिखता है; निर्यातकर्ता स्वयं ढीली XAML या छवि फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, आर्काइव‑लेखन चरण को एकत्रित बाइट एरेज़ के अपलोड से बदलें। निर्यात‑कार्य पहचानकर्ता को पूर्ण सापेक्ष आर्टिफैक्ट नाम के साथ ब्लॉब कुंजी के रूप में उपयोग करें, या डेटाबेस पंक्ति में कार्य‑पहचानकर्ता, सापेक्ष नाम और बाइनरी डेटा रखें। सभी अपलोड पूरी होने या डेटाबेस ट्रांज़ैक्शन कमिट होने के बाद ही कार्य प्रकाशित करें। यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, कस्टम सेवर प्रत्येक आर्टिफैक्ट को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है ताकि संपूर्ण निर्यात की अतिरिक्त प्रति मेमोरी में न रहे। निर्यातकर्ता के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: केवल तब रिटर्न करें जब गंतव्य ने बाइट्स स्वीकार कर लिए हों, और विफलताओं को कॉलर तक पहुंचने दें।

### **Preserve Resource Names and Verify References**

- जब गंतव्य इसे मांगता है तो पाथ सेपरेटर्स को सामान्यीकृत करें, लेकिन सापेक्ष निर्देशिकाएँ बनाए रखें। केवल तब [File.getName](https://developer.android.com/reference/java/io/File#getName()) का उपयोग करें जब सभी उत्पन्न नाम अद्वितीय हों और संसाधन संदर्भ मान्य रहें।
- गंतव्य‑विशिष्ट नाम सत्यापन लागू करें। ढीली फ़ाइलें लिखते समय रूटेड पाथ्स और ट्रैवर्सल सेगमेंट को अस्वीकार करें, गंतव्य को [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) से हल करें, और सुनिश्चित करें कि वह इच्छित निर्यात डायरेक्ट्री के भीतर ही रहे, जिसमें कंटेनमेंट जाँच में डायरेक्ट्री सेपरेटर शामिल हो। सिम्बॉलिक लिंक वाले डायरेक्ट्री का उपयोग न करें जो लिखने को पुनः‑निर्देशित कर सकते हैं।
- प्रत्येक निर्यात कार्य के लिए अलग‑अलग सेवर और स्टोरेज नेमस्पेस रखें। सेपरेटर सामान्यीकरण के बाद टकराव का पता लगाएँ और गंतव्य की केस‑संवेदनशीलता नियमों के अनुसार कार्य करें।
- प्रकाशित करने से पहले, प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसके फ़ाइल‑आधारित संसाधन रेफ़रेंसेज़, जैसे `Source` या `ImageSource` एट्रिब्यूट्स, की जाँच करें। प्रत्येक सापेक्ष URI को संबंधित XAML आर्टिफैक्ट की डायरेक्ट्री के विरुद्ध हल करें, उत्पन्न स्टोरेज नाम को सामान्यीकृत करें, और पुष्टि करें कि समान मानचित्र कुंजी, ZIP एंट्री या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के लिए, यदि `pres/Slide_1.xaml` में `images/image1.png` का रेफ़रेंस है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना इस संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज के लिए, कार्य‑प्रिफ़िक्स के तहत वही लेआउट बनाकर उन संसाधन URL को XAML उपभोक्ता के लिए सुलभ करें। पूर्ण ZIP को पुनः खोलें, एंट्री नाम और संसाधन बाइट्स की जाँच करें, और लक्ष्य XAML वातावरण में प्रतिनिधि स्लाइड्स लोड करके पुष्टि करें कि छवियाँ सही ढंग से हल हो रही हैं।

## **FAQ**

**मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं होने पर मैं सुगम फ़ॉन्ट कैसे सुनिश्चित करूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) को कॉल करें — यह निर्यात के दौरान मूल फ़ॉन्ट के अभाव में फ़ॉलबैक फ़ॉन्ट के रूप में उपयोग होता है। यह गारंटी नहीं देता कि उत्पन्न XAML फ़ॉलबैक फ़ॉन्ट को संदर्भित करता है या लक्ष्य मशीन पर वह फ़ॉन्ट उपलब्ध है। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट्स उस वातावरण में उपलब्ध हों जहाँ इसे प्रदर्शित किया जाएगा।

**क्या निर्यात किया गया XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। अन्य XAML स्टैक्स, जैसे UWP और Xamarin.Forms, के साथ संगतता की गारंटी नहीं है। उत्पन्न मार्कअप को अपने लक्षित वातावरण में टेस्ट करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकें?**

डिफ़ॉल्ट रूप से छिपी स्लाइडें शामिल नहीं होतीं। आप इसे [XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) में [setExportHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) के माध्यम से नियंत्रित कर सकते हैं — यदि आपको उन्हें निर्यात करने की आवश्यकता नहीं है तो इसे बंद रखें।