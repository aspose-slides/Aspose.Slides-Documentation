---
title: Android पर प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/androidjava/open-presentation/
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
- संरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Android
- Java
- Aspose.Slides
description: "ऑन Android Java के माध्यम से Aspose.Slides के साथ PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को आसानी से खोलें—तेज़, विश्वसनीय, पूरी तरह सुविधाजनक।"
---
## **परिचय**

सुरुए से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी अनुमति देता है। एक प्रस्तुति लोड करने के बाद, आप इसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड की सामग्री संपादित कर सकते हैं, नई स्लाइड जोड़ सकते हैं, मौजूदा स्लाइड को हटा सकते हैं, और बहुत कुछ।

## **प्रस्तुतियों को खोलें**

मौजूदा प्रस्तुति खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं और फ़ाइल पथ को इसके कन्स्ट्रक्टर में पास करें।

निम्नलिखित Java उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती कैसे प्राप्त करें:

```java
// Presentation क्लास का उदाहरण बनाएं और इसके कन्स्ट्रक्टर में फ़ाइल पथ पास करें.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // प्रस्तुति में कुल स्लाइड संख्या प्रिंट करें.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

जब आपको पासवर्ड-संरक्षित प्रस्तुति खोलनी हो, तो [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) क्लास की [setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) मेथड के माध्यम से पासवर्ड पास करके इसे डिक्रिप्ट और लोड करें। निम्नलिखित Java कोड इस ऑपरेशन को दर्शाता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति पर संचालन करें.
} finally {
    presentation.dispose();
}
```

## **बड़ी प्रस्तुतियों को खोलें**

Aspose.Slides विकल्प प्रदान करता है—विशेष रूप से [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) क्लास में [getBlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) मेथड—जो आपको बड़ी प्रस्तुतियों को लोड करने में मदद करता है।

निम्नलिखित Java कोड एक बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने को दर्शाता है:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked व्यवहार चुनें—प्रस्तुति फ़ाइल Presentation इंस्टैंस के जीवनकाल तक लॉक रहेगी, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की आवश्यकता नहीं है.
 // the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // बड़ी प्रस्तुति लोड हो गई है और उपयोग की जा सकती है, जबकि मेमोरी उपयोग कम बना रहता है.

    // प्रस्तुति में परिवर्तन करें.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // प्रस्तुति को किसी अन्य फ़ाइल में सहेजें। इस ऑपरेशन के दौरान मेमोरी उपयोग कम रहता है.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // यह न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति ऑब्जेक्ट नष्ट न हो जाए.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// यहाँ करना ठीक है। स्रोत फ़ाइल अब प्रस्तुति ऑब्जेक्ट द्वारा लॉक नहीं है.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="सूचना" %}}
स्ट्रीम्स के साथ काम करते समय कुछ सीमाओं को पार करने के लिए, Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति की कॉपी बनती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से सुझाव देते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हैं जिसमें बड़े ऑब्जेक्ट्स (वीडियो, ऑडियो, उच्च‑रिज़ॉल्यूशन छवियां आदि) हों, तो आप मेमोरी उपभोग को कम करने के लिए [BLOB management](/slides/hi/androidjava/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों को प्रबंधित करने की अनुमति देता है। निम्नलिखित Java कोड दिखाता है कि `IResourceLoadingCallback` इंटरफ़ेस का उपयोग कैसे करें:

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
                // एक प्रतिस्थापन छवि लोड करें.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // बाइट्स प्राप्त करने के लिए कोई भी विधि उपयोग करें
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // एक प्रतिस्थापन URL सेट करें.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // अन्य सभी छवियों को छोड़ें.
        return ResourceLoadingAction.Skip;
    }
}
```

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक PowerPoint प्रस्तुति निम्नलिखित प्रकार के एंबेडेड बाइनरी ऑब्जेक्ट्स रख सकती है:

- VBA परियोजना (प्राप्य है [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) के माध्यम से);
- OLE ऑब्जेक्ट एंबेडेड डेटा (प्राप्य है [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के माध्यम से);
- ActiveX कंट्रोल बाइनरी डेटा (प्राप्य है [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) के माध्यम से)।

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) मेथड का उपयोग करके, आप किसी भी एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुति लोड कर सकते हैं।

यह मेथड संभावित दुर्भावनापूर्ण बाइनरी सामग्री को हटाने के लिए उपयोगी है। निम्नलिखित Java कोड दर्शाता है कि कैसे किसी भी एंबेडेड बाइनरी सामग्री के बिना प्रस्तुति लोड की जा सकती है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // प्रस्तुति पर संचालन करें.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**मैं कैसे पता करूँ कि फ़ाइल खराब है और नहीं खोली जा सकती?**

लोड करने के दौरान आपको पार्सिंग/फ़ॉर्मेट वैधता अपवाद मिलेगा। ऐसे त्रुटियों में अक्सर अमान्य ZIP संरचना या टूटी हुई PowerPoint रिकॉर्ड्स का उल्लेख होता है।

**यदि खोलते समय आवश्यक फ़ॉन्ट्स मौजूद नहीं हैं तो क्या होता है?**

फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/androidjava/convert-presentation/) फ़ॉन्ट्स को बदल सकता है। रनटाइम पर्यावरण में [Configure font substitutions](/slides/hi/androidjava/font-substitution/) या [add the required fonts](/slides/hi/androidjava/custom-font/) जोड़ें।

**खोलते समय एंबेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति संसाधनों के रूप में उपलब्ध हो जाते हैं। यदि मीडिया को बाहरी पथों के माध्यम से संदर्भित किया गया है, तो सुनिश्चित करें कि उन पथों तक आपके पर्यावरण में पहुंच हो; अन्यथा [rendering/export](/slides/hi/androidjava/convert-presentation/) मीडिया को छोड़ सकता है।