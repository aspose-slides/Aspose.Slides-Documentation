---
title: JavaScript में प्रभावी मेमोरी उपयोग के लिए प्रस्तुति BLOBs प्रबंधित करें
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/manage-blob/
keywords:
- बड़ी वस्तु
- बड़ा आइटम
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी कम करें
- मेमोरी उपभोग
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में BLOB डेटा का प्रबंधन करके PowerPoint और OpenDocument फ़ाइल संचालन को सुगम बनाएं, जिससे प्रस्तुति को कुशलता से संभाला जा सके।"
---
## **अवलोकन**

Aspose.Slides बड़े बाइनरी डेटा को प्रस्तुतियों में BLOB-आधारित हैंडलिंग प्रदान करता है जिससे बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी खपत कम करने में मदद मिलती है।

यह लेख दिखाता है कि BLOB-आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़े मीडिया को कैसे जोड़ा जाए, प्रस्तुति से बड़े मीडिया को निर्यात किया जाए, और बड़ी प्रस्तुतियों को अधिक कुशलता से कैसे लोड किया जाए। यह यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहीत करने वाले फ़ोल्डर को कैसे बदला जाए।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी फ़ॉर्मेट में सहेजा जाता है।

Aspose.Slides for Node.js via Java आपको बड़े फ़ाइलों के साथ काम करते समय मेमोरी खपत कम करने के लिए ऑब्जेक्ट्स के लिए BLOB का उपयोग करने की अनुमति देता है।

{{% alert title="सूचना" color="info" %}}
स्ट्रीम्स के साथ इंटरैक्ट करते समय कुछ सीमाओं से बचने के लिए Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम के माध्यम से बड़ी प्रस्तुति को लोड करने से प्रस्तुति की सामग्री कॉपी होगी और लोडिंग धीमी हो जाएगी। इसलिए, जब आप बड़ी प्रस्तुति लोड करने का इरादा रखते हैं, तो हम दृढ़ता से अनुशंसा करते हैं कि आप प्रस्तुति फ़ाइल पथ का उपयोग करें, न कि उसकी स्ट्रीम का।
{{% /alert %}}

## **मेमोरी खपत कम करने के लिए BLOB का उपयोग करें**

### **BLOB के माध्यम से बड़ी फ़ाइल को प्रस्तुति में जोड़ें**

[Aspose.Slides](/slides/hi/nodejs-java/) for Node.js via Java आपको बड़ी फ़ाइलें (इस मामले में, बड़ी वीडियो फ़ाइल) को BLOB प्रक्रिया के माध्यम से जोड़ने की अनुमति देता है जिससे मेमोरी खपत कम होती है।

यह JavaScript दिखाता है कि BLOB प्रक्रिया के द्वारा बड़ी वीडियो फ़ाइल को प्रस्तुति में कैसे जोड़ा जाए:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// एक नई प्रस्तुति बनाता है जिसमें वीडियो जोड़ा जाएगा
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // आइए वीडियो को प्रस्तुति में जोड़ें - हमने KeepLocked व्यवहार चुना है क्योंकि हम
        // "veryLargeVideo.avi" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग
        // pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहता है
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **BLOB के माध्यम से प्रस्तुति से बड़ी फ़ाइल निर्यात करें**

Aspose.Slides for Node.js via Java आपको BLOB प्रक्रिया के द्वारा प्रस्तुतियों से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको प्रस्तुति से बड़ी मीडिया फ़ाइल निकालनी पड़ सकती है लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के द्वारा फ़ाइल निर्यात करने से मेमोरी खपत कम रहती है।

यह JavaScript कोड दर्शाता है कि वर्णित ऑपरेशन कैसे किया जाता है:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// स्रोत फ़ाइल को लॉक करता है और इसे मेमोरी में लोड नहीं करता
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Presentation का इंस्टेंस बनाता है, "hugePresentationWithAudiosAndVideos.pptx" फ़ाइल को लॉक करता है।
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // आइए प्रत्येक वीडियो को फ़ाइल में सहेजें। उच्च मेमोरी उपयोग रोकने के लिए हमें एक बफ़र की आवश्यकता है जो उपयोग किया जाएगा
    // प्रस्तुति के वीडियो स्ट्रीम से डेटा को नई बनाई गई वीडियो फ़ाइल के स्ट्रीम में स्थानांतरित करने के लिए।
    var buffer = new byte[8 * 1024];
    // वीडियोस के माध्यम से इटरेट करता है
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // प्रस्तुति वीडियो स्ट्रीम को खोलता है। कृपया ध्यान दें कि हमने जानबूझकर प्रॉपर्टीज़ तक पहुंचने से बचा है
        // जैसे video.BinaryData - क्योंकि यह प्रॉपर्टी पूर्ण वीडियो वाला बाइट ऐरे लौटाती है, जो फिर
        // बाइट्स को मेमोरी में लोड होने का कारण बनता है। हम video.GetStream का उपयोग करते हैं, जो स्ट्रीम लौटाता है - और यह नहीं
        // हमें पूरे वीडियो को मेमोरी में लोड करने की आवश्यकता नहीं होती।
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // वीडियो या प्रस्तुति के आकार की परवाह किए बिना मेमोरी उपभोग कम रहेगा।
    }
    // यदि आवश्यक हो, तो आप ऑडियो फ़ाइलों के लिए भी वही चरण लागू कर सकते हैं।
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **प्रस्तुति में छवि को BLOB के रूप में जोड़ें**

[**ImageCollection**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) और [**ImageCollection**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ImageCollection) कक्षा की विधियों का उपयोग करके आप बड़ी छवि को स्ट्रीम के रूप में जोड़ सकते हैं जिससे उसे BLOB के रूप में माना जाए।

यह JavaScript कोड दिखाता है कि BBlob प्रक्रिया के द्वारा बड़ी छवि को कैसे जोड़ा जाए:

```javascript
var pathToLargeImage = "large_image.jpg";
// एक नई प्रस्तुति बनाता है जिसमें छवि जोड़ी जाएगी।
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // आइए छवि को प्रस्तुति में जोड़ें - हम KeepLocked व्यवहार चुनते हैं क्योंकि हम
        // "largeImage.png" फ़ाइल तक पहुँचने का इरादा नहीं रखते।
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // प्रस्तुति को सहेजता है। जबकि बड़ी प्रस्तुति आउटपुट होती है, मेमोरी उपभोग
        // pres ऑब्जेक्ट के जीवनचक्र के दौरान कम रहता है
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, बड़ी प्रस्तुति को लोड करने के लिए कंप्यूटर को बहुत अधिक अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की पूरी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड की गई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB की वीडियो फ़ाइल शामिल है। प्रस्तुति को लोड करने की मानक विधि इस JavaScript कोड में वर्णित है:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी उपभोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB प्रक्रिया के माध्यम से आप बहुत कम मेमोरी का उपयोग करके बड़ी प्रस्तुति लोड कर सकते हैं। यह JavaScript कोड उस कार्यान्वयन को दर्शाता है जहाँ BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) लोड की जाती है:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **अस्थायी फ़ाइलों के फ़ोल्डर को बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, तो आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइल फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अलग फ़ोल्डर में रखी जाएँ, तो `setTempFilesRootPath` का उपयोग करके स्टोरेज सेटिंग बदल सकते हैं:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="सूचना" color="info" %}}
जब आप `setTempFilesRootPath` का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहीत करने के लिए फ़ोल्डर नहीं बनाता। आपको फ़ोल्डर मैन्युअली बनाना होगा।
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट्स को डिस्पोज़ करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को सही ढंग से डिस्पोज़ किया गया है ताकि वह मेमोरी रिलीज़ हो सके। प्रस्तुति का उपयोग समाप्त होने के बाद `dispose()` कॉल करके अनमैनेज्ड रिसोर्सेज़ को मुक्त करें।

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**

छवियां, ऑडियो और वीडियो जैसी बड़ी बाइनरी ऑब्जेक्ट्स BLOB के रूप में मानी जाती हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सहेजते समय BLOB हैंडलिंग में शामिल होती है। इन ऑब्जेक्ट्स को BLOB नीतियों द्वारा नियंत्रित किया जाता है जो मेमोरी उपयोग और आवश्यकतानुसार अस्थायी फ़ाइलों में स्पिल को प्रबंधित करती हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियम कहाँ कॉन्फ़िगर करूँ?**

[LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) के साथ [BlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/blobmanagementoptions/) का उपयोग करें। यहाँ आप मेमोरी में BLOB के अधिकतम बाइट्स, अस्थायी फ़ाइलों की अनुमति/निषेध, अस्थायी फ़ाइलों की रूट पाथ, और स्रोत लॉकिंग व्यवहार सेट कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करूँ?**

हां। BLOB को मेमोरी में रखना गति को अधिकतम करता है लेकिन RAM खपत बढ़ाता है; मेमोरी सीमा को कम करने से अधिक काम अस्थायी फ़ाइलों में शिफ्ट हो जाता है, जिससे RAM कम हो जाती है लेकिन अतिरिक्त I/O की लागत आती है। अपने वर्कलोड और पर्यावरण के लिए सही संतुलन पाने हेतु [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) मेथड का उपयोग करें।

**क्या अत्यधिक बड़ी प्रस्तुतियों (जैसे गीगाबाइट्स) को खोलते समय BLOB विकल्प मदद करते हैं?**

हां। [BlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/blobmanagementoptions/) इन परिदृश्यों के लिए डिजाइन किए गए हैं: अस्थायी फ़ाइलें सक्षम करके और स्रोत लॉकिंग का उपयोग करके पीक RAM उपयोग को काफी घटाया जा सकता है और बहुत बड़ी डेक्स के प्रोसेसिंग को स्थिर किया जा सकता है।

**क्या मैं डिस्क फ़ाइलों की बजाय स्ट्रीम्स से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**

हां। वही नियम स्ट्रीम्स पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को अपना सकता है और लॉक कर सकता है (चयनित लॉकिंग मोड के आधार पर), और अस्थायी फ़ाइलें तब उपयोग की जाएँगी जब अनुमति होगी, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमानित रहता है।