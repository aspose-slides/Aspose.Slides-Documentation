---
title: Aspose.Slides for .NET 15.1.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- स्थानांतरण
- पारंपरिक कोड
- आधुनिक कोड
- पारंपरिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा Aspose.Slides for .NET 15.1.0 API के साथ introd़्यूस किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **फ़ॉन्ट प्रतिस्थापन कार्यक्षमता जोड़ी गई है**
प्रस्तुति में फ़ॉन्ट को वैश्विक रूप से और रेंडरिंग के दौरान अस्थायी रूप से बदलने की संभावना जोड़ी गई है।

Presentation क्लास का नया प्रॉपर्टी "FontsManager" परिचय करवाया गया है। FontsManager क्लास में निम्नलिखित सदस्य हैं:

**IFontSubstRuleCollection FontSubstRuleList** प्रॉपर्टी

रेंडरिंग के दौरान फ़ॉन्ट्स को प्रतिस्थापित करने के लिए IFontSubstRule उदाहरणों का यह संग्रह उपयोग किया जाता है। IFontSubstRule में SourceFont और DestFont प्रॉपर्टी हैं जो IFontData इंटरफ़ेस को लागू करती हैं तथा ReplaceFontCondition प्रॉपर्टी है जो प्रतिस्थापन की शर्त चुनने की अनुमति देती है ("WhenInaccessible" या "Always")।

**IFontData[] GetFonts()** मेथड

वर्तमान प्रस्तुति में उपयोग किए गए सभी फ़ॉन्ट्स को प्राप्त करने के लिए उपयोग किया जाता है।

**ReplaceFont** मेथड्स

प्रस्तुति में फ़ॉन्ट को स्थायी रूप से बदलने के लिए उपयोग किया जाता है।

निम्नलिखित उदाहरण दिखाता है कि प्रस्तुति में फ़ॉन्ट को कैसे बदलें:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

एक और उदाहरण, जब फ़ॉन्ट पहुँच योग्य नहीं हो तो रेंडरिंग के लिए फ़ॉन्ट प्रतिस्थापन दर्शाता है:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // जब पहुँच योग्य न हो तो SomeRareFont के बजाय Arial फ़ॉन्ट का उपयोग किया जाएगा

            pres.Slides[0].GetImage();

```