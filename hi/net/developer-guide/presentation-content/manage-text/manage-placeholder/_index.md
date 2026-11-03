---
title: .NET में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/net/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर की जांच और संपादन करना तथा प्लेसहोल्डर इनहेरिटेंस को समझना सीखें।"
---
## **अवलोकन**

प्लेसहोल्डर एक आकार है जो प्रस्तुति टेम्पलेट में विशिष्ट प्रकार की सामग्री के लिए स्थान आरक्षित करता है। सामान्य उदाहरण हैं शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य प्रयोजन की सामग्री प्लेसहोल्डर। सामान्य आकार के विपरीत, प्लेसहोल्डर लेआउट स्लाइड या मास्टर स्लाइड से अपनी स्थिति, आकार, स्वरूपण और अन्य सेटिंग्स इनहेरिट कर सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) प्रॉपर्टी के माध्यम से उजागर करता है। प्रॉपर्टी एक [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) ऑब्जेक्ट या सामान्य आकार के लिए `null` लौटाती है। प्लेसहोल्डर में क्या सामग्री होनी चाहिए, यह निर्धारित करने के लिए [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) का उपयोग करें।

आकार इंटरफ़ेस अभी भी महत्वपूर्ण है जब आप प्लेसहोल्डर प्रकार जानते हैं:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट प्लेसहोल्डर को आम तौर पर एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) द्वारा दर्शाया जाता है।
- भरा हुआ चित्र प्लेसहोल्डर को एक [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) द्वारा दर्शाया जा सकता है।
- भरा हुआ चार्ट प्लेसहोल्डर को एक [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) और रनटाइम आकार इंटरफ़ेस दोनों को जांचें, बजाय यह मानने के कि हर प्लेसहोल्डर एक [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) है।

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार की रनटाइम टाइप की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल, या मीडिया-विशिष्ट सदस्य तक पहुँचने से पहले हमेशा टाइप चेक का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर इनहेरिटेंस को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. मास्टर स्लाइड पुन: उपयोग योग्य शैलियों को परिभाषित करता है और कुछ मामलों में मास्टर-लेवल प्लेसहोल्डर भी।
2. लेआउट स्लाइड उन एक या अधिक सामान्य स्लाइडों द्वारा उपयोग किए जाने वाले लेआउट को परिभाषित करती है और मास्टर से इनहेरिट कर सकती है।
3. सामान्य स्लाइड में उस स्लाइड के प्लेसहोल्डर होते हैं और वह अपने लेआउट से इनहेरिट कर सकता है।

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जाएँ। एक स्लाइड प्लेसहोल्डर सामान्यतः उसका लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर उसका मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार के पास बेस प्लेसहोल्डर नहीं होता तो मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर सूचीबद्ध करता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

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

सामान्य स्लाइड पर प्लेसहोल्डर का संपादन उस स्लाइड के लिए स्थानीय ओवरराइड बनाता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से सभी स्लाइडों पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग इनहेरिट करती हैं। एक स्थानीय साधारण आकार का कोई बेस प्लेसहोल्डर नहीं होता और केवल समान निर्देशांक रहने से इनहेरिट करना शुरू नहीं करता।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्पलेट को अनुकूलित करते समय, मौजूदा ऑब्जेक्ट को साधारण आकार के रूप में रखने के लिए [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) का उपयोग करें। उसकी [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) प्रॉपर्टी `null` हो जाती है, लेकिन आकार स्लाइड के संग्रह में बना रहता है। इसके विपरीत, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) आकार को उस संग्रह से हटा देता है।

निम्न उदाहरण के लिए `template.pptx` में कम से कम एक स्लाइड और पहले स्लाइड पर एक गैर-खाली टेक्स्ट प्लेसहोल्डर होना आवश्यक है। लेआउट या मास्टर से इनहेरिटेड फ़ॉर्मेटिंग वाले प्लेसहोल्डर का उपयोग करके संबंध हटाने के प्रभाव को देखें। उदाहरण जाँचता है कि वही आकार बना रहता है, अब साधारण आकार पर फिर से मेथड कॉल करता है, और परिणाम सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति हटाने से इनहेरिटेड उपस्थिति सेटिंग्स स्वचालित रूप से संरक्षित नहीं रहती हैं। नीचे दिया गया उदाहरण जानबूझकर उन सेटिंग्स को अपरिवर्तित छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। एक आकार जिसकी स्थिति और आकार पूरी तरह से इनहेरिटेड हैं, कॉल के बाद शून्य निर्देशांक और आयाम हो सकते हैं और वह संग्रह में बना रहने के बावजूद अदृश्य हो सकता है।
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // एक साधारण आकार पर इस मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता।
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

मेल खाने वाले प्लेसहोल्डर के लिए, सभी तीन जाँच `True` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन प्लेसहोल्डर संबंध हटाने पर इनहेरिटेड स्थिति, आकार, घुमाव, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट-फ़्रेम मार्जिन, वर्टिकल एंकरिंग, फ़िल और लाइन सेटिंग्स बदल सकती हैं। उदाहरण के लिए, इनहेरिटेड शीर्षक फ़ॉर्मेटिंग साधारण टेक्स्ट फ़ॉर्मेटिंग में वापस गिर सकती है। लेआउट के बारे में अधिक जानकारी के लिए [स्लाइड लेआउट](/slides/hi/net/slide-layout/) देखें।

इच्छित उपस्थिति को बनाए रखने के लिए, कॉल से पहले हल हुई स्थिति, आकार और घुमाव को कैप्चर करें, और आवश्यक प्रभावी फ़ॉर्मेटिंग मानों को अलग वेरिएबल्स में कॉपी करें। उन मानों को [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), और [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) के माध्यम से प्राप्त करें। केवल प्रभावी-फ़ॉर्मेट ऑब्जेक्ट्स पर निर्भर न रहें, क्योंकि संबंध हटाने के बाद उनके टेक्स्ट-फ़ॉर्मेटिंग मान बदल सकते हैं। बाद में कैप्चर किए गए मानों को साधारण आकार पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट फैमिली, आकार, स्टाइल, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट-फ़्रेम सेटिंग्स, फ़िल और लाइन शामिल हैं जो आपके टेम्पलेट द्वारा उपयोग किए गए हैं।

इनहेरिटेड आकार ज्योमेट्री को भी स्पष्ट रूप से [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) के माध्यम से असाइन करना पड़ सकता है। आयताकार टेक्स्ट प्लेसहोल्डर के लिये, इसका अर्थ है [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) असाइन करना; केवल फ़िल और लाइन को पुनर्स्थापित करने से दृश्य आयत नहीं बन सकता। अतिरिक्त इफ़ेक्ट या अधिक जटिल फ़ॉर्मेटिंग वाले टेम्पलेट को भी इन सेटिंग्स को संभालने की आवश्यकता होती है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित-शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। उपयोग करने से पहले इसकी [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) प्रॉपर्टी के लिए [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) की जाँच करें।

यह उदाहरण पहला स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल, या मीडिया प्लेसहोल्डर को [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) में कास्ट करने से बचाता है। यह प्लेसहोल्डर को उसके उद्देश्य से पहचानता है, न कि नाज़ुक आकार इंडेक्स पर निर्भर होने से।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट एक डिजाइन-टाइम निर्देश होता है जो खाली प्लेसहोल्डर में दिखता है, जैसे *Click to add title*। सामान्य स्लाइड की शैप कलेक्शन के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर कस्टम प्रॉम्प्ट टेक्स्ट सेट करें। लेआउट तक पहुँचने के लिए [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) का उपयोग करें और [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) पर इटररेट करें।

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए अभिप्रेत है। जब उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री देता है, तो प्रॉम्प्ट अब नहीं दिखता। प्रॉम्प्ट बदलने से लेआउट उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट नहीं बदला जाता।

## **चित्र प्लेसहोल्डर अपडेट करें**

संबंधित दो मामलों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) द्वारा दर्शाया गया है, तो छवि को [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) और [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) के माध्यम से बदलें।
- यदि वह अभी भी खाली प्लेसहोल्डर है, तो [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) का उपयोग करके प्लेसहोल्डर के निर्देशांक पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों मामलों का समर्थन करता है और प्रस्तुति सहेजता है:

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

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) केवल पढ़ने योग्य है। यह आरक्षित स्थान को रखता है लेकिन अब प्लेसहोल्डर-विशिष्ट व्यवहार इनहेरिट नहीं करता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides के साथ उत्पन्न [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) को अपडेट करें।

इमेज ट्रांसपेरेंसी, क्रॉपिंग और अन्य चित्र-विशिष्ट इफ़ेक्ट्स के लिए, देखें [चित्र फ़्रेम प्रबंधन](/slides/hi/net/picture-frame/). ये ऑपरेशन्स चित्र फ्रेम या चित्र फ़िल से संबंधित हैं, न कि प्लेसहोल्डर मेटाडेटा से।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

एक भरा हुआ चार्ट प्लेसहोल्डर को एक [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रनटाइम इंटरफ़ेस दोनों द्वारा ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

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

एक सामान्य कंटेंट प्लेसहोल्डर आम तौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों जैसे चार्ट, टेबल, डायाग्राम, चित्र, और मीडिया के लिए लॉन्चर के रूप में कार्य करता है। एक बार भरने के बाद, यह जानने के लिए वास्तविक आकार इंटरफ़ेस निरीक्षण करें कि इसमें क्या है। विशेषीकृत लेआउट भी [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides केवल [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) बदलने से एक खाली [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) प्लेसहोल्डर को [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) में नहीं बदलता; प्रकार केवल पढ़ने योग्य है। प्रोग्रामेटिक रूप से एक खाली चार्ट या कंटेंट एरिया भरने के लिए, प्लेसहोल्डर के निर्देशांक पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर हटाएँ। निम्न उदाहरण चार्ट के लिए यह करता है:

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

जोड़ाया गया चार्ट एक साधारण स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से इनहेरिट नहीं करता। जब आपको उसकी श्रेणियों, श्रृंखलाओं, या वर्कबुक डेटा को बदलने की आवश्यकता हो, तो समर्पित [चार्ट प्रबंधन लेख](/slides/hi/net/powerpoint-charts/) का उपयोग करें।

## **पूर्ण उदाहरण: टेक्स्ट या इमेज कंटेंट अपडेट करें**

निम्न अंत-से-अंत उदाहरण एक टेम्पलेट खोलता है, पहले स्लाइड में शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकारों की जाँच करता है, उचित कंटेंट अपडेट करता है, और आउटपुट सहेजता है। उदाहरण जानबूझकर शाप इंडेक्स मानने या सभी प्लेसहोल्डर को एक ही इंटरफ़ेस में कास्ट करने से बचता है।

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

**एक बेस प्लेसहोल्डर क्या है?**

एक बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर होता है, जिससे अन्य प्लेसहोल्डर इनहेरिट करता है। इसे प्राप्त करने के लिए [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) का उपयोग करें। एक साधारण स्थानीय आकार `null` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं सभी स्लाइड शीर्षकों को लेआउट प्लेसहोल्डर को संपादित करके बदल सकता हूँ?**

आप लेआउट के माध्यम से इनहेरिटेड फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत रहती है। पूरी प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों पर इटररेट करें और प्रत्येक शीर्षक प्लेसहोल्डर अपडेट करें।

**मैं डेट, स्लाइड-नंबर, हेडर, और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप में हेडर और फुटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए [प्रेजेंटेशन हेडर और फुटर प्रबंधन](/slides/hi/net/presentation-header-and-footer/) देखें।