---
title: ".NET में प्रस्तुति आकृतियों को अनुकूलित करें"
linktitle: "कस्टम आकृति"
type: docs
weight: 20
url: /hi/net/custom-shape/
keywords:
- "कस्टम आकृति"
- "आकृति जोड़ें"
- "आकृति बनाएं"
- "आकृति बदलें"
- "आकृति ज्यामिति"
- "ज्यामिति पथ"
- "पथ बिंदु"
- "संपादन बिंदु"
- "बिंदु जोड़ें"
- "बिंदु हटाएं"
- "संपादन संचालन"
- "घुमावदार कोना"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुति में आकृतियों को बनाएं और अनुकूलित करें: ज्यामिति पथ, घुमावदार कोने, समग्र आकृतियां."
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकृतियों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकृति ज्यामिति को संपादित करके अनुकूलित करने के तरीके को समझाता है। यह दिखाता है कि `GeometryPath` और `IGeometryPath` के साथ काम करके मौजूदा आकृतियों को संशोधित कैसे करें, बेसिक पथ संपादन संचालन करें, बिंदु जोड़ें या हटाएँ, और अपडेटेड ज्यामिति को फिर से आकृति पर लागू करें।

यह यह भी दर्शाता है कि कैसे कस्टम और समग्र (कॉम्पोज़िट) आकृतियां बनाई जाएँ, घुमावदार कोनों वाली आकृतियां निर्मित की जाएँ, यह निर्धारित किया जाए कि क्या आकृति की ज्यामिति बंद (क्लोज़) है, और अतिरिक्त ज्यामिति अनुकूलन परिदृश्यों के लिए `GeometryPath` और `GraphicsPath` के बीच रूपांतरण कैसे किया जाए।

## **संपादन बिंदुओं का उपयोग करके आकृति बदलें**

एक वर्ग (square) पर विचार करें। PowerPoint में, **संपादन बिंदुओं** (edit points) का उपयोग करके आप  

* वर्ग के कोने को अंदर या बाहर ले जा सकते हैं  
* कोने या बिंदु के लिए घुमाव को निर्दिष्ट कर सकते हैं  
* वर्ग में नए बिंदु जोड़ सकते हैं  
* वर्ग के बिंदुओं को हेर-फेर कर सकते हैं, आदि  

मूल रूप से, आप वर्णित कार्यों को किसी भी आकृति पर कर सकते हैं। संपादन बिंदुओं का उपयोग करके आप एक आकृति को बदल सकते हैं या मौजूदा आकृति से नई आकृति बना सकते हैं।  

## **आकृति संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकृतियों को संपादन बिंदुओं के माध्यम से संपादित करने से पहले, आपको इन बिंदुओं पर विचार करना चाहिए:

* एक आकृति (या इसका पथ) बंद या खुला दोनों हो सकता है।  
* सभी आकृतियों में कम से कम 2 एंकर पॉइंट होते हैं जो रेखाओं द्वारा जुड़ी होती हैं।  
* एक रेखा या तो सीधी या घुमावदार हो सकती है। एंकर पॉइंट रेखा की प्रकृति निर्धारित करते हैं।  
* एंकर पॉइंट कोने के बिंदु, सीधी बिंदु, या स्मूद बिंदु के रूप में मौजूद होते हैं:  
  * एक कोने का बिंदु वह बिंदु है जहाँ दो सीधी रेखाएँ कोण पर जुड़ती हैं।  
  * एक स्मूद बिंदु वह बिंदु है जहाँ दो हैंडल सीधी रेखा में होते हैं और रेखा के खंड एक स्मूद वक्र में जुड़ते हैं। इस स्थिति में, सभी हैंडल एंकर पॉइंट से समान दूरी पर होते हैं।  
  * एक सीधा बिंदु वह बिंदु है जहाँ दो हैंडल सीधी रेखा में होते हैं और उस रेखा के खंड स्मूद कर्व में जुड़ते हैं। इस स्थिति में, हैंडल को एंकर पॉइंट से समान दूरी पर रहने की आवश्यकता नहीं है।  
* एंकर पॉइंट को ले जाकर या संपादित करके (जिससे रेखाओं का कोण बदलता है), आप आकृति की दिखावट बदल सकते हैं।  

PowerPoint आकृतियों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [**GeometryPath**](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास और [**IGeometryPath**](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometrypath) इंटरफ़ेस प्रदान करता है।  

* एक [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) उदाहरण [IGeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape) ऑब्जेक्ट का जियोमेट्री पथ दर्शाता है।  
* `IGeometryShape` उदाहरण से `GeometryPath` प्राप्त करने के लिए आप [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/methods/getgeometrypaths) मेथड का उपयोग कर सकते हैं।  
* आकृति के लिए `GeometryPath` सेट करने हेतु आप इन मेथड्स का उपयोग कर सकते हैं: सॉलिड आकृतियों के लिए [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/methods/setgeometrypath) और कॉम्पोज़िट आकृतियों के लिए [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/methods/setgeometrypaths)।  
* सेगमेंट जोड़ने के लिए आप [IGeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometrypath) के तहत मेथड्स का उपयोग कर सकते हैं।  
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometrypath/properties/stroke) और [IGeometryPath.FillMode](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometrypath/properties/fillmode) प्रॉपर्टीज़ का उपयोग करके आप जियोमेट्री पथ की उपस्थिति सेट कर सकते हैं।  
* [IGeometryPath.PathData](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometrypath/properties/pathdata) प्रॉपर्टी का उपयोग करके आप `GeometryShape` का जियोमेट्री पथ पथ सेगमेंट के एरे के रूप में प्राप्त कर सकते हैं।  
* अतिरिक्त आकृति जियोमेट्री कस्टमाइज़ेशन विकल्पों तक पहुँचने के लिये आप [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) को [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) में रूपांतरित कर सकते हैं।  
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/hi/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) और [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) मेथड्स (जो [ShapeUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/shapeutil) क्लास से हैं) का उपयोग करके आप [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) को [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) में और वापस रूपांतरण कर सकते हैं।  

## **सरल संपादन संचालन**

यह C# कोड दिखाता है कि कैसे  

**एक रेखा जोड़ें** पथ के अंत में  
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```  

**एक रेखा जोड़ें** पथ पर निर्दिष्ट स्थिति में:  
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```  

**एक क्यूबिक Bezier वक्र जोड़ें** पथ के अंत में:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```  

**एक क्यूबिक Bezier वक्र जोड़ें** पथ पर निर्दिष्ट स्थिति में:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```  

**एक क्वाड्रेटिक Bezier वक्र जोड़ें** पथ के अंत में:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```  

**एक क्वाड्रेटिक Bezier वक्र जोड़ें** पथ पर निर्दिष्ट स्थिति में:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```  

**एक दिया गया आर्क जोड़ें** पथ में:  
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```  

**पथ की वर्तमान आकृति को बंद करें**:  
``` csharp
void CloseFigure();
```  

**अगले बिंदु के लिए स्थिति सेट करें**:  
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```  

**दिए गए इंडेक्स पर पथ सेगमेंट हटाएँ**:  
``` csharp
void RemoveAt(int index);
```  

## **आकृति में कस्टम बिंदु जोड़ें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/geometryshape) क्लास का एक इंस्टेंस बनाएं और [ShapeType.Rectangle](https://reference.aspose.com/slides/hi/net/aspose.slides/shapetype) प्रकार सेट करें।  
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास का एक इंस्टेंस प्राप्त करें।  
3. पथ में दो शीर्ष बिंदुओं के बीच एक नया बिंदु जोड़ें।  
4. पथ में दो निचले बिंदुओं के बीच एक नया बिंदु जोड़ें।  
5. पथ को आकृति पर लागू करें।  

यह C# कोड दिखाता है कि कैसे कस्टम बिंदु आकृति में जोड़ें:  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **आकृति से बिंदु हटाएँ**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/geometryshape) क्लास का एक इंस्टेंस बनाएं और [ShapeType.Heart](https://reference.aspose.com/slides/hi/net/aspose.slides/shapetype) प्रकार सेट करें।  
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास का एक इंस्टेंस प्राप्त करें।  
3. पथ का सेगमेंट हटाएँ।  
4. पथ को आकृति पर लागू करें।  

यह C# कोड दिखाता है कि कैसे बिंदु आकृति से हटाएँ:  
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```

![example2_image](custom_shape_2.png)

##  **एक कस्टम आकृति बनाएं**

1. आकृति के बिंदुओं की गणना करें।  
2. एक [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास का एक इंस्टेंस बनाएं।  
3. बिंदुओं के साथ पथ को भरें।  
4. एक [GeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/geometryshape) क्लास का एक इंस्टेंस बनाएं।  
5. पथ को आकृति पर लागू करें।  

यह C# दिखाता है कि कैसे कस्टम आकृति बनाएँ:  
``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```

![example3_image](custom_shape_3.png)

## **समग्र कस्टम आकृति बनाएं**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/geometryshape) क्लास का एक इंस्टेंस बनाएं।  
2. एक पहला [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास का इंस्टेंस बनाएं।  
3. एक दूसरा [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) क्लास का इंस्टेंस बनाएं।  
4. पथों को आकृति पर लागू करें।  

यह C# कोड दिखाता है कि कैसे समग्र कस्टम आकृति बनाएँ:  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```

![example4_image](custom_shape_4.png)

## **घुमावदार कोनों वाली कस्टम आकृति बनाएं**

यह C# कोड दिखाता है कि कैसे घुमावदार कोनों (भीतर की ओर) वाली कस्टम आकृति बनाएँ;  
```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **जाँचें कि क्या आकृति की ज्यामिति बंद है**

एक बंद आकृति वह होती है जहाँ सभी पक्ष मिलते हैं और बिना गैप के एक एकल सीमा बनाते हैं। ऐसी आकृति सरल ज्यामितीय रूप या जटिल कस्टम रूपरेखा हो सकती है। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे जाँचें कि आकृति की ज्यामिति बंद है या नहीं:  
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **GeometryPath को GraphicsPath (System.Drawing.Drawing2D) में बदलें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/net/aspose.slides/geometryshape) क्लास का एक इंस्टेंस बनाएं।  
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) नेमस्पेस की [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) क्लास का एक इंस्टेंस बनाएं।  
3. [ShapeUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/shapeutil) का उपयोग करके [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) इंस्टेंस को [GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath) इंस्टेंस में रूपांतरित करें।  
4. पथों को आकृति पर लागू करें।  

यह C# कोड—ऊपर बताए गए चरणों का कार्यान्वयन—**GeometryPath** से **GraphicsPath** रूपांतरण प्रक्रिया को दर्शाता है:  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**जियोमेट्री बदलने के बाद फ़िल और आउटलाइन के साथ क्या होगा?**  
स्टाइल आकृति के साथ रहता है; केवल कंटूर बदलता है। फ़िल और आउटलाइन स्वचालित रूप से नई जियोमेट्री पर लागू हो जाते हैं।

**मैं कस्टम आकृति को उसकी जियोमेट्री के साथ सही तरीके से कैसे घुमाऊँ?**  
आकृति की [rotation](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/rotation/) प्रॉपर्टी का उपयोग करें; जियोमेट्री आकृति के अपने कोऑर्डिनेट सिस्टम से बंधी होने के कारण आकृति के साथ घूमती है।

**क्या मैं कस्टम आकृति को एक इमेज में बदल कर परिणाम “लॉक” कर सकता हूँ?**  
हाँ। आवश्यक [slide](/slides/hi/net/convert-powerpoint-to-png/) क्षेत्र या [shape](/slides/hi/net/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में एक्सपोर्ट करें; यह भारी जियोमेट्री के साथ आगे के काम को सरल बनाता है।