---
title: ".NET में प्रस्तुति स्लाइड्स पर आकार पुनःआकारित करें"
type: docs
weight: 130
url: /hi/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /hi/net/re-sizing-shapes-on-slide/
keywords:
  - आकार पुनःआकारित करें
  - आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument स्लाइड्स पर आकार आसानी से पुनःआकारित करें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादनशीलता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुतिकरण की स्लाइड आकार बदलते हैं, तो आपको नई आयामों में फिट करने के लिए उसके आकारों को पुनः आकारित और पुनः स्थित करने की भी आवश्यकता पड़ सकती है। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभाला जाए।

## **आकार पुनःआकारित करें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को संरक्षित रखने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान ऊँचाई अनुपात को उसके लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक प्रस्तुति लोड करता है जिसकी स्लाइड्स में कोई तालिका नहीं है, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है ताकि अगला लूप स्केलिंग को नियंत्रित कर सके। अनुपात बिना इकाई के होते हैं; आकार की स्थिति और आयाम पॉइंट्स में मापे जाते हैं। अलग‑अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं स्केल होते।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
तालिकाओं को अलग‑अलग संभालने की आवश्यकता होती है: उनकी कॉलम चौड़ाइयों और पंक्ति ऊँचाइयों को स्केल करें, न कि तालिका की समग्र चौड़ाई और ऊँचाई को। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति की ऊँचाइयाँ अनुरोधित से बड़ी रह सकती हैं।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट के साथ-साथ व्यक्तिगत स्लाइड्स पर भी प्रोसेस करता है, फिर आकार बदली गई प्रस्तुति को सहेजता है। इसका हेल्पर प्रत्येक [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) को [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) और [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) को स्केल करके संभालता है। इसके बाद तालिका की समग्र आयामों को अलग‑अलग स्केल किए बिना उसकी स्थिति को स्केल करता है।
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// मास्टर और लेआउट में परिभाषित आकारों को व्यक्तिगत स्लाइड्स सहित पुनःआकारित करें.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // तालिका के आयाम कॉलम चौड़ाइयों और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकार क्यों विकृत या कटे हुए दिखते हैं?**

यदि आप स्लाइड आकार बदलते हैं लेकिन आकारों को स्केल नहीं करते, तो वे अपनी मूल स्थिति और आयाम बनाए रखते हैं और स्लाइड के बाहर तक पहुँच सकते हैं। चौड़ाई और ऊँचाई को अलग‑अलग अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और तालिकाबिहीन स्लाइड्स के लिए उद्देश्यपूर्ण है। दूसरा उदाहरण तालिकाओं को अलग‑अलग संभालता है। परिणामस्वरूप लेआउट, विशेषकर टेक्स्ट और तालिकाओं, की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकार को स्केल नहीं करते और तालिका की सामग्री पंक्तियों की ऊँचाइयों को प्रतिबंधित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे रिसाइज़ करें?**

कॉलम चौड़ाइयों को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाइयों को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह रिसाइज़िंग मास्टर स्लाइड्स और लेआउट स्लाइड्स पर भी काम करेगी?**

हां। दूसरा उदाहरण [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) और प्रत्येक मास्टर की [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) के माध्यम से इटरिट करता है और उनके आकारों पर समान रिसाइज़िंग लॉजिक लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को रिसाइज़िंग के साथ बदल सकता हूं?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) सेट करें, ताकि स्केल फ़ैक्टर अंतिम अभिविन्यास को प्रतिबिंबित करें।

**क्या स्लाइड आकार सेट करने की कोई सीमा है?**

आप [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले आकारों को विकृत होने से कैसे बचाया जाए?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर का उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए चौड़ाई और ऊँचाई दोनों के लिए छोटा अनुपात उपयोग करें। इससे अनुपात बना रहता है, पर एक किनारे पर कुछ अनउपयोगी स्थान बच सकता है।