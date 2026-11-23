---
title: .NET में Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 70
url: /hi/net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से बचाव
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for .NET का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के भाग के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप, टेबल, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और प्रस्तुति बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटक होते हैं। Aspose.Slides for .NET में स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या ऐसी क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for .NET निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) autoshapes को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) समूह आकारों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

लॉक को एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) पर लागू करने के लिए, उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

अनुकूल प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तरीय लिखने की सुरक्षा अलग [presentation protection settings](/slides/hi/net/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for .NET स्लाइड पर आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोशेप के लिए [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) और [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) को `true` सेट किया गया है, तथा समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समान लॉक लागू किए गए हैं। कनेक्टर गति के लिए [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) का उपयोग करता है; समूहों के लिए भी समूह बनाना रोकने हेतु [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड के shape collection में आकारों की जाँच करता है, और इन प्रतिबंधों को लागू करके एक प्रति सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर की चाइल्ड आकारों को नहीं पार करता।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **सुरक्षा हटाना**

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्न उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसमें आकार लॉक हैं और [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) और [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) के माध्यम से चयन, गति और आकार बदलने की प्रतिबंधों को साफ़ करता है। यह [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) भी साफ़ करता है और प्रस्तुति की एक प्रति सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **चित्र क्रॉप को संरक्षित करें**

कार्यशील निर्देशिका में `photo.jpg` नाम की फ़ाइल रखें। उदाहरण बाएँ से 12 % और दाएँ से 8 % क्रॉप करता है, फिर चित्र फ्रेम पर [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) सेट करता है। यह फ़्लैग आगे के क्रॉप को प्रतिबंधित करता है और मौजूदा क्रॉप को संरक्षित रखता है।

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में फोटो चयनित होने पर **Crop** कमांड अक्षम हो जाता है।

### **डायग्राम को ग्रुपेड रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह पर [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) सेट करता है ताकि डायग्राम के घटक साथ रहें। समूह को स्थानांतरित करना या घटक के फ़िल को बदलना जैसी अन्य संपादन अभी भी उपलब्ध रहती हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में पूरी डायग्राम चयनित होने पर **Ungroup** कमांड अक्षम हो जाता है।

### **निष्कर्ष**

Aspose.Slides for .NET आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स के across समान प्रतिबंधों को लागू करने की सुविधा देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको प्रतिबंध हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करता है, जबकि [password protection](/slides/hi/net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने पर प्रतिबंध लगा सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हां। केवल चयनित स्लाइड्स पर आकारों के लॉक लागू करें। इससे अन्य स्लाइड्स की लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह के [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह पर इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही प्रक्रिया दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के shape collection को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक नहीं सेट करते।