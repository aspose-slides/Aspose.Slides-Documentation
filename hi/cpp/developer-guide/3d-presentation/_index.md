---
title: C++ का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घुमाव
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint आकृतियों और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव और 3D पाठ को कॉन्फ़िगर करें।"
---
## **समीक्षा**

Aspose.Slides for C++ आकृतियों और पाठ के लिए PowerPoint-शैली 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख 3D प्रभावों को कवर करता है जैसे घुमाव, एक्सट्रूज़न, बिवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ।

{{% alert color="primary" %}}
यह लेख PowerPoint आकृतियों और पाठ पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित करने या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, Aspose.Slides इन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकृति पर 3D फॉर्मेटिंग लागू करने के लिए [IShape] इंटरफ़ेस की [get_ThreeDFormat] मेथड का उपयोग करें। यह मेथड [IThreeDFormat] लौटाता है, जो उस आकृति के लिए 3D सीन को नियंत्रित करता है।

पाठ के लिए, [ITextFrameFormat] इंटरफ़ेस की [get_ThreeDFormat] मेथड का उपयोग करें। यह आकृति के शरीर की बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण मेथड्स हैं:

| Method | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_camera/) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घुमाव, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाएँ या PowerPoint के 3D घुमाव प्रीसेट से मेल करें। |
| [get_LightRig](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_lightrig/) | लाइट प्रीसेट, दिशा, और लाइट घुमाव। | 3D सतह पर हाइलाइट और शैडो कैसे प्रदर्शित होते हैं उसे बदलें। |
| [set_Material](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_material/) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | एक ही ज्योमेट्री को अधिक सपाट, नरम, चमकीला या धातु जैसा बनाएं। |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | आकृति अपने सामने के फेस से पीछे कितनी दूर तक बढ़ती है। | सपाट आकृति को स्पष्ट रूप से मोटे 3D ऑब्जेक्ट में बदलें। |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | एक्सट्रूड की गई साइड्स का रंग। | गहराई को दृश्यमान बनाएं या साइड के रंग को सामने के भराव के साथ समन्वयित करें। |
| [set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की जाने अतिरिक्त 3D गहराई। | आकृतियों या पाठ के लिए गहराई को बारीक करें, विशेषकर बिवेल और सामग्री सेटिंग्स के साथ। |
| [get_BevelTop](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_beveltop/) और [get_BevelBottom](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | समने और पीछे के फ़ेस पर उठे या गोल किनारे। | तीखा सपाट फ़ेस के बजाय मुलायम या ढाले गए किनारे जोड़ें। |
| [get_ContourColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_contourcolor/) और [set_ContourWidth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट की सीमा को उजागर करें। |

## **3D आकृति बनाएं**

एक 3D रूप देने के लिए आकृति को आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश साइड्स और फेसों को पढ़ने योग्य बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकृति को मोटाई की आवश्यकता होती है।

निम्न उदाहरण एक आयत बनाता है, उसके सामने के फेस पर टेक्स्ट जोड़ता है, 3D फॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

रेंडर की गई स्लाइड छवि आयत को एक मोटी 3D ब्लॉक के रूप में दिखाती है:

![सामने के फेस पर सफेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकृति को घुमाएँ**

PowerPoint में, 3D घुमाव को 3-D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y और Z घुमाव मान कैमरा API के माध्यम से सेट किए गए घुमाव के अनुरूप होते हैं।

![PowerPoint 3-D Rotation पैन जिसमें X, Y और Z घुमाव मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घुमाव को [IThreeDFormat] के माध्यम से सेट करें:

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

कैमरा तब उपयोग करें जब आपको दर्शक द्वारा ऑब्जेक्ट को देखने के तरीके को बदलना हो। यह स्लाइड पर 2D आकृति ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकृति को मोटा बनाता है क्योंकि यह सामने के फेस के पीछे बढ़ता है। PowerPoint में, गहराई कंट्रोल इस दृश्य मोटाई को सेट करता है, और रंग कंट्रोल साइड फ़ेस के रंग को सेट करता है।

![PowerPoint गहराई कंट्रोल्स को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किया गया है](img_02_02.png)

मोटाई के लिए [set_ExtrusionHeight] और साइड रंग के लिए [get_ExtrusionColor] सेट करें:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

जब आपको PowerPoint की गहराई मान के साथ सीधे काम करना हो या गहराई को बिवेल, मैटेरियल और टेक्स्ट इफेक्ट्स के साथ संयोजित करना हो, तो [set_Depth] का उपयोग करें। कई आकृति परिस्थितियों में, `set_ExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्य एक्सट्रूज़न को दर्शाता है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फॉर्मेटिंग आकृति भराव से स्वतंत्र है। आप सामने के फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, मैटेरियल और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकृति पर ग्रेडिएंट भराव लागू करता है और साइड्स पर गहरा एक्सट्रूज़न रंग रखता है:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

रेंडर किया गया आउटपुट सामने के फेस पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है।

![नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

Picture fill के लिए, छवि को प्रस्तुति में जोड़ें और उसे आकृति भराव में असाइन करें:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

![सामने के फेस पर फ़ोटो भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **पाठ पर 3D फॉर्मेटिंग लागू करें**

आकृति 3D फॉर्मेटिंग आकृति शरीर को प्रभावित करती है। पाठ 3D फॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt जैसे प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [ITextFrameFormat] पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![अधःवक्र WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात निश्चित-लेआउट फ़ॉर्मेट में किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/cpp/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो कन्वर्ज़न](/slides/hi/cpp/convert-powerpoint-to-video/) के लिए फ़्रेम उत्पन्न करते हैं।

- निर्यातित छवियां और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम रूपरेखा कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको वंशागत या थीम-आधारित फॉर्मेटिंग मानों की जांच करनी हो, तो [प्रभावी आकृति गुण](/slides/hi/cpp/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहित नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियों बना सकता है?**

Aspose.Slides आकृतियों और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs, या HTML पृष्ठों को ऐसे इंटरैक्टिव 3D दृश्यों में नहीं बदलता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य बनी रहती है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल प्रस्तुति में सम्मिलित किया गया एक अलग 3D ऑब्जेक्ट है। 3D प्रभाव नियमित PowerPoint आकृति या पाठ पर लागू फ़ॉर्मेटिंग है, जैसे घुमाव, एक्सट्रूज़न, बिवेल, लाइटिंग, और मैटेरियल। यह लेख 3D प्रभावों को कवर करता है।

**एक दृश्यमान 3D आकृति के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घुमाव और या तो एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं दोनों आकृतियों और पाठ पर 3D प्रभाव लागू कर सकता हूँ?**

हाँ। आकृति शरीर के लिए [IShape] का उपयोग करें और पाठ के लिए [ITextFrameFormat] का उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करते समय दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो परिवर्तन के लिए उपयोग किए जाने वाले फ़्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया रूप रहता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [आकृति प्रभावी गुण](/slides/hi/cpp/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।