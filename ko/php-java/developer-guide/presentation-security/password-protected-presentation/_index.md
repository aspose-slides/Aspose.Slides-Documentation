---
title: PHP에서 프레젠테이션에 비밀번호 보호 적용
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/php-java/password-protected-presentation/
keywords:
- 비밀번호 보호 프레젠테이션
- 오프닝 비밀번호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 비밀번호 검증
- 프레젠테이션 비밀번호 확인
- 암호화된 프레젠테이션 열기
- 암호화 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 비밀번호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화하고, 탐지하고, 검증하고, 열고, 복호화합니다."
---
## **개요**

오프닝 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 콘텐츠를 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

오프닝 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정은 제한하지만 콘텐츠를 암호화하거나 프레젠테이션 로드를 방지하지 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [Write-Protect Presentations](/slides/ko/php-java/write-protected-presentation/)를 참조하십시오.

아래 워크플로는 PPT 및 PPTX 프레젠테이션 모두에 적용됩니다. 예제에서는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **오프닝 비밀번호로 프레젠테이션 암호화**

[ProtectionManager::encrypt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#encrypt)를 사용하여 오프닝 비밀번호를 할당합니다. 그런 다음 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save)를 사용해 암호화된 프레젠테이션을 저장합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **암호화된 프레젠테이션 로드**

[LoadOptions::setPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setPassword)를 오프닝 비밀번호로 설정하고 파일을 로드할 때 옵션을 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)에 전달합니다. 오프닝 비밀번호가 필요하지만 제공된 비밀번호가 없거나 틀린 경우 로드가 실패합니다.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 복호화된 프레젠테이션을 작업합니다.
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션에서 암호화 제거**

오프닝 비밀번호로 프레젠테이션을 로드하고 [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#removeEncryption)를 호출한 뒤 결과를 저장합니다. 저장된 프레젠테이션은 이후 비밀번호 없이 로드할 수 있습니다.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **로드 전 오프닝 비밀번호 검증**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/#getPresentationInfo)를 사용하여 전체 프레젠테이션 인스턴스를 만들지 않고 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/)를 가져옵니다. 비밀번호를 요청하거나 검증하기 전에 [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#isPasswordProtected)를 확인하십시오. 보호가 있는 경우 제공된 값을 [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#checkPassword)으로 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 오프닝 비밀번호를 검증하고 검증된 값을 [LoadOptions::setPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setPassword)으로 전달한 뒤 전체 프레젠테이션을 로드합니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **스트림 워크플로**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/#getPresentationInfo)의 스트림 오버로드는 동일한 워크플로를 제공합니다. 해당 스트림에서 전체 프레젠테이션을 로드하기 전에 시크 가능한 스트림의 위치를 재설정하십시오.

다음 예제는 PPT 파일을 사용합니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword 반환 값**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#checkPassword)는 프레젠테이션에 오프닝 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음 경우에는 `false`를 반환합니다:

- 비밀번호가 올바르지 않습니다.
- 프레젠테이션에 오프닝 비밀번호가 없습니다.
- 제공된 비밀번호가 `null`이거나 비어 있습니다.

동작은 PPT와 PPTX 프레젠테이션 모두 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후 [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#isEncrypted)를 검사하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전 오프닝 비밀번호 보호를 감지하려면 위와 같이 [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#isPasswordProtected)를 사용하십시오.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **보안 권장 사항**

{{% alert color="warning" title="보안" %}}
오프닝 비밀번호를 로그에 남기거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요한 동안만 메모리에 보관하며, 프레젠테이션을 즉시 로드할 때는 성공적인 검증 결과를 재사용하십시오.
{{% /alert %}}

## **온라인에서 프레젠테이션에 비밀번호 보호 적용**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
1. 프레젠테이션을 선택하거나 업로드합니다.
1. 보기 보호용 비밀번호를 입력합니다.
1. 선택적으로 편집 보호용 별도 비밀번호를 입력합니다.
1. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="참고" %}}
- [Write-Protect Presentations](/slides/ko/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**오프닝 비밀번호와 쓰기 보호 비밀번호의 차이점은 무엇인가요?**

오프닝 비밀번호는 프레젠테이션을 암호화하며, 콘텐츠를 로드하려면 필요합니다. 쓰기 보호 비밀번호는 콘텐츠를 암호화하지 않고 수정만 제한합니다.

**모든 슬라이드를 로드하지 않고 오프닝 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 가져오고, 오프닝 비밀번호 보호가 존재하는지 확인한 뒤, 전체 프레젠테이션 인스턴스를 생성하기 전에 비밀번호를 검증하십시오.

**비밀번호 검증 워크플로가 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 감지와 검증은 PPT와 PPTX 프레젠테이션 모두에서 동일하게 동작합니다.