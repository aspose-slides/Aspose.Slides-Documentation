---
title: Aspose.Slides for Java 15.5.0 में सार्वजनिक API और पीछे की ओर असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- स्थांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकर परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ Aspose.Slides for Java 15.5.0 API के साथ प्रस्तुत सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, साथ ही कोई नई प्रतिबंध और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **CommonSlideViewProperties क्लास और ICommonSlideViewProperties इंटरफ़ेस जोड़ी गई है**
com.aspose.slides.CommonSlideViewProperties क्लास (और इसका इंटरफ़ेस com.aspose.slides.ICommonSlideViewProperties) सामान्य स्लाइड दृश्य गुणों का प्रतिनिधित्व करती है (वर्तमान में दृश्य स्केल विकल्प)।

### **IAxis.getLabelOffset(), setLabelOffset(int) मेथड जोड़े गए हैं**
IAxis.getLabelOffset(), setLabelOffset(int) मेथड्स लेबल्स की एक्सिस से दूरी प्राप्त करने और निर्दिष्ट करने की अनुमति देते हैं। यह श्रेणी या तिथि एक्सिस पर लागू होता है।

### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) मेथड जोड़े गए हैं**
मेथड्स getAutofitType(), setAutofitType(/**TextAutofitType**/byte) को com.aspose.slides.IChartTextBlockFormat इंटरफ़ेस में जोड़ा गया है।
इस मान को बदलने से केवल इन चार्ट हिस्सों पर कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।

### **IChartTextBlockFormat.getWrapText(), setWrapText(byte) मेथड जोड़े गए हैं**
मेथड्स getWrapText(), setWrapText(/**NullableBool**/byte) को इंटरफ़ेस com.aspose.slides.IChartTextBlockFormat में जोड़ा गया है।
इस मान को बदलने से केवल इन चार्ट हिस्सों पर प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2007/2013 में पूर्ण समर्थन)।

### **IChartTextBlockFormat में मार्जिन प्रबंधन के मेथड जोड़े गए हैं**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() एवं setMarginBottom(double) मेथड्स को इंटरफ़ेस com.aspose.slides.IChartTextBlockFormat में जोड़ा गया है।
इन मानों को बदलने से केवल इन चार्ट हिस्सों पर प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।

### **ViewProperties.getNotesViewProperties() मेथड जोड़ा गया है**
com.aspose.slides.ViewProperties.getNotesViewProperties() प्रॉपर्टी जोड़ी गई है। यह नोट्स व्यू मोड से सम्बंधित सामान्य व्यू प्रॉपर्टी को प्राप्त करता है।

### **ViewProperties.getSlideViewProperties() मेथड जोड़ा गया है**
com.aspose.slides.ViewProperties.getSlideViewProperties() मेथड जोड़ा गया है। यह स्लाइड व्यू मोड से सम्बंधित सामान्य व्यू प्रॉपर्टी को प्राप्त करता है।