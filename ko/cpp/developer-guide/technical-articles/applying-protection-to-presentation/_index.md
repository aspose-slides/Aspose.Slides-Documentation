---
title: C++에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 10
url: /ko/cpp/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 조정 잠금
- 그룹화 잠금
- PowerPoint
- PPTX
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한할 수 있습니다."
---
## **배경**

Aspose.Slides for C++의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한할 수 있게 합니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for C++에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표현됩니다.

다양한 도형 유형마다 서로 다른 잠금 옵션을 제공합니다. [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) 인터페이스는 도형 잠금의 기본 인터페이스입니다. Aspose.Slides for C++는 다음과 같은 잠금 인터페이스를 제공합니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) 자동 도형을 잠급니다.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) 연결선 도형을 잠급니다.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) 그래픽 개체를 잠급니다.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 전체에 잠금을 적용하려면 슬라이드를 반복하면서 각 지원 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동 및 크기 조정과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집 불가능하게 만들지는 않습니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for C++는 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 인터페이스를 제공합니다.

예제에서는 자동 도형에 대해 `true` 값을 [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/)에 전달하고, 그룹 도형, 연결선 및 그림 프레임에 대해 유사한 잠금을 설정합니다. 연결선은 이동을 위해 [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/)을 사용하고, 그룹은 그룹화를 제한하기 위해 [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/)을 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고 각 슬라이드의 도형 컬렉션을 확인한 뒤 이러한 제한이 적용된 복사본을 저장합니다. 네 가지 처리 유형에 포함되지 않은 도형은 변경되지 않으며, 루프는 그룹 내부의 하위 도형을 탐색하지 않습니다.

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

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `false` 로 설정합니다. 아래 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고 [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/)을 해제하고 프레젠테이션 복사본을 저장합니다. 다른 잠금 설정은 그대로 유지됩니다.

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

### **결론**

Aspose.Slides for C++를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원하는 잠금을 선택하고, 제한을 제거해야 할 때는 값을 `false` 로 설정하면 됩니다.

## **FAQ**

**같은 프레젠테이션에서 도형 잠금과 비밀번호 보호를 함께 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/cpp/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일 파일에서 모두 사용할 수 있습니다.

**다른 슬라이드에 영향을 주지 않고 특정 슬라이드만 편집 제한을 할 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) 메서드가 반환하는 컬렉션을 반복하면서 각 하위 도형에 적절한 잠금을 적용합니다. 중첩된 그룹에 대해서도 동일하게 반복합니다. 위 예제는 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 잠금을 설정하지 않습니다.