---
title: 使用形狀鎖定限制 C++ 簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 10
url: /zh-hant/cpp/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定分組
- PowerPoint
- PPTX
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PPTX 簡報中鎖定與解鎖形狀，以限制選取、移動、調整大小和分組。"
---
## **背景**

Aspose.Slides for C++ 的常見用途是建立、更新與保存 PowerPoint (PPTX) 簡報，作為自動化工作流程的一部分。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對單一圖形的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素所組成。在 Aspose.Slides for C++ 中，投影片上的每個元素皆由實作 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 介面或繼承自該介面的類別之物件表示。

不同的圖形類型提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for C++ 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) 鎖定自動圖形。
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) 鎖定連接線圖形。
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) 鎖定群組圖形。
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) 鎖定圖片框。

若要在整個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 上套用鎖定，請遍歷其投影片，並對每個受支援的圖形設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。它們不會使整個簡報無法編輯。

### **套用保護至 PPTX 圖形**

Aspose.Slides for C++ 提供 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 介面，以在投影片上操作圖形。

範例將 `true` 傳遞給自動圖形的 [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)、[set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) 與 [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/)，對群組圖形、連接線與圖片框則使用相應的鎖定。連接線使用 [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) 以限制移動；群組亦使用 [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) 以限制分組。

範例載入現有的 PPTX 簡報，檢查每張投影片的圖形集合，並儲存套用這些限制的副本。未屬於上述四種處理類型的圖形將保持不變。此迴圈不會遍歷群組內的子圖形。

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

### **移除保護**

若要移除圖形鎖定，將其值設為 `false`。以下範例載入帶有圖形鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/)、[IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) 來清除選取、移動與調整大小的限制。它亦會清除 [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/)，並儲存簡報的副本。其他鎖定設定保持不變。

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

### **結論**

Aspose.Slides for C++ 讓您能限制單一圖形的特定編輯操作，或在多張投影片間套用相同的限制。選擇每種圖形類型支援的鎖定，並在需要移除這些限制時將其值設為 `false`。

## **常見問答**

**我可以在同一個簡報中同時使用圖形鎖定與密碼保護嗎？**

可以。圖形鎖定會限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/cpp/password-protected-presentation/) 可以限制開啟或修改簡報。您可以在同一個檔案中同時使用兩者。

**我可以限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅對所選投影片上的圖形套用鎖定，這不會改變其他投影片的鎖定設定。

**如何對群組內的單一圖形套用鎖定？**

遍歷群組的 [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) 方法所返回的集合，並對每個子圖形套用適當的鎖定。對任何巢狀群組重複此步驟。上面的範例僅處理投影片的圖形集合，因此未對個別群組成員設定鎖定。