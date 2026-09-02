---
title: TIFF के रूप में रेंडर किया गया
type: docs
weight: 30
url: /hi/net/rendered-as-tiff/
---
TIFF फ़ॉर्मेट अपनी बहु‑पृष्ठीय छवियों और डेटा को समायोजित करने की लचीलापन के कारण जाना जाता है। TIFF फ़ॉर्मेट के महत्व और लोकप्रियता को ध्यान में रखते हुए, Aspose.Slides for .NET प्रस्तुतियों को TIFF दस्तावेज़ में बदलने के लिए समर्थन प्रदान करता है।
यह लेख विभिन्न TIFF निर्यात विकल्पों को समझाता है:

- डिफ़ॉल्ट आकार के साथ प्रस्तुति को TIFF में परिवर्तित करना।
- कस्टम आकार के साथ प्रस्तुति को TIFF में परिवर्तित करना।

**Presentation** वर्ग द्वारा प्रदर्शित **Save** मेथड को डेवलपर्स द्वारा पूरी प्रस्तुति को **TIFF** दस्तावेज़ में बदलने के लिए बुलाया जा सकता है। इसके अलावा, TiffOptions वर्ग ImageSize प्रॉपर्टी को उजागर करता है जिससे आवश्यकता पड़ने पर डेवलपर छवि का आकार निर्धारित कर सकता है।

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (Presentation pres = new Presentation(srcFileName))

{

    //प्रस्तुति को TIFF दस्तावेज़ में सहेजा जा रहा है

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)