---
title: XPS में रूपांतरण
type: docs
weight: 40
url: /hi/net/conversion-to-xps/
---
**XPS** फ़ॉर्मेट डेटा के विनिमय के लिए भी व्यापक रूप से उपयोग किया जाता है। Aspose.Slides for .NET इसके महत्व को ध्यान में रखता है और प्रस्तुति को XPS दस्तावेज़ में बदलने के लिए अंतर्निहित समर्थन प्रदान करता है।

Presentation क्लास द्वारा प्रदान किया गया **Save** मेथड का उपयोग पूरी प्रस्तुति को **XPS** दस्तावेज़ में बदलने के लिए किया जा सकता है। आगे, **XpsOptions** क्लास **SaveMetafileAsPng** प्रॉपर्टी को एक्सपोज़ करती है जिसे आवश्यकता के अनुसार true या false पर सेट किया जा सकता है।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(srcFileName);

//प्रस्तुति को TIFF दस्तावेज़ में सहेजना

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **सैंपल कोड डाउनलोड करें**
- [गिटहब](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [बिटबकेट](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)