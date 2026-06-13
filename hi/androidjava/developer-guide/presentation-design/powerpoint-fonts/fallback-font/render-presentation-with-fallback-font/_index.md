---
title: "एंड्रॉइड पर फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें"
linktitle: "प्रस्तुतियों को रेंडर करें"
type: docs
weight: 30
url: /hi/androidjava/render-presentation-with-fallback-font/
keywords:
- फॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखने के लिए चरण‑बद्ध Java कोड नमूनों का उपयोग करें।"
---
## **परिचय**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि फॉलबैक फ़ॉन्ट नियमों का संग्रह कैसे बनायें, उसकी नियमों को हटाकर या फॉलबैक फ़ॉन्ट जोड़ कर संशोधित करें, और `FontsManager.setFontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को असाइन करें।

जब फॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन कर दिया जाता है, तो नियमों को सहेजने, रेंडर करने और प्रस्तुति को परिवर्तित करने जैसी प्रक्रियाओं के दौरान लागू किया जाता है। इस उदाहरण में दिखाया गया है कि स्लाइड थंबनेल को रेंडर करते समय और उसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का उपयोग कैसे किया जाता है।

## **फॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

निम्न उदाहरण इन चरणों को शामिल करता है:

1. हम [फॉलबैक फ़ॉन्ट नियमों का संग्रह बनाते हैं](/slides/hi/androidjava/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फॉलबैक फ़ॉन्ट नियम और [addFallBackFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) दूसरे नियम में जोड़ते हैं।
3. नियमों के संग्रह को [getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड में सेट करें।
4. [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड के साथ हम प्रस्तुति को समान फ़ॉर्मेट में या किसी अन्य फ़ॉर्मेट में सहेज सकते हैं। फॉलबैक फ़ॉन्ट नियमों का संग्रह [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) को सेट करने के बाद, ये नियम प्रस्तुति पर किए जाने वाले सभी कार्यों के दौरान लागू होते हैं: सहेजें, रेंडर करें, परिवर्तित करें, आदि।

```java
// नियम संग्रह की नई इंस्टेंस बनाएं
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //लोडेड नियमों से फॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
    fallBackRule.remove("Tahoma");

    //और निर्दिष्ट रेंज के लिए नियमों को अपडेट करना
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//हम सूची से किसी भी मौजूदा नियम को भी हटा सकते हैं
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //उपयोग के लिए तैयार किए गए नियम सूची को असाइन करना
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // आरंभ किए गए नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और JPEG में सेव करना
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //छवि को JPEG प्रारूप में डिस्क पर सहेजें
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
एंड्रॉइड पर PPT और PPTX को JPG में बदलें के बारे में और पढ़ें: [Convert PPT and PPTX to JPG on Android](/slides/hi/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}