---
title: Aspose.Slides for Java 14.6.0 में सार्वजनिक API और अनुकूल नहीं होने वाले परिवर्तन
linktitle: Aspose.Slides for Java 14.6.0
type: docs
weight: 50
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- स्थलांतर
- पुराना कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टूटने वाले बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुतीकरण समाधान को सहजता से स्थानांतरित कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ Aspose.Slides for Java 14.6.0 API के साथ प्रस्तुत किए गए सभी [जोड़ें](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) क्लास, मेथड, प्रॉपर्टी आदि, किसी भी नई प्रतिबंधों और अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **जोड़े गए क्लास, मेथड, इंटरफ़ेस और एनीमरेशन**
#### **जोड़ा गया ViewType एनीमरेशन, IViewProperties इंटरफ़ेस, ViewProperties क्लास और IPresentation.getViewProperties() मेथड**
IPresentation.getViewProperty() मेथड IViewProperties तक पहुंच प्रदान करता है और आपको Microsoft PowerPoint में प्रस्तुति खोलते समय प्रस्तुति दृश्य प्रकार और नोट्स की दृश्यता बदलने की अनुमति देता है।

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **जोड़े गए Aspose.Slides.IShapeCollection.addClone(...) और .insertClone(...) मेथड**
इनमेथड्स

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), और
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

निर्दिष्ट आकार की एक प्रतिलिपि को संग्रह में जोड़ते/सम्मिलित करते हैं। 

``` java

 Presentation srcPres = new Presentation("data/Source Frame.pptx");

IShapeCollection sourceShapes = srcPres.getSlides().get_Item(0).getShapes();

ILayoutSlide blankLayout = srcPres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);

ISlide destSlide = srcPres.getSlides().addEmptySlide(blankLayout);

IShapeCollection destShapes = destSlide.getShapes();

destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());

destShapes.addClone(sourceShapes.get_Item(2));

destShapes.addClone(sourceShapes.get_Item(3), 50, 200, 50, 50);

destShapes.addClone(sourceShapes.get_Item(4));

destShapes.addClone(sourceShapes.get_Item(5), 300, 300, 50, 200);

destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

```
#### **जोड़ा गया Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues इंटरफ़ेस**
यह इंटरफ़ेस ChartDataPoint.ErrorBarsCustomValues प्रॉपर्टी सूची में मानों के प्रकार को निर्दिष्ट करता है।

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **जोड़ा गया Aspose.Slides.Charts.IErrorBarsCustomValues इंटरफ़ेस**
जब IErrorBarsFormat.ValueType प्रॉपर्टी Custom के बराबर हो, तो मान निर्दिष्ट करने के लिए श्रृंखला के DataPoints संग्रह में विशिष्ट डेटा पॉइंट की ErrorBarCustomValues प्रॉपर्टी का उपयोग करें।

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **जोड़ा गया Aspose.Slides.Charts.IErrorBarsFormat इंटरफ़ेस**
यह इंटरफ़ेस चार्ट श्रृंखला के एरर बार को दर्शाता है।
कस्टम वैल्यू टाइप के मामले में, मान निर्दिष्ट करने के लिए श्रृंखला के DataPoins संग्रह में विशिष्ट डेटा पॉइंट की ErrorBarCustomValues प्रॉपर्टी का उपयोग करें।

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();

IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Fixed);

errBarX.setValue(0.1f);

errBarY.setValueType(ErrorBarValueType.Percentage);

errBarY.setValue(5);

errBarX.setType(ErrorBarType.Plus);

errBarY.getFormat().getLine().setWidth(2);

errBarX.setEndCap(true);

pres.save("data/ErrorBars.pptx", SaveFormat.Pptx);

```