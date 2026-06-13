---
title: ".NET में प्रस्तुतियों में कनेक्टर प्रबंधित करें"
linktitle: "कनेक्टर"
type: docs
weight: 10
url: /hi/net/connector/
keywords:
- "कनेक्टर"
- "कनेक्टर प्रकार"
- "कनेक्टर बिंदु"
- "कनेक्टर रेखा"
- "कनेक्टर कोण"
- "आकारों को कनेक्ट करें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET ऐप्स को PowerPoint स्लाइड्स में रेखाएँ बनाने, जोड़ने और स्वचालित रूप से मार्ग निर्धारित करने के लिए सक्षम बनाएं—सीधे, एल्बो और घुमावदार कनेक्टरों पर पूर्ण नियंत्रण प्राप्त करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष लाइन है जो दो आकारों को एक साथ जोड़ती या लिंक करती है और स्लाइड पर आकारों को ले जाने या पुनर्स्थापित करने पर भी जुड़ी रहती है।

कनेक्टर आमतौर पर *कनेक्शन डॉट्स* (हरा डॉट) से जुड़े होते हैं, जो डिफ़ॉल्ट रूप से सभी आकारों पर मौजूद होते हैं। कनेक्शन डॉट्स तब दिखाई देते हैं जब कर्सर उनके पास आता है।

*समायोजन बिंदु* (नारंगी डॉट), जो केवल कुछ कनेक्टर में होते हैं, कनेक्टर की स्थिति और आकार को बदलने के लिए उपयोग किए जाते हैं।

## **कनेक्टर के प्रकार**

PowerPoint में आप सीधा, एल्बो (कोणीय) और घुमावदार कनेक्टर का उपयोग कर सकते हैं।

Aspose.Slides ये कनेक्टर प्रदान करता है:

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **कनेक्टर का उपयोग करके आकारों को कनेक्ट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `AddAutoShape` मेथड का उपयोग करके स्लाइड पर दो [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `AddConnector` मेथड का उपयोग करके कनेक्टर टाइप निर्धारित कर एक कनेक्टर जोड़ें।  
1. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
1. सबसे छोटा कनेक्शन पाथ लागू करने के लिए `Reroute` मेथड को कॉल करें।  
1. प्रस्तुति को सहेजें।

यह C# कोड दिखाता है कि दो आकारों (एक अंडाकार और एक आयत) के बीच एक बेंट कनेक्टर कैसे जोड़ें:

```c#
// एक प्रस्तुति क्लास का इंस्टेंस बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
using (Presentation input = new Presentation())
{                
    // किसी विशेष स्लाइड के लिए शैप्स कलेक्शन तक पहुँचता है
    IShapeCollection shapes = input.Slides[0].Shapes;

    // एक एलिप्स ऑटॉशेप जोड़ता है
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // एक रेक्टैंगल ऑटॉशेप जोड़ता है
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // स्लाइड शैप्स कलेक्शन में एक कनेक्टर शेप जोड़ता है
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // कनेक्टर का उपयोग करके शैप्स को जोड़ता है
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // रीरूट को कॉल करता है जो शैप्स के बीच स्वचालित सबसे छोटा पाथ सेट करता है
    connector.Reroute();

    // प्रस्तुति को सहेजता है
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.Reroute` मेथड कनेक्टर को फिर से रूट करता है और इसे आकारों के बीच सबसे छोटा संभव पाथ लेने के लिए मजबूर करता है। यह लक्ष्य हासिल करने के लिए मेथड `StartShapeConnectionSiteIndex` और `EndShapeConnectionSiteIndex` बिंदुओं को बदल सकता है। 
{{% /alert %}} 

## **कनेक्शन डॉट निर्दिष्ट करें**
यदि आप चाहते हैं कि कनेक्टर विशिष्ट डॉट्स का उपयोग करके दो आकारों को लिंक करे, तो आप अपनी पसंदीदा कनेक्शन डॉट्स इस प्रकार निर्दिष्ट कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `AddAutoShape` मेथड का उपयोग करके स्लाइड पर दो [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `AddConnector` मेथड का उपयोग करके कनेक्टर टाइप निर्धारित कर एक कनेक्टर जोड़ें।  
1. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
1. आकारों पर अपनी पसंदीदा कनेक्शन डॉट्स सेट करें।  
1. प्रस्तुति को सहेजें।

यह C# कोड दर्शाता है कि कैसे एक पसंदीदा कनेक्शन डॉट निर्दिष्ट किया जाता है:

```c#
// एक प्रस्तुति क्लास का इंस्टेंस बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करती है
using (Presentation presentation = new Presentation())
{
    // किसी विशेष स्लाइड के लिए शैप्स कलेक्शन तक पहुँचता है
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // स्लाइड के शैप्स कलेक्शन में एक कनेक्टर शेप जोड़ता है
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // एक एलिप्स ऑटॉशेप जोड़ता है
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // एक रेक्टैंगल ऑटॉशेप जोड़ता है
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // कनेक्टर का उपयोग करके शैप्स को जोड़ता है
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // एलिप्स शेप पर पसंदीदा कनेक्शन डॉट इंडेक्स सेट करता है
    uint wantedIndex = 6;

    // जाँचता है कि पसंदीदा इंडेक्स अधिकतम साइट इंडेक्स गिनती से कम है या नहीं
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // एलिप्स ऑटॉशेप पर पसंदीदा कनेक्शन डॉट सेट करता है
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // प्रस्तुति को सहेजता है
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **कनेक्टर बिंदु को समायोजित करें**

आप मौजूदा कनेक्टर को उसके समायोजन बिंदुओं के माध्यम से समायोजित कर सकते हैं। केवल उन कनेक्टर को इस तरह बदला जा सकता है जिनमें समायोजन बिंदु होते हैं। देखें **[कनेक्टर के प्रकार](/slides/hi/net/connector/#types-of-connectors)** के तहत तालिका।

### **सरल मामला**

विचार करें कि दो आकारों (A और B) के बीच का कनेक्टर एक तीसरे आकार (C) के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

कोड:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

तीसरे आकार से बचने या उसे बायपास करने के लिए हम कनेक्टर को इस प्रकार बाएँ की ओर उसकी वर्टिकल लाइन को स्थानांतरित करके समायोजित कर सकते हैं:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **जटिल मामले**

जटिल समायोजन करने के लिए आपको निम्नलिखित बातों को ध्यान में रखना होगा:

* कनेक्टर का समायोज्य बिंदु एक फ़ॉर्मूले से कड़ा संबंध रखता है जो उसकी स्थिति की गणना करता है। इसलिए बिंदु के स्थान में बदलाव कनेक्टर के आकार को बदल सकता है।  
* कनेक्टर के समायोजन बिंदु एक एरे में सख्त क्रम में परिभाषित होते हैं। समायोजन बिंदु कनेक्टर के प्रारंभ बिंदु से अंत बिंदु तक क्रमांकित होते हैं।  
* समायोजन बिंदु मान कनेक्टर आकार की चौड़ाई/ऊँचाई के प्रतिशत को दर्शाते हैं।  
  * आकार कनेक्टर के प्रारंभ और अंत बिंदु द्वारा 1000 से गुणा करके सीमित होता है।  
  * पहला बिंदु, दूसरा बिंदु, और तीसरा बिंदु क्रमशः चौड़ाई का प्रतिशत, ऊँचाई का प्रतिशत, और फिर से चौड़ाई का प्रतिशत परिभाषित करते हैं।  
* कनेक्टर के समायोजन बिंदुओं के निर्देशांक निर्धारित करने वाली गणनाओं में आपको कनेक्टर के घुमाव और उसके प्रतिबिंब को ध्यान में रखना होगा। **ध्यान दें** कि सभी कनेक्टर के लिए दिखाए गए **[कनेक्टर के प्रकार](/slides/hi/net/connector/#types-of-connectors)** का घुमाव कोण 0 है।

#### **मामला 1**

विचार करें कि दो टेक्स्ट फ्रेम ऑब्जेक्ट कनेक्टर के माध्यम से जुड़े हैं:

![connector-shape-complex](connector-shape-complex.png)

कोड:

```c#
 // एक प्रस्तुति क्लास का इंस्टेंस बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation();
 // प्रस्तुति में पहली स्लाइड प्राप्त करता है
ISlide sld = pres.Slides[0];
 // ऐसे आकार जोड़ता है जो कनेक्टर के माध्यम से जुड़ेंगे
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
 // एक कनेक्टर जोड़ता है
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
 // कनेक्टर की दिशा निर्दिष्ट करता है
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
 // कनेक्टर का रंग निर्दिष्ट करता है
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
 // कनेक्टर की लाइन की मोटाई निर्दिष्ट करता है
connector.LineFormat.Width = 3;

 // कनेक्टर के साथ आकारों को आपस में जोड़ता है
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

 // कनेक्टर के लिए समायोजन बिंदु प्राप्त करता है
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**समायोजन**

हम कनेक्टर के समायोजन बिंदु मानों को संबंधित चौड़ाई और ऊँचाई प्रतिशत को क्रमशः 20 % और 200 % बढ़ाकर बदल सकते हैं:

```c#
// समायोजन बिंदुओं के मान बदलता है
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

परिणाम:

![connector-adjusted-1](connector-adjusted-1.png)

व्यक्तिगत भागों के निर्देशांक और आकार निर्धारित करने वाला मॉडल बनाने के लिए, आइए एक आकार बनाते हैं जो कनेक्टर के `Adjustments[0]` बिंदु के क्षैतिज घटक के अनुरूप हो:

```c#
// कनेक्टर के लंबवत घटक को बनाएं

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

परिणाम:

![connector-adjusted-2](connector-adjusted-2.png)

#### **मामला 2**

**मामला 1** में हमने बुनियादी सिद्धांतों का उपयोग करके एक सरल कनेक्टर समायोजन ऑपरेशन दिखाया था। सामान्य परिस्थितियों में आपको कनेक्टर का घुमाव और उसकी प्रस्तुति (जो `connector.Rotation`, `connector.Frame.FlipH`, और `connector.Frame.FlipV` द्वारा निर्धारित होती है) को ध्यान में रखना होगा। अब हम प्रक्रिया को दर्शाते हैं।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन के लिए) और एक नया (हरा) कनेक्टर बनाएं जो इसे पहले बनाए गए ऑब्जेक्ट्स से जोड़ता है।

```c#
 // एक नया बाइंडिंग ऑब्जेक्ट बनाता है
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
 // एक नया कनेक्टर बनाता है
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
 // नए बनाए गए कनेक्टर का उपयोग करके ऑब्जेक्ट्स को जोड़ता है
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
 // कनेक्टर के समायोजन बिंदु प्राप्त करता है
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
 // समायोजन बिंदुओं के मान बदलता है 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

परिणाम:

![connector-adjusted-3](connector-adjusted-3.png)

दूसरे, एक ऐसा आकार बनाएं जो नए कनेक्टर के समायोजन बिंदु `connector.Adjustments[0]` से होकर गुजरने वाले क्षैतिज घटक के अनुरूप हो। हम कनेक्टर डेटा से `connector.Rotation`, `connector.Frame.FlipH`, और `connector.Frame.FlipV` के मान उपयोग करेंगे और दिए हुए बिंदु x₀ के चारों ओर घुमाव के लिए लोकप्रिय कोऑर्डिनेट परिवर्तन फ़ॉर्मूला लागू करेंगे:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में वस्तु का घुमाव 90 डिग्री है और कनेक्टर लंबवत प्रदर्शित है, इसलिए संबंधित कोड यह है:

```c#
// कनेक्टर के निर्देशांक को सहेजता है
x = connector.X;
y = connector.Y;
// यदि यह दिखाई देता है तो कनेक्टर के निर्देशांक को सही करता है
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// समायोजन बिंदु के मान को निर्देशांक के रूप में लेता है
x += connector.Width * adjValue_0.RawValue / 100000;
// निर्देशांक को परिवर्तित करता है क्योंकि Sin(90) = 1 और Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// दूसरे समायोजन बिंदु मान का उपयोग करके क्षैतिज घटक की चौड़ाई निर्धारित करता है
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```

परिणाम:

![connector-adjusted-4](connector-adjusted-4.png)

हमने सरल समायोजन और जटिल समायोजन बिंदुओं (घुमाव कोण के साथ) वाले गणनाएँ प्रदर्शित कीं। प्राप्त ज्ञान के साथ आप अपना मॉडल विकसित कर सकते हैं (या कोड लिख सकते हैं) ताकि `GraphicsPath` ऑब्जेक्ट प्राप्त किया जा सके या विशिष्ट स्लाइड निर्देशांक के आधार पर कनेक्टर के समायोजन बिंदु मान सेट किए जा सकें।

## **कनेक्टर लाइनों का कोण खोजें**
1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।  
1. इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
1. कनेक्टर लाइन आकार तक पहुँचें।  
1. कोण की गणना के लिए लाइन की चौड़ाई, ऊँचाई, आकार फ्रेम की ऊँचाई और आकार फ्रेम की चौड़ाई का उपयोग करें।

यह C# कोड दर्शाता है कि हमने कनेक्टर लाइन आकार के लिए कोण की गणना कैसे की:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि कोई कनेक्टर किसी विशिष्ट आकार से "चिपक" सकता है?**  
जाँचें कि आकार [कनेक्शन साइट्स](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/connectionsitecount/) प्रदान करता है या नहीं। यदि कोई नहीं है या गिनती शून्य है, तो चिपकाना उपलब्ध नहीं है; इस स्थिति में आपको मुक्त एंडपॉइंट्स का उपयोग करके उन्हें मैन्युअली स्थिति देना होगा। अटैच करने से पहले साइट काउंट की जाँच करना उचित है।

**यदि मैं जुड़े हुए आकारों में से एक को हटाता हूँ तो कनेक्टर क्या करता है?**  
उसके अंत डिटैच हो जाएंगे; कनेक्टर स्लाइड पर एक सामान्य लाइन के रूप में रह जाता है जिसमें मुक्त प्रारंभ/समाप्त बिंदु होते हैं। आप इसे हटाया जा सकता है या कनेक्शन को पुनः निर्धारित किया जा सकता है और आवश्यक होने पर [reroute](https://reference.aspose.com/slides/hi/net/aspose.slides/connector/reroute/) किया जा सकता है।

**क्या स्लाइड को किसी अन्य प्रस्तुति में कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**  
आमतौर पर हाँ, बशर्ते लक्षित आकारों को भी कॉपी किया जाए। यदि स्लाइड को किसी अन्य फ़ाइल में बिना जुड़े हुए आकारों के सम्मिलित किया जाता है, तो अंत मुक्त हो जाते हैं और आपको उन्हें पुनः अटैच करना पड़ेगा।