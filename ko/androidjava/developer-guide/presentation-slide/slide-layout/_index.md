---
title: Android에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/androidjava/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 플레이스홀더
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 가시성
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 세로 텍스트
- 세로 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides에서 슬라이드 레이아웃을 적용, 생성 및 수정하고, 플레이스홀더를 추가하며, 사용되지 않은 레이아웃을 제거하고, 바닥글 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 플레이스홀더의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 가지면서 각 슬라이드가 자체 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제목 플레이스홀더를 포함합니다.
- **제목 및 내용**: 제목 플레이스홀더와 일반 콘텐츠 플레이스홀더를 포함합니다.
- **빈 슬라이드**: 콘텐츠 플레이스홀더가 없으며 모든 모양을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션은 세 개의 관련 레벨을 가집니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [일반 슬라이드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) uses one layout and stores the content entered for that slide.

일반 슬라이드는 레이아웃에서 테마와 서식을 상속하고, 레이아웃은 마스터에서 상속합니다. 일반 슬라이드에 직접 설정된 값은 해당 레벨에서 상속된 값을 재정의합니다. 일반 슬라이드가 생성될 때 선택된 레이아웃에서 플레이스홀더 모양이 생성되며, 해당 플레이스홀더에 입력된 콘텐츠는 일반 슬라이드에 속합니다.

슬라이드를 만들기 전에 레이아웃에 필요한 플레이스홀더를 추가하십시오. 레이아웃에 나중에 또 다른 플레이스홀더를 추가해도 기존 일반 슬라이드에 자동으로 해당 플레이스홀더 모양이 추가되지 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃에서 상속된 서식이나 기존 플레이스홀더 기하학을 변경하면 해당 레이아웃에 의존하는 모든 슬라이드가 업데이트될 수 있습니다. 이미 사용 중인 레이아웃을 편집하기 전에 해당 레이아웃에 의존하는 슬라이드를 확인하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드에서 아직 사용 중인 레이아웃은 제거할 수 없습니다. 먼저 해당 레이아웃에 의존하는 슬라이드를 다른 레이아웃으로 재지정하거나 사용되지 않은 레이아웃만 제거하십시오.

이 계층 구조의 최상위에 대한 자세한 내용은 [슬라이드 마스터](/slides/ko/androidjava/slide-master/)를 참조하십시오.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따를 때 레이아웃 유형을 사용하십시오. 레이아웃 이름은 사용자가 편집할 수 있으며 현지화될 수 있으므로, 소스 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 떨어집니다.

다음 예제는 첫 번째 마스터에서 **제목 및 내용**을 찾습니다. 해당 레이아웃이 없으면 의도적으로 **빈 슬라이드**로 대체합니다. 두 번째 null 확인은 프레젠테이션에 사용자 정의 레이아웃만 포함될 수 있기 때문에 필요합니다. 선택된 레이아웃은 [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) 메서드를 통해 첫 번째 일반 슬라이드에 적용됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

슬라이드의 레이아웃을 변경해도 슬라이드에 직접 추가된 일반 도형은 제거되지 않습니다. 그러나 플레이스홀더 위치, 상속된 서식 및 기존 플레이스홀더와 새 레이아웃 간의 대응 관계가 변경될 수 있으므로, 크게 다른 레이아웃 간 전환 시 출력을 검사하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성은 별개의 작업입니다. 이전 예제는 기존 레이아웃을 선택했을 뿐 생성하지 않았습니다. 레이아웃을 만들려면 대상 마스터의 레이아웃 컬렉션에서 [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) 메서드를 호출하십시오.

다음 예제는 항상 **제목 및 내용** 레이아웃을 `Report Title and Content`라는 이름으로 새로 추가하고, 이를 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

템플릿에 실제로 다른 재사용 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재한다면 중복을 만들기보다 선택하고 재사용하십시오.

## **레이아웃 슬라이드에 플레이스홀더 추가**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) 메서드는 레이아웃에 플레이스홀더 도형을 추가하기 위한 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)를 제공합니다.

| PowerPoint 플레이스홀더 | `ILayoutPlaceholderManager` 메서드 |
| ----------------------- | --------------------------------- |
| ![내용](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![내용 (세로)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![텍스트](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![텍스트 (세로)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![그림](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![차트](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![표](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![미디어](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![온라인 이미지](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

다음 예제는 **빈 슬라이드** 레이아웃이 존재하는지 확인하고, 네 개의 플레이스홀더를 추가한 다음 수정된 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도된 것이며, 플레이스홀더를 일반 슬라이드가 생성되기 전에 추가해야 Aspose.Slides가 해당 슬라이드에 대응하는 플레이스홀더 도형을 생성할 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![레이아웃 슬라이드의 플레이스홀더](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
상속된 서식이나 기존 레이아웃 플레이스홀더의 기하학을 변경하면 의존하는 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 플레이스홀더는 기존 일반 슬라이드에 자동으로 채워지지 않습니다. 레이아웃 변경을 프레젠테이션 복사본에서 테스트하고 모든 의존 슬라이드를 검토하십시오.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 메서드를 사용하여 일반 슬라이드가 참조하지 않는 레이아웃을 제거하십시오. 메서드는 아직 사용 중인 레이아웃은 그대로 유지합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

특정 레이아웃을 제거하려면 먼저 해당 레이아웃의 [hasDependingSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) 또는 [getDependingSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) 메서드를 사용하십시오. [ILayoutSlide.remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#remove--)을 호출하기 전에 모든 의존 슬라이드를 재지정하십시오. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxeditexception/)이 발생합니다.

## **레이아웃 슬라이드에서 바닥글 가시성 제어**

레이아웃에는 자체 바닥글, 슬라이드 번호 및 날짜‑시간 플레이스홀더가 있습니다. 해당 레이아웃의 플레이스홀더를 제어하려면 [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) 메서드를 사용하십시오. 예를 들어 콘텐츠 레이아웃은 바닥글을 표시하고 제목 레이아웃은 표시하지 않아야 할 때 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **마스터 및 자식 레이아웃에서 바닥글 가시성 제어**

마스터 계층 전체에 일관된 바닥글 설정을 적용하려면 [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) 메서드를 사용하십시오. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslideheaderfootermanager/)의 전파 메서드는 마스터와 해당 의존 레이아웃 슬라이드 및 일반 슬라이드에 작동하며, 단일 일반 슬라이드만을 대상으로 하지는 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇입니까?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 서식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 하나의 재사용 가능한 플레이스홀더 배열을 정의합니다. 일반 슬라이드는 이러한 레이아웃을 사용하고 슬라이드별 콘텐츠를 저장합니다.

**하나의 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있습니까?**

예. 대상 컬렉션에 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) 메서드를 사용하여 복사본을 추가하십시오. 프레젠테이션 간 복사 시 소스 레이아웃에서 사용된 글꼴, 테마, 이미지 및 기타 리소스도 확인하십시오.

**이미 사용 중인 레이아웃을 수정하면 어떤 일이 발생합니까?**

의존 슬라이드는 로컬에서 서식이나 개체를 재정의하지 않는 한 레이아웃 변경을 상속받습니다. 따라서 플레이스홀더 기하학 및 상속된 스타일이 한 번에 여러 슬라이드에 적용되어 변경될 수 있습니다. 레이아웃을 편집하기 전에 [getDependingSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--)을 사용해 영향을 받는 슬라이드를 식별하십시오.

**여전히 사용 중인 레이아웃을 제거하면 어떤 일이 발생합니까?**

Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxeditexception/)을 throw합니다. 먼저 의존 슬라이드를 재지정하거나 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)을 사용해 참조되지 않은 레이아웃만 제거하십시오.