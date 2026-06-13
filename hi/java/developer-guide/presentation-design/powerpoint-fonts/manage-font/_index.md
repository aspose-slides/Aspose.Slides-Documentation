---
title: Java का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- अनुच्छेद
- पाठ फ़ॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में फ़ॉन्ट नियंत्रित करें: कस्टम फ़ॉन्ट एंबेड करें, बदलें और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियों को स्पष्ट, ब्रांड‑सुरक्षित और सुसंगत रखा जा सके।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति के टेक्स्ट में फ़ॉन्ट गुणों को सीधे कोड से प्रबंधित करने की सुविधा देता है। आप शैलियों, टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन के माध्यम से स्लाइड के टेक्स्ट तक पहुँच सकते हैं और फिर चयनित टेक्स्ट पर फ़ॉर्मेटिंग लागू कर सकते हैं।

यह लेख यह दर्शाता है कि कैसे प्रस्तुति में मौजूदा टेक्स्ट के लिए फ़ॉन्ट‑संबंधी गुणों को कॉन्फ़िगर करें, जिसमें फ़ॉन्ट फ़ैमिली, बोल्ड और इटैलिक शैली, पैराग्राफ संरेखण और फ़ॉन्ट रंग शामिल हैं। यह यह भी दिखाता है कि कैसे एक टेक्स्ट बॉक्स बनाएं, उसमें टेक्स्ट जोड़ें, और फ़ॉन्ट गुण जैसे फ़ॉन्ट फ़ैमिली, बोल्ड, इटैलिक, अंडरलाइन, फ़ॉन्ट आकार और रंग सेट करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **फ़ॉन्ट‑संबंधी गुणों का प्रबंधन**
{{% alert color="primary" %}} 

प्रेजेंटेशन आमतौर पर टेक्स्ट और छवियों दोनों को शामिल करते हैं। टेक्स्ट को विभिन्न तरीकों से फॉर्मेट किया जा सकता है, चाहे वह विशिष्ट अनुभागों और शब्दों को उजागर करने के लिये हो या कॉरपोरेट स्टाइल के अनुरूप बनाना हो। टेक्स्ट फ़ॉर्मेटिंग उपयोगकर्ता को प्रेजेंटेशन सामग्री की दिखावट को बदलने में मदद करती है। यह लेख Aspose.Slides for Java का उपयोग करके स्लाइड पर पैराग्राफ टेक्स्ट के फ़ॉन्ट गुणों को कॉन्फ़िगर करने का तरीका दर्शाता है।

{{% /alert %}} 

Aspose.Slides for Java का उपयोग करके पैराग्राफ के फ़ॉन्ट गुणों को प्रबंधित करने के चरण:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स का उपयोग करके किसी स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में मौजूद [Placeholder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/placeholder/) शैलियों तक पहुँचें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) में टाइप‑कास्ट करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) द्वारा प्रकट [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) प्राप्त करें।
1. पैराग्राफ को जस्टिफ़ाई करें।
1. एक [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) के टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) तक पहुँचें।
1. [FontData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट परिभाषित करें और उसी अनुसार टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) का **Font** सेट करें।
   1. फ़ॉन्ट को बोल्ड सेट करें।
   1. फ़ॉन्ट को इटैलिक सेट करें।
1. [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रकट [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) का उपयोग करके फ़ॉन्ट रंग सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रेज़ेंटेशन लेता है और एक स्लाइड पर फ़ॉन्ट को फ़ॉर्मेट करता है। नीचे के स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट द्वारा किए गए परिवर्तन को दिखाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट शैली को बदलता है।

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में टेक्स्ट**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: अपडेटेड फ़ॉर्मेटिंग वाला वही टेक्स्ट**|

```java
	// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट को बनाएं
Presentation pres = new Presentation("FontProperties.pptx");
try {
		// स्लाइड को उसके स्थान का उपयोग करके एक्सेस कर रहे हैं
		ISlide slide = pres.getSlides().get_Item(0);

		// स्लाइड में पहले और दूसरे प्लेसहोल्डर को एक्सेस कर रहे हैं और उसे AutoShape में टाइप‑कास्ट कर रहे हैं
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// पहले पैराग्राफ को एक्सेस कर रहे हैं
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// पैराग्राफ को जस्टिफ़ाई करें
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// पहला पोर्शन एक्सेस कर रहे हैं
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// नए फ़ॉन्ट परिभाषित करें
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
{{% alert color="primary" %}} 

जैसा कि **फ़ॉन्ट‑संबंधी गुणों के प्रबंधन** में उल्लेख किया गया है, एक [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) पैराग्राफ में समान फ़ॉर्मेटिंग शैली वाले टेक्स्ट को रखता है। यह लेख Aspose.Slides for Java का उपयोग करके एक टेक्स्टबॉक्स बनाना, उसमें कुछ टेक्स्ट जोड़ना और फ़ॉन्ट फ़ैमिली श्रेणी की विशिष्ट फ़ॉन्ट तथा विभिन्न अन्य गुणों को परिभाषित करना दर्शाता है।

{{% /alert %}} 

टेक्स्टबॉक्स बनाकर उसके टेक्स्ट के फ़ॉन्ट गुण सेट करने के चरण:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड पर **Rectangle** प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) से जुड़ी फ़िल स्टाइल को हटा दें।
1. [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
1. उस [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) से जुड़े [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट तक पहुँचें।
1. [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) के लिए उपयोग करने योग्य फ़ॉन्ट परिभाषित करें।
1. [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रकट संबंधित गुणों का उपयोग करके बोल्ड, इटैलिक, अंडरलाइन, रंग और ऊँचाई जैसे अन्य फ़ॉन्ट गुण सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है।

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for Java द्वारा कुछ फ़ॉन्ट गुण सेट किया गया टेक्स्ट**|

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट को बनाएं
Presentation pres = new Presentation();
try {
	// पहली स्लाइड प्राप्त करें
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle प्रकार का AutoShape जोड़ें
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape से जुड़ी किसी भी फ़िल स्टाइल को हटाएँ
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape से जुड़ा TextFrame एक्सेस करें
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame से जुड़ा Portion एक्सेस करें
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion के लिए फ़ॉन्ट सेट करें
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// फ़ॉन्ट की Bold प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// फ़ॉन्ट की Italic प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// फ़ॉन्ट की Underline प्रॉपर्टी सेट करें
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// फ़ॉन्ट की ऊँचाई सेट करें
	port.getPortionFormat().setFontHeight(25);
	
	// फ़ॉन्ट का रंग सेट करें
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// प्रेज़ेंटेशन को डिस्क पर सहेजें
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```