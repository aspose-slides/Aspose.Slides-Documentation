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
description: "Java에서 슬라이드를 복제하고 마스터와 레이아웃을 제어하며 슬라이드 콘텐츠 크기를 조정하고 섹션을 보존하고 보호된 파일이나 대용량 파일을 처리함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Java는 프레젠테이션을 하나의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)에서 다른 프레젠테이션으로 슬라이드를 복제하여 병합합니다. 주요 작업은 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)이며, 이는 원본 슬라이드의 서식을 보존하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서에서는 가장 일반적인 병합 워크플로를 다룹니다:

- 원본 서식을 보존하면서 모든 슬라이드 병합;
- 선택된 슬라이드 병합;
- 대상 프레젠테이션의 마스터 적용;
- 대상 프레젠테이션의 특정 레이아웃 적용;
- 병합 전 서로 다른 슬라이드 크기 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 엔드‑투‑엔드 워크플로로 병합;
- 마스터, 리소스, 노트, 코멘트, 미디어, 글꼴, 비밀번호, 대용량 파일 및 멀티스레딩 관련 사항 처리.

## **슬라이드 복제가 마스터 및 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터로부터 외观의 대부분을 상속합니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 통합되는 방식이 결정됩니다.

다음 중 하나의 방법으로 [ISlideCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/)을 사용하십시오:

- `addClone(sourceSlide)` — 원본 슬라이드의 레이아웃 및 서식을 보존합니다. 필요할 경우 원본 마스터가 대상 프레젠테이션으로 자동 복제될 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 원본 마스터를 사용하는 반복 슬라이드가 마스터를 반복 복제하는 것을 방지합니다.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 레이아웃 유형 또는 이름으로 해당 마스터 아래에서 일치하는 레이아웃을 찾습니다.
- `addClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 직접 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilayoutslide/)에 연결합니다.

`addClone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 원본 서식 보존**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션으로 복사합니다. 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 경우 적합한 선택입니다.

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

원본과 대상이 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 보존할 때 예상되는 동작입니다.

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

슬라이드 인덱스가 사용자 입력 또는 외부 구성에서 제공되는 경우 복제하기 전에 유효성을 검사하십시오.

## **대상 마스터를 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 속한 마스터를 따라야 할 경우 [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 오버로드를 사용하십시오.

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

Aspose.Slides는 지정된 마스터 아래에서 원본 레이아웃의 유형 또는 이름과 일치하는 적절한 레이아웃을 선택합니다. 적합한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 원본 레이아웃이 복제되어 슬라이드를 추가할 수 있습니다. `false`인 경우 [PptxEditException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptxeditexception/)이 발생합니다.

대상 마스터에 추가 레이아웃을 도입하지 않고 병합을 실패하도록 하려면 `false`를 사용하십시오.

## **특정 대상 레이아웃을 사용하여 슬라이드 병합**

가져온 슬라이드가 사용할 정확한 대상 레이아웃을 알고 있을 때 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 오버로드를 사용하십시오.

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

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만 원본 슬라이드 내용이 재설계되는 것은 아닙니다. 원본 및 대상 레이아웃에 서로 다른 플레이스홀더 구조가 있는 경우 결과를 확인하여 상속된 서식과 플레이스홀더 동작이 적절한지 검증하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

다른 슬라이드 크기를 가진 프레젠테이션도 병합할 수 있지만, 슬라이드를 다른 크기의 프레젠테이션에 복제하면 내용이 새 캔버스에 맞게 자동으로 재설계되지 않습니다. 따라서 도형이 이동되거나 예상치 못하게 스케일이 변하거나 보이는 슬라이드 영역 밖에 나타날 수 있습니다.

실용적인 방법은 복제하기 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 메서드는 슬라이드 크기를 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesizescaletype/)은 콘텐츠를 요청된 크기에 맞게 스케일링합니다.

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

리사이징은 메모리 내의 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 그대로 유지해야 하면 병합을 위해 별도의 인스턴스를 열어야 합니다.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재생성하지 않습니다. 출력에서 섹션이 중요하다면 대상 프레젠테이션에 섹션을 생성하거나 선택하고 [addClone(ISlide, ISection)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)를 사용해 슬라이드를 명시적으로 복제하십시오.

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

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 [Presentation.getSections](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSections--)을 열거하고, 각 원본 섹션의 현재 슬라이드를 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSlidesListOfSection--)으로 가져온 다음, 대상에 섹션을 재생성하고 반환된 각 슬라이드를 해당 대상 섹션에 복제하십시오. 전체 섹션 열거 예제(빈 섹션 및 구조 변경 포함)는 [Manage Slide Sections](/slides/ko/java/slide-section/)를 참고하십시오.

## **여러 프레젠테이션 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 원본의 슬라이드 크기를 정규화하며, 복사 중에만 각 원본을 열어 두고 최종 파일을 한 번 저장합니다.

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

이는 가져온 슬라이드의 원본 서식을 보존하기 위한 유용한 기준선입니다. 출력에 단일 대상 테마를 사용해야 하는 경우, 간단한 `addClone(slide)` 호출을 앞에서 소개한 적절한 대상 마스터 또는 대상 레이아웃 오버로드로 교체하십시오.

## **실용적인 고려 사항**

### **마스터, 레이아웃 및 서식 정확성**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션으로 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 중복 복제하지 않도록 내부 레지스트리를 유지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 추적되지 않으므로 마스터 구조에 대한 명시적 제어가 필요하지 않은 한 사전 복제를 피하십시오.

같은 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모습을 제어해야 하는 경우, 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 확인하십시오.

### **노트 및 코멘트**

발표자 노트와 슬라이드 코멘트는 슬라이드 내용과 연결되어 있으며, 슬라이드가 복제될 때 복사됩니다. Aspose.Slides는 또한 [presentation notes](/slides/ko/java/presentation-notes/) 및 [presentation comments](/slides/ko/java/presentation-comments/)에 대한 전용 API를 제공합니다.

노트 페이지 서식이 중요한 경우, 노트 마스터가 프레젠테이션 수준 객체이며 원본 파일마다 다를 수 있으므로 병합된 프레젠테이션을 확인하십시오. 검토 워크플로에서는 다른 작성자나 템플릿의 파일을 결합한 후 코멘트 작성자와 스레드된 코멘트도 확인하십시오.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 삽입된 오디오, 삽입된 비디오 및 OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하고 보이는 도형만 복사하지 않으면 Aspose.Slides가 슬라이드와 리소스 간의 관계를 유지할 수 있습니다.

임베드된 리소스와 링크된 리소스는 다르게 처리해야 합니다. 링크된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 종속된 상태로 남으며, 슬라이드를 복제해도 외부 링크가 임베드된 콘텐츠로 변환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 명시적으로 추적하지만, 이는 서로 다른 원본 프레젠테이션의 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보증으로 간주해서는 안 됩니다. 출력 파일 크기가 중요하다면, 암시적 중복 제거에 의존하기보다 병합된 패키지를 검사하고 결과를 측정하십시오.

### **임베드된 글꼴 및 글꼴 가용성**

글꼴은 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 기계 간에 일관되어야 한다면, 슬라이드 복제만으로 모든 필요한 글꼴이 대상 환경에 제공된다고 가정하지 마십시오. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)으로 임베드된 글꼴을 검사하고 [Embed Fonts in Presentations](/slides/ko/java/embedded-font/)에 설명된 대로 임베드 작업을 명시적으로 관리할 수 있습니다.

또한 원본 파일에서 사용된 글꼴을 임베드할 권한이 있는지 확인하십시오. 글꼴 라이선스는 임베드를 제한할 수 있습니다.

### **암호로 보호된 프레젠테이션**

암호로 보호된 원본은 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)를 통해 제공하십시오.

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

암호화된 원본을 열어도 동일한 보호가 자동으로 대상 프레젠테이션에 적용되지 않습니다. 필요에 따라 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함한 대용량 프레젠테이션은 상당한 메모리를 소비할 수 있습니다. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)는 BLOB 처리 및 임시 파일 사용에 대한 제어를 제공합니다. 대용량 파일 전략은 [Manage Presentation BLOBs](/slides/ko/java/manage-blob/)를 참고하십시오.

대용량 파일의 경우 가능하면 파일 경로에서 로드하고, 병합이 완료되면 각 원본 프레젠테이션을 즉시 해제하며, 워크플로가 체크포인트를 요구하지 않는 한 중간 결과를 반복 저장하는 것을 피하십시오.

### **스레드 안정성**

여러 스레드에서 동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 동시에 로드, 수정, 저장 또는 복제하지 마십시오. 각 프레젠테이션 인스턴스는 하나의 병합 작업에만 사용하십시오. 독립적인 작업을 병렬화하는 경우 독립적인 프레젠테이션 인스턴스를 사용하고 [Aspose.Slides multithreading guidance](/slides/ko/java/multithreading/)를 따르십시오.

## **FAQ**

**원본 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

[addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)을 사용하고 대상 마스터나 레이아웃을 제공하지 않으십시오. Aspose.Slides는 가져온 슬라이드에 필요할 때 원본 마스터를 자동으로 복제할 수 있습니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 원본이 아닌 대상 프레젠테이션의 마스터를 전달합니다. Aspose.Slides는 각 원본 슬라이드를 해당 마스터 아래의 적절한 레이아웃에 매핑하려고 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 하는 경우는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 때는 특정 레이아웃을 사용하십시오. 원본 레이아웃 유형 또는 이름에 따라 해당 마스터의 레이아웃 중에서 선택하도록 Aspose.Slides가 하길 원한다면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

예, 하지만 슬라이드 내용이 대상 차원에 맞게 자동으로 재설계되지는 않습니다. 예측 가능한 배치가 필요할 경우 먼저 원본 프레젠테이션의 크기를 조정하십시오. 예를 들어 [SlideSize.setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 및 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesizescaletype/)를 사용할 수 있습니다.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 원본 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤 지원되는 출력 형식으로 저장하십시오. 프레젠테이션 형식마다 정확히 동일한 기능을 지원하지 않으므로, 교차 형식 병합 후 복합 콘텐츠를 확인하십시오. [Supported File Formats](/slides/ko/java/supported-file-formats/)를 참고하십시오.

**원본 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 자동으로 보존되지 않습니다. 대상에 필요한 섹션을 재생성하고 섹션 구조를 보존해야 할 경우 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)의 섹션 오버로드를 사용하십시오.

**발표자 노트와 코멘트가 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 코멘트 작성자, 스레드된 검토 데이터에 의존하는 워크플로의 경우, 이러한 시나리오는 프레젠테이션 수준 구조와 슬라이드 수준 콘텐츠를 모두 포함하므로 병합 결과를 확인하십시오.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계의 일부로 전달됩니다. 외부 링크는 외부에 남아 있으므로 병합 후에도 대상 파일이나 URL이 여전히 사용 가능해야 합니다.

**각 원본의 임베드된 글꼴이 병합된 프레젠테이션에 보장되나요?**

글꼴 배포를 위해 슬라이드 복제만에 의존하지 마십시오. 타이포그래피가 중요할 경우, 대상의 임베드된 글꼴을 검사하고 글꼴 임베드 또는 외부 글꼴 가용성을 명시적으로 관리하십시오.

**암호로 보호된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)으로 파일을 연 다음, 슬라이드를 일반적으로 복제하십시오. 출력 보호는 별도로 구성됩니다.

**매우 큰 프레젠테이션을 어떻게 처리해야 하나요?**

대형 바이너리 객체가 메모리 사용을 지배할 경우 BLOB 관리를 사용하고, 매우 큰 파일은 파일 경로 로드를 선호하며, 원본 프레젠테이션을 즉시 해제하고, 필요할 때만 최종 결과를 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

여러 스레드에서 하나의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 동시에 사용하지 마십시오. 각 병합 작업은 자체 프레젠테이션 인스턴스로 분리하십시오.