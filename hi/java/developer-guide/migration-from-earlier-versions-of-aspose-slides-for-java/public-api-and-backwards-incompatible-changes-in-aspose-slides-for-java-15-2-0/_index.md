---
title: Aspose.Slides for Java 15.2.0 में सार्वजनिक API और पिछले संस्करणों के साथ असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- माइग्रेशन
- पुरानी कोड
- आधुनिक कोड
- पुरानी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टुटने वाले परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सुचारु रूप से माइग्रेट करें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, किसी भी नई प्रतिबंधों और अन्य [परिवर्तनों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) को सूचीबद्ध करता है जो Aspose.Slides for Java 15.2.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} {{% alert color="info" %}} 

कुछ इमेज बुलेट्स और WordArt ऑब्जेक्ट्स से संबंधित ज्ञात समस्याएँ हैं, जिन्हें Aspose.Slides for Java 15.2.0 में ठीक किया जाएगा।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **addDataPointForDoughnutSeries मेथड्स जोड़े गए**
IChartDataPointCollection.addDataPointForDoughnutSeries() मेथड के दो ओवरलोड जोड़ें गए हैं ताकि डोनट प्रकार की सीरीज में डेटा पॉइंट्स जोड़े जा सकें।
### **com.aspose.slides.SmartArtShape क्लास को com.aspose.slides.GeometryShape क्लास से इनहेरिट किया गया है**
com.aspose.slides.SmartArtShape क्लास को com.aspose.slides.GeometryShape क्लास से इनहेरिट किया गया है। यह परिवर्तन Aspose.Slides ऑब्जेक्ट मॉडल को सुधारता है और SmartArtShape क्लास में नई सुविधाएँ जोड़ता है।
### **IGradientStopCollection.add(...) और IGradientStopCollection.insert(...) मेथड्स में परिवर्तन किए गए**
IGradientStop add(float position, int presetColor) का सिग्नेचर IGradientStop addPresetColor(float position, int presetColor) सिग्नेचर से प्रतिस्थापित किया गया है।

IGradientStopCollection मेथड IGradientStop add(float position, SchemeColor schemeColor) का सिग्नेचर IGradientStop addSchemeColor(float position, int schemeColor) सिग्नेचर से प्रतिस्थापित किया गया है।

IGradientStopCollection मेथड void insert(int index, float position, int presetColor) का सिग्नेचर void insertPresetColor(int index, float position, int presetColor) सिग्नेचर से प्रतिस्थापित किया गया है।

IGradientStopCollection मेथड void insert(int index, float position, SchemeColor schemeColor) का सिग्नेचर void insertSchemeColor(int index, float position, int schemeColor) सिग्नेचर से प्रतिस्थापित किया गया है।
### **com.aspose.slides.IChartSeries में java.awt.Color getAutomaticSeriesColor() मेथड जोड़ा गया है**
getAutomaticSeriesColor() मेथड सीरीज़ इंडेक्स और चार्ट स्टाइल के आधार पर सीरीज़ का स्वचालित रंग लौटाता है। यदि FillType NotDefined के बराबर है तो यह रंग डिफ़ॉल्ट रूप से उपयोग किया जाता है।
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **चार्ट डेटा पॉइंट और चार्ट कैटेगरी को उसके इंडेक्स द्वारा हटाने के लिए मेथड जोड़ा गया है**
IChartDataPointCollection.removeAt(int index) मेथड को उसके इंडेक्स द्वारा चार्ट डेटा पॉइंट हटाने के लिए जोड़ा गया है।
IChartCategoryCollection.removeAt(int index) मेथड को उसके इंडेक्स द्वारा चार्ट कैटेगरी हटाने के लिए जोड़ा गया है।
### **com.aspose.slides.PropertyType एनीमरेशन में PptXPptY मान जोड़ा गया है**
PptXPptY मान को com.aspose.slides.PropertyType एनीमरेशन में एक सीरियलाइज़ेशन समस्या के समाधान के दायरे में जोड़ा गया है।