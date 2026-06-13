---
title: OleObjectFrame जोड़ने पर ऑब्जेक्ट पूर्वावलोकन समस्या
linktitle: OLE ऑब्जेक्ट समस्या
type: docs
weight: 10
url: /hi/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- पूर्वावलोकन समस्या
- एंबेड ऑब्जेक्ट
- एंबेड फ़ाइल
- ऑब्जेक्ट बदला
- ऑब्जेक्ट पूर्वावलोकन
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP में OleObjectFrame जोड़ने पर EMBEDDED OLE OBJECT क्यों दिखाई देता है और PPT, PPTX और ODP प्रस्तुतियों में पूर्वावलोकन समस्याओं को कैसे ठीक किया जाए, जानें।"
---
## **परिचय**

Aspose.Slides for PHP via Java का उपयोग करते हुए, जब आप एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) जोड़ते हैं, तो आउटपुट स्लाइड पर "EMBEDDED OLE OBJECT" संदेश दिखाया जाता है। यह संदेश इरादतन है और यह बग नहीं है।

OLE ऑब्जेक्ट्स के साथ काम करने के बारे में अधिक जानकारी के लिए, देखें [Manage OLE](/slides/hi/php-java/manage-ole/)।

## **व्याख्या और समाधान**

Aspose.Slides "EMBEDDED OLE OBJECT" संदेश दिखाता है ताकि आपको सूचित किया जा सके कि OLE ऑब्जेक्ट बदल दिया गया है और प्रीव्यू इमेज को अपडेट करना आवश्यक है।

उदाहरण के लिए, यदि आप Microsoft Excel चार्ट को एक [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) के रूप में स्लाइड में जोड़ते हैं (अधिक विवरण के लिए "Manage OLE" लेख देखें) और फिर प्रस्तुति को Microsoft PowerPoint में खोलते हैं, तो आपको इस छवि को स्लाइड पर दिखाई देगा:

![OLE ऑब्जेक्ट संदेश](OLE_object_message.png)

यदि आप यह जांचना और पुष्टि करना चाहते हैं कि आपका OLE ऑब्जेक्ट स्लाइड में जोड़ा गया था, तो आपको "EMBEDDED OLE OBJECT" संदेश पर डबल-क्लिक करना होगा, या आप उस पर राइट-क्लिक करके **Object > Edit** विकल्प चुन सकते हैं।

![OLE ऑब्जेक्ट > संपादन](OLE_object_edit.png)

PowerPoint फिर एम्बेडेड OLE ऑब्जेक्ट को खोलता है।

![OLE ऑब्जेक्ट डेटा](OLE_object_data.png)

स्लाइड में "EMBEDDED OLE OBJECT" संदेश बना रह सकता है। एक बार जब आप OLE ऑब्जेक्ट पर क्लिक करते हैं, तो स्लाइड का प्रीव्यू अपडेट हो जाता है और "EMBEDDED OLE OBJECT" संदेश OLE ऑब्जेक्ट की वास्तविक छवि से बदल दिया जाता है।

![OLE ऑब्जेक्ट पूर्वावलोकन](OLE_object_preview.png)

अब, आप अपनी प्रस्तुति को सहेजना चाह सकते हैं ताकि OLE ऑब्जेक्ट की छवि सही तरीके से अपडेट हो सके। इस तरह, प्रस्तुति को सहेजने के बाद, जब आप प्रस्तुति को फिर से खोलेंगे, तो आपको "EMBEDDED OLE OBJECT" संदेश नहीं दिखाई देगा।

## **अन्य समाधान**

### **समाधान 1: "Embedded OLE Object" संदेश को एक छवि से बदलें**

यदि आप PowerPoint में प्रस्तुति खोलकर और फिर सहेजकर "EMBEDDED OLE OBJECT" संदेश को हटाना नहीं चाहते हैं, तो आप संदेश को अपनी पसंदीदा प्रीव्यू छवि से बदल सकते हैं। यह कोड लाइन्स प्रक्रिया को दर्शाती हैं:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // प्रेज़ेंटेशन संसाधनों में एक छवि जोड़ें।
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // OLE ऑब्जेक्ट पूर्वावलोकन के लिए शीर्षक और छवि सेट करें।
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

`OleObjectFrame` वाला स्लाइड तब इस प्रकार बदल जाता है:

![नया OLE ऑब्जेक्ट चित्र](OLE_object_new_image.png)

### **समाधान 2: PowerPoint के लिए एक Add-On बनाएं**

आप Microsoft PowerPoint के लिए एक Add-On भी बना सकते हैं जो जब आप कार्यक्रम में प्रस्तुतीकरण खोलते हैं तो सभी OLE ऑब्जेक्ट को अपडेट करता है।