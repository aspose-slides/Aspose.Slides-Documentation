---
title: Aspose.Slides for .NET 14.4.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तनों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
## **सार्वजनिक API और बैकवर्ड असंगत परिवर्तन**
### **जोड़े गए इंटरफ़ेस, क्लासेस, मेथड्स और प्रॉपर्टीज़**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides प्रॉपर्टी जोड़ी गई है**
प्रॉपर्टी Aspose.Slides.ILayoutSlide.HasDependingSlides true लौटाती है यदि कम से कम एक स्लाइड इस लेआउट स्लाइड पर निर्भर करता है। उदाहरण के लिए:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() मेथड**
मेथड Aspose.Slides.ILayoutSlide.Remove() आपको न्यूनतम कोड के साथ प्रस्तुति से एक लेआउट हटाने की अनुमति देता है। उदाहरण के लिए:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) मेथड**
मेथड Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) आपको संग्रह से एक लेआउट हटाने की अनुमति देता है। कोड उदाहरण:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

या

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
मेथड Aspose.Slides.ILayoutSlideCollection.RemoveUnused() आपको अनउपयोगित लेआउट स्लाइड्स (जिनकी HasDependingSlides false है) हटाने की अनुमति देता है। कोड उदाहरण:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

या

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides प्रॉपर्टी**
प्रॉपर्टी Aspose.Slides.IMasterSlide.HasDependingSlides true लौटाती है यदि कम से कम एक स्लाइड इस मास्टर स्लाइड पर निर्भर करता है। उदाहरण के लिए:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() मेथड**
मेथड Aspose.Slides.ISlide.Remove() आपको न्यूनतम कोड के साथ प्रस्तुति से एक स्लाइड हटाने की अनुमति देता है। उदाहरण के लिए:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
प्रॉपर्टी Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat लेआउट बुलेट प्रदान करने पर SmartArt नोड बुलेट के लिए IFillFormat लौटाती है। इसे बुलेट इमेज सेट करने के लिए उपयोग किया जा सकता है।

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level प्रॉपर्टी**
प्रॉपर्टी Aspose.Slides.SmartArt.ISmartArtNode.Level SmartArt नोड्स के लिए नेस्टेड लेवल लौटाती है।

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position प्रॉपर्टी**
प्रॉपर्टी Aspose.Slides.SmartArt.ISmartArtNode.Position अपने भाई‑बहनों के बीच नोड की स्थिति लौटाती है।

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() मेथड जोड़ी गई है**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() मेथड एक डायग्राम से नोड हटाने की अनुमति देता है।

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection इंटरफ़ेस और GlobalLayoutSlideCollection क्लास**
IGlobalLayoutSlideCollection इंटरफ़ेस और GlobalLayoutSlideCollection क्लास को Aspose.Slides नेमस्पेस में जोड़ा गया है।

GlobalLayoutSlideCollection क्लास IGlobalLayoutSlideCollection इंटरफ़ेस को इम्प्लीमेंट करती है।

IGlobalLayoutSlideCollection इंटरफ़ेस प्रस्तुति में सभी लेआउट स्लाइड्स का संग्रह दर्शाता है। IPresentation.LayoutSlides प्रॉपर्टी का प्रकार IGlobalLayoutSlideCollection है। IGlobalLayoutSlideCollection, ILayoutSlideCollection इंटरफ़ेस को विस्तारित करता है जिसमें व्यक्तिगत मास्टर लेआउट स्लाइड्स के संग्रह को जोड़ने और क्लोन करने के मेथड शामिल हैं:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – इसे उपयोग किया जा सकता है ताकि निर्दिष्ट लेआउट स्लाइड की एक प्रति प्रस्तुति में जोड़ी जा सके। यह मेथड स्रोत फ़ॉर्मेटिंग को बरकरार रखता है (जब विभिन्न प्रस्तुतियों के बीच लेआउट को क्लोन किया जाता है, तो लेआउट का मास्टर भी क्लोन हो सकता है। आंतरिक रेजिस्ट्रि का उपयोग स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करने के लिए किया जाता है ताकि समान मास्टर स्लाइड की कई क्लोन बनने से बचा जा सके।)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – इसे उपयोग किया जाता है ताकि निर्दिष्ट लेआउट स्लाइड की एक प्रति प्रस्तुति में जोड़ी जा सके। नई लेआउट लक्ष्य प्रस्तुति में परिभाषित मास्टर से लिंक होगी। यह विकल्प Microsoft PowerPoint में **Use Destination Theme** विकल्प के साथ कॉपी या पेस्ट करने के समकक्ष है।
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – इसे उपयोग किया जाता है ताकि प्रस्तुति में एक नई लेआउट स्लाइड जोड़ी जा सके। समर्थित लेआउट टाइप्स: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom। लेआउट नाम स्वतः उत्पन्न किया जा सकता है। SlideLayoutType.Custom प्रकार की जोड़ी गई लेआउट में कोई प्लेसहोल्डर या आकार नहीं होते। इस मेथड का समकक्ष IMasterSlide.LayoutSlides प्रॉपर्टी के माध्यम से पहुँचा जाता है: IMasterLayoutSlideCollection.Add(SlideLayoutType, string)।

#### **Interface IMasterLayoutSlideCollection और Class MasterLayoutSlideCollection**
IMasterLayoutSlideCollection इंटरफ़ेस और MasterLayoutSlideCollection क्लास को Aspose.Slides नेमस्पेस में जोड़ा गया है। MasterLayoutSlideCollection क्लास IMasterLayoutSlideCollection इंटरफ़ेस को इम्प्लीमेंट करती है।

IMasterLayoutSlideCollection इंटरफ़ेस परिभाषित मास्टर स्लाइड के सभी लेआउट स्लाइड्स के संग्रह का प्रतिनिधित्व करता है। यह ILayoutSlideCollection इंटरफ़ेस को विस्तारित करता है जिसमें व्यक्तिगत मास्टर लेआउट स्लाइड्स के संग्रह के संदर्भ में जोड़ने, इनसर्ट करने, हटाने या क्लोन करने के मेथड शामिल हैं:

``` csharp

 // मेथड सिग्नेचर:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// कोड उदाहरण जो sourceLayout की प्रति को destMasterSlide से जोड़ता है:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

यह मेथड निर्दिष्ट लेआउट स्लाइड की एक प्रति संग्रह के अंत में जोड़ने के लिए उपयोग किया जा सकता है। नई लेआउट इस लेआउट स्लाइड्स संग्रह के पैरेंट मास्टर स्लाइड से लिंक होगी। इसलिए यह PowerPoint में **Use Destination Theme** विकल्प के साथ कॉपी या पेस्ट करने के समकक्ष है। इस मेथड का समकक्ष IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) मेथड है जिसे IPresentation.LayoutSlides प्रॉपर्टी के माध्यम से पहुँचा जाता है।

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – इसे उपयोग किया जाता है ताकि निर्दिष्ट लेआउट स्लाइड की एक प्रति संग्रह के निर्दिष्ट स्थान पर डाली जा सके। नई लेआउट इस लेआउट स्लाइड्स संग्रह के पैरेंट मास्टर स्लाइड से लिंक होगी। इसलिए यह PowerPoint में **Use Destination Theme** विकल्प के साथ कॉपी और पेस्ट करने के समकक्ष है।
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – इसे उपयोग किया जाता है ताकि नई लेआउट स्लाइड जोड़ी या इनसर्ट की जा सके। समर्थित लेआउट टाइप्स: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom। लेआउट नाम स्वतः उत्पन्न किया जा सकता है। SlideLayoutType.Custom प्रकार की जोड़ी गई लेआउट में कोई प्लेसहोल्डर या आकार नहीं होते। इस मेथड का समकक्ष IPresentation.LayoutSlides प्रॉपर्टी के माध्यम से पहुँचा जाने वाला IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) मेथड है।
- void RemoveAt(int index); – इसे उपयोग किया जाता है ताकि संग्रह में निर्दिष्ट इंडेक्स पर लेआउट हटाया जा सके।
- void Reorder(int index, ILayoutSlide layoutSlide); – इसे उपयोग किया जाता है ताकि लेआउट स्लाइड को संग्रह में निर्दिष्ट स्थान पर ले जाया जा सके।
### **बदलाव वाले मेथड्स और प्रॉपर्टीज़**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) मेथड का सिग्नेचर**
ISlideCollection मेथड का सिग्नेचर:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

अब यह अप्रचलित है और निम्न सिग्नेचर से बदल दिया गया है

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout पैरामीटर यह निर्धारित करता है कि यदि destMaster में नई (क्लोन की गई) स्लाइड के लिये उपयुक्त लेआउट नहीं है तो क्या किया जाए। उपयुक्त लेआउट वह लेआउट है जिसका टाइप या नाम स्रोत स्लाइड के लेआउट के समान हो। यदि निर्दिष्ट मास्टर में उपयुक्त लेआउट नहीं है तो स्रोत स्लाइड का लेआउट क्लोन किया जाएगा (यदि allowCloneMissingLayout true है) या PptxEditException फेंका जाएगा (यदि allowCloneMissingLayout false है)।

अप्रचलित मेथड को इस तरह कॉल किया जाता था

AddClone(sourceSlide, destMaster);

मान लेता है कि allowCloneMissingLayout false है (अर्थात यदि उपयुक्त लेआउट नहीं है तो PptxEditException फेंका जाएगा)। नया सिग्नेचर उपयोग करने वाला समान कार्यात्मक कॉल इस प्रकार है:
AddClone(sourceSlide, destMaster, false);

यदि आप चाहते हैं कि अनुपलब्ध लेआउट्स स्वचालित रूप से क्लोन हो जाएँ और PptxEditException न फेंकेँ तो allowCloneMissingLayout पैरामीटर को true पास करें।

इसी प्रकार का परिवर्तन ISlideCollection मेथड पर भी लागू होता है:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

अब यह भी अप्रचलित है और निम्न सिग्नेचर से बदल दिया गया है

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides प्रॉपर्टी का टाइप**
Aspose.Slides.IMasterSlide.LayoutSlides प्रॉपर्टी का टाइप ILayoutSlideCollection से बदल कर नया IMasterLayoutSlideCollection इंटरफ़ेस किया गया है। IMasterLayoutSlideCollection इंटरफ़ेस ILayoutSlideCollection का वंशज है इसलिए मौजूदा कोड को कोई अनुकूलन करने की आवश्यकता नहीं है।
#### **Aspose.Slides.IPresentation.LayoutSlides प्रॉपर्टी का टाइप बदल दिया गया है**
Aspose.Slides.IPresentation.LayoutSlides प्रॉपर्टी का टाइप ILayoutSlideCollection से बदल कर नया IGlobalLayoutSlideCollection इंटरफ़ेस किया गया है। IGlobalLayoutSlideCollection इंटरफ़ेस ILayoutSlideCollection का वंशज है इसलिए मौजूदा कोड को कोई अनुकूलन करने की आवश्यकता नहीं है।