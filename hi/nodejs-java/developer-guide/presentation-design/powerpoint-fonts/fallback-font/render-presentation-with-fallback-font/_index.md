---
title: फॉलबैक फ़ॉन्ट के साथ जावास्क्रिप्ट में प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/nodejs-java/render-presentation-with-fallback-font/
keywords:
- फॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में फॉलबैक फ़ॉन्ट के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण जावास्क्रिप्ट कोड नमूनों के साथ।"
---
## **परिचय**

Aspose.Slides आपको फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की सुविधा देता है। यह लेख बताता है कि फ़ॉलबैक फ़ॉन्ट नियम संग्रह कैसे बनाया जाए, नियमों को फ़ॉलबैक फ़ॉन्ट हटाकर या जोड़कर कैसे संशोधित किया जाए, और `FontsManager.setFontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को कैसे असाइन किया जाए।

जब फ़ॉलबैक फ़ॉन्ट नियम संग्रह को प्रस्तुति के `FontsManager` को असाइन कर दिया जाता है, तो यह नियम सहेजने, रेंडर करने और प्रस्तुति को परिवर्तित करने जैसी क्रियाओं के दौरान लागू होते हैं। उदाहरण यह दर्शाता है कि स्लाइड थंबनेल को रेंडर करते समय और इसे PNG इमेज के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाए।

## **फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

निम्नलिखित उदाहरण में ये चरण शामिल हैं:

1. हम [फ़ॉलबैक फ़ॉन्ट नियम संग्रह बनाते हैं](/slides/hi/nodejs-java/create-fallback-fonts-collection/).
2. [हटाएँ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फ़ॉलबैक फ़ॉन्ट नियम और [addFallBackFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को दूसरे नियम में जोड़ें.
3. नियम संग्रह को [getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड में सेट करें.
4. हम [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके प्रस्तुति को उसी फ़ॉर्मेट में सहेज सकते हैं, या इसे किसी अन्य फ़ॉर्मेट में सहेज सकते हैं। फ़ॉलबैक फ़ॉन्ट नियम संग्रह को [FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontsManager) में सेट करने के बाद, ये नियम प्रस्तुति पर किए जाने वाले किसी भी कार्य—सहेजना, रेंडर करना, परिवर्तित करना, आदि—के दौरान लागू होते हैं।

```javascript
// नियम संग्रह का नया उदाहरण बनाएं
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// कई नियम बनाएं
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // लोडेड नियमों से फॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
    fallBackRule.remove("Tahoma");
    // और निर्दिष्ट रेंज के लिए नियमों को अपडेट करने के लिए
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// हम सूची से किसी भी मौजूदा नियम को हटा भी सकते हैं
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // उपयोग के लिए तैयार किए गए नियम सूची को असाइन करना
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // इनिशियलाइज़्ड नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और JPEG में सहेजना
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // इमेज को डिस्क पर JPEG फॉर्मेट में सहेजें
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
जावास्क्रिप्ट में PPT और PPTX को JPG में बदलने के बारे में अधिक पढ़ें: [PPT और PPTX को जावास्क्रिप्ट में JPG में बदलें](/slides/hi/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}