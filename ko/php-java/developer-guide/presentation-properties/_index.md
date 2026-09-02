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
- 기본 속성
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
description: "Aspose.Slides for PHP via Java에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getDocumentProperties) 메서드에 의해 반환됩니다. 아래 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
**Application** 및 **AppVersion** 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 해당 필드를 다시 씁니다. 따라서 저장된 프레젠테이션은 항상 "Aspose.Slides for PHP via Java"와 해당 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 사용하면 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 다음 두 종류가 있습니다.

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 작성자 이름, 문서 통계 등 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의하는 속성으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for PHP via Java를 사용하면 내장 속성과 사용자 정의 속성 모두에 액세스하고 값을 수정할 수 있습니다.

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007에서는 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. Office 아이콘을 클릭한 후 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다.

|**고급 속성 메뉴 항목 선택**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)|** **|
**고급 속성** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다.

|**속성 대화 상자**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)|** **|
위 **속성 대화 상자**에서는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 등 여러 탭 페이지를 볼 수 있습니다. 각 탭 페이지에서는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있습니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **Aspose.Slides for PHP via Java를 사용한 문서 속성 작업**

앞서 설명한 바와 같이 Aspose.Slides for PHP via Java는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for PHP via Java API를 사용하여 두 종류의 속성에 모두 액세스할 수 있습니다. Aspose.Slides for PHP via Java는 프레젠테이션 파일과 연결된 문서 속성을 나타내는 [DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties) 클래스를 제공합니다. 이 클래스는 **Presentation.DocumentProperties** 속성을 통해 접근할 수 있습니다.

개발자는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 객체가 제공하는 **DocumentProperties** 속성을 사용하여 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다.

## **내장 속성에 액세스**

[DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties) 객체가 노출하는 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(생성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

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

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 해당 속성에 문자열 값을 할당하는 것만큼 쉽습니다. 아래 예제에서는 Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

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

이 예제는 수정된 내장 속성을 아래와 같이 표시합니다.

|**수정 후 내장 문서 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)|** **|

## **사용자 정의 문서 속성 추가**

Aspose.Slides for PHP via Java를 사용하면 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있습니다. 아래 예제에서는 프레젠테이션에 사용자 정의 속성을 설정하는 방법을 보여줍니다.

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
    # 선택한 속성 제거
    $dProps->removeCustomProperty($getPropertyName);
    # 프레젠테이션 저장
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**추가된 사용자 정의 문서 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)|** **|

## **사용자 정의 속성 액세스 및 수정**

Aspose.Slides for PHP via Java를 사용하면 사용자 정의 속성의 값을 액세스하고 수정할 수 있습니다. 아래 예제에서는 프레젠테이션의 모든 사용자 정의 속성에 액세스하고 수정하는 방법을 보여줍니다.

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

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 사용자 정의 속성을 수정합니다. 다음 그림은 수정 전후의 사용자 정의 속성을 보여줍니다.

|**수정 전 사용자 정의 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)|** **|

|**수정 후 사용자 정의 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)|** **|

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}
새 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), [writeBindedPresentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)가 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo)에 추가되었으며, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#setLastSavedTime) 속성 설정자의 로직이 변경되었습니다.
{{% /alert %}} 

새 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)와 [updateDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)는 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo) 클래스에 추가되었습니다. 이 메서드를 사용하면 프레젠테이션 전체를 로드하지 않고도 문서 속성에 빠르게 액세스하고, 속성을 변경·업데이트할 수 있습니다.

일반적인 시나리오: 속성을 로드하고, 값을 변경한 뒤, 문서를 업데이트하는 예는 다음과 같습니다.

```php
  # 프레젠테이션 정보를 읽습니다
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 현재 속성을 가져옵니다
  $props = $info->readDocumentProperties();
  # Author 및 Title 필드의 새 값을 설정합니다
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 새 값으로 프레젠테이션을 업데이트합니다
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

특정 프레젠테이션의 속성을 템플릿으로 사용하여 다른 프레젠테이션의 속성을 업데이트하는 방법도 있습니다:

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

새 템플릿을 처음부터 만든 후 여러 프레젠테이션을 업데이트하는 데 사용할 수 있습니다:

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

Aspose.Slides는 PortionFormat 클래스가 제공하는 LanguageId 속성을 통해 PowerPoint 문서의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 PHP 코드는 PowerPoint의 교정 언어를 설정하는 방법을 보여줍니다: xxx Why is LanguageId missing from Java PortionFormat class?

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

다음 PHP 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여줍니다:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 새 사각형 모양을 텍스트와 함께 추가합니다
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 첫 번째 Portion의 언어를 확인합니다
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 작업하는 방법을 보려면 온라인 앱 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)를 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 부분이므로 완전히 제거할 수 없습니다. 다만 해당 속성의 값을 변경하거나, 해당 속성이 허용하는 경우 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새로운 값으로 덮어쓰기 됩니다. 속성을 사전에 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 액세스할 수 있나요?**

예. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/)를 사용한 다음 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/#readDocumentProperties)로 저장된 문서 메타데이터를 읽으면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 만들 필요가 없습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/php-java/examine-presentation/)를 참조하세요.