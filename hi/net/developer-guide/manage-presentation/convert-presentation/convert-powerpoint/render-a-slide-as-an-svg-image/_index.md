---
title: .NET में प्रस्तुति स्लाइड को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड को SVG में
type: docs
weight: 50
url: /hi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG में
- प्रेजेंटेशन को SVG में
- स्लाइड को SVG में
- PPT को SVG में
- PPTX को SVG में
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET में PowerPoint स्लाइड को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs, और इवेंट को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसिबिलिटी वर्कफ़्लो, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको नियंत्रण देता है कि टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्व कैसे लिखे जाएँ।

Use [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

फ़ाइलनाम में लूप इंडेक्स के बजाय [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) का उपयोग किया जाता है। आप एक स्लाइड व्यूअर या वेब पेज को केवल वह शैप चाहिए जब [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) के साथ व्यक्तिगत शैप भी निर्यात कर सकते हैं।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) निर्धारित करता है कि फ़्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर करना हो तो [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) को `true` सेट करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **एरोहेड्स पर लाइन‑एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में मार्कर इनसेट सेटिंग नहीं है जिससे निर्धारित किया जा सके कि लाइन एरोहेड के नीचे कहाँ रुकनी चाहिए। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यात की गई लाइन को छोटा करता है ताकि उसकी स्ट्रोक मार्कर के माध्यम से बाहर न निकले। स्ट्रोक को मूल एंडपॉइंट तक पूरी तरह खींचने के लिए [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) को `true` सेट करें। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है। स्लाइड पर लाइन अपनी स्थिति और लंबाई बनाए रखती है।

उदाहरण में त्रिकोण और हीरे के एरोहेड को 2‑पॉइंट और 10‑पॉइंट चौड़ी लाइनों पर दर्शाया गया है। यह वही स्लाइड दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प को बदलते हुए।

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

तुलना में 10‑पॉइंट लाइन पर त्रिकोणीय एरोहेड दिखाया गया है। क्रॉपिंग सक्षम होने पर नोक तेज़ होती है। क्रॉपिंग अक्षम होने पर स्ट्रोक मार्कर के ढाल वाले किनारों के माध्यम से निकलता है और फ़्लैट अंत बनता है।

![क्रॉपिंग सक्षम होने पर तेज़ नोक वाला बड़ा 10‑पॉइंट त्रिकोण और क्रॉपिंग अक्षम होने पर सपाट अंत](line-end-cropping.png)

उदाहरण की अन्य लाइनों में, 2‑पॉइंट त्रिकोण पर बाहर निकलती स्ट्रोक कम दिखाई देती है। भरपूर हीरा दोनों चौड़ाइयों पर स्ट्रोक के अंत को कवर करता है।

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

जब स्लाइड को SVG में निर्यात किया जाता है, तो आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट के रूप में रहे या वेक्टर ग्राफ़िक्स में बदला जाए, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। नीचे दिए विकल्प दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) को `true` सेट करने से सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखे जाते हैं। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और विभिन्न ब्राउज़रों में दृश्य परिणाम अधिक सुसंगत रहता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **बाहरी फ़ॉन्ट कैसे संभालें चुनें**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) उन फ़ॉन्ट्स के लिए [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है जो बाहरी रूप से लोड होते हैं। `AddLinksToFontFiles` चुनें ताकि अलग फ़ॉन्ट फ़ाइलों को संदर्भित किया जा सके, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में सम्मिलित हो, या `Vectorize` चुनें ताकि बाहरी फ़ॉन्ट वाले केवल टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर किया जाए। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की पुष्टि करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **एम्बेडेड इमेज का आकार घटाएँ**

एम्बेडेड चित्रों का रिज़ॉल्यूशन कम करने के लिए [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) का उपयोग करें, क्रॉप किए गए स्रोत क्षेत्रों को छोड़ने के लिए [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) का उपयोग करें, और JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करने के लिए [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) का उपयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज फ़िडेलिटी या रखे गए इमेज डेटा के लिए कीमत लेती हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को नियंत्रित करें**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) SVG निर्यात के दौरान मेटाफाइल को रास्टर करने के लिए निचली रिज़ॉल्यूशन सीमा निर्धारित करता है। इसका उपयोग EMF या WMF इमेज रास्टर करने पर विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए करें। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता और न ही स्लाइड पर प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनने के लिए मजबूर करता है।

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), which contains an EMF image with closely spaced diagonal lines. The following example exports its first slide at three rasterization resolutions through [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). All other export settings remain identical so that the results can be compared.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

आउटपुट में, EMF प्रत्येक SVG में एक एंबेडेड PNG बन गया। नीचे दिए माप प्रदान किए गए प्रेज़ेंटेशन के लिए हैं; ये DPI को पिक्सेल आयामों में बदलने के लिए सामान्य सूत्र नहीं हैं।

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीچے की तुलना में एक ही एंबेडेड रास्टर का वही क्षेत्र समान बड़े डिस्प्ले आकार पर दिखाया गया है। तिरछी लाइनों में 72 DPI पर पिक्सेलेशन दिखता है और उच्च रिज़ॉल्यूशन पर किनारे स्मूथ होते हैं, जबकि SVG फ़ाइल का आकार बढ़ता है। मान बढ़ाने से हर विवरण जरूरी नहीं कि सुधरे या हर निर्यात की गई छवि बदले।

![विभिन्न DPI (72, 150, 300) पर तिरछी‑लाइन विवरण का बड़ा प्रदर्शन](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) इमेज रिज़ॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छिपा सकता है। [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, न कि मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **शैप्स और टेक्स्ट को स्थायी IDs असाइन करें**

प्रत्येक SVG शैप के लिए [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करके [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) मान सेट करने के लिए [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) लागू करें। इन दोनों में से किसी भी कंट्रोलर को [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें।

निम्न कंट्रोलर [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) का उपयोग करता है, जो शैप की जीवन अवधि के दौरान स्थिर रहता है, और उसके टेक्स्ट स्पैन के लिए पुनरावृत्त काउंटर का उपयोग करता है। यह उत्पन्न IDs को अपरिवर्तित प्रेज़ेंटेशन के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **SVG इवेंट हैंडलर्स जोड़ें**

एक [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) में, निर्यातित शैप में जावा स्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) को [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें और पेज या SVG दस्तावेज़ में वह जावा स्क्रिप्ट फ़ंक्शन परिभाषित करें जो परिणाम को होस्ट करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

होस्ट पेज हैंडलर द्वारा संदर्भित जावा स्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, एक्सेसिबिलिटी सुधार, और अन्य इंटरैक्टिव SVG वर्कफ़्लो संभव होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मुझे [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) की बजाय [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) का उपयोग करना चाहिए?**

जब सभी टेक्स्ट को फ़ॉन्ट्स से स्वतंत्र होना चाहिए, तब [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) का उपयोग करें। जब केवल बाहरी फ़ॉन्ट वाले टेक्स्ट को ग्राफ़िक्स में बदला जाना हो, तब [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) का उपयोग करें।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

पहले एंबेडेड चित्रों को संपीड़ित करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण लिंक्ड फ़ॉन्ट फ़ाइलें सर्व कर सके तो उन्हें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक की गुणवत्ता और आकार के अलग‑अलग ट्रेड‑ऑफ़ होते हैं।

**क्या निर्यातित SVG तत्वों को निर्यात के बाद संशोधित किया जा सकता है?**

हाँ। फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलती‑जुलती SVG तत्वों का चयन करें।