---
title: PHP를 사용하여 프레젠테이션에서 태그 및 사용자 지정 데이터 관리
linktitle: 태그 및 사용자 지정 데이터
type: docs
weight: 300
url: /ko/php-java/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 지정 데이터
- 태그 추가
- 쌍 값
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 태그 및 사용자 지정 데이터를 추가, 읽기, 업데이트 및 제거하는 방법을 배우고, PowerPoint 및 OpenDocument 프레젠테이션 예제를 확인하세요."
---
## **개요**

이 문서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 지정 데이터와 함께 작동하는 방식을 설명합니다. PPTX 파일에 데이터가 저장되는 방법을 간략히 설명하고, 프레젠테이션 관련 데이터가 태그와 사용자 지정 XML 파트로 존재할 수 있음을 언급하며, 태그를 키-값 문자열 쌍으로 설명합니다.

또한 태그 값을 읽는 방법과 프레젠테이션, 개별 슬라이드 또는 셰이프에 태그를 추가하는 방법을 보여줍니다. 추가로, 모든 태그를 지우기, 이름으로 태그 제거, 태그 이름 목록 가져오기와 같은 일반적인 태그 관리 작업을 다룹니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일—.pptx 확장자를 가진 항목—은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML 형식은 프레젠테이션에 포함된 데이터 구조를 정의합니다.

*슬라이드*는 프레젠테이션 요소 중 하나이며, *슬라이드 파트*는 단일 슬라이드의 내용을 포함합니다. 슬라이드 파트는 ISO/IEC 29500에서 정의된 사용자 정의 태그와 같은 여러 파트와 명시적인 관계를 가질 수 있습니다.

프레젠테이션에 특정한 사용자 정의 데이터 또는 사용자는 태그([TagCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/)) 및 CustomXmlParts([CustomXmlPartCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/)) 형태로 존재할 수 있습니다.

{{% alert color="primary" %}} 
태그는 기본적으로 문자열-키 쌍 값입니다. 
{{% /alert %}} 

## **태그 값 가져오기**

슬라이드에서 태그는 [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#getKeywords) 및 [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#setKeywords) 메서드에 해당합니다. 이 샘플 코드는 Aspose.Slides for PHP via Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation)에서 태그 값을 가져오는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 사용자 정의 속성의 이름 - `MyTag`
- 사용자 정의 속성의 값 - `My Tag Value`

특정 규칙이나 속성을 기준으로 일부 프레젠테이션을 분류해야 하는 경우, 해당 프레젠테이션에 태그를 추가하면 도움이 됩니다. 예를 들어, 북미 국가의 모든 프레젠테이션을 하나로 묶고 싶다면, 북미 태그를 만들고 해당 국가(미국, 멕시코, 캐나다)를 값으로 지정할 수 있습니다.

이 샘플 코드는 Aspose.Slides for PHP via Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation)에 태그를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

태그는 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/)에도 설정할 수 있습니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)에도 적용할 수 있습니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **제한 사항**

`getCustomData()->getTags()`를 사용하여 사용자 정의 데이터 태그 컬렉션에 추가된 태그는 PowerPoint 파일 내부에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 태그 구조로 **전송되지** 않으며, 따라서 태그로 지정된 사용자 정의 식별자를 태그가 적용된 PDF에서 검색할 수 없습니다.

**해결 방법**: 객체의 **Alt Text**에 사용자 정의 식별자를 저장할 수 있습니다(예: `$shape->setAlternativeText("MyId")`). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **자주 묻는 질문**

**프레젠테이션, 슬라이드 또는 셰이프에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/)은 모든 키‑값 쌍을 한 번에 삭제하는 [clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/clear/) 작업을 지원합니다.

**전체 컬렉션을 순회하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/)에서 [remove(name)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/remove/) 작업을 사용하여 키로 태그를 삭제합니다.

**분석 또는 필터링을 위해 모든 태그 이름 목록을 가져오려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/)에서 [getNamesOfTags](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/getnamesoftags/)을 사용하면 모든 태그 이름을 배열로 반환합니다.