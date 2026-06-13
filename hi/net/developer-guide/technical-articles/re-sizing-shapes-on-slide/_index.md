---
title: ".NET में प्रेज़ेंटेशन स्लाइड्स पर शैप्स का आकार बदलें"
type: docs
weight: 130
url: /hi/net/re-sizing-shapes-on-slide/
keywords:
  - शेप रीसेज़
  - शेप का आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रेज़ेंटेशन
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument स्लाइड्स पर शैप्स को आसानी से री‑साइज़ करें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for .NET ग्राहकों से सबसे आम प्रश्नों में से एक है कि स्लाइड का आकार बदलने पर डेटा कट न जाए, इसके लिए शैप्स को कैसे री‑साइज़ करें। यह छोटा तकनीकी लेख दिखाता है कि यह कैसे किया जाता है।

## **शेप्स का आकार बदलें**

स्लाइड के आकार में परिवर्तन होने पर शैप्स के विसंगत होने से बचाने के लिए, प्रत्येक शैप की स्थिति और आयाम को अपडेट करें ताकि वे नई स्लाइड लेआउट के अनुरूप हों।

```c#
// प्रेज़ेंटेशन फ़ाइल लोड करें।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // मौजूदा शैप्स को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // नया स्लाइड आकार प्राप्त करें।
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // हर स्लाइड पर शैप्स का आकार बदलें और उनकी स्थिति बदलें।
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // शैप का आकार स्केल करें।
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // शैप की स्थिति स्केल करें।
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
यदि स्लाइड में टेबल शामिल है, तो उपरोक्त कोड सही ढंग से काम नहीं करेगा। ऐसे में टेबल की प्रत्येक सेल का आकार बदलना आवश्यक है।
{{% /alert %}}

नीचे दिया गया कोड अपने पक्ष में उपयोग करें ताकि टेबल वाली स्लाइड्स का आकार बदला जा सके। टेबल के लिए चौड़ाई या ऊँचाई सेट करना एक विशेष मामला है: आपको टेबल का कुल आकार बदलने के लिए व्यक्तिगत पंक्तियों की ऊँचाइयों और कॉलम की चौड़ाइयों को समायोजित करना होगा।

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // मूल स्लाइड आकार प्राप्त करें।
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // मौजूदा शैप्स को स्केल किए बिना स्लाइड आकार बदलें।
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
            // शैप का आकार स्केल करें।
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // शैप की स्थिति स्केल करें।
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // शैप का आकार स्केल करें।
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // शैप की स्थिति स्केल करें।
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // शैप का आकार स्केल करें।
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // शैप की स्थिति स्केल करें।
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद शैप्स विकृत या कट क्यों जाते हैं?**

स्लाइड का आकार बदलते समय शैप्स अपनी मूल स्थिति और आकार बनाए रखते हैं जब तक स्केल स्पष्ट रूप से नहीं बदला जाता। इससे सामग्री कट सकती है या शैप्स विसंगत हो सकते हैं।

**क्या दिया गया कोड सभी शैप प्रकारों के लिए काम करता है?**

बुनियादी उदाहरण अधिकांश शैप प्रकारों (टेक्स्ट बॉक्स, इमेज, चार्ट आदि) के लिए काम करता है। हालांकि, टेबल के लिए आपको पंक्तियों और कॉलमों को अलग से संभालना पड़ेगा, क्योंकि टेबल की ऊँचाई और चौड़ाई व्यक्तिगत सेल्स के आयामों से निर्धारित होती है।

**स्लाइड का आकार बदलते समय टेबल्स का आकार कैसे बदलूँ?**

आपको टेबल की सभी पंक्तियों और कॉलमों के माध्यम से लूप करना होगा और उनकी ऊँचाई व चौड़ाई को अनुपातिक रूप से री‑साइज़ करना होगा, जैसा कि दूसरे कोड उदाहरण में दिखाया गया है।

**क्या यह री‑साइज़िंग मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगी?**

हां, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) और [LayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/layoutslides/) के माध्यम से भी लूप करना चाहिए और उनके शैप्स पर वही स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुति में सुसंगति बनी रहे।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को री‑साइज़िंग के साथ बदल सकता हूँ?**

हां। आप [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/orientation/) को सेट करके अभिविन्यास बदल सकते हैं। लेआउट को सुरक्षित रखने के लिए स्केलिंग लॉजिक को उसी अनुसार समायोजित करें।

**क्या स्लाइड आकार की कोई सीमा है जिसे मैं सेट कर सकता हूँ?**

Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों के साथ संगतता को प्रभावित कर सकते हैं।

**स्थिर अनुपात वाले शैप्स को विकृत होने से कैसे रोकूँ?**

स्केलिंग से पहले शैप की `AspectRatioLocked` प्रॉपर्टी जांचें। यदि यह लॉक है, तो चौड़ाई या ऊँचाई को व्यक्तिगत रूप से स्केल करने के बजाय अनुपातिक रूप से समायोजित करें।