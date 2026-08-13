---
title: एन्ड्रॉइड पर फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/androidjava/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint को रेंडर करें
- प्रस्तुति को रेंडर करें
- स्लाइड को रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में पाठ को सुसंगत रखें, क्रमिक जावा कोड उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की सुविधा देता है। यह लेख दिखाता है कि फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कैसे बनाया जाए, नियमों को हटाकर या नए फ़ॉलबैक फ़ॉन्ट जोड़कर कैसे संशोधित किया जाए, और `FontsManager.setFontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को कैसे असाइन किया जाए।

एक बार फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाने पर, ये नियम सहेजने, रेंडर करने और प्रस्तुति को कनवर्ट करने जैसी कार्यों के दौरान लागू होते हैं। यह उदाहरण दिखाता है कि स्लाइड थंबनेल को रेंडर करते समय और उसे JPEG इमेज के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाता है।

## **फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करें**

निम्न उदाहरण इन चरणों को शामिल करता है:

1. हम [create fallback font rules collection](/slides/hi/androidjava/create-fallback-fonts-collection/) बनाते हैं।
1. [Remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फ़ॉलबैक फ़ॉन्ट नियम और [addFallBackFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को किसी अन्य नियम में जोड़ते हैं।
1. नियमों के संग्रह को [getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड को असाइन करते हैं।
1. [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके हम प्रस्तुति को उसी फॉर्मेट में या किसी अन्य फॉर्मेट में सहेज सकते हैं। जब फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह `FontsManager` को सेट किया जाता है, तो ये नियम प्रस्तुति पर किए जाने वाले सभी ऑपरेशनों में लागू होते हैं: सहेजना, रेंडर करना, कनवर्ट करना आदि।

```java
import com.aspose.slides.*;

// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Trying to remove FallBack font "Tahoma" from loaded rules
    fallBackRule.remove("Tahoma");

    // And to update of rules for specified range
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Also we can remove any existing rules from list, keeping at least one rule to render with
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Assigning a prepared rules list for using
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Save the image to disk in JPEG format
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
और अधिक पढ़ें: [Convert PPT and PPTX to JPG on Android](/slides/hi/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}