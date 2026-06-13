---
title: .NET에서 프리젠테이션 정보 검색 및 업데이트
linktitle: 프리젠테이션 정보
type: docs
weight: 30
url: /ko/net/examine-presentation/
keywords:
- 프리젠테이션 형식
- 프리젠테이션 속성
- 문서 속성
- 속성 가져오기
- 속성 읽기
- 속성 변경
- 속성 수정
- 속성 업데이트
- PPTX 검사
- PPT 검사
- ODP 검사
- PowerPoint
- OpenDocument
- 프리젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET을 사용하여 PowerPoint 및 OpenDocument 프리젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고 빠른 인사이트와 스마트한 콘텐츠 감사를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프리젠테이션 정보를 검사하는 방법을 보여 줍니다. 전체 파일을 로드하지 않고 프리젠테이션의 현재 형식을 확인하고, 문서 속성을 읽으며, 필요할 때 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/) API를 기반으로 하며, 프리젠테이션 메타데이터를 작업할 때 일반적으로 수행하는 작업을 보여 줍니다.

## **프리젠테이션 형식 확인**

프리젠테이션을 작업하기 전에 현재 프리젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프리젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 아래 C# 코드를 참고하세요:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **프리젠테이션 속성 가져오기**

아래 C# 코드는 프리젠테이션 속성(프리젠테이션에 대한 정보)을 가져오는 방법을 보여 줍니다:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

DocumentProperties 클래스 아래의 [properties](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/#properties) 를 확인해 볼 수 있습니다.

## **프리젠테이션 속성 업데이트**

Aspose.Slides는 프리젠테이션 속성을 변경할 수 있는 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 메서드를 제공합니다.

아래와 같이 문서 속성이 표시된 PowerPoint 프리젠테이션이 있다고 가정해 보겠습니다.

![PowerPoint 프리젠테이션의 원본 문서 속성](input_properties.png)

다음 코드 예제는 일부 프리젠테이션 속성을 편집하는 방법을 보여 줍니다:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

문서 속성을 변경한 결과는 아래와 같습니다.

![PowerPoint 프리젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

프리젠테이션 및 보안 속성에 대한 자세한 정보를 얻고자 할 때 다음 링크가 도움이 될 수 있습니다:

- [프리젠테이션이 암호화되었는지 확인](https://docs.aspose.com/slides/ko/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [프리젠테이션이 쓰기 보호(읽기 전용) 상태인지 확인](https://docs.aspose.com/slides/ko/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [프리젠테이션을 로드하기 전에 암호 보호 여부 확인](https://docs.aspose.com/slides/ko/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [프리젠테이션을 보호하는 데 사용된 암호 확인](https://docs.aspose.com/slides/ko/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**폰트가 임베드되어 있는지, 어떤 폰트가 임베드되어 있는지 어떻게 확인할 수 있나요?**

프리젠테이션 수준에서 [embedded-font 정보](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getembeddedfonts/) 를 찾아보고, 이를 [실제로 콘텐츠에서 사용된 폰트 집합](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getfonts/) 과 비교하여 렌더링에 중요한 폰트를 식별합니다.

**파일에 숨겨진 슬라이드가 있는지, 몇 개 있는지 빠르게 확인하려면 어떻게 해야 하나요?**

[슬라이드 컬렉션](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/) 을 반복하면서 각 슬라이드의 [visibility 플래그](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/hidden/) 를 검사합니다.

**사용자 정의 슬라이드 크기와 방향이 사용되고 있는지, 기본값과 다른지 감지할 수 있나요?**

네. 현재 [슬라이드 크기](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slidesize/) 와 방향을 표준 프리셋과 비교하면 인쇄 및 내보내기 동작을 예측하는 데 도움이 됩니다.

**차트가 외부 데이터 원본을 참조하고 있는지 빠르게 확인할 방법이 있나요?**

네. 모든 [차트](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/) 를 순회하면서 그들의 [데이터 소스](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/datasourcetype/) 를 확인하고, 데이터가 내부인지 링크 기반인지, 깨진 링크가 있는지 여부를 기록합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

각 슬라이드마다 객체 수를 합산하고 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아 대략적인 복잡도 점수를 부여하여 잠재적인 성능 병목 현상을 표시합니다.