---
title: .NET में प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: एम्बेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/net/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint में एम्बेडेड फ़ॉन्ट्स प्रबंधित करें। फ़ॉन्ट्स को जोड़ने, प्राप्त करने, हटाने और संकुचित करने के लिए C# का उपयोग करें ताकि टेक्स्ट का स्वरूप बना रहे और फ़ाइल आकार कम हो।"
---
## **परिचय**

फ़ॉन्ट एम्बेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के भीतर संग्रहीत हो जाता है। जब दर्शक एम्बेडेड फ़ॉन्ट्स को सपोर्ट करता है, तो यह उन फ़ॉन्ट्स का उपयोग करके टेक्स्ट प्रदर्शित कर सकता है भले ही वे लक्ष्य प्रणाली पर स्थापित न हों। यह लाइन ब्रेक, टेक्स्ट स्पेसिंग और स्लाइड लेआउट को बनाए रखने में मदद करता है।

Aspose.Slides for .NET आपको एम्बेडेड फ़ॉन्ट्स को प्राप्त करने, जोड़ने और हटाने की सुविधा देता है, यह [FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/fontsmanager/) प्रॉपर्टी के माध्यम से एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) की होती है। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे के उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट एम्बेड करने से पहले, सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides को उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट्स प्राप्त करें और हटाएँ**

एक प्रस्तुति में संग्रहीत फ़ॉन्ट्स की सूची प्राप्त करने के लिए [GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) का उपयोग करें। उन्हें हटाने के लिए, उस सूची से एक फ़ॉन्ट को [RemoveEmbeddedFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/removeembeddedfont/) में पास करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट्स की सूची देता है और यदि मौजूद हो तो Calibri को हटाता है:
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

एक एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हटा दिया जाता है; यह टेक्स्ट को असाइन किए गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य प्रणाली पर स्थापित है, तो टेक्स्ट फिर भी उसका उपयोग कर सकता है। अन्यथा, रेंडरिंग को [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) की आवश्यकता हो सकती है, जिससे लेआउट प्रभावित हो सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमति की जाँच करें**

फ़ॉन्ट्स को एम्बेड करने से पहले उनकी जाँच करने के लिए आप [IFontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/) इंटरफ़ेस का उपयोग कर सकते हैं। प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [IFontsManager.GetFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getfonts/) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [IFontData](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/net/aspose.slides/fontstyletype/) मान को [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getfontbytes/) में पास करें। यह मेथड उस फ़ॉन्ट स्टाइल के लिए बाइनरी डेटा लौटाता है, या जब अनुरोधित फ़ॉन्ट या स्टाइल उपलब्ध नहीं हो तो `null` लौटाता है। `null` परिणाम को [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) में पास न करें, क्योंकि इस मेथड को बाइट एरे की आवश्यकता होती है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/net/aspose.slides/embeddinglevel/) एक फ़्लैग्स एन्यूमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों की रिपोर्ट करता है:

- `Installable` एम्बेडिंग और दूसरे सिस्टम पर स्थायी इंस्टॉलेशन की अनुमति देता है, बशर्ते फ़ॉन्ट लाइसेंस की शर्तें पूरी हों।
- `Restricted` एम्बेडिंग को प्रतिबंधित करता है जब तक कि फ़ॉन्ट के कानूनी मालिक से अनुमति न प्राप्त हो, यदि यह एकमात्र उपयोग-परमिशन फ़्लैग हो।
- `PreviewPrint` दृश्य और प्रिंटिंग के लिए अस्थायी उपयोग की अनुमति देता है; फ़ॉन्ट शामिल करने वाला दस्तावेज़ केवल-रेड होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित तथा सहेजने की इजाजत देता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो ग्लिफ़ के केवल उपसमुच्चय को एम्बेड करने से रोकता है। जब यह फ़्लैग मौजूद हो तो सभी अक्षरों को एम्बेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एम्बेड करने की अनुमति देता है, आउटलाइन डेटा को नहीं। यदि फ़ॉन्ट में कोई बिटमैप स्ट्राइक नहीं है, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग की अनुमति का विवरण देते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ जोड़ा जा सकता है। मॉडिफ़ायर्स की जाँच बिटवाइस ऑपरेशन्स से करें। क्योंकि `Installable` शून्य है, इसे पहचानने के लिए `HasFlag` का उपयोग न करें; उपयोग-परमिशन बिट्स को मास्क करके परिणाम को `Installable` से तुलना करें। वर्तमान फ़ॉन्ट्स को अधिकतम एक उपयोग-परमिशन बिट सेट करना चाहिए। अधिक फ़ॉन्ट्स जो एक से अधिक सेट करते हैं, उनके साथ संगतता के लिए नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण `GetFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक और बोल्ड-इटैलिक डेटा की जाँच करता है। यह उपलब्ध न होने वाली स्टाइल, प्रतिबंधित फ़ॉन्ट, बिटमैप-ओनली फ़ॉन्ट, प्रीव्यू और प्रिंट तक सीमित फ़ॉन्ट (क्योंकि आउटपुट संपादन योग्य रहता है) और पहले से एम्बेडेड फ़ॉन्ट को छोड़ देता है। यदि किसी उपलब्ध स्टाइल में `NoSubsetting` हो, तो वह फ़ॉन्ट परिवार के सभी अक्षर एम्बेड करता है।
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

यह जाँच प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करती है। यह लाइसेंस नहीं देती, यह प्रमाणित नहीं करती कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, और एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच का स्थान नहीं लेती।

## **एम्बेडेड फ़ॉन्ट्स जोड़ें**

[AddEmbeddedFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/addembeddedfont/) का उपयोग करके फ़ॉन्ट एम्बेड करें। उसके ओवरलोड्स या तो एक [IFontData](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाले बाइट एरे को स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedfontcharacters/) एन्यूमरेशन नियंत्रित करता है कि कौन से अक्षर शामिल किए जाएँ:

- [All](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedfontcharacters/) फ़ॉन्ट के सभी अक्षरों को एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ताओं को प्रस्तुति को संपादित करने और नया टेक्स्ट दर्ज करने की आवश्यकता हो।
- [OnlyUsed](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedfontcharacters/) केवल प्रस्तुति में उपयोग किए गए अक्षरों को एम्बेड करता है ताकि फ़ाइल आकार कम हो। इस विकल्प को तब चुनें जब प्रस्तुति मुख्यतः देखने के लिये तैयार हो।

निम्न उदाहरण [GetFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getfonts/) का उपयोग करके `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट्स को प्राप्त करता है और उन फ़ॉन्ट्स को एम्बेड करता है जो पहले से एम्बेड नहीं हैं। जोड़ने वाले फ़ॉन्ट्स को कोड चलाने वाली मशीन पर उपलब्ध होना चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट्स अपने वर्तमान कैरेक्टर सेट को बरकरार रखते हैं।
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

## **एम्बेडेड फ़ॉन्ट्स संकुचित करें**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा को कम करता है। यह पहले से एम्बेड किए गए फ़ॉन्ट्स पर काम करता है, इसलिए आकार की कमी इस पर निर्भर करती है कि प्रस्तुति में कितनी अनउपयोगी फ़ॉन्ट डेटा मौजूद है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट्स को संकुचित करता है और परिणाम को अलग फ़ाइल के रूप में सहेजता है:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

यदि प्राप्तकर्ताओं को बाद में टेक्स्ट जोड़ने की आवश्यकता हो तो मूल फ़ाइल रखें। संकुचन के दौरान हटाए गए अक्षर एम्बेडेड फ़ॉन्ट से अब उपलब्ध नहीं रहेंगे, चाहे आपने प्रारम्भ में सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि रेंडरिंग के दौरान एम्बेडेड फ़ॉन्ट अभी भी प्रतिस्थापित किया जाएगा या नहीं?**

उस वातावरण में जहाँ आप प्रस्तुति रेंडर करते हैं, [GetSubstitutions](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getsubstitutions/) को कॉल करें ताकि आप देख सकें कि Aspose.Slides कौन से फ़ॉन्ट्स को बदलेगा। साथ ही [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/) सेटिंग्स और [फ़ॉन्ट फॉलबैक](/slides/hi/net/fallback-font/) नियमों की जाँच करें। फॉलबैक लापता अक्षरों को संभालता है, इसलिए फ़ॉन्ट को एम्बेड करने से उन अक्षरों का समाधान नहीं होता जो फ़ॉन्ट स्वयं में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट्स को एम्बेड करना चाहिए?**

निर्णय को लक्ष्य वातावरण के आधार पर लें। यदि आवश्यक फ़ॉन्ट्स प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति को खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर इन फ़ॉन्ट्स को नहीं रखते हैं, तो उन्हें एम्बेड करने से इच्छित रूप को बनाए रखने में मदद मिल सकती है, बशर्ते उनके लाइसेंस ऐसा अनुमति दें।