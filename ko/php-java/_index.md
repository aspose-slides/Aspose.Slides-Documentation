---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /ko/php-java/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "여기에서 시작하세요: Aspose.Slides for PHP via Java를 설치하고, 첫 번째 프레젠테이션을 만든 다음, 일반 작업 가이드, API 참고문서 및 지원 정보를 찾으세요."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java은 Microsoft PowerPoint 또는 Office Automation 없이 PHP 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 생성, 읽기, 편집 및 변환하기 위한 클래스 라이브러리입니다.

매크로 지원 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT 및 ODP 파일을 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/php-java/installation/">설치</a></li>
<li><a href="/slides/ko/php-java/create-presentation/">첫 번째 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/php-java/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/php-java/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/php-java/evaluate-aspose-slides/">체험 제한</a></li>
<li><a href="/slides/ko/php-java/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/php-java/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/php-java/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/php-java/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/php-java/convert-slide/">슬라이드 이미지로 렌더링</a></li>
<li><a href="/slides/ko/php-java/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로우</p>
<ul>
<li><a href="/slides/ko/php-java/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/php-java/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/php-java/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/php-java/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/php-java/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/php-java/examples/">슬라이드 요소별 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 &amp; 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/php-java/known-issues/">알려진 문제</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">제품 페이지</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 프레젠테이션**

Aspose.Slides for PHP via Java는 Apache Tomcat 내부의 Java에서 실행되며, PHP 스크립트는 PHP/Java Bridge를 통해 이를 사용합니다. [설치](/slides/ko/php-java/installation/) 은 PHP 8.3 이하, Java, Tomcat 및 브리지를 설정하고, 그런 다음 프로젝트 폴더에 Packagist에서 패키지를 설치합니다:

```bash
composer require aspose/slides
```

그런 다음 패키지의 JAR 파일을 브리지에 복사하고 Tomcat을 재시작합니다. 이는 [Linux에 설치](/slides/ko/php-java/installation/#install-on-linux) 의 4단계 또는 [Windows에 설치](/slides/ko/php-java/installation/#install-on-windows) 의 6단계와 같습니다. Tomcat이 실행 중이면 이 스크립트를 프로젝트 폴더에 *hello.php* 로 저장하고 `php hello.php`를 실행합니다:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

스크립트는 자체와 같은 위치에 *hello.pptx* 를 저장하며, 텍스트 상자가 있는 하나의 슬라이드를 포함합니다. 라이선스가 없으면 저장된 파일에 평가 워터마크가 표시됩니다 — [라이선스](/slides/ko/php-java/licensing/) 를 참조하세요. 프레젠테이션을 만들고 채우는 더 많은 방법은 [프레젠테이션 만들기](/slides/ko/php-java/create-presentation/) 를 확인하세요.