---
title: Android에서 프레젠테이션의 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에서 태그와 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션의 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 프레젠테이션별 데이터는 태그 또는 사용자 정의 XML 파트로 저장할 수 있습니다. 태그는 간단한 키-값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터와 응용 프로그램별 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 도형 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하기 위한 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로 상태, 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부에 저장되는 기타 구조화된 응용 프로그램 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

`.pptx` 확장자를 가진 PPTX 파일은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠와 관련 데이터를 저장하기 위한 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계로 연결된 여러 파트로 구성됩니다. 예를 들어, 슬라이드 파트는 단일 슬라이드의 내용을 포함하며 ISO/IEC 29500에 정의된 다른 파트와 명시적 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([ITagCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITagCollection)) 또는 사용자 정의 XML 파트([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection))로 저장할 수 있습니다. 두 기능 모두 [`ICustomData`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomData/) 인터페이스를 통해 사용할 수 있습니다.

{{% alert color="primary" %}}
태그는 단순 문자열 키-값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 도형에 연결될 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) 메서드는 특정 프레젠테이션 개체와 연결된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예시:

- `presentation.getCustomData().getCustomXmlParts()` 은 프레젠테이션 자체와 연결된 사용자 정의 XML 파트를 포함합니다.
- `slide.getCustomData().getCustomXmlParts()` 은 특정 슬라이드와 연결된 사용자 정의 XML 파트를 포함합니다.
- `shape.getCustomData().getCustomXmlParts()` 은 특정 도형과 연결된 사용자 정의 XML 파트를 포함합니다.

프레젠테이션 전체에 있는 모든 사용자 정의 XML 파트를 확인해야 할 경우 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 를 사용합니다.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 를 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add는 식별자를 자동으로 할당합니다. 특정 UUID는 필요한 경우에만 설정합니다.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 메서드는 XML을 바이트 배열이나 입력 스트림으로도 받을 수 있으며, XML 콘텐츠가 이미 바이너리 형태로 존재할 때 유용합니다.

### **슬라이드 또는 도형에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션이 아니라 특정 슬라이드 또는 도형에 연결할 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 하나의 객체에만 해당될 때 유용합니다.

다음 예제는 슬라이드에 하나의 사용자 정의 XML 파트를, 도형에 또 하나를 추가합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

파트가 추가되는 레벨에 따라 해당 객체의 `getCustomData().getCustomXmlParts()` 컬렉션이 파트와의 관계를 포함합니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에 적합하고, 슬라이드 수준 데이터는 특정 슬라이드에 속하는 정보에, 도형 수준 데이터는 개별 도형에 연결된 메타데이터에 적합합니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 를 사용하여 프레젠테이션의 모든 사용자 정의 XML 파트를 가져옵니다. 각 [`ICustomXmlPart`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart/) 은 식별자, XML 콘텐츠 및 연결된 네임스페이스 스키마를 노출합니다.

다음 예제는 모든 사용자 정의 XML 파트와 해당 네임스페이스 스키마를 나열합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) 은 해당 파트와 연결된 XML 스키마를 반환합니다. 이 정보는 외부 시스템에서 생성된 XML을 포함하는 프레젠테이션을 감사할 때 유용합니다.

### **XML 콘텐츠 및 ItemId 읽기 및 업데이트**

[`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 와 [`setXmlAsString()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) 을 사용하여 UTF-8 문자열 형태의 XML을 작업하거나, [`getXmlData()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) 와 [`setXmlData()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) 를 사용하여 원시 XML 바이트를 작업합니다.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) 메서드는 Office Open XML 문서에서 해당 사용자 정의 XML 파트를 식별하는 UUID를 반환합니다. 새로운 식별자가 필요할 경우 [`setItemId()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) 를 사용합니다.

다음 예제는 XML 콘텐츠와 식별자를 업데이트합니다:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 현재 XML을 텍스트로 읽습니다.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML을 UTF-8 문자열로 업데이트합니다.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData는 동일한 XML 콘텐츠를 원시 바이트 형태로 제공합니다.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 통합에 필요할 경우 식별자를 교체합니다.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` 또는 `setXmlData` 를 호출할 때는 유효하고 비어 있지 않은 XML을 제공해야 합니다. 문자열 중심으로 작업하는 경우와 바이트 데이터 중심으로 작업하는 경우 각각 적절한 표현을 사용하십시오.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#remove--) 은 프레젠테이션에서 해당 파트를 삭제합니다.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) 은 컬렉션에서 특정 파트를 삭제합니다.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) 은 지정된 인덱스의 파트를 삭제합니다.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) 은 특정 컬렉션의 모든 파트를 삭제합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 XML 파트를 참조 방식으로 하나 제거합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이미 `ICustomXmlPart` 를 보유하고 있고 컬렉션이 아닌 프레젠테이션 자체에서 해당 파트를 제거하려면 `customXmlPart.remove()` 를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **컬렉션에서 모든 사용자 정의 XML 파트 지우기**

특정 프레젠테이션 개체와 연결된 모든 사용자 정의 XML 파트를 삭제해야 할 때 `clear` 를 사용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` 는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어 슬라이드 컬렉션을 비워도 프레젠테이션 수준이나 도형 수준 컬렉션은 영향을 받지 않습니다.

프레젠테이션의 모든 사용자 정의 XML 파트를 제거하려면 `getAllCustomXmlParts()` 를 순회하면서 각 파트를 삭제합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **링크되거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트가 여러 프레젠테이션 객체에서 참조될 수 있습니다. 예를 들어, 하나의 파일에 여러 슬라이드나 도형이 같은 기본 사용자 정의 XML 파트에 대한 관계를 포함할 수 있습니다.

공유 파트는 여러 참조를 가진 하나의 데이터 객체로 취급해야 합니다:

- `setXmlAsString`, `setXmlData` 또는 `setItemId` 로 업데이트하면 기본 XML 파트가 변경되어 해당 파트를 참조하는 모든 위치에 변경이 적용됩니다.
- `getItemId()` 는 객체 수준 컬렉션을 감사하면서 동일한 사용자 정의 XML 파트를 식별하는 데 사용할 수 있습니다.
- 특정 `getCustomXmlParts()` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 삭제됩니다. 파트 자체를 프레젠테이션 전체에서 제거하려면 `ICustomXmlPart.remove()` 를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 다른 슬라이드나 도형이 여전히 참조하고 있는지 확인하려면 객체 수준 컬렉션을 검사하십시오.

`add` 오버로드는 XML 콘텐츠에서 새로운 사용자 정의 XML 파트를 생성하며 기존 `ICustomXmlPart` 를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 흔히 나타납니다.

다음 예제는 `ItemId` 로 프레젠테이션, 슬라이드 및 도형 수준 컬렉션을 감사하고, 하나 이상의 위치에서 참조되는 파트를 보고합니다:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

이러한 감사는 외부 시스템에서 생성된 프레젠테이션에서 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 유용합니다. 동일한 메타데이터 파트가 여러 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `IDocumentProperties.getKeywords()` 메서드와 대응됩니다. 다음 샘플 코드는 Aspose.Slides for Android via Java 로 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 에서 태그 값을 가져오는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 사용자 정의 속성 이름, 예: `MyTag`
- 사용자 정의 속성 값, 예: `My Tag Value`

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 할 경우 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어 북미 국가의 프레젠테이션을 구분하고 싶다면 북미 태그를 만들고 해당 국가명을 값으로 지정하면 됩니다.

다음 샘플 코드는 Aspose.Slides for Android via Java 로 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 에 태그를 추가하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

태그는 [Slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlide) 에도 설정할 수 있습니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 에도 설정할 수 있습니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **제한 사항**

`getCustomData().getTags()` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF 로 내보낼 때 태그 구조로 전송되지 **않습니다**. 따라서 태그로 지정한 사용자 정의 식별자는 태그가 지정된 PDF 에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text** (예: `shape.setAlternativeText("MyId")`) 에 사용자 정의 식별자를 저장할 수 있습니다. PDF 로 내보낸 뒤 Alt Text 가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/) 은 한 번에 모든 키-값 쌍을 삭제하는 [clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#clear--) 작업을 지원합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/) 에서 `remove(name)` (https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 을 사용하여 키로 태그를 삭제합니다.

**분석이나 필터링을 위해 모든 태그 이름 목록을 가져오려면?**

[tag collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/) 에서 `getNamesOfTags` (https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) 를 호출하면 모든 태그 이름 배열을 반환합니다.

**저장 위치에 관계없이 모든 사용자 정의 XML 파트를 찾으려면?**

[`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 를 사용하여 프레젠테이션에 존재하는 모든 사용자 정의 XML 파트를 가져옵니다.

**사용자 정의 XML 파트를 업데이트할 때 `getXmlAsString`/`setXmlAsString` 과 `getXmlData`/`setXmlData` 중 어느 것을 사용해야 하나요?**

애플리케이션이 UTF-8 XML 텍스트와 함께 작업한다면 `getXmlAsString` 와 `setXmlAsString` 을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이너리 중심 처리가 더 편리할 경우 `getXmlData` 와 `setXmlData` 를 사용하십시오. 두 표현 모두 동일한 사용자 정의 XML 파트의 XML 콘텐츠를 가리킵니다.