---
title: PHP에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/php-java/merge-presentation/
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
- PHP
- Aspose.Slides
description: "PHP에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 내용을 크기 조정하고, 섹션을 보존하며, 보호된 파일이나 대용량 파일을 처리함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for PHP via Java 은 한 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)의 슬라이드를 다른 프레젠테이션으로 복제하여 프레젠테이션을 병합합니다. 주요 작업은 [SlideCollection::addClone()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/)이며, 이 메서드는 원본 슬라이드의 서식을 유지하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 첨부할 수 있습니다.

이 문서는 가장 일반적인 병합 워크플로우를 다룹니다:

- 원본 서식을 유지하면서 모든 슬라이드 병합
- 선택된 슬라이드만 병합
- 대상 프레젠테이션의 마스터 적용
- 대상 프레젠테이션의 특정 레이아웃 적용
- 병합 전에 서로 다른 슬라이드 크기 정규화
- 섹션에 복제된 슬라이드 추가
- 여러 프레젠테이션을 하나의 엔드‑투‑엔드 워크플로우로 병합
- 마스터, 리소스, 노트, 코멘트, 미디어, 폰트, 비밀번호, 대용량 파일 및 다중 스레드 처리 문제 해결

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터로부터 대부분의 외관을 상속받습니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방법으로 [SlideCollection::addClone()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/)을 사용하십시오:

- `addClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 유지합니다. 필요시 원본 마스터가 자동으로 대상 프레젠테이션에 복제됩니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 마스터를 사용하는 반복 슬라이드가 마스터를 반복 복제하지 않도록 합니다.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [MasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)에 첨부합니다. Aspose.Slides는 해당 마스터 아래에서 레이아웃 유형 또는 이름으로 일치하는 레이아웃을 찾습니다.
- `addClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 특정 대상 [LayoutSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/)에 직접 첨부합니다.

`addClone` 오버로드에 전달되는 마스터나 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 원본 서식 유지**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 이는 가져온 슬라이드가 원래의 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합한 선택입니다.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

원본과 대상가 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 유지할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

사용자 입력이나 외부 구성에서 슬라이드 인덱스를 가져오는 경우 복제 전에 인덱스를 검증하십시오.

## **대상 마스터 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 존재하는 마스터를 따라야 할 경우 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 오버로드를 사용하십시오.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides는 원본 레이아웃의 유형 또는 이름과 일치하는 레이아웃을 지정된 마스터 아래에서 선택합니다. 적절한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 원본 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `false`인 경우 [PptxEditException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxeditexception/)이 발생합니다.

병합이 실패하도록 하고 싶을 때는 `false`를 사용하여 대상 마스터에 추가 레이아웃이 삽입되는 것을 방지하십시오.

## **특정 대상 레이아웃 사용하여 슬라이드 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용해야 할지 알 경우 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 오버로드를 사용하십시오.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만, 원본 슬라이드 콘텐츠 자체가 재설계되는 것은 아닙니다. 원본과 대상 레이아웃의 자리 표시자 구조가 다르면 결과를 검사하여 상속된 서식과 자리 표시자 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제하면 콘텐츠가 자동으로 새 캔버스에 맞게 재설계되지 않습니다. 따라서 도형이 이동되거나, 비정상적으로 확대되거나, 보이는 슬라이드 영역 밖에 위치할 수 있습니다.

실용적인 방법은 복제하기 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize::setSize()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesize/setsize/) 메서드는 슬라이드 크기를 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesizescaletype/) 은 콘텐츠를 요청된 크기에 맞게 스케일링합니다.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

크기 조정은 메모리 상의 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 그대로 유지해야 하면 병합을 위해 별도의 인스턴스를 열어 사용하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재현하지 않습니다. 출력에 섹션이 중요한 경우 대상 프레젠테이션에서 섹션을 만들거나 선택한 뒤, [addClone(Slide, Section)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/)을 사용해 슬라이드를 명시적으로 해당 섹션에 복제하십시오.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 대상에 동일한 섹션을 재생성하고 각 원본 슬라이드를 해당 대상 섹션에 매핑하십시오.

## **여러 프레젠테이션을 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 원본의 슬라이드 크기를 정규화하며, 복제 중에만 원본을 열고 마지막에 한 번만 파일을 저장합니다.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

이는 가져온 슬라이드의 원본 서식을 유지하기 위한 유용한 기본 방법입니다. 출력에 단일 대상 테마를 사용해야 하면 앞서 소개한 대상‑마스터 또는 대상‑레이아웃 오버로드를 사용하도록 `addClone($slide)` 호출을 교체하십시오.

## **실용적인 고려 사항**

### **마스터, 레이아웃 및 서식 정확도**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 동일한 마스터가 반복 복제되는 것을 방지하기 위해 자동 복제된 마스터를 내부 레지스트리에 저장합니다. 수동으로 복제한 마스터는 해당 레지스트리에 기록되지 않으므로, 명시적인 마스터 구조 제어가 필요하지 않는 한 사전에 마스터를 복제하지 않는 것이 좋습니다.

이름이 동일한 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모습을 제어해야 한다면 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **노트와 코멘트**

슬라이드 노트와 코멘트는 슬라이드 콘텐츠와 연결되어 있으며 슬라이드가 복제될 때 함께 복사됩니다. Aspose.Slides는 또한 [presentation notes](https://docs.aspose.com/slides/ko/php-java/presentation-notes/)와 [presentation comments](https://docs.aspose.com/slides/ko/php-java/presentation-comments/)에 대한 전용 API를 제공합니다.

노트 페이지 서식이 중요하다면 병합된 프레젠테이션을 검증하십시오. 노트 마스터는 프레젠테이션 수준 객체이며 원본 파일마다 다를 수 있습니다. 리뷰 워크플로우에서는 다른 작성자나 템플릿에서 결합한 파일의 코멘트 작성자와 스레드 코멘트도 확인하십시오.

### **이미지, 오디오, 비디오, OLE 개체 및 외부 링크**

슬라이드는 이미지, 임베드된 오디오, 임베드된 비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하여 리소스와의 관계를 유지하도록 하십시오. 복제만으로는 보이는 도형만 복사하는 것이 아닙니다.

임베드된 리소스와 링크된 리소스는 다르게 처리해야 합니다. 링크된 오디오, 비디오, OLE 개체 또는 하이퍼링크는 외부 대상에 의존하므로, 슬라이드를 복제해도 외부 링크가 임베드된 콘텐츠로 변환되지 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 추적하지만, 이는 서로 다른 원본 프레젠테이션의 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보장을 의미하지는 않습니다. 파일 크기가 중요하면 병합된 패키지를 검사하고 결과를 측정하여 암시적 중복 제거에 의존하지 마십시오.

### **임베드된 폰트와 폰트 가용성**

폰트는 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 기계 간에 일관되어야 한다면 슬라이드 복제만으로 모든 필요한 폰트가 대상 환경에 존재한다는 보장을 하지 마십시오. [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/getembeddedfonts/) 로 임베드된 폰트를 검사하고, [Embed Fonts in Presentations](https://docs.aspose.com/slides/ko/php-java/embedded-font/) 에 설명된 대로 임베드를 명시적으로 관리하십시오.

또한 원본 파일에서 사용된 폰트를 임베드할 권한이 있는지 확인하십시오. 폰트 라이선스는 임베드를 제한할 수 있습니다.

### **비밀번호로 보호된 프레젠테이션**

비밀번호가 설정된 원본은 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions::setPassword()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/setpassword/) 로 전달합니다.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // 복호화된 프레젠테이션으로 작업합니다.
} finally {
    $source->dispose();
}
```

암호화된 원본을 열어도 동일한 보호가 자동으로 대상 프레젠테이션에 적용되지 않습니다. 필요한 경우 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체가 포함된 대용량 프레젠테이션은 상당한 메모리를 소모할 수 있습니다. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) 은 BLOB 처리와 임시 파일 사용을 제어하는 옵션을 제공합니다. PHP via Java 에서 대용량 파일 예제는 [Open Presentations](https://docs.aspose.com/slides/ko/php-java/open-presentation/#open-large-presentations) 를 참조하십시오.

대용량 파일의 경우 가능한 한 파일 경로에서 로드하고, 각 원본 프레젠테이션을 병합이 끝나는 즉시 해제하며, 워크플로우에 체크포인트가 필요하지 않는 한 중간 결과를 반복 저장하는 것을 피하십시오.

### **스레드 안전성**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 로드, 수정, 저장 또는 복제하지 마십시오. PHP via Java 에서는 이러한 작업이 다중 스레드 환경을 지원하지 않습니다. 병렬 병합 작업이 필요하면 각 프로세스가 자체 프레젠테이션 인스턴스를 사용하도록 별도의 단일 스레드 프로세스로 실행하고, [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ko/php-java/multithreading/) 를 따르십시오.

## **FAQ**

**각 원본 프레젠테이션의 원래 디자인을 어떻게 유지하나요?**

대상 마스터나 레이아웃을 제공하지 않고 [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 를 사용하십시오. Aspose.Slides는 가져온 슬라이드에 필요할 경우 원본 마스터를 자동으로 복제할 수 있습니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 원본이 아닌 대상 프레젠테이션에 속한 마스터를 전달하면 Aspose.Slides가 해당 마스터 아래에서 적절한 레이아웃을 매핑하려 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 하는 경우는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 때는 특정 레이아웃을 사용하십시오. 소스 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중에서 선택하도록 하려면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

예, 가능하지만 슬라이드 콘텐츠가 대상 차원에 맞게 자동으로 재설계되지는 않습니다. 예측 가능한 배치를 원한다면 [SlideSize::setSize()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesize/setsize/) 와 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesizescaletype/) 을 사용해 먼저 원본 프레젠테이션을 크기 조정하십시오.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 원본 프레젠테이션을 로드한 뒤 필요한 슬라이드를 하나의 대상에 복제하고, 지원되는 출력 형식으로 저장하면 됩니다. 프레젠테이션 형식마다 지원하는 기능 세트가 정확히 동일하지 않으므로, 교차 형식 병합 후 복잡한 콘텐츠를 검증하십시오. 자세한 내용은 [Supported File Formats](https://docs.aspose.com/slides/ko/php-java/supported-file-formats/) 를 참조하십시오.

**원본 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 섹션이 보존되지 않습니다. 섹션 구조가 필요하면 대상에 해당 섹션을 재생성하고, 섹션 오버로드인 [addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/addclone/) 를 사용하십시오.

**스피커 노트와 코멘트가 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 코멘트 작성자 또는 스레드 리뷰 데이터에 의존하는 워크플로우에서는 병합 결과를 검증하십시오. 이러한 시나리오는 슬라이드 수준 콘텐츠뿐 아니라 프레젠테이션 수준 구조도 포함합니다.

**오디오, 비디오, OLE 개체 및 하이퍼링크는 어떻게 처리되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계에 포함됩니다. 외부 링크는 외부에 남아 있으므로 병합 후에도 해당 파일이나 URL이 접근 가능해야 합니다.

**모든 원본의 임베드된 폰트가 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 폰트 배포를 보장하지 마십시오. 대상에 임베드된 폰트를 검사하고, 타이포그래피가 중요할 경우 폰트 임베드 또는 외부 폰트 가용성을 명시적으로 관리하십시오.

**비밀번호가 설정된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions::setPassword()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/setpassword/) 로 파일을 연 뒤 일반적으로 슬라이드를 복제하면 됩니다. 출력 보호는 별도로 구성하십시오.

**매우 큰 프레젠테이션은 어떻게 처리하나요?**

BLOB 관리 옵션을 사용하고, 매우 큰 파일의 경우 파일 경로 로드를 선호하며, 소스 프레젠테이션을 즉시 해제하고, 최종 결과를 필요할 때만 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

PHP via Java 에서는 프레젠테이션을 여러 스레드에서 로드, 저장 또는 복제하는 것이 지원되지 않습니다. 병렬 작업이 필요하면 별도의 단일 스레드 프로세스로 나누고 각 프로세스가 자체 프레젠테이션 인스턴스를 사용하도록 하십시오.