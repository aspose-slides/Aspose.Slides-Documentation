---
title: Android에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/androidjava/examine-presentation/
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
- 안드로이드
- 자바
- Aspose.Slides
description: "Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색함으로써 더 빠른 인사이트와 더 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 정보를 검사하는 방법을 보여줍니다. 전체 파일을 로드하지 않고 프레젠테이션의 현재 형식을 확인하고, 문서 속성을 읽으며, 필요할 경우 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/documentproperties/) API를 기반으로 하며, 프레젠테이션 메타데이터를 다루는 일반적인 작업을 보여줍니다.

## **프레젠테이션 형식 확인**

프레젠테이션 작업을 시작하기 전에 현재 프레젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프레젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 아래 Java 코드를 참조하세요:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **프레젠테이션 속성 가져오기**

다음 Java 코드는 프레젠테이션 속성(프레젠테이션에 대한 정보)을 가져오는 방법을 보여줍니다:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

[DocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) 클래스 아래의 속성을 확인할 수도 있습니다.

## **프레젠테이션 속성 업데이트**

Aspose.Slides는 프레젠테이션 속성을 변경할 수 있는 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 메서드를 제공합니다.

다음과 같이 문서 속성이 표시된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

이 코드 예제는 몇몇 프레젠테이션 속성을 편집하는 방법을 보여줍니다:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

문서 속성을 변경한 결과는 아래와 같습니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

프레젠테이션 및 보안 속성에 대한 추가 정보를 얻고 싶다면 다음 링크가 도움이 될 수 있습니다:

- [프레젠테이션이 암호화 되었는지 확인하기](https://docs.aspose.com/slides/ko/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [프레젠테이션이 쓰기 보호(읽기 전용) 상태인지 확인하기](https://docs.aspose.com/slides/ko/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [로드하기 전에 프레젠테이션이 비밀번호로 보호되었는지 확인하기](https://docs.aspose.com/slides/ko/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [프레젠테이션을 보호하는 비밀번호 확인하기](https://docs.aspose.com/slides/ko/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**폰트가 포함되어 있는지와 포함된 폰트를 어떻게 확인할 수 있나요?**

프레젠테이션 수준에서 [임베디드 폰트 정보](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)를 찾은 다음, [실제로 사용된 폰트](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 집합과 비교하여 렌더링에 필요한 핵심 폰트를 식별합니다.

**파일에 숨겨진 슬라이드가 있는지와 개수를 빠르게 어떻게 알 수 있나요?**

[슬라이드 컬렉션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/)을 순회하면서 각 슬라이드의 [숨김 플래그](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#getHidden--)를 검사합니다.

**사용자 정의 슬라이드 크기와 방향이 적용되었는지, 기본값과 다른지 어떻게 감지할 수 있나요?**

예, 현재 [슬라이드 크기](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlideSize--)와 방향을 표준 프리셋과 비교하면 인쇄 및 내보내기 동작을 사전에 파악하는 데 도움이 됩니다.

**차트가 외부 데이터 소스를 참조하고 있는지 빠르게 확인할 수 있는 방법이 있나요?**

예, 모든 [차트](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chart/)를 순회하면서 해당 [데이터 소스](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)를 확인하고, 내부 데이터인지 링크 기반인지, 깨진 링크가 있는지 여부를 기록합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

각 슬라이드마다 객체 수를 집계하고, 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아 대략적인 복잡도 점수를 부여하여 잠재적인 성능 병목을 표시합니다.