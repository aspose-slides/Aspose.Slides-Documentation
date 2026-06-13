---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/net/slide-transitions/
---
समझना आसान बनाने के लिए, हमने Aspose.Slides for .NET के उपयोग को सरल स्लाइड ट्रांज़िशन प्रबंधन के लिए प्रदर्शित किया है। डेवलपर्स केवल स्लाइड्स पर विभिन्न स्लाइड ट्रांज़िशन प्रभाव लागू ही नहीं कर सकते, बल्कि इन ट्रांज़िशन प्रभावों के व्यवहार को भी अनुकूलित कर सकते हैं। एक सरल स्लाइड ट्रांज़िशन प्रभाव बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक उदाहरण बनाएँ
- Aspose.Slides for .NET द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक से **TransitionType** enum के माध्यम से स्लाइड पर एक Slide Transition Type लागू करें
- संशोधित प्रस्तुति फ़ाइल को लिखें।

## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//एक Presentation क्लास का उदाहरण बनाते हैं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

using (Presentation pres = new Presentation(FileName))

{

    //स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //प्रस्तुति को डिस्क पर लिखें

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **चलती हुई उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
अधिक विवरण के लिए, देखें [स्लाइड ट्रांज़िशन प्रबंधन](/slides/hi/net/slide-transition/).
{{% /alert %}}