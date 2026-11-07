---
title: .NET में प्रस्तुतियों में फ़ॉन्ट एंबेड करें
linktitle: एंबेडेड फ़ॉन्ट
type: docs
weight: 40
url: /hi/net/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एंबेड करें
- फ़ॉन्ट एंबेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ PowerPoint में एंबेडेड फ़ॉन्ट प्रबंधित करें। फ़ॉन्ट जोड़ने, प्राप्त करने, हटाने और संपीड़न के लिए C# का उपयोग करें ताकि टेक्स्ट की उपस्थिति बनी रहे और फ़ाइल आकार घटे।"
---
## **परिचय**

फ़ॉन्ट एंबेड करने से फ़ॉन्ट डेटा पावरपॉइंट प्रस्तुति में संग्रहित हो जाता है। जब दर्शक एंबेडेड फ़ॉन्ट का समर्थन करता है, तो वह लक्ष्य प्रणाली पर फ़ॉन्ट स्थापित न होने पर भी टेक्स्ट को उन फ़ॉन्टों के साथ प्रदर्शित कर सकता है। यह लाइन ब्रेक, टेक्स्ट स्पेसिंग और स्लाइड लेआउट को संरक्षित रखने में मदद करता है।

Aspose.Slides for .NET आपको एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) की [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) प्रॉपर्टी के माध्यम से एंबेडेड फ़ॉन्ट को प्राप्त करने, जोड़ने और हटाने की अनुमति देती है। आप प्रस्तुतिकरण में उपयोग न किए गए अक्षरों को हटाकर एंबेडेड फ़ॉन्ट डेटा का आकार भी घटा सकते हैं।

निम्न उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट एंबेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के पास उपलब्ध है और उसका लाइसेंस एंबेडिंग की अनुमति देता है।

## **एंबेडेड फ़ॉन्ट प्राप्त करना और हटाना**

प्रस्तुति में संग्रहित फ़ॉन्ट को सूचीबद्ध करने के लिए [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) का उपयोग करें। किसी फ़ॉन्ट को हटाने के लिए उस सूची से फ़ॉन्ट को [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) को पास करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एंबेडेड फ़ॉन्ट को सूचीबद्ध करता है और यदि मौजूद हो तो Calibri को हटाता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

एंबेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह टेक्स्ट को सौंपे गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य प्रणाली पर स्थापित है, तो टेक्स्ट अभी भी उसे उपयोग कर सकता है। अन्यथा, रेंडरिंग को [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) की आवश्यकता हो सकती है, जिससे लेआउट प्रभावित हो सकता है।

## **फ़ॉन्ट डेटा और एंबेडिंग अनुमतियों की जांच**

फ़ॉन्ट को एंबेड करने से पहले जांचने के लिए [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) इंटरफ़ेस का उपयोग करें। प्रस्तुति में उपयोग किए गए फ़ॉन्ट को प्राप्त करने के लिए [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए एक [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) मान को [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) को पास करें। यह मेथड उस फ़ॉन्ट स्टाइल के बाइनरी डेटा को लौटाता है, या `null` जब माँगा गया फ़ॉन्ट या स्टाइल उपलब्ध नहीं होता। `null` परिणाम को [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) को न पास करें, क्योंकि वह मेथड बाइट एरे की अपेक्षा करता है।

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) एक फ़्लैग्स एनीमरेशन है जो फ़ॉन्ट में संग्रहीत एंबेडिंग प्रतिबंधों को रिपोर्ट करता है:

- `Installable` एंबेडिंग और दूसरी प्रणाली पर स्थायी स्थापना की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` केवल तब एंबेडिंग की अनुमति देता है जब फ़ॉन्ट के कानूनी मालिक से अनुमति प्राप्त की गई हो, यदि यह एकमात्र उपयोग-अधिकार फ़्लैग है।
- `PreviewPrint` अस्थायी रूप से देखने और प्रिंट करने की अनुमति देता है; फ़ॉन्ट युक्त दस्तावेज़ केवल पढ़ने‑के‑लिए होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजने की अनुमति देता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो अक्षरों के केवल उपसमुच्चय को एंबेड करने से रोकता है। जब यह फ़्लैग मौजूद हो तो सभी अक्षर एंबेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एंबेड करने की अनुमति देता है, रूपरेखा डेटा को नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एंबेड नहीं किया जा सकता।

पहले चार मान उपयोग‑अनुमति का वर्णन करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ जोड़ा जा सकता है। बिटवाइज़ ऑपरेशनों से मॉडिफ़ायर की जांच करें। चूंकि `Installable` शून्य है, इसे पहचानने के लिए `HasFlag` का उपयोग न करें; उपयोग‑अनुज्ञा बिट्स को मास्क करके परिणाम की तुलना `Installable` से करें। वर्तमान फ़ॉन्ट को अधिकतम एक उपयोग‑अनुज्ञा बिट सेट करना चाहिए। पुराने फ़ॉन्ट जो एक से अधिक सेट करते हैं, के लिए नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण `GetFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक और बोल्ड‑इटैलिक डेटा का ऑडिट करता है। यह अनुपलब्ध स्टाइल, प्रतिबंधित फ़ॉन्ट, केवल‑बिटमैप फ़ॉन्ट, केवल‑प्रिव्यू‑प्रिंट फ़ॉन्ट (क्योंकि आउटपुट अभी भी संपादन‑योग्य रहता है) और पहले से एंबेडेड फ़ॉन्ट को छोड़ देता है। यदि किसी उपलब्ध स्टाइल में `NoSubsetting` है, तो वह फ़ॉन्ट परिवार के सभी अक्षर एंबेड करता है।

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

यह जांच प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करती है। यह कोई लाइसेंस नहीं देता, यह साबित नहीं करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, और एंबेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जांच को प्रतिस्थापित नहीं करती।

## **एंबेडेड फ़ॉन्ट जोड़ना**

फ़ॉन्ट को एंबेड करने के लिए [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) का उपयोग करें। इसके ओवरलोड्स या तो एक [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाला बाइट एरे स्वीकार करते हैं। कौन से अक्षर शामिल किए जाएँ, यह नियंत्रित करने के लिए [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) एनीमरेशन प्रयोग किया जाता है:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) फ़ॉन्ट में सभी अक्षर एंबेड करता है। जब प्राप्तकर्ताओं को प्रस्तुति संपादित करनी हो और नया टेक्स्ट जोड़ना हो, तब इस विकल्प का उपयोग करें।
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) केवल प्रस्तुति में प्रयुक्त अक्षरों को एंबेड करता है ताकि फ़ाइल आकार कम हो। समाप्त प्रस्तुति के लिए जो मुख्यतः देखने के उद्देश्य से है, इस विकल्प को चुनें।

निम्न उदाहरण `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट को प्राप्त करने के लिए [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) का उपयोग करता है और उन फ़ॉन्ट को एंबेड करता है जो पहले से एंबेड नहीं हैं। जोड़ने वाले फ़ॉन्ट को उस मशीन पर उपलब्ध होना चाहिए जहाँ कोड चल रहा है। मौजूदा एंबेडेड फ़ॉन्ट अपना वर्तमान कैरेक्टर सेट बनाए रखते हैं।

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **एंबेडेड फ़ॉन्ट संपीड़ित करना**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) उपयोग न किए गए अक्षरों को हटाकर एंबेडेड फ़ॉन्ट डेटा को घटाता है। यह पहले से एंबेडेड फ़ॉन्ट पर काम करता है, इसलिए आकार में कमी इस बात पर निर्भर करती है कि प्रस्तुति में कितना अप्रयुक्त फ़ॉन्ट डेटा है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट को संपीड़ित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

यदि प्राप्तकर्ता बाद में टेक्स्ट जोड़ सकते हैं, तो मूल फ़ाइल रखें। संपीड़न के दौरान हटाए गए अक्षर एंबेडेड फ़ॉन्ट से अब उपलब्ध नहीं रहेंगे, भले ही आपने शुरू में सभी अक्षर एंबेड किए हों।

एक मेल खाने वाले पंजीकृत फ़ॉन्ट को निर्यात के दौरान प्राथमिकता देने के लिए, एंबेडेड फ़ॉन्ट को हटाए बिना, देखें [Prefer Registered Fonts over Embedded Fonts](/slides/hi/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 या बाद का संस्करण)।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि एंबेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा या नहीं?**

जिस वातावरण में आप प्रस्तुति रेंडर करते हैं, वहाँ [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) को कॉल करें ताकि पता चल सके कि Aspose.Slides कौन से फ़ॉन्ट को बदल देगा। साथ ही [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) सेटिंग्स और [फ़ॉन्ट फ़ॉलबैक](/slides/hi/net/fallback-font/) नियमों की जाँच करें। फ़ॉलबैक गायब अक्षरों को संभालता है, इसलिए फ़ॉन्ट एंबेड करना उन अक्षरों को हल नहीं करता जो स्वयं फ़ॉन्ट में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट एंबेड करने चाहिए?**

निर्णय लक्ष्य वातावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति खोलती या रेंडर करती है, तो उन्हें एंबेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर उन फ़ॉन्ट को नहीं रखते, तो एंबेड करने से इच्छित रूप‑रेखा बनी रहती है, बशर्ते उनका लाइसेंस एंबेडिंग की अनुमति देता हो।