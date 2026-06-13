---
title: Android पर प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन
type: docs
weight: 10
url: /hi/androidjava/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument में छवि प्रबंधन को Aspose.Slides for Android via Java के साथ सहज बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को और अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फाइल, इंटरनेट या अन्य स्थानों से स्लाइड्स पर चित्र डाल सकते हैं। इसी तरह, Aspose.Slides आपको विभिन्न प्रक्रियाओं के माध्यम से अपनी प्रस्तुतियों में स्लाइड्स पर छवियां जोड़ने की अनुमति देता है।

{{% alert  title="सलाह" color="primary" %}} 

Aspose मुफ्त रूपांतरक प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेजी से प्रस्तुतियां बनाने की सुविधा देते हैं। 

{{% /alert %}} 

{{% alert title="सूचना" color="info" %}}

यदि आप किसी छवि को फ़्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप उसके आकार को बदलने, प्रभाव जोड़ने आदि के लिए मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बनाते हैं—तो देखें [Picture Frame](https://docs.aspose.com/slides/hi/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides इन लोकप्रिय फ़ॉर्मैटों में छवियों के साथ संचालन का समर्थन करता है: JPEG, PNG, GIF, और अन्य। 

## **स्लाइड्स में स्थानीय रूप से संग्रहीत छवियां जोड़ें**

आप अपने कंप्यूटर से एक या कई छवियों को प्रस्तुति की एक स्लाइड पर जोड़ सकते हैं। यह जावा में नमूना कोड दिखाता है कि कैसे एक स्लाइड में छवि जोड़ी जाए:

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

## **वेब से स्लाइड्स में छवियां जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप वह छवि सीधे वेब से जोड़ सकते हैं। 

यह नमूना कोड दिखाता है कि जावा में वेब से छवि को स्लाइड में कैसे जोड़ा जाए:

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

## **स्लाइड मास्टर में छवियां जोड़ें**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो इसके नीचे सभी स्लाइड्स की जानकारी (थीम, लेआउट आदि) को संग्रहीत और नियंत्रित करता है। इसलिए, जब आप स्लाइड मास्टर में कोई छवि जोड़ते हैं, तो वह छवि उस स्लाइड मास्टर के तहत सभी स्लाइड्स में दिखाई देती है। 

यह जावा नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ी जाए:

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

## **स्लाइड पृष्ठभूमि के रूप में छवियां जोड़ें**

आप किसी विशिष्ट स्लाइड या कई स्लाइड्स के पृष्ठभूमि के रूप में चित्र उपयोग करने का फैसला कर सकते हैं। ऐसे में, आपको देखना चाहिए *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/hi/androidjava/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**
आप किसी भी छवि को प्रस्तुति में जोड़ या सम्मिलित कर सकते हैं, इसके लिए आप [addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) मेथड का उपयोग कर सकते हैं, जो [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) इंटरफ़ेस का हिस्सा है।

SVG छवि के आधार पर इमेज ऑब्जेक्ट बनाने के लिए आप इस तरह कर सकते हैं:

1. SvgImage ऑब्जेक्ट बनाएँ और उसे ImageShapeCollection में डालें  
2. ISvgImage से PPImage ऑब्जेक्ट बनाएँ  
3. IPPImage इंटरफ़ेस का उपयोग करके PictureFrame ऑब्जेक्ट बनाएँ  

यह नमूना कोड दिखाता है कि उपरोक्त चरणों को लागू करके प्रस्तुति में SVG छवि कैसे जोड़ी जाए:
```java 
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
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

## **SVG को आकारों के सेट में बदलें**
Aspose.Slides में SVG को आकारों के सेट में बदलने की प्रक्रिया PowerPoint की उसी कार्यक्षमता जैसी है जिसका उपयोग SVG छवियों के साथ किया जाता है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [addGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) इंटरफ़ेस का हिस्सा है और पहला पैरामीटर के रूप में [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISvgImage) ऑब्जेक्ट लेता है।

यह नमूना कोड दिखाता है कि वर्णित मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे बदला जाए:

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

    // SVG छवि को आकार के समूह में बदलें और इसे स्लाइड आकार के अनुसार स्केल करें
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **स्लाइड्स में EMF के रूप में छवियां जोड़ें**
Aspose.Slides for Android via Java आपको एक्सेल शीट्स से EMF छवियां उत्पन्न करने और Aspose.Cells के साथ स्लाइड्स में EMF के रूप में जोड़ने की अनुमति देता है।  

यह नमूना कोड दर्शाता है कि वर्णित कार्य कैसे किया जाए:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// वर्कबुक को स्ट्रीम में सहेजें
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

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन (जिसमें स्लाइड शैप्स द्वारा उपयोग की जाने वाली छवियां भी शामिल हैं) में संग्रहीत छवियों को बदलने की सुविधा देता है। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों को दिखाता है। API सीधा‑सादा मेथड प्रदान करता है जिससे आप कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके छवियां सम्मिलित करने वाली प्रस्तुति फ़ाइल लोड करें।  
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।  
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।  
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और उस ऑब्जेक्ट से लक्ष्य छवि को बदलें।  
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("sample.pptx");
try {
    // पहला तरीका।
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
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

{{% alert title="सूचना" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरणकर्ता का उपयोग करके आप आसानी से टेक्स्ट को एनिमेट कर सकते हैं, टेक्स्ट से GIF बना सकते हैं, आदि। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Does the original image resolution remain intact after insertion?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप स्लाइड पर [picture](/slides/hi/androidjava/picture-frame/) के स्केल और सहेजते समय लागू किसी भी संपीड़न पर निर्भर करता है।

**What’s the best way to replace the same logo across dozens of slides at once?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—यह बदलाव उन सभी तत्वों में प्रसारित हो जाएगा जो उस संसाधन का उपयोग करते हैं।

**Can an inserted SVG be converted into editable shapes?**

हाँ। आप SVG को आकारों के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक शैप प्रॉपर्टीज़ के साथ संपादन योग्य हो जाते हैं।

**How can I set a picture as the background for multiple slides at once?**

मास्टर स्लाइड या संबंधित लेआउट पर छवि को पृष्ठभूमि के रूप में असाइन करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि विरासत में ले लेंगी।

**How do I prevent the presentation from "ballooning" in size because of many pictures?**

डुप्लिकेट के बजाय एक ही छवि संसाधन पुनः उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उचित हो ग्राफिक्स को मास्टर पर रखें।