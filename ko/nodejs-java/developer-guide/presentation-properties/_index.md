---
title: JavaScript에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/nodejs-java/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 사용자 지정 속성
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 프레젠테이션 속성을 완벽히 관리하고, PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides for Node.js via Java은 **내장** 및 **사용자 지정** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다. 이 필드는 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 내용과 함께 설명 정보를 저장합니다. 이 속성은 두 가지 범주로 나뉩니다:

- **내장 속성**은 표준 메타데이터를 포함하며, 제목, 작성자 및 문서 통계와 같은 정보를 포함합니다.
- **사용자 지정 속성**은 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for Node.js via Java는 두 범주 모두에 대한 액세스를 제공합니다. PowerPoint에서 **File → Info → Properties → Advanced Properties**를 선택하면 문서 메타데이터를 검사할 수 있습니다. 대화 상자는 정보를 **Summary**, **Statistics**, **Contents**, **Custom**와 같은 탭으로 구분합니다. **Custom** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 암호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. `false`와 함께 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 메서드를 호출한 후 프레젠테이션을 암호화하면 문서 속성은 공개 상태로 남습니다. 애플리케이션은 이후 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 메서드를 `true`와 함께 호출하여 열기 암호를 제공하지 않고 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 은 Aspose.Slides가 로드하는 내용을 제어합니다; 암호 해독은 하지 않습니다. 속성이 암호화에 포함된 경우 암호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제는 문서 속성이 공개된 상태로 남아 있는 암호화된 프레젠테이션이 필요합니다. 이 예제는 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 를 통해 로드 모드를 확인한 다음 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 를 사용하여 내장 속성을 읽습니다:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 지정 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하세요. 색인, 분류, 검색 또는 문서 관리 시스템이 암호 없이 접근해야 하는 특별한 요구가 있는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, `true`와 함께 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 를 호출한 후 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 것입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일치해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 암호와 전체 로드가 필요합니다.

예제는 공개 문서 속성이 있는 암호화된 PPTX 프레젠테이션과 알려진 열기 암호가 필요합니다. [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) 로 전체 프레젠테이션을 열고 공개 내장 속성을 업데이트한 후 결과를 저장합니다. 그런 다음 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) 를 사용하여 암호화가 유지되는지 확인하고, 암호 없이 공개 메타데이터를 다시 열어 새 값을 확인합니다:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성 액세스**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 클래스는 [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) 등 getter 메서드를 통해 내장 메타데이터를 노출합니다. 이 예제는 기존 프레젠테이션을 열고 콘솔에 저장된 메타데이터를 출력합니다. 값은 입력 프레젠테이션에 따라 다르며 일부 필드는 비어 있을 수 있습니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 로 반환된 객체의 setter 메서드를 사용합니다. 이 예제는 기존 프레젠테이션을 열고 [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments), [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) 를 호출한 뒤 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새 메타데이터가 포함됩니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **하이퍼링크 기본값 관리**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) 은 상대 하이퍼링크에 대한 문서 수준 기본값을 반환합니다. [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) 을 사용해 이를 변경하거나 지울 수 있습니다. 이는 프레젠테이션과 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이는 개별 하이퍼링크의 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) 와는 별개이며, 기본값을 변경해도 저장된 링크 주소가 재작성되거나 절대 목적지가 바뀌지는 않습니다.

예제는 `target.html` 과 같은 상대 링크와 `https://example.org/absolute.html` 과 같은 절대 링크를 모두 포함한 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새 기본 주소를 할당한 뒤 프레젠테이션을 저장·재열어 값을 확인합니다. 그런 다음 빈 문자열로 기본값을 지우고 별도 저장 파일에서 빈 값을 검증합니다. 예제 기본 주소를 실제 연결 파일 위치로 교체하십시오.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

두 검증 메시지는 `true` 를 출력해야 합니다. 기본값을 지우더라도 개별 하이퍼링크 주소는 그대로 유지됩니다.

`target.pptx` 에 대한 상대 링크는 기본값이 `old` 폴더를 가리킬 때 `old/target.pptx` 를 열었습니다. 기본값을 `new` 폴더로 변경하고 저장·재열면 동일한 링크가 `new/target.pptx` 를 엽니다. 절대 링크는 동일한 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본값을 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **사용자 지정 프레젠테이션 속성 추가**

사용자 지정 속성은 내장 필드에 해당하는 것이 없는 메타데이터를 저장합니다. [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 메서드를 사용해 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 만들고 두 개의 텍스트 값과 정수 버전 값을 추가한 뒤 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 로 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **사용자 지정 속성 액세스 및 수정**

이 예제는 사용자 지정 속성을 포함한 프레젠테이션을 열고 [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) 로 속성 수를 얻어 반복합니다. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) 은 0 기반 인덱스를 받아 [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 에 사용되는 이름을 반환합니다. 예제는 각 원래 이름과 값을 출력하고, 모든 값을 원래 유형에 관계없이 번호가 매겨진 문자열로 교체한 뒤 변경 사항을 저장합니다. 사용자 지정 속성이 없으면 루프는 아무 변화도 일으키지 않습니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 보려면 온라인 앱인 [**PowerPoint 메타데이터 보기 및 편집**](https://products.aspose.app/slides/metadata) 를 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 부분이며 완전히 제거할 수 없습니다. 그러나 특정 속성이 허용하는 경우 값 을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 지정 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 지정 속성을 추가하면 기존 값이 새 값으로 덮어쓰기됩니다. 속성을 사전에 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고도 프레젠테이션 속성에 액세스할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) 를 사용한 다음 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) 를 사용하면 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [경량 프레젠테이션 인벤토리 구축](/slides/ko/nodejs-java/examine-presentation/) 를 참고하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 암호 없이 읽을 수 있나요?**

예. 프레젠테이션은 `false`와 함께 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 를 호출한 후 암호화되어야 하며, `true`와 함께 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 를 호출한 후 로드되어야 합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 암호로 전체 프레젠테이션을 로드해야 합니다.