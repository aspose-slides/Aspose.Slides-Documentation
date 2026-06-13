---
title: .NET에서 프레젠테이션의 위첨자 및 아래첨자 관리
linktitle: 위첨자 및 아래첨자
type: docs
weight: 80
url: /ko/net/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 위첨자와 아래첨자를 완벽히 다루고, 전문적인 텍스트 서식을 통해 프레젠테이션을 최대한 효과적으로 향상시킵니다."
---
## **개요**

Aspose.Slides for .NET은 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 위첨자와 아래첨자 텍스트를 통합하는 기능을 제공합니다. 화학식, 수학 방정식 등을 강조하거나 각주로 내용을 주석 처리해야 할 때, 이러한 특수 서식 옵션을 사용하면 명확성과 정밀성을 유지할 수 있습니다. 이 문서에서는 위첨자와 아래첨자 스타일을 손쉽게 적용하고 모든 슬라이드에서 전문적인 결과를 얻는 방법을 배웁니다.

## **위첨자 및 아래첨자 텍스트 추가**

프레젠테이션의 모든 단락 안에 위첨자와 아래첨자 텍스트를 추가할 수 있습니다. Aspose.Slides에서 이를 수행하려면 `Escapement` 속성을 [PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/portionformat/) 클래스에서 사용해야 합니다.

이 속성을 사용하면 위첨자 또는 아래첨자 텍스트를 설정할 수 있으며, 값 범위는 -100% (아래첨자)에서 100% (위첨자)까지입니다.

구현 단계:

1. 프레젠테이션 클래스([Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/))의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 `Rectangle` 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)을 추가합니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)와 연결된 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 접근합니다.
1. 기존 단락을 삭제합니다.
1. 위첨자 텍스트용 새 [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/)를 만들고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)의 단락 컬렉션에 추가합니다.
1. 새 텍스트 부분 객체를 생성합니다.
1. 위첨자를 적용하려면 텍스트 부분의 `Escapement` 속성을 0에서 100 사이로 설정합니다(0은 위첨자 없음).
1. [Portion](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/)에 텍스트를 지정하고 해당 단락의 부분 컬렉션에 추가합니다.
1. 아래첨자 텍스트용 또 다른 [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/)를 만들고 이를 단락 컬렉션에 추가합니다.
1. 새 텍스트 부분 객체를 생성합니다.
1. 아래첨자를 적용하려면 텍스트 부분의 `Escapement` 속성을 0에서 -100 사이로 설정합니다(0은 아래첨자 없음).
1. [Portion](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/)에 텍스트를 지정하고 해당 단락의 부분 컬렉션에 추가합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 위 단계를 구현합니다:

```c#
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // 텍스트 상자를 생성합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // 위첨자 텍스트용 단락을 생성합니다.
    IParagraph superPar = new Paragraph();

    // 일반 텍스트가 포함된 텍스트 부분을 생성합니다.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // 위첨자 텍스트가 포함된 텍스트 부분을 생성합니다.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 아래첨자 텍스트용 단락을 생성합니다.
    IParagraph paragraph2 = new Paragraph();

    // 일반 텍스트가 포함된 텍스트 부분을 생성합니다.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 아래첨자 텍스트가 포함된 텍스트 부분을 생성합니다.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // 텍스트 상자에 단락을 추가합니다.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

결과:

![Superscript and Subscript](superscript_and_subscript.png)

## **FAQ**

**PDF 또는 다른 형식으로 내보낼 때 위첨자와 아래첨자가 보존되나요?**

예, Aspose.Slides for .NET은 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원 형식으로 내보낼 때 위첨자와 아래첨자 서식을 올바르게 유지합니다. 특수 서식이 모든 출력 파일에 그대로 적용됩니다.

**위첨자와 아래첨자를 굵게 또는 기울임꼴과 같은 다른 서식 스타일과 함께 사용할 수 있나요?**

예, Aspose.Slides를 사용하면 단일 텍스트 부분 내에서 다양한 텍스트 스타일을 혼합할 수 있습니다. [PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/portionformat/)에서 해당 속성을 구성하면 굵게, 기울임꼴, 밑줄과 동시에 위첨자 또는 아래첨자를 적용할 수 있습니다.

**표, 차트 또는 SmartArt 내부의 텍스트에도 위첨자와 아래첨자 서식이 적용되나요?**

예, Aspose.Slides for .NET은 표 및 차트 요소를 포함한 대부분의 객체 내 서식을 지원합니다. SmartArt를 사용할 경우 적절한 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartartnode/))와 해당 텍스트 컨테이너에 접근한 뒤 [PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/portionformat/) 속성을 동일하게 구성하면 됩니다.