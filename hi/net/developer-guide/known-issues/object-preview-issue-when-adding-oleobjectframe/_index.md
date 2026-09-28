---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट प्रीव्यू प्लेसहोल्डर
linktitle: OLE प्रीव्यू प्लेसहोल्डर
type: docs
weight: 10
url: /hi/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- प्रीव्यू समस्या
- प्रीव्यू प्लेसहोल्डर
- डिजाइन द्वारा
- एम्बेड ऑब्जेक्ट
- एम्बेड फ़ाइल
- ऑब्जेक्ट बदल गया
- ऑब्जेक्ट प्रीव्यू
- प्रेज़ेंटेशन
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "जब Aspose.Slides for .NET के साथ जोड़ा गया OLE ऑब्जेक्ट अपने प्रीव्यू को अपडेट होने तक \"EMBEDDED OLE OBJECT\" प्लेसहोल्डर दिखाता है, और आप अपना स्वयं का प्रीव्यू इमेज कैसे सेट कर सकते हैं।"
---
## **परिचय**

.NET के लिए Aspose.Slides का उपयोग करते हुए, जब आप [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe/) को स्लाइड में जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश दिखाया जाता है। यह संदेश जानबूझकर दिखाया जाता है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [OLE प्रबंधन](/slides/hi/net/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश प्रदर्शित करता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू इमेज को अपडेट करना आवश्यक है।

उदाहरण के लिए, यदि आप एक Microsoft Excel चार्ट को [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए "Manage OLE" लेख देखें) और फिर प्रस्तुतीकरण को Microsoft PowerPoint में खोलते हैं, तो आप इस चित्र को स्लाइड पर देखेंगे:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जाँचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया है, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल-क्लिक करना होगा, या आप उस पर राइट-क्लिक करके **ऑब्जेक्ट > संपादन** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादन](OLE_object_edit.png)

PowerPoint फिर एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। जब आप OLE ऑब्जेक्ट पर क्लिक करेंगे, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल जाता है।

![OLE ऑब्जेक्ट प्रीव्यू](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सहेजना चाह सकते हैं ताकि OLE ऑब्जेक्ट की छवि सही ढंग से अपडेट हो सके। इस प्रकार, प्रस्तुति को सहेजने के बाद, जब आप फिर से प्रस्तुति खोलेंगे, तो आप "EMBEDDED OLE OBJECT" संदेश नहीं देखेंगे।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर उसे सहेजकर "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप संदेश को अपनी पसंदीदा प्रीव्यू छवि से बदल सकते हैं। निम्नलिखित कोड लाइनें इस प्रक्रिया को दर्शाती हैं:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame` वाला स्लाइड फिर इस प्रकार बदल जाता है:

![नई OLE ऑब्जेक्ट छवि](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए ऐड-ऑन बनाएं**

आप Microsoft PowerPoint के लिए एक ऐड-ऑन भी बना सकते हैं जो प्रोग्राम में प्रस्तुति खोलने पर सभी OLE ऑब्जेक्ट्स को अपडेट करता है।