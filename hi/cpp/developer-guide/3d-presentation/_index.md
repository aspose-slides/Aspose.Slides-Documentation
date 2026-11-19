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
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint आकारों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for C++ आकारों और टेक्स्ट के लिए PowerPoint‑शैली के 3D फ़ॉर्मेटिंग को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट जैसे 3D प्रभावों को कवर करता है।

{{% alert color="info" title="नोट" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह अलग‑थलग 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) मेथड का उपयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण मेथड्स हैं:

| मेथड | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | व्यू पॉइंट, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम और परिप्रेक्ष्य। | 3D स्थान में ऑब्जेक्ट को घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मेल कराएँ। |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | लाइट प्रीसेट, दिशा और लाइट घूर्णन। | 3D सतह पर हाइलाइट्स और शैडोज़ कैसे दिखाई दें, इसे बदलें। |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या धातु। | एक ही ज्योमेट्री को अधिक सपाट, नरम, चमकदार, या धातु जैसा दिखाएँ। |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | आकार की सामने की सतह से पीछे तक कितना विस्तार होता है। | एक फ्लैट आकार को स्पष्ट रूप से मोटी 3D वस्तु में बदलें। |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | एक्सट्रूडेड पक्षों का रंग। | गहराई दिखाने या साइड रंग को सामने के भराव के साथ समन्वयित करने के लिये। |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की जाने वाली अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को बिवेल और मैटेरियल सेटिंग्स के साथ सूक्ष्म रूप से समायोजित करें। |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) और [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | सामने और पीछे के फेस पर उठे या गोल किनारे। | तीखे फ्लैट फेस के बजाय नरम या ढलाई वाले किनारे जोड़ें। |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) और [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर आउटपुट में ऑब्जेक्ट की सीमा को प्रभावी बनाएं। |

## **3D आकार बनाना**

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों को पढ़ने योग्य बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि फ्लैट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने की सतह पर टेक्स्ट जोड़ता है, और 3D फ़ॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को PNG छवि में दो गुना डिफ़ॉल्ट आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

![सामने की सतह पर सफ़ेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकार घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3‑D घूर्णन पैन जिसमें X, Y, और Z घूर्णन मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुँचने के लिए [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) का उपयोग करें। यह उदाहरण एक आयत बनाता है, ऑर्थोग्राफ़िक फ्रंट व्यू चुनता है, और उसके X, Y, और Z घूर्णन को क्रमशः 20, 30, और 40 डिग्री पर सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

जब आपको वरीयता चाहिए कि दर्शक वस्तु को कैसे देखे, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता; यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

### **टेम्प्लेट आकार से कैमरा अभिविन्यास कॉपी करें**

टेम्प्लेट आकार की कैमरा अभिविन्यास से मेल पाने के लिये, उसके प्रीसेट को [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) से पढ़ें और [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) से लागू करें। उदाहरण `template.pptx` खोलता है और पहले स्लाइड के पहले आकार से कैमरा अभिविन्यास को दूसरे आकार में कॉपी करता है। दोनों आकारों में पहले से ही 3D लाइटिंग है, और दूसरे आकार में कोई स्पष्ट कैमरा घूर्णन नहीं है।

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) कोणों को डिग्री में लौटाता है। इंडेक्स `0` अक्षांश, `1` देशांतर, और `2` फेरेन्ट है। इन क्रम में कोणों को [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) को पास करें। यदि स्रोत में स्पष्ट घूर्णन नहीं है, तो `GetRotation` null पॉइंटर लौटाता है, इसलिए दूसरे आकार के कोण को अनसेट रखें। `(0, 0, 0)` का स्पष्ट घूर्णन तीन शून्य का एरे लौटाता है और उसे कॉपी किया जाना चाहिए।

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

जब आप `camera-copy.pptx` को PowerPoint में पुनः खोलते हैं, तो दाएँ ओर का तीर बाएँ आयत के समान कैमरा प्रीसेट और घूर्णन रखता है। दोनों आकार समान लाइटिंग और एक्सट्रूज़न गहराई का उपयोग करते हैं।

![एक नीला 3D आयत और मिलते-जुलते कैमरा अभिविन्यास वाले दायें दिशा के तीर, ऊपर और दायें से देखे गए](camera-orientation.png)

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकार को सामने की सतह से पीछे की ओर विस्तारित करके मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटी को निर्धारित करता है, और रंग नियंत्रण साइड फेस के रंग को निर्धारित करता है।

![PowerPoint गहराई नियंत्रण जो एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किए गए हैं](img_02_02.png)

मोटाई के लिए [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) सेट करें और साइड रंग के लिए [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) सेट करें। यह उदाहरण आयत को 100‑पॉइंट एक्सट्रूज़न के साथ बैंगनी साइड्स देता है और कैमरा को घुमाकर उसकी मोटाई दिखाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) मेथड 3D आकार की गहराई सेट करता है। [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) मेथड एक्सट्रूज़न प्रभाव की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या पिक्चर फ़िल्स का उपयोग करें**

3D फ़ॉर्मेटिंग आकार भराव से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और वही कैमरा, लाइट, मैटेरियल, और एक्सट्रूज़न सेटिंग्स रख सकते हैं।

यह उदाहरण सामने की सतह पर नीले‑से‑नारंगी ग्रेडिएंट और 150‑पॉइंट एक्सट्रूज़न पर डार्क नारंगी रंग लागू करता है। ग्रेडिएंट स्टॉप 0 और 100 संकेत करता है जहाँ ग्रेडिएंट शुरू और समाप्त होता है। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आकार में PNG छवि में रेंडर किया गया है:

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

![नीले से नारंगी ग्रेडिएंट फ़िल और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकार भराव में असाइन करें। इस उदाहरण में कार्य निर्देशिका में "image.jpg" नाम की फ़ाइल मौजूद होनी चाहिए। चित्र को आयत में भरने के लिये स्ट्रेच किया जाता है, 150‑पॉइंट एक्सट्रूज़न लगाया जाता है, और कैमरा घूर्णन डिग्री में सेट किया जाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

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

चित्र सामने की सतह पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![सामने की सतह पर फोटो फ़िल और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

आकार की 3D फ़ॉर्मेटिंग आकार बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिये उपयोगी है जहाँ अक्षर स्वयं को एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक ऑरेंज‑और‑व्हाइट ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, ऊपर की ओर आर्च लागू करता है, और [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और गहराई पॉइंट में तथा लाइट घूर्णन डिग्री में हैं। आकार भराव और रूपरेखा छिपी हुई है ताकि केवल टेक्स्ट दिखे। उदाहरण PNG छवि को दो गुना डिफ़ॉल्ट स्लाइड आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

![आर्च्ड WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न फ़िल और डार्क एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **3D आकार पर टेक्स्ट को समतल रखें**

टेक्स्ट को 3D सीन से बाहर रखने के लिए [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) को [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) के माध्यम से कॉल करें। जब मान `true` हो, तो टेक्स्ट 3D सीन से बाहर रहता है। जब `false` हो, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का अनुसरण करता है।

यह सेटिंग आकार की 3D फ़ॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, मैटेरियल, और एक्सट्रूज़न अभी भी [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) के द्वारा कॉन्फ़िगर रहता है। यह सामान्य घूर्णन से भी अलग है। [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) स्लाइड प्लेन में आकार को घुमाता है, जबकि [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) टेक्स्ट के बॉक्स के भीतर कस्टम घूर्णन नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखने से उन कोणों में से कोई भी रीसेट नहीं होता।

निम्न स्वनिर्भर उदाहरण एक नीले आयत को टेक्स्ट के साथ बनाता है और उसे मूल आकार के बगल में क्लोन करता है। दोनों आकारों में समान 3D फ़ॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को PNG में दो गुना डिफ़ॉल्ट आकार में रेंडर करता है।

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

बाएँ पर टेक्स्ट 3D अभिविन्यास का अनुसरण करता है। दाएँ पर टेक्स्ट समतल रहता है और पढ़ने में आसान है। दोनों आयत समान दृश्यमान एक्सट्रूज़न और 3D अभिविन्यास बनाये रखते हैं।

![साइड बाय साइड 3D आयत: बाएँ पर KeepTextFlat false और दाएँ पर true](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PowerPoint फ़ॉर्मेट जैसे PPTX में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात स्थिर‑लेआउट फ़ॉर्मेट्स में किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/cpp/convert-powerpoint-to-png/), [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) में रेंडर करते हैं, या [वीडियो कन्वर्ज़न](/slides/hi/cpp/convert-powerpoint-to-video/) के लिए फ्रेम बनाते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यातित छवियों और PDFs में इंटरैक्टिविटी नहीं होती। ऑब्जेक्ट को निर्यात के बाद दर्शक नहीं घुमा सकता।
- अंतिम रूप कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको इनहेरिटेड या थीम‑आधारित फ़ॉर्मेटिंग मानों को देखना है, तो [प्रभावी आकार गुण](/slides/hi/cpp/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट्स संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट्स में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रेज़ेंटेशन बना सकता है?**

Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs या HTML पृष्ठों को इंटरैक्टिव 3D सीन नहीं बनाता जो दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**

3D मॉडल वह अलग‑थलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट वह फ़ॉर्मेटिंग है जो सामान्य PowerPoint आकार या टेक्स्ट पर लागू की जाती है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और मैटेरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**कौन सी सेटिंग्स एक दिखाई देने वाले 3D आकार के लिये आवश्यक हैं?**

कम से कम, कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाइलाइट्स और शैडोज़ हों।

**क्या मैं आकारों और टेक्स्ट दोनों पर 3D इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिये [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) और टेक्स्ट के लिये [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) का उपयोग करें।

**क्या 3D इफ़ेक्ट्स छवियों, PDF, HTML, या वीडियो फ्रेम में निर्यात करते समय दिखेंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट और वीडियो कन्वर्ज़न के लिये उपयोग किए जाने वाले फ्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ रूप दर्शाया जाता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं इनहेरिटेंस और थीम सेटिंग्स के लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल और संबंधित 3D मान पढ़ने के लिये [प्रभावी आकार गुण](/slides/hi/cpp/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।