---
title: 使用形状锁在 C++ 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 10
url: /zh/cpp/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小调整
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

Aspose.Slides for C++ 的常见用途是作为自动化工作流的一部分创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户收到这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁允许您对单个形状的特定编辑操作进行限制。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for C++ 中，幻灯片上的每个元素都由实现[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) 接口是形状锁的基础接口。Aspose.Slides for C++ 提供以下锁定接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) 锁定自动形状。
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) 锁定连接器形状。
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) 锁定图形对象。
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) 锁定组合形状。
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) 锁定图片框。

要在整个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)中应用锁定，请遍历其幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

形状锁限制诸如选择、移动和调整形状大小等操作。它们不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for C++ 提供[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)接口以在幻灯片上处理形状。

示例对自动形状调用 `true` 传递给[set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)、[set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/)和[set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/)，并对组合形状、连接器和图片框使用等效的锁定。连接器使用[set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/)来限制移动；组合形状还使用[set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/)来限制组合。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合，并保存一个已应用这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组内的子形状。

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

### **移除保护**

要移除形状锁，将其值设为 `false`。下面的示例加载一个带有形状锁的演示文稿，并通过[IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)和[IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/)清除选择、移动和大小调整限制。它还清除[IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/)并保存演示文稿的副本。其他锁定设置保持不变。

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

### **结论**

Aspose.Slides for C++ 允许您对单个形状的特定编辑操作进行限制，或在整张幻灯片中应用相同的限制。请选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而[密码保护](/slides/zh/cpp/password-protected-presentation/) 可以限制打开或修改演示文稿。您可以在同一文件中同时使用两者。

**我可以仅限制特定幻灯片的编辑而不影响其他幻灯片吗？**

可以。仅对选定幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的[get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)方法返回的集合，并对每个子形状应用相应的锁定。对任何嵌套的组重复此操作。上述示例仅处理幻灯片的形状集合，因此未对组内的单个成员设置锁定。