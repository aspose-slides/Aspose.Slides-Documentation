---
title: OpenOffice दस्तावेज़ का रूपांतरण
type: docs
weight: 30
url: /hi/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET **Presentation** क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। **Presentation** क्लास अब भी **ODP** तक पहुंच सकता है जब ऑब्जेक्ट को इनस्टैंशिएट किया जाता है, Presentation कंस्ट्रक्टर के माध्यम से।

नीचे ODP से PPT/PPTX में रूपांतरण का उदाहरण दिया गया है।
## **उदाहरण**
```

 //एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //PPTX प्रस्तुति को PPTX फॉर्मेट में सहेजा जा रहा है

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

नीचे PPT/PPTX से ODP में रूपांतरण का उदाहरण दिया गया है।
## **उदाहरण**
``` 

 //एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //PPTX प्रस्तुति को PPTX फॉर्मेट में सहेजा जा रहा है

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **चलता हुआ उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)