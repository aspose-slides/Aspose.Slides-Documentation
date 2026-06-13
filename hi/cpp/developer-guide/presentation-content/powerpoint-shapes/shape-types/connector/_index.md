---
title: C++ का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/cpp/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- आकृतियों को कनेक्ट करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint स्लाइड में रेखाओं को आरेखित करने, जोड़ने और स्वतः‑रूट करने के लिए C++ एप्लिकेशन को सक्षम बनाएं—सीधी, कोनीय और वक्र कनेक्टरों पर पूरा नियंत्रण प्राप्त करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष रेखा है जो दो आकृतियों को जोड़ती या लिंक करती है और स्लाइड पर आकृतियों को स्थानांतरित या पुनःस्थित करने पर भी उनसे जुड़ी रहती है।  

कनेक्टर आम तौर पर *connection dots* (हरे बिंदु) से जुड़े होते हैं, जो सभी आकृतियों में डिफ़ॉल्ट रूप से मौजूद होते हैं। कर्सर के पास आने पर कनेक्शन डॉट दिखते हैं।  

*Adjustment points* (नारंगी बिंदु), जो केवल कुछ कनेक्टरों में होते हैं, का उपयोग कनेक्टरों की स्थिति और आकार को बदलने के लिये किया जाता है।  

## **कनेक्टर के प्रकार**

PowerPoint में आप सीधी,_elbow_ (कोणीय) और वक्र कनेक्टरों का उपयोग कर सकते हैं।  

Aspose.Slides ये कनेक्टर प्रदान करता है:

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **कनेक्टर का उपयोग करके आकृतियों को जोड़ें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `Shapes` ऑब्जेक्ट द्वारा प्रदान की गई `AddAutoShape` मेथड का उपयोग करके स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.auto_shape) जोड़ें।  
4. कनेक्टर प्रकार को परिभाषित करके `Shapes` ऑब्जेक्ट द्वारा प्रदान की गई `AddConnector` मेथड का उपयोग करके एक कनेक्टर जोड़ें।  
5. कनेक्टर का उपयोग करके आकृतियों को जोड़ें।  
6. सबसे छोटे कनेक्शन पथ को लागू करने के लिए `Reroute` मेथड को कॉल करें।  
7. प्रस्तुति को सहेजें।  

यह C++ कोड दिखाता है कि दो आकृतियों (एक दीर्घवृत्त और एक आयत) के बीच एक कनेक्टर (एक बेंट कनेक्टर) कैसे जोड़ें:

```c++
// दस्तावेज़ निर्देशिका का पथ।
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// इच्छित प्रस्तुति लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// पहली स्लाइड तक पहुँचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// विशिष्ट स्लाइड के लिए आकार संग्रह तक पहुँचता है
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// एक दीर्घवृत्त ऑटोशेप जोड़ता है
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// एक आयत ऑटोशेप जोड़ता है
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// स्लाइड आकार संग्रह में एक कनेक्टर आकार जोड़ता है
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// कनेक्टर का उपयोग करके आकारों को जोड़ता है
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// ररूट कॉल करता है जो आकारों के बीच स्वत: सबसे छोटा पथ सेट करता है
	connector->Reroute();
	
	// प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

`connector->Reroute` मेथड एक कनेक्टर को पुन:मार्गित करता है और इसे आकृतियों के बीच सबसे छोटा संभव पथ लेने के लिए बाध्य करता है। अपने उद्देश्य को प्राप्त करने के लिये, यह मेथड `StartShapeConnectionSiteIndex` और `EndShapeConnectionSiteIndex` बिंदुओं को बदल सकता है। 

{{% /alert %}} 

## **कनेक्शन डॉट निर्दिष्ट करें**

यदि आप कनेक्टर को आकृतियों पर विशिष्ट डॉट्स के माध्यम से दो आकृतियों को जोड़ना चाहते हैं, तो आपको अपने पसंदीदा कनेक्शन डॉट्स इस प्रकार निर्दिष्ट करने होंगे:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `Shapes` ऑब्जेक्ट द्वारा प्रदान की गई `AddAutoShape` मेथड का उपयोग करके स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.auto_shape) जोड़ें।  
4. कनेक्टर प्रकार को परिभाषित करके `Shapes` ऑब्जेक्ट द्वारा प्रदान की गई `AddConnector` मेथड का उपयोग करके एक कनेक्टर जोड़ें।  
5. कनेक्टर का उपयोग करके आकृतियों को जोड़ें।  
6. आकृतियों पर अपने पसंदीदा कनेक्शन डॉट्स सेट करें।  
7. प्रस्तुति को सहेजें।  

यह C++ कोड दर्शाता है कि एक पसंदीदा कनेक्शन डॉट कैसे निर्दिष्ट किया जाता है:

```c++
	// दस्तावेज़ निर्देशिका का पथ।
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// इच्छित प्रस्तुति लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// पहली स्लाइड तक पहुँचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// विशिष्ट स्लाइड के लिए आकृति संग्रह तक पहुँचता है
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// एक दीर्घवृत्त ऑटोशेप जोड़ता है
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// एक आयत ऑटोशेप जोड़ता है
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// स्लाइड के आकार संग्रह में एक कनेक्टर आकार जोड़ता है
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// कनेक्टर का उपयोग करके आकारों को जोड़ता है
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// दीर्घवृत्त आकृति पर पसंदीदा कनेक्शन डॉट सूचकांक सेट करता है
	int wantedIndex = 6;

	// जाँचता है कि पसंदीदा सूचकांक अधिकतम साइट सूचकांक गणना से कम है या नहीं
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// दीर्घवृत्त ऑटोशेप पर पसंदीदा कनेक्शन डॉट सेट करता है
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **कनेक्टर बिंदु को समायोजित करें**

आप एक मौजूदा कनेक्टर को उसके समायोजन बिंदुओं के माध्यम से समायोजित कर सकते हैं। केवल उन कनेक्टरों को जो समायोजन बिंदु रखते हैं, इस प्रकार बदला जा सकता है। **[कनेक्टर के प्रकार.](/slides/hi/cpp/connector/#types-of-connectors)** के तहत तालिका देखें।  

### **सरल मामला**

एक ऐसा मामला मानिए जहाँ दो आकृतियों (A और B) के बीच का कनेक्टर तीसरी आकृति (C) के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

कोड:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

तीसरी आकृति से बचने या उसे बायपास करने के लिये, हम कनेक्टर को इस प्रकार उसकी लंबवत रेखा को बाईं ओर ले जाकर समायोजित कर सकते हैं:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **जटिल मामलों**

 अधिक जटिल समायोजन करने के लिये, आपको निम्न बातों को ध्यान में रखना होगा:

* कनेक्टर का समायोज्य बिंदु एक सूत्र से दृढ़ता से जुड़ा होता है जो उसके स्थान की गणना करता है। इसलिए बिंदु के स्थान में बदलाव कनेक्टर के आकार को बदल सकता है।  
* कनेक्टर के समायोजन बिंदु एक एरे में कठोर क्रम में परिभाषित होते हैं। समायोजन बिंदुओं को कनेक्टर के प्रारम्भ बिंदु से अंत बिंदु तक क्रमांकित किया जाता है।  
* समायोजन बिंदु मान कनेक्टर आकृति की चौड़ाई/ऊँचाई के प्रतिशत को दर्शाते हैं।  
  * आकृति को कनेक्टर के प्रारम्भ और अंत बिंदुओं को 1000 से गुणा करके सीमित किया जाता है।  
  * पहला बिंदु, दूसरा बिंदु, और तीसरा बिंदु क्रमशः चौड़ाई का प्रतिशत, ऊँचाई का प्रतिशत, और फिर से चौड़ाई का प्रतिशत परिभाषित करते हैं।  
* उन गणनाओं के लिये जो कनेक्टर के समायोजन बिंदुओं के निर्देशांक निर्धारित करती हैं, आपको कनेक्टर के घूर्णन और उसके प्रतिबिंब को ध्यान में रखना होगा। **Note** कि **[कनेक्टर के प्रकार](/slides/hi/cpp/connector/#types-of-connectors)** में दिखाए गये सभी कनेक्टरों का घूर्णन कोण 0 है।  

#### **मामला 1**

एक ऐसा मामला मानिए जहाँ दो टेक्स्ट फ्रेम ऑब्जेक्ट कनेक्टर द्वारा जुड़े हुए हैं:

![connector-shape-complex](connector-shape-complex.png)

कोड:

```c++
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति वर्ग का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>();
// प्रस्तुति में पहली स्लाइड प्राप्त करता है
auto slide = pres->get_Slides()->idx_get(0);
// पहली स्लाइड से आकृतियाँ प्राप्त करता है
auto shapes = slide->get_Shapes();
// ऐसे आकृतियों को जोड़ता है जो कनेक्टर के माध्यम से जुड़ी होंगी
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// एक कनेक्टर जोड़ता है
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// कनेक्टर की दिशा निर्दिष्ट करता है
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// कनेक्टर रेखा की मोटाई निर्दिष्ट करता है
lineFormat->set_Width(3);
// कनेक्टर का रंग निर्दिष्ट करता है
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// कनेक्टर के साथ आकृतियों को आपस में जोड़ता है
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// कनेक्टर के समायोजन बिंदु प्राप्त करता है
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**समायोजन**

हम कनेक्टर के समायोजन बिंदु मानों को क्रमशः चौड़ाई और ऊँचाई के प्रतिशत को 20 % और 200 % बढ़ाकर बदल सकते हैं:

```c++
// समायोजन बिंदुओं के मान बदलता है
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

परिणाम:

![connector-adjusted-1](connector-adjusted-1.png)

कनेक्टर के व्यक्तिगत भागों के निर्देशांक और आकार निर्धारित करने वाली मॉडल बनाने के लिये, चलिए कनेक्टर के `connector.Adjustments[0]` बिंदु पर क्षैतिज घटक के अनुरूप एक आकृति बनाते हैं:

```c++
// कनेक्टर का लंबवत घटक बनाएं
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

परिणाम:

![connector-adjusted-2](connector-adjusted-2.png)

#### **मामला 2**

**मामला 1** में हमने बुनियादी सिद्धांतों का उपयोग करके एक सरल कनेक्टर समायोजन ऑपरेशन दिखाया। सामान्य परिस्थितियों में, आपको कनेक्टर के घूर्णन और उसकी प्रस्तुति (`connector.Rotation`, `connector.Frame.FlipH`, और `connector.Frame.FlipV` द्वारा सेट) को ध्यान में रखना होगा। अब हम प्रक्रिया को प्रदर्शित करेंगे।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन के प्रयोजन से) और एक नया (हरा) कनेक्टर बनाएँ जो इसे पहले बनाए गए ऑब्जेक्ट्स से जोड़े।

```c++
// एक नया बाइंडिंग ऑब्जेक्ट बनाता है
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// एक नया कनेक्टर बनाता है
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// नए बनाए गए कनेक्टर का उपयोग करके ऑब्जेक्ट्स को जोड़ता है
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// कनेक्टर के समायोजन बिंदु प्राप्त करता है
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// समायोजन बिंदुओं के मान बदलता है
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

परिणाम:

![connector-adjusted-3](connector-adjusted-3.png)

दूसरे, एक ऐसी आकृति बनाएँ जो नए कनेक्टर के समायोजन बिंदु `connector.Adjustments[0]` के माध्यम से गुजरने वाले क्षैतिज घटक से मेल खाती हो। हम `connector.Rotation`, `connector.Frame.FlipH`, और `connector.Frame.FlipV` के मानों का उपयोग करके घूर्णन के लिये सामान्य निर्देशांक परिवर्तन सूत्र लागू करेंगे:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में, ऑब्जेक्ट का घूर्णन कोण 90 डिग्री है और कनेक्टर लंबवत प्रदर्शित हो रहा है, इसलिए संबंधित कोड यह है:

```c++

```

परिणाम:

![connector-adjusted-4](connector-adjusted-4.png)

हमने सरल समायोजन और घूर्णन कोण वाले जटिल समायोजन बिंदुओं से संबंधित गणनाओं को प्रदर्शित किया। प्राप्त ज्ञान का उपयोग करके आप अपना स्वयं का मॉडल विकसित कर सकते हैं (या कोड लिख सकते हैं) ताकि `GraphicsPath` ऑब्जेक्ट प्राप्त किया जाए या विशिष्ट स्लाइड निर्देशांक के आधार पर कनेक्टर के समायोजन बिंदु मान सेट किए जा सकें।  

## **कनेक्टर लाइनों का कोण खोजें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. कनेक्टर लाइन आकृति तक पहुँचें।  
4. लाइन की चौड़ाई, ऊँचाई, आकृति फ्रेम की ऊँचाई और आकृति फ्रेम की चौड़ाई का उपयोग करके कोण की गणना करें।  

यह C++ कोड एक ऐसी ऑपरेशन को दर्शाता है जहाँ हमने कनेक्टर लाइन आकृति के लिये कोण की गणना की:

```c++
void ConnectorLineAngle()
{

	// दस्तावेज़ निर्देशिका का पथ।
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// इच्छित प्रस्तुति लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// पहली स्लाइड तक पहुँचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// स्लाइड्स की आकार संग्रह तक पहुँचता है
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि कोई कनेक्टर किसी विशिष्ट आकृति से “चिपक” सकता है?**  
जाँचें कि आकृति [connection sites](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_connectionsitecount/) प्रदान करती है या नहीं। यदि कोई नहीं है या गणना शून्य है, तो चिपकाने की सुविधा उपलब्ध नहीं है; ऐसी स्थिति में आप मुक्त अंत बिंदु उपयोग कर सकते हैं और उन्हें मैन्युअली स्थित कर सकते हैं। कनेक्शन से पहले साइट गणना की जाँच करना समझदारी है।  

**यदि मैं जुड़े हुए आकृतियों में से एक को हटाता हूँ तो कनेक्टर क्या करता है?**  
इसके अंत मोड़ दिए जाएंगे; कनेक्टर स्लाइड पर एक सामान्य रेखा के रूप में बच जाता है जिसके पास मुक्त प्रारम्भ/समाप्त बिंदु होते हैं। आप इसे हटाना या कनेक्शन पुनः निर्धारित करना चुन सकते हैं, और आवश्यकता अनुसार [reroute](https://reference.aspose.com/slides/hi/cpp/aspose.slides/connector/reroute/) भी कर सकते हैं।  

**क्या स्लाइड को किसी अन्य प्रस्तुति में कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**  
आमतौर पर हाँ, बशर्ते लक्ष्य आकृतियों को भी कॉपी किया गया हो। यदि स्लाइड को बिना जुड़े हुए आकृतियों के किसी अन्य फ़ाइल में सम्मिलित किया जाता है, तो अंत बिंदु मुक्त हो जाते हैं और आपको उन्हें पुनः संलग्न करना पड़ेगा।