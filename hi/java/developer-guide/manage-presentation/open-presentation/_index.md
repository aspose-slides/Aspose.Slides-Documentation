---
title: Java में प्रस्तुतियों को खोलें
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
description: "Java में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Java के साथ मेमोरी उपयोग कम करें, यह सीखें।"
---
## **परिचय**

[Aspose.Slides for Java](https://products.aspose.com/slides/hi/java/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने पर, आप इसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित स्वरूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) वर्ग के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने वाला पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियों को खोलें**

फ़ाइल या स्ट्रीम लोड करने के बाद, आप [अपने मूल प्रस्तुति स्वरूप का निर्धारण करें](/slides/hi/java/detect-presentation-source-format/) करके चुन सकते हैं कि आपका एप्लिकेशन इसे कैसे प्रोसेस करे।

किसी मौजूदा प्रस्तुति को खोलने के लिए, उसकी फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कंस्ट्रक्टर को पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्नलिखित Java उदाहरण दिखाता है कि प्रस्तुति कैसे खोलें और उसकी स्लाइड संख्या कैसे प्राप्त करें:

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

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कंस्ट्रक्टर को प्रदान करें। जब पासवर्ड अनुपस्थित या गलत होता है तो लोडिंग विफल हो जाती है।

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

पासवर्ड का पता लगाने, सत्यापन और एन्क्रिप्शन वर्कफ़्लो के लिए देखें [पासवर्ड-संरक्षित प्रस्तुतियां](/slides/hi/java/password-protected-presentation/)। यदि एक एन्क्रिप्टेड प्रस्तुति जानबूझ कर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजी गई है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [प्रेजेंटेशन गुणों का प्रबंधन](/slides/hi/java/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) उन विकल्पों को लौटाता है जो नियंत्रित करते हैं कि Aspose.Slides छवियों, ऑडियो और वीडियो जैसे बड़े बाइनरी ऑब्जेक्ट्स को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित Java कोड एक बड़ी प्रस्तुति लोड करने का प्रदर्शन करता है (उदाहरण के लिए, 2 GB):

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
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को न हटाएँ, न बदलें, न ओवरराइट करें।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी-प्रबंधन विकल्पों के लिए देखें [BLOBs का प्रबंधन](/slides/hi/java/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियां होती हैं जिन्हें एप्लिकेशन-विशिष्ट सुरक्षा या संग्रह नियमों के अनुसार हल किया जाना चाहिए।

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

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं है या वह इसे रखना नहीं चाहता। उदाहरण में शामिल हैं:

- VBA प्रोजेक्ट्स, जो [IPresentation.getVbaProject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getVbaProject--) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) के माध्यम से उपलब्ध है;
- ActiveX नियंत्रण डेटा, जो [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) के माध्यम से उपलब्ध है।

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) को `true` पर सेट करने से लोडिंग के दौरान यह बाइनरी डेटा हटा दिया जाता है। सफ़ाई किया हुआ परिणाम सुरक्षित रखने के लिए लोडेड प्रस्तुति को सहेजें।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर-डिटेक्शन या कंटेंट-सैनिटाइज़ेशन प्रणाली नहीं है।

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

## **पूछे जाने वाले प्रश्न**

**मैं कैसे पहचान सकता हूँ कि फाइल दूषित है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत‑पासवर्ड त्रुटि से अलग ढंग से संभालें ताकि एप्लिकेशन कारण को सही ढंग से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स लापता हैं तो क्या होगा?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप आउटपुट को अधिक पूर्वानुमानित बनाने के लिए [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर करें](/slides/hi/java/font-substitution/) या [कस्टम फ़ॉन्ट प्रदान करें](/slides/hi/java/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसके एम्बेडेड मीडिया भी लोड हो जाते हैं?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध होते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुंच नहीं हो पाती तो वे अनुपलब्ध हो सकते हैं।