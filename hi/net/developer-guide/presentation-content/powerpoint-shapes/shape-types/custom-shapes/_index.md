---
title: .NET में प्रस्तुति शैलियों को अनुकूलित करें
linktitle: कस्टम शैली
type: docs
weight: 20
url: /hi/net/custom-shape/
keywords:
- कस्टम शैली
- शैली जोड़ें
- शैली बनाएं
- शैली बदलें
- शैली ज्यामिति
- ज्यामिति पाथ
- पाथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन ऑपरेशन
- मोड़ वाला कोना
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में शैलियों को बनाएं और अनुकूलित करें: ज्यामिति पाथ, मोड़ वाले कोने, सम्मिलित शैलियां।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति शैलियों को कस्टमाइज़ करने के लिए शैलियों की ज्यामिती को संपादन बिंदुओं और ज्यामिति पाथ के माध्यम से संपादित करने की प्रक्रिया को समझाता है। यह दिखाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) के साथ मौजूदा शैलियों को बदलें, बुनियादी पाथ संपादन ऑपरेशन्स करें, बिंदु जोड़ें या हटाएं, और अपडेटेड ज्यामिति को फिर से शैली पर लागू करें।

यह यह भी दर्शाता है कि कैसे कस्टम और कंपोज़िट शैलियों को बनाया जाए, मोड़ वाले कोनों के साथ शैलियों को निर्मित किया जाए, यह निर्धारित किया जाए कि शैली की ज्यामिति बंद है या नहीं, और अतिरिक्त ज्यामिति कस्टमाइज़ेशन परिदृश्यों के लिए [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) के बीच लेगेसी रूपांतरण का उपयोग किया जाए।

## **संपादन बिंदुओं द्वारा शैली बदलें**

PowerPoint में, आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको शैली की रूपरेखा बदलने या मौजूदा शैली को नई शैली के आधार के रूप में उपयोग करने की अनुमति देते हैं।

## **शैली संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint शैलियों को संपादित करते समय निम्नलिखित अवधारणाओं को ध्यान में रखें:

* एक शैली (या इसका पाथ) बंद या खुला हो सकता है।
* शैली का पाथ एंकर बिंदुओं से जुड़े खण्डों से बना होता है।
* एक खण्ड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसके आकार को निर्धारित करते हैं।
* एंकर बिंदु कोने बिंदु, सीधा बिंदु, या स्मूद बिंदु के रूप में मौजूद होते हैं:
  * कोने बिंदु पर, सटे खण्ड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से विभिन्न दूरी पर हो सकते हैं।
* एंकर बिंदुओं को स्थानांतरित करने या उनके हैंडल को समायोजित करने से शैली की रूपरेखा बदलती है।

PowerPoint शैलियों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) इंस्टेंस [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) ऑब्जेक्ट की ज्यामिति पाथ का प्रतिनिधित्व करता है।
* [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) मेथड का उपयोग करके आप [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) प्राप्त कर सकते हैं।
* शैली के लिए [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) सेट करने हेतु आप इन मेथड्स का उपयोग कर सकते हैं: एकल पाथ वाली शैलियों के लिए [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) और कई पाथ वाली शैलियों के लिए [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)।
* खण्ड जोड़ने के लिए आप [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) के तहत मेथड्स का उपयोग कर सकते हैं।
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) और [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) प्रॉपर्टीज़ के माध्यम से आप ज्यामिति पाथ की उपस्थिति निर्धारित कर सकते हैं।
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) प्रॉपर्टी का उपयोग करके आप एक [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खण्डों की ऐरे के रूप में प्राप्त कर सकते हैं।
* उन लेगेसी संस्करणों में जो नीचे दिए गए रूपांतरण मेथड्स को सपोर्ट करते हैं, आप [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) को [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) में बदल सकते हैं।
* [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) क्लास से [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) और [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) मेथड्स का उपयोग करके आप [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) के बीच रूपांतरण कर सकते हैं।

## **सरल संपादन ऑपरेशन्स**

निम्नलिखित मेथड्स का उपयोग करके आप एक ज्यामिति पाथ को संपादित कर सकते हैं। ओवरलोड जो इंडेक्स स्वीकार करते हैं, पाथ के खण्ड एरे में शून्य-आधारित स्थिति पर खण्ड सम्मिलित करते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| दो नियंत्रण बिंदुओं और एक अंतिम बिंदु के साथ क्यूबिक बीज़ियर वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| एक नियंत्रण बिंदु और एक अंतिम बिंदु के साथ क्वाड्रेटिक बीज़ियर वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| निर्दिष्ट आयाम और डिग्री में एंगल के साथ दीर्घवृत्तीय चाप जोड़ें। | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| वर्तमान आकृति को उसके अंतिम बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| आकृति के प्रारंभ बिंदु को सेट करें। | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| शून्य-आधारित इंडेक्स पर खण्ड हटाएँ। | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **शैली में कस्टम बिंदु जोड़ें**

यह उदाहरण [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) का उपयोग करके आयताकार शैली में दो बिंदु सम्मिलित करता है और संशोधित पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू करता है। निर्देशांक शैली के स्थानीय होते हैं: दोनों नए बिंदु शैली के केंद्र में स्थित हैं, बाएँ से 100 प्वाइंट और शीर्ष से 50 प्वाइंट पर। खण्ड इंडेक्स 1 और 4 उन्हें ऊपर और नीचे किनारों पर रखते हैं, जिससे वे किनारे अंदर की ओर खींचे जाते हैं।

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **शैली से बिंदु हटाएँ**

यह उदाहरण [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) के साथ शून्य-आधारित इंडेक्स 2 पर खण्ड हटाकर हृदय-आकार की रूपरेखा बदलता है। संशोधित पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू करने से शैली की ध्रुजें अपडेट हो जाती हैं।

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **कस्टम शैली बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) का उपयोग करके पाँच‑बिंदु वाले सितारे का निर्माण करता है। बाहरी और भीतरी त्रिज्या क्रमशः 100 और 50 प्वाइंट होते हैं, जो टिप्स और कटाव को परिभाषित करते हैं; 72‑डिग्री चरण पाँच टिप्स को समान रूप से विभाजित करता है। पाथ को [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) द्वारा बंद किया जाता है और आयताकार शैली पर [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) के माध्यम से लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **कम्पोज़िट कस्टम शैली बनाएँ**

यह उदाहरण शैली के ऊपर और नीचे के तिहाई भागों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ऑब्जेक्ट्स परिभाषित करता है। दोनों पाथ को [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करने से मध्य तिहाई में एक अंतर के साथ एकल कम्पोज़िट शैली बनती है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2, 0);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **मोड़ वाले कोनों के साथ कस्टम शैली बनाएँ**

यह उदाहरण [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) के साथ सीधी खण्डों को मिलाकर अंदर की ओर मोड़ वाले कोनों वाली शैली बनाता है। प्रत्येक कोना आकार बिंदुओं में चाप की चौड़ाई और ऊँचाई निर्धारित करता है, और -90‑डिग्री स्वीप एक विरोधी घड़ी की दिशा में चतुर्थक दीर्घवृत्त बनाता है। पूर्ण पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू किया जाता है, तथा प्रस्तुति को PPTX स्वरूप में सहेजा जाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **जांचें कि शैली की ज्यामिति बंद है या नहीं**

निम्नलिखित हेल्पर यह जाँचता है कि प्रत्येक गैर‑रिक्त ज्यामिति पाथ समाप्ति खण्ड के साथ बंद है या नहीं। यह [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) को पढ़ता है और अंतिम खण्ड के [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑रिक्त पाथ नहीं है तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक सब‑फ़िगर को नहीं देखता। उदाहरण एक आयत के लिए `True` प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **शैली तत्वों को निकालें और जाँचें**

एक मौजूदा शैली को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण करने के लिये [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) का उपयोग करें। प्रत्येक लौटाए गए [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) में कास्ट करके आप उसके [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) और [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) ऐरे पढ़ सकते हैं। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिये उपयोगी है।

उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर सीधे पहली ज्यामिति शैली खोजता है, और उसके पाथ खण्डों को प्रिंट करता है। दोनों सीधी और वक्र खण्ड वाली शैली वाले प्रेज़ेंटेशन का उपयोग करें ताकि दोनों प्रकार के आउटपुट देख सकें। यह समूहों के भीतर नहीं खोजता।

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

ऐरे इंडेक्स के अनुसार संगत होते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका को दर्शाता है। प्रकार `0` एक आकृति की शुरुआत करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा बनाता है। एक क्यूबिक बीज़ियर खण्ड पिछले अंतिम बिंदु से शुरू होता है और क्रमिक तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंतिम बिंदु। लूप इन तीन प्रविष्टियों को साथ में उपभोग करता है और बंद होने के लिए अंतिम बिंदु की जाँच करता है।

बिंदु प्रकारों में फ़्लैग भी होते हैं। खण्ड प्रकार पहचानने के लिये `0x07` से मास्क करें, और बंद सब‑पाथ का पता लगाने के लिये `0x80` को अलग से टेस्ट करें। उदाहरण के लिये, `129` (`0x81`) का अर्थ है एक रेखा अंत बिंदु जो सब‑पाथ को बंद करता है, और `131` (`0x83`) का अर्थ है एक बीज़ियर अंत बिंदु जो बंद करता है। केवल `1` या `3` से कच्चे मान की तुलना करने से ये केस छूट जाएंगे। डैश (`0x10`) और मार्कर (`0x20`) जैसे अन्य फ़्लैग मूल खण्ड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट्स (1/72 इंच) में मापे जाते हैं, जहाँ X दाएँ और Y नीचे की ओर बढ़ता है। अपरिभाषित शैली के लिए निकाले गए निर्देशांक पहले ही उसके [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) स्थिति को सम्मिलित करते हैं और वर्तमान चौड़ाई व ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित, आकार `120 × 80` वाला बिना घुमाए आयत की कंटूर सीमा `(100, 200)`‑`(220, 280)` होती है। शैली की स्थिति को पुनः न जोड़ें। अपने निर्देशांक को अनरोटेटेड फ्रेम के सापेक्ष प्राप्त करने हेतु उसके X और Y को घटाएँ।

निकाले गए बिंदु शैली के [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) या क्षैतिज‑वर्टिकल फ़्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः बनाने के लिये इन रूपांतरणों को शैली के केंद्र के चारों ओर लागू करें। समूहित शैलियों के लिये समूह निर्देशांक मैपिंग और रूपांतरणों को भी ध्यान में रखें; यह मान कर न चलें कि निकाले गए बिंदु अंतिम स्लाइड निर्देशांक हैं या अनावश्यक रूप से ट्रांसलेशन या स्केल दो बार लागू हो रहा है।

**निरीक्षण बनाम संपादन।** निकाले गए ऐरे कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल शैली अपडेट नहीं होती। जब आपके विश्लेषण या ड्राइंग कोड को बिंदु/प्रकार ऐरे की आवश्यकता हो तो इस विधि का उपयोग करें। शैली के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या ज्यामिति संपादित करनी हो तो [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। संपादित पाथ को [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) या [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करें।

## **GeometryPath को GraphicsPath (System.Drawing.Drawing2D) में बदलें**

निम्नलिखित उदाहरण एक लेगेसी Aspose.Slides for .NET असेंबली की आवश्यकता रखता है जो [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) को सपोर्ट करता है, जैसे संस्करण 25.10, और Windows पर `System.Drawing.Common` उपलब्ध हो। यह रूपांतरण मेथड्स [संस्करण 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) में हटा दिए गए हैं।

यह उदाहरण एक आयताकार रूपरेखा को टेक्स्ट के ज्यामिति में बदलता है। रूपरेखा का [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) फ़िल को निष्क्रिय करने के लिये सेट किया गया है। एक [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) टेक्स्ट रूपरेखा को संग्रहीत करता है, जिसे [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) द्वारा एक भरावयुक्त ज्यामिति पाथ में बदला जाता है। दोनों पाथ को [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करने से आयत और टेक्स्ट दोनों को सम्मिलित करने वाली एकल शैली बनती है। विपरीत दिशा में रूपांतरण के लिये आप [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) का उपयोग कर सकते हैं।

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ज्यामिति बदलने के बाद फ़िल और रूपरेखा क्या होगी?**

स्टाइल शैली के साथ रहता है; केवल कंटूर बदलता है। फ़िल और रूपरेखा नए ज्यामिति पर स्वतः लागू हो जाते हैं।

**कस्टम शैली को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमाएँ?**

शैली की [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) प्रॉपर्टी का उपयोग करें; क्योंकि ज्यामिति शैली के स्वयं के निर्देशांक प्रणाली से जुड़ी है, वह शैली के साथ घुम जाएगी।

**क्या मैं कस्टम शैली को एक चित्र में बदल कर परिणाम “लॉक” कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/net/convert-powerpoint-to-png/) क्षेत्र या [shape](/slides/hi/net/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के कार्य को सरल बनाता है।