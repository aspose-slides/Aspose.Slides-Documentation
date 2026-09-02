---
title: ".NET में PowerPoint फ़ॉन्ट को अनुकूलित करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/net/custom-font/
keywords:
- "फ़ॉन्ट"
- "कस्टम फ़ॉन्ट"
- "बाहरी फ़ॉन्ट"
- "फ़ॉन्ट लोड करें"
- "फ़ॉन्ट प्रबंधित करें"
- "फ़ॉन्ट फ़ोल्डर"
- "पावरपॉइंट"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को अनुकूलित करें ताकि आपकी प्रस्तुतियां किसी भी डिवाइस पर तीक्ष्ण और सुसंगत रहें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़‑स्तरीय फ़ॉन्ट स्रोतों के माध्यम से किसी विशेष प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब किसी प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के तौर पर PDF, छवियों, और अन्य समर्थित फ़ॉर्मैट्स में। इससे विभिन्न वातावरणों में प्रस्तुति आउटपुट सुसंगत रहता है। इस लेख में यह भी बताया गया है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को रजिस्टर करना फ़ॉन्ट्स को PPTX फ़ाइल में एम्बेड करने से अलग है। यदि किसी फ़ॉन्ट को सीधे प्रस्तुति में संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग फीचर को स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड का उपयोग करके लोड करने की सुविधा देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। अधिक जानकारी के लिए देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) फ़ॉन्ट्स। अधिक जानकारी के लिए देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, छवियों, और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट्स को कस्टम निर्देशिकाओं से लोड किया जाता है।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डरों को निर्दिष्ट करें।
2. उन फ़ोल्डरों से फ़ॉन्ट लोड करने के लिए स्थैतिक [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.ClearCache](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/clearcache/) को कॉल करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियां, या अन्य फ़ॉर्मेट)।
presentation.Save("output.pdf", SaveFormat.Pdf);

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader.ClearCache();
```

{{% alert color="info" title="नोट" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन यह फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ किए जाते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. फ़ॉन्ट्स को [FontsLoader](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पथ।  
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides आपको फ़ॉन्ट फ़ोल्डर खोजने के लिए [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) मेथड प्रदान करता है। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह C# कोड दर्शाता है कि आप [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) का उपयोग कैसे कर सकते हैं:

```c#
using Aspose.Slides;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जिन्हें फ़ॉन्ट फ़ाइलों के लिए जाँच किया जाता है.
// ये फ़ोल्डर LoadExternalFonts मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर हैं.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides आपको प्रस्तुतिकरण के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स को निर्दिष्ट करने के लिए [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी प्रदान करता है।

यह C# कोड दर्शाता है कि आप [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी का उपयोग कैसे कर सकते हैं:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**
Aspose.Slides आपको बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड करने के लिए [LoadExternalFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) मेथड प्रदान करता है।

यह C# कोड बाइट एरे फ़ॉन्ट लोड करने की प्रक्रिया दर्शाता है: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // प्रस्तुति के जीवनकाल के दौरान बाहरी फ़ॉन्ट लोड किया गया
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**  
हाँ। जुड़े हुए फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट्स स्वतः परिणामस्वरूप PPTX में एम्बेड हो जाते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट को रजिस्टर करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के अंदर रखना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/net/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ नहीं होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हाँ। आप [font substitution](/slides/hi/net/font-substitution/), [replacement rules](/slides/hi/net/font-replacement/), और [fallback sets](/slides/hi/net/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को सिस्टम‑व्यापी रूप से इंस्टॉल किए बिना उपयोग कर सकता हूँ?**  
हाँ। आप अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर संकेत कर सकते हैं या बाइट एरे से फ़ॉन्ट्स लोड कर सकते हैं। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट निर्देशिकाओं पर निर्भरता समाप्त हो जाती है।

> **Linux/Docker के लिए नोट**: `FontsLoader.LoadExternalFonts` को कॉल करते समय यह सुनिश्चित करें कि `directories` एरे में प्रत्येक एंट्री में किसी मौजूदा निर्देशिका का गैर‑खाली पाथ हो। यदि फ़ॉन्ट पाथ बनाने के लिए उपयोग किया गया पर्यावरण‑चर अपरिभाषित या खाली है, तो Aspose.Slides उस खाली मान को पूर्ण पाथ के रूप में हल करने की कोशिश कर सकता है, जिससे `System.ArgumentException` उत्पन्न हो सकता है।

**लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एम्बेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।