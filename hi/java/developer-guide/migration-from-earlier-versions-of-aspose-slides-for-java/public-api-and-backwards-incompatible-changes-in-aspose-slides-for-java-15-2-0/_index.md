---
title: Aspose.Slides for Java 15.2.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- स्थानांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टुटने वाले परिवर्तनों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से स्थानांतरित कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) कक्षाओं, मेथड्स, प्रॉपर्टीज़ आदि, सभी नए प्रतिबंधों और अन्य [परिवर्तनों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) को सूचीबद्ध करता है, जो Aspose.Slides for Java 15.2.0 API के साथ पेश किए गए हैं। 

{{% /alert %}} {{% alert color="primary" %}} 

कुछ इमेज बुल्लेट्स और WordArt ऑब्जेक्ट्स में ज्ञात समस्याएँ हैं, जिन्हें Aspose.Slides for Java 15.2.0 में सुधारा जाएगा। 

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **addDataPointForDoughnutSeries मेथड्स जोड़े गए हैं**
The two overloads of IChartDataPointCollection.addDataPointForDoughnutSeries() method have been added for adding data points into series of Doughnut type.
### **com.aspose.slides.SmartArtShape क्लास को com.aspose.slides.GeometryShape क्लास से विरासत में मिला है**
com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class. This change improves Aspose.Slides object model and adds new features to SmartArtShape class.
### **IGradientStopCollection.add(...) और IGradientStopCollection.insert(...) मेथड्स में परिवर्तन किया गया है**
The signature of IGradientStop add(float position, int presetColor) is replaced with IGradientStop addPresetColor(float position, int presetColor) signature.

The signature of IGradientStopCollection method IGradientStop add(float position, SchemeColor schemeColor) is replaced with IGradientStop addSchemeColor(float position, int schemeColor) signature.

The signature of the IGradientStopCollection method void insert(int index, float position, int presetColor) is replaced with void insertPresetColor(int index, float position, int presetColor) signature.

The signature of the IGradientStopCollection method void insert(int index, float position, SchemeColor schemeColor) is replaced with void insertSchemeColor(int index, float position, int schemeColor) signature.
### **java.awt.Color getAutomaticSeriesColor() मेथड को com.aspose.slides.IChartSeries में जोड़ा गया है**
getAutomaticSeriesColor() method returns an automatic color of series based on series index and chart style. This color is used by default if FillType equals NotDefined.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **इंडेक्स द्वारा चार्ट डेटा पॉइंट और चार्ट कैटेगरी को हटाने के लिए मेथड जोड़ा गया है**
IChartDataPointCollection.removeAt(int index) method has been added for removing chart data point by its index.
IChartCategoryCollection.removeAt(int index) method has been added for removing chart category by its index.
### **PptXPptY मान को com.aspose.slides.PropertyType एनीयमरेशन में जोड़ा गया है**
PptXPptY value has been added to com.aspose.slides.PropertyType enumeration in the scope of a serialization issue fix.