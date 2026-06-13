---
title: C++를 사용하여 프레젠테이션에서 텍스트 구문 관리
linktitle: 텍스트 구문
type: docs
weight: 70
url: /ko/cpp/portion/
keywords:
- 텍스트 구문
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 텍스트 구문을 관리하는 방법을 배우고, 성능과 맞춤화를 향상시킵니다."
---
## **소개**

텍스트 구문은 단락 내의 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 해줍니다. Aspose.Slides에서는 텍스트 조각의 위치를 가져오거나, 단락의 일부분에만 서식을 적용하거나, 텍스트 동작을 보다 상세하게 제어해야 할 때 구문을 사용할 수 있습니다.

## **텍스트 구문 좌표 가져오기**
**GetCoordinates()** 메서드는 IPortion 및 Portion 클래스에 추가되어 구문의 시작 좌표를 가져올 수 있습니다:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 구문에 [하이퍼링크 할당](/slides/ko/cpp/manage-hyperlinks/)을 할 수 있습니다; 해당 조각만 클릭 가능하며 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 구문이 오버라이드하는 것이 무엇이며, Paragraph/TextFrame에서 가져오는 것은 무엇인가요?**

구문 수준 속성이 최우선 순위를 갖습니다. 속성이 [Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portion/)에 설정되지 않은 경우, 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraph/)에서 가져옵니다; 그곳에서도 설정되지 않은 경우, [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/theme/) 스타일에서 가져옵니다.

**Portion에 지정된 폰트가 대상 머신/서버에 없으면 어떻게 되나요?**

[Font substitution rules](/slides/ko/cpp/font-selection-sequence/)가 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 줍니다.

**Portion 별 텍스트 채우기 투명도 또는 그라디언트를 단락의 나머지와 독립적으로 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도는 인접한 조각과 다를 수 있습니다.