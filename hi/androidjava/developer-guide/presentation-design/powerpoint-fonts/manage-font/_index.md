---
title: Android पर प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- पैराग्राफ़
- पाठ फॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java में फ़ॉन्ट नियंत्रित करें: कस्टम फ़ॉन्ट एम्बेड, प्रतिस्थापित और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियाँ स्पष्ट, ब्रांड-सुरक्षित और सुसंगत रहें।"
---
## **परिचय**

Aspose.Slides आपको कोड से सीधे प्रस्तुति पाठ में फ़ॉन्ट गुणों को प्रबंधित करने की अनुमति देता है। आप आकृतियों, टेक्स्ट फ़्रेम, पैराग्राफ़ और भागों के माध्यम से स्लाइड्स में पाठ तक पहुँच सकते हैं और चयनित पाठ पर फॉर्मेटिंग लागू कर सकते हैं।

यह लेख प्रस्तुति में मौजूदा पाठ के लिए फ़ॉन्ट संबंधी गुणों को कॉन्फ़िगर करने के तरीके को समझाता है, जिसमें फ़ॉन्ट फैमिली, बोल्ड और इटैलिक स्टाइल, पैराग्राफ़ संरेखण और फ़ॉन्ट रंग शामिल है। यह एक टेक्स्ट बॉक्स बनाने, उसमें पाठ जोड़ने, और फ़ॉन्ट गुण जैसे फ़ॉन्ट फैमिली, बोल्ड, इटैलिक, अंडरलाइन, फ़ॉन्ट आकार और रंग सेट करने तथा परिणाम को PPTX फ़ाइल के रूप में सहेजने का प्रदर्शन भी करता है।

## **फ़ॉन्ट संबंधित गुणों का प्रबंधन**
{{% alert color="primary" %}} 

प्रेजेंटेशन आमतौर पर टेक्स्ट और इमेज दोनों को शामिल करते हैं। टेक्स्ट को विभिन्न तरीकों से फॉर्मेट किया जा सकता है, चाहे विशेष सेक्शन और शब्दों को उजागर करने के लिए या कॉर्पोरेट शैली के साथ मेल खाने के लिए। टेक्स्ट फॉर्मेटिंग उपयोगकर्ताओं को प्रस्तुति सामग्री की दिखावट को विविध बनाने में मदद करती है। यह लेख Aspose.Slides for Android via Java का उपयोग करके स्लाइड्स पर पैराग्राफ़ के फ़ॉन्ट गुण कॉन्फ़िगर करने का तरीका दर्शाता है।

{{% /alert %}} 

Aspose.Slides for Android via Java का उपयोग करके पैराग्राफ़ के फ़ॉन्ट गुण प्रबंधित करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में [Placeholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) आकृतियों तक पहुँचें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) में टाइपकास्ट करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) द्वारा प्रदर्शित [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) प्राप्त करें।
1. पैराग्राफ़ को जस्टिफ़ाई करें।
1. [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) के पाठ [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) तक पहुँचें।
1. [FontData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट निर्धारित करें और पाठ [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) का **Font** उसी अनुसार सेट करें।
   1. फ़ॉन्ट को बोल्ड सेट करें।
   1. फ़ॉन्ट को इटैलिक सेट करें।
1. [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रदर्शित [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) का उपयोग करके फ़ॉन्ट रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में पाठ**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: अद्यतन फ़ॉर्मेटिंग के साथ वही पाठ**|

```java
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// स्लाइड को उसके क्रमांक से एक्सेस करना
	ISlide slide = pres.getSlides().get_Item(0);

	// स्लाइड में पहले और दूसरे प्लेसहोल्डर को एक्सेस करना और इसे AutoShape में टाइपकास्ट करना
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// पहले पैराग्राफ को एक्सेस करना
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// पैराग्राफ को जस्टिफ़ाई करना
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// पहले भाग को एक्सेस करना
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// नई फ़ॉन्ट परिभाषित करें
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// नए फ़ॉन्ट को भाग पर असाइन करें
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// फ़ॉन्ट को बोल्ड सेट करें
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// फ़ॉन्ट को इटैलिक सेट करें
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// फ़ॉन्ट का रंग सेट करें
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX को डिस्क पर सेव करें
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **पाठ फ़ॉन्ट गुण सेट करें**
{{% alert color="primary" %}} 

जैसा कि **फ़ॉन्ट संबंधित गुणों का प्रबंधन** में बताया गया है, एक [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) का उपयोग पैराग्राफ़ में समान फॉर्मेटिंग शैली वाले पाठ को रखने के लिए किया जाता है। यह लेख Aspose.Slides for Android via Java का उपयोग करके एक टेक्स्टबॉक्स बनाता है, उसमें कुछ पाठ जोड़ता है और फ़ॉन्ट फ़ैमिली श्रेणी के विशिष्ट फ़ॉन्ट और विभिन्न अन्य गुणों को परिभाषित करता है।

{{% /alert %}} 

एक टेक्स्टबॉक्स बनाने और उसमें पाठ के फ़ॉन्ट गुण सेट करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में **Rectangle** प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) से जुड़े फाइल शैली को हटाएं।
1. [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) तक पहुँचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) में कुछ पाठ जोड़ें।
1. [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) से जुड़े [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) ऑब्जेक्ट तक पहुँचें।
1. [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) के लिए उपयोग किए जाने वाले फ़ॉन्ट को निर्धारित करें।
1. [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रदर्शित संबंधित गुणों का उपयोग करके बोल्ड, इटैलिक, अंडरलाइन, रंग और ऊँचाई जैसे अन्य फ़ॉन्ट गुण सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

The implementation of the above steps is given below.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for Android via Java द्वारा सेट किए गए कुछ फ़ॉन्ट गुणों के साथ पाठ**|

```java
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
	// पहली स्लाइड प्राप्त करें
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle प्रकार का AutoShape जोड़ें
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape से जुड़ी किसी भी फ़िल शैली को हटाएँ
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
	
	// प्रस्तुति को डिस्क पर सहेजें
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```