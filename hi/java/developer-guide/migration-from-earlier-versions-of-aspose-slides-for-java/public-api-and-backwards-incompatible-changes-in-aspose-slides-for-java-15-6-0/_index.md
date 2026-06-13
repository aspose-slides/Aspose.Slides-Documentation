---
title: Aspose.Slides for Java 15.6.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- स्थानांतरण
- पुराना कोड
- आधुनिक कोड
- परम्परागत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 
यह पृष्ठ Aspose.Slides for Java 15.6.0 API के साथ प्रस्तुत सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) वर्गों, विधियों, गुणों आदि, किसी भी नई प्रतिबंधों और अन्य [परिवर्तनों](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) को सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **com.aspose.slides.DataLabel कंस्ट्रक्टर सिग्नेचर बदल दिया गया है**
कंस्ट्रक्टर का सिग्नेचर DataLabel(com.aspose.slides.IChartSeries) से बदलकर DataLabel(com.aspose.slides.IChartDataPoint) कर दिया गया है।
#### **सदस्य com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) को अप्रचलित चिह्नित किया गया है; इसके स्थान पर विकल्प पेश किए गए हैं**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) विधियों को अप्रचलित चिह्नित किया गया है। इसके स्थान पर IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) विधियां पेश की गई हैं।
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() जोड़ा गया है**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() विधि कुछ स्लाइड की नोट्स स्लाइड को हटाने के लिए जोड़ी गई है।
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() जोड़ा गया है। Methods ISlide.getNotesSlide() और ISlide.addNotesSlide() को अप्रचलित चिह्नित किया गया है**
ISlide.getNotesSlide(), ISlide.addNotesSlide() विधियों को अप्रचलित चिह्नित किया गया है। इसके बदले नई विधि ISlide.getNotesSlideManager() का उपयोग करें।
``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - अप्रचलित

// notes = slide.getNotesSlide(); - अप्रचलित

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() को com.aspose.slides.IDocumentProperties में जोड़ा गया है**
com.aspose.slides.IDocumentProperties.getAppVersion() विधि को बिल्ट‑इन दस्तावेज़ गुण प्राप्त करने के लिए जोड़ा गया है, जो Microsoft PowerPoint द्वारा उपयोग किए जाने वाले आंतरिक संस्करण संख्याएँ दर्शाता है।
#### **Method remove() को com.aspose.slides.IComment में जोड़ा गया है**
com.aspose.slides.IComment.remove() विधि संग्रह से टिप्पणी हटाने के लिये जोड़ी गई है।
#### **Method remove() को com.aspose.slides.ICommentAuthor में जोड़ा गया है**
ICommentAuthor.Remove विधि संग्रह से टिप्पणियों के लेखक को हटाने के लिये जोड़ी गई है।
#### **Methods clearCustomProperties() और clearBuiltInProperties() को com.aspose.slides.IDocumentProperties में जोड़ा गया है**
com.aspose.slides.IDocumentProperties.clearCustomProperties() विधि सभी कस्टम दस्तावेज़ गुणों को हटाने के लिए जोड़ी गई है।
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() विधि सभी बिल्ट‑इन दस्तावेज़ गुणों (Company, Subject, Author आदि) को हटाने और उनके डिफॉल्ट मान सेट करने के लिये जोड़ी गई है।
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) को com.aspose.slides.IShape में जोड़ा गया है**
com.aspose.slides.IShape में getBlackWhiteMode(), setBlackWhiteMode(byte) विधियों को जोड़ा गया है। ये विधियां निर्धारित करती हैं कि एक आकार काले‑सफेद प्रदर्शन मोड में कैसे रेंडर होगा। संभावित मान com.aspose.slides.BlackWhiteMode वर्ग में निर्दिष्ट हैं।

|**मान** |**अर्थ** |
| :- | :- |
|Color |सामान्य रंगिंग के साथ लौटें |
|Automatic |स्वचालित रंगिंग के साथ लौटें |
|Gray |भूरा रंगिंग के साथ लौटें |
|LightGray |हल्का भूरा रंगिंग के साथ लौटें |
|InverseGray |उल्टा भूरा रंगिंग के साथ लौटें |
|GrayWhite |भूरा और सफेद रंगिंग के साथ लौटें |
|BlackGray |काला और भूरा रंगिंग के साथ लौटें |
|BlackWhite |काला और सफेद रंगिंग के साथ लौटें |
|Black |केवल काले रंगिंग के साथ लौटें |
|White |सफ़ेद रंगिंग के साथ लौटें |
|Hidden |ऑब्जेक्ट रेंडर नहीं होगा |
#### **Methods removeAt(int), remove(ICommentAuthor) और clear() को com.aspose.slides.ICommentAuthorCollection में जोड़ा गया है**
ICommentAuthorCollection.removeAt(int) विधि निर्दिष्ट अनुक्रमांक द्वारा लेखक को हटाने के लिये जोड़ी गई है। ICommentAuthorCollection.remove(ICommentAuthor) विधि संग्रह से निर्दिष्ट लेखक को हटाने के लिये जोड़ी गई है। ICommentAuthorCollection.clear() विधि सभी आइटम्स को संग्रह से हटाने के लिये जोड़ी गई है।