---
title: C++ में PowerPoint फ़ॉन्ट को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/cpp/custom-font/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को कस्टमाइज़ करें ताकि आपकी प्रस्तुतियों को किसी भी डिवाइस पर तेज़ और संगत रखा जा सके।"
---
## **समीक्षा**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़-स्तर के फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुतिकरण के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या निर्यात किया जाता है, उदाहरण के रूप में PDF, छवियों और अन्य समर्थित प्रारूपों में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट की संगति बनाए रखने में मदद करता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डरों की जांच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ किया जाए।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स का पंजीकरण PPTX फ़ाइल में फ़ॉन्ट्स को एंबेड करने से अलग है। यदि किसी फ़ॉन्ट को सीधे प्रस्तुति के भीतर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एंबेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है, उपयोग करके [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में प्रयुक्त फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। इससे निर्यात आउटपुट—जैसे PDF, छवियां, और अन्य समर्थित प्रारूपों—पर प्रभाव पड़ता है, जिससे परिणामी दस्तावेज़ विभिन्न वातावरणों में समान दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट्स लोड करने के लिए स्थिर [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोड करने की प्रक्रिया दर्शाता है:

```cpp
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load custom fonts from the specified folders.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियां, या अन्य फ़ॉर्मैट).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन यह फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. [FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पथ।  
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides आपको फ़ॉन्ट फ़ोल्डर खोजने के लिए [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) प्रदान करता है। यह मेथड `LoadExternalFonts` मेथड के द्वारा जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह C++ कोड आपको दर्शाता है कि कैसे [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) मेथड का उपयोग किया जाए:

``` cpp
// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जिन्हें फ़ॉन्ट फ़ाइलों के लिए जाँच किया जाता है.
// ये फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides आपको प्रस्तुति के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स निर्दिष्ट करने के लिए [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी प्रदान करता है।

यह C++ कोड आपको दिखाता है कि कैसे [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी का उपयोग किया जाए:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //प्रस्तुति के साथ कार्य करें
    //CustomFont1, CustomFont2 के साथ-साथ assets\fonts और global\fonts फ़ोल्डरों तथा उनकी सबफ़ोल्डरों में मौजूद फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**
Aspose.Slides आपको बाहरी फ़ॉन्ट्स को बाइट एरे में लोड करने की अनुमति देने के लिए [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfont/) मेथड प्रदान करता है।

यह C++ कोड बाइट एरे फ़ॉन्ट लोड करने की प्रक्रिया को दर्शाता है:

```cpp
// दस्तावेज़ निर्देशिका का पथ
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**  
हां। जुड़े फ़ॉन्ट्स को रेंडरर सभी निर्यात फ़ॉर्मैट्स में उपयोग करता है।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एंबेड हो जाते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकरण करना PPTX में इसे एंबेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के अंदर रखना आवश्यक है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/cpp/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फ़ॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हां। आप [font substitution](/slides/hi/cpp/font-substitution/), [replacement rules](/slides/hi/cpp/font-replacement/), और [fallback sets](/slides/hi/cpp/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरुक्त ग्लिफ़ गायब होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स का उपयोग बिना उन्हें सिस्टम-व्यापी इंस्टॉल किए कर सकता हूँ?**  
हां। अपने फ़ॉन्ट फ़ोल्डरों की ओर इशारा करें या फ़ॉन्ट्स को बाइट एरे से लोड करें। यह कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर किसी भी निर्भरता को हटा देता है।

**लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एंबेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें विभिन्न हो सकती हैं; कुछ लाइसेंस एंबेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।