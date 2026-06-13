---
title: Android पर प्रस्तुति BLOBs को कुशल मेमोरी उपयोग के लिए प्रबंधित करें
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides में BLOB डेटा को Java के माध्यम से प्रबंधित करके PowerPoint और OpenDocument फ़ाइल कार्यों को सरल बनाते हुए कुशल प्रस्तुति हैंडलिंग प्राप्त करें."
---
## **अवलोकन**

Aspose.Slides बड़े बाइनरी डेटा को प्रस्तुतियों में BLOB‑आधारित हैंडलिंग प्रदान करता है ताकि बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी ख़पत कम हो सके।

यह लेख दर्शाता है कि कैसे BLOB‑आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़ी मीडिया जोड़ी जा सकती है, प्रस्तुति से बड़ी मीडिया निर्यात की जा सकती है, और बड़ी प्रस्तुतियों को अधिक कुशलता से लोड किया जा सकता है। यह यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहीत करने वाले फ़ोल्डर को कैसे बदला जा सकता है।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी फ़ॉर्मैट में सहेजा जाता है।

Aspose.Slides for Android via Java आपको BLOB‑s का उपयोग करके ऑब्जेक्ट्स को इस तरह हैंडल करने की अनुमति देता है जिससे बड़ी फ़ाइलों के साथ काम करते समय मेमोरी ख़पत कम हो जाती है।

{{% alert title="Info" color="info" %}}
स्ट्रीम्स के साथ इंटरैक्ट करते समय कुछ सीमाओं से बचने के लिए Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम के माध्यम से बड़ी प्रस्तुति लोड करने पर प्रस्तुति की सामग्री कॉपी हो जाएगी और लोडिंग धीमी हो जाएगी। इसलिए, जब आप बड़ी प्रस्तुति लोड करना चाहते हैं, तो हम दृढ़ता से सलाह देते हैं कि आप प्रस्तुति फ़ाइल पाथ का उपयोग करें, न कि उसकी स्ट्रीम।
{{% /alert %}}

## **मेमोरी खपत कम करने के लिए BLOB का उपयोग**

### **BLOB के माध्यम से प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/androidjava/) for Java आपको BLOB‑s शामिल करने वाली प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस मामले में, बड़ी वीडियो फ़ाइल) जोड़ने की अनुमति देता है जिससे मेमोरी ख़पत कम हो जाती है।

यह Java उदाहरण दिखाता है कि कैसे एक बड़ी वीडियो फ़ाइल को BLOB प्रक्रिया के माध्यम से प्रस्तुति में जोड़ा जाए:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // आइए वीडियो को प्रस्तुति में जोड़ें - हमने KeepLocked व्यवहार चुना क्योंकि हम
        // "veryLargeVideo.avi" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी खपत
        // pres ऑब्जेक्ट के जीवनचक्र में कम रहती है 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **BLOB के माध्यम से प्रस्तुति से बड़ी फ़ाइल निर्यात करें**

Aspose.Slides for Android via Java आपको BLOB‑s शामिल करने वाली प्रक्रिया के माध्यम से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) प्रस्तुतियों से निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको प्रस्तुति से बड़ी मीडिया फ़ाइल निकालनी हो सकती है लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करने से मेमोरी ख़पत कम रहती है।

यह Java कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// सोर्स फ़ाइल को लॉक करता है और इसे मेमोरी में लोड नहीं करता
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation का इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // प्रत्येक वीडियो को एक फ़ाइल में सहेजें। उच्च मेमोरी उपयोग को रोकने के लिये हमें एक बफ़र चाहिए जो उपयोग किया जाएगा
    // प्रस्तुति के वीडियो स्ट्रीम से डेटा को नई बनाई गई वीडियो फ़ाइल के स्ट्रीम में ट्रांसफ़र करने के लिए।
    byte[] buffer = new byte[8 * 1024];

    // वीडियो को इटरेट करता है
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // प्रस्तुति वीडियो स्ट्रीम को खोलता है। कृपया ध्यान दें कि हमने जानबूझकर प्रॉपर्टीज़ तक पहुँचने से बचा है
        // जैसे video.BinaryData - क्योंकि यह प्रॉपर्टी पूरी वीडियो वाले बाइट एरे को रिटर्न करती है, जो तब
        // बाइट्स को मेमोरी में लोड कराता है। हम video.GetStream का उपयोग करते हैं, जो Stream रिटर्न करेगा - और मेमोरी में पूरी वीडियो लोड नहीं करता
        //  हमें पूरी वीडियो मेमोरी में लोड करने की आवश्यकता नहीं पड़ती।
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
        // मेमोरी खपत वीडियो या प्रस्तुति के आकार के बावजूद कम रहेगी।
    }
    // यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी समान कदम लागू कर सकते हैं। 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **प्रस्तुति में छवि को BLOB के रूप में जोड़ें**

[**IImageCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImageCollection) इंटरफ़ेस और [**ImageCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ImageCollection) क्लास की विधियों का उपयोग करके आप बड़ी छवि को स्ट्रीम के रूप में जोड़ सकते हैं ताकि उसे BLOB के रूप में ट्रीट किया जा सके।

यह Java कोड दिखाता है कि कैसे बड़ी छवि को BLOB प्रक्रिया के माध्यम से जोड़ा जाए:

```java
String pathToLargeImage = "large_image.jpg";

// नई प्रस्तुति बनाता है जिसमें चित्र जोड़ा जाएगा.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// आइए चित्र को प्रस्तुति में जोड़ें - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
		// "largeImage.png" फ़ाइल तक पहुँचने का इरादा नहीं रखते.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी खपत
		// pres ऑब्जेक्ट के जीवनचक्र में कम रहती है.
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, बड़ी प्रस्तुति लोड करने के लिए कंप्यूटर को बहुत सारी अस्थायी मेमोरी की जरूरत होती है। प्रस्तुति की सभी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड की गई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB का वीडियो फ़ाइल शामिल है। प्रस्तुति को लोड करने की मानक विधि इस Java कोड में वर्णित है:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी का उपयोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB शामिल करने वाली प्रक्रिया के माध्यम से आप कम मेमोरी का उपयोग करते हुए बड़ी प्रस्तुति को लोड कर सकते हैं। यह Java कोड दर्शाता है कि कैसे BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) लोड की जाती है:

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

जब BLOB प्रक्रिया का उपयोग किया जाता है, तो आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइलों के फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अलग फ़ोल्डर में रखी जाएँ, तो आप `TempFilesRootPath` का उपयोग करके संग्रहण सेटिंग्स बदल सकते हैं:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
जब आप `TempFilesRootPath` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहीत करने के लिए फ़ोल्डर नहीं बनाता। आपको फ़ोल्डर मैन्युअली बनाना होगा।
{{% /alert %}}

### **प्रस्तुति ऑब्जेक्ट्स को डिस्पोज़ करके मेमोरी मुक्त करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को ठीक से डिस्पोज़ किया गया है ताकि वह मेमोरी रिलीज़ हो सके। प्रस्तुति के उपयोग के बाद `dispose()` कॉल करके अनमैनेज्ड संसाधनों को मुक्त करें।

```java
Presentation presentation = new Presentation("large.pptx");

// ...प्रस्तुति को प्रोसेस करें...
presentation.save("large.pdf", SaveFormat.Pdf);

// स्पष्ट रूप से संसाधनों को मुक्त करें.
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में ट्रीट होता है और BLOB विकल्पों द्वारा नियंत्रित किया जाता है?**

छवियां, ऑडियो, वीडियो जैसी बड़ी बाइनरी ऑब्जेक्ट्स BLOB के रूप में ट्रीट होते हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करते समय BLOB हैंडलिंग में शामिल होती है। ये ऑब्जेक्ट्स BLOB नीतियों द्वारा नियंत्रित होते हैं जिससे आप मेमोरी उपयोग को प्रबंधित कर सकते हैं और आवश्यकता पड़ने पर अस्थायी फ़ाइलों में स्पिल कर सकते हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियम कहाँ कॉन्फ़िगर करें?**

[LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) के साथ [BlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/blobmanagementoptions/) का उपयोग करें। यहाँ आप BLOB के लिए इन‑मेरी मेमोरी सीमा सेट करते हैं, अस्थायी फ़ाइलों को अनुमति या प्रतिबंधित करते हैं, अस्थायी फ़ाइलों के रूट पाथ को चुनते हैं, और सोर्स लॉकिंग व्यवहार निर्धारित करते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**

हाँ। BLOB को मेमोरी में रखने से गति अधिकतम होती है लेकिन RAM उपयोग बढ़ता है; मेमोरी सीमा घटाने से अधिक काम अस्थायी फ़ाइलों को सौंपा जाता है, जिससे RAM कम होती है लेकिन अतिरिक्त I/O लागत आती है। अपने वर्कलोड और पर्यावरण के अनुसार सही संतुलन पाने के लिए [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) मेथड का उपयोग करें।

**क्या अत्यधिक बड़ी प्रस्तुतियों (जैसे गीगाबाइट आकार) खोलते समय BLOB विकल्प मदद करते हैं?**

हाँ। [BlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/blobmanagementoptions/) ऐसे परिदृश्यों के लिए तैयार किए गए हैं: अस्थायी फ़ाइलें सक्षम करना और सोर्स लॉकिंग का उपयोग करना पीक RAM उपयोग को काफी घटा सकता है और बहुत बड़ी डेक्स की प्रोसेसिंग को स्थिर बना सकता है।

**क्या स्ट्रिम्स से लोड करते समय BLOB नीतियों का उपयोग किया जा सकता है, न कि डिस्क फ़ाइलों से?**

हाँ। वही नियम स्ट्रिम्स पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रिम को स्वामित्व और लॉक कर सकता है (चयनित लॉकिंग मोड पर निर्भर), और जब अनुमति हो तो अस्थायी फ़ाइलें उपयोग की जाती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वनिर्धारित रहता है।