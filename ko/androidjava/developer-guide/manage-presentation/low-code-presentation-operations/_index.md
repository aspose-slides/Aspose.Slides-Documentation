---
title: Android에서 로우코드 프레젠테이션 작업
linktitle: 로우코드 API
type: docs
weight: 50
url: /ko/androidjava/low-code-presentation-operations/
keywords:
- 로우코드 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 반복
- 도형 반복
- 텍스트 반복
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않은 마스터 슬라이드 제거
- 사용되지 않은 레이아웃 슬라이드 제거
- 임베디드 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 Aspose.Slides 로우코드 API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 반복하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

[com.aspose.slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/) 패키지는 일반적인 프레젠테이션 작업을 위한 정적 도우미 클래스를 제공합니다. 이러한 도우미는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 감싸서 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하며, 사용되지 않은 콘텐츠를 더 적은 코드로 제거할 수 있게 합니다.

작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 맞을 때 Low-code 도우미가 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간의 관계를 세밀하게 제어해야 할 경우 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 도우미들을 요약합니다:

| 도우미 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/) | 프레젠테이션을 직접 파일-파일 호출로 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) | 각 슬라이드, 도형, 단락, 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) | 사용되지 않은 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소합니다. |

## **프레젠테이션 변환**

[Convert.autoByExtension](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)을 사용하면 출력 파일 확장자로 내보내기 형식을 선택하기에 충분합니다. 이 메서드는 소스 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 기록합니다.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/) 클래스는 PDF, SVG, JPEG, PNG, TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나 선택된 도우미에서 제공하지 않는 내보내기 옵션을 구성해야 할 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로 및 옵션은 [Convert Presentation](/slides/ko/androidjava/convert-presentation/)를 참조하세요.

## **프레젠테이션 병합**

[Merger.process](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-)를 사용하면 한 번의 호출로 전체 프레젠테이션 파일을 결합할 수 있습니다. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

모든 슬라이드를 하나의 결과에 순차적으로 추가해야 하고 개별 슬라이드 선택이나 매핑이 필요 없는 경우 이 도우미가 적합합니다. 선택된 슬라이드를 병합하거나 대상 마스터 또는 레이아웃을 적용하고, 섹션을 명시적으로 보존하거나, 서로 다른 슬라이드 크기를 조정해야 할 경우 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/slides/ko/androidjava/merge-presentation/)를 참고하세요.

## **프레젠테이션 요소 반복**

[ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) 클래스는 요청된 각 프레젠테이션 요소 유형에 대해 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체에 대한 검사 또는 서식 변경에 편리합니다.

다음 예제는 [ForEach.slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), 및 [ForEach.portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-)을 사용하여 해당 요소들을 검사합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회는 일반, 마스터 및 레이아웃 슬라이드를 포함합니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링, 상세한 부모-자식 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

[Collect.shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)를 사용하면 각 도형에 대한 콜백 대신 프레젠테이션 전체 도형 컬렉션이 필요할 때 유용합니다. 동일한 도형 집합을 여러 번 필터링, 카운트 또는 처리해야 할 경우에 적합합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

각 도형을 즉시 처리하고 수집된 결과를 유지할 필요가 없는 경우 [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)을 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) 클래스는 사용되지 않은 구조 요소를 제거하고 포함된 글꼴 데이터를 줄일 수 있습니다:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)은 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)은 포함된 글꼴에서 사용되지 않는 문자들을 제거합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사용되지 않은 레이아웃을 먼저 제거한 다음 사용되지 않은 마스터를 제거하십시오. 이렇게 하면 레이아웃 정리 후 참조되지 않게 된 마스터도 제거할 수 있습니다. 나중에 원본 마스터, 레이아웃 또는 전체 포함 글꼴 데이터가 필요할 수 있으므로 최적화된 프레젠테이션을 새 파일에 저장하세요. 자세한 내용은 [Slide Master](/slides/ko/androidjava/slide-master/)와 [Embedded Font](/slides/ko/androidjava/embedded-font/)를 참조하십시오.

## **FAQ**

**저코드 API를 전체 객체 모델 대신 언제 사용해야 하나요?**

표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 세부 제어가 필요하지 않을 때 Low-code 도우미를 사용하십시오. 특정 슬라이드를 선택하거나 마스터와 레이아웃 관계를 제어하고, 중간 상태를 검사하거나 도우미가 제공하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하세요.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger.process](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-)는 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert.autoByExtension](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) 등을 사용하여 입력 파일을 공통 형식으로 변환한 다음 변환된 파일을 병합하십시오.

**ForEach가 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach.slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)은 일반 프레젠테이션 슬라이드를 순회합니다. 프레젠테이션 전체에 걸친 [ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), 및 [ForEach.portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 작업은 기본적으로 일반, 마스터 및 레이아웃 슬라이드를 포함합니다. 노트 슬라이드를 포함하려면 `includeNotes`를 `true`로 설정한 오버로드를 사용하십시오.

**ForEach.shape와 Collect.shapes의 차이점은 무엇인가요?**

[ForEach.shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)을 사용하면 콜백을 통해 각 도형을 즉시 처리할 수 있습니다. 반복 가능한 결과를 유지하고, 필터링하거나, 카운트하거나, 여러 번 순회해야 할 경우에는 [Collect.shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-)을 사용하십시오.

**Compress가 항상 프레젠테이션 파일을 작게 만들나요?**

반드시 그렇지는 않습니다. 프레젠테이션에 사용되지 않은 레이아웃, 사용되지 않은 마스터, 혹은 사용되지 않은 문자를 포함한 포함 글꼴이 있는지 여부에 따라 결과가 달라집니다. 이러한 요소가 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**ForEach 또는 Compress가 수행한 변경 사항이 자동으로 저장되나요?**

아니요. 이러한 도우미는 메모리의 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 객체에서 작동합니다. [ForEach](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/)를 실행한 후에는 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)을 호출하여 결과를 파일에 기록해야 합니다.

## **관련 문서**

- [Convert Presentation](/slides/ko/androidjava/convert-presentation/)
- [Merge Presentations](/slides/ko/androidjava/merge-presentation/)
- [Slide Master](/slides/ko/androidjava/slide-master/)
- [Manage Text Box](/slides/ko/androidjava/manage-textbox/)
- [Embedded Font](/slides/ko/androidjava/embedded-font/)