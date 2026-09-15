---
title: OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एंबेड ऑब्जेक्ट
- एंबेड फाइल
- ऑब्जेक्ट बदला
- ऑब्जेक्ट प्रीव्यू
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "जानेँ कि Aspose.Slides for Python via Java में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे हल करें।"
---
## **परिचय**

जब आप Aspose.Slides for Python via Java का उपयोग करके किसी स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश प्रदर्शित होता है। यह संदेश जानबूझकर दिखाया जाता है और यह कोई बग नहीं है।

अधिक जानकारी के लिए OLE ऑब्जेक्ट्स के साथ काम करने के बारे में देखें [Manage OLE](/slides/hi/python-java/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आप को सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और उसका प्रीव्यू इमेज अपडेट करना आवश्यक है।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए, "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको स्लाइड पर यह छवि दिखाई देगी:

![OLE object message](OLE_object_message.png)

यह पुष्टि करने के लिए कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, "EMBEDDED OLE OBJECT" संदेश पर डबल-क्लिक करें, या उस पर राइट-क्लिक करके **Object > Edit** चुनें।

![OLE object > Edit](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE object data](OLE_object_data.png)

स्लाइड में अभी भी "EMBEDDED OLE OBJECT" संदेश रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से प्रतिस्थापित हो जाता है।

![OLE object preview](OLE_object_preview.png)

अपडेटेड OLE ऑब्जेक्ट प्रीव्यू इमेज को संरक्षित रखने के लिए अपनी प्रस्तुति को सहेजें। जब आप प्रस्तुति को फिर से खोलेंगे, तो आपको अब "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर सहेजकर "EMBEDDED OLE OBJECT" संदेश नहीं हटाना चाहते हैं, तो आप संदेश को अपनी पसंद की प्रीव्यू छवि से बदल सकते हैं। निम्नलिखित कोड इस प्रक्रिया को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # प्रेजेंटेशन संसाधनों में एक छवि जोड़ें।
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # OLE ऑब्जेक्ट प्रीव्यू के लिए एक शीर्षक और छवि सेट करें।
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जिस स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) शामिल है, वह फिर इस रूप में बदल जाता है:

![New OLE object image](OLE_object_new_image.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**"EMBEDDED OLE OBJECT" संदेश क्यों दिखाई देता है?**

यह संदेश दर्शाता है कि OLE ऑब्जेक्ट बदल गया है और उसके प्रीव्यू इमेज को अपडेट करने की आवश्यकता है। यह व्यवहार जानबूझकर किया गया है।

**मैं PowerPoint में प्रीव्यू कैसे अपडेट कर सकता हूँ?**

संदेश पर डबल-क्लिक करें या **Object > Edit** चुनें ताकि एम्बेडेड OLE ऑब्जेक्ट खुल सके। प्रीव्यू को अपडेट करने के लिए OLE ऑब्जेक्ट पर क्लिक करें, फिर प्रस्तुति को सहेजें।

**क्या मैं PowerPoint में प्रस्तुति खोले बिना संदेश को बदल सकता हूँ?**

हाँ। आप ऊपर दिखाए गए कोड उदाहरण के अनुसार OLE ऑब्जेक्ट को अपनी पसंद की प्रीव्यू छवि असाइन कर सकते हैं।