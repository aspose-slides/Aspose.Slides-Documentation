---
title: .NET में PowerPoint फ़ॉन्ट कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाह्य फ़ॉन्ट
- फ़ॉन्ट लोड करना
- फ़ॉन्ट्स प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स में फ़ॉन्ट कस्टमाइज़ करें ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **सारांश**

Aspose.Slides आपको कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है, बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप कस्टम फ़ोल्डर्स से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से विशेष प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, छवियों और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न परिवेशों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी समझाता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डर्स की जांच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को रजिस्टर करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि किसी फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना आवश्यक हो, तो फ़ॉन्ट एम्बेडिंग सुविधाओं को स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम व्यक्तिगत लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नाम संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को इंस्टॉल या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए [स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट्स](/slides/hi/net/script-specific-font-mappings/) देखें, और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}
Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है, जो आप [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) विधि का उपयोग करके कर सकते हैं:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट को प्रभावित करता है—जैसे PDF, छवियां, और अन्य समर्थित फ़ॉर्मैट्स—जिससे उत्पन्न दस्तावेज़ विभिन्न परिवेशों में सुसंगत दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट्स लोड करने के लिए स्थिर [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर को परिभाषित करें।
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (उदा., PDF, छवियों या अन्य फ़ॉर्मैट्स में)।
presentation.Save("output.pdf", SaveFormat.Pdf);

// कार्य समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पाथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन यह फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. वह पाथ जो [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) के माध्यम से लोड किया गया है।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर्स खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर्स और सिस्टम फ़ॉन्ट फ़ोल्डर्स को वापस करता है।

यह C# कोड दिखाता है कि आप [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) का उपयोग कैसे करें:

```c#
using Aspose.Slides;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जिन्हें फ़ॉन्ट फ़ाइलों के लिए जाँच किया जाता है.
// ये फ़ोल्डर LoadExternalFonts मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्धारित करें**
Aspose.Slides [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी प्रदान करता है जिससे आप वह बाहरी फ़ॉन्ट्स निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग किए जाएंगे।

यह C# कोड दिखाता है कि आप [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) प्रॉपर्टी का उपयोग कैसे करें:

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
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके सबफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

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
        // प्रस्तुति के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

एक मेल खाने वाले पंजीकृत फ़ॉन्ट को निर्यात के दौरान प्राथमिकता देने के लिए, बिना एम्बेडेड फ़ॉन्ट को हटाए, देखें [पंजीकृत फ़ॉन्ट्स को एम्बेडेड फ़ॉन्ट्स पर प्राथमिकता दें](/slides/hi/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 या बाद)।

## **FAQ**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**  
हाँ। जुड़े हुए फ़ॉन्ट्स को रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में उपयोग किया जाता है।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट को रजिस्टर करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो आपको स्पष्ट रूप से [एम्बेडिंग सुविधाएँ](/slides/hi/net/embedded-font/) का उपयोग करना चाहिए।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ नहीं होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हाँ। जब अनुरोधित ग्लिफ़ गायब हो तो कौन सा फ़ॉन्ट उपयोग किया जाए, इसे निर्धारित करने के लिए आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/), [प्रतिस्थापन नियम](/slides/hi/net/font-replacement/), और [फ़ॉलबैक सेट](/slides/hi/net/fallback-font/) को कॉन्फ़िगर कर सकते हैं।

**क्या मैं फ़ॉन्ट्स को Linux/Docker कंटेनरों में सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूँ?**  
हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर इशारा करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर निर्भरता समाप्त हो जाती है।

> **Linux/Docker के लिए नोट**: जब `FontsLoader.LoadExternalFonts` को कॉल किया जाता है, तो सुनिश्चित करें कि `directories` एरे में प्रत्येक एंट्री में कोई खाली न हो ऐसा मौजूदा डायरेक्टरी पाथ हो। यदि फ़ॉन्ट पाथ बनाने के लिए प्रयुक्त कोई एनवायरनमेंट वेरिएबल अनिर्धारित या खाली है, तो Aspose.Slides उस खाली मान को पूर्ण पाथ के रूप में रिजॉल्व करने का प्रयास कर सकता है, जिससे `System.ArgumentException` उत्पन्न होता है।

**लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध एम्बेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें अलग‑अलग होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।