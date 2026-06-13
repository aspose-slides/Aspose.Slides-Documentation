---
title: .NET में प्रेजेंटेशन व्यूअर बनाएं
linktitle: प्रेजेंटेशन व्यूअर
type: docs
weight: 50
url: /hi/net/presentation-viewer/
keywords:
- प्रेजेंटेशन देखें
- प्रेजेंटेशन व्यूअर
- प्रेजेंटेशन व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides का उपयोग करके कस्टम प्रेजेंटेशन व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for .NET का उपयोग स्लाइड वाली प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइड को Microsoft PowerPoint आदि में प्रेजेंटेशन खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी स्लाइड को अपनी पसंदीदा इमेज व्यूअर में इमेज के रूप में देखना या कस्टम प्रेजेंटेशन व्यूअर में उपयोग करना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको व्यक्तिगत स्लाइड को इमेज के रूप में एक्सपोर्ट करने की अनुमति देता है। यह लेख बताता है कि यह कैसे किया जाए।

## **स्लाइड से SVG इमेज उत्पन्न करें**

Aspose.Slides का उपयोग करके प्रेजेंटेशन स्लाइड से SVG इमेज उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें।

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक instance बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक फ़ाइल स्ट्रीम खोलें।
4. स्लाइड को SVG इमेज के रूप में फ़ाइल स्ट्रीम में सहेजें।

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **कस्टम शेप ID के साथ SVG उत्पन्न करें**

Aspose.Slides का उपयोग कस्टम शेप `ID` के साथ स्लाइड से [SVG](https://docs.fileformat.com/page-description-language/svg/) उत्पन्न करने के लिए किया जा सकता है। इसे प्राप्त करने के लिए, [ISvgShape](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isvgshape) इंटरफ़ेस की Id प्रॉपर्टी का उपयोग करें। `CustomSvgShapeFormattingController` क्लास का उपयोग शेप ID सेट करने के लिए किया जा सकता है।

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **स्लाइड थंबनेल इमेज बनाएं**

Aspose.Slides आपको स्लाइड के थंबनेल इमेज बनाने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड का थंबनेल बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक instance बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. रेफ़रेंस की गई स्लाइड का थंबनेल इमेज वांछित स्केल पर बनाएं।
4. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **यूज़र परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

यूज़र द्वारा परिभाषित आयामों के साथ स्लाइड थंबनेल इमेज बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक instance बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. निर्दिष्ट आयामों के साथ रेफ़रेंस की गई स्लाइड का थंबनेल इमेज जनरेट करें।
4. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

स्पीकर नोट्स के साथ स्लाइड का थंबनेल Aspose.Slides का उपयोग करके बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/) क्लास की एक instance बनाएं।
2. स्पीकर नोट्स की पोज़ीशन सेट करने के लिए `RenderingOptions.SlidesLayoutOptions` प्रॉपर्टी का उपयोग करें।
3. [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक instance बनाएं।
4. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
5. रेंडरिंग ऑप्शन्स का उपयोग करके रेफ़रेंस की गई स्लाइड का थंबनेल इमेज जनरेट करें।
6. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **लाइव उदाहरण**

Try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) free app to see what you can implement with Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/hi/viewer/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं ASP.NET वेब एप्लिकेशन में प्रस्तुति व्यूअर एम्बेड कर सकता हूँ?**

हाँ। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइड को इमेज या HTML के रूप में रेंडर कर सकते हैं और ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम फीचर को जावास्क्रिप्ट के साथ लागू किया जा सकता है जिससे इंटरैक्टिव अनुभव मिलता है।

**कस्टम .NET व्यूअर में स्लाइड को प्रदर्शित करने का सर्वश्रेष्ठ तरीका क्या है?**

सिफ़ारिश की गई विधि यह है कि प्रत्येक स्लाइड को इमेज (जैसे PNG या SVG) के रूप में रेंडर करें या Aspose.Slides का उपयोग करके इसे HTML में बदलें, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में प्रदर्शित करें।

**मैं कई स्लाइड वाली बड़ी प्रेजेंटेशन को कैसे संभालूं?**

बड़ी प्रेजेंटेशन के लिए, स्लाइड को लेज़ी-लोडिंग या ऑन-डिमांड रेंडरिंग पर विचार करें। इसका मतलब है कि स्लाइड की सामग्री केवल तभी जेनरेट करें जब उपयोगकर्ता उसे नेविगेट करे, जिससे मेमोरी और लोड टाइम कम हो जाता है।