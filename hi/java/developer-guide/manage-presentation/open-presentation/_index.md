---
title: जावा में प्रस्तुतियों को खोलना
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/java/open-presentation/
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
- संरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Java
- Aspose.Slides
description: "जावा में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Java के साथ मेमोरी उपयोग को कम करें, यह जानें।"
---
## **परिचय**

[Aspose.Slides for Java](https://products.aspose.com/slides/hi/java/) फ़ाइलों और स्ट्रीम से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने वाला पासवर्ड दे सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एंबेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियों को खोलें**

एक मौजूदा प्रस्तुति को खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधनों को तुरंत मुक्त किया जा सके।

नीचे दिया गया जावा उदाहरण प्रस्तुतियों को खोलने और स्लाइडों की संख्या प्राप्त करने को दर्शाता है:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति को लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) में पास करें और यह विकल्प [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कंस्ट्रक्टर को प्रदान करें। यदि पासवर्ड अनुपलब्ध या गलत है तो लोडिंग विफल हो जाएगी।

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

पासवर्ड की जाँच, वैधता और एन्क्रिप्शन वर्कफ़्लो के बारे में जानने के लिए, देखें [Password-Protect Presentations](/slides/hi/java/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजी गई हो, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/java/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) विकल्प लौटाता है जो Aspose.Slides द्वारा छवियां, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को संभालने के तरीके को नियंत्रित करता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

नीचे दिया गया जावा कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने को दर्शाता है:

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
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न ओवरराइट करें, न ही डिलीट करें।

Aspose.Slides लोड करते समय इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/java/manage-blob/)।

{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को रीडायरेक्ट कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियां होती हैं जिनको एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल करना आवश्यक होता है।

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

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एंबेडेड बाइनरी डेटा हो सकता है जिसे एप्लिकेशन को आवश्यकता नहीं होती या वह उसे बनाए नहीं रखना चाहता। उदाहरणों में शामिल हैं:

- VBA प्रोजेक्ट्स, जो [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getVbaProject--) के माध्यम से उपलब्ध हैं;
- एंबेडेड OLE डेटा, जो [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के माध्यम से उपलब्ध है;
- ActiveX कंट्रोल डेटा, जो [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) के माध्यम से उपलब्ध है।

लोडिंग के दौरान इस बाइनरी डेटा को हटाने के लिए [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) को `true` सेट करें। शुद्ध परिणाम को बनाए रखने के लिए लोडेड प्रस्तुति को सहेजें।

यह विकल्प अनचाहे एंबेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूरी तरह से मैलवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइजेशन प्रणाली नहीं है।

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

**मैं कैसे पता लगा सकता हूँ कि फ़ाइल दूषित है और खोली नहीं जा सकती?**  
Aspose.Slides लोडिंग के दौरान एक पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग तरीके से हैंडल करें ताकि एप्लिकेशन कारण को सही रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होगा?**  
प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट बदलाव कर सकते हैं। आप [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर](/slides/hi/java/font-substitution/) कर सकते हैं या अधिक पूर्वानुमेय आउटपुट के लिए [कस्टम फ़ॉन्ट प्रदान](/slides/hi/java/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसकी एंबेडेड मीडिया भी लोड हो जाती है?**  
एंबेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुंच नहीं हो पाती तो उपलब्ध नहीं हो सकते।