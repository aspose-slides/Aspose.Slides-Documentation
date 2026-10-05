---
title: जावा में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
type: docs
weight: 40
url: /hi/java/export-to-html5/
keywords:
- PowerPoint को HTML5 में
- OpenDocument को HTML5 में
- प्रस्तुति को HTML5 में
- स्लाइड को HTML5 में
- PPT को HTML5 में
- PPTX को HTML5 में
- ODP को HTML5 में
- PPT को HTML5 के रूप में सहेजें
- PPTX को HTML5 के रूप में सहेजें
- ODP को HTML5 के रूप में सहेजें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। फ़ॉर्मेटिंग, एनिमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह बुनियादी निर्यात, आकार (shape) एनिमेशन और स्लाइड ट्रांज़िशन के नियंत्रण, और टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG‑आधारित आउटपुट की तुलना भी HTML5 आउटपुट से करता है।

## **PowerPoint को HTML5 में निर्यात करना**

निम्न उदाहरण कार्य निर्देशिका से प्रस्तुति को लोड करता है और उसे HTML5 प्रारूप में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण दिखाता है कि एनिमेशन प्लेबैक को स्पष्ट रूप से कैसे नियंत्रित करें। इनपुट पथ को अपनी प्रस्तुति के पथ से बदलें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML दस्तावेज़ के अतिरिक्त, निर्यात स्लाइड शैलीकरण, एनिमेशन, प्रभाव और नेविगेशन के लिए सहायक CSS और JavaScript फ़ाइलें लिखता है। इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें जब आप आउटपुट को स्थानांतरित या प्रकाशित करें। उत्पन्न पृष्ठ jQuery और Anime.js को सार्वजनिक CDN से भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनिमेशन काम नहीं करेंगे।
{{% /alert %}}

शेपी एनिमेशन या स्लाइड ट्रांज़िशन चलाए बिना निर्यात करने के लिए, [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) में `false` पास करें, जो [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) में मौजूद हैं। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम कर सकते हैं जबकि दूसरे को अक्षम कर सकते हैं। उदाहरण प्रस्तुति को दोनों प्रकार के एनिमेशन अक्षम करके निर्यात करता है।

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint को HTML में निर्यात करना**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को एक HTML पृष्ठ के अंदर SVG के रूप में दर्शाया जाता है। निम्न उदाहरण इस रेंडरिंग दृष्टिकोण का उपयोग करके एक प्रस्तुति को HTML दस्तावेज़ में बदलता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

नीचे दिया गया सरलित मार्कअप उत्पन्न पृष्ठ की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट वह सामग्री दर्शाता है और यह वास्तविक निर्यात आउटपुट नहीं है।

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG‑आधारित निर्यात PowerPoint आकारों को व्यक्तिगत HTML तत्वों के रूप में उजागर नहीं करता। जब आपको इस लेख में दिखाए गए आकार‑एनिमेशन और स्लाइड‑ट्रांज़िशन विकल्पों की आवश्यकता हो तो HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड दृश्य में निर्यात करना**

HTML5 निर्यात ब्राउज़र में प्रस्तुति स्लाइड्स को देखने और नेविगेट करने के लिए एक पृष्ठ बनाता है। यह उदाहरण दोनों [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम करता है ताकि निर्यातित स्लाइड दृश्य स्रोत प्रस्तुति से प्रभाव चला सके।

ऐसी प्रस्तुति उपयोग करें जिसमें पहले से ही आकार एनिमेशन और स्लाइड ट्रांज़िशन हों, ताकि इन सेटिंग्स का प्रभाव देख सकें। इन्हें सक्षम करने से उन स्लाइड्स में नया प्रभाव नहीं जुड़ता जिनमें कोई प्रभाव नहीं था। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को ब्राउज़र में खोलें और इसके सहायक फ़ाइलों को उपलब्ध रखें।

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **टिप्पणियों के साथ HTML5 दस्तावेज़ में प्रस्तुति बदलना**

आप HTML5 आउटपुट में मौजूदा स्लाइड टिप्पणियों को शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ प्रतिक्रिया देख सकें। इस अनुभाग का उदाहरण मानता है कि स्रोत प्रस्तुति में टिप्पणियाँ हैं, जैसा कि नीचे दिखाया गया है। यह टिप्पणियों को निर्यात करता है; नई टिप्पणियों का निर्माण नहीं करता।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड में पास करें, जो [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) से जुड़ा है। प्रत्येक स्लाइड के दाएँ तरफ टिप्पणियों को रखने के लिए [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) एनोमरेशन से `Right` चुनने हेतु [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) का उपयोग करें।

निम्न उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। बिना टिप्पणियों वाली प्रस्तुति में कोई टिप्पणी टेक्स्ट नहीं दिखेगा।

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

नीचे दिखाया गया चित्र निर्यातित HTML5 दस्तावेज़ को दर्शाता है जिसमें टिप्पणियाँ स्लाइड के बगल में दिखाई देती हैं।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखना**

मान लीजिए `hyperlinks.pptx` में एक लिंक्ड टेक्स्ट है जिसका लक्ष्य `javascript:alert('Hello')` है और एक सामान्य `https://example.com/` लिंक है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखने के लिए, [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) में `true` पास करें। डिफ़ॉल्ट रूप से यह `false` है, इसलिए इन लिंक को तब तक फ़िल्टर नहीं किया जाता जब तक आप विकल्प को सक्रिय नहीं करते।

निम्न उदाहरण कार्य निर्देशिका से प्रस्तुति को लोड करता है और इसे [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) का उपयोग करके निर्यात करता है:

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

निर्यातित फ़ाइल JavaScript हाइपरलिंक को हटा देती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बनाए रखती है। स्रोत प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प JavaScript हाइपरलिंक को फ़िल्टर करता है; यह सभी स्क्रिप्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में स्लाइड नेविगेशन और एनिमेशन के लिए अभी भी स्क्रिप्ट शामिल होती हैं।

## **FAQ**

**क्या मैं HTML5 में ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़िशन के चलने को नियंत्रित कर सकता हूँ?**

हाँ, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियों का समर्थन है, और उन्हें स्लाइड के सापेक्ष कहाँ रख सकते हैं?**

हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और स्लाइड के दाएँ (उदाहरण के लिये) जैसी जगह पर [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript चालू करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) सेटिंग आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देती है। डिफ़ॉल्ट `false` है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखने के उदाहरण के लिए देखें [Exclude JavaScript Hyperlinks During Export](/slides/hi/java/export-to-html5/#exclude-javascript-hyperlinks-during-export)। यह सेटिंग HTML5 व्यूअर द्वारा नेविगेशन और एनिमेशन के लिए उपयोग किए जाने वाले JavaScript को नहीं हटाती।