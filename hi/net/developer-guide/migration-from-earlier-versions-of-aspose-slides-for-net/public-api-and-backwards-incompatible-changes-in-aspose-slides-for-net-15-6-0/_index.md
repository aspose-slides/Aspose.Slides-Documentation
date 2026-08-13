---
title: Aspose.Slides for .NET 15.6.0 में सार्वजनिक API और अनुकूलन के लिए असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- स्थलांतर
- पारम्परिक कोड
- आधुनिक कोड
- पारम्परिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और टूटने वाले परिवर्तनों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से स्थानांतरित करें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) क्लास, मेथड, प्रॉपर्टी आदि तथा Aspose.Slides for .NET 15.6.0 API के साथ प्रस्तुत किए गए अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **DataLabel कंस्ट्रक्टर सिग्नेचर बदल दिया गया है**
DataLabel कंस्ट्रक्टर सिग्नेचर बदल दिया गया है:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **सदस्य IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) को अप्रचलित चिह्नित किया गया है और उनके स्थानापन्न पेश किए गए हैं।**
Property IDocumentProperties.Count और मेथड्स IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) को अप्रचलित चिह्नित किया गया है। Property IDocumentProperties.CountOfCustomProperties और मेथड्स IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) को इसके बजाय जोड़ा गया है।
#### **मेथड INotesSlideManager.RemoveNotesSlide() जोड़ा गया है**
मेथड INotesSlideManager.RemoveNotesSlide() कुछ स्लाइड की नोट्स स्लाइड को हटाने के लिए जोड़ा गया है।
#### **मेथड Remove को IComment में जोड़ा गया है**
मेथड IComment.Remove संग्रह से टिप्पणी को हटाने के लिए जोड़ा गया है।
#### **मेथड Remove को ICommentAuthor में जोड़ा गया है**
मेथड ICommentAuthor.Remove संग्रह से टिप्पणी लेखकों को हटाने के लिए जोड़ा गया है।
#### **मेथड्स ClearCustomProperties और ClearBuiltInProperties को IDocumentProperties में जोड़ा गया है**
मेथड IDocumentProperties.ClearCustomProperties सभी कस्टम दस्तावेज़ गुणों को हटाने के लिए जोड़ा गया है।
मेथड IDocumentProperties.ClearBuiltInProperties सभी अंतर्निहित दस्तावेज़ गुणों (Company, Subject, Author आदि) को हटाने और डिफॉल्ट मान सेट करने के लिए जोड़ा गया है।
#### **मेथड्स RemoveAt, Remove और Clear को ICommentAuthorCollection में जोड़ा गया है**
मेथड ICommentAuthorCollection.RemoveAt निर्दिष्ट इंडेक्स द्वारा लेखक को हटाने के लिए जोड़ा गया है।
मेथड ICommentAuthorCollection.Remove संग्रह से निर्दिष्ट लेखक को हटाने के लिए जोड़ा गया है।
मेथड ICommentAuthorCollection.Clear संग्रह से सभी आइटम हटाने के लिए जोड़ा गया है।
#### **प्रॉपर्टी AppVersion को IDocumentProperties में जोड़ा गया है**
प्रॉपर्टी IDocumentProperties.AppVersion को Microsoft द्वारा विकास के दौरान उपयोग किए जाने वाले आंतरिक संस्करण संख्याओं को दर्शाने वाले अंतर्निहित दस्तावेज़ गुण को प्राप्त करने के लिए जोड़ा गया है।
#### **प्रॉपर्टी BlackWhiteMode को IShape और Shape में जोड़ा गया है**
प्रॉपर्टी BlackWhiteMode को IShape और Shape में जोड़ा गया है।

यह प्रॉपर्टी निर्धारित करती है कि आकृति श्वेत-श्याम प्रदर्शन मोड में कैसे प्रदर्शित होगी।

|**मान**|**अर्थ**|
| :- | :- |
|रंग|साधारण रंगिंग के साथ रेंडर करें|
|स्वचालित|स्वचालित रंगिंग के साथ रेंडर करें|
|धूसर|धूसर रंगिंग के साथ रेंडर करें|
|हल्का धूसर|हल्का धूसर रंगिंग के साथ रेंडर करें|
|उलटा धूसर|उलटा धूसर रंगिंग के साथ रेंडर करें|
|धूसर-श्वेत|धूसर और श्वेत रंगिंग के साथ रेंडर करें|
|काला-धूसर|काला और धूसर रंगिंग के साथ रेंडर करें|
|काला-श्वेत|काला और श्वेत रंगिंग के साथ रेंडर करें|
|काला|केवल काली रंगिंग के साथ रेंडर करें|
|श्वेत|श्वेत रंगिंग के साथ रेंडर करें|
|छिपा हुआ|रेंडर नहीं करें|
|अपरिभाषित|मतलब कि प्रॉपर्टी सेट नहीं है|
#### **प्रॉपर्टी ISlide.NotesSlideManager जोड़ी गई है। प्रॉपर्टी ISlide.NotesSlide और मेथड ISlide.AddNotesSlide() को अप्रचलित चिह्नित किया गया है।**
ISlide.NotesSlide, ISlide.AddNotesSlide() सदस्यों को अप्रचलित चिह्नित किया गया है। इसके बजाय नई प्रॉपर्टी ISlide.NotesSlideManager का उपयोग करें।

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - अप्रचलित
    // notes = slide.NotesSlide; - अप्रचलित

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```