---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/net/examples/elements/layout-slide/
keywords:
- लेआउट स्लाइड
- लेआउट स्लाइड जोड़ें
- लेआउट स्लाइड एक्सेस करें
- लेआउट स्लाइड हटाएँ
- उपयोग न किए गए लेआउट स्लाइड
- लेआउट स्लाइड क्लोन करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में मुख्य लेआउट स्लाइड्स: स्लाइड लेआउट, प्लेसहोल्डर और मास्टर को चुनें, लागू करें और कस्टमाइज़ करें, साथ ही PPT, PPTX और ODP प्रस्तुतियों के लिए C# उदाहरणों के साथ।"
---
यह लेख दिखाता है कि **Layout Slides** को Aspose.Slides for .NET में कैसे उपयोग किया जाता है। एक लेआउट स्लाइड वह डिज़ाइन और फ़ॉर्मेटिंग परिभाषित करती है जो सामान्य स्लाइड्स द्वारा विरासत में मिलती है। आप लेआउट स्लाइड्स को जोड़, एक्सेस, क्लोन और हटाकर, साथ ही अनउपयोगी स्लाइड्स को साफ़ करके प्रस्तुति का आकार कम कर सकते हैं।

## **Add a Layout Slide**

आप पुन: उपयोग योग्य फ़ॉर्मेटिंग निर्धारित करने के लिए एक कस्टम लेआउट स्लाइड बना सकते हैं। उदाहरण के लिए, आप एक टेक्स्ट बॉक्स जोड़ सकते हैं जो इस लेआउट का उपयोग करने वाली सभी स्लाइड्स में दिखाई देगा।

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // एक खाली लेआउट प्रकार और एक कस्टम नाम के साथ लेआउट स्लाइड बनाएँ।
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // लेआउट स्लाइड में एक टेक्स्ट बॉक्स जोड़ें।
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // इस लेआउट का उपयोग करके दो स्लाइड्स जोड़ें; दोनों लेआउट से टेक्स्ट विरासत में प्राप्त करेंगे।
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** लेआउट स्लाइड्स व्यक्तिगत स्लाइड्स के लिए टेम्प्लेट के रूप में कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित करके कई स्लाइड्स में पुनः उपयोग कर सकते हैं।

> 💡 **Note 2:** जब आप लेआउट स्लाइड में शैप या टेक्स्ट जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइड्स स्वचालित रूप से यह साझा सामग्री प्रदर्शित करेंगे।  
> नीचे दिया गया स्क्रीनशॉट दो स्लाइड्स को दिखाता है, जिनमें से प्रत्येक समान लेआउट स्लाइड से एक टेक्स्ट बॉक्स विरासत में प्राप्त करता है।

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

लेआउट स्लाइड्स को इंडेक्स या लेआउट प्रकार (जैसे `Blank`, `Title`, `SectionHeader` आदि) द्वारा एक्सेस किया जा सकता है।

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // इंडेक्स द्वारा लेआउट स्लाइड तक पहुँचें।
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // प्रकार द्वारा लेआउट स्लाइड तक पहुँचें।
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Remove a Layout Slide**

यदि कोई लेआउट स्लाइड अब आवश्यक नहीं है, तो आप उसे हटा सकते हैं।

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और इसे हटाएँ।
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Remove Unused Layout Slides**

प्रेजेंटेशन का आकार घटाने के लिए आप उन लेआउट स्लाइड्स को हटाना चाह सकते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं हो रही हैं।

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // स्वचालित रूप से सभी लेआउट स्लाइड्स को हटाता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clone a Layout Slide**

आप `AddClone` मेथड का उपयोग करके एक लेआउट स्लाइड को डुप्लिकेट कर सकते हैं।

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें।
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // लेआउट स्लाइड को लेआउट स्लाइड संग्रह के अंत में क्लोन करें।
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** लेआउट स्लाइड्स स्लाइड्स में सुसंगत फ़ॉर्मेटिंग प्रबंधित करने के लिए शक्तिशाली टूल हैं। Aspose.Slides लेआउट स्लाइड्स को बनाने, प्रबंधित करने और अनुकूलित करने पर पूर्ण नियंत्रण प्रदान करता है।