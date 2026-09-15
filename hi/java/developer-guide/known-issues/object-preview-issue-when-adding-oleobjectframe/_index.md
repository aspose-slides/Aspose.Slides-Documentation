---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एंबेड ऑब्जेक्ट
- एंबेड फ़ाइल
- ऑब्जेक्ट बदला
- ऑब्जेक्ट प्रीव्यू
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे ठीक करें।"
---
## **परिचय**

Aspose.Slides for Java का उपयोग करते हुए, जब आप किसी स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश दिखता है। यह संदेश जानबूझकर दिखाया जाता है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [Manage OLE](/slides/hi/java/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश तब दिखाता है जब OLE ऑब्जेक्ट बदल गया हो और पूर्वावलोकन छवि को अपडेट करने की आवश्यकता हो।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को [OleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/oleobjectframe/) के रूप में किसी स्लाइड में जोड़ते हैं (अधिक विवरण के लिए, "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको स्लाइड पर यह छवि दिखाई देगी:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जाँचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल‑क्लिक करना होगा, या आप उस पर राइट‑क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादित करें](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का पूर्वावलोकन अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल दिया जाता है।

![OLE ऑब्जेक्ट पूर्वावलोकन](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सहेजना चाह सकते हैं ताकि OLE ऑब्जेक्ट की छवि सही ढंग से अपडेट हो सके। इस तरह, प्रस्तुति सहेजने के बाद, जब आप फिर से प्रस्तुति खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

यदि आप PowerPoint में प्रस्तुति खोल कर और फिर सहेज कर "EMBEDDED OLE OBJECT" संदेश हटाना नहीं चाहते हैं, तो आप इस संदेश को अपनी पसंदीदा पूर्वावलोकन छवि से बदल सकते हैं। नीचे दिया गया कोड इस प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

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

फिर `OleObjectFrame` वाली स्लाइड इस प्रकार बदल जाएगी:

![नई OLE ऑब्जेक्ट छवि](OLE_object_new_image.png)