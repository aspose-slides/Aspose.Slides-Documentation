---
title: .NET में प्रेज़ेंटेशन स्लाइड्स को SVG इमेजेज़ के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेज़ेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET में PowerPoint स्लाइड्स को SVG इमेजेज़ के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML‑आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर, पहुँच कार्यप्रवाह, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्वों को कैसे लिखा जाए, नियंत्रित करने देता है।

जब निर्यात किया गया SVG संक्षिप्त, ब्राउज़र में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) का उपयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं, एक स्लाइड चुनें, और उसे स्ट्रीम में लिखें। निम्न उदाहरण प्रस्तुति में प्रत्येक स्लाइड को अलग SVG फ़ाइल के रूप में निर्यात करता है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

फ़ाइलनाम [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) का उपयोग लूप इंडेक्स के बजाय करता है। आप केवल तब किसी एकल आकार को निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पृष्ठ को केवल वही आकार चाहिए, इसके लिए [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) का उपयोग करें।

## **SVG आउटपुट कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को सम्मिलित करता है, और [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) निर्धारित करता है कि फ्रेम रोटेशन लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तब [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) को `true` पर सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

जब स्लाइड को SVG में निर्यात किया जाता है, तो आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट के रूप में रहे या वेक्टर ग्राफ़िक्स में बदल दिया जाए, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। निम्न विकल्प आपको निर्यातित SVG में दृश्य निरंतरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) को `true` पर सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। यह फ़ॉन्ट निर्भरताओं को समाप्त करता है और विभिन्न ब्राउज़रों में दृश्य परिणाम को अधिक निरंतर बनाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट कैसे संभाले जाएँ चुनें**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) बाहरी रूप से लोड किए जाने वाले फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles`, फ़ॉन्ट डेटा को SVG में शामिल करने के लिए `Embed`, या बाहरी फ़ॉन्ट उपयोग करने वाले टेक्स्ट को केवल ग्राफ़िक्स में बदलने के लिए `Vectorize` चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की पुष्टि करें।

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

## **एम्बेडेड इमेज साइज़ कम करें**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) का उपयोग एम्बेडेड चित्रों के रिज़ॉल्यूशन को कम करने के लिए करें, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) का उपयोग क्रॉप किए गए स्रोत क्षेत्रों को हटाने के लिए, और [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) का उपयोग JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करने के लिए करें। ये सेटिंग्स फ़ाइल आकार को कम करती हैं, लेकिन इमेज फिडेलिटी या रखे गए इमेज डेटा की कीमत पर।

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

## **मेटाफाइल रास्टराइज़ेशन रेज़ॉल्यूशन नियंत्रित करें**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) SVG निर्यात के दौरान मेटाफाइलों को रास्टराइज़ करने की निचली रिज़ॉल्यूशन सीमा निर्धारित करता है। इसे उपयोग करें ताकि EMF या WMF चित्र को रास्टराइज़ करते समय विवरण और फ़ाइल आकार को संतुलित किया जा सके। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता और न ही स्लाइड पर प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनाता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकट-स्थापित विकर्ण रेखाओं वाला एक EMF चित्र है। निम्न उदाहरण [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) के माध्यम से उसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। सभी अन्य निर्यात सेटिंग्स समान रखी गई हैं ताकि परिणामों की तुलना की जा सके।

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

| मेटाफाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे दिया गया तुलना वही एम्बेडेड रास्टर क्षेत्र को समान बड़े प्रदर्शन आकार पर दिखाता है। विकर्ण रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन दिखाती हैं और उच्च रिज़ॉल्यूशन पर अधिक स्मूथ किनारे दिखाते हैं, जबकि SVG फ़ाइल आकार बढ़ता है। मान बढ़ाने से हर विवरण बेहतर नहीं होता और न ही प्रत्येक निर्यातित चित्र बदलता है।

![72, 150, और 300 DPI पर बढ़ी हुई विकर्ण-रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) छवि रिज़ॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रेज़ॉल्यूशन परिवर्तन के प्रभाव को छुपा सकता है। [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, मेटाफाइल रास्टराइज़ेशन रेज़ॉल्यूशन को नहीं।

## **Shapes और टेक्स्ट के लिए स्थिर IDs निर्धारित करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) मान सेट करने के लिए, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) लागू करें। किसी भी एक कंट्रोलर को [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें।

निम्न कंट्रोलर [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) का उपयोग करता है, जो आकार के जीवनकाल में स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावृत्त काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

## **SVG इवेंट हैंडलर जोड़ें**

एक [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) में, एक [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) मूल्य के साथ [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) को कॉल करें ताकि निर्यातित आकार में एक JavaScript इवेंट हैंडलर जोड़ा जा सके। कंट्रोलर को [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें और पृष्ठ या SVG दस्तावेज़ में वह JavaScript फ़ंक्शन परिभाषित करें जो परिणाम होस्ट करता है।

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

होस्ट पृष्ठ हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलरों को असाइन करने से स्लाइड व्यूअर, पहुँच सुधार, और अन्य इंटरैक्टिव SVG कार्यप्रवाह सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**कब मुझे [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) के बजाय करना चाहिए?**

जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए, तब [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) का उपयोग करें। जब केवल बाहरी फ़ॉन्ट उपयोग करने वाले टेक्स्ट को ग्राफ़िक में बदला जाना चाहिए, तब [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) का उपयोग करें।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण फ़ॉन्ट फ़ाइलें सर्व कर सकता है तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम चित्र रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक का अलग‑अलग गुणवत्ता और आकार ट्रेड‑ऑफ़ होता है।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।