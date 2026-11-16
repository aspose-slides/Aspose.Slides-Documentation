---
title: PHP에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/php-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 수직 분할기 고정
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 줌
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 일반 보기 레이아웃, 슬라이드 및 노트 줌, 그리드 간격, 댓글 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서는 슬라이드가 썸네일 또는 개요용 사이드 페인과 아래의 노트 페인 사이에 표시됩니다. Aspose.Slides for PHP via Java는 프레젠테이션의 저장된 편집 기본 설정을 [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/)를 통해 노출합니다. 여기에는 페인 레이아웃, 줌 레벨, 그리드 간격 및 댓글 표시 여부가 포함됩니다.

## **NormalViewProperties에 대하여**

[getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)를 사용하여 [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) 클래스를 액세스합니다. [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/)는 개요에서 슬라이드 제목 옆에 아이콘을 표시할지 여부를 제어합니다. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/)는 사용자가 사이드 페인을 좁히면 최소화 상태로 고정되도록 합니다. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/)는 전체 창에서 하나의 페인을 표시하는 기본 설정을 나타냅니다.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/)는 사이드 페인과 슬라이드 사이의 구분자를 제어합니다. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/)는 노트 페인 위의 구분자를 제어합니다. 두 메서드 모두 `Minimized`, `Maximized`, `Restored` 중 하나의 [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) 값을 허용합니다.

## **NormalViewProperties 복원에 대하여**

구분자가 복원될 때, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/)는 사이드 페인의 저장된 크기를 제공하고, [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/)는 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 메서드 모두 [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/)를 노출합니다. 이 클래스의 [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) 메서드는 0에서 100까지의 백분율을 허용하며, [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/)는 창 크기가 조정될 때 편집기가 크기를 자동으로 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 수평 구분자를 복원하고, [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/)이 반환하는 크기를 자동 조정이 활성화된 상태에서 80%로 설정하며, 수직 구분자를 최대화합니다. 또한 [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/)를 호출하여 개요 보기에서 아이콘을 표시합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **기본 줌 값 설정**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)와 [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/)는 편집기에 대한 개별 줌 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생 또는 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/)를 호출하여 슬라이드를 편집 창에 맞춥니다. 노트 페이지의 경우 자동 스케일링을 비활성화하고 [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/)를 호출하여 고정된 80% 줌을 설정합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **그리드 간격 설정**

[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/)의 `setGridSpacing` 메서드는 프레젠테이션 전체에 걸쳐 편집 그리드 선 사이의 거리를 설정합니다. 이 메서드는 인치당 72포인트인 양의 포인트 값을 입력받습니다. 이 예제는 기존 프레젠테이션에서 현재 간격을 출력하고, 간격을 18포인트(¼인치)로 설정하여 그리드를 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

그리드는 고정된 간격으로 반복됩니다. [그리기 가이드](/slides/ko/php-java/drawing-guides/)는 개별 가로 또는 세로 위치를 표시합니다. 둘 다 편집 보조 도구이며 이를 표시하는 편집기에서만 나타납니다. 슬라이드 쇼 및 PDF, 이미지, SVG로의 내보내기에서는 표시되지 않습니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/)는 프레젠테이션을 열 때 호환 편집기가 사용하는 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/)를 [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView)와 함께 호출하여 사본이 슬라이드 보기로 열리도록 합니다.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

주석을 숨기면 텍스트, 작성자, 위치, 답변 및 상태가 보존됩니다. 주석 자체를 변경하려면 [프레젠테이션 주석](/slides/ko/php-java/presentation-comments/)을 참조하십시오. 내보내기 설정은 주석이 PDF, HTML, 이미지, 노트 또는 유인물에 표시될지 여부를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열 때 그리드가 숨겨지는 이유는 무엇인가요?**

프레젠테이션은 그리드 간격을 저장합니다. 그리드를 보려면 편집기에서 그리드 표시를 활성화하십시오.

**그리기 가이드를 삭제해도 그리드 간격이 변경되나요?**

아니요. 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변하지 않습니다.

**프레젠테이션의 다른 섹션에 서로 다른 보기 설정을 적용할 수 있나요?**

아니요. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자별로 다른 보기 설정을 저장할 수 있나요?**

파일은 모든 사용자를 위해 하나의 보기 속성 집합만 저장합니다. 편집기는 사용자의 로컬 기본 설정을 추가로 적용할 수 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**

예. 템플릿에서 만든 프레젠테이션은 템플릿에 저장된 보기 설정을 상속합니다.