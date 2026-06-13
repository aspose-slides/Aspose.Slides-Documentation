---
title: जावास्क्रिप्ट में प्रस्तुतियाँ खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को Aspose.Slides for Node.js द्वारा Java के माध्यम से आसानी से खोलें—तेज़, विश्वसनीय, पूर्ण फीचर वाला."
---
## **परिचय**

शुरू से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी सुविधा देता है। प्रस्तुति लोड करने के बाद, आप उसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड की सामग्री संपादित कर सकते हैं, नई स्लाइडें जोड़ सकते हैं, मौजूदा स्लाइडें हटा सकते हैं, और बहुत कुछ कर सकते हैं।

## **प्रस्तुतियों को खोलना**

किसी मौजूदा प्रस्तुति को खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और फ़ाइल पथ को उसके कंस्ट्रक्टर में पास करें।

निम्नलिखित JavaScript उदाहरण दर्शाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती कैसे प्राप्त करें:

```js
// Presentation क्लास का उदाहरण बनाएं और उसके कंस्ट्रक्टर में फ़ाइल पथ पास करें।
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // प्रस्तुति में कुल स्लाइडों की संख्या प्रिंट करें।
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-सुरक्षित प्रस्तुतियों को खोलना**

जब आपको पासवर्ड-सुरक्षित प्रस्तुति खोलनी हो, तो पासवर्ड को [setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) मेथड के माध्यम से [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) क्लास में पास करें ताकि वह डिक्रिप्ट हो सके और लोड हो सके। निम्नलिखित JavaScript कोड इस ऑपरेशन को दर्शाता है:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति पर संचालन करें।
} finally {
    presentation.dispose();
}
```

## **बड़ी प्रस्तुतियों को खोलना**

Aspose.Slides विकल्प प्रदान करता है—विशेष रूप से [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) क्लास में [getBlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) मेथड—ताकि आप बड़ी प्रस्तुतियों को लोड कर सकें।

निम्नलिखित JavaScript कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) लोड करने को दर्शाता है:

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// KeepLocked व्यवहार चुनें—प्रेजेंटेशन फ़ाइल जीवनकाल के दौरान लॉक्ड रहेगी
// प्रेजेंटेशन इंस्टेंस के लिए, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की आवश्यकता नहीं है।
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // बड़ी प्रस्तुति लोड हो गई है और इसका उपयोग किया जा सकता है, जबकि मेमोरी उपयोग कम रहता है।
    
    // प्रस्तुति में बदलाव करें।
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // प्रस्तुति को दूसरी फ़ाइल में सहेजें। इस ऑपरेशन के दौरान मेमोरी उपयोग कम रहता है।
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // यह न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक्ड रहेगी जब तक प्रेजेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं हो जाता।
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// इसे यहां करना ठीक है। स्रोत फ़ाइल अब प्रेजेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं है।
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
स्ट्रीम्स के साथ काम करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम से बड़ी प्रस्तुति लोड करने पर प्रस्तुति की कॉपी बनती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से सलाह देते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हों जिसमें बड़े ऑब्जेक्ट (वीडियो, ऑडियो, उच्च‑रिज़ॉल्यूशन छवियां आदि) हों, तो आप मेमोरी उपभोग कम करने के लिए [BLOB management](/slides/hi/nodejs-java/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाहरी संसाधनों को नियंत्रित करना**

Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों का प्रबंधन करने की अनुमति देता है। निम्नलित JavaScript कोड दर्शाता है कि `IResourceLoadingCallback` इंटरफ़ेस का उपयोग कैसे करें:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // एक प्रतिस्थापन चित्र लोड करें।
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // एक प्रतिस्थापन URL सेट करें।
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // अन्य सभी चित्रों को छोड़ें।
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करना**

एक PowerPoint प्रस्तुति में निम्न प्रकार के एम्बेडेड बाइनरी ऑब्जेक्ट हो सकते हैं:

- VBA प्रोजेक्ट (जिसे [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getVbaProject) के माध्यम से पहुँच सकते हैं);
- OLE ऑब्जेक्ट एम्बेडेड डेटा (जिसे [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) के माध्यम से पहुँच सकते हैं);
- ActiveX कंट्रोल बाइनरी डेटा (जिसे [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/control/#getActiveXControlBinary) के माध्यम से पहुँच सकते हैं)।

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) मेथड का उपयोग करके, आप कोई भी एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुति लोड कर सकते हैं।

यह मेथड संभावित दुर्भावनापूर्ण बाइनरी सामग्री को हटाने में उपयोगी है। निम्नलिखित JavaScript कोड दर्शाता है कि एम्बेडेड बाइनरी सामग्री के बिना प्रस्तुति को कैसे लोड किया जाए:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // प्रस्तुति पर संचालन करें।
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता लगा सकता हूँ कि फ़ाइल भ्रष्ट है और खोली नहीं जा सकती?**

लोड करने के दौरान आपको पार्सिंग/फ़ॉर्मेट वैलिडेशन अपवाद मिलेगा। ऐसे त्रुटियों में अक्सर अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड का उल्लेख होता है।

**खोलते समय आवश्यक फ़ॉन्ट्स अनुपलब्ध होने पर क्या होता है?**

फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/nodejs-java/convert-presentation/) फ़ॉन्ट को बदल सकता है। रनटाइम environment में [Configure font substitutions](/slides/hi/nodejs-java/font-substitution/) या [add the required fonts](/slides/hi/nodejs-java/custom-font/) जोड़ें।

**खोलते समय एम्बेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति संसाधन के रूप में उपलब्ध हो जाते हैं। यदि मीडिया को बाहरी पथों के माध्यम से संदर्भित किया गया है, तो सुनिश्चित करें कि वे पथ आपके वातावरण में सुलभ हों; अन्यथा [rendering/export](/slides/hi/nodejs-java/convert-presentation/) मीडिया को छोड़ सकता है।