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
- 파워포인트
- 오픈문서
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하여 빠른 인사이트와 보다 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션 형식을 식별하고 전체 프레젠테이션 객체 모델을 생성하지 않고도 문서 메타데이터를 읽을 수 있습니다. 파일을 분류하거나 인벤토리를 구축하거나 프레젠테이션 내용을 로드하고 처리하기 전에 속성을 검사해야 할 때 유용합니다.

이 문서는 [PresentationFactory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/)와 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/)를 통한 경량 검사를 보여주며, [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/)를 통한 대상 업데이트도 설명합니다.

## **프레젠테이션 형식 확인**

이미 로드된 프레젠테이션이 있는 경우 로드 후 형식 감지를 위한 [Determine the Original Presentation Format](/slides/ko/nodejs-java/detect-presentation-source-format/)과 레거시 PPT, PPS, POT 스트림의 제한 사항을 확인하십시오.

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사합니다. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/getloadformat/) 메서드는 PPTX, PPT 또는 ODP와 같이 감지된 형식을 반환합니다.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **경량 프레젠테이션 인벤토리 구축**

많은 프레젠테이션 파일을 처리할 때 검증, 인덱싱 또는 문서 관리 시스템을 위한 압축 인벤토리가 필요할 수 있습니다. 이 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용하여 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/) 객체를 얻고, 이어서 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)를 호출하여 문서 메타데이터를 읽습니다. 이 접근 방식은 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 생성하지 않으며 전체 프레젠테이션 객체 모델을 탐색할 필요도 없습니다.

[DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/)에서 제공하는 확장 속성은 다음과 같은 인벤토리 값을 제공합니다:

| 메서드 | 인벤토리 값 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getSlides) | 전체 슬라이드 수. |
| [getHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 숨김 슬라이드 수. |
| [getNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getNotes) | 노트를 포함한 슬라이드 수. |
| [getParagraphs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 가능한 경우 전체 단락 수. |
| [getWords](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getWords) | 전체 단어 수. |
| [getMultimediaClips](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | 오디오 및 비디오 클립 총 수. |

다음 예제는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 객체를 만들지 않고 이러한 값을 읽어 압축 인벤토리를 출력합니다. 또한 [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs)와 [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)를 결합하여 글꼴, 테마 및 슬라이드 제목과 같은 콘텐츠 그룹을 표시합니다.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
...
```

각 [HeadingPair](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/)은 [HeadingPair.getName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/#getName)으로 그룹 이름을 제공하고, [HeadingPair.getCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/#getCount)으로 해당 그룹의 항목 수를 제공합니다. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)는 평평하고 순서가 지정된 배열을 반환하므로 각 헤딩 쌍이 지정한 연속된 제목 수만큼 사용합니다.

### **저장된 메타데이터 및 형식 제한**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)에서 반환되는 인벤토리 속성은 원본 문서에 존재하는 메타데이터를 반영합니다. Aspose.Slides는 이 호출을 위해 프레젠테이션 객체 모델을 로드하고 탐색하지 않으며, 누락된 속성은 기본값으로 표시되고, 마지막으로 파일을 저장한 애플리케이션이 문서 속성을 업데이트하지 않은 경우 저장된 값이 오래될 수 있습니다.

- **PPTX:** 슬라이드, 노트, 숨김 슬라이드, 단락, 단어 및 멀티미디어 수와 헤딩 페어, 파트 제목에 대한 확장 문서 속성을 제공합니다. 가용성은 문서 제작자가 어떤 속성을 기록했는지에 따라 달라집니다.
- **PPT:** 바이너리 형식은 해당 문서 요약 속성을 저장할 수 있습니다. 속성이 없거나 문서 제작자가 최신 상태로 갱신하지 않은 경우 Aspose.Slides는 슬라이드에서 계산하지 않고 저장된 값 또는 기본값을 반환합니다.
- **ODP:** OpenDocument 메타데이터는 페이지, 단락 및 단어 수와 같은 일반 문서 통계를 제공하지만 이러한 값은 모든 PowerPoint 고유 확장 속성에 매핑되지 않습니다. 숨김 슬라이드, 노트 슬라이드, 멀티미디어, 헤딩 페어 및 파트 제목 메타데이터는 제공되지 않을 수 있으며, 인벤토리 속성은 기본값을 반환할 수 있습니다. 값이 0이거나 배열이 비어 있다고 해서 해당 콘텐츠가 없다는 것을 권위 있게 증명하는 것으로 간주하지 마십시오.

인벤토리와 초기 검사를 위해 경량 메타데이터 방식을 사용하십시오. 결과가 메모리 내 변경을 반영해야 하거나 실제 프레젠테이션 콘텐츠를 확인해야 할 경우 프레젠테이션을 로드하고 실시간 객체 모델을 검사하십시오.

## **프레젠테이션 속성 업데이트**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)에서 반환된 속성은 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 변경할 수 있습니다. 변경 사항을 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/)로 적용한 다음, [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/)으로 바인딩된 프레젠테이션을 저장하십시오.

다음 이미지는 원본 문서 속성을 보여줍니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 예제는 제목과 마지막 저장 시간을 변경하고 결과를 새 파일에 씁니다:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

다음 이미지는 업데이트된 문서 속성을 보여줍니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

관련 보안 검사와 보호 설정에 대해서는 다음 문서를 참고하십시오:

- [Password-Protect Presentations](/slides/ko/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ko/nodejs-java/write-protected-presentation/)

## **FAQ**

**폰트가 임베드되어 있는지, 어떤 폰트가 임베드되어 있는지 어떻게 확인할 수 있나요?**

프레젠테이션을 로드하고 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getfontsmanager/)를 사용하십시오. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)를 호출하면 임베드된 폰트를 얻을 수 있고, [FontsManager.getFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/)를 호출하면 프레젠테이션에서 사용되는 폰트를 얻을 수 있습니다. 두 결과를 비교하여 렌더링에 필요하지만 임베드되지 않은 폰트를 찾으십시오.

**파일에 숨김 슬라이드가 있는지, 몇 개 있는지 빠르게 확인하려면 어떻게 해야 하나요?**

저장된 문서 메타데이터가 충분할 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)와 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)를 통해 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides)를 읽으십시오. 이는 경량 인벤토리에 적합합니다. 프레젠테이션이 메모리에서 수정된 경우 저장된 메타데이터가 없거나 오래될 수 있으므로, 실제 값을 확인하려면 [Presentation.getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/)를 순회하고 각 슬라이드의 [Slide.getHidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/gethidden/) 메서드를 검사하십시오.

**사용자 지정 슬라이드 크기 및 방향이 사용되는지, 기본값과 다른지 어떻게 감지할 수 있나요?**

예. 프레젠테이션을 로드하고 [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslidesize/)를 호출하십시오. [SlideSize.getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/getsize/), [SlideSize.getOrientation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/getorientation/)을 사용하여 현재 설정을 예상 프리셋 및 차원과 비교하십시오.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인할 방법이 있나요?**

예. 각 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/)를 찾아 [ChartData.getDataSourceType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)를 호출하십시오. 외부 워크북인 경우 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)를 호출하면 됩니다. 데이터 소스 유형과 경로가 외부 참조를 나타내지만, 대상이 실제로 사용 가능한지는 별도의 리소스 검사가 필요합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**

단일 복잡성 속성은 없습니다. [Presentation.getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/)와 각 슬라이드의 [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/#getShapes) 컬렉션을 순회하십시오. 도형 수, 큰 이미지, 효과, 애니메이션 또는 멀티미디어 존재 여부를 스크리닝 신호로 활용하고, 대표적인 렌더링 또는 내보내기 시간을 측정한 뒤 슬라이드를 성능 병목으로 확정하십시오.