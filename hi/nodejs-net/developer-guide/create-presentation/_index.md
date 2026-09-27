---
title: Node.js द्वारा .NET में प्रस्तुतियों का निर्माण
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/nodejs-net/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नई प्रस्तुति
- PowerPoint बनाएं
- PPTX बनाएं
- टेक्स्ट बॉक्स जोड़ें
- स्लाइड जोड़ें
- स्लाइड आकार
- वाइडस्क्रीन
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में Aspose.Slides for Node.js via .NET के साथ PowerPoint प्रस्तुतियों को बनाएं: टेक्स्ट बॉक्स और स्लाइडें जोड़ें, 16:9 स्लाइड आकार सेट करें, और परिणाम को PPTX के रूप में सहेजें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Node.js via .NET का उपयोग करके प्रस्तुति कैसे बनायीँ, उसकी पहली स्लाइड में टेक्स्ट बॉक्स कैसे जोड़ें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। यह यह भी दिखाता है कि अधिक स्लाइडें कैसे जोड़ें और प्रस्तुति को वाइडस्क्रीन (16:9) स्लाइडों में कैसे बदलें।

उदाहरणों को एक प्रोजेक्ट की आवश्यकता होती है जैसा कि [Installation](/slides/hi/nodejs-net/installation/) में वर्णित है। प्रत्येक उदाहरण को प्रोजेक्ट फ़ोल्डर में एक `.js` फ़ाइल के रूप में सहेजें और उस फ़ोल्डर से `node` के साथ चलाएँ, उदाहरण के लिए `node create-presentation.js`।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET के पास अपना कोई API संदर्भ नहीं है। यह Aspose.Slides for .NET API को camelCase नामों के साथ प्रतिबिंबित करता है, इसलिए इस लेख में API लिंक मिलती-जुलती कक्षाओं और सदस्यों की ओर ले जाती हैं [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/)।
{{% /alert %}}

## **टेक्स्ट बॉक्स के साथ प्रस्तुति बनाना**

एक प्रस्तुति बनाने और उसकी पहली स्लाइड पर टेक्स्ट बॉक्स रखने के लिए, इन चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ। एक नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
2. उस स्लाइड को [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह से प्राप्त करें। इस पैकेज में संग्रह `get(index)` के साथ पढ़े जाते हैं, और इंडेक्स 0 से शुरू होते हैं।
3. [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) मेथड से एक आयत जोड़ें और उसकी [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) को उसके [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) में सेट करें।
4. [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड और `SaveFormat.Pptx` मान का उपयोग करके प्रस्तुति को सहेजें।
5. प्रस्तुति को समर्थन देने वाले .NET संसाधनों को मुक्त करने के लिए `finally` ब्लॉक में `dispose` कॉल करें।

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // स्थिति (x, y) और आकार (चौड़ाई, ऊँचाई) पॉइंट्स में हैं।
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `new-presentation.pptx` को प्रोजेक्ट फ़ोल्डर में लिखती है। फ़ाइल में एक स्लाइड होती है जिसमें एक भरी हुई आयत होती है जिसकी ऊपर-बाएँ कोना स्लाइड के बाएँ और ऊपर किनारे से 50 पॉइंट दूर है। आयत की चौड़ाई 400 पॉइंट और ऊँचाई 100 पॉइंट है, और इसका टेक्स्ट केंद्रित है। एक पॉइंट 1/72 इंच होता है। लाइसेंस के बिना, Aspose.Slides स्लाइड में एक मूल्यांकन वाटरमार्क भी जोड़ता है; देखें [Licensing](/slides/hi/nodejs-net/licensing/)।

## **स्लाइडें जोड़ें**

एक नई प्रस्तुति में एक स्लाइड होती है। अधिक जोड़ने के लिए, `slides` संग्रह के [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) मेथड में एक लेआउट स्लाइड पास करें। [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) संग्रह की [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) मेथड एक दिए गए [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/) की पहली लेआउट लौटाती है।

निम्नलिखित उदाहरण ब्लैंक्स लेआउट के साथ दो स्लाइडें जोड़ता है:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `Slide count: 3` प्रिंट करती है और `three-slides.pptx` लिखती है। नई स्लाइडें पहली के बाद जोड़ी जाती हैं और उनमें कोई आकार नहीं होता। एक नई प्रस्तुति हमेशा एक Blank लेआउट रखती है, लेकिन यदि आप फ़ाइल से कोई प्रस्तुति खोलते हैं तो उसमें अनुरोधित प्रकार का लेआउट नहीं हो सकता; ऐसे में `getByType` `null` लौटाता है, इसलिए आगे पास करने से पहले परिणाम की जाँच करें।

## **स्लाइड आकार सेट करें**

एक नई प्रस्तुति 4:3 स्लाइडें उपयोग करती है जो 720 × 540 पॉइंट (10 × 7.5 इंच) होती हैं। वाइडस्क्रीन स्लाइडें बनाने के लिए, प्रस्तुति के [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) के साथ [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) मेथड को एक [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) मान और एक [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) मान के साथ कॉल करें। स्केल प्रकार Aspose.Slides को बताता है कि स्लाइडों में पहले से मौजूद आकारों के साथ क्या करना है; `DoNotScale` उन्हें जैसे का तैसा छोड़ देता है, जो उन प्रस्तुतियों के लिए सही विकल्प है जिनमें अभी कोई सामग्री नहीं है।

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `Slide size: 960 x 540 points` प्रिंट करती है, जो 13.33 × 7.5 इंच है, और `widescreen.pptx` लिखती है। `SlideSizeType.OnScreen16x9` का समान 16:9 अनुपात है लेकिन यह छोटा है: 720 × 405 पॉइंट।

## **अक्सर पूछे जाने वाले प्रश्न**

**स्थिति और आकार किन इकाइयों में मापे जाते हैं?**

पॉइंट्स में। एक इंच 72 पॉइंट्स है, इसलिए डिफ़ॉल्ट 4:3 स्लाइड 720 × 540 पॉइंट्स है, और 16:9 वाइडस्क्रीन स्लाइड 960 × 540 पॉइंट्स है।

**मैं नई प्रस्तुति को किन फ़ॉर्मैट्स में सहेज सकता हूँ?**

यह [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) एनोमरेशन का कोई भी मान हो सकता है, उदाहरण के लिए PowerPoint 97–2003 के लिए `SaveFormat.Ppt`, OpenDocument के लिए `SaveFormat.Odp`, या `SaveFormat.Pdf`। PDF आउटपुट के लिए, देखें [Convert PowerPoint to PDF](/slides/hi/nodejs-net/convert-powerpoint-to-pdf/)।

**सहेजी गई प्रस्तुति में "Evaluation only" टेक्स्ट क्यों दिखता है?**

लाइसेंस के बिना, Aspose.Slides सहेजी गई स्लाइडों में एक मूल्यांकन वाटरमार्क जोड़ता है। इसे हटाने के लिए [Licensing](/slides/hi/nodejs-net/licensing/) में वर्णित अनुसार एक लाइसेंस लागू करें।

**मुझे `dispose` क्यों कॉल करना चाहिए?**

`Presentation` ऑब्जेक्ट एक .NET ऑब्जेक्ट द्वारा समर्थित है जो मेमोरी और अन्य संसाधन रखता है। `dispose` कॉल करने से वे संसाधन तुरंत मुक्त हो जाते हैं जब आपको प्रस्तुति की आवश्यकता नहीं रहती, और `finally` ब्लॉक में कॉल करने से त्रुटि होने पर भी वे मुक्त हो जाते हैं।