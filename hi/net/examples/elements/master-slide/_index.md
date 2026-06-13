---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/net/examples/elements/master-slide/
keywords:
- मास्टर स्लाइड
- मास्टर स्लाइड जोड़ें
- मास्टर स्लाइड तक पहुँचें
- मास्टर स्लाइड हटाएँ
- अनुपयोगी मास्टर स्लाइड
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET मास्टर स्लाइड उदाहरणों का अन्वेषण करें: PPT, PPTX और ODP में स्पष्ट C# कोड के साथ मास्टर्स, प्लेसहोल्डर्स और थीम्स बनाएं, संपादित करें और शैली प्रदान करें।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड इनहेरिटेंस पदानुक्रम के शीर्ष स्तर का निर्माण करती हैं। एक **मास्टर स्लाइड** पृष्ठभूमि, लोगो, और टेक्स्ट फ़ॉर्मेटिंग जैसे सामान्य डिज़ाइन तत्वों को परिभाषित करती है। **लेआउट स्लाइड्स** मास्टर स्लाइड्स से विरासत में लेती हैं, और **नॉर्मल स्लाइड्स** लेआउट स्लाइड्स से विरासत में लेती हैं।

यह लेख Aspose.Slides for .NET का उपयोग करके मास्टर स्लाइड्स को बनाने, संशोधित करने और प्रबंधित करने का प्रदर्शन करता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण दिखाता है कि डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाइड कैसे बनाई जाए। फिर यह लेआउट इनहेरिटेंस के माध्यम से सभी स्लाइड्स में कंपनी नाम बैनर जोड़ता है।

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // मास्टर स्लाइड के शीर्ष पर कंपनी नाम के साथ बैनर जोड़ें.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // नई मास्टर स्लाइड को लेआउट स्लाइड को असाइन करें.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड को असाइन करें.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **नोट 1:** मास्टर स्लाइड्स सभी स्लाइड्स में निरंतर ब्रांडिंग या साझा डिज़ाइन तत्वों को लागू करने का तरीका प्रदान करती हैं। मास्टर में किए गए किसी भी बदलाव का स्वतः प्रभाव निर्भर लेआउट और नॉर्मल स्लाइड्स पर पड़ेगा।

> 💡 **नोट 2:** मास्टर स्लाइड में जोड़े गए किसी भी आकार या फ़ॉर्मेटिंग को लेआउट स्लाइड्स द्वारा विरासत में प्राप्त किया जाता है और क्रमशः उन लेआउट्स का उपयोग करने वाली सभी नॉर्मल स्लाइड्स द्वारा। नीचे दिया गया चित्र दिखाता है कि मास्टर स्लाइड पर जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से कैसे रेंडर होता है।

![मास्टर इनहेरिटेंस उदाहरण](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुंचें**

`Presentation.Masters` संग्रह का उपयोग करके आप मास्टर स्लाइड्स तक पहुंच सकते हैं। यहाँ बताया गया है कि उन्हें कैसे प्राप्त करें और उनके साथ काम करें:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // पहले मास्टर स्लाइड तक पहुँचें.
    var firstMasterSlide = presentation.Masters[0];

    // बैकग्राउंड प्रकार बदलें.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **मास्टर स्लाइड हटाएँ**

मास्टर स्लाइड्स को अनुक्रमणिका या संदर्भ द्वारा हटाया जा सकता है।

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // इंडेक्स द्वारा मास्टर स्लाइड हटाएँ.
    presentation.Masters.RemoveAt(0);

    // रेफरेंस द्वारा मास्टर स्लाइड हटाएँ.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुतियों में ऐसे मास्टर स्लाइड्स होते हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार को कम करने में मदद मिल सकती है।

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ (उनमें से भी जिन्हें Preserve के रूप में चिह्नित किया गया है).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```