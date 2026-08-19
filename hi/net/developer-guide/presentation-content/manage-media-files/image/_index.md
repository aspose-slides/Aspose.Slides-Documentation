---
title: .NET में प्रस्तुतियों में इमेज प्रबंधन का अनुकूलन
linktitle: इमेज प्रबंधित करें
type: docs
weight: 10
url: /hi/net/image/
keywords:
- इमेज जोड़ें
- चित्र जोड़ें
- इमेज बदलें
- इमेज संग्रह
- चित्र फ़्रेम
- लिंक्ड इमेज
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- SVG से शैप्स
- बाहरी SVG रिसोर्सेज
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG इमेजेज़ को जोड़ना, पुन: उपयोग करना, लिंक करना, बदलना और प्रबंधित करना सीखें।"
---
## **परिचय**

Aspose.Slides for .NET कई तरीकों से इमेजेज़ के साथ काम करने के विकल्प प्रदान करता है, और प्रत्येक का अलग उद्देश्य है। आप एक इमेज को प्रेजेंटेशन में स्टोर कर सकते हैं, इसे एक पिक्चर फ्रेम में प्रदर्शित कर सकते हैं, स्लाइड बैकग्राउंड के रूप में उपयोग कर सकते हैं, बाहरी इमेज का लिंक दे सकते हैं, शेयर किए गए इमेज रिसोर्स को बदल सकते हैं, या SVG कंटेंट को एडिटेबल शेप्स में कनवर्ट कर सकते हैं।

यह लेख इमेज रिसोर्सेज़ और उनके प्रेजेंटेशन में उपयोग पर केंद्रित है। व्यक्तिगत पिक्चर फ्रेम में लागू किए गए क्रॉपिंग, ट्रांसपैरेंसी, इफ़ेक्ट्स, स्ट्रेचिंग और अन्य फॉर्मेटिंग के लिए देखें [Picture Frame](/slides/hi/net/picture-frame/)।

## **इमेज मॉडल को समझें**

निम्नलिखित API अवधारणाएँ निकटता से जुड़ी हुई हैं लेकिन परस्पर विनिमेय नहीं हैं:

- [presentation image collection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection/) प्रस्तुति द्वारा उपयोग किए गए इमेज रिसोर्सेज़ को संग्रहीत करता है। इमेज डेटा जोड़ने और एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) रिसोर्स प्राप्त करने के लिए [ImageCollection.AddImage](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/addimage/) का उपयोग करें।
- एक [picture frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) एक शैप है जो स्लाइड, लेआउट या मास्टर पर इमेज को प्रदर्शित करता है। स्लाइड पर इमेज रिसोर्स रखने के लिए [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) का उपयोग करें।
- स्लाइड बैकग्राउंड इमेज को स्लाइड फिल का हिस्सा बनाता है, न कि एक शैप के रूप में। इसलिए यह पिक्चर फ्रेम जैसा व्यवहार नहीं करता।
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/replaceimage/) इमेज रिसोर्स को बदलता है। यदि कई प्रस्तुति तत्व उस रिसोर्स का उपयोग कर रहे हैं, तो वे सभी प्रतिस्थापन का उपयोग करेंगे।
- SVG को शेप्स में बदलने से एडिटेबल स्लाइड शेप्स बनते हैं। परिवर्तन के बाद कंटेंट अब एक ही पिक्चर रिसोर्स के रूप में प्रबंधित नहीं रहता।

एक सामान्य वर्कफ़्लो इस प्रकार है: इमेज डेटा को इमेज कलेक्शन में जोड़ें, एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) प्राप्त करें, और फिर उस रिसोर्स को एक या अधिक पिक्चर फ्रेम या फिल में उपयोग करें।

## **एक एम्बेडेड इमेज जोड़ें**

स्थानीय इमेज डालने के लिए फ़ाइल पढ़ें, उसके डेटा को इमेज कलेक्शन में जोड़ें, और लौटाए गए `IPPImage` का उपयोग करके एक पिक्चर फ्रेम बनाएं।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

इस प्रकार जोड़ी गई इमेज प्रस्तुति में एम्बेडेड रहती है, इसलिए परिणामी फ़ाइल मूल इमेज फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से इमेज जोड़ें**

जब इमेज HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स को `HttpClient` से डाउनलोड करें, उन्हें प्रस्तुति इमेज कलेक्शन में जोड़ें, और स्थानीय इमेज की तरह ही लौटाए गए इमेज रिसोर्स का उपयोग करें।

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

दीर्घकालिक एप्लिकेशन में प्रत्येक अनुरोध के लिए नया इंस्टेंस बनाने के बजाय `HttpClient` को पुन: उपयोग करें। जब स्रोत विश्वसनीय न हो तो रिमोट URL, प्रतिक्रियाकी आकार, और कंटेंट टाइप की भी जाँच करें।

## **स्लाइड्स में इमेजेज़ को पुन: उपयोग करें**

यदि एक ही इमेज कई बार चाहिए, तो उसे प्रस्तुति में एक बार जोड़ें और अतिरिक्त पिक्चर फ्रेम बनाते समय लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का पुन: उपयोग करें। इससे समान स्रोत डेटा को बार-बार लोड करने से बचा जा सकता है और शेयर किए गए इमेज रिसोर्स और उसके उपयोगों के बीच का संबंध स्पष्ट हो जाता है।

कई स्लाइड्स पर स्वचालित रूप से दिखाई देना चाहिए ऐसी ग्राफ़िक्स, जैसे कंपनी लोगो, को प्रत्येक स्लाइड में समान शैप जोड़ने के बजाय [slide master](/slides/hi/net/slide-master/) या लेआउट पर पिक्चर फ्रेम रखने पर विचार करें।

## **इमेज को स्लाइड बैकग्राउंड के रूप में उपयोग करें**

बैकग्राउंड इमेज स्लाइड फिल को असाइन की जाती है; इसे पिक्चर-फ़्रेम शैप के रूप में नहीं जोड़ा जाता। यह तब उपयोगी होता है जब चित्र को स्लाइड बैकग्राउंड को कवर करना हो और उसे सामान्य स्लाइड ऑब्जेक्ट की तरह नहीं बदलना हो।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

अतिरिक्त बैकग्राउंड विकल्पों के लिए, जिसमें मास्टर और लेआउट बैकग्राउंड शामिल हैं, देखें [Presentation Background](/slides/hi/net/presentation-background/)।

## **एम्बेडेड इमेजेज़ और लिंक्ड इमेजेज़**

एम्बेडेड और लिंक्ड इमेजेज़ के पोर्टेबिलिटी और फ़ाइल‑साइज़ ट्रेड‑ऑफ़ अलग होते हैं:

- **Embedded image:** इमेज डेटा प्रस्तुति के अंदर संग्रहीत होता है। प्रस्तुति स्वयं‑समावेशी होती है, लेकिन फ़ाइल आकार में इमेज डेटा शामिल होता है।
- **Linked image:** प्रस्तुति बाहरी इमेज का पाथ या URL संग्रहीत करती है। इससे प्रस्तुति आकार कम हो सकता है, लेकिन बाहरी रिसोर्स का एक्सेस आवश्यक रहता है।

एक लिंक्ड पिक्चर को [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/linkpathlong/) के माध्यम से बाहरी पाथ या URL असाइन करके बनाया जा सकता है, बजाय इमेज डेटा को एम्बेड किए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

केवल तभी लिंक्ड इमेजेज़ प्रयोग करें जब डिप्लॉयमेंट वातावरण बाहरी रिसोर्स को विश्वसनीय रूप से एक्सेस कर सके। उन प्रस्तुतियों के लिए जो ऑफ़लाइन काम करनी हों या सिस्टम के बीच ले जानी हों, एम्बेडेड इमेजेज़ आमतौर पर सुरक्षित होते हैं।

## **SVG इमेजेज़ के साथ काम करें**

SVG एक वेक्टर फ़ॉर्मेट है, इसलिए यह आइकन, डायग्राम और अन्य ग्राफ़िक्स के लिए उपयोगी है जिन्हें रास्टर इमेजेज़ की तरह विवरण की हानि के बिना स्केल किया जा सके। Aspose.Slides SVG को इमेज रिसोर्स और एडिटेबल स्लाइड शेप्स के स्रोत दोनों के रूप में समर्थन करता है।

### **SVG को इमेज के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/svgimage/) बनाएं, उसे इमेज कलेक्शन में जोड़ें, और परिणामस्वरूप इमेज रिसोर्स को पिक्चर फ्रेम में रखें।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **बाहरी रिसोर्सेज़ वाले SVG फ़ाइलें**

एक SVG बाहरी इमेजेज़, स्टाइलशीट्स या फ़ॉन्ट्स को रेफ़र कर सकता है। ऐसे मामलों के लिए, [SvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/svgimage/) ऐसे कन्स्ट्रक्टर प्रदान करता है जो एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/) और बेस URI को स्वीकार करता है। रेज़ॉल्वर रिलेटिव URI को अनुमति प्राप्त एब्सोल्यूट URI में मैप कर सकता है और अनुरोधित रिसोर्स के लिए स्ट्रीम रिटर्न कर सकता है।

रेज़ॉल्वर बाहरी रिसोर्सेज़ को SVG प्रक्रिया के दौरान उपलब्ध कराता है, लेकिन यह SVG को स्वयं‑समावेशी दस्तावेज़ में पुनः लिखता नहीं है। यदि SVG को पोर्टेबल रखना है, तो आवश्यक रिसोर्सेज़ को स्वयं SVG में एम्बेड करें, जैसे लिंक्ड इमेजेज़ के लिए `data:` URI का प्रयोग करें।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रेज़ॉल्वर द्वारा एक्सेस किए जा सकने वाले स्कीम, फ़ाइल लोकेशन और होस्ट को प्रतिबंधित करें। नेटवर्क रेज़ॉल्वर को टाइमआउट, रिस्पॉन्स‑साइज़ लिमिट और कंटेंट वैलिडेशन भी लागू करना चाहिए।

### **SVG को एडिटेबल शेप्स में बदलें**

Aspose.Slides SVG को एडिटेबल स्लाइड शेप्स के समूह में बदल सकता है, जो संबंधित PowerPoint कमांड के समान है।

![PowerPoint Popup Menu](img_01_01.png)

परिवर्तन करने के लिए [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addgroupshape/) ओवरलोड का उपयोग करें जो एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) को स्वीकार करता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

SVG‑से‑शेप्स परिवर्तन तब उपयोग करें जब व्यक्तिगत वेक्टर एलिमेंट्स को PowerPoint शैप्स के रूप में संपादित करने की आवश्यकता हो। यदि SVG केवल प्रदर्शित करनी है, तो उसे इमेज के रूप में रखना सरल है और कई अलग‑अलग शैप्स बनाने से बचाता है।

## **मौजूद इमेज रिसोर्स को बदलें**

जब आप किसी मौजूदा इमेज रिसोर्स को बदलना चाहते हैं तो [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/replaceimage/) का उपयोग करें। यह विशेष रूप से साझा ग्राफ़िक्स जैसे लोगो के लिए उपयोगी है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

यदि कई पिक्चर फ्रेम, बैकग्राउंड, मास्टर या लेआउट एक ही इमेज रिसोर्स का उपयोग करते हैं, तो उस रिसोर्स को बदलने से सभी स्थानों पर अपडेट हो जाता है। यदि केवल एक पिक्चर फ्रेम को बदलना है, तो साझा रिसोर्स को बदलने के बजाय उस फ्रेम को अलग इमेज असाइन करें।

`ReplaceImage` ऐसे ओवरलोड भी प्रदान करता है जो एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) या अन्य [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को स्वीकार करते हैं।

## **व्यावहारिक इमेज प्रबंधन गाइडेंस**

### **प्रेजेंटेशन साइज़ को नियंत्रित करें**

बड़ी रास्टर इमेजेज़ प्रस्तुति को अनावश्यक रूप से बड़ा बना सकती हैं। लक्ष्यित डिस्प्ले साइज़ के अनुसार उपयुक्त डाइमेंशन वाली स्रोत इमेजेज़ उपयोग करें, संभव हो तो साझा इमेज रिसोर्सेज़ को पुन: उपयोग करें, और एक ही हाई‑रिज़ॉल्यूशन ग्राफ़िक की कई कॉपी एम्बेड करने से बचें।

रास्टर चित्र जो पहले से पिक्चर फ्रेम में रखे गए हैं, उनके लिए [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/) चयनित रेजोल्यूशन और क्रॉप सेटिंग के अनुसार इमेज डेटा को कम कर सकता है। यह पिक्चर‑फ़्रेम प्रोसेसिंग है, इमेज‑कलेक्शन मैनेजमेंट नहीं, इसलिए संबंधित फॉर्मैटिंग ऑपरेशन्स के लिए देखें [Picture Frame](/slides/hi/net/picture-frame/)।

### **एम्बेडेड और लिंक्ड कंटेंट के बीच चयन करें**

एम्बेडिंग प्रस्तुति को पोर्टेबल बनाता है क्योंकि सभी आवश्यक इमेज डेटा फ़ाइल के साथ चलता है। लिंकिंग फ़ाइल साइज़ को घटा सकता है, लेकिन यह बाहरी निर्भरता लाता है। लिंक केवल तभी उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **शेयर किए गए ब्रांडिंग का पुन: उपयोग करें**

बार‑बार उपयोग होने वाले लोगो, वाटरमार्क या सजावटी ग्राफ़िक्स के लिए एक इमेज रिसोर्स बनाकर उसे पुन: उपयोग करें। यदि ग्राफ़िक स्लाइड सामग्री के बजाय प्रस्तुति डिज़ाइन का हिस्सा है, तो उसे मास्टर या लेआउट पर रखें ताकि उपयुक्त स्लाइड्स द्वारा इनहेरीट किया जा सके।

### **SVG रिसोर्सेज़ को पोर्टेबल रखें**

एक सेल्फ‑कंटेनड SVG को ले जाना और लगातार रेंडर करना आसान होता है बनिस्पत ऐसी SVG के जो बाहरी फ़ाइलों या नेटवर्क रिसोर्सेज़ पर निर्भर हो। संभव हो तो SVG आयात करने से पहले आवश्यक रिसोर्सेज़ को एम्बेड करें। केवल तब SVG को शैप्स में बदलें जब व्यक्तिगत वेक्टर एलिमेंट्स को संपादित करने की आवश्यकता हो।

### **आधुनिक क्रॉस‑प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए .NET कोड के लिए, `System.Drawing.Image` या `Bitmap` पर निर्भर रहने के बजाय Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/net/aspose.slides/images/) API का उपयोग करें। माइग्रेशन गाइडेंस के लिए देखें [Modern API](/slides/hi/net/modern-api/)।

WMF और EMF को विशेष ध्यान देना पड़ता है। जब इन फ़ॉर्मेट्स को एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के माध्यम से पास किया जाता है, तो [ImageCollection.AddImage](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/addimage/) मेटाफाइल को PNG रास्टर प्रतिनिधित्व में बदल देता है। यदि मेटाफाइल डेटा को संरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम‑आधारित [ImageCollection.AddImage](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/addimage/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य प्रोडक्ट्स से EMF कंटेंट जेनरेट करना एक अलग इंटीग्रेशन वर्कफ़्लो है और इस लेख के दायरे से बाहर है।

## **FAQ**

**इमेज कलेक्शन और पिक्चर फ्रेम में क्या अंतर है?**

इमेज कलेक्शन पुन: उपयोग योग्य इमेज रिसोर्सेज़ को संग्रहीत करता है। पिक्चर फ्रेम एक स्लाइड शैप है जो उन रिसोर्सेज़ में से एक को प्रदर्शित करता है और क्रॉपिंग व इफ़ेक्ट्स जैसी पिक्चर‑स्पेसिफिक फ़ॉर्मेटिंग प्रदान करता है।

**सभी स्थानों पर एक ही लोगो बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से एक इमेज रिसोर्स के रूप में साझा किया गया है, तो उसे [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/replaceimage/) से बदलें। प्रेज़ेंटेशन‑व्यापी ब्रांडिंग के लिए लोगो को मास्टर या लेआउट पर रखने से डुप्लिकेट स्लाइड कंटेंट कम हो सकता है।

**लिंक्ड इमेज दूसरे कंप्यूटर पर क्यों नहीं दिखती?**

लिंक्ड पिक्चर अपने बाहरी फ़ाइल या URL पर निर्भर करता है। यदि वह रिसोर्स दूसरे कंप्यूटर से पहुँचा नहीं जा सकता, तो लिंक्ड इमेज उपलब्ध नहीं होगी। जब प्रस्तुति को स्वयं‑समावेशी होना आवश्यक हो, तो इमेज को एम्बेड करें।

**क्या डाली गई SVG को PowerPoint शैप्स के रूप में संपादित किया जा सकता है?**

हां। SVG को [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addgroupshape/) से बदलें; परिणामी समूह में एडिटेबल स्लाइड शैप्स होते हैं, न कि एक SVG पिक्चर।

**बहुत सारी इमेजेज़ वाली प्रस्तुतियों को छोटा कैसे रखें?**

शेयर किए गए इमेज रिसोर्सेज़ को पुन: उपयोग करें, अनावश्यक रूप से बड़े रास्टर स्रोतों से बचें, उपयुक्त समय पर रास्टर चित्रों को संकुचित करें, पुन: उपयोग योग्य ब्रांडिंग को मास्टर या लेआउट पर रखें, और लिंक्ड इमेजेज़ का उपयोग केवल तभी करें जब बाहरी निर्भरता स्वीकार्य हो।