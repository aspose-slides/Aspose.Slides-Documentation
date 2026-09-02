---
title: .NET में PowerPoint फ़ॉन्ट्स को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड
- फ़ॉन्ट प्रबंधन
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint स्लाइड्स में फ़ॉन्ट्स को Aspose.Slides for .NET के साथ कस्टमाइज़ करें ताकि आपके प्रेज़ेंटेशन किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप कस्टम फ़ोल्डर से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तरीय फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, जैसे PDF, छवियों और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर को कैसे निरीक्षण करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें, यह भी समझाता है।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना फ़ॉन्ट को PPTX फ़ाइल में एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना आवश्यक है, तो स्पष्ट रूप से फ़ॉन्ट एम्बेडिंग सुविधाओं का उपयोग करें।

एक प्रस्तुति थीम व्यक्तिगत लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नाम संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/net/script-specific-font-mappings/), और नीचे दिए गये लोडिंग विकल्पों का उपयोग करें ताकि संदर्भित फ़ॉन्ट्स निरंतर रेंडरिंग के लिए उपलब्ध हों।

{{% alert color="info" title="Note" %}}

Aspose Slides आपको इन फ़ॉन्ट्स को [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड का उपयोग करके लोड करने देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर स्थापित किए बिना लोड करने देता है। यह निर्यात आउटपुट—जैसे PDF, छवियों और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है ताकि उत्पन्न दस्तावेज़ विभिन्न वातावरणों में समान दिखें। फ़ॉन्ट्स को कस्टम डायरेक्टरीज़ से लोड किया जाता है।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. स्थैतिक [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.ClearCache](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// कस्टम फ़ॉन्ट फ़ाइलों को शामिल करने वाले फ़ोल्डर निर्धारित करें।
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// निर्दिष्ट फ़ोल्डर से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियों या अन्य फ़ॉर्मैट्स में)।
presentation.Save("output.pdf", SaveFormat.Pdf);

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfonts/) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।
1. वह पथ जो [FontsLoader](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/) के माध्यम से लोड किया गया है।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**

Aspose.Slides आपको फ़ॉन्ट फ़ोल्डर खोजने के लिए [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) मेथड प्रदान करता है। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह C# कोड दिखाता है कि आप [GetFontFolders](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/getfontfolders/) को कैसे उपयोग कर सकते हैं:

```c#
using Aspose.Slides;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जो फ़ॉन्ट फ़ाइलों के लिए जाँच किए जाते हैं。
// ये फ़ोल्डर LoadExternalFonts मेथड द्वारा जोड़े गये हैं और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**

Aspose.Slides आपको प्रस्तुति के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स को निर्दिष्ट करने के लिए [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी प्रदान करता है।

यह C# कोड दिखाता है कि आप [DocumentLevelFontSources](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी को कैसे उपयोग कर सकते हैं:

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
    // CustomFont1, CustomFont2, और assets\\fonts एवं global\\fonts फ़ोल्डरों तथा उनके सबफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides आपको बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड करने के लिए [LoadExternalFont](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) मेथड प्रदान करता है।

यह C# कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // presentation के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?**

हाँ। कनेक्टेड फ़ॉन्ट्स सभी एक्सपोर्ट फ़ॉर्मैट्स में रेंダーर द्वारा उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?**

नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो स्पष्ट रूप से [एम्बेडिंग सुविधाओं](/slides/hi/net/embedded-font/) का उपयोग करें।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**

हाँ। आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/), [रिप्लेसमेंट नियम](/slides/hi/net/font-replacement/) और [फ़ॉलबैक सेट](/slides/hi/net/fallback-font/) को कॉन्फ़िगर करके तय कर सकते हैं कि अनुरोधित ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाएगा।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को सिस्टम‑वाइड स्थापित किए बिना उपयोग कर सकता हूँ?**

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर इशारा करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर कोई निर्भरता नहीं रहती।

> **Linux/Docker के लिए नोट**: जब `FontsLoader.LoadExternalFonts` को कॉल किया जाता है, तो सुनिश्चित करें कि `directories` एरे में प्रत्येक प्रविष्टि एक गैर‑खाली पथ हो जो मौजूद डायरेक्टरी की ओर इशारा करता हो। यदि फ़ॉन्ट पथ बनाने के लिए उपयोग किया गया पर्यावरण परिवर्तन अपरिभाषित या खाली है, तो Aspose.Slides इसे खाली मान को पूर्ण पथ के रूप में हल करने का प्रयास कर सकता है, जिससे `System.ArgumentException` उत्पन्न हो सकता है।

**लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें विभिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर प्रतिबंध लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।