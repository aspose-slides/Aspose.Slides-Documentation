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
- 라이선스 확인
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

때때로 최상의 평가 결과를 얻기 위해서는 직접 체험하는 접근 방식이 필요할 수 있습니다. 이러한 이유로 Aspose.Slides는 다양한 구매 플랜을 제공하고 무료 평가판 및 30일 임시 라이선스를 평가용으로 제공합니다.

{{% alert color="primary" %}}
우리 제품을 평가하고 적절히 라이선스를 적용하며 구매하는 방법을 안내하는 일반 정책 및 관행이 여러 가지 있습니다. 해당 내용은 ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) 섹션에서 확인할 수 있습니다.
{{% /alert %}}

## **Aspose.Slides 평가**
평가용 Aspose.Slides를 쉽게 다운로드할 수 있습니다. 평가 패키지는 구매 패키지와 동일합니다. 라이선스를 적용하는 몇 줄의 코드를 추가하면 평가 버전이 바로 라이선스가 적용된 상태가 됩니다.

## **평가 버전 제한**
Aspose.Slides 평가 버전(라이선스가 지정되지 않음)은 전체 제품 기능을 제공하지만, 문서를 열거나 저장할 때 문서 상단에 평가 워터마크를 삽입합니다. 또한 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 슬라이드 하나로 제한됩니다.

{{% alert color="primary" %}} 
평가 버전 제한 없이 Aspose.Slides를 테스트하고 싶다면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) 를 참고하십시오.
{{% /alert %}} 

## **라이선스 정보**
Aspose.Slides for PHP via Java의 [download page](https://packagist.org/packages/aspose/slides)에서 평가 버전을 쉽게 다운로드할 수 있습니다. 평가 버전은 Aspose.Slides 정식 라이선스 버전과 **동일한 기능**을 제공합니다. 또한 라이선스를 구매하고 몇 줄의 코드를 추가해 적용하면 평가 버전이 바로 라이선스가 적용된 상태가 됩니다.

라이선스는 제품명, 라이선스 대상 개발자 수, 구독 만료일 등 세부 정보를 포함한 일반 텍스트 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 파일 내용에 줄 바꿈 하나가 추가되더라도 무효화됩니다.

평가 버전의 제한을 피하려면 **Aspose.Slides** 사용 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

{{% alert color="primary" %}} 
다음의 [Metered Licensing](https://docs.aspose.com/slides/ko/php-java/metered-licensing/)을 확인해 보세요.
{{% /alert %}} 

## **구매 라이선스**

구매 후에는 라이선스 파일이나 스트림을 적용해야 합니다.

{{% alert color="primary" %}}
라이선스를 설정해야 합니다:
* 애플리케이션 도메인당 한 번만
* 다른 Aspose.Slides 클래스를 사용하기 전에
{{% /alert %}}

{{% alert color="primary" %}}
가격 정보는 [“Pricing Information”](https://purchase.aspose.com/pricing/slides/ko/family) 페이지에서 확인할 수 있습니다.
{{% /alert %}}

### **Aspose.Slides for PHP via Java에서 라이선스 설정**

라이선스는 다음 위치에서 적용할 수 있습니다:
* 명시적 경로
* 스트림
* Metered License로 적용 – 새로운 라이선스 메커니즘

{{% alert color="primary" %}}
구성 요소에 라이선스를 적용하려면 **setLicense** 메서드를 사용하십시오.

**setLicense**를 여러 번 호출해도 문제가 되지는 않지만, 리소스(프로세서)를 낭비하게 됩니다.
{{% /alert %}}

{{% alert color="warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이 라이선스를 인식하지 못합니다.
{{% /alert %}}

#### **파일을 사용하여 라이선스 적용**

다음 코드 스니펫은 라이선스 파일을 설정하는 데 사용됩니다:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

setLicense 메서드를 호출할 때 라이선스 이름은 라이선스 파일 이름과 동일해야 합니다. 예를 들어 라이선스 파일 이름을 "Aspose.Slides.lic.xml"로 변경할 수 있습니다. 그런 다음 코드에서 새 라이선스 이름(Aspose.Slides.lic.xml)을 setLicense 메서드에 전달해야 합니다.

#### **스트림에서 라이선스 적용**

다음 코드 스니펫은 스트림에서 라이선스를 적용하는 데 사용됩니다:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**완전히 오프라인 환경(인터넷 접속 없음)에서도 라이선스를 적용할 수 있나요?**

예. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

**1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?**

아니요. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.