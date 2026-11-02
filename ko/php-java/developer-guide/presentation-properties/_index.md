---
title: PHP에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/php-java/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 사용자 정의 속성
- 고급 속성
- 속성 관리
- 속성 수정
- 문서 메타데이터
- 메타데이터 편집
- 교정 언어
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides for PHP via Java는 **내장** 및 **사용자 정의** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides를 사용하면 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 클래스의 인스턴스는 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다. 이 예제들은 PHP/Java Bridge와 Aspose.Slides PHP 래퍼가 초기화되어 있다고 가정합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다; 이 필드들은 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 콘텐츠와 함께 설명 정보를 저장합니다. 두 가지 범주로 구분됩니다:

- **내장 속성** 표준 메타데이터를 포함하며, 제목, 작성자 및 문서 통계와 같은 정보를 포함합니다.
- **사용자 정의 속성** 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for PHP via Java는 두 범주 모두에 대한 액세스를 제공합니다. PowerPoint에서 **File → Info → Properties → Advanced Properties**를 선택하면 문서 메타데이터를 검사할 수 있습니다. 대화 상자는 정보를 **Summary**, **Statistics**, **Contents**, **Custom**과 같은 탭으로 구분합니다. **Custom** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 콘텐츠와 문서 속성을 모두 보호합니다. [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/)를 `false`와 함께 호출한 후 프레젠테이션을 암호화하면, 해당 문서 속성은 공개 상태로 남습니다. 그런 다음 애플리케이션은 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/)를 `true`와 함께 호출하여 열기 비밀번호 없이 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/)는 Aspose.Slides가 로드하는 항목을 제어하며, 암호를 해제하지는 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

이 예제는 문서 속성이 공개된 상태로 남은 암호화된 프레젠테이션이 필요합니다. [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/)를 통해 로드 모드를 확인한 다음 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/)를 사용하여 내장 속성을 읽습니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

이 모드에서는 슬라이드 콘텐츠가 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/)를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 액세스해야 하는 특정 요구가 있을 경우에만 공개 상태로 두십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/)를 `true`와 함께 호출한 후 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없으며, 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일관되어야 합니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

이 예제는 공개 문서 속성이 있는 암호화된 PPTX 프레젠테이션과 알려진 열기 비밀번호가 필요합니다. [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/)를 사용하여 전체 프레젠테이션을 열고, 공개 내장 속성을 업데이트한 뒤 결과를 저장합니다. 그런 다음 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/)를 사용하여 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새 값을 검증합니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

애플리케이션이 프레젠테이션 콘텐츠를 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성 액세스**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 클래스는 [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/), [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) 등 getter 메서드를 통해 내장 메타데이터를 노출합니다. 이 예제는 기존 프레젠테이션을 열고 저장된 메타데이터를 콘솔에 출력합니다. 값은 입력 프레젠테이션에 따라 다르며, 일부 필드는 비어 있을 수 있습니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/)에서 반환된 객체의 setter 메서드를 사용합니다. 이 예제는 기존 프레젠테이션을 열고 [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/), [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/)를 호출한 뒤, [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)으로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **하이퍼링크 기본값 관리**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/)은 상대 하이퍼링크에 대한 문서 수준의 기본값을 반환합니다. [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/)를 사용하여 변경하거나 지울 수 있습니다. 이는 프레젠테이션과 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이것은 개별 하이퍼링크의 [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/)와는 별개이며, 기본값을 변경해도 저장된 링크 주소가 다시 쓰이거나 절대 경로가 변경되지 않습니다.

이 예제는 `target.html`과 같은 상대 링크와 `https://example.org/absolute.html`과 같은 절대 링크를 모두 포함한 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새 기본 주소를 할당한 뒤 프레젠테이션을 저장하고 다시 열어 값을 확인합니다. 그런 다음 빈 문자열로 기본값을 지우고 별도의 저장 파일에서 빈 값을 검증합니다. 예제 기본 주소를 연결된 파일이 위치한 곳으로 교체하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

두 확인 메시지는 `true`를 출력해야 합니다. 기본값을 지워도 개별 하이퍼링크 주소는 그대로 유지됩니다.

`target.pptx`에 대한 상대 링크는 기본값이 `old` 폴더를 가리킬 때 `old/target.pptx`를 열었습니다. 기본값을 `new` 폴더로 변경하고 저장 및 프레젠테이션을 다시 열면 같은 링크가 `new/target.pptx`를 엽니다. 절대 링크는 동일한 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본값을 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **사용자 정의 프레젠테이션 속성 추가**

사용자 정의 속성은 해당하는 내장 필드가 없는 메타데이터를 저장합니다. [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) 메서드를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값 및 정수 버전 값을 추가한 뒤 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)으로 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 대체됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **사용자 정의 속성 액세스 및 수정**

이 예제는 사용자 정의 속성을 포함하는 프레젠테이션을 열고 [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/)를 사용하여 반복합니다. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/)는 0부터 시작하는 인덱스를 받아 [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/)에서 사용된 이름을 반환합니다. 예제는 각 원래 이름과 값을 출력하고, 모든 값을 원래 유형에 관계없이 번호가 매겨진 문자열로 교체한 뒤 변경 사항을 저장합니다. 사용자 정의 속성이 없으면 루프는 아무 변경도 하지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **실시간 예제**

[**PowerPoint 메타데이터 보기 및 편집**](https://products.aspose.app/slides/metadata) 온라인 앱을 사용해 Aspose.Slides API로 문서 속성을 다루는 방법을 확인하십시오:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 그러나 해당 값을 변경하거나 특정 속성이 허용하는 경우 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어쓰여집니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 액세스할 수 있나요?**

예. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용한 다음 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제 및 형식별 제한 사항은 [경량 프레젠테이션 인벤토리 구축](/slides/ko/php-java/examine-presentation/)을 참조하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽할 수 있나요?**

예. 프레젠테이션은 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/)를 `false`와 함께 호출한 후 암호화되어야 하며, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/)를 `true`와 함께 호출한 후 로드되어야 합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니오. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호로 전체 프레젠테이션을 로드해야 합니다.