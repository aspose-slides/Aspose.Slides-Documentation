---
title: TIFF के रूप में रेंडर किया गया
type: docs
weight: 30
url: /hi/net/rendered-as-tiff/
---
TIFF फ़ॉर्मेट अपनी बहु-पृष्ठीय छवियों और डेटा को समायोजित करने की लचीलापन के कारण जाना जाता है। TIFF फ़ॉर्मेट के महत्व और लोकप्रियता को देखते हुए, Aspose.Slides for .NET प्रस्तुतियों को TIFF दस्तावेज़ में परिवर्तित करने के समर्थन प्रदान करता है।
यह लेख विभिन्न TIFF निर्यात विकल्पों को कैसे उपयोग किया जाए, समझाता है:

- डिफ़ॉल्ट आकार के साथ प्रस्तुतिकरण को TIFF में परिवर्तित करना।
- कस्टम आकार के साथ प्रस्तुतिकरण को TIFF में परिवर्तित करना।

डिवेलपर्स **Presentation** क्लास द्वारा प्रदत्त **Save** मेथड को कॉल करके पूरी प्रस्तुतिकरण को **TIFF** दस्तावेज़ में परिवर्तित कर सकते हैं। आगे, TiffOptions क्लास ImageSize प्रॉपर्टी को उजागर करता है जो आवश्यक होने पर डेवलपर को छवि का आकार निर्धारित करने की सुविधा देता है।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//एक Presentation ऑब्जेक्ट का इंस्टेंशिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (Presentation pres = new Presentation(srcFileName))

{

    //प्रस्तुति को TIFF दस्तावेज़ में सहेज रहा है

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)