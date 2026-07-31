---
title: C++ में PowerPoint फ़ॉन्ट्स को अनुकूलित करें
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
description: "C++ के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट्स को अनुकूलित करें ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप कस्टम फ़ोल्डर्स से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़‑स्तर के फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, इमेजेज़ और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न पर्यावरणों में प्रस्तुति आउटपुट को स्थिर रखने में मदद करता है। इस लेख में Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर्स को कैसे निरीक्षण किया जाए और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ किया जाए, भी बताया गया है।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को रजिस्टर करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को स्वयं प्रस्तुति के अंदर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) के माध्यम से:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।
{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, इमेजेज़ और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है, जिससे तैयार दस्तावेज़ विभिन्न पर्यावरणों में समान दिखते हैं। फ़ॉन्ट्स को कस्टम डायरेक्टरीज़ से लोड किया जाता है।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डर्स निर्दिष्ट करें।
2. उन फ़ोल्डर्स से फ़ॉन्ट लोड करने के लिए स्थैतिक [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड करें तथा रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/clearcache/) को कॉल करें।

फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाते हुए नीचे कोड उदाहरण दिया गया है:

```cpp
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर्स को परिभाषित करें।
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// निर्दिष्ट फ़ोल्डर्स से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (उदाहरण के लिए, PDF, इमेजेज़, या अन्य फ़ॉर्मैट्स)।
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// काम समाप्त होने के बाद फ़ॉन्ट कैश को साफ़ करें।
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट सर्च पाथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन यह फ़ॉन्ट इनिशियलाइज़ेशन क्रम को बदलता नहीं है।
फ़ॉन्ट्स इस क्रम में प्रारम्भ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. उन पाथ्स को जो [FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) द्वारा लोड किए गए हैं।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides आपको फ़ॉन्ट फ़ोल्डर्स खोजने के लिए [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) प्रदान करता है। यह मेथड `LoadExternalFonts` मेथड द्वारा जोड़े गए फ़ोल्डर्स और सिस्टम फ़ॉन्ट फ़ोल्डर्स को लौटाता है।

यह C++ कोड दर्शाता है कि आप [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) मेथड का कैसे उपयोग कर सकते हैं:

``` cpp
// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जो फ़ॉन्ट फ़ाइलों के लिए जांचे जाते हैं.
// वे फ़ोल्डर हैं जो LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
auto fontFolders = FontsLoader::GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides आपको प्रस्तुति के साथ प्रयोग किए जाने वाले बाहरी फ़ॉन्ट्स को निर्दिष्ट करने के लिए [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी प्रदान करता है।

यह C++ कोड दर्शाता है कि आप [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी का कैसे उपयोग कर सकते हैं:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //प्रेजेंटेशन के साथ काम करें
    //CustomFont1, CustomFont2 के साथ-साथ assets\fonts & global\fonts फ़ोल्डर और उनके सबफ़ोल्डर के फ़ॉन्ट्स प्रेजेंटेशन के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**
Aspose.Slides आपको बाहरी फ़ॉन्ट्स को बाइट एरे में लोड करने के लिए [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfont/) मेथड प्रदान करता है।

यह C++ कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को प्रदर्शित करता है:

```cpp
// डॉक्यूमेंट्स डायरेक्टरी का पाथ
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

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?**  
हां। जुड़े हुए फ़ॉन्ट्स को रेंडरर द्वारा सभी एक्सपोर्ट फ़ॉर्मैट्स में उपयोग किया जाता है।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड होते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट को रजिस्टर करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल में सम्मिलित करना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/cpp/embedded-font/) का उपयोग करना चाहिए।

**क्या मैं कस्टम फ़ॉन्ट में कुछ glyphs न होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हां। आपRequested glyph missing होने पर कौन सा फ़ॉन्ट प्रयोग किया जाएगा, इसे परिभाषित करने के लिए [font substitution](/slides/hi/cpp/font-substitution/), [replacement rules](/slides/hi/cpp/font-replacement/), और [fallback sets](/slides/hi/cpp/fallback-font/) को कॉन्फ़िगर कर सकते हैं।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूँ?**  
हां। अपने स्वयं के फ़ॉन्ट फ़ोल्डर्स की ओर इशारा करें या फ़ॉन्ट्स को बाइट एरे से लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर निर्भरता समाप्त हो जाती है।

**लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न हो सकती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।