---
title: "एंड्रॉइड पर प्रेज़ेंटेशन खोलें"
linktitle: "प्रेज़ेंटेशन खोलें"
type: docs
weight: 20
url: /hi/androidjava/open-presentation/
keywords:
- "PowerPoint खोलें"
- "प्रेज़ेंटेशन खोलें"
- "PPTX खोलें"
- "PPT खोलें"
- "ODP खोलें"
- "प्रेज़ेंटेशन लोड करें"
- "PPTX लोड करें"
- "PPT लोड करें"
- "ODP लोड करें"
- "सुरक्षित प्रेज़ेंटेशन"
- "बड़ी प्रेज़ेंटेशन"
- "बाहरी संसाधन"
- "बाइनरी ऑब्जेक्ट"
- "एंड्रॉइड"
- "जावा"
- "Aspose.Slides"
description: "एंड्रॉइड पर PowerPoint और OpenDocument प्रेज़ेंटेशन कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Android via Java के साथ मेमोरी उपयोग को कम करें, यह सीखें।"
---
## **परिचय**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hi/androidjava/) फ़ाइलों और स्ट्रिम्स से PowerPoint और OpenDocument प्रस्तुति लोड कर सकता है। प्रस्तुति लोड होने के बाद आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी से बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रेज़ेंटेशन खोलें**

फ़ाइल या स्ट्रिम लोड करने के बाद आप अपनी एप्लिकेशन के प्रोसेस करने के तरीके का चयन करने के लिए [इसके मूल प्रेज़ेंटेशन फ़ॉर्मेट को निर्धारित करें](/slides/hi/androidjava/detect-presentation-source-format/)। 

एक मौजूदा प्रेज़ेंटेशन खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। उपयोग के बाद प्रेज़ेंटेशन को डिस्पोज़ करें ताकि फ़ाइल हैंडल्स, अस्थायी डेटा और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्नलिखित Java उदाहरण दिखाता है कि प्रेज़ेंटेशन को कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-संरक्षित प्रेज़ेंटेशन खोलें**

एक खोलने वाला पासवर्ड प्रेज़ेंटेशन सामग्री को एन्क्रिप्ट करता है। पूर्ण प्रेज़ेंटेशन लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) में पास करें और इस विकल्प को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) कंस्ट्रक्टर को दें। पासवर्ड अनुपलब्ध या गलत होने पर लोडिंग विफल हो जाएगी।

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

पासवर्ड पहचान, सत्यापन और एन्क्रिप्शन वर्कफ़्लो के लिए, देखें [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रेज़ेंटेशन को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया है, तो इन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/androidjava/presentation-properties/)।

## **बड़ी प्रेज़ेंटेशन खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) विकल्प लौटाता है जो Aspose.Slides द्वारा इमेज, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालता है, उसे नियंत्रित करता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा सीमित कर सकते हैं।

निम्नलिखित Java कोड एक बड़ी प्रेज़ेंटेशन (उदाहरण के लिए, 2 GB) लोड करने को दर्शाता है:

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रेज़ेंटेशन इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को न हटाएँ, न बदलें और न स्थानांतरित करें।

Aspose.Slides लोड करते समय इनपुट स्ट्रिम की सामग्री कॉपी कर सकता है। बड़ी प्रेज़ेंटेशन के लिए फ़ाइल पथ आम तौर पर स्ट्रिम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/androidjava/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रेज़ेंटेशन में बाहरी इमेजेज़ होते हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल किया जाना आवश्यक होता है।

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रेज़ेंटेशन लोड करें**

एक प्रेज़ेंटेशन में एम्बेडेड बाइनरी डेटा हो सकता है जिसे एप्लिकेशन को आवश्यक नहीं है या वह बनाए नहीं रखना चाहता। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, जिन्हें [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) के माध्यम से पहुँचाया जा सकता है;
- एम्बेडेड OLE डेटा, जिसे [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के माध्यम से प्राप्त किया जा सकता है;
- ActiveX कंट्रोल डेटा, जिसे [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) के माध्यम से प्राप्त किया जा सकता है।

लोड करते समय इस बाइनरी डेटा को हटाने के लिए [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) को `true` सेट करें। लोडेड प्रेज़ेंटेशन को सहेजें ताकि साफ‑सुथरा परिणाम स्थायी हो सके।

यह विकल्प अनपेक्षित एम्बेडेड पेलोड्स के जोखिम को कम करता है, लेकिन यह पूर्ण मालवेयर‑डिटेक्शन या कंटेंट‑सैनीटाइजेशन प्रणाली नहीं है।

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पहचान सकता हूँ कि फ़ाइल खराब है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान एक पार्सिंग या फ़ॉर्मेट एक्सेप्शन फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग‑अलग संभालें ताकि एप्लिकेशन सटीक कारण रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होगा?**

प्रेज़ेंटेशन अभी भी लोड हो सकता है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप आउटपुट को अधिक पूर्वानुमानित बनाने के लिए [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें](/slides/hi/androidjava/font-substitution/) या [कस्टम फ़ॉन्ट्स प्रदान करें](/slides/hi/androidjava/custom-font/)।

**क्या प्रेज़ेंटेशन लोड करने से उसके एम्बेडेड मीडिया भी लोड हो जाते हैं?**

एम्बेडेड ऑडियो और वीडियो प्रेज़ेंटेशन ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुंच नहीं हो पाती तो उपलब्ध नहीं हो सकते।