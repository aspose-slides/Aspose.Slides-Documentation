---
title: Aspose.Slides के लिए Node.js के माध्यम से Java
second_title: Aspose.Slides के लिए Node.js
type: docs
weight: 47
url: /hi/nodejs-java/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रसंस्करण
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for Node.js via Java स्थापित करें, पहली प्रस्तुति बनाएँ, और सामान्य कार्यों के लिए गाइड, API संदर्भ और समर्थन खोजें।"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java एक लाइब्रेरी है जो Node.js अनुप्रयोगों में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और परिवर्तित करने के लिए है, बिना Microsoft PowerPoint के।

यह PPT, PPTX, PPS, POT और ODP को लोड और सेव करता है, जिसमें मैक्रो-समर्थित और टेम्पलेट वेरिएंट शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और छवियों में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>शुरुआत</p>
<ul>
<li><a href="/slides/hi/nodejs-java/installation/">स्थापना</a></li>
<li><a href="/slides/hi/nodejs-java/create-presentation/">अपनी पहली प्रस्तुति बनाएं</a></li>
<li><a href="/slides/hi/nodejs-java/getting-started/">शुरुआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/nodejs-java/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/nodejs-java/evaluate-aspose-slides/">परीक्षण सीमाएँ</a></li>
<li><a href="/slides/hi/nodejs-java/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/nodejs-java/open-presentation/">एक प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/nodejs-java/save-presentation/">एक प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/nodejs-java/convert-powerpoint-to-pdf/">PDF में परिवर्तित करें</a></li>
<li><a href="/slides/hi/nodejs-java/convert-slide/">स्लाइड को छवि के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/nodejs-java/manage-text/">पाठ और आकृतियों को संपादित करें</a></li>
</ul>
<p>Slides कार्यप्रवाह</p>
<ul>
<li><a href="/slides/hi/nodejs-java/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/nodejs-java/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/nodejs-java/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/nodejs-java/presentation-design/">स्लाइड डिजाइन</a></li>
<li><a href="/slides/hi/nodejs-java/merge-presentation/">प्रस्तुतियाँ मिलाएँ</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/nodejs-java/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ &amp; समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/nodejs-java/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">उत्पाद पृष्ठ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">नि:शुल्क समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

Node.js 20 या बाद के संस्करण के अलावा, पैकेज को Java Development Kit (JDK), Python और एक C++ बिल्ड टूलचेन की आवश्यकता होती है, क्योंकि npm इंस्टॉलेशन के दौरान अपने `java` ब्रिज को कंपाइल करता है। प्रत्येक ऑपरेटिंग सिस्टम पर चरणों के लिए देखें [स्थापना](/slides/hi/nodejs-java/installation/). फिर एक प्रोजेक्ट बनाएं और npm से पैकेज इंस्टॉल करें:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

इस कोड को प्रोजेक्ट फ़ोल्डर में *hello.js* के रूप में सहेजें:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides एक Java वर्चुअल मशीन में चलता है जो Node.js को चलते रहने देता है, इसलिए प्रक्रिया को स्पष्ट रूप से समाप्त करें।
process.exit(0);
```

`node hello.js` के साथ चलाएँ। स्क्रिप्ट *hello.pptx* को एक स्लाइड के साथ सहेजती है जिसमें एक टेक्स्ट बॉक्स है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क होता है — देखें [लाइसेंसिंग](/slides/hi/nodejs-java/licensing/). अधिक तरीकों से प्रस्तुति बनाने और भरने के लिए देखें [प्रस्तुतियाँ बनाएं](/slides/hi/nodejs-java/create-presentation/).