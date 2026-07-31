---
title: Aspose.Slides for Java 15.6.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
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
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें."
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) क्लास, मेथड, प्रॉपर्टी आदि, साथ ही नई प्रतिबंधों और अन्य [changes](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) को सूचीबद्ध करता है, जो Aspose.Slides for Java 15.6.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
कंस्ट्रक्टर सिग्नेचर को DataLabel(com.aspose.slides.IChartSeries) से बदलकर DataLabel(com.aspose.slides.IChartDataPoint) कर दिया गया है।
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) मेथड को डिप्रिकेटेड चिह्नित किया गया है। इसके स्थान पर IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) मेथड प्रस्तुत किए गए हैं।
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() मेथड जोड़े गया है ताकि किसी स्लाइड के नोट्स स्लाइड को हटाया जा सके।
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
ISlide.getNotesSlide() और ISlide.addNotesSlide() मेथड डिप्रिकेटेड चिह्नित किए गए हैं। नई मेथड ISlide.getNotesSlideManager() का उपयोग करें।

```java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - अप्रचलित

// notes = slide.getNotesSlide(); - अप्रचलित

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
com.aspose.slides.IDocumentProperties.getAppVersion() मेथड जोड़ा गया है ताकि बिल्ट‑इन डॉक्यूमेंट प्रॉपर्टी प्राप्त की जा सके, जो Microsoft PowerPoint द्वारा उपयोग किए जाने वाले आंतरिक संस्करण संख्याओं को दर्शाता है।
#### **Method remove() has been added to com.aspose.slides.IComment**
com.aspose.slides.IComment.remove() मेथड जोड़ा गया है जिससे कमेंट को कलेक्शन से हटाया जा सके।
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
ICommentAuthor.Remove मेथड जोड़ा गया है जिससे कमेंट्स के लेखक को कलेक्शन से हटाया जा सके।
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
com.aspose.slides.IDocumentProperties.clearCustomProperties() मेथड जोड़ा गया है जिससे सभी कस्टम डॉक्यूमेंट प्रॉपर्टी हटाई जा सकें।
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() मेथड जोड़ा गया है जिससे सभी बिल्ट‑इन डॉक्यूमेंट प्रॉपर्टी (Company, Subject, Author आदि) को हटाया और उनके डिफ़ॉल्ट मान सेट किए जा सकें।
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
com.aspose.slides.IShape में getBlackWhiteMode() और setBlackWhiteMode(byte) मेथड जोड़े गए हैं। ये मेथड निर्धारित करते हैं कि शैप ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड में कैसे रेंडर होगा। संभावित मान com.aspose.slides.BlackWhiteMode क्लास में निर्दिष्ट हैं।

|**Value** |**Meaning** |
| :- | :- |
|Color |सामान्य रंग के साथ लौटता है |
|Automatic |स्वचालित रंग के साथ लौटता है |
|Gray |धूसर रंग के साथ लौटता है |
|LightGray |हल्के धूसर रंग के साथ लौटता है |
|InverseGray |उल्टा धूसर रंग के साथ लौटता है |
|GrayWhite |धूसर और सफेद रंग के साथ लौटता है |
|BlackGray |काली और धूसर रंग के साथ लौटता है |
|BlackWhite |काली और सफेद रंग के साथ लौटता है |
|Black |सिर्फ काली रंग के साथ लौटता है |
|White |सफेद रंग के साथ लौटता है |
|Hidden |ऑब्जेक्ट रेंडर नहीं होता है |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
ICommentAuthorCollection.removeAt(int) मेथड निर्दिष्ट इंडेक्स द्वारा लेखक को हटाने के लिए जोड़ा गया है। ICommentAuthorCollection.remove(ICommentAuthor) मेथड निर्दिष्ट लेखक को कलेक्शन से हटाने के लिए जोड़ा गया है। ICommentAuthorCollection.clear() मेथड सभी आइटम्स को कलेक्शन से हटाने के लिए जोड़ा गया है।