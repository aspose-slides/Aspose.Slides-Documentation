---
title: ".NET में PowerPoint फ़ॉन्ट कस्टमाइज़ करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को कस्टमाइज़ करके अपनी प्रस्तुतियों को किसी भी डिवाइस पर तेज़ और सुसंगत रखें।"
---
## **अवलोकन**

Aspose.Slides आपको ऑपरेटिंग सिस्टम पर स्थापित किए बिना प्रस्तुतियों में कस्टम फ़ॉन्ट उपयोग करने की अनुमति देता है। आप कस्टम फ़ोल्डर्स से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़-स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट का उपयोग प्रस्तुति को रेंडर या निर्यात करते समय किया जाता है, जैसे PDF, छवियों और अन्य समर्थित फ़ॉर्मेट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर्स की जांच कैसे करें और बाहरी फ़ॉन्ट के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें, इसे भी समझाता है।

रेंडरिंग के लिए कस्टम फ़ॉन्ट को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एंबेड करने से अलग है। यदि किसी फ़ॉन्ट को प्रस्तुति के भीतर ही संग्रहित करना आवश्यक है, तो फ़ॉन्ट एंबेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 

Aspose Slides आपको इन फ़ॉन्ट को लोड करने की अनुमति देती है [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड का उपयोग करके:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको सिस्टम पर स्थापित किए बिना प्रस्तुति में उपयोग किए गए फ़ॉन्ट लोड करने की अनुमति देता है। यह निर्यात आउटपुट को प्रभावित करता है—जैसे PDF, छवियां और अन्य समर्थित फ़ॉर्मेट्स—ताकि परिणामी दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखें। फ़ॉन्ट कस्टम डिरेक्टरीज़ से लोड किए जाते हैं।

1. वह एक या अधिक फ़ोल्डर निर्दिष्ट करें जिसमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट लोड करने के लिए स्थिर [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.ClearCache](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```cs
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर को परिभाषित करें।
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// लोड किए गए फ़ॉन्ट का उपयोग करके प्रस्तुतीकरण को रेंडर/निर्यात करें (उदा., PDF, छवियों या अन्य फ़ॉर्मेट्स में)।
presentation.Save("output.pdf", SaveFormat.Pdf);

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता। फ़ॉन्ट इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/) द्वारा लोड किए गए पथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides आपको फ़ॉन्ट फ़ोल्डर्स खोजने के लिए [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) मेथड प्रदान करता है। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर लौटाता है।

यह C# कोड आपको दिखाता है कि [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) कैसे उपयोग करें:

```c#
// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जिन्हें फ़ॉन्ट फ़ाइलों के लिए जाँचा जाता है.
// ये फ़ोल्डर LoadExternalFonts मेथड के माध्यम से जोड़े गए और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट निर्दिष्ट करें**
Aspose.Slides आपको प्रस्तुति के साथ उपयोग होने वाले बाहरी फ़ॉन्ट निर्दिष्ट करने के लिए [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी प्रदान करता है।

यह C# कोड आपको दिखाता है कि [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी कैसे उपयोग करें:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके सबफ़ोल्डरों से फ़ॉन्ट प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट को बाहरी रूप से प्रबंधित करें**

Aspose.Slides आपको बाइनरी डेटा से बाहरी फ़ॉन्ट लोड करने के लिए [LoadExternalFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) मेथड प्रदान करता है।

यह C# कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // प्रेज़ेंटेशन के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) के निर्यात को प्रभावित करते हैं?**

हाँ। जुड़े हुए फ़ॉन्ट रेंडरर द्वारा सभी निर्यात फ़ॉर्मेट्स में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट स्वचालित रूप से परिणामी PPTX में एंबेड हो जाते हैं?**

नहीं। रेंडरिंग के लिए फ़ॉन्ट को पंजीकृत करना इसे PPTX में एंबेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल में शामिल करने की आवश्यकता है, तो आपको स्पष्ट रूप से [एंबेडिंग सुविधाएँ](/slides/hi/net/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ glyph न होने पर fallback व्यवहार को नियंत्रित कर सकता हूँ?**

हाँ। जब अनुरोधित glyph अनुपलब्ध हो तो कौन सा फ़ॉन्ट उपयोग किया जाए, इसे परिभाषित करने के लिए आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/), [प्रतिस्थापन नियम](/slides/hi/net/font-replacement/), और [fallback सेट](/slides/hi/net/fallback-font/) कॉन्फ़िगर कर सकते हैं।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट का उपयोग सिस्टम-व्यापी इंस्टॉल किए बिना कर सकता हूँ?**

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर इंगित करें या बाइट एरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डिरेक्ट्रीज़ पर निर्भरता समाप्त हो जाती है।

**लाइसेंसिंग के बारे में क्या—क्या मैं बिना प्रतिबंध के किसी भी कस्टम फ़ॉन्ट को एंबेड कर सकता हूँ?**

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें अलग-अलग होती हैं; कुछ लाइसेंस एंबेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।