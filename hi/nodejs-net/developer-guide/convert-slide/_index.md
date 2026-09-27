---
title: Node.js के माध्यम से .NET में प्रस्तुति स्लाइड को छवियों में बदलें
linktitle: स्लाइड से छवि
type: docs
weight: 40
url: /hi/nodejs-net/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड से छवि
- स्लाइड से PNG
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड रेंडर करें
- स्लाइड थंबनेल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PPTX, PPT, और ODP प्रस्तुतियों से स्लाइड को PNG छवियों के रूप में JavaScript में Aspose.Slides for Node.js via .NET के साथ रेंडर करें, स्केल कारक या पिक्सेल में वास्तविक आकार पर।"
---
## **समीक्षा**

Aspose.Slides for Node.js via .NET PowerPoint और OpenDocument प्रस्तुतियों की स्लाइडों को छवियों के रूप में रेंडर करता है, उदाहरण के लिए वेब पेज पर स्लाइड पूर्वावलोकन दिखाने के लिए। यह लेख छवि का आकार चुनने के दो तरीके दर्शाता है: स्लाइड आकार के सापेक्ष एक स्केल कारक, और पिक्सेल में सटीक आकार। दोनों उदाहरण PNG फ़ाइलें सहेजते हैं।

उदाहरणों को आपके द्वारा [स्थापना](/slides/hi/nodejs-net/installation/) में सेट किए गये प्रोजेक्ट फ़ोल्डर में `sample.pptx` नामक प्रस्तुति की अपेक्षा है। कोई भी PowerPoint प्रस्तुति काम करेगी। प्रत्येक उदाहरण को प्रोजेक्ट फ़ोल्डर में एक `.js` फ़ाइल के रूप में सहेजें और `node` के साथ उसी फ़ोल्डर से चलाएँ।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET के पास अपना कोई API संदर्भ नहीं है। यह Aspose.Slides for .NET API को camelCase नामों के साथ प्रतिबिंबित करता है, इसलिए इस लेख में API लिंक [Aspose.Slides for .NET API संदर्भ](https://reference.aspose.com/slides/net/) में मिलते-जुलते क्लास और मेंबर्स की ओर ले जाते हैं।
{{% /alert %}}

एक स्लाइड को छवि में परिवर्तित करने के लिए, इन चरणों का पालन करें:

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) कन्स्ट्रक्टर से खोलें।
2. `get(index)` के साथ [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह से एक स्लाइड प्राप्त करें। इंडेक्स 0 से शुरू होते हैं।
3. स्लाइड को `getImageWithScale` या `getImageWithImageSize` के साथ रेंडर करें। .NET API संदर्भ में, दोनों [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) के ओवरलोड हैं। वे एक छवि ऑब्जेक्ट लौटाते हैं जो [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) के अनुरूप होता है।
4. छवि को उसके [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) मेथड और एक [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) मान के साथ सहेजें, और फिर उसका `dispose` मेथड कॉल करें।

## **प्रत्येक स्लाइड को PNG छवि में परिवर्तित करें**

`getImageWithScale` एक क्षैतिज और ऊर्ध्वाधर स्केल कारक लेता है। स्केल 1 पर, स्लाइड का एक पॉइंट छवि का एक पिक्सेल बन जाता है। निम्न उदाहरण प्रत्येक स्लाइड को स्केल 2 पर रेंडर करता है:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// स्केल 1 पर एक पॉइंट में एक पिक्सेल रेंडर होता है; 2 पर चौड़ाई और ऊँचाई दोगुनी हो जाती है।
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट प्रत्येक स्लाइड के लिए एक फ़ाइल लिखती है, `slide_1.png`, `slide_2.png`, आदि, जो 1 से क्रमांकित होते हैं। 16:9 प्रस्तुति में 960 × 540 पॉइंट स्लाइडों के लिए, प्रत्येक छवि 1920 × 1080 पिक्सेल होती है। छुपी हुई स्लाइडें भी रेंडर होती हैं; उन्हें छोड़ने के लिए स्लाइड के [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) प्रॉपर्टी की जाँच करें। प्रत्येक छवि को उसके स्वयं के `finally` ब्लॉक में डिस्पोज़ किया जाता है, जो अगली स्लाइड रेंडर होने से पहले इसे रिलीज़ कर देता है। लाइसेंस के बिना, छवियों पर मूल्यांकन वॉटरमार्क भी दिखता है; देखें [लाइसेंसिंग](/slides/hi/nodejs-net/licensing/)।

## **निर्दिष्ट आकार की छवि में एक स्लाइड को परिवर्तित करें**

`getImageWithImageSize` एक ऑब्जेक्ट लेता है जिसमें पिक्सेल में `width` और `height` होते हैं। निम्न उदाहरण पहली स्लाइड को 1280 पिक्सेल चौड़ाई के साथ रेंडर करता है और ऊँचाई को स्लाइड आकार से गणना करता है, ताकि छवि स्लाइड के आकार अनुपात को बनाए रखे:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) प्रॉपर्टी स्लाइड की चौड़ाई और ऊँचाई पॉइंट में लौटाती है। 16:9 प्रस्तुति के लिए, स्क्रिप्ट `Saved a 1280 x 720 image` प्रिंट करती है और `slide_1_1280px.png` लिखती है; 4:3 प्रस्तुति के लिए, छवि 1280 × 960 पिक्सेल होती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**`getImage` बिना तर्कों के जो छवि है वह इतनी छोटी क्यों है?**  
बिना आर्गुमेंट के, `getImage` स्लाइड को उसके आकार के 20 % पॉइंट में रेंडर करता है, इसलिए 960 × 540 पॉइंट स्लाइड 192 × 108 पिक्सेल छवि बन जाती है। आकार चुनने के लिए `getImageWithScale` या `getImageWithImageSize` का उपयोग करें।

**JPEG या अन्य छवि स्वरूपों को कैसे सहेजूं?**  
छवि के `save` मेथड को कोई अन्य `ImageFormat` मान पास करें, उदाहरण के लिए `image.save("slide_1.jpg", ImageFormat.Jpeg)`। स्वरूप `ImageFormat` मान से आता है, फ़ाइल एक्सटेंशन से नहीं, इसलिए दोनों को संगत रखें।

**Linux पर छवियों में टेक्स्ट अलग क्यों दिखता है?**  
Aspose.Slides केवल उन फ़ॉन्ट्स का उपयोग कर सकता है जो उस मशीन पर स्थापित हैं जो स्लाइडें रेंडर करती है। जब प्रस्तुति कोई फ़ॉन्ट उपयोग करती है जो अनुपलब्ध है, जैसे कि सामान्य Linux सर्वर पर Calibri, तो Aspose.Slides उसकी जगह स्थापित फ़ॉन्ट का उपयोग करता है, जिससे टेक्स्ट का रूप और लाइन ब्रेक बदल सकते हैं। वही छवियाँ प्राप्त करने के लिए वह फ़ॉन्ट स्थापित करें जो आपकी प्रस्तुतियों में उपयोग होते हैं, जैसे Windows पर।

**`getThumbnailWithImageSize` TypeError के साथ क्यों विफल हो रहा है?**  
पैकेज README `getThumbnailWithImageSize` का उपयोग करता है, लेकिन पैकेज में कोई `getThumbnail` मेथड नहीं है। इसके बजाय `getImageWithImageSize` का उपयोग करें; यह वही `{ width, height }` आर्गुमेंट लेता है।