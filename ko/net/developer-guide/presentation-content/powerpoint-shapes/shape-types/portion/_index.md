---
title: .NET에서 프레젠테이션 텍스트 구문 관리
linktitle: 텍스트 구문
type: docs
weight: 70
url: /ko/net/portion/
keywords:
- 텍스트 구문
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션의 텍스트 구문을 관리하는 방법을 배우고, 성능과 커스터마이징을 향상시킵니다."
---
## **개요**

텍스트 구문은 단락 내부의 특정 텍스트 조각을 나타내며, 해당 조각을 주변 내용과 독립적으로 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 위치를 가져오거나, 단락의 일부만 서식을 적용하거나, 텍스트 동작을 보다 자세히 제어해야 할 때 구문을 사용할 수 있습니다.

이 문서에서는 `GetCoordinates()` 메서드를 사용하여 구문의 시작 좌표를 가져오는 방법을 보여줍니다. 또한 단일 텍스트 조각에 하이퍼링크 적용, 구문, 단락, 텍스트 프레임 및 테마 상속을 통한 서식 해결 방식 이해, 지정된 글꼴이 없을 경우 처리와 같은 일반적인 구문 관련 시나리오를 강조합니다. 추가로 동일한 단락 내 개별 구문에 대해 텍스트 채우기, 색상 및 투명도를 다르게 설정할 수 있음을 언급합니다.

## **텍스트 구문의 좌표 가져오기**
**GetCoordinates()** 메서드가 IPortion 및 Portion 클래스에 추가되었으며, 구문의 시작 좌표를 가져올 수 있습니다:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부분에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 구문에 [하이퍼링크 할당](/slides/ko/net/manage-hyperlinks/)을 할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: 구문이 무엇을 재정의하고, 무엇을 단락/텍스트 프레임에서 가져오나요?**

구문 수준 속성이 가장 높은 우선순위를 가집니다. 속성이 [구문](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [단락](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/)에서 가져옵니다; 거기에서도 설정되지 않으면 [텍스트 프레임](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/) 또는 [테마](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/theme/) 스타일에서 가져옵니다.

**구문에 지정된 글꼴이 대상 머신/서버에 없으면 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/net/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 줍니다.

**구문별 텍스트 채우기 투명도 또는 그라디언트를 단락의 나머지와 독립적으로 설정할 수 있나요?**

예, [구문](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 설정할 수 있습니다.