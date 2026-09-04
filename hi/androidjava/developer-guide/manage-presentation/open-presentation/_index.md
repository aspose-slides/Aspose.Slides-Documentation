---
title: Android पर प्रस्तुतियों को खोलें
linktitle: प्रेजेंटेशन खोलें
type: docs
weight: 20
url: /hi/androidjava/open-presentation/
keywords:
- PowerPoint खोलें
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
- Android
- Java
- Aspose.Slides
description: Android पर PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Android via Java के साथ मेमोरी उपयोग को कम करें, यह सीखें।
---
## **परिचय**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hi/androidjava/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी से बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एंबेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियाँ खोलें**

एक मौजूदा प्रस्तुति को खोलने के लिए, उसके फ़ाइल पाथ को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधनों को तुरंत मुक्त करने के लिए उपयोग के बाद प्रस्तुति को डिस्पोज़ करें।

निम्नलिखित Java उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड संख्या कैसे प्राप्त करें:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-प्रोटेक्टेड प्रस्तुतियों को खोलें**

खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूर्ण प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) कंस्ट्रक्टर में प्रदान करें। पासवर्ड अनुपस्थित या गलत होने पर लोडिंग विफल हो जाएगी।

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

पासवर्ड पहचान, वैधता और एन्क्रिप्शन वर्कफ़्लो के लिए, देखें [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया हो, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/androidjava/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) विकल्प लौटाता है जो नियंत्रित करता है कि Aspose.Slides छवियों, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालती है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित Java कोड बड़े प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने का प्रदर्शन करता है:

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

{{% alert color="info" title="नोट" %}}

[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक कि प्रस्तुति उदाहरण को डिस्पोज़ नहीं किया जाता। उस उदाहरण के जीवित रहने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न ओवरराइट करें, न हटाएँ।

Aspose.Slides इनपुट स्ट्रीम की सामग्री को लोड करते समय कॉपी कर सकता है। बड़े प्रस्तुतियों के लिए, फ़ाइल पाथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/androidjava/manage-blob/)।

{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनः निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी चित्र होते हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या भंडारण नियमों के अनुसार हल करना आवश्यक होता है।

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

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एंबेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं होती या वह उसे रखना नहीं चाहती। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, उपलब्ध है [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) के माध्यम से;
- एंबेडेड OLE डेटा, उपलब्ध है [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के माध्यम से;
- ActiveX नियंत्रण डेटा, उपलब्ध है [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) के माध्यम से।

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) को `true` पर सेट करें ताकि लोडिंग के दौरान इस बाइनरी डेटा को हटा दिया जाए। लोड की गई प्रस्तुति को सहेजें ताकि सफ़ाई किया हुआ परिणाम बना रहे।

यह विकल्प अनचाहे एंबेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह एक पूर्ण मैलवेयर‑डिटेक्शन या कंटेंट‑सैनीटाइज़ेशन सिस्टम नहीं है।

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

**मैं कैसे पता करूँ कि फ़ाइल भ्रष्ट है और उसे खोल नहीं सकता?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट एक्सेप्शन फेंकता है। इस विफलता को गलत‑पासवर्ड त्रुटि से अलग ढंग से संभालें ताकि एप्लिकेशन कारण को सही रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप आउटपुट को अधिक पूर्वानुमेय बनाने के लिए [configure font substitution](/slides/hi/androidjava/font-substitution/) या [provide custom fonts](/slides/hi/androidjava/custom-font/) कर सकते हैं।

**क्या प्रस्तुति को लोड करने से उसके एंबेडेड मीडिया भी लोड होते हैं?**

एंबेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थानों तक पहुँच नहीं पाई जा सकती तो वे अनुपलब्ध हो सकते हैं।