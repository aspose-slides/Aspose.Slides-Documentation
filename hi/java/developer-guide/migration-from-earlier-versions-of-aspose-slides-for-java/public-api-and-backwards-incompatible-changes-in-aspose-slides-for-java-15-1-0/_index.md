---
title: Aspose.Slides for Java 15.1.0 में सार्वजनिक API और बैकवर्ड्स असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- स्थानांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेज़ेंटेशन समाधानों को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 
यह पृष्ठ सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, नए प्रतिबंध और अन्य [changes](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) को Aspose.Slides for Java 15.1.0 API के साथ सूचीबद्ध करता है।
{{% /alert %}} {{% alert color="primary" %}} 
कुछ इमेज बुलेट्स और WordArt ऑब्जेक्ट्स में ज्ञात समस्याएँ हैं जिन्हें Aspose.Slides for Java 15.2.0 में ठीक किया जाएगा।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **फ़ॉन्ट प्रतिस्थापन कार्यक्षमता जोड़ी गई है**
प्रेज़ेंटेशन में फ़ॉन्ट्स को ग्लोबली बदलने और रेंडरिंग के लिए अस्थायी रूप से बदलने की संभावना जोड़ी गई है।

Presentation क्लास में नया मेथड getFontsManager() पेश किया गया है। FontsManager क्लास में निम्नलिखित सदस्य हैं:

**IFontSubstRuleCollection getFontSubstRuleList**() मेथड

यह रेंडरिंग के दौरान फ़ॉन्ट्स को प्रतिस्थापित करने के लिए उपयोग किए जाने वाले IFontSubstRule इंस्टेंस की संग्रह है। IFontSubstRule में getSourceFont() और getDestFont() मेथड्स हैं जो IFontData इंटरफ़ेस को लागू करते हैं तथा getReplaceFontCondition() मेथड है जो प्रतिस्थापन की शर्त चुनने की अनुमति देता है ("WhenInaccessible" या "Always")।

**IFontData[] getFonts()** मेथड का उपयोग वर्तमान प्रेज़ेंटेशन में उपयोग किए गए सभी फ़ॉन्ट्स को प्राप्त करने के लिए किया जा सकता है।

**replaceFont(...)** मेथड्स का उपयोग प्रेज़ेंटेशन में फ़ॉन्ट को स्थायी रूप से बदलने के लिए किया जा सकता है।

निम्नलिखित उदाहरण दिखाता है कि प्रेज़ेंटेशन में फ़ॉन्ट को कैसे बदलें:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

एक अन्य उदाहरण दिखाता है कि जब फ़ॉन्ट पहुंच योग्य नहीं हो तो रेंडरिंग के लिए फ़ॉन्ट प्रतिस्थापन कैसे किया जाए:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
// जब पहुँच योग्य न हो तो SomeRareFont के बजाय Arial फ़ॉन्ट का उपयोग किया जाएगा

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```