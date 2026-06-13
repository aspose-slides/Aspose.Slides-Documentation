---
title: C++에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/cpp/examine-presentation/
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
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고 빠른 인사이트와 보다 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션 정보를 검사하는 방법을 보여줍니다. 전체 파일을 로드하지 않고 프레젠테이션의 현재 형식을 확인하고, 문서 속성을 읽으며, 필요할 때 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/documentproperties/) API를 기반으로 하며 프레젠테이션 메타데이터 작업에 대한 일반적인 운영을 시연합니다.

## **프레젠테이션 형식 확인**

프레젠테이션 작업을 시작하기 전에 현재 프레젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프레젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 다음 C++ 코드를 참고하십시오:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **프레젠테이션 속성 가져오기**

다음 C++ 코드는 프레젠테이션 속성(프레젠테이션에 대한 정보)을 가져오는 방법을 보여줍니다:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **프레젠테이션 속성 업데이트**

Aspose.Slides는 프레젠테이션 속성을 변경할 수 있는 [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) 메서드를 제공합니다.

아래와 같이 문서 속성이 표시된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 코드 예제는 일부 프레젠테이션 속성을 편집하는 방법을 보여줍니다:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

문서 속성을 변경한 결과는 아래와 같이 표시됩니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

프레젠테이션 및 보안 속성에 대한 자세한 정보를 얻으려면 다음 링크가 도움이 될 수 있습니다:

- [프레젠테이션이 암호화되었는지 확인](https://docs.aspose.com/slides/ko/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [프레젠테이션이 쓰기 보호(읽기 전용) 되었는지 확인](https://docs.aspose.com/slides/ko/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [프레젠테이션을 로드하기 전에 암호 보호되었는지 확인](https://docs.aspose.com/slides/ko/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [프레젠테이션을 보호하는 데 사용된 암호 확인](https://docs.aspose.com/slides/ko/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**폰트가 포함되었는지 및 어떤 폰트인지 어떻게 확인할 수 있나요?**

프레젠테이션 수준에서 [embedded-font 정보](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 를 찾은 다음, 해당 항목을 실제 콘텐츠에 사용된 [폰트 집합](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getfonts/) 과 비교하여 렌더링에 중요한 폰트를 식별합니다.

**파일에 숨겨진 슬라이드가 있는지 및 개수를 어떻게 빠르게 확인할 수 있나요?**

[슬라이드 컬렉션](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidecollection/)을 순회하면서 각 슬라이드의 [visibility 플래그](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/get_hidden/) 를 검사합니다.

**사용자 지정 슬라이드 크기와 방향이 사용되는지, 기본값과 다른지 확인할 수 있나요?**

예. 현재 [슬라이드 크기와 방향](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_slidesize/) 을 표준 프리셋과 비교합니다. 이는 인쇄 및 내보내기 동작을 예측하는 데 도움이 됩니다.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인할 수 있나요?**

예. 모든 [차트](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chart/) 를 순회하고 그들의 [데이터 소스](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) 를 확인하여 데이터가 내부인지 링크 기반인지, 깨진 링크가 있는지 여부를 기록합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

각 슬라이드마다 객체 수를 집계하고 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아봅니다. 대략적인 복잡도 점수를 부여하여 잠재적인 성능 병목 현상을 표시합니다.