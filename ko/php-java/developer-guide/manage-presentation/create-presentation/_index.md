---
title: PHP에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/php-java/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새로운 프레젠테이션
- PPT 만들기
- 새로운 PPT
- PPTX 만들기
- 새로운 PPTX
- ODP 만들기
- 새로운 ODP
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션을 만들고 — PPT, PPTX 및 ODP 파일을 프로그래밍 방식으로 생성하고 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 생성하고 첫 번째 슬라이드에 텍스트 상자를 추가한 후 결과를 파일로 저장하는 방법을 보여줍니다. 또한 빈 프레젠테이션을 생성하고 저장하는 방법과 지원되는 형식의 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법도 설명합니다. 마지막 FAQ 섹션에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 관한 일반적인 질문을 다룹니다.

시작하기 전에 Composer를 사용하여 Java용 Aspose.Slides for PHP를 설치하고 Apache Tomcat에서 PHP/Java Bridge를 시작하십시오. 전체 설정은 [설치](/slides/ko/php-java/installation/)을 참조하십시오. 아래 예제는 Tomcat이 `localhost:8080`에서 실행 중이며 Composer `vendor` 폴더가 스크립트 옆에 있다고 가정합니다.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 배치하려면 다음 단계를 따르십시오:

1. 새로운 프레젠테이션은 이미 빈 슬라이드 하나를 포함하고 있습니다. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/)가 반환하는 컬렉션에서 인덱스 0으로 해당 슬라이드를 가져옵니다.
3. [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) 메서드를 사용하여 사각형을 추가하고, [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/)으로 텍스트를 설정합니다.
4. [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 메서드로 프레젠테이션을 PPTX 파일로 저장합니다.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`require_once` 두 줄은 Tomcat에서 PHP/Java Bridge 클라이언트를 로드하고 Composer 패키지에서 Aspose.Slides 클래스를 로드합니다. 사각형의 왼쪽 위 모서리는 슬라이드 왼쪽 가장자리에서 50포인트, 위쪽 가장자리에서 50포인트 떨어져 있으며, 사각형의 너비는 400포인트, 높이는 100포인트입니다. 저장된 파일에는 해당 사각형과 텍스트가 포함된 슬라이드가 하나 있습니다. 라이선스가 없으면 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가합니다; [라이선스](/slides/ko/php-java/licensing/)을 참조하십시오.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 PHP 프로세스가 아니라 Tomcat 내부에서 파일을 읽고 쓰기 때문에 `"hello.pptx"`와 같은 상대 경로는 Tomcat의 작업 폴더를 기준으로 해석됩니다. 이 페이지의 예제는 `__DIR__`을 사용하여 절대 경로를 생성하므로 파일이 스크립트 옆에서 읽히고 저장됩니다.
{{% /alert %}}

## **프레젠테이션 만들기 및 저장**

빈 프레젠테이션을 만들고 저장하려면 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스를 인스턴스화한 다음 [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) 열거형의 원하는 형식으로 저장합니다. 결과는 빈 슬라이드 하나를 포함한 프레젠테이션입니다.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션 열기 및 저장**

프레젠테이션을 한 형식에서 다른 형식으로 변환하려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 생성자에 전달하여 열고, 원하는 대상 형식으로 저장합니다. Aspose.Slides는 파일 자체에서 PPT, PPTX, ODP와 같은 입력 형식을 자동으로 감지합니다.

아래 예제는 스크립트 옆에 있는 *Sample.odp*라는 OpenDocument 프레젠테이션을 기대하며 이를 PPTX 형식으로 저장합니다.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### 새 프레젠테이션을 저장할 수 있는 형식은 무엇입니까?

다음 경로를 통해 [PPTX, PPT, ODP](/slides/ko/php-java/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/php-java/convert-powerpoint-to-html/), [SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/), 그리고 [images](/slides/ko/php-java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 후 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사 형식은 [지원됩니다](/slides/ko/php-java/supported-file-formats/)됩니다.

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어합니까?

[슬라이드 크기](/slides/ko/php-java/slide-size/)를 설정합니다(4:3, 16:9와 같은 사전 설정이나 사용자 정의 치수를 포함). 그리고 콘텐츠가 어떻게 스케일링될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정됩니까?

포인트 단위: 1인치는 72포인트에 해당합니다.

### 메모리 사용량을 줄이기 위해 매우 큰 프레젠테이션(다수의 미디어 파일 포함)을 어떻게 처리합니까?

[BLOB 관리 전략](/slides/ko/php-java/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

### 프레젠테이션을 병렬로 생성/저장할 수 있나요?

동일한 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 인스턴스를 [다중 스레드](/slides/ko/php-java/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

### 평가용 워터마크 및 제한을 제거하려면 어떻게 합니까?

프로세스당 한 번씩 [라이선스 적용](/slides/ko/php-java/licensing/)를 적용하십시오. 라이선스 XML은 수정하지 않아야 하며, 다중 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

### 만든 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/php-java/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

### 생성된 프레젠테이션에서 매크로(VBA)가 지원되나요?

예. [VBA 프로젝트 만들기/편집](/slides/ko/php-java/presentation-via-vba/)을 통해 VBA 프로젝트를 만들거나 편집할 수 있으며 PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.