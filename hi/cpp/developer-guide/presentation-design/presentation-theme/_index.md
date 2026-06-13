---
title: "C++ में प्रस्तुति थीम को प्रबंधित करें"
linktitle: "प्रस्तुति थीम"
type: docs
weight: 10
url: /hi/cpp/presentation-theme/
keywords:
- "PowerPoint थीम"
- "प्रस्तुति थीम"
- "स्लाइड थीम"
- "थीम सेट करें"
- "थीम बदलें"
- "थीम प्रबंधित करें"
- "थीम रंग"
- "अतिरिक्त पैलेट"
- "थीम फ़ॉन्ट"
- "थीम शैली"
- "थीम इफ़ेक्ट"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ में प्रस्तुति थीम को प्रमुख रूप से प्रबंधित करें ताकि आप PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बना, अनुकूलित और परिवर्तित कर सकें।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की गुणधर्मों को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूलतः दृश्यमान तत्वों और उनके गुणधर्मों का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम रंग, [fonts](/slides/hi/cpp/powerpoint-fonts/), [background styles](/slides/hi/cpp/presentation-background/), और इफेक्ट्स से मिलकर बनती है।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint की थीम स्लाइड के विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। आपको नया थीम रंग चुनने में मदद करने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) enumeration के तहत मान प्रदान करता है।

This C++ code shows you how to change the accent color for a theme:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

आप इस तरह से परिणामी रंग का प्रभावी मान निर्धारित कर सकते हैं:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (रंग [A=255, R=128, G=100, B=162])
```

रंग परिवर्तन संचालन को और दर्शाने के लिए, हम एक और तत्व बनाते हैं और प्रारंभिक संचालन से प्राप्त एक्सेंट रंग को उसे असाइन करते हैं। फिर हम थीम में रंग बदलते हैं:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **वैकल्पिक पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग (1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो वैकल्पिक पैलेट (2) से रंग बनते हैं। आप फिर उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1**- मुख्य थीम रंग

**2**- वैकल्पिक पैलेट से रंग

This C++ code demonstrates an operation where additional palette colors are obtained from the main theme color and then used in shapes:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// एक्सेंट 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// एक्सेंट 4, हल्का 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// एक्सेंट 4, हल्का 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// एक्सेंट 4, हल्का 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// एक्सेंट 4, गहरा 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// एक्सेंट 4, गहरा 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` को `IColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देखेंगे कि इसमें निम्नलिखित थीम रंग मान हैं:

`Background1`, `Background2`, `Text1`, और `Text2`।

हालाँकि, `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार उजागर करता है:

`Dark1`, `Dark2`, `Light1`, और `Light2`।

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट को दर्शाते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आता है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग होते थे, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

आपको थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने में मदद करने के लिए, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में उपयोग किए जाने वाले के समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

This C++ code shows you how to assign the Latin font to a theme element:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

This C++ code shows you how to change the presentation theme font:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

सभी टेक्स्ट बॉक्स में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint fonts](/slides/hi/cpp/powerpoint-fonts/)।
{{% /alert %}}

## **थीम बैकग्राउंड शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint एप्लिकेशन 12 पूर्वनिर्धारित बैकग्राउंड प्रदान करता है, लेकिन उन 12 में से केवल 3 बैकग्राउंड एक सामान्य प्रस्तुति में सहेजे जाते हैं।

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint ऐप में एक प्रस्तुति सहेजने के बाद, आप इस C++ कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित बैकग्राउंड की संख्या पता कर सकते हैं:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) गुण को [FormatScheme](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme/) वर्ग से उपयोग करके PowerPoint थीम में बैकग्राउंड शैली जोड़ या एक्सेस कर सकते हैं। 
{{% /alert %}}

This C++ code shows you how to set the background for a presentation:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Index guide**: 0 का उपयोग कोई भराव नहीं होने के लिए किया जाता है। सूचकांक 1 से शुरू होता है।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint Background](/slides/hi/cpp/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट बदलें**

PowerPoint थीम आमतौर पर प्रत्येक शैली ऐरे के लिए 3 मान रखती है। इन ऐरे को मिलाकर ये 3 इफ़ेक्ट बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, यह परिणाम है जब प्रभावों को किसी विशिष्ट आकार पर लागू किया जाता है:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme/) वर्ग से 3 गुणों ([FillStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) का उपयोग करके आप थीम में तत्वों को बदल सकते हैं (PowerPoint के विकल्पों से भी अधिक लचीलापन के साथ)।

This C++ code shows you how to change a theme effect by altering parts of elements:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

परिणामस्वरूप भराव रंग, भराव प्रकार, छाया इफ़ेक्ट आदि में परिवर्तन दिखते हैं:

![todo:image_alt_text](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर को बदलें बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। Aspose.Slides स्लाइड-स्तरीय थीम ओवरराइड का समर्थन करता है, इसलिए आप स्थानीय थीम को केवल उस स्लाइड पर लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं (via the [SlideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/slidethememanager/))।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

[Clone slides](/slides/hi/cpp/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में ले जाएँ। इससे मूल मास्टर, लेआउट और संबंधित थीम संरक्षित रहती है, जिससे उपस्थिति समान बनी रहती है।

**सभी विरासत और ओवरराइड के बाद "effective" मान कैसे देखूँ?**

थीम/रंग/फ़ॉन्ट/इफ़ेक्ट के लिए API के ["effective" views](/slides/hi/cpp/shape-effective-properties/) का उपयोग करें। ये मास्टर प्लस किसी भी स्थानीय ओवरराइड लागू करने के बाद प्राप्त अंतिम, समाधानित गुण लौटाते हैं।