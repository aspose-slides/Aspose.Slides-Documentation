---
title: "Android에서 프레젠테이션의 태그 및 사용자 지정 데이터 관리"
linktitle: "태그 및 사용자 지정 데이터"
type: docs
weight: 300
url: /ko/androidjava/managing-tags-and-custom-data
keywords:
- 문서 속성
- 태그
- 사용자 지정 데이터
- 사용자 지정 XML
- 사용자 지정 XML 파트
- XML 메타데이터
- ItemId
- 태그 추가
- 값 쌍
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 PowerPoint 프레젠테이션에서 태그와 사용자 지정 XML 데이터를 관리하는 방법을 배웁니다. 여기에는 사용자 지정 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 지정 데이터를 어떻게 다루는지 설명합니다. 프레젠테이션별 데이터는 태그 또는 사용자 지정 XML 파트로 저장할 수 있습니다. 태그는 단순한 키-값 문자열 쌍이며, 사용자 지정 XML 파트는 구조화된 메타데이터와 애플리케이션별 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 모양 수준에서 사용자 지정 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하기 위한 API를 제공합니다. 사용자 지정 XML 파트는 프레젠테이션 내부에 문서 관리 식별자, 워크플로 상태, 규정 준수 메타데이터, 템플릿 바인딩 데이터 또는 기타 구조화된 애플리케이션 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일(`.pptx` 확장자를 가진 파일)은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠와 관련 데이터를 저장하는 데 사용되는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계로 연결된 여러 파트로 구성됩니다. 예를 들어, 슬라이드 파트는 단일 슬라이드의 내용을 포함하며 ISO/IEC 29500에 정의된 다른 파트와 명시적인 관계를 가질 수 있습니다.

사용자 지정 데이터는 태그([ITagCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITagCollection)) 또는 사용자 지정 XML 파트([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection))로 저장될 수 있습니다. 두 가지 모두 [`ICustomData`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomData/) 인터페이스를 통해 사용할 수 있습니다.

{{% alert color="info" %}}
태그는 단순한 문자열 키-값 쌍을 저장합니다. 사용자 지정 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 모양에 연결될 수 있습니다.
{{% /alert %}}

## **사용자 지정 XML 파트 작업**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) 메서드는 특정 프레젠테이션 객체와 연결된 사용자 지정 XML 파트 컬렉션을 반환합니다. 예를 들어:

- `presentation.getCustomData().getCustomXmlParts()`는 프레젠테이션 자체와 연결된 사용자 지정 XML 파트를 포함합니다.
- `slide.getCustomData().getCustomXmlParts()`는 특정 슬라이드와 연결된 사용자 지정 XML 파트를 포함합니다.
- `shape.getCustomData().getCustomXmlParts()`는 특정 모양과 연결된 사용자 지정 XML 파트를 포함합니다.

프레젠테이션 내 모든 사용자 지정 XML 파트를 검사하려면 연결 위치와 관계없이 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)를 사용하십시오.

### **프레젠테이션에 사용자 지정 XML 파트 추가**

[`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 메서드를 사용하여 XML 데이터를 사용자 지정 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있어서는 안 됩니다.

다음 예제는 프레젠테이션 수준의 사용자 지정 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

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

    // add는 식별자를 자동으로 할당합니다. 필요한 경우에만 특정 UUID를 설정하십시오.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 메서드는 XML을 바이트 배열이나 입력 스트림으로도 받아들일 수 있으며, XML 콘텐츠가 이미 이진 형태로 존재할 때 유용합니다.

### **슬라이드 또는 모양에 사용자 지정 XML 파트 추가**

전체 프레젠테이션이 아니라 특정 슬라이드나 모양에 사용자 지정 XML 데이터를 연결할 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 하나의 객체만을 설명할 때 유용합니다.

다음 예제는 슬라이드에 하나의 사용자 지정 XML 파트를, 모양에 또 다른 파트를 추가합니다:

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

파트를 추가하는 수준에 따라 어느 객체의 `getCustomData().getCustomXmlParts()` 컬렉션에 해당 파트와의 관계가 포함되는지가 결정됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에 적합하고, 슬라이드 수준 데이터는 특정 슬라이드에 속한 정보에, 모양 수준 데이터는 개별 모양에 연결된 메타데이터에 적합합니다.

### **모든 사용자 지정 XML 파트 나열 및 감사**

프레젠테이션의 모든 사용자 지정 XML 파트를 검색하려면 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)를 사용하십시오. 각 [`ICustomXmlPart`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart/)은 식별자, XML 내용 및 연관된 네임스페이스 스키마를 제공합니다.

다음 예제는 모든 사용자 지정 XML 파트와 해당 네임스페이스 스키마를 나열합니다:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--)는 사용자 지정 XML 파트와 연관된 XML 스키마를 반환합니다. 이 정보는 외부 시스템에서 생성된 XML을 포함하는 프레젠테이션을 감사할 때 유용할 수 있습니다.

### **XML 내용 및 ItemId 읽기 및 업데이트**

XML을 UTF-8 문자열로 다루려면 [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 및 [`setXmlAsString()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-)를 사용하고, 원시 XML 바이트를 다루려면 [`getXmlData()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) 및 [`setXmlData()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-)를 사용하십시오.

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) 메서드는 Office Open XML 문서에서 사용자 지정 XML 파트를 식별하는 UUID를 반환합니다. 통합에서 새 식별자가 필요할 경우 [`setItemId()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)를 사용하십시오.

다음 예제는 XML 내용과 식별자를 업데이트합니다:

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

    // getXmlData는 동일한 XML 내용을 원시 바이트로 제공합니다.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 통합에서 필요할 경우 식별자를 교체합니다.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` 또는 `setXmlData`를 호출할 때는 유효하고 비어 있지 않은 XML을 제공하십시오. 애플리케이션이 주로 문자열로 작업하는지 바이트 데이터로 작업하는지에 따라 하나의 표현 방식을 선택하십시오.

### **사용자 지정 XML 파트 제거**

Aspose.Slides는 사용자 지정 XML 데이터를 제거하는 여러 방법을 제공합니다:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPart#remove--)는 프레젠테이션에서 해당 사용자 지정 XML 파트를 제거합니다.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-)는 사용자 지정 XML 파트 컬렉션에서 특정 파트를 제거합니다.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-)는 지정된 컬렉션 인덱스에 있는 파트를 제거합니다.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--)는 특정 컬렉션의 모든 파트를 제거합니다.

다음 예제는 참조를 통해 프레젠테이션 수준의 사용자 지정 XML 파트 하나를 제거합니다:

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

`ICustomXmlPart`를 이미 가지고 있고 특정 컬렉션을 지정하지 않고 프레젠테이션에서 해당 파트를 제거하려면 `customXmlPart.remove()`를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **컬렉션에서 모든 사용자 지정 XML 파트 제거**

특정 프레젠테이션 객체와 연결된 모든 사용자 지정 XML 파트를 제거하려면 `clear`를 사용하십시오.

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

`clear`는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어, 슬라이드 컬렉션을 비우면 프레젠테이션 수준이나 모양 수준 컬렉션은 비워지지 않습니다.

프레젠테이션의 모든 사용자 지정 XML 파트를 제거하려면 `getAllCustomXmlParts()`를 반복하면서 각 파트를 제거하십시오:

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

### **연결되거나 공유된 사용자 지정 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 지정 XML 파트를 둘 이상의 프레젠테이션 객체가 참조할 수 있습니다. 예를 들어, 기존 파일에는 여러 슬라이드 또는 모양이 동일한 기본 사용자 지정 XML 파트에 대한 관계를 포함할 수 있습니다.

공유 파트는 여러 참조를 가진 하나의 데이터 객체로 취급해야 합니다:

- `setXmlAsString`, `setXmlData` 또는 `setItemId`로 업데이트하면 기본 사용자 지정 XML 파트가 변경되며, 해당 파트를 참조하는 모든 위치에 변경 사항이 적용됩니다.
- `getItemId()`는 객체 수준 컬렉션을 감사할 때 동일한 사용자 지정 XML 파트를 식별하는 데 사용할 수 있습니다.
- 특정 `getCustomXmlParts()` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 파트가 제거됩니다. 파트 자체를 프레젠테이션에서 제거하려면 `ICustomXmlPart.remove()`를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 객체 수준 컬렉션을 검사하여 다른 슬라이드나 모양이 여전히 이를 참조하고 있는지 확인하십시오.

`add` 오버로드는 XML 콘텐츠에서 새로운 사용자 지정 XML 파트를 생성하며, 기존 `ICustomXmlPart`를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 흔히 나타납니다.

다음 예제는 `ItemId`별로 프레젠테이션, 슬라이드 및 모양 수준 컬렉션을 감사하고 한 곳 이상에서 참조되는 파트를 보고합니다:

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

외부 시스템이 만든 프레젠테이션에서 사용자 지정 XML 데이터를 수정하거나 삭제하기 전에 이러한 감사는 동일한 메타데이터 파트가 여러 관계에 참여할 수 있기 때문에 유용합니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `IDocumentProperties.getKeywords()` 메서드에 해당합니다. 다음 샘플 코드는 Aspose.Slides for Android를 Java로 사용하여 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation)에서 태그 값을 가져오는 방법을 보여줍니다:

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

- 예: `MyTag`와 같은 사용자 정의 속성의 이름;
- 예: `My Tag Value`와 같은 사용자 정의 속성의 값.

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 하는 경우 해당 목적에 맞게 태그를 추가할 수 있습니다. 예를 들어, 북미 국가의 프레젠테이션을 구분하려면 북미 태그를 만들고 해당 국가를 값으로 지정하면 됩니다.

다음 샘플 코드는 Aspose.Slides for Android를 Java로 사용하여 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation)에 태그를 추가하는 방법을 보여줍니다:

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

태그는 [Slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlide)에도 설정할 수 있습니다:

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

또는 개별 [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape)에도 설정할 수 있습니다:

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

`getCustomData().getTags()` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 태그 구조로 이전되지 **않습니다**. 따라서 태그로 지정된 사용자 정의 식별자는 태그가 적용된 PDF에서 가져올 수 없습니다.

**우회 방법**: 객체의 **대체 텍스트**에 사용자 정의 식별자를 저장할 수 있습니다(예: `shape.setAlternativeText("MyId")`). PDF로 내보낸 후 대체 텍스트가 PDF 태그 구조에 표시될 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 모양에서 모든 태그를 한 번에 제거할 수 있나요?**  
예. [태그 컬렉션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/)은 모든 키-값 쌍을 한 번에 삭제하는 [clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#clear--) 작업을 지원합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 하나요?**  
`remove(name)`([remove(name)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-)) 메서드를 [태그 컬렉션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/)에 사용하여 키로 태그를 삭제합니다.

**분석이나 필터링을 위해 태그 이름 전체 목록을 어떻게 가져올 수 있나요?**  
[태그 컬렉션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/)에서 [getNamesOfTags](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--)를 사용하면 모든 태그 이름이 배열로 반환됩니다.

**저장 위치에 관계없이 모든 사용자 지정 XML 파트를 어떻게 찾을 수 있나요?**  
프레젠테이션의 모든 사용자 지정 XML 파트를 검색하려면 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)를 사용하십시오.

**사용자 지정 XML 파트를 업데이트할 때 `getXmlAsString`/`setXmlAsString`와 `getXmlData`/`setXmlData` 중 어떤 것을 사용해야 하나요?**  
애플리케이션이 UTF-8 XML 텍스트를 다룰 경우 `getXmlAsString`와 `setXmlAsString`을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이너리 중심 처리가 더 편리한 경우 `getXmlData`와 `setXmlData`를 사용하십시오. 두 표현 모두 동일한 사용자 지정 XML 파트의 XML 내용을 가리킵니다.