---
title: जावा में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/java/open-presentation/
keywords:
- PowerPoint खोलें
- OpenDocument खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को सहजता से खोलें—तेज़, विश्वसनीय, पूरी तरह विशेषताओं से युक्त।"
---
## **परिचय**

शुरू से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी अनुमति देता है। प्रस्तुति लोड करने के बाद, आप उसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड सामग्री को संपादित कर सकते हैं, नई स्लाइड जोड़ सकते हैं, मौजूदा स्लाइड को हटा सकते हैं, और भी बहुत कुछ।

## **प्रस्तुतियों को खोलना**

एक मौजूदा प्रस्तुति खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं और फ़ाइल पथ को उसके कन्स्ट्रक्टर में पास करें।

निम्नलिखित Java उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:
```java
// Presentation क्लास का इंस्टैंस बनाएं और उसके कन्स्ट्रक्टर में फ़ाइल पथ पास करें।
Presentation presentation = new Presentation("Sample.pptx");
try {
    // प्रस्तुति में कुल स्लाइड्स की संख्या प्रिंट करें।
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलना**

जब आपको पासवर्ड-संरक्षित प्रस्तुति खोलनी हो, तो पासवर्ड को [setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) मेथड के माध्यम से [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) क्लास में पास करें ताकि इसे डीक्रिप्ट और लोड किया जा सके। निम्नलिखित Java कोड इस ऑपरेशन को दर्शाता है:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति पर ऑपरेशन्स करें।
} finally {
    presentation.dispose();
}
```

## **बड़ी प्रस्तुतियों को खोलना**

Aspose.Slides विकल्प प्रदान करता है—विशेषतः [getBlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) मेथड, जो [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) क्लास में है—ताकि आप बड़ी प्रस्तुतियों को लोड करने में मदद ले सकें।

निम्नलिखित Java कोड एक बड़ी प्रस्तुति (उदाहरण के तौर पर 2 GB) लोड करने को दर्शाता है:
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked व्यवहार चुनें—प्रेज़ेंटेशन फ़ाइल अपने जीवनकाल तक लॉक रहेगी
// प्रेज़ेंटेशन इंस्टेंस के दौरान, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की आवश्यकता नहीं है।
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // बड़ी प्रस्तुति लोड हो गई है और इसका उपयोग किया जा सकता है, जबकि मेमोरी उपयोग कम बना रहता है।

    // प्रेज़ेंटेशन में परिवर्तन करें।
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // प्रेज़ेंटेशन को दूसरी फ़ाइल में सहेजें। इस ऑपरेशन के दौरान मेमोरी उपयोग कम बना रहता है।
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // ऐसा न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहेगी जब तक प्रेज़ेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं किया जाता।
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// यहाँ करने में कोई समस्या नहीं है। स्रोत फ़ाइल अब प्रेज़ेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं है।
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
स्ट्रीम के साथ काम करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides संभवतः स्ट्रीम की सामग्री की कॉपी बना सकता है। स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति की कॉपी बनती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, हम दृढ़ता से अनुशंसा करते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हैं जिसमें बड़े ऑब्जेक्ट (वीडियो, ऑडियो, उच्च-रिज़ॉल्यूशन छवियाँ आदि) शामिल हों, तो आप मेमोरी उपयोग कम करने के लिए [BLOB management](/slides/hi/java/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाहरी संसाधनों को नियंत्रित करना**

Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों का प्रबंधन करने की अनुमति देता है। निम्नलिखित Java कोड `IResourceLoadingCallback` इंटरफ़ेस का उपयोग कैसे करें दर्शाता है:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```
```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // एक प्रतिस्थापन छवि लोड करें।
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // एक प्रतिस्थापन URL सेट करें।
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // अन्य सभी छवियों को छोड़ें।
        return ResourceLoadingAction.Skip;
    }
}
```

## **बिना एम्बेडेड बाइनरी ऑब्जेक्ट्स के प्रस्तुतियों को लोड करना**

PowerPoint प्रस्तुति में निम्नलिखित प्रकार के एम्बेडेड बाइनरी ऑब्जेक्ट हो सकते हैं:

- VBA प्रोजेक्ट (जिसे [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getVbaProject--) के द्वारा एक्सेस किया जा सकता है);
- OLE ऑब्जेक्ट एम्बेडेड डेटा (जिसे [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के द्वारा एक्सेस किया जा सकता है);
- ActiveX कंट्रोल बाइनरी डेटा (जिसे [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) के द्वारा एक्सेस किया जा सकता है)।

आप [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) मेथड का उपयोग करके प्रस्तुति को बिना किसी एम्बेडेड बाइनरी ऑब्जेक्ट के लोड कर सकते हैं।

यह मेथड संभावित दुर्भावनात्मक बाइनरी सामग्री को हटाने में उपयोगी है। निम्नलिखित Java कोड बिना किसी एम्बेडेड बाइनरी सामग्री के प्रस्तुति को लोड करने का उदाहरण दिखाता है:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // प्रेज़ेंटेशन पर ऑपरेशन्स करें।
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ाइल भ्रष्ट है और नहीं खोली जा सकती, यह कैसे पता चल सकता है?**

लोड के दौरान आपको एक पार्सिंग/फ़ॉर्मेट वैलिडेशन एक्सेप्शन प्राप्त होगा। ऐसी त्रुटियों में अक्सर एक अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड का उल्लेख होता है।

**खोलते समय आवश्यक फ़ॉन्ट अनुपलब्ध हों तो क्या होगा?**

फ़ाइल खुलेगी, लेकिन बाद में [rendering/export](/slides/hi/java/convert-presentation/) फ़ॉन्ट प्रतिस्थापित कर सकता है। [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें](/slides/hi/java/font-substitution/) या [आवश्यक फ़ॉन्ट जोड़ें](/slides/hi/java/custom-font/) रनटाइम एनवायरनमेंट में।

**खोलते समय एम्बेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति के संसाधन के रूप में उपलब्ध हो जाएंगे। यदि मीडिया बाह्य पथों के माध्यम से संदर्भित हैं, तो सुनिश्चित करें कि वे पथ आपके वातावरण में उपलब्ध हों; अन्यथा [rendering/export](/slides/hi/java/convert-presentation/) मीडिया को छोड़ सकता है।