---
title: जावा का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों को प्रबंधित करें
type: docs
weight: 10
url: /hi/java/image/
keywords:
  - छवि जोड़ें
  - चित्र जोड़ें
  - बिटमैप जोड़ें
  - छवि प्रतिस्थापित करें
  - चित्र प्रतिस्थापित करें
  - वेब से
  - पृष्ठभूमि
  - PNG जोड़ें
  - JPG जोड़ें
  - SVG जोड़ें
  - EMF जोड़ें
  - WMF जोड़ें
  - TIFF जोड़ें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - EMF
  - SVG
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियाँ प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में आप फ़ाइल, इंटरनेट या अन्य स्थानों से चित्र को स्लाइड पर सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides आपको विभिन्न प्रक्रियाओं के माध्यम से अपनी प्रस्तुतियों की स्लाइड में छवियों को जोड़ने की सुविधा देता है।

{{% alert  title="Tip" color="primary" %}} 

Aspose मुफ्त कन्वर्टर्स—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—प्रदान करता है, जिससे लोग छवियों से जल्दी प्रस्तुतियों का निर्माण कर सकते हैं। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप छवि को फ़्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप उसका आकार बदलने, प्रभाव जोड़ने आदि के लिए मानक फ़ॉर्मैटिंग विकल्पों का उपयोग करने की योजना बनाते हैं—तो देखें [Picture Frame](https://docs.aspose.com/slides/hi/java/picture-frame/)। 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप छवियों और PowerPoint प्रस्तुतियों से संबंधित इनपुट/आउटपुट प्रक्रियाओं को संचालित करके एक फ़ॉर्मैट से दूसरी फ़ॉर्मैट में छवि को परिवर्तित कर सकते हैं। इन पृष्ठों को देखें: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides इन लोकप्रिय फ़ॉर्मैट्स: JPEG, PNG, GIF, आदि में छवियों के साथ ऑपरेशन्स का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड में जोड़ें**

आप अपने कंप्यूटर पर एक या कई छवियों को प्रस्तुति की स्लाइड में जोड़ सकते हैं। Java में यह नमूना कोड दिखाता है कि कैसे छवि को स्लाइड में जोड़ा जाए:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **वेब से छवियों को स्लाइड में जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 

यह नमूना कोड दिखाता है कि Java में वेब से छवि को स्लाइड में कैसे जोड़ा जाए:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **स्लाइड मास्टर में छवियों को जोड़ें**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो उसके नीचे सभी स्लाइडों की जानकारी (थीम, लेआउट, आदि) को संग्रहीत और नियंत्रित करता है। इसलिए, जब आप स्लाइड मास्टर में एक छवि जोड़ते हैं, वह छवि उस मास्टर के नीचे प्रत्येक स्लाइड पर दिखाई देती है। 

यह Java नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ी जाए:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **स्लाइड बैकग्राउंड के रूप में छवियों को जोड़ें**

आप किसी विशिष्ट स्लाइड या कई स्लाइडों के लिए पृष्ठभूमि के रूप में एक चित्र का उपयोग कर सकते हैं। ऐसे में, आपको *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/hi/java/presentation-background/#setting-images-as-background-for-slides)* देखना चाहिए।

## **प्रेजेंटेशन में SVG जोड़ें**
आप किसी भी छवि को प्रस्तुति में जोड़ने या सम्मिलित करने के लिए [addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड का उपयोग कर सकते हैं, जो कि [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) इंटरफ़ेस से संबंधित है।

SVG छवि के आधार पर एक इमेज ऑब्जेक्ट बनाने के लिए आप इसे इस प्रकार कर सकते हैं:

1. SvgImage ऑब्जेक्ट बनाकर उसे ImageShapeCollection में डालें  
2. ISvgImage से PPImage ऑब्जेक्ट बनाएँ  
3. IPPImage इंटरफ़ेस का उपयोग करके PictureFrame ऑब्जेक्ट बनाएँ  

यह नमूना कोड दिखाता है कि ऊपर बताए गए चरणों को लागू करके प्रस्तुति में एक SVG छवि कैसे जोड़ी जाए:
```java
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SVG को आकारों के सेट में परिवर्तित करें**
Aspose.Slides द्वारा SVG को आकारों के सेट में परिवर्तित करना PowerPoint की वह कार्यक्षमता के समान है जो SVG छवियों के साथ काम करने के लिए उपयोग की जाती है:

![PowerPoint पॉपअप मेनू](img_01_01.png)

यह कार्यक्षमता [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) इंटरफ़ेस के [addGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) मेथड के ओवरलोड्स में से एक द्वारा प्रदान की जाती है, जो प्रथम तर्क के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISvgImage) ऑब्जेक्ट लेती है।

यह नमूना कोड दिखाता है कि वर्णित मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित किया जाए:

```java 
// नई प्रस्तुति बनाएं
IPresentation presentation = new Presentation();
try {
    // SVG फ़ाइल की सामग्री पढ़ें
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage ऑब्जेक्ट बनाएं
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड का आकार प्राप्त करें
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG छवि को आकारों के समूह में बदलें और उसे स्लाइड आकार के अनुसार स्केल करें
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **EMF के रूप में छवियों को स्लाइड में जोड़ें**
Aspose.Slides for Java आपको Excel शीट्स से EMF छवियाँ बनाने और Aspose.Cells के साथ स्लाइड में EMF के रूप में छवियों को जोड़ने की सुविधा देता है।  

यह नमूना कोड दर्शाता है कि वर्णित कार्य कैसे किया जाए:

```java 
//वर्कबुक को स्ट्रीम में सहेजें
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **इमेज कलेक्शन में छवियों को प्रतिस्थापित करें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों (स्लाइड शेप्स द्वारा उपयोग की गई छवियों सहित) को बदलने की अनुमति देता है। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों को दिखाता है। API बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि को बदलने के लिए सीधी विधियाँ प्रदान करता है।

नीचे दिए गए चरणों का पालन करें:

1. उस प्रस्तुति फ़ाइल को लोड करें जिसमें छवियाँ हैं, इसके लिये [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करें।  
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।  
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।  
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।  
5. तीसरे तरीके में, लक्ष्य छवि को उस छवि से बदलें जो पहले से प्रस्तुति के इमेज कलेक्शन में मौजूद है।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("sample.pptx");
try {
    // पहला तरीका।
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // दूसरा तरीका।
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // तीसरा तरीका।
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर का उपयोग करके आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं, टेक्स्ट से GIF बना सकते हैं, आदि। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सम्मिलन के बाद मूल छवि का रिज़ोल्यूशन अपरिवर्तित रहता है?**  
हाँ। स्रोत पिक्सेल सुरक्षित रहते हैं, लेकिन अंतिम दिखाई देना इस पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/java/picture-frame/) को कैसे स्केल किया गया है और सेव करने पर कौन सा संपीड़न लागू किया गया है।

**एक ही लोगो को कई स्लाइडों में एक साथ बदलने का सबसे अच्छा तरीका क्या है?**  
लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—अपडेट सभी उन तत्वों में प्रसारित हो जाएंगे जो उस रिसोर्स का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकारों में परिवर्तित किया जा सकता है?**  
हाँ। आप SVG को आकारों के समूह में परिवर्तित कर सकते हैं, जिससे व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**एक साथ कई स्लाइडों के लिए छवि को पृष्ठभूमि के रूप में कैसे सेट किया जाए?**  
[Assign the image as the background](/slides/hi/java/presentation-background/) को मास्टर स्लाइड या संबंधित लेआउट पर सेट करें—वह मास्टर/लेआउट उपयोग करने वाली सभी स्लाइडें पृष्ठभूमि को विरासत में प्राप्त करेंगी।

**बहुत सारी छवियों के कारण प्रस्तुति का आकार "वसूली" से बचाने के लिए क्या किया जाए?**  
एक ही छवि रिसोर्स को कई बार उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सेव करते समय संपीड़न लागू करें, और जहां उपयुक्त हो, दोहराए गए ग्राफिक्स को मास्टर पर रखें।