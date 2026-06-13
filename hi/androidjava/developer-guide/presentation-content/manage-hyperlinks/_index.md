---
title: Android पर प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/androidjava/manage-hyperlinks/
keywords:
  - URL जोड़ें
  - हाइपरलिंक जोड़ें
  - हाइपरलिंक बनाएं
  - हाइपरलिंक स्वरूपित करें
  - हाइपरलिंक हटाएँ
  - हाइपरलिंक अद्यतन करें
  - पाठ हाइपरलिंक
  - स्लाइड हाइपरलिंक
  - आकृति हाइपरलिंक
  - चित्र हाइपरलिंक
  - वीडियो हाइपरलिंक
  - परिवर्तनीय हाइपरलिंक
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—कुछ ही मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक किसी वस्तु, डेटा या किसी स्थान का संदर्भ होता है। नीचे PowerPoint प्रस्तुतियों में आमतौर पर उपयोग किए जाने वाले हाइपरलिंक हैं:

* पाठ, आकृति या मीडिया के भीतर वेबसाइटों के लिंक
* स्लाइड्स के लिंक

Aspose.Slides for Android via Java आपको प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="primary" %}} 

आप Aspose Simple, [नि:शुल्क ऑनलाइन PowerPoint संपादक.](https://products.aspose.app/slides/hi/editor)

{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **पाठ में URL हाइपरलिंक जोड़ें**

यह Java कोड दिखाता है कि कैसे आप किसी पाठ में वेबसाइट हाइपरलिंक जोड़ सकते हैं:

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

### **आकृतियों या फ्रेम्स में URL हाइपरलिंक जोड़ें**

यह Java नमूना कोड दिखाता है कि कैसे आप किसी आकृति में वेबसाइट हाइपरलिंक जोड़ सकते हैं:

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

यह नमूना कोड दिखाता है कि कैसे आप **चित्र** में हाइपरलिंक जोड़ सकते हैं:

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
	// पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ्रेम बनाता है
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

यह नमूना कोड दिखाता है कि कैसे आप **ऑडियो फ़ाइल** में हाइपरलिंक जोड़ सकते हैं:

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

यह नमूना कोड दिखाता है कि कैसे आप **वीडियो** में हाइपरलिंक जोड़ सकते हैं:

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

आप देखना चाहेंगे *[Manage OLE](/slides/hi/androidjava/manage-ole/)*।

{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं। 

यह नमूना कोड दिखाता है कि कैसे आप हाइपरलिंक के साथ एक सामग्री तालिका बना सकते हैं:

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

## **हाइपरलिंक को स्वरूपित करें**

### **रंग**

आप [ColorSource](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) प्रॉपर्टी के साथ, [IHyperlink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink) इंटरफ़ेस में, हाइपरलिंक का रंग सेट कर सकते हैं और हाइपरलिंक से रंग की जानकारी प्राप्त कर सकते हैं। इस सुविधा को पहली बार PowerPoint 2019 में प्रस्तुत किया गया था, इसलिए इस प्रॉपर्टी से संबंधित परिवर्तन पुराने PowerPoint संस्करणों में लागू नहीं होते।

यह नमूना कोड दर्शाता है कि कैसे विभिन्न रंगों के हाइपरलिंक एक ही स्लाइड में जोड़े गए:

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

### **पाठ से हाइपरलिंक हटाएँ**

यह Java कोड दिखाता है कि कैसे आप प्रस्तुति स्लाइड में किसी पाठ से हाइपरलिंक को हटाएँ:

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

### **आकृतियों या फ्रेम्स से हाइपरलिंक हटाएँ**

यह Java कोड दिखाता है कि कैसे आप प्रस्तुति स्लाइड में किसी आकृति से हाइपरलिंक को हटाएँ: 

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

[Hyperlink](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Hyperlink) क्लास परिवर्तनीय है। इस क्लास के साथ, आप इन प्रॉपर्टीज़ के मान बदल सकते हैं:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

कोड स्निपेट दिखाता है कि कैसे आप स्लाइड में हाइपरलिंक जोड़ें और बाद में इसका टूलटिप संपादित करें:

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

## **IHyperlinkQueries में समर्थित प्रॉपर्टीज़**

आप प्रस्तुतिकरण, स्लाइड, या उस पाठ से [IHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries) तक पहुँच सकते हैं जिसके लिए हाइपरलिंक परिभाषित है।

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries) क्लास इन मेथड्स और प्रॉपर्टीज़ का समर्थन करता है:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं केवल स्लाइड तक नहीं, बल्कि एक "सेक्शन" या सेक्शन की पहली स्लाइड तक आंतरिक नेविगेशन कैसे बना सकता हूँ?**

PowerPoint में सेक्शन स्लाइड्स का समूह होते हैं; नेविगेशन तकनीकी रूप से एक विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन तक नेविगेट" करने के लिए, आप सामान्यतः उसकी पहली स्लाइड से लिंक बनाते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर कार्य करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को समर्थन देते हैं। ऐसे लिंक चाइल्ड स्लाइड्स पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक योग्य होते हैं।

**क्या हाइपरलिंक PDF, HTML, इमेजेज़ या वीडियो में एक्सपोर्ट करते समय संरक्षित रहते हैं?**

[PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/androidjava/convert-powerpoint-to-png/) और [video](/slides/hi/androidjava/convert-powerpoint-to-video/) में एक्सपोर्ट करते हैं, तो क्लिक करने की क्षमता उन प्रारूपों की प्रकृति के कारण (रास्टर फ्रेम/वीडियो हाइपरलिंक का समर्थन नहीं करते) नहीं बनी रहती।