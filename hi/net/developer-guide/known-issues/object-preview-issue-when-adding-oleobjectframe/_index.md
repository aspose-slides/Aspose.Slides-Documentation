---
title: OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- एम्बेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट प्रीव्यू
- प्रस्तुति
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "जाने कि Aspose.Slides for .NET में OleObjectFrame जोड़ते समय EMBEDDED OLE OBJECT क्यों दिखता है और PPT, PPTX और ODP प्रस्तुतियों में प्रीव्यू समस्याओं को कैसे ठीक करें।"
---
## **परिचय**

.NET के लिए Aspose.Slides का उपयोग करते हुए, जब आप एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश प्रदर्शित होता है। यह संदेश जानबूझकर दिखाया जाता है और यह कोई बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [Manage OLE](/slides/hi/net/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल गया है और प्रीव्यू छवि को अपडेट करना होगा।

उदाहरण के लिए, यदि आप एक Microsoft Excel चार्ट को [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए, "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको इस छवि को स्लाइड पर दिखेगा:

![OLE object message](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर दो बार क्लिक करना होगा, या आप उस पर राइट‑क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE object > Edit](OLE_object_edit.png)

PowerPoint तब एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE object data](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश को OLE ऑब्जेक्ट की वास्तविक छवि से बदल दिया जाता है।

![OLE object preview](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सेव करना चाह सकते हैं ताकि OLE ऑब्जेक्ट की छवि सही तरीके से अपडेट हो सके। इस प्रकार, प्रस्तुति को सेव करने के बाद, जब आप फिर से प्रस्तुति खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखेगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को छवि से बदलें**

यदि आप प्रस्तुति को PowerPoint में खोलकर और फिर सेव करके "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप इस संदेश को अपनी इच्छित प्रीव्यू छवि से बदल सकते हैं। निम्नलिखित कोड पंक्तियां इस प्रक्रिया को दर्शाती हैं:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame` वाले स्लाइड को फिर इस प्रकार बदल दिया जाता है:

![New OLE object image](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए ऐड‑ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड‑ऑन भी बना सकते हैं जो प्रोग्राम में प्रस्तुति खोलते समय सभी OLE ऑब्जेक्ट्स को अपडेट करता है।