---
title: C++ में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 10
url: /hi/cpp/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षित रखें
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार परिवर्तन लॉक करें
- समूहबद्धता लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक कैसे करें, जिससे चयन, गति, आकार परिवर्तन और समूहबंदी को प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for C++ का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के भाग के रूप में PowerPoint (PPTX) प्रस्तुतियां बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन ऑपरेशनों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोषेप्स, टेबल, OLE ऑब्जेक्ट, ग्रुप्ड आकार, पिक्चर फ्रेम, वीडियो फ्रेम, कनेक्टर्स, और अन्य तत्वों जैसे घटकों का सम्मिलन होता है। Aspose.Slides for C++ में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में मिलता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रकट करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for C++ निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) ऑटोषेप्स को लॉक करता है।
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) ग्रुप आकारों को लॉक करता है।
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) पिक्चर फ्रेम को लॉक करता है।

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स को क्रमिक रूप से पार करके प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **संरक्षण लागू करें और हटाएं**

अनुकूल प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन ऑपरेशनों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़‑स्तरीय लेखन सुरक्षा अलग-अलग [presentation protection settings](/slides/hi/cpp/password-protected-presentation/) हैं।

### **PPTX आकारों पर संरक्षण लागू करें**

Aspose.Slides for C++ आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण `true` को [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) और [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) में ऑटोषेप्स के लिए पास करता है, साथ ही ग्रुप आकार, कनेक्टर्स और पिक्चर फ्रेम के लिए समतुल्य लॉक। कनेक्टर्स गति के लिए [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) का उपयोग करते हैं; समूह भी ग्रुपिंग को प्रतिबंधित करने के लिए [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड की shape collection में आकारों की जाँच करता है, और इन प्रतिबंधों को लागू करके एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के अंदर के चाइल्ड आकारों को पार नहीं करता।

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

### **संरक्षण हटाएं**

आकार लॉक हटाने के लिए, उसके मान को `false` सेट करें। निम्नलिखित उदाहरण लॉक वाले एक प्रस्तुति को लोड करता है और चयन, गति और आकार बदलने के प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) और [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह साथ ही [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) को भी साफ़ करता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को संरक्षित करें**

कार्य निर्देशिका में `photo.jpg` नामक एक फोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर पिक्चर फ्रेम लॉक पर [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) को कॉल करके क्रॉप को संरक्षित करता है और आगे के क्रॉप को प्रतिबंधित करता है।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहित करता है। PowerPoint में, फोटो के चयन पर **Crop** कमांड निष्क्रिय रहता है।

### **डायाग्राम को ग्रुप्ड रखें**

उदाहरण एक आयत और एक तीर को ग्रुप करता है, फिर समूह के लॉक पर [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) को कॉल करके डायाग्राम के घटकों को साथ रखता है। समूह को ले जाना या घटक के फ़िल को बदलना जैसी अन्य संपादन उपलब्ध रहती हैं।

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहित करता है। PowerPoint में, पूरी डायाग्राम के चयन पर **Ungroup** कमांड निष्क्रिय रहता है।

### **निष्कर्ष**

Aspose.Slides for C++ आपको व्यक्तिगत आकारों पर विशिष्ट संपादन ऑपरेशनों को प्रतिबंधित करने या पूरे स्लाइडों में समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको इन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **FAQ**

**क्या मैं aynı प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकार लॉक विशिष्ट संपादन ऑपरेशनों को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/cpp/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**

हां। केवल चयनित स्लाइडों के आकारों पर लॉक लागू करें। यह अन्य स्लाइडों के लॉक सेटिंग को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) विधि से मिली संग्रह को क्रमिक रूप से पार करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की shape collection को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।