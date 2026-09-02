---
title: ".NET में प्रस्तुति प्लेसहोल्डर प्रबंधित करें"
linktitle: "प्लेसहोल्डर प्रबंधित करें"
type: docs
weight: 10
url: /hi/net/manage-placeholder/
keywords:
- "प्लेसहोल्डर"
- "टेक्स्ट प्लेसहोल्डर"
- "छवि प्लेसहोल्डर"
- "चार्ट प्लेसहोल्डर"
- "सामग्री प्लेसहोल्डर"
- "प्रॉम्प्ट टेक्स्ट"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर का निरीक्षण और संपादन कैसे करें और प्लेसहोल्डर विरासत को समझें सीखें।"
---
## **अवलोकन**

प्लेसहोल्डर एक आकार (shape) है जो प्रस्तुति टेम्पलेट में किसी विशिष्ट प्रकार की सामग्री के लिए एक स्थिति आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट और सामान्य-उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। एक सामान्य आकार के विपरीत, प्लेसहोल्डर अपनी स्थिति, आकार, फ़ॉर्मेटिंग और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में प्राप्त कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape.Placeholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/placeholder/) प्रॉपर्टी के माध्यम से उजागर करता है। यह प्रॉपर्टी एक [IPlaceholder](https://reference.aspose.com/slides/hi/net/aspose.slides/iplaceholder/) ऑब्जेक्ट या सामान्य आकार के लिए `null` लौटाती है। यह निर्धारित करने के लिए कि प्लेसहोल्डर में क्या होना चाहिए, [IPlaceholder.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/iplaceholder/type/) का उपयोग करें।

आकार इंटरफ़ेस अभी भी महत्वपूर्ण है जब आप प्लेसहोल्डर प्रकार जान लेते हैं:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट प्लेसहोल्डर आमतौर पर एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) द्वारा दर्शाया जाता है।
- एक भरा हुआ चित्र प्लेसहोल्डर [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर [IChart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। यह मानने के बजाय कि हर प्लेसहोल्डर एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है, दोनों [IPlaceholder.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/iplaceholder/type/) और रनटाइम आकार इंटरफ़ेस की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/iplaceholder/type/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार के रनटाइम प्रकार की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया-विशिष्ट सदस्य तक पहुँचने से पहले हमेशा प्रकार जाँच का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य स्टाइल्स और कुछ मामलों में मास्टर-स्तर के प्लेसहोल्डर निर्धारित करती है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था निर्धारित करती है और मास्टर से विरासत में प्राप्त कर सकती है।
3. एक सामान्य स्लाइड में उस स्लाइड के प्लेसहोल्डर होते हैं और वह अपने लेआउट से विरासत में प्राप्त कर सकता है।

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getbaseplaceholder/) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जाएँ। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार के पास कोई बेस प्लेसहोल्डर नहीं होता है, तो यह मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर की सूची बनाता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

सामान्य स्लाइड पर किसी प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए एक स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइडों पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग विरासत में प्राप्त कर रही हैं। एक स्थानीय सामान्य आकार के पास बेस प्लेसहोल्डर नहीं होता और केवल इसलिए विरासत नहीं शुरू करता क्योंकि वह समान निर्देशांक लेता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित-शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट को समर्थन देते हैं। इसका [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/textframe/) प्रॉपर्टी उपयोग करने से पहले [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) की जाँच करें।

यह उदाहरण पहले स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

यह पैराडाइम चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य के आधार पर पहचानता है न कि नाज़ुक आकार इंडेक्स पर निर्भर होकर।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिज़ाइन‑टाइम निर्देश है जो एक खाली प्लेसहोल्डर में प्रदर्शित होता है, जैसे *Click to add title*। सामान्य स्लाइड के आकार संग्रह के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर कस्टम प्रॉम्प्ट टेक्स्ट सेट करें। लेआउट तक पहुँचने के लिए [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) का उपयोग करें और [ILayoutSlide.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/shapes/) पर इटरिटेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट बदलता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे एडिटिंग एप्लिकेशन में खाली प्लेसहोल्डर के लिए निर्देशित है। एक उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान करने पर प्रॉम्प्ट अब नहीं दिखाया जाता। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र प्लेसहोल्डर अपडेट करें**

हैंडल करने के दो केस हैं:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो छवि को [IPictureFillFormat.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/picture/) और [ISlidesPicture.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/image/) के माध्यम से बदलें।
- यदि वह अभी भी एक खाली प्लेसहोल्डर है, तो [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) का उपयोग करके प्लेसहोल्डर के निर्देशांक पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर हटा दें।

अगला उदाहरण दोनों मामलों को समर्थन देता है और प्रस्तुति सहेजता है:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [IShape.Placeholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/placeholder/) केवल‑पढ़ने योग्य है। यह आरक्षित स्थिति बनाए रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार को विरासत में नहीं लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides के साथ परिणामी [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/net/picture-frame/)। ये ऑपरेशन चित्र फ्रेम या चित्र फ़िल पर लागू होते हैं, प्लेसहोल्डर मेटाडेटा पर नहीं।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

एक भरा हुआ चार्ट प्लेसहोल्डर [IChart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रनटाइम इंटरफ़ेस दोनों से ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

एक सामान्य कंटेंट प्लेसहोल्डर आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों—जैसे चार्ट, टेबल, डायग्राम, चित्र और मीडिया—के लिए लॉन्चर के रूप में कार्य करता है। एक बार भरने पर, वास्तविक आकार इंटरफ़ेस की जाँच करें ताकि पता चले कि इसमें क्या है। विशेष लेआउट भी [PlaceholderType.Chart](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/hi/net/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides केवल [IPlaceholder.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/iplaceholder/type/) को बदलकर एक खाली [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) प्लेसहोल्डर को [IChart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/) में परिवर्तित नहीं करता; प्रकार केवल‑पढ़ने योग्य है। प्रोग्रामmatically एक खाली चार्ट या कंटेंट एरिया भरने के लिए, प्लेसहोल्डर के निर्देशांक पर आवश्यक वस्तु जोड़ें और फिर खाली प्लेसहोल्डर हटा दें। निम्न उदाहरण चार्ट के लिए यही करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर का क्षेत्र घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। इसके श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलने की आवश्यकता होने पर समर्पित [chart management articles](/slides/hi/net/powerpoint-charts/) देखें।

## **पूर्ण उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्न एंड‑टू‑एंड उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकारों की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। उदाहरण जानबूझकर आकार इंडेक्स मानने या हर प्लेसहोल्डर को एक ही इंटरफ़ेस में कास्ट करने से बचता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित होता है और जिससे दूसरा प्लेसहोल्डर विरासत प्राप्त करता है। इसे प्राप्त करने के लिए [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getbaseplaceholder/) का उपयोग करें। एक सामान्य स्थानीय आकार `null` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों में संग्रहीत होती है। पूरे प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइड्स पर इटरिटेट करके प्रत्येक शीर्षक प्लेसहोल्डर अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फ़ूटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप पर हेडर और फ़ूटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/net/presentation-header-and-footer/).