---
title: Java에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/java/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- Java
- Aspose.Slides
description: "Java에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 콘텐츠 크기를 조정하고, 섹션을 보존하며, 보호된 파일이나 대용량 파일을 처리하여 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배우세요."
---
## **개요**

Aspose.Slides for Java 은 한 [프레젠테이션](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)의 슬라이드를 복제하여 다른 프레젠테이션에 병합합니다. 주요 작업은 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)이며, 이는 원본 슬라이드의 서식을 보존하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서에서는 가장 일반적인 병합 작업 흐름을 다룹니다:

- 원본 서식을 보존하면서 모든 슬라이드 병합;
- 선택한 슬라이드 병합;
- 대상 프레젠테이션의 마스터 적용;
- 대상 프레젠테이션의 특정 레이아웃 적용;
- 병합 전에 서로 다른 슬라이드 크기 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 엔드‑투‑엔드 워크플로우로 병합;
- 마스터, 리소스, 노트, 댓글, 미디어, 글꼴, 암호, 대용량 파일 및 멀티스레딩 관련 문제 처리.

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터에서 외관의 대부분을 상속받습니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방식으로 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/)을 사용하십시오:

- `addClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 보존합니다. 필요할 경우, 원본 마스터가 자동으로 대상 프레젠테이션에 복제됩니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 마스터를 사용하는 반복 슬라이드가 마스터를 여러 번 복제하지 않도록 합니다.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 레이아웃 유형이나 이름을 기준으로 해당 마스터 아래에 일치하는 레이아웃을 찾습니다.
- `addClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilayoutslide/)에 직접 연결합니다.

`addClone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션을 병합하고 원본 서식 보존**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 이는 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합한 선택입니다.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

원본과 대상이 서로 다른 디자인을 사용할 경우, 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 보존할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

사용자 입력이나 외부 구성에서 슬라이드 인덱스를 가져오는 경우, 복제 전에 인덱스를 검증하십시오.

## **대상 마스터 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 포함된 마스터를 사용하도록 하려면 [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 오버로드를 사용하십시오.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides는 원본 레이아웃의 유형 또는 이름과 일치하는 레이아웃을 지정된 마스터 아래에서 선택합니다. 적합한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 원본 레이아웃이 복제되어 슬라이드를 추가할 수 있습니다. `false`이면 [PptxEditException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptxeditexception/)이 발생합니다.

추가 레이아웃을 대상 마스터에 도입하지 않고 병합을 중단하고 싶다면 `false`를 사용하십시오.

## **특정 대상 레이아웃 사용하여 슬라이드 병합**

가져온 슬라이드가 정확히 지정된 대상 레이아웃을 사용해야 할 경우 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 오버로드를 사용하십시오.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만, 원본 슬라이드 내용이 재설계되는 것은 아닙니다. 원본과 대상 레이아웃의 플레이스홀더 구조가 다르면, 결과를 검사하여 상속된 서식 및 플레이스홀더 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제하면 내용이 자동으로 새로운 캔버스에 맞게 재설계되지 않습니다. 따라서 도형이 이동되거나, 예상치 못하게 스케일되거나, 보이는 슬라이드 영역 밖에 나타날 수 있습니다.

실용적인 방법은 복제 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 메서드는 슬라이드 차원을 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesizescaletype/)은 요청된 크기에 맞게 콘텐츠를 맞춥니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

크기 조정은 메모리 내의 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 원본 그대로 유지해야 한다면, 병합을 위해 별도의 인스턴스를 열어 사용하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재현하지 않습니다. 출력에 섹션이 중요한 경우, 대상 프레젠테이션에서 섹션을 생성하거나 선택한 뒤 [addClone(ISlide, ISection)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)을 사용해 명시적으로 섹션에 슬라이드를 복제하십시오.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 대상에 해당 섹션을 재생성하고 각 원본 슬라이드를 적절한 대상 섹션에 매핑하십시오.

## **여러 프레젠테이션을 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 추가 소스마다 슬라이드 크기를 정규화하며, 각 소스를 복사하는 동안에만 열고, 마지막에 한 번만 파일을 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

이는 가져온 슬라이드의 원본 서식을 보존하는 데 유용한 기본 선례입니다. 출력에 단일 대상 테마를 사용해야 하는 경우, 앞서 보여준 대상‑마스터 또는 대상‑레이아웃 오버로드로 `addClone(slide)` 호출을 교체하십시오.

## **실무 고려 사항**

### **마스터, 레이아웃 및 서식 정확도**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 기록해 동일한 마스터가 중복 복제되는 것을 방지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 기록되지 않으므로, 마스터 구조에 대한 명시적 제어가 필요하지 않는 한 사전 복제를 피하십시오.

동일한 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모양을 제어해야 하는 경우, 대상 마스터나 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **노트 및 댓글**

슬라이드에 연결된 발표자 노트와 슬라이드 댓글은 슬라이드가 복제될 때 함께 복사됩니다. Aspose.Slides는 또한 [프레젠테이션 노트](https://docs.aspose.com/slides/ko/java/presentation-notes/) 및 [프레젠테이션 댓글](https://docs.aspose.com/slides/ko/java/presentation-comments/)을 위한 전용 API를 제공합니다.

노트 페이지 서식이 중요한 경우, 노트 마스터가 프레젠테이션 수준 객체이며 소스 파일마다 다를 수 있으므로 병합된 프레젠테이션을 확인하십시오. 리뷰 워크플로우에서는 서로 다른 작성자나 템플릿에서 파일을 결합한 후 댓글 작성자와 스레드 댓글을 검증하십시오.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 임베드된 오디오, 임베드된 비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하면 Aspose.Slides가 해당 리소스와의 관계를 유지할 수 있습니다.

임베드된 리소스와 링크된 리소스는 다르게 취급해야 합니다. 링크된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 의존하므로, 슬라이드를 복제해도 외부 링크가 임베드된 콘텐츠로 변환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 추적하지만, 이는 서로 다른 소스 프레젠테이션에서 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적 보장을 의미하지는 않습니다. 출력 파일 크기가 중요한 경우, 병합된 패키지를 직접 검사하고 결과를 측정하여 암시적 중복 제거에만 의존하지 마십시오.

### **임베드된 글꼴 및 글꼴 가용성**

글꼴은 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 기계 간에 일관되어야 한다면, 슬라이드 복제만으로 모든 필요한 글꼴이 대상 환경에 존재한다는 것을 가정하지 마십시오. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)를 사용해 임베드된 글꼴을 검사하고, [프레젠테이션에 글꼴 임베드](https://docs.aspose.com/slides/ko/java/embedded-font/)하는 방법에 따라 명시적으로 관리하십시오.

또한 소스 파일에서 사용된 글꼴을 임베드할 권한이 있는지 확인하십시오. 글꼴 라이선스는 임베드를 제한할 수 있습니다.

### **암호로 보호된 프레젠테이션**

암호로 보호된 소스는 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)를 통해 제공하십시오.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션을 사용합니다.
} finally {
    source.dispose();
}
```

암호화된 소스를 열어도 동일한 보호가 자동으로 대상 프레젠테이션에 적용되지 않습니다. 필요에 따라 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체가 포함된 대용량 프레젠테이션은 상당한 메모리를 소비할 수 있습니다. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)은 BLOB 처리 및 임시 파일 사용에 대한 제어를 제공합니다. 대용량 파일 전략에 대해서는 [프레젠테이션 BLOB 관리](https://docs.aspose.com/slides/ko/java/manage-blob/)를 참조하십시오.

대용량 파일의 경우 가능하면 파일 경로에서 직접 로드하고, 각 소스 프레젠테이션을 병합이 끝나는 즉시 해제하며, 워크플로우가 체크포인트를 필요로 하지 않는 한 중간 결과를 반복 저장하지 않도록 하십시오.

### **스레드 안전성**

동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 수정, 저장 또는 복제하지 마십시오. 각 프레젠테이션 인스턴스를 하나의 병합 작업에만 사용하십시오. 독립적인 작업을 병렬화하려면 독립적인 프레젠테이션 인스턴스를 사용하고, [Aspose.Slides 멀티스레딩 가이드](https://docs.aspose.com/slides/ko/java/multithreading/)를 따르십시오.

## **FAQ**

**각 소스 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

대상 마스터나 레이아웃을 제공하지 않고 [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)을 사용하십시오. Aspose.Slides는 가져온 슬라이드에 필요할 경우 원본 마스터를 자동으로 복제합니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 대상 프레젠테이션에 존재하는 마스터를 전달하고, 소스에서 마스터를 전달하지 마십시오. Aspose.Slides는 해당 마스터 아래에서 원본 레이아웃 유형이나 이름에 맞는 레이아웃을 매핑하려 시도합니다.

**특정 대상 레이아웃을 사용해야 할 때와 대상 마스터를 사용해야 할 때는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 하면 특정 레이아웃을 사용하십시오. 원본 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중에서 선택하도록 하려면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

가능하지만 슬라이드 내용이 자동으로 새로운 차원에 맞게 재설계되지 않습니다. 예측 가능한 위치 지정이 필요하면 [SlideSize.setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesize/#setSize-float-float-int-)와 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesizescaletype/)을 사용해 원본 프레젠테이션을 먼저 크기 조정하십시오.

**PPT, PPTX, ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

가능합니다. 각 소스 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤, 지원되는 출력 형식으로 저장하십시오. 프레젠테이션 형식마다 지원되는 기능이 정확히 동일하지 않으므로, 교차 형식 병합 후 복잡한 콘텐츠를 검증하십시오. 자세한 내용은 [지원되는 파일 형식](https://docs.aspose.com/slides/ko/java/supported-file-formats/)을 참조하십시오.

**원본 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 자동으로 보존되지 않습니다. 섹션 구조를 유지해야 하면 대상에 필요한 섹션을 재생성하고, 섹션 오버로드인 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)을 사용하십시오.

**발표자 노트와 댓글은 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 댓글 작성자 또는 스레드 리뷰 데이터를 의존하는 워크플로우에서는 병합 결과를 확인하십시오. 이러한 시나리오는 슬라이드 수준 콘텐츠뿐만 아니라 프레젠테이션 수준 구조도 포함합니다.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 처리되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계와 함께 전달됩니다. 외부 링크는 외부에 남아 있으므로, 병합 후에도 해당 파일이나 URL이 접근 가능해야 합니다.

**모든 소스의 임베드된 글꼴이 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 글꼴 배포를 보장하지 마십시오. 대상의 임베드된 글꼴을 검사하고, 타이포그래피가 중요한 경우 글꼴 임베드 또는 외부 글꼴 가용성을 명시적으로 관리하십시오.

**암호가 걸린 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)를 통해 파일을 열고, 일반적으로 슬라이드를 복제하십시오. 출력 보호는 별도로 구성합니다.

**매우 큰 프레젠테이션을 어떻게 처리하나요?**

대용량 바이너리 객체가 메모리를 많이 차지하는 경우 BLOB 관리 옵션을 사용하고, 가능한 경우 파일 경로에서 직접 로드하며, 소스 프레젠테이션은 병합이 끝나는 즉시 해제하고, 최종 결과를 필요할 때만 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

하나의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 사용하지 마십시오. 각 병합 작업마다 별도의 프레젠테이션 인스턴스를 사용하고, 멀티스레딩 가이드를 따르십시오.