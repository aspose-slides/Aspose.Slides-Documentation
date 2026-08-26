---
title: JavaScript에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드, 구조 및 메타데이터를 탐색하여 빠른 인사이트와 보다 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션 정보를 검사하는 방법을 보여줍니다. 전체 파일을 로드하지 않고 프레젠테이션의 현재 형식을 확인하고, 문서 속성을 읽으며, 필요할 때 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/) API를 기반으로 하며 프레젠테이션 메타데이터 작업을 위한 일반적인 작업을 시연합니다.

## **프레젠테이션 형식 확인**

프레젠테이션 작업을 시작하기 전에 현재 프레젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프레젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 아래 JavaScript 코드를 참고하세요:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **프레젠테이션 속성 가져오기**

이 JavaScript 코드는 프레젠테이션 속성(프레젠테이션에 대한 정보)을 가져오는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

[DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) 클래스 아래의 속성을 확인하고 싶을 수 있습니다.

## **프레젠테이션 속성 업데이트**

Aspose.Slides는 프레젠테이션 속성을 변경할 수 있는 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 메서드를 제공합니다.

아래와 같이 문서 속성이 표시된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

이 코드 예제는 일부 프레젠테이션 속성을 수정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

문서 속성을 변경한 결과는 아래와 같습니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

프레젠테이션 및 보안 속성에 대한 추가 정보를 얻으려면 다음 링크가 도움이 될 수 있습니다:

- [프레젠테이션 암호 보호](/slides/ko/nodejs-java/password-protected-presentation/)
- [프레젠테이션 쓰기 보호](/slides/ko/nodejs-java/write-protected-presentation/)

## **FAQ**

**글꼴이 포함되어 있는지와 포함된 글꼴은 무엇인지 어떻게 확인할 수 있나요?**

프레젠테이션 수준에서 [embedded-font 정보](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)를 찾아보고, 이를 [실제로 콘텐츠에서 사용되는 글꼴 목록](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/)과 비교하여 렌더링에 필수적인 글꼴을 식별합니다.

**파일에 숨겨진 슬라이드가 있는지와 그 개수를 빠르게 확인하려면 어떻게 해야 하나요?**

[슬라이드 컬렉션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)을 순회하면서 각 슬라이드의 [visibility 플래그](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/gethidden/)를 검사합니다.

**사용자 정의 슬라이드 크기 및 방향이 적용되었는지, 기본값과 다른지 어떻게 감지할 수 있나요?**

현재 [슬라이드 크기](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslidesize/)와 방향을 표준 프리셋과 비교합니다. 이를 통해 인쇄 및 내보내기 동작을 예측할 수 있습니다.

**차트가 외부 데이터 소스를 참조하고 있는지 빠르게 확인할 방법이 있나요?**

모든 [차트](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/)를 순회하고, 해당 차트의 [데이터 소스](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)를 확인하여 데이터가 내부에 있는지 링크 기반인지, 깨진 링크가 있는지 여부를 파악합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가하나요?**

각 슬라이드별로 객체 수를 집계하고, 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아 대략적인 복잡도 점수를 부여하여 성능 병목 가능성을 표시합니다.