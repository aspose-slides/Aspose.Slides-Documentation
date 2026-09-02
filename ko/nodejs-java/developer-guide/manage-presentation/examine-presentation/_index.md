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
description: "JavaScript를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고 빠른 인사이트와 스마트한 콘텐츠 감사를 실현합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션의 형식을 식별하고 전체 프레젠테이션 개체 모델을 만들지 않고도 문서 메타데이터를 읽을 수 있습니다. 파일을 분류하거나 인벤토리를 구축하거나 프레젠테이션 콘텐츠를 로드하고 처리할지 결정하기 전에 속성을 검사해야 할 때 유용합니다.

이 문서에서는 [PresentationFactory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/)와 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/)를 통한 경량 검사와 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/)를 통한 대상 업데이트를 보여줍니다.

## **프레젠테이션 형식 확인**

파일을 검사하면서 [Presentation] 인스턴스를 만들지 않으려면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용합니다. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/getloadformat/) 메서드는 PPTX, PPT, ODP와 같은 감지된 형식을 보고합니다.

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

많은 프레젠테이션 파일을 처리할 때, 검증, 인덱싱 또는 문서 관리 시스템을 위한 간결한 인벤토리가 필요할 수 있습니다. 이 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용해 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/) 객체를 얻고, 이어서 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)를 호출해 문서 메타데이터를 읽습니다. 이 방법은 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 생성하거나 전체 프레젠테이션 개체 모델을 탐색할 필요가 없습니다.

[DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/)가 노출하는 확장 속성은 다음 인벤토리 값을 제공합니다:

| 메서드 | 인벤토리 값 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getSlides) | 전체 슬라이드 수. |
| [getHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 숨김 슬라이드 수. |
| [getNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getNotes) | 노트가 포함된 슬라이드 수. |
| [getParagraphs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 가능한 경우 전체 단락 수. |
| [getWords](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getWords) | 전체 단어 수. |
| [getMultimediaClips](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | 오디오 및 비디오 클립 전체 수. |

다음 예제는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 객체를 만들지 않고 이러한 값을 읽어 간결한 인벤토리를 출력합니다. 또한 [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs)와 [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)를 결합해 폰트, 테마, 슬라이드 제목과 같은 콘텐츠 그룹을 표시합니다.

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
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

각 [HeadingPair](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/)은 [HeadingPair.getName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/#getName)을 통해 그룹 이름을 제공하고, [HeadingPair.getCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/headingpair/#getCount)를 통해 해당 그룹의 항목 수를 제공합니다. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)는 평탄하고 순서가 지정된 배열을 반환하므로, 각 HeadingPair가 지정한 연속된 제목 수만큼 사용합니다.

### **저장된 메타데이터 및 형식 제한**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)가 반환하는 인벤토리 속성은 원본 문서에 존재하는 메타데이터를 반영합니다. Aspose.Slides는 이 호출을 위해 프레젠테이션 개체 모델을 로드하거나 탐색하여 값을 재계산하지 않습니다. 누락된 속성은 기본값으로 표시되며, 마지막으로 파일을 저장한 애플리케이션이 문서 속성을 업데이트하지 않은 경우 저장된 값이 오래될 수 있습니다.

- **PPTX:** 이 형식은 슬라이드, 노트, 숨김 슬라이드, 단락, 단어 및 멀티미디어 수에 대한 확장 문서 속성뿐 아니라 heading pair와 파트 제목을 제공합니다. 이용 가능 여부는 문서 작성자가 어떤 속성을 기록했는지에 따라 다릅니다.
- **PPT:** 이 바이너리 형식은 해당하는 문서 요약 속성을 저장할 수 있습니다. 속성이 없거나 문서 작성자가 새로 고치지 않은 경우, Aspose.Slides는 슬라이드에서 계산하는 대신 저장된 값이나 기본값을 반환합니다.
- **ODP:** OpenDocument 메타데이터는 페이지, 단락, 단어 수와 같은 일반 문서 통계를 제공하지만, 이러한 값은 모든 PowerPoint 특정 확장 속성에 매핑되지 않습니다. 숨김 슬라이드, 노트 슬라이드, 멀티미디어, heading-pair 및 파트 제목 메타데이터가 없을 수 있으며, 인벤토리 속성은 기본값을 반환할 수 있습니다. 0값이나 빈 배열을 해당 콘텐츠가 없다는 확실한 증거로 간주하지 마십시오.

인벤토리 및 사전 검사를 위해 경량 메타데이터 접근 방식을 사용하십시오. 결과가 메모리 내 변경을 반영해야 하거나 실제 프레젠테이션 내용을 확인해야 할 경우 프레젠테이션을 로드하고 실시간 개체 모델을 검사하십시오.

## **프레젠테이션 속성 업데이트**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)가 반환하는 속성은 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 생성하지 않고도 변경할 수 있습니다. 변경 사항은 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/)을 사용해 적용하고, 그런 다음 [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/)으로 바인딩된 프레젠테이션을 저장합니다.

다음 이미지는 원본 문서 속성을 보여줍니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 예제는 제목과 마지막 저장 시간을 변경하고 결과를 새 파일에 기록합니다:

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

관련 보안 검사 및 보호 설정에 대해서는 다음 문서를 참조하십시오:

- [프레젠테이션 암호 보호](/slides/ko/nodejs-java/password-protected-presentation/)
- [프레젠테이션 쓰기 보호](/slides/ko/nodejs-java/write-protected-presentation/)

## **자주 묻는 질문**

**폰트가 임베드되어 있는지와 어떤 폰트인지 어떻게 확인할 수 있나요?**  
프레젠테이션을 로드하고 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getfontsmanager/)를 사용합니다. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)를 호출해 임베드된 폰트를 가져오고, [FontsManager.getFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/)를 호출해 프레젠테이션이 사용하는 폰트를 가져옵니다. 두 결과를 비교하여 렌더링에 필요하지만 임베드되지 않은 폰트를 찾습니다.

**파일에 숨김 슬라이드가 있는지와 그 수를 빠르게 확인하려면 어떻게 해야 하나요?**  
저장된 문서 메타데이터만으로 충분하면 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides)를 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)와 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)를 통해 읽습니다. 이는 경량 인벤토리에 적합합니다. 프레젠테이션이 메모리에서 수정된 경우 저장된 메타데이터가 없거나 오래됐을 수 있으며, 실시간 값을 확인하려면 [Presentation.getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/)를 순회하고 각 슬라이드의 [Slide.getHidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/gethidden/) 메서드를 검사하십시오.

**사용자 지정 슬라이드 크기와 방향이 사용되는지, 그리고 기본값과 다른지 확인할 수 있나요?**  
예. 프레젠테이션을 로드하고 [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslidesize/)를 호출합니다. [SlideSize.getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/getsize/), [SlideSize.getOrientation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/getorientation/)을 사용해 현재 설정을 예상 프리셋 및 크기와 비교합니다.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인하는 방법이 있나요?**  
예. 각 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/)를 찾은 다음 [ChartData.getDataSourceType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)을 호출합니다. 외부 워크북인 경우 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)를 호출합니다. 데이터 소스 유형과 경로가 외부 참조를 나타내지만, 대상이 사용 가능한지 확인하려면 별도의 리소스 검사가 필요합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무거운' 슬라이드를 어떻게 평가할 수 있나요?**  
단일 복잡도 속성은 없습니다. [Presentation.getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/)와 각 슬라이드의 [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/#getShapes) 컬렉션을 탐색하십시오. 도형 수와 큰 이미지, 효과, 애니메이션, 멀티미디어 존재 여부를 판단 신호로 사용하고, 슬라이드를 확실한 성능 병목으로 간주하기 전에 대표적인 렌더링이나 내보내기 시간을 측정하십시오.