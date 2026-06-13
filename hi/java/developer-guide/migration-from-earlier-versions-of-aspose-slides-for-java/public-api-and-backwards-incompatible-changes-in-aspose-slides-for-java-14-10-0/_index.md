---
title: Aspose.Slides for Java 14.10.0 में सार्वजनिक API और पिछले संस्करणों के साथ असंगत परिवर्तन
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- स्थानांतरण
- पुरानी कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ Aspose.Slides for Java 14.10.0 API के साथ पेश किए गए सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) वर्गों, विधियों, गुणों आदि, किसी भी नई प्रतिबंधों और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **com.aspose.slides.FieldType.getFooter() विधि जोड़ी गई है**
getFooter() विधि फुटर फ़ील्ड प्रकार लौटाती है। यह इस प्रकार के फ़ील्ड बनाने की संभावना के कार्यान्वयन और वैध प्रस्तुति सीरियलाइज़ेशन के लिए जोड़ी गई है।
### **Element com.aspose.slides.ShapeElementFillSource.Own हटाया गया है**
Element ShapeElementFillSource.Own दोहराव के कारण हटाया गया है। ShapeElementFillSource.Own के बजाय ShapeElementFillSource.Shape का उपयोग करें।
### **चार्ट डेटा पॉइंट्स, श्रेणियों को हटाने के लिए विधियाँ जोड़ी गई हैं**
**निम्नलिखित विधियाँ, जो चार्ट डेटा पॉइंट को चार्ट डेटा पॉइंट संग्रह से हटाने की अनुमति देती हैं, जोड़ी गई हैं:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**निम्नलिखित विधि, जो कंटेनर संग्रह से एक चार्ट श्रेणी हटाने की अनुमति देती है, जोड़ी गई है:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove() के साथ हटाएँ

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove() के साथ हटाएँ

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove() के साथ हटाएँ

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **अप्रचलित Aspose.Slides.ParagraphFormat विधियाँ हटा दी गई हैं**
getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() और उनके संबंधित set विधियों को हटा दिया गया है। इन्हें बहुत समय पहले अप्रचलित चिह्नित किया गया था।
### **अप्रयुक्त और अप्रचलित कन्स्ट्रक्टर्स हटा दिए गए हैं**
निम्नलिखित कन्स्ट्रक्टर्स को हटा दिया गया है:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)