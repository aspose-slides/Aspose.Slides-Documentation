---
title: Aspose.Slides for .NET 14.5.0 में सार्वजनिक API और पिछड़ी असंगत परिवर्तन
linktitle: Aspose.Slides के लिए .NET 14.5.0
type: docs
weight: 70
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- स्थानांतरण
- पारंपरिक कोड
- आधुनिक कोड
- पारंपरिक दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) क्लास, मेथड, प्रॉपर्टी आदि, साथ ही नई [restrictions](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) और अन्य [changes](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) को Aspose.Slides for .NET 14.5.0 API में प्रस्तुत किए गए को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API और पिछड़ी असंगत परिवर्तन**
### **जोड़े गए इंटरफ़ेस, क्लास, प्रॉपर्टी और मेथड**
#### **Aspose.Slides.IPresentationInfo इंटरफ़ेस और PresentationInfo क्लास जोड़ी गई**
प्रेजेंटेशन के बारे में जानकारी दर्शाता है।

- Boolean प्रॉपर्टी IsEncrypted प्रेजेंटेशन एन्क्रिप्टेड होने पर True लौटाती है, अन्यथा False।
- प्रॉपर्टी LoadFormat प्रस्तुति का प्रकार प्राप्त करती है।
#### **Aspose.Slides.IShape.IsGrouped प्रॉपर्टी जोड़ी गई**
प्रॉपर्टी Aspose.Slides.IShape.IsGrouped निर्धारित करती है कि कोई आकार समूहित है या नहीं।
#### **Aspose.Slides.IShape.ParentGroup प्रॉपर्टी जोड़ी गई**
प्रॉपर्टी Aspose.Slides.IShape.ParentGroup समूहित आकार होने पर पैरेंट GroupShape ऑब्जेक्ट लौटाती है। अन्यथा null लौटाती है।
#### **Aspose.Slides.IShapeCollection.AddGroupShape() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.AddGroupShape() एक नया GroupShape बनाता है और उसे संग्रह के अंत में जोड़ता है।
जब नया आकार जोड़ा जाता है तो GroupShape फ्रेम का आकार और स्थिति सामग्री के अनुसार समायोजित हो जाएगी।
#### **Aspose.Slides.IShapeCollection.Clear() मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.Clear() संग्रह से सभी आकारों को हटा देता है।
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) मेथड जोड़ी गई**
मेथड Aspose.Slides.IShapeCollection.InsertGroupShape(int) एक नया GroupShape बनाता है और उसे निर्दिष्ट इंडेक्स स्थिति पर संग्रह में डालता है।
जब नया आकार जोड़ा जाता है तो GroupShape फ्रेम का आकार और स्थिति सामग्री के अनुसार समायोजित हो जाएगी।
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) मेथड जोड़े गए**
ये मेथड प्रेजेंटेशन फ़ाइल या स्ट्रीम की जानकारी पूर्ण रूप से लोड किए बिना प्राप्त करने की अनुमति देते हैं।
#### **IPresentationFactory PresentationFactory.Instance प्रॉपर्टी जोड़ी गई**
यह प्रॉपर्टी डेवलपर्स को फैक्टरी कार्यक्षमता को इंस्टांटिएट किए बिना उपयोग करने देती है।
### **प्रतिबंध**
#### **IShape.Frame पर प्रतिबंध**
IShape.Frame के लिए अपरिभाषित मानों के उपयोग पर प्रतिबंध जोड़े गए हैं। कोड जो IShape.Frame को अपरिभाषित फ्रेम असाइन करने की कोशिश करता है, अधिकांश मामलों में अर्थहीन है (विशेष रूप से जब पैरेंट GroupShape कई अन्य {{GroupShape}}s में नेस्टेड हो)। उदाहरण के लिए:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

या

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

ऐसा कोड अस्पष्ट स्थितियों का कारण बन सकता है। इसलिए IShape.Frame के लिए अपरिभाषित मानों के उपयोग पर प्रतिबंध जोड़े गए हैं। x, y, width, height, flipH, flipV और rotationAngle के मान परिभाषित होने चाहिए (और float.NaN या NullableBool.NotDefined पर सेट नहीं होने चाहिए)। ऊपर दिया गया उदाहरण कोड अब ArgumentException अपवाद फेंकेगा।
यह इन उपयोग मामलों पर लागू होता है:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // अपरिभाषित नहीं हो सकता

IShapeCollection shapes = ...;

// x, y, चौड़ाई, ऊंचाई पैरामीटर float.NaN नहीं हो सकते:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

लेकिन IShape.RawFrame फ्रेम प्रॉपर्टी अपरिभाषित हो सकती हैं। यह तब समझ में आता है जब कोई आकार प्लेसहोल्डर से जुड़ा होता है। तब अपरिभाषित आकार फ्रेम मान पैरेंट प्लेसहोल्डर आकार से ओवरराइड हो जाते हैं। यदि कोई पैरेंट प्लेसहोल्डर आकार नहीं है, तो वह आकार अपने IShape.RawFrame के आधार पर प्रभावी फ्रेम का मूल्यांकन करते समय डिफ़ॉल्ट मानों का उपयोग करता है। डिफ़ॉल्ट मान x, y, width, height, flipH, flipV और rotationAngle के लिए 0 और NullableBool.False होते हैं। उदाहरण के लिए:

``` csharp

 IShape shape = ...; // shape placeholder से जुड़ा हुआ है
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// अब shape placeholder से x, y, height, flipH, flipV मान विरासत में लेता है और width=100 और rotationAngle=0 को ओवरराइड करता है।

``` 
### **बदले हुए प्रॉपर्टी**
#### **Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का नाम और प्रकार बदला गया**
- Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का प्रकार ISlideComponent से बदलकर नया IGroupShape इंटरफ़ेस किया गया है। IGroupShape इंटरफ़ेस ISlideComponent का वंशज है इसलिए मौजूदा कोड को कोई संशोधन करने की आवश्यकता नहीं है।
- Aspose.Slides.IShapeCollection.Parent प्रॉपर्टी का नाम Parent से बदलकर ParentGroup कर दिया गया है।
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV प्रॉपर्टी प्रकार बदले गए**
- Aspose.Slides.IShapeFrame.FlipH प्रॉपर्टी का प्रकार bool से बदलकर NullableBool किया गया है।
- IShape.Frame प्रॉपर्टी एक प्रभावी IShapeFrame इंस्टेंस लौटाती है (जिसकी सभी प्रॉपर्टी परिभाषित प्रभावी मान रखती हैं)।
- IShape.RawFrame प्रॉपर्टी एक IShapeFrame इंस्टेंस लौटाती है जिसमें प्रत्येक प्रॉपर्टी का मान अपरिभाषित हो सकता है (विशेषकर FlipH या FlipV का मान NullableBool.NotDefined हो सकता है)।