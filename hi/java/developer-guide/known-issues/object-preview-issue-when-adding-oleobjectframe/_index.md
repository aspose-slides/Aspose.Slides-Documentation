---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट पूर्वावलोकन समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- पूर्वावलोकन समस्या
- एम्बेडेड ऑब्जेक्ट
- एम्बेडेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट पूर्वावलोकन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: Aspose.Slides for Java में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखाई देता है और PPT, PPTX और ODP प्रस्तुतियों में पूर्वावलोकन समस्याओं को कैसे ठीक करें।
---
## **परिचय**

Aspose.Slides for Java का उपयोग करते हुए, जब आप किसी स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश प्रदर्शित होता है। यह संदेश जानबूझकर दिखाया गया है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [OLE प्रबंधन](/slides/hi/java/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आप जान सकें कि OLE ऑब्जेक्ट बदल गया है और प्रीव्यू छवि को अपडेट करने की आवश्यकता है।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए "OLE प्रबंधन" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको स्लाइड पर यह चित्र दिखाई देगा:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर दो बार क्लिक करना होगा, या आप उस पर राइट‑क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादित करें](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल जाता है।

![OLE ऑब्जेक्ट पूर्वावलोकन](OLE_object_preview.png)

अब आप अपनी प्रस्तुति को सहेजना चाहते हैं ताकि OLE ऑब्जेक्ट की छवि सही ढंग से अपडेट हो जाए। इस तरह, प्रस्तुति को सहेजने के बाद, जब आप प्रस्तुति को फिर से खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर उसे सहेजकर "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते, तो आप संदेश को अपनी पसंदीदा प्रीव्यू छवि से बदल सकते हैं। यह कोड इस प्रक्रिया को दर्शाता है:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // प्रेजेंटेशन संसाधनों में एक छवि जोड़ें।
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE ऑब्जेक्ट पूर्वावलोकन के लिए एक शीर्षक और छवि सेट करें।
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

`OleObjectFrame` वाला स्लाइड फिर इस तरह बदल जाता है:

![नई OLE ऑब्जेक्ट छवि](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए ऐड‑ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड‑ऑन भी बना सकते हैं जो प्रोग्राम में प्रस्तुति खोलते समय सभी OLE ऑब्जेक्ट्स को अपडेट करता है।