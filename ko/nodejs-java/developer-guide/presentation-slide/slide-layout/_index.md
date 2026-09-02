---
title: JavaScript에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/nodejs-java/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리 표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 표시
- 제목 슬라이드
- 제목 및 콘텐츠
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 Java를 사용하여 슬라이드 레이아웃을 적용·생성·수정하고, 자리 표시자를 추가하고, 사용되지 않은 레이아웃을 제거하며, 바닥글 표시를 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리 표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드에 일관된 구조를 제공하면서 각 슬라이드마다 고유한 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제 자리 표시자를 포함합니다.
- **제목 및 콘텐츠**: 제목 자리 표시자와 일반 용도 콘텐츠 자리 표시자를 포함합니다.
- **빈 슬라이드**: 콘텐츠 자리 표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션에는 세 가지 관련 수준이 있습니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [일반 슬라이드](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

일반 슬라이드는 레이아웃으로부터 테마와 서식을 상속하고, 레이아웃은 마스터로부터 상속합니다. 일반 슬라이드에 직접 설정된 값은 해당 수준에서 상속된 값을 재정의합니다. 일반 슬라이드가 생성될 때 선택된 레이아웃에서 자리 표시자 도형이 생성되며, 해당 자리 표시자에 입력된 콘텐츠는 일반 슬라이드에 속합니다.

레이아웃을 만든 후 슬라이드를 만들기 전에 필요한 자리 표시자를 레이아웃에 추가하십시오. 이후에 레이아웃에 다른 자리 표시자를 추가해도 기존 일반 슬라이드에 자동으로 해당 자리 표시자 도형이 추가되지 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃에서 상속된 서식이나 기존 자리 표시자 기하학을 변경하면 해당 레이아웃을 사용하는 모든 슬라이드가 업데이트됩니다. 이미 사용 중인 레이아웃을 편집하기 전에 종속 슬라이드를 검사하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드에서 아직 사용 중인 레이아웃은 제거할 수 없습니다. 먼저 종속 슬라이드를 다른 레이아웃으로 재할당하거나 사용되지 않은 레이아웃만 제거하십시오.

이 계층 구조의 최상위에 대한 자세한 내용은 [슬라이드 마스터](/slides/ko/nodejs-java/slide-master/)를 참조하십시오.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따르는 경우 [SlideLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidelayouttype/) 값을 사용하십시오. 레이아웃 이름은 사용자가 편집할 수 있고 현지화될 수 있으므로, 소스 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 떨어집니다.

다음 예제는 첫 번째 마스터에서 **제목 및 콘텐츠** 레이아웃을 찾습니다. 해당 레이아웃이 없으면 의도적으로 **빈 슬라이드**로 대체합니다. 두 번째 null 검사는 프레젠테이션에 사용자 정의 레이아웃만 포함될 수 있기 때문에 필요합니다. 선택된 레이아웃은 [Slide.setLayoutSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#setLayoutSlide) 메서드를 통해 첫 번째 일반 슬라이드에 적용됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

슬라이드 레이아웃을 변경해도 직접 슬라이드에 추가된 일반 도형은 제거되지 않습니다. 그러나 자리 표시자 위치, 상속된 서식 및 기존 자리 표시자와 새 레이아웃 간의 매핑이 변경될 수 있으므로, 크게 다른 레이아웃으로 전환할 때는 출력물을 검사하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성은 별개의 작업입니다. 앞 예제는 기존 레이아웃을 선택했을 뿐 생성하지 않았습니다. 레이아웃을 만들려면 대상 마스터의 레이아웃 컬렉션에서 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) 메서드를 호출하십시오.

다음 예제는 항상 새 **제목 및 콘텐츠** 레이아웃을 `Report Title and Content`라는 이름으로 추가한 후, 이를 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

템플릿에 실제로 새로운 재사용 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재한다면 중복을 만들지 말고 선택해 재사용하십시오.

## **레이아웃 슬라이드에 자리 표시자 추가**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) 메서드는 레이아웃에 자리 표시자 도형을 추가하기 위한 [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/)를 제공합니다.

| PowerPoint 자리 표시자              | `LayoutPlaceholderManager` 메서드 |
| ----------------------------------- | --------------------------------- |
| ![콘텐츠](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![콘텐츠 (수직)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![텍스트](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![텍스트 (수직)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![그림](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![차트](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![표](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![스마트아트](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![미디어](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![온라인 이미지](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

다음 예제는 **빈 슬라이드** 레이아웃이 존재하는지 확인한 후 네 개의 자리 표시자를 추가하고, 수정된 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도된 것으로, 일반 슬라이드를 만들기 전에 자리 표시자를 추가하면 Aspose.Slides가 해당 슬라이드에 대응하는 자리 표시자 도형을 생성할 수 있습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![레이아웃 슬라이드의 자리 표시자](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
상속된 서식이나 기존 레이아웃 자리 표시자의 기하학을 변경하면 종속 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 자리 표시자는 기존 일반 슬라이드에 자동으로 채워지지 않습니다. 레이아웃 변경을 프레젠테이션 복사본에서 테스트하고 모든 종속 슬라이드를 검사하십시오.
{{% /alert %}}

## **사용되지 않은 레이아웃 슬라이드 제거**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 메서드를 사용하면 일반 슬라이드에서 참조되지 않는 레이아웃을 제거할 수 있습니다. 사용 중인 레이아웃은 그대로 유지됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

특정 레이아웃을 하나만 제거하려면 먼저 해당 레이아웃의 [hasDependingSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) 또는 [getDependingSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) 메서드를 사용하십시오. [LayoutSlide.remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#remove) 호출 전에 모든 종속 슬라이드를 재할당하십시오. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxeditexception/)이 발생합니다.

## **레이아웃 슬라이드에서 바닥글 표시 제어**

레이아웃에는 자체 바닥글, 슬라이드 번호 및 날짜/시간 자리 표시자가 있습니다. [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) 메서드를 사용하여 해당 레이아웃의 자리 표시자를 제어할 수 있습니다. 예를 들어 콘텐츠 레이아웃은 바닥글을 표시하고 제목 레이아웃은 표시하지 않도록 할 때 유용합니다.

다음 예제는 레이아웃을 안전하게 선택하고 바닥글 요소를 표시하도록 설정합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **마스터 및 자식 레이아웃 슬라이드에서 바닥글 표시 제어**

마스터 전체에 일관된 바닥글 설정을 적용하려면 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) 메서드를 사용하십시오. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslideheaderfootermanager/)의 전파 메서드는 마스터와 해당 종속 레이아웃 슬라이드 및 일반 슬라이드에 적용되며, 단일 일반 슬라이드만을 대상으로 하지 않습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇입니까?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 서식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 하나의 재사용 가능한 자리 표시자 배열을 정의합니다. 일반 슬라이드는 해당 레이아웃을 사용하고 슬라이드 별 콘텐츠를 저장합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있습니까?**

예. [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) 메서드를 사용하여 대상 컬렉션에 복사본을 추가하십시오. 프레젠테이션 간 복사 시 원본 레이아웃에서 사용된 글꼴, 테마, 이미지 및 기타 리소스도 확인하십시오.

**이미 사용 중인 레이아웃을 수정하면 어떻게 됩니까?**

종속 슬라이드는 해당 레이아웃 변경을 상속합니다(로컬에서 서식이나 개체를 재정의하지 않은 경우). 따라서 자리 표시자 기하학 및 상속된 스타일이 여러 슬라이드에 동시에 변경될 수 있습니다. 레이아웃을 편집하기 전에 [getDependingSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)으로 영향을 받는 슬라이드를 확인하십시오.

**아직 사용 중인 레이아웃을 제거하면 어떻게 됩니까?**

Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxeditexception/)을 발생시킵니다. 먼저 종속 슬라이드를 다른 레이아웃으로 재할당하거나, [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 메서드를 사용해 참조되지 않은 레이아웃만 제거하십시오.