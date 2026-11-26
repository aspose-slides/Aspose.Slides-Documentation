---
title: ".NET में प्रस्तुति आकारों को अनुकूलित करें"
linktitle: "कस्टम आकार"
type: docs
weight: 20
url: /hi/net/custom-shape/
keywords:
- "कस्टम आकार"
- "आकार जोड़ें"
- "आकार बनाएँ"
- "आकार बदलें"
- "आकार ज्यामिति"
- "ज्यामिति पाथ"
- "पाथ बिंदु"
- "संपादन बिंदु"
- "बिंदु जोड़ें"
- "बिंदु हटाएँ"
- "संपादन संचालन"
- "वक्र कोना"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में आकार बनाएँ और अनुकूलित करें: ज्यामिति पाथ, वक्र कोने, संयुक्त आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पाथ्स के माध्यम से आकार की ज्यामिति को संपादित कर अनुकूलित करने का तरीका बताता है। यह दर्शाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) के साथ काम करके मौजूदा आकारों को संशोधित किया जाए, बुनियादी पाथ संपादन कार्य किए जाएँ, बिंदुओं को जोड़ा या हटाया जाए, और अद्यतन ज्यामिति को फिर से आकार पर लागू किया जाए।  
यह यह भी दर्शाता है कि कैसे कस्टम और कंपोज़िट आकार बनाएँ, वक्र कोनों वाले आकार बनाएँ, यह निर्धारित करें कि आकार की ज्यामिति बंद है या नहीं, और अतिरिक्त ज्यामिति अनुकूलन परिदृश्यों के लिए [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) के बीच पुरानी रूपांतरण का उपयोग करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में आप **Edit Points** का उपयोग करके वर्ग को संशोधित कर सकते हैं:

* एक कोना अंदर या बाहर की ओर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की रूपरेखा को बदल सकते हैं या किसी मौजूदा आकार को नए आकार के आधार के रूप में उपयोग कर सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* एक आकार (या इसका पाथ) बंद या खुला हो सकता है।  
* आकार का पाथ एंकर बिंदुओं से जुड़े खंडों से बना होता है।  
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।  
* एंकर बिंदु कोने वाले बिंदु, सीधे बिंदु या स्मूथ बिंदु के रूप में मौजूद होते हैं:
  * कोने वाले बिंदु पर, जुड़ने वाले खंड एक कोण पर मिल सकते हैं।  
  * स्मूथ बिंदु पर, दोनों नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।  
  * सीधे बिंदु पर, दोनों नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।  
* एंकर बिंदुओं को ले जाना या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) उदाहरण [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) वस्तु का ज्यामिति पाथ दर्शाता है।  
* [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) उदाहरण से [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) मेथड का उपयोग कर सकते हैं।  
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) सेट करने हेतु आप ये मेथड उपयोग कर सकते हैं: एकल पाथ वाले आकार के लिए [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) और बहु‑पाथ वाले आकार के लिए [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)।  
* खंड जोड़ने के लिए आप [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) के तहत उपलब्ध मेथड्स का उपयोग कर सकते हैं।  
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) और [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) प्रॉपर्टीज़ का उपयोग करके आप ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।  
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) प्रॉपर्टी से आप किसी [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खंडों की एरे के रूप में प्राप्त कर सकते हैं।  
* नीचे दिए गए रूपांतरण मेथड्स को समर्थन देने वाले पुरानी संस्करणों में आप [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) को [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) में बदल सकते हैं।  
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) और [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) मेथड्स (जो [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) क्लास से आती हैं) का उपयोग करके आप [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) और [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) के बीच रूपांतरण कर सकते हैं।

## **सरल संपादन संचालन**

ज्यामिति पाथ को संपादित करने के लिए नीचे दिए गए मेथड्स का उपयोग करें। जो ओवरलोड इंडेक्स स्वीकार करते हैं, वे पाथ की खंड एरे में उस शून्य‑आधारित स्थिति पर खंड सम्मिलित करते हैं।

| ऑपरेशन | विधि |
| --- | --- |
| एक सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु वाला क्यूबिक Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| एक नियंत्रण बिंदु और एक अंत बिंदु वाला द्विघात Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| निर्दिष्ट आयाम और डिग्री में कोणों के साथ एक दीर्घवृत्तीय चाप जोड़ें। | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारंभिक बिंदु से जोड़कर बंद करें। | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| आकृति का प्रारंभिक बिंदु निर्धारित करें। | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| शून्य‑आधारित सूचकांक पर एक खंड हटाएँ। | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) का उपयोग कर सम्मिलित करता है और संशोधित पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू करता है। निर्देशांक आकार के सापेक्ष स्थानीय होते हैं: दोनों नए बिंदु उसके केंद्र में स्थित हैं, बाएँ से १०० पॉइंट और ऊपर से ५० पॉइंट पर। खंड सूचकांक 1 और 4 उन्हें क्रमशः ऊपर और नीचे किनारों पर रखते हैं, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

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

## **आकार से बिंदु हटाएँ**

यह उदाहरण [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) का उपयोग कर शून्य‑आधारित सूचकांक 2 पर खंड हटाकर हृदय आकार की रूपरेखा बदलता है। संशोधित पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू करने से आकार की रूपरेखा अद्यतन हो जाती है।

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

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) का उपयोग कर पाँच‑बिंदु वाले सितारे का निर्माण करता है। बाहरी और आंतरिक त्रिज्याओं को क्रमशः १०० और ५० पॉइंट सेट करके टिप्स और अंदरूनी कटाव निर्धारित होते हैं; ७२‑डिग्री कदम पाँच टिप्स को समान रूप से वितरित करता है। पाथ को [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) द्वारा बंद किया जाता है और [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) के द्वारा आयताकार आकार पर लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

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

## **संयुक्त कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपर और नीचे के एक‑तीहाई भागों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) वस्तुओं को परिभाषित करता है। दोनों पाथ्स को [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करने से मध्य के एक‑तीहाई हिस्से में खाई के साथ एक एकल संयुक्त आकार बनता है।

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

## **वक्र कोनों वाला कस्टम आकार बनाएँ**

यह उदाहरण सीधे खंडों को [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) के साथ मिलाकर अंदर की ओर वक्र कोनों वाला आकार बनाता है। प्रत्येक कोना आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट्स में निर्धारित करता है, और -९०‑डिग्री स्वेप एक प्रतिक्लॉकवाइज़ क्वार्टर एलिप्स बनाता है। पूर्ण पाथ को [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) द्वारा लागू किया जाता है, और प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जाता है।

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

## **पता लगाएँ कि आकार की ज्यामिति बंद है या नहीं**

निम्नलिखित सहायक प्रत्येक गैर‑खाली ज्यामिति पाथ के समाप्ति खंड को जाँचता है कि वह बंद है या नहीं। यह [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) को पढ़ता है और अंतिम खंड के [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑खाली पाथ नहीं है तो यह false लौटाता है। यह प्रत्येक पाथ की अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑आकृति को नहीं देखता। उदाहरण में आयत के लिए `True` प्रिंट करता है।

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

## **ज्यामिति पाथ कमांड की जांच करें**

[contour.pptx](contour.pptx) डाउनलोड करें और उसे एप्लिकेशन की कार्य निर्देशिका में रखें। पहली स्लाइड में एक आकार है जिसमें ऊपर की सीधी किनारा, क्यूबिक Bézier वक्र, और नीचे की सीधी बंद किनारा है। उसकी पाथ्स को पढ़ने के लिए [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। प्रत्येक पाथ अपने खंडों को ड्रॉइंग क्रम में [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) में सूचीबद्ध करता है। प्रत्येक खंड का [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) निर्धारित करता है कि उसके [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/) को कैसे पढ़ना है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

आकार स्लाइड पर (200, 100) पॉइंट्स पर स्थित है। रिपोर्ट किए गए बिंदु आकार के स्थानीय होते हैं, जहाँ (0, 0) उसके ऊपरी‑बाएँ कोने पर होता है, X दाएँ की ओर बढ़ता है और Y नीचे की ओर। बंद खंड अतिरिक्त निर्देशांक के बिना शुरू बिंदु पर वापस लौटता है।

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![ऊपर की सीधी किनारा, ऊपर दाएँ से नीचे बाएँ तक वक्र किनारा, और बाएँ की सीधी किनारा वाला PowerPoint आकार](contour.png)

## **आकार तत्वों को निकालें और जांचें**

आप [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) का उपयोग करके मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाला तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गए [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) में कास्ट करके आप उसके [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) और [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) एरे पढ़ सकते हैं। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने में उपयोगी है।

उदाहरण एक प्रस्तुति खोलता है, पहले स्लाइड पर सीधे पहले ज्यामिति आकार को खोजता है, और उसके पाथ खंडों को प्रिंट करता है। ऐसी प्रस्तुति जिसका आकार सीधे तथा वक्र दोनों प्रकार के खंडों को सम्मिलित करता हो, उपयोग करें। यह समूहों के भीतर खोज नहीं करता।

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
        var pointType = types[i] & 0x07; // सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखें।
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
                i += 2; // दोनों नियंत्रण बिंदुओं और अंत बिंदु को उपयोग करें।
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

एरे समानांक द्वारा संबंधित होते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` आकृति की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक एक सीधी रेखा बनाता है। क्यूबिक Bézier खंड पिछले अंत बिंदु से शुरू होता है और क्रमशः दो नियंत्रण बिंदु तथा नया अंत बिंदु दर्शाने वाले तीन क्रमिक प्रकार‑`3` प्रविष्टियों का उपयोग करता है। लूप इन तीन प्रविष्टियों को एक साथ उपयोग करता है और बंद होने के लिए अंत बिंदु की जाँच करता है।

बिंदु प्रकारों में फ्लैग भी होते हैं। खंड प्रकार पहचानने के लिए `0x07` के साथ मास्क करें, और बंद उप‑पाथ का पता लगाने के लिए `0x80` को अलग से जाँचें। उदाहरण के लिये, `129` (`0x81`) का अर्थ है वह रेखा अंत बिंदु जो उप‑पाथ को बंद करता है, और `131` (`0x83`) का अर्थ है Bézier अंत बिंदु जो उप‑पाथ को बंद करता है। केवल `1` या `3` से तुलना करने पर ये मामलों को मिस किया जा सकता है। अन्य फ्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु 1/72 इंच में मापे जाते हैं, X दाएँ की ओर और Y नीचे की ओर बढ़ता है। एक अन‑ग्रुप्ड आकार के लिये निकाले गये निर्देशांक पहले से ही उसके [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) और [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) स्थिति को सम्मिलित करते हैं और उसकी वर्तमान चौड़ाई‑ऊँचाई को दर्शाते हैं। उदाहरण के लिये, बिना घुमाए हुए आयत `(100, 200)` पर आकार `120 × 80` के साथ कंटूर बाउंड्स `(100, 200)`‑`(220, 280)` होते हैं। आकार की स्थिति को दोबारा नहीं जोड़ें। उसके X और Y को घटाकर स्थानीय निर्देशांक प्राप्त करें।

निकाले गये बिंदु आकार की [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) या क्षैतिज व लंबवत फ़्लिप लागू नहीं करते। प्रदर्शित कंटूर को पुनः बनाना हो तो इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। ग्रुप्ड आकारों के लिए समूह निर्देशांक मैपिंग और रूपांतरण को भी ध्यान में रखें; यह न मानें कि निकाले गये बिंदु अंतिम स्लाइड रेंडरिंग निर्देशांक हैं या एक ही फ्रेम में अनजाने में दो बार अनुवाद या स्केल लागू हो गया है।

**निरीक्षण बनाम संपादन।** निकाले गये एरे केवल कंटूर का वर्णन करते हैं; उन्हें बदलना मूल आकार को अपडेट नहीं करता। जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार एरे की आवश्यकता रखता है तब इस विधि का उपयोग करें। आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड की आवश्यकता या संपादन हेतु [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) का उपयोग करें। संशोधित पाथ को [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) या [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) के द्वारा लागू करें।

## **GeometryPath को GraphicsPath (System.Drawing.Drawing2D) में बदलें**

निम्न उदाहरण के लिये एक पुरानी Aspose.Slides for .NET असेंबली आवश्यक है जो [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) को समर्थन देती हो, उदाहरण के लिये संस्करण 25.10, और Windows परिवेश जिसमें `System.Drawing.Common` उपलब्ध हो। रूपांतरण मेथड्स को [संस्करण 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) में हटा दिया गया है।

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ जोड़ता है जिसे ज्यामिति में बदला गया है। रूपरेखा का [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) भराव को निष्क्रिय करने के लिये सेट किया गया है। [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) टेक्स्ट रूपरेखा को संग्रहीत करता है, जिसे [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) द्वारा भरी हुई ज्यामिति पाथ में बदला जाता है। दोनों पाथ्स को [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) द्वारा लागू करने से आयत और टेक्स्ट दोनों को सम्मिलित करने वाला एकल आकार बनता है। विपरीत दिशा में रूपांतरण के लिये, [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) का उपयोग करें।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति को बदलने के बाद भराव और रूपरेखा के साथ क्या होगा?**

शैली आकार के साथ रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वतः नई ज्यामिति पर लागू हो जाती हैं।

**मैं कस्टम आकार को उसके ज्यामिति के साथ सही तरीके से कैसे घुमा सकता हूँ?**

आकार की [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) प्रॉपर्टी का उपयोग करें; ज्यामिति आकार के साथ घुमती है क्योंकि वह आकार की अपनी स्थानीय निर्देशांक प्रणाली से बँधी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदल सकता हूँ ताकि परिणाम “लॉक” हो जाए?**

हाँ। आवश्यक [slide](/slides/hi/net/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/net/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के कार्य को सरल बनाता है।