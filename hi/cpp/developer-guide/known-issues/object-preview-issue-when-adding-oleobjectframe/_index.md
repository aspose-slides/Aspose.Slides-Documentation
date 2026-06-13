---
title: OleObjectFrame जोड़ते समय ऑब्जेक्ट पूर्वावलोकन समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- पूर्वावलोकन समस्या
- एम्बेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट पूर्वावलोकन
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "जानें कि Aspose.Slides for C++ में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखाई देता है और PPT, PPTX और ODP प्रस्तुतियों में पूर्वावलोकन समस्याओं को कैसे ठीक करें।"
---
## **परिचय**

Aspose.Slides for C++ का उपयोग करते समय, जब आप किसी स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश दिखाया जाता है। यह संदेश जानबूझकर दिखाया जाता है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए देखें [Manage OLE](/slides/hi/cpp/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश प्रदर्शित करता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू छवि को अपडेट करने की आवश्यकता है।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (विस्तृत जानकारी के लिए "Manage OLE" लेख देखें) और फिर प्रेजेंटेशन को Microsoft PowerPoint में खोलते हैं, तो आपको स्लाइड पर यह छवि दिखेगी:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल‑क्लिक करना होगा, या आप उस पर राइट‑क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > Edit](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करेंगे, तो स्लाइड प्रीव्यू अपडेट हो जाएगा और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल दिया जाएगा।

![OLE ऑब्जेक्ट प्रीव्यू](OLE_object_preview.png)

अब, आप यह सुनिश्चित करने के लिए अपनी प्रस्तुति को सहेजना चाह सकते हैं कि OLE ऑब्जेक्ट की छवि सही ढंग से अपडेट हो गई है। इस तरह, प्रस्तुति को सहेजने के बाद, जब आप फिर से प्रस्तुति खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को एक छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर सहेजकर "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप संदेश को अपनी पसंदीदा प्रीव्यू छवि से बदल सकते हैं। इस प्रक्रिया को दर्शाने वाला कोड नीचे दिया गया है:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`OleObjectFrame` वाला स्लाइड फिर इस प्रकार बदल जाता है:

![नया OLE ऑब्जेक्ट छवि](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए एक ऐड‑ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड‑ऑन भी बना सकते हैं जो प्रेजेंटेशन्स को खोलते समय सभी OLE ऑब्जेक्ट्स को अपडेट करता है।