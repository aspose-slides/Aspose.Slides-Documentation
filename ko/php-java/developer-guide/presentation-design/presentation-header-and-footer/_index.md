---
title: PHP에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/php-java/presentation-header-and-footer/
keywords:
- 머리글
- 머리글 텍스트
- 바닥글
- 바닥글 텍스트
- 머리글 설정
- 바닥글 설정
- 유인물
- 메모
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 슬라이드, 메모 페이지 및 유인물의 바닥글, 날짜/시간, 슬라이드 번호 및 머리글 자리표시자를 관리하는 방법을 배웁니다."
---
## **개요**

PowerPoint는 페이지 유형에 따라 다른 머리글 및 바닥글 자리표시자를 사용합니다. Aspose.Slides for PHP via Java를 사용하면 머리글/바닥글 관리자 클래스를 통해 이러한 자리표시자의 텍스트와 표시 여부를 제어할 수 있습니다.

사용 가능한 자리표시자는 범위에 따라 달라집니다:

| 범위 | 머리글 | 바닥글 | 날짜/시간 | 슬라이드/페이지 번호 |
|---|---|---|---|---|
| 일반 슬라이드 | 아니오 | 예 | 예 | 예 |
| 메모 마스터 | 예 | 예 | 예 | 예 |
| 메모 슬라이드 | 예 | 예 | 예 | 예 |
| 유인물 마스터 | 예 | 예 | 예 | 예 |

일반 프레젠테이션 슬라이드에는 머리글 자리표시자가 없습니다. 머리글은 메모 페이지와 유인물 페이지에서 사용할 수 있습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 사용하십시오.

변경의 적용 범위는 사용하는 관리자에 따라 다릅니다. [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideheaderfootermanager/) 클래스는 단일 일반 슬라이드를 제어합니다. [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notesslideheaderfootermanager/) 클래스는 단일 메모 슬라이드를 제어합니다. 마스터 및 레이아웃 관리자는 종속 슬라이드에 설정을 전파할 수 있으며, [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 클래스는 유인물 마스터를 제어합니다.

## **일반 슬라이드에 바닥글, 날짜/시간 및 슬라이드 번호 설정**

일반 슬라이드의 기본 흐름은 각 슬라이드의 머리글/바닥글 관리자에 접근하여 바닥글과 날짜/시간 텍스트를 설정하고 필요한 자리표시자를 활성화한 뒤 프레젠테이션을 저장하는 것입니다. 슬라이드 번호는 프레젠테이션에서 자동 생성되므로 표시 여부만 제어하면 됩니다.

텍스트 설정에는 [`setFooterText`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/)와 [`setDateTimeText`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/)를 사용하고, 해당 자리표시자를 표시하려면 [`setFooterVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) 및 [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/)를 사용합니다.

다음 전체 예제는 모든 일반 슬라이드에 동일한 바닥글, 날짜/시간 텍스트 및 슬라이드 번호 표시 여부를 적용합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

하나의 슬라이드만 업데이트해야 하는 경우 전체 컬렉션을 반복하지 말고 [`getSlides`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getslides/) 메서드를 통해 해당 슬라이드에 직접 접근하십시오.

## **메모 마스터에 머리글 및 바닥글 설정**

메모 마스터는 메모 페이지에 대한 일반 서식 및 자리표시자 동작을 정의합니다. 메모 마스터 자체만 변경하려면 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/) 클래스를 사용하십시오.

다음 예제는 메모 마스터에 머리글, 바닥글 및 날짜/시간 텍스트를 설정하고 해당 마스터에서 지원되는 모든 자리표시자를 표시합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

프레젠테이션에 메모 마스터가 포함되지 않은 경우 [`getMasterNotesSlide`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) 메서드는 `null`을 반환합니다.

## **메모 마스터 설정을 자식 메모 슬라이드에 적용**

메모 마스터는 자체와 모든 종속 메모 슬라이드에 머리글 및 바닥글 설정을 적용할 수 있습니다. 동일한 설정을 메모 계층 전체에 적용하려면 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/)의 전파 전용 메서드를 사용하십시오.

예를 들어, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/)와 [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/)는 메모 마스터 머리글과 모든 자식 머리글을 업데이트합니다. 바닥글, 날짜/시간 및 슬라이드 번호에 대해서도 유사한 메서드가 제공됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

위에서 사용한 전파 메서드는 [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), 그리고 [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)입니다.

## **개별 메모 슬라이드에 머리글 및 바닥글 설정**

메모 슬라이드는 특정 일반 슬라이드에 속합니다. 해당 메모 페이지만 사용자 지정하려면 [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notesslideheaderfootermanager/) 클래스를 사용하십시오.

[`addNotesSlide`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notesslidemanager/addnotesslide/) 메서드는 현재 슬라이드에 대한 메모 슬라이드를 반환하며, 존재하지 않을 경우 새로 생성합니다. 다음 예제는 첫 번째 프레젠테이션 슬라이드와 연결된 메모 페이지를 구성합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

먼저 메모 마스터에서 설정을 전파한 뒤 개별 메모 슬라이드를 변경하면, 이후 슬라이드별 설정을 통해 해당 메모 페이지를 독립적으로 사용자 지정할 수 있습니다.

## **유인물 마스터에 머리글 및 바닥글 설정**

유인물 페이지는 유인물 마스터를 사용하여 머리글, 바닥글, 날짜/시간 및 페이지 번호 자리표시자를 관리합니다. 메모 페이지와 달리 유인물 설정은 개별 유인물 슬라이드가 아니라 유인물 마스터를 통해 관리됩니다.

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) 메서드로 유인물 마스터에 접근하십시오. 마스터가 존재하지 않을 경우 [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/)를 호출하여 기본 유인물 마스터를 생성합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범위 및 상속 이해**

변경하려는 범위에 맞는 머리글/바닥글 관리자를 선택하십시오:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideheaderfootermanager/) 은 하나의 일반 슬라이드에 대해 바닥글, 날짜/시간 및 슬라이드 번호 설정을 변경합니다.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslideheaderfootermanager/) 은 레이아웃 슬라이드를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslideheaderfootermanager/) 은 일반 슬라이드 마스터를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslideheaderfootermanager/) 은 메모 마스터를 제어하고 모든 종속 메모 슬라이드에 설정을 전파할 수 있습니다.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notesslideheaderfootermanager/) 은 하나의 메모 슬라이드를 변경하며, 머리글 자리표시자를 바닥글, 날짜/시간 및 슬라이드 번호와 함께 지원합니다.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 은 유인물 마스터를 변경하고 네 가지 자리표시자 유형을 모두 지원합니다.

동일한 설정을 전체 계층에 적용하려면 마스터 또는 레이아웃에서 전파하십시오. 하나의 페이지에만 로컬 설정이 필요하면 개별 슬라이드 또는 메모‑슬라이드 관리자를 사용하십시오.

## **FAQ**

**일반 슬라이드에 머리글을 추가할 수 있나요?**

아니오. PowerPoint는 일반 슬라이드에 머리글 자리표시자를 정의하지 않습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 사용하십시오. 머리글 자리표시자는 메모 페이지와 유인물에서 사용할 수 있습니다.

**바닥글, 날짜/시간 또는 슬라이드 번호 자리표시자가 보이지 않는 경우 어떻게 해야 하나요?**

해당 머리글/바닥글 관리자를 사용하여 표시 여부를 확인하고 필요에 따라 활성화하십시오. 예를 들어, [`isFooterVisible`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 은 바닥글 자리표시자가 존재하는지 여부를 반환하고, [`setFooterVisibility`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 은 표시 여부를 변경합니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 하나요?**

프레젠테이션의 [`setFirstSlideNumber`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/setfirstslidenumber/) 메서드를 호출하십시오. 그러면 슬라이드 번호 자리표시자가 업데이트된 번호 순서를 사용하게 됩니다.

**PDF, 이미지 또는 HTML로 내보낼 때 머리글과 바닥글은 어떻게 처리되나요?**

표시된 머리글 및 바닥글 요소는 출력 형식의 나머지 프레젠테이션 내용과 함께 렌더링됩니다. 외관은 내보내는 페이지 유형과 해당 자리표시자 표시 설정에 따라 달라집니다.