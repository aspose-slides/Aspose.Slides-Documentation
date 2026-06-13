---
title: सार्वजनिक API और Aspose.Slides for Java 15.5.0 में बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- स्थांतरण
- पारंपरिक कोड
- आधुनिक कोड
- पारंपरिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टूटने वाले परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से स्थलांतरित कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, नई प्रतिबंध और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) को Aspose.Slides for Java 15.5.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **CommonSlideViewProperties क्लास और ICommonSlideViewProperties इंटरफ़ेस जोड़ दिए गए हैं**
com.aspose.slides.CommonSlideViewProperties क्लास (और इसका इंटरफ़ेस com.aspose.slides.ICommonSlideViewProperties) सामान्य स्लाइड व्यू प्रॉपर्टीज़ का प्रतिनिधित्व करता है (वर्तमान में व्यू स्केल विकल्प)।
### **IAxis.getLabelOffset(), setLabelOffset(int) मेथड जोड़ दिए गए हैं**
IAxis.getLabelOffset(), setLabelOffset(int) मेथड लेबलों की अक्ष से दूरी प्राप्त करने और निर्दिष्ट करने की अनुमति देते हैं। यह श्रेणी या तिथि अक्ष पर लागू होते हैं।
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) मेथड जोड़ दिए गए हैं**
com.aspose.slides.IChartTextBlockFormat इंटरफ़ेस में getAutofitType(), setAutofitType(/**TextAutofitType**/byte) मेथड जोड़े गए हैं। इस मान को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
### **IChartTextBlockFormat.getWrapText(), setWrapText(byte) मेथड जोड़ दिए गए हैं**
com.aspose.slides.IChartTextBlockFormat इंटरफ़ेस में getWrapText(), setWrapText(/**NullableBool**/byte) मेथड जोड़े गए हैं। इस मान को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2007/2013 में पूर्ण समर्थन)।
### **IChartTextBlockFormat में मार्जिन प्रबंधन के लिए मेथड जोड़ दिए गए हैं**
com.aspose.slides.IChartTextBlockFormat इंटरफ़ेस में getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() और setMarginBottom(double) मेथड जोड़े गए हैं। इन मानों को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
### **ViewProperties.getNotesViewProperties() मेथड जोड़ दिया गया है**
com.aspose.slides.ViewProperties.getNotesViewProperties() प्रॉपर्टी जोड़ी गई है। यह नोट्स व्यू मोड से संबंधित सामान्य व्यू प्रॉपर्टीज़ प्राप्त करती है।
### **ViewProperties.getSlideViewProperties() मेथड जोड़ दिया गया है**
com.aspose.slides.ViewProperties.getSlideViewProperties() मेथड जोड़ी गई है। यह स्लाइड व्यू मोड से संबंधित सामान्य व्यू प्रॉपर्टीज़ प्राप्त करता है।