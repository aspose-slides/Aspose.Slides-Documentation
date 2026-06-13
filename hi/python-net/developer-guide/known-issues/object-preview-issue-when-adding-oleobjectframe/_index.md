---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एम्बेडेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट परिवर्तित
- ऑब्जेक्ट पूर्वावलोकन
- प्रस्तुति
- PowerPoint
- Python
- Aspose.Slides
description: "Aspose.Slides for Python में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे ठीक करें, इसे जानें।"
---
## **परिचय**

Aspose.Slides for Python via .NET का उपयोग करते हुए, जब आप एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर एक "EMBEDDED OLE OBJECT" संदेश दिखाया जाता है। यह संदेश इरादतन है और बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [Manage OLE](/slides/hi/python-net/manage-ole/). 

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश प्रदर्शित करता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू इमेज को अपडेट करना आवश्यक है। 

उदाहरण के लिए, यदि आप एक स्लाइड में Microsoft Excel चार्ट को [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) के रूप में जोड़ते हैं (अधिक विवरण के लिए, "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको इस इमेज को स्लाइड पर दिखेगा:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया था, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल-क्लिक करना होगा, या आप उस पर राइट-क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादित करें](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक इमेज से प्रतिस्थापित हो जाता है। 

![OLE ऑब्जेक्ट प्रीव्यू](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सेव करना चाह सकते हैं ताकि OLE ऑब्जेक्ट की इमेज सही ढंग से अपडेट हो सके। इस प्रकार, प्रस्तुति को सेव करने के बाद, जब आप प्रस्तुति को फिर से खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखाई देगा। 

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को इमेज से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर उसे सेव करके "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते, तो आप संदेश को अपनी पसंदीदा प्रीव्यू इमेज से बदल सकते हैं। नीचे दिए गए कोड लाइनों में प्रक्रिया दर्शाई गई है:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # प्रस्तुति संसाधनों में एक छवि जोड़ें।
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE ऑब्जेक्ट प्रीव्यू के लिए शीर्षक और छवि सेट करें।
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

इसके बाद `OleObjectFrame` वाले स्लाइड को इस प्रकार बदल दिया जाता है:

![नया OLE ऑब्जेक्ट इमेज](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए एक ऐड-ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड-ऑन भी बना सकते हैं जो प्रेजेंटेशन खोलते समय सभी OLE ऑब्जेक्ट को अपडेट करता है।