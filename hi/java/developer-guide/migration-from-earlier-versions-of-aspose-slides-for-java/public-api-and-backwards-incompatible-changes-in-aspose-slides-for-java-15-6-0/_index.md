---
title: "Aspose.Slides for Java 15.6.0 में सार्वजनिक API और पिछड़े अनुकूल नहीं होने वाले परिवर्तन"
linktitle: "Aspose.Slides for Java 15.6.0"
type: docs
weight: 140
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - माइग्रेशन
  - पुराना कोड
  - आधुनिक कोड
  - पुराना दृष्टिकोण
  - आधुनिक दृष्टिकोण
  - PowerPoint
  - OpenDocument
  - प्रेजेंटेशन
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और तोड़ने वाले परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि की सूची देता है, साथ ही Aspose.Slides for Java 15.6.0 API के साथ प्रस्तुत नई प्रतिबंधों और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) का विवरण देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **com.aspose.slides.DataLabel कन्स्ट्रक्टर सिग्नेचर बदल दिया गया है**
कन्स्ट्रक्टर का सिग्नेचर DataLabel(com.aspose.slides.IChartSeries) से बदलकर DataLabel(com.aspose.slides.IChartDataPoint) कर दिया गया है।
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) को डिप्रिकेट कर दिया गया है; इसके बजाय नए विकल्प पेश किए गए हैं**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) मेथड्स को डिप्रिकेट कर दिया गया है। इसके बजाय IDocumentProperties.countOfCustomProperties(), IDDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) मेथड्स पेश किए गए हैं।
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() जोड़ दिया गया है**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() मेथड कुछ स्लाइड की नोट्स स्लाइड को हटाने के लिए जोड़ा गया है।
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() जोड़ दिया गया है। Methods ISlide.getNotesSlide() और ISlide.addNotesSlide() को डिप्रिकेट कर दिया गया है**
ISlide.getNotesSlide(), ISlide.addNotesSlide() मेथड्स को डिप्रिकेट किया गया है। इसके बजाय नया मेथड ISlide.getNotesSlideManager() उपयोग करें।

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - अप्रचलित

    // notes = slide.getNotesSlide(); - अप्रचलित

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() को com.aspose.slides.IDocumentProperties में जोड़ा गया है**
com.aspose.slides.IDocumentProperties.getAppVersion() मेथड बिल्ट‑इन डॉक्यूमेंट प्रॉपर्टी प्राप्त करने के लिए जोड़ा गया है, जो Microsoft PowerPoint द्वारा उपयोग किए जाने वाले आंतरिक संस्करण नंबरों को दर्शाता है।
#### **Method remove() को com.aspose.slides.IComment में जोड़ा गया है**
com.aspose.slides.IComment.remove() मेथड कमेंट को कलेक्शन से हटाने के लिए जोड़ा गया है।
#### **Method remove() को com.aspose.slides.ICommentAuthor में जोड़ा गया है**
ICommentAuthor.Remove मेथड कमेंट्स के लेखक को कलेक्शन से हटाने के लिए जोड़ा गया है।
#### **Methods clearCustomProperties() और clearBuiltInProperties() को com.aspose.slides.IDocumentProperties में जोड़ा गया है**
com.aspose.slides.IDocumentProperties.clearCustomProperties() मेथड सभी कस्टम डॉक्यूमेंट प्रॉपर्टीज़ को हटाने के लिए जोड़ा गया है।
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() मेथड सभी बिल्ट‑इन डॉक्यूमेंट प्रॉपर्टीज़ (Company, Subject, Author आदि) को हटाने और उनकी डिफ़ॉल्ट मान सेट करने के लिए जोड़ा गया है।
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) को com.aspose.slides.IShape में जोड़ा गया है**
Methods getBlackWhiteMode(), setBlackWhiteMode(byte) को com.aspose.slides.IShape में जोड़ा गया है। ये मेथड यह निर्धारित करते हैं कि ब्लैक‑एंड‑वाइट डिस्प्ले मोड में शैप कैसे रेंडर होगा। संभव मान com.aspose.slides.BlackWhiteMode क्लास में निर्दिष्ट हैं।

|**Value** |**Meaning** |
| :- | :- |
|Color |सामान्य रंग के साथ लौटता है |
|Automatic |स्वचालित रंगीकरण के साथ लौटता है |
|Gray |धूसर रंग के साथ लौटता है |
|LightGray |हल्के धूसर रंग के साथ लौटता है |
|InverseGray |उलटा धूसर रंग के साथ लौटता है |
|GrayWhite |धूसर और श्वेत रंग के साथ लौटता है |
|BlackGray |काला और धूसर रंग के साथ लौटता है |
|BlackWhite |काला और श्वेत रंग के साथ लौटता है |
|Black |केवल काले रंग के साथ लौटता है |
|White |श्वेत रंग के साथ लौटता है |
|Hidden |ऑब्जेक्ट रेंडर नहीं होता |
#### **Methods removeAt(int), remove(ICommentAuthor) और clear() को com.aspose.slides.ICommentAuthorCollection में जोड़ा गया है**
ICommentAuthorCollection.removeAt(int) मेथड निर्दिष्ट इंडेक्स द्वारा लेखक को हटाने के लिए जोड़ा गया है। ICommentAuthorCollection.remove(ICommentAuthor) मेथड निर्दिष्ट लेखक को कलेक्शन से हटाने के लिए जोड़ा गया है। ICommentAuthorCollection.clear() मेथड सभी आइटेम्स को कलेक्शन से हटाने के लिए जोड़ा गया है।