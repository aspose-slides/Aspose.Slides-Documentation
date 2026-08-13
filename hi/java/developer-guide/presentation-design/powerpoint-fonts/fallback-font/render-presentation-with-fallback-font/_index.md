---
title: जावा में फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/java/render-presentation-with-fallback-font/
keywords:
- फॉलबैक फ़ॉन्ट
- PowerPoint रेंडर
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें - PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखने के लिए चरण-दर-चरण जावा कोड नमूने।"
---
## **अवलोकन**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे फॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए, नियमों को फॉलबैक फ़ॉन्ट हटाकर या जोड़कर संशोधित किया जाए, और `FontsManager.setFontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को असाइन किया जाए।

एक बार फॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाने पर, नियमों को सहेजने, रेंडर करने और प्रस्तुति को कनवर्ट करने जैसे कार्यों के दौरान लागू किया जाता है। उदाहरण दर्शाता है कि कैसे कॉन्फ़िगर किए गए नियमों का उपयोग स्लाइड थंबनेल रेंडर करने और उसे JPEG इमेज के रूप में सहेजने के समय किया जाता है।

## **फॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

1. हम [फ़ॉल्बैक फ़ॉन्ट नियमों का संग्रह बनाते हैं](/slides/hi/java/create-fallback-fonts-collection/).
2. [हटाएँ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) एक फॉलबैक फ़ॉन्ट नियम और [addFallBackFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को दूसरे नियम में जोड़ें.
3. नियम संग्रह को [getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) मेथड के द्वारा सेट करें.
4. [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके हम प्रस्तुति को उसी फ़ॉर्मेट में सहेज सकते हैं, या इसे किसी अन्य फ़ॉर्मेट में सहेज सकते हैं। फॉलबैक फ़ॉन्ट नियमों का संग्रह [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) को सेट करने के बाद, ये नियम प्रस्तुति पर किसी भी ऑपरेशन के दौरान लागू होते हैं: सहेजना, रेंडर करना, कनवर्ट करना, आदि.

```java
import com.aspose.slides.*;

// नियम संग्रह की नई इंस्टेंस बनाएं
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// कई नियम बनाएं
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //लोडेड नियमों से फॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
    fallBackRule.remove("Tahoma");

    // निर्दिष्ट रेंज के लिए नियमों को अपडेट करने के लिए
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//हम सूची से किसी भी मौजूदा नियम को हटा सकते हैं, रेंडर करने के लिये कम से कम एक नियम रख कर
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //उपयोग के लिए तैयार नियम सूची को असाइन कर रहे हैं
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // थंबनेल को रेंडर कर रहे हैं, प्रारम्भित नियम संग्रह का उपयोग करके और JPEG में सहेज रहे हैं
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
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
जावा में PPT और PPTX को JPG में कनवर्ट करने के बारे में अधिक पढ़ें। [जावा में PPT और PPTX को JPG में बदलें](/slides/hi/java/convert-powerpoint-to-jpg/).
{{% /alert %}}