---
title: C++ का उपयोग करके प्रस्तुतियों में 3D इफ़ेक्ट्स बनाएं
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
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint आकृतियों और टेक्स्ट के लिए 3D इफ़ेक्ट लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव और 3D टेक्स्ट कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for C++ आकृतियों और टेक्स्ट के लिए PowerPoint‑शैली 3D फ़ॉर्मेटिंग बनाना, संपादित करना, संरक्षित करना और रेंडर करना सक्षम है। यह लेख घुमाव, एक्सट्रूज़न, बीवेल, लाइटिंग, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट जैसे 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" %}}
यह लेख PowerPoint आकृतियों और टेक्स्ट पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलें डालने या संपादित करने के बारे में नहीं है। जब आप स्लाइड को इमेज, PDF या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

एक आकृति पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) इंटरफ़ेस की [get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_threedformat/) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) लौटाता है, जो उस आकृति के लिए 3D दृश्य को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/) इंटरफ़ेस की [get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/get_threedformat/) मेथड का उपयोग करें। यह आकृति बॉडी की बजाय टेक्स्ट फ़्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण मेथड्स हैं:

| मेथड | क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_camera/) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घुमाव, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाएँ या PowerPoint 3D घुमाव प्रीसेट से मिलाएँ। |
| [get_LightRig](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_lightrig/) | लाइट प्रीसेट, दिशा, और लाइट रोटेशन। | 3D सतह पर हाइलाइट और शैडो के प्रदर्शित होने के तरीके को बदलें। |
| [set_Material](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_material/) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या धातु। | एक ही जियोमेट्री को सपाट, नरम, चमकदार, या धातु जैसा दिखाएँ। |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | आकृति अपने सामने वाले फेस से पीछे कितनी दूर तक विस्तार करती है। | एक सपाट आकृति को दृश्य‑गोचर मोटी 3D वस्तु में बदलें। |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्य बनाएं या पक्ष के रंग को सामने की भराव के साथ समन्वयित करें। |
| [set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकृतियों या टेक्स्ट के लिए गहराई को बारीकी से समायोजित करें, विशेष रूप से बीवेल और सामग्री सेटिंग्स के साथ। |
| [get_BevelTop](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_beveltop/) और [get_BevelBottom](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | सामने और पीछे के फेसेस पर उठे या गोल किनारे। | तीखा सपाट फेस की बजाय मुलायम या ढला हुआ किनारा जोड़ें। |
| [get_ContourColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_contourcolor/) और [set_ContourWidth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर्ड आउटपुट में वस्तु की सीमा को ज़ोर दें। |

## **3D आकृति बनाएं**

एक आकृति को यथार्थवादी 3D दिखाने के लिए सामान्यतः चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि लाइटिंग से फ़ेस और साइड्स स्पष्ट दिखते हैं।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि लाइट कैसे रेंडर होती है।
- एक्सट्रूज़न या डिप्थ सेटिंग्स, क्योंकि एक सपाट आकृति को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके फ्रंट फेस में टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

रेंडर की गई स्लाइड छवि आयत को एक मोटे 3D ब्लॉक के रूप में दिखाती है:

![फ़्रंट फेस पर सफेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकृति को घुमाएँ**

PowerPoint में, 3D घुमाव को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घुमाव मान उन घुमावों के अनुरूप होते हैं जो आप कैमरा API के माध्यम से सेट करते हैं।

![X, Y, और Z घुमाव मान हाइलाइट किए गए PowerPoint 3‑D Rotation पैन](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घुमाव को [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के माध्यम से सेट करें:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

जब आपको दर्शक के वस्तु को देखने के तरीके को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकृति ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकृति को उसकी सामने वाली सतह के पीछे विस्तार देकर मोटा दिखाता है। PowerPoint में, डिप्थ कंट्रोल इस दृश्य‑गोचर मोटाई को निर्धारित करता है, और कलर कंट्रोल साइड फ़ेस का रंग सेट करता है।

![एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से जुड़े PowerPoint गहराई कंट्रोल](img_02_02.png)

मोटाई के लिए [set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) और साइड रंग के लिए [get_ExtrusionColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) सेट करें:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

जब आपको सीधे PowerPoint की गहराई मान के साथ काम करना हो या गहराई को बीवेल, सामग्री और टेक्स्ट इफ़ेक्ट्स के साथ मिलाना हो, तब [set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_depth/) उपयोग करें। कई आकृति परिदृश्यों में, `set_ExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह दृश्य‑गोचर एक्सट्रूज़न को सीधे व्यक्त करता है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या picture भराव का प्रयोग करें**

3D फ़ॉर्मेटिंग आकृति भराव से स्वतंत्र है। आप फ्रंट फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न या चित्र भराव लगा सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकृति पर ग्रेडिएंट भराव और साइड्स पर गहरा एक्सट्रूज़न रंग लागू करता है:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

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

रेंडर आउटपुट फ्रंट फेस पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले‑से‑ऑरेंज ग्रेडिएंट भराव और ऑरेंज एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, छवि को प्रस्तुति में जोड़ें और उसे आकृति भराव में असाइन करें:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

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

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![फ़्रंट फेस पर फोटो भराव और ऑरेंज एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

आकृति की 3D फ़ॉर्मेटिंग आकृति बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑जैसे इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

टेक्स्ट को वक्र, एक्सट्रूडेड 3D लेटरिंग के रूप में रेंडर किया गया है:

![आर्च्ड WordArt ट्रांसफ़ॉर्म, ऑरेंज पैटर्न भराव और डार्क एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या फिक्स्ड‑लेआउट फ़ॉर्मेट में निर्यात किया जाता है, तो 3D दृश्य को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/cpp/convert-powerpoint-to-png/) पर रेंडर करते हैं, [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/cpp/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

ध्यान रखें:

- निर्यात की गई छवियों और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों का निरीक्षण करना हो, तो [प्रभावी आकृति गुण](/slides/hi/cpp/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?

Aspose.Slides आकृतियों और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित छवियों, PDF या HTML पृष्ठों को इंटरैक्टिव 3D दृश्यों में नहीं बदलता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

### 3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?

3D मॉडल वह अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में डाला जाता है। 3D इफ़ेक्ट वह फ़ॉर्मेटिंग है जो सामान्य PowerPoint आकृति या टेक्स्ट पर लागू की जाती है, जैसे घुमाव, एक्सट्रूज़न, बीवेल, लाइटिंग और सामग्री। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

### दृश्यमान 3D आकृति के लिए किन सेटिंग्स की आवश्यकता है?

कम से कम कैमरा घुमाव और या तो एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर्ड फ़ेस में स्पष्ट हाइलाइट और शैडो दिखें।

### क्या मैं दोनों आकृतियों और टेक्स्ट पर 3D इफ़ेक्ट्स लागू कर सकता हूँ?

हां। आकृति बॉडी के लिए [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) और टेक्स्ट के लिए [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/) का उपयोग करें।

### क्या 3D इफ़ेक्ट्स छवियों, PDF, HTML या वीडियो फ्रेम्स में निर्यात करते समय दिखाई देंगे?

हां। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर्ड दिखावट होती है, न कि संपादन योग्य 3D ऑब्जेक्ट।

### क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?

हां। [प्रभावी आकृति गुण](/slides/hi/cpp/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग APIs का उपयोग करके अंतिम कैमरा, लाइट रिग, बीवेल और संबंधित 3D मान पढ़ें।