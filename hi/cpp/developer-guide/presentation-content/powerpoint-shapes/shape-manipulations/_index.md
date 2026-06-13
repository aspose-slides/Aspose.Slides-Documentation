---
title: C++ में प्रस्तुति आकार प्रबंधित करें
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/cpp/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार लेआउट फ़ॉर्मेट
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में आकार बनाना, संपादित करना और अनुकूलित करना सीखें और उच्च-प्रदर्शन PowerPoint प्रस्तुतियाँ प्रस्तुत करें."
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में आकारों के साथ काम करने का तरीका समझाता है। यह दिखाता है कि स्लाइड पर किसी आकार को कैसे खोजें, उसे क्लोन करें, हटाएँ, छुपाएँ, क्रम बदलें, उसका Interop shape ID प्राप्त करें, और पहचान एवं आगे की प्रोसेसिंग के लिए वैकल्पिक टेक्स्ट सेट करें।

यह आकारों के लेआउट फ़ॉर्मेट को एक्सेस करने, आकार को SVG के रूप में रेंडर करने, स्लाइड पर आकारों को संरेखित करने और क्षैतिज एवं लंबवत मिररिंग के लिए फ़्लिप प्रॉपर्टी का उपयोग करने को भी कवर करता है। साथ ही यह आकार संयोजन, स्टैकिंग क्रम और आकार लॉकिंग के बारे में एक छोटा FAQ शामिल करता है।

## **स्लाइड पर आकार खोजें**
यह विषय एक सरल तकनीक का वर्णन करेगा जिससे डेवलपर्स को स्लाइड पर किसी विशिष्ट आकार को उसके आंतरिक Id का उपयोग किए बिना आसानी से खोजा जा सके। यह जानना महत्वपूर्ण है कि PowerPoint प्रस्तुति फ़ाइलों में आकारों की पहचान करने का कोई तरीका नहीं है सिवाय एक आंतरिक अनूठे Id के। डेवलपर्स के लिए इस अनूठे Id का उपयोग करके आकार ढूँढ़ना कठिन हो सकता है। सभी जोड़े गए आकारों में कुछ Alt Text होता है। हम सलाह देते हैं कि विशिष्ट आकार खोजने के लिए वैकल्पिक टेक्स्ट का उपयोग किया जाए। आप भविष्य में बदलने की योजना बना रहे ऑब्जेक्ट्स के लिए MS PowerPoint का उपयोग करके वैकल्पिक टेक्स्ट निर्धारित कर सकते हैं।

किसी इच्छित आकार का वैकल्पिक टेक्स्ट सेट करने के बाद, आप Aspose.Slides for C++ का उपयोग करके वह प्रस्तुति खोल सकते हैं और स्लाइड में जोड़े गए सभी आकारों पर इटररेट कर सकते हैं। प्रत्येक इटरेशन में आप आकार के वैकल्पिक टेक्स्ट की जाँच कर सकते हैं और मिलते‑जुलते वैकल्पिक टेक्स्ट वाला आकार वही होगा जिसकी आपको आवश्यकता है। इस तकनीक को बेहतर तरीके से दिखाने के लिए हमने एक विधि बनाई है, [FindShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) जो स्लाइड में विशिष्ट आकार खोजकर उसे वापस देता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **आकार क्लोन करें**
Aspose.Slides for C++ का उपयोग करके किसी स्लाइड में आकार क्लोन करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।
1. उसके अनुक्रमांक (index) का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्रोत स्लाइड की shape collection तक पहुँचें।
1. प्रस्तुति में एक नई स्लाइड जोड़ें।
1. स्रोत स्लाइड की shape collection से आकारों को नई स्लाइड में क्लोन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण एक समूह आकार को स्लाइड में जोड़ता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **आकार हटाएँ**
Aspose.Slides for C++ डेवलपर्स को किसी भी आकार को हटाने की अनुमति देता है। किसी स्लाइड से आकार हटाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को हटाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **आकार छुपाएँ**
Aspose.Slides for C++ डेवलपर्स को किसी भी आकार को छुपाने की अनुमति देता है। किसी स्लाइड से आकार छुपाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को छुपाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **आकार क्रम बदलें**
Aspose.Slides for C++ डेवलपर्स को आकारों का क्रम बदलने की अनुमति देता है। क्रम बदलने से यह निर्धारित होता है कि कौन सा आकार आगे दिखेगा और कौन सा पीछे। किसी स्लाइड में आकार का क्रम बदलने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. एक आकार जोड़ें।
1. आकार के टेक्स्ट फ्रेम में कुछ टेक्स्ट जोड़ें।
1. वही कोऑर्डिनेट वाले दूसरे आकार को जोड़ें।
1. आकारों का क्रम बदलें।
1. फ़ाइल को डिस्क पर सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop Shape ID प्राप्त करें**
Aspose.Slides for C++ डेवलपर्स को स्लाइड स्तर पर एक अनूठा आकार पहचानकर्ता (UniqueId प्रॉपर्टी के विपरीत) प्राप्त करने की अनुमति देता है। OfficeInteropShapeId प्रॉपर्टी को IShape इंटरफ़ेस और Shape क्लास में जोड़ा गया है। OfficeInteropShapeId प्रॉपर्टी द्वारा लौटाए गए मान का मेल Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id मान से होता है। नीचे नमूना कोड दिया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText प्रॉपर्टी सेट करें**
Aspose.Slides for C++ डेवलपर्स को किसी भी आकार का AlternateText सेट करने की अनुमति देता है। किसी आकार का AlternateText सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. स्लाइड में कोई भी आकार जोड़ें।
1. नए जोड़े गए आकार के साथ कुछ कार्य करें।
1. आकारों के माध्यम से इटररेट करके इच्छित आकार खोजें।
1. AlternativeText सेट करें।
1. फ़ाइल को डिस्क पर सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **आकार के लिए लेआउट फ़ॉर्मेट एक्सेस करें**
Aspose.Slides for C++ डेवलपर्स को आकार के लिए लेआउट फ़ॉर्मेट एक्सेस करने की अनुमति देता है। यह लेख दिखाता है कि आप आकार के **FillFormat** और **LineFormat** प्रॉपर्टी को कैसे एक्सेस कर सकते हैं।

नीचे नमूना कोड दिया गया है।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **आकार को SVG के रूप में रेंडर करें**
अब Aspose.Slides for C++ आकार को SVG के रूप में रेंडर करने को समर्थन देता है। WriteAsSvg मेथड (और उसका ओवरलोड) Shape क्लास और IShape इंटरफ़ेस में जोड़ा गया है। यह मेथड आकार की सामग्री को SVG फ़ाइल के रूप में सहेजने की अनुमति देता है। नीचे दिया गया कोड स्निपेट दिखाता है कि स्लाइड के आकार को SVG फ़ाइल में कैसे निर्यात करें।

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **आकार संरेखण**
Aspose.Slides आकारों को स्लाइड के मार्जिन या एक‑दूसरे के सापेक्ष संरेखित करने की अनुमति देता है। इसके लिए ओवरलोडेड [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) मेथड उपलब्ध किया गया है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) enumeration संभावित संरेखण विकल्पों को परिभाषित करता है।

**उदाहरण 1**

नीचे दिया गया स्रोत कोड इंडेक्स 1, 2 और 4 वाले आकारों को स्लाइड की ऊपरी सीमा के साथ संरेखित करता है।

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**उदाहरण 2**

नीचे का उदाहरण दिखाता है कि संपूर्ण आकार संग्रह को संग्रह में सबसे निचले आकार के सापेक्ष कैसे संरेखित किया जाए।

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **फ़्लिप प्रॉपर्टी**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeframe/) क्लास `flipH` और `flipV` प्रॉपर्टी के माध्यम से आकारों के क्षैतिज और लंबवत मिररिंग को नियंत्रित करती है। दोनों प्रॉपर्टी [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) प्रकार की हैं, जिससे `True` फ्लिप को दर्शाता है, `False` बिना फ्लिप के, और `NotDefined` डिफ़ॉल्ट व्यवहार रखता है। ये मान आकार के [Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_frame/) से उपलब्ध हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapeframe/) उदाहरण वर्तमान स्थान और आकार, वांछित `flipH` तथा `flipV` मान, और रोटेशन एंगल के साथ बनाया जाता है। इस उदाहरण को आकार के [Frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_frame/) में असाइन करके और प्रस्तुति सहेजने से मिरर परिवर्तन लागू हो जाते हैं।

मान लीजिए हमारे पास sample.pptx फ़ाइल है जिसमें पहली स्लाइड में डिफ़ॉल्ट फ़्लिप सेटिंग वाला एकल आकार है, जैसा कि नीचे दिखाया गया है।

![फ़्लिप किए जाने वाला आकार](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टी को प्राप्त करता है और उसे क्षैतिज एवं लंबवत दोनों दिशा में फ़्लिप करता है।

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// आकार की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// आकार की लंबवत फ़्लिप प्रॉपर्टी प्राप्त करें।
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // क्षैतिज फ़्लिप।
auto flipV = NullableBool::True; // क्षैतिज फ़्लिप।
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![फ़्लिप किया गया आकार](flipped_shape.png)

## **FAQ**

**क्या मैं स्लाइड पर आकारों को (union/intersect/subtract) डेस्कटॉप एडिटर की तरह जोड़ सकता हूँ?**

ऐसी कोई बिल्ट‑इन Boolean ऑपरेशन API नहीं है। आप इच्छित रूपरेखा स्वयं बनाकर एक अनुमानित समाधान प्राप्त कर सकते हैं—उदाहरण के लिए, परिणामस्वरूप ज्यामिति को [GeometryPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides/geometrypath/) के माध्यम से गणना करके उस कंटूर के साथ नया आकार बनाएँ और मूल आकारों को वैकल्पिक रूप से हटा दें।

**मैं स्टैकिंग क्रम (z‑order) को कैसे नियंत्रित करूँ ताकि आकार हमेशा “सबसे ऊपर” रहे?**

स्लाइड के [shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseslide/get_shapes/) संग्रह में सम्मिलन/स्थानांतरित क्रम बदलें। पूर्वानुमानित परिणामों के लिए सभी अन्य स्लाइड संशोधनों के बाद z‑order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को आकार संपादित करने से रोकने के लिये उसे “लॉक” कर सकता हूँ?**

हाँ। [shape‑level protection flags](/slides/hi/cpp/applying-protection-to-presentation/) सेट करें (उदा., चयन, गति, आकार बदलना, टेक्स्ट संपादन को लॉक करें)। आवश्यकता पड़ने पर मास्टर या लेआउट पर प्रतिबंध लागू करें। यह UI‑स्तर का संरक्षण है, सुरक्षा सुविधा नहीं; अधिक मजबूत संरक्षण के लिये फ़ाइल‑स्तर की प्रतिबंधों जैसे [पढ़ने‑के‑लिए‑सिफ़ारिशें या पासवर्ड](/slides/hi/cpp/password-protected-presentation/) के साथ संयोजन करें।