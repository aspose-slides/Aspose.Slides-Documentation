---
title: 커넥터
type: docs
weight: 190
url: /ko/cpp/examples/elements/connector/
keywords:
- 코드 예제
- 커넥터
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 도형 간에 커넥터를 추가, 경로 지정 및 스타일링하는 방법을 배우고, PPT, PPTX 및 ODP 프레젠테이션 예제를 확인하세요."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 도형을 커넥터로 연결하고 대상(타겟)을 변경하는 방법을 보여줍니다.

## **커넥터 추가**

슬라이드의 두 지점 사이에 커넥터 모양을 삽입합니다.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **커넥터 가져오기**

슬라이드에 추가된 첫 번째 커넥터 모양을 가져옵니다.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // 슬라이드에서 첫 번째 커넥터에 접근합니다.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **커넥터 제거**

슬라이드에서 커넥터를 삭제합니다.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **도형 재연결**

시작 및 끝 대상(target)을 지정하여 커넥터를 두 도형에 연결합니다.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```