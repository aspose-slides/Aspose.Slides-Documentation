---
title: एन्ड्रॉइड पर प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5
type: docs
weight: 40
url: /hi/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करते हुए PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे परिवर्तित किया जाए। यह बुनियादी निर्यात, आकार एनीमेशन और स्लाइड ट्रांज़िशन के नियंत्रण, और टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG-आधारित आउटपुट की तुलना HTML5 आउटपुट से भी करता है।

## **PowerPoint को HTML5 में निर्यात करें**

निम्नलिखित उदाहरण कार्यशील निर्देशिका से एक प्रस्तुति लोड करता है और उसे HTML5 फ़ॉर्मेट में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण स्पष्ट रूप से एनीमेशन प्लेबैक को नियंत्रित करने का तरीका दिखाता है। इनपुट पथ को अपनी प्रस्तुति के पथ से बदलें।

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
HTML दस्तावेज़ के अलावा, निर्यात स्लाइड स्टाइलिंग, एनीमेशन, इफ़ेक्ट और नेविगेशन के लिए समर्थन करने वाली CSS और JavaScript फ़ाइलें भी लिखता है। आउटपुट को स्थानांतरित करने या प्रकाशित करने पर इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें। उत्पन्न पृष्ठ सार्वजनिक CDN से jQuery और Anime.js भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन काम नहीं करेंगे।
{{% /alert %}}

शेप एनीमेशन या स्लाइड ट्रांज़िशन को चलाए बिना निर्यात करने के लिए, [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) में [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को `false` पास करें। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम कर सकते हैं और दूसरे को निष्क्रिय रख सकते हैं। यह उदाहरण दोनों प्रकार के एनीमेशन को निष्क्रिय करके प्रस्तुति को निर्यात करता है।

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

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को HTML पृष्ठ के भीतर SVG के रूप में दर्शाया जाता है। निम्नलिखित उदाहरण इस रेंडरिंग दृष्टिकोण का उपयोग करके एक प्रस्तुति को HTML दस्तावेज़ में बदलता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

नीचे दिया गया सरल मार्कअप उत्पन्न पृष्ठ की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट उस सामग्री का प्रतिनिधित्व करता है और वास्तविक निर्यात आउटपुट नहीं है।

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
SVG-आधारित निर्यात PowerPoint के आकारों को व्यक्तिगत HTML तत्वों के रूप में उजागर नहीं करता। इस लेख में दर्शाए गए आकार-एनीमेशन और स्लाइड-ट्रांज़िशन विकल्पों की आवश्यकता होने पर HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

HTML5 निर्यात एक पृष्ठ बनाता है जिससे ब्राउज़र में प्रस्तुति स्लाइड्स को देखा और नेविगेट किया जा सके। यह उदाहरण दोनों [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम करता है ताकि निर्यातित स्लाइड व्यू स्रोत प्रस्तुति के इफ़ेक्ट्स चलाए जा सकें।

इन सेटिंग्स का प्रभाव देखने के लिए ऐसी प्रस्तुति का उपयोग करें जिसमें पहले से ही आकार एनीमेशन और स्लाइड ट्रांज़िशन हों। इन्हें सक्षम करने से उन स्लाइड्स में नए इफ़ेक्ट नहीं जुड़ते जिनमें पहले से कोई इफ़ेक्ट नहीं है। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को ब्राउज़र में खोलें और उसके समर्थन फ़ाइलें उपलब्ध रखें।

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

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में बदलें**

आप मौजूदा स्लाइड टिप्पणियों को HTML5 आउटपुट में शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ फीडबैक देख सकें। इस अनुभाग का उदाहरण स्रोत प्रस्तुति में टिप्पणियों के होने की अपेक्षा करता है, जैसा कि नीचे दिखाया गया है। यह उन टिप्पणियों को निर्यात करता है; नई टिप्पणियां नहीं बनाता।

![प्रस्तुति स्लाइड पर दो टिप्पणियां](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) की [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड में पास करें। प्रत्येक स्लाइड के दाहिनी ओर टिप्पणियों को रखने के लिए [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) एनेमरेशन से `Right` चुनने हेतु [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) का उपयोग करें।

निम्नलिखित उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। बिना टिप्पणियों वाली प्रस्तुति में प्रदर्शित करने के लिए कोई टिप्पणी पाठ नहीं होगा।

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

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियां](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक्स को बाहर करें**

मान लीजिए `hyperlinks.pptx` में लिंक किया गया टेक्स्ट है जिसमें `javascript:alert('Hello')` लक्ष्य और एक सामान्य `https://example.com/` लिंक है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर करने के लिए, [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) को `true` पास करें। डिफ़ॉल्ट रूप से यह `false` है, इसलिए इन लिंक को फ़िल्टर नहीं किया जाता जब तक आप विकल्प सक्षम नहीं करते।

निम्नलिखित उदाहरण कार्यशील निर्देशिका से प्रस्तुति को लोड करता है और इसे [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) का उपयोग करके निर्यात करता है:

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

निर्यातित फ़ाइल JavaScript हाइपरलिंक को हटाती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक को बरकरार रखती है। स्रोत प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प JavaScript हाइपरलिंक्स को फ़िल्टर करता है; यह सभी स्क्रिप्ट्स या अन्य सक्रिय सामग्री को नहीं हटाता, न ही CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनीमेशन के लिए स्क्रिप्ट्स शामिल होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन के चलने को नियंत्रित कर सकता/सकती हूँ?**  
हां, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियों का समर्थन किया जाता है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**  
हां, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और नोट्स और टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से (उदाहरण के लिए, स्लाइड के दाहिनी ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता/सकती हूँ?**  
हां, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) सेटिंग आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देती है। डिफ़ॉल्ट रूप से यह `false` है। [Exclude JavaScript Hyperlinks During Export](/slides/hi/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) देखें HTML5 निर्यात उदाहरण और फ़िल्टर के दायरे के लिए। यह सेटिंग HTML5 व्यूअर द्वारा नेविगेशन और एनीमेशन के लिए उपयोग किए गए JavaScript को नहीं हटाती।