---
title: .NET में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 70
url: /hi/net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षित रखें
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

Aspose.Slides for .NET का एक सामान्य उपयोग स्वचालित वर्कफ़्लो के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता ये प्रस्तुतियाँ प्राप्त करते हैं, तो आकारों में किए जाने वाले बदलावों को प्रतिबंधित करने से वांछित लेआउट और सामग्री संरक्षित रखी जा सकती है।

यह लेख बताता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटक शामिल होते हैं। Aspose.Slides for .NET में स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा प्रस्तुत किया जाता है जो [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में प्राप्त होता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प उजागर करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for .NET निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) ऑटोशेप को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) कनेक्टर आकार को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) समूह आकार को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन संचालन को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज‑स्तर लेखन सुरक्षा अलग‑अलग [presentation protection settings](/slides/hi/net/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for .NET आकारों के साथ काम करने के लिये [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

यह उदाहरण ऑटोशेप के लिये [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) और [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) को `true` सेट करता है, तथा समूह आकार, कनेक्टर और चित्र फ्रेम के लिये समकक्ष लॉक लागू करता है। कनेक्टर गति के लिये [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) का उपयोग करता है; समूह भी ग्रुपिंग को प्रतिबंधित करने के लिये [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) का उपयोग करता है।

यह उदाहरण मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रह जाते हैं। लूप समूह के भीतर के चाइल्ड आकारों को नहीं पार करता।

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

### **सुरक्षा हटाएँ**

एक आकार लॉक को हटाने के लिये, उसके मान को `false` सेट करें। नीचे दिया गया उदाहरण आकार लॉक के साथ एक प्रस्तुति को लोड करता है और चयन, गति और आकार बदलने की प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) और [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) के ज़रिए साफ़ करता है। यह साथ ही [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) को भी साफ़ करता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र कटिंग को संरक्षित रखें**

कार्यशील निर्देशिका में `photo.jpg` नाम की एक फ़ोटो रखें। यह उदाहरण बाएँ से 12 % और दाएँ से 8 % काटता है, फिर चित्र फ्रेम पर [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) सेट करता है। यह फ़्लैग आगे की कटिंग को प्रतिबंधित करता है और मौजूदा कट को संरक्षित रखता है।

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

`PictureLocked.pptx` में कट लॉक को `true` के रूप में संग्रहीत किया गया है। PowerPoint में, फोटो चुनने पर **Crop** कमांड निष्क्रिय हो जाती है।

### **डायग्राम को ग्रुप्ड रखें**

यह उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह पर स्वयं [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) सेट करता है ताकि डायग्राम के घटक साथ रहें। समूह को स्थानांतरित करने या किसी घटक के फ़िल को बदलने जैसी अन्य संपादनों की अनुमति रहती है।

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

`DiagramLocked.pptx` में अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत किया गया है। PowerPoint में, पूरी डायग्राम चुनने पर **Ungroup** कमांड निष्क्रिय हो जाता है।

### **मौजूदा आकार लॉक की रिपोर्ट करें**

एक टेम्पलेट की समीक्षा करने के लिये, उसे खोलें और प्रत्येक आकार के लॉक ऑब्जेक्ट को पढ़ें। सभी फ़्लैग निष्क्रिय होने पर [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) `true` होता है और कम से कम एक फ़्लैग सक्रिय होने पर `false`। एक समूह और उसके बच्चों के पास अलग‑अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह के पास कोई लॉक न होने पर भी बच्चों की जाँच करें।

यह उदाहरण ऑटोशेप, चित्र फ्रेम और समूहों की गति, चित्रों की कटिंग और समूहों की अनग्रुपिंग की जाँच करता है। यह पहचाने गए फ़्लैग को रिपोर्ट करता है और उन आकार प्रकारों को चिह्नित करता है जिन्हें यह निरीक्षण नहीं करता।

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसमें अनग्रुपिंग लॉक है, उसके भीतर `Photo` नाम की एक तस्वीर है जिसमें क्रॉप लॉक है, और `Free` नाम का एक अनलॉक्ड आयत है। रिपोर्ट `Free` को छोड़ देती है और निम्न दो पंक्तियाँ प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहीत आकार‑स्तर संपादन फ़्लैग को बिना बदलें या प्रस्तुति सहेजे पढ़ती है। दस्तावेज‑स्तर लेखन सुरक्षा एक अलग सेटिंग है, और प्रत्येक फ़्लैग का प्रवर्तन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for .NET आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या कई स्लाइडों में समान प्रतिबंध लागू करने की सुविधा देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको प्रतिबंध हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने पर प्रतिबंध लगा सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं कुछ विशिष्ट स्लाइडों पर ही संपादन प्रतिबंध लगाकर बाकी स्लाइडों को प्रभावित नहीं कर सकता?**

हाँ। केवल चयनित स्लाइडों पर आकार लॉक लागू करें। इससे अन्य स्लाइडों की लॉक सेटिंग्स अपरिवर्तित रहती हैं।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह पर इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिये भी यही प्रक्रिया दोहराएँ, जैसा कि रिपोर्टिंग उदाहरण में वर्णित है।