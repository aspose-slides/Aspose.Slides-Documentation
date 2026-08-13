---
title: Aspose.Slides for Java 15.4.0 में सार्वजनिक API और पिछड़े अनुकूलता न रखने वाले बदलाव
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- परिवर्तन
- पुराना कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) क्लास, मेथड, प्रॉपर्टी आदि, किसी भी नए प्रतिबंध और अन्य [बदलाव](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) को Aspose.Slides for Java 15.4.0 API के साथ प्रस्तुत करता है।

{{% /alert %}} 
## **Public API Changes**
### **Enum OrganizationChartLayoutType has been added**
The com.aspose.slides.OrganizationChartLayoutType enum एक संगठन चार्ट में चाइल्ड नोड्स के फ़ॉर्मेटिंग प्रकार का प्रतिनिधित्व करता है।
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() has been added**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts bullets सक्षम होने पर प्रभावी पैराग्राफ Indent और MarginLeft के लिए डिफ़ॉल्ट गैर‑शून्य शिफ्ट सेट करता है (जैसा PowerPoint पैराग्राफ बुलेट/नंबरिंग सक्षम करने पर करता है)। यदि bullets निष्क्रिय है तो केवल पैराग्राफ Indent और MarginLeft रीसेट करता है (जैसा PowerPoint निष्क्रिय करने पर करता है)।
### **Method IConnector.reroute() has been added**
Method com.aspose.slides.IConnector.reroute() कनेक्टर को पुनः रूट करता है ताकि वह जुड़े हुए शैलियों के बीच सबसे छोटा संभव मार्ग ले। इस हेतु reroute() मेथड StartShapeConnectionSiteIndex और EndShapeConnectionSiteIndex को बदल सकता है।

``` java
import com.aspose.slides.*;


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
Method Aspose.Slides.IPresentation.getSlideById(long) स्लाइड Id द्वारा Slide, MasterSlide या LayoutSlide लौटाता है।

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() has been added**
Method com.aspose.slides.ISmartArt.getNodes() SmartArt ऑब्जेक्ट में रूट नोड्स का संग्रह लौटाता है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // दूसरा रूट नोड चुनें

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) has been added**
Method for property com.aspose.slides.ISmartArt.setLayout(int) जोड़ा गया है। यह मौजूदा डायग्राम का लेआउट प्रकार बदलने की अनुमति देता है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() has been added**
Method com.aspose.slides.ISmartArtNode.isHidden() true लौटाता है यदि यह नोड डेटा मॉडल में छिपा हुआ नोड है।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // true लौटाता है

if(hidden) {

    // कुछ कार्य या सूचनाएँ करें

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() have been added**
Property com.aspose.slides.ISmartArt.IsReversed SmartArt डायग्राम की दिशा (बाएँ‑से‑दाएँ LTR या दाएँ‑से‑बाएँ RTL) को प्राप्त या सेट करने की अनुमति देती है, यदि डायग्राम रिवर्सल का समर्थन करता है।

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) वर्तमान नोड से जुड़ा संगठन चार्ट प्रकार प्राप्त या सेट करने की अनुमति देते हैं।

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() has been added**
Property com.aspose.slides.getConnectionSiteCount() शैल में कनेक्शन साइट्स की संख्या लौटाता है।

``` java
import com.aspose.slides.*;


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
यह न्यूनतम API बदलावों की सूची है:

|Enum com.aspose.slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |deleted, unused property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |added |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |deleted as obsolete |