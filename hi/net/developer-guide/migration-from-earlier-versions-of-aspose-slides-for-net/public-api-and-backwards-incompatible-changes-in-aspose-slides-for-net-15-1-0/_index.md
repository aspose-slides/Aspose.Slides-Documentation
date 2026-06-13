---
title: Aspose.Slides for .NET 15.1.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी एप्रोच
- आधुनिक एप्रोच
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट्स और ब्रेकिंग बदलावों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधानों को सुगमता से माइग्रेट करें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ Aspose.Slides for .NET 15.1.0 API के साथ प्रस्तुत सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा अन्य परिवर्तन दर्शाता है।

{{% /alert %}} 
## **Public API परिवर्तन**
#### **फ़ॉन्ट प्रतिस्थापन कार्यक्षमता जोड़ी गई है**
प्रस्तुति में फ़ॉन्ट को पूरी तरह और रेंडरिंग के लिए अस्थायी रूप से बदलने की संभावना जोड़ी गई है।

Presentation क्लास में नया प्रॉपर्टी "FontsManager" प्रस्तुत किया गया है। FontsManager क्लास में निम्न सदस्य हैं:

**IFontSubstRuleCollection FontSubstRuleList** प्रॉपर्टी

यह IFontSubstRule इंस्टेंस की संग्रह रेंडरिंग के दौरान फ़ॉन्ट बदलने के लिए उपयोग की जाती है। IFontSubstRule में SourceFont और DestFont प्रॉपर्टी हैं जो IFontData इंटरफ़ेस को लागू करती हैं और ReplaceFontCondition प्रॉपर्टी है जो प्रतिस्थापन की शर्त चुनने की अनुमति देती है ("WhenInaccessible" या "Always")।

**IFontData[] GetFonts()** मेथड

वर्तमान प्रस्तुति में उपयोग किए गए सभी फ़ॉन्ट प्राप्त करने के लिए उपयोग किया जाता है।

**ReplaceFont** मेथड्स

प्रस्तुति में फ़ॉन्ट को स्थायी रूप से बदलने के लिए उपयोग किया जाता है।

निम्न उदाहरण दिखाता है कि प्रस्तुति में फ़ॉन्ट को कैसे बदलें:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

एक अन्य उदाहरण, जब फ़ॉन्ट उपलब्ध नहीं हो तो रेंडरिंग के लिए फ़ॉन्ट प्रतिस्थापन दर्शाता है:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // जब फ़ॉन्ट उपलब्ध न हो तो SomeRareFont के बजाय Arial फ़ॉन्ट का उपयोग किया जाएगा

            pres.Slides[0].GetThumbnail();

```