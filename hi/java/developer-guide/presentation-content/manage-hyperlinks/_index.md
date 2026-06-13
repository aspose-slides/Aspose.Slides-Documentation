---
title: Java में प्रस्तुति हाइपरलिंक का प्रबंधन
linktitle: हाइपरलिंक प्रबंधन
type: docs
weight: 20
url: /hi/java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक का स्वरूपण
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—इंटरैक्टिविटी और कार्यप्रवाह को कुछ ही मिनटों में बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक किसी वस्तु, डेटा या किसी चीज़ में किसी स्थान का संदर्भ होता है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* पाठ, आकार या मीडिया के भीतर वेबसाइटों के लिंक
* स्लाइडों के लिंक

Aspose.Slides for Java आपको प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="primary" %}} 
आप Aspose Simple को देख सकते हैं, [नि:शुल्क ऑनलाइन PowerPoint संपादक।](https://products.aspose.app/slides/hi/editor)
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **URL हाइपरलिंक को टेक्स्ट में जोड़ें**

यह Java कोड आपको दिखाता है कि टेक्स्ट में वेबसाइट हाइपरलिंक कैसे जोड़ें:
```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **आकार या फ़्रेम में URL हाइपरलिंक जोड़ें**

यह Java में नमूना कोड आपको दिखाता है कि आकार में वेबसाइट हाइपरलिंक कैसे जोड़ें:
```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **मीडिया में URL हाइपरलिंक जोड़ें**

Aspose.Slides आपको चित्रों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है। 

यह नमूना कोड आपको दिखाता है कि **छवि** में हाइपरलिंक कैसे जोड़ें:
```java
Presentation pres = new Presentation();
try {
	// प्रस्तुति में छवि जोड़ता है
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ़्रेम बनाता है
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

यह नमूना कोड आपको दिखाता है कि **ऑडियो फ़ाइल** में हाइपरलिंक कैसे जोड़ें:
```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

यह नमूना कोड आपको दिखाता है कि **वीडियो** में हाइपरलिंक कैसे जोड़ें:
```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
आप *[OLE प्रबंधन](/slides/hi/java/manage-ole/)* देखना चाह सकते हैं।
{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

चूँकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं। 

यह नमूना कोड आपको दिखाता है कि हाइपरलिंक के साथ सामग्री तालिका कैसे बनाएं:
```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **हाइपरलिंक का स्वरूपण**

### **रंग**

आप [IHyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink) इंटरफ़ेस में [ColorSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Hyperlink#setColorSource-int-) प्रॉपर्टी के साथ हाइपरलिंक की रंग सेट कर सकते हैं और हाइपरलिंक से रंग संबंधी जानकारी प्राप्त भी कर सकते हैं। यह सुविधा पहली बार PowerPoint 2019 में पेश की गई थी, इसलिए इस प्रॉपर्टी से संबंधित परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते।

यह नमूना कोड एक प्रक्रिया को दर्शाता है जहाँ विभिन्न रंगों के हाइपरलिंक एक ही स्लाइड में जोड़े गए:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **प्रस्तुतियों से हाइपरलिंक हटाएँ**

### **टेक्स्ट से हाइपरलिंक हटाएँ**

यह Java कोड आपको दिखाता है कि प्रस्तुति स्लाइड के टेक्स्ट से हाइपरलिंक कैसे हटाएँ:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **आकार या फ़्रेम से हाइपरलिंक हटाएँ**

यह Java कोड आपको दिखाता है कि प्रस्तुति स्लाइड के आकार से हाइपरलिंक कैसे हटाएँ:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **परिवर्तनीय हाइपरलिंक**

क्लास [Hyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Hyperlink) परिवर्तनशील (mutable) है। इस क्लास के साथ आप इन गुणों के मान बदल सकते हैं:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

यह कोड स्निपेट आपको दिखाता है कि स्लाइड में हाइपरलिंक कैसे जोड़ें और बाद में उसका टूलटिप कैसे संपादित करें:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries में समर्थित गुण**

आप किसी प्रस्तुति, स्लाइड या टेक्स्ट से, जिसके लिए हाइपरलिंक परिभाषित है, [IHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries) को एक्सेस कर सकते हैं। 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries) क्लास इन विधियों और गुणों का समर्थन करता है: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं केवल स्लाइड नहीं बल्कि "सेक्शन" या सेक्शन की पहली स्लाइड पर आंतरिक नेविगेशन कैसे बना सकता हूँ?**

PowerPoint में सेक्शन स्लाइडों के समूह होते हैं; नेविगेशन तकनीकी रूप से किसी विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट" करने के लिए, आप सामान्यतः उसकी पहली स्लाइड से लिंक करते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइडों पर दिखाई देते हैं और स्लाइड शो के दौरान क्लिक करने योग्य होते हैं।

**क्या PDF, HTML, इमेजेस या वीडियो में एक्सपोर्ट करने पर हाइपरलिंक संरक्षित रहते हैं?**

[PDF](/slides/hi/java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/java/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब [images](/slides/hi/java/convert-powerpoint-to-png/) और [video](/slides/hi/java/convert-powerpoint-to-video/) में एक्सपोर्ट किया जाता है, तो क्लिक करने की क्षमता नहीं रहती क्योंकि इन स्वरूपों की प्रकृति (रास्टर फ्रेम/वीडियो हाइपरलिंक का समर्थन नहीं करते) के कारण।