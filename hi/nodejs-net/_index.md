---
title: Aspose.Slides के लिये Node.js via .NET
second_title: Aspose.Slides के लिये Node.js
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
description: "यहाँ से शुरू करें: Aspose.Slides for Node.js via .NET को स्थापित करें, पहला प्रस्तुतीकरण बनाएँ, और सामान्य कार्यों, लाइसेंसिंग, API संदर्भ और समर्थन के लिए मार्गदर्शिकाएँ खोजें।"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET एक लाइब्रेरी है जो Node.js अनुप्रयोगों में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और परिवर्तित करने की सुविधा देती है, बिना Microsoft PowerPoint या Office Automation के। यह edge‑js ब्रिज के माध्यम से Aspose.Slides for .NET को चलाता है, इसलिए इसका JavaScript API .NET API के समान है, जिसमें camelCase सदस्य नाम होते हैं।

यह PPT, PPTX, PPS, POT और ODP को लोड और सहेजता है, जिसमें मैक्रो‑सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, TIFF, Markdown और छवियों में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>शुरू करें</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/hi/nodejs-net/installation/">स्थापना</a></li>
<li><a href="/slides/hi/nodejs-net/create-presentation/">अपना पहला प्रस्तुतीकरण बनाएं</a></li>
<li><a href="/slides/hi/nodejs-net/developer-guide/">डेवलपर गाइड</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/hi/nodejs-net/evaluate-aspose-slides/">परीक्षण सीमाएँ</a></li>
<li><a href="/slides/hi/nodejs-net/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/hi/nodejs-net/open-presentation/">प्रस्तुतीकरण खोलें और सहेजें</a></li>
<li><a href="/slides/hi/nodejs-net/convert-powerpoint-to-pdf/">PDF में परिवर्तित करें</a></li>
<li><a href="/slides/hi/nodejs-net/convert-slide/">स्लाइडों को छवियों के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/nodejs-net/manage-text/">पाठ संपादित करें</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ एवं समर्थन</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hi/net/">.NET API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/nodejs-net/release-notes/">रिलीज नोट्स</a></li>
<li><a href="https://releases.aspose.com/slides/hi/nodejs-net/">डाउनलोड</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hi/11">निःशुल्क समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान किया गया समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपका पहला प्रस्तुतीकरण**

आपको Node.js 22 या 24 और .NET SDK 8 या उससे नए की आवश्यकता है; Linux को भी कुछ सिस्टम पैकेज चाहिए। [स्थापना](/slides/hi/nodejs-net/installation/) में उनकी सूची और परीक्षण किए गए प्लेटफ़ॉर्म दिए गए हैं। एक प्रोजेक्ट बनाएँ, एक ओवरराइड जोड़ें जो npm को बताता है कि कौन‑सा edge‑js रिलीज़ स्थापित किया जाए, और पैकेज स्थापित करें:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

प्रत्येक मशीन पर एक बार, लाइब्रेरी द्वारा निर्भर .NET पैकेज पुनर्स्थापित करें। `deps.csproj` फ़ाइल को [.NET निर्भरताओं को पुनर्स्थापित करें](/slides/hi/nodejs-net/installation/#restore-the-net-dependencies) से प्रोजेक्ट फ़ोल्डर के अंदर `deps` फ़ोल्डर में सहेजें, फिर चलाएँ:

```sh
dotnet restore deps/deps.csproj
```

इस कोड को *hello.js* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// एक नई प्रस्तुति में एक खाली स्लाइड शामिल है।
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // स्थिति और आकार पॉइंट्स (1/72 इंच) में हैं: x, y, चौड़ाई, ऊँचाई।
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // प्रेज़ेंटेशन को समर्थन देने वाले .NET ऑब्जेक्ट को रिलीज़ करें।
    presentation.dispose();
}
```

इसे प्रोजेक्ट फ़ोल्डर से चलाएँ:

```sh
node hello.js
```

स्क्रिप्ट `Saved hello.pptx` प्रदर्शित करती है और *hello.pptx* को एक स्लाइड के साथ सहेजती है जिसमें टेक्ट्स्ट वाला एक आयत होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क रहता है — देखें [लाइसेंसिंग](/slides/hi/nodejs-net/licensing/)। प्रस्तुतीकरण बनाने और भरने के अधिक तरीकों के लिए देखें [प्रस्तुतीकरण बनाएं](/slides/hi/nodejs-net/create-presentation/).