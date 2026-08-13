---
title: जावा में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
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
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—मिनटों में इंटरेक्टिविटी और कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक किसी वस्तु, डेटा या किसी स्थान का संदर्भ होता है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* टेक्स्ट, आकार या मीडिया में वेबसाइटों के लिंक
* स्लाइडों के लिंक

Aspose.Slides for Java आपको प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है। 

{{% alert color="info" %}} 
आप Aspose का सरल, [नि:शुल्क ऑनलाइन PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) देख सकते हैं। 
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **टेक्स्ट में URL हाइपरलिंक जोड़ें**

यह Java कोड आपको दिखाता है कि टेक्स्ट में वेबसाइट हाइपरलिंक कैसे जोड़ें:
```java
import com.aspose.slides.*;

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

### **आकार या फ्रेम में URL हाइपरलिंक जोड़ें**

यह Java नमूना कोड आपको दिखाता है कि आकार में वेबसाइट हाइपरलिंक कैसे जोड़ें:
```java
import com.aspose.slides.*;

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

Aspose.Slides आपको छवियों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है। 

यह नमूना कोड आपको दिखाता है कि **छवि** में हाइपरलिंक कैसे जोड़ें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // प्रस्तुति में छवि जोड़ता है
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ्रेम बनाता है
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

यह नमूना कोड आपको दिखाता है कि **ऑडियो फ़ाइल** में हाइपरलिंक कैसे जोड़ें:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 
आप *[OLE प्रबंधन](/slides/hi/java/manage-ole/)* देखना चाह सकते हैं। 
{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री सूची बनाएं**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री सूची बना सकते हैं। 

यह नमूना कोड आपको दिखाता है कि हाइपरलिंक के साथ सामग्री सूची कैसे बनाएं:
```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **हाइपरलिंक को फ़ॉर्मेट करें**

### **रंग**

आप [IHyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink) इंटरफ़ेस में [ColorSource](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Hyperlink#setColorSource-int-) प्रॉपर्टी के साथ हाइपरलिंक का रंग सेट कर सकते हैं और हाइपरलिंक से रंग की जानकारी प्राप्त कर सकते हैं। यह सुविधा पहली बार PowerPoint 2019 में पेश की गई थी, इसलिए इस प्रॉपर्टी में परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते। 

यह नमूना कोड एक ऑपरेशन दर्शाता है जहाँ विभिन्न रंगों वाले हाइपरलिंक एक ही स्लाइड में जोड़े गए थे:
```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **प्रस्तुतियों से हाइपरलिंक हटाएं**

### **टेक्स्ट से हाइपरलिंक हटाएं**

यह Java कोड आपको दिखाता है कि प्रस्तुति स्लाइड के टेक्स्ट से हाइपरलिंक कैसे हटाएँ:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **आकार या फ्रेम से हाइपरलिंक हटाएं**

यह Java कोड आपको दिखाता है कि प्रस्तुति स्लाइड के आकार से हाइपरलिंक कैसे हटाएँ:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

यह [Hyperlink](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Hyperlink) क्लास परिवर्तनशील (mutable) है। इस क्लास के साथ आप इन प्रॉपर्टियों के मान बदल सकते हैं:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

यह कोड स्निपेट आपको दिखाता है कि स्लाइड में हाइपरलिंक कैसे जोड़ें और बाद में उसका टूलटिप संपादित करें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// पहले जोड़े गए हाइपरलिंक का टूलटिप बदलता है
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries में समर्थित प्रॉपर्टीज़**

आप एक प्रस्तुति, स्लाइड, या टेक्स्ट से [IHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries) तक पहुँच सकते हैं, जिसके लिए हाइपरलिंक परिभाषित है। 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

यह [IHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries) क्लास इन मेथड्स और प्रॉपर्टीज़ को सपोर्ट करता है: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं स्लाइड के अलावा एक “सेक्शन” या सेक्शन की पहली स्लाइड पर आंतरिक नेविगेशन कैसे बना सकता हूँ?

सेक्शन PowerPoint में स्लाइडों का समूह होता है; नेविगेशन तकनीकी रूप से एक विशिष्ट स्लाइड को लक्षित करता है। “सेक्शन पर नेविगेट” करने के लिए आप आमतौर पर उसकी पहली स्लाइड को लिंक करते हैं।

### क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को सपोर्ट करते हैं। ऐसे लिंक चाइल्ड स्लाइड्स पर भी दिखते हैं और स्लाइडशो के दौरान क्लिक योग्य होते हैं।

### क्या हाइपरलिंक PDF, HTML, इमेज या वीडियो में एक्सपोर्ट करने पर संरक्षित रहेंगे?

[PDF](/slides/hi/java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/java/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/java/convert-powerpoint-to-png/) और [video](/slides/hi/java/convert-powerpoint-to-video/) में एक्सपोर्ट करते हैं, तो क्लिक करने की क्षमता नहीं रहती क्योंकि इन फ़ॉर्मेट्स (रास्टर फ्रेम/वीडियो) हाइपरलिंक को सपोर्ट नहीं करते।