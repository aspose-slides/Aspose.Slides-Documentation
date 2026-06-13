---
title: प्रस्तुति को HTML में बदलें
type: docs
weight: 40
url: /hi/net/convert-presentation-to-html/
---
**HTML** डेटा के आदान‑प्रदान के लिए उपयोग किए जाने वाले कई व्यापक रूप से उपयोग किए जाने वाले स्वरूपों में से एक है। **Aspose.Slides for .NET** प्रस्तुति को HTML में बदलने के लिए समर्थन प्रदान करता है। नीचे कोड स्निपेट दिया गया है जो दिखाता है कि यह कैसे किया जाता है।
## **उदाहरण**
``` 

 //एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//प्रस्तुति को HTML में सहेजा जा रहा है

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);
``` 
## **चल रहा उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
अधिक जानकारी के लिए, देखें [.NET में PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें](/slides/hi/net/convert-powerpoint-to-html/)
{{% /alert %}}