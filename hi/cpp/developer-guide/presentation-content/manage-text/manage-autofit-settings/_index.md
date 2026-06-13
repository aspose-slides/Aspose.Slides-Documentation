---
title: AutoFit के साथ C++ में अपनी प्रस्तुतियों को बेहतर बनाएं
linktitle: Autofit सेटिंग्स
type: docs
weight: 30
url: /hi/cpp/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटोफ़िट
- ऑटॉफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट छोटा करें
- टेक्स्ट रैप करें
- शेप का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में AutoFit सेटिंग्स को प्रबंधित करना सीखें ताकि आपके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट डिस्प्ले को अनुकूलित किया जा सके और सामग्री की पठनीयता में सुधार हो सके।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint उस टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसके अंदर का टेक्स्ट हमेशा फिट हो सके। 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स का टेक्स्ट लंबा या बड़ा हो जाता है, तो PowerPoint स्वतः टेक्स्टबॉक्स को बड़ा कर देता है—उसकी ऊंचाई बढ़ाता है—ताकि वह अधिक टेक्स्ट समा सके। 
* जब टेक्स्टबॉक्स का टेक्स्ट छोटा या संकुचित हो जाता है, तो PowerPoint स्वतः टेक्स्टबॉक्स को घटा देता है—उसकी ऊंचाई घटाता है—ताकि अनावश्यक स्थान साफ हो सके। 

PowerPoint में, ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं: 

* **ऑटोफ़िट न करें**
* **अधिकतम होने पर टेक्स्ट छोटा करें**
* **टेक्स्ट को फिट करने के लिए आकार बदलें**
* **आकार में टेक्स्ट रैप करें।**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format) क्लास के कुछ मेथड्स—जो प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देते हैं। 

## **टेक्स्ट को फिट करने के लिए आकार बदलें**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा बॉक्स में फिट रहे, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format) क्लास से है) को `Shape` पर सेट करें। 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

यह C++ कोड दिखाता है कि आप कैसे निर्दिष्ट कर सकते हैं कि PowerPoint प्रस्तुति में टेक्स्ट हमेशा अपने बॉक्स में फिट हो। 

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से आकार बदल लेगा (ऊंचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके उल्टा होगा। 

## **ऑटोफ़िट न करें**

यदि आप चाहते हैं कि टेक्स्टबॉक्स या आकार अपने आयाम बरकरार रखे, चाहे उसके अंदर के टेक्स्ट में कितनी भी परिवर्तन हों, तो आपको **Do not Autofit** विकल्प उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) प्रॉपर्टी को `None` पर सेट करें। 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

यह C++ कोड दिखाता है कि आप कैसे निर्दिष्ट कर सकते हैं कि PowerPoint प्रस्तुति में टेक्स्टबॉक्स हमेशा अपने आयाम बरकरार रखे। 

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है। 

## **ओवरफ़्लो पर टेक्स्ट छोटा करें**

यदि टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और स्पेसिंग कम की जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format) क्लास से है) को `Normal` पर सेट करें। 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

यह C++ कोड दिखाता है कि आप कैसे निर्दिष्ट कर सकते हैं कि PowerPoint प्रस्तुति में टेक्स्ट को ओवरफ़्लो पर छोटा किया जाए: 

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
जब **Shrink text on overflow** विकल्प उपयोग किया जाता है, तो यह सेटिंग केवल तब लागू होती है जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है। 
{{% /alert %}}

## **टेक्स्ट रैप**

यदि आप चाहते हैं कि आकार के भीतर टेक्स्ट रैप हो जाए जब टेक्स्ट आकार की सीमा (केवल चौड़ाई) से बाहर जाये, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [WrapText](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame_format) क्लास से है) को `true` पर सेट करना होगा। 

यह C++ कोड दिखाता है कि आप कैसे Wrap Text सेटिंग को PowerPoint प्रस्तुति में उपयोग कर सकते हैं: 

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
यदि आप किसी आकार के लिए `WrapText` प्रॉपर्टी को `False` पर सेट करते हैं, तो जब आकार के अंदर का टेक्स्ट आकार की चौड़ाई से अधिक हो जाता है, तो टेक्स्ट एक ही पंक्ति में आकार की सीमा से बाहर विस्तारित हो जाता है। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या टेक्स्ट फ्रेम के अंदरूनी मार्जिन AutoFit को प्रभावित करते हैं?**

हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को कम कर देती है, इसलिए AutoFit पहले सक्रिय हो जाता है—फ़ॉन्ट को छोटा करने या आकार को जल्दी बदलने के लिए। AutoFit को ट्यून करने से पहले मार्जिन की जाँच और समायोजन करें।

**AutoFit मैनुअल और सॉफ्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

ज़रूरत नहीं वाले ब्रेक्स को हटाने से अक्सर यह कम हो जाता है कि AutoFit को टेक्स्ट को कितना तीव्रता से छोटा करना पड़ता है। जबरन ब्रेक्स बने रहते हैं, और AutoFit उनके आसपास फ़ॉन्ट आकार और स्पेसिंग को अनुकूलित करता है।

**थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन करने से AutoFit परिणामों पर असर पड़ता है क्या?**

हाँ। अलग गै्लिफ मेट्रिक्स वाले फ़ॉन्ट में प्रतिस्थापन करने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जो अंतिम फ़ॉन्ट आकार और लाइन रैप को प्रभावित कर सकती है। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद स्लाइड्स की फिर से जाँच करें।