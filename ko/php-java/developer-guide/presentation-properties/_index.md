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
description: "Aspose.Slides for PHP via Java에서 프레젠테이션 속성을 완벽히 관리하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이 두 속성 유형은 Aspose.Slides API를 사용하여 쉽게 접근하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 다룰 수 있습니다. 이 클래스의 인스턴스는 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDocumentProperties) 메서드가 반환합니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
주의하십시오: **Application** 및 **AppVersion** 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 이 필드를 다시 씁니다. 따라서 저장된 프레젠테이션은 항상 "Aspose.Slides for PHP via Java"와 해당 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 몇 가지 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음과 같이 두 종류가 있습니다.

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 작성자 이름, 문서 통계 등 일반적인 정보를 포함합니다. **Custom** 속성은 사용자가 **이름/값** 쌍으로 정의한 것으로, 이름과 값 모두 사용자가 정의합니다. Aspose.Slides for PHP via Java를 사용하면 Built-in 속성과 Custom 속성의 값을 모두 접근하고 수정할 수 있습니다.

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있게 해 줍니다. 아래와 같이 Office 아이콘을 클릭하고 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다.

|**Advanced Properties 메뉴 항목 선택**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다.

|**속성 대화 상자**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

위 **속성 대화 상자**에서는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 등 여러 탭 페이지가 있는 것을 확인할 수 있습니다. 이러한 탭 페이지들은 PowerPoint 파일과 관련된 다양한 정보를 설정하도록 해 줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

### Aspose.Slides for PHP via Java를 사용한 문서 속성 작업

앞서 설명했듯이 Aspose.Slides for PHP via Java는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for PHP via Java API를 사용하여 두 종류의 속성에 모두 접근할 수 있습니다. Aspose.Slides for PHP via Java는 **Presentation.DocumentProperties** 속성을 통해 프레젠테이션 파일에 연결된 문서 속성을 나타내는 [DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties) 클래스를 제공합니다.

개발자는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 객체가 제공하는 **DocumentProperties** 속성을 사용하여 프레젠테이션 파일의 문서 속성에 아래와 같이 접근할 수 있습니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 암호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. `[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)`에 `false`를 전달하여 프레젠테이션을 암호화하면 문서 속성은 공개된 상태로 유지됩니다. 그런 다음 애플리케이션은 `[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)`에 `true`를 전달하여 열기 암호를 제공하지 않고도 공개 메타데이터를 읽을 수 있습니다.

문서‑속성‑전용 옵션은 Aspose.Slides가 로드하는 내용을 제어할 뿐이며, 실제로 암호를 해제하지는 않습니다. 속성이 암호화에 포함되어 있으면 암호 없이 로드할 경우 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 `[ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)`를 통해 로드 모드를 확인한 다음 `[Presentation::getDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDocumentProperties)`를 사용해 Built-in 속성을 읽습니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 `[ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)`를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터에는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 정의 값이 포함될 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템에서 암호 없이 접근해야 할 특별한 요구가 있는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, 문서‑속성‑전용 모드로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터‑전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일치해야 하므로, 속성을 업데이트하려면 올바른 열기 암호와 전체 로드가 필요합니다.

다음 예제는 `[LoadOptions::setPassword](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setPassword)`를 사용해 프레젠테이션을 열고, 공개 Built-in 속성을 업데이트한 뒤 결과를 저장합니다. 이후 `[PresentationInfo::isEncrypted](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#isEncrypted)`를 사용해 암호화가 유지되는지 확인하고, 암호 없이 공개 메타데이터를 다시 열어 새 값을 검증합니다:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성은 읽기 전용으로 취급해야 합니다.

## **Built-in 속성 접근**

[DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties) 객체가 제공하는 이러한 속성에는 **Creator** (작성자), **Description** (설명), **Keywords** (키워드), **Created** (작성 날짜), **Modified** (수정 날짜), **Printed** (마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc** (다른 제작자와 공유 여부?), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

```php
  # 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    $dp = $pres->getDocumentProperties();
    # 내장 속성을 표시합니다
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Built-in 속성 수정**

프레젠테이션 파일의 Built-in 속성을 수정하는 것은 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 변경됩니다. 아래 예제에서는 Aspose.Slides for PHP via Java를 사용해 프레젠테이션 파일의 Built-in 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    $dp = $pres->getDocumentProperties();
    # 내장 속성을 설정합니다
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # 프레젠테이션을 파일에 저장합니다
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

이 예제는 아래와 같이 수정된 Built-in 속성을 확인할 수 있습니다:

|**수정 후 Built-in 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Custom 문서 속성 추가**

Aspose.Slides for PHP via Java를 사용하면 개발자가 프레젠테이션 문서 속성에 Custom 값을 추가할 수 있습니다. 아래 예제는 프레젠테이션에 Custom 속성을 설정하는 방법을 보여 줍니다.

```php
  $pres = new Presentation();
  try {
    # 문서 속성 가져오기
    $dProps = $pres->getDocumentProperties();
    # 사용자 정의 속성 추가
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 특정 인덱스의 속성 이름 가져오기
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # 선택된 속성 제거
    $dProps->removeCustomProperty($getPropertyName);
    # 프레젠테이션 저장
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**추가된 Custom 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Custom 속성 접근 및 수정**

Aspose.Slides for PHP via Java는 개발자가 Custom 속성 값을 접근하는 것도 지원합니다. 아래 예제는 프레젠테이션에 대해 모든 Custom 속성을 어떻게 접근하고 수정할 수 있는지 보여 줍니다.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation와 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    $dp = $pres->getDocumentProperties();
    # 사용자 정의 속성에 접근하고 수정합니다
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # 사용자 정의 속성의 이름과 값을 표시합니다
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # 사용자 정의 속성의 값을 수정합니다
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # 프레젠테이션을 파일에 저장합니다
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 Custom 속성을 수정합니다. 다음 그림은 수정 전과 후의 프레젠테이션 Custom 속성을 보여 줍니다:

|**수정 전 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**수정 후 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}
새로운 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), 그리고 [writeBindedPresentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)가 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo)에 추가되었습니다. 또한 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#setLastSavedTime) 속성 설정자의 로직이 변경되었습니다.
{{% /alert %}} 

두 새로운 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)와 [updateDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)는 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo) 클래스에 추가되었습니다. 이 메서드들은 문서 속성에 빠르게 접근하고 전체 프레젠테이션을 로드하지 않고도 속성을 변경·업데이트할 수 있게 해 줍니다.

일반적인 시나리오는 속성을 로드하고, 값을 변경한 뒤 문서를 업데이트하는 것으로, 다음과 같이 구현할 수 있습니다:

```php
  # 프레젠테이션 정보를 읽습니다
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 현재 속성을 가져옵니다
  $props = $info->readDocumentProperties();
  # Author 및 Title 필드의 새 값을 설정합니다
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 새로운 값으로 프레젠테이션을 업데이트합니다
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

특정 프레젠테이션의 속성을 템플릿으로 사용해 다른 프레젠테이션의 속성을 업데이트하는 다른 방법도 있습니다:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

새 템플릿을 처음부터 만들고 이를 사용해 여러 프레젠테이션을 업데이트할 수도 있습니다:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 PHP 코드는 PowerPoint의 교정 언어를 설정하는 방법을 보여 줍니다: xxx 왜 Java PortionFormat 클래스에 LanguageId가 없나요?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// 교정 언어의 ID를 설정합니다

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **기본 언어 설정**

다음 PHP 코드는 전체 PowerPoint 프레젠테이션에 대한 기본 언어를 설정하는 방법을 보여 줍니다:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 새 사각형 도형을 텍스트와 함께 추가합니다
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 첫 번째 구절의 언어를 확인합니다
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **실시간 예제**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata) 온라인 앱을 사용해 Aspose.Slides API를 통해 문서 속성을 어떻게 다루는지 직접 확인해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 Built-in 속성을 제거할 수 있나요?**

Built-in 속성은 프레젠테이션의 핵심 부분이며 완전히 제거할 수 없습니다. 다만, 허용되는 경우 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 Custom 속성을 추가하면 어떻게 되나요?**

이미 존재하는 Custom 속성을 추가하면 기존 값이 새로운 값으로 덮어써집니다. 속성을 미리 삭제하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/)를 사용한 뒤 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#readDocumentProperties)로 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 포맷별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/php-java/examine-presentation/)를 참고하세요.

**암호화된 프레젠테이션의 공개 속성을 열기 암호 없이 읽을 수 있나요?**

예. 문서‑속성 암호화가 프레젠테이션이 암호화되기 전에 비활성화되었고, 프레젠테이션이 문서‑속성‑전용 모드로 로드된 경우 가능합니다.

**암호화된 PPTX 파일을 문서‑속성‑전용 모드에서 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 암호와 함께 전체 프레젠테이션을 로드해야 합니다.