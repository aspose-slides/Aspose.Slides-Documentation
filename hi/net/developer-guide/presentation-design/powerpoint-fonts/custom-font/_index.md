---
title: PowerPoint फ़ॉन्ट्स को .NET में अनुकूलित करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स में फ़ॉन्ट्स को अनुकूलित करें ताकि आपके प्रस्तुतियां किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **Overview**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स को ऑपरेटिंग सिस्टम पर इंस्टॉल किए बिना उपयोग करने की अनुमति देता है। आप कस्टम फ़ोल्डरों से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़-स्तरीय फ़ॉन्ट स्रोतों के माध्यम से एक विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, इमेजेज और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डरों की जांच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को रजिस्टर करना, फ़ॉन्ट्स को PPTX फ़ाइल में एम्बेड करने से अलग है। यदि किसी फ़ॉन्ट को प्रस्तुति के भीतर ही संग्रहीत होना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="info" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।
{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट को प्रभावित करता है—जैसे PDF, इमेजेज और अन्य समर्थित फ़ॉर्मैट्स—जिससे परिणामस्वरूप दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्ट्रीज़ से लोड किए जाते हैं।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डरों को निर्दिष्ट करें।
2. स्थैतिक [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/clearcache/) को कॉल करके फ़ॉन्ट कैश साफ़ करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को निर्धारित करें।
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (उदा., PDF, इमेजेज, या अन्य फ़ॉर्मैट्स)।
presentation.Save("output.pdf", SaveFormat.Pdf);

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पाथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन यह फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/) द्वारा लोड किए गए पाथ।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides आपके लिए फ़ॉन्ट फ़ोल्डर्स खोजने हेतु [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) मेथड प्रदान करता है। यह मेथड उन फ़ोल्डरों को वापस करता है जो `LoadExternalFonts` मेथड के माध्यम से जोड़े गए हैं और सिस्टम फ़ॉन्ट फ़ोल्डर्स।

```c#
using Aspose.Slides;

// यह पंक्ति फ़ॉन्ट फ़ाइलों के लिए जाँचे गए फ़ोल्डरों को आउटपुट करती है。
// ये वे फ़ोल्डर हैं जो LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides आपके लिए वह [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी प्रदान करता है जिससे आप प्रस्तुति के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स निर्दिष्ट कर सकते हैं।

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
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं।
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides आपको बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड करने के लिए [LoadExternalFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) मेथड प्रदान करता है।

यह C# कोड बाइट ऐरे फ़ॉन्ट लोड करने की प्रक्रिया दर्शाता है:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // प्रेजेंटेशन के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?**

हाँ। कनेक्टेड फ़ॉन्ट्स का उपयोग रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में किया जाता है।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?**

नहीं। रेंडरिंग के लिए फ़ॉन्ट को रजिस्टर करना, उसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/net/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फॉलबैक व्यवहार नियंत्रित कर सकता हूँ?**

हाँ। जब अनुरोधित ग्लिफ़ अनुपलब्ध हो तो कौन सा फ़ॉन्ट उपयोग किया जाना चाहिए, इसे परिभाषित करने के लिए आप [font substitution](/slides/hi/net/font-substitution/), [replacement rules](/slides/hi/net/font-replacement/), और [fallback sets](/slides/hi/net/fallback-font/) को कॉन्फ़िगर कर सकते हैं।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स का उपयोग सिस्टम-व्यापी इंस्टॉल किए बिना कर सकता हूँ?**

हाँ। आप अपने फ़ॉन्ट फ़ोल्डरों की ओर संकेत कर सकते हैं या बाइट ऐरे से फ़ॉन्ट्स लोड कर सकते हैं। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्ट्रीज़ पर निर्भरता समाप्त हो जाती है।

> **Linux/Docker के लिए नोट**: जब `FontsLoader.LoadExternalFonts` को कॉल किया जाता है, तो सुनिश्चित करें कि `directories` ऐरे में प्रत्येक एंट्री में मौजूद डायरेक्ट्री के लिए एक गैर-खाली पाथ हो। यदि फ़ॉन्ट पाथ बनाने के लिए प्रयुक्त वातावरण चर अपरिभाषित या खाली है, तो Aspose.Slides खाली मान को पूर्ण पाथ के रूप में हल करने की कोशिश कर सकता है, जिससे `System.ArgumentException` उत्पन्न होता है।

**लेसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**

आप फ़ॉन्ट लेसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।