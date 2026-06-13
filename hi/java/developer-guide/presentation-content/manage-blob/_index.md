---
title: "जावा में प्रस्तुति BLOBs को कुशल मेमोरी उपयोग के लिए प्रबंधित करें"
linktitle: "BLOB प्रबंधन"
type: docs
weight: 10
url: /hi/java/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ी वस्तु
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी कम करें
- मेमोरी खपत
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में BLOB डेटा को प्रबंधित करके PowerPoint और OpenDocument फ़ाइल संचालन को कुशल प्रस्तुति हैंडलिंग के लिए आसान बनाएं।"
---
## **परिचय**

Aspose.Slides बड़ी बाइनरी डेटा को प्रस्तुतियों में संभालने के लिए BLOB‑आधारित हैंडलिंग प्रदान करता है, जिससे बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी खपत कम करने में मदद मिलती है।

यह लेख बताता है कि BLOB‑आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़े मीडिया को कैसे जोड़ें, प्रस्तुति से बड़े मीडिया को निर्यात करें, और बड़े प्रस्तुतियों को अधिक कुशलता से कैसे लोड करें। यह यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलें कैसे उपयोग की जा सकती हैं और उन्हें संग्रहित करने के लिए फ़ोल्डर को कैसे बदलें।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़ या मीडिया) होता है जिसे बाइनरी फ़ॉर्मेट में सहेजा जाता है।

Aspose.Slides for Java आपको बड़े फ़ाइलों के साथ काम करते समय मेमोरी खपत को कम करने के लिए ऑब्जेक्ट्स के लिए BLOB का उपयोग करने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
स्ट्रीम के साथ इंटरैक्ट करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides स्ट्रीम की सामग्री की प्रतिलिपि बना सकता है। स्ट्रीम के माध्यम से बड़े प्रस्तुति को लोड करने से प्रस्तुति की सामग्री की कॉपी बनती है और लोडिंग धीमी हो जाती है। इसलिए, जब आप बड़े प्रस्तुति को लोड करने का इरादा रखते हैं, तो हम दृढ़ता से सलाह देते हैं कि आप प्रस्तुति फ़ाइल पथ का उपयोग करें, न कि उसकी स्ट्रीम का।
{{% /alert %}}

## **मेमोरी खपत कम करने के लिए BLOB का उपयोग**

### **BLOB के माध्यम से प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/java/) for Java आपको BLOB शामिल प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस उदाहरण में एक बड़ी वीडियो फ़ाइल) जोड़ने की अनुमति देता है ताकि मेमोरी खपत कम हो सके।

यह Java कोड आपको दिखाता है कि BLOB प्रक्रिया के द्वारा प्रस्तुति में बड़ी वीडियो फ़ाइल कैसे जोड़ें:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// एक नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // आइए वीडियो को प्रस्तुति में जोड़ते हैं - हमने KeepLocked व्यवहार चुना क्योंकि हम
        //"veryLargeVideo.avi" फ़ाइल को एक्सेस करने का इरादा नहीं रखते।
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // प्रस्तुति को सहेजता है। बड़े प्रस्तुति को आउटपुट करते समय, मेमोरी की खपत
        // प्रेज़ ऑब्जेक्ट के लाइफसाइकिल के दौरान कम रहती है 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **प्रस्तुति से BLOB के माध्यम से बड़ी फ़ाइल निर्यात करें**
Aspose.Slides for Java आपको BLOB शामिल प्रक्रिया के द्वारा प्रस्तुतियों से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) निर्यात करने की अनुमति देता है। उदाहरण के लिए, आप प्रस्तुति से बड़ी मीडिया फ़ाइल निकालना चाहते हैं लेकिन फ़ाइल को अपने कंप्यूटर की मेमोरी में लोड नहीं करना चाहते। BLOB प्रक्रिया के द्वारा फ़ाइल निर्यात करने से मेमोरी खपत कम रहती है।

यह Java कोड उपर्युक्त कार्रवाई को प्रदर्शित करता है:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// स्रोत फ़ाइल को लॉक करता है और उसे मेमोरी में लोड नहीं करता
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// प्रस्तुति का इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // प्रत्येक वीडियो को फ़ाइल में सहेजते हैं। उच्च मेमोरी उपयोग को रोकने के लिए, हमें एक बफ़र चाहिए
    // जो प्रस्तुति के वीडियो स्ट्रीम से नया बनाया गया वीडियो फ़ाइल के स्ट्रीम में डेटा स्थानांतरित करे।
    byte[] buffer = new byte[8 * 1024];

    // वीडियो के माध्यम से इटरिट करता है
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // प्रस्तुति वीडियो स्ट्रीम खोलता है। कृपया ध्यान दें कि हमने जानबूझकर गुणों तक पहुँचने से बचा
        // जैसे video.BinaryData - क्योंकि यह विशेषता पूर्ण वीडियो वाला बाइट एरे लौटाती है, जो तब
        // मेमोरी में बाइट लोड करता है। हम video.GetStream का उपयोग करते हैं, जो Stream लौटाता है - और
        //  पूरे वीडियो को मेमोरी में लोड करने की आवश्यकता नहीं होती।
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // मेमोरी खपत वीडियो या प्रस्तुति के आकार की परवाह किए बिना कम रहेगी।
    }
    // यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी वही चरण लागू कर सकते हैं।
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **प्रस्तुति में एक छवि को BLOB के रूप में जोड़ें**
[**IImageCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImageCollection) इंटरफ़ेस और [**ImageCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ImageCollection) क्लास की विधियों का उपयोग करके, आप बड़ी छवियों को एक स्ट्रीम के रूप में जोड़ सकते हैं ताकि उन्हें BLOB माना जाए।

यह Java कोड आपको दिखाता है कि BLOB प्रक्रिया के द्वारा बड़ी छवि कैसे जोड़ें:

```java
String pathToLargeImage = "large_image.jpg";

// नई प्रस्तुति बनाता है जिसमें चित्र जोड़ा जाएगा।
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// आइए चित्र को प्रस्तुति में जोड़ें - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
		// फ़ाइल "largeImage.png" तक पहुंचने का इरादा नहीं रखते।
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// प्रस्तुति को सहेजता है। बड़े प्रस्तुति को आउटपुट करते समय, मेमोरी की खपत
		// pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहती है।
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **मेमोरी और बड़ी प्रस्तुतियां**

आमतौर पर, बड़ी प्रस्तुति को लोड करने के लिए कंप्यूटर को बहुत अधिक अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की पूरी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB की वीडियो फ़ाइल है। इस प्रस्तुति को लोड करने की मानक विधि नीचे दिए गए Java कोड में वर्णित है:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

लेकिन इस विधि से लगभग 1.6 GB अस्थायी मेमोरी प्रयोग होती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB शामिल प्रक्रिया के द्वारा आप बड़ी प्रस्तुति को कम मेमोरी के साथ लोड कर सकते हैं। यह Java कोड दर्शाता है कि BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) को कैसे लोड किया जाता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **अस्थायी फ़ाइलों के फ़ोल्डर को बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, तो आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइल फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप अस्थायी फ़ाइलों को किसी अलग फ़ोल्डर में रखना चाहते हैं, तो आप `TempFilesRootPath` का उपयोग करके संग्रहण सेटिंग बदल सकते हैं:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
जब आप `TempFilesRootPath` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहित करने के लिए कोई फ़ोल्डर नहीं बनाता। आपको स्वयं फ़ोल्डर बनाना होगा।
{{% /alert %}}

### **प्रेजेंटेशन ऑब्जेक्ट्स को डिस्पोज़ करके मेमोरी मुक्त करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को सही तरीके से डिस्पोज़ किया गया हो ताकि वह मेमोरी मुक्त हो सके। प्रस्तुति का उपयोग समाप्त होने के बाद `dispose()` कॉल करके अनमैनेज्ड रिसोर्सेज़ को मुक्त करें।

```java
Presentation presentation = new Presentation("large.pptx");

// ...प्रस्तुति को प्रोसेस करें...
presentation.save("large.pdf", SaveFormat.Pdf);

// स्पष्ट रूप से संसाधनों को मुक्त करें।
presentation.dispose();
```

## **FAQ**

**एक Aspose.Slides प्रस्तुति में कौन-सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**

छवियों, ऑडियो और वीडियो जैसी बड़ी बाइनरी ऑब्जेक्ट्स BLOB माने जाते हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव होते समय BLOB हैंडलिंग में शामिल होती है। ये ऑब्जेक्ट्स BLOB नीतियों द्वारा नियंत्रित होते हैं जो मेमोरी उपयोग और आवश्यकतानुसार अस्थायी फ़ाइलों में स्पिल को प्रबंधित करती हैं।

**प्रेजेंटेशन लोडिंग के दौरान BLOB हैंडलिंग नियमों को कहाँ कॉन्फ़िगर करें?**

[LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहां आप BLOB के लिए इन‑मेमोरी सीमा सेट कर सकते हैं, अस्थायी फ़ाइलों की अनुमति दे या निरुत्साहित कर सकते हैं, अस्थायी फ़ाइलों के रूट पाथ को चुन सकते हैं, और स्रोत लॉकिंग व्यवहार निर्धारित कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**

हां। BLOB को मेमोरी में रखने से गति अधिक होती है लेकिन RAM की खपत बढ़ती है; मेमोरी सीमा कम करने से अधिक काम अस्थायी फ़ाइलों पर जाता है, जिससे RAM कम होती है लेकिन अतिरिक्त I/O की लागत आती है। सही संतुलन पाने के लिए [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) मेथड का उपयोग करें।

**क्या BLOB विकल्प अत्यंत बड़ी प्रस्तुतियों (जैसे गीगाबाइट स्तर) खोलते समय मदद करते हैं?**

हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/blobmanagementoptions/) इन परिदृश्यों के लिए डिज़ाइन किए गए हैं: अस्थायी फ़ाइलें सक्षम करके और स्रोत लॉकिंग का उपयोग करके पीक RAM उपयोग को काफी हद तक कम किया जा सकता है और बहुत बड़ी डेक की प्रोसेसिंग स्थिर की जा सकती है।

**क्या मैं डिस्क फ़ाइलों के बजाय स्ट्रीम से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**

हां। वही नियम स्ट्रीम पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को अपने पास रख सकता है और उसे लॉक कर सकता है (चुने गए लॉकिंग मोड पर निर्भर), और अस्थायी फ़ाइलें तब उपयोग की जाती हैं जब अनुमति दी गई हो, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमानित रहता है।