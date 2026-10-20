---
title: تقييد تحرير العرض بأقفال الأشكال في C++
linktitle: تقييد تحرير العرض
type: docs
weight: 10
url: /ar/cpp/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for C++ لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for C++ هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير محددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء عرض تقديمي. في Aspose.Slides for C++، يُمثَّل كل عنصر في الشريحة بواسطة كائن يطبق واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for C++ الواجهات القفلية التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) يقفل أشكال الموصل.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) يقفل إطارات الصور.

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تقيد أقفال الأشكال عمليات مثل اختيار الأشكال، نقلها، وتغيير حجمها. لا تجعل هذه الأقفال العرض التقديمي بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for C++ واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

يمرّر المثال القيمة `true` إلى [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/) و[set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) و[set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) للأشكال التلقائية، مع أقفال مكافئة للأشكال المجمعة، الموصلات، وإطارات الصور. تستخدم الموصلات [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) للحركة؛ كما تستخدم المجموعات [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة أشكال كل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل شكل، اضبط قيمته إلى `false`. يحمل المثال التالي عرضًا يحتوي على أقفال أشكال ويزيل قيود الاختيار، الحركة، وتغيير الحجم من خلال [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)، و[IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). كما يزيل [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

### **الخلاصة**

يتيح لك Aspose.Slides for C++ تقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض التقديمي؟**

نعم. تقيد أقفال الأشكال عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/cpp/password-protected-presentation/) يمكن أن تقيّد فتح العرض أو تعديلّه. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرى؟**

نعم. طبق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) الخاصة بالمجموعة وطبّق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة السابقة تعالج فقط مجموعة أشكال الشريحة، لذا لا تقوم بتعيين أقفال على أعضاء المجموعة الفردية.