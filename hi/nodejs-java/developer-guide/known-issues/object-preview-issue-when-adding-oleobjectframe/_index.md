---
title: OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एम्बेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट प्रीव्यू
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में OleObjectFrame जोड़ते समय EMBEDDED OLE OBJECT क्यों दिखाई देता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे ठीक करें, यह सीखें।"
---
## **परिचय**

Aspose.Slides for Java का उपयोग करते हुए, जब आप एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश दिखाया जाता है। यह संदेश जानबूझकर दिखाया गया है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [Manage OLE](/slides/hi/nodejs-java/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू छवि को अद्यतन करने की आवश्यकता है। 

उदाहरण के लिए, यदि आप एक Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए, "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आप इस छवि को स्लाइड पर देखेंगे:

![OLE object message](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल‑क्लिक करना होगा, या आप उस पर राइट‑क्लिक करके **Object > Edit** विकल्प के माध्यम से जा सकते हैं।

![OLE object > Edit](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट खोलता है।

![OLE object data](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश रहता है। जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल जाता है।

![OLE object preview](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को इस तरह सेव करना चाहेंगे कि OLE ऑब्जेक्ट की छवि सही ढंग से अपडेट हो सके। इस प्रकार, प्रस्तुति को सेव करने के बाद, जब आप इसे फिर से खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को एक छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर उसे सेव करके "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप इस संदेश को अपनी इच्छित प्रीव्यू छवि से बदल सकते हैं। ये कोड पंक्तियाँ इस प्रक्रिया को दर्शाती हैं:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // प्रस्तुति संसाधनों में एक चित्र जोड़ें।
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // OLE ऑब्जेक्ट प्रीव्यू के लिए शीर्षक और चित्र सेट करें।
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

`OleObjectFrame` वाले स्लाइड में फिर यह परिवर्तन होता है:

![New OLE object image](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए एक ऐड‑ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड‑ऑन भी बना सकते हैं जो प्रस्तुति खोलते समय सभी OLE ऑब्जेक्ट्स को अपडेट कर देता है।