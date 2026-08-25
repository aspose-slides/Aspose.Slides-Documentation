---
title: JavaScript에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 슬라이드를 복제하고 마스터와 레이아웃을 제어하며 슬라이드 콘텐츠 크기를 조정하고 섹션을 보존하고 보호된 파일이나 대용량 파일을 처리함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 슬라이드를 복제하여 한 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)에서 다른 프레젠테이션으로 병합합니다. 주요 작업은 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)이며, 원본 슬라이드의 서식을 유지하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서는 가장 일반적인 병합 워크플로우를 다룹니다:

- 원본 서식을 유지하면서 모든 슬라이드 병합;
- 선택한 슬라이드만 병합;
- 대상 프레젠테이션의 마스터 적용;
- 대상 프레젠테이션의 특정 레이아웃 적용;
- 병합 전에 서로 다른 슬라이드 크기 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 종단 간 워크플로우로 병합;
- 마스터, 리소스, 노트, 댓글, 미디어, 폰트, 비밀번호, 대용량 파일 및 멀티스레딩 문제 처리.

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드의 외관 대부분은 레이아웃과 마스터에서 상속됩니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방법으로 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)을 사용하세요:

- `addClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 유지합니다. 필요 시 원본 마스터가 자동으로 대상 프레젠테이션에 복제될 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 같은 마스터를 사용하는 반복 슬라이드가 반복 복제되는 것을 방지합니다.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 특정 목적지 [MasterSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/)에 복제된 슬라이드를 연결합니다. Aspose.Slides는 레이아웃 유형이나 이름으로 해당 마스터 아래 일치하는 레이아웃을 찾습니다.
- `addClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 특정 목적지 [LayoutSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/)에 직접 연결합니다.

`addClone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 원본 서식 유지**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합한 선택입니다.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

소스와 대상이 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 유지할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 소스 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

사용자 입력이나 외부 구성에서 가져온 경우 복제하기 전에 슬라이드 인덱스를 검증하세요.

## **대상 마스터 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 속한 마스터를 따라야 할 경우 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 오버로드를 사용하세요.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides는 소스 레이아웃의 유형이나 이름을 일치시켜 지정된 마스터 아래 적절한 레이아웃을 선택합니다. 적합한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 소스 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `false`이면 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxeditexception/)이 발생합니다.

추가 레이아웃을 대상 마스터에 도입하고 싶지 않고 병합을 실패하도록 하려면 `false`를 사용하세요.

## **특정 대상 레이아웃 사용하여 슬라이드 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용할지 알고 있는 경우 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) 오버로드를 사용하세요.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계만 변경되며, 소스 슬라이드 내용 자체가 재설계되지 않습니다. 소스와 대상 레이아웃의 플레이스홀더 구조가 다르면 상속된 서식과 플레이스홀더 동작이 적절한지 결과를 확인하세요.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기의 프레젠테이션에 슬라이드를 복제해도 콘텐츠가 새로운 캔버스에 맞게 자동으로 재설계되지는 않습니다. 이로 인해 도형이 이동되거나, 비정상적으로 스케일되거나, 보이는 슬라이드 영역 밖에 배치될 수 있습니다.

실용적인 방법은 복제하기 전에 소스 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.setSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) 메서드는 슬라이드 차원을 변경하면서 기존 콘텐츠를 스케일할 수 있습니다. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesizescaletype/)은 요청된 크기에 맞게 콘텐츠를 스케일합니다.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

크기 조정은 메모리상의 소스 프레젠테이션 객체를 변경합니다. 다른 작업에 원본 프레젠테이션을 그대로 유지해야 하는 경우 병합을 위해 별도의 인스턴스를 열어 사용하세요.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 소스 프레젠테이션의 섹션 계층 구조를 재생성하지 않습니다. 출력에서 섹션이 중요하다면 대상 프레젠테이션에 섹션을 만들거나 선택하고, [addClone(Slide, Section)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)을 사용해 슬라이드를 명시적으로 해당 섹션에 복제하세요.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 소스 섹션을 보존하려면 [Presentation.getSections](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getSections)를 열거하고, 각 소스 섹션의 현재 슬라이드를 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSlidesListOfSection)으로 가져온 뒤, 대상에 섹션을 재생성하고 반환된 슬라이드를 해당 대상 섹션에 복제하세요. 전체 섹션 열거 예제는 [Manage Slide Sections](/slides/ko/nodejs-java/slide-section/)를 참조하십시오(빈 섹션 및 구조 변경 포함).

## **여러 프레젠테이션 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 추가 소스마다 슬라이드 크기를 정규화하며, 각 소스를 복사하는 동안만 열어 두고 최종 파일을 한 번만 저장합니다.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

이 방식은 가져온 슬라이드의 원본 서식을 보존하는 데 유용한 기본값입니다. 출력에 단일 대상 테마를 사용해야 하는 경우 앞서 소개한 적절한 대상‑마스터 또는 대상‑레아웃 오버로드로 단순 `addClone(sourceSlide)` 호출을 교체하세요.

## **실용적 고려 사항**

### **마스터, 레이아웃 및 서식 정확성**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 보관해 동일 마스터가 반복 복제되는 것을 방지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 추적되지 않으므로 마스터 구조에 대한 명시적 제어가 필요하지 않은 한 미리 복제하는 것을 피하세요.

동일한 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마세요. 기업 템플릿이 최종 외관을 제어해야 한다면 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **노트 및 댓글**

연설자 노트와 슬라이드 댓글은 슬라이드 내용과 연결되어 있으며 슬라이드가 복제될 때 복사됩니다. Aspose.Slides는 또한 [presentation notes](/slides/ko/nodejs-java/presentation-notes/)와 [presentation comments](/slides/ko/nodejs-java/presentation-comments/)에 대한 전용 API를 제공합니다.

노트 페이지 서식이 중요하다면 병합된 프레젠테이션을 검증하세요. 노트 마스터는 프레젠테이션 수준 객체이며 소스 파일마다 다를 수 있습니다. 리뷰 워크플로우의 경우 다른 작성자 또는 템플릿에서 결합된 파일의 댓글 작성자와 스레드 댓글도 확인하십시오.

### **이미지, 오디오, 비디오, OLE 개체 및 외부 링크**

슬라이드는 이미지, 임베드된 오디오, 임베드된 비디오 및 OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하고 보이는 도형만 복사하지 않아야 Aspose.Slides가 슬라이드와 리소스 간 관계를 유지합니다.

임베드된 리소스와 링크된 리소스는 다르게 취급해야 합니다. 링크된 오디오, 비디오, OLE 개체 또는 하이퍼링크는 외부 대상에 의존하며, 슬라이드를 복제해도 외부 링크가 임베드된 콘텐츠로 변환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하세요.

Aspose.Slides는 자동 복제된 마스터를 명시적으로 추적하지만, 이는 서로 다른 소스 프레젠테이션에서 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보장을 의미하지 않습니다. 출력 파일 크기가 중요하다면 병합된 패키지를 검사하고 결과를 측정하여 암시적 중복 제거에 의존하지 마세요.

### **임베드된 폰트 및 폰트 가용성**

폰트는 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 머신 간에 일관되어야 한다면 슬라이드 복제만으로 모든 필요한 폰트가 대상 환경에 존재한다는 것을 가정하지 마세요. [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)을 사용해 임베드된 폰트를 확인하고, [Embed Fonts in Presentations](/slides/ko/nodejs-java/embedded-font/)에 설명된 대로 임베딩을 명시적으로 관리하십시오.

또한 소스 파일에서 사용된 폰트를 임베드할 수 있는 권한이 있는지 확인하세요. 폰트 라이선스는 임베딩을 제한할 수 있습니다.

### **비밀번호 보호 프레젠테이션**

비밀번호로 보호된 소스는 슬라이드를 복제하기 전에 성공적으로 열려야 합니다. 비밀번호는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)를 통해 제공하세요.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션으로 작업합니다.
} finally {
    source.dispose();
}
```

암호화된 소스를 열었다고 해서 대상 프레젠테이션에 동일한 보호가 자동으로 적용되는 것은 아닙니다. 필요한 경우 별도로 출력 보호를 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함한 대용량 프레젠테이션은 상당한 메모리를 사용할 수 있습니다. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--)은 BLOB 처리 및 임시 파일 사용에 대한 제어를 제공합니다. 대용량 파일 전략은 [Manage Presentation BLOBs](/slides/ko/nodejs-java/manage-blob/)를 참조하세요.

대용량 파일의 경우 가능하면 파일 경로에서 로드하고, 소스 프레젠테이션을 병합이 끝나는 즉시 해제하며, 워크플로우에 체크포인트가 필요하지 않은 한 중간 결과를 반복 저장하는 것을 피하십시오.

### **스레드 안전성**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 로드, 저장 또는 복제하지 마세요. 이러한 작업은 멀티스레드 사용을 지원하지 않습니다. 독립적인 병합 작업을 병렬화해야 할 경우 각자 자체 프레젠테이션 인스턴스를 갖는 여러 단일 스레드 프로세스를 사용하고, [Aspose.Slides 멀티스레딩 가이드](/slides/ko/nodejs-java/multithreading/)를 따르세요.

## **FAQ**

**각 소스 프레젠테이션의 원래 디자인을 어떻게 유지합니까?**

대상 마스터나 레이아웃을 제공하지 않고 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)을 사용하세요. Aspose.Slides는 필요할 경우 원본 마스터를 자동으로 복제할 수 있습니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하세요. 소스가 아니라 대상 프레젠테이션에 있는 마스터를 전달하면 Aspose.Slides가 해당 마스터 아래 적절한 레이아웃에 각 소스 슬라이드를 매핑합니다.

**특정 대상 레이아웃을 사용해야 할 때는 언제이며, 마스터 대신 언제 사용해야 하나요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 경우 특정 레이아웃을 사용하세요. 소스 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중에서 선택하도록 하려면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

가능하지만 슬라이드 콘텐츠가 대상 차원에 맞게 자동으로 재설계되지 않습니다. 예측 가능한 배치를 원한다면 [SlideSize.setSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)와 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesizescaletype/)을 사용해 소스 프레젠테이션을 먼저 크기 조정하세요.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 소스 프레젠테이션을 로드하고 필요한 슬라이드를 하나의 대상에 복제한 뒤 지원되는 출력 형식으로 저장하면 됩니다. 프레젠테이션 형식마다 지원하는 기능 세트가 정확히 동일하지 않으므로 교차 형식 병합 후 복잡한 콘텐츠를 검증하세요. 자세한 내용은 [Supported File Formats](/slides/ko/nodejs-java/supported-file-formats/)를 참고하십시오.

**소스 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 보존되지 않습니다. 섹션 구조를 유지하려면 대상에 필요한 섹션을 재생성하고 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)의 섹션 오버로드를 사용하세요.

**연설자 노트와 댓글이 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 댓글 작성자 또는 스레드 리뷰 데이터에 의존하는 워크플로우의 경우, 병합된 결과를 반드시 검증하십시오. 이는 프레젠테이션 수준 구조와 슬라이드 수준 콘텐츠 모두에 영향을 줍니다.

**오디오, 비디오, OLE 개체 및 하이퍼링크는 어떻게 처리되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계에 포함됩니다. 외부 링크는 외부에 남아 있으므로 대상 파일이나 URL이 병합 후에도 사용할 수 있어야 합니다.

**모든 소스에서 임베드된 폰트가 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 폰트 배포를 보장하지 마세요. 대상에 임베드된 폰트를 검사하고 타이포그래피가 중요할 경우 폰트 임베딩 또는 외부 폰트 가용성을 명시적으로 관리하십시오.

**비밀번호가 설정된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)로 열고 슬라이드를 정상적으로 복제하세요. 출력 보호는 별도로 구성합니다.

**대용량 프레젠테이션을 어떻게 처리해야 하나요?**

BLOB 관리 옵션을 사용해 대용량 바이너리 객체를 제어하고, 가능하면 파일 경로에서 로드하며, 소스 프레젠테이션을 병합이 끝나는 즉시 해제하고, 필요하지 않은 한 중간 결과를 반복 저장하지 마세요.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 로드, 저장 또는 복제하지 마세요. 병합 작업을 병렬화하려면 각 프로세스가 자체 단일 스레드와 독립 프레젠테이션 인스턴스를 사용하도록 하십시오.