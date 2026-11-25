---
title: C++ में शैप लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 10
url: /hi/cpp/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से सुरक्षा
- शैप लॉक
- स्थिति लॉक
- चयन लॉक
- आकार बदलना लॉक
- समूह बनाना लॉक
- PowerPoint
- PPTX
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PPTX प्रस्तुतियों में शैप्स को लॉक और अनलॉक करके चयन, गति, आकार बदलना और समूह बनाना को प्रतिबंधित करना सीखें।"
---
## **पृष्ठभूमि**

Aspose.Slides for C++ का एक आम उपयोग स्वचालित वर्कफ़्लो का हिस्सा के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो शैप्स में बदलावों को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि स्लाइड्स पर शैप्स कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में शैप लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत शैप्स पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप्स, तालिकाएँ, OLE ऑब्जेक्ट्स, समूहित शैप्स, पिक्चर फ्रेम्स, वीडियो फ्रेम्स, कनेक्टर्स और अन्य तत्व शामिल होते हैं जो प्रस्तुति बनाने के लिए उपयोग किए जाते हैं। Aspose.Slides for C++ में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या ऐसी क्लास से विरासत में प्राप्त करता है।

विभिन्न शैप प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) इंटरफ़ेस शैप लॉक का बेस इंटरफ़ेस है। Aspose.Slides for C++ निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) ऑटोशेप्स को लॉक करता है।
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) कनेक्टर शैप्स को लॉक करता है।
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) ग्रुप शैप्स को लॉक करता है।
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) पिक्चर फ्रेम्स को लॉक करता है।

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) में लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटरिटे करें और प्रत्येक समर्थित शैप पर उपयुक्त लॉक सेट करें।

## **लॉक्स लागू करें और हटाएँ**

अनुकूल प्रस्तुति संपादक शैप लॉक का उपयोग व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग [प्रस्तुति सुरक्षा सेटिंग्स](/slides/hi/cpp/password-protected-presentation/) हैं।

### **PPTX शैप्स पर सुरक्षा लागू करें**

Aspose.Slides for C++ स्लाइड पर शैप्स के साथ काम करने के लिये [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोशेप्स के लिये `true` को [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), और [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) को पास किया जाता है, और समूह शैप्स, कनेक्टर्स और पिक्चर फ्रेम्स के लिये समान लॉक लागू होते हैं। कनेक्टर्स गति के लिये [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) का उपयोग करते हैं; समूह भी समूहकरण को प्रतिबंधित करने के लिये [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के शैप कलेक्शन में शैप्स की जाँच करता है, और इन प्रतिबंधों को लागू करके एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के शैप्स अपरिवर्तित रहते हैं। लूप समूह के अंदर के चाइल्ड शैप्स को नहीं पार करता है।

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

शैप लॉक हटाने के लिये, उसका मान `false` सेट करें। निम्न उदाहरण शैप लॉक के साथ एक प्रस्तुति लोड करता है और चयन, गति, तथा आकार बदलने प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) को भी साफ़ करता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को संरक्षित रखें**

कार्यकारी फ़ोल्डर में `photo.jpg` नाम की फोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर पिक्चर फ्रेम लॉक पर [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) को कॉल करके क्रॉप को संरक्षित रखता है और आगे के क्रॉप को प्रतिबंधित करता है।

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

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब फोटो चयनित होता है तो **Crop** कमांड निष्क्रिय हो जाता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) को कॉल करके डायग्राम के घटकों को साथ रखता है। अन्य संपादन, जैसे समूह को स्थानांतरित करना या किसी घटक के भराव को बदलना, उपलब्ध रहते हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब पूरा डायग्राम चयनित हो तो **Ungroup** कमांड निष्क्रिय हो जाता है।

### **मौजूदा शैप लॉक की रिपोर्ट**

एक टेम्पलेट की समीक्षा करने के लिये, उसे खोलें और प्रत्येक शैप के लिये लॉक ऑब्जेक्ट पढ़ें। [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) `true` लौटाता है जब उस ऑब्जेक्ट पर सभी फ़्लैग निष्क्रिय हों और `false` जब कम से कम एक सक्षम हो। एक समूह और उसके चाइल्ड्स के पास अलग-अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह के पास लॉक न होने पर भी चाइल्ड्स की जाँच करें।

यह उदाहरण ऑटोशेप्स, पिक्चर फ्रेम्स और समूहों के लिये गति, चित्रों के लिये क्रॉपिंग और समूहों के लिये अनग्रुपिंग की जाँच करता है। यह उन फ़्लैग्स की रिपोर्ट करता है जिन्हें यह पहचानता है और उन शैप प्रकारों को चिह्नित करता है जिनकी जाँच यह नहीं करता।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसमें अनग्रुपिंग लॉक है, उसके अंदर `Photo` नाम की एक तस्वीर है जिसमें क्रॉपिंग लॉक है, और एक अनलॉक्ड आयत है जिसका नाम `Free` है। रिपोर्ट `Free` को छोड़ देती है और इन दो पंक्तियों को प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहीत शैप-स्तर संपादन फ़्लैग्स को पढ़ती है बिना उन्हें बदले या प्रस्तुति को सहेजे। दस्तावेज़-स्तर लिखने की सुरक्षा एक अलग सेटिंग है, और प्रत्येक फ़्लैग का प्रवर्तन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for C++ आपको व्यक्तिगत शैप्स पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स में समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक शैप प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको इन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में शैप लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। शैप लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/cpp/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं अन्य स्लाइड्स को प्रभावित किए बिना विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ?**

हां। केवल चयनित स्लाइड्स के शैप्स पर ही लॉक लागू करें। इससे अन्य स्लाइड्स की लॉक सेटिंग्स नहीं बदलती हैं।

**मैं एक समूह के अंदर व्यक्तिगत शैप्स पर लॉक कैसे लागू कर सकता हूँ?**

समूह के [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) मेथड द्वारा लौटाए गए कलेक्शन पर इटरिटे करें और प्रत्येक चाइल्ड शैप पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिये भी यह दोहराएँ, रिपोर्टिंग उदाहरण में दर्शाए गए ट्रैवर्सल का पालन करते हुए।