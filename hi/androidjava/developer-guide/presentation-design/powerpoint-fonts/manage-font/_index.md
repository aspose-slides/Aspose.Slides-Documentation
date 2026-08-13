---
title: एंड्रॉइड पर प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- पैराग्राफ
- पाठ स्वरूपण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java में फ़ॉन्ट नियंत्रित करें: एम्बेड, प्रतिस्थापित और कस्टम फ़ॉन्ट लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियों को स्पष्ट, ब्रांड-सेफ़ और सुसंगत रखा जा सके।"
---
## **सारांश**

Aspose.Slides आपको कोड से सीधे प्रस्तुति के टेक्स्ट में फ़ॉन्ट गुणों को प्रबंधित करने की सुविधा देता है। आप स्लाइड्स में टेक्स्ट को शेप्स, टेक्स्ट फ्रेम्स, पैराग्राफ़ और पोर्शन के माध्यम से एक्सेस कर सकते हैं, और फिर चयनित टेक्स्ट पर फॉर्मेटिंग लागू कर सकते हैं।

यह लेख प्रस्तुति में मौजूदा टेक्स्ट के लिए फ़ॉन्ट‑संबंधी गुणों को कॉन्फ़िगर करने के तरीके को समझाता है, जिसमें फ़ॉन्ट फ़ैमिली, बोल्ड और इटैलिक स्टाइल, पैराग्राफ़ अलाइनमेंट और फ़ॉन्ट रंग शामिल हैं। यह यह भी दिखाता है कि टेक्स्ट बॉक्स कैसे बनाएं, उसमें टेक्स्ट जोड़ें, और फ़ॉन्ट फ़ैमिली, बोल्ड, इटैलिक, अंडरलाइन, फ़ॉन्ट साइज और रंग जैसे फ़ॉन्ट गुण सेट करके परिणाम को PPTX फ़ाइल के रूप में सहेजें।

## **फ़ॉन्ट‑संबंधी गुणों का प्रबंधन**
{{% alert color="info" %}} 

प्रेजेंटेशन आमतौर पर टेक्स्ट और इमेज दोनों को शामिल करते हैं। टेक्स्ट को विभिन्न तरीकों से फ़ॉर्मेट किया जा सकता है, चाहे विशिष्ट सेक्शन और शब्दों को उजागर करने के लिए या कॉर्पोरेट शैली के अनुरूप बनाने के लिए। टेक्स्ट फ़ॉर्मेटिंग उपयोगकर्ताओं को प्रेजेंटेशन सामग्री की लुक और फ़ील को वैविध्य देने में मदद करती है। यह लेख Aspose.Slides for Android via Java का उपयोग करके स्लाइड्स पर पैराग्राफ़ टेक्स्ट के फ़ॉन्ट गुणों को कॉन्फ़िगर करने का तरीका दर्शाता है।

{{% /alert %}} 

Aspose.Slides for Android via Java का उपयोग करके पैराग्राफ़ के फ़ॉन्ट गुणों को प्रबंधित करने के लिए:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/placeholder/) shapes in the slide and typecast them to [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/).
1. Get the [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) from the [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) exposed by [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/).
1. Justify the paragraph.
1. Access a [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/)'s text [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/).
1. Define the font using [FontData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontdata/) and set the **Font** of the text [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) exposed by the [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) object.
1. Save the modified presentation to a PPTX file.

उपर्युक्त चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रेजेंटेशन लेता है और उसके एक स्लाइड पर फ़ॉन्ट को फॉर्मेट करता है। निम्नलिखित स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट्स द्वारा हुए परिवर्तन को दर्शाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट स्टाइल को बदलता है।

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में टेक्स्ट**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: वही टेक्स्ट अपडेटेड फ़ॉर्मेटिंग के साथ**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाएं
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// स्लाइड की स्थिति का उपयोग करके स्लाइड एक्सेस कर रहे हैं
	ISlide slide = pres.getSlides().get_Item(0);

	// स्लाइड में पहले और दूसरे प्लेसहोल्डर को एक्सेस कर रहे हैं और इसे AutoShape में टाइपकास्ट कर रहे हैं
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// पहला पैराग्राफ एक्सेस कर रहे हैं
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// पैराग्राफ को जस्टिफ़ाई कर रहे हैं
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// पहला पोर्शन एक्सेस कर रहे हैं
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// नई फ़ॉन्ट निर्धारित करें
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// पोर्शन को नई फ़ॉन्ट असाइन करें
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

जैसा कि **फ़ॉन्ट‑संबंधी गुणों के प्रबंधन** में बताया गया है, एक [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) का उपयोग पैराग्राफ़ में समान फ़ॉर्मेटिंग स्टाइल वाले टेक्स्ट को रखने के लिए किया जाता है। यह लेख Aspose.Slides for Android via Java का उपयोग करके एक टेक्स्टबॉक्स बनाना, उसमें कुछ टेक्स्ट जोड़ना और फिर फ़ॉन्ट फ़ैमिली श्रेणी के विभिन्न गुणों को परिभाषित करना दिखाता है।

{{% /alert %}} 

टेक्स्टबॉक्स बनाने और उसके टेक्स्ट के फ़ॉन्ट गुण सेट करने के लिए:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/).
1. Access the of the [AutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/).
1. Add some text to the [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/).
1. Access the [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) object associated with the [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/).
1. Define the font to be used for the [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) object.
1. Write the modified presentation as a PPTX file.

उपर्युक्त चरणों का कार्यान्वयन नीचे दिया गया है।

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for Android via Java द्वारा सेट किए गए कुछ फ़ॉन्ट गुणों के साथ टेक्स्ट**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनायें
Presentation pres = new Presentation();
try {
	// पहली स्लाइड प्राप्त करें
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle प्रकार का AutoShape जोड़ें
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape से जुड़े किसी भी फ़िल स्टाइल को हटाएँ
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape से जुड़े TextFrame को एक्सेस करें
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame से जुड़े Portion को एक्सेस करें
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
	
	// प्रस्तुति को डिस्क पर सहेजें
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```