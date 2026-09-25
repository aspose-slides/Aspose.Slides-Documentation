---
title: C++ का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूजन
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint आकार और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूजन, भराव, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **समीक्षा**

Aspose.Slides for C++ आकार और टेक्स्ट के लिए PowerPoint-शैली के 3D फ़ॉर्मेटिंग को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख 3D प्रभावों जैसे घुमाव, एक्सट्रुजन, बिवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट को कवर करता है।

{{% alert color="info" title="Note" %}}
इस लेख में PowerPoint आकार और टेक्स्ट पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में बताया गया है। यह स्वतंत्र 3D मॉडल फाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_threedformat/) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/get_threedformat/) मेथड का उपयोग करें। यह आकार के बॉडी की बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण मेथड्स हैं:

| विधि | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_camera/) | दृश्य बिंदु, पूर्वनिर्धारित कैमरा प्रकार, घुमाव, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाने या PowerPoint 3D घुमाव प्रीसेट से मेल करने के लिए। |
| [get_LightRig](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_lightrig/) | प्रकाश का प्रीसेट, दिशा, और प्रकाश घुमाव। | 3D सतह पर हाइलाइट और शेडो कैसे दिखते हैं, इसे बदलने के लिए। |
| [set_Material](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_material/) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | एक ही ज्यामिति को अधिक सपाट, मुलायम, चमकदार या धातु जैसी बनाने के लिए। |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | आकार अपनी सामने की सतह से पीछे कितनी दूर तक विस्तारित होता है। | सपाट आकार को स्पष्ट रूप से मोटी 3D वस्तु में बदलने के लिए। |
| [get_ExtrusionColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | अतिरिक्त पक्षों का रंग। | गहराई को दृश्यमान बनाने या साइड रंग को सामने के फिल के साथ तालमेल रखने के लिए। |
| [set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट की गहराई को बारीकी से समायोजित करने के लिए, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [get_BevelTop](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_beveltop/) और [get_BevelBottom](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | सामने और पीछे की सतहों पर उठे या गोल किनारे। | तीखा सपाट चेहरा की बजाय मुलायम या ढाला हुआ किनारा जोड़ने के लिए। |
| [get_ContourColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_contourcolor/) और [set_ContourWidth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करने के लिए। |

## **3D आकार बनाना**

एक आकार को विश्वसनीय 3D दिखने के लिए आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रुशन को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश चेहरे और किनारों को पढ़ने योग्य बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रुशन या डेप्थ सेटिंग्स, क्योंकि सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने की सतह पर टेक्स्ट जोड़ता है, और 3D फ़ॉर्मेटिंग लागू करता है। कैमरा घुमाव मान डिग्री में हैं, और एक्सट्रुशन ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को दो गुना डिफ़ॉल्ट आयामों पर PNG इमेज में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

रेंडर किया हुआ स्लाइड इमेज आयत को एक मोटी 3D ब्लॉक के रूप में दिखाता है:

![रेंडर किया गया नीला 3D आयत, सामने की सतह पर सफ़ेद 3D टेक्स्ट के साथ](img_01_01.png)

## **कैमरा से आकार को घुमाना**

PowerPoint में, 3D घुमाव को 3-D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y, और Z घुमाव मान कैमरा API के माध्यम से सेट किए गए घुमाव से मेल खाते हैं।

![PowerPoint 3-D Rotation पेन जिसमें X, Y, और Z घुमाव मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा को [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_camera/) के माध्यम से एक्सेस करें। यह उदाहरण एक आयत बनाता है, एक ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और क्रमशः उसके X, Y, और Z घुमाव को 20, 30, और 40 डिग्री पर सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

presentation->Dispose();
```

जब आपको दर्शक की वस्तु के देखने के तरीके को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रुजन और डेप्थ जोड़ें**

एक्सट्रुजन एक आकार को सामने की सतह के पीछे विस्तारित करके उसे मोटा दिखाता है। PowerPoint में, डेप्थ नियंत्रण इस दृश्यमान मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस का रंग निर्धारित करता है।

![PowerPoint डेप्थ कंट्रोल्स जो एक्सट्रुशन रंग और एक्सट्रुशन ऊँचाई प्रॉपर्टीज़ से जुड़े हैं](img_02_02.png)

मोटाई के लिए [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) सेट करें और साइड रंग के लिए [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) उपयोग करें। यह उदाहरण आयत को 100 पॉइंट एक्सट्रुजन के साथ बैंगनी साइड्स देता है और उसकी मोटाई दिखाने के लिए कैमरा को घुमाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_depth/) मेथड 3D आकार की गहराई सेट करता है। [set_ExtrusionHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) मेथड एक्सट्रुशन प्रभाव की ऊँचाई नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फ़ॉर्मेटिंग आकार भराव से स्वतंत्र है। आप सामने की सतह पर सॉलिड रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री, और एक्सट्रुजन सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण सामने की सतह पर नीले से नारंगी ग्रेडिएंट लागू करता है और 150 पॉइंट एक्सट्रुजन पर डार्क ऑरेंज रंग सेट करता है। ग्रेडिएंट को 0 और 100 पर रोक दिया गया है जो क्रमशः ग्रेडिएंट की शुरुआत और अंत को दर्शाते हैं। कैमरा घुमाव मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आयामों पर PNG इमेज में रेंडर किया गया है:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

![रेंडर किया गया 3D आयत, नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रुशन के साथ](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे आकार भराव में असाइन करें। इस उदाहरण को कार्यशील डायरेक्टरी में "image.jpg" नाम की मौजूदा फ़ाइल चाहिए। यह चित्र को आयत भरने के लिए खींचता है, 150 पॉइंट एक्सट्रुशन लागू करता है, और कैमरा घुमाव को डिग्री में सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

![रेंडर किया गया 3D आयत, सामने की सतह पर फोटो भराव और नारंगी एक्सट्रुशन के साथ](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करना**

आकार 3D फ़ॉर्मेटिंग आकार के बॉडी को प्रभावित करती है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt जैसी प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रुजन, सामग्री, प्रकाश और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक ऑरेंज-और-व्हाइट ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, उपर की ओर एक आर्क लागू करता है, और 3D सेटिंग्स को [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/get_threedformat/) के माध्यम से कॉन्फ़िगर करता है। एक्सट्रुशन ऊँचाई और डेप्थ पॉइंट में हैं, और लाइट घुमाव डिग्री में है। आकार भराव और रूपरेखा छिपी हुई हैं ताकि केवल टेक्स्ट ही दिखे। उदाहरण डिफ़ॉल्ट स्लाइड आयामों के दो गुना पर PNG इमेज रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

![रेंडर किया गया 3D टेक्स्ट, आर्ड WordArt ट्रांसफ़ॉर्म, ऑरेंज पैटर्न भराव, और डार्क एक्सट्रुजन के साथ](img_02_05.png)

## **3D आकार पर टेक्स्ट को सपाट रखें**

शेप की 3D उपस्थिति को बनाए रखते हुए टेक्स्ट को पढ़ने योग्य रखने के लिए, [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_textframeformat/) के माध्यम से [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_keeptextflat/) को कॉल करें। जब मान `true` हो, तो टेक्स्ट 3D सीन से बाहर रहता है। जब यह `false` हो, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग आकार के 3D फ़ॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, सामग्री और एक्सट्रुजन [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_threedformat/) के माध्यम से कॉन्फ़िगर रहता है। यह सामान्य घुमाव से भी अलग है। [IShape::set_Rotation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_rotation/) स्लाइड समतल में आकार को घुमाता है, जबकि [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_rotationangle/) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घुमाव को नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखने से उन कोणों को रीसेट नहीं किया जाता।

निम्न स्व-समाहित उदाहरण एक नीला आयत टेक्स्ट के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D फ़ॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रुजन ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को डिफ़ॉल्ट आयामों के दो गुना पर PNG में रेंडर करता है।

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

बाएँ पर, टेक्स्ट 3D अभिविन्यास का अनुसरण करता है। दाएँ पर, यह सपाट रहता है और पढ़ने में आसान होता है। दोनों आयत समान दृश्यमान एक्सट्रुजन और 3D अभिविन्यास को बनाए रखते हैं।

![साइड-बाय-साइड 3D आयत: बाएँ पर KeepTextFlat false और दाएँ पर true है](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसी PowerPoint फॉर्मैट्स में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। रेंडरिंग या फिक्स्ड-लेआउट फॉर्मैट्स में निर्यात करते समय, 3D सीन को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड्स को [PNG](/slides/hi/cpp/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो रूपांतरण](/slides/hi/cpp/convert-powerpoint-to-video/) के लिए फ्रेम बनाते हैं।

- निर्यात की गई इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रुजन, भराव, और स्लाइड स्केलेशन के संयोजन पर निर्भर करता है।
- यदि आपको इनहेरिटेड या थीम-आधारित फ़ॉर्मेटिंग मूल्यों को देखना है, तो [effective shape properties](/slides/hi/cpp/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फॉर्मैट्स में संपादित करने योग्य PowerPoint 3D फ़ॉर्मेटिंग सहेजा नहीं जा सकता। उन फॉर्मैट्स में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादित करने योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides आकार और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात किए गए इमेज, PDF, या HTML पेजों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहां फॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादित रखने योग्य रहती है।

**एक 3D मॉडल और एक 3D प्रभाव में क्या अंतर है?**

3D मॉडल वह अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint आकार या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घुमाव, एक्सट्रुजन, बिवेल, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दृश्यमान 3D आकार के लिए कौनसी सेटिंग्स आवश्यक हैं?**

कम से कम एक कैमरा घुमाव और या तो एक्सट्रुजन या डेप्थ सेट करें। व्यावहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाईलाइट और शैडो हों।

**क्या मैं दोनों आकारों और टेक्स्ट पर 3D प्रभाव लागू कर सकता हूँ?**

हां। आकार बॉडी के लिए [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_threedformat/) और टेक्स्ट के लिए [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/get_threedformat/) का उपयोग करें।

**क्या 3D प्रभाव इमेज, PDF, HTML, या वीडियो फ्रेम में निर्यात करने पर दिखाई देंगे?**

हां। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया रूप दिखता है, न कि संपादित करने योग्य 3D ऑब्जेक्ट।

**क्या मैं इनहेरिटेंस और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/cpp/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग APIs का उपयोग करें।