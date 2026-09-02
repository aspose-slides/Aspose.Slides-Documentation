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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 프레젠테이션 속성을 완벽히 관리하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Application 및 AppVersion 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 해당 필드를 다시 작성하므로 저장된 프레젠테이션은 항상 "Aspose.Slides for Node.js via Java" 및 해당 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 사용하면 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음과 같이 두 종류가 있습니다.

- 시스템 정의(내장) 속성
- 사용자 정의(맞춤) 속성

**Built-in** 속성에는 문서 제목, 저자 이름, 문서 통계 등 일반적인 정보가 포함됩니다. **Custom** 속성은 사용자가 **이름/값** 쌍으로 정의한 것으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for Node.js via Java를 사용하면 개발자는 내장 속성과 맞춤 속성의 값을 모두 액세스하고 수정할 수 있습니다.

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있게 합니다. 아래와 같이 Office 아이콘을 클릭한 후 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다.

|**Advanced Properties 메뉴 항목 선택**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다.

|**속성 대화 상자**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

위 **속성 대화 상자**에서 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭 페이지가 표시됩니다. 각 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 합니다. **Custom** 탭은 PowerPoint 파일의 맞춤 속성을 관리하는 데 사용됩니다.

## **Aspose.Slides for Node.js via Java를 사용한 문서 속성 작업**

앞서 설명했듯이 Aspose.Slides for Node.js via Java는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for Node.js via Java API를 통해 두 종류의 속성에 모두 액세스할 수 있습니다. Aspose.Slides for Node.js via Java는 프레젠테이션 파일에 연결된 문서 속성을 나타내는 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 클래스를 제공합니다. 이 클래스는 **Presentation.DocumentProperties** 속성을 통해 사용할 수 있습니다.

개발자는 아래와 같이 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 객체가 노출하는 **DocumentProperties** 속성을 사용하여 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다.

## **Built-in 속성 액세스**

[DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 객체를 통해 노출되는 이러한 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 있습니다.

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

## **Built-in 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 방법은 해당 속성에 문자열 값을 할당하는 것만큼 간단합니다. 아래 예제에서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

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

이 예제는 수정된 내장 문서 속성을 아래와 같이 보여줍니다.

|**수정 후 내장 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **맞춤 문서 속성 추가**

Aspose.Slides for Node.js via Java를 사용하면 개발자는 프레젠테이션 문서 속성에 맞춤 값을 추가할 수 있습니다. 아래 예제는 프레젠테이션에 맞춤 속성을 설정하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 문서 속성 가져오기
    var dProps = pres.getDocumentProperties();
    // 맞춤 속성 추가
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 특정 인덱스의 속성 이름 가져오기
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 선택된 속성 제거
    dProps.removeCustomProperty(getPropertyName);
    // 프레젠테이션 저장
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**추가된 맞춤 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **맞춤 속성 액세스 및 수정**

Aspose.Slides for Node.js via Java를 사용하면 맞춤 속성의 값을 액세스하고 수정할 수 있습니다. 아래 예제는 프레젠테이션의 모든 맞춤 속성을 어떻게 액세스하고 수정할 수 있는지 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 맞춤 속성에 접근하고 수정합니다
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 맞춤 속성의 이름과 값을 표시합니다
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 맞춤 속성의 값을 수정합니다
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

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 맞춤 속성을 수정합니다. 아래 그림은 수정 전후의 맞춤 속성을 보여줍니다.

|**수정 전 맞춤 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**수정 후 맞춤 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}
새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), 및 [WriteBindedPresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-)이 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo)에 추가되었으며, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 속성 설정자의 로직이 변경되었습니다.
{{% /alert %}} 

두 새로운 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)와 [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)가 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo) 클래스에 추가되었습니다. 이 메서드들은 문서 속성에 빠르게 접근하고 전체 프레젠테이션을 로드하지 않고도 속성을 변경 및 업데이트할 수 있게 합니다.

일반적인 시나리오는 속성을 로드하고, 값을 변경한 뒤, 문서를 업데이트하는 것입니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션의 정보를 읽습니다
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

특정 프레젠테이션의 속성을 템플릿으로 사용하여 다른 프레젠테이션의 속성을 업데이트할 수도 있습니다:

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

새 템플릿을 처음부터 만들고 여러 프레젠테이션을 업데이트하는 방법:

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

## **교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 통해 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 맞춤법 및 문법 검사에 사용되는 언어입니다.

다음 JavaScript 코드는 PowerPoint의 교정 언어를 설정하는 방법을 보여줍니다: xxx 왜 JavaScript PortionFormat 클래스에 LanguageId가 누락되었나요?

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
    portionFormat.setLanguageId("zh-CN");// 교정 언어의 ID를 설정합니다
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **기본 언어 설정**

다음 JavaScript 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여줍니다:

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
    // 첫 번째 구문의 언어를 확인합니다
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **실시간 예제**

Aspose.Slides API를 통해 문서 속성을 작업하는 방법을 보려면 온라인 앱 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)를 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성의 값을 변경하거나 허용되는 경우 빈값으로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)를 사용한 뒤 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 만들지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 포맷별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/nodejs-java/examine-presentation/)을 참고하세요.