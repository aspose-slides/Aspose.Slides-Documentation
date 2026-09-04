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
description: "Aspose.Slides for Node.js via Java에서 프레젠테이션 속성을 완벽하게 관리하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides는 **내장** 및 **사용자 지정** 두 가지 유형의 문서 속성을 지원합니다. 이 두 종류의 속성은 Aspose.Slides API를 통해 손쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 메서드가 반환합니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}

**Application** 및 **AppVersion** 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 이 필드를 다시 씁니다. 따라서 저장된 프레젠테이션은 항상 "Aspose.Slides for Node.js via Java"와 해당 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.

{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 몇 가지 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 사용하면 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음 두 가지 종류가 있습니다.

- 시스템 정의(내장) 속성
- 사용자 정의(커스텀) 속성

**내장** 속성은 문서 제목, 작성자 이름, 문서 통계 등 일반적인 정보를 포함합니다. **커스텀** 속성은 사용자가 **이름/값** 쌍으로 정의하는 속성으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for Node.js via Java를 사용하면 개발자는 내장 속성과 커스텀 속성의 값을 모두 액세스하고 수정할 수 있습니다.

## **PowerPoint에서의 문서 속성**

Microsoft PowerPoint 2007에서는 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. 아래와 같이 Office 아이콘을 클릭한 다음 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다.

|**Advanced Properties 메뉴 항목 선택**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|
**Advanced Properties** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다.

|**속성 대화 상자**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|
위 **속성 대화 상자**에서는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 등 여러 탭 페이지를 확인할 수 있습니다. 각 탭은 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해 줍니다. **Custom** 탭은 PowerPoint 파일의 커스텀 속성을 관리하는 데 사용됩니다.

### Aspose.Slides for Node.js via Java를 사용한 문서 속성 작업

앞서 설명했듯이 Aspose.Slides for Node.js via Java는 **내장** 및 **커스텀** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for Node.js via Java API를 사용해 두 종류의 속성에 모두 액세스할 수 있습니다. Aspose.Slides for Node.js via Java는 **Presentation.DocumentProperties** 속성을 통해 프레젠테이션 파일에 연결된 문서 속성을 나타내는 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 클래스를 제공합니다.

개발자는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 객체가 노출하는 **DocumentProperties** 속성을 사용해 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. `false`를 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 에 전달하여 문서를 암호화하면, 해당 문서의 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 `true`를 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 에 전달하여 열기 비밀번호 없이 공개 메타데이터만 읽을 수 있습니다.

문서‑속성‑전용 옵션은 Aspose.Slides가 로드하는 대상을 제어하며, 실제로 복호화는 수행하지 않습니다. 속성이 암호화에 포함되어 있다면 비밀번호 없이 로드에 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 로 로드 모드를 확인한 뒤, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 로 내장 속성을 읽습니다.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체에 접근할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터에는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 커스텀 값이 포함될 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템에서 비밀번호 없이 접근해야 하는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일에 대해 문서‑속성‑전용 모드로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터‑전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일관성을 유지해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

다음 예제는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword) 로 프레젠테이션을 연 뒤, 공개 내장 속성을 업데이트하고 결과를 저장합니다. 이후 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) 로 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새 값을 검증합니다.

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성은 읽기 전용으로 취급해야 합니다.

## **내장 속성 액세스**

[DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 객체가 노출하는 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 내장 속성을 표시합니다
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 해당 속성에 문자열 값을 할당하는 것만큼 간단합니다. 아래 예제에서는 Aspose.Slides for Node.js via Java를 사용해 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 내장 속성을 설정합니다
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // 프레젠테이션을 파일에 저장합니다
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

다음 그림은 수정된 내장 문서 속성을 보여줍니다.

|**수정 후 내장 문서 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **커스텀 문서 속성 추가**

Aspose.Slides for Node.js via Java를 사용하면 개발자가 프레젠테이션 문서 속성에 커스텀 값을 추가할 수 있습니다. 아래 예제는 프레젠테이션에 커스텀 속성을 설정하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 문서 속성 가져오기
    var dProps = pres.getDocumentProperties();
    // 커스텀 속성 추가
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 특정 인덱스의 속성 이름 가져오기
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 선택한 속성 제거
    dProps.removeCustomProperty(getPropertyName);
    // 프레젠테이션 저장
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**추가된 커스텀 문서 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **커스텀 속성 액세스 및 수정**

Aspose.Slides for Node.js via Java를 사용하면 개발자가 커스텀 속성 값을 액세스하고 수정할 수 있습니다. 아래 예제는 프레젠테이션의 모든 커스텀 속성을 어떻게 액세스하고 수정할 수 있는지 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 커스텀 속성에 접근하고 수정합니다
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 커스텀 속성의 이름과 값을 표시합니다
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 커스텀 속성의 값을 수정합니다
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // 프레젠테이션을 파일에 저장합니다
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 커스텀 속성을 수정합니다. 다음 그림은 수정 전후의 커스텀 속성을 각각 보여줍니다.

|**수정 전 커스텀 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**수정 후 커스텀 속성**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}

새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), 및 [WriteBindedPresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) 가 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo) 에 추가되었으며, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 속성 설정자의 로직이 변경되었습니다.

{{% /alert %}} 

새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) 및 [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 가 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo) 클래스에 추가되었습니다. 이 메서드들은 문서 속성에 빠르게 접근하고 전체 프레젠테이션을 로드하지 않고도 속성을 변경·업데이트할 수 있게 해 줍니다.

일반적인 시나리오는 속성을 로드하고, 값을 변경한 뒤, 문서를 업데이트하는 방식으로 구현됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 정보를 읽습니다
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 현재 속성을 가져옵니다
var props = info.readDocumentProperties();
// Author와 Title 필드의 새 값을 설정합니다
props.setAuthor("New Author");
props.setTitle("New Title");
// 새 값으로 프레젠테이션을 업데이트합니다
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

특정 프레젠테이션의 속성을 템플릿으로 사용해 다른 프레젠테이션의 속성을 업데이트하는 또 다른 방법이 있습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

새 템플릿을 처음부터 만들고 여러 프레젠테이션을 업데이트하는 방법도 있습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **맞춤법 교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 통해 PowerPoint 문서의 맞춤법 교정 언어를 설정할 수 있게 해 줍니다. 맞춤법 교정 언어는 PowerPoint에서 철자 및 문법 검사를 수행할 언어를 의미합니다.

다음 JavaScript 코드는 PowerPoint의 맞춤법 교정 언어를 설정하는 방법을 보여 줍니다: xxx 왜 JavaScript PortionFormat 클래스에 LanguageId가 없나요?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **기본 언어 설정**

다음 JavaScript 코드는 전체 PowerPoint 프레젠테이션에 대한 기본 언어를 설정하는 방법을 보여 줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 텍스트가 포함된 새로운 사각형 도형을 추가합니다
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 첫 번째 부분의 언어를 확인합니다
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **실시간 예제**

Aspose.Slides API를 통해 문서 속성을 다루는 방법을 확인하려면 온라인 앱 **[Aspose.Slides Metadata](https://products.aspose.app/slides/ko/metadata)**을 사용해 보세요.

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거할 수 있나요?**

내장 속성은 프레젠테이션의 필수 요소이며 완전히 제거할 수 없습니다. 그러나 해당 속성이 허용하는 경우 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 커스텀 속성을 추가하면 어떻게 되나요?**

이미 존재하는 커스텀 속성을 추가하면 기존 값이 새 값으로 덮어쓰기 됩니다. 속성을 사전에 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고도 속성에 접근할 수 있나요?**

네. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) 를 사용한 뒤 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/nodejs-java/examine-presentation/) 를 참고하세요.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

네. 문서‑속성 암호화가 프레젠테이션 암호화 전에 비활성화되어 있었고, 프레젠테이션이 문서‑속성‑전용 모드로 로드된 경우 가능합니다.

**암호화된 PPTX 파일을 문서‑속성‑전용 모드에서 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호와 함께 전체 프레젠테이션을 로드해야 합니다.