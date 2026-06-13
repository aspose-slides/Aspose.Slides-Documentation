---
title: Java में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/java/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में पाठ को सुसंगत रखने के लिए चरण-दर-चरण Java कोड नमूनों के साथ।"
---
## **परिचय**

Aspose.Slides आपको फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दर्शाता है कि फ़ॉलबैक फ़ॉन्ट नियम संग्रह कैसे बनाएं, नियमों को फ़ॉलबैक फ़ॉन्ट हटाकर या जोड़कर संशोधित करें, और `FontsManager.setFontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को असाइन करें।

एक बार फ़ॉलबैक फ़ॉन्ट नियम संग्रह को प्रस्तुति के `FontsManager` को असाइन कर देने पर, नियमों को सहेजने, रेंडर करने और प्रस्तुति को परिवर्तित करने जैसी क्रियाओं के दौरान लागू किया जाता है। यह उदाहरण दिखाता है कि स्लाइड थंबनेल रेंडर करते समय और उसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का उपयोग कैसे किया जाता है।

## **फ़ॉलबैक फ़ॉन्ट नियमों के साथ स्लाइड रेंडर करना**

निम्नलिखित उदाहरण में ये चरण शामिल हैं:

1. हम [फ़ॉलबैक फ़ॉन्ट नियम संग्रह बनाएँ](/slides/hi/java/create-fallback-fonts-collection/)।
2. [हटाएँ]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फ़ॉलबैक फ़ॉन्ट नियम और [addFallBackFonts]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को किसी अन्य नियम में जोड़ें।
3. नियम संग्रह को [getFontsManager]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--) के [getFontFallBackRulesCollection]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड से सेट करें।
4. [Presentation.save]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके प्रस्तुति को उसी फ़ॉर्मेट में या किसी अन्य फ़ॉर्मेट में सहेजा जा सकता है। जब फ़ॉलबैक फ़ॉन्ट नियम संग्रह को [FontsManager]​(https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) को असाइन किया जाता है, तो ये नियम प्रस्तुति पर किए गए किसी भी कार्य‑जैसे सहेजना, रेंडर करना, परिवर्तित करना, आदि‑के दौरान लागू होते हैं।

```java
// नियम संग्रह का नया इंस्टेंज़ बनाएं
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // "Tahoma" फ़ॉलबैक फ़ॉन्ट को लोडेड नियमों से हटाने का प्रयास
    fallBackRule.remove("Tahoma");

    // और निर्दिष्ट रेंज के लिए नियमों को अपडेट करना
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// हम सूची से किसी भी मौजूदा नियम को भी हटा सकते हैं
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // उपयोग के लिए तैयार नियम सूची असाइन कर रहे हैं
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // चित्र को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Java में PPT और PPTX को JPG में परिवर्तित करने के बारे में अधिक जानने के लिए [Convert PPT and PPTX to JPG in Java](/slides/hi/java/convert-powerpoint-to-jpg/) पढ़ें।
{{% /alert %}}