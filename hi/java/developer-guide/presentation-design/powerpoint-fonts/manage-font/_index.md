---
title: Java का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करना
- फ़ॉन्ट गुण
- पैराग्राफ
- टेक्स्ट फॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में फ़ॉन्ट को नियंत्रित करें: कस्टम फ़ॉन्ट एम्बेड, प्रतिस्थापित और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियां स्पष्ट, ब्रांड‑सुरक्षित और सुसंगत रहें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुति पाठ में फ़ॉन्ट गुणों को सीधे कोड से प्रबंधित करने की सुविधा देता है। आप स्लाइडों में शकलों, टेक्स्ट फ़्रेम, पैराग्राफ और पोर्शन के माध्यम से पाठ तक पहुँच सकते हैं और चयनित पाठ पर फॉर्मेटिंग लागू कर सकते हैं।

यह लेख प्रस्तुति में मौजूदा पाठ के फ़ॉन्ट‑संबंधी गुणों को कॉन्फ़िगर करने का विवरण देता है, जिसमें फ़ॉन्ट परिवार, बोल्ड और इटैलिक शैली, पैराग्राफ संरेखण और फ़ॉन्ट रंग शामिल हैं। यह दिखाता है कि कैसे एक टेक्स्ट बॉक्स बनाकर उसमें पाठ जोड़ें और फ़ॉन्ट परिवार, बोल्ड, इटैलिक, अंडरलाइन, फ़ॉन्ट आकार और रंग जैसी फ़ॉन्ट गुण सेट करके परिणाम को PPTX फ़ाइल के रूप में सहेजा जाए।

## **फ़ॉन्ट संबंधित गुणों का प्रबंधन**
{{% alert color="info" %}} 

प्रस्तुतियों में अक्सर टेक्स्ट और छवियाँ दोनों होते हैं। टेक्स्ट को विभिन्न तरीकों से फॉर्मेट किया जा सकता है, चाहे वह विशिष्ट अनुभागों और शब्दों को उजागर करने के लिए हो या कॉर्पोरेट शैली के अनुरूप हो। टेक्स्ट फॉर्मेटिंग उपयोगकर्ताओं को प्रस्तुति सामग्री की दिखावट को बदलने में मदद करती है। यह लेख Aspose.Slides for Java का उपयोग करके स्लाइडों पर पैराग्राफ टेक्स्ट के फ़ॉन्ट गुणों को कॉन्फ़िगर करने का तरीका दर्शाता है।

{{% /alert %}} 

Aspose.Slides for Java का उपयोग करके पैराग्राफ के फ़ॉन्ट गुणों को प्रबंधित करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
1. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में मौजूद [Placeholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) शकलों तक पहुंचें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) में टाइप‑कास्ट करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) द्वारा प्रदान किए गए [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) प्राप्त करें।
1. पैराग्राफ को जस्टिफाई (समरूप) करें।
1. एक [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) के टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) तक पहुंचें।
1. [FontData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट निर्धारित करें और टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) का **Font** उसी अनुसार सेट करें।
   1. फ़ॉन्ट को बोल्ड करें।
   1. फ़ॉन्ट को इटैलिक करें।
1. [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रदान किए गए [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) से फ़ॉन्ट रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रस्तुति लेता है और किसी एक स्लाइड पर फ़ॉन्ट को फ़ॉर्मेट करता है। आगे के स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट्स द्वारा किए गए परिवर्तन को दर्शाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट शैली को बदलता है।

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में टेक्स्ट**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: समान टेक्स्ट के साथ अपडेटेड फॉर्मेटिंग**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक Presentation ऑब्जेक्ट बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// स्लाइड को उसके स्थान का उपयोग करके पहुँच रहा है
	ISlide slide = pres.getSlides().get_Item(0);

	// स्लाइड में पहले और दूसरे प्लेसहोल्डर को पहुँच रहा है और उसे AutoShape के रूप में टाइपकास्ट कर रहा है
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// पहले पैराग्राफ को पहुँच रहा है
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// पैराग्राफ को जस्टिफाई (समान) करें
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// पहले पोर्शन को पहुँच रहा है
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// नए फ़ॉन्ट निर्धारित करें
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// नए फ़ॉन्ट को पोर्शन को असाइन करें
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// फ़ॉन्ट को बोल्ड सेट करें
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// फ़ॉन्ट को इटैलिक सेट करें
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// फ़ॉन्ट रंग सेट करें
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX को डिस्क पर सहेजें
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **टेक्स्ट फ़ॉन्ट गुण सेट करना**
{{% alert color="info" %}} 

**फ़ॉन्ट संबंधित गुणों का प्रबंधन** में उल्लेखित अनुसार, एक [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) का प्रयोग पैराग्राफ में समान फ़ॉर्मेटिंग शैली वाले टेक्स्ट को रखने के लिए किया जाता है। यह लेख Aspose.Slides for Java का उपयोग करके एक टेक्स्टबॉक्स बनाने, उसमें कुछ टेक्स्ट डालने और फिर फ़ॉन्ट परिवार श्रेणी के विभिन्न गुण निर्धारित करने का तरीका दिखाता है।

{{% /alert %}} 

एक टेक्स्टबॉक्स बनाकर उसमें टेक्स्ट के फ़ॉन्ट गुण सेट करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
1. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड पर प्रकार **Rectangle** का एक [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जोड़ें।
1. उस [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) से जुड़ी फ़िल स्टाइल को हटाएं।
1. [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) तक पहुंचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
1. उस [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) से जुड़ा [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट प्राप्त करें।
1. उस [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) के लिए उपयोग किया जाने वाला फ़ॉन्ट निर्धारित करें।
1. [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा एक्सपोज़्ड संबंधित प्रॉपर्टीज़ का उपयोग करके अन्य फ़ॉन्ट गुण जैसे बोल्ड, इटैलिक, अंडरलाइन, रंग और ऊँचाई सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है।

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for Java द्वारा सेट किए गए कुछ फ़ॉन्ट गुणों वाला टेक्स्ट**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
	// पहली स्लाइड प्राप्त करें
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle प्रकार का AutoShape जोड़ें
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape से जुड़ी किसी भी फ़िल स्टाइल को हटाएँ
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape से जुड़ी TextFrame तक पहुँचें
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame से जुड़ी Portion तक पहुँचें
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion के लिए फ़ॉन्ट सेट करें
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// फ़ॉन्ट की Bold प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// फ़ॉन्ट की Italic प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// फ़ॉन्ट की Underline प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// फ़ॉन्ट की Height सेट करें
	port.getPortionFormat().setFontHeight(25);
	
	// फ़ॉन्ट का रंग सेट करें
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// प्रेजेंटेशन को डिस्क पर सहेजें
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```