---
title: JavaScript에서 로우코드 프레젠테이션 작업
linktitle: 로우코드 API
type: docs
weight: 50
url: /ko/nodejs-java/low-code-presentation-operations/
keywords:
- 로우코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 반복
- 도형 반복
- 텍스트 반복
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 포함된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 반복하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

`aspose.slides` 네임스페이스는 일반적인 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이러한 헬퍼는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 감싸므로 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하며, 도형을 수집하고, 사용되지 않는 콘텐츠를 보다 적은 코드로 제거할 수 있습니다.

작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로가 요구사항에 맞을 때 로우코드 헬퍼가 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요하면 전체 [Aspose.Slides 객체 모델](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 헬퍼를 요약한 것입니다:

| 헬퍼 | 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/) | 직접 파일 간 호출로 프레젠테이션을 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) | 각 슬라이드, 도형, 단락 또는 텍스트 조각에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리하거나 분석합니다. |
| [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소합니다. |

## **프레젠테이션 변환**

출력 파일 확장자가 내보내기 형식을 선택하기에 충분할 때는 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/#autoByExtension)를 사용합니다. 이 메서드는 소스 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 씁니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정하거나 선택한 헬퍼가 제공하지 않는 옵션을 구성해야 할 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로와 옵션은 [프레젠테이션 변환](/nodejs-java/convert-presentation/)을 참조하세요.

## **프레젠테이션 병합**

[Merger.process](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/#process)를 사용하면 하나의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

이 헬퍼는 개별 슬라이드를 선택하거나 재매핑하지 않고 모든 슬라이드를 하나의 결과에 추가해야 할 때 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터 또는 레이아웃을 적용하거나 섹션을 명시적으로 보존하거나 서로 다른 슬라이드 크기를 조정해야 할 경우 전체 객체 모델을 사용하십시오. 해당 시나리오는 [프레젠테이션 병합](/nodejs-java/merge-presentation/)을 참고하세요.

## **프레젠테이션 요소 반복**

[ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) 클래스는 요청된 유형의 프레젠테이션 요소마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체에 대한 검사 또는 형식 변경에 편리합니다. Node.js에서는 `java.newProxy`로 콜백 인터페이스 구현을 생성합니다.

다음 예제는 [ForEach.slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#paragraph) 및 [ForEach.portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#portion)를 사용해 해당 요소를 검사합니다:

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

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회에는 일반 슬라이드, 마스터 슬라이드, 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링 또는 자세한 부모‑자식 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

프레젠테이션 내 모든 도형의 컬렉션이 필요하고 각 도형에 대해 즉시 콜백을 실행할 필요가 없을 때는 [Collect.shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/#shapes)를 사용하십시오. 동일한 집합을 여러 번 필터링하거나 계산하거나 처리하려는 경우에 유용합니다.

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

각 도형을 즉시 처리하고 수집된 결과를 유지할 필요가 없을 경우에는 대신 [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape)를 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스는 사용되지 않는 구조 요소를 제거하고 포함된 글꼴 데이터를 축소할 수 있습니다:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 은 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) 은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) 은 포함된 글꼴에서 사용되지 않는 문자를 제거합니다.

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

먼저 사용되지 않는 레이아웃을 제거한 후 사용되지 않는 마스터를 제거하십시오. 레이아웃 정리 후에 참조되지 않게 된 마스터도 삭제될 수 있습니다. 원본 마스터, 레이아웃 또는 전체 포함 글꼴 데이터를 나중에 필요할 수 있다면 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [슬라이드 마스터](/nodejs-java/slide-master/)와 [포함 글꼴](/nodejs-java/embedded-font/)을 참고하세요.

## **FAQ**

**전체 객체 모델 대신 로우코드 API를 사용해야 하는 경우는 언제인가요?**

표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 세부 제어가 필요하지 않을 때 로우코드 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터 및 레이아웃 관계를 제어하거나 중간 상태를 검사하거나 헬퍼가 제공하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger.process](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/merger/#process)는 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/convert/#autoByExtension) 등으로 입력 파일을 공통 형식으로 변환한 다음 병합하십시오.

**ForEach는 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach.slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#slide)은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에서 [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#paragraph), [ForEach.portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#portion) 작업은 기본적으로 일반, 마스터, 레이아웃 슬라이드를 포함합니다. 노트 슬라이드를 포함하려면 `includeNotes`를 `true`로 설정한 오버로드를 사용하십시오.

**ForEach.shape와 Collect.shapes의 차이점은 무엇인가요?**

각 도형을 콜백을 통해 즉시 처리하려면 [ForEach.shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/#shape)를 사용하십시오. 도형 컬렉션을 보관하고, 필터링하고, 여러 번 계산하거나 순회할 필요가 있을 때는 [Collect.shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/collect/#shapes)를 사용하십시오.

**Compress는 항상 프레젠테이션 파일을 작게 만들까요?**

반드시 그렇지는 않습니다. 프레젠테이션에 사용되지 않은 레이아웃, 사용되지 않은 마스터 또는 사용되지 않은 문자를 포함한 글꼴이 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 작업이 파일 크기를 감소시키지 않을 수 있습니다.

**ForEach나 Compress가 수행한 변경 사항이 자동으로 저장되나요?**

아니요. 이러한 헬퍼는 메모리의 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 객체에서 작업합니다. [ForEach](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/)를 실행한 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save)를 호출해 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [프레젠테이션 변환](/nodejs-java/convert-presentation/)
- [프레젠테이션 병합](/nodejs-java/merge-presentation/)
- [슬라이드 마스터](/nodejs-java/slide-master/)
- [텍스트 상자 관리](/nodejs-java/manage-textbox/)
- [포함 글꼴](/nodejs-java/embedded-font/)