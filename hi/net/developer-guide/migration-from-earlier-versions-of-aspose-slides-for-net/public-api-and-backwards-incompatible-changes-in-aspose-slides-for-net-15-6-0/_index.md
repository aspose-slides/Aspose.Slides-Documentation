---
title: Aspose.Slides for .NET 15.6.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- माइग्रेशन
- पुराना कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रेज़ेंटेशन समाधान को सहजता से माइग्रेट करें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) क्लासेज, मेथड्स, प्रॉपर्टीज़ आदि की सूची प्रस्तुत करता है, और Aspose.Slides for .NET 15.6.0 API में प्रस्तुत किए गए अन्य परिवर्तन।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **DataLabel कन्स्ट्रक्टर सिग्नेचर बदल दिया गया है**
DataLabel कन्स्ट्रक्टर सिग्नेचर बदल दिया गया है:
पहले: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
अब: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **सदस्य IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) को अप्रचलित चिह्नित किया गया है और इनके स्थान पर नए विकल्प पेश किए गए हैं।**
IDocumentProperties.Count प्रॉपर्टी और मेथड्स IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) को अप्रचलित चिह्नित किया गया है। इसके बजाय IDocumentProperties.CountOfCustomProperties प्रॉपर्टी और मेथड्स IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) जोड़े गए हैं।
#### **Method INotesSlideManager.RemoveNotesSlide() जोड़ा गया है**
कुछ स्लाइड की नोट्स स्लाइड को हटाने के लिए Method INotesSlideManager.RemoveNotesSlide() जोड़ा गया है।
#### **Method Remove IComment में जोड़ा गया है**
कलेक्शन से टिप्पणी हटाने के लिए Method IComment.Remove जोड़ा गया है।
#### **Method Remove ICommentAuthor में जोड़ा गया है**
कलेक्शन से टिप्पणी लेखकों को हटाने के लिए Method ICommentAuthor.Remove जोड़ा गया है।
#### **IDocumentProperties में Methods ClearCustomProperties और ClearBuiltInProperties जोड़े गए हैं**
सभी कस्टम दस्तावेज़ प्रॉपर्टीज़ को हटाने के लिए Method IDocumentProperties.ClearCustomProperties जोड़ा गया है।
सभी बिल्ट-इन दस्तावेज़ प्रॉपर्टीज़ (Company, Subject, Author आदि) को हटाने और डिफॉल्ट मान सेट करने के लिए Method IDocumentProperties.ClearBuiltInProperties जोड़ा गया है।
#### **ICommentAuthorCollection में Methods RemoveAt, Remove और Clear जोड़े गए हैं**
निर्दिष्ट इंडेक्स द्वारा लेखक को हटाने के लिए Method ICommentAuthorCollection.RemoveAt जोड़ा गया है।
कलेक्शन से निर्दिष्ट लेखक को हटाने के लिए Method ICommentAuthorCollection.Remove जोड़ा गया है।
कलेक्शन से सभी आइटम हटाने के लिए Method ICommentAuthorCollection.Clear जोड़ा गया है।
#### **IDocumentProperties में Property AppVersion जोड़ा गया है**
Microsoft द्वारा विकास के दौरान उपयोग किए गए आंतरिक संस्करण नंबरों को दर्शाने वाली बिल्ट-इन दस्तावेज़ प्रॉपर्टी प्राप्त करने के लिए Property IDocumentProperties.AppVersion जोड़ा गया है।
#### **IShape और Shape में Property BlackWhiteMode जोड़ा गया है**
Property BlackWhiteMode को IShape और Shape में जोड़ा गया है।

यह प्रॉपर्टी दर्शाती है कि कोई शैप ब्लैक-एंड-व्हाइट डिस्प्ले मोड में कैसे रेंडर होगा।

|**मान** |**अर्थ** |
| :- | :- |
|Color |सामान्य रंगिंग के साथ रेंडर |
|Automatic |स्वचालित रंगिंग के साथ रेंडर |
|Gray |स्लेट रंग में रेंडर |
|LightGray |हल्के स्लेट रंग में रेंडर |
|InverseGray |उल्टे स्लेट रंग में रेंडर |
|GrayWhite |स्लेट और सफेद रंग में रेंडर |
|BlackGray |काले और स्लेट रंग में रेंडर |
|BlackWhite |काले और सफेद रंग में रेंडर |
|Black |केवल काले रंग में रेंडर |
|White |सफ़ेद रंग में रेंडर |
|Hidden |रेंडर नहीं किया जाता |
|NotDefined|का अर्थ है कि प्रॉपर्टी सेट नहीं है|
#### **प्रॉपर्टी ISlide.NotesSlideManager जोड़ी गई है। प्रॉपर्टी ISlide.NotesSlide और मेथड ISlide.AddNotesSlide() को अप्रचलित चिह्नित किया गया है।**
ISlide.NotesSlide, ISlide.AddNotesSlide() सदस्य को अप्रचलित (Obsolete) चिह्नित किया गया है। इसके बजाय नई प्रॉपर्टी ISlide.NotesSlideManager का उपयोग करें।

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - अप्रचलित

// notes = slide.NotesSlide; - अप्रचलित

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```