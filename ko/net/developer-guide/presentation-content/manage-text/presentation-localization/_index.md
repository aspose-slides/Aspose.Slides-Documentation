---
title: .NET에서 프레젠테이션 로컬라이제이션 자동화
linktitle: 프레젠테이션 로컬라이제이션
type: docs
weight: 100
url: /ko/net/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 언어 ID
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드 로컬라이제이션을 자동화하고, 빠른 글로벌 배포를 위한 실용적인 C# 코드 샘플과 팁을 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 텍스트에 `LanguageId`를 설정하는 방법을 설명합니다. 프레젠테이션을 열고, 텍스트가 포함된 도형을 추가하고, 텍스트 부분에 언어 식별자를 할당한 다음 결과를 PPTX 파일로 저장하는 방법을 보여줍니다.

## **프레젠테이션 및 도형 텍스트의 언어 변경**
- Presentation 클래스의 인스턴스를 생성합니다.
- 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- 슬라이드에 사각형 유형의 AutoShape을 추가합니다.
- TextFrame에 텍스트를 추가합니다.
- 텍스트에 Language Id를 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래 예제에서 보여집니다.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**언어 ID가 자동 텍스트 번역을 트리거합니까?**

아니요. Aspose.Slides의 [LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/languageid/)는 맞춤법 검사 및 문법 교정을 위해 언어를 저장하지만, 텍스트 내용을 번역하거나 변경하지는 않습니다. 이는 PowerPoint가 교정을 위해 이해하는 메타데이터입니다.

**언어 ID가 렌더링 시 하이픈 삽입 및 줄 바꿈에 영향을 줍니까?**

Aspose.Slides에서 [LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/languageid/)는 교정을 위한 것입니다. 하이픈 삽입 품질과 줄 바꿈은 주로 [적절한 글꼴](/slides/ko/net/powerpoint-fonts/)와 쓰기 시스템에 대한 레이아웃/줄 바꿈 설정에 따라 달라집니다. 올바른 렌더링을 보장하려면 필요한 글꼴을 사용할 수 있게 하고, [글꼴 대체 규칙](/slides/ko/net/font-substitution/)을 구성하며, 또는 프레젠테이션에 [글꼴 삽입](/slides/ko/net/embedded-font/)을 삽입하십시오.

**단일 단락 내에서 서로 다른 언어를 설정할 수 있나요?**

예. [LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/languageid/)는 텍스트 부분 수준에 적용되므로, 단일 단락에서도 서로 다른 교정 설정을 가진 여러 언어를 혼합할 수 있습니다.