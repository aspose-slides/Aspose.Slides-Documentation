---
title: OpenDocument प्रस्तुति तक पहुंच
type: docs
weight: 10
url: /hi/net/access-opendocument-presentation/
---
Aspose.Slides for .NET **Presentation** क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। **Presentation** क्लास अब **Presentation** कंस्ट्रक्टर के माध्यम से **ODP** तक भी पहुँच सकता है जब वस्तु का निर्माण किया जाता है।
## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (Presentation pres = new Presentation(srcFileName))

{

    //PPTX प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **चल रहा उदाहरण डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)