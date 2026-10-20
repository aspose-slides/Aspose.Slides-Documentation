---
title: C++ में शैप लॉक के साथ प्रस्तुति संपादन प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 10
url: /hi/cpp/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से बचाएँ
- शेप लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलने को लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PPTX प्रस्तुतियों में शैप्स को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूहबद्ध करना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for C++ का एक सामान्य उपयोग स्वचालित वर्कफ़्लो के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो शेप्स में बदलावों को सीमित करना इच्छित लेआउट और सामग्री को संरक्षित करने में मदद कर सकता है।

यह लेख समझाता है कि शेप्स स्लाइड्स में कैसे व्यवस्थित हैं और PPTX प्रस्तुति में शेप लॉक कैसे लागू और हटाएँ। ये लॉक आपको व्यक्तिगत शेप्स पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप्स, टेबल्स, OLE ऑब्जेक्ट्स, ग्रुपेड शेप्स, पिक्चर फ्रेम्स, वीडियो फ्रेम्स, कनेक्टर्स और अन्य तत्व जैसे घटकों का उपयोग करके निर्मित किया जाता है। Aspose.Slides for C++ में, स्लाइड पर प्रत्येक तत्व को उस ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या किसी क्लास से इनहेरिट करता है।

विभिन्न शेप प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) इंटरफ़ेस शेप लॉक के लिए बेस इंटरफ़ेस है। Aspose.Slides for C++ निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) ऑटोशेप्स को लॉक करता है।
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) कनेक्टर शेप्स को लॉक करता है।
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) ग्रुप शेप्स को लॉक करता है।
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) पिक्चर फ्रेम्स को लॉक करता है।

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) में लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटरेट करें और प्रत्येक समर्थित शेप पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू और हटाएँ**

शेप लॉक चयन, स्थानांतरण और आकार बदलने जैसे कार्यों को प्रतिबंधित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते।

### **PPTX शेप्स पर सुरक्षा लागू करें**

Aspose.Slides for C++ शेप्स के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण `true` को [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) और [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) पर पास करता है ऑटोशेप्स के लिए, समूह शेप्स, कनेक्टर्स और पिक्चर फ्रेम्स के लिए समान लॉक के साथ। कनेक्टर्स गति के लिए [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) का प्रयोग करते हैं; समूह भी ग्रुपिंग को प्रतिबंधित करने के लिए [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के शेप कलेक्शन में शेप्स की जाँच करता है, और इन प्रतिबंधों के साथ एक कॉपी सहेजता है। चार संभाले गये प्रकारों के बाहर के शेप्स को अपरिवर्तित छोड़ दिया जाता है। लूप समूह के भीतर के चाइल्ड शेप्स को ट्रैवर्स नहीं करता।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **सुरक्षा हटाएँ**

एक शेप लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण शेप लॉक के साथ एक प्रस्तुति को लोड करता है और चयन, स्थानांतरण और आकार बदलने के प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) और [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) को भी साफ़ करता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स को अपरिवर्तित छोड़ दिया जाता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **निष्कर्ष**

Aspose.Slides for C++ आपको व्यक्तिगत शेप्स पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स में समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक शेप प्रकार द्वारा समर्थित लॉक चुनें, और जब इन प्रतिबंधों को हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में शेप लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। शेप लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/cpp/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स पर शेप्स के लिए लॉक लागू करें। इससे अन्य स्लाइड्स पर लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के अंदर व्यक्तिगत शेप्स पर लॉक कैसे लागू करूँ?**

समूह की [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) मेथड द्वारा लौटाए गए कलेक्शन पर इटरेट करें और प्रत्येक चाइल्ड शेप पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह प्रक्रिया दोहराएँ। ऊपर दिए गए उदाहरण केवल स्लाइड के शेप कलेक्शन को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।