---
title: PPT से PPTX फ़ॉर्मेट में रूपांतरण
type: docs
weight: 20
url: /hi/net/conversion-from-ppt-to-pptx-format/
---
Aspose.Slides की अनोखी विशेषता जो संस्करण परिवर्तनों में लचीलापन प्रदान करती है बिना कार्य को प्रभावित किए।
SaveFormat एक enumeration है जो नीचे तालिका में दी गई एक्सटेंशन में दस्तावेज़ को परिवर्तित कर सकता है।

|**सदस्य नाम**|**मान**|**विवरण**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

निम्नलिखित कोड स्निपेट PPT से PPTX में रूपांतरण दिखाता है, आप इसे विपरीत दिशा में भी कर सकते हैं।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//एक Presentation ऑब्जेक्ट को instantiate करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(srcFileName);

//PPTX प्रस्तुति को PPTX फॉर्मेट में सहेज रहा है

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)