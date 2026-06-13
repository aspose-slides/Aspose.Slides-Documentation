---
title: PHP에서 비밀번호로 프레젠테이션 보안
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/php-java/password-protected-presentation/
keywords:
- PowerPoint 잠금
- 프레젠테이션 잠금
- PowerPoint 잠금 해제
- 프레젠테이션 잠금 해제
- PowerPoint 보호
- 프레젠테이션 보호
- 비밀번호 설정
- 비밀번호 추가
- PowerPoint 암호화
- 프레젠테이션 암호화
- PowerPoint 복호화
- 프레젠테이션 복호화
- 쓰기 보호
- PowerPoint 보안
- 프레젠테이션 보안
- 비밀번호 제거
- 보호 제거
- 암호화 제거
- 비밀번호 비활성화
- 보호 비활성화
- 쓰기 보호 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제하는 방법을 배우세요. 프레젠테이션을 안전하게 보호하세요."
---
## **소개**

프레젠테이션에 비밀번호 보호를 설정하면 비밀번호를 설정하여 프레젠테이션에 특정 제한을 적용한다는 의미입니다. 제한을 제거하려면 비밀번호를 입력해야 합니다. 비밀번호로 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로 프레젠테이션에 이러한 제한을 적용하기 위해 비밀번호를 설정할 수 있습니다:

- **수정**

  특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않는 한 사람들의 프레젠테이션 수정, 변경 또는 복사를 방지합니다. 

  그러나 이 경우 비밀번호가 없어도 사용자는 문서에 접근하여 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션의 내용이나 하이퍼링크, 애니메이션, 효과 등을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다. 

- **열기**

  특정 사용자만 프레젠테이션을 열도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 비밀번호를 제공하지 않는 한 사람들의 프레젠테이션 내용을 볼 수 없게 합니다.

  기술적으로 열기 제한은 사용자가 프레젠테이션을 수정하는 것도 방지합니다: 사용자가 프레젠테이션을 열 수 없으면 수정하거나 변경할 수 없습니다. 
  
  **Note** 비밀번호 보호를 통해 열기를 방지하면 프레젠테이션 파일이 암호화됩니다.

## **온라인에서 프레젠테이션 비밀번호 보호하는 방법**

1. 우리의 [**Aspose.Slides Lock**](https://products.aspose.app/slides/ko/lock) 페이지로 이동합니다. 

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files**를 클릭합니다.

3. 컴퓨터에서 비밀번호 보호하려는 파일을 선택합니다. 

4. 편집 보호용 비밀번호와 보기 보호용 비밀번호를 입력합니다. 

5. 프레젠테이션을 최종 사본으로 보이게 하려면 **Mark as final** 체크박스를 선택합니다.

6. **PROTECT NOW.**를 클릭합니다. 

7. **DOWNLOAD NOW.**를 클릭합니다.

## **Aspose.Slides에서 프레젠테이션 비밀번호 보호**
**지원되는 형식**

Aspose.Slides는 다음 형식의 프레젠테이션에 대해 비밀번호 보호, 암호화 및 유사한 작업을 지원합니다: 

- PPTX 및 PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**지원되는 작업**

Aspose.Slides를 사용하면 다음 방법으로 프레젠테이션 수정 방지를 위해 비밀번호 보호를 사용할 수 있습니다:

- 프레젠테이션 암호화
- 프레젠테이션에 쓰기 보호 설정

**기타 작업**

Aspose.Slides를 사용하면 다음 방법으로 비밀번호 보호 및 암호화와 관련된 기타 작업을 수행할 수 있습니다:

- 프레젠테이션 암호 해제; 암호화된 프레젠테이션 열기
- 암호화 제거; 비밀번호 보호 비활성화
- 프레젠테이션에서 쓰기 보호 제거
- 암호화된 프레젠테이션의 속성 가져오기
- 프레젠테이션이 암호화되었는지 확인
- 프레젠테이션이 비밀번호 보호되었는지 확인.

## **프레젠테이션 암호화**

비밀번호를 설정하여 프레젠테이션을 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 비밀번호를 제공해야 합니다. 

프레젠테이션을 암호화하거나 비밀번호 보호하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/)의 encrypt 메서드를 사용하여 프레젠테이션에 비밀번호를 설정합니다. 비밀번호를 encrypt 메서드에 전달하고 save 메서드를 사용하여 이제 암호화된 프레젠테이션을 저장합니다.

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션에 “수정 금지” 표시를 추가할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 수정하지 않도록 알릴 수 있습니다.  

**Note** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 실제로 원한다면 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 프레젠테이션을 만들어야 합니다. 

쓰기 보호를 설정하려면 [setWriteProtection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#setWriteProtection) 메서드를 사용해야 합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **암호화된 프레젠테이션 로드**

Aspose.Slides를 사용하면 비밀번호를 전달하여 암호화된 파일을 로드할 수 있습니다. 프레젠테이션을 복호화하려면 매개변수 없이 [removeEncryption](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#removeEncryption) 메서드를 호출해야 합니다. 그런 다음 올바른 비밀번호를 입력하여 프레젠테이션을 로드합니다.

다음 샘플 코드는 프레젠테이션을 복호화하는 방법을 보여줍니다: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 복호화된 프레젠테이션 작업
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **프레젠테이션에서 암호화 제거**

프레젠테이션에서 암호화 또는 비밀번호 보호를 제거할 수 있습니다. 이렇게 하면 사용자가 제한 없이 프레젠테이션에 접근하거나 수정할 수 있게 됩니다. 

암호화 또는 비밀번호 보호를 제거하려면 [removeEncryption](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#removeEncryption) 메서드를 호출해야 합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **프레젠테이션에서 쓰기 보호 제거**

Aspose.Slides를 사용하면 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자가 원하는 대로 수정할 수 있으며, 해당 작업을 수행할 때 경고가 표시되지 않습니다.

프레젠테이션에서 쓰기 보호를 제거하려면 [removeWriteProtection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#removeWriteProtection) 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **암호화된 프레젠테이션의 속성 가져오기**

일반적으로 사용자는 암호화되었거나 비밀번호로 보호된 프레젠테이션의 문서 속성을 가져오는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 비밀번호 보호하면서도 사용자가 해당 프레젠테이션의 속성에 접근할 수 있는 메커니즘을 제공합니다.

**Note** Aspose.Slides가 프레젠테이션을 암호화하면 기본적으로 프레젠테이션의 문서 속성도 비밀번호로 보호됩니다. 하지만 암호화 후에도 프레젠테이션 속성을 접근 가능하게 해야 하는 경우, Aspose.Slides는 정확히 그 작업을 수행할 수 있게 해줍니다. 

암호화된 프레젠테이션의 속성을 사용자가 접근할 수 있도록 하려면 `true` 값을 사용하여 [encryptDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) 메서드를 호출하면 됩니다. 다음 샘플 코드는 프레젠테이션을 암호화하면서 사용자가 문서 속성에 접근할 수 있게 하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **프레젠테이션이 비밀번호 보호되었는지 확인**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 비밀번호로 보호되지 않았는지 확인하고 싶을 수 있습니다. 이렇게 하면 비밀번호가 없는 상태로 비밀번호 보호된 프레젠테이션을 로드하려 할 때 발생하는 오류와 유사한 문제를 피할 수 있습니다.

다음 PHP 코드는 프레젠테이션을 실제로 로드하지 않고도 비밀번호 보호 여부를 검사하는 방법을 보여줍니다:

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **프레젠테이션이 암호화되었는지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이 작업을 수행하려면 암호화된 경우 `true`, 그렇지 않은 경우 `false`를 반환하는 [isEncrypted](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#isEncrypted) 메서드를 사용할 수 있습니다.

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **프레젠테이션이 쓰기 보호되었는지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이 작업을 수행하려면 암호화된 경우 `true`, 그렇지 않은 경우 `false`를 반환하는 [isWriteProtected](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#isWriteProtected) 메서드를 사용할 수 있습니다.

다음 샘플 코드는 프레젠테이션이 쓰기 보호되었는지 확인하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **특정 비밀번호가 사용되었는지 검증하거나 확인**

프레젠테이션 문서를 보호하기 위해 특정 비밀번호가 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 비밀번호를 검증할 수 있는 수단을 제공합니다. 

다음 샘플 코드는 비밀번호를 검증하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # "pass"가 일치하는지 확인
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

지정된 비밀번호로 프레젠테이션이 암호화된 경우 `true`를 반환하고, 그렇지 않은 경우 `false`를 반환합니다.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방법은 무엇입니까?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방법을 지원하여 프레젠테이션의 데이터 보안을 높은 수준으로 보장합니다.

**프레젠테이션을 열려고 할 때 잘못된 비밀번호를 입력하면 어떻게 됩니까?**

잘못된 비밀번호가 사용되면 예외가 발생하여 프레젠테이션에 대한 접근이 거부되었음을 알립니다. 이는 무단 접근을 방지하고 프레젠테이션 콘텐츠를 보호하는 데 도움이 됩니다.

**비밀번호 보호된 프레젠테이션을 작업할 때 성능에 영향을 미칩니까?**

암호화 및 복호화 과정은 열기 및 저장 작업 시 약간의 오버헤드를 발생시킬 수 있습니다. 대부분의 경우 이 성능 영향은 미미하며 프레젠테이션 작업 전체 처리 시간에 크게 영향을 주지 않습니다.