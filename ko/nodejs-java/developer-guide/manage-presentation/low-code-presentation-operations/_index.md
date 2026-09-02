---
title: JavaScript에서 Low-Code 프레젠테이션 작업
linktitle: Low-Code API
type: docs
weight: 50
url: /ko/nodejs-java/low-code-presentation-operations/
keywords:
- Low-Code 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 순회
- 도형 순회
- 텍스트 순회
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않은 마스터 슬라이드 제거
- 사용되지 않은 레이아웃 슬라이드 제거
- 내장 폰트 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 Aspose.Slides Low-Code API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

`aspose.slides` 네임스페이스는 일반적인 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이러한 헬퍼는 자주 사용되는 오브젝트 모델 워크플로를 집중된 메서드로 래핑하여 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하고, 사용되지 않은 콘텐츠를 더 적은 코드로 제거할 수 있습니다.

Low-code 헬퍼는 작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 맞을 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요할 경우 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/)을 사용하세요.

다음 표는 사용 가능한 헬퍼를 요약한 것입니다:

| 헬퍼 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/) | 프레젠테이션을 다른 형식으로 변환하며 파일 간 직접 호출을 사용합니다. |
| [Merger](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/) | 동일 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리하거나 분석합니다. |
| [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 폰트 데이터를 줄입니다. |

## **프레젠테이션 변환**

출력 파일 확장자만으로 내보내기 형식을 선택할 수 있을 때는 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/#autoByExtension)를 사용하십시오. 이 메서드는 소스 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 판단한 뒤 결과를 기록합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나 선택된 헬퍼에서 제공하지 않는 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [Convert Presentation](/slides/ko/nodejs-java/convert-presentation/)를 참조하십시오.

## **프레젠테이션 병합**

[Merger.process](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/#process)를 사용하여 한 번의 호출로 전체 프레젠테이션 파일을 결합하십시오. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

이 헬퍼는 모든 슬라이드를 하나의 결과로 순차적으로 추가하고 개별 슬라이드를 선택하거나 재매핑할 필요가 없을 때 적합합니다. 선택된 슬라이드를 병합하거나 대상 마스터 또는 레이아웃을 적용하고, 섹션을 명시적으로 보존하거나, 서로 다른 슬라이드 크기를 조정해야 하는 경우 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/slides/ko/nodejs-java/merge-presentation/)를 참조하십시오.

## **프레젠테이션 요소 반복**

[ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) 클래스는 요청된 유형의 프레젠테이션 요소 각각에 대해 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체 검사나 서식 변경에 편리합니다. Node.js에서는 `java.newProxy`를 사용해 콜백 인터페이스 구현을 생성합니다.

다음 예제는 [ForEach.slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#paragraph), 및 [ForEach.portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#portion)을 사용해 해당 요소들을 검사합니다:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회는 일반 슬라이드, 마스터 슬라이드 및 레이아웃 슬라이드를 포함합니다. `includeNotes` 매개변수가 있는 오버로드는 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링 또는 상세한 부모-자식 제어가 중요할 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

[Collect.shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/#shapes)를 사용하면 각 도형에 대한 콜백 대신 프레젠테이션의 모든 도형 컬렉션을 얻을 수 있습니다. 동일한 세트를 여러 번 필터링하거나 카운트하거나 처리해야 할 때 유용합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

각 도형을 즉시 처리하고 수집된 결과를 유지할 필요가 없을 경우 [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape)을 대신 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 폰트 데이터를 줄일 수 있습니다:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) : 일반 슬라이드에서 참조되지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) : 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) : 포함된 폰트에서 사용되지 않는 문자들을 제거합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사용되지 않는 레이아웃을 먼저 제거하고 그 다음 사용되지 않은 마스터를 제거하십시오. 레이아웃 정리 후에 참조되지 않게 된 마스터도 제거될 수 있습니다. 원본 마스터, 레이아웃 또는 전체 포함 폰트 데이터를 나중에 필요할 수 있다면 최적화된 프레젠테이션을 새 파일로 저장하십시오. 자세한 내용은 [Slide Master](/slides/ko/nodejs-java/slide-master/) 및 [Embedded Font](/slides/ko/nodejs-java/embedded-font/)를 확인하십시오.

## **FAQ**

**언제 전체 객체 모델 대신 Low-code API를 사용해야 하나요?**

표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 자세한 제어가 필요 없을 때 Low-code 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터 및 레이아웃 관계를 제어하고, 중간 상태를 검사하거나 헬퍼가 노출하지 않은 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger.process](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/#process)는 동일한 형식의 입력 프레젠테이션이 필요합니다. 먼저 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/#autoByExtension)를 사용해 입력 파일을 공통 형식으로 변환한 뒤 변환된 파일을 병합하십시오.

**ForEach가 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach.slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#slide) 은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체 [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#paragraph), 및 [ForEach.portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#portion) 작업은 기본적으로 일반, 마스터 및 레이아웃 슬라이드를 포함합니다. 노트 슬라이드를 포함하려면 `includeNotes`를 `true`로 설정한 오버로드를 사용하십시오.

**ForEach.shape와 Collect.shapes의 차이점은 무엇인가요?**

[ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape)을 사용하면 콜백을 통해 각 도형을 즉시 처리합니다. [Collect.shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/#shapes)은 유지, 필터링, 카운트 또는 여러 번 순회할 수 있는 반복 가능한 결과가 필요할 때 사용합니다.

**Compress가 항상 프레젠테이션 파일을 작게 만들나요?**

항상 그렇지는 않습니다. 결과는 프레젠테이션에 사용되지 않는 레이아웃, 사용되지 않는 마스터 또는 사용되지 않은 문자가 포함된 포함 폰트가 있는지에 따라 달라집니다. 해당 항목이 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**ForEach나 Compress가 수행한 변경 사항이 자동으로 저장되나요?**

아니요. 이러한 헬퍼는 메모리 내에 로드된 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 객체에서 작동합니다. [ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/)를 실행한 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save)를 호출해 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [프레젠테이션 변환](/slides/ko/nodejs-java/convert-presentation/)
- [프레젠테이션 병합](/slides/ko/nodejs-java/merge-presentation/)
- [슬라이드 마스터](/slides/ko/nodejs-java/slide-master/)
- [텍스트 상자 관리](/slides/ko/nodejs-java/manage-textbox/)
- [포함 폰트](/slides/ko/nodejs-java/embedded-font/)