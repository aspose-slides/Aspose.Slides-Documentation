---
title: .NET में प्रस्तुति स्लाइड्स पर आकृतियों का आकार बदलें
type: docs
weight: 130
url: /hi/net/re-sizing-shapes-on-slide/
keywords:
- आकृति आकार बदलें
- आकृति का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आकृतियों को आसानी से आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for .NET ग्राहकों के सबसे सामान्य प्रश्नों में से एक है कि स्लाइड का आकार बदलने पर डेटा कट न जाए, इसके लिए आकृतियों (shapes) का आकार कैसे बदलें। यह संक्षिप्त तकनीकी लेख दिखाता है कि इसे कैसे किया जाए।

## **आकृतियों का आकार बदलें**

स्लाइड का आकार बदलने पर आकृतियों का विसंरेखित (misaligned) न होने के लिए, प्रत्येक आकृति की स्थिति और आयाम को नए स्लाइड लेआउट के अनुसार अपडेट करें।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल लोड करें।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // प्रत्येक स्लाइड पर आकृतियों का आकार बदलें और पुनर्स्थापित करें।
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // आकृति का आकार स्केल करें।
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // आकृति की स्थिति स्केल करें।
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
यदि स्लाइड में तालिका (table) शामिल है, तो ऊपर दिया गया कोड सही कार्य नहीं करेगा। ऐसे में तालिका की प्रत्येक सेल का आकार बदलना आवश्यक है।
{{% /alert %}}

वह कोड उपयोग करें जो तालिका वाले स्लाइड्स के आकार को बदलता है। तालिकाओं के लिए, आकृति की चौड़ाई और ऊँचाई के बजाय व्यक्तिगत पंक्तियों की ऊँचाई और कॉलम की चौड़ाई को स्केल करें—दोनों को स्केल करने से तालिका दो बार स्केल हो जाएगी और स्लाइड से बाहर जा जाएगी।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // आकृति का आकार स्केल करें।
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // आकृति की स्थिति स्केल करें.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // आकृति का आकार स्केल करें।
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // आकृति की स्थिति स्केल करें.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // तालिका का आकार उसकी पंक्तियों और स्तंभों के माध्यम से स्केल करें।
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // आकृति का आकार स्केल करें।
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // आकृति की स्थिति स्केल करें.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न (FAQ)**

### स्लाइड का आकार बदलने के बाद आकृतियां विकृत या कट क्यों जाती हैं?
स्लाइड का आकार बदलने पर, यदि स्केल स्पष्ट रूप से नहीं बदला जाता तो आकृतियों की मूल स्थिति और आकार ही रहता है। इससे सामग्री कट सकती है या आकृतियां विसंरेखित हो सकती हैं।

### क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?
मूल उदाहरण अधिकांश आकृति प्रकारों (टेक्स्ट बॉक्स, छवियां, चार्ट आदि) के लिए काम करता है। हालांकि, तालिकाओं के लिए आपको पंक्तियों और कॉलमों को अलग से संभालना होगा, क्योंकि तालिका की ऊँचाई और चौड़ाई व्यक्तिगत सेलों के आयामों से निर्धारित होती है।

### स्लाइड का आकार बदलते समय तालिकाओं का आकार कैसे बदलें?
आपको तालिका की सभी पंक्तियों और कॉलमों के माध्यम से लूप करना होगा और उन्हें दूसरे कोड उदाहरण में दिखाए अनुसार अनुपातिक रूप से उनकी ऊँचाई और चौड़ाई बदलनी होगी।

### क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स पर भी काम करेगा?
हाँ, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) और [LayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/layoutslides/) पर भी लूप करके उनके आकृतियों पर समान स्केलिंग तर्क लागू करना चाहिए ताकि प्रस्तुति में निरंतरता बनी रहे।

### क्या मैं स्लाइड की अभिविन्यास (portrait/landscape) को आकार बदलते समय बदल सकता हूँ?
हाँ। आप [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/orientation/) सेट करके अभिविन्यास बदल सकते हैं। लेआउट को संरक्षित रखने के लिए स्केलिंग तर्क को उसी अनुसार सेट करना सुनिश्चित करें।

### क्या स्लाइड के आकार पर कोई सीमा है जिसे मैं सेट कर सकता हूँ?
Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों की संगतता को प्रभावित कर सकते हैं।

### फिक्स्ड आस्पेक्ट रेशियो वाली आकृतियों को विकृत होने से कैसे बचाएँ?
आकृति को स्केल करने से पहले आप `AspectRatioLocked` प्रॉपर्टी की जाँच कर सकते हैं। यदि यह लॉक है, तो व्यक्तिगत रूप से स्केल करने के बजाय चौड़ाई या ऊँचाई को अनुपातिक रूप से समायोजित करें।