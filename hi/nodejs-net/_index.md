---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /hi/nodejs-net/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुति प्रसंस्करण
- प्रस्तुति रूपांतरण
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for Node.js via .NET स्थापित करें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों, लाइसेंसिंग, API संदर्भ और समर्थन के लिए गाइड खोजें।"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Node.js के लिए Aspose.Slides, .NET के माध्यम से" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET एक लाइब्रेरी है जिससे Node.js अनुप्रयोगों में PowerPoint और OpenDocument प्रस्तुतियों को बनाया, पढ़ा, संपादित और रूपांतरित किया जा सकता है, बिना Microsoft PowerPoint या Office Automation के। यह edge‑js ब्रिज के माध्यम से Aspose.Slides for .NET चलाता है, इसलिए इसका JavaScript API .NET API को प्रतिबिंबित करता है, जिसमें camelCase सदस्य नाम होते हैं।

यह PPT, PPTX, PPS, POT और ODP फ़ाइलें लोड और सहेजता है, जिसमें मैक्रो‑सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, TIFF, Markdown और इमेजेज में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/hi/nodejs-net/installation/">स्थापना</a></li>
<li><a href="/slides/hi/nodejs-net/create-presentation/">अपनी पहली प्रस्तुति बनायें</a></li>
<li><a href="/slides/hi/nodejs-net/developer-guide/">डेवलपर गाइड</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/hi/nodejs-net/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/nodejs-net/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/hi/nodejs-net/open-presentation/">प्रस्तुति खोलें और सहेजें</a></li>
<li><a href="/slides/hi/nodejs-net/convert-powerpoint-to-pdf/">PDF में बदलें</a></li>
<li><a href="/slides/hi/nodejs-net/convert-slide/">स्लाइड को छवियों के रूप में प्रस्तुत करें</a></li>
<li><a href="/slides/hi/nodejs-net/manage-text/">पाठ संपादित करें</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">उत्पाद पृष्ठ</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">डाउनलोड</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">नि:शुल्क समर्थन फोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">सशुल्क समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

आपको Node.js 22 या 24 और .NET SDK 8 या उसके बाद का संस्करण चाहिए; Linux को कुछ सिस्टम पैकेजों की भी आवश्यकता होती है। [स्थापना](/slides/hi/nodejs-net/installation/) में उन्हें और परीक्षण किये गए प्लेटफ़ॉर्म की सूची है। एक प्रोजेक्ट बनायें, एक ओवरराइड जोड़ें जो npm को बताता है कि कौन‑सा edge‑js रिलीज़ इंस्टॉल करना है, और पैकेज इंस्टॉल करें:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

एक बार मशीन पर, लाइब्रेरी द्वारा आवश्यक .NET पैकेज रीस्टोर करें। `deps.csproj` फ़ाइल को [Restore the .NET Dependencies](/slides/hi/nodejs-net/installation/#restore-the-net-dependencies) से `deps` फ़ोल्डर में प्रोजेक्ट फ़ोल्डर के अंदर रखें, फिर चलाएँ:

```sh
dotnet restore deps/deps.csproj
```

इस कोड को *hello.js* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// नई प्रस्तुति में एक खाली स्लाइड होती है।
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // स्थिति और आकार पॉइंट्स (1/72 इंच) में हैं: x, y, चौड़ाई, ऊँचाई।
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // .NET ऑब्जेक्ट को रिलीज़ करें जो प्रस्तुति को बैक करता है।
    presentation.dispose();
}
```

प्रोजेक्ट फ़ोल्डर से इसे चलाएँ:

```sh
node hello.js
```

स्क्रिप्ट `Saved hello.pptx` प्रिंट करती है और *hello.pptx* को एक स्लाइड के साथ सहेजती है जिसमें एक आयत में यह टेक्स्ट होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क रहता है — देखें [लाइसेंसिंग](/slides/hi/nodejs-net/licensing/)। प्रस्तुति बनाने और भरने के अधिक तरीकों के लिए देखें [प्रस्तुति बनाएं](/slides/hi/nodejs-net/create-presentation/).