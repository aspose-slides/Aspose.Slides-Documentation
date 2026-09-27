---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
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
description: "यहाँ से शुरू करें: Aspose.Slides for Node.js via Java स्थापित करें, पहला प्रस्तुति बनाएँ, और सामान्य कार्यों, API रेफ़रेंस और समर्थन के लिए गाइड खोजें।"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java एक लाइब्रेरी है जो Node.js एप्लिकेशन में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और रूपांतरित करने की सुविधा देती है, बिना Microsoft PowerPoint की आवश्यकता के।

यह PPT, PPTX, PPS, POT और ODP फाइलें लोड और सेव करती है, जिसमें मैक्रो-सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown तथा इमेजेज़ में निर्यात करती है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/hi/nodejs-java/installation/">इंस्टॉलेशन</a></li>
<li><a href="/slides/hi/nodejs-java/create-presentation/">अपना पहला प्रस्तुतिकरण बनाएं</a></li>
<li><a href="/slides/hi/nodejs-java/getting-started/">शुरुआत गाइड</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/hi/nodejs-java/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/nodejs-java/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/nodejs-java/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/hi/nodejs-java/open-presentation/">प्रस्तुतिकरण खोलें</a></li>
<li><a href="/slides/hi/nodejs-java/save-presentation/">प्रस्तुतिकरण सहेजें</a></li>
<li><a href="/slides/hi/nodejs-java/convert-powerpoint-to-pdf/">PDF में रूपांतरित करें</a></li>
<li><a href="/slides/hi/nodejs-java/convert-slide/">स्लाइड को छवियों के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/nodejs-java/manage-text/">टेक्स्ट और शैप्स संपादित करें</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/hi/nodejs-java/powerpoint-charts/">चार्ट्स</a></li>
<li><a href="/slides/hi/nodejs-java/powerpoint-animation/">एनीमेशन</a></li>
<li><a href="/slides/hi/nodejs-java/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/nodejs-java/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/nodejs-java/merge-presentation/">प्रस्तुतिकरण मिलाएँ</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/hi/nodejs-java/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API रेफ़रेंस</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/nodejs-java/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">डाउनलोड</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">मुफ़्त सपोर्ट फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">पेड सपोर्ट हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Node.js 20 या उससे नए संस्करण के साथ, पैकेज को Java Development Kit (JDK), Python और C++ बिल्ड टूलचेन की आवश्यकता होती है, क्योंकि npm इंस्टॉलेशन के दौरान इसका `java` ब्रिज कंपाइल करता है। प्रत्येक ऑपरेटिंग सिस्टम पर चरणों के लिए देखें [Installation](/slides/hi/nodejs-java/installation/)। फिर एक प्रोजेक्ट बनाएं और npm से पैकेज इंस्टॉल करें:

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

// Aspose.Slides एक Java वर्चुअल मशीन में चलता है जो Node.js को चलाते रहता है, इसलिए प्रक्रिया को स्पष्ट रूप से समाप्त करें।
process.exit(0);
```

इसे `node hello.js` के साथ चलाएँ। स्क्रिप्ट *hello.pptx* को एक स्लाइड के साथ सहेजती है जिसमें एक टेक्स्ट बॉक्स होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क होता है — देखें [Licensing](/slides/hi/nodejs-java/licensing/)। प्रस्तुतिकरण बनाने और उसे भरने के अधिक तरीकों के लिए देखें [Create Presentations](/slides/hi/nodejs-java/create-presentation/).