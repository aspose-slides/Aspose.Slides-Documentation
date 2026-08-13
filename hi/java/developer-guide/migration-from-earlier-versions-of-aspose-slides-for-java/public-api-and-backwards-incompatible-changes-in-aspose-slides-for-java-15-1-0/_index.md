---
title: Aspose.Slides for Java 15.1.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- स्थांतरण
- पुराना कोड
- आधुनिक कोड
- पुराया दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) क्लास, मेथड, प्रॉपर्टी आदि, किसी भी नई प्रतिबंधों और अन्य [changes](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) को सूचीबद्ध करता है, जो Aspose.Slides for Java 15.1.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} {{% alert color="info" %}} 

कुछ इमेज बुलेट्स और WordArt ऑब्जेक्ट्स में ज्ञात समस्याएँ हैं, जिन्हें Aspose.Slides for Java 15.2.0 में ठीक किया जाएगा।

{{% /alert %}} 
## **Public API Changes**
### **Fonts substitutions functinality has been added**
प्रेजेंटेशन में फ़ॉन्ट्स को ग्लोबली और रेंडरिंग के लिए अस्थायी रूप से बदलने की संभावना जोड़ी गई है।

Presentation क्लास में नया मेथड getFontsManager() पेश किया गया है। FontsManager क्लास में निम्न सदस्य हैं:

**IFontSubstRuleCollection getFontSubstRuleList**() मेथड

यह IFontSubstRule इंस्टेंस की कलेक्शन है, जिसका उपयोग रेंडरिंग के दौरान फ़ॉन्ट्स को प्रतिस्थापित करने के लिए किया जाता है। IFontSubstRule में getSourceFont() और getDestFont() मेथड्स हैं जो IFontData इंटरफ़ेस को लागू करते हैं तथा getReplaceFontCondition() मेथड है जो प्रतिस्थापन की शर्त चुनने की अनुमति देता है ("WhenInaccessible" या "Always")।

**IFontData[] getFonts()** मेथड का उपयोग वर्तमान प्रेजेंटेशन में उपयोग किए गए सभी फ़ॉन्ट्स को प्राप्त करने के लिए किया जा सकता है।

**replaceFont(...)** मेथड्स का उपयोग प्रेजेंटेशन में फ़ॉन्ट को स्थायी रूप से बदलने के लिए किया जा सकता है।  

निम्न उदाहरण दिखाता है कि प्रेजेंटेशन में फ़ॉन्ट को कैसे बदलें:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

एक अन्य उदाहरण, जब फ़ॉन्ट पहुँच से बाहर हो तो रेंडरिंग के लिए फ़ॉन्ट प्रतिस्थापन दर्शाता है:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // जब पहुँच नहीं होगी तो SomeRareFont के बजाय Arial फ़ॉन्ट का उपयोग किया जाएगा।
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```