---
title: प्रेजेंटेशन के आकार और लेआउट के साथ काम करना
type: docs
weight: 90
url: /hi/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** और **SlideSize.Size** प्रेजेंटेशन क्लास के प्रॉपर्टीज़ हैं जिन्हें नीचे दिए गए उदाहरण में दिखाए अनुसार सेट या गेट किया जा सकता है।
## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//एक Presentation ऑब्जेक्ट बनाएं जो एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//जनरेट किए गए प्रेजेंटेशन के स्लाइड आकार को स्रोत के समान सेट करें

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//प्रेजेंटेशन को डिस्क पर सहेजें

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **चलता हुआ उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
अधिक विवरण के लिए, देखें [.NET में प्रेजेंटेशन स्लाइड आकार बदलें](/slides/hi/net/slide-size/).
{{% /alert %}}