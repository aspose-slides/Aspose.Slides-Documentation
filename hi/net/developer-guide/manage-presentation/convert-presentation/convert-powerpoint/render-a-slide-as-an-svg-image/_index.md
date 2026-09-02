---
title: ".NET में प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें"
linktitle: "स्लाइड से SVG"
type: docs
weight: 50
url: /hi/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint से SVG"
- "प्रस्तुति से SVG"
- "स्लाइड से SVG"
- "PPT से SVG"
- "PPTX से SVG"
- "SVG निर्यात विकल्प"
- "इंटरैक्टिव SVG"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides के साथ .NET में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और फ़ॉन्ट, टेक्स्ट, छवियों, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर, पहुँच कार्यप्रवाह और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्वों के लिखे जाने के तरीके को नियंत्रित करने की सुविधा देता है।

Use [SVGOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **एक स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

फाइलनाम लूप इंडेक्स के बजाय [ISlide.SlideNumber](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/slidenumber/) का उपयोग करता है। आप एक व्यक्तिगत आकार को भी [IShape.WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/writeassvg/) के साथ निर्यात कर सकते हैं जब किसी स्लाइड व्यूअर या वेब पेज को केवल वह आकार चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/useframesize/) टेक्स्ट फ्रेम को रेंडरिंग क्षेत्र में सम्मिलित करता है, और [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/useframerotation/) यह निर्धारित करता है कि फ्रेम का घुमाव लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/disablefontligatures/) को `true` पर सेट करें।

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

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/vectorizetext/) को `true` पर सेट करें ताकि सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखे जाएँ। यह फ़ॉन्ट निर्भरताओं को हटाता है और दृश्य परिणाम को विभिन्न ब्राउज़रों में अधिक सुसंगत बनाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट कैसे हैंडल किए जाएँ, चुनें**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/externalfontshandling/) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। विभिन्न फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles` चुनें, फ़ॉन्ट डेटा को SVG में सम्मिलित करने के लिए `Embed` चुनें, या केवल बाहरी फ़ॉन्ट्स वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें। फ़ॉन्ट्स को एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एम्बेडेड इमेज आकार घटाएँ**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/picturescompression/) का उपयोग करके एम्बेडेड चित्रों का रिज़ॉल्यूशन घटाएँ, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) से क्रॉप किए गए स्रोत क्षेत्रों को हटाएँ, और [SVGOptions.JpegQuality](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/jpegquality/) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। इन सेटिंग्स से फ़ाइल आकार घटता है, लेकिन इमेज की स्पष्टता या संरक्षित इमेज डेटा की कीमत पर।

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

## **आकृतियों और टेक्स्ट को स्थायी IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.Id](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshape/id/) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.Id](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgtspan/id/) मान सेट करने के लिए [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) लागू करें। इन कंट्रोलर्स में से किसी को भी [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें।

निम्नलिखित कंट्रोलर [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/officeinteropshapeid/) का उपयोग करता है, जो आकार के जीवनकाल के दौरान स्थिर रहता है, और इसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। इससे उत्पन्न IDs अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनती हैं।

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

एक [ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshapeformattingcontroller/) में, निर्यातित आकार पर एक JavaScript इवेंट हैंडलर जोड़ने के लिए [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshape/seteventhandler/) को [SvgEvent](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) के साथ असाइन करें और परिणाम को होस्ट करने वाले पृष्ठ या SVG दस्तावेज़ में JavaScript फ़ंक्शन परिभाषित करें।

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

होस्ट पेज हैन्डलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, पहुँच सुधार, और अन्य इंटरैक्टिव SVG कार्यप्रवाह सक्षम होते हैं।

## **FAQ**

**मैं कब SVGOptions.VectorizeText का उपयोग करूँगा, SvgExternalFontsHandling.Vectorize के बजाय?**

जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना आवश्यक हो, तब SVGOptions.VectorizeText का उपयोग करें। जब केवल बाहरी फ़ॉन्ट्स वाले टेक्स्ट को ग्राफ़िक्स में बदलना हो, तब SvgExternalFontsHandling.Vectorize का उपयोग करें।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को संपीड़ित करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण फ़ॉन्ट फ़ाइलों को सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज्ड टेक्स्ट प्रत्येक के अलग गुणवत्ता और आकार के समझौते होते हैं।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।