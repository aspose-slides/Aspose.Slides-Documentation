---
title: .NET में प्रस्तुतियों में फ़ॉन्ट एंबेड करें
linktitle: फ़ॉन्ट एंबेड करना
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
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एंबेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

**PowerPoint** में फ़ॉन्ट एंबेड करने से आपकी प्रस्तुति विभिन्न सिस्टमों पर अपनी इच्छित रूपरेखा बनाए रखती है। रचनात्मकता के लिए विशिष्ट फ़ॉन्ट या मानक फ़ॉन्ट का उपयोग चाहे, फ़ॉन्ट एंबेड करने से पाठ और लेआउट में बाधा नहीं आती।

यदि आपने अपने काम में रचनात्मकता दिखाने के लिए थर्ड‑पार्टी या गैर‑मानक फ़ॉन्ट का प्रयोग किया है, तो फ़ॉन्ट एंबेड करने के और भी कारण बनते हैं। अन्यथा (एंबेडेड फ़ॉन्ट न होने पर) आपके स्लाइड्स पर टेक्स्ट या नंबर, लेआउट, स्टाइल आदि बदल सकते हैं या भ्रमित करने वाले आयत में बदल सकते हैं।

एंबेडेड फ़ॉन्ट को प्रबंधित करने के लिए [FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/hi/net/aspose.slides/fontdata/), और [Compress](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/) क्लासों का उपयोग करें।

## **एंबेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

[GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts) और [RemoveEmbeddedFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/removeembeddedfont) मेथड्स के साथ आप प्रस्तुति से एंबेडेड फ़ॉन्ट को आसानी से प्राप्त या हटासकते हैं।

यह C# कोड दिखाता है कि कैसे प्रस्तुति से एंबेडेड फ़ॉन्ट को प्राप्त और हटाया जा सकता है:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // एंबेडेड "FunSized" का उपयोग करने वाले टेक्स्ट फ्रेम वाले स्लाइड को रेंडर करता है
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // "Calibri" फ़ॉन्ट खोजता है
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // "Calibri" फ़ॉन्ट हटाता है
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // प्रस्तुति रेंडर करता है; "Calibri" फ़ॉन्ट को एक मौजूदा फ़ॉन्ट से बदल दिया जाता है
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // एंबेडेड "Calibri" फ़ॉन्ट के बिना प्रस्तुति को डिस्क पर सहेजता है
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **एंबेडेड फ़ॉन्ट जोड़ें**

[EmbedFontCharacters](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedfontcharacters/) एन्‍युम और [AddEmbeddedFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/addembeddedfont/) मेथड के दो ओवरलोड का उपयोग करके आप अपनी पसंदीदा (एंबेडिंग) नियम चुन सकते हैं और फ़ॉन्ट को प्रस्तुति में एंबेड कर सकते हैं। यह C# कोड दिखाता है कि कैसे फ़ॉन्ट को एंबेड और जोड़ें:

```c#
 // प्रस्तुति लोड करता है
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// प्रस्तुति को डिस्क पर सहेजता है
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **एंबेडेड फ़ॉन्ट को संपीड़ित करें**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) का उपयोग करके एंबेडेड फ़ॉन्ट को संपीड़ित करके फ़ाइल आकार को अनुकूलित करें।

संपीड़न के लिए उदाहरण कोड:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे निर्धारित करूँ कि प्रस्तुति में कोई विशिष्ट फ़ॉन्ट एंबेडिंग के बावजूद रेंडरिंग के समय भी प्रतिस्थापित होगा?**  
फ़ॉन्ट मैनेजर में [substitution information](/slides/hi/net/font-substitution/) और [fallback/substitution rules](/slides/hi/net/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो फ़ॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे "सिस्टम" फ़ॉन्ट को एंबेड करना सार्थक है?**  
आमतौर पर नहीं—ये फ़ॉन्ट लगभग हमेशा उपलब्ध होते हैं। लेकिन "थिन" वातावरण (Docker, प्री‑इंस्टॉल्ड फ़ॉन्ट न वाले Linux सर्वर) में पूर्ण पोर्टेबिलिटी के लिये सिस्टम फ़ॉन्ट को एंबेड करने से अनपेक्षित प्रतिस्थापन का जोखिम समाप्त हो सकता है।