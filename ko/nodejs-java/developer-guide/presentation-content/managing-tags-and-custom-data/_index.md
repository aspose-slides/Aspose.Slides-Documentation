---
title: JavaScript를 사용하여 프레젠테이션에서 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/nodejs-java/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 사용자 정의 XML
- 사용자 정의 XML 파트
- XML 메타데이터
- ItemId
- 태그 추가
- 쌍 값
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 태그와 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 프레젠테이션별 데이터는 태그 또는 사용자 정의 XML 파트로 저장될 수 있습니다. 태그는 간단한 키-값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터와 응용 프로그램별 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 도형 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하는 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로 상태, 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부에 저장되는 기타 구조화된 응용 프로그램 데이터와 같은 정보를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

`.pptx` 확장자를 가진 PPTX 파일은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠와 관련 데이터를 저장하는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계에 의해 연결된 여러 파트로 구성됩니다. 예를 들어, 슬라이드 파트는 단일 슬라이드의 콘텐츠를 포함하고 ISO/IEC 29500에서 정의된 다른 파트와 명시적 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([TagCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tagcollection/)) 또는 사용자 정의 XML 파트([CustomXmlPartCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpartcollection/))로 저장될 수 있습니다. 두 방법 모두 [`CustomData`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customdata/) 클래스를 통해 사용할 수 있습니다.

{{% alert color="primary" %}}
태그는 간단한 문자열 키‑값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 도형에 연관시킬 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

[`CustomData`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customdata/)의 `getCustomXmlParts()` 메서드는 특정 프레젠테이션 객체와 연관된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예시:

- `presentation.getCustomData().getCustomXmlParts()` 은 프레젠테이션 자체와 연관된 사용자 정의 XML 파트를 포함합니다.
- `slide.getCustomData().getCustomXmlParts()` 은 특정 슬라이드와 연관된 사용자 정의 XML 파트를 포함합니다.
- `shape.getCustomData().getCustomXmlParts()` 은 특정 도형과 연관된 사용자 정의 XML 파트를 포함합니다.

프레젠테이션 전체에 존재하는 모든 사용자 정의 XML 파트를 확인하려면 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)를 사용하십시오.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[`CustomXmlPartCollection`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpartcollection/)의 `add` 메서드를 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예시는 프레젠테이션 수준 사용자 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add은 식별자를 자동으로 할당합니다. 특정 UUID는 필요할 때만 설정하십시오.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 메서드는 XML을 바이트 배열로도 받을 수 있으며, 이는 XML 내용이 이미 바이너리 형태로 존재할 때 유용합니다.

### **슬라이드 또는 도형에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션 대신 특정 슬라이드나 도형에 연관시킬 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 하나의 객체에만 해당될 때 유용합니다.

다음 예시는 슬라이드에 하나의 사용자 정의 XML 파트를, 도형에 또 하나를 추가합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

파트가 추가된 수준에 따라 어느 객체의 `getCustomData().getCustomXmlParts()` 컬렉션에 해당 관계가 포함되는지가 결정됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에, 슬라이드 수준 데이터는 특정 슬라이드에, 도형 수준 데이터는 개별 도형에 메타데이터를 연결하는 데 적합합니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)를 사용하여 프레젠테이션의 모든 사용자 정의 XML 파트를 검색하십시오. 각 [`CustomXmlPart`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpart/)는 식별자, XML 내용 및 연관된 네임스페이스 스키마를 제공한다.

다음 예시는 모든 사용자 정의 XML 파트와 그 네임스페이스 스키마를 나열합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpart/)는 해당 파트에 연결된 XML 스키마를 반환합니다. 외부 시스템이 생성한 XML을 포함한 프레젠테이션을 감사할 때 유용합니다.

### **XML 내용 및 ItemId 읽기·업데이트**

[`CustomXmlPart`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpart/)의 `getXmlAsString()` 및 `setXmlAsString()`을 사용하면 UTF‑8 문자열 형태의 XML을 다룰 수 있으며, `getXmlData()`와 `setXmlData()`를 사용하면 원시 XML 바이트를 다룰 수 있습니다.

`getItemId()` 메서드는 Office Open XML 문서에서 사용자 정의 XML 파트를 식별하는 UUID를 반환합니다. 새 식별자가 필요할 경우 `setItemId()`를 사용하십시오.

다음 예시는 XML 내용과 식별자를 업데이트합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 현재 XML을 텍스트로 읽습니다.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // XML을 UTF-8 문자열로 업데이트합니다.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData는 동일한 XML 내용을 원시 바이트로 제공합니다.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // 통합에서 필요할 때 식별자를 교체합니다.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` 또는 `setXmlData`를 호출할 때는 유효하고 비어 있지 않은 XML을 제공하십시오. 문자열 기반 처리인지 바이트 기반 처리인지에 따라 적절한 방식을 선택하면 됩니다.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다.

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpart/) 은 프레젠테이션에서 해당 파트를 제거합니다.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpartcollection/) 은 컬렉션에서 특정 파트를 제거합니다.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpartcollection/) 은 지정된 인덱스의 파트를 제거합니다.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/customxmlpartcollection/) 은 해당 컬렉션의 모든 파트를 제거합니다.

다음 예시는 프레젠테이션 수준 사용자 정의 XML 파트를 참조를 통해 하나 제거합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이미 `CustomXmlPart` 인스턴스를 가지고 있고 특정 컬렉션이 아닌 프레젠테이션 자체에서 제거하려면 `customXmlPart.remove()`를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **컬렉션에서 모든 사용자 정의 XML 파트 비우기**

특정 프레젠테이션 객체와 연관된 모든 사용자 정의 XML 파트를 제거해야 할 경우 `clear`를 사용하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear`는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어 슬라이드 컬렉션을 비워도 프레젠테이션 수준이나 도형 수준 컬렉션은 그대로 유지됩니다.

프레젠테이션의 모든 사용자 정의 XML 파트를 삭제하려면 `getAllCustomXmlParts()`를 순회하면서 각 파트를 제거하십시오:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **연결되었거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트가 여러 프레젠테이션 객체에서 참조될 수 있습니다. 예를 들어 하나의 파일에 여러 슬라이드 또는 도형이 동일한 기본 XML 파트에 대한 관계를 가질 수 있습니다.

공유 파트는 여러 참조를 가진 단일 데이터 객체로 취급해야 합니다.

- `setXmlAsString`, `setXmlData` 또는 `setItemId`로 업데이트하면 기본 XML 파트가 변경되므로 모든 참조 위치에 변경이 적용됩니다.
- `getItemId()`를 사용하면 감사 시 동일 파트를 식별할 수 있습니다.
- 특정 `getCustomXmlParts()` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 제거됩니다. 프레젠테이션 전체에서 파트를 삭제하려면 `CustomXmlPart.remove()`를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 객체 수준 컬렉션을 확인하여 다른 슬라이드나 도형이 아직 참조하고 있는지 판단하십시오.

`add` 오버로드는 기존 `CustomXmlPart`를 받아들이지 않고 XML 콘텐츠로부터 새 파트를 생성합니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 주로 나타납니다.

다음 예시는 `ItemId`를 기준으로 프레젠테이션·슬라이드·도형 수준 컬렉션을 감사하고, 한 곳 이상에서 참조되는 파트를 보고합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

이러한 감사는 외부 시스템이 만든 프레젠테이션에서 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 매우 유용합니다. 동일 메타데이터 파트가 여러 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `DocumentProperties.getKeywords()` 메서드에 해당합니다. 다음 샘플 코드는 Aspose.Slides for Node.js via Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)에서 태그 값을 얻는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 요소로 구성됩니다.

- 사용자 정의 속성 이름, 예: `MyTag`
- 사용자 정의 속성 값, 예: `My Tag Value`

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 할 경우, 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어 북미 국가의 프레젠테이션을 구분하고 싶다면 “NorthAmerican” 태그를 만들고 해당 국가명을 값으로 지정하면 됩니다.

다음 샘플 코드는 Aspose.Slides for Node.js via Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)에 태그를 추가하는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

태그는 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/)에도 설정할 수 있습니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 설정할 수도 있습니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **제한 사항**

`getCustomData().getTags()` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장되며, 프레젠테이션을 PDF로 내보낼 때 PDF 태그 구조로 전송되지 **않습니다**. 따라서 태그로 지정한 사용자 정의 식별자는 PDF에서 반환할 수 없습니다.

**우회 방법**: 객체의 **Alt Text**(예: `shape.setAlternativeText("MyId")`)에 사용자 정의 식별자를 저장하십시오. PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**  
예. [tag collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tagcollection/)은 한 번에 모든 키‑값 쌍을 삭제하는 `clear` 작업을 지원합니다.

**전체 컬렉션을 순회하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 하나요?**  
[tag collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tagcollection/)의 `remove(name)`을 사용하면 키로 태그를 삭제할 수 있습니다.

**분석이나 필터링을 위해 태그 이름 전체 목록을 얻으려면?**  
[tag collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tagcollection/)의 `getNamesOfTags()`를 호출하면 모든 태그 이름이 배열로 반환됩니다.

**저장 위치와 관계없이 모든 사용자 정의 XML 파트를 찾으려면?**  
[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)를 사용하면 프레젠테이션에 포함된 모든 사용자 정의 XML 파트를 가져올 수 있습니다.

**사용자 정의 XML 파트를 업데이트할 때 `getXmlAsString`/`setXmlAsString`와 `getXmlData`/`setXmlData` 중 어느 것을 사용해야 하나요?**  
응용 프로그램이 UTF‑8 텍스트 형태의 XML을 주로 다룬다면 `getXmlAsString`·`setXmlAsString`을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이트 기반 처리가 더 편리하다면 `getXmlData`·`setXmlData`를 사용하면 됩니다. 두 방식 모두 동일 파트의 XML 내용을 참조합니다.