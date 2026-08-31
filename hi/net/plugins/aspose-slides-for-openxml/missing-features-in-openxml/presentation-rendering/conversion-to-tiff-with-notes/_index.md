---
title: नोट्स के साथ टीफ़फ में रूपांतरण
type: docs
weight: 10
url: /hi/net/conversion-to-tiff-with-notes/
---
TIFF कई व्यापक रूप से उपयोग किए जाने वाले इमेज फ़ॉर्मैट्स में से एक है जिसे Aspose.Slides for .NET नोट्स के साथ प्रस्तुति को छवियों में परिवर्तित करने के लिए समर्थन करता है। आप नोट्स स्लाइड व्यू में स्लाइड थंबनेल भी जेनरेट कर सकते हैं। नीचे दो कोड स्निपेट्स दिखाए गए हैं जो नोट्स स्लाइड व्यू में प्रस्तुति की TIFF छवियों को उत्पन्न करने का तरीका बताते हैं।

**Presentation** क्लास द्वारा एक्सपोज़ किया गया **Save** मेथड पूरी प्रस्तुति को नोट्स स्लाइड व्यू में TIFF में बदलने के लिए उपयोग किया जा सकता है। आप व्यक्तिगत स्लाइड्स के लिए भी नोट्स स्लाइड व्यू में स्लाइड थंबनेल जेनरेट कर सकते हैं।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//एक Presentation ऑब्जेक्ट को इनस्टेंटिएट करें जो प्रस्तुति फ़ाइल को दर्शाता है
using (Presentation pres = new Presentation(srcFileName))
{
    //प्रत्येक रेंडर की गई स्लाइड के नीचे स्पीकर नोट्स रखें
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //नोट्स के साथ प्रस्तुति को TIFF में सहेजें
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)