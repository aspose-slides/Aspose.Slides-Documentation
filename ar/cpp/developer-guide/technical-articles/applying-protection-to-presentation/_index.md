---
title: تقييد تحرير العرض باستخدام أقفال الشكل في C++
linktitle: تقييد تحرير العرض
type: docs
weight: 10
url: /ar/cpp/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل تعديل الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for C++ لتقييد الاختيار، الحركة، تعديل الحجم، والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for C++ هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التعديلات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

هذه المقالة تشرح كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح هذه الأقفال بتقييد عمليات تحرير معينة على كل شكل على حدة.

## **تركيب الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for C++، كل عنصر على الشريحة يُمثَّل ككائن يطبق واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) أو يرث من فئة تفعل ذلك.

أنواع الأشكال المختلفة توفر خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for C++ واجهات القفل التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) يقفل إطارات الصور.

لتطبيق أقفال عبر [العرض](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، يتم التجول عبر شرائحه وتعيين الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملف وحماية الكتابة على مستوى المستند هي إعدادات منفصلة لـ [إعدادات حماية العرض](/slides/ar/cpp/password-protected-presentation/).

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for C++ واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

يمرر المثال القيمة `true` إلى [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)، [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/)، و[set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) للأشكال التلقائية، مع أقفال مماثلة لأشكال المجموعات والموصلات وإطارات الصور. تستخدم الموصلات [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) للتحريك؛ وتستخدم المجموعات أيضًا [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيدات. تُترك الأشكال خارج الأنواع الأربعة التي تم التعامل معها دون تعديل. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

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

### **إزالة الحماية**

لإزالة قفل الشكل، يتم تعيين قيمته إلى `false`. يحمل المثال التالي عرضًا يحتوي على أقفال الأشكال ويمسح قيود الاختيار، والتحريك، وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)، و[IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). كما يمسح [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) ويحفظ نسخة من العرض. تُترك إعدادات القفل الأخرى دون تعديل.

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

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. يقوم المثال بقص 12% من الجانب الأيسر و8% من الجانب الأيمن، ثم يستدعي [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) على قفل إطار الصورة للحفاظ على القص وتقييد أي قص إضافي.

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

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، يتم تعطيل أمر **Crop** عند تحديد الصورة.

### **إبقاء المخطط مجمعًا**

يقوم المثال بتجميع مستطيل وسهم، ثم يستدعي [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) على قفل المجموعة لإبقاء مكونات المخطط معًا. تظل عمليات تحرير أخرى، مثل تحريك المجموعة أو تغيير تعبئة مكون، متاحة.

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

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `true`. في PowerPoint، يتم تعطيل أمر **Ungroup** عند اختيار المخطط بالكامل.

### **الإبلاغ عن أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. تُعيد [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) القيمة `true` عندما تكون جميع العلامات على ذلك الكائن غير مفعلة و`false` عندما يكون على الأقل واحدة مفعلة. للمجموعة وأطفالها كائنات قفل منفصلة، لذا يجب فحص الأطفال حتى عندما لا تحتوي المجموعة على أقفال.

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

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة تسمى `Layout` بقفل فك التجميع، وصورة تسمى `Photo` داخلها بقفل القص، ومستطيل غير مقفل يسمى `Free`. يتخطى التقرير `Free` ويطبع السطرين التاليين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير العلامات المخزنة على مستوى الشكل دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتطبيق كل علامة يعتمد على المحرر.

### **الخلاصة**

تتيح Aspose.Slides for C++ لك تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، وضع قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/cpp/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون تأثير على الأخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغير إعدادات القفل في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتجول عبر المجموعة باستخدام الطريقة التي تعيدها [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) للمجموعة، وطبق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة، متبعًا طريقة التجول في مثال التقرير.