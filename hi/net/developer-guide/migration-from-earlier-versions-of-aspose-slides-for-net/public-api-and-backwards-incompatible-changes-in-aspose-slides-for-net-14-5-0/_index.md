---
title: Aspose.Slides for .NET 14.5.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- प्रवासन
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 
यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, साथ ही नए [पाबंदियों](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) और अन्य [बदलाव](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) को Aspose.Slides for .NET 14.5.0 API के साथ प्रस्तुत करता है।
{{% /alert %}} 
## **सार्वजनिक API और बैकवर्ड असंगत परिवर्तन**
### **जोड़ी गई इंटरफ़ेस, क्लास, प्रॉपर्टी और मेथड**
#### **Aspose.Slides.IPresentationInfo इंटरफ़ेस और PresentationInfo क्लास को जोड़ा गया**
प्रेज़ेंटेशन के बारे में जानकारी का प्रतिनिधित्व करता है।

- Boolean प्रॉपर्टी IsEncrypted True लौटाता है यदि प्रेज़ेंटेशन एन्क्रिप्टेड है, अन्यथा False।
- प्रॉपर्टी LoadFormat प्रकार का LoadFormat प्रेज़ेंटेशन का प्रकार दर्शाता है।
#### **Aspose.Slides.IShape.IsGrouped प्रॉपर्टी को जोड़ा गया**
प्रॉपर्टी Aspose.Slides.IShape.IsGrouped यह निर्धारित करती है कि शेप समूहित है या नहीं।
#### **Aspose.Slides.IShape.ParentGroup प्रॉपर्टी को जोड़ा गया**
प्रॉपर्टी Aspose.Slides.IShape.ParentGroup यदि शेप समूहित है तो पैरेंट GroupShape ऑब्जेक्ट लौटाता है। अन्यथा null लौटाता है।
#### **Aspose.Slides.IShapeCollection.AddGroupShape() मेथड को जोड़ा गया**
मेथड Aspose.Slides.IShapeCollection.AddGroupShape() नया GroupShape बनाता है और इसे कलेक्शन के अंत में जोड़ता है। नया शेप जोड़े जाने पर GroupShape का फ्रेम आकार और स्थिति कंटेंट के अनुसार फिट हो जाएगी।
#### **Aspose.Slides.IShapeCollection.Clear() मेथड को जोड़ा गया**
मेथड Aspose.Slides.IShapeCollection.Clear() कलेक्शन से सभी शेप हटाता है।
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) मेथड को जोड़ा गया**
मेथड Aspose.Slides.IShapeCollection.InsertGroupShape(int) नया GroupShape बनाता है और निर्दिष्ट इंडेक्स स्थान पर कलेक्शन में सम्मिलित करता है। नया शेप जोड़ते समय GroupShape का फ्रेम आकार और स्थिति कंटेंट के अनुसार फिट हो जाएगी।
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream) मेथड को जोड़ा गया**
इन मेथड्स से प्रेज़ेंटेशन फ़ाइल या स्ट्रीम की जानकारी बिना पूर्ण लोड किए प्राप्त की जा सकती है।
#### **IPresentationFactory PresentationFactory.Instance प्रॉपर्टी को जोड़ा गया**
यह प्रॉपर्टी डेवलपर्स को फैक्ट्री फ़ंक्शनैलिटी का उपयोग इंस्टैंसिएशन के बिना करने देती है।
### **पाबंदियाँ**
#### **IShape.Frame पर पाबंदियाँ**
IShape.Frame के लिए अनिर्दिष्ट मानों के उपयोग पर पाबंदियाँ जोड़ी गई हैं। कोड जो IShape.Frame को अनिर्दिष्ट फ्रेम असाइन करने की कोशिश करता है, अधिकांश मामलों में अर्थ नहीं रखता (विशेषकर जब पैरेंट GroupShape कई स्तरों में नेस्टेड हो)। उदाहरण:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// ArgumentException फेंकता है: फ्रेम मान निर्धारित होने चाहिए।
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

या

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// ArgumentException फेंकता है: x, y, width और height निर्धारित होने चाहिए।
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

ऐसा कोड अस्पष्ट स्थितियों को जन्म दे सकता है। इसलिए IShape.Frame के अनिर्दिष्ट मानों के उपयोग पर पाबंदियाँ लागू की गई हैं। x, y, width, height, flipH, flipV और rotationAngle के मान निर्धारित होने चाहिए (और float.NaN या NullableBool.NotDefined पर सेट नहीं होने चाहिए)। ऊपर दिया गया उदाहरण कोड अब ArgumentException उत्पन्न करेगा। यह निम्न उपयोग मामलों पर लागू होती हैं:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x, y, width और height पैरामीटर float.NaN नहीं हो सकते, और flipH, flipV
// NullableBool.NotDefined नहीं हो सकते:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// वही प्रतिबंध उन सभी विधियों पर लागू होता है जो एक शेप बनाती हैं:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

हालांकि IShape.RawFrame फ्रेम प्रॉपर्टीज़ अनिर्दिष्ट हो सकती हैं। यह तब समझ में आता है जब शेप किसी प्लेसहोल्डर से बंधा हो। तब अनिर्दिष्ट शेप फ्रेम मान पैरेंट प्लेसहोल्डर शेप से ओवरराइड हो जाते हैं। यदि कोई पैरेंट प्लेसहोल्डर शेप नहीं है, तो शेप अपने IShape.RawFrame के आधार पर प्रभावी फ्रेम का मूल्यांकन करते समय डिफ़ॉल्ट मान उपयोग करता है। डिफ़ॉल्ट मान x, y, width, height, flipH, flipV और rotationAngle के लिए क्रमशः 0 और NullableBool.False होते हैं। उदाहरण:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // शेप एक प्लेसहोल्डर से जुड़ा है
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // अब शेप प्लेसहोल्डर से x, y, height, flipH, flipV मान विरासत में लेता है और width=100 तथा rotationAngle=0 को ओवरराइड करता है।
}
``` 
### **बदले हुए प्रॉपर्टी**
#### **Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का नाम और प्रकार बदला गया**
- Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का प्रकार ISlideComponent से बदलकर नया IGroupShape इंटरफ़ेस किया गया है। IGroupShape इंटरफ़ेस ISlideComponent का वंशज है इसलिए मौजूदा कोड को कोई अनुकूलन नहीं चाहिए।
- Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का नाम Parent से बदलकर ParentGroup किया गया है।
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV प्रॉपर्टी के प्रकार बदल गए**
- Aspose.Slides.IShapeFrame.FlipH प्रॉपर्टी का प्रकार bool से NullableBool में बदला गया है।
- IShape.Frame प्रॉपर्टी एक प्रभावी IShapeFrame इंस्टेंस लौटाती है (जिसकी सभी प्रॉपर्टीज़ के प्रभावी मान परिभाषित होते हैं)।
- IShape.RawFrame प्रॉपर्टी एक IShapeFrame इंस्टेंस लौटाती है जिसमें प्रत्येक प्रॉपर्टी अनिर्दिष्ट हो सकती है (विशेषकर FlipH या FlipV का मान NullableBool.NotDefined हो सकता है)।