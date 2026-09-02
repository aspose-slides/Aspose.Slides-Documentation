---
title: ".NET में प्रस्तुति आकारों के थंबनेल बनाएं"
linktitle: "आकार थंबनेल"
type: docs
weight: 70
url: /hi/net/create-shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- दृश्य सीमाएँ
- आकार सीमाएँ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स से उच्च-गुणवत्ता वाले आकार थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for .NET का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint का उपयोग करके प्रस्तुति फ़ाइलें खोलकर देखा जा सकता है। लेकिन कभी‑कभी, डेवलपर्स को आकार की छवियों को अलग से इमेज व्यूअर में देखना पड़ सकता है। ऐसे मामलों में, Aspose.Slides for .NET आपको स्लाइड आकारों की थंबनेल छवियां बनाने में मदद करता है। इस सुविधा का उपयोग कैसे करें, यह लेख में बताया गया है।
यह लेख विभिन्न तरीकों से स्लाइड थंबनेल जेनरेट करने के बारे में बताता है:

- स्लाइड के भीतर आकार थंबनेल बनाना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड आकार के लिए आकार थंबनेल बनाना।
- आकार की उपस्थिति की सीमाओं में आकार थंबनेल बनाना।

## **स्लाइड से आकार थंबनेल जेनरेट करें**
स्लाइड से आकार थंबनेल जेनरेट करने के लिए Aspose.Slides for .NET का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स का उपयोग करके प्राप्त करें।
3. संदर्भित स्लाइड की डिफ़ॉल्ट स्केल पर आकार थंबनेल छवि प्राप्त करें।
4. थंबनेल छवि को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

निम्नलिखित उदाहरण आकार थंबनेल जेनरेट करता है।

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फैक्टर थंबनेल जेनरेट करें**
किसी भी स्लाइड आकार का थंबनेल जेनरेट करने के लिए Aspose.Slides for .NET का उपयोग करें:

1. `Presentation` क्लास का एक उदाहरण बनाएँ।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स से प्राप्त करें।
3. संदर्भित स्लाइड की आकार सीमाओं के साथ थंबनेल छवि प्राप्त करें।
4. थंबनेल छवि को किसी भी इच्छित इमेज फॉर्मेट में सहेजें।

निम्नलिखित उदाहरण उपयोगकर्ता‑परिभाषित स्केलिंग फैक्टर के साथ थंबनेल जेनरेट करता है।

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X और Y अक्षों के साथ स्केलिंग।

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **बाउंड्स‑आधारित आकार उपस्थिति थंबनेल बनाएं**
यह विधि आकार के थंबनेल बनाने के लिए डेवलपर्स को आकार की उपस्थिति की सीमाओं में थंबनेल जेनरेट करने की अनुमति देती है। यह सभी आकार प्रभावों को ध्यान में रखता है। जेनरेट किया गया आकार थंबनेल स्लाइड सीमाओं द्वारा सीमित होता है। किसी भी स्लाइड आकार को उसकी उपस्थिति की सीमा में थंबनेल जेनरेट करने के लिए नीचे दिया गया नमूना कोड उपयोग करें:

1. `Presentation` क्लास का एक उदाहरण बनाएँ।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स से प्राप्त करें।
3. संदर्भित स्लाइड की आकार सीमाओं को उपस्थिति के रूप में लेकर थंबनेल छवि प्राप्त करें।
4. थंबनेल छवि को किसी भी इच्छित इमेज फॉर्मेट में सहेजें।

निम्नलिखित उदाहरण बाउंड्स‑आधारित आकार उपस्थिति थंबनेल बनाता है।

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X और Y अक्षों के साथ स्केलिंग।

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **आकार के वास्तविक विज़ुअल बाउंड्स प्राप्त करें**

[IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) की फ्रेम प्रॉपर्टीज़—`X`, `Y`, `Width`, और `Height`—प्रेजेंटेशन मॉडल में संग्रहित आयत का विवरण देती हैं। वास्तविक रूप से रेंडर किया गया कंटेंट उस फ्रेम से बाहर तक फैला हो सकता है या किसी अलग अक्ष‑संतुलित आयत में स्थित हो सकता है। घूर्णन, आउटलाइन, तीर की टोकरी, टेक्स्ट लेआउट और ओवरफ़्लो, जेनरेट किया गया SmartArt ज्योमेट्री, और अन्य रेंडरिंग इफ़ेक्ट्स सभी कब्ज़ा किए गए क्षेत्र को बदल सकते हैं।

[GetVisualBounds](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getvisualbounds/) का उपयोग करके आप बिना इमेज बनाए उस कब्ज़ा किए गए क्षेत्र की गणना कर सकते हैं। यह मेथड स्लाइड कॉर्डिनेट्स में एक [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) लौटाता है। लौटाया गया आयत स्लाइड तक क्लिप नहीं किया गया है, इसलिए जब कंटेंट स्लाइड मूल बिंदु से बाहर तक फैला होता है तो उसके कॉर्डिनेट्स नकारात्मक हो सकते हैं।

[GetVisualBounds](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getvisualbounds/) वर्तमान में [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस द्वारा घोषित नहीं है। इसलिए, स्लाइड के shape कलेक्शन से प्राप्त shape को एक इंटरफ़ेस वैल्यू के रूप में रखें और मेथड कॉल करते समय ही इसे कास्ट करें।

निम्नलिखित उदाहरण फ्रेम और विज़ुअल बाउंड्स को प्राप्त करता है और उनकी तुलना करता है:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

उसी [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) का उपयोग निकटवर्ती आकारों को उसके `Left`, `Right`, `Top`, या `Bottom` किनारे पर संरेखित करने, जेनरेट किए गए लेआउट में पर्याप्त स्थान आरक्षित करने, या अनुमत क्षेत्र के बाहर के कंटेंट का पता लगाने के लिए किया जा सकता है। विज़ुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, तीर, चित्र, घुमाए गए आकार और ग्रुप आकार के लिए उपयोगी होते हैं, जहाँ संग्रहीत फ्रेम पूर्ण रेंडर परिणाम का प्रतिनिधित्व नहीं कर सकता।

जब आपको लेआउट या वैलिडेशन के लिए कॉर्डिनेट्स चाहिए और बिटमैप नहीं चाहिए, तो [GetVisualBounds](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getvisualbounds/) का उपयोग करें। जब आपको आकार को रेंडर करना हो, तो [IShape.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getimage/) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/net/aspose.slides/shapethumbnailbounds/) के साथ, `ShapeThumbnailBounds.Shape` आकार सीमाओं, आउटलाइन सेटिंग्स सहित, से इमेज का आकार तय करता है, जबकि `ShapeThumbnailBounds.Appearance` आकार की उपस्थिति से आकार तय करता है और परिणाम को स्लाइड सीमाओं तक सीमित करता है। इसके विपरीत, [GetVisualBounds](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getvisualbounds/) केवल गणना किया गया आयत लौटाता है और उसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल सहेजते समय किन इमेज फॉर्मेट्स का उपयोग किया जा सकता है?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/), और अन्य। आकार को [वेक्टर SVG के रूप में निर्यात किया गया](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/) भी जा सकता है, shape की सामग्री को SVG के रूप में सहेजकर।

**थंबनेल रेंडर करते समय Shape और Appearance बाउंड्स में क्या अंतर है?**

`Shape` आकार की ज्यामिति का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/net/shape-effect/) (छाया, चमक आदि) को ध्यान में रखता है।

**यदि किसी आकार को छिपा हुआ चिह्नित किया गया है तो क्या होता है? क्या वह अभी भी थंबनेल के रूप में रेंडर होगा?**

एक छिपा हुआ आकार मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; छिपा फ़्लैग केवल स्लाइडशो डिस्प्ले को प्रभावित करता है, लेकिन आकार की इमेज जेनरेट करने से नहीं रोकेगा।

**क्या ग्रुप आकार, चार्ट, SmartArt और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**

हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/) (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartart/) शामिल हैं) के रूप में प्रतिनिधित्व किया गया है, उसे थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल किए गए फ़ॉन्ट्स टेक्स्ट आकारों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हाँ। अनपेक्षित फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचने के लिए आपको [आवश्यक फ़ॉन्ट्स प्रदान करने चाहिए](/slides/hi/net/custom-font/) (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करने चाहिए](/slides/hi/net/font-substitution/)).