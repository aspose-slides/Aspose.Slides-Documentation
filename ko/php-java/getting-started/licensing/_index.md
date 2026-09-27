---
title: 라이선스
type: docs
weight: 80
url: /ko/php-java/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 대한 중단 없는 액세스를 보장합니다."
---
## **소개**

때때로 최상의 평가 결과를 위해 직접 체험이 필요할 수 있습니다. 이를 위해 Aspose.Slides는 다양한 구매 플랜을 제공하고 무료 체험 및 30일 임시 라이선스를 제공합니다.

{{% alert color="info" title="Note" %}}
일반적인 정책 및 실무가 많이 있으며, 이를 통해 제품을 평가하고 적절히 라이선스를 적용하며 구매하는 방법을 안내합니다. ["구매 정책 및 FAQ"](https://purchase.aspose.com/policies) 섹션에서 확인할 수 있습니다.
{{% /alert %}}

## **Aspose.Slides 평가**
평가용으로 Aspose.Slides를 쉽게 다운로드할 수 있습니다. 평가 패키지는 구매 패키지와 동일합니다. 평가 버전은 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.

## **평가 버전 제한 사항**
라이선스가 지정되지 않은 Aspose.Slides 평가 버전은 전체 기능을 제공하지만 두 가지 제한이 있습니다:

* 저장하는 각 프레젠테이션의 모든 슬라이드 중앙에 평가 워터마크 텍스트 상자를 추가합니다.
* 코드가 프레젠테이션에서 읽는 텍스트는 처음 몇 글자만 표시되고 평가 제한 안내가 추가됩니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}
평가 버전 제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스를 받는 방법?](https://purchase.aspose.com/temporary-license) 를 참조하십시오.
{{% /alert %}} 

## **라이선스 정보**
PHP via Java용 Aspose.Slides 평가 버전을 해당 [download page](https://packagist.org/packages/aspose/slides)에서 쉽게 다운로드할 수 있습니다. 평가 버전은 라이선스 버전과 **동일한 기능**을 제공합니다. 또한 라이선스를 구매하고 몇 줄의 코드를 추가하면 평가 버전이 라이선스가 적용됩니다.

라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료일 등 정보를 포함한 일반 텍스트 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정하면 안 됩니다. 파일에 여분의 줄 바꿈을 추가하는 것조차 무효화합니다.

평가 버전의 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 설정하면 됩니다.

{{% alert color="info" title="Note" %}}
[계량식 라이선스](/slides/ko/php-java/metered-licensing/) 를 확인해 보세요.
{{% /alert %}} 

## **구매 라이선스**

구매 후 라이선스 파일 또는 스트림을 적용해야 합니다.

{{% alert color="info" title="Note" %}}
라이선스 설정:
* 애플리케이션 도메인당 한 번만
* Aspose.Slides의 다른 클래스를 사용하기 전에
{{% /alert %}}

{{% alert color="info" title="Note" %}}
[“Pricing Information”](https://purchase.aspose.com/pricing/slides/family) 페이지에서 가격 정보를 확인할 수 있습니다.
{{% /alert %}}

### **PHP via Java용 Aspose.Slides에서 라이선스 설정**

라이선스는 다음 위치에서 적용할 수 있습니다:

* 명시적 경로
* 스트림
* 계량식 라이선스 – 새로운 라이선스 메커니즘

{{% alert color="info" title="Note" %}}
구성 요소에 라이선스를 적용하려면 **setLicense** 메서드를 사용하십시오.

**setLicense**를 여러 번 호출해도 문제가 없지만 리소스(프로세서)를 낭비합니다.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화합니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 인식하지 않습니다.
{{% /alert %}}

#### **파일을 사용해 라이선스 적용**

이 코드 스니펫은 라이선스 파일을 설정하는 데 사용됩니다:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

샘플은 스크립트와 같은 디렉터리에 라이선스 파일이 있기를 기대하며 절대 경로를 전달합니다. Aspose.Slides는 Tomcat 내부에서 실행되므로 상대 경로를 스크립트 폴더 기준으로 해석하지 않습니다. setLicense 메서드를 호출할 때 라이선스 이름은 라이선스 파일명과 동일해야 합니다. 예를 들어 라이선스 파일명을 "Aspose.Slides.lic.xml"로 변경할 수 있습니다. 그런 다음 코드에서 새 라이선스 이름(Aspose.Slides.lic.xml)을 setLicense 메서드에 전달해야 합니다.

#### **스트림으로 라이선스 적용**

이 코드 스니펫은 스트림에서 라이선스를 적용하는 데 사용됩니다:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### 라이선스를 완전히 오프라인 환경(인터넷 접속 없음)에서 적용할 수 있나요?

네. 라이선스 검증은 로컬에서 라이선스 파일을 사용해 수행되며 인터넷 연결이 필요 없습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니요. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전을 계속 사용할 수 있습니다. 다만 새 릴리스를 사용하려면 갱신이 필요합니다.