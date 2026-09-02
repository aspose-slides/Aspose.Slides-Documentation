---
title: PHP를 사용하여 프레젠테이션에서 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/php-java/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 사용자 정의 XML
- 사용자 정의 XML 파트
- XML 메타데이터
- ItemId
- 태그 추가
- 키-값 쌍
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 태그와 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 프레젠테이션별 데이터는 태그 또는 사용자 정의 XML 파트로 저장될 수 있습니다. 태그는 단순한 키-값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터 및 애플리케이션별 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 도형 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하기 위한 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로 상태, 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부의 기타 구조화된 애플리케이션 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

`.pptx` 확장자를 가진 PPTX 파일은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠 및 관련 데이터를 저장하기 위해 사용되는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계로 연결된 여러 파트로 구성됩니다. 예를 들어 슬라이드 파트는 단일 슬라이드의 내용을 포함하며 ISO/IEC 29500에서 정의된 다른 파트에 대한 명시적 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([TagCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/)) 또는 사용자 정의 XML 파트([CustomXmlPartCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/))로 저장될 수 있습니다. 두 기능 모두 [`CustomData`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customdata/) 클래스를 통해 사용할 수 있습니다.

{{% alert color="primary" %}}
태그는 단순 문자열 키-값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 도형에 연결될 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customdata/#getCustomXmlParts) 메서드는 특정 프레젠테이션 객체에 연결된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예시:

- `$presentation->getCustomData()->getCustomXmlParts()`는 프레젠테이션 자체에 연결된 사용자 정의 XML 파트를 포함합니다.
- `$slide->getCustomData()->getCustomXmlParts()`는 특정 슬라이드에 연결된 사용자 정의 XML 파트를 포함합니다.
- `$shape->getCustomData()->getCustomXmlParts()`는 특정 도형에 연결된 사용자 정의 XML 파트를 포함합니다.

프레젠테이션 전체의 모든 사용자 정의 XML 파트를 검사해야 할 경우에는 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getAllCustomXmlParts)를 사용하십시오.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/#add) 메서드를 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예시는 프레젠테이션 수준의 사용자 정의 데이터 컬렉션에 구조화된 메타데이터를 추가합니다.

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add는 식별자를 자동으로 할당합니다. 필요한 경우에만 특정 UUID를 설정합니다.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` 메서드는 XML을 바이트 배열이나 입력 스트림으로도 받을 수 있으며, 이는 XML 콘텐츠가 이미 바이너리 형태로 존재할 때 유용합니다.

### **슬라이드 또는 도형에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션 대신 특정 슬라이드나 도형에 연결할 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 단일 객체에만 해당될 때 유용합니다.

다음 예시는 슬라이드에 하나의 사용자 정의 XML 파트를, 도형에 또 하나를 추가합니다.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

파트가 추가되는 레벨에 따라 해당 객체의 `getCustomData()->getCustomXmlParts()` 컬렉션에 관계가 포함됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에, 슬라이드 수준 데이터는 특정 슬라이드에 대한 정보에, 도형 수준 데이터는 개별 도형에 연결된 메타데이터에 적합합니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 를 사용하여 프레젠테이션에서 모든 사용자 정의 XML 파트를 가져옵니다. 각 [`CustomXmlPart`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/) 은 식별자, XML 내용 및 관련 네임스페이스 스키마를 제공합니다.

다음 예시는 모든 사용자 정의 XML 파트와 해당 네임스페이스 스키마를 나열합니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) 은 해당 파트와 연결된 XML 스키마를 반환합니다. 이 정보는 외부 시스템에서 생성된 XML을 포함하는 프레젠테이션을 감사할 때 유용합니다.

### **XML 콘텐츠 및 ItemId 읽기 및 업데이트**

[`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#getXmlAsString) 과 [`setXmlAsString()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#setXmlAsString) 를 사용하여 UTF-8 문자열 형태의 XML을 작업하거나, [`getXmlData()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#getXmlData) 와 [`setXmlData()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#setXmlData) 를 사용하여 원시 XML 바이트를 작업합니다.

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#getItemId) 메서드는 Office Open XML 문서에서 해당 사용자 정의 XML 파트를 식별하는 UUID를 반환합니다. 새로운 식별자가 필요할 경우 [`setItemId()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#setItemId) 를 사용하십시오.

다음 예시는 XML 콘텐츠와 식별자를 업데이트합니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // 현재 XML을 텍스트로 읽습니다.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // XML을 UTF-8 문자열로 업데이트합니다.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData는 동일한 XML 내용을 원시 바이트 형태로 제공합니다.
    $customXmlData = $customXmlPart->getXmlData();

    // 통합에서 필요할 때 식별자를 교체합니다.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`setXmlAsString` 또는 `setXmlData` 를 호출할 때는 유효하고 비어 있지 않은 XML을 제공합니다. 애플리케이션이 문자열 중심인지 바이트 중심인지에 따라 하나의 표현을 선택하십시오.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다.

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpart/#remove) 은 프레젠테이션에서 해당 파트를 제거합니다.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/#remove) 은 컬렉션에서 특정 파트를 제거합니다.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/#removeAt) 은 지정된 인덱스의 파트를 제거합니다.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/customxmlpartcollection/#clear) 은 특정 컬렉션의 모든 파트를 제거합니다.

다음 예시는 프레젠테이션 수준 사용자 정의 XML 파트 하나를 참조를 통해 제거합니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이미 `CustomXmlPart` 인스턴스가 있는 경우 해당 파트를 프레젠테이션에서 제거하려면 `$customXmlPart->remove()` 를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다.

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **컬렉션에서 모든 사용자 정의 XML 파트 삭제**

특정 프레젠테이션 객체와 연결된 모든 사용자 정의 XML 파트를 제거해야 할 경우 `clear` 를 사용하십시오.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` 는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어 슬라이드 컬렉션을 비워도 프레젠테이션 수준이나 도형 수준 컬렉션은 그대로 유지됩니다.

프레젠테이션 전체의 모든 사용자 정의 XML 파트를 제거하려면 `getAllCustomXmlParts()` 를 반복하면서 각 파트를 제거하십시오.

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **연결되거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트를 여러 프레젠테이션 객체가 참조할 수 있습니다. 예를 들어 기존 파일에 여러 슬라이드나 도형이 동일한 사용자 정의 XML 파트와 관계를 맺을 수 있습니다.

공유 파트는 여러 참조를 가진 하나의 데이터 객체로 취급해야 합니다.

- `setXmlAsString`, `setXmlData` 또는 `setItemId` 로 업데이트하면 기본 사용자 정의 XML 파트가 변경되므로 해당 파트를 참조하는 모든 위치에 적용됩니다.
- `getItemId()` 를 사용하여 감사 시 동일한 사용자 정의 XML 파트를 식별할 수 있습니다.
- 특정 `getCustomXmlParts()` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 삭제됩니다. 프레젠테이션 전체에서 파트를 제거하려면 `CustomXmlPart::remove()` 를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 다른 슬라이드나 도형이 아직 참조하고 있는지 객체 수준 컬렉션을 검사하십시오.

`add` 오버로드는 XML 콘텐츠에서 새로운 사용자 정의 XML 파트를 생성하며 기존 `CustomXmlPart` 를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 흔히 나타납니다.

다음 예시는 `ItemId` 로 프레젠테이션, 슬라이드 및 도형 수준 컬렉션을 감사하고 여러 위치에서 참조되는 파트를 보고합니다.

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

이러한 감사는 외부 시스템에서 생성된 프레젠테이션의 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 유용합니다. 동일한 메타데이터 파트가 둘 이상의 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `DocumentProperties::getKeywords()` 메서드에 해당합니다. 다음 샘플 코드는 Aspose.Slides for PHP via Java 를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 에서 태그 값을 가져오는 방법을 보여줍니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다.

- 사용자 정의 속성 이름, 예: `MyTag`
- 사용자 정의 속성 값, 예: `My Tag Value`

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 하는 경우 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어 북미 국가의 프레젠테이션을 구분하고 싶다면 북미 태그를 만들고 해당 국가명을 값으로 할당하면 됩니다.

다음 샘플 코드는 Aspose.Slides for PHP via Java 를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)에 태그를 추가하는 방법을 보여줍니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

태그는 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 에도 설정할 수 있습니다.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 에도 설정할 수 있습니다.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **제한 사항**

`getCustomData()->getTags()` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF 로 내보낼 때 태그 구조로 **전송되지 않습니다**. 따라서 태그로 할당된 사용자 정의 식별자는 PDF 에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text** 에 사용자 정의 식별자를 저장할 수 있습니다(예: `$shape->setAlternativeText("MyId")`). PDF 로 내보낸 후 Alt Text 가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/) 은 모든 키-값 쌍을 한 번에 삭제하는 [clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/#clear) 연산을 지원합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 제거하려면 어떻게 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/) 에서 [remove(name)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/#remove) 을 사용하여 키로 태그를 삭제하십시오.

**분석이나 필터링을 위해 태그 이름 전체 목록을 가져오려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/) 에서 [getNamesOfTags](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tagcollection/#getNamesOfTags) 를 사용하면 모든 태그 이름이 배열로 반환됩니다.

**저장 위치와 관계없이 모든 사용자 정의 XML 파트를 찾으려면 어떻게 하나요?**

[`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 를 사용하여 프레젠테이션의 모든 사용자 정의 XML 파트를 가져오십시오.

**사용자 정의 XML 파트를 업데이트할 때 `getXmlAsString`/`setXmlAsString` 과 `getXmlData`/`setXmlData` 중 어느 것을 사용해야 하나요?**

애플리케이션이 UTF‑8 XML 텍스트와 함께 작업한다면 `getXmlAsString` 와 `setXmlAsString` 을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이너리 처리가 더 편리하다면 `getXmlData` 와 `setXmlData` 를 사용하십시오. 두 표현은 동일한 사용자 정의 XML 파트의 내용을 참조합니다.