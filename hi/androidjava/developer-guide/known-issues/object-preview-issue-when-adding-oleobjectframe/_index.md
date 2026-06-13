---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एम्बेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट प्रीव्यू
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "जानें कि Aspose.Slides for Android via Java में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे ठीक करें।"
---
## **परिचय**

Java के माध्यम से Android के लिए Aspose.Slides का उपयोग करते हुए, जब आप किसी स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश प्रदर्शित होता है। यह संदेश जानबूझकर है और बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [OLE प्रबंधन](/slides/hi/androidjava/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू इमेज को अपडेट करना आवश्यक है।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको इस छवि को स्लाइड पर दिखेगा:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल-क्लिक करना होगा, या आप उस पर राइट-क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादित करें](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से प्रतिस्थापित हो जाता है।

![OLE ऑब्जेक्ट प्रीव्यू](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सहेजना चाह सकते हैं ताकि OLE ऑब्जेक्ट की छवि सही तरीके से अपडेट हो सके। इस प्रकार, प्रस्तुति को सहेजने के बाद, जब आप प्रस्तुति को फिर से खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर सहेजकर "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप संदेश को अपनी पसंदीदा प्रीव्यू छवि से बदल सकते हैं। नीचे दिया गया कोड इस प्रक्रिया को दर्शाता है:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // प्रस्तुति संसाधनों में एक छवि जोड़ें।
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE ऑब्जेक्ट प्रीव्यू के लिए शीर्षक और छवि सेट करें।
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

`OleObjectFrame` वाला स्लाइड फिर इस रूप में बदल जाता है:

![नई OLE ऑब्जेक्ट छवि](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए ऐड-ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड-ऑन भी बना सकते हैं जो प्रोग्राम में प्रस्तुतियों को खोलते समय सभी OLE ऑब्जेक्ट्स को अपडेट करता है।