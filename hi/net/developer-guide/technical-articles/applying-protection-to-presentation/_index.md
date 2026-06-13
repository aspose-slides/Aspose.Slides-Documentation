---
title: शेप लॉक के साथ .NET में प्रेजेंटेशन संपादन को रोकें
linktitle: प्रेजेंटेशन संपादन को रोकें
type: docs
weight: 70
url: /hi/net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा करें
- शेप लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार लॉक करें
- समूहकरण लॉक करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "जानेँ कैसे Aspose.Slides for .NET PPT, PPTX और ODP फाइलों में शेप को लॉक या अनलॉक करता है, जिससे प्रस्तुतियों को सुरक्षित किया जाता है जबकि नियंत्रित संपादन की अनुमति मिलती है।"
---
## **पृष्ठभूमि**

Aspose.Slides का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में Microsoft PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। ऐसे अनुप्रयोगों के उपयोगकर्ताओं को निर्मित प्रस्तुतियों तक पहुंच मिलती है, इसलिए उन्हें संपादन से बचाना एक आम चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से उत्पन्न प्रस्तुतियों का मूल स्वरूप और सामग्री बना रहे।

यह लेख बताता है कि प्रस्तुतियों और स्लाइडों की संरचना कैसे होती है और Aspose.Slides for .NET कैसे एक प्रस्तुति पर सुरक्षा लागू कर सकता है और बाद में उसे हटा सकता है। यह डेवलपर्स को यह नियंत्रित करने का तरीका प्रदान करता है कि उनके अनुप्रयोग द्वारा निर्मित प्रस्तुतियों का उपयोग कैसे किया जाता है।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोग्राफ़िक आकार, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व शामिल होते हैं। Aspose.Slides for .NET में स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में मिलता है।

PPTX की संरचना जटिल है, इसलिए PPT की तरह सभी प्रकार के आकारों के लिए एक सामान्य लॉक नहीं लगाया जा सकता; विभिन्न आकार प्रकारों को अलग-अलग लॉक की आवश्यकता होती है। [IBaseShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseshapelock/) इंटरफ़ेस PPTX के लिए सामान्य लॉक क्लास है। Aspose.Slides for .NET में PPTX के लिए निम्नलिखित प्रकार के लॉक समर्थित हैं:

- [IAutoShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshapelock/) autoshapes को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/hi/net/aspose.slides/iconnectorlock/) connector shapes को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hi/net/aspose.slides/igraphicalobjectlock/) graphical objects को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshapelock/) group shapes को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/) picture frames को लॉक करता है।  

[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट में सभी shape ऑब्जेक्ट्स पर किया गया कोई भी कार्य पूरी प्रस्तुति पर लागू होता है।

## **सुरक्षा लागू करें और हटाएं**

सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रस्तुति को संपादित नहीं किया जा सकता। यह प्रस्तुति की सामग्री की रक्षा के लिए एक उपयोगी तकनीक है।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for .NET स्लाइड पर आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

जैसा कि पहले उल्लेख किया गया था, प्रत्येक shape वर्ग के लिए सुरक्षा हेतु एक संबंधित shape‑lock वर्ग उपलब्ध है। यह लेख NoSelect, NoMove और NoResize लॉक पर केंद्रित है। ये लॉक सुनिश्चित करते हैं कि आकारों को चयन (माउस क्लिक या अन्य विधियों से) नहीं किया जा सकता और न ही उन्हें स्थानांतरित या आकार बदल सके।

नीचे दिया गया कोड नमूना प्रस्तुति में सभी shape प्रकारों पर सुरक्षा लागू करता है।

```cs
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं.
using Presentation presentation = new Presentation("Sample.pptx");

// प्रेजेंटेशन की सभी स्लाइडों पर इटरशन करना.
foreach (ISlide slide in presentation.Slides)
{
    // स्लाइड में सभी आकारों के माध्यम से यात्रा करना.
    foreach (IShape shape in slide.Shapes)
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

// प्रेजेंटेशन फ़ाइल को सहेजना.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **सुरक्षा हटाएं**

एक shape को अनलॉक करने के लिए लागू लॉक के मान को `false` सेट करें। नीचे दिया गया कोड नमूना दिखाता है कि लॉक्ड प्रस्तुति में आकारों को कैसे अनलॉक किया जाए।

```cs
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// प्रेजेंटेशन की सभी स्लाइडों पर इटरशन करना.
foreach (ISlide slide in presentation.Slides)
{
    // स्लाइड में सभी आकारों के माध्यम से यात्रा करना.
    foreach (IShape shape in slide.Shapes)
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

// प्रेजेंटेशन फ़ाइल को सहेजना.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **निष्कर्ष**

Aspose.Slides प्रस्तुति में आकारों को सुरक्षित करने के कई विकल्प प्रदान करता है। आप व्यक्तिगत shape को लॉक कर सकते हैं या प्रस्तुति में सभी आकारों के माध्यम से क्रमागत रूप से प्रत्येक को लॉक कर पूरी फ़ाइल को प्रभावी रूप से सुरक्षित कर सकते हैं। आप लॉक के मान को `false` सेट करके सुरक्षा हटा सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में shape लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। लॉक फ़ाइल के भीतर के ऑब्जेक्ट्स के संपादन को सीमित करते हैं, जबकि [password protection](/slides/hi/net/password-protected-presentation/) खोलने और/या बदलावों को सहेजने तक पहुंच को नियंत्रित करता है। ये तंत्र एक‑दूसरे को पूरक करते हैं और साथ मिलकर काम करते हैं।

**क्या मैं विशिष्ट स्लाइडों पर संपादन को सीमित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**

हाँ। चयनित स्लाइडों पर आकारों के लिए लॉक लागू करें; शेष स्लाइडें संपादन योग्य बनी रहेंगी।

**क्या shape लॉक समूहित वस्तुओं और कनेक्टर पर लागू होते हैं?**

हाँ। समूहों, कनेक्टर, ग्राफ़िकल ऑब्जेक्ट और अन्य shape प्रकारों के लिए विशेष लॉक प्रकार समर्थित हैं।