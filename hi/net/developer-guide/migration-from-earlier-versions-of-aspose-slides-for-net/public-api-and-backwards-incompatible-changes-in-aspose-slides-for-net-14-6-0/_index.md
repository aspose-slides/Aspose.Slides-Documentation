---
title: Aspose.Slides for .NET 14.6.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.6.0
type: docs
weight: 80
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- स्थांतरण
- पुरानी कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और तोड़ने वाले परिवर्तनों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 
यह पृष्ठ Aspose.Slides for .NET 14.6.0 API के साथ प्रस्तुत किए गए सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) वर्ग, विधियाँ, गुण आदि, नई [प्रतिबंध](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) और अन्य [परिवर्तन](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) को सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **जोड़े गए इंटरफ़ेस, विधियाँ और गुण**
#### **Aspose.Slides.Charts.IErrorBarsFormat इंटरफ़ेस जोड़ा गया**
यह चार्ट श्रृंखला की त्रुटि बार को दर्शाता है।

कस्टम मान प्रकार के मामले में, किसी मान को निर्दिष्ट करने के लिए, श्रृंखला के DataPoints संग्रह में विशिष्ट डेटा पॉइंट की ErrorBarCustomValues प्रॉपर्टी का उपयोग करें।

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;

    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Fixed;

    errBarX.Value = 0.1f;

    errBarY.ValueType = ErrorBarValueType.Percentage;

    errBarY.Value = 5;

    errBarX.Type = ErrorBarType.Plus;

    errBarY.Format.Line.Width = 2;

    errBarX.HasEndCap = true;

    pres.Save("ErrorBars.pptx", SaveFormat.Pptx);

}

``` 
#### **Aspose.Slides.Charts.IErrorBarsCustomValues इंटरफ़ेस जोड़ा गया**
जब IErrorBarsFormat.ValueType प्रॉपर्टी Custom के बराबर हो, तो मान निर्दिष्ट करने हेतु DataPoints संग्रह में विशिष्ट डेटा पॉइंट की ErrorBarCustomValues प्रॉपर्टी का उपयोग करें।

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues इंटरफ़ेस जोड़ा गया**
ChartDataPoint.ErrorBarsCustomValues प्रॉपर्टी सूची में मानों के प्रकार को निर्दिष्ट करता है।

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }
    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);
}
``` 
#### **Aspose.Slides.IShapeCollection.AddClone(...), और .InsertClone(...) विधियों को जोड़ा गया**
निम्नलिखित विधियां निर्दिष्ट आकार की एक कॉपी को संग्रह में जोड़ती/डालती हैं। 

- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y, float width, float height)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y, float width, float height)

``` csharp

 using (Presentation srcPres = new Presentation(dataPath_ShapeCloning + "Source Frame.pptx"))
{
    IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
    ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
    ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.Shapes;
    destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
    destShapes.AddClone(sourceShapes[2]);
    destShapes.AddClone(sourceShapes[3], 50, 200, 50, 50);
    destShapes.AddClone(sourceShapes[4]);
    destShapes.AddClone(sourceShapes[5], 300, 300, 50, 200);
    destShapes.InsertClone(0, sourceShapes[0], 50, 150);
}
``` 
#### **ViewType Enum, IViewProperties इंटरफ़ेस, ViewProperties क्लास और IPresentation.ViewProperties प्रॉपर्टी को जोड़ा गया**
IPresentation.ViewProperty डेवलपर्स को PowerPoint में प्रेज़ेंटेशन खोलते समय प्रस्तुति के दृश्य प्रकार और नोट्स की दिखावट बदलने की अनुमति देता है।

``` csharp

 using(Presentation p = new Presentation())
{
    p.ViewProperties.LastView = ViewType.SlideMasterView;
}
```