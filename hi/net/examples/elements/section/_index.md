---
title: सेक्शन
type: docs
weight: 90
url: /hi/net/examples/elements/section/
keywords:
- सेक्शन
- स्लाइड सेक्शन
- सेक्शन जोड़ें
- सेक्शन तक पहुँचें
- सेक्शन हटाएँ
- सेक्शन का नाम बदलें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड सेक्शन प्रबंधित करें: स्लाइड्स को बनाएँ, नाम बदलें, पुनर्स्थित करें, और समूहित करें। PPT, PPTX और ODP के लिए C# उदाहरणों के साथ।"
---
प्रेज़ेंटेशन सेक्शन्स को प्रोग्रामेटिकली प्रबंधित करने के उदाहरण—जोड़ना, एक्सेस करना, हटाना और उनका नाम बदलना, **Aspose.Slides for .NET** का उपयोग करके।

## **सेक्शन जोड़ें**
एक सेक्शन बनाएं जो किसी विशिष्ट स्लाइड से शुरू होता है।

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // सेक्शन की शुरुआत को इंगित करने वाली स्लाइड निर्दिष्ट करें।
    presentation.Sections.AddSection("New Section", slide);
}
```

## **सेक्शन तक पहुँचें**
प्रेज़ेंटेशन से सेक्शन की जानकारी पढ़ें।

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // इंडेक्स द्वारा सेक्शन तक पहुँचें।
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **सेक्शन हटाएँ**
पहले जोड़े गए सेक्शन को हटाएँ।

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // पहला सेक्शन हटाएँ।
    presentation.Sections.RemoveSection(section);
}
```

## **सेक्शन का नाम बदलें**
मौजूदा सेक्शन का नाम बदलें।

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```