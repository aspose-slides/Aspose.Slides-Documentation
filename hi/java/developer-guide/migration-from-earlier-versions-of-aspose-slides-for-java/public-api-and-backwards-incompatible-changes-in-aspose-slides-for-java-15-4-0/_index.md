---
title: Aspose.Slides for Java 15.4.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) वर्ग, विधियों, गुणों आदि, नई प्रतिबंधों और अन्य [बदलाव](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) को सूचीबद्ध करता है जो Aspose.Slides for Java 15.4.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} 
## **Public API Changes**
### **Enum OrganizationChartLayoutType has been added**
com.aspose.slides.OrganizationChartLayoutType enum एक संगठन चार्ट में बाल नोड्स के स्वरूपण प्रकार को दर्शाता है।
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() has been added**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts डिफ़ॉल्ट शून्य‑से‑भिन्न शिफ्ट सेट करता है प्रभावी पैराग्राफ इंडेंट और MarginLeft के लिए जब बुलेट सक्षम हो (जैसे PowerPoint पैराग्राफ बुलेट/नंबरिंग सक्षम करने पर करता है)। यदि बुलेट निष्क्रिय हो तो केवल पैराग्राफ इंडेंट और MarginLeft को रीसेट करता है (जैसे PowerPoint बुलेट/नंबरिंग निष्क्रिय करने पर करता है)।
### **Method IConnector.reroute() has been added**
Method com.aspose.slides.IConnector.reroute() कनेक्टर को पुनः मार्गित करता है ताकि वह जुड़े आकारों के बीच सबसे छोटा संभव मार्ग ले सके। इसके लिए reroute() मेथड StartShapeConnectionSiteIndex और EndShapeConnectionSiteIndex को बदल सकता है।

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Method IPresentation.getSlideById(long) has been added**
Method Aspose.Slides.IPresentation.getSlideById(int) स्लाइड, मास्टरस्लाइड या लेआउटस्लाइड को स्लाइड Id द्वारा लौटाता है।

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() has been added**
Method com.aspose.slides.ISmartArt.getNodes() SmartArt ऑब्जेक्ट में मूल नोड्स का संग्रह लौटाता है।

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // दूसरे मूल नोड को चुनें

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) has been added**
Method com.aspose.slides.ISmartArt.setLayout(int) को जोड़ा गया है। यह मौजूदा आरेख के लेआउट प्रकार को बदलने की अनुमति देता है।

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() has been added**
Method com.aspose.slides.ISmartArtNode.isHidden() true लौटाता है यदि यह नोड डेटा मॉडल में छुपा हुआ है।

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //true लौटाता है

if(hidden) {

    //कुछ कार्रवाई या सूचनाएँ करें

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() have been added**
Property com.aspose.slides.ISmartArt.IsReversed बाएँ‑से‑दाएँ (LTR) या दाएँ‑से‑बाएँ (RTL) दिशा में SmartArt आरेख की स्थिति को प्राप्त या सेट करने की अनुमति देता है, यदि आरेख उलटने का समर्थन करता है।

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) वर्तमान नोड से जुड़े संगठन चार्ट प्रकार को प्राप्त या सेट करने की अनुमति देते हैं।

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() has been added**
Property com.aspose.slides.getConnectionSiteCount() आकार पर कनेक्शन साइटों की संख्या लौटाता है।

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Minor Changes**
यहां छोटे API बदलावों की सूची है:

| Enum com.aspose.slides.BevelColorMode | हटाया गया, अप्रयुक्त एनम |
| :- | :- |
| Method ThreeDFormatEffectiveData.getBevelColorMode() | हटाया गया, अप्रयुक्त प्रॉपर्टी |
| Method com.aspose.slides.ChartSeriesGroup.getChart() | जोड़ा गया |
| Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent | हटाया गया |
| Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | पुराने होने के कारण हटाया गया |