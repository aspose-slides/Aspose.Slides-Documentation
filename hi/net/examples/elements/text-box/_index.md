---  
title: टेक्स्ट बॉक्स  
type: docs  
weight: 40  
url: /hi/net/examples/elements/text-box/  
keywords:  
- टेक्स्ट बॉक्स  
- टेक्स्ट बॉक्स जोड़ें  
- टेक्स्ट बॉक्स तक पहुँचें  
- टेक्स्ट बॉक्स हटाएँ  
- कोड उदाहरण  
- PowerPoint  
- OpenDocument  
- presentation  
- .NET  
- C#  
- Aspose.Slides  
description: "Aspose.Slides for .NET में टेक्स्ट बॉक्स के साथ काम करें: C# का उपयोग करके PPT, PPTX और ODP प्रस्तुतियों के लिए टेक्स्ट जोड़ें, स्वरूपित करें, संरेखित करें, लपेटें, ऑटॉफिट और स्टाइल करें।"  
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** को `AutoShape` द्वारा दर्शाया जाता है। लगभग कोई भी आकार टेक्स्ट रख सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई फाइल या बॉर्डर नहीं होता और यह केवल टेक्स्ट दिखाता है।

यह गाइड प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स जोड़ने, पहुँचने और हटाने के तरीके को समझाता है।

## **एक टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स साधारणतः एक `AutoShape` होता है जिसमें कोई फाइल या बॉर्डर नहीं होता और कुछ स्वरूपित टेक्स्ट होता है। इसे बनाने का तरीका इस प्रकार है:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // एक आयताकार आकार बनाएं (डिफ़ॉल्ट रूप से बॉर्डर के साथ भरा हुआ और कोई टेक्स्ट नहीं)।
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // भरण और बॉर्डर हटाएँ ताकि यह एक सामान्य टेक्स्ट बॉक्स जैसा दिखे।
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // टेक्स्ट स्वरूपण सेट करें।
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // वास्तविक टेक्स्ट सामग्री असाइन करें।
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **नोट:** कोई भी `AutoShape` जिसमें गैर-खाली `TextFrame` हो, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री द्वारा टेक्स्ट बॉक्स तक पहुँचें**

किसी विशिष्ट कुंजीशब्द (उदाहरण के लिए "Slide") को शामिल करने वाले सभी टेक्स्ट बॉक्स खोजने के लिए, आकारों के माध्यम से इटरट करें और उनके टेक्स्ट की जाँच करें:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // केवल AutoShapes संपादन योग्य टेक्स्ट रख सकते हैं।
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // मैचिंग टेक्स्ट बॉक्स के साथ कुछ करें।
            }
        }
    }
}
```

## **सामग्री द्वारा टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहले स्लाइड पर उन सभी टेक्स्ट बॉक्स को खोजता और हटाता है जिनमें एक विशिष्ट कुंजीशब्द शामिल है:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **टिप:** इटरेशन के दौरान इसे संशोधित करने से पहले हमेशा आकार संग्रह की एक प्रति बनाएं ताकि संग्रह संशोधन त्रुटियों से बचा जा सके।