---
title: .NET에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/net/examine-presentation/
keywords:
- 프레젠테이션 형식
- 프레젠테이션 속성
- 문서 속성
- 속성 가져오기
- 속성 읽기
- 속성 변경
- 속성 수정
- 속성 업데이트
- PPTX 검사
- PPT 검사
- ODP 검사
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조, 메타데이터를 .NET으로 탐색하여 빠른 인사이트와 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 정보를 검사하는 방법을 보여줍니다. 전체 파일을 로드하지 않고 프레젠테이션의 현재 형식을 확인하고, 문서 속성을 읽으며, 필요에 따라 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/) API를 기반으로 하며, 프레젠테이션 메타데이터 작업에 일반적인 작업을 시연합니다.

## **프레젠테이션 형식 확인**

프레젠테이션을 작업하기 전에 현재 프레젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프레젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 다음 C# 코드를 참고하십시오:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **프레젠테이션 속성 가져오기**

다음 C# 코드는 프레젠테이션 속성(프레젠테이션에 대한 정보)을 가져오는 방법을 보여줍니다:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

DocumentProperties 클래스 아래의 [properties](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/#properties)를 확인해볼 수 있습니다.

## **프레젠테이션 속성 업데이트**

Aspose.Slides는 프레젠테이션 속성을 변경할 수 있는 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 메서드를 제공합니다.

다음과 같이 문서 속성이 표시된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![Original document properties of the PowerPoint presentation](input_properties.png)

이 코드 예제는 일부 프레젠테이션 속성을 편집하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

문서 속성을 변경한 결과는 아래와 같습니다.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **유용한 링크**

프레젠테이션 및 보안 속성에 대한 자세한 정보를 얻고 싶다면 다음 링크가 도움이 될 수 있습니다:

- [비밀번호로 프레젠테이션 보호](/slides/ko/net/password-protected-presentation/)
- [쓰기 방지 프레젠테이션](/slides/ko/net/write-protected-presentation/)

## **FAQ**

**폰트가 삽입되어 있는지 및 어떤 폰트가 삽입되어 있는지 확인하려면 어떻게 해야 하나요?**

프레젠테이션 수준에서 [embedded-font information](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getembeddedfonts/)을 찾아보고, 이를 [실제로 콘텐츠에서 사용되는 폰트](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getfonts/)와 비교하여 렌더링에 중요한 폰트를 식별합니다.

**파일에 숨겨진 슬라이드가 있는지 및 개수를 빠르게 확인하려면 어떻게 하나요?**

[slide collection](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/)을 순회하면서 각 슬라이드의 [visibility flag](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/hidden/)을 검사합니다.

**사용자 지정 슬라이드 크기 및 방향이 사용되는지, 기본값과 다른지 감지할 수 있나요?**

예. 현재 [slide size](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slidesize/)와 방향을 표준 프리셋과 비교하면 인쇄 및 내보내기 동작을 예측하는 데 도움이 됩니다.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인할 방법이 있나요?**

예. 모든 [charts](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chart/)를 탐색하고, 해당 [data source](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/datasourcetype/)를 확인하여 데이터가 내부인지 링크 기반인지, 깨진 링크가 있는지 여부를 기록합니다.

**렌더링이나 PDF 내보내기를 늦출 수 있는 '무거운' 슬라이드를 어떻게 평가하나요?**

각 슬라이드마다 객체 수를 집계하고 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아 대략적인 복잡도 점수를 부여하여 잠재적 성능 병목을 표시합니다.